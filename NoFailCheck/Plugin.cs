using IPA;
using Logger = IPA.Logging.Logger;
using HarmonyLib;
using BS_Utils.Utilities;
using BeatSaberMarkupLanguage.Settings;
using IPA.Config.Stores;
using NoFailCheck.UI;
using Config = IPA.Config.Config;

namespace NoFailCheck
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public static SemVer.Version Version => IPA.Loader.PluginManager.GetPlugin("NoFailCheck").Version;

        internal static Harmony harmony;

        public static Logger Log { get; internal set; }

        internal static Settings cfg;

        [Init]
        public void Init(Logger log, Config conf)
        {
            Log = log;
            cfg = conf.Generated<Settings>();
        }

        [OnStart]
        public void OnStart()
        {
            harmony = new Harmony("com.nate1280.BeatSaber.NoFailCheck");
            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());

            BSEvents.OnLoad();
            BSEvents.lateMenuSceneLoadedFresh += lateMenuSceneLoadedFresh;
        }

        private void lateMenuSceneLoadedFresh(ScenesTransitionSetupDataSO obj)
        {
            // add BSML mod settings
            BSMLSettings.instance.AddSettingsMenu("NoFail Check", "NoFailCheck.Views.NoFailCheckSettings.bsml", NoFailCheckSettings.instance);

            // load main mod
            NoFailCheck.Instance.OnLoad();
        }

        [OnExit]
        public void OnExit()
        {
            harmony.UnpatchSelf();
        }
    }
}
