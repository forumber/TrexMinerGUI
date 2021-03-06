using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TrexMinerGUI
{
    public partial class StatisticsForm : Form
    {
        private readonly System.Windows.Forms.Timer TheTimer;

        public StatisticsForm()
        {
            InitializeComponent();

            TheTimer = new System.Windows.Forms.Timer();
            TheTimer.Tick += UpdateStatistics;
            TheTimer.Interval = 1000;
            TheTimer.Start();
        }

        private void UpdateStatistics(object sender, EventArgs e)
        {
            DurationTextBox.Text = Program.TheStopWatchWrapper.GetTotalElapsedTime().ToString("G");
            MinerStatusTextBox.Text = Program.TheStopWatchWrapper.TheStopWatch.IsRunning ? "Çalışıyor" : "Çalışmıyor";
            SpeedTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Speed;
            PowerTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Power;
            FanSpeedTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.FanSpeed;
            TempTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Temp;
            WarnCountTextBox.Text = Program.TheTrexWrapper.GetWarnCount().ToString();
            ErrorCountTextBox.Text = Program.TheTrexWrapper.GetErrorCount().ToString();
            LastUpdatedText.Text = Program.TheTrexWrapper.TheTrexStatisctics.LastUpdated;
        }
    }
}
