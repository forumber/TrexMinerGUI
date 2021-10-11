using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TrexMinerGUI
{
    public static class Logging
    {
        private static readonly string LogFilePath = Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location) + "_log.txt";

        public static void WriteLog(MethodBase methodBase, string message)
        {
            // The replace method is ugly, i know
            string Tag = methodBase.DeclaringType.ToString().Replace("TrexMinerGUI.","") + "." + methodBase.Name;

            string FinalLogMessage = String.Join(" ", DateTime.Now.ToString("s"), Tag + ":", message);
            File.AppendAllText(LogFilePath, FinalLogMessage + Environment.NewLine);
        }

    }
}
