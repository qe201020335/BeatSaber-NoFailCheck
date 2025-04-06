using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace NoFailCheck
{
    internal class Settings
    {
        public bool Enabled { get; set; } = true;
        public bool DoublePress { get; set; } = true;
        public bool ChangeText { get; set; } = true;
    }
}