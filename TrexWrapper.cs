﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TrexMinerGUI
{
    public class TrexWrapper
    {
        public class TrexStatisctics
        {
            public string Speed { get; set; }
            public string FanSpeed { get; set; }
            public string Power { get; set; }
            public string Efficiency { get; set; }
            public string Temp { get; set; }
            public string LastUpdated { get; set; }

            public TrexStatisctics()
            {
                Speed = "0";
                FanSpeed = "0";
                Power = "0";
                Efficiency = "0";
                Temp = "0";
                LastUpdated = "";
            }
        }

        private readonly Process TrexProcess;

        public readonly string LogFileName;
        public readonly string ErrorLogFileName;
        public readonly string WarnLogFileName;

        public bool IsRunning { get; set; }
        private bool IsTerminatedByGUI { get; set; }
        public TrexStatisctics TheTrexStatisctics { get; }

        public TrexWrapper()
        {
            TrexProcess = new Process();
            TrexProcess.StartInfo.FileName = Program.ExecutionPath + "t-rex.exe";
            TrexProcess.StartInfo.UseShellExecute = false;
            TrexProcess.StartInfo.RedirectStandardOutput = true;
            TrexProcess.StartInfo.RedirectStandardError = true;
            TrexProcess.StartInfo.CreateNoWindow = true;
            TrexProcess.EnableRaisingEvents = true;

            TrexProcess.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            TrexProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            TrexProcess.Exited += new EventHandler(ProcExitedHandler); 

            LogFileName = "trex_log.txt";
            ErrorLogFileName = "trex_error_log.txt";
            WarnLogFileName = "trex_warn_log.txt";
            IsRunning = false;
            IsTerminatedByGUI = false;
            TheTrexStatisctics = new TrexStatisctics();
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (e == null || String.IsNullOrEmpty(e.Data))
                return;

            WriteLogToFile(e.Data);
            //Console.WriteLine("OutputHandler: " + e.Data);

            try
            {
                if (e.Data.StartsWith("#"))
                {
                    if (e.Data.Contains("download"))
                    {
                        Task.Run(() => Program.TheSelfUpdate.UpdateTrex(e.Data.Substring(12)));
                        Stop();
                    }
                }
                else if (e.Data.StartsWith("-"))
                {
                    TheTrexStatisctics.LastUpdated = e.Data.Split(" ")[2];
                }
                else if (e.Data.StartsWith(@"GPU #0:"))
                {
                    try
                    {
                        var Statistics = e.Data.Split(" - ")[1].Split(",");
                        TheTrexStatisctics.Speed = Statistics[0];
                        TheTrexStatisctics.Temp = Statistics[1].Substring(4);
                        TheTrexStatisctics.Power = Statistics[2].Substring(3);
                        TheTrexStatisctics.FanSpeed = Statistics[3].Substring(3);
                        TheTrexStatisctics.Efficiency = Statistics[4].Substring(3).Replace(']', ' ');
                    }
                    catch
                    {

                    }
                }
                else
                {
                    string DateTimeHeader = e.Data.Substring(0, 17);
                    string Info = e.Data.Substring(18);

                    //Debug.WriteLine("DateTimeHeader:" + DateTimeHeader);
                    //Debug.WriteLine("Info:" + Info);

                    if (Info.Contains("epoch") && !Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                    {
                        Program.TheStopWatchWrapper.TheStopWatch.Start();
                    }
                    else if (Info.ToLower().Contains("error") || Info.ToLower().Contains("exception"))
                    {
                        //new System.Threading.Thread(() => System.Windows.Forms.MessageBox.Show(@"GPU Hatası! Log'u kontrol edin!", "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)).Start();

                        if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                            Program.TheStopWatchWrapper.TheStopWatch.Stop();
                    }
                }
            } 
            catch (Exception TheException)
            {
                if (!(TheException is ArgumentOutOfRangeException))
                    File.AppendAllText(Program.ExecutionPath + Program.ExceptionLogFileName, Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + TheException.ToString() + Environment.NewLine);
            }
        }

        private void WriteLogToFile(string LineToWrite)
        {
            if (String.IsNullOrEmpty(LineToWrite))
                return;

            if (LineToWrite.ToLower().Contains("error") || LineToWrite.ToLower().Contains("exception"))
            {
                File.AppendAllText(Program.ExecutionPath + ErrorLogFileName, LineToWrite + Environment.NewLine);
            }
            else if (LineToWrite.ToLower().Contains("warn") && (!(LineToWrite.ToLower().Contains("devfee") || LineToWrite.ToLower().Contains("intensity"))))
            {
                File.AppendAllText(Program.ExecutionPath + WarnLogFileName, LineToWrite + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(Program.ExecutionPath + LogFileName, LineToWrite + Environment.NewLine);
            }
        }

        public void Start()
        {
            if (Program.TheSelfUpdate.IsTrexUpdating)
            {
                return;
            }

            if (!File.Exists(Program.ExecutionPath + "t-rex.exe"))
            {
                Task.Run(() => Program.TheSelfUpdate.UpdateTrex(@"https://github.com/trexminer/T-Rex/releases/download/0.20.1/t-rex-0.20.1-win.zip"));
                return;
            }

            TrexProcess.StartInfo.Arguments = Program.TheConfig.MinerArgs;

            TrexProcess.Start();
            TrexProcess.BeginOutputReadLine();
            TrexProcess.BeginErrorReadLine();

            IsRunning = true;

            if (Program.TheConfig.ApplyAfterburnerProfileOnMinerStart)
            {
                bool IsAlreadyRunning = Process.GetProcessesByName("MSIAfterburner").Length >= 1;

                Process TheAfterburnerProcess = new Process();
                TheAfterburnerProcess.StartInfo.Arguments = @"/m -Profile" + Program.TheConfig.ProfileToApplyOnMinerStart;
                TheAfterburnerProcess.StartInfo.UseShellExecute = true;
                TheAfterburnerProcess.StartInfo.FileName = @"C:\Program Files (x86)\MSI Afterburner\MSIAfterburner.exe";
                TheAfterburnerProcess.Start();

                if (!IsAlreadyRunning)
                {
                    Task.Run(() => {
                        Task.Delay(6000).Wait();
                        TheAfterburnerProcess.Kill();
                        try { Process.GetProcessesByName("RTSS").First().Kill(); } catch { }
                        try { Process.GetProcessesByName("EncoderServer").First().Kill(); } catch { }
                        try { Process.GetProcessesByName("EncoderServer64").First().Kill(); } catch { }
                        try { Process.GetProcessesByName("RTSSHooksLoader").First().Kill(); } catch { }
                        try { Process.GetProcessesByName("RTSSHooksLoader64").First().Kill(); } catch { }
                    });
                }
            }

            //ExternalMethods.OpenConsole();

        }

        private void ProcExitedHandler(object sender, EventArgs e)
        {
            IsRunning = false;

            TrexProcess.CancelOutputRead();
            TrexProcess.CancelErrorRead();

            if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                Program.TheStopWatchWrapper.TheStopWatch.Stop();

            if (IsTerminatedByGUI)
            {
                IsTerminatedByGUI = false;
                if (Program.TheConfig.ApplyAfterburnerProfileOnMinerClose)
                {
                    bool IsAlreadyRunning = Process.GetProcessesByName("MSIAfterburner").Length >= 1;

                    Process TheAfterburnerProcess = new Process();
                    TheAfterburnerProcess.StartInfo.Arguments = @"/m -Profile" + Program.TheConfig.ProfileToApplyOnMinerClose;
                    TheAfterburnerProcess.StartInfo.UseShellExecute = true;
                    TheAfterburnerProcess.StartInfo.FileName = @"C:\Program Files (x86)\MSI Afterburner\MSIAfterburner.exe";
                    TheAfterburnerProcess.Start();

                    if (!IsAlreadyRunning)
                    {
                        Task.Run(() => {
                            Task.Delay(6000).Wait();
                            TheAfterburnerProcess.Kill();
                            try { Process.GetProcessesByName("RTSS").First().Kill(); } catch { }
                            try { Process.GetProcessesByName("EncoderServer").First().Kill(); } catch { }
                            try { Process.GetProcessesByName("EncoderServer64").First().Kill(); } catch { }
                            try { Process.GetProcessesByName("RTSSHooksLoader").First().Kill(); } catch { }
                            try { Process.GetProcessesByName("RTSSHooksLoader64").First().Kill(); } catch { }
                        });
                    }
                }
            }
            else
            {
                Start();
            }
                

            //ExternalMethods.CloseConsole();
        }

        public void Stop()
        {
            IsTerminatedByGUI = true;

            try
            {
                TrexProcess.Kill();
                TrexProcess.WaitForExit();
            } 
            catch
            {
                IsTerminatedByGUI = false;

                while (Process.GetProcessesByName("t-rex").Length > 0)
                {
                    var Procs = Process.GetProcessesByName("t-rex");

                    foreach (var Proc in Procs)
                    {
                        Proc.Kill();
                        Proc.WaitForExit();
                    }
                }
            }
        }

        public int GetWarnCount()
        {
            try
            {
                return File.ReadAllLines(Program.ExecutionPath + WarnLogFileName).Length;
            } catch
            {
                return 0;
            }
        }

        public int GetErrorCount()
        {
            try
            {
                return File.ReadAllLines(Program.ExecutionPath + ErrorLogFileName).Length;
            } catch
            {
                return 0;
            }
        }
    }
}
