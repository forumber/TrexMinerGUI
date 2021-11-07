using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrexMinerGUI
{
    static class Program
    {
        private static EventHandler IdleEventHandler;

        public static MainAppContext TheMainAppContext;
        public static StopWatchWrapper TheStopWatchWrapper;
        public static TrexWrapper TheTrexWrapper;
        public static SelfUpdate TheSelfUpdate;
        public static Config TheConfig;
        public static string ExecutionPath;
        public static string ExceptionLogFileName;
        public static Mutex TheMutex;
        public static bool ApplicationStarted;

        [STAThread]
        public static void Main(string[] args)
        {
            ApplicationStarted = false;

            ExecutionPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\";
            ExceptionLogFileName = "trex_gui_exception_log.txt";

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionMessageBox);
            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadUnhandledExceptionMessageBox);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TheMutex = new Mutex(true, "TrexMinerGUI");

            if (!TheMutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show(owner: null, text: "An instance of application is already running!", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

            if (args.Length >= 1)
            {
                if (args[0] == "startup")
                {
                    // Lets make sure that the tray icon is visible after login by restarting the app with significant delay
                    ProcessStartInfo Info = new ProcessStartInfo();
                    string ThePath = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.Length - 4) + ".exe";
                    Info.Arguments = "/C timeout /t 4 /nobreak && start \"\" \"" + ThePath + "\"";
                    Info.WindowStyle = ProcessWindowStyle.Hidden;
                    Info.CreateNoWindow = true;
                    Info.FileName = "cmd.exe";
                    Process.Start(Info);
                    System.Environment.Exit(0);
                }
            }

            TheConfig = Config.LoadConfigFile();
            //TheConfig.SaveConfigToFile();
            TheSelfUpdate = new SelfUpdate();
            TheMainAppContext = new MainAppContext();
            TheStopWatchWrapper = new StopWatchWrapper();
            TheTrexWrapper = new TrexWrapper();

            if (TheConfig.StartMiningOnAppStart)
                Task.Run(() => Program.TheTrexWrapper.Start());

            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            TheSelfUpdate.CleanUp();

            IdleEventHandler = new EventHandler((sender, eventArgs) =>
            {
                ApplicationStarted = true;

                Application.Idle -= IdleEventHandler;

                if (Program.TheConfig.IsConfigHasBeenReset)
                {
                    MessageBox.Show("The configuration has been reset! Please reconfigure your settings.", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.TheMainAppContext.ShowMainForm(sender, eventArgs);
                }

                IdleEventHandler = null;
            });

            Application.Idle += IdleEventHandler;

            Application.Run(TheMainAppContext);
        }

        private static void ShowExceptionMessage(Exception TheException)
        {
            if (TheException.InnerException != null)
                ShowExceptionMessage(TheException.InnerException);

            try
            {
                MessageBox.Show(TheException.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception GUIException)
            {
                try
                {
                    MessageBox.Show("Fatal exception: \n\n"
                        + GUIException.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private static void UIThreadUnhandledExceptionMessageBox(object sender, ThreadExceptionEventArgs e)
        {
            File.AppendAllText(ExecutionPath + ExceptionLogFileName,
                Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + e.Exception.ToString() + Environment.NewLine);

            ShowExceptionMessage(e.Exception);

            Application.Exit();
        }

        private static void UnhandledExceptionMessageBox(object sender, UnhandledExceptionEventArgs e)
        {
            File.AppendAllText(ExecutionPath + ExceptionLogFileName,
                Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + ((Exception)e.ExceptionObject).ToString() + Environment.NewLine);

            ShowExceptionMessage((Exception)e.ExceptionObject);

            Application.Exit();
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            TheMainAppContext.trayIcon.Visible = false;
            TheStopWatchWrapper.SaveToFile();
            if (TheTrexWrapper.IsRunning)
                TheTrexWrapper.Stop();
            if (Program.TheSelfUpdate.UpdateScript != null)
                Process.Start(Program.TheSelfUpdate.UpdateScript);
            TheMutex.ReleaseMutex();
        }
    }
}
