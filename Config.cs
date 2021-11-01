using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using TrexMinerGUI.Forms;

namespace TrexMinerGUI
{
    public class Config
    {
        private readonly string InvalidMinerArgsMessage = "Invalid MinerArgs!";
        private string _minerArgs;
        public string MinerArgs { 
            get
            {
                return _minerArgs;
            }
            set
            {
                string[] fields = value.Split(" ");
                if (
                    fields[0] == "t-rex" ||
                    (!fields.Contains("-a") && !fields.Contains("--algo")) ||
                    (!fields.Contains("-o") && !fields.Contains("--url"))
                )
                {
                    throw new ArgumentException(InvalidMinerArgsMessage);
                }

                _minerArgs = value;
            }
        }
        public bool StartMiningOnAppStart { get; set; }
        public bool ApplyAfterburnerProfileOnMinerStart { get; set; }
        public bool ApplyAfterburnerProfileOnMinerClose { get; set; }
        public bool TryToCloseMSIAfterburnerIfItIsNotRunningAlready { get; set; }
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
                    else if (Sections[0] == "TryToCloseMSIAfterburnerIfItIsNotRunningAlready")
                        TryToCloseMSIAfterburnerIfItIsNotRunningAlready = Sections[1] == "True";
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

            }
            catch (Exception TheException)
            {
                if (TheException.Message == InvalidMinerArgsMessage)
                    throw TheException;

                // https://github.com/trexminer/T-Rex#examples
                MinerArgs = "-a ethash -o stratum+tcp://eth.2miners.com:2020 -u 0x1f75eccd8fbddf057495b96669ac15f8e296c2cd -p x -w rigTrexTest";
                StartMiningOnAppStart = false;
                ApplyAfterburnerProfileOnMinerStart = false;
                ApplyAfterburnerProfileOnMinerClose = false;
                TryToCloseMSIAfterburnerIfItIsNotRunningAlready = true;
                ProfileToApplyOnMinerStart = "1";
                ProfileToApplyOnMinerClose = "1";

                Task.Run(() =>
                {
                    using (var TheMainForm = new MainForm())
                    {
                        TheMainForm.ShowDialog();
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
                "TryToCloseMSIAfterburnerIfItIsNotRunningAlready=" + TryToCloseMSIAfterburnerIfItIsNotRunningAlready + Environment.NewLine +
                "ProfileToApplyOnMinerStart=" + ProfileToApplyOnMinerStart + Environment.NewLine +
                "ProfileToApplyOnMinerClose=" + ProfileToApplyOnMinerClose + Environment.NewLine;

            ExternalMethods.WriteAllTextWithBackup(Program.ExecutionPath + "trex_gui.conf", TheFileContent);
        }
    }
}
