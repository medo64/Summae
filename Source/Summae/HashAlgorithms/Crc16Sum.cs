using System;
using System.Collections.Generic;
using Medo.Security.Checksum;

namespace Summae.HashAlgorithms {
    public class Crc16Sum : SumAlgorithmBase {

        private Crc16 _algorithm;

        public Crc16Sum()
            : base("crc16", "CRC-16") {
            this._algorithm = new Crc16();
            base.ResultByteCount = 2;
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
