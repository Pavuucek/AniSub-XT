using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AniDBClient.Forms;
using WinAPI;

namespace AniDBClient
{
    internal static class Program
    {
        public const string ApplicationName = "AniSub-Grep-a-Fruit";

        [STAThread]
        //Startup hlavního programu
        private static void Main(string[] args)
        {
            var att = "";

            foreach (var arg in args)
                att += arg + " ";

            var executablePath = new FileInfo(Application.ExecutablePath);
            var globalAdresar = executablePath.DirectoryName + @"\";

            bool noInstanceCurrently;

            var mutex = new Mutex(true, ApplicationName, out noInstanceCurrently);

            if (noInstanceCurrently)
            {
                AppDomain.CurrentDomain.AppendPrivatePath(globalAdresar);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main(globalAdresar));

                GC.KeepAlive(mutex);
                GC.WaitForPendingFinalizers();
            }

            if (att == "") return;
            var procs = Process.GetProcesses();

            foreach (var proc in procs)
            {
                if (!proc.ProcessName.Contains("AniSub")) continue;
                if (Process.GetCurrentProcess().Handle != proc.Handle)
                    WinApi.sendWindowsStringMessage((int) proc.MainWindowHandle, 0, att);
            }
        }
    }
}