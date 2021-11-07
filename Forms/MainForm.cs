using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrexMinerGUI.Properties;

namespace TrexMinerGUI.Forms
{
    public partial class MainForm : Form
    {
        enum ButtonBackgroundImage
        {
            START,
            STOP
        }

        private ButtonBackgroundImage buttonBackgroundImage { get; set; }

        public MainForm()
        {
            InitializeComponent();

            this.Icon = Resources.AppIcon;
            this.VersionLabel.Text = "v" + Program.TheSelfUpdate.TheAppVersion.ToString();
            UpdateProfileList();

            this.buttonBackgroundImage = ButtonBackgroundImage.START;
            this.Select(); // make sure that none of the elemets are selected
        }

        private void UpdateProfileList()
        {
            this.ProfileComboBox.Items.Clear();
            this.ProfileComboBox.Items.AddRange(Program.TheConfig.Profiles.Select(s => s.Name).ToArray());
            this.ProfileComboBox.SelectedIndex = this.ProfileComboBox.FindString(Program.TheConfig.ActiveProfile.Name);
        }

        private void ProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ProfileComboBox.SelectedIndex == this.ProfileComboBox.FindString(Program.TheConfig.ActiveProfile.Name))
                return;

            Program.TheConfig.ActiveProfileName = ((ComboBox)sender).Text;
            Program.TheConfig.SaveConfigToFile();
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (Program.TheTrexWrapper.IsRunning)
                Task.Run(() => Program.TheTrexWrapper.Stop());
            else
                Task.Run(() => Program.TheTrexWrapper.Start());
        }

        private void UpdateForm(object sender, EventArgs e)
        {
            #region StartStopButton_Profile
            if (Program.TheTrexWrapper.IsStarting || Program.TheSelfUpdate.IsTrexUpdating)
            {
                this.StartStopButton.Enabled = false;
                if (buttonBackgroundImage == ButtonBackgroundImage.START)
                {
                    this.StartStopButton.BackgroundImage = Resources.Stop_red_icon;
                    buttonBackgroundImage = ButtonBackgroundImage.STOP;
                }

                if (this.ProfileComboBox.Enabled)
                    this.ProfileComboBox.Enabled = false;

            }
            else if (Program.TheTrexWrapper.IsStopping)
            {
                this.StartStopButton.Enabled = false;
                if (buttonBackgroundImage == ButtonBackgroundImage.STOP)
                {
                    this.StartStopButton.BackgroundImage = Resources.Start_icon;
                    buttonBackgroundImage = ButtonBackgroundImage.START;
                }

                if (this.ProfileComboBox.Enabled)
                    this.ProfileComboBox.Enabled = false;
            }
            else if (Program.TheTrexWrapper.IsRunning)
            {
                this.StartStopButton.Enabled = true;
                if (buttonBackgroundImage == ButtonBackgroundImage.START)
                {
                    this.StartStopButton.BackgroundImage = Resources.Stop_red_icon;
                    buttonBackgroundImage = ButtonBackgroundImage.STOP;
                }

                if (this.ProfileComboBox.Enabled)
                    this.ProfileComboBox.Enabled = false;
            }
            else
            {
                this.StartStopButton.Enabled = true;
                if (buttonBackgroundImage == ButtonBackgroundImage.STOP)
                {
                    this.StartStopButton.BackgroundImage = Resources.Start_icon;
                    buttonBackgroundImage = ButtonBackgroundImage.START;
                }

                if (!this.ProfileComboBox.Enabled)
                    this.ProfileComboBox.Enabled = true;
            }
            #endregion

            #region StatisticsGroup
            DurationTextBox.Text = Program.TheStopWatchWrapper.GetTotalElapsedTime().ToString("G");
            MinerStatusTextBox.Text = Program.TheTrexWrapper.GetStatus();
            SpeedTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Speed;
            PowerTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Power;
            EfficiencyTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Efficiency;
            FanSpeedTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.FanSpeed;
            TempTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Temp;
            LastUpdatedText.Text = Program.TheTrexWrapper.TheTrexStatisctics.LastUpdated.ToString("HH:mm:ss");
            if (Program.TheTrexWrapper.IsRunning)
                LastUpdatedText.Text += String.Format(" ({0} seconds ago)", (DateTime.Now - Program.TheTrexWrapper.TheTrexStatisctics.LastUpdated).TotalSeconds.ToString("F0"));
            #endregion

            #region SessionGroup
            SessionStartedAtTextBox.Text = Program.TheTrexWrapper.Session;
            WarnCountTextBox.Text = Program.TheTrexWrapper.GetWarnCount().ToString();
            ErrorCountTextBox.Text = Program.TheTrexWrapper.GetErrorCount().ToString();
            SharesTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Shares;
            if (Program.TheTrexWrapper.TheTrexStatisctics.RestartCount > 0)
            {
                if (!SharesWarningLinkLabel.Visible)
                    SharesWarningLinkLabel.Visible = true;
            }
            else
            {
                if (SharesWarningLinkLabel.Visible)
                    SharesWarningLinkLabel.Visible = false;
            }

            #endregion

            #region TrexVersionLabel
            if (Program.TheTrexWrapper.CurrentTrexVersion != null)
            {
                TrexVersionLabel.Text = "T-Rex v" + Program.TheTrexWrapper.CurrentTrexVersion.ToString();
            }
            else
            {
                TrexVersionLabel.Text = "";
            }
            #endregion
        }

        private void WarningCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Program.TheTrexWrapper.GetWarningLogPathForCurrentSession(),
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("There are no warnings to show!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ErrorCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Program.TheTrexWrapper.GetErrorLogPathForCurrentSession(),
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("There are no errors to show!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformationLogButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Program.TheTrexWrapper.GetLogPathForCurrentSession(),
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("There are no logs to show!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GUISettingsButton_Click(object sender, EventArgs e)
        {
            using (var TheGUISettingsForm = new GUISettingsForm())
            {
                TheGUISettingsForm.ShowDialog();
            }
        }

        private void ProfilesButton_Click(object sender, EventArgs e)
        {
            using (var TheProfilesForm = new ProfilesForm())
            {
                TheProfilesForm.ShowDialog();
            }

            UpdateProfileList();
        }

        private void SharesWarningLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Miner has been restarted (check for logs to get more information). Share information may not be accurate for the current sesssion.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (Program.TheTrexWrapper.IsRunning)
            {
                var Result = MessageBox.Show("Do you want to restart the session?", "Restart?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    Task.Run(() => Program.TheTrexWrapper.Restart());
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Activate();
        }
    }
}
