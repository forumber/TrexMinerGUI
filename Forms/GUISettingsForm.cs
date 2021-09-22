using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrexMinerGUI.Properties;

namespace TrexMinerGUI.Forms
{
    public partial class GUISettingsForm : Form
    {
        private bool IsInitialized { get; set; }

        public GUISettingsForm()
        {
            IsInitialized = false;

            InitializeComponent();

            InitValues();

            IsInitialized = true;
        }

        private void InitValues()
        {
            this.StartOnStartupCheckBox.Checked = TaskSchedulerOperations.IsItInTS();
            this.StartMiningOnAppStartCheckBox.Checked = Program.TheConfig.StartMiningOnAppStart;
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

        private void StartMiningOnAppStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.StartMiningOnAppStart = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }
    }
}
