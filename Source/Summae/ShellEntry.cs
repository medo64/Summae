using System;
using System.Collections.Generic;

namespace Summae {
    internal class ShellEntry {

        private ShellEntry(string name, string title) {
            this.Name = name;
            this.Title = title;
        }

        public string Name { get; }
        public string Title { get; }


        public static ShellEntry GetEntry(string name) {
            foreach (var entry in AllEntries) {
                if (string.Equals(entry.Name, name, StringComparison.Ordinal)) { return entry; }
            }
            return null;
        }

        public static IEnumerable<ShellEntry> AllEntries {
            get {
                yield return Crc16;
                yield return Crc32;
                yield return Md5;
                yield return RipeMd160;
                yield return Sha1;
                yield return Sha256;
                yield return Sha384;
                yield return Sha512;
            }
        }

        public static ShellEntry Crc16 { get; } = new ShellEntry("Crc16", "CRC-16");
        public static ShellEntry Crc32 { get; } = new ShellEntry("Crc32", "CRC-32");
        public static ShellEntry Md5 { get; } = new ShellEntry("Md5", "MD-5");
        public static ShellEntry RipeMd160 { get; } = new ShellEntry("RipeMd160", "RIPE MD-160");
        public static ShellEntry Sha1 { get; } = new ShellEntry("Sha1", "SHA-1");
        public static ShellEntry Sha256 { get; } = new ShellEntry("Sha256", "SHA-256");
        public static ShellEntry Sha384 { get; } = new ShellEntry("Sha384", "SHA-384");
        public static ShellEntry Sha512 { get; } = new ShellEntry("Sha512", "SHA-512");

    }
}
