using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Medo.Text;

namespace Summae {
    internal partial class SettingsProgressForm : Form {
        public SettingsProgressForm(bool summae, bool crc16, bool crc32, bool md5, bool ripemd160, bool sha1, bool sha256, bool sha384, bool sha512) {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;

            var sb = new StringAdder(" ");
            if (summae) { sb.Append("/summae"); }
            if (crc16) { sb.Append("/crc16"); }
            if (crc32) { sb.Append("/crc32"); }
            if (md5) { sb.Append("/md5"); }
            if (ripemd160) { sb.Append("/ripemd160"); }
            if (sha1) { sb.Append("/sha1"); }
            if (sha256) { sb.Append("/sha256"); }
            if (sha384) { sb.Append("/sha384"); }
            if (sha512) { sb.Append("/sha512"); }

            bw.RunWorkerAsync(sb.ToString());
        }


        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            string arguments = (string)e.Argument;

            var startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = Process.GetCurrentProcess().StartInfo.CreateNoWindow;
            startInfo.FileName = Path.Combine((new FileInfo(Assembly.GetExecutingAssembly().Location)).DirectoryName, "SummaeSettings.exe");
            startInfo.Arguments = arguments;
            startInfo.WorkingDirectory = System.Environment.CurrentDirectory;
            try {
                Process.Start(startInfo).WaitForExit();
            } catch (Win32Exception) {
                e.Cancel = true;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.DialogResult = e.Cancelled ? DialogResult.Cancel : DialogResult.OK;
        }
    }
}
