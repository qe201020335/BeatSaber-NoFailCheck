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
        private readonly Harmony _harmony = new Harmony("com.nate1280.BeatSaber.NoFailCheck");

        public static Logger Log { get; private set; }

        internal static Settings Config {get; private set;}

        [Init]
        public void Init(Logger log, Config conf)
        {
            Log = log;
            Config = conf.Generated<Settings>();
        }

        [OnStart]
        public void OnStart()
        {
            _harmony.PatchAll();

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
            _harmony.UnpatchSelf();
        }
    }
}
