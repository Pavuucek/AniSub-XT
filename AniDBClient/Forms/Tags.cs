using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AniDBClient.Forms
{
    public partial class Tags : Form
    {
        public List<string> Tagy;

        public Tags(DataTable tagy, DataTable tagych)
        {
            InitializeComponent();

            for (var i = 0; i < tagy.Rows.Count; i++)
                Tags_Tags.Items.Add(tagy.Rows[i]["tags_name"].ToString());

            for (var i = 0; i < tagych.Rows.Count; i++)
            {
                var x = Tags_Tags.Items.IndexOf(tagych.Rows[i]["tags_name"].ToString());

                if (x >= 0 && x < Tags_Tags.Items.Count)
                    Tags_Tags.SetItemChecked(x, true);
            }
        }

        //Potvrď
        private void Tags_OK_Click(object sender, EventArgs e)
        {
            Tagy = new List<string>();

            foreach (string tag in Tags_Tags.CheckedItems)
                Tagy.Add(tag);

            DialogResult = DialogResult.OK;
            Close();
        }

        //Zavři
        private void Tags_KO_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        //Přidej tag
        private void Tags_Add_Click(object sender, EventArgs e)
        {
            if (Tags_Tag.Text.Length > 0)
            {
                Tags_Tags.Items.Add(Tags_Tag.Text);
                Tags_Tag.Text = "";
            }
        }
    }
}