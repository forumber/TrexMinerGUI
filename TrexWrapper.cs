using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TrexMinerGUI
{
    public class TrexWrapper
    {
        public class TrexStatisctics
        {
            public string Speed;
            public string FanSpeed;
            public string Power;
            public string Temp;
            public string LastUpdated;

            public TrexStatisctics()
            {
                Speed = "0";
                FanSpeed = "0";
                Power = "0";
                Temp = "0";
                LastUpdated = "";
            }
        }

        public class TrexConfig
        {
            public string Algorithm;
            public string URL;
            public string Address;
            public string WorkerName;

            public TrexConfig(string Algorithm, string URL, string Address, string WorkerName)
            {
                this.Algorithm = Algorithm;
                this.URL = URL;
                this.Address = Address;
                this.WorkerName = WorkerName;
            }
        }

        private readonly Process TrexProcess;

        public readonly string LogFileName;
        public readonly string ErrorLogFileName;
        public readonly string TrexWrapperErrorLogFileName;
        public readonly string WarnLogFileName;

        private readonly string ConfigFileName;
        private TrexConfig TheTrexConfig;

        public bool IsRunning;
        private bool IsTerminatedByGUI;
        public readonly TrexStatisctics TheTrexStatisctics;

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
            TrexProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler); // T-Rex does not give any output to stderr, lets put it in here anyway
            TrexProcess.Exited += new EventHandler(ProcExitedHandler); 

            LogFileName = "trex_log.txt";
            ErrorLogFileName = "trex_error_log.txt";
            WarnLogFileName = "trex_warn_log.txt";
            ConfigFileName = "trex_gui.conf";
            TrexWrapperErrorLogFileName = "trex_gui_error_log.txt";
            IsRunning = false;
            IsTerminatedByGUI = false;
            TheTrexStatisctics = new TrexStatisctics();

            GetTrexConfig();
            TrexProcess.StartInfo.Arguments = "-a " + TheTrexConfig.Algorithm + " -o " + TheTrexConfig.URL + " -u " + TheTrexConfig.Address + " -p x -w " + TheTrexConfig.WorkerName;
        }

        private void GetTrexConfig()
        {
            var Lines = File.ReadAllLines(Program.ExecutionPath + ConfigFileName);

            string Algorithm = "", URL = "", Address = "", WorkerName = "";

            foreach (string Line in Lines)
            {
                string[] Sections = Line.Split("=");
                if (Sections[0] == "Algorithm")
                    Algorithm = Sections[1];
                else if (Sections[0] == "URL")
                    URL = Sections[1];
                else if (Sections[0] == "Address")
                    Address = Sections[1];
                else if (Sections[0] == "WorkerName")
                    WorkerName = Sections[1];
            }

            TheTrexConfig = new TrexConfig(Algorithm, URL, Address, WorkerName);
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            WriteLogToFile(e.Data);

            try
            {
                //Console.WriteLine("OutputHandler: " + e.Data);

                string DateTimeHeader = e.Data.Substring(0, 17);
                string Info = e.Data.Substring(18);

                //Debug.WriteLine("DateTimeHeader:" + DateTimeHeader);
                //Debug.WriteLine("Info:" + Info);

                if (Info.Contains("epoch") && !Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                {
                    Program.TheStopWatchWrapper.TheStopWatch.Start();
                }
                else if (Info.ToLower().Contains("error"))
                {
                    if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                        Program.TheStopWatchWrapper.TheStopWatch.Stop();
                }
                else if (Info.StartsWith(@"GPU #0:"))
                {
                    try
                    {
                        var Statistics = Info.Split(" - ")[1].Split(",");
                        TheTrexStatisctics.Speed = Statistics[0];
                        TheTrexStatisctics.Temp = Statistics[1].Substring(4);
                        TheTrexStatisctics.Power = Statistics[2].Substring(3);
                        TheTrexStatisctics.FanSpeed = Statistics[3].Substring(3);
                        TheTrexStatisctics.LastUpdated = DateTimeHeader.Split(" ")[1];
                    }
                    catch
                    {

                    }
                }
            } 
            catch (Exception TheException)
            {
                File.AppendAllText(Program.ExecutionPath + LogFileName, TheException.ToString() + Environment.NewLine);
            }

            
        }

        private void WriteLogToFile(string LineToWrite)
        {
            if (LineToWrite.ToLower().Contains("error"))
            {
                File.AppendAllText(Program.ExecutionPath + ErrorLogFileName, LineToWrite + Environment.NewLine);
            }
            else if (LineToWrite.ToLower().Contains("warn") && (!(LineToWrite.ToLower().Contains("devfee") || LineToWrite.ToLower().Contains("intensity set to"))))
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
            TrexProcess.Start();
            TrexProcess.BeginOutputReadLine();
            TrexProcess.BeginErrorReadLine();

            IsRunning = true;

            //ExternalMethods.OpenConsole();

        }

        private void ProcExitedHandler(object sender, EventArgs e)
        {
            TrexProcess.CancelOutputRead();
            TrexProcess.CancelErrorRead();
            IsRunning = false;

            if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                Program.TheStopWatchWrapper.TheStopWatch.Stop();

            if (IsTerminatedByGUI)
                IsTerminatedByGUI = false;
            else
                Start();

            //ExternalMethods.CloseConsole();
        }

        public void Stop()
        {
            IsTerminatedByGUI = true;

            try
            {
                TrexProcess.Kill();
                TrexProcess.WaitForExit();
            } catch (Exception)
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
            } catch (Exception)
            {
                return 0;
            }
        }

        public int GetErrorCount()
        {
            try
            {
                return File.ReadAllLines(Program.ExecutionPath + ErrorLogFileName).Length;
            } catch (Exception)
            {
                return 0;
            }
        }
    }
}
