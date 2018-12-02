using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Summae {
    internal partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
        }


        private void SettingsForm_Load(object sender, EventArgs e) {
            var entries = new List<ShellEntry>();

            using (var rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*\shell", writable: false)) {
                if (rk != null) {
                    using (var key = rk.OpenSubKey("Summae", writable: false)) {
                        if (key != null) {
                            var subCommands = key.GetValue("SubCommands");
                            if (subCommands != null) {
                                foreach (var subCommand in subCommands.ToString().Split(';')) {
                                    entries.Add(ShellEntry.GetEntry(subCommand));
                                }
                            }
                        }
                    }
                }
            }

            chbCrc16.Checked = entries.Contains(ShellEntry.Crc16);
            chbCrc32.Checked = entries.Contains(ShellEntry.Crc32);
            chbMd5.Checked = entries.Contains(ShellEntry.Md5);
            chbRipeMd160.Checked = entries.Contains(ShellEntry.RipeMd160);
            chbSha1.Checked = entries.Contains(ShellEntry.Sha1);
            chbSha256.Checked = entries.Contains(ShellEntry.Sha256);
            chbSha384.Checked = entries.Contains(ShellEntry.Sha384);
            chbSha512.Checked = entries.Contains(ShellEntry.Sha512);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var entries = new List<ShellEntry>();
            if (chbCrc16.Checked) { entries.Add(ShellEntry.Crc16); }
            if (chbCrc32.Checked) { entries.Add(ShellEntry.Crc32); }
            if (chbMd5.Checked) { entries.Add(ShellEntry.Md5); }
            if (chbRipeMd160.Checked) { entries.Add(ShellEntry.RipeMd160); }
            if (chbSha1.Checked) { entries.Add(ShellEntry.Sha1); }
            if (chbSha256.Checked) { entries.Add(ShellEntry.Sha256); }
            if (chbSha384.Checked) { entries.Add(ShellEntry.Sha384); }
            if (chbSha512.Checked) { entries.Add(ShellEntry.Sha512); }

            CreateMenu(entries);
        }

        private static void CreateMenu(IEnumerable<ShellEntry> entries) {
            //Create: HKCU\Software\Classes\*
            using (var rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) { //Windows 7 might not have star (*) registry entry
                if (rk == null) {
                    using (var rkStar = Registry.CurrentUser.OpenSubKey(@"Software\Classes", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                        rkStar.CreateSubKey("*");
                    }
                }
            }

            //Delete: HKCU\Software\Classes\*\shell\Summae (and Create: HKCU\Software\Classes\*\shell)
            using (var rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                if (rk == null) {
                    using (var rkShell = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                        rkShell.CreateSubKey("shell");
                    }
                } else {
                    try {
                        rk.DeleteSubKeyTree("Summae");
                    } catch (ArgumentException) { } //ignore if it doesn't exist
                }
            }

            //Create: Software\Classes\*\shell\Summae (SubCommands)
            using (var rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                using (var key = rk.CreateSubKey("Summae")) {
                    key.SetValue("Icon", @"""" + Assembly.GetExecutingAssembly().Location + @"""", RegistryValueKind.String);
                    key.SetValue("MUIVerb", @"Summae", RegistryValueKind.String);

                    var subcommandList = new List<string>();
                    foreach (var entry in entries) {
                        subcommandList.Add(entry.Command);
                    }
                    if (subcommandList.Count > 0) {
                        key.SetValue("SubCommands", string.Join(";", subcommandList.ToArray()), RegistryValueKind.String);
                    } else {
                        key.SetValue("AppliesTo", @"System.FileName:=\", RegistryValueKind.String); //dummy filename; trick to prevent inheritance from HKEY_CLASSES_ROOT
                    }
                }
            }
        }
    }
}
