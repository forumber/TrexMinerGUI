using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrexMinerGUI
{
    public static class TaskSchedulerOperations
    {
        public static void AddToTS()
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = @"TrexMiner'ı açar";
                //td.Principal.LogonType = TaskLogonType.InteractiveToken;
                td.Principal.RunLevel = TaskRunLevel.Highest;
                td.Settings.StopIfGoingOnBatteries = false;
                td.Settings.DisallowStartIfOnBatteries = false;

                //td.Triggers.Add(new LogonTrigger { UserId = System.Security.Principal.WindowsIdentity.GetCurrent().Name });
                td.Triggers.Add(new LogonTrigger());

                td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.Length - 4) + ".exe", "startup"));

                ts.RootFolder.RegisterTaskDefinition("ETHSayac", td);
            }
        }

        public static void RemoveFromTS()
        {
            using (TaskService ts = new TaskService())
            {
                ts.RootFolder.DeleteTask("ETHSayac");
            }
        }

        public static bool IsItInTS()
        {
            // THIS CAUSES A DELAY, FIND A BETTER SOLUTION!
            using (TaskService ts = new TaskService())
                foreach (var TheTask in ts.RootFolder.AllTasks)
                    if (TheTask.Name == "ETHSayac")
                        return true;

            return false;
        }

    }
}
