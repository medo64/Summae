using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Summae {
    internal partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            lblWarning.Font = new Font(SystemFonts.MessageBoxFont, FontStyle.Bold);

            var hIcon = NativeMethods.LoadImageW(IntPtr.Zero, NativeMethods.IDI_SHIELD, NativeMethods.IMAGE_ICON, 24, 24, NativeMethods.LR_DEFAULTCOLOR);
            if (!hIcon.Equals(System.IntPtr.Zero)) {
                var icon = System.Drawing.Icon.FromHandle(hIcon);
                if (icon != null) {
                    btnOK.Image = icon.ToBitmap();
                }
            }
        }


        private void SettingsForm_Load(object sender, EventArgs e) {
            using (var rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"*\shell", writable: false)) {
                var subCommandList = new List<string>();
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

                chbCrc16.Checked = subCommandList.Contains("Summae.Crc16");
                chbCrc32.Checked = subCommandList.Contains("Summae.Crc32");
                chbMd5.Checked = subCommandList.Contains("Summae.Md5");
                chbRipeMd160.Checked = subCommandList.Contains("Summae.RipeMd160");
                chbSha1.Checked = subCommandList.Contains("Summae.Sha1");
                chbSha256.Checked = subCommandList.Contains("Summae.Sha256");
                chbSha384.Checked = subCommandList.Contains("Summae.Sha384");
                chbSha512.Checked = subCommandList.Contains("Summae.Sha512");
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            using (var form = new SettingsProgressForm(chbCrc16.Checked, chbCrc32.Checked, chbMd5.Checked, chbRipeMd160.Checked, chbSha1.Checked, chbSha256.Checked, chbSha384.Checked, chbSha512.Checked)) {
                this.DialogResult = form.ShowDialog(this);
            }
        }


        private static class NativeMethods {

            internal static readonly IntPtr IDI_SHIELD = new IntPtr(106);
            internal const uint IMAGE_ICON = 1;
            internal const uint LR_DEFAULTCOLOR = 0x00000000;

            [DllImportAttribute("user32.dll", EntryPoint = "LoadImageW")]
            internal static extern IntPtr LoadImageW(IntPtr hInst, IntPtr name, uint type, int cx, int cy, uint fuLoad);

        }

    }
}
