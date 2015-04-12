using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace AniDBClient.Utilities
{
    internal class Settings
    {
        //Ulož nastavení
        public static void Settings_Save(string path, SettingsData data)
        {
            if (File.Exists(path))
                File.Delete(path);

            var f = new BinaryFormatter();
            var st = new StreamWriter(path, false, Encoding.UTF8);
            f.Serialize(st.BaseStream, data);
            st.Close();
            st.Dispose();
        }

        //Načti nastavení
        public static SettingsData Settings_Load(string path)
        {
            if (!File.Exists(path)) return null;
            var cti = new StreamReader(path, Encoding.UTF8);
            SettingsData data = null;

            try
            {
                var b = new BinaryFormatter();
                data = (SettingsData) b.Deserialize(cti.BaseStream);
            }
            catch
            {
            }

            cti.Close();
            cti.Dispose();

            return data;
        }
    }

    [Serializable]
    public class SettingsData
    {
        public CheckState AnimeTreeCh01 = CheckState.Unchecked;
        public bool AnimeTreeCh02 = false;
        public int Backup = 5;
        public string DataFilesRb = "DataFiles_RB04";
        public bool DataFilesTreeCh01 = false;
        public bool DataFilesTreeCh02 = false;
        public bool DataFilesTreeCh03 = false;
        public int Delay = 5;
        public bool Export1 = false;
        public bool Export2 = false;
        public bool Export3 = false;
        public bool Export4 = false;
        public string Extensions = ".mkv;.wmv;.avi;.ogm;.flv;.rmvb;.mp4;.ogg;.mpeg;.mpg;.asf;.ed2k;.sfv;.md5;.sha;.xml";
        public bool HashCh01 = false;
        public bool HashCh02 = false;
        public bool HashCh03 = true;
        public int HashWaiting = 0;
        public int Info = 0;
        public int InfoRb = 0;
        public int Language = 0;

        public List<string> ListChars = new List<string>
        {
            "*;%*",
            "/;%*",
            "\\;%*",
            "~;%*",
            "<;%*",
            ">;%*",
            ":;%* -",
            "?;%*",
            "\";%*",
            "|;%*",
            "{;%*",
            "};%*",
            "`;%*'"
        };

        public bool LoadAutomaticaly = false;
        public int Localizace = 0;
        public string MangaDirectory = @"C:\";
        public bool MangaTreeCh01 = false;
        public int Move = 0;
        public int MoveRb = 2;
        public List<object[]> MyList = new List<object[]>();
        public bool MyListAdd = false;
        public List<object> MyListPre = new List<object>();
        public string Name = "";
        public bool OptionsCh08 = true;
        public bool OptionsCh13 = false;
        public bool OptionsCh14 = false;
        public bool OptionsCh15 = true;
        public bool OptionsCh16 = false;
        public bool OptionsCh17 = false;
        public bool OptionsCh18 = false;
        public bool OptionsCh19 = true;
        public bool OptionsCh21 = false;
        public bool OptionsCh24 = false;
        public string OptionsNetwork = "";
        public int PagesAnime = 30;
        public int PagesFile = 80;
        public string Pass = "";
        public string Port = "9000";
        public string PortLocal = "45678";
        public int Rename = 0;
        public int RenameRb = 3;
        public int Reset = 3;
        public bool RulesCh01 = false;
        public bool RulesCh02 = true;
        public bool RulesCh03 = false;
        public bool RulesCh04 = false;
        public int RulesPosition = 0;
        public string Server = "api.anidb.info";
        public int TimeOut = 10;
        public bool TreeList = false;
        public bool WatcherCh01 = false;
        public int WebServerMpchc = 12345;
        public int WebServerPort = 11011;
        public Color Color01 = Color.FromArgb(201, 234, 252);
        public Color Color02 = Color.FromArgb(241, 250, 254);
        public Color Color03 = Color.FromArgb(255, 237, 182);
        public Color Color04 = Color.FromArgb(255, 128, 0);
        public Color Color05 = Color.FromArgb(180, 180, 180);
        public Color Color06 = Color.Black;
        public Color Color07 = Color.Black;
        public Color Color08 = Color.White;
        public Color Color09 = Color.White;
        public Color Color10 = Color.FromArgb(0, 219, 58);
    }
}