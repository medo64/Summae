using Medo.Configuration;

namespace Summae {
    internal static class Settings {

        public static double ScaleBoost {
            get { return Config.Read("ScaleBoost", 0.00); }
        }

    }
}
