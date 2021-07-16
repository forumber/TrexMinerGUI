using System;
using System.Windows.Forms;
using TrexMinerGUI.Properties;

namespace TrexMinerGUI
{
    public partial class StatisticsForm : Form
    {
        private readonly System.Windows.Forms.Timer TheTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                TheTimer.Dispose();
            }
            base.Dispose(disposing);
        }

        public StatisticsForm()
        {
            InitializeComponent();

            this.Icon = Resources.AppIcon;

            TheTimer = new System.Windows.Forms.Timer();
            TheTimer.Tick += UpdateStatistics;
            TheTimer.Interval = 1000;
            TheTimer.Start();
        }

        private void UpdateStatistics(object sender, EventArgs e)
        {
            DurationTextBox.Text = Program.TheStopWatchWrapper.GetTotalElapsedTime().ToString("G");
            MinerStatusTextBox.Text = Program.TheTrexWrapper.GetStatus();
            SpeedTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Speed;
            PowerTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Power;
            EfficiencyTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Efficiency;
            FanSpeedTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.FanSpeed;
            TempTextBox.Text = Program.TheTrexWrapper.TheTrexStatisctics.Temp;
            WarnCountTextBox.Text = Program.TheTrexWrapper.GetWarnCount().ToString();
            ErrorCountTextBox.Text = Program.TheTrexWrapper.GetErrorCount().ToString();
            LastUpdatedText.Text = Program.TheTrexWrapper.TheTrexStatisctics.LastUpdated;
        }
    }
}
