using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrexMinerGUI
{
    class SelfUpdate
    {
        private class JsonClass
        {
            public string latestVersion { get; set; }
            public string latestVersionURL { get; set; }
        }

        private readonly System.Threading.Timer TheGUITimer;
        private readonly System.Threading.Timer TheTrexTimer;
        private readonly string JsonURL;
        public readonly Version TheAppVersion;
        private readonly string UpdateFileName;
        private readonly string UpdateFolderName;
        private JsonClass JsonContents { get; set; }
        public bool IsTrexUpdating { get; set; }
        public string TrexUpdatingTo { get; set; }
        public ProcessStartInfo UpdateScript;
        private readonly string LogFileName;

        public SelfUpdate()
        {
            UpdateFileName = "temp_update.zip";
            UpdateFolderName = "temp_update";
            TheAppVersion = typeof(Program).Assembly.GetName().Version;
            JsonURL = "https://raw.githubusercontent.com/forumber/TrexMinerGUI_Updater-API/main/update.json";
            TheGUITimer = new System.Threading.Timer((_) => CheckForGUIUpdate(), null, dueTime: TimeSpan.FromSeconds(2), period: TimeSpan.FromMinutes(1));
            TheTrexTimer = new System.Threading.Timer((_) => CheckForTrexUpdate(), null, dueTime: TimeSpan.FromSeconds(2), period: TimeSpan.FromHours(1));
            IsTrexUpdating = false;
            TrexUpdatingTo = "";
            UpdateScript = null;
            LogFileName = "log_SelfUpdate.txt";
        }

        private void CheckForGUIUpdate()
        {
            try
            {
                string json;

                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString(JsonURL);
                }

                JsonContents = JsonConvert.DeserializeObject<JsonClass>(json);

                if (new Version(JsonContents.latestVersion).CompareTo(TheAppVersion) > 0)
                {
                    UpdateGUI();
                }
            }
            catch { }
        }

        private void CheckForTrexUpdate()
        {
            string LogTag = "CheckForTrexUpdate";

            WriteLog(LogTag, "start");

            if (IsTrexUpdating)
            {
                WriteLog(LogTag, "an update process is already running, aborting update check");
                return;
            }

            if (!Program.TheTrexWrapper.IsRunning)
            {
                WriteLog(LogTag, "miner is not running, aborting update check");
                return;
            }

            try
            {
                Version CurrentTrexVersion;
                try
                {
                    WriteLog(LogTag, "trying to get current miner version information by checking file metadata");
                    CurrentTrexVersion = new Version(ExternalMethods.GetVersionInfo(Program.ExecutionPath + "t-rex.exe", "ProductVersion")[0].Item2.Split(" ")[0]);
                }
                catch
                {
                    WriteLog(LogTag, "trying to get current miner version information by checking file metadata...failed");
                    WriteLog(LogTag, "trying to get current miner version information by using miner version information from miner output");
                    CurrentTrexVersion = Program.TheTrexWrapper.CurrentTrexVersion;
                }

                WriteLog(LogTag, "CurrentTrexVersion: " + CurrentTrexVersion.ToString());

                (Version LatestTrexVersion, string LatestTrexVersionDownloadURL) = GithubAPI.GetLatestTrexRelease();

                WriteLog(LogTag, "LatestTrexVersion: " + LatestTrexVersion.ToString());

                if (LatestTrexVersion > CurrentTrexVersion)
                {
                    WriteLog(LogTag, "firing up update procedure");
                    DownloadAndInstallTrex(LatestTrexVersionDownloadURL, LatestTrexVersion);
                }
            }
            catch (Exception TheException)
            {
                File.AppendAllText(Program.ExecutionPath + LogFileName, Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + TheException.ToString() + Environment.NewLine);
            }
            WriteLog(LogTag, "done");
        }

        public void DownloadAndInstallTrex(String DownloadURL = null, Version TrexVersion = null)
        {
            string LogTag = "DownloadAndInstallLatestTrex";

            WriteLog(LogTag, "start");
            try
            {
                if (DownloadURL == null)
                {
                    WriteLog(LogTag, "there are no args provided, requesting latest version");
                    (TrexVersion, DownloadURL) = GithubAPI.GetLatestTrexRelease();
                }

                if (TrexVersion == null)
                {
                    WriteLog(LogTag, "version information is null, using TrexUpdatingTo");
                    WriteLog(LogTag, "TrexUpdatingTo: " + TrexUpdatingTo);
                }
                else
                {
                    WriteLog(LogTag, "TrexVersion: " + TrexVersion.ToString());
                    TrexUpdatingTo = TrexVersion.ToString() + " (Github)";
                }
                
                Program.TheTrexWrapper.Stop();
                IsTrexUpdating = true;

                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Updating Trex...", "to version " + TrexUpdatingTo, System.Windows.Forms.ToolTipIcon.Info);

                DownloadAndExtractZip(DownloadURL);
                WriteLog(LogTag, "updating...");

                File.Copy(Program.ExecutionPath + UpdateFolderName + @"\" + "t-rex.exe", Program.ExecutionPath + "t-rex.exe", overwrite: true);
                IsTrexUpdating = false;
                WriteLog(LogTag, "update has been completed, restarting miner...");

                Task.Run(() => Program.TheTrexWrapper.Start());

                CleanUp();

                TrexUpdatingTo = "";

                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Trex update completed", "Miner has been restarted", System.Windows.Forms.ToolTipIcon.Info);
                WriteLog(LogTag, "done");

            }
            catch (Exception TheException)
            {
                File.AppendAllText(Program.ExecutionPath + LogFileName, Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + TheException.ToString());
            }
        }

        private void WriteLog(string LogTag, string Message)
        {
            File.AppendAllText(Program.ExecutionPath + LogFileName, DateTime.Now.ToString("s") + " " + LogTag + ": " + Message + Environment.NewLine);
        }

        private void UpdateGUI()
        {
            Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Updating TrexMinerGUI...", "to version " + JsonContents.latestVersion, System.Windows.Forms.ToolTipIcon.Info);

            DownloadAndExtractZip(JsonContents.latestVersionURL);

            UpdateScript = new ProcessStartInfo();
            UpdateScript.Arguments = "/C timeout /t 5 /nobreak && xcopy \"" +
                Program.ExecutionPath + UpdateFolderName + @"\" +
                "\" \"" + Program.ExecutionPath +
                "\" /E /H /Y && start \"\" \"" +
                Program.ExecutionPath + "TrexMinerGUI.exe\"";
            UpdateScript.WindowStyle = ProcessWindowStyle.Hidden;
            UpdateScript.CreateNoWindow = true;
            UpdateScript.FileName = "cmd.exe";
            Application.Exit();
        }

        private void DownloadAndExtractZip(string URL)
        {
            string LogTag = "DownloadAndExtractZip";

            WriteLog(LogTag, "downloading file: " + URL);
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(URL, Program.ExecutionPath + UpdateFileName);
            }
            WriteLog(LogTag, "unzipping " + Program.ExecutionPath + UpdateFileName);

            System.IO.Compression.ZipFile.ExtractToDirectory(Program.ExecutionPath + UpdateFileName, Program.ExecutionPath + UpdateFolderName + @"\", overwriteFiles: true);
        }

        public void CleanUp()
        {
            string LogTag = "CleanUp";

            WriteLog(LogTag, "cleaning...");

            File.Delete(Program.ExecutionPath + UpdateFileName);
            Directory.Delete(Program.ExecutionPath + UpdateFolderName, recursive: true);
        }
    }
}
