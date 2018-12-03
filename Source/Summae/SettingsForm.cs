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
                            using (var rkShell = key.OpenSubKey("Shell", writable: false)) {
                                if (rkShell != null) {
                                    foreach (var subkey in rkShell.GetSubKeyNames()) {
                                        var entry = ShellEntry.GetEntry(subkey);
                                        if (entry != null) { entries.Add(entry); }
                                    }
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


        private static void CreateMenu(IList<ShellEntry> entries) {
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

            var assemblyLocation = Assembly.GetExecutingAssembly().Location;

            //Create: Software\Classes\*\shell\Summae (SubCommands)
            using (var rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                using (var rkMenu = rk.CreateSubKey("Summae")) {
                    rkMenu.SetValue("Icon", @"""" + assemblyLocation + @"""", RegistryValueKind.String);
                    rkMenu.SetValue("MUIVerb", @"Summae", RegistryValueKind.String);

                    if (entries.Count > 0) {
                        rkMenu.SetValue("SubCommands", @"", RegistryValueKind.String);

                        using (var rkEntryShell = rkMenu.CreateSubKey("Shell")) {
                            foreach (var entry in entries) {
                                using (var rkEntry = rkEntryShell.CreateSubKey(entry.Name)) {
                                    rkEntry.SetValue("MUIVerb", entry.Title, RegistryValueKind.String);
                                    rkEntry.SetValue("MultiSelectModel", "Player", RegistryValueKind.String);
                                    using (var rkCommand = rkEntry.CreateSubKey("command")) {
                                        rkCommand.SetValue("", @"""" + assemblyLocation + @""" /" + entry.Name.ToLowerInvariant() + @" ""%1""", RegistryValueKind.String);
                                    }
                                }
                            }
                        }
                    } else { //if no subitems, allow clicking on parent
                        using (var rkCommand = rkMenu.CreateSubKey("command")) {
                            rkCommand.SetValue("", @"""" + assemblyLocation + @""" ""%1""", RegistryValueKind.String);
                        }
                    }
                }
            }
        }
    }
}
