using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace SummaeExecutor {
    internal class SumItem {

        public SumItem(SumAlgorithmBase algorithm) {
            this.Algorithm = algorithm;
        }


        public SumAlgorithmBase Algorithm { get; private set; }
        public byte[] ExpectedResult { get; set; }
        public byte[] ExpectedResult2 { get; set; }

        public Label LabelControl { get; set; }
        public TextBox TextBoxControl { get; set; }
        public Button ButtonControl { get; set; }


        public bool AreResultsSame {
            get {
                if ((this.Algorithm.Result != null) && (this.ExpectedResult != null)) {
                    if (this.Algorithm.Result.Length == this.ExpectedResult.Length) {
                        for (int i = 0; i < this.Algorithm.Result.Length; ++i) {
                            if (this.Algorithm.Result[i] != this.ExpectedResult[i]) { return false; }
                        }
                        return true;
                    }
                }
                return false;
            }
        }

        public bool AreResultsSame2 {
            get {
                if ((this.Algorithm.Result != null) && (this.ExpectedResult2 != null)) {
                    if (this.Algorithm.Result.Length == this.ExpectedResult2.Length) {
                        for (int i = 0; i < this.Algorithm.Result.Length; ++i) {
                            if (this.Algorithm.Result[i] != this.ExpectedResult2[i]) { return false; }
                        }
                        return true;
                    }
                }
                return false;
            }
        }

        public bool AreResultsDifferent {
            get {
                if ((this.Algorithm.Result != null) && (this.ExpectedResult != null)) {
                    if (this.Algorithm.Result.Length == this.ExpectedResult.Length) {
                        for (int i = 0; i < this.Algorithm.Result.Length; ++i) {
                            if (this.Algorithm.Result[i] != this.ExpectedResult[i]) { return true; }
                        }
                        return false;
                    } else {
                        return true;
                    }
                }
                return false;
            }
        }


        public override string ToString() {
            return ToSpacedString();
        }

        public string ToSpacedString() {
            var sb = new StringBuilder();
            if ((this.Algorithm != null) && (this.Algorithm.Result != null)) {
                int step = 1;
                if ((this.Algorithm.Result.Length > 16) && ((this.Algorithm.Result.Length % 8) == 0)) {
                    step = 8;
                } else if ((this.Algorithm.Result.Length > 8) && ((this.Algorithm.Result.Length % 4) == 0)) {
                    step = 4;
                } else if ((this.Algorithm.Result.Length > 1) && ((this.Algorithm.Result.Length % 2) == 0)) {
                    step = 2;
                }

                for (int i = 0; i < this.Algorithm.Result.Length; ++i) {
                    if (sb.Length > 0) {
                        if ((i % step) == 0) {
                            sb.Append(" ");
                        }
                    }
                    sb.Append(this.Algorithm.Result[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }

        public string ToNonspacedString() {
            var sb = new StringBuilder();
            if ((this.Algorithm != null) && (this.Algorithm.Result != null)) {
                for (int i = 0; i < this.Algorithm.Result.Length; ++i) {
                    sb.Append(this.Algorithm.Result[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }


        public static byte[] GetExpectedResult(FileInfo file, SumAlgorithmBase algorithm) {
            string fileName = file.FullName + "." + algorithm.Name;
            if (File.Exists(fileName)) {
                try {
                    return GetExpectedResult(File.ReadAllText(fileName));
                } catch (IOException) {
                    return null;
                }
            } else {
                return null;
            }
        }

        public static byte[] GetExpectedResult(string text) {
            if (text == null) { return null; }
            var filteredText = new StringBuilder();
            foreach (char iChar in text) {
                if (char.IsWhiteSpace(iChar)) {
                } else {
                    if ("0123456789abcdefABCDEF".IndexOf(iChar) >= 0) {
                        filteredText.Append(iChar);
                    } else {
                        return null; //it is not a hex digit.
                    }
                }
            }
            var bytes = new List<byte>();
            if (filteredText.Length % 2 != 0) { filteredText.Insert(0, "0"); }
            var text2 = filteredText.ToString();
            for (int i = 0; i < text2.Length; i += 2) {
                bytes.Add(byte.Parse(text2.Substring(i, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture));
            }
            return bytes.ToArray();
        }

    }
}
