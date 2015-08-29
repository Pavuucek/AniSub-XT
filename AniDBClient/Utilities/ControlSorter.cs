using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AniDBClient.Utilities
{
    //Srovnání prvků
    public class ControlsSorter : IComparer<Control>
    {
        public int Compare(Control x, Control y)
        {
            if (x.Location.Y > y.Location.Y)
            {
                x.TabIndex = 1;
                y.TabIndex = 0;
            }
            else if (x.Location.Y == y.Location.Y)
            {
                if (x.Location.X > y.Location.X)
                {
                    x.TabIndex = 1;
                    y.TabIndex = 0;
                }
                else if (x.Location.X == y.Location.X)
                {
                    x.TabIndex = 1;
                    y.TabIndex = 1;
                }
                else
                {
                    x.TabIndex = 0;
                    y.TabIndex = 1;
                }
            }
            else
            {
                x.TabIndex = 0;
                y.TabIndex = 1;
            }

            return x.TabIndex.CompareTo(y.TabIndex);
        }
    }
}
