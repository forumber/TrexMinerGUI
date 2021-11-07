using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrexMinerGUI.Forms
{
    public partial class ProfilesForm : Form
    {
        private Config.Profile _currentProfile;
        private bool _propsChanged;
        private bool Ready { get; set; }
        private bool MinerArgsChanged { get; set; }
        private bool PropsChanged
        {
            get => _propsChanged; set
            {
                _propsChanged = value;
                SaveCurrentProfileButton.Enabled = value;
            }
        }

        public ProfilesForm()
        {
            Ready = false;
            MinerArgsChanged = false;

            InitializeComponent();

            LoadProfileNameList();

            this.Select(); // make sure that none of the elemets are selected

            Ready = true;
        }

        private Config.Profile GetCurrentProfile()
        {
            return _currentProfile;
        }

        private void SetCurrentProfile(Config.Profile value)
        {
            Ready = false;
            _currentProfile = value;
            this.ProfileNameTextBox.Text = _currentProfile.Name;
            this.MinerArgsTextBox.Text = _currentProfile.MinerArgs;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked = _currentProfile.ApplyAfterburnerProfileOnMinerClose;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked = _currentProfile.ApplyAfterburnerProfileOnMinerStart;
            this.ProfileToApplyOnMinerCloseComboBox.SelectedIndex = this.ProfileToApplyOnMinerCloseComboBox.FindString(_currentProfile.ProfileToApplyOnMinerClose);
            this.ProfileToApplyOnMinerStartComboBox.SelectedIndex = this.ProfileToApplyOnMinerStartComboBox.FindString(_currentProfile.ProfileToApplyOnMinerStart);
            this.ProfileToApplyOnMinerCloseComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked;
            this.ProfileToApplyOnMinerStartComboBox.Enabled = this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked;
            PropsChanged = false;
            Ready = true;
        }

        private void LoadProfileNameList(int SelectedIndex = -1)
        {
            PropsChanged = false;

            this.ProfileComboBox.Items.Clear();
            this.ProfileComboBox.Items.AddRange(Program.TheConfig.Profiles.Select(s => s.Name).ToArray());
            if (SelectedIndex < 0)
                this.ProfileComboBox.SelectedIndex = this.ProfileComboBox.FindString(Program.TheConfig.ActiveProfile.Name);
            else
                this.ProfileComboBox.SelectedIndex = SelectedIndex;

            this.DeleteCurrentProfileButton.Enabled = Program.TheConfig.Profiles.Count > 1;

        }

        private void MinerArgsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/trexminer/T-Rex#examples",
                UseShellExecute = true
            });
        }

        private bool SaveCurrentProfile()
        {
            try
            {
                GetCurrentProfile().MinerArgs = this.MinerArgsTextBox.Text;
                GetCurrentProfile().ApplyAfterburnerProfileOnMinerStart = this.ApplyAfterburnerProfileOnMinerStartCheckBox.Checked;
                GetCurrentProfile().ApplyAfterburnerProfileOnMinerClose = this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Checked;
                GetCurrentProfile().ProfileToApplyOnMinerStart = this.ProfileToApplyOnMinerStartComboBox.Text;
                GetCurrentProfile().ProfileToApplyOnMinerClose = this.ProfileToApplyOnMinerCloseComboBox.Text;
                GetCurrentProfile().Name = this.ProfileNameTextBox.Text;
                if (Program.TheConfig.ActiveProfile == GetCurrentProfile())
                    Program.TheConfig.ActiveProfileName = Program.TheConfig.ActiveProfile.Name;
                LoadProfileNameList(this.ProfileComboBox.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Arguments are not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Program.TheConfig.SaveConfigToFile();

            if (Program.TheConfig.ActiveProfile == GetCurrentProfile() && Program.TheTrexWrapper.IsRunning && MinerArgsChanged)
            {
                Task.Run(() => Program.TheTrexWrapper.Restart());

                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Miner has been restarted", "MinerArgs has been changed", System.Windows.Forms.ToolTipIcon.Info);
            }

            PropsChanged = false;
            MinerArgsChanged = false;

            return true;
        }

        private void TrexSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PropsChanged)
            {
                e.Cancel = !DisplayDontForgetToSaveForm();
            }
        }

        private bool DisplayDontForgetToSaveForm()
        {
            var Result = MessageBox.Show("Do you want to save the changes?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                return SaveCurrentProfile();
            }
            else if (Result == DialogResult.No)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveCurrrentProfileButton_Click(object sender, EventArgs e)
        {
            SaveCurrentProfile();
        }

        private void ProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GetCurrentProfile() != null)
                if (this.ProfileComboBox.SelectedIndex == this.ProfileComboBox.FindString(GetCurrentProfile().Name))
                    return;

            if (PropsChanged)
            {
                if (!DisplayDontForgetToSaveForm())
                {
                    this.ProfileComboBox.SelectedIndex = this.ProfileComboBox.FindString(GetCurrentProfile().Name);
                    return;
                }
            }

            SetCurrentProfile(Program.TheConfig.Profiles.Where(s => s.Name == ProfileComboBox.Text).FirstOrDefault());
        }

        private void ApplyAfterburnerProfileOnMinerStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Ready)
                return;

            PropsChanged = true;

            this.ProfileToApplyOnMinerStartComboBox.Enabled = ((CheckBox)sender).Checked;
        }

        private void ApplyAfterburnerProfileOnMinerCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Ready)
                return;

            PropsChanged = true;

            this.ProfileToApplyOnMinerCloseComboBox.Enabled = ((CheckBox)sender).Checked;
        }

        private void ChangePropStatus(object sender, EventArgs e)
        {
            if (!Ready)
                return;

            PropsChanged = true;
        }

        private void EditMinerArgsButton_Click(object sender, EventArgs e)
        {
            using (var TheTextBoxForm = new TextBoxForm("Miner Args", "Enter the miner arguments:", this.MinerArgsTextBox.Text))
            {
                TheTextBoxForm.ShowDialog();
                this.MinerArgsTextBox.Text = TheTextBoxForm.ReturnValue;
            }
        }

        private void MinerArgsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Ready)
                return;

            PropsChanged = true;
            MinerArgsChanged = true;
        }

        private void DeleteCurrentProfileButton_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("Are you sure you want to delete the current profile?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                if (!Program.TheConfig.DeleteProfile(GetCurrentProfile().Name))
                {
                    MessageBox.Show("You cant delete active profile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int CurrentIndex = this.ProfileComboBox.SelectedIndex;

                    if (Program.TheConfig.Profiles.Count > CurrentIndex)
                        LoadProfileNameList(CurrentIndex);
                    else
                        LoadProfileNameList(CurrentIndex - 1);
                }
            }
        }

        private void DeleteCurrentProfileButton_EnabledChanged(object sender, EventArgs e)
        {
            if (this.DeleteCurrentProfileButton.Enabled)
                this.DeleteCurrentProfileButton.BackgroundImage = global::TrexMinerGUI.Properties.Resources.button_delete_red;
            else
                this.DeleteCurrentProfileButton.BackgroundImage = ExternalMethods.ToGrayScale(global::TrexMinerGUI.Properties.Resources.button_delete_red);
        }

        private void CreateProfileButton_Click(object sender, EventArgs e)
        {
            if (PropsChanged)
            {
                if (!DisplayDontForgetToSaveForm())
                    return;
            }

            LoadProfileNameList(Program.TheConfig.CreateProfile());
        }
    }
}
