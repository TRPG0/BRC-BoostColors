using UnityEngine;

namespace BoostColors
{
    public static class Assets
    {
        public static AssetBundle bundle = AssetBundle.LoadFromMemory(Properties.Resources.boostcolors);
        public static Texture SwirlColorPalletes = bundle.LoadAsset<Texture>("assets/SwirlColorPalletes.png");
        public static Texture effectTex = bundle.LoadAsset<Texture>("assets/effectTex.png");

        public static Texture GetBoostpackTexture(BoostColor color)
        {
            return bundle.LoadAsset<Texture>($"assets/boost{color}Tex.png");
        }

        public static Texture GetTrailTexture(BoostColor color)
        {
            return bundle.LoadAsset<Texture>($"assets/{color}ToAlpha.png");
        }

        public static float GetSwirlColorIndex(BoostColor color)
        {
            return color switch
            {
                BoostColor.Red => 0.031f,
                BoostColor.Orange => 0.094f,
                BoostColor.Yellow => 0.157f,
                BoostColor.Lime => 0.219f,
                BoostColor.Green => 0.281f,
                BoostColor.Teal => 0.344f,
                BoostColor.LightBlue => 0.406f,
                BoostColor.Blue => 0.469f,
                BoostColor.DarkBlue => 0.531f,
                BoostColor.Indigo => 0.594f,
                BoostColor.Purple => 0.656f,
                BoostColor.Magenta => 0.719f,
                BoostColor.Pink => 0.781f,
                BoostColor.White => 0.844f,
                BoostColor.Gray => 0.906f,
                BoostColor.Black => 0.969f,
                _ => 0.406f
            };
        }

        public static Vector2 GetFrictionColorOffset(BoostColor color)
        {
            return color switch
            {
                BoostColor.Red => new Vector2(0.01f, 0),
                BoostColor.Orange => new Vector2(0.01f, -0.16f),
                BoostColor.Yellow => new Vector2(0.01f, -0.32f),
                BoostColor.Lime => new Vector2(0.01f, -0.48f),
                BoostColor.Green => new Vector2(0.01f, -0.64f),
                BoostColor.Teal => new Vector2(0.01f, -0.8f),
                BoostColor.LightBlue => new Vector2(0.33f, 0),
                BoostColor.Blue => new Vector2(0.33f, -0.16f),
                BoostColor.DarkBlue => new Vector2(0.33f, -0.32f),
                BoostColor.Indigo => new Vector2(0.33f, -0.48f),
                BoostColor.Purple => new Vector2(0.33f, -0.64f),
                BoostColor.Magenta => new Vector2(0.66f, 0),
                BoostColor.Pink => new Vector2(0.66f, -0.16f),
                BoostColor.White => new Vector2(0.66f, -0.32f),
                BoostColor.Gray => new Vector2(0.66f, -0.48f),
                BoostColor.Black => new Vector2(0.66f, -0.64f),
                _ => new Vector2(0.33f, 0)
            };
        }

        public static Sprite GetComboFillSprite(BoostColor color)
        {
            if (Core.configSetUIColors.Value == false) return bundle.LoadAsset<Sprite>("assets/comboTimerFill.png");
            else return bundle.LoadAsset<Sprite>($"assets/comboTimerFill{color}.png");
        }

        public static Sprite GetComboBGSprite(BoostColor color)
        {
            if (Core.configSetUIColors.Value == false) return bundle.LoadAsset<Sprite>("assets/comboTimerBG.png");
            else return bundle.LoadAsset<Sprite>($"assets/comboTimerBG{color}.png");
        }

        public static Color32 GetTextFaceColor(BoostColor color)
        {
            if (Core.configSetUIColors.Value == false) return new Color32(244, 211, 66, 255);
            else return color switch
            {
                BoostColor.Red => new Color32(244, 84, 66, 255),
                BoostColor.Orange => new Color32(244, 146, 66, 255),
                BoostColor.Yellow => new Color32(244, 211, 66, 255),
                BoostColor.Lime => new Color32(196, 244, 65, 255),
                BoostColor.Green => new Color32(119, 244, 66, 255),
                BoostColor.Teal => new Color32(65, 244, 163, 255),
                BoostColor.LightBlue => new Color32(66, 226, 244, 255),
                BoostColor.Blue => new Color32(0, 165, 255, 255),
                BoostColor.DarkBlue => new Color32(66, 84, 245, 255),
                BoostColor.Indigo => new Color32(118, 0, 255, 255),
                BoostColor.Purple => new Color32(191, 66, 245, 255),
                BoostColor.Magenta => new Color32(245, 66, 135, 255),
                BoostColor.Pink => new Color32(247, 116, 201, 255),
                BoostColor.White => new Color32(229, 229, 229, 255),
                BoostColor.Gray => new Color32(127, 127, 127, 255),
                BoostColor.Black => new Color32(36, 36, 36, 255),
                _ => new Color32(244, 211, 66, 255)
            };
        }

        public static Color32 GetTextOutlineColor(BoostColor color)
        {
            if (Core.configSetUIColors.Value == false) return new Color32(34, 27, 13, 255);
            return color switch
            {
                BoostColor.Red => new Color32(33, 15, 13, 255),
                BoostColor.Orange => new Color32(33, 26, 13, 255),
                BoostColor.Yellow => new Color32(34, 27, 13, 255),
                BoostColor.Lime => new Color32(28, 33, 13, 255),
                BoostColor.Green => new Color32(15, 33, 13, 255),
                BoostColor.Teal => new Color32(13, 33, 24, 255),
                BoostColor.LightBlue => new Color32(13, 31, 33, 255),
                BoostColor.Blue => new Color32(13, 26, 33, 255),
                BoostColor.DarkBlue => new Color32(13, 15, 33, 255),
                BoostColor.Indigo => new Color32(22, 13, 33, 255),
                BoostColor.Purple => new Color32(27, 13, 33, 255),
                BoostColor.Magenta => new Color32(33, 13, 20, 255),
                BoostColor.Pink => new Color32(33, 13, 26, 255),
                BoostColor.White => new Color32(33, 33, 33, 255),
                BoostColor.Gray => new Color32(16, 16, 16, 255),
                BoostColor.Black => new Color32(127, 127, 127, 255),
                _ => new Color32(34, 27, 13, 255)
            };
        }
    }
}
