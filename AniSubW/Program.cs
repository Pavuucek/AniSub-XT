using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace AniSubW
{
    static class Program
    {
        public const string ApplicationName = "AniSubW-Grep-a-Fruit";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] agrs)
        {
            string ac = "";

            foreach (string x in agrs)
                ac += x + " ";

            if (ac.Length > 5)
                ac = ac.Substring(0, ac.Length - 5) + ".mdb";

            if (File.Exists(ac))
            {
                string GlobalAdresar = new FileInfo(Application.ExecutablePath).DirectoryName + @"\";

                bool NoInstanceCurrently;

                Mutex mutex = new Mutex(true, ApplicationName, out NoInstanceCurrently);

                if (NoInstanceCurrently)
                {
                    AppDomain.CurrentDomain.AppendPrivatePath(GlobalAdresar);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main(ac, GlobalAdresar));

                    GC.KeepAlive(mutex);
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }
}
