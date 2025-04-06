using HarmonyLib;

namespace NoFailCheck.HarmonyPatches
{
    [HarmonyPatch(typeof(LevelSelectionFlowCoordinator))]
    [HarmonyPatch("HandleLevelSelectionNavigationControllerDidPressActionButton", MethodType.Normal)]
    class SoloFreePlayFlowCoordinatorPatches
    {
        static bool Prefix(LevelSelectionNavigationController viewController)
        {
            if (Plugin.Config.Enabled && NoFailCheck.IsInSoloFreeplay)
            {
                if (NoFailCheck.NoFailEnabled)
                {
                    if (Plugin.Config.DoublePress && NoFailCheck.NoFailPressCount == 0)
                    {
                        NoFailCheck.NoFailPressCount++;
                        return false;
                    }
                    else if (Plugin.Config.DoublePress && NoFailCheck.NoFailPressCount == 1)
                    {
                        NoFailCheck.NoFailPressCount = 0;
                    }
                }
            }
            return true;
        }
    }
}
