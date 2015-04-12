using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AniDB
{
    public partial class Calendar : Form
    {
        
        public Calendar(DateTime datum)
        {
            InitializeComponent();

            try
            {
                Cal.SelectionStart = datum;
            }
            catch
            {
                Cal.SelectionStart = DateTime.Today;
            }

            try
            {
                Cal.SelectionEnd = datum;
            }
            catch
            {
                Cal.SelectionEnd = DateTime.Today;
            }
        }

        public DateTime GetDate()
        {
            return Cal.SelectionStart;
        }
    }
}
