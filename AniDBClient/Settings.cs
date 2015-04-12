using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Drawing.Design;
using AniDB.Lang;

namespace AniDB
{
    class Settings
    {
        //Ulož nastavení
        public static void Settings_Save(string Path, SettingsData Data)
        {
            if (File.Exists(Path))
                File.Delete(Path);

            BinaryFormatter f = new BinaryFormatter();
            StreamWriter st = new StreamWriter(Path, false, Encoding.UTF8);
            f.Serialize(st.BaseStream, Data);
            st.Close();
            st.Dispose();
        }

        //Načti nastavení
        public static SettingsData Settings_Load(string Path)
        {
            if (File.Exists(Path))
            {
                StreamReader Cti = new StreamReader(Path, Encoding.UTF8);
                SettingsData Data = null;

                try
                {
                    BinaryFormatter b = new BinaryFormatter();
                    Data = (SettingsData)b.Deserialize(Cti.BaseStream);
                }
                catch
                {
                }

                Cti.Close();
                Cti.Dispose();

                return Data;
            }
            else
                return null;
        }
    }

    [Serializable]
    public class SettingsData
    {
        public string _Server = "api.anidb.info";
        public string _Port = "9000";
        public string _Name = "";
        public string _Pass = "";
        public string _Extensions = ".mkv;.wmv;.avi;.ogm;.flv;.rmvb;.mp4;.ogg;.mpeg;.mpg;.asf;.ed2k;.sfv;.md5;.sha;.xml";
        public string _PortLocal = "45678";
        public string _Manga_Directory = @"C:\";
        public string _Options_Network = "";
        public string _DataFiles_RB = "DataFiles_RB04";

        public int _TimeOut = 10;
        public int _Delay = 5;
        public int _Reset = 3;
        public int _Rename = 0;
        public int _Info = 0;
        public int _Move = 0;
        public int _InfoRB = 0;
        public int _MoveRB = 2;
        public int _RenameRB = 3;
        public int _Localizace = 0;
        public int _PagesFile = 80;
        public int _PagesAnime = 30;
        public int _Language = 0;
        public int _Rules_Position = 0;
        public int _Hash_Waiting = 0;
        public int _Backup = 5;
        public int _WebServerPort = 11011;
        public int _WebServerMPCHC = 12345;

        public bool _LoadAutomaticaly = false;
        public bool _MyListAdd = false;      
        public bool _Rules_CH01 = false;
        public bool _Rules_CH02 = true;
        public bool _Rules_CH03 = false;
        public bool _Rules_CH04 = false;      
        public bool _Options_CH08 = true;
        public bool _Options_CH13 = false;
        public bool _Options_CH14 = false;
        public bool _Options_CH15 = true;
        public bool _Options_CH16 = false;
        public bool _Options_CH17 = false;
        public bool _Options_CH18 = false;
        public bool _Options_CH19 = true;
        public bool _Options_CH21 = false;
        public bool _Options_CH24 = false;
        public bool _TreeList = false;
        public bool _Hash_CH01 = false;
        public bool _Hash_CH02 = false;
        public bool _Hash_CH03 = true;
        public bool _Export1 = false;
        public bool _Export2 = false;
        public bool _Export3 = false;
        public bool _Export4 = false;
        public bool _Watcher_CH01 = false;
        public bool _DataFilesTree_CH01 = false;
        public bool _DataFilesTree_CH02 = false;
        public bool _DataFilesTree_CH03 = false;
        public bool _AnimeTree_CH02 = false;
        public bool _MangaTree_CH01 = false;
        
        public CheckState _AnimeTree_CH01 = CheckState.Unchecked;

        public List<object[]> _MyList = new List<object[]>();
        public List<object> _MyListPre = new List<object>();

        public List<string> _ListChars = new List<string> { "*;%*", "/;%*", "\\;%*", "~;%*", "<;%*", ">;%*", ":;%* -", "?;%*", "\";%*", "|;%*", "{;%*", "};%*", "`;%*'" };

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
