using System;
using System.Windows.Forms;

namespace AniDBClient.Forms
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