using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security.AccessControl;
using Medo.Application;
using System.Globalization;

namespace SummaeSettings {
    internal static class App {

        private static Mutex _setupMutex;

        [STAThread]
        internal static void Main(string[] args) {
            _setupMutex = new Mutex(false, @"Global\JosipMedved_Summae");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            Medo.Diagnostics.ErrorReport.DisableAutomaticSaveToTemp = true;
            Medo.Application.UnhandledCatch.ThreadException += new EventHandler<ThreadExceptionEventArgs>(UnhandledCatch_ThreadException);
            Medo.Application.UnhandledCatch.Attach();
            Medo.Diagnostics.ErrorReport.DisableAutomaticSaveToTemp = Settings.IsPortable;

            if (!((Environment.OSVersion.Version.Build < 7000) || (App.IsRunningOnMono))) {
                var appId = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
                if (appId.Length > 127) { appId = @"JosipMedved_Summae\" + appId.Substring(appId.Length - 127 - 20); }
                NativeMethods.SetCurrentProcessExplicitAppUserModelID(appId);
            }


            //clear list
            using (var rk = Registry.ClassesRoot.OpenSubKey(@"*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                var list = new List<string>(rk.GetSubKeyNames());
                if (list.Contains("Summae")) { rk.DeleteSubKeyTree(@"Summae"); }
                if (list.Contains("Summae (CRC-16)")) { rk.DeleteSubKeyTree("Summae (CRC-16)"); }
                if (list.Contains("Summae (CRC-32)")) { rk.DeleteSubKeyTree("Summae (CRC-32)"); }
                if (list.Contains("Summae (MD-5)")) { rk.DeleteSubKeyTree("Summae (MD-5)"); }
                if (list.Contains("Summae (RIPE MD-160)")) { rk.DeleteSubKeyTree("Summae (RIPE MD-160)"); }
                if (list.Contains("Summae (SHA-1)")) { rk.DeleteSubKeyTree("Summae (SHA-1)"); }
                if (list.Contains("Summae (SHA-256)")) { rk.DeleteSubKeyTree("Summae (SHA-256)"); }
                if (list.Contains("Summae (SHA-384)")) { rk.DeleteSubKeyTree("Summae (SHA-384)"); }
                if (list.Contains("Summae (SHA-512)")) { rk.DeleteSubKeyTree("Summae (SHA-512)"); }
            }


            //add new
            var fileNameSummae = Path.Combine((new FileInfo(Assembly.GetExecutingAssembly().Location)).DirectoryName, "Summae.exe");
            var fileNameSummaeExecutor = Path.Combine((new FileInfo(Assembly.GetExecutingAssembly().Location)).DirectoryName, "SummaeExecutor.exe");
            if (Args.Current.ContainsKey("summae")) { AddContextMenuItem("Summae", fileNameSummae, null); }
            if (Args.Current.ContainsKey("crc16")) { AddContextMenuItem("Summae (CRC-16)", fileNameSummaeExecutor, "/crc16"); }
            if (Args.Current.ContainsKey("crc32")) { AddContextMenuItem("Summae (CRC-32)", fileNameSummaeExecutor, "/crc32"); }
            if (Args.Current.ContainsKey("md5")) { AddContextMenuItem("Summae (MD-5)", fileNameSummaeExecutor, "/md5"); }
            if (Args.Current.ContainsKey("ripemd160")) { AddContextMenuItem("Summae (RIPE MD-160)", fileNameSummaeExecutor, "/ripemd160"); }
            if (Args.Current.ContainsKey("sha1")) { AddContextMenuItem("Summae (SHA-1)", fileNameSummaeExecutor, "/sha1"); }
            if (Args.Current.ContainsKey("sha256")) { AddContextMenuItem("Summae (SHA-256)", fileNameSummaeExecutor, "/sha256"); }
            if (Args.Current.ContainsKey("sha384")) { AddContextMenuItem("Summae (SHA-384)", fileNameSummaeExecutor, "/sha384"); }
            if (Args.Current.ContainsKey("sha512")) { AddContextMenuItem("Summae (SHA-512)", fileNameSummaeExecutor, "/sha512"); }


            _setupMutex.Close();
        }

        private static void AddContextMenuItem(string name, string fileName, string argument) {
            string command;
            if (string.IsNullOrEmpty(argument)) {
                command = string.Format(CultureInfo.InvariantCulture, @"""{0}"" ""%1""", fileName);
            } else {
                command = string.Format(CultureInfo.InvariantCulture, @"""{0}"" {1} ""%1""", fileName, argument);
            }

            using (var rk = Registry.ClassesRoot.OpenSubKey(@"*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                using (var keyMain = rk.CreateSubKey(name)) {
                    keyMain.SetValue("MultiSelectModel", "Player", RegistryValueKind.String);
                    using (var keyCommand = keyMain.CreateSubKey("command")) {
                        keyCommand.SetValue(null, command, RegistryValueKind.String);
                    }
                }
            }
        }


        private static void UnhandledCatch_ThreadException(object sender, ThreadExceptionEventArgs e) {
#if !DEBUG
            Medo.Diagnostics.ErrorReport.ShowDialog(null, e.Exception, new Uri("http://jmedved.com/feedback/"));
#else
            throw e.Exception;
#endif
        }


        private static class NativeMethods {

            [DllImport("Shell32.dll", SetLastError = true)]
            public static extern UInt32 SetCurrentProcessExplicitAppUserModelID(String AppID);

        }

        private static bool IsRunningOnMono {
            get {
                return (Type.GetType("Mono.Runtime") != null);
            }
        }

    }
}
