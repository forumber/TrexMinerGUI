using TrexMinerGUI.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrexMinerGUI
{
    public class MainAppContext : ApplicationContext
    {
        public NotifyIcon trayIcon;
        private ContextMenuStrip TheContextMenu;

        public MainAppContext()
        {
            TheContextMenu = new ContextMenuStrip();
            TheContextMenu.Items.Add("Miner: ", System.Drawing.SystemIcons.Information.ToBitmap(), null);
            TheContextMenu.Items.Add("Süre: ", System.Drawing.SystemIcons.Information.ToBitmap(), null);
            TheContextMenu.Items.Add("Hız: ", System.Drawing.SystemIcons.Information.ToBitmap(), null);
            TheContextMenu.Items.Add("Sıcaklık: ", System.Drawing.SystemIcons.Information.ToBitmap(), null);
            TheContextMenu.Items.Add("Güç: ", System.Drawing.SystemIcons.Information.ToBitmap(), null);
            TheContextMenu.Items.Add("Fan: ", System.Drawing.SystemIcons.Information.ToBitmap(), null);
            TheContextMenu.Items.Add(@"Log'u göster", null, ShowLog_Event);
            TheContextMenu.Items.Add("Başlangıçta Aç", null, (sender, eventArgs) => TaskSchedulerOperations.AddToTS());
            TheContextMenu.Items.Add("Başlangıçta Aç", null, (sender, eventArgs) => TaskSchedulerOperations.RemoveFromTS());
            TheContextMenu.Items.Add("Çalıştır", null, (sender, eventArgs) => Program.TheTrexWrapper.Start());
            TheContextMenu.Items.Add("Durdur", null, (sender, eventArgs) => Program.TheTrexWrapper.Stop());
            TheContextMenu.Items.Add("Kapat", System.Drawing.SystemIcons.Error.ToBitmap(), (sender, eventArgs) => {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                trayIcon.Visible = false;

                Application.Exit();
            });

            TheContextMenu.Items[0].Enabled = false;
            TheContextMenu.Items[1].Enabled = false;
            TheContextMenu.Items[2].Enabled = false;
            TheContextMenu.Items[3].Enabled = false;
            TheContextMenu.Items[4].Enabled = false;
            TheContextMenu.Items[5].Enabled = false;

            ((ToolStripMenuItem)TheContextMenu.Items[8]).Checked = true;

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenuStrip = TheContextMenu,
                Visible = true
            };

            trayIcon.Click += TrayIcon_Click;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
        }

        private void ShowLog_Event(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Program.ExecutionPath + Program.TheTrexWrapper.LogFileName,
                    UseShellExecute = true
                });
            } 
            catch
            {

            }
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<StatisticsForm>().Count() == 0)
            {
                using (StatisticsForm TheStatisticsForm = new StatisticsForm())
                {
                    TheStatisticsForm.ShowDialog();
                }
            }
        }

        private void UpdateStatistics(bool SwitchToEnable)
        {
            if (SwitchToEnable)
            {
                TheContextMenu.Items[2].Text = "Hız: " + Program.TheTrexWrapper.TheTrexStatisctics.Speed;
                TheContextMenu.Items[3].Text = "Sıcaklık: " + Program.TheTrexWrapper.TheTrexStatisctics.Temp;
                TheContextMenu.Items[4].Text = "Güç: " + Program.TheTrexWrapper.TheTrexStatisctics.Power;
                TheContextMenu.Items[5].Text = "Fan: " + Program.TheTrexWrapper.TheTrexStatisctics.FanSpeed;

                TheContextMenu.Items[2].Visible = true;
                TheContextMenu.Items[3].Visible = true;
                TheContextMenu.Items[4].Visible = true;
                TheContextMenu.Items[5].Visible = true;
            }
            else
            {
                TheContextMenu.Items[2].Visible = false;
                TheContextMenu.Items[3].Visible = false;
                TheContextMenu.Items[4].Visible = false;
                TheContextMenu.Items[5].Visible = false;
            }
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            TheContextMenu.Items[0].Text = "Miner: ";

            if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
            {
                TheContextMenu.Items[0].Text += "Çalışıyor";
                UpdateStatistics(true);
            }
            else if (!Program.TheStopWatchWrapper.TheStopWatch.IsRunning && Program.TheTrexWrapper.IsRunning)
            {
                TheContextMenu.Items[0].Text += "Başlatılıyor...";
                UpdateStatistics(false);
            }
            else if (!Program.TheStopWatchWrapper.TheStopWatch.IsRunning && !Program.TheTrexWrapper.IsRunning)
            {
                TheContextMenu.Items[0].Text += "Kapalı";
                UpdateStatistics(false);
            }

            //TheContextMenu.Items[1].Text = "Süre: " + Program.TheStopWatchWrapper.GetTotalElapsedTime().ToString(@"hh\:mm\:ss");
            //TheContextMenu.Items[1].Text = "Süre: " + string.Format(@"{0}\:{1}\:{2}",
            //         Convert.ToInt32(Program.TheStopWatchWrapper.GetTotalElapsedTime().TotalHours),
            //         Program.TheStopWatchWrapper.GetTotalElapsedTime().Minutes,
            //         Program.TheStopWatchWrapper.GetTotalElapsedTime().Seconds);
            TheContextMenu.Items[1].Text = "Süre: " + Program.TheStopWatchWrapper.GetTotalElapsedTime().TotalHours.ToString("0.##") + " saat";

            if (Process.GetProcessesByName("t-rex").Length == 0)
            {
                TheContextMenu.Items[9].Visible = true;
                TheContextMenu.Items[10].Visible = false;
            } else
            {
                TheContextMenu.Items[9].Visible = false;
                TheContextMenu.Items[10].Visible = true;
            }

            // It is a bad practice, but clearing the events from EventHandler is much more complex than I thought.
            if (TaskSchedulerOperations.IsItInTS())
            {
                TheContextMenu.Items[7].Visible = false;
                TheContextMenu.Items[8].Visible = true;
            }
            else
            {
                TheContextMenu.Items[7].Visible = true;
                TheContextMenu.Items[8].Visible = false;
            }
        }
    }
}
