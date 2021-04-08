using TrexMinerGUI.Properties;
using System;
using System.Diagnostics;
using System.Linq;
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
            TheContextMenu.Items.Add("Miner: ", System.Drawing.SystemIcons.Information.ToBitmap(), null); // 0
            TheContextMenu.Items.Add("Süre: ", System.Drawing.SystemIcons.Information.ToBitmap(), null); // 1
            TheContextMenu.Items.Add("Hız: ", System.Drawing.SystemIcons.Information.ToBitmap(), null); // 2
            TheContextMenu.Items.Add(@"Log'u göster", null, ShowLog_Event); // 3
            TheContextMenu.Items.Add("Ayarlar", null, OpenSettings_Event); // 4
            TheContextMenu.Items.Add("Çalıştır", null, (sender, eventArgs) => Program.TheTrexWrapper.Start()); // 5
            TheContextMenu.Items.Add("Durdur", null, (sender, eventArgs) => Program.TheTrexWrapper.Stop()); // 6
            TheContextMenu.Items.Add("Kapat", System.Drawing.SystemIcons.Error.ToBitmap(), (sender, eventArgs) => Application.Exit()); // 7

            TheContextMenu.Items[0].Enabled = false;
            TheContextMenu.Items[1].Enabled = false;
            TheContextMenu.Items[2].Enabled = false;

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

        private void OpenSettings_Event(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SettingsForm>().Count() == 0)
            {
                using (SettingsForm TheSettingsForm = new SettingsForm())
                {
                    TheSettingsForm.ShowDialog();
                }
            }
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

            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Program.ExecutionPath + Program.TheTrexWrapper.ErrorLogFileName,
                    UseShellExecute = true
                });
            }
            catch
            {

            }

            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Program.ExecutionPath + Program.TheTrexWrapper.WarnLogFileName,
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

                TheContextMenu.Items[2].Visible = true;
            }
            else
            {
                TheContextMenu.Items[2].Visible = false;
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
            else if (Program.TheSelfUpdate.IsTrexUpdating)
            {
                TheContextMenu.Items[0].Text += "Güncelleniyor...";
                UpdateStatistics(false);
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

            TheContextMenu.Items[1].Text = "Süre: " + Program.TheStopWatchWrapper.GetTotalElapsedTime().TotalHours.ToString("0.##") + " saat";

            if (Process.GetProcessesByName("t-rex").Length == 0)
            {
                TheContextMenu.Items[5].Visible = true;
                TheContextMenu.Items[6].Visible = false;
            } else
            {
                TheContextMenu.Items[5].Visible = false;
                TheContextMenu.Items[6].Visible = true;
            }
        }
    }
}
