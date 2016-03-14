using System.Security.Cryptography;

namespace Summae.HashAlgorithms {
    public class Sha384Sum : SumAlgorithmBase {

        private HashAlgorithm _algorithm;

        public Sha384Sum()
            : base("sha384", "SHA-384") {
            this._algorithm = new SHA384Managed();
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
