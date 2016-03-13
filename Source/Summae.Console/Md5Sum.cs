using System.Security.Cryptography;

namespace HashAlgorithms {
    public class Md5Sum : SumAlgorithmBase {

        private HashAlgorithm _algorithm;

        public Md5Sum()
            : base("md5", "MD-5") {
            this._algorithm = new MD5CryptoServiceProvider();
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
