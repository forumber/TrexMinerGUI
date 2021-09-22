using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrexMinerGUI.Forms
{
    public partial class TrexSettingsForm : Form
    {
        private bool IsArgsChanged { get; set; }
        private bool IsInitialized { get; set; }

        public TrexSettingsForm()
        {
            IsInitialized = false;

            InitializeComponent();

            InitValues();

            IsInitialized = true;
        }

        private void InitValues()
        {
            IsArgsChanged = false;

            this.MinerArgsTextBox.Text = Program.TheConfig.MinerArgs;
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
                SaveMinerArgButton.Enabled = true;
                TheToolTip.Show(@"Don't forget to save!", SaveMinerArgButton, 3000);
            }
        }

        private void SaveMinerArgs(object sender, EventArgs e)
        {
            Program.TheConfig.MinerArgs = this.MinerArgsTextBox.Text;
            Program.TheConfig.SaveConfigToFile();

            if (Program.TheTrexWrapper.IsRunning)
            {
                Task.Run(() => Program.TheTrexWrapper.Stop()).ContinueWith((_) => Program.TheTrexWrapper.Start());

                Program.TheMainAppContext.trayIcon.ShowBalloonTip(0, "Miner has been restarted", "MinerArgs has been changed", System.Windows.Forms.ToolTipIcon.Info);
            }

            IsArgsChanged = false;

            SaveMinerArgButton.Enabled = false;
        }

        private void TrexSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsArgsChanged)
            {
                var Result = MessageBox.Show("Do you want to save new miner args?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    SaveMinerArgs(sender, e);
                }
                else if (Result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
                
        }
    }
}
