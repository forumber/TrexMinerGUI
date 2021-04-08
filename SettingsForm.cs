using System;
using System.Diagnostics;
using System.Windows.Forms;
using TrexMinerGUI.Properties;

namespace TrexMinerGUI
{
    public partial class SettingsForm : Form
    {
        private bool IsArgsChanged;

        public SettingsForm()
        {
            InitializeComponent();

            IsArgsChanged = false;

            this.Icon = Resources.AppIcon;
            this.Text += " - v" + Program.TheSelfUpdate.TheAppVersion.ToString();

            this.StartOnStartupCheckBox.Checked = TaskSchedulerOperations.IsItInTS();
            this.StartMiningOnAppStartCheckBox.Checked = Program.TheConfig.StartMiningOnAppStart;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked = Program.TheConfig.ApplyAfterburnerProfileOnMinerStart;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked = Program.TheConfig.ApplyAfterburnerProfileOnMinerClose;
            this.ProfileToApplyOnMinerStartComboBox.Text = Program.TheConfig.ProfileToApplyOnMinerStart;
            this.ProfileToApplyOnMinerCloseComboBox.Text = Program.TheConfig.ProfileToApplyOnMinerClose;
            this.MinerArgsTextBox.Text = Program.TheConfig.MinerArgs;

            this.ProfileToApplyOnMinerStartComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked;
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked;

            this.StartOnStartupCheckBox.CheckedChanged += new System.EventHandler(this.StartOnStartupCheckBox_CheckedChanged);
            this.StartMiningOnAppStartCheckBox.CheckedChanged += new System.EventHandler(this.StartMiningOnAppStart_CheckedChanged);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfile1OnMinerStartCheckBox_CheckedChanged);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfile5OnMinerCloseCheckBox_CheckedChanged);
            this.ProfileToApplyOnMinerStartComboBox.TextChanged += new System.EventHandler(this.ProfileToApplyOnMinerStartComboBox_TextChanged);
            this.ProfileToApplyOnMinerCloseComboBox.TextChanged += new System.EventHandler(this.ProfileToApplyOnMinerCloseComboBox_TextChanged);
            this.MinerArgsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MinerArgsLabel_LinkClicked);
            this.MinerArgsTextBox.TextChanged += new System.EventHandler(this.MinerArgsTextBox_TextChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
        }

        private void StartOnStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
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
            Program.TheConfig.StartMiningOnAppStart = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void ApplyAfterburnerProfile1OnMinerStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.TheConfig.ApplyAfterburnerProfileOnMinerStart = ((CheckBox)sender).Checked;
            this.ProfileToApplyOnMinerStartComboBox.Enabled = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void ApplyAfterburnerProfile5OnMinerCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.TheConfig.ApplyAfterburnerProfileOnMinerClose = ((CheckBox)sender).Checked;
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void ProfileToApplyOnMinerStartComboBox_TextChanged(object sender, EventArgs e)
        {
            Program.TheConfig.ProfileToApplyOnMinerStart = ((ComboBox)sender).Text;
            Program.TheConfig.SaveConfigToFile();
        }

        private void ProfileToApplyOnMinerCloseComboBox_TextChanged(object sender, EventArgs e)
        {
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
            IsArgsChanged = true;
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsArgsChanged)
            {
                Program.TheConfig.MinerArgs = this.MinerArgsTextBox.Text;
                Program.TheConfig.SaveConfigToFile();

                if (Program.TheTrexWrapper.IsRunning)
                {
                    Program.TheTrexWrapper.Stop();
                    Program.TheTrexWrapper.Start();

                    Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Miner yeniden başlatıldı", "MinerArgs değiştirildi", System.Windows.Forms.ToolTipIcon.Info);
                }
            }
        }
    }
}
