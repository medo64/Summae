using Summae.HashAlgorithms;
using Medo.Application;
using System;
using System.Collections.Generic;
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
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

                Medo.Diagnostics.ErrorReport.DisableAutomaticSaveToTemp = true;
                UnhandledCatch.ThreadException += new EventHandler<ThreadExceptionEventArgs>(UnhandledCatch_ThreadException);
                UnhandledCatch.Attach();

                Medo.Configuration.Settings.NoRegistryWrites = Medo.Configuration.Settings.NoRegistryWrites;
                Medo.Windows.Forms.State.NoRegistryWrites = Medo.Configuration.Settings.NoRegistryWrites;
                Medo.Diagnostics.ErrorReport.DisableAutomaticSaveToTemp = !Medo.Configuration.Settings.Read("Installed", false);

                if (!((Environment.OSVersion.Version.Build < 7000) || (App.IsRunningOnMono))) {
                    var appId = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
                    if (appId.Length > 127) { appId = @"JosipMedved_Summae\" + appId.Substring(appId.Length - 127 - 20); }
                    NativeMethods.SetCurrentProcessExplicitAppUserModelID(appId);
                }


                if (Args.Current.ContainsKey("CURRENTDIRECTORY")) {
                    Environment.CurrentDirectory = Args.Current.GetValue("CURRENTDIRECTORY");
                }

                var files = new List<FileInfo>();
                foreach (var file in Args.Current.GetValues("")) {
                    files.Add(new FileInfo(file));
                }

                var hashMethods = new List<string>();
                foreach (string key in Args.Current.GetKeys()) {
                    if (SumAlgorithmBase.GetAlgorithmByName(key) != null) {
                        hashMethods.Add(key);
                    }
                }

                if (hashMethods.Count > 0) {
                    foreach (var file in files) {
                        var items = new List<SumItem>();

                        foreach (var method in hashMethods) {
                            var item = new SumItem(SumAlgorithmBase.GetAlgorithmByName(method));
                            item.ExpectedResult = SumItem.GetExpectedResult(file, item.Algorithm);
                            items.Add(item);
                        }
                        var form = new CalculateForm(file, items.AsReadOnly());
                        form.Show();
                    }
                    Application.Run();
                } else {
                    Application.Run(new MainForm(files));
                }
            }
        }

        private static void UnhandledCatch_ThreadException(object sender, ThreadExceptionEventArgs e) {
#if !DEBUG
            Medo.Diagnostics.ErrorReport.ShowDialog(null, e.Exception, new Uri("https://medo64.com/feedback/"));
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
