using BeatSaberMarkupLanguage.Attributes;

namespace NoFailCheck.UI
{
    public class NoFailCheckSettings : PersistentSingleton<NoFailCheckSettings>
    {
        [UIValue("enabled")]
        public bool Enabled
        {
            get => Plugin.Config.Enabled;
            set => Plugin.Config.Enabled = value;
        }

        [UIValue("double-press")]
        public bool DoublePress
        {
            get => Plugin.Config.DoublePress;
            set => Plugin.Config.DoublePress = value;
        }

        [UIValue("change-text")]
        public bool ChangeText
        {
            get => Plugin.Config.ChangeText;
            set => Plugin.Config.ChangeText = value;
        }
    }
}
