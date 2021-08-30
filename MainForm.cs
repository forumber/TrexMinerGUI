using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrexMinerGUI.Properties;

namespace TrexMinerGUI
{
    public partial class MainForm : Form
    {
        enum ButtonBackgroundImage
        {
            START,
            STOP
        }

        private ButtonBackgroundImage buttonBackgroundImage { get; set; }

        private bool IsArgsChanged { get; set; }

        private bool IsInitialized { get; set; }

        public MainForm()
        {
            IsInitialized = false;

            InitializeComponent();
            InitSettingsBox();

            this.Icon = Resources.AppIcon;
            this.VersionLabel.Text = "v" + Program.TheSelfUpdate.TheAppVersion.ToString();

            this.buttonBackgroundImage = ButtonBackgroundImage.START;
            this.Select(); // make sure that none of the elemets are selected

            IsInitialized = true;
        }

        private void InitSettingsBox()
        {
            this.StartOnStartupCheckBox.Checked = TaskSchedulerOperations.IsItInTS();
            this.StartMiningOnAppStartCheckBox.Checked = Program.TheConfig.StartMiningOnAppStart;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked = Program.TheConfig.ApplyAfterburnerProfileOnMinerStart;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked = Program.TheConfig.ApplyAfterburnerProfileOnMinerClose;
            this.ProfileToApplyOnMinerStartComboBox.Text = Program.TheConfig.ProfileToApplyOnMinerStart;
            this.ProfileToApplyOnMinerCloseComboBox.Text = Program.TheConfig.ProfileToApplyOnMinerClose;
            this.MinerArgsTextBox.Text = Program.TheConfig.MinerArgs;

            this.ProfileToApplyOnMinerStartComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked;
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked;
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

            this.SaveMinerArgButton.Enabled = IsArgsChanged;

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

        private void StartOnStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            if (((CheckBox)sender).Checked)
            {
                TaskSchedulerOperations.AddToTS();
            }
            else
            {
                TaskSchedulerOperations.RemoveFromTS();
            }
        }

        private void StartMiningOnAppStart_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.StartMiningOnAppStart = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void ApplyAfterburnerProfileOnMinerStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.ApplyAfterburnerProfileOnMinerStart = ((CheckBox)sender).Checked;
            this.ProfileToApplyOnMinerStartComboBox.Enabled = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void ApplyAfterburnerProfileOnMinerCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.ApplyAfterburnerProfileOnMinerClose = ((CheckBox)sender).Checked;
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void ProfileToApplyOnMinerStartComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.ProfileToApplyOnMinerStart = ((ComboBox)sender).Text;
            Program.TheConfig.SaveConfigToFile();
        }

        private void ProfileToApplyOnMinerCloseComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.ProfileToApplyOnMinerClose = ((ComboBox)sender).Text;
            Program.TheConfig.SaveConfigToFile();
        }

        private void MinerArgsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/trexminer/T-Rex#examples",
                UseShellExecute = true
            });
        }

        private void MinerArgsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            if (!IsArgsChanged)
            {
                IsArgsChanged = true;
                TheToolTip.Show(@"Don't forget to save!", SaveMinerArgButton, 3000);
            }
        }

        private void SaveMinerArg(object sender, EventArgs e)
        {
            Program.TheConfig.MinerArgs = this.MinerArgsTextBox.Text;
            Program.TheConfig.SaveConfigToFile();

            if (Program.TheTrexWrapper.IsRunning)
            {
                Task.Run(() => Program.TheTrexWrapper.Stop()).ContinueWith((_) => Program.TheTrexWrapper.Start());

                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Miner has been restarted", "MinerArgs has been changed", System.Windows.Forms.ToolTipIcon.Info);
            }

            IsArgsChanged = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsArgsChanged)
                SaveMinerArg(sender, e);
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
    }
}
