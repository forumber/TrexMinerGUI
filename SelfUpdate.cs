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

        private readonly System.Threading.Timer TheTimer;
        private readonly string JsonURL;
        public readonly Version TheAppVersion;
        private readonly string UpdateFileName;
        private readonly string UpdateFolderName;
        private JsonClass JsonContents { get; set; }
        public bool IsTrexUpdating { get; set; }
        public string TrexUpdatingTo { get; set; }

        public SelfUpdate()
        {
            UpdateFileName = "temp_update.zip";
            UpdateFolderName = "temp_update";
            TheAppVersion = typeof(Program).Assembly.GetName().Version;
            JsonURL = "https://raw.githubusercontent.com/forumber/TrexMinerGUI_Updater-API/main/update.json";
            TheTimer = new System.Threading.Timer((e) => CheckForUpdate(), null, dueTime: TimeSpan.FromSeconds(2), period: TimeSpan.FromMinutes(1));
            IsTrexUpdating = false;
            TrexUpdatingTo = "";
        }

        private void CheckForUpdate()
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
                    Update();
                }
            }
            catch { }
        }

        private void Update()
        {
            Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Updating TrexMinerGUI...", " ", System.Windows.Forms.ToolTipIcon.Info);

            DownloadAndExtractZip(JsonContents.latestVersionURL);

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C timeout /t 30 /nobreak && xcopy \"" +
                Program.ExecutionPath + UpdateFolderName + @"\" +
                "\" \"" + Program.ExecutionPath +
                "\" /E /H /Y && start \"\" \"" +
                Program.ExecutionPath + "TrexMinerGUI.exe\"";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            Application.Exit();
        }

        private void DownloadAndExtractZip(string URL)
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(URL, Program.ExecutionPath + UpdateFileName);
            }

            System.IO.Compression.ZipFile.ExtractToDirectory(Program.ExecutionPath + UpdateFileName, Program.ExecutionPath + UpdateFolderName + @"\", overwriteFiles: true);
        }

        public void UpdateTrex(string URL)
        {
            IsTrexUpdating = true;


            if (!String.IsNullOrEmpty(TrexUpdatingTo))
                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Updating Trex...", "to version " + TrexUpdatingTo, System.Windows.Forms.ToolTipIcon.Info);
            else
                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Updating Trex...", " ", System.Windows.Forms.ToolTipIcon.Info);

            DownloadAndExtractZip(URL);

            File.Copy(Program.ExecutionPath + UpdateFolderName + @"\" + "t-rex.exe", Program.ExecutionPath + "t-rex.exe", true);

            IsTrexUpdating = false;

            Task.Run(() => Program.TheTrexWrapper.Start());

            CleanUp();

            TrexUpdatingTo = "";

            Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Trex update completed", "Miner has been restarted", System.Windows.Forms.ToolTipIcon.Info);
        }

        public void CleanUp()
        {
            File.Delete(Program.ExecutionPath + UpdateFileName);
            Directory.Delete(Program.ExecutionPath + UpdateFolderName, recursive: true);
        }
    }
}
