using System.Security.Cryptography;

namespace Summae.HashAlgorithms {
    public class Sha256Sum : SumAlgorithmBase {

        private HashAlgorithm _algorithm;

        public Sha256Sum()
            : base("sha256", "SHA-256") {
            this._algorithm = new SHA256Managed();
            base.ResultByteCount = this._algorithm.HashSize / 8;
        }


        public override void TransformBlock(byte[] buffer, int offset, int count) {
            this._algorithm.TransformBlock(buffer, 0, count, null, 0);
        }

        public override void TransformFinalBlock(byte[] buffer, int offset, int count) {
            this._algorithm.TransformFinalBlock(buffer, 0, count);
        }

        public override byte[] Result {
            get { return this._algorithm.Hash; }
        }

    }
}
