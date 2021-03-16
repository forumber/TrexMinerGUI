using System;
using System.Windows.Forms;
using TrexMinerGUI.Properties;

namespace TrexMinerGUI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            this.Icon = Resources.AppIcon;

            this.StartOnStartupCheckBox.Checked = TaskSchedulerOperations.IsItInTS();
            this.StartMiningOnAppStartCheckBox.Checked = Program.TheTrexWrapper.TheTrexConfig.StartMiningOnAppStart;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked = Program.TheTrexWrapper.TheTrexConfig.ApplyAfterburnerProfileOnMinerStart;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked = Program.TheTrexWrapper.TheTrexConfig.ApplyAfterburnerProfileOnMinerClose;
            this.ProfileToApplyOnMinerStartComboBox.Text = Program.TheTrexWrapper.TheTrexConfig.ProfileToApplyOnMinerStart;
            this.ProfileToApplyOnMinerCloseComboBox.Text = Program.TheTrexWrapper.TheTrexConfig.ProfileToApplyOnMinerClose;

            this.ProfileToApplyOnMinerStartComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked;
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked;

            this.StartOnStartupCheckBox.CheckedChanged += new System.EventHandler(this.StartOnStartupCheckBox_CheckedChanged);
            this.StartMiningOnAppStartCheckBox.CheckedChanged += new System.EventHandler(this.StartMiningOnAppStart_CheckedChanged);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfile1OnMinerStartCheckBox_CheckedChanged);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfile5OnMinerCloseCheckBox_CheckedChanged);
            this.ProfileToApplyOnMinerStartComboBox.TextChanged += new System.EventHandler(this.ProfileToApplyOnMinerStartComboBox_TextChanged);
            this.ProfileToApplyOnMinerCloseComboBox.TextChanged += new System.EventHandler(this.ProfileToApplyOnMinerCloseComboBox_TextChanged);
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
            Program.TheTrexWrapper.TheTrexConfig.StartMiningOnAppStart = ((CheckBox)sender).Checked;
            Program.TheTrexWrapper.TheTrexConfig.SaveConfigToFile();
        }

        private void ApplyAfterburnerProfile1OnMinerStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.TheTrexWrapper.TheTrexConfig.ApplyAfterburnerProfileOnMinerStart = ((CheckBox)sender).Checked;
            this.ProfileToApplyOnMinerStartComboBox.Enabled = ((CheckBox)sender).Checked;
            Program.TheTrexWrapper.TheTrexConfig.SaveConfigToFile();
        }

        private void ApplyAfterburnerProfile5OnMinerCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.TheTrexWrapper.TheTrexConfig.ApplyAfterburnerProfileOnMinerClose = ((CheckBox)sender).Checked;
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = ((CheckBox)sender).Checked;
            Program.TheTrexWrapper.TheTrexConfig.SaveConfigToFile();
        }

        private void ProfileToApplyOnMinerStartComboBox_TextChanged(object sender, EventArgs e)
        {
            Program.TheTrexWrapper.TheTrexConfig.ProfileToApplyOnMinerStart = ((ComboBox)sender).Text;
            Program.TheTrexWrapper.TheTrexConfig.SaveConfigToFile();
        }

        private void ProfileToApplyOnMinerCloseComboBox_TextChanged(object sender, EventArgs e)
        {
            Program.TheTrexWrapper.TheTrexConfig.ProfileToApplyOnMinerClose = ((ComboBox)sender).Text;
            Program.TheTrexWrapper.TheTrexConfig.SaveConfigToFile();
        }
    }
}
