using Microsoft.Win32.TaskScheduler;

namespace TrexMinerGUI
{
    public static class TaskSchedulerOperations
    {
        public static string TaskName = "TrexMinerGUI";
        public static string OldTaskName = "ETHSayac";

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

                ts.RootFolder.RegisterTaskDefinition(TaskName, td);
            }
        }

        public static void RemoveFromTS()
        {
            using (TaskService ts = new TaskService())
            {
                ts.RootFolder.DeleteTask(TaskName);
            }
        }

        public static bool IsItInTS()
        {
            // THIS CAUSES A DELAY, FIND A BETTER SOLUTION!
            using (TaskService ts = new TaskService())
                foreach (var TheTask in ts.RootFolder.AllTasks)
                    if (TheTask.Name == TaskName)
                        return true;

            return false;
        }

        public static bool IsOldNameInTS()
        {
            // THIS CAUSES A DELAY, FIND A BETTER SOLUTION!
            using (TaskService ts = new TaskService())
                foreach (var TheTask in ts.RootFolder.AllTasks)
                    if (TheTask.Name == OldTaskName)
                        return true;

            return false;
        }

        public static void UpdateTS()
        {
            if (IsOldNameInTS())
            {
                try
                {
                    using (TaskService ts = new TaskService())
                    {
                        ts.RootFolder.DeleteTask(OldTaskName);
                    }
                }
                catch { }

                AddToTS();
            }
        }

    }
}
