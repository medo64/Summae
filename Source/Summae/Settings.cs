using System;

namespace Summae {
    internal static class Settings {

        public static double ScaleBoost {
            get { return Medo.Configuration.Settings.Read("ScaleBoost", 0.00); }
        }

    }
}