using Medo.Configuration;

namespace Summae {
    internal static class Settings {

        public static bool OnTop {
            get { return Config.Read("OnTop", false); }
            set { Config.Write("OnTop", value); }
        }

        public static double ScaleBoost {
            get { return Config.Read("ScaleBoost", 0.00); }
        }

    }
}
