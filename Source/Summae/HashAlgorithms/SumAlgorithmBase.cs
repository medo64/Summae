using System;
using System.Diagnostics;

namespace Summae.HashAlgorithms {
    public abstract class SumAlgorithmBase {

        protected SumAlgorithmBase(string name, string displayName) {
            this.Name = name;
            this.DisplayName = displayName;
        }

        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public int ResultByteCount { get; protected set; }

        public abstract void TransformBlock(byte[] buffer, int offset, int count);
        public abstract void TransformFinalBlock(byte[] buffer, int offset, int count);
        public abstract byte[] Result { get; }


        public static SumAlgorithmBase GetAlgorithmByName(string name) { 
            SumAlgorithmBase result = null;
            
            if (string.Compare(name, "CRC16", StringComparison.OrdinalIgnoreCase) == 0) {
                result = new Crc16Sum();
            } else if (string.Compare(name, "CRC32", StringComparison.OrdinalIgnoreCase) == 0) {
                result = new Crc32Sum();
            } else if (string.Compare(name, "MD5", StringComparison.OrdinalIgnoreCase) == 0) {
                result = new Md5Sum();
            } else if (string.Compare(name, "RIPEMD160", StringComparison.OrdinalIgnoreCase) == 0) {
                result = new RipeMd160Sum();
            } else if (string.Compare(name, "SHA1", StringComparison.OrdinalIgnoreCase) == 0) {
                result = new Sha1Sum();
            } else if (string.Compare(name, "SHA256", StringComparison.OrdinalIgnoreCase) == 0) {
                result = new Sha256Sum();
            } else if (string.Compare(name, "SHA384", StringComparison.OrdinalIgnoreCase) == 0) {
                result = new Sha384Sum();
            } else if (string.Compare(name, "SHA512", StringComparison.OrdinalIgnoreCase) == 0) {
                result = new Sha512Sum();
            }

            if (result != null) {
                Debug.Assert(string.Compare(name, result.Name, StringComparison.OrdinalIgnoreCase) == 0);
            }
            return result;
        }
    }
}
