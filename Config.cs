using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using TrexMinerGUI.Forms;
using Newtonsoft.Json;
using System.Reflection;

namespace TrexMinerGUI
{
    public class Config
    {
        private static readonly string InvalidMinerArgsMessage = "Invalid MinerArgs!";
        private static readonly string InvalidDefaultProfileNameMessage = "Invalid DefaultProfileName!";
        private static readonly string InvalidProfileNamesMessage = "Invalid Profile Names!";
        private string _activeProfileName;
        private static string ConfigFilePath { get => Program.ExecutionPath + "config.json"; }

        public class Profile
        {
            public string Name { get; set; }
            private string _minerArgs;
            public string MinerArgs
            {
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
            public bool ApplyAfterburnerProfileOnMinerStart { get; set; }
            public bool ApplyAfterburnerProfileOnMinerClose { get; set; }
            public string ProfileToApplyOnMinerStart { get; set; }
            public string ProfileToApplyOnMinerClose { get; set; }
        }

        public bool StartMiningOnAppStart { get; set; }
        public bool TryToCloseMSIAfterburnerIfItIsNotRunningAlready { get; set; }
        public List<Profile> Profiles { get; set; }
        [JsonIgnore]
        public Profile ActiveProfile { get; private set; }
        [JsonProperty]
        public string ActiveProfileName
        {
            private get => _activeProfileName;
            set
            {
                ActiveProfile = Profiles.Find(x => x.Name == value);
                if (ActiveProfile == null) throw new ArgumentException(InvalidDefaultProfileNameMessage);
                _activeProfileName = value;
            }
        }
        [JsonIgnore]
        public bool IsConfigHasBeenReset { get; private set; } = false;

        public void SaveConfigToFile()
        {
            string TheFileContent = JsonConvert.SerializeObject(this, Formatting.Indented);

            ExternalMethods.WriteAllTextWithBackup(ConfigFilePath, TheFileContent);
        }

        public bool DeleteProfile(Profile TheProfile)
        {
            if (TheProfile == ActiveProfile)
                return false;

            if (Profiles.Remove(TheProfile))
            {
                SaveConfigToFile();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private static Profile GenerateNewProfile(String ProfileName = null)
        {
            string NewProfileName = ProfileName != null ? ProfileName : "default";

            return new Profile
            {
                // https://github.com/trexminer/T-Rex#examples
                MinerArgs = "-a ethash -o stratum+tcp://eth.2miners.com:2020 -u 0x1f75eccd8fbddf057495b96669ac15f8e296c2cd -p x -w rigTrexTest",
                Name = NewProfileName,
                ApplyAfterburnerProfileOnMinerClose = false,
                ApplyAfterburnerProfileOnMinerStart = false,
                ProfileToApplyOnMinerClose = "1",
                ProfileToApplyOnMinerStart = "1"
            };
        }

        public int CreateProfile()
        {
            string NewProfileName = "NewProfile";
            int prefix = 1;

            while (Profiles.Find(x => x.Name == NewProfileName + prefix) != null)
            {
                prefix++;
            }

            Profiles.Add(GenerateNewProfile(NewProfileName + prefix));
            SaveConfigToFile();

            return Profiles.Count - 1;
        }

        public static Config LoadConfigFile()
        {
            try
            {
                if (File.Exists(Program.ExecutionPath + "trex_gui.conf"))
                {
                    Config newConfig = new Config
                    {
                        Profiles = new List<Profile>
                        {
                            GenerateNewProfile()
                        }
                    };

                    newConfig.ActiveProfileName = newConfig.Profiles[0].Name;

                    var Lines = File.ReadAllLines(Program.ExecutionPath + "trex_gui.conf");

                    foreach (string Line in Lines)
                    {
                        string[] Sections = Line.Split("=");
                        switch (Sections[0])
                        {
                            case "MinerArgs":
                                newConfig.Profiles[0].MinerArgs = Sections[1];
                                break;
                            case "StartMiningOnAppStart":
                                newConfig.StartMiningOnAppStart = Sections[1] == "True";
                                break;
                            case "ApplyAfterburnerProfileOnMinerStart":
                                newConfig.Profiles[0].ApplyAfterburnerProfileOnMinerStart = Sections[1] == "True";
                                break;
                            case "ApplyAfterburnerProfileOnMinerClose":
                                newConfig.Profiles[0].ApplyAfterburnerProfileOnMinerClose = Sections[1] == "True";
                                break;
                            case "TryToCloseMSIAfterburnerIfItIsNotRunningAlready":
                                newConfig.TryToCloseMSIAfterburnerIfItIsNotRunningAlready = Sections[1] == "True";
                                break;
                            case "ProfileToApplyOnMinerStart":
                                newConfig.Profiles[0].ProfileToApplyOnMinerStart = Sections[1];
                                break;
                            case "ProfileToApplyOnMinerClose":
                                newConfig.Profiles[0].ProfileToApplyOnMinerClose = Sections[1];
                                break;
                        }
                    }

                    if (String.IsNullOrEmpty(newConfig.Profiles[0].MinerArgs) ||
                            String.IsNullOrEmpty(newConfig.Profiles[0].ProfileToApplyOnMinerStart) ||
                            String.IsNullOrEmpty(newConfig.Profiles[0].ProfileToApplyOnMinerClose))
                    {
                        throw new ArgumentException();
                    }

                    newConfig.SaveConfigToFile();

                    File.Delete(Program.ExecutionPath + "trex_gui.conf");
                    File.Delete(Program.ExecutionPath + "trex_gui.conf.backup");

                    return newConfig;
                }

                var JsonString = File.ReadAllText(ConfigFilePath);

                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    CheckAdditionalContent = true,
                    MissingMemberHandling = MissingMemberHandling.Error
                };

                var LoadedConfig = JsonConvert.DeserializeObject<Config>(JsonString, jsonSerializerSettings);

                if (LoadedConfig == null)
                    throw new FileNotFoundException();

                if (LoadedConfig.Profiles.Select(s => s.Name).Distinct().Count() != LoadedConfig.Profiles.Select(s => s.Name).Count() ||
                    LoadedConfig.ActiveProfile == null)
                    throw new ArgumentException(InvalidProfileNamesMessage);

                return LoadedConfig;
            }
            catch (FileNotFoundException)
            {
                List<Profile> NewProfileList = new List<Profile>
                {
                    GenerateNewProfile()
                };

                return new Config
                {
                    StartMiningOnAppStart = false,
                    TryToCloseMSIAfterburnerIfItIsNotRunningAlready = true,
                    Profiles = NewProfileList,
                    ActiveProfileName = NewProfileList[0].Name,
                    IsConfigHasBeenReset = true
                };
            }
        }
    }
}
