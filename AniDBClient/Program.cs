using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WinAPI;

namespace AniDB
{
    static class Program
    {
        public const string ApplicationName = "AniSub-Grep-a-Fruit";

        [STAThread]
        //Startup hlavního programu
        static void Main(string[] Args)
        {
            string Att = "";

            foreach (string Arg in Args)
                Att += Arg + " ";

            FileInfo ExecutablePath = new FileInfo(Application.ExecutablePath);
            string GlobalAdresar = ExecutablePath.DirectoryName + @"\";                

            bool NoInstanceCurrently;

            Mutex mutex = new Mutex(true, ApplicationName, out NoInstanceCurrently);

            if (NoInstanceCurrently)
            {
                AppDomain.CurrentDomain.AppendPrivatePath(GlobalAdresar);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main(GlobalAdresar));

                GC.KeepAlive(mutex);
                GC.WaitForPendingFinalizers();
            }

            if (Att != "")
            {
                Process[] Procs = Process.GetProcesses();

                foreach (Process Proc in Procs)
                {
                    if (Proc.ProcessName.Contains("AniSub"))
                        if (Process.GetCurrentProcess().Handle != Proc.Handle)
                            WinApi.sendWindowsStringMessage((int)Proc.MainWindowHandle, 0, Att);
                }
            }
        }
    }
}
