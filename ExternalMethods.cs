using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace TrexMinerGUI
{
    public static class ExternalMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool FreeConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);

        [DllImport("Kernel32", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(HandlerRoutine handler, bool add);

        enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        private delegate bool HandlerRoutine(CtrlTypes CtrlType);

        public static void StopProgram(System.Diagnostics.Process proc)
        {
            if (AttachConsole((uint)proc.Id))
            {
                SetConsoleCtrlHandler(null, true);
                GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);

                proc.WaitForExit();

                FreeConsole();

                SetConsoleCtrlHandler(null, false);
            }
            else
                throw new InvalidOperationException();
        }

        // Credits: https://stackoverflow.com/questions/25366534/file-writealltext-not-flushing-data-to-disk
        public static void WriteAllTextWithBackup(string path, string contents)
        {
            var data = System.Text.Encoding.UTF8.GetBytes(contents);

            if (!File.Exists(path))
            {
                using (var tempFile = File.Create(path, 4096, FileOptions.WriteThrough))
                    tempFile.Write(data, 0, data.Length);
            }
            else
            {
                var tempPath = Path.GetTempFileName();

                var backup = path + ".backup";

                if (File.Exists(backup))
                    File.Delete(backup);

                using (var tempFile = File.Create(tempPath, 4096, FileOptions.WriteThrough))
                    tempFile.Write(data, 0, data.Length);

                File.Replace(tempPath, path, backup);
            }
        }

        public static void ApplyAfterburnerProfile(int ProfileNumber)
        {
            bool IsAlreadyRunning = Process.GetProcessesByName("MSIAfterburner").Length >= 1;

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = @"/m -Profile" + ProfileNumber;
            Info.UseShellExecute = true;
            Info.FileName = @"C:\Program Files (x86)\MSI Afterburner\MSIAfterburner.exe";
            Process.Start(Info);

            if (!IsAlreadyRunning && Program.TheConfig.TryToCloseMSIAfterburnerIfItIsNotRunningAlready)
                KillAfterbuner();
        }

        public static void KillAfterbuner()
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = @"/C timeout /t 10 /nobreak && taskkill /im msiafterburner.exe";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
        }
    }
}
