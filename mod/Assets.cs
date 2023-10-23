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
            switch (color)
            {
                case BoostColor.Red:
                    return bundle.LoadAsset<Texture>("assets/boostRedTex.png");
                case BoostColor.Orange:
                    return bundle.LoadAsset<Texture>("assets/boostOrangeTex.png");
                case BoostColor.Yellow:
                    return bundle.LoadAsset<Texture>("assets/boostYellowTex.png");
                case BoostColor.Green:
                    return bundle.LoadAsset<Texture>("assets/boostGreenTex.png");
                case BoostColor.LightBlue:
                    return bundle.LoadAsset<Texture>("assets/boostLightBlueTex.png");
                case BoostColor.Blue:
                    return bundle.LoadAsset<Texture>("assets/boostBlueTex.png");
                case BoostColor.Purple:
                    return bundle.LoadAsset<Texture>("assets/boostPurpleTex.png");
                case BoostColor.Pink:
                    return bundle.LoadAsset<Texture>("assets/boostPinkTex.png");
                default:
                    return bundle.LoadAsset<Texture>("assets/boostLightBlueTex.png");
            }
        }

        public static Texture GetTrailTexture(BoostColor color)
        {
            switch (color)
            {
                case BoostColor.Red:
                    return bundle.LoadAsset<Texture>("assets/RedToAlpha.png");
                case BoostColor.Orange:
                    return bundle.LoadAsset<Texture>("assets/OrangeToAlpha.png");
                case BoostColor.Yellow:
                    return bundle.LoadAsset<Texture>("assets/YellowToAlpha.png");
                case BoostColor.Green:
                    return bundle.LoadAsset<Texture>("assets/GreenToAlpha.png");
                case BoostColor.LightBlue:
                    return bundle.LoadAsset<Texture>("assets/LightBlueToAlpha.png");
                case BoostColor.Blue:
                    return bundle.LoadAsset<Texture>("assets/BlueToAlpha.png");
                case BoostColor.Purple:
                    return bundle.LoadAsset<Texture>("assets/PurpleToAlpha.png");
                case BoostColor.Pink:
                    return bundle.LoadAsset<Texture>("assets/PinkToAlpha.png");
                default:
                    return bundle.LoadAsset<Texture>("assets/YellowToAlpha.png");
            }
        }

        public static float GetSwirlColorIndex(BoostColor color)
        {
            switch (color)
            {
                case BoostColor.Red:
                    return 0.01f;
                case BoostColor.Orange:
                    return 0.13f;
                case BoostColor.Yellow:
                    return 0.26f;
                case BoostColor.Green:
                    return 0.38f;
                case BoostColor.LightBlue:
                    return 0.52f;
                case BoostColor.Blue:
                    return 0.64f;
                case BoostColor.Purple:
                    return 0.8f;
                case BoostColor.Pink:
                    return 0.9f;
                default:
                    return 0.52f;
            }
        }

        public static Vector2 GetFrictionColorOffset(BoostColor color)
        {
            switch (color)
            {
                case BoostColor.Red:
                    return new Vector2(0.01f, 0);
                case BoostColor.Orange:
                    return new Vector2(0.01f, -0.16f);
                case BoostColor.Yellow:
                    return new Vector2(0.01f, -0.32f);
                case BoostColor.Green:
                    return new Vector2(0.01f, -0.48f);
                case BoostColor.LightBlue:
                    return new Vector2(0.33f, 0);
                case BoostColor.Blue:
                    return new Vector2(0.33f, -0.16f);
                case BoostColor.Purple:
                    return new Vector2(0.33f, -0.32f);
                case BoostColor.Pink:
                    return new Vector2(0.33f, -0.48f);
                default:
                    return new Vector2(0.33f, 0);
            }
        }
    }
}
