using HarmonyLib;
using Reptile;

namespace BoostColors.Patches
{
    [HarmonyPatch(typeof(Player), "SetCharacter")]
    public class Player_SetCharacter_Patch
    {
        public static void Postfix(Player __instance, Characters setChar, int setOutfit = 0)
        {
            if (Reptile.Core.Instance.BaseModule.IsLoading) return;
            if (!Traverse.Create(__instance).Field<bool>("isAI").Value)
            {
                Core.Instance.FindVFX();
                Core.Instance.SetTextures();
                Core.Instance.SetColors(Core.configPrimaryColor.Value, Core.configSecondaryColor.Value);
            }
        }
    }
}
