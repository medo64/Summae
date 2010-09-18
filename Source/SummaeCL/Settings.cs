using System;
using System.Collections.Generic;
using System.Text;

namespace SummaeCL {
    internal static class Settings {

        /// <summary>
        /// If this is set to true, no data will be written to registry.
        /// </summary>
        public static bool IsPortable { 
            get { return Medo.Configuration.Settings.Read("Portable", false); } 
        }

    }
}
