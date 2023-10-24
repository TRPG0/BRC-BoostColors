using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using Reptile;
using HarmonyLib;
using BepInEx.Logging;
using BoostColors.Patches;
using BepInEx.Configuration;

namespace BoostColors
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Core : BaseUnityPlugin
    {
        public const string PluginGUID = "trpg.brc.boostcolors";
        public const string PluginName = "BoostColors";
        public const string PluginVersion = "1.0.1";

        public static Core Instance;
        public static new ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource("BoostColors");

        public static ConfigEntry<BoostColor> configPrimaryColor;
        public static ConfigEntry<BoostColor> configSecondaryColor;

        public GameplayUI ui;
        public Image chargeBar;
        public SkinnedMeshRenderer boostpackPrimaryEffect;
        public SkinnedMeshRenderer boostpackSecondaryEffect;
        public TrailRenderer boostpackTrail;
        public SkinnedMeshRenderer frictionPrimaryEffect1;
        public SkinnedMeshRenderer frictionPrimaryEffect2;
        public SkinnedMeshRenderer frictionSecondaryEffect1;
        public SkinnedMeshRenderer frictionSecondaryEffect2;

        private void Awake()
        {
            Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} is loaded.");
            Instance = this;

            Harmony Harmony = new Harmony("BoostColors");
            Harmony.PatchAll(typeof(BaseModule_HandleStageFullyLoaded_Patch));
            Harmony.PatchAll(typeof(Player_SetCharacter_Patch));
            Harmony.PatchAll(typeof(Core_OnApplicationFocus_Patch));

            configPrimaryColor = Config.Bind("Colors",
                "configPrimaryColor",
                BoostColor.Yellow,
                "Primary boost color");

            configSecondaryColor = Config.Bind("Colors",
                "configSecondaryColor",
                BoostColor.LightBlue,
                "Secondary boost color");
        }

        public void FindVFX()
        {
            if (!Reptile.Core.Instance.BaseModule.IsPlayingInStage) return;

            Player player = WorldHandler.instance.GetCurrentPlayer();
            Traverse playerT = Traverse.Create(player);
            PlayerVisualEffects vfx = playerT.Field<CharacterVisual>("characterVisual").Value.VFX;

            ui = playerT.Field<GameplayUI>("ui").Value;
            chargeBar = ui.chargeBar;
            boostpackPrimaryEffect = vfx.boostpackEffect.transform.Find("boostMesh").GetComponent<SkinnedMeshRenderer>();
            boostpackSecondaryEffect = vfx.boostpackBlueEffect.transform.Find("boostMesh").GetComponent<SkinnedMeshRenderer>();
            boostpackTrail = vfx.boostpackTrail.GetComponent<TrailRenderer>();
            frictionPrimaryEffect1 = vfx.frictionEffect.transform.Find("Cylinder015").GetComponent<SkinnedMeshRenderer>();
            frictionPrimaryEffect2 = vfx.frictionEffect.transform.Find("Cylinder016").GetComponent<SkinnedMeshRenderer>();
            frictionSecondaryEffect1 = vfx.frictionBlueEffect.transform.Find("Cylinder015").GetComponent<SkinnedMeshRenderer>();
            frictionSecondaryEffect2 = vfx.frictionBlueEffect.transform.Find("Cylinder016").GetComponent<SkinnedMeshRenderer>();
        }

        public void SetTextures()
        {
            if (frictionSecondaryEffect2 == null)
            {
                Logger.LogWarning("Not all VFX components were found.");
                return;
            }

            chargeBar.material.SetTexture("_ColorTex", Assets.SwirlColorPalletes);
            frictionPrimaryEffect1.material.SetTexture("_MainTex", Assets.effectTex);
            frictionPrimaryEffect2.material.SetTexture("_MainTex", Assets.effectTex);
            frictionSecondaryEffect1.material.SetTexture("_MainTex", Assets.effectTex);
            frictionSecondaryEffect2.material.SetTexture("_MainTex", Assets.effectTex);
        }

        public void SetVFXColors(BoostColor primary, BoostColor secondary)
        {
            if (!Reptile.Core.Instance.BaseModule.IsPlayingInStage)
            {
                Logger.LogWarning("Can't set VFX colors because player is not currently in stage.");
                return;
            }
            else if (frictionSecondaryEffect2 == null)
            {
                Logger.LogWarning("Not all VFX components were found.");
                return;
            }

            Logger.LogInfo($"Setting colors ({primary}, {secondary})");
            SetBarPrimaryColor(primary);
            SetBarSecondaryColor(secondary);
            SetBoostPrimaryColor(primary);
            SetBoostSecondaryColor(secondary);
            SetBoostTrailColor(primary);
            SetFrictionPrimaryColor(primary);
            SetFrictionSecondaryColor(secondary);
        }

        public void SetBarPrimaryColor(BoostColor color)
        {
            if (chargeBar == null)
            {
                Logger.LogWarning("Can't set charge bar color because chargeBar is null!");
                return;
            }

            ui.chargeBarTrickingColorIndex = Assets.GetSwirlColorIndex(color);
        }

        public void SetBarSecondaryColor(BoostColor color)
        {
            if (chargeBar == null)
            {
                Logger.LogWarning("Can't set charge bar color because chargeBar is null!");
                return;
            }

            ui.chargeBarDefaultColorIndex = Assets.GetSwirlColorIndex(color);
        }

        public void SetBoostPrimaryColor(BoostColor color)
        {
            if (boostpackPrimaryEffect == null)
            {
                Logger.LogWarning("Can't set boost primary color because boostpackPrimaryEffect is null!");
                return;
            }

            boostpackPrimaryEffect.material.SetTexture("_ScreenSpaceTexture", Assets.GetBoostpackTexture(color));
        }

        public void SetBoostSecondaryColor(BoostColor color)
        {
            if (boostpackSecondaryEffect == null)
            {
                Logger.LogWarning("Can't set boost secondary color because boostpackSecondaryEffect is null!");
                return;
            }

            boostpackSecondaryEffect.material.SetTexture("_ScreenSpaceTexture", Assets.GetBoostpackTexture(color));
        }

        public void SetBoostTrailColor(BoostColor color)
        {
            if (boostpackTrail == null)
            {
                Logger.LogWarning("Can't set boost trail color because boostpackTrail is null!");
                return;
            }

            boostpackTrail.material.SetTexture("_MainTex", Assets.GetTrailTexture(color));
        }

        public void SetFrictionPrimaryColor(BoostColor color)
        {
            if (frictionPrimaryEffect1 == null || frictionPrimaryEffect2 == null)
            {
                Logger.LogWarning("Can't set friction primary color because a SkinnedMeshRenderer is null!");
                return;
            }

            frictionPrimaryEffect1.material.mainTextureOffset = Assets.GetFrictionColorOffset(color);
            frictionPrimaryEffect2.material.mainTextureOffset = Assets.GetFrictionColorOffset(color);
        }

        public void SetFrictionSecondaryColor(BoostColor color)
        {
            if (frictionSecondaryEffect1 == null || frictionSecondaryEffect2 == null)
            {
                Logger.LogWarning("Can't set friction secondary color because a SkinnedMeshRenderer is null!");
                return;
            }

            frictionSecondaryEffect1.material.mainTextureOffset = Assets.GetFrictionColorOffset(color);
            frictionSecondaryEffect2.material.mainTextureOffset = Assets.GetFrictionColorOffset(color);
        }

        // only made this for use in UnityExplorer because it can't comprehend the swirls (neither can I)
        public Material GetImageMaterial(Image image)
        {
            return image.material;
        }
    }

    public enum BoostColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        LightBlue,
        Blue,
        Purple,
        Pink
    }
}
