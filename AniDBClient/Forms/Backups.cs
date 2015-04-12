using System;
using System.IO;
using System.Windows.Forms;

namespace AniDBClient.Forms
{
    public partial class Backups : Form
    {
        private readonly string _account = "";
        private readonly string _globalAdresar = "";

        public Backups(string account, string globalAdresar)
        {
            _globalAdresar = globalAdresar;
            _account = account;

            InitializeComponent();

            BackupsLoad();
        }

        //Načtení záloh
        private void BackupsLoad()
        {
            Backups_List.Items.Clear();

            var soubor = new FileInfo(_account);
            var ucet = soubor.Name.Replace(soubor.Extension, "");

            var adresar = new DirectoryInfo(_globalAdresar + @"Accounts\" + ucet + @"\");

            foreach (var x in adresar.GetFiles("*.mdb"))
            {
                if (x.Name != ucet + ".mdb")
                    Backups_List.Items.Add(x.Name);
            }
        }

        //Zavřít
        private void Backups_KO_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //Obnovit ze zálohy
        private void Backups_OK_Click(object sender, EventArgs e)
        {
            if (Backups_List.SelectedIndex >= 0)
            {
                var soubor = new FileInfo(_account);
                var ucet = soubor.Name.Replace(soubor.Extension, "");

                FileDelete(_globalAdresar + @"Accounts\" + ucet + @"\" + ucet + ".mdb");
                File.Copy(_globalAdresar + @"Accounts\" + ucet + @"\" + Backups_List.Items[Backups_List.SelectedIndex],
                    _globalAdresar + @"Accounts\" + ucet + @"\" + ucet + ".mdb");

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        //Smazat zálohu
        private void Backups_Del_Click(object sender, EventArgs e)
        {
            if (Backups_List.SelectedIndex >= 0)
            {
                var soubor = new FileInfo(_account);
                var ucet = soubor.Name.Replace(soubor.Extension, "");

                FileDelete(_globalAdresar + @"Accounts\" + ucet + @"\" + Backups_List.Items[Backups_List.SelectedIndex]);

                BackupsLoad();
            }
        }

        //Smazání souboru
        private void FileDelete(string path)
        {
            if (File.Exists(path))
                try
                {
                    File.Delete(path);
                }
                catch
                {
                }
        }
    }
}