using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using AniDBClient.Utilities;

namespace AniDBClient.Helpers
{
    public static class ControlHelpers
    {
        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;

            var aProp = typeof (Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        //Srovnání prvků+

        public static List<Control> GetAllControls(Control con)
        {
            var cons = new List<Control>();

            cons.Add(con);

            foreach (Control cont in con.Controls)
            {
                var conts = GetAllControls(cont);

                foreach (var c in conts)
                    cons.Add(c);
            }

            return cons;
        }

        public static void SortControls(List<Control> con)
        {
            con.Sort(new ControlsSorter());

            var k = 1;
            foreach (var cont in con)
            {
                try
                {
                    cont.TabIndex = k;
                }
                catch
                {
                }

                k++;
            }
        }
    }
}