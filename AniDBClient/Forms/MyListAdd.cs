using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AniDBClient.Lang;

namespace AniDBClient.Forms
{
    public partial class MyListAdd : Form
    {
        public List<object[]> ML = new List<object[]>();

        public MyListAdd(string index, string source, string storage, string other, string watched, List<object[]> ml)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            Options_MylistState.SelectedIndex = Convert.ToInt32(index);

            Options_MylistSource.Text = source;
            Options_MylistStorage.Text = storage;
            Options_MylistOther.Text = other;

            if (watched == "1")
                Options_CH02.Checked = true;

            Options_LB10.Text = Language.Options_lblOther;
            Options_LB09.Text = Language.Options_lblStorage;
            Options_LB08.Text = Language.Options_lblSource;
            Options_LB07.Text = Language.Options_lblStatus;
            Options_GR02.Text = Language.Options_MyList;
            Options_CH02.Text = Language.Options_Watched;

            ML = ml;

            Options_MyList.Items.Add("Default");

            if (ML != null)
                for (var i = 0; i < ML.Count; i++)
                    Options_MyList.Items.Add(ML[i][0].ToString());
        }

        //Potvrzení
        private void Options_MylistOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        //Při stistku kláves
        private void MyListAdd_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    DialogResult = DialogResult.OK;
                    Close();
                    break;

                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    Close();
                    break;
            }
        }

        //Při vybrání ze seznamu
        private void Options_MyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Options_MyList.SelectedIndex > 0 && Options_MyList.SelectedIndex - 1 < ML.Count)
            {
                Options_GR02.Enabled = false;

                Options_MylistName.Text = ML[Options_MyList.SelectedIndex - 1][0].ToString();
                Options_MylistSource.Text = ML[Options_MyList.SelectedIndex - 1][1].ToString();
                Options_MylistStorage.Text = ML[Options_MyList.SelectedIndex - 1][2].ToString();
                Options_MylistOther.Text = ML[Options_MyList.SelectedIndex - 1][3].ToString();
                Options_MylistState.SelectedIndex = (int) ML[Options_MyList.SelectedIndex - 1][4];
                Options_CH02.Checked = (bool) ML[Options_MyList.SelectedIndex - 1][5];
            }
            else if (Options_MyList.SelectedIndex == 0)
            {
                Options_MylistName.Text = "Default";
                Options_GR02.Enabled = true;
            }
        }

        //Přidání do seznamu
        private void Option_MylistSave_Click(object sender, EventArgs e)
        {
            if (Options_MylistName.Text.Length == 0)
                Options_MylistName.Text = Options_MylistStorage.Text;

            Options_MyList.Items.Add(Options_MylistName.Text);

            var ml = new object[6];

            ml[0] = Options_MylistName.Text;
            ml[1] = Options_MylistSource.Text;
            ml[2] = Options_MylistStorage.Text;
            ml[3] = Options_MylistOther.Text;
            ml[4] = Options_MylistState.SelectedIndex;
            ml[5] = Options_CH02.Checked;

            ML.Add(ml);
        }

        //Smazání ze seznamu
        private void Option_MylistDel_Click(object sender, EventArgs e)
        {
            if (Options_MyList.SelectedIndex > 1 && Options_MyList.SelectedIndex - 1 < ML.Count)
            {
                ML.RemoveAt(Options_MyList.SelectedIndex - 1);
                Options_MyList.Items.RemoveAt(Options_MyList.SelectedIndex);
            }
        }

        //Při ukončení
        private void Option_MylistClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //Při načtení formuláře
        private void MyListAdd_Load(object sender, EventArgs e)
        {
            if (Options_MylistState.SelectedIndex == -1)
                Options_MylistState.SelectedIndex = 0;
        }
    }
}