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


            TheTimer = new System.Threading.Timer((e) => SaveToFile(), null, dueTime: TimeSpan.FromSeconds(1), period: TimeSpan.FromMinutes(1));
        }

        public void SaveToFile()
        {
            ExternalMethods.WriteAllTextWithBackup(Program.ExecutionPath + FileName, GetTotalElapsedTime().ToString("G"));
        }

        private void LoadFromFile()
        {
            if (!File.Exists(Program.ExecutionPath + FileName))
            {
                ElapsedTimeSoFar = new TimeSpan();
                return;
            }

            string[] TheText = File.ReadAllText(Program.ExecutionPath + FileName).Split(":");
            ElapsedTimeSoFar = new TimeSpan(days: int.Parse(TheText[0]), hours: int.Parse(TheText[1]), minutes: int.Parse(TheText[2]), seconds: int.Parse(TheText[3].Substring(0, 2)));
        }

        public TimeSpan GetTotalElapsedTime()
        {
            return TheStopWatch.Elapsed.Add(ElapsedTimeSoFar);
        }
    }
}
