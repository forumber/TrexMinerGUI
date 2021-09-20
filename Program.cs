using Newtonsoft.Json;
using System;
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
        public static MainAppContext TheMainAppContext;
        public static StopWatchWrapper TheStopWatchWrapper;
        public static TrexWrapper TheTrexWrapper;
        public static SelfUpdate TheSelfUpdate;
        public static Config TheConfig;
        public static string ExecutionPath;
        public static string ExceptionLogFileName;
        public static Mutex TheMutex;

        [STAThread]
        public static void Main(string[] args)
        {
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
                    Info.Arguments = "/C ping 127.0.0.1 -n 4 && start \"\" \"" + ThePath + "\"";
                    Info.WindowStyle = ProcessWindowStyle.Hidden;
                    Info.CreateNoWindow = true;
                    Info.FileName = "cmd.exe";
                    Process.Start(Info);
                    System.Environment.Exit(0);
                }
            }

            TheConfig = new Config();
            TheSelfUpdate = new SelfUpdate();
            TheMainAppContext = new MainAppContext();
            TheStopWatchWrapper = new StopWatchWrapper();
            TheTrexWrapper = new TrexWrapper();

            if (TheConfig.StartMiningOnAppStart)
                Task.Run(() => Program.TheTrexWrapper.Start());

            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            try
            {
                TheSelfUpdate.CleanUp();
            }
            catch { }

            Application.Run(TheMainAppContext);
        }

        private static void UIThreadUnhandledExceptionMessageBox(object sender, ThreadExceptionEventArgs e)
        {
            File.AppendAllText(ExecutionPath + ExceptionLogFileName,
                Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + e.Exception.ToString() + Environment.NewLine);

            try
            {
                MessageBox.Show(e.Exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal exception happend inside UIThreadException handler",
                        "Fatal Windows Forms Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Here we can decide if we want to end our application or do something else
            Application.Exit();
        }

        private static void UnhandledExceptionMessageBox(object sender, UnhandledExceptionEventArgs e)
        {
            File.AppendAllText(ExecutionPath + ExceptionLogFileName,
                Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + ((Exception)e.ExceptionObject).ToString() + Environment.NewLine);

            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal exception happend inside UnhadledExceptionHandler: \n\n"
                        + exc.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            TheMainAppContext.trayIcon.Visible = false;
            TheStopWatchWrapper.SaveToFile();
            if (TheTrexWrapper.IsRunning)
                TheTrexWrapper.Stop();
            TheMutex.ReleaseMutex();
        }
    }
}
