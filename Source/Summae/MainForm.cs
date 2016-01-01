using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;
using Medo;
using Medo.Text;
using System.ComponentModel;
using System.Threading;

namespace Summae {
    internal partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            mnu.Renderer = Helper.ToolstripRenderer;
            Helper.ScaleToolstrip(mnu);

            mnuCalculate.DropDown.Items.Add(new HashMenuItem("crc16", "CRC-16", Medo.Configuration.Settings.Read("crc16", false)));
            mnuCalculate.DropDown.Items.Add(new HashMenuItem("crc32", "CRC-32", Medo.Configuration.Settings.Read("crc32", false)));
            mnuCalculate.DropDown.Items.Add(new HashMenuItem("md5", "MD-5", Medo.Configuration.Settings.Read("md5", false)));
            mnuCalculate.DropDown.Items.Add(new HashMenuItem("ripemd160", "RIPE MD-160", Medo.Configuration.Settings.Read("ripemd160", false)));
            mnuCalculate.DropDown.Items.Add(new HashMenuItem("sha1", "SHA-1", Medo.Configuration.Settings.Read("sha1", true)));
            mnuCalculate.DropDown.Items.Add(new HashMenuItem("sha256", "SHA-256", Medo.Configuration.Settings.Read("sha256", false)));
            mnuCalculate.DropDown.Items.Add(new HashMenuItem("sha384", "SHA-384", Medo.Configuration.Settings.Read("sha384", false)));
            mnuCalculate.DropDown.Items.Add(new HashMenuItem("sha512", "SHA-512", Medo.Configuration.Settings.Read("sha512", false)));

            foreach (var iFile in Medo.Application.Args.Current.GetValues("")) {
                var iFileInfo = new FileInfo(iFile);
                AddFileToListView(iFileInfo.FullName);
            }
            RefreshEnableDisable();

            mnuAppOptions.Visible = (Medo.Configuration.Settings.NoRegistryWrites == false);
            mnuAppOptionsSeparator.Visible = false;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Alt | Keys.O: {
                        mnuAppOptions_Click(null, null);
                    } return true;

                case Keys.Control | Keys.N: {
                        mnuNew_Click(null, null);
                    } return true;

                case Keys.Control | Keys.O: {
                        mnuOpen_Click(null, null);
                    } return true;

                case Keys.F5: {
                        mnuCalculate.PerformButtonClick();
                    } return true;

