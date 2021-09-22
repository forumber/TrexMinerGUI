using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrexMinerGUI.Forms
{
    public partial class GPUTuningForm : Form
    {
        private bool IsInitialized { get; set; }

        public GPUTuningForm()
        {
            IsInitialized = false;

            InitializeComponent();

            InitValues();

            IsInitialized = true;
        }

        private void InitValues()
        {
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked = Program.TheConfig.ApplyAfterburnerProfileOnMinerStart;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked = Program.TheConfig.ApplyAfterburnerProfileOnMinerClose;
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.Checked = (bool)Program.TheConfig.TryToCloseMSIAfterburnerIfItIsNotRunningAlready;
            this.ProfileToApplyOnMinerStartComboBox.Text = Program.TheConfig.ProfileToApplyOnMinerStart;
            this.ProfileToApplyOnMinerCloseComboBox.Text = Program.TheConfig.ProfileToApplyOnMinerClose;

            this.ProfileToApplyOnMinerStartComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked;
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked;

            SetCloseMSIAfterburnerCheckboxStatus();
        }

        private void ApplyAfterburnerProfileOnMinerStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.ApplyAfterburnerProfileOnMinerStart = ((CheckBox)sender).Checked;
            this.ProfileToApplyOnMinerStartComboBox.Enabled = ((CheckBox)sender).Checked;
            SetCloseMSIAfterburnerCheckboxStatus();
            Program.TheConfig.SaveConfigToFile();
        }

        private void ApplyAfterburnerProfileOnMinerCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.ApplyAfterburnerProfileOnMinerClose = ((CheckBox)sender).Checked;
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = ((CheckBox)sender).Checked;
            SetCloseMSIAfterburnerCheckboxStatus();
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

        private void TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.TryToCloseMSIAfterburnerIfItIsNotRunningAlready = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void SetCloseMSIAfterburnerCheckboxStatus()
        {
            if (this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked || this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked)
                this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.Enabled = true;
            else
                this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.Enabled = false;
        }
    }
}
