using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
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
        private System.Threading.Timer TheTrexTimer;
        private readonly string JsonURL;
        public readonly Version TheAppVersion;
        private readonly string UpdateFileName;
        private readonly string UpdateFolderName;
        private JsonClass JsonContents { get; set; }
        public bool IsTrexUpdating { get; set; }
        public string TrexUpdatingTo { get; set; }
        public ProcessStartInfo UpdateScript;

        public SelfUpdate()
        {
            UpdateFileName = "temp_update.zip";
            UpdateFolderName = "temp_update";
            TheAppVersion = typeof(Program).Assembly.GetName().Version;
            JsonURL = "https://raw.githubusercontent.com/forumber/TrexMinerGUI_Updater-API/main/update.json";
            TheGUITimer = new System.Threading.Timer((_) => CheckForGUIUpdate(), null, dueTime: TimeSpan.FromSeconds(2), period: TimeSpan.FromMinutes(1));
            TheTrexTimer = null;
            IsTrexUpdating = false;
            TrexUpdatingTo = "";
            UpdateScript = null;
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
            Logging.WriteLog(MethodBase.GetCurrentMethod(), "start");

            if (IsTrexUpdating)
            {
                Logging.WriteLog(MethodBase.GetCurrentMethod(), "an update process is already running, aborting update check");
                return;
            }

            if (!Program.TheTrexWrapper.IsRunning)
            {
                Logging.WriteLog(MethodBase.GetCurrentMethod(), "miner is not running, aborting update check");
                return;
            }

            try
            {
                Version CurrentTrexVersion;
                try
                {
                    CurrentTrexVersion = Program.TheTrexWrapper.CurrentTrexVersion;

                    if (CurrentTrexVersion < (new Version("0.20.0")))
                        throw new Exception();
                }
                catch
                {
                    Logging.WriteLog(MethodBase.GetCurrentMethod(), "failed to get current miner version information by using miner version information from miner output, trying again by checking file metadata");
                    CurrentTrexVersion = new Version(ExternalMethods.GetVersionInfo(Program.ExecutionPath + "t-rex.exe", "ProductVersion")[0].Item2.Split(" ")[0]);
                }

                Logging.WriteLog(MethodBase.GetCurrentMethod(), "CurrentTrexVersion: " + CurrentTrexVersion.ToString());

                (Version LatestTrexVersion, string LatestTrexVersionDownloadURL) = GithubAPI.GetLatestTrexRelease();

                Logging.WriteLog(MethodBase.GetCurrentMethod(), "LatestTrexVersion: " + LatestTrexVersion.ToString());

                if (LatestTrexVersion > CurrentTrexVersion)
                {
                    Logging.WriteLog(MethodBase.GetCurrentMethod(), "firing up update procedure");
                    DownloadAndInstallTrex(LatestTrexVersionDownloadURL, LatestTrexVersion);
                }
            }
            catch (Exception TheException)
            {
                Logging.WriteLog(MethodBase.GetCurrentMethod(), Environment.NewLine + TheException.ToString());
            }
            Logging.WriteLog(MethodBase.GetCurrentMethod(), "done");
        }

        public void DownloadAndInstallTrex(String DownloadURL = null, Version TrexVersion = null)
        {
            Logging.WriteLog(MethodBase.GetCurrentMethod(), "start");
            try
            {
                if (DownloadURL == null)
                {
                    Logging.WriteLog(MethodBase.GetCurrentMethod(), "there are no args provided, requesting latest version");
                    (TrexVersion, DownloadURL) = GithubAPI.GetLatestTrexRelease();
                }

                if (TrexVersion == null)
                {
                    Logging.WriteLog(MethodBase.GetCurrentMethod(), "version information is null, using TrexUpdatingTo");
                    Logging.WriteLog(MethodBase.GetCurrentMethod(), "TrexUpdatingTo: " + TrexUpdatingTo);
                }
                else
                {
                    Logging.WriteLog(MethodBase.GetCurrentMethod(), "TrexVersion: " + TrexVersion.ToString());
                    TrexUpdatingTo = TrexVersion.ToString() + " (Github)";
                }
                
                Program.TheTrexWrapper.Stop();
                IsTrexUpdating = true;

                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Updating Trex...", "to version " + TrexUpdatingTo, System.Windows.Forms.ToolTipIcon.Info);

                DownloadAndExtractZip(DownloadURL);
                Logging.WriteLog(MethodBase.GetCurrentMethod(), "updating...");

                File.Copy(Program.ExecutionPath + UpdateFolderName + @"\" + "t-rex.exe", Program.ExecutionPath + "t-rex.exe", overwrite: true);
                IsTrexUpdating = false;
                Logging.WriteLog(MethodBase.GetCurrentMethod(), "update has been completed, restarting miner...");

                Task.Run(() => Program.TheTrexWrapper.Start());

                CleanUp();

                TrexUpdatingTo = "";

                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Trex update completed", "Miner has been restarted", System.Windows.Forms.ToolTipIcon.Info);
                Logging.WriteLog(MethodBase.GetCurrentMethod(), "done");

            }
            catch (Exception TheException)
            {
                Logging.WriteLog(MethodBase.GetCurrentMethod(), Environment.NewLine + TheException.ToString());
            }
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
            Logging.WriteLog(MethodBase.GetCurrentMethod(), "downloading file: " + URL);
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(URL, Program.ExecutionPath + UpdateFileName);
            }
            Logging.WriteLog(MethodBase.GetCurrentMethod(), "unzipping " + Program.ExecutionPath + UpdateFileName);

            System.IO.Compression.ZipFile.ExtractToDirectory(Program.ExecutionPath + UpdateFileName, Program.ExecutionPath + UpdateFolderName + @"\", overwriteFiles: true);
        }

        public void CleanUp()
        {
            Logging.WriteLog(MethodBase.GetCurrentMethod(), "cleaning...");

            try
            {
                File.Delete(Program.ExecutionPath + UpdateFileName);
            }
            catch { }

            try
            {
                Directory.Delete(Program.ExecutionPath + UpdateFolderName, recursive: true);
            }
            catch { }
        }

        public void StartTrexUpdateTimer()
        {
            if (TheTrexTimer == null)
                TheTrexTimer = new System.Threading.Timer((_) => CheckForTrexUpdate(), null, dueTime: TimeSpan.FromSeconds(10), period: TimeSpan.FromDays(1));
            else
                throw new InvalidOperationException("Timer is already running");
        }

        public void StopTrexUpdateTimer()
        {
            if (TheTrexTimer != null)
            {
                TheTrexTimer.Dispose();
                TheTrexTimer = null;
            }
            else
                throw new InvalidOperationException("Timer is not running already");
        }
    }
}
