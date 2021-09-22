using System;
using System.Diagnostics;
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

            this.buttonBackgroundImage = ButtonBackgroundImage.START;
            this.Select(); // make sure that none of the elemets are selected
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
            #region StartStopButton
            if (Program.TheTrexWrapper.IsStarting || Program.TheSelfUpdate.IsTrexUpdating)
            {
                this.StartStopButton.Enabled = false;
                if (buttonBackgroundImage == ButtonBackgroundImage.START)
                {
                    this.StartStopButton.BackgroundImage = Resources.Stop_red_icon;
                    buttonBackgroundImage = ButtonBackgroundImage.STOP;
                }

            }
            else if (Program.TheTrexWrapper.IsStopping)
            {
                this.StartStopButton.Enabled = false;
                if (buttonBackgroundImage == ButtonBackgroundImage.STOP)
                {
                    this.StartStopButton.BackgroundImage = Resources.Start_icon;
                    buttonBackgroundImage = ButtonBackgroundImage.START;
                }
            }
            else if (Program.TheTrexWrapper.IsRunning)
            {
                this.StartStopButton.Enabled = true;
                if (buttonBackgroundImage == ButtonBackgroundImage.START)
                {
                    this.StartStopButton.BackgroundImage = Resources.Stop_red_icon;
                    buttonBackgroundImage = ButtonBackgroundImage.STOP;
                }
            }
            else
            {
                this.StartStopButton.Enabled = true;
                if (buttonBackgroundImage == ButtonBackgroundImage.STOP)
                {
                    this.StartStopButton.BackgroundImage = Resources.Start_icon;
                    buttonBackgroundImage = ButtonBackgroundImage.START;
                }
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
            LastUpdatedText.Text = Program.TheTrexWrapper.TheTrexStatisctics.LastUpdated;
            #endregion

            #region SessionGroup
            SessionStartedAtTextBox.Text = Program.TheTrexWrapper.Session;
            WarnCountTextBox.Text = Program.TheTrexWrapper.GetWarnCount().ToString();
            ErrorCountTextBox.Text = Program.TheTrexWrapper.GetErrorCount().ToString();
            SharesTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Shares;
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
                MessageBox.Show("There are logs to show!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GUISettingsButton_Click(object sender, EventArgs e)
        {
            using (var TheGUISettingsForm = new GUISettingsForm())
            {
                TheGUISettingsForm.ShowDialog();
            }
        }

        private void TrexMinerSettingsButton_Click(object sender, EventArgs e)
        {
            using (var TheTrexMinerSettingsForm = new TrexSettingsForm())
            {
                TheTrexMinerSettingsForm.ShowDialog();
            }
        }

        private void GPUTuningSettingsButton_Click(object sender, EventArgs e)
        {
            using (var TheGPUTuningForm = new GPUTuningForm())
            {
                TheGPUTuningForm.ShowDialog();
            }
        }
    }
}
