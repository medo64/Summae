using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Summae.HashAlgorithms;

namespace Summae {
    internal partial class CalculateForm : Form {

        private FileInfo _file;
        private IList<SumItem> _items;

        internal CalculateForm(FileInfo file, IList<SumItem> items) {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            this.Cursor = Cursors.WaitCursor;

            this._file = file;
            this._items = items;

            this.Text = this._file.Name + " - " + this.Text;

            int dluW, dluH;
            using (var graphics = this.CreateGraphics()) {
                var fewCharSize = graphics.MeasureString("0123456789abcdef", SystemFonts.MessageBoxFont);
                dluW = (int)System.Math.Ceiling(fewCharSize.Width / 16);
                dluH = (int)System.Math.Ceiling(fewCharSize.Height);
            }

            if (items != null) {
                int labelWidth = 8 * dluW;
                int textWidth = 32 * dluW;
                foreach (var iItem in items) {
                    int lw = iItem.Algorithm.DisplayName.Length * dluW;
                    if (labelWidth < lw) { labelWidth = lw; }

                    int tw = (int)(iItem.Algorithm.ResultByteCount * 2 + 3) * dluW;
                    if (textWidth < tw) { textWidth = tw; }
                }
                var screenRect = Screen.GetBounds(this);
                if ((labelWidth + textWidth) > screenRect.Width) {
                    labelWidth = (screenRect.Width / 10) * 1;
                    textWidth = (screenRect.Width / 10) * 8;
                }


                textFileName.Top = dluW;
                textFileName.Left = dluW + labelWidth + dluW;
                textFileName.Width = textWidth + textFileName.Height;
                textFileName.ReadOnly = true;
                textFileName.Text = this._file.FullName;
                textFileName.SelectionStart = textFileName.Text.Length;
                textFileName.GotFocus += new EventHandler(text_GotFocus);
                textFileName.KeyDown += new KeyEventHandler(text_KeyDown);

                labelFileName.AutoSize = false;
                labelFileName.Left = dluW;
                labelFileName.Top = dluW;
                labelFileName.Width = labelWidth + dluW / 2;
                labelFileName.Height = textFileName.Height;
                labelFileName.TextAlign = ContentAlignment.MiddleLeft;
                labelFileName.AutoEllipsis = true;


                int top = dluW + textFileName.Height + dluW + dluW / 2;
                foreach (var iItem in items) {
                    var text = new TextBox();
                    text.Top = top;
                    text.Left = dluW + labelWidth + dluW;
                    text.Width = textWidth;
                    text.ReadOnly = true;
                    text.Visible = false;
                    text.GotFocus += new EventHandler(text_GotFocus);
                    text.KeyDown += new KeyEventHandler(text_KeyDown);
                    this.Controls.Add(text);
                    iItem.TextBoxControl = text;

                    var button = new Button();
                    button.Width = text.Height;
                    button.Height = text.Height;
                    button.Top = top;
                    button.Left = text.Left + text.Width;
                    button.Image = Properties.Resources.btnSave_16;
                    button.Tag = iItem;
                    button.Visible = false;
                    button.Click += new EventHandler(button_Click);
                    toolTip.SetToolTip(button, "Creates new file that will contain result of " + iItem.Algorithm.DisplayName + " calculation. File will have same name as original with added ." + iItem.Algorithm.Name + " as extension.");
                    this.Controls.Add(button);
                    iItem.ButtonControl = button;

                    var label = new Label();
                    label.AutoSize = false;
                    label.Left = dluW;
                    label.Top = top;
                    label.Width = labelWidth + dluW / 2;
                    label.Height = text.Height;
                    label.Text = iItem.Algorithm.DisplayName + ":";
                    label.TextAlign = ContentAlignment.MiddleLeft;
                    label.AutoEllipsis = true;
                    label.Visible = false;
                    this.Controls.Add(label);
                    iItem.LabelControl = label;

                    top += text.Height + dluW;
                }
                top += dluW;

                top += buttonCancel.Height;
                this.ClientSize = new Size(dluW + labelWidth + dluW + textWidth + textFileName.Height + dluW, top + dluW);

                buttonCancel.Location = new Point(this.ClientRectangle.Right - buttonCancel.Width - dluW, this.ClientRectangle.Bottom - buttonCancel.Height - dluW);
                progress.Location = new Point(dluW, dluW + textFileName.Height + dluW + dluW / 2);
                progress.Width = this.ClientRectangle.Width - dluW - dluW;
                labelSpeed.Location = new Point(dluW, progress.Top + progress.Height + dluW);

                var workArea = Screen.GetWorkingArea(this);
                if (this.Right > workArea.Right) {
                    this.Left = workArea.Right - this.Width;
                }
                if (this.Bottom > workArea.Bottom) {
                    this.Top = workArea.Bottom - this.Height;
                }
                //this.Location = new Point((screenRect.Width - this.Width) / 2, (screenRect.Height - this.Height) / 2);
            }

            Medo.Windows.Forms.TaskbarProgress.DefaultOwner = this;
            Medo.Windows.Forms.TaskbarProgress.DoNotThrowNotImplementedException = true;
            Medo.Windows.Forms.TaskbarProgress.SetState(Medo.Windows.Forms.TaskbarProgressState.Normal);

            bwFileReader.RunWorkerAsync();
        }

