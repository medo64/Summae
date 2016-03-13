using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;
using Medo.Application;
using Microsoft.Win32;

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

            var fileNameSummae = Path.Combine((new FileInfo(Assembly.GetExecutingAssembly().Location)).DirectoryName, "Summae.exe");

            //clear list
            using (var rk = Registry.ClassesRoot.OpenSubKey(@"*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                rk.DeleteSubKey("Summae", throwOnMissingSubKey: false);
            }

            //add new
            var subCommandList = new List<string>();
            if (Args.Current.ContainsKey("crc16")) { subCommandList.Add("Summae.Crc16"); }
            if (Args.Current.ContainsKey("crc32")) { subCommandList.Add("Summae.Crc32"); }
            if (Args.Current.ContainsKey("md5")) { subCommandList.Add("Summae.Md5"); }
            if (Args.Current.ContainsKey("ripemd160")) { subCommandList.Add("Summae.RipeMd160"); }
            if (Args.Current.ContainsKey("sha1")) { subCommandList.Add("Summae.Sha1"); }
            if (Args.Current.ContainsKey("sha256")) { subCommandList.Add("Summae.Sha256"); }
            if (Args.Current.ContainsKey("sha384")) { subCommandList.Add("Summae.Sha384"); }
            if (Args.Current.ContainsKey("sha512")) { subCommandList.Add("Summae.Sha512"); }

            if (subCommandList.Count > 0) {
                using (var rk = Registry.ClassesRoot.OpenSubKey(@"*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl)) {
                    using (var key = rk.CreateSubKey("Summae")) {
                        key.SetValue("Icon", @"""" + fileNameSummae + @"""", RegistryValueKind.String);
                        key.SetValue("SubCommands", string.Join(";", subCommandList.ToArray()), RegistryValueKind.String);
                    }
                }
            }

            _setupMutex.Close();
        }


        private static void UnhandledCatch_ThreadException(object sender, ThreadExceptionEventArgs e) {
#if !DEBUG
            Medo.Diagnostics.ErrorReport.ShowDialog(null, e.Exception, new Uri("https://medo64.com/feedback/"));
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
