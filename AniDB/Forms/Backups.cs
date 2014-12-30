using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AniDB
{
    public partial class Backups : Form
    {
        private string GlobalAdresar = "";
        private string Account = "";

        public Backups(string account, string globalAdresar)
        {
            GlobalAdresar = globalAdresar;
            Account = account;

            InitializeComponent();

            BackupsLoad();
        }
        
        //Načtení záloh
        private void BackupsLoad()
        {
            Backups_List.Items.Clear(); 

            FileInfo Soubor = new FileInfo(Account);
            string Ucet = Soubor.Name.Replace(Soubor.Extension, "");

            DirectoryInfo Adresar = new DirectoryInfo(GlobalAdresar + @"Accounts\" + Ucet + @"\");

            foreach (FileInfo x in Adresar.GetFiles("*.mdb"))
            {
                if (x.Name != Ucet + ".mdb")
                    Backups_List.Items.Add(x.Name);
            }
        }

        //Zavřít
        private void Backups_KO_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        //Obnovit ze zálohy
        private void Backups_OK_Click(object sender, EventArgs e)
        {
            if (Backups_List.SelectedIndex >= 0)
            {
                FileInfo Soubor = new FileInfo(Account);
                string Ucet = Soubor.Name.Replace(Soubor.Extension, "");

                FileDelete(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + ".mdb");
                File.Copy(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Backups_List.Items[Backups_List.SelectedIndex], GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + ".mdb");
                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        //Smazat zálohu
        private void Backups_Del_Click(object sender, EventArgs e)
        {
            if (Backups_List.SelectedIndex >= 0)
            {
                FileInfo Soubor = new FileInfo(Account);
                string Ucet = Soubor.Name.Replace(Soubor.Extension, "");

                FileDelete(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Backups_List.Items[Backups_List.SelectedIndex]);

                BackupsLoad();
            }
        }

        //Smazání souboru
        private void FileDelete(string Path)
        {
            if (File.Exists(Path))
                try
                {
                    File.Delete(Path);
                }
                catch
                {
                }
        }
    }
}
