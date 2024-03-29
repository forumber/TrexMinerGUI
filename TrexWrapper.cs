﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            public string Shares { get; set; }
            public DateTime LastUpdated { get; set; }
            public int RestartCount { get; set; }

            public TrexStatisctics()
            {
                Speed = "-";
                FanSpeed = "-";
                Power = "-";
                Efficiency = "-";
                Temp = "-";
                Shares = @"0/0";
                LastUpdated = DateTime.Now;
                RestartCount = -1;
            }
        }

        enum LogCategory
        {
            NORMAL,
            WARN,
            ERROR
        }

        private readonly Process TrexProcess;

        public bool IsRunning { get; set; }
        private bool IsTerminatedByGUI { get; set; }
        public TrexStatisctics TheTrexStatisctics { get; set; }
        public string Session { get; set; }
        public bool IsStarting { get; set; }
        public bool IsStopping { get; set; }
        private LogCategory LastLogCategory { get; set; }
        private bool ApplyAfterburnerProfileB { get; set; }
        public Version CurrentTrexVersion { get; set; }
        private int HardRestartCount { get; set; }
        public string HTTPUrl { get; set; }

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

            IsRunning = false;
            IsStarting = false;
            IsStopping = false;
            IsTerminatedByGUI = false;
            TheTrexStatisctics = new TrexStatisctics();
            Session = "-";
            LastLogCategory = LogCategory.NORMAL;
            ApplyAfterburnerProfileB = true;
            CurrentTrexVersion = null;
            HardRestartCount = 0;
            HTTPUrl = "";
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
                    if (e.Data.Contains("version"))
                    {
                        Program.TheSelfUpdate.TrexUpdatingTo = e.Data.Split(" ")[2];
                    }
                    if (e.Data.Contains("download"))
                    {
                        ApplyAfterburnerProfileB = false;
                        Task.Run(() => Program.TheSelfUpdate.DownloadAndInstallTrex(DownloadURL: e.Data.Split(" ")[2]));
                    }
                }
                else if (e.Data.StartsWith(@"GPU #0:"))
                {
                    TheTrexStatisctics.LastUpdated = DateTime.Now;

                    try
                    {
                        var Statistics = e.Data.Split(" - ")[1].Split(", ");

                        TheTrexStatisctics.Speed = Statistics.FirstOrDefault();

                        // If we can get this far on that code, that means the miner is running. Start the stopwatch if it has not been fired already.
                        if (!Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                        {
                            Program.TheStopWatchWrapper.TheStopWatch.Start();
                        }

                        foreach (var TheStatistic in Statistics)
                        {
                            var TrimmedStat = TheStatistic.Replace("[", "").Replace("]", "").Split(":");

                            if (TrimmedStat[0] == "T")
                                TheTrexStatisctics.Temp = TrimmedStat[1];
                            else if (TrimmedStat[0] == "P")
                                TheTrexStatisctics.Power = TrimmedStat[1];
                            else if (TrimmedStat[0] == "F")
                                TheTrexStatisctics.FanSpeed = TrimmedStat[1];
                            else if (TrimmedStat[0] == "E")
                                TheTrexStatisctics.Efficiency = TrimmedStat[1];
                        }

                        if (char.IsDigit(Statistics.LastOrDefault()[0]))
                            TheTrexStatisctics.Shares = Statistics.LastOrDefault();
                    }
                    catch (Exception TheException)
                    {
                        if (!(TheException is ArgumentOutOfRangeException))
                            File.AppendAllText(Program.ExecutionPath + Program.ExceptionLogFileName, Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + TheException.ToString() + Environment.NewLine);
                    }
                }
                else
                {
                    string DateTimeHeader = e.Data.Substring(0, 17);
                    string Info = e.Data.Substring(18);

                    //Debug.WriteLine("DateTimeHeader:" + DateTimeHeader);
                    //Debug.WriteLine("Info:" + Info);

                    if (Info.Contains("Starting on:"))
                        TheTrexStatisctics.RestartCount++;

                    if (Info.Contains("For control navigate to: "))
                        HTTPUrl = Info.Replace("For control navigate to: ", "");

                    if (Info.Contains("OK"))
                    {
                        if (!Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                            Program.TheStopWatchWrapper.TheStopWatch.Start();
                    }
                    else if (Info.ToLowerInvariant().Contains("error") || Info.ToLowerInvariant().Contains("exception") || Info.ToLowerInvariant().Contains("fail"))
                    {
                        if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                            Program.TheStopWatchWrapper.TheStopWatch.Stop();

                        if (Program.TheConfig.TheEmailSetting.SendMail)
                            SendEmail(e.Data);
                    }
                    else if (Info.StartsWith("T-Rex NVIDIA GPU miner v"))
                    {
                        CurrentTrexVersion = new Version(Info.Split(" ")[4].Substring(1));
                    }
                }
            }
            catch (Exception TheException)
            {
                if (!(TheException is ArgumentOutOfRangeException))
                    File.AppendAllText(Program.ExecutionPath + Program.ExceptionLogFileName, Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + TheException.ToString() + Environment.NewLine);
            }
        }

        public string GetErrorLogPathForCurrentSession()
        {
            return Program.ExecutionPath + @"logs\log_" + Session + "_error.txt";
        }

        public string GetWarningLogPathForCurrentSession()
        {
            return Program.ExecutionPath + @"logs\log_" + Session + "_warn.txt";
        }

        public string GetLogPathForCurrentSession()
        {
            return Program.ExecutionPath + @"logs\log_" + Session + ".txt";
        }

        private void WriteLogToFile(string LineToWrite)
        {
            if (String.IsNullOrEmpty(LineToWrite))
                return;

            if (LineToWrite.StartsWith(DateTime.Today.ToString("yyyyMMdd")))
            {
                string Tag = LineToWrite.Split(' ')[2];

                if (Tag == "ERROR:")
                    LastLogCategory = LogCategory.ERROR;
                else if (Tag == "WARN:" && (!(LineToWrite.ToLowerInvariant().Contains("devfee") || LineToWrite.ToLowerInvariant().Contains("intensity") || LineToWrite.ToLowerInvariant().Contains("from console"))))
                    LastLogCategory = LogCategory.WARN;
                else
                {
                    if (LineToWrite.ToLowerInvariant().Contains("error") || LineToWrite.ToLowerInvariant().Contains("exception") || LineToWrite.ToLowerInvariant().Contains("fail"))
                        LastLogCategory = LogCategory.ERROR;
                    else if (LineToWrite.ToLowerInvariant().Contains("warn") && (!(LineToWrite.ToLowerInvariant().Contains("devfee") || LineToWrite.ToLowerInvariant().Contains("intensity") || LineToWrite.ToLowerInvariant().Contains("from console"))))
                        LastLogCategory = LogCategory.WARN;
                    else
                        LastLogCategory = LogCategory.NORMAL;
                }
            }
            else if (LineToWrite.StartsWith("--") || LineToWrite.StartsWith("#"))
            {
                LastLogCategory = LogCategory.NORMAL;
            } // else use the last log catagory

            string LogPathToWrite = "";

            switch (LastLogCategory)
            {
                case LogCategory.ERROR:
                    LogPathToWrite = GetErrorLogPathForCurrentSession();
                    break;
                case LogCategory.WARN:
                    LogPathToWrite = GetWarningLogPathForCurrentSession();
                    break;
                case LogCategory.NORMAL:
                    LogPathToWrite = GetLogPathForCurrentSession();
                    break;
            }

            File.AppendAllText(LogPathToWrite, LineToWrite + Environment.NewLine);
        }

        public void Start(bool ResetHardRestartCount = true)
        {
            if (Program.TheSelfUpdate.IsTrexUpdating || IsStarting)
            {
                return;
            }

            if (Process.GetProcessesByName("t-rex").Length > 0)
            {
                Stop();
            }

            while (IsStopping)
            {
                Task.Delay(100).Wait();
            }

            if (!File.Exists(Program.ExecutionPath + "t-rex.exe"))
            {
                Task.Run(() => Program.TheSelfUpdate.DownloadAndInstallTrex());
                return;
            }

            IsStarting = true;

            if (ResetHardRestartCount)
                HardRestartCount = 0;

            TheTrexStatisctics = new TrexStatisctics();

            Session = DateTime.Now.ToString("yyyyMMdd'-'HHmmss");

            if (!Directory.Exists(Program.ExecutionPath + @"logs\"))
            {
                Directory.CreateDirectory(Program.ExecutionPath + @"logs\");
            }

            TrexProcess.StartInfo.Arguments = Program.TheConfig.ActiveProfile.MinerArgs;

            if (!TrexProcess.StartInfo.Arguments.Contains("--api-read-only"))
                TrexProcess.StartInfo.Arguments += " --api-read-only";

            TrexProcess.Start();
            TrexProcess.BeginOutputReadLine();
            TrexProcess.BeginErrorReadLine();

            IsRunning = true;

            if (ApplyAfterburnerProfileB && Program.TheConfig.ActiveProfile.ApplyAfterburnerProfileOnMinerStart)
                ExternalMethods.ApplyAfterburnerProfile(int.Parse(Program.TheConfig.ActiveProfile.ProfileToApplyOnMinerStart));

            IsStarting = false;

            //ExternalMethods.OpenConsole();

            // Always reset just in case
            ApplyAfterburnerProfileB = true;

            Program.TheSelfUpdate.StartTrexUpdateTimer();

        }

        private void ProcExitedHandler(object sender, EventArgs e)
        {
            Program.TheSelfUpdate.StopTrexUpdateTimer();
            CurrentTrexVersion = null;
            HTTPUrl = "";

            IsRunning = false;

            TrexProcess.CancelOutputRead();
            TrexProcess.CancelErrorRead();

            if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                Program.TheStopWatchWrapper.TheStopWatch.Stop();

            if (IsTerminatedByGUI)
            {
                IsTerminatedByGUI = false;

                if (ApplyAfterburnerProfileB && Program.TheConfig.ActiveProfile.ApplyAfterburnerProfileOnMinerClose)
                    ExternalMethods.ApplyAfterburnerProfile(int.Parse(Program.TheConfig.ActiveProfile.ProfileToApplyOnMinerClose));

                IsStopping = false;
            }
            else if (!IsStopping)
            {
                HardRestartCount++;
                ApplyAfterburnerProfileB = false;
                IsStopping = false;
                if (HardRestartCount > 2)
                {
                    Stop();
                    MessageBox.Show("Trex got hard restarted multiple times.\nPlease review your miner arguments!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    Start(ResetHardRestartCount: false);
                }
            }

            //ExternalMethods.CloseConsole();
        }

        public void Stop()
        {
            if (IsStopping)
                goto waitForStop;

            while (IsStarting)
            {
                Task.Delay(100).Wait();
            }

            IsStopping = true;

            IsTerminatedByGUI = true;

            try
            {
                ExternalMethods.StopProgram(TrexProcess);
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
                IsStopping = false;
            }

        waitForStop:
            while (IsStopping || Process.GetProcessesByName("t-rex").Length > 0)
            {
                Task.Delay(100).Wait();
            }
        }

        public int GetWarnCount()
        {
            try
            {
                return File.ReadAllLines(GetWarningLogPathForCurrentSession()).Where((TheString) => TheString.StartsWith(DateTime.Today.ToString("yyyy"))).Count();
            }
            catch
            {
                return 0;
            }
        }

        public int GetErrorCount()
        {
            try
            {
                return File.ReadAllLines(GetErrorLogPathForCurrentSession()).Where((TheString) => TheString.StartsWith(DateTime.Today.ToString("yyyy"))).Count();
            }
            catch
            {
                return 0;
            }
        }

        public string GetStatus()
        {
            if (IsStopping)
                return "Stopping...";
            else if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                return "Running";
            else if (Program.TheSelfUpdate.IsTrexUpdating)
                return "Updating...";
            else if (!Program.TheStopWatchWrapper.TheStopWatch.IsRunning && (IsRunning || IsStarting))
                return "Starting...";
            else //if (!Program.TheStopWatchWrapper.TheStopWatch.IsRunning && !Program.TheTrexWrapper.IsRunning)
                return "Not running";
        }

        public void Restart()
        {
            ApplyAfterburnerProfileB = false;
            Stop();
            Start();
        }

        private void SendEmail(string Message)
        {
            try
            {
                using (var smtpClient = new System.Net.Mail.SmtpClient(host: Program.TheConfig.TheEmailSetting.Host, port: Program.TheConfig.TheEmailSetting.Port))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential(Program.TheConfig.TheEmailSetting.UserName, Program.TheConfig.TheEmailSetting.Password);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(from: Program.TheConfig.TheEmailSetting.SendFrom,
                        recipients: Program.TheConfig.TheEmailSetting.SendTo,
                        subject: Program.TheConfig.TheEmailSetting.Subject,
                        body: Message);
                }
            } catch { }
        }
    }
}
