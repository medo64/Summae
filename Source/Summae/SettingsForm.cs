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
                    Bitmap bitmap = icon.ToBitmap();
                    if (bitmap != null) { btnOK.Image = bitmap; }
                }
            }
        }


        private void SettingsForm_Load(object sender, EventArgs e) {
            using (var rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"*\shell", false)) {
                var list = new List<string>(rk.GetSubKeyNames());
                chbSummae.Checked = list.Contains("Summae");
                chbCrc16.Checked = list.Contains("Summae (CRC-16)");
                chbCrc32.Checked = list.Contains("Summae (CRC-32)");
                chbMd5.Checked = list.Contains("Summae (MD-5)");
                chbRipeMd160.Checked = list.Contains("Summae (RIPE MD-160)");
                chbSha1.Checked = list.Contains("Summae (SHA-1)");
                chbSha256.Checked = list.Contains("Summae (SHA-256)");
                chbSha384.Checked = list.Contains("Summae (SHA-384)");
                chbSha512.Checked = list.Contains("Summae (SHA-512)");
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            using (var form = new SettingsProgressForm(chbSummae.Checked, chbCrc16.Checked, chbCrc32.Checked, chbMd5.Checked, chbRipeMd160.Checked, chbSha1.Checked, chbSha256.Checked, chbSha384.Checked, chbSha512.Checked)) {
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
