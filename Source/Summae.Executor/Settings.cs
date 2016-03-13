using System;
using System.Collections.Generic;
using System.Text;

namespace SummaeExecutor {
    internal static class Settings {

        /// <summary>
        /// If this is set to true, no data will be written to registry.
        /// </summary>
        public static bool IsPortable {
            get { return !Medo.Configuration.Settings.Read("Installed", false); } 
        }

    }
}
