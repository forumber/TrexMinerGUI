using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace TrexMinerGUI
{
    public static class ExternalMethods
    {
        #region EXTERNAL_CTRL_C

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
        #endregion

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

        // Credits: https://stackoverflow.com/a/43229358/15302047
        // I need these because FileVersionInfo.GetVersionInfo(pathToExe) does not f**king work on t-rex.exe.
        #region EXTERNAL_VERSION
        [DllImport("version.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetFileVersionInfoSize(string lptstrFilename, out int lpdwHandle);

        [DllImport("version.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetFileVersionInfo(string lptstrFilename, int dwHandle, int dwLen, byte[] lpData);

        [DllImport("version.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool VerQueryValue(byte[] pBlock, string lpSubBlock, out IntPtr lplpBuffer, out int puLen);

        public static Tuple<string, string>[] GetVersionInfo(string fileName, params string[] keys)
        {
            int num;
            int size = GetFileVersionInfoSize(fileName, out num);

            if (size == 0)
            {
                throw new Win32Exception();
            }

            var bytes = new byte[size];
            bool success = GetFileVersionInfo(fileName, 0, size, bytes);

            if (!success)
            {
                throw new Win32Exception();
            }

            int size2;
            IntPtr ptr;

            success = VerQueryValue(bytes, @"\VarFileInfo\Translation", out ptr, out size2);

            uint[] langs;

            if (success)
            {
                langs = new uint[size2 / 4];

                for (int i = 0, j = 0; j < size2; i++, j += 4)
                {
                    langs[i] = unchecked((uint)(((ushort)Marshal.ReadInt16(ptr, j) << 16) | (ushort)Marshal.ReadInt16(ptr, j + 2)));
                }
            }
            else
            {
                // Taken from https://referencesource.microsoft.com/#System/services/monitoring/system/diagnosticts/FileVersionInfo.cs,470
                langs = new uint[] { 0x040904B0, 0x040904E4, 0x04090000 };
            }

            string[] langs2 = Array.ConvertAll(langs, x => @"\StringFileInfo\" + x.ToString("X8") + @"\");

            var kv = new Tuple<string, string>[keys.Length];

            for (int i = 0; i < kv.Length; i++)
            {
                string key = keys[i];
                string value = null;

                foreach (var lang in langs2)
                {
                    success = VerQueryValue(bytes, lang + key, out ptr, out size2);

                    if (success)
                    {
                        value = Marshal.PtrToStringUni(ptr);
                        break;
                    }
                }

                kv[i] = Tuple.Create(key, value);
            }

            return kv;
        }
        #endregion

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


        // Credits: https://stackoverflow.com/a/61584671
        #region GRAY_SCALE_IMAGE
        static ColorMatrix grayMatrix = new ColorMatrix(new float[][]
        {
            new float[] { .2126f, .2126f, .2126f, 0, 0 },
            new float[] { .7152f, .7152f, .7152f, 0, 0 },
            new float[] { .0722f, .0722f, .0722f, 0, 0 },
            new float[] { 0, 0, 0, 1, 0 },
            new float[] { 0, 0, 0, 0, 1 }
        });

        public static Bitmap ToGrayScale(Image source)
        {
            var grayImage = new Bitmap(source.Width, source.Height, source.PixelFormat);
            grayImage.SetResolution(source.HorizontalResolution, source.VerticalResolution);

            using (var g = Graphics.FromImage(grayImage))
            using (var attributes = new ImageAttributes())
            {
                attributes.SetColorMatrix(grayMatrix);
                g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
                            0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
                return grayImage;
            }
        }
        #endregion
    }
}
