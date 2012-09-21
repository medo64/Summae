using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Summae {
    static class App {

        [STAThread]
        static void Main() {
            bool createdNew;
            var mutexSecurity = new MutexSecurity();
            mutexSecurity.AddAccessRule(new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow));
            using (var setupMutex = new Mutex(false, @"Global\JosipMedved_Summae", out createdNew, mutexSecurity)) {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

                Medo.Diagnostics.ErrorReport.DisableAutomaticSaveToTemp = true;
                Medo.Application.UnhandledCatch.ThreadException += new EventHandler<ThreadExceptionEventArgs>(UnhandledCatch_ThreadException);
                Medo.Application.UnhandledCatch.Attach();

                Medo.Configuration.Settings.NoRegistryWrites = !Medo.Configuration.Settings.Read("Installed", false);
                Medo.Windows.Forms.State.NoRegistryWrites = !Medo.Configuration.Settings.Read("Installed", false);
                Medo.Diagnostics.ErrorReport.DisableAutomaticSaveToTemp = !Medo.Configuration.Settings.Read("Installed", false);

                if (!((Environment.OSVersion.Version.Build < 7000) || (App.IsRunningOnMono))) {
                    var appId = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
                    if (appId.Length > 127) { appId = @"JosipMedved_Summae\" + appId.Substring(appId.Length - 127 - 20); }
                    NativeMethods.SetCurrentProcessExplicitAppUserModelID(appId);
                }


                Application.Run(new MainForm());

            }
        }


        private static void UnhandledCatch_ThreadException(object sender, ThreadExceptionEventArgs e) {
#if !DEBUG
            Medo.Diagnostics.ErrorReport.ShowDialog(null, e.Exception, new Uri("http://jmedved.com/feedback/"), new string[] { "Test line 1.", "Test line 2." });
            Medo.Services.Upgrade.ShowDialog(null, new Uri("http://jmedved.com/upgrade/"));
#else
            throw e.Exception;
#endif
        }


        private static class NativeMethods {

            [DllImport("Shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern UInt32 SetCurrentProcessExplicitAppUserModelID(String AppID);

        }

        private static bool IsRunningOnMono {
            get {
                return (Type.GetType("Mono.Runtime") != null);
            }
        }

    }
}
