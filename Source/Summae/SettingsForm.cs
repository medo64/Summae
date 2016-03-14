using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Summae {
    internal partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
        }


        private void SettingsForm_Load(object sender, EventArgs e) {
            var subCommandList = new List<string>();

            using (var rk = Registry.ClassesRoot.OpenSubKey(@"*\shell", writable: false)) {
                if (rk != null) {
                    using (var key = rk.OpenSubKey("Summae", writable: false)) {
                        if (key != null) {
                            var subCommands = key.GetValue("SubCommands");
                            if (subCommands != null) {
                                foreach (var subCommand in subCommands.ToString().Split(';')) {
                                    subCommandList.Add(subCommand);
                                }
                            }
                        }
                    }
                }
            }

            using (var rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*\shell", writable: false)) {
                if (rk != null) {
                    using (var key = rk.OpenSubKey("Summae", writable: false)) {
                        if (key != null) {
                            var subCommands = key.GetValue("SubCommands");
                            if (subCommands != null) {
                                foreach (var subCommand in subCommands.ToString().Split(';')) {
                                    subCommandList.Add(subCommand);
                                }
                            }
                        }
                    }
                }
            }

            chbCrc16.Checked = subCommandList.Contains("Summae.Crc16");
            chbCrc32.Checked = subCommandList.Contains("Summae.Crc32");
            chbMd5.Checked = subCommandList.Contains("Summae.Md5");
            chbRipeMd160.Checked = subCommandList.Contains("Summae.RipeMd160");
            chbSha1.Checked = subCommandList.Contains("Summae.Sha1");
            chbSha256.Checked = subCommandList.Contains("Summae.Sha256");
            chbSha384.Checked = subCommandList.Contains("Summae.Sha384");
            chbSha512.Checked = subCommandList.Contains("Summae.Sha512");
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var subCommandList = new List<string>();
            if (chbCrc16.Checked) { subCommandList.Add("Summae.Crc16"); }
            if (chbCrc32.Checked) { subCommandList.Add("Summae.Crc32"); }
            if (chbMd5.Checked) { subCommandList.Add("Summae.Md5"); }
            if (chbRipeMd160.Checked) { subCommandList.Add("Summae.RipeMd160"); }
            if (chbSha1.Checked) { subCommandList.Add("Summae.Sha1"); }
            if (chbSha256.Checked) { subCommandList.Add("Summae.Sha256"); }
            if (chbSha384.Checked) { subCommandList.Add("Summae.Sha384"); }
            if (chbSha512.Checked) { subCommandList.Add("Summae.Sha512"); }

            using (var rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                try {
                    rk.DeleteSubKeyTree("Summae");
                } catch (ArgumentException) { } //ignore if it doesn't exist

                using (var key = rk.CreateSubKey("Summae")) {
                    key.SetValue("Icon", @"""" + Assembly.GetExecutingAssembly().Location + @"""", RegistryValueKind.String);
                    key.SetValue("MUIVerb", @"Summae", RegistryValueKind.String);
                    if (subCommandList.Count > 0) {
                        key.SetValue("SubCommands", string.Join(";", subCommandList.ToArray()), RegistryValueKind.String);
                    } else {
                        key.SetValue("AppliesTo", @"System.FileName:=\", RegistryValueKind.String); //dummy filename; trick to prevent inheritance from HKEY_CLASSES_ROOT
                    }
                }
            }
        }

    }
}