        void button_Click(object sender, EventArgs e) {
            var thisButton = (Button)sender;
            var thisItem = (SumItem)thisButton.Tag;
            try {
                File.WriteAllText(this._file.FullName + "." + thisItem.Algorithm.Name, thisItem.ToNonspacedString());
                thisButton.Enabled = false;
                buttonCancel.Select();
            } catch (UnauthorizedAccessException ex) {
                Medo.MessageBox.ShowError(this, ex.Message);
            } catch (System.IO.IOException ex2) {
                Medo.MessageBox.ShowError(this, ex2.Message);
            }
        }

        void text_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == (Keys.Control | Keys.A)) {
                ((TextBox)sender).SelectAll();
            }
        }

        void text_GotFocus(object sender, EventArgs e) {
            ((TextBox)sender).SelectAll();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            if (buttonCancel.Text.Equals("Cancel")) {
                bwFileReader.CancelAsync();
            } else {
                this.Close();
            }
        }

        private void bwFileReader_DoWork(object sender, DoWorkEventArgs e) {
            try {
                using (var sr = new System.IO.FileStream(this._file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    byte[] buffer = new byte[256 * 1024];
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    long lastMilliseconds = 0;
                    do {
                        if (bwFileReader.CancellationPending) {
                            e.Cancel = true; break;
                        }
                        int count = sr.Read(buffer, 0, buffer.Length);
                        foreach (var iItem in this._items) {
                            if (sr.Position < sr.Length) {
                                iItem.Algorithm.TransformBlock(buffer, 0, count);
                            } else {
                                iItem.Algorithm.TransformFinalBlock(buffer, 0, count);
                            }
                        }
                        if (lastMilliseconds + 250 < stopWatch.ElapsedMilliseconds) {
                            lastMilliseconds = stopWatch.ElapsedMilliseconds;
                            var mbPerSecond = ((double)sr.Position / 1024 / 1024) / (stopWatch.ElapsedMilliseconds / 1000);
                            if (!double.IsInfinity(mbPerSecond) && !double.IsNaN(mbPerSecond)) {
                                int percent = (int)((sr.Position * 100) / sr.Length);
                                if ((stopWatch.ElapsedMilliseconds < 15000) || (percent < 10)) {
                                    bwFileReader.ReportProgress(percent, mbPerSecond.ToString("0") + " MB/s");
                                } else if ((stopWatch.ElapsedMilliseconds < 60000) || (percent < 50)) {
                                    bwFileReader.ReportProgress(percent, mbPerSecond.ToString("0.0") + " MB/s");
                                } else {
                                    bwFileReader.ReportProgress(percent, mbPerSecond.ToString("0.00") + " MB/s");
                                }
                            }
                        }
                    } while (sr.Position < sr.Length);
                    var finalMbPerSecond = ((double)sr.Length / 1024 / 1024) / (stopWatch.ElapsedMilliseconds / 1000);
                    if (double.IsInfinity(finalMbPerSecond) || double.IsNaN(finalMbPerSecond)) {
                        bwFileReader.ReportProgress(100, "");
                    } else {
                        bwFileReader.ReportProgress(100, finalMbPerSecond.ToString("0.00") + " MB/s");
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void bwFileReader_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progress.Value = e.ProgressPercentage;
            labelSpeed.Text = e.UserState.ToString();
            Medo.Windows.Forms.TaskbarProgress.SetPercentage(e.ProgressPercentage);
        }

        private void bwFileReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.Cursor = Cursors.Default;
            if (e.Error != null) {
                Medo.Windows.Forms.TaskbarProgress.SetState(Medo.Windows.Forms.TaskbarProgressState.Error);
                Medo.MessageBox.ShowError(this, e.Error.Message);
                this.Close();
            } else if (e.Cancelled) {
                this.Close();
            } else {
                Medo.Windows.Forms.TaskbarProgress.SetState(Medo.Windows.Forms.TaskbarProgressState.Normal);

                buttonCancel.Text = "Close";
                progress.Visible = false;
                labelSpeed.Top = this.ClientRectangle.Height - labelSpeed.Height - labelSpeed.Left;

                var clipboardBytes = SumItem.GetExpectedResult(Clipboard.GetText());

                foreach (var iItem in this._items) {
                    if ((clipboardBytes != null) && (clipboardBytes.Length == iItem.Algorithm.ResultByteCount)) {
                        iItem.ExpectedResult2 = clipboardBytes;
                    }

                    iItem.LabelControl.Visible = true;
                    iItem.TextBoxControl.Text = iItem.ToString();
                    if (iItem.AreResultsSame || iItem.AreResultsSame2) {
                        iItem.TextBoxControl.BackColor = Color.LightGreen;
                        iItem.ButtonControl.Enabled = false;
                    } else if (iItem.AreResultsDifferent) {
                        iItem.TextBoxControl.BackColor = Color.Pink;
                    }
                    iItem.TextBoxControl.Visible = true;
                    iItem.ButtonControl.Visible = true;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (bwFileReader.IsBusy) { bwFileReader.CancelAsync(); }
            this.Hide();
            while (bwFileReader.IsBusy) {
                Application.DoEvents(); //in order to allow call to RunWorkerCompleted
            }
            if (Application.OpenForms.Count == 1) { Application.Exit(); }
        }

    }
}