                default: {
                    } return base.ProcessCmdKey(ref msg, keyData);
            }
        }


        private void Form_Load(object sender, EventArgs e) {
            Medo.Windows.Forms.State.Load(this, lsvFiles);
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e) {
            Medo.Windows.Forms.State.Save(this, lsvFiles);
            foreach (HashMenuItem iItem in mnuCalculate.DropDown.Items) {
                Medo.Configuration.Settings.Write(iItem.Key, iItem.Checked);
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e) {
            bwCheckForUpgrade.CancelAsync();
            Application.Exit();
        }

        private void Form_Shown(object sender, EventArgs e) {
            var version = Assembly.GetExecutingAssembly().GetName().Version; //don't auto-check for development builds
            if ((version.Major != 0) || (version.Minor != 0)) { bwCheckForUpgrade.RunWorkerAsync(); }
            bwCheckForUpgrade.RunWorkerAsync();
        }

        #region Menu

        private void mnuNew_Click(object sender, EventArgs e) {
            lsvFiles.Items.Clear();
            RefreshEnableDisable();
        }

        private void mnuOpen_Click(object sender, EventArgs e) {
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                lsvFiles.BeginUpdate();
                foreach (var iFileName in ofd.FileNames) {
                    AddFileToListView(iFileName);
                }
                lsvFiles.EndUpdate();
                RefreshEnableDisable();
            }
        }

        private void AddFileToListView(string fileName) {
            var file = new FileInfo(fileName);
            foreach (ListViewItem iItem in lsvFiles.Items) {
                string otherFileName = ((FileInfo)iItem.Tag).FullName;
                if (string.Compare(fileName, otherFileName, StringComparison.OrdinalIgnoreCase) == 0) {
                    iItem.Focused = true;
                    iItem.Selected = true;
                    return;
                }
            }

            var lvi = new ListViewItem();
            lvi.Tag = file;
            lvi.Text = file.Name;
            lvi.SubItems.Add(file.DirectoryName);
            lsvFiles.Items.Add(lvi);
            lvi.Selected = true;
            lvi.Focused = true;
        }


        private void mnuCalculate_ButtonClick(object sender, EventArgs e) {
            if (lsvFiles.Items.Count > 0) {
                try {
                    this.Cursor = Cursors.WaitCursor;

                    var sbArgs = new StringAdder(" ");
                    foreach (HashMenuItem item in mnuCalculate.DropDown.Items) {
                        if (item.Checked) {
                            sbArgs.Append("/" + item.Key);
                        }
                    }

                    foreach (ListViewItem iItem in lsvFiles.Items) {
                        var iFile = (FileInfo)iItem.Tag;
                        var startInfo = new ProcessStartInfo();
                        startInfo.CreateNoWindow = Process.GetCurrentProcess().StartInfo.CreateNoWindow;
                        startInfo.FileName = Path.Combine((new FileInfo(Assembly.GetExecutingAssembly().Location)).DirectoryName, "SummaeExecutor.exe");
                        startInfo.Arguments = sbArgs.ToString() + " \"" + iFile.FullName + "\"";
                        startInfo.WorkingDirectory = System.Environment.CurrentDirectory;
                        Process.Start(startInfo).WaitForInputIdle();
                    }
                    lsvFiles.Items.Clear();
                    this.Close();

                } finally {
                    this.Cursor = Cursors.Default;
                }
            }
        }


        private void mnuAppOptions_Click(object sender, EventArgs e) {
            using (var form = new SettingsForm()) {
                form.ShowDialog(this);
            }
        }

        private void mnuAppFeedback_Click(object sender, EventArgs e) {
            Medo.Diagnostics.ErrorReport.ShowDialog(this, null, new Uri("https://medo64.com/feedback/"));
        }

        private void mnuAppUpgrade_Click(object sender, EventArgs e) {
            Medo.Services.Upgrade.ShowDialog(this, new Uri("https://medo64.com/upgrade/"));
        }

        private void mnuAppAbout_Click(object sender, EventArgs e) {
            Medo.Windows.Forms.AboutBox.ShowDialog(this, new Uri("https://www.medo64.com/summae/"));
        }

        #endregion


        private void RefreshEnableDisable() {
            var state = (lsvFiles.Items.Count > 0);
            if (mnuCalculate.Enabled != state) { mnuCalculate.Enabled = state; }
        }

        private void lsvFiles_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyData) {
                case Keys.Insert: {
                        e.SuppressKeyPress = true;
                        mnuOpen_Click(sender, null);
                    } break;

                case Keys.Delete: {
                        e.SuppressKeyPress = true;
                        if (lsvFiles.SelectedItems.Count > 0) {
                            var items = new List<ListViewItem>();
                            foreach (ListViewItem iItem in lsvFiles.SelectedItems) {
                                items.Add(iItem);
                            }
                            lsvFiles.BeginUpdate();
                            foreach (var iItem in items) {
                                lsvFiles.Items.Remove(iItem);
                            }
                            if (lsvFiles.FocusedItem != null) { lsvFiles.FocusedItem.Selected = true; }
                            lsvFiles.EndUpdate();
                            RefreshEnableDisable();
                        }
                    } break;

            }
        }

        private void lsvFiles_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent("FileDrop")) {
                e.Effect = DragDropEffects.Link;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lsvFiles_DragDrop(object sender, DragEventArgs e) {
            foreach (var iFormat in e.Data.GetFormats()) {
                Debug.WriteLine(iFormat);
            }
            var files = e.Data.GetData("FileDrop") as string[];
            if (files != null) {
                lsvFiles.BeginUpdate();
                foreach (var iFile in files) {
                    AddFileToListView(iFile);
                }
                lsvFiles.EndUpdate();
            }
            RefreshEnableDisable();
            this.Activate();
        }

        private void bwCheckForUpgrade_DoWork(object sender, DoWorkEventArgs e) {
            e.Cancel = true;

            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < 3000) { //wait for three seconds
                Thread.Sleep(100);
                if (bwCheckForUpgrade.CancellationPending) { return; }
            }

            var file = Medo.Services.Upgrade.GetUpgradeFile(new Uri("https://medo64.com/upgrade/"));
            if (file != null) {
                if (bwCheckForUpgrade.CancellationPending) { return; }
                e.Cancel = false;
            }
        }

        private void bwCheckForUpgrade_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (!e.Cancelled) {
                Helper.ScaleToolstripItem(mnuApp, "mnuAppUpgrade");
                mnuAppUpgrade.Text = "Upgrade is available";
            }
        }

    }
}
