using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using HashAlgorithms;
using Medo.Application;

namespace SummaeCL {

    internal class App {
        private static Mutex _setupMutex;

        internal static void Main() {
            _setupMutex = new Mutex(false, @"Global\JosipMedved_Summae");

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            string[] argfiles = Args.Current.GetValues("");
            var files = new List<FileInfo>();
            foreach (var iArgFile in argfiles) {
                if (Directory.Exists(iArgFile)) {
                    AddDirectory(iArgFile, files);
                } else {
                    string fileDirectory;
                    string filePattern;
                    var iSep = iArgFile.LastIndexOf(Path.DirectorySeparatorChar);
                    if (iSep >= 0) {
                        fileDirectory = iArgFile.Substring(0, iSep);
                        filePattern = iArgFile.Substring(iSep + 1);
                    } else {
                        fileDirectory = Environment.CurrentDirectory;
                        filePattern = iArgFile;
                    }
                    foreach (var iFile in Directory.GetFiles(fileDirectory, filePattern)) {
                        files.Add(new FileInfo(iFile));
                    }
                }
            }

            if (files.Count == 0) {
                System.Environment.Exit(1);
            } else {
                var showProgress = Args.Current.ContainsKey("showprogress") || Args.Current.ContainsKey("progress");
                var showFileName = Args.Current.ContainsKey("showfilename");

                foreach (var iFile in files) {
                    try {
                        if (showFileName) { Console.WriteLine(iFile.FullName); }

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

                        int savedLeft = Console.CursorLeft;
                        using (var sr = new System.IO.FileStream(iFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                            byte[] buffer = new byte[256 * 1024];

                            var stopWatch = new Stopwatch();
                            stopWatch.Start();
                            long lastMilliseconds = 0;

                            do {
                                int count = sr.Read(buffer, 0, buffer.Length);
                                foreach (var iItem in items) {
                                    if (sr.Position < sr.Length) {
                                        iItem.Algorithm.TransformBlock(buffer, 0, count);
                                    } else {
                                        iItem.Algorithm.TransformFinalBlock(buffer, 0, count);
                                    }
                                }

                                if ((showProgress) && (lastMilliseconds + 1000 < stopWatch.ElapsedMilliseconds)) {
                                    lastMilliseconds = stopWatch.ElapsedMilliseconds;

                                    int lastLeft = Console.CursorLeft;
                                    Console.CursorLeft = savedLeft;

                                    int percent = (int)((sr.Position * 100) / sr.Length);
                                    var progressText = percent.ToString("0") + "%";
                                    var mbPerSecond = ((double)sr.Position / 1024 / 1024) / (stopWatch.ElapsedMilliseconds / 1000);
                                    if (!double.IsInfinity(mbPerSecond)) {
                                        if ((stopWatch.ElapsedMilliseconds < 15000) || (percent < 10)) {
                                            progressText += " (" + mbPerSecond.ToString("0") + " MB/s)";
                                        } else if ((stopWatch.ElapsedMilliseconds < 60000) || (percent < 50)) {
                                            progressText += " (" + mbPerSecond.ToString("0.0") + " MB/s)";
                                        } else {
                                            progressText += " (" + mbPerSecond.ToString("0.00") + " MB/s)";
                                        }
                                    }

                                    Console.Write(progressText);
                                    if (Console.CursorLeft < lastLeft) {
                                        int currLeft = Console.CursorLeft;
                                        Console.Write(new string(' ', lastLeft - Console.CursorLeft));
                                        Console.CursorLeft = currLeft;
                                    }
                                }

                            } while (sr.Position < sr.Length);
                        }

                        if (Console.CursorLeft != savedLeft) {
                            Console.Write(new string(' ', Console.CursorLeft - savedLeft));
                            Console.CursorLeft = savedLeft;
                        }

                        foreach (var iItem in items) {
                            if (iItem.AreResultsSame) {
                                Console.ForegroundColor = ConsoleColor.Green;
                            } else if (iItem.AreResultsDifferent) {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.WriteLine(iItem.ToNonspacedString());
                            Console.ResetColor();
                        }
                    } catch (IOException ex) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("EXCEPTION: " + ex.Message);
                        Console.ResetColor();
                        System.Environment.Exit(2);
                    }
                }
            }

            _setupMutex.Close();
        }

        private static void AddDirectory(string baseDirectory, IList<FileInfo> files) {
            foreach (var iFileName in Directory.GetFiles(baseDirectory)) {
                files.Add(new FileInfo(iFileName));
            }
            foreach (var iDirectoryName in Directory.GetDirectories(baseDirectory)) {
                AddDirectory(iDirectoryName, files);
            }
        }


        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Console.Error.WriteLine();
            var ex = e.ExceptionObject as Exception;
            if (ex != null) {
                Console.Error.WriteLine(ex.Message);
            } else {
                Console.Error.WriteLine("Unknown exception.");
            }
            Environment.Exit(1);
        }

    }
}
