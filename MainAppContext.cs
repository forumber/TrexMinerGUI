using TrexMinerGUI.Properties;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using TrexMinerGUI.Forms;

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
            TheContextMenu.Items.Add("Duration: ", System.Drawing.SystemIcons.Information.ToBitmap(), null); // 1
            TheContextMenu.Items.Add("Speed: ", System.Drawing.SystemIcons.Information.ToBitmap(), null); // 2
            TheContextMenu.Items.Add("Start", null, (sender, eventArgs) => Task.Run(() => Program.TheTrexWrapper.Start())); // 3
            TheContextMenu.Items.Add("Stop", null, (sender, eventArgs) => Task.Run(() => Program.TheTrexWrapper.Stop())); // 4
            TheContextMenu.Items.Add("Exit", System.Drawing.SystemIcons.Error.ToBitmap(), (sender, eventArgs) => Application.Exit()); // 5

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

            TheContextMenu.Opening += UpdateContextMenu;
            trayIcon.DoubleClick += ShowMainForm;
        }

        private void ShowMainForm(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MainForm>().Count() == 0)
            {
                using (var TheMainForm = new MainForm())
                {
                    TheMainForm.ShowDialog();
                }
            }
        }

        private void UpdateStatistics(bool SwitchToEnable)
        {
            if (SwitchToEnable)
            {
                TheContextMenu.Items[2].Text = "Speed: " + Program.TheTrexWrapper.TheTrexStatisctics.Speed;

                TheContextMenu.Items[2].Visible = true;
            }
            else
            {
                TheContextMenu.Items[2].Visible = false;
            }
        }

        private void UpdateContextMenu(object sender, EventArgs e)
        {
            TheContextMenu.Items[0].Text = "Miner: " + Program.TheTrexWrapper.GetStatus();

            if (Program.TheStopWatchWrapper.TheStopWatch.IsRunning)
                UpdateStatistics(true);
            else
                UpdateStatistics(false);

            TheContextMenu.Items[1].Text = "Duration: " + Program.TheStopWatchWrapper.GetTotalElapsedTime().TotalHours.ToString("0.##") + " hours";

            if (Program.TheTrexWrapper.IsStopping)
            {
                TheContextMenu.Items[3].Visible = true;
                TheContextMenu.Items[3].Enabled = false;
                TheContextMenu.Items[4].Visible = false;
            }
            else if (Program.TheTrexWrapper.IsStarting || Program.TheSelfUpdate.IsTrexUpdating)
            {
                TheContextMenu.Items[3].Visible = false;
                TheContextMenu.Items[4].Visible = true;
                TheContextMenu.Items[4].Enabled = false;
            }
            else if (Program.TheTrexWrapper.IsRunning)
            {
                TheContextMenu.Items[3].Visible = false;
                TheContextMenu.Items[4].Visible = true;
                TheContextMenu.Items[4].Enabled = true;
            }
            else
            {
                TheContextMenu.Items[3].Visible = true;
                TheContextMenu.Items[3].Enabled = true;
                TheContextMenu.Items[4].Visible = false;
            }
        }
    }
}
