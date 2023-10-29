using HarmonyLib;
using Reptile;

namespace BoostColors.Patches
{
    [HarmonyPatch(typeof(BaseModule), "HandleStageFullyLoaded")]
    public class BaseModule_HandleStageFullyLoaded_Patch
    {
        public static void Postfix()
        {
            Core.Instance.FindVFX();
            Core.Instance.SetTextures();
            Core.Instance.SetColors(Core.configPrimaryColor.Value, Core.configSecondaryColor.Value);
            Core.Instance.ui.SetTrickingChargeBarActive(false);
        }
    }
}
