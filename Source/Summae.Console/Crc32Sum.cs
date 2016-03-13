using System;
using System.Collections.Generic;
using Medo.Security.Checksum;

namespace HashAlgorithms {
    public class Crc32Sum : SumAlgorithmBase {

        private Crc32 _algorithm;

        public Crc32Sum()
            : base("crc32", "CRC-32") {
            this._algorithm = new Crc32();
            base.ResultByteCount = 4;
        }


        public override void TransformBlock(byte[] buffer, int offset, int count) {
            this._algorithm.Append(buffer, 0, count);
        }

        public override void TransformFinalBlock(byte[] buffer, int offset, int count) {
            this._algorithm.Append(buffer, 0, count);
        }

        public override byte[] Result {
            get {
                var bytes = new List<byte>(System.BitConverter.GetBytes(this._algorithm.Digest));
                if (BitConverter.IsLittleEndian) {
                    bytes.Reverse(0, bytes.Count);
                }
                return bytes.ToArray();
            }
        }

    }
}
