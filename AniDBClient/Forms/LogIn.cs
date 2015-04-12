using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;
using AniDB.Lang;

namespace AniDB
{
    public partial class LogIn : Form
    {
        private string GlobalAdresar;
        public SettingsData settingsData;
        OleDbConnection AniDBDatabase;

        public LogIn(string globalAdresar, bool LoadingStart)
        {
            this.GlobalAdresar = globalAdresar;
            InitializeComponent();

            if (File.Exists(GlobalAdresar + @"AniSubLogIn.jpg"))
                this.BackgroundImage = Image.FromFile(GlobalAdresar + @"AniSubLogIn.jpg");

            LogIn_Language.SelectedIndex = 0;

            LogIn_LB03.BackColor = Color.Black;
            LogIn_LB03.BackColor = Color.Transparent;
            LogIn_LB03.Update();

            SQL();

            DirectoryInfo Adersar = new DirectoryInfo(this.GlobalAdresar + @"Accounts");

            this.DialogResult = DialogResult.Cancel;

            foreach (DirectoryInfo AdresarSub in Adersar.GetDirectories())
            {
                if (AdresarSub.Name.Substring(0, 1) != "!")
                {
                    LogIn_Accounts.Items.Add(AdresarSub.Name);
                    if (File.Exists(this.GlobalAdresar + @"AniSub-Account.hash") && LoadingStart)
                    {
                        if (File.Exists(this.GlobalAdresar + @"Accounts\" + AdresarSub.Name + @"\" + AdresarSub.Name + ".dat.enc"))
                            EncDec.Decrypt(this.GlobalAdresar + @"Accounts\" + AdresarSub.Name + @"\" + AdresarSub.Name + ".dat.enc", this.GlobalAdresar + @"Accounts\" + AdresarSub.Name + @"\" + AdresarSub.Name + ".dat", "4651511fac9cbbc80c8417779620b893");

                        settingsData = Settings.Settings_Load(this.GlobalAdresar + @"Accounts\" + AdresarSub.Name + @"\" + AdresarSub.Name + ".dat");

                        if (settingsData != null)
                        {
                            if (settingsData._LoadAutomaticaly)
                            {
                                byte[] bytePass = Encoding.ASCII.GetBytes(settingsData._Pass);
                                byte[] byteLogin = Encoding.ASCII.GetBytes(settingsData._Name);

                                MD5 md5 = MD5.Create();
                                SHA1 sha1 = SHA1.Create();

                                string hashPass = Convert.ToBase64String(md5.ComputeHash(bytePass));
                                string hashLogin = Convert.ToBase64String(md5.ComputeHash(byteLogin));

                                byte[] byteLP = Encoding.ASCII.GetBytes(hashLogin + hashPass);

                                string HashPass = Convert.ToBase64String(sha1.ComputeHash(byteLP));

                                StreamReader Cti = new StreamReader(this.GlobalAdresar + @"AniSub-Account.hash");
                                string HashStream = Cti.ReadLine().Replace("\r", "").Replace("\n", "");
                                Cti.Close();

                                if (HashStream == HashPass)
                                {
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                    break;
                                }
                                else
                                    settingsData = null;
                            }
                            else
                                settingsData = null;
                        }
                    }
                }
            }

            if (LogIn_Accounts.Items.Count > 0)
                LogIn_Accounts.SelectedIndex = 0;
        }

        //Načti jazykovou sadu
        private void InitializeLanguage()
        {
            LogIn_LB01.Text = Language.Options_LB03;
            LogIn_LB02.Text = Language.Options_LB04;
            LogIn_LB03.Text = Language.LogIn_LB03;
            LogIn_LB04.Text = Language.LogIn_LB04;
            LogIn_LB07.Text = Language.LogIn_LB07;
            LogIn_Register.Text = Language.LogIn_Register;
            LogIn_LogIn.Text = Language.LogIn_LogIn;
            LogIn_CH01.Text = Language.LogIn_CH01;
            LogIn_LogOut.Text = Language.LogIn_LogOut;
        }

        //Update databáze v účtě
        private void SQL()
        {
            if (File.Exists(GlobalAdresar + @"Update.sql"))
            {
                List<string> SQLList = new List<string>();

                StreamReader Cti = new StreamReader(GlobalAdresar + @"Update.sql");

                while (Cti.Peek() >= 0)
                    SQLList.Add(Cti.ReadLine());

                Cti.Close();
                Cti.Dispose();

                DirectoryInfo Adresar = new DirectoryInfo(GlobalAdresar + @"Accounts\");

                foreach (DirectoryInfo AdresarSub in Adresar.GetDirectories())
                {
                    if (AdresarSub.Name.Substring(0, 1) != "!")
                        try
                        {
                            string AniDatabasePripojeni = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + this.GlobalAdresar + @"Accounts\" + AdresarSub.Name + @"\" + AdresarSub.Name + ".mdb\";User Id=admin;Password=;";
                            this.AniDBDatabase = new OleDbConnection();
                            this.AniDBDatabase.ConnectionString = AniDatabasePripojeni;
                            this.AniDBDatabase.Open();

                            foreach (string Radek in SQLList)
                                DatabaseAdd(Radek);

                            this.AniDBDatabase.Close();
                            this.AniDBDatabase.Dispose();

                            Process.Start(GlobalAdresar + "AniDBUpdate.exe", (this.GlobalAdresar + @"Accounts\" + AdresarSub.Name + @"\" + AdresarSub.Name).Replace(" ", "?") + ".mdb*" + Process.GetCurrentProcess().MainWindowHandle + "*update");
                        }
                        catch
                        {
                        }
                }

                File.Delete(GlobalAdresar + @"Update.sql");
            }
        }

        //Přidání/editace/mazání z/do databáze - VOID
        private void DatabaseAdd(string SQLString)
        {
            AniDBDatabase.ResetState();

            OleDbCommand SQLCommand = new OleDbCommand();
            SQLCommand.CommandText = SQLString;
            SQLCommand.Connection = AniDBDatabase;

            try
            {
                int response = SQLCommand.ExecuteNonQuery();
            }
            catch
            {
            }

            SQLCommand.Dispose();
        }

        //Zaregistrovat nový účet
        private void LogIn_Register_Click(object sender, EventArgs e)
        {
            if (!LogIn_Accounts.Items.Contains(LogIn_User.Text))
            {
                Directory.CreateDirectory(this.GlobalAdresar + @"Accounts\" + LogIn_User.Text);

                settingsData = new SettingsData();

                settingsData._Pass = LogIn_Password.Text;
                settingsData._Name = LogIn_User.Text;

                Settings.Settings_Save(this.GlobalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat", settingsData);

                File.Copy(this.GlobalAdresar + @"Accounts\OriginalDatabase.mdb", this.GlobalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".mdb");

                LogIn_Accounts.Items.Add(LogIn_User.Text);

                MessageBox.Show(Language.MessageBox_RegisterI, Language.MessageBox_Register);
            }
            else
                MessageBox.Show(Language.MessageBox_RegisterEI, Language.MessageBox_RegisterE);

            LogIn_User_TextChanged(null, null);
        }

        //Přihlásit
        private void LogIn_LogIn_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.GlobalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat.enc"))
                EncDec.Decrypt(this.GlobalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat.enc", this.GlobalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat", "4651511fac9cbbc80c8417779620b893");

            settingsData = Settings.Settings_Load(this.GlobalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat");

            if (settingsData == null)
            {
                settingsData = new SettingsData();
                settingsData._Pass = LogIn_Password.Text;
                settingsData._Name = LogIn_User.Text;

                object[] ml = new object[6];

                ml[0] = "";
                ml[1] = "";
                ml[2] = "";
                ml[3] = "";
                ml[4] = 0;
                ml[5] = false;

                settingsData._MyList.Add(ml);
            }

            if (settingsData._Pass == LogIn_Password.Text)
            {
                if (LogIn_CH01.Checked)
                {
                    settingsData._LoadAutomaticaly = true;
                    settingsData._Language = LogIn_Language.SelectedIndex;
                    Settings.Settings_Save(this.GlobalAdresar + @"Accounts\" + settingsData._Name + @"\" + settingsData._Name + ".dat", settingsData);

                    StreamWriter Zapis = new StreamWriter(this.GlobalAdresar + @"AniSub-Account.hash", false);

                    byte[] bytePass = Encoding.ASCII.GetBytes(settingsData._Pass);
                    byte[] byteLogin = Encoding.ASCII.GetBytes(settingsData._Name);

                    MD5 md5 = MD5.Create();
                    SHA1 sha1 = SHA1.Create();

                    string hashPass = Convert.ToBase64String(md5.ComputeHash(bytePass));
                    string hashLogin = Convert.ToBase64String(md5.ComputeHash(byteLogin));

                    byte[] byteLP = Encoding.ASCII.GetBytes(hashLogin + hashPass);

                    string HashPass = Convert.ToBase64String(sha1.ComputeHash(byteLP));

                    Zapis.Write(HashPass);
                    Zapis.Close();
                    Zapis.Dispose();
                }
                else
                {
                    settingsData._LoadAutomaticaly = false;
                    settingsData._Language = LogIn_Language.SelectedIndex;
                    Settings.Settings_Save(this.GlobalAdresar + @"Accounts\" + settingsData._Name + @"\" + settingsData._Name + ".dat", settingsData);

                    if (File.Exists(this.GlobalAdresar + @"AniSub-Account.hash"))
                        File.Delete(this.GlobalAdresar + @"AniSub-Account.hash");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Retry;
                settingsData = null;
                MessageBox.Show(Language.MessageBox_LogInI, Language.MessageBox_LogIn);
            }
        }

        //Výběr účtu
        private void LogIn_Accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogIn_User.Text = LogIn_Accounts.Text;
        }

        //Přihlášneí přes enter
        private void LogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LogIn_LogIn_Click(sender, null);
            else if (e.KeyCode == Keys.Escape)
                LogIn_LogOut_Click(sender, null);
        }

        //Kontrola účtu
        private void LogIn_User_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(this.GlobalAdresar + @"Accounts\" + LogIn_User.Text))
            {
                LogIn_LogIn.Enabled = true;
                LogIn_Register.Enabled = false;
            }
            else
            {
                LogIn_LogIn.Enabled = false;
                LogIn_Register.Enabled = true;
            }
        }

        //Změna jazyka
        private void LogIn_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LogIn_Language.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");
                    break;
            }

            InitializeLanguage();
        }

        //Odhlášení
        private void LogIn_LogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        //První použítí
        private void LogIn_LB05_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://blog.benda-11.cz/2011/09/anisub-navod-pro-zacatecniky/");
        }

        //První použítí
        private void LogIn_LB06_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://translate.google.com/translate?hl=cs&sl=cs&tl=en&u=http%3A%2F%2Fblog.benda-11.cz%2F2011%2F09%2Fanisub-navod-pro-zacatecniky%2F");
        }

        //Licence
        private void LogIn_LB07_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(GlobalAdresar + @"License.rtf");
        }
    }
}
