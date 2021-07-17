using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace TrexMinerGUI
{
    public static class ExternalMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        public static void OpenConsole()
        {
            AllocConsole();
        }

        public static void CloseConsole()
        {
            FreeConsole();
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
    }
}
