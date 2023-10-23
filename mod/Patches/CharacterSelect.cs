using HarmonyLib;
using Reptile;

namespace BoostColors.Patches
{
    [HarmonyPatch(typeof(CharacterSelect), "SetPlayerToCharacter")]
    public class CharacterSelect_SetPlayerToCharacter_Patch
    {
        public static void Postfix()
        {
            Core.Instance.FindVFX();
            Core.Instance.SetTextures();
            Core.Instance.SetVFXColors(Core.configPrimaryColor.Value, Core.configSecondaryColor.Value);
        }
    }
}
