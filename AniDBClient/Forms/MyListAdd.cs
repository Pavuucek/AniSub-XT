using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AniDBClient.Lang;

namespace AniDBClient
{
    public partial class MyListAdd : Form
    {
        public List<object[]> ML = new List<object[]>();

        public MyListAdd(string Index, string Source, string Storage, string Other, string Watched, List<object[]> ml)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;

            Options_MylistState.SelectedIndex = Convert.ToInt32(Index);

            Options_MylistSource.Text = Source;
            Options_MylistStorage.Text = Storage;
            Options_MylistOther.Text = Other;

            if (Watched == "1")
                Options_CH02.Checked = true;

            Options_LB10.Text = Language.Options_LB10;
            Options_LB09.Text = Language.Options_LB09;
            Options_LB08.Text = Language.Options_LB08;
            Options_LB07.Text = Language.Options_LB07;
            Options_GR02.Text = Language.Options_GR02;
            Options_CH02.Text = Language.Options_CH02;

            ML = ml;

            Options_MyList.Items.Add("Default");

            if (ML != null)
                for (int i = 0; i < ML.Count; i++)
                    Options_MyList.Items.Add(ML[i][0].ToString());
        }

        //Potvrzení
        private void Options_MylistOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Při stistku kláves
        private void MyListAdd_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;

                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
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
                Options_MylistState.SelectedIndex = (int)ML[Options_MyList.SelectedIndex - 1][4];
                Options_CH02.Checked = (bool)ML[Options_MyList.SelectedIndex - 1][5];
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

            object[] ml = new object[6];

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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Při načtení formuláře
        private void MyListAdd_Load(object sender, EventArgs e)
        {
            if (Options_MylistState.SelectedIndex == -1)
                Options_MylistState.SelectedIndex = 0;
        }
    }
}
