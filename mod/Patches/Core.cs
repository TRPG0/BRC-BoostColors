using HarmonyLib;
using Reptile;

namespace BoostColors.Patches
{
    [HarmonyPatch(typeof(Reptile.Core), "OnApplicationFocus")]
    public class Core_OnApplicationFocus_Patch
    {
        public static void Prefix(bool focus)
        {
            if (focus)
            {
                Core.Instance.Config.Reload();
                if (Reptile.Core.Instance.BaseModule.IsPlayingInStage)
                {
                    Core.Instance.SetColors(Core.configPrimaryColor.Value, Core.configSecondaryColor.Value);
                    if (WorldHandler.instance.GetCurrentPlayer().IsComboing()) Core.Instance.ui.SetTrickingChargeBarActive(true);
                    else Core.Instance.ui.SetTrickingChargeBarActive(false);
                }
            }
        }
    }
}
