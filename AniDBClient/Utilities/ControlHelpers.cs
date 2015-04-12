using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AniDBClient.Utilities
{
    public static class ControlHelpers
    {
        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;

            var aProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        //Srovnání prvků+

        public static List<Control> GetAllControls(Control Con)
        {
            List<Control> Cons = new List<Control>();

            Cons.Add(Con);

            foreach (Control Cont in Con.Controls)
            {
                List<Control> Conts = GetAllControls(Cont);

                foreach (Control C in Conts)
                    Cons.Add(C);
            }

            return Cons;
        }

        public static void SortControls(List<Control> Con)
        {
            Con.Sort(new ControlsSorter());

            int k = 1;
            foreach (Control Cont in Con)
            {
                try
                {
                    Cont.TabIndex = k;
                }
                catch
                {
                }

                k++;
            }
        }
    }
}
