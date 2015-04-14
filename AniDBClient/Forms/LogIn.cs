using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AniDBClient.Lang;
using AniDBClient.Utilities;

namespace AniDBClient.Forms
{
    public partial class LogIn : Form
    {
        private OleDbConnection _aniDbDatabase;
        public SettingsData SettingsData;
        private readonly string _globalAdresar;

        public LogIn(string globalAdresar, bool loadingStart)
        {
            _globalAdresar = globalAdresar;
            InitializeComponent();

            if (File.Exists(_globalAdresar + @"AniSubLogIn.jpg"))
                BackgroundImage = Image.FromFile(_globalAdresar + @"AniSubLogIn.jpg");

            LogIn_Language.SelectedIndex = 0;

            LogIn_LB03.BackColor = Color.Black;
            LogIn_LB03.BackColor = Color.Transparent;
            LogIn_LB03.Update();

            Sql();

            var adresar = new DirectoryInfo(_globalAdresar + @"Accounts");

            DialogResult = DialogResult.Cancel;

            foreach (var adresarSub in adresar.GetDirectories())
            {
                if (adresarSub.Name.Substring(0, 1) != "!")
                {
                    LogIn_Accounts.Items.Add(adresarSub.Name);
                    if (File.Exists(_globalAdresar + @"AniSub-Account.hash") && loadingStart)
                    {
                        if (
                            File.Exists(_globalAdresar + @"Accounts\" + adresarSub.Name + @"\" + adresarSub.Name +
                                        ".dat.enc"))
                            EncDec.Decrypt(
                                _globalAdresar + @"Accounts\" + adresarSub.Name + @"\" + adresarSub.Name + ".dat.enc",
                                _globalAdresar + @"Accounts\" + adresarSub.Name + @"\" + adresarSub.Name + ".dat",
                                "4651511fac9cbbc80c8417779620b893");

                        SettingsData =
                            Settings.Settings_Load(_globalAdresar + @"Accounts\" + adresarSub.Name + @"\" +
                                                   adresarSub.Name + ".dat");

                        if (SettingsData != null)
                        {
                            if (SettingsData.LoadAutomaticaly)
                            {
                                var bytePass = Encoding.ASCII.GetBytes(SettingsData.Pass);
                                var byteLogin = Encoding.ASCII.GetBytes(SettingsData.Name);

                                var md5 = MD5.Create();
                                var sha1 = SHA1.Create();

                                var hashPass = Convert.ToBase64String(md5.ComputeHash(bytePass));
                                var hashLogin = Convert.ToBase64String(md5.ComputeHash(byteLogin));

                                var byteLp = Encoding.ASCII.GetBytes(hashLogin + hashPass);

                                var HashPass = Convert.ToBase64String(sha1.ComputeHash(byteLp));

                                var cti = new StreamReader(_globalAdresar + @"AniSub-Account.hash");
                                var hashStream = cti.ReadLine().Replace("\r", "").Replace("\n", "");
                                cti.Close();

                                if (hashStream == HashPass)
                                {
                                    DialogResult = DialogResult.OK;
                                    Close();
                                    break;
                                }
                                SettingsData = null;
                            }
                            else
                                SettingsData = null;
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
            LogIn_LB01.Text = Language.Options_lblUserName;
            LogIn_LB02.Text = Language.Options_lblPassword;
            LogIn_LB03.Text = Language.LogIn_WelcomeMessage;
            LogIn_LB04.Text = Language.LogIn_FirstUse;
            LogIn_LB07.Text = Language.LogIn_LicenseAgreement;
            LogIn_Register.Text = Language.LogIn_Register;
            LogIn_LogIn.Text = Language.LogIn_LogIn;
            LogIn_CH01.Text = Language.LogIn_AutoLogin;
            LogIn_LogOut.Text = Language.LogIn_LogOut;
        }

        //Update databáze v účtě
        private void Sql()
        {
            if (File.Exists(_globalAdresar + @"Update.sql"))
            {
                var sqlList = new List<string>();

                var cti = new StreamReader(_globalAdresar + @"Update.sql");

                while (cti.Peek() >= 0)
                    sqlList.Add(cti.ReadLine());

                cti.Close();
                cti.Dispose();

                var adresar = new DirectoryInfo(_globalAdresar + @"Accounts\");

                foreach (var adresarSub in adresar.GetDirectories())
                {
                    if (adresarSub.Name.Substring(0, 1) != "!")
                        try
                        {
                            var aniDatabasePripojeni = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + _globalAdresar +
                                                       @"Accounts\" + adresarSub.Name + @"\" + adresarSub.Name +
                                                       ".mdb\";User Id=admin;Password=;";
                            _aniDbDatabase = new OleDbConnection();
                            _aniDbDatabase.ConnectionString = aniDatabasePripojeni;
                            _aniDbDatabase.Open();

                            foreach (var radek in sqlList)
                                DatabaseAdd(radek);

                            _aniDbDatabase.Close();
                            _aniDbDatabase.Dispose();

                            Process.Start(_globalAdresar + "AniDBUpdate.exe",
                                (_globalAdresar + @"Accounts\" + adresarSub.Name + @"\" + adresarSub.Name).Replace(" ",
                                    "?") + ".mdb*" + Process.GetCurrentProcess().MainWindowHandle + "*update");
                        }
                        catch
                        {
                        }
                }

                File.Delete(_globalAdresar + @"Update.sql");
            }
        }

        //Přidání/editace/mazání z/do databáze - VOID
        private void DatabaseAdd(string SQLString)
        {
            _aniDbDatabase.ResetState();

            var sqlCommand = new OleDbCommand();
            sqlCommand.CommandText = SQLString;
            sqlCommand.Connection = _aniDbDatabase;

            try
            {
                var response = sqlCommand.ExecuteNonQuery();
            }
            catch
            {
            }

            sqlCommand.Dispose();
        }

        //Zaregistrovat nový účet
        private void LogIn_Register_Click(object sender, EventArgs e)
        {
            if (!LogIn_Accounts.Items.Contains(LogIn_User.Text))
            {
                Directory.CreateDirectory(_globalAdresar + @"Accounts\" + LogIn_User.Text);

                SettingsData = new SettingsData();

                SettingsData.Pass = LogIn_Password.Text;
                SettingsData.Name = LogIn_User.Text;

                Settings.Settings_Save(
                    _globalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat", SettingsData);

                File.Copy(_globalAdresar + @"Accounts\OriginalDatabase.mdb",
                    _globalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".mdb");

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
            if (File.Exists(_globalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat.enc"))
                EncDec.Decrypt(_globalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat.enc",
                    _globalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat",
                    "4651511fac9cbbc80c8417779620b893");

            SettingsData =
                Settings.Settings_Load(_globalAdresar + @"Accounts\" + LogIn_User.Text + @"\" + LogIn_User.Text + ".dat");

            if (SettingsData == null)
            {
                SettingsData = new SettingsData();
                SettingsData.Pass = LogIn_Password.Text;
                SettingsData.Name = LogIn_User.Text;

                var ml = new object[6];

                ml[0] = "";
                ml[1] = "";
                ml[2] = "";
                ml[3] = "";
                ml[4] = 0;
                ml[5] = false;

                SettingsData.MyList.Add(ml);
            }

            if (SettingsData.Pass == LogIn_Password.Text)
            {
                if (LogIn_CH01.Checked)
                {
                    SettingsData.LoadAutomaticaly = true;
                    SettingsData.Language = LogIn_Language.SelectedIndex;
                    Settings.Settings_Save(
                        _globalAdresar + @"Accounts\" + SettingsData.Name + @"\" + SettingsData.Name + ".dat",
                        SettingsData);

                    var zapis = new StreamWriter(_globalAdresar + @"AniSub-Account.hash", false);

                    var bytePass = Encoding.ASCII.GetBytes(SettingsData.Pass);
                    var byteLogin = Encoding.ASCII.GetBytes(SettingsData.Name);

                    var md5 = MD5.Create();
                    var sha1 = SHA1.Create();

                    var hashPass = Convert.ToBase64String(md5.ComputeHash(bytePass));
                    var hashLogin = Convert.ToBase64String(md5.ComputeHash(byteLogin));

                    var byteLp = Encoding.ASCII.GetBytes(hashLogin + hashPass);

                    var HashPass = Convert.ToBase64String(sha1.ComputeHash(byteLp));

                    zapis.Write(HashPass);
                    zapis.Close();
                    zapis.Dispose();
                }
                else
                {
                    SettingsData.LoadAutomaticaly = false;
                    SettingsData.Language = LogIn_Language.SelectedIndex;
                    Settings.Settings_Save(
                        _globalAdresar + @"Accounts\" + SettingsData.Name + @"\" + SettingsData.Name + ".dat",
                        SettingsData);

                    if (File.Exists(_globalAdresar + @"AniSub-Account.hash"))
                        File.Delete(_globalAdresar + @"AniSub-Account.hash");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.Retry;
                SettingsData = null;
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
            if (Directory.Exists(_globalAdresar + @"Accounts\" + LogIn_User.Text))
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
            DialogResult = DialogResult.Abort;
            Close();
        }

        //První použítí
        private void LogIn_LB05_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://blog.benda-11.cz/2011/09/anisub-navod-pro-zacatecniky/");
        }

        //První použítí
        private void LogIn_LB06_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(
                "http://translate.google.com/translate?hl=cs&sl=cs&tl=en&u=http%3A%2F%2Fblog.benda-11.cz%2F2011%2F09%2Fanisub-navod-pro-zacatecniky%2F");
        }

        //Licence
        private void LogIn_LB07_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(_globalAdresar + @"License.rtf");
        }
    }
}