using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using Medo.Text;
using Medo;
using System.Security.Permissions;

namespace Summae {
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;

            checkedMethods.Items.Add(new Medo.TagItem<string, string>("crc16", "CRC-16"), Medo.Configuration.Settings.Read("crc16", false));
            checkedMethods.Items.Add(new Medo.TagItem<string, string>("crc32", "CRC-32"), Medo.Configuration.Settings.Read("crc32", false));
            checkedMethods.Items.Add(new Medo.TagItem<string, string>("md5", "MD-5"), Medo.Configuration.Settings.Read("md5", false));
            checkedMethods.Items.Add(new Medo.TagItem<string, string>("ripemd160", "RIPE MD-160"), Medo.Configuration.Settings.Read("ripemd160", false));
            checkedMethods.Items.Add(new Medo.TagItem<string, string>("sha1", "SHA-1"), Medo.Configuration.Settings.Read("sha1", true));
            checkedMethods.Items.Add(new Medo.TagItem<string, string>("sha256", "SHA-256"), Medo.Configuration.Settings.Read("sha256", false));
            checkedMethods.Items.Add(new Medo.TagItem<string, string>("sha384", "SHA-384"), Medo.Configuration.Settings.Read("sha384", false));
            checkedMethods.Items.Add(new Medo.TagItem<string, string>("sha512", "SHA-512"), Medo.Configuration.Settings.Read("sha512", false));

            foreach (var iFile in Medo.Application.Args.Current.GetValues("")) {
                var iFileInfo = new FileInfo(iFile);
                AddFileToListView(iFileInfo.FullName);
            }
            RefreshEnableDisable();

            toolToolsSettings.Visible = (Medo.Configuration.Settings.NoRegistryWrites == false);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Alt | Keys.O: {
                        toolToolsSettings_Click(null, null);
                    } return true;

                case Keys.Alt | Keys.R: {
                        toolHelpReportABug_Click(null, null);
                    } return true;

                case Keys.Alt | Keys.A: {
                        toolHelpAbout_Click(null, null);
                    } return true;

                case Keys.Control | Keys.N: {
                        toolFileNew_Click(null, null);
                    } return true;

                case Keys.Control | Keys.O: {
                        toolFileOpen_Click(null, null);
                    } return true;

                case Keys.F5: {
                        toolFileCalculate_Click(null, null);
                    } return true;

                default: {
                    } return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void toolFileNew_Click(object sender, EventArgs e) {
            lsvFiles.Items.Clear();
            RefreshEnableDisable();
        }

        private void toolFileOpen_Click(object sender, EventArgs e) {
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

        private void toolFileCalculate_Click(object sender, EventArgs e) {
            if (lsvFiles.Items.Count > 0) {
                try {
                    this.Cursor = Cursors.WaitCursor;

                    var sbArgs = new StringAdder(" ");
                    foreach (var iMethod in checkedMethods.CheckedItems) {
                        var iMethodTag = (TagItem<string, string>)iMethod;
                        sbArgs.Append("/" + iMethodTag.Key);
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

        private void toolToolsSettings_Click(object sender, EventArgs e) {
            using (var form = new SettingsForm()) {
                form.ShowDialog(this);
            }
        }

        private void toolHelpReportABug_Click(object sender, EventArgs e) {
            Medo.Diagnostics.ErrorReport.ShowDialog(this, null, new Uri("http://jmedved.com/feedback/"));
        }

        private void toolHelpAbout_Click(object sender, EventArgs e) {
            Medo.Windows.Forms.AboutBox.ShowDialog(this, new Uri("http://www.jmedved.com/summae/"));
        }

        private void checkedMethods_ItemCheck(object sender, ItemCheckEventArgs e) {
            if ((e.CurrentValue == CheckState.Checked) && (e.NewValue == CheckState.Unchecked) && (checkedMethods.CheckedItems.Count == 1)) {
                e.NewValue = CheckState.Checked;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Medo.Windows.Forms.State.Save(this, lsvFiles);
            foreach (var iItem in checkedMethods.Items) {
                var iMethodTag = (TagItem<string, string>)iItem;
                Medo.Configuration.Settings.Write(iMethodTag.Key, checkedMethods.GetItemChecked(checkedMethods.Items.IndexOf(iItem)));
            }
        }

        private void RefreshEnableDisable() {
            var state = (lsvFiles.Items.Count > 0);
            if (toolFileCalculate.Enabled != state) { toolFileCalculate.Enabled = state; }
        }

        private void lsvFiles_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyData) {
                case Keys.Insert: {
                        e.SuppressKeyPress = true;
                        toolFileOpen_Click(sender, null);
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
            //foreach (var iFormat in e.Data.GetFormats()) {
            //    if (string.Compare(iFormat, "FileNameW", StringComparison.OrdinalIgnoreCase) == 0) {
            //        e.Effect = DragDropEffects.Link;
            //        return;
            //    }
            //}
            //e.Effect = DragDropEffects.None;
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

        private void MainForm_Load(object sender, EventArgs e) {
            Medo.Windows.Forms.State.Load(this, lsvFiles);
        }

    }
}
