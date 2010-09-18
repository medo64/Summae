﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace SummaeExecutor {
    internal class Sha512Sum : SumAlgorithmBase {

        private HashAlgorithm _algorithm;

        public Sha512Sum()
            : base("sha512", "SHA-512") {
            this._algorithm = new SHA512Managed();
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
