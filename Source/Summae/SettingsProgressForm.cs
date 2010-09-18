using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Medo.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Summae {
    public partial class SettingsProgressForm : Form {
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
            Process.Start(startInfo).WaitForExit();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
