using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using HashAlgorithms;
using Medo.Application;
using Medo.Text;

namespace SummaeExecutor {
    internal static class App {

        private static Mutex _setupMutex;

        [STAThread]
        internal static void Main() {
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


            string[] argfiles = Args.Current.GetValues("");
            var files = new List<FileInfo>();
            foreach (var iFile in argfiles) {
                files.Add(new FileInfo(iFile));
            }

            if (files.Count == 0) {
                System.Environment.Exit(1);
            } else {
                var validHashMethods = new List<string>(new string[] { "CRC16", "CRC32", "MD5", "RIPEMD160", "SHA1", "SHA256", "SHA384", "SHA512" });

                if (Args.Current.ContainsKey("CURRENTDIRECTORY")) {
                    Environment.CurrentDirectory = Args.Current.GetValue("CURRENTDIRECTORY");
                }

                if (files.Count > 1) {
                    var sbBaseLine = new StringAdder(" ");
                    foreach (var iKey in Args.Current.GetKeys()) {
                        if ((iKey != null) && (iKey.Length > 0)) {
                            if (validHashMethods.Contains(iKey)) {
                                sbBaseLine.Append("/" + iKey);
                            }
                        }
                    }
                    sbBaseLine.Append("/CURRENTDIRECTORY=\"" + Environment.CurrentDirectory + "\"");
                    for (int i = 1; i < files.Count; ++i) {
                        var startInfo = new ProcessStartInfo();
                        startInfo.CreateNoWindow = Process.GetCurrentProcess().StartInfo.CreateNoWindow;
                        startInfo.FileName = Assembly.GetExecutingAssembly().Location;
                        startInfo.Arguments = sbBaseLine.ToString() + " \"" + files[i].FullName + "\"";
                        startInfo.WorkingDirectory = System.Environment.CurrentDirectory;
                        //Process.Start(startInfo);
                    }
                }

                var iFile = files[0];


                var items = new List<SumItem>();

                foreach (string iKey in Args.Current.GetKeys()) {
                    SumAlgorithmBase newAlgorithm = SumAlgorithmBase.GetAlgorithmByName(iKey);
                    if (newAlgorithm != null) {
                        items.Add(new SumItem(newAlgorithm));
                    }
                }
                if (items.Count == 0) { items.Add(new SumItem(new Sha1Sum())); }

                foreach (var iItem in items) {
                    iItem.ExpectedResult = SumItem.GetExpectedResult(iFile, iItem.Algorithm);
                }

                Application.Run(new MainForm(iFile, items.AsReadOnly()));
            }


            _setupMutex.Close();
        }

        private static void UnhandledCatch_ThreadException(object sender, ThreadExceptionEventArgs e) {
#if !DEBUG
            Medo.Diagnostics.ErrorReport.ShowDialog(null, e.Exception, new Uri("http://jmedved.com/feedback/"));
#else
            Medo.Diagnostics.ErrorReport.SaveToTemp(e.Exception);
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
