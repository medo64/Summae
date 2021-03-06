using Medo.Configuration;

namespace Summae {
    internal static class Settings {

        public static bool OnTop {
            get { return Config.Read("OnTop", false); }
            set { Config.Write("OnTop", value); }
        }

        public static bool SpacedHash {
            get { return Config.Read("SpacedHash", false); }
            set { Config.Write("SpacedHash", value); }
        }

        public static bool UppercaseHash {
            get { return Config.Read("UppercaseHash", false); }
            set { Config.Write("UppercaseHash", value); }
        }

        public static double ScaleBoost {
            get { return Config.Read("ScaleBoost", 0.00); }
        }

    }
}
