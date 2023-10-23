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
                Core.Instance.SetVFXColors(Core.configPrimaryColor.Value, Core.configSecondaryColor.Value);
            }
        }
    }
}
