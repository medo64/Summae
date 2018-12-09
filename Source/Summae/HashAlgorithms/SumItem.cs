using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Summae.HashAlgorithms {
    public class SumItem {

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
                        for (var i = 0; i < this.Algorithm.Result.Length; ++i) {
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
                        for (var i = 0; i < this.Algorithm.Result.Length; ++i) {
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
                        for (var i = 0; i < this.Algorithm.Result.Length; ++i) {
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
                var step = 1;
                if ((this.Algorithm.Result.Length > 16) && ((this.Algorithm.Result.Length % 8) == 0)) {
                    step = 8;
                } else if ((this.Algorithm.Result.Length > 8) && ((this.Algorithm.Result.Length % 4) == 0)) {
                    step = 4;
                } else if ((this.Algorithm.Result.Length > 1) && ((this.Algorithm.Result.Length % 2) == 0)) {
                    step = 2;
                }

                for (var i = 0; i < this.Algorithm.Result.Length; ++i) {
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
                for (var i = 0; i < this.Algorithm.Result.Length; ++i) {
                    sb.Append(this.Algorithm.Result[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }


        public static byte[] GetExpectedResult(FileInfo file, SumAlgorithmBase algorithm) {
            var fileName = file.FullName + "." + algorithm.Name;
            if (File.Exists(fileName)) {
                try {
                    return GetExpectedResult(File.ReadAllText(fileName));
                } catch { }
            } else {
                var names = new List<string> {
                    Path.Combine(file.DirectoryName, algorithm.Name + "sum.txt"),
                    Path.Combine(file.DirectoryName, algorithm.Name + "sums.txt"),
                    Path.Combine(file.DirectoryName, algorithm.Name + "sum.txt.asc"),
                    Path.Combine(file.DirectoryName, "sum.txt"),
                    Path.Combine(file.DirectoryName, "sums.txt")
                };
                foreach (var sumFile in file.Directory.GetFiles("*." + algorithm.Name)) {
                    names.Add(sumFile.FullName);
                }
                foreach (var name in names) {
                    try {
                        if (File.Exists(name)) {
                            var resultRow = GetExpectedResultRow(file, File.ReadAllText(name));
                            if (resultRow != null) {
                                var result = GetExpectedResult(resultRow);
                                if (result != null) { return result; }
                            }
                        }
                    } catch { }
                }
            }
            return null;
        }

        private static string GetExpectedResultRow(FileInfo file, string fileContent) {
            var rows = fileContent.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows) {
                var columns = row.Split(new char[] { ' ', '\t' }, 2, StringSplitOptions.None);
                var col1 = columns[0].Trim(new char[] { ' ', '\t', '*' });
                var col2 = columns[1].Trim(new char[] { ' ', '\t', '*' });
                if (col1.Equals(file.Name, StringComparison.InvariantCultureIgnoreCase)) {
                    return col2;
                } else if (col2.Equals(file.Name, StringComparison.InvariantCultureIgnoreCase)) {
                    return col1;
                }
            }
            return null;
        }

        public static byte[] GetExpectedResult(string text) {
            if (text == null) { return null; }
            var filteredText = new StringBuilder();
            foreach (var iChar in text) {
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
            for (var i = 0; i < text2.Length; i += 2) {
                bytes.Add(byte.Parse(text2.Substring(i, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture));
            }
            return bytes.ToArray();
        }

    }
}
