using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrexMinerGUI
{
    public class Config
    {
        public string MinerArgs { get; set; }
        public bool StartMiningOnAppStart { get; set; }
        public bool ApplyAfterburnerProfileOnMinerStart { get; set; }
        public bool ApplyAfterburnerProfileOnMinerClose { get; set; }
        public string ProfileToApplyOnMinerStart { get; set; }
        public string ProfileToApplyOnMinerClose { get; set; }

        public Config()
        {
            try
            {
                var Lines = File.ReadAllLines(Program.ExecutionPath + "trex_gui.conf");

                foreach (string Line in Lines)
                {
                    string[] Sections = Line.Split("=");
                    if (Sections[0] == "MinerArgs")
                        MinerArgs = Sections[1];
                    else if (Sections[0] == "StartMiningOnAppStart")
                        StartMiningOnAppStart = Sections[1] == "True";
                    else if (Sections[0] == "ApplyAfterburnerProfileOnMinerStart")
                        ApplyAfterburnerProfileOnMinerStart = Sections[1] == "True";
                    else if (Sections[0] == "ApplyAfterburnerProfileOnMinerClose")
                        ApplyAfterburnerProfileOnMinerClose = Sections[1] == "True";
                    else if (Sections[0] == "ProfileToApplyOnMinerStart")
                        ProfileToApplyOnMinerStart = Sections[1];
                    else if (Sections[0] == "ProfileToApplyOnMinerClose")
                        ProfileToApplyOnMinerClose = Sections[1];
                }

                if (String.IsNullOrEmpty(MinerArgs) ||
                        String.IsNullOrEmpty(ProfileToApplyOnMinerStart) ||
                        String.IsNullOrEmpty(ProfileToApplyOnMinerClose))
                {
                    throw new ArgumentException();
                }

            } catch {
                MinerArgs = "";
                StartMiningOnAppStart = false;
                ApplyAfterburnerProfileOnMinerStart = false;
                ApplyAfterburnerProfileOnMinerClose = false;
                ProfileToApplyOnMinerStart = "1";
                ProfileToApplyOnMinerClose = "1";

                Task.Run(() => {
                    using (var TheStatisticsForm = new StatisticsForm())
                    {
                        TheStatisticsForm.ShowDialog();
                    }
                });
            }

            
        }

        public void SaveConfigToFile()
        {
            string TheFileContent =
                "MinerArgs=" + MinerArgs + Environment.NewLine +
                "StartMiningOnAppStart=" + StartMiningOnAppStart + Environment.NewLine +
                "ApplyAfterburnerProfileOnMinerStart=" + ApplyAfterburnerProfileOnMinerStart + Environment.NewLine +
                "ApplyAfterburnerProfileOnMinerClose=" + ApplyAfterburnerProfileOnMinerClose + Environment.NewLine +
                "ProfileToApplyOnMinerStart=" + ProfileToApplyOnMinerStart + Environment.NewLine +
                "ProfileToApplyOnMinerClose=" + ProfileToApplyOnMinerClose + Environment.NewLine;

            ExternalMethods.WriteAllTextWithBackup(Program.ExecutionPath + "trex_gui.conf", TheFileContent);
        }
    }
}
