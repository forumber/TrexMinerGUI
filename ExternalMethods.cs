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

        public static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        // Credits: https://stackoverflow.com/questions/25366534/file-writealltext-not-flushing-data-to-disk
        public static void WriteAllTextWithBackup(string path, string contents)
        {
            // get the bytes
            var data = System.Text.Encoding.UTF8.GetBytes(contents);

            if (!File.Exists(path))
            {
                // write the data to a temp file
                using (var tempFile = File.Create(path, 4096, FileOptions.WriteThrough))
                    tempFile.Write(data, 0, data.Length);
            }
            else
            {
                // generate a temp filename
                var tempPath = Path.GetTempFileName();

                // create the backup name
                var backup = path + ".backup";

                // delete any existing backups
                if (File.Exists(backup))
                    File.Delete(backup);

                // write the data to a temp file
                using (var tempFile = File.Create(tempPath, 4096, FileOptions.WriteThrough))
                    tempFile.Write(data, 0, data.Length);

                // replace the contents
                File.Replace(tempPath, path, backup);
            }
        }
    }
}
