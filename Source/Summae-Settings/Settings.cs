namespace SummaeSettings {
    internal static class Settings {

        /// <summary>
        /// If this is set to true, no data will be written to registry.
        /// </summary>
        public static bool IsPortable {
            get { return !Medo.Configuration.Settings.Read("Installed", false); }
        }

    }
}
