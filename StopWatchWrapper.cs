using System;
using System.Diagnostics;
using System.IO;

namespace TrexMinerGUI
{
    class StopWatchWrapper
    {
        public Stopwatch TheStopWatch;
        private TimeSpan ElapsedTimeSoFar;
        private readonly string FileName;
        private readonly System.Threading.Timer TheTimer;

        public class MD5Exception : Exception
        {
            public MD5Exception() : base("MD5Mismatch!") { }
        }

        public StopWatchWrapper()
        {
            FileName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location) + ".bin";
            TheStopWatch = new Stopwatch();
            LoadFromFile();


            TheTimer = new System.Threading.Timer((e) => SaveToFile(), null, dueTime: TimeSpan.Zero, period: TimeSpan.FromMinutes(1));
        }

        public void SaveToFile()
        {
            File.WriteAllText(Program.ExecutionPath + FileName, GetTotalElapsedTime().ToString("G"));
            File.WriteAllText(Program.ExecutionPath + FileName + ".md5", ExternalMethods.CalculateMD5(Program.ExecutionPath + FileName));
        }

        private void LoadFromFile()
        {
            if (File.Exists(Program.ExecutionPath + FileName) && File.Exists(Program.ExecutionPath + FileName + ".md5"))
            {
                if (ExternalMethods.CalculateMD5(Program.ExecutionPath + FileName) != File.ReadAllText(Program.ExecutionPath + FileName + ".md5"))
                    throw new MD5Exception();
            }
            else if (File.Exists(Program.ExecutionPath + FileName) && !File.Exists(Program.ExecutionPath + FileName + ".md5"))
            {
                throw new MD5Exception();
            }
            else
            {
                ElapsedTimeSoFar = new TimeSpan();
                return;
            }

            string[] TheText = File.ReadAllText(Program.ExecutionPath + FileName).Split(":");
            ElapsedTimeSoFar = new TimeSpan(days: int.Parse(TheText[0]), hours: int.Parse(TheText[1]), minutes: int.Parse(TheText[2]), seconds: int.Parse(TheText[3].Substring(0,2)));
        }

        public TimeSpan GetTotalElapsedTime()
        {
            return TheStopWatch.Elapsed.Add(ElapsedTimeSoFar);
        }
    }
}
