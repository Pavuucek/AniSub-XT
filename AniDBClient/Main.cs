using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Imaging;
using System.Security.Cryptography;

using WinAPI;
using Cryptography;
using AniDB.Properties;
using AniDB.Lang;
using ZedGraph;

using HttpServer;
using HttpListener = HttpServer.HttpListener;

namespace AniDB
{
    public partial class Main : Form
    {
        private OleDbConnection AniDBDatabase = null;
        private AniDBClient2 aniDBClient = null;
        private string GlobalAdresar = null;
        private string GlobalAdresarAccount = null;
        private string AniSubV = "84";
        private string AniSubC = "subgui";
        private string AniSubImgUrl = "http://img7.anidb.net/pics/anime/";

        private StreamWriter ZapisLogA = null;
        private StreamWriter ZapisLogS = null;
        private StreamWriter ZapisLogE = null;

        private HttpListener WebServer = null;

        #region BOOL
        private bool Database_Wait = false;
        private bool ComunicationW_Wait = false;
        private bool ComunicationW_Reconncect = true;
        private bool ComunicationW_ReLogIn = true;
        private bool isConnected = false;
        private bool Hash_JeSmazano = false;
        private bool Hash_Chyba = false;
        private bool AmimeTreeWasSelected = false;
        private bool FRename_Wait = true;
        private bool LogonKill = false;
        #endregion

        #region STRING
        private string DatabaseSelectFilesCascade = "";
        private string ComunicationW_DataReceive = null;
        private string ComunicationW_DataSend = null;
        private string ComunicationW_Task = "";
        private string AniDBSessions = null;
        private string MangaUrlObr = "";
        private string Hash_String;
        #endregion

        #region INT
        private Int64 Hash_TotalLenght = 0;
        private Int64 Hash_TotalLenghtCast = 0;
        private const int ODBC_ADD_DSN = 1;
        private int CRessetCount = 0;
        #endregion

        #region IMPORT
        private AniDBMsgs AniDBStatus = AniDBMsgs.A_DISCONNECT;
        private List<string> FRename_List = new List<string>();
        private List<object[]> GlobalMyList = new List<object[]>();
        private FileInfo Watcher_SouborOldM = null;
        private FileInfo Watcher_SouborOldR = null;
        private UnZipRar UnZip = new UnZipRar();

        [DllImport("ODBCCP32.DLL", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SQLConfigDataSource(IntPtr parent, int request, string driver, string attributes);

        [DllImport("Explorerframe.dll")]
        private static extern bool SetProgressState(IntPtr hwnd, uint tbpFlags);

        [DllImport("Explorerframe.dll")]
        private static extern bool SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);
        #endregion

        public Main(string globalAdresar)
        {
            Directory.CreateDirectory(globalAdresar + @"Accounts\!imgs");
            Directory.CreateDirectory(globalAdresar + @"Accounts\!move");
            Directory.CreateDirectory(globalAdresar + @"Accounts\!rename");
            Directory.CreateDirectory(globalAdresar + @"Accounts\!imgsm");

            this.Visible = false;
            this.GlobalAdresar = globalAdresar;

            this.InitializeComponent();

            foreach (Control Cont in this.Controls)
                SortControls(GetAllControls(Cont));

            SetDoubleBuffered(Rules_Replace);
            SetDoubleBuffered(DataAnime);
            SetDoubleBuffered(DataFiles);
            SetDoubleBuffered(AnimeData);
            SetDoubleBuffered(DataGenres);
            SetDoubleBuffered(DataGroups);
            SetDoubleBuffered(DataSearch);
            SetDoubleBuffered(Manga_Data);
            SetDoubleBuffered(DataSQL);
            SetDoubleBuffered(MangaSearch);
            SetDoubleBuffered(Manga_ChaptersDT);
            SetDoubleBuffered(WEB);
            SetDoubleBuffered(MyListAnime);

            Options_Network.Items.Add("");
            Options_Network.SelectedIndex = 0;

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback && adapter.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                    foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Options_Network.Items.Add(adapter.Name + " * " + adapter.Description + " * " + ip.Address.ToString());
                        }
                    }
                }
            }
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        //Srovnání prvků+
        public List<Control> GetAllControls(Control Con)
        {
            List<Control> Cons = new List<Control>();

            Cons.Add(Con);

            foreach (Control Cont in Con.Controls)
            {
                List<Control> Conts = GetAllControls(Cont);

                foreach (Control C in Conts)
                    Cons.Add(C);
            }

            return Cons;
        }

        public void SortControls(List<Control> Con)
        {
            Con.Sort(new ControlsSorter());

            int k = 1;
            foreach (Control Cont in Con)
            {
                try
                {
                    Cont.TabIndex = k;
                }
                catch
                {
                }

                k++;
            }
        }

        //Srovnání prvků
        public class ControlsSorter : IComparer<Control>
        {
            public int Compare(Control x, Control y)
            {
                if (x.Location.Y > y.Location.Y)
                {
                    x.TabIndex = 1;
                    y.TabIndex = 0;
                }
                else if (x.Location.Y == y.Location.Y)
                {
                    if (x.Location.X > y.Location.X)
                    {
                        x.TabIndex = 1;
                        y.TabIndex = 0;
                    }
                    else if (x.Location.X == y.Location.X)
                    {
                        x.TabIndex = 1;
                        y.TabIndex = 1;
                    }
                    else
                    {
                        x.TabIndex = 0;
                        y.TabIndex = 1;
                    }
                }
                else
                {
                    x.TabIndex = 0;
                    y.TabIndex = 1;
                }

                return x.TabIndex.CompareTo(y.TabIndex);
            }
        }

        //Spojení cross-instance
        protected override void WndProc(ref System.Windows.Forms.Message message)
        {
            if (message.Msg == WinApi.SGUI_Show)
                InitializeComponentMylist();
            else if (message.Msg == (int)WinApi.Msgs.WM_COPYDATA)
            {
                WinApi.COPYDATASTRUCT mystr = new WinApi.COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (WinApi.COPYDATASTRUCT)message.GetLParam(mytype);

                Nacti_Hash(mystr.lpData.ToString());
            }

            base.WndProc(ref message);
        }

        #region Po spuštění
        //Načtení uživatele
        private void Main_Load(object sender, EventArgs e)
        {
            if (!File.Exists(GlobalAdresar + @"Accounts\OriginalDatabase.mdb"))
            {
                MessageBox.Show(Language.MessageBox_DB, "Error");
                this.Close();
            }
            else
            {
                Options_MylistState.SelectedIndex = 0;
                LogonKill = !Options_AccountLoad(true);

                if (LogonKill)
                    this.Close();
                else
                {
                    WEB.SuspendLayout();
                    WEB.Navigate(GlobalAdresar + @"Manual\index.en-US.html");
                    WEB.ResumeLayout();

                    AnimeData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    Manga_Data.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    Add_Text02.SelectedIndex = 0;
                    this.ShowInTaskbar = true;
                    this.WindowState = FormWindowState.Maximized;
                    this.Visible = true;
                    DataFiles_Year.Value = DateTime.Now.Year;
                    DataFiles_Month.Value = DateTime.Now.Month;
                    DataFiles_Day.Value = DateTime.Now.Day;

                    if (Options_CH24.Checked)
                        WebServerStart();

                    Watcher_Run();
                }
            }
        }

        //Rozparsování předaných proměných
        private void InitializeComponentArgs(string Agrs)
        {
            string[] AgrsT = Agrs.Split('*');

            if (File.Exists(AgrsT[1]))
            {
                FileInfo Soubor = new FileInfo(AgrsT[1]);

                AgrsT[1] = AgrsT[1].Replace("'", "''");

                if (Options_ExtensionList.Items.Contains(Soubor.Extension.ToLower()))
                {
                    DataTable Exist = DatabaseSelect("SELECT * FROM files WHERE files_ed2k='" + AgrsT[0].ToLower() + "'");

                    if (Exist.Rows.Count == 0)
                    {
                        DatabaseAdd("INSERT INTO files (files_ed2k, files_localfile, files_size, files_date) VALUES ('" + AgrsT[0].ToLower() + "', '" + AgrsT[1] + "', " + AgrsT[2] + ", NOW())");
                        ComunicationNewTask("FILE size=" + AgrsT[2] + "&ed2k=" + AgrsT[0].ToLower() + "&fmask=7FFAFFF9&amask=FEE0F0C1");

                    }
                    else
                    {
                        DatabaseAdd("UPDATE files SET files_localfile='" + AgrsT[1] + "', files_date=NOW() WHERE files_ed2k='" + AgrsT[0].ToLower() + "'");
                        ComunicationNewTask("FILE size=" + AgrsT[2] + "&ed2k=" + AgrsT[0].ToLower() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                    }
                }
            }
        }

        //Načtení Lokolizace
        private void InitializeComponentLanguage()
        {
            MainTab_Mn00.Text = Language.MainTab_Mn00;
            MainTab_Mn01.Text = Language.MainTab_Mn01;
            MainTab_Mn02.Text = Language.MainTab_Mn02;
            MainTab_Mn03.Text = Language.MainTab_Mn03;
            MainTab_Mn04.Text = Language.MainTab_Mn04;
            MainTab_Mn05.Text = Language.MainTab_Mn05;
            MainTab_Mn06.Text = Language.MainTab_Mn06;
            MainTab_Mn07.Text = Language.MainTab_Mn07;

            StatusBar_ConnectLB.Text = Language.StatusBar_ConnectLBOff;

            DataAnime.Columns[4].HeaderText = Language.DataAnime_Mn04;
            DataAnime.Columns[5].HeaderText = Language.DataAnime_Mn05;
            DataAnime.Columns[6].HeaderText = Language.DataAnime_Mn06;
            DataAnime.Columns[7].HeaderText = Language.DataAnime_Mn07;
            DataAnime.Columns[8].HeaderText = Language.DataAnime_Mn08;
            DataAnime.Columns[9].HeaderText = Language.DataAnime_Mn09;
            DataAnime.Columns[10].HeaderText = Language.DataAnime_Mn10;
            DataAnime.Columns[11].HeaderText = Language.DataAnime_Mn11;
            DataAnime.Columns[12].HeaderText = Language.DataAnime_Mn12;
            DataAnime.Columns[13].HeaderText = Language.DataAnime_Mn13;
            DataAnime.Columns[14].HeaderText = Language.DataAnime_Mn14;
            DataAnime.Columns[15].HeaderText = Language.DataAnime_Mn15;

            DataAnime_Menu_Mn01.Text = Language.DataAnime_Menu_Mn01;
            DataAnime_Menu_Mn02.Text = Language.DataAnime_Menu_Mn02;
            DataAnime_Menu_Mn03.Text = Language.DataAnime_Menu_Mn03;
            DataAnime_Menu_Mn01_Mn01.Text = Language.DataAnime_Menu_Mn01_Mn01;
            DataAnime_Menu_Mn01_Mn02.Text = Language.DataAnime_Menu_Mn01_Mn02;
            DataAnime_Menu_Mn01_Mn03.Text = Language.DataAnime_Menu_Mn01_Mn03;
            DataAnime_Menu_Mn01_Mn04.Text = Language.DataAnime_Menu_Mn01_Mn04;
            DataAnime_Menu_Mn01_Mn05.Text = Language.DataAnime_Menu_Mn01_Mn05;
            DataAnime_Menu_Mn01_Mn06.Text = Language.DataAnime_Menu_Mn01_Mn06;

            DataGenres.Columns[3].HeaderText = Language.DataAnime_Mn04;
            DataGenres.Columns[4].HeaderText = Language.DataAnime_Mn05;
            DataGenres.Columns[5].HeaderText = Language.DataAnime_Mn06;
            DataGenres.Columns[6].HeaderText = Language.DataAnime_Mn07;

            DataGroups.Columns[3].HeaderText = Language.DataAnime_Mn04;
            DataGroups.Columns[4].HeaderText = Language.DataAnime_Mn05;
            DataGroups.Columns[5].HeaderText = Language.DataAnime_Mn06;
            DataGroups.Columns[6].HeaderText = Language.DataAnime_Mn07;

            DataSearch.Columns[1].HeaderText = Language.DataAnime_Mn04;
            DataSearch.Columns[2].HeaderText = Language.DataAnime_Mn05;
            DataSearch.Columns[3].HeaderText = Language.DataAnime_Mn06;
            DataSearch.Columns[4].HeaderText = Language.DataAnime_Mn07;

            Rules_LB01.Text = Language.Rules_LB01;

            Rules_GR01.Text = Language.Rules_GR01;
            Rules_GR02.Text = Language.Rules_GR02;
            Rules_GR03.Text = Language.Rules_GR03;

            Options_CH01.Text = Language.Options_CH01;
            Options_CH02.Text = Language.Options_CH02;
            Options_CH03.Text = Language.Options_CH03;
            Options_CH04.Text = Language.Options_CH04;
            Options_CH05.Text = Language.Options_CH05;
            Options_CH06.Text = Language.Options_CH06;
            Options_CH07.Text = Language.Options_CH07;
            Options_CH08.Text = Language.Options_CH08;
            Options_CH09.Text = Language.Options_CH09;
            Options_CH10.Text = Language.Options_CH10;
            Options_CH11.Text = Language.Options_CH11;
            Options_CH12.Text = Language.Options_CH12;
            Options_CH13.Text = Language.Options_CH13;
            Options_CH14.Text = Language.Options_CH14;
            Options_CH15.Text = Language.Options_CH15;
            Options_CH16.Text = Language.Options_CH16;
            Options_CH17.Text = Language.Options_CH17;
            Options_CH18.Text = Language.Options_CH18;
            Options_CH19.Text = Language.Options_CH19;
            Options_CH20.Text = Language.Options_CH20;
            Options_CH21.Text = Language.Options_CH21;
            Options_CH22.Text = Language.Options_CH22;
            Options_CH23.Text = Language.Options_CH23;
            Options_CH24.Text = Language.Options_CH24;

            Options_LB01.Text = Language.Options_LB01;
            Options_LB02.Text = Language.Options_LB02;
            Options_LB03.Text = Language.Options_LB03;
            Options_LB04.Text = Language.Options_LB04;
            Options_LB05.Text = Language.Options_LB05;
            Options_LB06.Text = Language.Options_LB06;
            Options_LB07.Text = Language.Options_LB07;
            Options_LB08.Text = Language.Options_LB08;
            Options_LB09.Text = Language.Options_LB09;
            Options_LB10.Text = Language.Options_LB10;
            Options_LB45.Text = Language.Options_LB45;
            Options_LB51.Text = Language.Options_LB51;
            Options_LB53.Text = Language.Options_LB53;
            Options_LB55.Text = Language.Options_LB55;
            Options_LB57.Text = Language.Options_LB57;
            Options_LB59.Text = Language.Options_LB59;
            Options_LB61.Text = Language.Options_LB61;
            Options_LB63.Text = Language.Options_LB63;
            Options_LB67.Text = Language.Options_LB66;
            Options_LB68.Text = Language.Options_LB68;
            Options_LB69.Text = Language.Options_LB69;

            Options_LB11.Text = Language.Options_Network;
            Options_LB12.Text = Language.Options_GR03;
            Options_LB13.Text = Language.Hash_GR02;

            Rules_FilesRulesRename_RB01.Text = Language.Rules_FilesRulesRename_RB01;
            Rules_FilesRulesRename_RB02.Text = Language.Rules_FilesRulesRename_RB02;
            Rules_CH01.Text = Language.Rules_CH01;
            Rules_CH02.Text = Language.Rules_CH02;
            Rules_CH03.Text = Language.Rules_CH03;
            Rules_CH04.Text = Language.Rules_CH04;

            Rules_Tags.Text = Language.Rules_Tags;

            Rules_InfoRB01.Text = Language.Rules_InfoRB01;
            Rules_InfoRB02.Text = Language.Rules_FilesRulesRename_RB02;
            Rules_GR04.Text = Language.Rules_GR04;

            StatusBar_Mn01.Text = Language.StatusBar_Mn01;

            MainTabLog_Mn01.Text = Language.MainTabLog_Mn01;
            MainTabLog_Mn02.Text = Language.MainTabLog_Mn02;
            MainTabLog_Mn03.Text = Language.MainTabLog_Mn03;
            MainTabLog_Mn04.Text = Language.MainTabLog_Mn04;

            MainTabData_Mn00.Text = Language.MainTabData_Mn00;
            MainTabData_Mn01.Text = Language.MainTabData_Mn01;
            MainTabData_Mn02.Text = Language.MainTabData_Mn02;
            MainTabData_Mn03.Text = Language.MainTabData_Mn03;
            MainTabData_Mn04.Text = Language.MainTabData_Mn04;
            MainTabData_Mn05.Text = Language.MainTabData_Mn05;
            MainTabData_Mn07.Text = Language.MainTabData_Mn07;
            MainTabData_Mn08.Text = Language.MainTabData_Mn08;
            MainTabData_Mn09.Text = Language.MainTabData_Mn09;
            MainTabData_Mn10.Text = Language.MainTabData_Mn10;

            DataSQL_BT01.Text = Language.DataSQL_BT01;
            DataSQL_BT02.Text = Language.DataSQL_BT02;
            DataSQL_BT03.Text = Language.DataSQL_BT03;
            DataSQL_BT04.Text = Language.DataSQL_BT04;
            DataSQL_GR01.Text = Language.DataSQL_GR01;

            DataAnime_Menu_Mn02_Mn01.Text = Language.DataAnime_Menu_Mn02_Mn01;
            DataAnime_Menu_Mn02_Mn02.Text = Language.DataAnime_Menu_Mn02_Mn02;
            DataAnime_Menu_Mn02_Mn03.Text = Language.DataAnime_Menu_Mn02_Mn03;

            DataAnime_Menu_Mn03_Mn01.Text = Language.DataAnime_Menu_Mn03_Mn01;

            DataFiles_Menu_Mn01_Mn01.Text = Language.DataAnime_Menu_Mn02_Mn01;
            DataFiles_Menu_Mn01_Mn02.Text = Language.DataAnime_Menu_Mn02_Mn02;
            DataFiles_Menu_Mn01_Mn03.Text = Language.DataAnime_Menu_Mn02_Mn03;

            DataFiles_Menu_Mn01.Text = Language.DataAnime_Menu_Mn02;
            DataFiles_Menu_Mn02.Text = Language.DataAnime_Menu_Mn03;
            DataFiles_Menu_Mn03.Text = Language.DataFiles_Menu_Mn03;
            DataFiles_Menu_Mn04.Text = Language.DataFiles_Menu_Mn04;
            DataFiles_Menu_Mn07.Text = Language.DataFiles_Menu_Mn07;

            DataFiles_Menu_Mn02_Mn01.Text = Language.DataAnime_Menu_Mn03_Mn01;

            DataFilesTree_CH01.Text = Language.DataFilesTree_CH01;
            DataFilesTree_CH02.Text = Language.DataFilesTree_CH02;
            DataFilesTree_CH03.Text = Language.DataFilesTree_CH03;

            DataFilesTree_Mn01.Text = Language.DataAnime_Menu_Mn01;
            DataFilesTree_Mn02.Text = Language.DataAnime_Menu_Mn02;
            DataFilesTree_Mn03.Text = Language.DataAnime_Menu_Mn03;
            DataFilesTree_Mn04.Text = Language.DataFiles_Menu_Mn04;
            DataFilesTree_Mn05.Text = Language.DataFilesTree_Mn05;
            DataFilesTree_Mn06.Text = Language.DataFiles_Menu_Mn03;
            DataFilesTree_Mn08.Text = Language.DataFiles_Menu_Mn07;

            DataFilesTree_Mn01_Mn01.Text = Language.DataAnime_Menu_Mn01_Mn03;
            DataFilesTree_Mn01_Mn02.Text = Language.DataAnime_Menu_Mn01_Mn06;
            DataFilesTree_Mn02_Mn01.Text = Language.DataAnime_Menu_Mn02_Mn01;
            DataFilesTree_Mn02_Mn02.Text = Language.DataAnime_Menu_Mn02_Mn02;
            DataFilesTree_Mn02_Mn03.Text = Language.DataAnime_Menu_Mn02_Mn03;
            DataFilesTree_Mn03_Mn01.Text = Language.DataAnime_Menu_Mn03_Mn01;

            Anime_LB03.Text = Language.Anime_LB03;
            Anime_LB04.Text = Language.Anime_LB04;
            Anime_LB05.Text = Language.Anime_LB05;
            Anime_LB06.Text = Language.Anime_LB06;
            Anime_LB07.Text = Language.Anime_LB07;
            Anime_LB09.Text = Language.Anime_LB09;
            Anime_LB10.Text = Language.Anime_LB10;
            Anime_LB11.Text = Language.Anime_LB11;

            DataFiles_RB01.Text = Language.DataFiles_RB01;
            DataFiles_RB02.Text = Language.DataFiles_RB02;
            DataFiles_RB03.Text = Language.DataFiles_RB03;
            DataFiles_RB04.Text = Language.DataFiles_RB04;
            DataFiles_RB05.Text = Language.DataFiles_RB05;

            Add_LB01.Text = Language.Add_LB01;

            Rules_FilesRulesMove_RB01.Text = Language.Rules_FilesRulesMove_RB01;
            Rules_FilesRulesMove_RB02.Text = Language.Rules_FilesRulesMove_RB02;
            Rules_FilesRulesMove_RB03.Text = Language.Rules_FilesRulesMove_RB03;

            DataFiles_Mn05.HeaderText = Language.DataFiles_Mn02;
            DataFiles_Mn06.HeaderText = Language.DataFiles_Mn03;
            DataFiles_Mn07.HeaderText = Language.DataFiles_Mn07;
            DataFiles_Mn08.HeaderText = Language.DataFiles_Mn04;
            DataFiles_Mn09.HeaderText = Language.DataFiles_Mn05;
            DataFiles_Mn10.HeaderText = Language.DataFiles_Mn06;

            DataFiles_Mn16.HeaderText = Language.DataFiles_Mn08;
            DataFiles_Mn17.HeaderText = Language.DataFiles_Mn09;

            AnimeData_Mn03.HeaderText = Language.AnimeData_Mn03;
            AnimeData_Mn04.HeaderText = Language.AnimeData_Mn04;
            AnimeData_Mn05.HeaderText = Language.AnimeData_Mn05;

            Hash_GR01.Text = Language.Hash_GR01;
            Hash_LB02.Text = Language.Hash_LB02;

            AnimeData_Menu_Mn01.Text = Language.DataAnime_Menu_Mn01;
            AnimeData_Menu_Mn02.Text = Language.DataAnime_Menu_Mn02;
            AnimeData_Menu_Mn03.Text = Language.DataAnime_Menu_Mn03;
            AnimeData_Menu_Mn04.Text = Language.DataFiles_Menu_Mn04;
            AnimeData_Menu_Mn05.Text = Language.DataFiles_Menu_Mn07;
            AnimeData_Menu_Mn06.Text = Language.DataFiles_Menu_Mn07;

            AnimeData_Menu_Mn01_Mn01.Text = Language.DataAnime_Menu_Mn01_Mn02;
            AnimeData_Menu_Mn01_Mn02.Text = Language.DataAnime_Menu_Mn01_Mn04;
            AnimeData_Menu_Mn02_Mn01.Text = Language.DataAnime_Menu_Mn02_Mn01;
            AnimeData_Menu_Mn02_Mn02.Text = Language.DataAnime_Menu_Mn02_Mn02;
            AnimeData_Menu_Mn02_Mn03.Text = Language.DataAnime_Menu_Mn02_Mn03;
            AnimeData_Menu_Mn03_Mn01.Text = Language.DataAnime_Menu_Mn03_Mn01;

            ToolTip.SetToolTip(DataFiles_Bt00, Language.DataFiles_Bt00_ToolTip);
            ToolTip.SetToolTip(StatusBar_Refresh, Language.DataFiles_Bt00_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt01, Language.DataFiles_Bt01_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt02, Language.DataFiles_Bt02_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt03, Language.DataFiles_Bt03_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt04, Language.DataFiles_Bt04_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt05, Language.DataFiles_Bt05_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt06, Language.DataFiles_Bt06_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt07, Language.DataFiles_Bt07_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt08, Language.DataFiles_Bt08_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt09, Language.DataFiles_Bt09_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt10, Language.DataFiles_Bt10_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt11, Language.DataFiles_Bt11_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt12, Language.DataFiles_Bt12_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt13, Language.DataFiles_Bt13_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt14, Language.DataFiles_Bt14_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt15, Language.DataFiles_Bt15_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt16, Language.DataFiles_Bt16_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt17, Language.DataFiles_Bt17_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt18, Language.DataFiles_Bt18_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt20, Language.DataFiles_Bt20_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt21, Language.DataFiles_Bt21_ToolTip);
            ToolTip.SetToolTip(DataFiles_Bt22, Language.DataFiles_Bt22_ToolTip);
            ToolTip.SetToolTip(DataFilesTree_CH04, Language.DataFilesTree_CH04);
            ToolTip.SetToolTip(Options_SetingsDefault, Language.Options_SetingsDefault_ToolTip);

            DataSearch_LB01.Text = Language.DataSearch_LB01;
            DataSearch_LB02.Text = Language.DataSearch_LB02;
            DataSearch_LB03.Text = Language.DataSearch_LB03;
            DataSearch_LB04.Text = Language.DataSearch_LB04;
            DataSearch_LB05.Text = Language.DataSearch_LB05;
            DataSearch_LB06.Text = Language.DataSearch_LB06;
            DataSearch_LB07.Text = Language.DataSearch_LB07;
            DataSearch_LB08.Text = Language.DataSearch_LB08;
            DataSearch_LB09.Text = Language.DataSearch_LB09;
            DataSearch_LB10.Text = Language.DataSearch_LB10;
            DataSearch_LB11.Text = Language.DataSearch_LB11;
            DataSearch_LB12.Text = Language.DataSearch_LB12;
            DataSearch_LB13.Text = Language.DataSearch_LB13;
            DataSearch_LB14.Text = Language.DataSearch_LB14;
            DataSearch_LB15.Text = Language.DataSearch_LB15;
            DataSearch_LB16.Text = Language.DataSearch_LB16;

            DataSearch_CH02.Text = Language.DataSearch_CH02;

            DataSearch_Clear.Text = Language.DataSearch_Clear;
            DataSearch_Select.Text = Language.DataSearch_Select;

            DataFiles_Menu_Mn05.Text = Language.DataFiles_Menu_Mn05;
            DataFiles_Menu_Mn05_Mn01.Text = Language.DataFiles_Menu_Mn05_Mn01;
            DataFiles_Menu_Mn05_Mn02.Text = Language.DataFiles_Menu_Mn05_Mn02;
            DataFiles_Menu_Mn05_Mn03.Text = Language.DataFiles_Menu_Mn05_Mn03;
            DataFiles_Menu_Mn05_Mn04.Text = Language.DataFiles_Menu_Mn05_Mn04;
            DataFiles_Menu_Mn05_Mn05.Text = Language.DataFiles_Menu_Mn05_Mn05;

            AnimeData_Menu_Mn05.Text = Language.DataFiles_Menu_Mn05;
            AnimeData_Menu_Mn05_Mn01.Text = Language.DataFiles_Menu_Mn05_Mn01;
            AnimeData_Menu_Mn05_Mn02.Text = Language.DataFiles_Menu_Mn05_Mn02;
            AnimeData_Menu_Mn05_Mn03.Text = Language.DataFiles_Menu_Mn05_Mn03;
            AnimeData_Menu_Mn05_Mn04.Text = Language.DataFiles_Menu_Mn05_Mn04;
            AnimeData_Menu_Mn05_Mn05.Text = Language.DataFiles_Menu_Mn05_Mn05;

            AnimeTree_Menu_Mn01.Text = Language.DataFiles_Menu_Mn05;
            AnimeTree_Menu_Mn01_Mn01.Text = Language.DataFiles_Menu_Mn05_Mn01;
            AnimeTree_Menu_Mn01_Mn02.Text = Language.DataFiles_Menu_Mn05_Mn02;
            AnimeTree_Menu_Mn01_Mn03.Text = Language.DataFiles_Menu_Mn05_Mn03;
            AnimeTree_Menu_Mn01_Mn04.Text = Language.DataFiles_Menu_Mn05_Mn04;
            AnimeTree_Menu_Mn01_Mn05.Text = Language.DataFiles_Menu_Mn05_Mn05;
            AnimeTree_Menu_Mn02.Text = Language.AnimeTree_Menu_Mn02;

            AnimeTree_CH01.Text = Language.AnimeTree_CH01;
            AnimeTree_CH02.Text = Language.DataSearch_CH02;

            DataFilesTree_Mn07.Text = Language.DataFiles_Menu_Mn05;
            DataFilesTree_Mn07_Mn01.Text = Language.DataFiles_Menu_Mn05_Mn01;
            DataFilesTree_Mn07_Mn02.Text = Language.DataFiles_Menu_Mn05_Mn02;
            DataFilesTree_Mn07_Mn03.Text = Language.DataFiles_Menu_Mn05_Mn03;
            DataFilesTree_Mn07_Mn04.Text = Language.DataFiles_Menu_Mn05_Mn04;
            DataFilesTree_Mn07_Mn05.Text = Language.DataFiles_Menu_Mn05_Mn05;

            DataAnime_Menu_Mn04.Text = Language.DataFiles_Menu_Mn05;
            DataAnime_Menu_Mn04_Mn01.Text = Language.DataFiles_Menu_Mn05_Mn01;
            DataAnime_Menu_Mn04_Mn02.Text = Language.DataFiles_Menu_Mn05_Mn02;
            DataAnime_Menu_Mn04_Mn03.Text = Language.DataFiles_Menu_Mn05_Mn03;
            DataAnime_Menu_Mn04_Mn04.Text = Language.DataFiles_Menu_Mn05_Mn04;
            DataAnime_Menu_Mn04_Mn05.Text = Language.DataFiles_Menu_Mn05_Mn05;

            StatusBar_Mn03.Text = Language.StatusBar_Mn03;
            StatusBar_Mn04.Text = Language.StatusBar_Mn04_Off;
            StatusBar_Mn05.Text = Language.StatusBar_Mn05;
            StatusBar_Mn05.Text += AniSubV;

            DataFiles_Menu_Mn06.Text = Language.DataFiles_Menu_Mn06;
            DataFiles_Menu_Mn06_Mn01.Text = Language.DataFiles_Menu_Mn06_Mn01;
            DataFiles_Menu_Mn06_Mn02.Text = Language.DataFiles_Menu_Mn06_Mn02;
            DataFiles_Menu_Mn06_Mn03.Text = Language.DataFiles_Menu_Mn06_Mn03;
            DataFiles_Menu_Mn06_Mn04.Text = Language.DataFiles_Menu_Mn06_Mn04;

            DataFiles_LB01.Text = Language.DataFiles_LB01;
            DataFiles_LB02.Text = Language.DataFiles_LB02;
            DataFiles_LB03.Text = Language.DataFiles_LB03;
            DataFiles_LB04.Text = Language.DataFiles_LB04;
            DataFiles_LB05.Text = Language.DataFiles_LB05;

            Watcher_CH01.Text = Language.Watcher_CH01;

            Manga_Gr04.Text = Language.MainTabManga_Mn00;
            MainTabManga_Mn01.Text = Language.MainTabManga_Mn01;
            MainTabManga_Mn02.Text = Language.MainTabManga_Mn02;
            MainTabManga_Mn03.Text = Language.MainTabData_Mn07;

            Manga_Gr02.Text = Language.Manga_Gr02;
            Manga_Gr03.Text = Language.Manga_Gr03;

            Manga_LB01.Text = Language.Manga_LB01;
            Manga_LB03.Text = Language.Manga_LB03;
            Manga_LB05.Text = Language.Manga_LB05;
            Manga_LB07.Text = Language.Manga_LB07;
            Manga_LB09.Text = Language.Manga_LB09;
            Manga_LB15.Text = Language.Manga_LB15;
            Manga_LB25.Text = Language.Manga_LB25;
            Manga_LB16.Text = Language.Manga_LB16;
            Manga_LB17.Text = Language.Manga_LB17;
            Manga_LB18.Text = Language.Manga_LB18;
            Manga_LB19.Text = Language.Manga_LB19;
            Manga_LB20.Text = Language.Manga_LB20;
            Manga_LB21.Text = Language.Manga_LB21;
            Manga_LB22.Text = Language.Manga_LB22;
            Manga_LB23.Text = Language.Manga_LB23;
            Manga_LB24.Text = Language.Manga_LB24;
            Manga_LB35.Text = Language.Manga_LB35;
            Manga_LB36.Text = Language.Manga_LB36;
            Manga_LB37.Text = Language.Manga_LB37;
            Manga_LB39.Text = Language.Manga_LB39;
            Manga_LB41.Text = Language.Manga_LB29;
            Manga_LB42.Text = Language.Manga_LB33;
            Manga_LB43.Text = Language.Manga_LB27;
            Manga_LB44.Text = Language.Manga_LB44;
            Manga_LB50.Text = Language.Manga_LB50;
            Manga_LB51.Text = Language.Manga_LB51;

            MangaSearch_LB01.Text = Language.Manga_LB16;
            MangaSearch_LB02.Text = Language.Manga_LB17;
            MangaSearch_LB03.Text = Language.Manga_LB18;
            MangaSearch_LB04.Text = Language.Manga_LB35;
            MangaSearch_LB05.Text = Language.Manga_LB36;
            MangaSearch_LB06.Text = Language.Manga_LB20;
            MangaSearch_LB07.Text = Language.Manga_LB21;
            MangaSearch_LB08.Text = Language.Manga_LB19;
            MangaSearch_LB09.Text = Language.Manga_LB22;
            MangaSearch_LB10.Text = Language.Manga_LB25;

            MangaSearch_New.Text = Language.DataSearch_Clear;
            MangaSearch_Search.Text = Language.DataSearch_Select;

            MangaTree_CH01.Text = Language.MangaTree_CH01;

            Manga_Data_Menu_Mn02.Text = Language.Manga_Data_Menu_Mn02;
            Manga_Data_Menu_Mn03.Text = Language.Manga_Data_Menu_Mn03;
            Manga_Data_Menu_Mn04.Text = Language.Manga_Data_Menu_Mn04;

            Manga_Data_Mn03.HeaderText = Language.Manga_Data_Mn03;
            Manga_Data_Mn04.HeaderText = Language.Manga_Data_Mn04;
            Manga_Data_Mn05.HeaderText = Language.Manga_Data_Mn05;
            Manga_Data_Mn08.HeaderText = Language.Manga_Data_Mn08;
            Manga_Data_Mn09.HeaderText = Language.Manga_Data_Mn09;
            Manga_Data_Mn10.HeaderText = Language.Manga_Data_Mn10;

            Manga_Tree_Menu_Mn01.Text = Language.Manga_Tree_Menu_Mn01;

            Anime_RelDel.Text = Language.Anime_RelDel;

            Anime_ExportCH01.Text = Language.Anime_ExportCH01;
            Anime_ExportCH02.Text = Language.Anime_ExportCH02;
            Anime_ExportCH03.Text = Language.Anime_ExportCH03;
            Anime_ExportCH04.Text = Language.Anime_ExportCH04;
            Anime_ExportCH05.Text = Language.Anime_ExportCH05;
            Anime_ExportCH06.Text = Language.Anime_ExportCH06;
            Anime_ExportCH07.Text = Language.Anime_ExportCH07;
            Anime_ExportCH08.Text = Language.Anime_ExportCH08;
            Anime_ExportCH09.Text = Language.Anime_ExportCH09;
            Anime_ExportCH10.Text = Language.Anime_ExportCH10;
            Anime_ExportCH11.Text = Language.Anime_ExportCH11;
            Anime_ExportCH12.Text = Language.Anime_ExportCH12;
            Anime_ExportCH13.Text = Language.Anime_ExportCH13;
            Anime_ExportCH14.Text = Language.Anime_ExportCH14;
            Anime_ExportCH15.Text = Language.Anime_ExportCH15;
            Anime_ExportCH16.Text = Language.Anime_ExportCH16;
            Anime_ExportCH17.Text = Language.Anime_ExportCH17;
            Anime_ExportCH18.Text = Language.Anime_ExportCH18;
            Anime_ExportBT01.Text = Language.Anime_ExportBT01;
            Anime_ExportBT02.Text = Language.Anime_ExportBT02;
            Anime_ExportLB01.Text = Language.Anime_ExportLB01;

            Manga_ChaptersCM02.HeaderText = Language.Manga_LB28;
            Manga_ChaptersCM03.HeaderText = Language.Manga_LB32;
            Manga_ChaptersCM04.HeaderText = Language.Manga_LB31;
            Manga_ChaptersCM05.HeaderText = Language.Manga_LB34;
            Manga_ChaptersCM06.HeaderText = Language.Manga_LB29;

            Options_GR01.Text = Language.Options_GR02;
            Options_GR02.Text = Language.Options_GR06Tab01;
            Options_GR03.Text = Language.Options_GR06Tab02;
            Options_GR04.Text = Language.Options_GR04;
            Options_GR05.Text = Language.Options_GR06Tab03;
            Options_GR05.Text = Language.Options_GR06;

            ToolTip.SetToolTip(StatusBar_Hash, Language.Hash);
            ToolTip.SetToolTip(StatusBar_Connect, Language.Options_StartComunicationOff);
            ToolTip.SetToolTip(Options_SetingsSave, Language.Options_SetingsSave);
            ToolTip.SetToolTip(Options_SetingsLoad, Language.Options_SetingsLoad);
            ToolTip.SetToolTip(Options_AccountChange, Language.Options_AccountChange);
            ToolTip.SetToolTip(Options_StartComunication, Language.Options_StartComunicationOff);
            ToolTip.SetToolTip(Options_ExtensionAdd, Language.Options_ExtensionAdd);
            ToolTip.SetToolTip(Options_CH03BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH04BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH05BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH06BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH07BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH08BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH09BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH10BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH11BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH12BT, Language.Options_CH03BT);
            ToolTip.SetToolTip(Options_CH13BT, Language.Options_CH03BT);

            ToolTip.SetToolTip(Rules_FilesRulesMoveAdd, Language.Rules_FilesRulesMoveAdd);
            ToolTip.SetToolTip(Rules_FilesRulesMoveDel, Language.Rules_FilesRulesMoveDel);
            ToolTip.SetToolTip(Rules_InfoAdd, Language.Rules_FilesRulesMoveAdd);
            ToolTip.SetToolTip(Rules_InfoDell, Language.Rules_FilesRulesMoveDel);
            ToolTip.SetToolTip(Rules_FilesRulesRenameAdd, Language.Rules_FilesRulesRenameAdd);
            ToolTip.SetToolTip(Rules_FilesRulesRenameDel, Language.Rules_FilesRulesRenameDel);
            ToolTip.SetToolTip(Options_ExtensionRem, Language.Rules_FilesRulesRenameDel);
            ToolTip.SetToolTip(LogTasksDel, Language.LogTasksDel);
            ToolTip.SetToolTip(LogTasksDelAll, Language.Hash_DeleteAll);
            ToolTip.SetToolTip(Hash_Stop_Total, Language.Hash_Stop_Total);
            ToolTip.SetToolTip(Hash_DeleteAll, Language.Hash_DeleteAll);
            ToolTip.SetToolTip(Hash, Language.Hash);
            ToolTip.SetToolTip(Hash_Delete, Language.Hash_Delete);
            ToolTip.SetToolTip(Hash_Files, Language.Hash_File);
            ToolTip.SetToolTip(Watcher_Delete, Language.Watcher_Delete);
            ToolTip.SetToolTip(Watcher_Add, Language.Watcher_Add);
            ToolTip.SetToolTip(Options_MyListRefreshManga, Language.Options_MyListRefreshManga);
            ToolTip.SetToolTip(Options_MyListRefresh, Language.Options_MyListRefresh);
            ToolTip.SetToolTip(Options_MyListRefreshMin, Language.Options_MyListRefreshMin);
            ToolTip.SetToolTip(Add_Add, Language.Add_Add);
            ToolTip.SetToolTip(Manga_Chapter, Language.Manga_Chapter);
            ToolTip.SetToolTip(Manga_Edit, Language.Manga_Edit);
            ToolTip.SetToolTip(Manga_EditCh, Language.Manga_Edit);
            ToolTip.SetToolTip(Manga_Insert, Language.Manga_Insert);
            ToolTip.SetToolTip(Manga_Update, Language.Manga_Update);
            ToolTip.SetToolTip(Manga_Insert_CHD, Language.Manga_Insert_CH);
            ToolTip.SetToolTip(Manga_Delete, Language.Manga_Delete);
            ToolTip.SetToolTip(Zgc_GraphB01, Language.MainTabData_Mn03);
            ToolTip.SetToolTip(Zgc_GraphB02, Language.DataAnime_Mn14);
            ToolTip.SetToolTip(Zgc_GraphB03, Language.DataAnime_Mn15);
            ToolTip.SetToolTip(Zgc_GraphB04, Language.Zgc_GraphB04);
            ToolTip.SetToolTip(Zgc_GraphB05, Language.Anime_LB11);
            ToolTip.SetToolTip(Zgc_GraphB06, Language.AnimeRating);
            ToolTip.SetToolTip(Options_Color01, Language.Options_Color01);
            ToolTip.SetToolTip(Options_Color02, Language.Options_Color02);
            ToolTip.SetToolTip(Options_Color03, Language.Options_Color03);
            ToolTip.SetToolTip(Options_Color04, Language.Options_Color04);
            ToolTip.SetToolTip(Options_Color05, Language.Options_Color05);
            ToolTip.SetToolTip(Options_Color06, Language.Options_Color06);
            ToolTip.SetToolTip(Options_Color07, Language.Options_Color07);
            ToolTip.SetToolTip(Options_Color08, Language.Options_Color08);
            ToolTip.SetToolTip(Options_Color09, Language.Options_Color09);
            ToolTip.SetToolTip(Options_Color10, Language.Options_Color10);
            ToolTip.SetToolTip(Options_w8Hack, Language.Options_w8Hack);
        }

        //Načtení statistiky
        private void InitializeComponentMylist()
        {
            MyListAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            MyListAnime.SuspendLayout();
            MyListAnime.Rows.Clear();
            MyListAnime.Columns.Clear();

            try
            {
                DataRow rowML = (DatabaseSelect("SELECT * FROM mylist_local")).Rows[0];
                DataRow rowMA = (DatabaseSelect("SELECT * FROM mylist_anidb")).Rows[0];
                DataRow rowMM = (DatabaseSelect("SELECT * FROM mylist_manga")).Rows[0];
                DataTable DTStorage = DatabaseSelect("SELECT * FROM mylist_storages");
                DataTable DTsource = DatabaseSelect("SELECT * FROM mylist_sources");

                MyListAnime.Columns.Add("MyListAnime_CM01", "");
                MyListAnime.Columns.Add("MyListAnime_CM02", "");
                MyListAnime.Columns.Add("MyListAnime_CM03", "");
                MyListAnime.Columns.Add("MyListAnime_CM04", "");
                MyListAnime.Columns.Add("MyListAnime_CM05", "");
                MyListAnime.Columns.Add("MyListAnime_CM06", "");
                MyListAnime.Columns.Add("MyListAnime_CM07", "");
                MyListAnime.Columns.Add("MyListAnime_CM08", "");
                MyListAnime.Columns.Add("MyListAnime_CM09", "");


                MyListAnime.Rows.Add(Language.Options_LB38, "", "", "", Language.Options_LB39);

                MyListAnime.Rows.Add("", Language.Options_LB11, rowML["mylist_local_anime"].ToString(), "", "", Language.Options_LB11, rowMA["mylist_anidb_anime"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB12, rowML["mylist_local_episodes"].ToString(), "", "", Language.Options_LB12, rowMA["mylist_anidb_epn"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB13, rowML["mylist_local_files"].ToString(), "", "", Language.Options_LB13, rowMA["mylist_anidb_files"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB14, rowML["mylist_local_sizetotal"].ToString(), "", "", Language.Options_LB14, rowMA["mylist_anidb_filessize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB47, rowML["mylist_local_lenghtwatched"].ToString(), "", "", Language.Options_LB47, GetLenght((Convert.ToInt64(rowMA["mylist_anidb_mylistviewedmin"].ToString()) * 60).ToString()));

                MyListAnime.Rows.Add("");

                MyListAnime.Rows.Add("", Language.Options_LB15, rowML["mylist_local_watchedanime"].ToString(), "", "", Language.Options_LB47, rowMA["mylist_anidb_mylistviewednum"].ToString() + " (" + rowMA["mylist_anidb_mylistviewed"].ToString() + ")");
                MyListAnime.Rows.Add("", Language.Options_LB16, rowML["mylist_local_watchedsize"].ToString(), "", "", Language.Options_LB37, rowMA["mylist_anidb_viewed"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB46, rowML["mylist_local_groups"].ToString(), "", "", Language.Options_LB40, rowMA["mylist_anidb_mylist"].ToString());
                MyListAnime.Rows.Add("", Language.Options_VL86, rowML["mylist_local_18"].ToString() + " (" + rowML["mylist_local_18P"].ToString() + ")", "", "", Language.Options_LB35, rowMA["mylist_anidb_leech"].ToString());
                MyListAnime.Rows.Add("", "", "", "", "", Language.Options_LB36, rowMA["mylist_anidb_glory"].ToString());
                MyListAnime.Rows.Add("", "", "", "", "", Language.Options_LB43, rowMA["mylist_anidb_votes"].ToString());
                MyListAnime.Rows.Add("", "", "", "", "", Language.Options_LB31, rowMA["mylist_anidb_addanime"].ToString());
                MyListAnime.Rows.Add("", "", "", "", "", Language.Options_LB32, rowMA["mylist_anidb_addepn"].ToString());
                MyListAnime.Rows.Add("", "", "", "", "", Language.Options_LB33, rowMA["mylist_anidb_addfiles"].ToString());
                MyListAnime.Rows.Add("", "", "", "", "", Language.Options_LB44, rowMA["mylist_anidb_revies"].ToString());
                MyListAnime.Rows.Add("", "", "", "", "", Language.Options_LB34, rowMA["mylist_anidb_addgroups"].ToString());


                MyListAnime.Rows.Add("");
                MyListAnime.Rows.Add("");
                MyListAnime.Rows.Add("");

                //TV Serie
                MyListAnime.Rows.Add(Language.Options_VL07);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_tvW"].ToString(), rowML["mylist_local_tv"].ToString(), rowML["mylist_local_tvpercent"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_tvSizeW"].ToString(), rowML["mylist_local_tvSize"].ToString(), rowML["mylist_local_tvpercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_tvLW"].ToString(), rowML["mylist_local_tvL"].ToString(), rowML["mylist_local_tvLP"].ToString());

                MyListAnime.Rows.Add("");

                //TV Specials
                MyListAnime.Rows.Add(Language.Options_VL08);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_tvsW"].ToString(), rowML["mylist_local_tvs"].ToString(), rowML["mylist_local_tvspercent"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_tvsSizeW"].ToString(), rowML["mylist_local_tvsSize"].ToString(), rowML["mylist_local_tvspercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_tvsLW"].ToString(), rowML["mylist_local_tvsL"].ToString(), rowML["mylist_local_tvsLP"].ToString());

                MyListAnime.Rows.Add("");

                //Movies
                MyListAnime.Rows.Add(Language.Options_VL09);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_moviesW"].ToString(), rowML["mylist_local_movies"].ToString(), rowML["mylist_local_moviespercent"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_moviesSizeW"].ToString(), rowML["mylist_local_moviesSize"].ToString(), rowML["mylist_local_moviespercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_moviesLW"].ToString(), rowML["mylist_local_moviesL"].ToString(), rowML["mylist_local_moviesLP"].ToString());

                MyListAnime.Rows.Add("");

                //OVA
                MyListAnime.Rows.Add(Language.Options_VL10);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_ovaW"].ToString(), rowML["mylist_local_ova"].ToString(), rowML["mylist_local_ovapercent"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_ovaSizeW"].ToString(), rowML["mylist_local_ovaSize"].ToString(), rowML["mylist_local_ovapercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_ovaLW"].ToString(), rowML["mylist_local_ovaL"].ToString(), rowML["mylist_local_ovaLP"].ToString());

                MyListAnime.Rows.Add("");

                //WWW
                MyListAnime.Rows.Add(Language.Options_VL11);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_webW"].ToString(), rowML["mylist_local_ova"].ToString(), rowML["mylist_local_web"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_webSizeW"].ToString(), rowML["mylist_local_webSize"].ToString(), rowML["mylist_local_webpercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_webLW"].ToString(), rowML["mylist_local_webL"].ToString(), rowML["mylist_local_webLP"].ToString());

                MyListAnime.Rows.Add("");

                //Music video
                MyListAnime.Rows.Add(Language.Options_VL66);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_musicW"].ToString(), rowML["mylist_local_music"].ToString(), rowML["mylist_local_musicpercent"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_musicSizeW"].ToString(), rowML["mylist_local_musicSize"].ToString(), rowML["mylist_local_musicpercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_musicLW"].ToString(), rowML["mylist_local_musicL"].ToString(), rowML["mylist_local_musicLP"].ToString());

                MyListAnime.Rows.Add("");

                //Other
                MyListAnime.Rows.Add(Language.Options_VL12);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_othersW"].ToString(), rowML["mylist_local_others"].ToString(), rowML["mylist_local_otherspercent"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_othersSizeW"].ToString(), rowML["mylist_local_othersSize"].ToString(), rowML["mylist_local_otherspercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_othersLW"].ToString(), rowML["mylist_local_othersL"].ToString(), rowML["mylist_local_othersLP"].ToString());

                MyListAnime.Rows.Add("");

                //Unknown
                MyListAnime.Rows.Add(Language.Options_VL13);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_unknownW"].ToString(), rowML["mylist_local_unknown"].ToString(), rowML["mylist_local_unknownpercent"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_unknownSizeW"].ToString(), rowML["mylist_local_unknownSize"].ToString(), rowML["mylist_local_unknownpercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_unknownLW"].ToString(), rowML["mylist_local_unknownL"].ToString(), rowML["mylist_local_unknownLP"].ToString());

                MyListAnime.Rows.Add("");

                //Sum
                MyListAnime.Rows.Add(Language.Options_VL21);
                MyListAnime.Rows.Add("", Language.Options_LB18, rowML["mylist_local_sumW"].ToString(), rowML["mylist_local_sum"].ToString(), rowML["mylist_local_sumpercent"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB20, rowML["mylist_local_sumSizeW"].ToString(), rowML["mylist_local_sumSize"].ToString(), rowML["mylist_local_sumpercentsize"].ToString());
                MyListAnime.Rows.Add("", Language.Options_LB21, rowML["mylist_local_sumLW"].ToString(), rowML["mylist_local_sumL"].ToString(), rowML["mylist_local_sumLP"].ToString());

                MyListAnime.Rows.Add("");

                //Status
                MyListAnime.Rows.Add(Language.Options_LB22, Language.Options_LB23, Language.Options_LB24, Language.Options_LB25, Language.Options_LB26);
                MyListAnime.Rows.Add(Language.Options_VL44, rowML["mylist_local_counthdd"].ToString(), rowML["mylist_local_sizehdd"].ToString(), rowML["mylist_local_lenhdd"].ToString(), rowML["mylist_local_watchedhdd"].ToString() + " (" + rowML["mylist_local_watchedhddpercent"].ToString() + ")");
                MyListAnime.Rows.Add(Language.Options_VL45, rowML["mylist_local_countcd"].ToString(), rowML["mylist_local_sizecd"].ToString(), rowML["mylist_local_lencd"].ToString(), rowML["mylist_local_watchedcd"].ToString() + " (" + rowML["mylist_local_watchedcdpercent"].ToString() + ")");
                MyListAnime.Rows.Add(Language.Options_VL46, rowML["mylist_local_countdeleted"].ToString(), rowML["mylist_local_sizedeleted"].ToString(), rowML["mylist_local_lendeleted"].ToString(), rowML["mylist_local_watcheddeleted"].ToString() + " (" + rowML["mylist_local_watcheddeletedpercent"].ToString() + ")");
                MyListAnime.Rows.Add(Language.Options_VL43, rowML["mylist_local_countunknown"].ToString(), rowML["mylist_local_sizeunknown"].ToString(), rowML["mylist_local_lenunknown"].ToString(), rowML["mylist_local_watchedunknown"].ToString() + " (" + rowML["mylist_local_watchedunknownpercent"].ToString() + ")");
                MyListAnime.Rows.Add(Language.Options_VL25, rowML["mylist_local_countsum"].ToString(), rowML["mylist_local_sizesum"].ToString(), rowML["mylist_local_lensum"].ToString(), rowML["mylist_local_watchedsum"].ToString() + " (" + rowML["mylist_local_watchedsumpercent"].ToString() + ")");

                //Storage & source
                MyListAnime.Rows.Add("");
                MyListAnime.Rows.Add(Language.Options_LB48);

                foreach (DataRow rowX in DTStorage.Rows)
                    MyListAnime.Rows.Add("", rowX["mylist_storages_storage"].ToString(), rowX["mylist_storages_count"].ToString(), rowX["mylist_storages_size"].ToString(), rowX["mylist_storages_percent"].ToString());

                MyListAnime.Rows.Add("");
                MyListAnime.Rows.Add(Language.Options_LB49);

                foreach (DataRow rowX in DTsource.Rows)
                    MyListAnime.Rows.Add("", rowX["mylist_storages_storage"].ToString(), rowX["mylist_storages_count"].ToString(), rowX["mylist_storages_size"].ToString(), rowX["mylist_storages_percent"].ToString());

                //MANGA
                Options_LB52.Text = rowMM["mylist_manga_manga"].ToString();
                Options_LB54.Text = rowMM["mylist_manga_volumes"].ToString();
                Options_LB56.Text = rowMM["mylist_manga_chapters"].ToString();
                Options_LB58.Text = rowMM["mylist_manga_size_files"].ToString();
                Options_LB60.Text = rowMM["mylist_manga_manga_read"].ToString() + " (" + rowMM["mylist_manga_manga_readP"].ToString() + ")";
                Options_LB62.Text = rowMM["mylist_manga_pages"].ToString();
                Options_LB64.Text = rowMM["mylist_manga_manga_18"].ToString();
                Options_LB65.Text = rowMM["mylist_manga_pages_read"].ToString() + "/" + rowMM["mylist_manga_pages"].ToString() + " (" + rowMM["mylist_manga_pages_readP"].ToString() + ")";

            }
            catch
            {
            }

            MyListAnime.ResumeLayout();
            MyListAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //Uložit nastavení
        private void Options_SetingsSave_Click(object sender, EventArgs e)
        {
            SettingsData settingsData = new SettingsData();

            settingsData._Pass = Options_Password.Text;
            settingsData._LoadAutomaticaly = true;
            settingsData._Server = Options_ServerName.Text;
            settingsData._Port = Options_ServerPort.Text;
            settingsData._Name = Options_User.Text;
            settingsData._TimeOut = (int)Options_TimeOut.Value;
            settingsData._Delay = (int)Options_Delay.Value;
            settingsData._MyListAdd = Options_CH01.Checked;
            settingsData._Options_CH13 = Options_CH13.Checked;
            settingsData._Options_CH14 = Options_CH14.Checked;
            settingsData._Options_CH15 = Options_CH15.Checked;
            settingsData._Options_CH16 = Options_CH16.Checked;
            settingsData._Options_CH17 = Options_CH17.Checked;
            settingsData._Options_CH18 = Options_CH18.Checked;
            settingsData._Options_CH19 = Options_CH19.Checked;
            settingsData._Options_CH21 = Options_CH21.Checked;
            settingsData._Options_CH24 = Options_CH24.Checked;
            settingsData._Reset = (int)Options_Reset.Value;
            settingsData._Options_Network = Options_Network.SelectedItem.ToString();
            settingsData._MyList = GlobalMyList;
            settingsData._MyListPre.Clear();
            settingsData._MyListPre.Add(Options_MylistStorage.Text);
            settingsData._MyListPre.Add(Options_MylistSource.Text);
            settingsData._MyListPre.Add(Options_MylistOther.Text);
            settingsData._MyListPre.Add(Options_MylistState.SelectedIndex);
            settingsData._MyListPre.Add(Options_CH02.Checked);
            settingsData._PortLocal = Options_LocalPort.Text;
            settingsData._PagesFile = (int)DataFiles_Rows.Value;
            settingsData._PagesAnime = (int)DataAnime_Rows.Value;
            settingsData._Options_CH08 = Options_CH08.Checked;
            settingsData._Hash_CH01 = Hash_CH01.Checked;
            settingsData._Hash_CH02 = Hash_CH02.Checked;
            settingsData._Hash_CH03 = Hash_CH03.Checked;
            settingsData._Rules_Position = Rules_Position.SelectedIndex;
            settingsData._Hash_Waiting = (int)Hash_Waiting.Value;
            settingsData._Export1 = DataFiles_Menu_Mn06_Mn01.Checked;
            settingsData._Export2 = DataFiles_Menu_Mn06_Mn02.Checked;
            settingsData._Export3 = DataFiles_Menu_Mn06_Mn03.Checked;
            settingsData._Export4 = DataFiles_Menu_Mn06_Mn04.Checked;
            settingsData._Watcher_CH01 = Watcher_CH01.Checked;
            settingsData._AnimeTree_CH01 = AnimeTree_CH01.CheckState;
            settingsData._AnimeTree_CH02 = AnimeTree_CH02.Checked;
            settingsData._MangaTree_CH01 = MangaTree_CH01.Checked;
            settingsData._Backup = (int)Options_Backup.Value;
            settingsData._WebServerPort = (int)WebServer_Port.Value;
            settingsData._WebServerMPCHC = (int)WebServer_MPCHC.Value;

            settingsData._DataFilesTree_CH01 = DataFilesTree_CH01.Checked;
            settingsData._DataFilesTree_CH02 = DataFilesTree_CH02.Checked;
            settingsData._DataFilesTree_CH03 = DataFilesTree_CH03.Checked;

            settingsData._Rename = Rules_FilesRulesRenameC.SelectedIndex;
            settingsData._Move = Rules_FilesRulesMoveC.SelectedIndex;
            settingsData._Info = Rules_InfoC.SelectedIndex;

            settingsData._Manga_Directory = Manga_Tx19.Text;

            foreach (Control c in MainTabData_Mn01.Controls)
            {
                if (c is System.Windows.Forms.RadioButton)
                {
                    RadioButton cc = c as System.Windows.Forms.RadioButton;

                    if (cc.Checked)
                        settingsData._DataFiles_RB = cc.Name;
                }
            }

            if (Rules_FilesRulesMove_RB01.Checked)
                settingsData._MoveRB = 1;
            else if (Rules_FilesRulesMove_RB02.Checked)
                settingsData._MoveRB = 2;
            else
                settingsData._MoveRB = 3;

            if (Rules_FilesRulesRename_RB01.Checked)
                settingsData._RenameRB = 1;
            else
                settingsData._RenameRB = 2;

            if (Rules_InfoRB01.Checked)
                settingsData._InfoRB = 1;
            else
                settingsData._InfoRB = 2;

            if (Rules_CH01.Checked)
                settingsData._Rules_CH01 = true;
            else
                settingsData._Rules_CH01 = false;

            if (Rules_CH02.Checked)
                settingsData._Rules_CH02 = true;
            else
                settingsData._Rules_CH02 = false;

            if (Rules_CH03.Checked)
                settingsData._Rules_CH03 = true;
            else
                settingsData._Rules_CH03 = false;

            if (Rules_CH04.Checked)
                settingsData._Rules_CH04 = true;
            else
                settingsData._Rules_CH04 = false;

            settingsData._TreeList = DataFilesTree.Enabled;

            settingsData._Extensions = "";
            foreach (string Polozka in Options_ExtensionList.Items)
                settingsData._Extensions += Polozka + ";";

            settingsData._ListChars.Clear();

            for (int i = 0; i < Rules_Replace.Rows.Count - 1; i++)
                settingsData._ListChars.Add(Rules_Replace[0, i].Value.ToString() + ";%*" + Rules_Replace[1, i].Value.ToString());

            settingsData._Language = Options_Language.SelectedIndex;

            settingsData.Color01 = Options_Color01.BackColor;
            settingsData.Color02 = Options_Color02.BackColor;
            settingsData.Color03 = Options_Color03.BackColor;
            settingsData.Color04 = Options_Color04.BackColor;
            settingsData.Color05 = Options_Color05.BackColor;
            settingsData.Color06 = Options_Color06.BackColor;
            settingsData.Color07 = Options_Color07.BackColor;
            settingsData.Color08 = Options_Color08.BackColor;
            settingsData.Color09 = Options_Color09.BackColor;
            settingsData.Color10 = Options_Color10.BackColor;

            Settings.Settings_Save(GlobalAdresarAccount, settingsData);
        }

        //Načti nastavení
        private void Options_SetingsLoad_Click(object sender, EventArgs e)
        {
            this.Options_SetingsLoadApply(Settings.Settings_Load(GlobalAdresarAccount), false);
        }

        //Našíst defaultní nastavení
        private void Options_SetingsDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.MessageBox_SettingsClear + " 1/3", "Warring", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show(Language.MessageBox_SettingsClear + " 2/3", "Warring", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (MessageBox.Show(Language.MessageBox_SettingsClear + " 3/3", "Warring", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Options_SetingsLoadApply(new SettingsData(), true);
                    }
                }
            }
        }

        //Aplikuj nastavení
        private void Options_SetingsLoadApply(SettingsData settingsData, bool defaultSettingsData)
        {
            Options_Language.SelectedIndex = settingsData._Language;

            Options_ServerName.Text = settingsData._Server;
            Options_ServerPort.Text = settingsData._Port;

            if (!defaultSettingsData)
            {
                Options_User.Text = settingsData._Name;
                Options_Password.Text = settingsData._Pass;
            }

            Options_TimeOut.Value = settingsData._TimeOut;
            Options_Delay.Value = settingsData._Delay;
            Options_CH01.Checked = settingsData._MyListAdd;
            GlobalMyList = settingsData._MyList;
            Options_Reset.Value = settingsData._Reset == 0 ? 3 : settingsData._Reset;
            Options_CH13.Checked = settingsData._Options_CH13;
            Options_CH14.Checked = settingsData._Options_CH14;
            Options_CH15.Checked = settingsData._Options_CH15;
            Options_CH16.Checked = settingsData._Options_CH16;
            Options_CH17.Checked = settingsData._Options_CH17;
            Options_CH18.Checked = settingsData._Options_CH18;
            Options_CH19.Checked = settingsData._Options_CH19;
            Options_CH21.Checked = settingsData._Options_CH21;
            Options_CH24.Checked = settingsData._Options_CH24;

            try
            {
                WebServer_Port.Value = settingsData._WebServerPort;
                WebServer_MPCHC.Value = settingsData._WebServerMPCHC;
            }
            catch { }

            if (settingsData._Options_Network != null)
            {
                string[] OP = settingsData._Options_Network.Split(new string[] { " * " }, StringSplitOptions.None);

                for (int i = 0; i < Options_Network.Items.Count; i++)
                {
                    if (Options_Network.Items[i].ToString().Contains(OP[0]))
                    {
                        Options_Network.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (settingsData._MyListPre != null)
            {
                if (settingsData._MyListPre.Count == 5)
                {
                    try
                    {
                        Options_MylistStorage.Text = (string)settingsData._MyListPre[0];
                        Options_MylistSource.Text = (string)settingsData._MyListPre[1].ToString();
                        Options_MylistOther.Text = (string)settingsData._MyListPre[2].ToString();
                        Options_MylistState.SelectedIndex = (int)settingsData._MyListPre[3];
                        Options_CH02.Checked = (bool)settingsData._MyListPre[4];
                    }
                    catch
                    {
                    }
                }
            }

            foreach (Control c in MainTabData_Mn01.Controls)
            {
                if (c is System.Windows.Forms.RadioButton)
                {
                    RadioButton cc = c as System.Windows.Forms.RadioButton;

                    if (cc.Name == settingsData._DataFiles_RB)
                        cc.Checked = true;
                }
            }

            Options_LocalPort.Text = settingsData._PortLocal;

            if (settingsData._PagesFile > 1000)
                DataFiles_Rows.Value = 1000;
            else
                DataFiles_Rows.Value = settingsData._PagesFile;


            DataAnime_Rows.Value = settingsData._PagesAnime > 5000 ? 5000 : settingsData._PagesAnime;

            Options_CH08.Checked = settingsData._Options_CH08;
            Hash_CH01.Checked = settingsData._Hash_CH01;
            Hash_CH02.Checked = settingsData._Hash_CH02;
            Hash_CH03.Checked = settingsData._Hash_CH03;
            Rules_Position.SelectedIndex = settingsData._Rules_Position;
            Hash_Waiting.Value = settingsData._Hash_Waiting;
            DataFiles_Menu_Mn06_Mn01.Checked = settingsData._Export1;
            DataFiles_Menu_Mn06_Mn02.Checked = settingsData._Export2;
            DataFiles_Menu_Mn06_Mn03.Checked = settingsData._Export3;
            DataFiles_Menu_Mn06_Mn04.Checked = settingsData._Export4;
            Watcher_CH01.Checked = settingsData._Watcher_CH01;
            AnimeTree_CH01.CheckState = settingsData._AnimeTree_CH01;
            AnimeTree_CH02.Checked = settingsData._AnimeTree_CH02;
            MangaTree_CH01.Checked = settingsData._MangaTree_CH01;
            Options_Backup.Value = settingsData._Backup == 0 ? 2 : settingsData._Backup;

            DataFilesTree_CH01.Checked = settingsData._DataFilesTree_CH01;
            DataFilesTree_CH02.Checked = settingsData._DataFilesTree_CH02;
            DataFilesTree_CH03.Checked = settingsData._DataFilesTree_CH03;

            Manga_Tx19.Text = settingsData._Manga_Directory;

            if (Rules_FilesRulesRenameC.Items.Count > settingsData._Rename)
                Rules_FilesRulesRenameC.SelectedIndex = settingsData._Rename;

            if (Rules_FilesRulesMoveC.Items.Count > settingsData._Move)
                Rules_FilesRulesMoveC.SelectedIndex = settingsData._Move;

            if (Rules_InfoC.Items.Count > settingsData._Info)
                Rules_InfoC.SelectedIndex = settingsData._Info;

            switch (settingsData._MoveRB)
            {
                case 1:
                    Rules_FilesRulesMove_RB01.Checked = true;
                    break;

                case 2:
                    Rules_FilesRulesMove_RB02.Checked = true;
                    break;

                case 3:
                    Rules_FilesRulesMove_RB03.Checked = true;
                    break;

                default:
                    Rules_FilesRulesMove_RB01.Checked = true;
                    break;
            }

            switch (settingsData._RenameRB)
            {
                case 1:
                    Rules_FilesRulesRename_RB01.Checked = true;
                    break;

                case 2:
                    Rules_FilesRulesRename_RB02.Checked = true;
                    break;

                default:
                    Rules_FilesRulesRename_RB01.Checked = true;
                    break;
            }

            switch (settingsData._InfoRB)
            {
                case 1:
                    Rules_InfoRB01.Checked = true;
                    break;

                case 2:
                    Rules_InfoRB02.Checked = true;
                    break;

                default:
                    Rules_InfoRB02.Checked = true;
                    break;
            }

            if (settingsData._Rules_CH01)
                Rules_CH01.Checked = true;
            else
                Rules_CH01.Checked = false;


            if (settingsData._Rules_CH02)
                Rules_CH02.Checked = true;
            else
                Rules_CH02.Checked = false;

            if (settingsData._Rules_CH03)
                Rules_CH03.Checked = true;
            else
                Rules_CH03.Checked = false;

            if (settingsData._Rules_CH04)
                Rules_CH04.Checked = true;
            else
                Rules_CH04.Checked = false;

            if (settingsData._TreeList)
                DataFiles_Bt19_Click(null, null);

            Options_ExtensionList.Items.Clear();
            foreach (string Polozka in settingsData._Extensions.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                Options_ExtensionList.Items.Add(Polozka);

            Rules_Replace.SuspendLayout();
            Rules_Replace.Rows.Clear();
            foreach (string Polozka in settingsData._ListChars)
            {
                string[] PolozkaT = Polozka.Split(new string[] { ";%*" }, StringSplitOptions.None);

                Rules_Replace.Rows.Add(PolozkaT[0], PolozkaT[1]);
            }
            Rules_Replace.ResumeLayout();

            Options_Color01.BackColor = settingsData.Color01.A == 0 ? Color.FromArgb(201, 234, 252) : settingsData.Color01;
            Options_Color02.BackColor = settingsData.Color02.A == 0 ? Color.FromArgb(241, 250, 254) : settingsData.Color02;
            Options_Color03.BackColor = settingsData.Color03.A == 0 ? Color.FromArgb(255, 237, 182) : settingsData.Color03;
            Options_Color04.BackColor = settingsData.Color04.A == 0 ? Color.FromArgb(194, 247, 177) : settingsData.Color04;
            Options_Color05.BackColor = settingsData.Color05.A == 0 ? Color.FromArgb(180, 180, 180) : settingsData.Color05;
            Options_Color06.BackColor = settingsData.Color06.A == 0 ? Color.Black : settingsData.Color06;
            Options_Color07.BackColor = settingsData.Color07.A == 0 ? Color.Black : settingsData.Color07;
            Options_Color08.BackColor = settingsData.Color08.A == 0 ? Color.White : settingsData.Color08;
            Options_Color09.BackColor = settingsData.Color09.A == 0 ? Color.White : settingsData.Color09;
            Options_Color10.BackColor = settingsData.Color10.A == 0 ? Color.FromArgb(0, 219, 58) : settingsData.Color10;

            Option_ColorChange();
        }

        //Změna účtu
        private void Options_AccountChange_Click(object sender, EventArgs e)
        {
            FileDelete(GlobalAdresar + @"AniSub-Account.hash");

            this.MainTab.Enabled = false;
            if (!Options_AccountLoad(false))
                this.Close();
        }

        //Načtení účtu
        private bool Options_AccountLoad(bool LoadingStart)
        {
            DialogResult dialogResult;

            while (true)
            {
                LogIn logIn = new LogIn(GlobalAdresar, LoadingStart);

                if (logIn.IsDisposed)
                    dialogResult = logIn.DialogResult;
                else
                    dialogResult = logIn.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    Options_ExtensionList.Items.Clear();

                    Rules_Replace.SuspendLayout();
                    Rules_Replace.Rows.Clear();
                    Rules_Replace.ResumeLayout();

                    DirectoryInfo Adresar = new DirectoryInfo(GlobalAdresar + @"Accounts\!imgs\");

                    foreach (FileInfo Soubor in Adresar.GetFiles())
                    {
                        if (Soubor.Length == 0)
                            FileDelete(Soubor.FullName);
                    }

                    Adresar = new DirectoryInfo(GlobalAdresar + @"Accounts\!rename\");
                    foreach (FileInfo Soubor in Adresar.GetFiles("*.txt"))
                        Rules_FilesRulesRenameC.Items.Add(Soubor.Name.Replace(".txt", ""));

                    Adresar = new DirectoryInfo(GlobalAdresar + @"Accounts\!move\");
                    foreach (FileInfo Soubor in Adresar.GetFiles("*.txt"))
                        Rules_FilesRulesMoveC.Items.Add(Soubor.Name.Replace(".txt", ""));

                    Adresar = new DirectoryInfo(GlobalAdresar + @"Accounts\!info\");
                    foreach (FileInfo Soubor in Adresar.GetFiles("*.txt"))
                        Rules_InfoC.Items.Add(Soubor.Name.Replace(".txt", ""));

                    this.MainTab.Enabled = true;
                    this.StatusBar_Connect.Enabled = true;

                    this.Options_SetingsLoadApply(logIn.settingsData, false);

                    GlobalAdresarAccount = this.GlobalAdresar + @"Accounts\" + logIn.settingsData._Name + @"\" + logIn.settingsData._Name + ".dat";

                    ChBackup();
                    LogFileEnable();

                    try
                    {
                        string AniDatabasePripojeni = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + this.GlobalAdresar + @"Accounts\" + logIn.settingsData._Name + @"\" + logIn.settingsData._Name + ".mdb\";User Id=Admin;Password=;";
                        this.AniDBDatabase = new OleDbConnection();
                        this.AniDBDatabase.ConnectionString = AniDatabasePripojeni;
                        this.AniDBDatabase.Open();
                    }
                    catch
                    {
                        this.MainTab.Enabled = false;
                        this.StatusBar_Connect.Enabled = false;
                        MessageBox.Show(Language.MessageBox_AccoutI, Language.MessageBox_Accout);
                        Options_AccountLoad(false);
                    }

                    // Zkontrolování souborů dle AniDB
                    this.InitializeComponentFilesMylist();

                    //MyList
                    InitializeComponentMylist();

                    DataTable HashTable = DatabaseSelect("SELECT * FROM hash_files");

                    foreach (DataRow Row in HashTable.Rows)
                        Hash_Nazvy_Souboru.Items.Add(Row["hash_files_file"].ToString());

                    Hash_Check();

                    FileDelete(GlobalAdresarAccount + ".enc");

                    MainTab.MouseMove += new MouseEventHandler(Tab_MouseMove);
                    MainTabData.MouseMove += new MouseEventHandler(Tab_MouseMove);
                    MainTabManga.MouseMove += new MouseEventHandler(Tab_MouseMove);
                    MainTabLog.MouseMove += new MouseEventHandler(Tab_MouseMove);

                    MainTab.MouseWheel += new MouseEventHandler(Tab_MouseWheel);
                    MainTabData.MouseWheel += new MouseEventHandler(Tab_MouseWheel);
                    MainTabManga.MouseWheel += new MouseEventHandler(Tab_MouseWheel);
                    MainTabLog.MouseWheel += new MouseEventHandler(Tab_MouseWheel);

                    break;
                }
                else if (dialogResult == DialogResult.Abort)
                    break;
            }

            if (dialogResult == DialogResult.Abort)
                return false;
            else
                return true;
        }

        //Blokování WEB
        private void WEB_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            WEB.SuspendLayout();

            if (!e.Url.AbsolutePath.Contains("Manual/index"))
            {
                if (e.Url.ToString().Contains("http://") || e.Url.ToString().Contains("License.rtf"))
                    Process.Start(e.Url.ToString());
                else
                    Nacti_Hash(Uri.UnescapeDataString(e.Url.AbsolutePath));

                e.Cancel = true;
            }

            if (e.Url.AbsolutePath.Contains("index.en-US.html"))
            {
                if (Options_CH18.Checked)
                {
                    StreamReader Cti = new StreamReader(GlobalAdresar + @"Manual\index.en-US.html");
                    string TxO = Cti.ReadToEnd();
                    Cti.Close();
                    Cti.Dispose();

                    StreamWriter Zapis = new StreamWriter(GlobalAdresar + @"Manual\index.en-US-Full-1.html");
                    Zapis.Write(TxO.Replace("%animes%", ""));
                    Zapis.Close();
                    Zapis.Dispose();

                    e.Cancel = true;
                    WEB.Navigate(GlobalAdresar + @"Manual\index.en-US-Full-1.html");
                }
                else
                {
                    DataTable DT;

                    if (Options_CH14.Checked)
                        DT = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_obr FROM anime ORDER BY anime_nazevjap");
                    else
                        DT = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_obr FROM anime WHERE anime_18=0 ORDER BY anime_nazevjap");

                    string animes = "";
                    string lists = "";

                    StreamReader Cti = new StreamReader(GlobalAdresar + @"Manual\index.en-US.html");
                    string TxO = Cti.ReadToEnd();
                    Cti.Close();
                    Cti.Dispose();

                    int k = 1;

                    int c = DT.Rows.Count / 28 + 1;

                    DirectoryInfo Adresar = new DirectoryInfo(GlobalAdresar + "Manual");

                    foreach (FileInfo Soubor in Adresar.GetFiles("index.en-US-Full-*.html"))
                        FileDelete(Soubor.FullName);

                    for (int i = 1; i <= c; i++)
                        lists += "<a href=\"" + GlobalAdresar + "Manual\\index.en-US-Full-" + i.ToString() + ".html\">" + i + "</a> ";

                    lists = "<div class=\"lists\">" + lists + "</div>";

                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        if (i > 0 && i % 28 == 0)
                        {
                            if (animes != "")
                            {
                                string pages = "<div class=\"pages\">";
                                if (k > 1)
                                    pages += "<a href=\"" + GlobalAdresar + "Manual\\index.en-US-Full-" + (k - 1).ToString() + ".html\">««««««</a>";
                                pages += " <a href=\"" + GlobalAdresar + "Manual\\index.en-US-Full-" + (k + 1).ToString() + ".html\">»»»»»»</a>";
                                pages += "</div>";

                                animes = pages + "<hr class=\"cistic\" />" + animes + "<hr class=\"cistic\" />" + pages + "<hr class=\"cistic\" />" + lists;
                            }

                            StreamWriter Zapis = new StreamWriter(GlobalAdresar + @"Manual\index.en-US-Full-" + k + ".html");
                            Zapis.Write(TxO.Replace("%animes%", animes));
                            Zapis.Close();
                            Zapis.Dispose();

                            animes = "";
                            k++;
                        }

                        animes += "<div class=\"anime\">";
                        animes += "<a href=\"" + GlobalAdresar + @"Manual\anime" + DT.Rows[i]["id_anime"].ToString() + ".html\">";
                        if (File.Exists(GlobalAdresar + @"Accounts\!imgs\" + DT.Rows[i]["anime_obr"].ToString()))
                            animes += "<img src=\"" + GlobalAdresar + @"Accounts\!imgs\" + DT.Rows[i]["anime_obr"].ToString() + "\" alt=\"\" />";
                        animes += "<br />" + DT.Rows[i]["anime_nazevjap"].ToString() + "</a>\r\n";
                        animes += "</div>";
                    }

                    if (k > 0)
                    {
                        if (animes != "")
                        {
                            string pages = "<div class=\"pages\">";
                            if (k > 1)
                                pages += "<a href=\"" + GlobalAdresar + "Manual\\index.en-US-Full-" + (k - 1).ToString() + ".html\">««««««</a>";
                            pages += "</div>";

                            animes = pages + "<hr class=\"cistic\" />" + animes + "<hr class=\"cistic\" />" + pages + "<hr class=\"cistic\" />" + lists;
                        }

                        StreamWriter Zapis = new StreamWriter(GlobalAdresar + @"Manual\index.en-US-Full-" + k + ".html");
                        Zapis.Write(TxO.Replace("%animes%", animes));
                        Zapis.Close();
                        Zapis.Dispose();
                    }

                    e.Cancel = true;
                    WEB.Navigate(GlobalAdresar + @"Manual\index.en-US-Full-1.html");
                }
            }

            if (e.Url.AbsolutePath.Contains(@"Manual/anime"))
            {
                AnimeTree_Find(Parse(e.Url.AbsolutePath, "Manual/anime", ".", false));
                e.Cancel = true;
            }

            WEB.ResumeLayout();
        }

        //Vytvoř a zkontroluj zálohy
        private void ChBackup()
        {
            FileInfo Soubor = new FileInfo(GlobalAdresarAccount);
            string Ucet = Soubor.Name.Replace(Soubor.Extension, "");

            string datum = DateTime.Now.Year.ToString() + "-" + String.Format("{0:00}", DateTime.Now.Month) + "-" + String.Format("{0:00}", DateTime.Now.Day);

            if (!File.Exists(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + "-" + datum + ".mdb")
                && File.Exists(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + ".mdb"))
                File.Copy(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + ".mdb", GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + "-" + datum + ".mdb");

            FileDelete(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + "-B.mdb");

            DirectoryInfo Adresar = new DirectoryInfo(GlobalAdresar + @"Accounts\" + Ucet + @"\");

            while (true)
            {
                List<FileInfo> Soubory = new List<FileInfo>();

                foreach (FileInfo x in Adresar.GetFiles("*.mdb"))
                    Soubory.Add(x);

                Soubory.Sort(delegate(FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });

                if (Soubory.Count > Options_Backup.Value + 1)
                    FileDelete(Soubory[1].FullName);
                else
                    break;
            }
        }

        //Aplikování hacku pro w8
        private void Options_w8Hack_Click(object sender, EventArgs e)
        {
            if (File.Exists(GlobalAdresar + "w8-Hack.reg"))
            {
                MessageBox.Show(Language.MessageBox_W8Hack);

                Process prc = new Process();
                prc.StartInfo.FileName = GlobalAdresar + "w8-Hack.reg";
                prc.Start();
            }
        }
        #endregion

        #region Kontrola DB
        //Zkontrolování souborů dle AniDB
        private void InitializeComponentFilesMylist()
        {
            //Načtení předešlých úloh
            DataTable dataTable = DatabaseSelect("SELECT * FROM task");
            foreach (DataRow row in dataTable.Rows)
            {
                Application.DoEvents();
                ComunicationNewTaskKO(row["task_task"].ToString());
            }

            DatabaseAdd("UPDATE files SET files_date=NOW() WHERE ((Len([files].[files_date] & '')=0))");

            StatusBar_Mn02.Text = LogTasks.Items.Count.ToString();
        }

        //Kontrola neznámých souborů
        private void Options_CH03BT_Click(object sender, EventArgs e)
        {
            //Načtení Unknown files
            DataTable dataTable = DatabaseSelect("SELECT * FROM files WHERE id_files=0");
            foreach (DataRow row in dataTable.Rows)
            {
                Application.DoEvents();
                ComunicationNewTask("FILE size=" + row["files_size"] + "&ed2k=" + row["files_ed2k"] + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }

            //Načtení Unknown files
            dataTable = DatabaseSelect("SELECT * FROM files WHERE IsNull([files]![files_ed2k])=-1");
            foreach (DataRow row in dataTable.Rows)
            {
                Application.DoEvents();
                ComunicationNewTask("FILE fid=" + row["id_files"] + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }

            LogAddError("CHECK > U N K N O W N   F I L E S   W E R E   C H E C K E D");
        }

        //Kontrola episod k anime
        private void Options_CH04BT_Click(object sender, EventArgs e)
        {
            //Načtení nezkontrolovaných anime
            DataTable dataTable = DatabaseSelect("SELECT * FROM anime");
            foreach (DataRow row in dataTable.Rows)
            {
                DataTable dataTable2 = DatabaseSelect("SELECT * FROM episodes WHERE id_anime=" + row["id_anime"]);

                List<string> Epizody = new List<string>();

                foreach (DataRow row2 in dataTable2.Rows)
                {
                    Application.DoEvents();
                    Epizody.Add(row2["episodes_epn"].ToString());
                }

                for (int i = 1; i <= Convert.ToInt32(row["anime_epn"].ToString()); i++)
                {
                    Application.DoEvents();
                    if (!Epizody.Contains(i.ToString()))
                        ComunicationNewTask("EPISODE aid=" + row["id_anime"] + "&epno=" + i.ToString());
                }
            }

            LogAddError("CHECK > E P I S O D E S   W E R E   C H E C K E D");
        }

        //Kontrola souborů k episodám
        private void Options_CH05BT_Click(object sender, EventArgs e)
        {
            //Načtení nezkontrolovaných episod
            DataTable dataTable = DatabaseSelect("SELECT files.id_files, episodes.id_anime, episodes.episodes_epn FROM episodes LEFT JOIN files ON files.id_episodes=episodes.id_episodes WHERE (((CStr([files]![id_files] & '0'))=0))");
            foreach (DataRow row in dataTable.Rows)
            {
                Application.DoEvents();
                if (row["id_files"].ToString() == "")
                    ComunicationNewTask("MYLIST aid=" + row["id_anime"] + "&epno=" + row["episodes_epn"]);
            }

            LogAddError("CHECK > E P I S O D E S   W E R E   C H E C K E D");
        }

        //Kontrola zdvojení
        private void Options_CH06BT_Click(object sender, EventArgs e)
        {
            DataTable dataTable = DatabaseSelect("SELECT files.id_files, Count(files.id_files) AS CountOfid_files FROM files GROUP BY files.id_files HAVING (((Count(files.id_files))>1));");

            foreach (DataRow row in dataTable.Rows)
            {
                Application.DoEvents();
                DataTable IDFile = DatabaseSelect("SELECT * FROM files WHERE id_files=" + row["id_files"]);

                if (IDFile.Rows[0]["files_localfile"].ToString().Length == 0)
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[0]["id_files_local"]);
                else if (IDFile.Rows[1]["files_localfile"].ToString().Length == 0)
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[1]["id_files_local"]);
                else if (IDFile.Rows[0]["files_ed2k"].ToString().Length == 0)
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[0]["id_files_local"]);
                else if (IDFile.Rows[1]["files_ed2k"].ToString().Length == 0)
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[1]["id_files_local"]);
                else if (IDFile.Rows[0]["files_storage"].ToString().Length == 0)
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[0]["id_files_local"]);
                else if (IDFile.Rows[1]["files_storage"].ToString().Length == 0)
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[1]["id_files_local"]);
                else if (IDFile.Rows[0]["files_other"].ToString().Length == 0)
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[0]["id_files_local"]);
                else if (IDFile.Rows[1]["files_other"].ToString().Length == 0)
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[1]["id_files_local"]);
                else
                    DatabaseSelect("DELETE FROM files WHERE id_files_local=" + IDFile.Rows[1]["id_files_local"]);

                ComunicationNewTask("FILE fid=" + IDFile.Rows[0]["id_files"] + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }

            LogAddError("CHECK > D O U B L E   F I L E S   W E R E   C H E C K E D");
        }

        //Komprimace DB
        private void Options_CH07BT_Click(object sender, EventArgs e)
        {
            DatabaseCompact(GlobalAdresarAccount.Substring(0, GlobalAdresarAccount.Length - 3).Replace(" ", "?") + "mdb");
        }

        //Vytvořit zálohu
        private void Options_CH08BT_Click(object sender, EventArgs e)
        {
            FileInfo Soubor = new FileInfo(GlobalAdresarAccount);
            string Ucet = Soubor.Name.Replace(Soubor.Extension, "");

            string datum = DateTime.Now.Year.ToString() + "-" + String.Format("{0:00}", DateTime.Now.Month) + "-" + String.Format("{0:00}", DateTime.Now.Day);

            FileDelete(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + "-" + datum + ".mdb");

            if (!File.Exists(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + "-" + datum + ".mdb"))
                File.Copy(GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + ".mdb", GlobalAdresar + @"Accounts\" + Ucet + @"\" + Ucet + "-" + datum + ".mdb");

            LogAddError("BACKUP > B A C K U P   W A S   C R E A T E D");
        }

        //Obnovit ze zálohy
        private void Options_CH09BT_Click(object sender, EventArgs e)
        {
            AniDBDatabase.Close();

            Backups bck = new Backups(GlobalAdresarAccount, GlobalAdresar);

            if (bck.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LogAddError("BACKUP < R E S T O R E D   F R O M   B A C K U P");

            AniDBDatabase.Open();
        }

        //Updatovat databázi
        private void Options_CH10BT_Click(object sender, EventArgs e)
        {
            StreamWriter Zapis = new StreamWriter(GlobalAdresar + @"Update.sql");

            if (File.Exists(GlobalAdresar + @"Accounts\Update-Old.sql"))
            {
                StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\Update-Old.sql");
                Zapis.Write(Cti.ReadToEnd());
                Cti.Close();
                Cti.Dispose();
            }

            if (File.Exists(GlobalAdresar + @"Accounts\Update.sql"))
            {
                StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\Update.sql");
                Zapis.Write(Cti.ReadToEnd());
                Cti.Close();
                Cti.Dispose();
            }

            Zapis.Close();
            Zapis.Dispose();

            MessageBox.Show(Language.MessageBox_Restart);

            Application.Restart();
        }

        //Smazat databázi
        private void Options_CH11BT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.MessageBox_ClearDatabase + " 1/3", "Warring", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show(Language.MessageBox_ClearDatabase + " 2/3", "Warring", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (MessageBox.Show(Language.MessageBox_ClearDatabase + " 3/3", "Warring", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (isConnected)
                        {
                            isConnected = false;
                            Options_StartComunication.Text = Language.Options_StartComunicationOff;
                            ComunicationW.CancelAsync();
                        }

                        if (Hash_W.IsBusy)
                            Hash_W.CancelAsync();

                        Thread.Sleep(5000);

                        DatabaseAdd("DELETE FROM anime_relations");
                        DatabaseAdd("DELETE FROM genres_relations");
                        DatabaseAdd("DELETE FROM anime");
                        DatabaseAdd("DELETE FROM files");
                        DatabaseAdd("DELETE FROM episodes");
                        DatabaseAdd("DELETE FROM groups");
                        DatabaseAdd("DELETE FROM hash_files");
                        DatabaseAdd("DELETE FROM manga");
                        DatabaseAdd("DELETE FROM manga_anime");
                        DatabaseAdd("DELETE FROM manga_relations");
                        DatabaseAdd("DELETE FROM manga_genres");
                        DatabaseAdd("DELETE FROM manga_chapters");
                        DatabaseAdd("DELETE FROM tags");
                        DatabaseAdd("DELETE FROM task");
                        DatabaseAdd("DELETE FROM watcher");
                        DatabaseAdd("DELETE FROM genres");
                        DatabaseAdd("DELETE FROM mylist_storages");
                        DatabaseAdd("DELETE FROM mylist_sources");
                        DatabaseAdd("DELETE FROM tags_relation");
                        DatabaseAdd("DELETE FROM task");

                        Hash_Nazvy_Souboru.Items.Clear();
                        Log.Text = "";
                        LogSQL.Text = "";
                        LogError.Text = "";
                        LogTasks.Items.Clear();
                    }
                }
            }
        }

        //Kontrola nových chapterů u mangy
        private void Options_CH12BT_Click(object sender, EventArgs e)
        {
            DataTable DT;

            DT = DatabaseSelect("SELECT Max(id_manga_chatpers) FROM manga_chapters");

            int ID = 1;

            try
            {
                ID = Convert.ToInt32(DT.Rows[0][0]) + 1;
            }
            catch
            {
            }

            DT = DatabaseSelect("SELECT id_manga, manga_chatpers_file FROM manga_chapters");

            List<string> CHid = new List<string>();
            List<string> CHfile = new List<string>();

            List<string> CHch = new List<string>();

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                CHid.Add(DT.Rows[i][0].ToString());
                CHfile.Add(DT.Rows[i][1].ToString());
            }

            for (int i = 0; i < CHfile.Count; i++)
            {
                FileInfo soubor = new FileInfo(CHfile[i]);

                if (Directory.Exists(soubor.Directory.FullName))
                {
                    if (!CHch.Contains(soubor.Directory.FullName))
                    {
                        foreach (FileInfo subsoubor in soubor.Directory.GetFiles())
                        {
                            if (!CHfile.Contains(subsoubor.FullName))
                            {
                                DatabaseAdd("INSERT INTO manga_chapters VALUES (" + ID + ", " + CHid[i] + ", " + Manga_Chapters(subsoubor.Name) + ", " + Manga_Volumes(subsoubor.FullName) + ", " + subsoubor.Length + ", 0, " + Manga_List(subsoubor) + ", 'english', '" + subsoubor.FullName.Replace("'", "''") + "', '" + subsoubor.Name.Replace("'", "''").Replace("_", " ").Replace(subsoubor.Extension, "") + "')");
                                ID++;

                                CHfile.Add(subsoubor.FullName);
                            }
                        }

                        CHch.Add(soubor.Directory.FullName);

                        Application.DoEvents();
                    }
                }
            }
        }
        #endregion

        #region Databáze
        //Komprimace databáze
        public void DatabaseCompact(string mdbFileName)
        {
            AniDBDatabase.Close();
            try
            {
                string cmd = string.Format("COMPACT_DB=\"{0}\" \"{0}\" General\0", mdbFileName);
                SQLConfigDataSource((IntPtr)0, ODBC_ADD_DSN, "Microsoft Access Driver (*.mdb)", cmd);

                LogAddError("DB > D A T A B A S E   W A S   C O M P R I M E D");
            }
            catch
            {
                LogAdd(Language.MessageBox_DBC);
            }
            AniDBDatabase.Open();
        }

        //Formát data
        private string DatumFormat(DateTime datum)
        {
            return datum.Year + "-" + String.Format("{0:00}", datum.Month) + "-" + String.Format("{0:00}", datum.Day) + " " + String.Format("{0:00}", datum.Hour) + ":" + String.Format("{0:00}", datum.Minute) + ":" + String.Format("{0:00}", datum.Second);
        }

        //Přidání/editace/mazání z/do databáze - VOID
        private void DatabaseAdd(string SQLString)
        {
            LogAddSQL("MySQL > " + SQLString);

            OleDbCommand SQLCommand = new OleDbCommand();
            SQLCommand.CommandText = SQLString;
            SQLCommand.Connection = this.AniDBDatabase;

            try
            {
                SQLCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                LogAddError("MySQL ERROR > " + SQLString + "\r\n" + e.ToString());
            }

            SQLCommand.Dispose();
            AniDBDatabase.ResetState();
        }

        //Výběr z databáze
        private DataTable DatabaseSelect(string SQLString)
        {
            if (AniDBDatabase != null)
            {
                LogAddSQL("MySQL < " + SQLString);

                OleDbCommand SQLQuery = new OleDbCommand();
                SQLQuery.CommandText = SQLString;
                SQLQuery.Connection = AniDBDatabase;
                SQLQuery.CommandTimeout = 30;

                DataTable Data = new DataTable();

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(SQLQuery);

                try
                {
                    dataAdapter.Fill(Data);
                }
                catch (Exception e)
                {
                    LogAddError("MySQL ERROR > " + SQLString + "\r\n" + e.ToString());
                }

                SQLQuery.Dispose();
                AniDBDatabase.ResetState();
                return Data;
            }

            return new DataTable();
        }

        //Přidání/editace/mazání z/do databáze - VOID
        private void DatabaseAddNoLog(string SQLString)
        {
            AniDBDatabase.ResetState();

            OleDbCommand SQLCommand = new OleDbCommand();
            SQLCommand.CommandText = SQLString;
            SQLCommand.Connection = AniDBDatabase;

            try
            {
                SQLCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                LogAddError("MySQL ERROR > " + SQLString + "\r\n" + e.ToString());
            }

            SQLCommand.Dispose();

            this.AniDBDatabase.ResetState();
        }

        //Výběr z databáze
        private DataTable DatabaseSelectNoLog(string SQLString)
        {
            if (AniDBDatabase != null)
            {
                OleDbCommand SQLQuery = new OleDbCommand();
                SQLQuery.CommandText = SQLString;
                SQLQuery.Connection = AniDBDatabase;
                SQLQuery.CommandTimeout = 30;

                DataTable Data = new DataTable();

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(SQLQuery);

                try
                {
                    dataAdapter.Fill(Data);
                }
                catch (Exception e)
                {
                    LogAddError("MySQL ERROR > " + SQLString + "\r\n" + e.ToString());
                }

                SQLQuery.Dispose();
                return Data;
            }

            return new DataTable();
        }

        //Výběr Anime z databáze
        private void DatabaseSelectAnime()
        {
            if (AniDBDatabase != null && DataAnime.ReadOnly)
            {
                DataTable DAnime = DatabaseSelect("SELECT TOP " + DataAnime_Rows.Value + " * FROM (SELECT TOP " + DataAnime_Rows.Value + " * FROM (SELECT TOP " + (DataAnime_Page.Value * DataAnime_Rows.Value) + " * FROM anime ORDER BY CStr([anime]![anime_nazevjap]) ASC) ORDER BY CStr([anime]![anime_nazevjap]) DESC) ORDER by CStr([anime]![anime_nazevjap]) ASC");

                DataAnime.SuspendLayout();
                DataAnime.Rows.Clear();
                DataAnime.ReadOnly = false;

                for (int i = 0; i < DAnime.Rows.Count; i++)
                {
                    if (i >= DAnime.Rows.Count)
                        break;

                    DataRow row = DAnime.Rows[i];

                    DataAnime.Rows.Add(
                    new bool[3] { false, false, false },
                    Resources.i_Expand,
                    new Bitmap(1, 1),
                    row["id_anime"].ToString(),
                    row["anime_nazevjap"].ToString(),
                    row["anime_nazeveng"].ToString(),
                    row["anime_rok"].ToString(),
                    row["anime_typ"].ToString(),
                    row["anime_dub"].ToString(),
                    row["anime_sub"].ToString(),
                    row["anime_epn"].ToString(),
                    row["anime_size"].ToString(),
                    row["anime_length"].ToString(),
                    new Bitmap(1, 1),
                    row["anime_storage"].ToString(),
                    row["anime_source"].ToString()
                    );

                    DataAnime.Rows[DataAnime.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color01.BackColor;
                }

                DataAnime.ReadOnly = true;
                DataAnime.ResumeLayout();
            }
        }

        //Výběr anime do stromu
        private void DatabaseSelectAnimeTree(int Lang)
        {
            if (AniDBDatabase != null)
            {
                DataTable dataTable;

                AnimeTree.BeginUpdate();
                AnimeTree.Nodes.Clear();

                string Podminka = "";

                if (AnimeTree_CH01.CheckState == CheckState.Checked)
                    Podminka += "anime_18=1";
                else if (AnimeTree_CH01.CheckState == CheckState.Indeterminate)
                    Podminka += "id_anime>0";
                else
                    Podminka += "anime_18=0";

                if (AnimeTree_CH02.Checked)
                    Podminka += " AND anime_watched=1";

                switch (Lang)
                {
                    case 2:
                        dataTable = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_nazeveng, anime_nazevkaj FROM anime WHERE " + Podminka + " ORDER BY anime_nazeveng");
                        break;

                    case 3:
                        dataTable = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_nazeveng, anime_nazevkaj FROM anime WHERE " + Podminka + " ORDER BY anime_nazevkaj");
                        break;

                    default:
                        dataTable = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_nazeveng, anime_nazevkaj FROM anime WHERE " + Podminka + " ORDER BY anime_nazevjap");
                        break;
                }


                foreach (DataRow row in dataTable.Rows)
                {
                    switch (Lang)
                    {
                        case 2:
                            if (row["anime_nazeveng"].ToString().Length > 0)
                                AnimeTree.Nodes.Add(row["id_anime"].ToString(), row["anime_nazeveng"].ToString());
                            else
                                AnimeTree.Nodes.Add(row["id_anime"].ToString(), row["anime_nazevjap"].ToString());
                            break;
                        case 3:
                            if (row["anime_nazevkaj"].ToString().Length > 0)
                                AnimeTree.Nodes.Add(row["id_anime"].ToString(), row["anime_nazevkaj"].ToString());
                            else
                                AnimeTree.Nodes.Add(row["id_anime"].ToString(), row["anime_nazevjap"].ToString());
                            break;
                        default:
                            AnimeTree.Nodes.Add(row["id_anime"].ToString(), row["anime_nazevjap"].ToString());
                            break;
                    }
                }

                AnimeTree.Sort();
                AnimeTree.EndUpdate();

                if (!AmimeTreeWasSelected && AnimeTree.Nodes.Count > 0)
                {
                    AmimeTreeWasSelected = true;
                    AnimeTree.SelectedNode = AnimeTree.Nodes[0];

                    Anime_GR01.Visible = true;
                }
            }
        }

        //Výběr anime do stromu
        private void DatabaseSelectMangaTree(int Lang)
        {
            if (AniDBDatabase != null)
            {
                DataTable dataTable;

                Manga_Tree.BeginUpdate();
                Manga_Tree.Nodes.Clear();

                string Podminka = "";

                if (!MangaTree_CH01.Checked)
                    Podminka = "WHERE manga_18=0";

                switch (Lang)
                {
                    case 2:
                        dataTable = DatabaseSelect("SELECT id_manga, manga_nazevjap, manga_nazeveng, manga_nazevkaj FROM manga " + Podminka + " ORDER BY manga_nazeveng");
                        break;

                    case 3:
                        dataTable = DatabaseSelect("SELECT id_manga, manga_nazevjap, manga_nazeveng, manga_nazevkaj FROM manga " + Podminka + " ORDER BY manga_nazevkaj");
                        break;

                    default:
                        dataTable = DatabaseSelect("SELECT id_manga, manga_nazevjap, manga_nazeveng, manga_nazevkaj FROM manga " + Podminka + " ORDER BY manga_nazevjap");
                        break;
                }


                foreach (DataRow row in dataTable.Rows)
                {
                    switch (Lang)
                    {
                        case 2:
                            if (row["manga_nazeveng"].ToString().Length > 0)
                                Manga_Tree.Nodes.Add(row["id_manga"].ToString(), row["manga_nazeveng"].ToString());
                            else
                                Manga_Tree.Nodes.Add(row["id_manga"].ToString(), row["manga_nazevjap"].ToString());
                            break;
                        case 3:
                            if (row["manga_nazevkaj"].ToString().Length > 0)
                                Manga_Tree.Nodes.Add(row["id_manga"].ToString(), row["manga_nazevkaj"].ToString());
                            else
                                Manga_Tree.Nodes.Add(row["id_manga"].ToString(), row["manga_nazevjap"].ToString());
                            break;
                        default:
                            Manga_Tree.Nodes.Add(row["id_manga"].ToString(), row["manga_nazevjap"].ToString());
                            break;
                    }
                }

                Manga_Tree.Sort();
                Manga_Tree.EndUpdate();

                if (Manga_Tree.Nodes.Count > 0)
                {
                    if (Manga_Tree.Nodes.Count > 0)
                        Manga_Tree.SelectedNode = Manga_Tree.Nodes[0];

                    Manga_Gr01.Visible = true;
                }
                else
                    Manga_Gr01.Visible = false;
            }
        }

        //Výběr souborů ve vláknu
        private void DatabaseSelectFiles()
        {
            if (AniDBDatabase != null && DataFiles.ReadOnly)
            {
                DataFiles.ReadOnly = false;
                DataFiles.SuspendLayout();
                DataFiles.ColumnHeadersVisible = false;

                List<DataGridViewAutoSizeColumnMode> ASM = new List<DataGridViewAutoSizeColumnMode>();

                foreach (DataGridViewColumn c in DataFiles.Columns)
                {
                    ASM.Add(c.AutoSizeMode);
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }

                DataFiles.Rows.Clear();

                DataTable DFiles = null;
                DataRow row = null;
                string Podminka = "";

                if (DataFiles_Filtr01.Text.Length > 0)
                {
                    try
                    {
                        int x = Convert.ToInt32(DataFiles_Filtr01.Text);

                        Podminka += " AND (anime.id_anime=" + x.ToString() + ")";
                    }
                    catch
                    {
                        DataTable DAnime = DatabaseSelect("SELECT * FROM anime WHERE anime_nazevjap LIKE '%" + DataFiles_Filtr01.Text.Replace("'", "''") + "%' OR anime_nazevkaj LIKE '%" + DataFiles_Filtr01.Text.Replace("'", "''") + "%' OR anime_nazeveng LIKE '%" + DataFiles_Filtr01.Text.Replace("'", "''") + "%'");

                        if (DAnime.Rows.Count > 0)
                        {
                            Podminka += " AND (";

                            foreach (DataRow Row in DAnime.Rows)
                                Podminka += "anime.id_anime=" + Row["id_anime"].ToString() + " OR ";

                            if (Podminka.Length > 4)
                                Podminka = Podminka.Remove(Podminka.Length - 4, 4);

                            Podminka += ")";
                        }
                        else
                            Podminka += " AND (anime.id_anime=0)";
                    }
                }

                if (DataFiles_Filtr02.Text.Length > 0)
                    Podminka += " AND files_localfile LIKE '%" + DataFiles_Filtr02.Text.Replace("'", "''") + "%'";

                if (DataFiles_Filtr03.Text.Length > 0)
                    Podminka += " AND files_storage LIKE '%" + DataFiles_Filtr03.Text.Replace("'", "''") + "%'";

                if (DataFiles_Filtr04.Text.Length > 0)
                    Podminka += " AND files_source LIKE '%" + DataFiles_Filtr04.Text.Replace("'", "''") + "%'";

                if (!DataFilesTree.Visible && DatabaseSelectFilesCascade.Length == 0)
                {
                    DateTime Datum = new DateTime(1, 1, 1);

                    if (DataFiles_RB01.Checked)
                        Datum = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    else if (DataFiles_RB02.Checked)
                    {
                        Datum = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        Datum = Datum.AddHours(-24);
                    }
                    else if (DataFiles_RB03.Checked)
                    {
                        Datum = new DateTime(Convert.ToInt32(DataFiles_Year.Value.ToString()), Convert.ToInt32(DataFiles_Month.Value.ToString()), Convert.ToInt32(DataFiles_Day.Value.ToString()));
                    }

                    DFiles = DatabaseSelect("SELECT * FROM files WHERE files.id_anime=0 AND files.files_date>=#" + DatumFormat(Datum) + "#");

                    for (int i = ((int)DataFiles_Page.Value - 1) * (int)DataFiles_Rows.Value; i < (((int)DataFiles_Page.Value - 1) * (int)DataFiles_Rows.Value) + (int)DataFiles_Rows.Value; i++)
                    {
                        if (i >= DFiles.Rows.Count)
                            break;

                        row = DFiles.Rows[i];

                        DataFiles.Rows.Add(
                        new string[4] { row["id_files_local"].ToString(), row["id_files"].ToString(), row["files_lid"].ToString(), null },
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        new Bitmap(1, 1),
                        new Bitmap(1, 1),
                        new Bitmap(1, 1),
                        new Bitmap(1, 1),
                        new Bitmap(1, 1),
                        row["files_localfile"].ToString(),
                        FilesSize(row["files_size"].ToString())
                        );

                        if (row["files_watched"].ToString() == "1")
                            DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color02.BackColor;
                        else if (row["id_files"].ToString() == "-1")
                            DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color03.BackColor;
                        else if (row["id_files"].ToString() == "0")
                            DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color04.BackColor;
                    }
                }

                if (!DataFiles_RB05.Checked)
                {
                    DateTime Datum = new DateTime(1, 1, 1);

                    if (DataFiles_RB01.Checked)
                        Datum = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    else if (DataFiles_RB02.Checked)
                    {
                        Datum = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        Datum = Datum.AddHours(-24);
                    }
                    else if (DataFiles_RB03.Checked)
                    {
                        Datum = new DateTime(Convert.ToInt32(DataFiles_Year.Value.ToString()), Convert.ToInt32(DataFiles_Month.Value.ToString()), Convert.ToInt32(DataFiles_Day.Value.ToString()));
                    }

                    if (!DataFilesTree_CH03.Checked || DataFilesTree.Visible)
                    {
                        DFiles = DatabaseSelect("SELECT TOP " + DataFiles_Rows.Value + " * FROM [SELECT TOP " + DataFiles_Rows.Value + " * FROM (SELECT TOP " + (DataFiles_Page.Value * DataFiles_Rows.Value) + " * FROM (groups RIGHT JOIN (episodes RIGHT JOIN files ON episodes.id_episodes = files.id_episodes) ON  groups.id_groups = files.id_groups) INNER JOIN anime ON files.id_anime = anime.id_anime WHERE files.files_date>=#" + DatumFormat(Datum) + "#" + DatabaseSelectFilesCascade + Podminka + " ORDER BY CStr(anime.anime_nazevjap & '') ASC, episodes.episodes_epn ASC) ORDER BY CStr(anime.anime_nazevjap & '') DESC, episodes.episodes_epn DESC]. AS [ALIAS] ORDER BY CStr([anime].[anime_nazevjap] & ''), CStr([ALIAS].[episodes_spec] & ''), [ALIAS].episodes_epn");
                    }
                    else
                    {
                        Podminka = Podminka.Replace("anime.", "files.");
                        DFiles = DatabaseSelect("SELECT TOP " + DataFiles_Rows.Value + " * FROM [SELECT TOP " + (DataFiles_Page.Value * DataFiles_Rows.Value) + " * FROM files WHERE files.files_date>=#" + DatumFormat(Datum) + "#" + DatabaseSelectFilesCascade + Podminka + " ORDER BY files_localfile ASC, id_files ASC]. AS [ALIAS] ORDER BY CStr([ALIAS].files_localfile & '') DESC, [ALIAS].id_files DESC");
                    }

                    if (DataFilesTree.Visible)
                    {
                        DataFilesTree.BeginUpdate();

                        if (DataFilesTree_CH01.Checked)
                            DataFilesTree.Nodes.Clear();
                    }

                    for (int i = 0; i < DFiles.Rows.Count; i++)
                    {
                        DataFiles_LB06.Text = Language.DataFiles_LB06 + ": " + DFiles.Rows.Count + " / 1";
                        row = DFiles.Rows[i];

                        if (!DataFilesTree.Visible)
                        {
                            if (!DataFilesTree_CH03.Checked)
                                DatabaseSelectFilesAddRow(row);
                            else
                                DatabaseSelectFilesAddRowOnlyFiles(row);
                        }
                        else
                        {
                            if (row["files_localfile"].ToString() != "")
                            {
                                string[] T = row["files_localfile"].ToString().Split('\\');

                                if (T.Length > 0)
                                {
                                    TreeNode Node;

                                    if (!DataFilesTree.Nodes.ContainsKey(T[0]))
                                        Node = DataFilesTree.Nodes.Add(T[0], T[0]);
                                    else
                                        Node = DataFilesTree.Nodes[T[0]];

                                    for (int j = 1; j < T.Length; j++)
                                    {
                                        try
                                        {
                                            if (j == T.Length - 1)
                                            {
                                                string FExt = null;

                                                if (row["files_localfile"].ToString().Length > 3)
                                                    FExt = row["files_localfile"].ToString().Substring(row["files_localfile"].ToString().Length - 4, 4).ToLower().Replace(".", "");

                                                Node = AddNode(Node, T[j], row["id_files_local"].ToString(), true);
                                                Node.Tag = "F*" + row["id_files"].ToString();
                                                Node.ImageIndex = FExtension(FExt) + 1;
                                                Node.SelectedImageIndex = Node.ImageIndex;

                                                if (row["files_watched"].ToString() == "1")
                                                    Node.BackColor = Options_Color02.BackColor;

                                                Node.Checked = true;
                                            }
                                            else if (j == T.Length - 2)
                                            {
                                                Node = AddNode(Node, T[j], row["anime.id_anime"].ToString(), true);
                                                Node.ImageIndex = 1;
                                                Node.SelectedImageIndex = 1;
                                            }
                                            else
                                            {
                                                Node = AddNode(Node, T[j], null, false);
                                                Node.ImageIndex = 1;
                                                Node.SelectedImageIndex = 1;
                                            }
                                        }
                                        catch
                                        {
                                            Node = AddNode(Node, T[j], null, false);
                                            Node.ImageIndex = 4;
                                            Node.SelectedImageIndex = 4;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (DataFilesTree.Visible)
                    {
                        DataFilesTree.TreeViewNodeSorter = new NodeSorter();

                        if (DataFilesTree_CH02.Checked)
                            DataFilesTree.ExpandAll();

                        if (DataFilesTree.Nodes.Count > 0)
                            DataFilesTree.Nodes[0].EnsureVisible();

                        DataFilesTree.EndUpdate();
                    }
                    else
                    {
                        if (DataFiles.SortedColumn != null)
                            DataFiles.Sort(DataFiles.SortedColumn, DataFiles.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
                    }
                }

                int k = 0;
                foreach (DataGridViewColumn c in DataFiles.Columns)
                {
                    c.AutoSizeMode = ASM[k];
                    k++;
                }

                DataFiles.ColumnHeadersVisible = true;
                DataFiles.ResumeLayout();
                DataFiles.ReadOnly = true;
            }
        }

        //Přidání souborů do DataFiles
        private void DatabaseSelectFilesAddRow(DataRow row)
        {
            string spec = "";
            string nula = "";

            string DST = FilesState(row["files_state"].ToString());
            string Dvid = row["files_video"].ToString();
            string Dver = "";

            if (DST.Contains("v5"))
                Dver = "     v5";
            else if (DST.Contains("v4"))
                Dver = "     v4";
            else if (DST.Contains("v3"))
                Dver = "     v3";
            else if (DST.Contains("v2"))
                Dver = "     v2";

            if (row["episodes_spec"].ToString() != "0")
                spec = row["episodes_spec"].ToString();

            if (row["episodes_spec"].ToString() == "0")
                for (int i = row["episodes_epn"].ToString().Length; i < row["anime_epn"].ToString().Length; i++)
                    nula += "0";

            Image Dinv = new Bitmap(1, 1);
            Image Dcen = new Bitmap(1, 1);
            Image Seen = new Bitmap(1, 1);
            Image Stastus = new Bitmap(1, 1);
            Image Rip = new Bitmap(1, 1);

            if (DST.Contains("CRC not match"))
                Dinv = Resources.anidb_crc_no;
            else
                Dinv = Resources.anidb_crc_yes;

            if (DST.Contains("cen"))
                Dcen = Resources.anidb_censored;
            else if (DST.Contains("UNC"))
                Dcen = Resources.anidb_uncensored;

            switch (row["files_status"].ToString())
            {
                case "0":
                    Stastus = Resources.anidb_state_unknown;
                    break;

                case "1":
                    Stastus = Resources.anidb_state_onhdd;
                    break;

                case "2":
                    Stastus = Resources.anidb_state_oncd;
                    break;

                case "3":
                    Stastus = Resources.anidb_state_deleted;
                    break;
            }

            switch (row["files_typ"].ToString())
            {
                case "Blu-ray":
                    Rip = Resources.anidb_atype_ova;
                    break;

                case "HDTV":
                    Rip = Resources.anidb_atype_tv_special;
                    break;

                case "DVD":
                    Rip = Resources.Anidb_filestate_ondvd;
                    break;

                case "TV":
                case "DTV":
                    Rip = Resources.anidb_atype_tv_series;
                    break;

                case "www":
                    Rip = Resources.anidb_atype_web;
                    break;

                case "unknown":
                    Rip = Resources.anidb_atype_other;
                    break;

                case "VHS":
                    Rip = Resources.Anidb_filestate_onvhs;
                    break;

                default:
                    Rip = Resources.anidb_atype_other;
                    break;
            }

            if (row["files_watched"].ToString() == "1")
                Seen = Resources.anidb_seen_yes;
            else
                Seen = Resources.anidb_seen_no;

            if (row["files_depth"].ToString().Contains("10"))
                Dvid = "Hi10p";

            DataFiles.Rows.Add(
            new string[4] { row["id_files_local"].ToString(), row["id_files"].ToString(), row["files_lid"].ToString(), row["anime.id_anime"].ToString() },
            row["anime.id_anime"].ToString(),
            row["files.id_episodes"].ToString(),
            row["id_files"].ToString(),
            row["files_lid"].ToString(),
            row["anime_nazevjap"],
            spec + nula + row["episodes_epn"].ToString() + "  -  " + row["episodes_nazeveng"].ToString(),
            row["groups_namezk"].ToString(),
            row["files_resultion"].ToString() + "   " + Dvid + "   " + row["files_audio"].ToString() + Dver,
            row["files_storage"].ToString(),
            row["files_source"].ToString(),
            Seen,
            Stastus,
            Rip,
            Dinv,
            Dcen,
            row["files_localfile"].ToString(),
            FilesSize(row["files_size"].ToString())
            );

            if (row["files_watched"].ToString() == "1")
                DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color02.BackColor;
            else if (row["id_files"].ToString() == "-1")
                DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color03.BackColor;
            else if (row["id_files"].ToString() == "0")
                DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color04.BackColor;
        }

        //Přidání souborů do DataFiles
        private void DatabaseSelectFilesAddRowOnlyFiles(DataRow row)
        {
            string Dcen = FilesState(row["files_state"].ToString());
            string Dver = "";
            string Dinv = "";
            string Dvid = row["files_video"].ToString();

            if (Dcen.Contains("v5"))
                Dver = "     v5";
            else if (Dcen.Contains("v4"))
                Dver = "     v4";
            else if (Dcen.Contains("v3"))
                Dver = "     v3";
            else if (Dcen.Contains("v2"))
                Dver = "     v2";

            if (Dcen.Contains("CRC not match"))
                Dinv = "     CRC not match";

            if (Dcen.Contains("cen"))
                Dcen = "     {CEN}";
            else if (Dcen.Contains("UNC"))
                Dcen = "     {UNC}";
            else
                Dcen = "";

            if (row["files_depth"].ToString().Contains("10"))
                Dvid = "Hi10p";

            DataFiles.Rows.Add(
            new string[4] { row["id_files_local"].ToString(), row["id_files"].ToString(), row["files_lid"].ToString(), null },
            row["id_anime"].ToString(),
            row["id_episodes"].ToString(),
            row["id_files"].ToString(),
            row["files_lid"].ToString(),
            "",
            "",
            "",
            row["files_resultion"].ToString() + "   " + Dvid + "   " + row["files_audio"].ToString() + Dcen + Dver + Dinv,
            row["files_storage"].ToString(),
            row["files_source"].ToString(),
            new Bitmap(1, 1),
            new Bitmap(1, 1),
            new Bitmap(1, 1),
            new Bitmap(1, 1),
            new Bitmap(1, 1),
            row["files_localfile"].ToString(),
            FilesSize(row["files_size"].ToString())
            );

            if (row["files_watched"].ToString() == "1")
                DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color02.BackColor;
            else if (row["id_files"].ToString() == "-1")
                DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color03.BackColor;
            else if (row["id_files"].ToString() == "0")
                DataFiles.Rows[DataFiles.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color04.BackColor;
        }

        //Obrázek přípona
        private int FExtension(string Ext)
        {
            switch (Ext)
            {
                case "asf":
                    return 3;

                case "asx":
                    return 4;

                case "avi":
                    return 5;

                case "dat":
                    return 6;

                case "m1v":
                    return 7;

                case "m2v":
                    return 8;

                case "mid":
                    return 9;

                case "mms":
                    return 10;

                case "mov":
                    return 11;

                case "mp3":
                    return 12;

                case "mpe":
                    return 13;

                case "mpeg":
                    return 14;

                case "mpg":
                    return 15;

                case "qt":
                    return 16;

                case "vob":
                    return 17;

                case "wav":
                    return 18;

                case "wma":
                    return 19;

                case "wmv":
                    return 20;

                case "smi":
                    return 21;

                case "pls":
                    return 22;

                case "m3u":
                    return 23;

                case "ra":
                    return 24;

                case "rm":
                    return 25;

                case "rmj":
                    return 26;

                case "rms":
                    return 27;

                case "ram":
                    return 28;

                case "rmm":
                    return 29;

                case "rmvb":
                    return 30;

                case "ogg":
                    return 31;

                case "ogm":
                    return 32;

                case "mkv":
                    return 33;

                case "RT":
                    return 34;

                case "sub":
                    return 35;

                case "idx":
                    return 36;

                case "ass":
                    return 37;

                case "ssa":
                    return 38;

                case "psb":
                    return 39;

                case "srt":
                    return 40;

                case "s2k":
                    return 41;

                case "ifo":
                    return 43;

                case "flac":
                    return 44;

                case "aac":
                    return 45;

                case "mp4":
                    return 46;

                case "ape":
                    return 47;

                case "mpc":
                    return 48;

                case "ac3":
                    return 49;

                case "3g2":
                    return 50;

                case "3gp":
                    return 51;

                case "aifc":
                    return 52;

                case "aiff":
                    return 53;

                case "au":
                    return 54;

                case "bik":
                    return 55;

                case "bin":
                    return 56;

                case "cda":
                    return 57;

                case "d2v":
                    return 58;

                case "divx":
                    return 59;

                case "drc":
                    return 60;

                case "dts":
                    return 61;

                case "flc":
                    return 62;

                case "fli":
                    return 63;

                case "flic":
                    return 64;

                case "img":
                    return 66;

                case "iso":
                    return 66;

                case "it":
                    return 67;

                case "ivf":
                    return 68;

                case "m1a":
                    return 69;

                case "m2a":
                    return 70;

                case "m4a":
                    return 71;

                case "m4v":
                    return 72;

                case "midi":
                    return 73;

                case "mka":
                    return 74;

                case "mks":
                    return 75;

                case "mo3":
                    return 78;

                case "mod":
                    return 79;

                case "mp2":
                    return 80;

                case "mp2v":
                    return 81;

                case "mpa":
                    return 82;

                case "mpv2":
                    return 84;

                case "mqv":
                    return 85;

                case "mtm":
                    return 86;

                case "nrg":
                    return 87;

                case "ofr":
                    return 88;

                case "part":
                    return 89;

                case "pss":
                    return 90;

                case "pva":
                    return 91;

                case "rmi":
                    return 92;

                case "roq":
                    return 93;

                case "rpm":
                    return 94;

                case "rv":
                    return 95;

                case "s3m":
                    return 96;

                case "smk":
                    return 97;

                case "snd":
                    return 98;

                case "swf":
                    return 99;

                case "tp":
                    return 100;

                case "tpr":
                    return 101;

                case "ts":
                    return 102;

                case "umx":
                    return 103;

                case "vp6":
                    return 104;

                case "wax":
                    return 105;

                case "wm":
                    return 106;

                case "wmp":
                    return 107;

                case "wmx":
                    return 108;

                case "wpl":
                    return 109;

                case "wvx":
                    return 110;

                case "xm":
                    return 111;

                case "xvid":
                    return 112;

                case "trp":
                    return 113;

                case "flv":
                    return 114;

                case "arm":
                    return 115;

                case "avc":
                    return 116;

                case "dvr":
                    return 117;

                case "gvi":
                    return 118;

                case "m2ts":
                    return 119;

                case "nsv":
                    return 120;

                case "pmp":
                    return 121;

                case "shn":
                    return 122;

                case "vp7":
                    return 123;

                case "wv":
                    return 124;

                case "k3g":
                    return 125;

                case "m2t":
                    return 127;

                case "mts":
                    return 128;

                case "skm":
                    return 129;

                case "264":
                    return 130;

                case "eac3":
                    return 131;

                case "ec3":
                    return 132;

                case "evo":
                    return 133;

                case "h264":
                    return 134;

                case "lpcm":
                    return 135;

                case "mlp":
                    return 136;

                case "mt9":
                    return 137;

                case "pcm":
                    return 138;

                case "pfm":
                    return 140;

                case "thd":
                    return 141;

                case "vc1":
                    return 142;

                default:
                    return 2;
            }
        }

        //Přidání uzlu
        private TreeNode AddNode(TreeNode node, string key, string key2, bool key3)
        {
            if (key3)
            {
                if (node.Nodes.ContainsKey(key2))
                {
                    return node.Nodes[key2];
                }
                else
                {
                    return node.Nodes.Add(key2, key);
                }
            }
            else
            {
                if (node.Nodes.ContainsKey(key))
                {
                    return node.Nodes[key];
                }
                else
                {
                    return node.Nodes.Add(key, key);
                }
            }
        }

        // Create a node sorter that implements the IComparer interface.
        public class NodeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                return string.Compare(tx.Text, ty.Text);
            }
        }

        //Výběr žánrů z databáze
        private void DatabaseSelectGenres()
        {
            DataTable DGenres = DatabaseSelect("SELECT TOP " + DataGenres_Rows.Value + " * FROM (SELECT TOP " + DataGenres_Rows.Value + " * FROM (SELECT TOP " + (DataGenres_Rows.Value * DataGenres_Page.Value) + " * FROM genres ORDER BY CStr(genres_genre) ASC) ORDER BY CStr(genres_genre) DESC) ORDER BY CStr(genres_genre) ASC");

            DataGenres.SuspendLayout();
            DataGenres.Rows.Clear();

            for (int i = 0; i < DGenres.Rows.Count; i++)
            {
                DataRow row = DGenres.Rows[i];

                DataGenres.Rows.Add(
                new bool[2] { false, false },
                Resources.i_Expand,
                row["id_grenres"].ToString(),
                row["genres_genre"].ToString(),
                "", "", ""
                );

                DataGenres.Rows[DataGenres.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color01.BackColor;
            }

            DataGenres.ResumeLayout();
        }

        //Výběr skupin z databáze
        private void DatabaseSelectGroups()
        {
            DataTable DGroups = DatabaseSelect("SELECT TOP " + DataGroups_Rows.Value + " * FROM (SELECT TOP " + DataGroups_Rows.Value + " * FROM (SELECT TOP " + (DataGroups_Rows.Value * DataGroups_Page.Value) + " * FROM groups ORDER BY CStr(groups_name) ASC) ORDER BY CStr(groups_name) DESC) ORDER BY CStr(groups_name) ASC");

            DataGroups.SuspendLayout();
            DataGroups.Rows.Clear();

            for (int i = 0; i < DGroups.Rows.Count; i++)
            {
                DataRow row = DGroups.Rows[i];

                DataGroups.Rows.Add(
                new bool[2] { false, false },
                Resources.i_Expand,
                row["id_groups"].ToString(),
                row["groups_name"].ToString(),
                row["groups_namezk"].ToString(),
                "", ""
                );

                DataGroups.Rows[DataGroups.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color01.BackColor;
            }

            DataGroups.ResumeLayout();
        }

        //Výběr tagů
        private void DatabaseSelectTags()
        {
            AnimeTags.BeginUpdate();
            AnimeSeen.BeginUpdate();
            AnimeRating.BeginUpdate();

            AnimeTags.Nodes.Clear();
            AnimeSeen.Nodes.Clear();
            AnimeRating.Nodes.Clear();

            DataTable DT;

            DT = DatabaseSelect("SELECT anime.id_anime, tags_name, anime_nazevjap FROM (anime INNER JOIN tags_relation ON tags_relation.id_anime=anime.id_anime) INNER JOIN tags ON tags.id_tags=tags_relation.id_tags ORDER BY tags_name, anime_nazevjap");

            string tag = "";
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                try
                {
                    if (tag != DT.Rows[i]["tags_name"].ToString())
                    {
                        tag = DT.Rows[i]["tags_name"].ToString();
                        AnimeTags.Nodes.Add("0", tag);
                        AnimeTags.Nodes[AnimeTags.Nodes.Count - 1].SelectedImageIndex = 1;
                    }

                    AnimeTags.Nodes[AnimeTags.Nodes.Count - 1].Nodes.Add(DT.Rows[i]["id_anime"].ToString(), DT.Rows[i]["anime_nazevjap"].ToString());
                    AnimeTags.Nodes[AnimeTags.Nodes.Count - 1].Nodes[AnimeTags.Nodes[AnimeTags.Nodes.Count - 1].Nodes.Count - 1].SelectedImageIndex = 1;
                }
                catch
                {
                }
            }

            DT = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_rating FROM anime ORDER BY anime_rating DESC, anime_nazevjap");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                try
                {
                    if (tag != DT.Rows[i]["anime_rating"].ToString())
                    {
                        tag = DT.Rows[i]["anime_rating"].ToString();
                        AnimeRating.Nodes.Add("0", Language.AnimeRating + " " + tag + "/10");
                        AnimeRating.Nodes[AnimeRating.Nodes.Count - 1].SelectedImageIndex = 1;
                    }

                    AnimeRating.Nodes[AnimeRating.Nodes.Count - 1].Nodes.Add(DT.Rows[i]["id_anime"].ToString(), DT.Rows[i]["anime_nazevjap"].ToString());
                    AnimeRating.Nodes[AnimeRating.Nodes.Count - 1].Nodes[AnimeRating.Nodes[AnimeRating.Nodes.Count - 1].Nodes.Count - 1].SelectedImageIndex = 1;
                }
                catch
                {
                }
            }

            DT = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_seen FROM anime WHERE anime_watched=1 ORDER BY anime_seen DESC, anime_nazevjap");
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                try
                {
                    DateTime Cas = DateTime.Parse(DT.Rows[i]["anime_seen"].ToString());

                    if (tag != Cas.Year.ToString())
                    {
                        tag = Cas.Year.ToString();
                        AnimeSeen.Nodes.Add("0", tag);
                        AnimeSeen.Nodes[AnimeSeen.Nodes.Count - 1].SelectedImageIndex = 1;
                    }

                    AnimeSeen.Nodes[AnimeSeen.Nodes.Count - 1].Nodes.Add(DT.Rows[i]["id_anime"].ToString(), DT.Rows[i]["anime_nazevjap"].ToString() + " (" + Cas.ToShortDateString() + ")");
                    AnimeSeen.Nodes[AnimeSeen.Nodes.Count - 1].Nodes[AnimeSeen.Nodes[AnimeSeen.Nodes.Count - 1].Nodes.Count - 1].SelectedImageIndex = 1;
                }
                catch
                {
                }
            }

            AnimeTags.EndUpdate();
            AnimeSeen.EndUpdate();
            AnimeRating.EndUpdate();
        }

        //Výběr episod dle anime
        private DataTable DatabaseSelectAnimeID(string AnimeID)
        {
            return DatabaseSelect("SELECT * FROM episodes WHERE id_anime=" + AnimeID + " ORDER BY episodes_spec DESC, episodes_epn DESC");
        }

        //Výběr souborů dle epizod
        private DataTable DatabaseSelectEpisodeID(string EpisodeID)
        {
            return DatabaseSelect("SELECT * FROM files INNER JOIN groups ON groups.id_groups=files.id_groups WHERE id_episodes=" + EpisodeID + " ORDER BY id_files DESC");
        }
        #endregion

        #region Main
        //Hlavní Panel
        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabSelect(false);
        }

        //Anime Panel
        private void MainTabData_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabSelect(false);
        }

        //Manga Panel
        private void MainTabManga_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabSelect(false);
        }

        //Ukončení spojení při zavření aplikace
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!LogonKill)
            {
                if (Options_CH08.Checked)
                    Options_SetingsSave_Click(null, null);

                if (isConnected)
                {
                    isConnected = false;
                    Options_StartComunication.Text = Language.Options_StartComunicationOff;
                    ComunicationW.CancelAsync();
                }

                if (Hash_W.IsBusy)
                    Hash_W.CancelAsync();

                if (AniDBDatabase != null)
                    this.AniDBDatabase.Close();

                FileDelete(GlobalAdresar + @"AniSub-MyList.log");
                FileDelete(GlobalAdresar + @"avdumpLog.txt");

                EncDec.Encrypt(GlobalAdresarAccount, GlobalAdresarAccount + ".enc", "4651511fac9cbbc80c8417779620b893");
                FileDelete(GlobalAdresarAccount);

                DatabaseCompact(GlobalAdresarAccount.Substring(0, GlobalAdresarAccount.Length - 3).Replace(" ", "?") + "mdb");

            }
        }

        //Změna polohy
        private void Main_Resize(object sender, EventArgs e)
        {

            if (MainTabData.SelectedIndex == 8)
            {
                Zgc_Graph.AxisChange();
                Zgc_Graph.Invalidate();
            }

            if (this.WindowState != FormWindowState.Minimized)
            {
                int x = MainTab.Width / 2 - 12;
                int y = MainTab.Height / 2 - 30;
                int z = ((MainTab.Height / 100) * 60) - 12;

                Rules_GR03.Width = MainTab.Width - 24;
                Rules_GR03.Height = MainTab.Height - z - 48;

                Rules_GR03.Location = new Point(6, z + 18);

                Manga_Gr02.Height = y - 5;
                Manga_Gr03.Height = y;

                Manga_Gr03.Location = new Point(Manga_Gr02.Location.X, Manga_Gr02.Height + 5);

                AnimeTags.Height = MainTabData_Mn08.Height - 20;
                AnimeRating.Height = MainTabData_Mn08.Height - 20;
                AnimeSeen.Height = MainTabData_Mn08.Height - 20;

                AnimeTags.Width = (MainTabData_Mn08.Width / 3) - 20;
                AnimeRating.Width = (MainTabData_Mn08.Width / 3) - 20;
                AnimeSeen.Width = (MainTabData_Mn08.Width / 3) - 20;

                AnimeTags.Location = new Point(10, 10);
                AnimeRating.Location = new Point(AnimeRating.Width + 30, 10);
                AnimeSeen.Location = new Point(AnimeRating.Width * 2 + 50, 10);

                x = (MainTab.Width - 4 * 10) / 3;

                Rules_GR01.Width = x;
                Rules_GR01.Height = z - 48;

                Rules_GR02.Width = x;
                Rules_GR02.Height = z - 48;

                Rules_GR04.Width = x;
                Rules_GR04.Height = z - 48;

                Rules_GR01.Location = new Point(10, 49);
                Rules_GR02.Location = new Point(20 + x, 49);
                Rules_GR04.Location = new Point(30 + x + x, 49);

                x = (Manga_Gr02.Width - 4 * 10) / 3;

                Manga_Genres.Width = x;
                Manga_Manga.Width = x;
                Manga_Anime.Width = x;

                Manga_Genres.Location = new Point(10, Manga_Genres.Location.Y);
                Manga_Manga.Location = new Point(Manga_Genres.Location.X + x + 10, Manga_Genres.Location.Y);
                Manga_Anime.Location = new Point(Manga_Manga.Location.X + x + 10, Manga_Manga.Location.Y);

                this.Refresh();
                this.Invalidate();
            }

            if (Options_CH16.Checked)
            {
                if (FormWindowState.Minimized == WindowState)
                {
                    this.Hide();
                    Notify.Visible = true;
                }
            }
        }

        //System tray
        private void Notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Notify.Visible = false;
            WindowState = FormWindowState.Maximized;
            this.Show();
            this.Focus();
        }

        //Akce Panel
        private void TabSelect(bool force)
        {
            if (MainTab.SelectedIndex == 2 || MainTab.SelectedIndex == 1)
            {
                Main_Resize(null, null);
            }
            else if (MainTab.SelectedIndex == 4)
            {
                if (MainTabData.SelectedIndex == 1 && ((DataFiles.Rows.Count == 0 && !DataFilesTree.Enabled) || force))
                {
                    DatabaseSelectFiles();
                }
                else if (MainTabData.SelectedIndex == 2 && (DataAnime.Rows.Count == 0 || force))
                {
                    DatabaseSelectAnime();
                }
                else if (MainTabData.SelectedIndex == 3 && (AnimeTree.Nodes.Count == 0 || force))
                {
                    string id = null;

                    try
                    {
                        id = AnimeTree.SelectedNode.Name;
                    }
                    catch
                    {
                    }

                    DatabaseSelectAnimeTree(1);

                    if (id != null)
                        AnimeTree_Find(id);
                }
                else if (MainTabData.SelectedIndex == 4 && (DataGenres.Rows.Count == 0 || force))
                {
                    DatabaseSelectGenres();
                }
                else if (MainTabData.SelectedIndex == 5 && (DataGroups.Rows.Count == 0 || force))
                {
                    DatabaseSelectGroups();
                }
                else if (MainTabData.SelectedIndex == 6 && (DataSearch_Genres.Items.Count == 0 || force))
                {
                    DataSearch_Genres.BeginUpdate();
                    DataSearch_Genres.Items.Clear();

                    DataTable dataTable = DatabaseSelect("SELECT * FROM genres");

                    foreach (DataRow row in dataTable.Rows)
                        DataSearch_Genres.Items.Add(row["genres_genre"], false);

                    DataSearch_Genres.EndUpdate();
                }
                else if (MainTabData.SelectedIndex == 7)
                {
                    Main_Resize(null, null);
                    DatabaseSelectTags();
                }
                else if (MainTabData.SelectedIndex == 8)
                {
                    Zgc_GraphB01_Click(null, null);
                }
            }
            else if (MainTab.SelectedIndex == 5)
            {
                if (MainTabManga.SelectedIndex == 0 && (Manga_Tree.Nodes.Count == 0 || force))
                {
                    string id = null;

                    try
                    {
                        id = Manga_Tree.SelectedNode.Name;
                    }
                    catch
                    {
                    }

                    DatabaseSelectMangaTree(1);

                    if (id != null)
                        MangaTree_Find(id);

                }
                else if (MainTabManga.SelectedIndex == 1)
                {
                    Main_Resize(null, null);

                    MangaUrlObr = "";
                    Manga_Tx00.Text = "0";
                    Manga_Tx01.Text = "";
                    Manga_Tx02.Text = "";
                    Manga_Tx03.Text = "";
                    Manga_Tx04.Text = "0";
                    Manga_Tx05.Text = "0";
                    Manga_Tx06.Text = "0";
                    Manga_Tx07.Text = "0";
                    Manga_Tx08.Text = "";
                    Manga_Tx17.Text = "";
                    Manga_Tx18.Text = "";
                    Manga_Tx23.Text = "0";
                    Manga_Tx24.Text = "0";

                    Manga_Update.Visible = false;
                    Manga_Insert.Visible = true;
                    Manga_Delete.Visible = false;

                    if (Manga_Anime.Items.Count == 0 || force)
                    {
                        Manga_Anime.BeginUpdate();
                        Manga_Anime.Items.Clear();

                        DataTable dataTable = DatabaseSelect("SELECT anime_nazevjap FROM anime");

                        foreach (DataRow row in dataTable.Rows)
                            Manga_Anime.Items.Add(row["anime_nazevjap"], false);

                        Manga_Anime.EndUpdate();
                    }

                    if (Manga_Manga.Items.Count == 0 || force)
                    {
                        Manga_Manga.BeginUpdate();
                        Manga_Manga.Items.Clear();

                        DataTable dataTable = DatabaseSelect("SELECT manga_nazevjap FROM manga");

                        foreach (DataRow row in dataTable.Rows)
                            Manga_Manga.Items.Add(row["manga_nazevjap"], false);

                        Manga_Manga.EndUpdate();
                    }

                    if (Manga_Genres.Items.Count == 0 || force)
                    {
                        Manga_Genres.BeginUpdate();
                        Manga_Genres.Items.Clear();

                        DataTable dataTable = DatabaseSelect("SELECT * FROM genres");

                        foreach (DataRow row in dataTable.Rows)
                            Manga_Genres.Items.Add(row["genres_genre"], false);

                        Manga_Genres.EndUpdate();
                    }
                }
                else if (MainTabManga.SelectedIndex == 2 && (MangaSearch_Genres.Items.Count == 0 || force))
                {
                    MangaSearch_Genres.BeginUpdate();
                    MangaSearch_Genres.Items.Clear();

                    DataTable dataTable = DatabaseSelect("SELECT * FROM genres");

                    foreach (DataRow row in dataTable.Rows)
                        MangaSearch_Genres.Items.Add(row["genres_genre"], false);

                    MangaSearch_Genres.EndUpdate();
                }
            }
            else if (MainTab.SelectedIndex == 7)
            {
                DataSQL_Tables.BeginUpdate();
                DataSQL_Tables.Items.Clear();

                if (DataSQL_Tables.Items.Count == 0 || force)
                {
                    DataTable Tabulky = DatabaseSelect("SELECT * FROM MSysObjects WHERE (((MSysObjects.Type)=1)) ORDER BY MSysObjects.Name");

                    foreach (DataRow row in Tabulky.Rows)
                        if (!row["Name"].ToString().Contains("MSys"))
                            DataSQL_Tables.Items.Add(row["Name"]);
                }

                DataSQL_Tables.EndUpdate();
            }
        }

        //Při scrollování
        void Tab_MouseWheel(object sender, MouseEventArgs e)
        {
            if (sender is TabControl)
            {
                TabControl TC = (TabControl)sender;

                if (e.Y <= TC.ItemSize.Height && e.Y >= 0)
                {
                    if (e.Delta < 0)
                        TC.SelectedIndex = TC.SelectedIndex + 1 >= TC.TabCount ? 0 : TC.SelectedIndex + 1;
                    else
                        TC.SelectedIndex = TC.SelectedIndex - 1 <= 0 ? TC.TabCount - 1 : TC.SelectedIndex - 1;

                    if (TC.SelectedTab == null)
                        TC.SelectedIndex = 0;

                    TC.Focus();
                }
            }
        }

        //Při nájezdu aktivuj scrollování
        private void Tab_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is TabControl)
            {
                TabControl TC = (TabControl)sender;

                if (e.Y <= TC.ItemSize.Height && e.Y >= 0)
                    TC.Focus();
            }
        }

        //Stistky kláves
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DataFiles_Filtr01.Focused ||
                    DataFiles_Filtr02.Focused ||
                    DataFiles_Filtr03.Focused ||
                    DataFiles_Filtr04.Focused)
                {
                    DataFiles_Bt01_Click((object)DataFiles_Bt00, null);
                }
                else if (DataFiles_Filtr01.Focused ||
                    DataFiles_Filtr02.Focused ||
                    DataFiles_Filtr03.Focused ||
                    DataFiles_Filtr04.Focused)
                {
                    DataFiles_Bt01_Click((object)DataFiles_Bt01, null);
                }
                else if (DataSearch_NM01.Focused ||
                    DataSearch_NM02.Focused ||
                    DataSearch_NM03.Focused ||
                    DataSearch_NM04.Focused ||
                    DataSearch_NM05.Focused ||
                    DataSearch_TX01.Focused ||
                    DataSearch_TX02.Focused ||
                    DataSearch_TX03.Focused ||
                    DataSearch_TX04.Focused ||
                    DataSearch_TX05.Focused ||
                    DataSearch_TX06.Focused ||
                    DataSearch_TX07.Focused ||
                    DataSearch_TX08.Focused)
                {
                    DataSearch_Select_Click(null, null);
                }
                else if (Add_Text01.Focused)
                {
                    Add_Add_Click(null, null);
                }
                else if (MangaSearch_TX01.Focused ||
                    MangaSearch_TX02.Focused ||
                    MangaSearch_TX03.Focused ||
                    MangaSearch_TX04.Focused ||
                    MangaSearch_TX05.Focused ||
                    MangaSearch_NM01.Focused ||
                    MangaSearch_NM02.Focused ||
                    MangaSearch_NM03.Focused ||
                    MangaSearch_NM04.Focused ||
                    MangaSearch_Genres.Focused)
                {
                    MangaSearch_Search_Click(null, null);
                }
            }
        }
        #endregion

        #region AniDB Komunikace
        //Začni komunikaci
        private void Options_StartComunication_Click(object sender, EventArgs e)
        {
            if (!ComunicationW.IsBusy && !ComunicationRec.Enabled)
            {
                CRessetCount = 0;
                this.ToolTip.SetToolTip(Options_StartComunication, Language.Options_StartComunicationOn);
                this.ToolTip.SetToolTip(StatusBar_Connect, Language.Options_StartComunicationOn);

                ComunicationW_Reconncect = true;
                ComunicationW.RunWorkerAsync();
            }
            else
            {
                ComunicationW_Reconncect = false;
                ComunicationW.CancelAsync();
            }
        }

        //Odešli správu + log
        private void CommunicationSend(string message)
        {
            while (true)
            {
                if (aniDBClient._Status != AniDBClient2.SocketMsgs.S_SENDING)
                    break;

                Thread.Sleep(500);
            }

            if (!message.Contains("PING") &&
                !message.Contains("AUTH") &&
                !message.Contains("LOGOUT") &&
                !message.Contains("MYLISTSTATS"))
                message += "&s=" + AniDBSessions;

            byte[] buffer = aniDBClient.ConvertToByte(message);
            aniDBClient.Send(buffer, 0, buffer.Length);
        }

        //Získej zprávu + log
        private string CommunicationReceive()
        {
            if (aniDBClient.SocketAniDB != null)
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (aniDBClient._Status != AniDBClient2.SocketMsgs.S_RECEIVEING)
                        break;
                }

                Thread.Sleep(500);

                int nBytesReceive = aniDBClient.SocketAniDB.Available;

                int k = 0;

                while (nBytesReceive == 0)
                {
                    nBytesReceive = aniDBClient.SocketAniDB.Available;
                    Thread.Sleep(500);
                    k++;
                    if (k > 10)
                    {
                        nBytesReceive = 10240;
                        break;
                    }
                }

                byte[] buffer = new byte[nBytesReceive];


                buffer = aniDBClient.Receive(buffer, 0, nBytesReceive);

                string message = aniDBClient.ConvertFromByte(buffer);

                if (message != null)
                {
                    message = message.Replace("\0", "");
                    message = message.Replace("\n", "\r\n");
                }
                else
                    message = "";

                AniDBMsgsParser(message);

                return message;
            }

            return "";
        }

        //Zjisti zprávu
        private void AniDBMsgsParser(string message)
        {
            if (message != null)
            {
                if (message.Length > 0)
                {
                    if (message.Contains("\n"))
                    {
                        AniDBStatus = AniDBMsgs.A__NOTHING_;

                        string[] T = message.Split('\n');

                        if (T[0].Contains("CONNECT"))
                            AniDBStatus = AniDBMsgs.A_CONNECT;

                        if (T[0].Contains("DISCONNECT"))
                            AniDBStatus = AniDBMsgs.A_DISCONNECT;

                        if (T[0].Contains("ILLEGAL INPUT"))
                            AniDBStatus = AniDBMsgs.A_ILLEGAL_INPUT;

                        if (T[0].Contains("BANNED"))
                            AniDBStatus = AniDBMsgs.A_BANNED;

                        if (T[0].Contains("UNKNOWN COMMAND"))
                            AniDBStatus = AniDBMsgs.A_UNKNOWN_COMMAND;

                        if (T[0].Contains("INTERNAL SERVER ERROR"))
                            AniDBStatus = AniDBMsgs.A_INTERNAL_SERVER_ERROR;

                        if (T[0].Contains("OUT OF SERVICE"))
                            AniDBStatus = AniDBMsgs.A_OUT_OF_SERVICE;

                        if (T[0].Contains("SERVER BUSY"))
                            AniDBStatus = AniDBMsgs.A_SERVER_BUSY;

                        if (T[0].Contains("LOGIN FIRST"))
                            AniDBStatus = AniDBMsgs.A_LOGIN_FIRST;

                        if (T[0].Contains("ACCESS DENIED"))
                            AniDBStatus = AniDBMsgs.A_ACCESS_DENIED;

                        if (T[0].Contains("INVALID SESSION"))
                            AniDBStatus = AniDBMsgs.A_INVALID_SESSION;

                        if (T[0].Contains("ERROR"))
                            AniDBStatus = AniDBMsgs.A_ERROR;

                        if (T[0].Contains("AUTH"))
                            AniDBStatus = AniDBMsgs.A_AUTH;

                        if (T[0].Contains("A_AUTH"))
                            AniDBStatus = AniDBMsgs.A_SERVER_BUSY;

                        if (T[0].Contains("LOGOUT"))
                            AniDBStatus = AniDBMsgs.A_LOGOUT;

                        if (T[0].Contains("LOGGED OUT"))
                            AniDBStatus = AniDBMsgs.A_LOGGED_OUT;

                        if (T[0].Contains("LOGIN ACCEPTED"))
                            AniDBStatus = AniDBMsgs.A_LOGIN_ACCEPTED;

                        if (T[0].Contains("LOGIN ACCEPTED NEW VER"))
                            AniDBStatus = AniDBMsgs.A_LOGIN_ACCEPTED_NEW_VER;

                        if (T[0].Contains("LOGIN FAILED"))
                            AniDBStatus = AniDBMsgs.A_LOGIN_FAILED;

                        if (T[0].Contains("CLIENT BANNED"))
                            AniDBStatus = AniDBMsgs.A_CLIENT_BANNED;

                        if (T[0].Contains("NOT LOGGED"))
                            AniDBStatus = AniDBMsgs.A_NOT_LOGGED;

                        if (T[0].Contains("NOTIFICATION ENABLED"))
                            AniDBStatus = AniDBMsgs.A_NOTIFICATION_ENABLED;

                        if (T[0].Contains("NOTIFICATION DISABLED"))
                            AniDBStatus = AniDBMsgs.A_NOTIFICATION_DISABLED;

                        if (T[0].Contains("NOTIFYLIST"))
                            AniDBStatus = AniDBMsgs.A_NOTIFYLIST;

                        if (T[0].Contains("NOTIFYGET"))
                            AniDBStatus = AniDBMsgs.A_NOTIFYGET;

                        if (T[0].Contains("NO SUCH ENTRY"))
                            AniDBStatus = AniDBMsgs.A_NO_SUCH_ENTRY;

                        if (T[0].Contains("NOTIFYACK"))
                            AniDBStatus = AniDBMsgs.A_NOTIFYACK;

                        if (T[0].Contains("BUDDYDEL"))
                            AniDBStatus = AniDBMsgs.A_BUDDYDEL;

                        if (T[0].Contains("BUDDYACCEPT"))
                            AniDBStatus = AniDBMsgs.A_BUDDYACCEPT;

                        if (T[0].Contains("BUDDYDENY"))
                            AniDBStatus = AniDBMsgs.A_BUDDYDENY;

                        if (T[0].Contains("BUDDYLIST"))
                            AniDBStatus = AniDBMsgs.A_BUDDYLIST;

                        if (T[0].Contains("ANIME"))
                            AniDBStatus = AniDBMsgs.A_ANIME;

                        if (T[0].Contains("NO SUCH ANIME"))
                            AniDBStatus = AniDBMsgs.A_NO_SUCH_ANIME;

                        if (T[0].Contains("EPISODE"))
                            AniDBStatus = AniDBMsgs.A_EPISODE;

                        if (T[0].Contains("NO SUCH EPISODE"))
                            AniDBStatus = AniDBMsgs.A_NO_SUCH_EPISODE;

                        if (T[0].Contains("FILE"))
                            AniDBStatus = AniDBMsgs.A_FILE;

                        if (T[0].Contains("NO SUCH FILE"))
                            AniDBStatus = AniDBMsgs.A_NO_SUCH_FILE;

                        if (T[0].Contains("MULTIPLE FILES FOUND"))
                            AniDBStatus = AniDBMsgs.A_MULTIPLE_FILES_FOUND;

                        if (T[0].Contains("GROUP"))
                            AniDBStatus = AniDBMsgs.A_GROUP;

                        if (T[0].Contains("NO SUCH GROUP"))
                            AniDBStatus = AniDBMsgs.A_NO_SUCH_GROUP;

                        if (T[0].Contains("GROUPSTATUS"))
                            AniDBStatus = AniDBMsgs.A_GROUPSTATUS;

                        if (T[0].Contains("MYLIST"))
                            AniDBStatus = AniDBMsgs.A_MYLIST;

                        if (T[0].Contains("NO SUCH MYLIST ENTRY"))
                            AniDBStatus = AniDBMsgs.A_NO_SUCH_MYLIST_ENTRY;

                        if (T[0].Contains("MULTIPLE MYLIST ENTRIES"))
                            AniDBStatus = AniDBMsgs.A_MULTIPLE_MYLIST_ENTRIES;

                        if (T[0].Contains("MYLISTADD"))
                            AniDBStatus = AniDBMsgs.A_MYLISTADD;

                        if (T[0].Contains("MYLIST ENTRY ADDED"))
                            AniDBStatus = AniDBMsgs.A_MYLIST_ENTRY_ADDED;

                        if (T[0].Contains("FILE ALREADY IN MYLIST"))
                            AniDBStatus = AniDBMsgs.A_FILE_ALREADY_IN_MYLIST;

                        if (T[0].Contains("MULTIPLE FILES FOUND"))
                            AniDBStatus = AniDBMsgs.A_MULTIPLE_FILES_FOUND;

                        if (T[0].Contains("MYLISTDEL"))
                            AniDBStatus = AniDBMsgs.A_MYLISTDEL;

                        if (T[0].Contains("MYLIST ENTRY DELETED"))
                            AniDBStatus = AniDBMsgs.A_MYLIST_ENTRY_DELETED;

                        if (T[0].Contains("MYLIST STATS"))
                            AniDBStatus = AniDBMsgs.A_MYLISTSTATS;

                        if (T[0].Contains("VOTE"))
                            AniDBStatus = AniDBMsgs.A_VOTE;

                        if (T[0].Contains("INVALID VOTE TYPE"))
                            AniDBStatus = AniDBMsgs.A_INVALID_VOTE_TYPE;

                        if (T[0].Contains("PERMVOTE NOT ALLOWED"))
                            AniDBStatus = AniDBMsgs.A_PERMVOTE_NOT_ALLOWED;

                        if (T[0].Contains("RANDOMANIME"))
                            AniDBStatus = AniDBMsgs.A_RANDOMANIME;

                        if (T[0].Contains("MYLISTEXPORT"))
                            AniDBStatus = AniDBMsgs.A_MYLISTEXPORT;

                        if (T[0].Contains("PING"))
                            AniDBStatus = AniDBMsgs.A_VOTE;

                        if (T[0].Contains("PONG"))
                            AniDBStatus = AniDBMsgs.A_PONG;

                        if (T[0].Contains("VERSION"))
                            AniDBStatus = AniDBMsgs.A_VERSION;

                        if (T[0].Contains("UPTIME"))
                            AniDBStatus = AniDBMsgs.A_UPTIME;

                        if (T[0].Contains("USER"))
                            AniDBStatus = AniDBMsgs.A_USER;

                        if (T[0].Contains("UNKNOWN COMMAND"))
                            AniDBStatus = AniDBMsgs.A_UNKNOWN_COMMAND;

                        if (T[0].Contains("LOGIN FIRST"))
                            AniDBStatus = AniDBMsgs.A_LOGIN_FIRST;

                        if (T[0].Contains("MYLIST ENTRY EDITED"))
                            AniDBStatus = AniDBMsgs.A_MYLIST_ENTRY_EDITED;
                    }
                    else
                        AniDBStatus = AniDBMsgs.A_DISCONNECT;
                }
                else
                    AniDBStatus = AniDBMsgs.A_DISCONNECT;
            }
            else
                AniDBStatus = AniDBMsgs.A_DISCONNECT;
        }

        #region AniDBMsgs
        //Zprávy
        public enum AniDBMsgs
        {
            A__NOTHING_ = 0x1000,
            A_DISCONNECT = 0x0000,
            A_CONNECT = 0x0001,
            A_ILLEGAL_INPUT = 0x0002,
            A_BANNED = 0x0003,
            A_UNKNOWN_COMMAND = 0x0004,
            A_INTERNAL_SERVER_ERROR = 0x0005,
            A_OUT_OF_SERVICE = 0x0006,
            A_SERVER_BUSY = 0x0007,
            A_LOGIN_FIRST = 0x0008,
            A_ACCESS_DENIED = 0x0009,
            A_INVALID_SESSION = 0x0010,
            A_ERROR = 0x0011,
            A_AUTH = 0x0012,
            A_LOGOUT = 0x0013,
            A_LOGIN_ACCEPTED = 0x0014,
            A_LOGIN_FAILED = 0x0015,
            A_VERSION_OUTDATED = 0x0016,
            A_CLIENT_BANNED = 0x0017,
            A_NOT_LOGGED = 0x0018,
            A_NOTIFICATION_ENABLED = 0x0019,
            A_NOTIFICATION_DISABLED = 0x0020,
            A_NOTIFYLIST = 0x0021,
            A_NOTIFYGET = 0x0022,
            A_NO_SUCH_ENTRY = 0x0023,
            A_NOTIFYACK = 0x0024,
            A_BUDDYADD = 0x0025,
            A_BUDDYDEL = 0x0026,
            A_BUDDYACCEPT = 0x0027,
            A_BUDDYDENY = 0x0028,
            A_BUDDYLIST = 0x0029,
            A_ANIME = 0x0030,
            A_NO_SUCH_ANIME = 0x0031,
            A_ANIMEDESC = 0x0032,
            A_EPISODE = 0x0033,
            A_NO_SUCH_EPISODE = 0x0034,
            A_FILE = 0x0035,
            A_NO_SUCH_FILE = 0x0036,
            A_MULTIPLE_FILES_FOUND = 0x0037,
            A_GROUP = 0x0038,
            A_NO_SUCH_GROUP = 0x0039,
            A_GROUPSTATUS = 0x0040,
            A_MYLIST = 0x0041,
            A_MULTIPLE_MYLIST_ENTRIES = 0x0042,
            A_MYLISTADD = 0x0043,
            A_MYLIST_ENTRY_ADDED = 0x0044,
            A_FILE_ALREADY_IN_MYLIST = 0x0045,
            A_USER = 0x0046,
            A_MYLIST_ENTRY_EDITED = 0x0047,
            A_MYLISTDEL = 0x0048,
            A_MYLIST_ENTRY_DELETED = 0x0049,
            A_MYLISTSTATS = 0x0050,
            A_VOTE = 0x0051,
            A_INVALID_VOTE_TYPE = 0x0052,
            A_PERMVOTE_NOT_ALLOWED = 0x0053,
            A_ALREADY_PERMVOTED = 0x0054,
            A_RANDOMANIME = 0x0055,
            A_MYLISTEXPORT = 0x0056,
            A_PING = 0x0057,
            A_PONG = 0x0058,
            A_VERSION = 0x0059,
            A_UPTIME = 0x0060,
            A_NO_SUCH_MYLIST_ENTRY = 0x0061,
            A_LOGGED_OUT = 0x0062,
            A_LOGIN_ACCEPTED_NEW_VER = 0x0063
        }
        #endregion

        //Úlohy pro připojení
        private void ComunicationNewTask(string Task)
        {
            if (!LogTasks.Items.Contains(Task))
            {
                LogTasks.Items.Add(Task);
                StatusBar_Mn02.Text = LogTasks.Items.Count.ToString();

                DatabaseAdd("INSERT INTO task (task_task) VALUES ('" + Task + "')");
            }
        }

        //Úlohy pro připojení
        private void ComunicationNewTaskKO(string Task)
        {
            if (!LogTasks.Items.Contains(Task))
            {
                StatusBar_Mn02.Text = LogTasks.Items.Count.ToString();
                LogTasks.Items.Add(Task);
            }
        }

        //Recconcet
        private void ComunicationRec_Tick(object sender, EventArgs e)
        {
            ComunicationW.CancelAsync();
            ComunicationW.RunWorkerAsync();
            ComunicationRec.Stop();
        }

        //Posílej zprávy
        private void ComunicationW_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ComunicationW_ReLogIn)
            {
                ComunicationW_ReLogIn = false;

                aniDBClient = new AniDBClient2(Options_ServerName.Text, (int)Options_ServerPort.Value, (int)Options_LocalPort.Value, (int)Options_TimeOut.Value, Options_Network.SelectedItem.ToString());

                aniDBClient.Connnect();

                ComunicationW_DataSend = "AUTH user=" + Options_User.Text + "&pass=" + Options_Password.Text + "&protover=3&client=" + AniSubC + "&clientver=" + AniSubV + "&enc=utf8";
                CommunicationSend(ComunicationW_DataSend);
                ComunicationW_DataSend = ComunicationW_DataSend.Replace(Options_Password.Text, "XXXX");
                ComunicationW_WaitW("Send");

                ComunicationW_DataReceive = CommunicationReceive();
                ComunicationW_WaitW("Receive");
            }
            else if (AniDBSessions == null)
            {
                AniDBStatus = AniDBMsgs.A_ERROR;
                ComunicationW_Task = "";
                ComunicationW_WaitW("Error");

                ComunicationW_Reconncect = false;
                ComunicationW.CancelAsync();
                aniDBClient.Close();
            }
            else
            {
                aniDBClient.Close();
                aniDBClient.Connnect();
                isConnected = true;
                ComunicationW_Reconncect = true;
                ComunicationW_Task = "";
            }

            int toPing = 0;

            if (isConnected)
            {
                while (true)
                {
                    if (ComunicationW.CancellationPending)
                        break;

                    Thread.Sleep(1000);
                    toPing++;

                    if (ComunicationW.CancellationPending)
                        break;

                    if (LogTasks.Items.Count > 0 || toPing >= 60 * 20)
                    {
                        if (ComunicationW.CancellationPending)
                            break;

                        if (toPing >= 60 * 20 && LogTasks.Items.Count == 0 && isConnected && AniDBSessions != null)
                            LogTasks.Items.Add("PING s=" + AniDBSessions);

                        toPing = 0;

                        while (LogTasks.Items.Count > 0)
                        {

                            Thread.Sleep((int)Options_Delay.Value * 1000);

                            if (ComunicationW.CancellationPending)
                                break;

                            ComunicationW_DataSend = LogTasks.Items[0].ToString();
                            CommunicationSend(ComunicationW_DataSend);
                            ComunicationW_WaitW("Send");

                            ComunicationW_DataReceive = CommunicationReceive();

                            if (AniDBStatus == AniDBMsgs.A_DISCONNECT || ComunicationW_ReLogIn || AniDBStatus == AniDBMsgs.A_LOGIN_FIRST)
                            {
                                aniDBClient.Close();
                                ComunicationW.CancelAsync();
                                ComunicationW_Reconncect = true;
                                break;
                            }

                            ComunicationW_Task = ComunicationW_DataSend;
                            ComunicationW_WaitW("Receive");
                        }
                    }

                    if (ComunicationW.CancellationPending)
                        break;
                }
            }

            if (!ComunicationW_Reconncect)
            {
                switch (AniDBStatus)
                {
                    case AniDBMsgs.A_BANNED:
                    case AniDBMsgs.A_ERROR:
                    case AniDBMsgs.A_INTERNAL_SERVER_ERROR:
                    case AniDBMsgs.A_LOGIN_FAILED:
                    case AniDBMsgs.A_LOGIN_FIRST:
                    case AniDBMsgs.A_OUT_OF_SERVICE:
                    case AniDBMsgs.A_CLIENT_BANNED:
                    case AniDBMsgs.A_SERVER_BUSY:
                    case AniDBMsgs.A_VERSION_OUTDATED:
                        break;

                    default:
                        if (AniDBSessions != null)
                        {
                            ComunicationW_DataSend = "LOGOUT s=" + AniDBSessions;
                            CommunicationSend(ComunicationW_DataSend);
                            ComunicationW_WaitW("Send");

                            ComunicationW_DataReceive = CommunicationReceive();

                            ComunicationW_Task = "";
                            ComunicationW_WaitW("Receive");
                        }
                        break;
                }
            }
        }

        //Počkej na odpovědi
        private void ComunicationW_WaitW(string MSG)
        {
            ComunicationW_Wait = false;

            if (MSG == "Receive")
            {
                switch (AniDBStatus)
                {
                    case AniDBMsgs.A_BANNED:
                    case AniDBMsgs.A_ACCESS_DENIED:
                    case AniDBMsgs.A_ERROR:
                    case AniDBMsgs.A_ILLEGAL_INPUT:
                    case AniDBMsgs.A_INTERNAL_SERVER_ERROR:
                    case AniDBMsgs.A_UNKNOWN_COMMAND:
                    case AniDBMsgs.A_LOGIN_FAILED:
                    case AniDBMsgs.A_LOGIN_FIRST:
                    case AniDBMsgs.A_OUT_OF_SERVICE:
                    case AniDBMsgs.A_CLIENT_BANNED:
                    case AniDBMsgs.A_SERVER_BUSY:
                    case AniDBMsgs.A_VERSION_OUTDATED:
                        MSG = "Error";
                        break;
                }

                if (ComunicationW_DataReceive == "" || ComunicationW_DataReceive == null || AniDBStatus == AniDBMsgs.A_DISCONNECT || AniDBStatus == AniDBMsgs.A_SERVER_BUSY)
                {
                    MSG = "Error";
                    CRessetCount++;
                    LogAddError("Reset count: " + CRessetCount);

                    if (CRessetCount >= Options_Reset.Value)
                    {
                        AniDBStatus = AniDBMsgs.A_ERROR;
                        ComunicationW.ReportProgress(1, "Error");

                        ComunicationW_Reconncect = false;
                        ComunicationW.CancelAsync();
                        return;
                    }
                }
            }
            else
                AniDBStatus = AniDBMsgs.A__NOTHING_;

            long sleep = CRessetCount * 2 * 60 * 1000;

            if (AniDBStatus == AniDBMsgs.A_SERVER_BUSY)
                ComunicationW_DataReceive += " * Sleep time " + sleep.ToString() + "ms";

            ComunicationW.ReportProgress(1, MSG);

            if (AniDBStatus == AniDBMsgs.A_SERVER_BUSY)
            {
                for (long i = 0; i <= sleep; i += 10)
                {
                    Thread.Sleep(10);

                    if (ComunicationW.CancellationPending)
                        return;
                }
            }

            while (true)
            {
                Thread.Sleep(100);
                if (ComunicationW_Wait)
                    break;

                if (ComunicationW.CancellationPending)
                    break;
            }
        }

        //Zpracuj zprávy
        private void ComunicationW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (e.UserState.ToString() == "Send")
                {
                    LogAdd("AniDB > " + e.UserState.ToString() + " : " + ComunicationW_DataSend);
                }
                else
                {
                    LogAdd("AniDB < " + e.UserState.ToString() + " : " + ComunicationW_DataReceive);

                    string[] T = ComunicationW_DataReceive.Replace("'", "''").Replace("\r", "").Split('\n');

                    if ((e.UserState.ToString() == "Receive" && ComunicationW_DataReceive != "") || AniDBStatus == AniDBMsgs.A_ACCESS_DENIED)
                    {
                        CRessetCount = 0;
                        DatabaseAdd("DELETE FROM task WHERE task_task='" + ComunicationW_Task + "'");
                        LogTasks.Items.Remove(ComunicationW_Task);
                        StatusBar_Mn02.Text = LogTasks.Items.Count.ToString();
                    }

                    if (AniDBStatus == AniDBMsgs.A_LOGIN_ACCEPTED ||
                        AniDBStatus == AniDBMsgs.A_LOGIN_ACCEPTED_NEW_VER)
                    {
                        StatusBar_ConnectLB.Text = Language.StatusBar_ConnectLBOn;
                        ToolTip.SetToolTip(Options_StartComunication, Language.Options_StartComunicationOn);
                        ToolTip.SetToolTip(StatusBar_Connect, Language.Options_StartComunicationOn);
                        Options_StartComunication.BackgroundImage = Resources.i_GlobeG;
                        StatusBar_Connect.BackgroundImage = Resources.i_GlobeG;
                        isConnected = true;
                        T = T[0].Split(' ');
                        AniDBSessions = T[1];
                    }

                    if (AniDBStatus == AniDBMsgs.A_LOGIN_FAILED)
                    {
                        MessageBox.Show(Language.MSG03, "AniSub - Error", MessageBoxButtons.OK);
                    }

                    if (AniDBStatus == AniDBMsgs.A_LOGIN_FIRST)
                    {
                        MessageBox.Show(Language.MSG03, "AniSub - Error", MessageBoxButtons.OK);
                        ComunicationW_Reconncect = true;
                    }

                    if (AniDBStatus == AniDBMsgs.A_LOGIN_ACCEPTED_NEW_VER)
                    {
                        MessageBox.Show(Language.MSG05, "AniSub", MessageBoxButtons.OK);
                    }

                    if (AniDBStatus == AniDBMsgs.A_VERSION_OUTDATED)
                    {
                        MessageBox.Show(Language.MSG01, "AniSub - Error", MessageBoxButtons.OK);
                    }

                    if (AniDBStatus == AniDBMsgs.A_BANNED ||
                        AniDBStatus == AniDBMsgs.A_CLIENT_BANNED)
                    {
                        ComunicationW_Reconncect = false;
                        ComunicationW.CancelAsync();
                        MessageBox.Show(Language.MSG02, "AniSub - Error", MessageBoxButtons.OK);
                    }

                    if (AniDBStatus == AniDBMsgs.A_SERVER_BUSY)
                    {
                        //
                    }

                    if (AniDBStatus == AniDBMsgs.A_INTERNAL_SERVER_ERROR ||
                        AniDBStatus == AniDBMsgs.A_ERROR ||
                        AniDBStatus == AniDBMsgs.A_OUT_OF_SERVICE)
                    {

                        MessageBox.Show(Language.MSG04, "AniSub - Error", MessageBoxButtons.OK);
                    }

                    if (AniDBStatus == AniDBMsgs.A_UNKNOWN_COMMAND ||
                        AniDBStatus == AniDBMsgs.A_ILLEGAL_INPUT)
                    {
                        MessageBox.Show(Language.MSG02, "AniSub - Error", MessageBoxButtons.OK);
                    }

                    if (T.Length >= 2)
                    {
                        ComunicationW_DataReceive = T[1];

                        if (AniDBStatus == AniDBMsgs.A_MYLIST ||
                            AniDBStatus == AniDBMsgs.A_FILE_ALREADY_IN_MYLIST)
                        {
                            AniDBParserMyList();
                        }

                        if (AniDBStatus == AniDBMsgs.A_FILE)
                        {
                            AniDBParserFiles();
                        }

                        if (AniDBStatus == AniDBMsgs.A_MYLISTSTATS)
                        {
                            AniDBParserMyListStats();
                        }

                        if (AniDBStatus == AniDBMsgs.A_MYLIST_ENTRY_ADDED ||
                            AniDBStatus == AniDBMsgs.A_MYLIST_ENTRY_EDITED)
                        {
                            if (ComunicationW_DataSend.Contains("fid="))
                            {
                                string fid = Parse(ComunicationW_DataSend, "fid=", "&", false);
                                if (fid != "")
                                    ComunicationNewTask("MYLIST fid=" + fid);
                            }
                        }

                        if (AniDBStatus == AniDBMsgs.A_MYLIST_ENTRY_DELETED)
                        {
                            if (ComunicationW_DataSend.Contains("MYLISTDEL fid="))
                            {
                                string fid = ComunicationW_DataSend.Replace("MYLISTDEL fid=", "");

                                if (fid != "")
                                    DatabaseAdd("UPDATE files SET files_source='', files_storage='', files_watched=0, files_lid=0, files_other='', files_status=0, files_state=0 WHERE id_files=" + fid);
                            }
                        }

                        if (AniDBStatus == AniDBMsgs.A_NO_SUCH_ENTRY ||
                            AniDBStatus == AniDBMsgs.A_MULTIPLE_MYLIST_ENTRIES ||
                            AniDBStatus == AniDBMsgs.A_NO_SUCH_MYLIST_ENTRY)
                        {
                            if (ComunicationW_DataSend.Contains("MYLIST") && ComunicationW_DataSend.Contains("fid="))
                            {
                                string fid = ComunicationW_DataSend.Replace("MYLIST", "");
                                fid = fid.Replace("DEL", "");
                                fid = fid.Replace(" ", "");
                                fid = fid.Replace("fid=", "");
                                fid = fid.Replace("&", "");

                                if (fid != "")
                                    DatabaseAdd("UPDATE files SET files_other='', files_state=0, files_dateAdded=#" + DatumFormat(new DateTime(1, 1, 1, 0, 0, 0)) + "#, files_seen=#" + DatumFormat(new DateTime(1, 1, 1, 0, 0, 0)) + "#, files_watched=0, files_storage='', files_source='', files_status=0 WHERE id_files=" + fid);
                            }
                        }

                        if (AniDBStatus == AniDBMsgs.A_NO_SUCH_FILE)
                        {
                            if ((ComunicationW_DataSend.Contains("FILE") || ComunicationW_DataSend.Contains("MYLIST")) && ComunicationW_DataSend.Contains("ed2k="))
                            {
                                string ed2k = Parse(ComunicationW_DataSend, "ed2k=", "&", false);

                                if (ed2k != "")
                                    DatabaseAdd("UPDATE files SET id_files=-1 WHERE files_ed2k='" + ed2k + "'");
                            }
                        }

                        if (AniDBStatus == AniDBMsgs.A_EPISODE)
                        {
                            AniDBParserEpisodes();
                        }

                        if (AniDBStatus == AniDBMsgs.A_ANIME)
                        {
                            AniDBParserAnime();
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                LogAddError("Thread error: " + ee.ToString());
            }

            ComunicationW_Wait = true;
        }

        //Ukončení spojení
        private void ComunicationW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isConnected = false;
            aniDBClient.Close();

            if (ComunicationW_Reconncect)
            {
                ComunicationRec.Start();
            }
            else
            {
                this.ToolTip.SetToolTip(Options_StartComunication, Language.Options_StartComunicationOff);
                this.ToolTip.SetToolTip(StatusBar_Connect, Language.Options_StartComunicationOff);
                this.ToolTip.SetToolTip(Options_StartComunication, Language.Options_StartComunicationOn);

                StatusBar_ConnectLB.Text = Language.StatusBar_ConnectLBOff;

                Options_StartComunication.BackgroundImage = Resources.i_GlobeR;
                StatusBar_Connect.BackgroundImage = Resources.i_GlobeR;

                ComunicationW_ReLogIn = true;
                AniDBSessions = null;
            }
        }
        #endregion

        #region Parser
        //Parsování anime
        private void AniDBParserAnime()
        {
            string[] T = ComunicationW_DataReceive.Split('|');

            if (T.Length == 17)
            {
                string[] TR = T[3].Replace("\'\'", "\'").Split('\'');
                string[] TRT = T[4].Replace("\'\'", "\'").Split('\'');
                string[] TC = T[5].Split(',');

                //0 - ID Anime
                //1 - Year
                //2 - TV Series
                //3 - Relations Anime
                //4 - Relations Anime type
                //5 - Categories
                //6 - JP
                //7 - KAJ
                //8 - ENG
                //9 - Episodes
                //10 - Episodes Normal
                //11 - Episodes Spec
                //12 - Air date
                //13 - End date
                //14 - URL
                //15 - Picture
                //16 - 18+

                if (T[15] != "N" && T[15] == "")
                    T[15] = "None.jpg";

                DataTable dataTable = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + T[0]);

                if (dataTable.Rows.Count == 0)
                {
                    if (ComunicationW_DataReceive.Contains("|N|N|N|N|N|N|N|N"))
                    {
                        DatabaseAdd("INSERT INTO anime (id_anime, anime_rok, anime_typ, anime_nazevjap, anime_nazevkaj, anime_nazeveng, anime_watched, anime_seen, anime_rating, anime_18, anime_epn_spec, anime_epn) VALUES (" + T[0] + ", '" + T[1] + "', '" + T[2] + "', '" + T[6] + "', '" + T[7] + "', '" + T[8] + "', 0, #" + DatumFormat(new DateTime(2000, 1, 1)) + "#, 0, 0, 0, 0)");
                        ComunicationNewTask("ANIME aid=" + T[0] + "&amask=BEE0FE01");
                    }
                    else
                        DatabaseAdd("INSERT INTO anime (id_anime, anime_rok, anime_typ, anime_nazevjap, anime_nazevkaj, anime_nazeveng, anime_epn, anime_epn_spec, anime_date_air, anime_date_end, anime_url, anime_obr, anime_18, anime_watched) VALUES (" + T[0] + ", '" + T[1] + "', '" + T[2] + "', '" + T[6] + "', '" + T[7] + "', '" + T[8] + "', " + T[10] + ", " + T[11] + ", #" + DatumFormat(GetDateFromSeconds(T[13])) + "#, #" + DatumFormat(GetDateFromSeconds(T[12])) + "#, '" + T[14] + "', '" + T[15] + "', " + T[16] + ", 0)");
                }
                else
                {
                    if (ComunicationW_DataReceive.Contains("|N|N|N|N|N|N|N|N"))
                        DatabaseAdd("UPDATE anime SET anime_nazeveng='" + T[8] + "', anime_nazevkaj='" + T[7] + "', anime_nazevjap='" + T[6] + "', anime_typ='" + T[2] + "', anime_rok='" + T[1] + "' WHERE id_anime=" + T[0]);
                    else
                        DatabaseAdd("UPDATE anime SET anime_18=" + T[16] + ", anime_obr='" + T[15] + "', anime_url='" + T[14] + "', anime_date_end=#" + DatumFormat(GetDateFromSeconds(T[12])) + "#, anime_date_air=#" + DatumFormat(GetDateFromSeconds(T[13])) + "#, anime_epn_spec=" + T[11] + ", anime_epn=" + T[10] + ", anime_nazeveng='" + T[8] + "', anime_nazevkaj='" + T[7] + "', anime_nazevjap='" + T[6] + "', anime_typ='" + T[2] + "', anime_rok='" + T[1] + "' WHERE id_anime=" + T[0]);
                }

                foreach (string Genre in TC)
                {
                    if (Genre != "")
                    {
                        dataTable = DatabaseSelect("SELECT * FROM genres WHERE genres_genre='" + Genre + "'");
                        if (dataTable.Rows.Count == 0)
                        {
                            DatabaseAdd("INSERT INTO genres (genres_genre) VALUES ('" + Genre + "')");
                            dataTable = DatabaseSelect("SELECT * FROM genres WHERE genres_genre='" + Genre + "'");
                        }

                        string id_genre = dataTable.Rows[0]["id_grenres"].ToString();
                        dataTable = DatabaseSelect("SELECT * FROM genres_relations WHERE id_anime=" + T[0] + " AND id_genres=" + id_genre + "");

                        if (dataTable.Rows.Count == 0)
                            DatabaseAdd("INSERT INTO genres_relations (id_anime, id_genres) VALUES (" + T[0] + ", " + id_genre + ")");
                    }
                }

                if (TR.Length == TRT.Length)
                    for (int i = 0; i < TR.Length; i++)
                    {
                        if (TR[i] != "" || TRT[i] != "")
                        {
                            dataTable = DatabaseSelect("SELECT * FROM anime_relations WHERE id_anime=" + T[0] + " AND id_relation=" + TRT[i] + " AND id_anime_related=" + TR[i]);

                            if (dataTable.Rows.Count == 0)
                                DatabaseAdd("INSERT INTO anime_relations (id_anime, id_relation, id_anime_related) VALUES (" + T[0] + ", " + TRT[i] + ", " + TR[i] + ")");
                        }
                    }
            }
            else
            {
                LogAddError("Input string isn't valid format: " + ComunicationW_DataReceive + ", Array lenght != 17");
            }
        }

        //Parsování MyListu
        private void AniDBParserMyList()
        {
            try
            {
                //MYLIST
                //00 - MyLIST ID
                //01 - File ID
                //02 - Episode ID
                //03 - Anime ID
                //04 - Group ID
                //05 - Datum {1242419692}
                //06 - Status HDD, CD, DELETED, UNKNOWN -  Čísla
                //07 - Datum watched {0}
                //08 - Storage
                //09 - Source
                //10 - Other
                //11 - File state - Čísla

                //7836802|
                //273308|
                //48440|
                //645|
                //147|
                //1228683706|
                //1|
                //1356913012|
                //Anime 3|
                //|
                //|
                //0

                string[] T = ComunicationW_DataReceive.Split('|');

                if (T.Length == 12)
                {
                    string Watched = "0";
                    if (GetDateFromSeconds(T[7]) > new DateTime(1970, 1, 1, 0, 0, 0))
                        Watched = "1";

                    if (T[0] == "")
                        T[0] = "0";

                    DataTable dataTable = DatabaseSelect("SELECT * FROM files WHERE id_files=" + T[1]);
                    if (dataTable.Rows.Count > 0)
                        DatabaseAdd("UPDATE files SET files_watched=" + Watched + ", files_lid=" + T[0] + ", files_dateAdded=#" + DatumFormat(GetDateFromSeconds(T[5])) + "#, files_status=" + T[6] + ", files_other='" + T[10] + "', files_seen=#" + DatumFormat(GetDateFromSeconds(T[7])) + "#, files_source='" + T[9] + "', files_storage='" + T[8] + "' WHERE id_files=" + T[1]);
                    else
                    {
                        DatabaseAdd("INSERT INTO files (files_lid, files_status, files_other, files_source, files_storage, id_files, files_date) VALUES (" + T[0] + ", " + T[6] + ", '" + T[10] + "', '" + T[9] + "', '" + T[8] + "', " + T[1] + ", NOW())");
                        DatabaseAdd("UPDATE files SET files_watched=" + Watched + ", files_lid=" + T[0] + ", files_dateAdded=#" + DatumFormat(GetDateFromSeconds(T[5])) + "#, files_status=" + T[6] + ", files_other='" + T[10] + "', files_seen=#" + DatumFormat(GetDateFromSeconds(T[7])) + "#, files_source='" + T[9] + "', files_storage='" + T[8] + "' WHERE id_files=" + T[1]);
                        ComunicationNewTask("FILE fid=" + T[1] + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                    }
                }
                else
                    LogAddError("Input string isn't valid format: " + ComunicationW_DataReceive + ", Array lenght != 12");

            }
            catch (Exception e)
            {
                LogAddError(e.ToString());
            }
        }

        //Parsování souborů
        private void AniDBParserFiles()
        {
            string[] T = ComunicationW_DataReceive.Split('|');

            if (T.Length == 42 && ComunicationW_Task.Contains("&amask=FEE080C1"))
            {
                string[] A = new string[45];

                for (int i = 0; i < 39; i++)
                    A[i] = T[i];

                A[39] = "";
                A[40] = "";
                A[41] = "";
                A[42] = T[39];
                A[43] = T[40];
                A[44] = T[41];

                T = A;
            }

            if (T.Length == 45)
            {
                //00 - File ID
                //01 - Anime ID
                //02 - Episode ID
                //03 - Group ID
                //04 - MyList ID
                //05 - List Other Episodes
                //06 - IsDeprecated
                //07 - File status
                //08 - File size
                //09 - Ed2k
                //10 - MD5
                //11 - SHA1
                //12 - CRC32
                //13 - 10bit / 8bit
                //14 - DTV, HDTV, DVD, ...
                //15 - Source
                //16 - Audio Codec
                //17 - Audio Biterate
                //18 - Video Codec
                //19 - Vidoe Biterate
                //20 - Resultion
                //21 - Extension
                //22 - DUB
                //23 - SUB
                //24 - Lenght Seconds
                //25 - Description
                //26 - Air Date
                //27 - AniDB FileName

                //28 - Total Episodes
                //29 - High Episode
                //30 - Year
                //31 - TV Serie
                //32 - Relations Anime
                //33 - Relations Anime Type
                //34 - Categories
                //35 - JP
                //36 - KAJ
                //37 - ENG

                //38 - Episode Number
                //39 - Episode Name ENG
                //40 - Episode Name JP
                //41 - Episode Name KAJ
                //42 - Group
                //43 - Group Short
                //44 - Date Watched

                if (T[16] == "none")
                    T[16] = "";
                if (T[17] == "none")
                    T[17] = "0";
                if (T[18] == "none")
                    T[18] = "";
                if (T[19] == "none")
                    T[19] = "0";
                if (T[22] == "none")
                    T[22] = "";

                T[17] = T[17].Replace("\'\'", "\'").Split('\'')[0];
                T[19] = T[19].Replace("\'\'", "\'").Split('\'')[0];

                ComunicationW_DataReceive = T[1] + "|" + T[30] + "|" + T[31] + "|" + T[32] + "|" + T[33] + "|" + T[34] + "|" + T[35] + "|" + T[36] + "|" + T[37] + "|N|N|N|N|N|N|N|N";
                AniDBParserAnime();

                DataTable dataTable;
                string EpisodeSpec = "0";

                if (T[38].Contains("S"))
                {
                    T[38] = T[38].Replace("S", "");
                    EpisodeSpec = "S";
                }
                else if (T[38].Contains("O"))
                {
                    T[38] = T[38].Replace("O", "");
                    EpisodeSpec = "O";
                }
                else if (T[38].Contains("T"))
                {
                    T[38] = T[38].Replace("T", "");
                    EpisodeSpec = "T";
                }
                else if (T[38].Contains("P"))
                {
                    T[38] = T[38].Replace("P", "");
                    EpisodeSpec = "P";
                }
                else if (T[38].Contains("C"))
                {
                    T[38] = T[38].Replace("C", "");
                    EpisodeSpec = "C";
                }

                DataTable DFile = DatabaseSelect("SELECT * FROM files WHERE files_ed2k='" + T[9] + "' AND files_size=" + T[8]);
                DataTable dataTableIDFile = DatabaseSelect("SELECT * FROM files WHERE id_files=" + T[0]);

                if (DFile.Rows.Count == 0)
                {
                    if (dataTableIDFile.Rows.Count == 0)
                        DatabaseAdd("INSERT INTO files (files_ed2k, files_size, id_files, files_dateadded, files_date) VALUES ('" + T[9] + "', " + T[8] + ",  " + T[0] + ", NOW(), NOW())");
                }
                else
                {
                    string x = DFile.Rows[0]["files_dub"].ToString().Replace("'", "''");
                    string y = DFile.Rows[0]["files_sub"].ToString().Replace("'", "''");
                    string z = DFile.Rows[0]["files_anidb_name"].ToString().Replace("'", "''");


                    if (T[27] == "" && z != "")
                        DatabaseAdd("UPDATE files SET files_anidb_name='" + z + "' WHERE id_files_local=" + DFile.Rows[0]["id_files_local"].ToString());

                    if (T[22] == "" && x != "")
                        DatabaseAdd("UPDATE files SET files_dub='" + x + "' WHERE id_files_local=" + DFile.Rows[0]["id_files_local"].ToString());

                    if (T[23] == "" && y != "")
                        DatabaseAdd("UPDATE files SET files_sub='" + y + "' WHERE id_files_local=" + DFile.Rows[0]["id_files_local"].ToString());
                }

                DatabaseAdd("UPDATE files SET files_depth='" + T[13] + "', files_sha1='" + T[11] + "', files_date_air=#" + DatumFormat(GetDateFromSeconds(T[26])) + "#, files_anidb_name='" + T[27].Replace("'", "''") + "', files_biterate_audio=" + T[17] + ", files_biterate_video=" + T[19] + ", files_extension='" + T[21] + "', files_lenght=" + T[24] + ", id_files=" + T[0] + ", id_episodes=" + T[2] + ", id_anime=" + T[1] + ", id_groups=" + T[3] + ", files_lid=" + T[4] + ", files_crc32='" + T[12] + "', files_md5='" + T[10] + "', files_dub='" + T[22] + "', files_sub='" + T[23] + "', files_quality='" + T[14].Replace("'", "''") + "', files_audio='" + T[16].Replace("'", "''") + "', files_video='" + T[18] + "', files_resultion='" + T[20] + "', files_typ='" + T[15] + "', files_state=" + T[7] + " WHERE files_ed2k='" + T[9] + "' AND files_size=" + T[8]);

                if (dataTableIDFile.Rows.Count == 0 && Options_CH19.Checked)
                    ComunicationNewTask("MYLIST fid=" + T[0]);

                dataTable = DatabaseSelect("SELECT * FROM groups WHERE id_groups=" + T[3]);

                if (dataTable.Rows.Count == 0)
                    DatabaseAdd("INSERT INTO groups (id_groups, groups_name, groups_namezk) VALUES (" + T[3] + ", '" + T[42] + "', '" + T[43] + "')");

                List<int> Episodes = new List<int>();
                string[] EpisodesO = T[38].Split(',');
                int EpisodesM = -1;

                for (int i = 0; i < EpisodesO.Length; i++)
                {
                    if (T[27].Contains(" - " + EpisodesO[i] + " - "))
                    {
                        EpisodesM = i;
                        break;
                    }
                }

                if (EpisodesM >= 0)
                {
                    int x = 0;

                    try
                    {
                        x = Convert.ToInt32(EpisodesO[EpisodesM]);
                    }
                    catch
                    {
                    }

                    if (x > 0)
                        Episodes.Add(x);
                }

                if (Episodes.Count == 0)
                {
                    for (int i = 0; i < EpisodesO.Length; i++)
                    {
                        string[] Episode = EpisodesO[i].Split('-');

                        int x = 0;
                        int y = 0;

                        try
                        {
                            x = Convert.ToInt32(Episode[0]);
                        }
                        catch
                        {
                        }

                        try
                        {
                            y = Convert.ToInt32(Episode[1]);
                        }
                        catch
                        {
                        }

                        if (y == 0 && x > 0)
                            y = x;

                        if (y != 0 && x != 0)
                            for (int j = x; j <= y; j++)
                                Episodes.Add(j);
                    }
                }

                int LenghtM = Convert.ToInt32(T[24]) / 60;
                int AnimeEpn = 0;

                dataTable = DatabaseSelect("SELECT anime_epn FROM anime WHERE id_anime=" + T[1]);
                if (dataTable.Rows.Count > 0)
                    AnimeEpn = Convert.ToInt32(dataTable.Rows[0]["anime_epn"].ToString());

                for (int i = 0; i < Episodes.Count; i++)
                {
                    if (Episodes[i] > AnimeEpn)
                    {
                        ComunicationNewTask("ANIME aid=" + T[1] + "&amask=BEE0FE01");

                        dataTable = DatabaseSelect("SELECT * FROM episodes WHERE id_anime=" + T[1]);

                        List<string> Epizody = new List<string>();

                        foreach (DataRow row in dataTable.Rows)
                            Epizody.Add(row["episodes_epn"].ToString());

                        for (int j = 1; j <= AnimeEpn; j++)
                            if (!Epizody.Contains(j.ToString()))
                                ComunicationNewTask("EPISODE aid=" + T[1] + "&epno=" + j.ToString());
                    }

                    dataTable = DatabaseSelect("SELECT * FROM episodes WHERE id_episodes=" + T[2] + " AND episodes_epn=" + Episodes[i].ToString());

                    if (dataTable.Rows.Count == 0)
                        DatabaseAdd("INSERT INTO episodes (episodes_epn, episodes_nazeveng, episodes_nazevkan, episodes_nazevjap, id_anime, episodes_spec, id_episodes, episodes_lenght) VALUES (" + Episodes[i].ToString() + ", '" + T[39] + "',  '" + T[41] + "', '" + T[40] + "', " + T[1] + ", '" + EpisodeSpec + "', " + T[2] + ", " + LenghtM + ")");
                    else
                        DatabaseAdd("UPDATE episodes SET episodes_lenght=" + LenghtM + ", episodes_nazeveng='" + T[39] + "', episodes_nazevkan='" + T[41] + "', episodes_nazevjap='" + T[40] + "', id_anime=" + T[1] + ", episodes_spec='" + EpisodeSpec + "' WHERE id_episodes=" + T[2]);
                }

                if (Options_CH01.Checked)
                {
                    int x = 0;

                    try
                    {
                        x = Convert.ToInt32(T[4]);
                    }
                    catch
                    {
                    }

                    string Watched = "0";
                    if (Options_CH02.Checked)
                        Watched = "1";

                    if (x > 0)
                        ComunicationNewTask("MYLISTADD edit=1&fid=" + T[0] + "&source=" + Options_MylistSource.Text + "&storage=" + Options_MylistStorage.Text + "&other=" + Options_MylistOther.Text + "&state=" + Options_MylistState.SelectedIndex.ToString() + "&viewed=" + Watched);
                    else
                        ComunicationNewTask("MYLISTADD edit=0&fid=" + T[0] + "&source=" + Options_MylistSource.Text + "&storage=" + Options_MylistStorage.Text + "&other=" + Options_MylistOther.Text + "&state=" + Options_MylistState.SelectedIndex.ToString() + "&viewed=" + Watched);

                    ComunicationNewTask("MYLIST fid=" + T[0]);
                }

                if (Rules_CH01.Checked)
                {
                    if (!FRename_List.Contains(T[0]))
                    {
                        FRename_List.Add(T[0]);

                        if (!FRename_W.IsBusy)
                            FRename_W.RunWorkerAsync();
                    }
                }
            }
            else
            {
                if (!ComunicationW_Task.Contains("&amask=FEE080C1"))
                    ComunicationNewTask(ComunicationW_Task.Replace("&amask=FEE0F0C1", "&amask=FEE080C1"));

                LogAddError("Input string isn't valid format: " + ComunicationW_DataReceive + ", Array lenght != 45");
            }
        }

        //Informace o epizodách
        private void AniDBParserEpisodes()
        {
            //{int4 eid}|
            //{int4 aid}|
            //{int4 length}|
            //{int4 rating}|
            //{int4 votes}|
            //{str epno}|
            //{str eng}|
            //{str romaji}|
            //{str kanji}|
            //{int4 aired}|
            //{new}
            string[] T = ComunicationW_DataReceive.Split('|');

            if (T.Length == 11)
            {
                string EpisodeSpec = "0";

                if (T[5].Contains("S"))
                {
                    T[5] = T[5].Replace("S", "");
                    EpisodeSpec = "S";
                }
                else if (T[5].Contains("O"))
                {
                    T[5] = T[5].Replace("O", "");
                    EpisodeSpec = "O";
                }
                else if (T[5].Contains("T"))
                {
                    T[5] = T[5].Replace("T", "");
                    EpisodeSpec = "T";
                }
                else if (T[5].Contains("P"))
                {
                    T[5] = T[5].Replace("P", "");
                    EpisodeSpec = "P";
                }
                else if (T[5].Contains("C"))
                {
                    T[5] = T[5].Replace("C", "");
                    EpisodeSpec = "C";
                }

                DataTable dataTable = DatabaseSelect("SELECT * FROM episodes WHERE id_episodes=" + T[0]);
                if (dataTable.Rows.Count > 0)
                    DatabaseAdd("UPDATE episodes SET episodes_spec='" + EpisodeSpec + "', episodes_epn='" + T[5] + "', episodes_nazeveng='" + T[6] + "', episodes_nazevjap='" + T[7] + "', episodes_nazevkan='" + T[8] + "', episodes_lenght=" + T[2] + ", episodes_rating=" + T[3] + ", episodes_votes=" + T[4] + ", episodes_date=#" + DatumFormat(GetDateFromSeconds(T[9])) + "# WHERE id_episodes=" + T[0]);
                else
                {
                    DatabaseAdd("INSERT INTO episodes (id_episodes, id_anime, episodes_epn, episodes_nazeveng, episodes_nazevkan, episodes_nazevjap, episodes_spec, episodes_lenght, episodes_rating, episodes_votes) VALUES (" + T[0] + ", " + T[1] + ", " + T[5] + ", '" + T[6] + "', '" + T[8] + "', '" + T[7] + "', '" + EpisodeSpec + "', " + T[2] + ", '" + T[3] + "', '" + T[4] + "')");
                    DatabaseAdd("UPDATE episodes SET episodes_date=#" + DatumFormat(GetDateFromSeconds(T[9])) + "# WHERE id_episodes=" + T[0]);
                }
            }
            else
                LogAddError("Input string isn't valid format: " + ComunicationW_DataReceive + ", Array lenght != 10");
        }

        //Informace o MyListu
        private void AniDBParserMyListStats()
        {
            //{animes}
            //{eps}
            //{files}
            //{size of files}
            //{added animes}
            //{added eps}
            //{added files}
            //{added groups}
            //{leech %}
            //{glory %}
            //{viewed % of db}
            //{mylist % of db}
            //{viewed % of mylist}
            //{number of viewed eps}
            //{votes}
            //{reviews}
            //{viewed length in minutes}

            string[] T = ComunicationW_DataReceive.Split('|');

            if (T.Length == 17)
            {

                T[3] = FilesSize(T[3]);

                if (T[3].Contains("MB"))
                    T[3] = T[3].Replace("MB", "TB");
                else if (T[3].Contains("kB"))
                    T[3] = T[3].Replace("kB", "GB");
                else
                    T[3] = T[3].Replace("B", "MB");

                DatabaseAdd("UPDATE mylist_anidb SET mylist_anidb_anime='" + T[0] + "', mylist_anidb_epn='" + T[1] + "', mylist_anidb_files='" + T[2] + "', mylist_anidb_filessize='" + T[3] + "', mylist_anidb_addanime='" + T[4] + "', mylist_anidb_addepn='" + T[5] + "', mylist_anidb_addfiles='" + T[6] + "', mylist_anidb_addgroups='" + T[7] + "', mylist_anidb_leech='" + T[8] + "%', mylist_anidb_glory='" + T[9] + "%', mylist_anidb_viewed='" + T[10] + "%', mylist_anidb_mylist='" + T[11] + "%', mylist_anidb_mylistviewed='" + T[12] + "%', mylist_anidb_mylistviewednum='" + T[13] + "', mylist_anidb_votes='" + T[14] + "', mylist_anidb_revies='" + T[15] + "', mylist_anidb_mylistviewedmin='" + T[16] + "' WHERE id_myslist_anidb=1");
            }
            else
                LogAddError("Input string isn't valid format: " + ComunicationW_DataReceive + ", Array lenght != 16");
        }

        //Parsování
        private string Parse(string Radek, string Start, string Cil, bool StartAno)
        {
            Radek = Radek + " ";

            for (int i = 0; i < Radek.Length - Start.Length; i++)
                if (Radek.Substring(i, Start.Length) == Start)
                    if (Radek.Substring(i + Start.Length, Radek.Length - i - Start.Length).Contains(Cil))
                        for (int j = 0; j < Radek.Length - Start.Length - Cil.Length; j++)
                            if (Radek.Substring(i + Start.Length + j, Cil.Length) == Cil)
                            {
                                if (StartAno)
                                    return Radek.Substring(i, j + Start.Length);
                                else
                                    return Radek.Substring(i + Start.Length, j);
                            }

            return "";
        }

        //Získej čas ze sekund
        private DateTime GetDateFromSeconds(string sString)
        {
            DateTime dateTimeReturn = new DateTime(1970, 1, 1, 0, 0, 0);

            try
            {
                if (sString == "")
                    return dateTimeReturn;

                long s = Convert.ToInt64(sString);

                if (s == 0)
                    return dateTimeReturn;

                return dateTimeReturn.AddSeconds(s);
            }
            catch
            {
                return dateTimeReturn;
            }
        }

        //Získej délku videa
        private string GetLenght(string sString)
        {
            if (sString == null)
                return "0s";

            if (sString == "")
                return "0s";

            try
            {
                long s = Convert.ToInt64(sString);

                if (s == 0)
                    return "0s";

                long m = 0;
                long h = 0;
                long d = 0;

                while (s >= 60)
                {
                    s -= 60;
                    m++;
                }

                while (m >= 60)
                {
                    m -= 60;
                    h++;
                }

                while (h >= 24)
                {
                    h -= 24;
                    d++;
                }

                return d.ToString() + "D " + h.ToString() + "H " + m.ToString() + "m " + s.ToString() + "s";
            }
            catch
            {
                return "0s";
            }
        }

        //Převod jednotek
        private string FilesSize(string size)
        {
            if (size == null)
                return "0 B";

            if (size == "")
                return "0 B";

            try
            {
                double x = Convert.ToDouble(size);

                int k = 0;
                while (x > 1024)
                {
                    x /= 1024;
                    k++;
                }

                x = Math.Round((double)x, 2);

                switch (k)
                {
                    case 1:
                        return x.ToString() + " kB";
                    case 2:
                        return x.ToString() + " MB";
                    case 3:
                        return x.ToString() + " GB";
                    case 4:
                        return x.ToString() + " TB";
                    default:
                        return x.ToString() + " B";
                }
            }
            catch
            {
                return "0 B";
            }
        }

        //File State - cen, ...
        private string FilesState(string state)
        {
            string StatusS = "";
            int x = Convert.ToInt32(state);

            if (x == 0)
                return "Not check-v1";

            int[] Status = new int[] { 128, 64, 32, 16, 8, 4, 2, 1 };

            for (int i = 0; i < Status.Length; i++)
            {
                if (x >= Status[i])
                {
                    x -= Status[i];

                    switch (Status[i])
                    {
                        case 128:
                            StatusS += "cen-";
                            break;
                        case 64:
                            StatusS += "unc-";
                            break;
                        case 32:
                            StatusS += "v5-";
                            break;
                        case 16:
                            StatusS += "v4-";
                            break;
                        case 8:
                            StatusS += "v3-";
                            break;
                        case 4:
                            StatusS += "v2-";
                            break;
                        case 2:
                            StatusS += "CRC not match-v1-";
                            break;
                        case 1:
                            StatusS += "CRC match-v1-";
                            break;
                    }
                }
            }

            return StatusS;
        }

        //Cleaner HTML
        private string CleanerHTML(string Input, string start, string end)
        {
            if (Input.Length > 0)
            {
                while (true)
                {
                    string html = Parse(Input, start, end, false);

                    if (html == "")
                        break;
                    else
                        Input = Input.Replace(start + html + end, "");
                }
            }

            return Input;
        }
        #endregion

        #region Rules
        //Zapiš rename
        private void Rules_FilesRulesRenameAdd_Click(object sender, EventArgs e)
        {
            bool Prepis = false;
            if (File.Exists(GlobalAdresar + @"Accounts\!rename\" + Rules_FilesRulesRenameC.Text + ".txt"))
            {
                if (MessageBox.Show(Language.MessageBox_RenameI, Language.MessageBox_Rename, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Prepis = true;
            }
            else
                Prepis = true;

            if (Prepis)
            {
                StreamWriter Zapis = new StreamWriter(GlobalAdresar + @"Accounts\!rename\" + Rules_FilesRulesRenameC.Text + ".txt");
                if (!Rules_FilesRulesRenameC.Items.Contains(Rules_FilesRulesRenameC.Text))
                    Rules_FilesRulesRenameC.Items.Add(Rules_FilesRulesRenameC.Text);
                Zapis.WriteLine(Rules_FilesRulesRename.Text);
                Zapis.Close();
            }
        }

        //Zapiš move
        private void Rules_FilesRulesMoveAdd_Click(object sender, EventArgs e)
        {
            bool Prepis = false;
            if (File.Exists(GlobalAdresar + @"Accounts\!move\" + Rules_FilesRulesMoveC.Text + ".txt"))
            {
                if (MessageBox.Show(Language.MessageBox_RenameI, Language.MessageBox_Rename, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Prepis = true;
            }
            else
                Prepis = true;

            if (Prepis)
            {
                StreamWriter Zapis = new StreamWriter(GlobalAdresar + @"Accounts\!move\" + Rules_FilesRulesMoveC.Text + ".txt");
                if (!Rules_FilesRulesMoveC.Items.Contains(Rules_FilesRulesMoveC.Text))
                    Rules_FilesRulesMoveC.Items.Add(Rules_FilesRulesMoveC.Text);
                Zapis.WriteLine(Rules_FilesRulesMove.Text);
                Zapis.Close();
            }
        }

        //Smaž rename
        private void Rules_FilesRulesRenameDel_Click(object sender, EventArgs e)
        {
            FileDelete(GlobalAdresar + @"Accounts\!rename\" + Rules_FilesRulesRenameC.Text + ".txt");
            Rules_FilesRulesRenameC.Items.Remove(Rules_FilesRulesRenameC.Text);
        }

        //Smaž move
        private void Rules_FilesRulesMoveDel_Click(object sender, EventArgs e)
        {
            FileDelete(GlobalAdresar + @"Accounts\!move\" + Rules_FilesRulesMoveC.Text + ".txt");
            Rules_FilesRulesMoveC.Items.Remove(Rules_FilesRulesMoveC.Text);
        }

        //Čti rename
        private void Rules_FilesRulesRenameC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(GlobalAdresar + @"Accounts\!rename\" + Rules_FilesRulesRenameC.Text + ".txt"))
            {
                StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\!rename\" + Rules_FilesRulesRenameC.Text + ".txt");
                Rules_FilesRulesRename.Text = Cti.ReadToEnd();
                Cti.Close();
            }
        }

        //Čti move
        private void Rules_FilesRulesMoveC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(GlobalAdresar + @"Accounts\!move\" + Rules_FilesRulesMoveC.Text + ".txt"))
            {
                StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\!move\" + Rules_FilesRulesMoveC.Text + ".txt");
                Rules_FilesRulesMove.Text = Cti.ReadToEnd();
                Cti.Close();
            }
        }

        //Aplikování pravidel
        private void Rules_Apply(string DFilesID)
        {
            try
            {
                if (Rules_FilesRulesRename_RB02.Checked && Rules_FilesRulesMove_RB03.Checked)
                {
                }
                else
                {
                    string DSoubor = "N";
                    string DPath = "N";
                    DataTable DFile = DatabaseSelectNoLog("SELECT * FROM files WHERE id_files=" + DFilesID);

                    if (Rules_FilesRulesRename_RB01.Checked)
                        DSoubor = Rules_ParseFiles(DFilesID, true);

                    if (Rules_FilesRulesMove_RB01.Checked || Rules_FilesRulesMove_RB02.Checked)
                        DPath = Rules_ParseFiles(DFilesID, false) + @"\";

                    if (DSoubor != "" && DPath != "" && File.Exists(DFile.Rows[0]["files_localfile"].ToString()))
                    {
                        bool FRename = false;

                        FileInfo Soubor = new FileInfo(DFile.Rows[0]["files_localfile"].ToString());

                        if (DPath == "N")
                            DPath = Soubor.FullName.Replace(Soubor.Name, "");

                        if (DSoubor == "N")
                            DSoubor = Soubor.Name.Replace(Soubor.Extension, "");

                        if (!Directory.Exists(DPath))
                            Directory.CreateDirectory(DPath);

                        DirectoryInfo Adresar = new DirectoryInfo(DPath);

                        if (Rules_CH02.Checked)
                        {
                            if (Adresar.Root.Name == Soubor.Directory.Root.Name)
                                FRename = true;
                            else
                                FRename = false;
                        }
                        else
                            FRename = true;

                        if (Rules_CH03.Checked && FRename)
                        {
                            if (File.Exists(DPath + DSoubor + Soubor.Extension))
                            {
                                FileDelete(DPath + DSoubor + Soubor.Extension);
                                FRename = true;
                            }
                            else
                                FRename = false;
                        }
                        else if (FRename)
                        {
                            if (File.Exists(DPath + DSoubor + Soubor.Extension))
                                FRename = false;
                            else
                                FRename = true;
                        }

                        if (Soubor.FullName != DPath + DSoubor + Soubor.Extension && FRename)
                        {
                            if (Rules_FilesRulesMove_RB01.Checked || Rules_FilesRulesMove_RB03.Checked)
                                File.Move(Soubor.FullName, DPath + DSoubor + Soubor.Extension);

                            if (Rules_FilesRulesMove_RB02.Checked)
                                File.Copy(Soubor.FullName, DPath + DSoubor + Soubor.Extension, true);

                            LogAddError("RENAME > " + Soubor.FullName + " >> " + DPath + DSoubor + Soubor.Extension);

                            DatabaseAdd("UPDATE files SET files_localfile='" + DPath.Replace("'", "''") + DSoubor.Replace("'", "''") + Soubor.Extension + "' WHERE id_files=" + DFilesID);
                        }
                        else
                        {
                            if (!FRename)
                                LogAddError("RENAME ! Rules disabled renaming * " + Soubor.FullName + " >!> " + DPath + DSoubor + Soubor.Extension);

                            if (Soubor.FullName == DPath + DSoubor + Soubor.Extension)
                                LogAddError("RENAME ! New name is same as old name * " + Soubor.FullName + " >!> " + DPath + DSoubor + Soubor.Extension);
                        }

                        if (Rules_CH04.Checked)
                        {
                            string[] T = (Soubor.Directory.FullName).Split('\\');

                            for (int i = T.Length - 1; i > 0; i--)
                            {
                                string AdresarDelUrl = "";
                                for (int j = 0; j <= i; j++)
                                    AdresarDelUrl += T[j] + "\\";

                                DirectoryInfo AdresarDel = new DirectoryInfo(AdresarDelUrl);

                                try
                                {
                                    if (AdresarDel.GetFiles("*", SearchOption.AllDirectories).LongLength == 0)
                                    {
                                        Directory.Delete(AdresarDel.FullName, true);
                                        LogAddError("RENAME ! DELETED DIRECTORY: " + AdresarDel.FullName);
                                    }
                                }
                                catch
                                {
                                    LogAddError("RENAME ! CANT DELETE DIRECTORY: " + AdresarDel.FullName);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (DSoubor == "")
                            LogAddError("RENAME ! File name is null * " + DFile.Rows[0]["files_localfile"].ToString() + " !!! " + DPath + DSoubor);

                        if (DPath == "")
                            LogAddError("RENAME ! File path is null * " + DFile.Rows[0]["files_localfile"].ToString() + " !!! " + DPath + DSoubor);

                        if (!File.Exists(DFile.Rows[0]["files_localfile"].ToString()))
                            LogAddError("RENAME ! File doesnt exist * " + DFile.Rows[0]["files_localfile"].ToString() + " !!! " + DPath + DSoubor);
                    }
                }

                if (Rules_InfoRB01.Checked)
                    Rules_InfoE(DFilesID);
            }
            catch (Exception ee)
            {
                LogAddError("RENAME ! " + ee.Message);
            }
        }

        //Aplikování pravidel pro přejmenování a přesun
        private string Rules_ParseFiles(string DFilesID, bool DFilesB)
        {
            DataTable DFile = DatabaseSelectNoLog("SELECT * FROM files WHERE id_files=" + DFilesID);
            DataTable DAnime = DatabaseSelectNoLog("SELECT * FROM anime WHERE id_anime=" + DFile.Rows[0]["id_anime"].ToString());
            DataTable DEpisode = DatabaseSelectNoLog("SELECT * FROM episodes WHERE id_episodes=" + DFile.Rows[0]["id_episodes"].ToString());
            DataTable DGroup = DatabaseSelectNoLog("SELECT * FROM groups WHERE id_groups=" + DFile.Rows[0]["id_groups"].ToString());
            DataTable DGenres = DatabaseSelectNoLog("SELECT * FROM genres INNER JOIN genres_relations ON genres.id_grenres = genres_relations.id_genres WHERE id_anime=" + DFile.Rows[0]["id_anime"].ToString());

            DFile = Rules_ParseFilesChars(DFile);
            DAnime = Rules_ParseFilesChars(DAnime);
            DEpisode = Rules_ParseFilesChars(DEpisode);
            DGroup = Rules_ParseFilesChars(DGroup);
            DGenres = Rules_ParseFilesChars(DGenres);

            int DepnL = -1;

            switch (Rules_Position.SelectedIndex)
            {
                case 1:
                    int DepnLA = DAnime.Rows[0]["anime_epn"].ToString().Length;
                    int DepnLE = DEpisode.Rows[0]["episodes_epn"].ToString().Length;
                    int DepnLEmax = -1;

                    DataTable DepnMax = DatabaseSelect("SELECT Max(episodes.episodes_epn) FROM episodes GROUP BY episodes.id_anime HAVING (((episodes.id_anime)=" + DAnime.Rows[0]["id_anime"].ToString() + "))");
                    DepnLEmax = DepnMax.Rows[0][0].ToString().Length;

                    if (DepnLEmax > DepnLA)
                        DepnLA = DepnLEmax;

                    if (Rules_Position.SelectedIndex == 2 && DepnLE == 1 && DepnLA < 2)
                        DepnLE = 0;

                    DepnL = DepnLA - DepnLE;
                    break;

                case 3:
                    DepnL = 2 - DEpisode.Rows[0]["episodes_epn"].ToString().Length;
                    break;

                case 4:
                    DepnL = 3 - DEpisode.Rows[0]["episodes_epn"].ToString().Length;
                    break;

                case 5:
                    DepnL = 4 - DEpisode.Rows[0]["episodes_epn"].ToString().Length;
                    break;

                case 6:
                    DepnL = 5 - DEpisode.Rows[0]["episodes_epn"].ToString().Length;
                    break;

                case 7:
                    DepnL = 6 - DEpisode.Rows[0]["episodes_epn"].ToString().Length;
                    break;
            }

            string Drot = new FileInfo(DFile.Rows[0]["files_localfile"].ToString()).Directory.Root.FullName;

            if (DFile.Rows[0]["files_localfile"].ToString().Substring(0, Drot.Length) != Drot)
                Drot = DFile.Rows[0]["files_localfile"].ToString().Substring(0, 3);

            string Depn = "";
            string Dver = "";
            string Dinv = "";
            string Dcen = FilesState(DFile.Rows[0]["files_state"].ToString());

            for (int i = 0; i < DepnL; i++)
                Depn += "0";

            if (DEpisode.Rows[0]["episodes_spec"].ToString() != "0")
                Depn = DEpisode.Rows[0]["episodes_spec"].ToString() + Depn + DEpisode.Rows[0]["episodes_epn"].ToString();
            else
                Depn += DEpisode.Rows[0]["episodes_epn"].ToString();

            if (Dcen.Contains("v5"))
                Dver = "v5";
            else if (Dcen.Contains("v4"))
                Dver = "v4";
            else if (Dcen.Contains("v3"))
                Dver = "v3";
            else if (Dcen.Contains("v2"))
                Dver = "v2";
            else if (Dcen.Contains("v1"))
                Dver = "v1";

            if (Dcen.Contains("CRC not match"))
                Dinv = "CRC not match";

            if (Dcen.Contains("cen"))
                Dcen = "cen";
            else if (Dcen.Contains("unc"))
                Dcen = "unc";
            else
                Dcen = "";

            string[] T;

            if (DFilesB)
                T = Rules_FilesRulesRename.Text.Replace("\r", "").Split('\n');
            else
                T = Rules_FilesRulesMove.Text.Replace("\r", "").Split('\n');

            string Name = "";
            bool Podminka = true;
            bool PodminkaOld = false;
            bool PodminkaFail = false;
            bool PodminkaUsed = false;

            for (int i = 0; i < T.Length; i++)
            {
                string y = Parse(T[i], "'", "'", false);

                for (int j = 0; j < T[i].Length; j++)
                {
                    if (T[i].Substring(0, 2) == "//")
                        break;

                    if (T[i].Length - j > 6 && Podminka)
                        if (T[i].Substring(j, 6) == "DO ADD" || T[i].Substring(j, 6) == "DO SET")
                        {
                            y = y.Replace("%ann", DAnime.Rows[0]["anime_nazevjap"].ToString());
                            y = y.Replace("%kan", DAnime.Rows[0]["anime_nazevkaj"].ToString());
                            y = y.Replace("%eng", DAnime.Rows[0]["anime_nazeveng"].ToString());
                            y = y.Replace("%epn", DEpisode.Rows[0]["episodes_nazeveng"].ToString());
                            y = y.Replace("%epk", DEpisode.Rows[0]["episodes_nazevkan"].ToString());
                            y = y.Replace("%epr", DEpisode.Rows[0]["episodes_nazevjap"].ToString());
                            y = y.Replace("%enr", Depn);
                            y = y.Replace("%ent", DEpisode.Rows[0]["episodes_spec"].ToString());
                            y = y.Replace("%grp", DGroup.Rows[0]["groups_namezk"].ToString());
                            y = y.Replace("%ed2", DFile.Rows[0]["files_ed2k"].ToString().ToLower());
                            y = y.Replace("%ED2", DFile.Rows[0]["files_ed2k"].ToString().ToUpper());
                            y = y.Replace("%md5", DFile.Rows[0]["files_md5"].ToString().ToLower());
                            y = y.Replace("%MD5", DFile.Rows[0]["files_md5"].ToString().ToUpper());
                            y = y.Replace("%sha", DFile.Rows[0]["files_sha1"].ToString().ToLower());
                            y = y.Replace("%SHA", DFile.Rows[0]["files_sha1"].ToString().ToUpper());
                            y = y.Replace("%crc", DFile.Rows[0]["files_crc32"].ToString().ToLower());
                            y = y.Replace("%CRC", DFile.Rows[0]["files_crc32"].ToString().ToUpper());
                            y = y.Replace("%ver", Dver);
                            y = y.Replace("%inv", Dinv);
                            y = y.Replace("%cen", Dcen);
                            y = y.Replace("%dub", DFile.Rows[0]["files_dub"].ToString());
                            y = y.Replace("%sub", DFile.Rows[0]["files_sub"].ToString());
                            y = y.Replace("%vid", DFile.Rows[0]["files_video"].ToString());
                            y = y.Replace("%aud", DFile.Rows[0]["files_audio"].ToString());
                            y = y.Replace("%qua", DFile.Rows[0]["files_quality"].ToString());
                            y = y.Replace("%src", DFile.Rows[0]["files_typ"].ToString());
                            y = y.Replace("%res", DFile.Rows[0]["files_resultion"].ToString());
                            y = y.Replace("%yea", DAnime.Rows[0]["anime_rok"].ToString().Split('-')[0]);
                            y = y.Replace("%eps", DAnime.Rows[0]["anime_epn"].ToString());
                            y = y.Replace("%typ", DAnime.Rows[0]["anime_typ"].ToString());
                            y = y.Replace("%gen", DFile.Rows[0]["files_typ"].ToString());
                            y = y.Replace("%fid", DFile.Rows[0]["id_files"].ToString());
                            y = y.Replace("%aid", DAnime.Rows[0]["id_anime"].ToString());
                            y = y.Replace("%eid", DEpisode.Rows[0]["id_episodes"].ToString());
                            y = y.Replace("%gid", DGroup.Rows[0]["id_groups"].ToString());
                            y = y.Replace("%ani", DFile.Rows[0]["files_anidb_name"].ToString());
                            y = y.Replace("%dsk", Drot);
                            y = y.Replace("%dpt", DFile.Rows[0]["files_depth"].ToString());


                            if (T[i].Substring(j, 6) == "DO ADD")
                                Name += y;
                            else
                                Name = y;
                        }

                    if (T[i].Length - j > 7 && !PodminkaUsed)
                        if (T[i].Substring(j, 7) == "ELSE IF")
                        {
                            if (PodminkaOld)
                            {
                                Podminka = true;
                                break;
                            }

                            List<bool> Podminka2 = new List<bool>();
                            bool Podminka3 = false;
                            int k = 0;

                            while (true)
                            {
                                Podminka = Rules_ParseFilesPodminka(T[i], DFile, DAnime, DEpisode, DGroup, DGenres, Dcen, Dver, Dinv);

                                Podminka2.Add(Podminka);

                                string z = Parse(T[i], "(", ")", false);
                                T[i] = T[i].Replace("(" + z + ")", "");
                                T[i] = T[i].Replace("IF ", "");
                                T[i] = T[i].Replace("ELSE ", "");

                                if (4 + j < T[i].Length)
                                {
                                    if (T[i].Substring(1 + k, 1) == ";")
                                        Podminka3 = true;
                                    else if (T[i].Substring(1 + k, 1) == ",")
                                        Podminka3 = false;
                                    else
                                        break;

                                    T[i] = T[i].Remove(1 + k, 1);
                                }
                                else
                                    break;

                                k++;
                            }

                            if (Podminka2.Count > 1)
                            {
                                if (Podminka3)
                                {
                                    for (int l = 0; l <= k; l++)
                                        if (!Podminka2[l])
                                            Podminka = false;
                                }
                                else
                                    if (Podminka2.Contains(true))
                                        Podminka = true;
                                    else
                                        Podminka = false;
                            }

                            PodminkaUsed = true;
                        }

                    if (T[i].Length - j > 2 && !PodminkaUsed)
                        if (T[i].Substring(j, 2) == "IF")
                        {
                            List<bool> Podminka2 = new List<bool>();
                            bool Podminka3 = false;
                            int k = 0;

                            while (true)
                            {
                                Podminka = Rules_ParseFilesPodminka(T[i], DFile, DAnime, DEpisode, DGroup, DGenres, Dcen, Dver, Dinv);

                                Podminka2.Add(Podminka);

                                string z = Parse(T[i], "(", ")", false);
                                T[i] = T[i].Replace("(" + z + ")", "");
                                T[i] = T[i].Replace("IF ", "");
                                T[i] = T[i].Replace("ELSE ", "");

                                if (4 + j < T[i].Length)
                                {
                                    if (T[i].Substring(1 + k, 1) == ";")
                                        Podminka3 = true;
                                    else if (T[i].Substring(1 + k, 1) == ",")
                                        Podminka3 = false;
                                    else
                                        break;

                                    T[i] = T[i].Remove(1 + k, 1);
                                }
                                else
                                    break;

                                k++;
                            }

                            if (Podminka2.Count > 1)
                            {
                                if (Podminka3)
                                {
                                    for (int l = 0; l <= k; l++)
                                        if (!Podminka2[l])
                                            Podminka = false;
                                }
                                else
                                    if (Podminka2.Contains(true))
                                        Podminka = true;
                                    else
                                        Podminka = false;
                            }

                            PodminkaUsed = true;
                        }

                    if (T[i].Length - j > 4 && !PodminkaUsed)
                        if (T[i].Substring(j, 4) == "ELSE" && !PodminkaOld && i > 0)
                        {
                            Podminka = true;
                        }
                        else if (T[i].Substring(j, 4) == "ELSE" && PodminkaOld && i > 0)
                        {
                            Podminka = false;
                            break;
                        }

                    if (T[i].Length - j > 5 && Podminka)
                        if (T[i].Substring(j, 6) == "FINISH")
                        {
                            PodminkaFail = true;
                            break;
                        }

                    if (T[i].Length - j > 3 && Podminka)
                        if (T[i].Substring(j, 4) == "FAIL")
                        {
                            Name = "";
                            PodminkaFail = true;
                            break;
                        }

                    if (T[i].Length - j > 3 && Podminka)
                        if (T[i].Substring(j, 3) == "M(\"")
                        {
                            string ReplaceOld = Parse(T[i], "(\"", "\", ", false);
                            T[i] = T[i].Replace("(\"" + ReplaceOld + "\", ", "");
                            string ReplaceNew = Parse(T[i], "\"", "\")", false);

                            Name = Name.Replace(ReplaceOld, ReplaceNew);
                        }

                    if (T[i].Length - j > 3 && Podminka)
                        if (T[i].Substring(j, 2) == "L(")
                        {
                            string xs = Parse(T[i], "(", ")", false);
                            int x = 0;

                            try
                            {
                                x = Convert.ToInt32(xs);
                            }
                            catch
                            {
                            }

                            if (x > 0 && Name.Length > x)
                                Name = Name.Remove(Name.Length - x, x);
                        }

                    if (T[i].Length - j > 3 && Podminka)
                        if (T[i].Substring(j, 2) == "U(")
                        {
                            string xs = Parse(T[i], "(", ")", false);
                            string[] xT = xs.Split(':');

                            if (xT.Length == 2 || xT.Length == 3)
                            {
                                int xstart = 0;
                                int xend = 0;

                                if (xT.Length == 2)
                                {
                                    try { xend = Convert.ToInt32(xT[1]); }
                                    catch { }
                                }

                                if (xT.Length == 3)
                                {
                                    try { xstart = Convert.ToInt32(xT[1]); }
                                    catch { }
                                    try { xend = Convert.ToInt32(xT[2]); }
                                    catch { }
                                }

                                switch (xT[0])
                                {
                                    case "ann":
                                        if (xend <= 0 || xend > DAnime.Rows[0]["anime_nazevjap"].ToString().Length)
                                            xend = DAnime.Rows[0]["anime_nazevjap"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DAnime.Rows[0]["anime_nazevjap"].ToString().Length)
                                            Name += DAnime.Rows[0]["anime_nazevjap"].ToString().Substring(xstart, xend);
                                        break;

                                    case "kan":
                                        if (xend <= 0 || xend > DAnime.Rows[0]["anime_nazevkaj"].ToString().Length)
                                            xend = DAnime.Rows[0]["anime_nazevkaj"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DAnime.Rows[0]["anime_nazevkaj"].ToString().Length)
                                            Name += DAnime.Rows[0]["anime_nazevkaj"].ToString().Substring(xstart, xend);
                                        break;

                                    case "eng":
                                        if (xend <= 0 || xend > DAnime.Rows[0]["anime_nazeveng"].ToString().Length)
                                            xend = DAnime.Rows[0]["anime_nazeveng"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DAnime.Rows[0]["anime_nazeveng"].ToString().Length)
                                            Name += DAnime.Rows[0]["anime_nazeveng"].ToString().Substring(xstart, xend);
                                        break;

                                    case "epn":
                                        if (xend <= 0 || xend > DEpisode.Rows[0]["episodes_nazeveng"].ToString().Length)
                                            xend = DEpisode.Rows[0]["episodes_nazeveng"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DEpisode.Rows[0]["episodes_nazeveng"].ToString().Length)
                                            Name += DEpisode.Rows[0]["episodes_nazeveng"].ToString().Substring(xstart, xend);
                                        break;

                                    case "epk":
                                        if (xend <= 0 || xend > DEpisode.Rows[0]["episodes_nazevkan"].ToString().Length)
                                            xend = DEpisode.Rows[0]["episodes_nazevkan"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DEpisode.Rows[0]["episodes_nazevkan"].ToString().Length)
                                            Name += DEpisode.Rows[0]["episodes_nazevkan"].ToString().Substring(xstart, xend);
                                        break;

                                    case "epr":
                                        if (xend <= 0 || xend > DEpisode.Rows[0]["episodes_nazevjap"].ToString().Length)
                                            xend = DEpisode.Rows[0]["episodes_nazevjap"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DEpisode.Rows[0]["episodes_nazevjap"].ToString().Length)
                                            Name += DEpisode.Rows[0]["episodes_nazevjap"].ToString().Substring(xstart, xend);
                                        break;

                                    case "grp":
                                        if (xend <= 0 || xend > DGroup.Rows[0]["groups_namezk"].ToString().Length)
                                            xend = DGroup.Rows[0]["groups_namezk"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DGroup.Rows[0]["groups_namezk"].ToString().Length)
                                            Name += DGroup.Rows[0]["groups_namezk"].ToString().Substring(xstart, xend);
                                        break;

                                    case "dub":
                                        if (xend <= 0 || xend > DFile.Rows[0]["files_dub"].ToString().Length)
                                            xend = DFile.Rows[0]["files_dub"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DFile.Rows[0]["files_dub"].ToString().Length)
                                            Name += DFile.Rows[0]["files_dub"].ToString().Substring(xstart, xend);
                                        break;

                                    case "sub":
                                        if (xend <= 0 || xend > DFile.Rows[0]["files_sub"].ToString().Length)
                                            xend = DFile.Rows[0]["files_sub"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DFile.Rows[0]["files_sub"].ToString().Length)
                                            Name += DFile.Rows[0]["files_sub"].ToString().Substring(xstart, xend);
                                        break;

                                    case "aud":
                                        if (xend <= 0 || xend > DFile.Rows[0]["files_audio"].ToString().Length)
                                            xend = DFile.Rows[0]["files_audio"].ToString().Length;

                                        xend = xend - xstart;

                                        if (xend > 0 && xend + xstart <= DFile.Rows[0]["files_audio"].ToString().Length)
                                            Name += DFile.Rows[0]["files_audio"].ToString().Substring(xstart, xend);
                                        break;
                                }
                            }
                        }
                }

                PodminkaUsed = false;

                if (PodminkaFail)
                    break;

                PodminkaOld = Podminka;

                Podminka = true;
            }

            return Name;
        }

        //Parsování podmínky
        private bool Rules_ParseFilesPodminka(string Radek, DataTable DFile, DataTable DAnime, DataTable DEpisode, DataTable DGroup, DataTable DGenres, string Dcen, string Dver, string Dinv)
        {
            bool Podminka = true;
            string z = Parse(Radek, "(", ")", false);

            int k = Radek.IndexOf("(" + z + ")");

            string r = "";

            if (k >= 0)
                r = Radek.Substring(k - 1, 1);

            switch (r)
            {
                #region W
                case "W":
                    try
                    {
                        string Negace = null;
                        if (z.Substring(0, 1) == "!")
                        {
                            z = z.Remove(0, 1);
                            Negace = "!";
                        }
                        else if (z.Substring(0, 1) == "<")
                        {
                            z = z.Remove(0, 1);
                            Negace = "<";
                        }
                        else if (z.Substring(0, 1) == ">")
                        {
                            z = z.Remove(0, 1);
                            Negace = ">";
                        }

                        int x = 0;
                        int y = 0;

                        try
                        {
                            x = Convert.ToInt32(z);
                        }
                        catch
                        {
                        }

                        try
                        {
                            y = Convert.ToInt32(DAnime.Rows[0]["anime_epn"].ToString());
                        }
                        catch
                        {
                        }

                        switch (Negace)
                        {
                            case "!":
                                if (x != y)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;

                            case "<":
                                if (x > y)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;

                            case ">":
                                if (x < y)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;

                            default:
                                if (x == y)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;

                        }
                    }
                    catch
                    {
                    }
                    break;
                #endregion

                #region A
                case "A":
                    try
                    {
                        bool Negace = false;
                        if (z.Substring(0, 1) == "!")
                        {
                            z = z.Remove(0, 1);
                            Negace = true;
                        }
                        MatchCollection matches1 = Regex.Matches(DAnime.Rows[0]["anime_nazeveng"].ToString(), z);
                        MatchCollection matches2 = Regex.Matches(DAnime.Rows[0]["anime_nazevkan"].ToString(), z);
                        MatchCollection matches3 = Regex.Matches(DAnime.Rows[0]["anime_nazevjap"].ToString(), z);
                        MatchCollection matches4 = Regex.Matches(DAnime.Rows[0]["id_anime"].ToString(), z);

                        if (matches1.Count > 0 || matches2.Count > 0 || matches3.Count > 0 || matches4.Count > 0)
                            Podminka = true;
                        else
                            Podminka = false;

                        if (Negace && Podminka)
                            Podminka = false;
                        else if (Negace && !Podminka)
                            Podminka = true;
                    }
                    catch
                    {
                    }
                    break;
                #endregion

                #region G
                case "G":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        if (z.Contains("unknown") && DGroup.Rows[0]["groups_namezk"].ToString().Length != 0)
                            Podminka = true;
                        else if (DGroup.Rows[0]["groups_namezk"].ToString() != z)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        if (z.Contains("unknown") && DGroup.Rows[0]["groups_namezk"].ToString().Length == 0)
                            Podminka = true;
                        else if (DGroup.Rows[0]["groups_namezk"].ToString() == z.Replace("!", ""))
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region E
                case "E":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        MatchCollection matches1 = Regex.Matches(DEpisode.Rows[0]["episodes_nazeveng"].ToString(), z);
                        MatchCollection matches2 = Regex.Matches(DEpisode.Rows[0]["episodes_nazevkan"].ToString(), z);
                        MatchCollection matches3 = Regex.Matches(DEpisode.Rows[0]["episodes_nazevjap"].ToString(), z);

                        if (DEpisode.Rows[0]["episodes_spec"].ToString() == "0" && matches1.Count == 0 && matches2.Count == 0 && matches3.Count == 0)
                        {
                            if (DEpisode.Rows[0]["episodes_epn"].ToString() != z)
                                Podminka = true;
                            else
                                Podminka = false;
                        }
                        else
                        {
                            if (DEpisode.Rows[0]["episodes_spec"].ToString() + DEpisode.Rows[0]["episodes_epn"].ToString() != z && matches1.Count == 0 && matches2.Count == 0 && matches3.Count == 0)
                                Podminka = true;
                            else
                                Podminka = false;
                        }
                    }
                    else
                    {
                        MatchCollection matches1 = Regex.Matches(DEpisode.Rows[0]["episodes_nazeveng"].ToString(), z);
                        MatchCollection matches2 = Regex.Matches(DEpisode.Rows[0]["episodes_nazevkan"].ToString(), z);
                        MatchCollection matches3 = Regex.Matches(DEpisode.Rows[0]["episodes_nazevjap"].ToString(), z);

                        if (DEpisode.Rows[0]["episodes_spec"].ToString() == "0")
                        {
                            if (DEpisode.Rows[0]["episodes_epn"].ToString() == z || matches1.Count > 0 || matches2.Count > 0 || matches3.Count > 0)
                                Podminka = true;
                            else
                                Podminka = false;
                        }
                        else
                        {
                            if (DEpisode.Rows[0]["episodes_spec"].ToString() + DEpisode.Rows[0]["episodes_epn"].ToString() == z || matches1.Count > 0 || matches2.Count > 0 || matches3.Count > 0)
                                Podminka = true;
                            else
                                Podminka = false;
                        }
                    }
                    break;
                #endregion

                #region Q
                case "Q":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);
                        if (DFile.Rows[0]["files_quality"].ToString().Length == 0 && z.ToLower().Contains("unknown"))
                            Podminka = false;
                        else if (DFile.Rows[0]["files_quality"].ToString().ToLower() != z.ToLower())
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        if (DFile.Rows[0]["files_quality"].ToString().Length == 0 && z.ToLower().Contains("unknown"))
                            Podminka = true;
                        if (DFile.Rows[0]["files_quality"].ToString().ToLower() == z.ToLower())
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region R
                case "R":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        if (DFile.Rows[0]["files_typ"].ToString().Length == 0 && z.ToLower().Contains("unknown"))
                            Podminka = false;
                        else if (DFile.Rows[0]["files_typ"].ToString().ToLower() != z.ToLower())
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        if (DFile.Rows[0]["files_typ"].ToString().Length == 0 && z.ToLower().Contains("unknown"))
                            Podminka = true;
                        if (DFile.Rows[0]["files_typ"].ToString().ToLower() == z.ToLower())
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region T
                case "T":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        if (DAnime.Rows[0]["anime_typ"].ToString().Length != 0 && z.ToLower().Contains("unknown"))
                            Podminka = false;
                        else if (DAnime.Rows[0]["anime_typ"].ToString().ToLower() != z.ToLower())
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        if (DAnime.Rows[0]["anime_typ"].ToString().Length == 0 && z.ToLower().Contains("unknown"))
                            Podminka = true;
                        if (DAnime.Rows[0]["anime_typ"].ToString().ToLower() == z.ToLower())
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region Y
                case "Y":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        if (DAnime.Rows[0]["anime_rok"].ToString().Split('-')[0] != z)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else if (z.Substring(0, 1) == "<")
                    {
                        int x = 0;
                        int y = 0;

                        try
                        {
                            x = Convert.ToInt32(z);
                        }
                        catch
                        {
                            x = 0;
                        }

                        try
                        {
                            y = Convert.ToInt32(DAnime.Rows[0]["anime_rok"].ToString().Split('-')[0]);
                        }
                        catch
                        {
                            y = 0;
                        }

                        if (y < x)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else if (z.Substring(0, 1) == ">")
                    {
                        int x = 0;
                        int y = 0;

                        try
                        {
                            x = Convert.ToInt32(z);
                        }
                        catch
                        {
                            x = 0;
                        }

                        try
                        {
                            y = Convert.ToInt32(DAnime.Rows[0]["anime_rok"].ToString().Split('-')[0]);
                        }
                        catch
                        {
                            y = 0;
                        }

                        if (y > x)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        if (DAnime.Rows[0]["anime_rok"].ToString().Split('-')[0] == z)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region D
                case "D":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        MatchCollection matches1 = Regex.Matches(DAnime.Rows[0]["files_dub"].ToString(), z);

                        if (matches1.Count == 0)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        MatchCollection matches1 = Regex.Matches(DAnime.Rows[0]["files_dub"].ToString(), z);

                        if (matches1.Count > 0)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region S
                case "S":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        MatchCollection matches1 = Regex.Matches(DFile.Rows[0]["files_sub"].ToString(), z);

                        if (matches1.Count == 0)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        MatchCollection matches1 = Regex.Matches(DFile.Rows[0]["files_sub"].ToString(), z);

                        if (matches1.Count > 0)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region P
                case "P":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        MatchCollection matches1 = Regex.Matches(DFile.Rows[0]["files_localfile"].ToString(), z);

                        if (matches1.Count == 0)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        MatchCollection matches1 = Regex.Matches(DFile.Rows[0]["files_localfile"].ToString(), z);

                        if (matches1.Count > 0)
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region N
                case "N":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        Podminka = true;

                        foreach (DataRow GRow in DGenres.Rows)
                            if (GRow["genres_genre"].ToString().ToLower().Contains(z.ToLower()))
                            {
                                Podminka = false;
                                break;
                            }
                    }
                    else
                    {
                        Podminka = false;

                        foreach (DataRow GRow in DGenres.Rows)
                            if (GRow["genres_genre"].ToString().ToLower().Contains(z.ToLower()))
                            {
                                Podminka = true;
                                break;
                            }
                    }
                    break;
                #endregion

                #region I
                case "I":
                    try
                    {
                        bool Negace = false;
                        string p = "";

                        if (z.Substring(0, 1) == "!")
                        {
                            z = z.Remove(0, 1);

                            Negace = true;
                        }

                        if (z.Contains("=\""))
                            p = Parse(z, "=\"", "\"", false);

                        z = z.Replace("=\"" + p + "\"", "");

                        switch (z)
                        {
                            case "ann":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DAnime, "anime_nazevjap", p);
                                else if (DAnime.Rows[0]["anime_nazevjap"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "kan":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DAnime, "anime_nazevkaj", p);
                                else if (DAnime.Rows[0]["anime_nazevkaj"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "eng":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DAnime, "anime_nazeveng", p);
                                else if (DAnime.Rows[0]["anime_nazeveng"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "epn":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DEpisode, "episodes_nazeveng", p);
                                else if (DEpisode.Rows[0]["episodes_nazeveng"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "epk":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DEpisode, "episodes_nazevkan", p);
                                else if (DEpisode.Rows[0]["episodes_nazevkan"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "epr":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DEpisode, "episodes_nazevjap", p);
                                else if (DEpisode.Rows[0]["episodes_nazevjap"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "enr":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DEpisode, "episodes_epn", p);
                                else if (DEpisode.Rows[0]["episodes_epn"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "ent":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DEpisode, "episodes_spec", p);
                                else if (DEpisode.Rows[0]["episodes_spec"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "grp":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DGroup, "groups_namezk", p);
                                else if (DGroup.Rows[0]["groups_namezk"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "ed2":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_ed2k", p);
                                else if (DFile.Rows[0]["files_ed2k"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "md5":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_md5", p);
                                else if (DFile.Rows[0]["files_md5"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "sha":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_sha1", p);
                                else if (DFile.Rows[0]["files_sha1"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "crc":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_crc32", p);
                                else if (DFile.Rows[0]["files_crc32"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "cen":
                                if (p.Length > 0)
                                {
                                    MatchCollection matches1 = Regex.Matches(Dcen, p);

                                    if (matches1.Count > 0)
                                        Podminka = true;
                                    else
                                        Podminka = false;
                                }
                                else if (Dcen.Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "inv":
                                if (p.Length > 0)
                                {
                                    MatchCollection matches1 = Regex.Matches(Dinv, p);

                                    if (matches1.Count > 0)
                                        Podminka = true;
                                    else
                                        Podminka = false;
                                }
                                else if (Dinv.Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "ver":
                                if (p.Length > 0)
                                {
                                    MatchCollection matches1 = Regex.Matches(Dver, p);

                                    if (matches1.Count > 0)
                                        Podminka = true;
                                    else
                                        Podminka = false;
                                }
                                else if (Dver.Length > 0 && Dver != "v1")
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "dub":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_dub", p);
                                else if (DFile.Rows[0]["files_dub"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "sub":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_sub", p);
                                else if (DFile.Rows[0]["files_sub"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "vid":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_video", p);
                                else if (DFile.Rows[0]["files_video"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "aud":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_audio", p);
                                else if (DFile.Rows[0]["files_audio"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "qua":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_quality", p);
                                else if (DFile.Rows[0]["files_quality"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "src":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_typ", p);
                                else if (DFile.Rows[0]["files_typ"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "res":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_resultion", p);
                                else if (DFile.Rows[0]["files_resultion"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "yea":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DAnime, "anime_rok", p);
                                else if (DAnime.Rows[0]["anime_rok"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "eps":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DAnime, "anime_epn", p);
                                else if (DAnime.Rows[0]["anime_epn"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "typ":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DAnime, "anime_typ", p);
                                else if (DAnime.Rows[0]["anime_typ"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "gen":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_typ", p);
                                else if (DFile.Rows[0]["files_typ"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "fid":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "id_files", p);
                                else if (DFile.Rows[0]["id_files"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "aid":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DAnime, "id_anime", p);
                                else if (DAnime.Rows[0]["id_anime"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "eid":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DEpisode, "id_episodes", p);
                                else if (DEpisode.Rows[0]["id_episodes"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "gid":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DGroup, "id_groups", p);
                                else if (DGroup.Rows[0]["id_groups"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                            case "dpt":
                                if (p.Length > 0)
                                    Podminka = Rules_ParseFilesPodminkaIParser(DFile, "files_depth", p);
                                else if (DFile.Rows[0]["files_depth"].ToString().Length > 0)
                                    Podminka = true;
                                else
                                    Podminka = false;
                                break;
                        }

                        if (Negace && Podminka)
                            Podminka = false;
                        else if (Negace && !Podminka)
                            Podminka = true;
                    }
                    catch
                    {
                    }

                    break;
                #endregion

                #region H
                case "H":
                    try
                    {
                        bool Negace = false;

                        if (z.Substring(0, 1) == "!")
                        {
                            z = z.Remove(0, 1);

                            Negace = true;
                        }

                        string[] T = z.Split('=');

                        if (T.Length > 1)
                        {
                            for (int i = 0; i < T.Length; i++)
                            {
                                switch (T[i])
                                {
                                    case "ann":
                                        T[i] = DAnime.Rows[0]["anime_nazevjap"].ToString();
                                        break;
                                    case "kan":
                                        T[i] = DAnime.Rows[0]["anime_nazevkaj"].ToString();
                                        break;
                                    case "eng":
                                        T[i] = DAnime.Rows[0]["anime_nazeveng"].ToString();
                                        break;
                                    case "epn":
                                        T[i] = DEpisode.Rows[0]["episodes_nazeveng"].ToString();
                                        break;
                                    case "epk":
                                        T[i] = DEpisode.Rows[0]["episodes_nazevkan"].ToString();
                                        break;
                                    case "epr":
                                        T[i] = DEpisode.Rows[0]["episodes_nazevjap"].ToString();
                                        break;
                                    case "enr":
                                        T[i] = DEpisode.Rows[0]["episodes_epn"].ToString();
                                        break;
                                    case "ent":
                                        T[i] = DEpisode.Rows[0]["episodes_spec"].ToString();
                                        break;
                                    case "grp":
                                        T[i] = DGroup.Rows[0]["groups_namezk"].ToString();
                                        break;
                                    case "ed2":
                                        T[i] = DFile.Rows[0]["files_ed2k"].ToString();
                                        break;
                                    case "md5":
                                        T[i] = DFile.Rows[0]["files_md5"].ToString();
                                        break;
                                    case "sha":
                                        T[i] = DFile.Rows[0]["files_sha1"].ToString();
                                        break;
                                    case "crc":
                                        T[i] = DFile.Rows[0]["files_crc32"].ToString();
                                        break;
                                    case "cen":
                                        T[i] = Dcen;
                                        break;
                                    case "inv":
                                        T[i] = Dinv;
                                        break;
                                    case "ver":
                                        T[i] = Dver;
                                        break;
                                    case "dub":
                                        T[i] = DFile.Rows[0]["files_dub"].ToString();
                                        break;
                                    case "sub":
                                        T[i] = DFile.Rows[0]["files_sub"].ToString();
                                        break;
                                    case "vid":
                                        T[i] = DFile.Rows[0]["files_video"].ToString();
                                        break;
                                    case "aud":
                                        T[i] = DFile.Rows[0]["files_audio"].ToString();
                                        break;
                                    case "qua":
                                        T[i] = DFile.Rows[0]["files_quality"].ToString();
                                        break;
                                    case "src":
                                        T[i] = DFile.Rows[0]["files_typ"].ToString();
                                        break;
                                    case "res":
                                        T[i] = DFile.Rows[0]["files_resultion"].ToString();
                                        break;
                                    case "yea":
                                        T[i] = DAnime.Rows[0]["anime_rok"].ToString();
                                        break;
                                    case "eps":
                                        T[i] = DAnime.Rows[0]["anime_epn"].ToString();
                                        break;
                                    case "typ":
                                        T[i] = DAnime.Rows[0]["anime_typ"].ToString();
                                        break;
                                    case "gen":
                                        T[i] = DFile.Rows[0]["files_typ"].ToString();
                                        break;
                                    case "fid":
                                        T[i] = DFile.Rows[0]["id_files"].ToString();
                                        break;
                                    case "aid":
                                        T[i] = DFile.Rows[0]["id_anime"].ToString();
                                        break;
                                    case "eid":
                                        T[i] = DFile.Rows[0]["id_episodes"].ToString();
                                        break;
                                    case "gid":
                                        T[i] = DFile.Rows[0]["id_groups"].ToString();
                                        break;
                                    case "dpt":
                                        T[i] = DFile.Rows[0]["files_depth"].ToString();
                                        break;
                                }
                            }

                            for (int i = 0; i < T.Length - 1; i++)
                            {
                                if (T[i] == T[i + 1])
                                    Podminka = true;
                                else
                                {
                                    Podminka = false;
                                    break;
                                }
                            }
                        }


                        if (Negace && Podminka)
                            Podminka = false;
                        else if (Negace && !Podminka)
                            Podminka = true;
                    }
                    catch
                    {
                    }

                    break;
                #endregion

                #region C
                case "C":
                    if (z.Substring(0, 1) == "!")
                    {
                        z = z.Remove(0, 1);

                        if (!DFile.Rows[0]["files_audio"].ToString().Contains(z) &&
                        !DFile.Rows[0]["files_video"].ToString().Contains(z))
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    else
                    {
                        if (DFile.Rows[0]["files_audio"].ToString().Contains(z) &&
                        DFile.Rows[0]["files_video"].ToString().Contains(z))
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion

                #region 8
                case "8":
                    if (z.Length > 0)
                    {
                        if (z.Substring(0, 1) == "!")
                        {
                            z = z.Remove(0, 1);

                            if (DAnime.Rows[0]["anime_18"].ToString() != "1")
                                Podminka = true;
                            else
                                Podminka = false;
                        }
                    }
                    else
                    {
                        if (DAnime.Rows[0]["anime_18"].ToString() == "1")
                            Podminka = true;
                        else
                            Podminka = false;
                    }
                    break;
                #endregion
            }

            return Podminka;
        }

        //Parsování podmínky pro tag I
        private bool Rules_ParseFilesPodminkaIParser(DataTable x, string q, string p)
        {
            MatchCollection matches1 = Regex.Matches(x.Rows[0][q].ToString(), p);

            if (matches1.Count > 0)
                return true;
            else
                return false;
        }

        //Odstranění nechtěných znaků
        private DataTable Rules_ParseFilesChars(DataTable DT)
        {
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                for (int j = 0; j < DT.Columns.Count; j++)
                {
                    for (int l = 0; l < Rules_Replace.Rows.Count; l++)
                    {
                        try
                        {
                            if (DT.Columns[j].ColumnName != "files_localfile")
                                DT.Rows[i][j] = DT.Rows[i][j].ToString().Replace(Rules_Replace[0, l].Value.ToString(), Rules_Replace[1, l].Value.ToString());
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return DT;
        }

        //Export informací
        private void Rules_InfoE(string DFilesID)
        {
            DataTable DFile = DatabaseSelectNoLog("SELECT * FROM files WHERE id_files=" + DFilesID);

            FileInfo Soubor = new FileInfo(DFile.Rows[0]["files_localfile"].ToString());
            if (Soubor.Exists)
            {
                DataTable DAnime = DatabaseSelectNoLog("SELECT * FROM anime WHERE id_anime=" + DFile.Rows[0]["id_anime"].ToString());
                DataTable DEpisode = DatabaseSelectNoLog("SELECT * FROM episodes WHERE id_episodes=" + DFile.Rows[0]["id_episodes"].ToString());
                DataTable DGroup = DatabaseSelectNoLog("SELECT * FROM groups WHERE id_groups=" + DFile.Rows[0]["id_groups"].ToString());
                DataTable DGenres = DatabaseSelectNoLog("SELECT * FROM genres INNER JOIN genres_relations ON genres.id_grenres = genres_relations.id_genres WHERE id_anime=" + DFile.Rows[0]["id_anime"].ToString());

                string Drot = new FileInfo(DFile.Rows[0]["files_localfile"].ToString()).Directory.Root.FullName;
                string Depn = "";
                string Dver = "";
                string Dinv = "";
                string Dcen = FilesState(DFile.Rows[0]["files_state"].ToString());

                if (DEpisode.Rows[0]["episodes_spec"].ToString() != "0")
                    Depn = DEpisode.Rows[0]["episodes_spec"].ToString() + Depn + DEpisode.Rows[0]["episodes_epn"].ToString();
                else
                    Depn += DEpisode.Rows[0]["episodes_epn"].ToString();

                if (Dcen.Contains("v5"))
                    Dver = "v5";
                else if (Dcen.Contains("v4"))
                    Dver = "v4";
                else if (Dcen.Contains("v3"))
                    Dver = "v3";
                else if (Dcen.Contains("v2"))
                    Dver = "v2";
                else if (Dcen.Contains("v1"))
                    Dver = "v1";

                if (Dcen.Contains("CRC not match"))
                    Dinv = "CRC not match";

                if (Dcen.Contains("cen"))
                    Dcen = "cen";
                else if (Dcen.Contains("unc"))
                    Dcen = "unc";
                else
                    Dcen = "";

                string y = Rules_Info.Text;

                y = y.Replace("%ann", DAnime.Rows[0]["anime_nazevjap"].ToString());
                y = y.Replace("%kan", DAnime.Rows[0]["anime_nazevkaj"].ToString());
                y = y.Replace("%eng", DAnime.Rows[0]["anime_nazeveng"].ToString());
                y = y.Replace("%epn", DEpisode.Rows[0]["episodes_nazeveng"].ToString());
                y = y.Replace("%epk", DEpisode.Rows[0]["episodes_nazevkan"].ToString());
                y = y.Replace("%epr", DEpisode.Rows[0]["episodes_nazevjap"].ToString());
                y = y.Replace("%enr", Depn);
                y = y.Replace("%grp", DGroup.Rows[0]["groups_namezk"].ToString());
                y = y.Replace("%ed2", DFile.Rows[0]["files_ed2k"].ToString().ToLower());
                y = y.Replace("%ED2", DFile.Rows[0]["files_ed2k"].ToString().ToUpper());
                y = y.Replace("%md5", DFile.Rows[0]["files_md5"].ToString().ToLower());
                y = y.Replace("%MD5", DFile.Rows[0]["files_md5"].ToString().ToUpper());
                y = y.Replace("%sha", DFile.Rows[0]["files_sha1"].ToString().ToLower());
                y = y.Replace("%SHA", DFile.Rows[0]["files_sha1"].ToString().ToUpper());
                y = y.Replace("%crc", DFile.Rows[0]["files_crc32"].ToString().ToLower());
                y = y.Replace("%CRC", DFile.Rows[0]["files_crc32"].ToString().ToUpper());
                y = y.Replace("%ver", Dver);
                y = y.Replace("%inv", Dinv);
                y = y.Replace("%cen", Dcen);
                y = y.Replace("%dub", DFile.Rows[0]["files_dub"].ToString());
                y = y.Replace("%sub", DFile.Rows[0]["files_sub"].ToString());
                y = y.Replace("%vid", DFile.Rows[0]["files_video"].ToString());
                y = y.Replace("%aud", DFile.Rows[0]["files_audio"].ToString());
                y = y.Replace("%qua", DFile.Rows[0]["files_quality"].ToString());
                y = y.Replace("%src", DFile.Rows[0]["files_typ"].ToString());
                y = y.Replace("%res", DFile.Rows[0]["files_resultion"].ToString());
                y = y.Replace("%yea", DAnime.Rows[0]["anime_rok"].ToString().Split('-')[0]);
                y = y.Replace("%eps", DAnime.Rows[0]["anime_epn"].ToString());
                y = y.Replace("%typ", DAnime.Rows[0]["anime_typ"].ToString());
                y = y.Replace("%gen", DFile.Rows[0]["files_typ"].ToString());
                y = y.Replace("%fid", DFile.Rows[0]["id_files"].ToString());
                y = y.Replace("%aid", DAnime.Rows[0]["id_anime"].ToString());
                y = y.Replace("%eid", DEpisode.Rows[0]["id_episodes"].ToString());
                y = y.Replace("%gid", DGroup.Rows[0]["id_groups"].ToString());
                y = y.Replace("%ani", DFile.Rows[0]["files_anidb_name"].ToString());
                y = y.Replace("%dsk", Drot);

                string Nazev = Soubor.Directory.Name == "" ? Soubor.Directory.Root.Name : Soubor.Directory.Name;
                Nazev = Nazev.Replace(":", "").Replace(@"\", "");

                StreamWriter Zapis = new StreamWriter(Soubor.Directory.FullName + @"\" + Nazev + ".txt");
                Zapis.WriteLine(y);
                Zapis.Close();
                Zapis.Dispose();

                LogAddError("EXPORT > " + Soubor.Directory.FullName + @"\" + Nazev + ".txt");
            }
            else
            {
                LogAddError("EXPORT ! File doesnt exist");
            }
        }

        //Smazat zakázané zanky
        private void Rules_Replace_KeyUp(object sender, KeyEventArgs e)
        {
            List<int> DellRows = new List<int>();

            if (e.KeyData == Keys.Delete)
                foreach (DataGridViewCell cell in Rules_Replace.SelectedCells)
                    if (cell.RowIndex > 0 && cell.RowIndex < Rules_Replace.Rows.Count - 1 && !DellRows.Contains(cell.RowIndex))
                        DellRows.Add(cell.RowIndex);

            DellRows.Sort();
            int k = 0;

            foreach (int row in DellRows)
            {
                Rules_Replace.Rows.RemoveAt(row - k);
                k++;
            }
        }

        //Zobraz pravidla
        private void Rules_Tags_Click(object sender, EventArgs e)
        {
            if (File.Exists(GlobalAdresar + "AniSubTags.txt"))
                Process.Start(GlobalAdresar + "AniSubTags.txt");
        }

        //Zapiš Info
        private void Rules_InfoAdd_Click(object sender, EventArgs e)
        {
            bool Prepis = false;
            if (File.Exists(GlobalAdresar + @"Accounts\!info\" + Rules_InfoC.Text + ".txt"))
            {
                if (MessageBox.Show(Language.MessageBox_RenameI, Language.MessageBox_Rename, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Prepis = true;
            }
            else
                Prepis = true;

            if (Prepis)
            {
                StreamWriter Zapis = new StreamWriter(GlobalAdresar + @"Accounts\!info\" + Rules_InfoC.Text + ".txt");
                if (!Rules_InfoC.Items.Contains(Rules_InfoC.Text))
                    Rules_InfoC.Items.Add(Rules_InfoC.Text);
                Zapis.WriteLine(Rules_Info.Text);
                Zapis.Close();
            }
        }

        //Smaž Info
        private void Rules_InfoDell_Click(object sender, EventArgs e)
        {
            FileDelete(GlobalAdresar + @"Accounts\!info\" + Rules_InfoC.Text + ".txt");
            Rules_InfoC.Items.Remove(Rules_InfoC.Text);
        }

        //Čti Info
        private void Rules_InfoC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(GlobalAdresar + @"Accounts\!info\" + Rules_InfoC.Text + ".txt"))
            {
                StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\!info\" + Rules_InfoC.Text + ".txt");
                Rules_Info.Text = Cti.ReadToEnd();
                Cti.Close();
            }
        }
        #endregion

        #region DataFiles
        //Listování
        private void DataFiles_Page_ValueChanged(object sender, EventArgs e)
        {
            DatabaseSelectFiles();
        }

        //Nastavit - Přidat / upravit soubory
        private void DataFiles_Menu_Mn01_Mn01_Click(object sender, EventArgs e)
        {
            string MSource = "";
            string MStorage = "";
            string MState = "1";
            string MOther = "";
            string MWatched = "0";

            if (Options_MylistStorage.Text.Length > 0)
            {
                MSource = Options_MylistSource.Text;
                MStorage = Options_MylistStorage.Text;
                MOther = Options_MylistOther.Text;
                MState = Options_MylistState.SelectedIndex.ToString();
                if (Options_CH02.Checked)
                    MWatched = "1";
                else
                    MWatched = "0";
            }
            else if (DataFiles.SelectedRows.Count > 0)
            {
                string[] Id = (string[])DataFiles[0, DataFiles.SelectedRows[0].Index].Value;

                DataTable DataFile = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + Id[0]);

                if (DataFile.Rows.Count > 0)
                {
                    MSource = DataFile.Rows[0]["files_source"].ToString();
                    MStorage = DataFile.Rows[0]["files_storage"].ToString();
                    MOther = DataFile.Rows[0]["files_other"].ToString();
                    MWatched = DataFile.Rows[0]["files_watched"].ToString();
                    MState = DataFile.Rows[0]["files_status"].ToString();
                }
            }

            MyListAdd myListAdd = new MyListAdd(MState, MSource, MStorage, MOther, MWatched, GlobalMyList);

            myListAdd.ShowDialog();
            GlobalMyList = myListAdd.ML;

            if (myListAdd.DialogResult == DialogResult.OK)
            {
                MSource = myListAdd.Options_MylistSource.Text;
                MStorage = myListAdd.Options_MylistStorage.Text;
                MState = myListAdd.Options_MylistState.SelectedIndex.ToString();
                MOther = myListAdd.Options_MylistOther.Text;
                MWatched = "0";

                if (myListAdd.Options_CH02.Checked)
                    MWatched = "1";

                foreach (DataGridViewRow Row in DataFiles.SelectedRows)
                {
                    string[] Id = (string[])DataFiles[0, Row.Index].Value;

                    if (Id[2] != "0")
                    {
                        if (Id[1] != "-1" && Id[1] != "0")
                            ComunicationNewTask("MYLISTADD edit=1&fid=" + Id[1] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                    }
                    else if (Id[1] != "-1" && Id[1] != "0")
                        ComunicationNewTask("MYLISTADD edit=0&fid=" + Id[1] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                }
            }
        }

        //Nastavit - Smazat
        private void DataFiles_Menu_Mn01_Mn02_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in DataFiles.SelectedRows)
            {
                string[] Id = (string[])DataFiles[0, Row.Index].Value;

                if (Id[1] != "-1" && Id[1] != "0" && Id[2] != "0")
                    ComunicationNewTask("MYLISTDEL fid=" + Id[1]);
            }
        }

        //Nastavit - Shlédnuto
        private void DataFiles_Menu_Mn01_Mn03_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in DataFiles.SelectedRows)
            {
                string[] Id = (string[])DataFiles[0, Row.Index].Value;

                if (Id[2] != "0")
                {
                    if (Id[1] != "-1" && Id[1] != "0")
                        ComunicationNewTask("MYLISTADD edit=1&fid=" + Id[1] + "&state=1&viewed=1");
                }
                else if (Id[1] != "-1" && Id[1] != "0")
                    ComunicationNewTask("MYLISTADD edit=0&fid=" + Id[1] + "&state=1&viewed=1");
            }
        }

        //Smazání z databáze
        private void DataFiles_Menu_Mn02_Mn01_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.MessageBox_DeleteI, Language.MessageBox_Delete, MessageBoxButtons.YesNo) == DialogResult.Yes)
                foreach (DataGridViewRow Row in DataFiles.SelectedRows)
                {
                    string[] Id = (string[])DataFiles[0, Row.Index].Value;
                    DatabaseAdd("DELETE FROM files WHERE id_files_local=" + Id[0]);
                }
        }

        //Aktualizace - Anime
        private void DataFiles_Menu_Mn05_Mn01_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Hide();

            foreach (DataGridViewRow Row in DataFiles.SelectedRows)
            {
                string[] Id = (string[])DataFiles[0, Row.Index].Value;
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + Id[0]);

                if (Convert.ToInt32(DFiles.Rows[0]["id_anime"].ToString()) > 0)
                    ComunicationNewTask("ANIME aid=" + DFiles.Rows[0]["id_anime"].ToString() + "&amask=BEE0FE01");
                else
                    ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
        }

        //Aktualizace - Episodes
        private void DataFiles_Menu_Mn05_Mn02_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Hide();

            foreach (DataGridViewRow Row in DataFiles.SelectedRows)
            {
                string[] Id = (string[])DataFiles[0, Row.Index].Value;
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + Id[0]);

                if (Convert.ToInt32(DFiles.Rows[0]["id_episodes"].ToString()) > 0)
                    ComunicationNewTask("EPISODE eid=" + DFiles.Rows[0]["id_episodes"].ToString());
                else if (Convert.ToInt32(DFiles.Rows[0]["id_anime"].ToString()) > 0)
                    ComunicationNewTask("ANIME aid=" + DFiles.Rows[0]["id_anime"].ToString() + "&amask=BEE0FE01");
                else
                    ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
        }

        //Aktualizace - Files
        private void DataFiles_Menu_Mn05_Mn03_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Hide();

            foreach (DataGridViewRow Row in DataFiles.SelectedRows)
            {
                string[] Id = (string[])DataFiles[0, Row.Index].Value;
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + Id[0]);

                ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
        }

        //Aktualizace - MyList
        private void DataFiles_Menu_Mn05_Mn04_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Hide();

            foreach (DataGridViewRow Row in DataFiles.SelectedRows)
            {
                string[] Id = (string[])DataFiles[0, Row.Index].Value;
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + Id[0]);

                if (Convert.ToInt32(DFiles.Rows[0]["id_files"].ToString()) > 0)
                    ComunicationNewTask("MYLIST fid=" + DFiles.Rows[0]["id_files"].ToString());
                else
                    ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
        }

        //Aktualizace - All
        private void DataFiles_Menu_Mn05_Mn05_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Hide();

            DataFiles_Menu_Mn05_Mn01_Click(sender, e);
            DataFiles_Menu_Mn05_Mn02_Click(sender, e);
            DataFiles_Menu_Mn05_Mn03_Click(sender, e);
            DataFiles_Menu_Mn05_Mn04_Click(sender, e);
        }

        //Vybrání souborů dle data
        private void DataFiles_RB01_CheckedChanged(object sender, EventArgs e)
        {
            DatabaseSelectFiles();
        }

        //Vybrání souborů dle data
        private void DataFiles_Day_ValueChanged(object sender, EventArgs e)
        {
            if (DataFiles_RB03.Checked)
            {
                DatabaseSelectFiles();
            }
        }

        //Aplikování pravidel
        private void DataFiles_Menu_Mn03_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Close();

            foreach (DataGridViewRow Row in DataFiles.SelectedRows)
            {
                string[] Id = (string[])DataFiles[0, Row.Index].Value;

                if (Id[1] != "0" && !FRename_List.Contains(Id[1]))
                    FRename_List.Add(Id[1]);
            }

            if (!FRename_W.IsBusy)
                FRename_W.RunWorkerAsync();
        }

        //Výběr pravidel
        private void DataFiles_Menu_Mn03_DropDownOpening(object sender, EventArgs e)
        {
            DataFiles_Menu_Mn03.DropDownItems.Clear();

            foreach (string Polozka in Rules_FilesRulesRenameC.Items)
            {
                ToolStripButton DataFiles_Menu_Mn03_Mn01 = new ToolStripButton(Polozka);
                DataFiles_Menu_Mn03_Mn01.Click += new EventHandler(DataFiles_Menu_Mn03_Mn01_Click);
                DataFiles_Menu_Mn03.DropDownItems.Add(DataFiles_Menu_Mn03_Mn01);
                if (Rules_FilesRulesRenameC.Text == Polozka)
                    DataFiles_Menu_Mn03_Mn01.Checked = true;
            }
        }

        //Aplikování pravidel
        void DataFiles_Menu_Mn03_Mn01_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton SubTlacitko in DataFiles_Menu_Mn03.DropDownItems)
                if (SubTlacitko.Checked)
                {
                    SubTlacitko.Checked = false;
                    break;
                }

            ToolStripButton Tlacitko = (ToolStripButton)sender;
            Tlacitko.Checked = true;
            Rules_FilesRulesRenameC.SelectedIndex = Rules_FilesRulesRenameC.Items.IndexOf(Tlacitko.Text);
            DataFiles_Menu_Mn03_Click(sender, e);
        }

        //Otevření anime
        private void DataFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = DataFiles.HitTest(e.X, e.Y);

            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 1)
            {
                DataSQL_Text.Text = "SELECT * FROM files WHERE id_anime=" + DataFiles[1, Hit.RowIndex].Value.ToString();

                DataSQL_SelectS();

                MainTab.SelectedIndex = 7;
            }

            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 2)
            {
                DataSQL_Text.Text = "SELECT * FROM files WHERE id_episodes=" + DataFiles[2, Hit.RowIndex].Value.ToString();

                DataSQL_SelectS();

                MainTab.SelectedIndex = 7;
            }

            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 3)
            {
                DataSQL_Text.Text = "SELECT * FROM files WHERE id_files=" + DataFiles[3, Hit.RowIndex].Value.ToString();

                DataSQL_SelectS();

                MainTab.SelectedIndex = 7;
            }

            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 4)
            {
                DataSQL_Text.Text = "SELECT * FROM files WHERE files_lid=" + DataFiles[4, Hit.RowIndex].Value.ToString();

                DataSQL_SelectS();

                MainTab.SelectedIndex = 7;
            }


            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 5)
            {
                string[] Id = (string[])DataFiles[0, Hit.RowIndex].Value;

                if (Id[3] != null)
                    AnimeTree_Find(Id[3]);
            }

            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 16)
            {
                if (File.Exists(DataFiles[16, Hit.RowIndex].Value.ToString()))
                    Process.Start(DataFiles[16, Hit.RowIndex].Value.ToString());
            }
        }

        //Filtrování
        private void DataFiles_Bt01_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "DataFiles_Bt00":
                    break;

                case "DataFiles_Bt01":
                    DatabaseSelectFilesCascade = "";
                    DataFiles_Filtr01.Text = "";
                    DataFiles_Filtr02.Text = "";
                    DataFiles_Filtr03.Text = "";
                    DataFiles_Filtr04.Text = "";
                    DataFiles_Bt01.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt02.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt03.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt04.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt05.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt06.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt07.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt08.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt09.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt10.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt11.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt12.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt13.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt14.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt15.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt16.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt17.FlatStyle = FlatStyle.Standard;
                    DataFiles_Bt18.FlatStyle = FlatStyle.Standard;
                    break;

                case "DataFiles_Bt02":
                    if (DataFiles_Bt02.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_status<>1"; //storage on HDD
                        else
                            DatabaseSelectFilesCascade += " AND files_status=1"; //storage on HDD
                        DataFiles_Bt02.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_status<>1", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_status=1", "");
                        DataFiles_Bt02.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt03":
                    if (DataFiles_Bt03.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_status<>2"; //storage on CD/DVD
                        else
                            DatabaseSelectFilesCascade += " AND files_status=2"; //storage on CD/DVD
                        DataFiles_Bt03.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_status<>2", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_status=2", "");
                        DataFiles_Bt03.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt04":
                    if (DataFiles_Bt04.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_status<>3"; //storage deleted
                        else
                            DatabaseSelectFilesCascade += " AND files_status=3"; //storage deleted
                        DataFiles_Bt04.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_status<>3", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_status=3", "");
                        DataFiles_Bt04.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt05":
                    if (DataFiles_Bt05.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_status<>0"; //unknown storage
                        else
                            DatabaseSelectFilesCascade += " AND files_status=0"; //unknown storage
                        DataFiles_Bt05.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_status<>0", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_status=0", "");
                        DataFiles_Bt05.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt06":
                    if (DataFiles_Bt06.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND Len(files_storage & '')<>0"; //unknown storage
                        else
                            DatabaseSelectFilesCascade += " AND Len(files_storage & '')=0"; //unknown storage
                        DataFiles_Bt06.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND Len(files_storage & '')<>0", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND Len(files_storage & '')=0", "");
                        DataFiles_Bt06.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt07":
                    if (DataFiles_Bt07.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND Len(files_other & '')<>0"; //unknown other
                        else
                            DatabaseSelectFilesCascade += " AND Len(files_other & '')=0"; //unknown other
                        DataFiles_Bt07.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND Len(files_other & '')<>0", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND Len(files_other & '')=0", "");
                        DataFiles_Bt07.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt08":
                    if (DataFiles_Bt08.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND Len(files_source & '')<>0"; //unknown source
                        else
                            DatabaseSelectFilesCascade += " AND Len(files_source & '')=0"; //unknown source
                        DataFiles_Bt08.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND Len(files_source & '')<>0", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND Len(files_source & '')=0", "");
                        DataFiles_Bt08.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt09":
                    if (DataFiles_Bt09.FlatStyle == FlatStyle.Standard)
                    {
                        DatabaseSelectFilesCascade += " AND files_watched=0"; //unseen
                        DataFiles_Bt09.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_watched=0", "");
                        DataFiles_Bt09.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt10":
                    if (DataFiles_Bt10.FlatStyle == FlatStyle.Standard)
                    {
                        DatabaseSelectFilesCascade += " AND files_watched=1"; //seen
                        DataFiles_Bt10.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_watched=1", "");
                        DataFiles_Bt10.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt11":
                    if (DataFiles_Bt11.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_typ<>'Blu-ray'"; //Blu-ray
                        else
                            DatabaseSelectFilesCascade += " AND files_typ='Blu-ray'"; //Blu-ray
                        DataFiles_Bt11.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ='Blu-ray'", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ<>'Blu-ray'", "");
                        DataFiles_Bt11.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt12":
                    if (DataFiles_Bt12.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_typ<>'HDTV'"; //HDTV
                        else
                            DatabaseSelectFilesCascade += " AND files_typ='HDTV'"; //HDTV
                        DataFiles_Bt12.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ<>'HDTV'", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ='HDTV'", "");
                        DataFiles_Bt12.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt13":
                    if (DataFiles_Bt13.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_typ<>'DVD'"; //DVD
                        else
                            DatabaseSelectFilesCascade += " AND files_typ='DVD'"; //DVD
                        DataFiles_Bt13.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ<>'DVD'", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ='DVD'", "");
                        DataFiles_Bt13.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt14":
                    if (DataFiles_Bt14.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_typ<>'DTV'"; //DTV
                        else
                            DatabaseSelectFilesCascade += " AND files_typ='DTV'"; //DTV
                        DataFiles_Bt14.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ<>'DTV'", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ='DTV'", "");
                        DataFiles_Bt14.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt15":
                    if (DataFiles_Bt15.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_typ<>'www'"; //www
                        else
                            DatabaseSelectFilesCascade += " AND files_typ='www'"; //www
                        DataFiles_Bt15.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ<>'www'", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ='www'", "");
                        DataFiles_Bt15.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt16":
                    if (DataFiles_Bt16.FlatStyle == FlatStyle.Standard)
                    {
                        if (DataFilesTree_CH04.Checked)
                            DatabaseSelectFilesCascade += " AND files_typ<>'unknown'"; //unknown
                        else
                            DatabaseSelectFilesCascade += " AND files_typ='unknown'"; //unknown
                        DataFiles_Bt16.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ<>'unknown'", "");
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_typ='unknown'", "");
                        DataFiles_Bt16.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt17":
                    if (DataFiles_Bt17.FlatStyle == FlatStyle.Standard)
                    {
                        DatabaseSelectFilesCascade += " AND files_lid>0"; //Je v Mylist
                        DataFiles_Bt17.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_lid>0", "");
                        DataFiles_Bt17.FlatStyle = FlatStyle.Standard;
                    }
                    break;

                case "DataFiles_Bt18":
                    if (DataFiles_Bt18.FlatStyle == FlatStyle.Standard)
                    {
                        DatabaseSelectFilesCascade += " AND files_lid=0"; //Není v Mylist
                        DataFiles_Bt18.FlatStyle = FlatStyle.Popup;
                    }
                    else
                    {
                        DatabaseSelectFilesCascade = DatabaseSelectFilesCascade.Replace(" AND files_lid=0", "");
                        DataFiles_Bt18.FlatStyle = FlatStyle.Standard;
                    }
                    break;
            }

            DataFilesTree_CH04.Checked = false;

            DatabaseSelectFiles();
        }

        //Zobrazení Tree
        private void DataFiles_Bt19_Click(object sender, EventArgs e)
        {
            if (!DataFilesTree.Visible)
            {
                DataFilesTree.Location = DataFiles.Location;
                DataFilesTree.Width = DataFiles.Width;
                DataFilesTree.Height = DataFiles.Height;
                DataFilesTree.Visible = true;
                DataFilesTree.Enabled = true;
                DataFilesTree_CH01.Visible = true;
                DataFilesTree_CH02.Visible = true;
            }
            else
            {
                DataFilesTree.Visible = false;
                DataFilesTree.Enabled = false;
                DataFilesTree_CH01.Visible = false;
                DataFilesTree_CH02.Visible = false;
            }

            DatabaseSelectFiles();
        }

        //Generování kontroly existujících souborů
        private void DataFiles_Bt20_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "*.txt|*.txt";

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files ORDER BY files_localfile");

                StreamWriter Zapis = new StreamWriter(SFD.FileName, false, Encoding.UTF8, 512);

                Zapis.WriteLine("~AniSub v" + AniSubV);
                Zapis.WriteLine("~Date " + DateTime.Now.ToLongDateString());
                Zapis.WriteLine("~Report of files exist state");

                string hdd = "";

                foreach (DataRow row in DFiles.Rows)
                {
                    string Cesta = row["files_localfile"].ToString();

                    if (Cesta.Length > 0)
                    {
                        if (Cesta.Substring(0, 3) != hdd)
                        {
                            hdd = Cesta.Substring(0, 3);

                            Zapis.WriteLine("-------------------------------------------------------");
                            Zapis.WriteLine("-------------------------------------------------------");
                            Zapis.WriteLine("HDD: " + hdd);
                            Zapis.WriteLine("-------------------------------------------------------");
                        }
                    }

                    if (File.Exists(Cesta))
                        Zapis.WriteLine("Exist: " + Cesta);
                    else
                        Zapis.WriteLine("DOESNT Exist: " + Cesta);
                }

                Zapis.Close();
                Zapis.Dispose();
                Process.Start(SFD.FileName);
            }
        }

        //Stromová struktura
        private void DataFiles_Bt21_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "*.txt|*.txt";

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files ORDER BY files_localfile");

                StreamWriter Zapis = new StreamWriter(SFD.FileName, false, Encoding.UTF8);

                Zapis.WriteLine("~AniSub v" + AniSubV);
                Zapis.WriteLine("~Date " + DateTime.Now.ToLongDateString());
                Zapis.WriteLine("~Filestree");

                List<string> STRUC = new List<string>();

                string HDD = "";
                string DIR = "";
                int ODS = 0;

                foreach (DataRow row in DFiles.Rows)
                {
                    try
                    {
                        FileInfo Soubor = new FileInfo(row["files_localfile"].ToString());

                        if (HDD != Soubor.Directory.Root.ToString())
                        {
                            HDD = Soubor.Directory.Root.ToString();
                            Zapis.WriteLine();
                            Zapis.WriteLine(HDD);
                            STRUC.Add(HDD);
                        }

                        if (DIR != Soubor.Directory.FullName)
                        {
                            string[] DIRTP = DIR.Split('\\');
                            DIR = Soubor.Directory.FullName;
                            string[] DIRT = DIR.Split('\\');
                            string DIRS = "";
                            ODS = 0;

                            if (STRUC.Count > 1)
                            {
                                string DIR1 = "";
                                string DIR2 = "";

                                int x = DIRTP.Length < DIRT.Length ? DIRTP.Length : DIRT.Length;
                                int y = 0;

                                for (int i = 0; i < x; i++)
                                {
                                    DIR1 += DIRTP[i] + "\\";
                                    DIR2 += DIRT[i] + "\\";

                                    if (DIR1 == DIR2)
                                        y++;
                                    else
                                        break;
                                }

                                if (y == 1)
                                    Zapis.WriteLine("  |");
                                else
                                {
                                    Zapis.Write("  |");
                                    for (int i = 0; i < y - 1; i++)
                                        Zapis.Write("   |");
                                    Zapis.Write("\r\n");
                                }
                            }

                            foreach (string DIRR in DIRT)
                            {
                                DIRS += DIRR + "\\";

                                if (!STRUC.Contains(DIRS))
                                {
                                    STRUC.Add(DIRS);

                                    Zapis.Write("  ");
                                    for (int i = 0; i < ODS - 1; i++)
                                        Zapis.Write("|   ");

                                    Zapis.Write("+ - \\ [" + DIRR + "]\r\n");
                                }

                                ODS++;
                            }
                        }

                        Zapis.Write("  ");
                        for (int i = 0; i < ODS - 1; i++)
                            Zapis.Write("|   ");

                        Zapis.Write("+ - > " + Soubor.Name + "   (" + FilesSize(row["files_size"].ToString()) + ")\r\n");

                        Zapis.Flush();
                    }
                    catch
                    {
                    }
                }

                Zapis.Close();
                Zapis.Dispose();
                Process.Start(SFD.FileName);
            }
        }

        //Duplikátní soubory
        private void DataFiles_Bt22_Click(object sender, EventArgs e)
        {
            DataFiles.Rows.Clear();
            DataFilesTree.Visible = false;
            DataFilesTree.Enabled = false;
            DataFilesTree_CH01.Visible = false;
            DataFilesTree_CH02.Visible = false;

            DataTable DFiles = DatabaseSelect("SELECT * FROM (groups RIGHT JOIN (episodes RIGHT JOIN files ON episodes.id_episodes = files.id_episodes) ON  groups.id_groups = files.id_groups) INNER JOIN anime ON files.id_anime = anime.id_anime WHERE files.id_episodes IN (SELECT files.id_episodes FROM files GROUP BY files.id_episodes HAVING COUNT(files.id_episodes) > 1) ORDER BY CStr(anime.anime_nazevjap & '') ASC, episodes.episodes_epn ASC");

            for (int i = 0; i < DFiles.Rows.Count; i++)
            {
                if (!DataFilesTree_CH03.Checked)
                    DatabaseSelectFilesAddRow(DFiles.Rows[i]);
                else
                    DatabaseSelectFilesAddRowOnlyFiles(DFiles.Rows[i]);
            }

            DataFiles_LB06.Text = Language.DataFiles_LB06 + ": " + DFiles.Rows.Count + " / 1";
        }

        //Předotevřením Menu
        private void DataFiles_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (DataFiles.SelectedRows.Count == 1)
                DataFiles_Menu_Mn04.Visible = true;
            else
                DataFiles_Menu_Mn04.Visible = false;
        }

        //Otevření WIN kontextového menu
        private void DataFiles_Menu_Mn04_Click(object sender, EventArgs e)
        {
            if (DataFiles.SelectedRows.Count > 0)
            {
                if (File.Exists(DataFiles[16, DataFiles.SelectedRows[0].Index].Value.ToString()))
                {
                    ShellContextMenu ctxMnu = new ShellContextMenu();
                    FileInfo[] arrFI = new FileInfo[1];
                    arrFI[0] = new FileInfo(DataFiles[16, DataFiles.SelectedRows[0].Index].Value.ToString());
                    ctxMnu.ShowContextMenu(arrFI, this.PointToScreen(new Point(MousePosition.X - 60, MousePosition.Y - 60)));
                }
            }
        }

        //Počet souborů
        private void DataFilesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] T = DataFiles_LB06.Text.Replace(" / ", "/").Split('/');
            int x = DataFilesTree.SelectedNode.Nodes.Count;
            if (x == 0)
                x = 1;

            DataFiles_LB06.Text = T[0] + " / " + x;
        }

        //Počet souborů
        private void DataFiles_SelectionChanged(object sender, EventArgs e)
        {
            string[] T = DataFiles_LB06.Text.Replace(" / ", "/").Split('/');

            DataFiles_LB06.Text = T[0] + " / " + DataFiles.SelectedRows.Count;
        }

        //Otevření souboru
        private void DataFilesTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (File.Exists(DataFilesTree.SelectedNode.FullPath))
                    Process.Start(DataFilesTree.SelectedNode.FullPath);
                else if (Directory.Exists(DataFilesTree.SelectedNode.FullPath))
                    Process.Start(DataFilesTree.SelectedNode.FullPath);
            }
            catch
            {
            }
        }

        //Rozevření
        private void DataFilesTree_Mn01_Mn01_Click(object sender, EventArgs e)
        {
            DataFilesTree.BeginUpdate();
            DataFilesTree.ExpandAll();
            if (DataFilesTree.Nodes.Count > 0)
                DataFilesTree.Nodes[0].EnsureVisible();
            DataFilesTree.EndUpdate();
        }

        //Zavření
        private void DataFilesTree_Mn01_Mn02_Click(object sender, EventArgs e)
        {
            DataFilesTree.BeginUpdate();
            DataFilesTree.CollapseAll();
            DataFilesTree.EndUpdate();
        }

        //MyList - add / edit
        private void DataFilesTree_Mn02_Mn01_Click(object sender, EventArgs e)
        {
            if (DataFilesTree.SelectedNode.Checked)
            {
                string MSource = "";
                string MStorage = "";
                string MState = "1";
                string MOther = "";
                string MWatched = "0";

                DataTable DataFile = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                if (DataFile.Rows.Count > 0)
                {
                    MSource = DataFile.Rows[0]["files_source"].ToString();
                    MStorage = DataFile.Rows[0]["files_storage"].ToString();
                    MOther = DataFile.Rows[0]["files_other"].ToString();
                    MWatched = DataFile.Rows[0]["files_watched"].ToString();
                    MState = DataFile.Rows[0]["files_status"].ToString();
                }

                MyListAdd myListAdd = new MyListAdd(MState, MSource, MStorage, MOther, MWatched, GlobalMyList);

                myListAdd.ShowDialog();
                GlobalMyList = myListAdd.ML;

                if (myListAdd.DialogResult == DialogResult.OK)
                {
                    MSource = myListAdd.Options_MylistSource.Text;
                    MStorage = myListAdd.Options_MylistStorage.Text;
                    MState = myListAdd.Options_MylistState.SelectedIndex.ToString();
                    MOther = myListAdd.Options_MylistOther.Text;
                    MWatched = "0";

                    if (myListAdd.Options_CH02.Checked)
                        MWatched = "1";

                    DataTable DFile = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                    if (DFile.Rows.Count > 0)
                        ComunicationNewTask("MYLISTADD edit=1&fid=" + DFile.Rows[0]["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                }
            }
            else if (DataFilesTree.SelectedNode.Name != null)
            {
                string MSource = "";
                string MStorage = "";
                string MState = "1";
                string MOther = "";
                string MWatched = "0";

                string[] Id = (string[])DataFiles[0, DataFiles.SelectedRows[0].Index].Value;

                DataTable DataFile = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);

                if (DataFile.Rows.Count > 0)
                {
                    MSource = DataFile.Rows[0]["files_source"].ToString();
                    MStorage = DataFile.Rows[0]["files_storage"].ToString();
                    MOther = DataFile.Rows[0]["files_other"].ToString();
                    MWatched = DataFile.Rows[0]["files_watched"].ToString();
                    MState = DataFile.Rows[0]["files_status"].ToString();
                }

                MyListAdd myListAdd = new MyListAdd(MState, MSource, MStorage, MOther, MWatched, GlobalMyList);

                myListAdd.ShowDialog();
                GlobalMyList = myListAdd.ML;

                if (myListAdd.DialogResult == DialogResult.OK)
                {
                    MSource = myListAdd.Options_MylistSource.Text;
                    MStorage = myListAdd.Options_MylistStorage.Text;
                    MState = myListAdd.Options_MylistState.SelectedIndex.ToString();
                    MOther = myListAdd.Options_MylistOther.Text;
                    MWatched = "0";

                    if (myListAdd.Options_CH02.Checked)
                        MWatched = "1";

                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);

                    foreach (DataRow Row in DFiles.Rows)
                        if (Row["files_lid"].ToString() != "0")
                            ComunicationNewTask("MYLISTADD edit=1&fid=" + Row["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                        else
                            ComunicationNewTask("MYLISTADD edit=0&fid=" + Row["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                }
            }
        }

        //MyList - Smazání
        private void DataFilesTree_Mn02_Mn02_Click(object sender, EventArgs e)
        {
            if (DataFilesTree.SelectedNode.Checked)
            {
                DataTable DFile = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                ComunicationNewTask("MYLISTDEL fid=" + DFile.Rows[0]["id_files"]);
            }
            else if (DataFilesTree.SelectedNode.Name != null)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);

                foreach (DataRow Row in DFiles.Rows)
                    ComunicationNewTask("MYLISTDEL fid=" + Row["id_files"]);
            }
        }

        //MyList - Shlédnuto
        private void DataFilesTree_Mn02_Mn03_Click(object sender, EventArgs e)
        {
            if (DataFilesTree.SelectedNode.Checked)
            {
                DataTable DFile = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                if (DFile.Rows[0]["files_lid"].ToString() != "0")
                    ComunicationNewTask("MYLISTADD edit=1&fid=" + DFile.Rows[0]["id_files"] + "&viewed=1");
                else
                    ComunicationNewTask("MYLISTADD edit=0&fid=" + DFile.Rows[0]["id_files"] + "&viewed=1");
            }
            else if (DataFilesTree.SelectedNode.Name != null)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);

                foreach (DataRow Row in DFiles.Rows)
                    if (Row["files_lid"].ToString() != "0")
                        ComunicationNewTask("MYLISTADD edit=1&fid=" + Row["id_files"] + "&viewed=1");
                    else
                        ComunicationNewTask("MYLISTADD edit=0&fid=" + Row["id_files"] + "&viewed=1");
            }
        }

        //Aktualizace - Anime
        private void DataFilesTree_Mn07_Mn01_Click(object sender, EventArgs e)
        {
            DataFilesTree_Menu.Hide();

            if (DataFilesTree.SelectedNode.Checked)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                if (Convert.ToInt32(DFiles.Rows[0]["id_anime"].ToString()) > 0)
                    ComunicationNewTask("ANIME aid=" + DFiles.Rows[0]["id_anime"].ToString() + "&amask=BEE0FE01");
                else
                    ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
            else if (DataFilesTree.SelectedNode.Name != null)
            {
                ComunicationNewTask("ANIME aid=" + DataFilesTree.SelectedNode.Name + "&amask=BEE0FE01");
            }
        }

        //Aktualizace - Episodes
        private void DataFilesTree_Mn07_Mn02_Click(object sender, EventArgs e)
        {
            DataFilesTree_Menu.Hide();

            if (DataFilesTree.SelectedNode.Checked)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                if (Convert.ToInt32(DFiles.Rows[0]["id_episodes"].ToString()) > 0)
                    ComunicationNewTask("EPISODE eid=" + DFiles.Rows[0]["id_episodes"].ToString());
                else if (Convert.ToInt32(DFiles.Rows[0]["id_anime"].ToString()) > 0)
                    ComunicationNewTask("ANIME aid=" + DFiles.Rows[0]["id_anime"].ToString() + "&amask=BEE0FE01");
                else
                    ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
            else if (DataFilesTree.SelectedNode.Name != null)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);

                for (int i = 0; i < DFiles.Rows.Count; i++)
                {
                    if (Convert.ToInt32(DFiles.Rows[i]["id_episodes"].ToString()) > 0)
                        ComunicationNewTask("EPISODE eid=" + DFiles.Rows[i]["id_episodes"].ToString());
                    else if (Convert.ToInt32(DFiles.Rows[0]["id_anime"].ToString()) > 0)
                        ComunicationNewTask("ANIME aid=" + DFiles.Rows[i]["id_anime"].ToString() + "&amask=BEE0FE01");
                    else
                        ComunicationNewTask("FILE size=" + DFiles.Rows[i]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[i]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                }
            }
        }

        //Aktualizace - Files
        private void DataFilesTree_Mn07_Mn03_Click(object sender, EventArgs e)
        {
            DataFilesTree_Menu.Hide();

            if (DataFilesTree.SelectedNode.Checked)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
            else if (DataFilesTree.SelectedNode.Name != null)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);

                for (int i = 0; i < DFiles.Rows.Count; i++)
                    ComunicationNewTask("FILE size=" + DFiles.Rows[i]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[i]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
        }

        //Aktualizace - MyList
        private void DataFilesTree_Mn07_Mn04_Click(object sender, EventArgs e)
        {
            DataFilesTree_Menu.Hide();

            if (DataFilesTree.SelectedNode.Checked)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                if (Convert.ToInt32(DFiles.Rows[0]["id_files"].ToString()) > 0)
                    ComunicationNewTask("MYLIST fid=" + DFiles.Rows[0]["id_files"].ToString());
                else
                    ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
            else if (DataFilesTree.SelectedNode.Name != null)
            {
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);

                for (int i = 0; i < DFiles.Rows.Count; i++)
                {
                    if (Convert.ToInt32(DFiles.Rows[i]["id_files"].ToString()) > 0)
                        ComunicationNewTask("MYLIST fid=" + DFiles.Rows[i]["id_files"].ToString());
                    else
                        ComunicationNewTask("FILE size=" + DFiles.Rows[i]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[i]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                }
            }
        }

        //Aktualizace - All
        private void DataFilesTree_Mn07_Mn05_Click(object sender, EventArgs e)
        {
            DataFilesTree_Menu.Hide();

            DataFilesTree_Mn07_Mn01_Click(sender, e);
            DataFilesTree_Mn07_Mn02_Click(sender, e);
            DataFilesTree_Mn07_Mn03_Click(sender, e);
            DataFilesTree_Mn07_Mn04_Click(sender, e);
        }

        //Database delete
        private void DataFilesTree_Mn03_Mn01_Click(object sender, EventArgs e)
        {
            if (DataFilesTree.SelectedNode.Checked)
            {
                if (MessageBox.Show(Language.MessageBox_DeleteI, Language.MessageBox_Delete, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    DatabaseAdd("DELETE FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);
            }

            else if (DataFilesTree.SelectedNode.Name != null)
            {
                if (MessageBox.Show(Language.MessageBox_DeleteI, Language.MessageBox_Delete, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    DatabaseAdd("DELETE FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);
            }
        }

        //Zobrazení win kontextového menu
        private void DataFilesTree_Mn04_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataFilesTree.SelectedNode.Checked && File.Exists(DataFilesTree.SelectedNode.FullPath))
                {
                    ShellContextMenu ctxMnu = new ShellContextMenu();
                    FileInfo[] arrFI = new FileInfo[1];
                    arrFI[0] = new FileInfo(DataFilesTree.SelectedNode.FullPath);
                    ctxMnu.ShowContextMenu(arrFI, this.PointToScreen(new Point(MousePosition.X - 60, MousePosition.Y - 60)));
                }
                else if (!DataFilesTree.SelectedNode.Checked && Directory.Exists(DataFilesTree.SelectedNode.FullPath))
                {
                    ShellContextMenu ctxMnu = new ShellContextMenu();
                    DirectoryInfo[] arrFI = new DirectoryInfo[1];
                    arrFI[0] = new DirectoryInfo(DataFilesTree.SelectedNode.FullPath);
                    ctxMnu.ShowContextMenu(arrFI, this.PointToScreen(new Point(MousePosition.X - 60, MousePosition.Y - 60)));
                }
            }
            catch
            {
            }
        }

        //Vyčistit Tree
        private void DataFilesTree_Mn05_Click(object sender, EventArgs e)
        {
            DataFilesTree.Nodes.Clear();
        }

        //Přejmenuj - Rozveření seznamu
        private void DataFilesTree_Mn06_DropDownOpening(object sender, EventArgs e)
        {
            DataFilesTree_Mn06.DropDownItems.Clear();

            foreach (string Polozka in Rules_FilesRulesRenameC.Items)
            {
                ToolStripButton DataFilesTree_Mn06_Mn01 = new ToolStripButton(Polozka);
                DataFilesTree_Mn06_Mn01.Click += new EventHandler(DataFilesTree_Mn06_Mn01_Click);
                DataFilesTree_Mn06.DropDownItems.Add(DataFilesTree_Mn06_Mn01);
            }
        }

        //Přejmenuj - aplikuj jiná pravidla
        private void DataFilesTree_Mn06_Mn01_Click(object sender, EventArgs e)
        {
            ToolStripButton Tlacitko = (ToolStripButton)sender;
            Rules_FilesRulesRenameC.SelectedIndex = Rules_FilesRulesRenameC.Items.IndexOf(Tlacitko.Text);
            DataFilesTree_Mn06_Click(sender, e);
        }

        //Přejmenuj - aplikuj pravidla
        private void DataFilesTree_Mn06_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Close();

            RenameTreeNode(DataFilesTree.SelectedNode);

            if (!FRename_W.IsBusy)
                FRename_W.RunWorkerAsync();
        }

        //Přejmenuj - aplikuj pravidla
        private void RenameTreeNode(TreeNode TN)
        {
            foreach (TreeNode Node in TN.Nodes)
                RenameTreeNode(Node);

            if (TN.Tag != null)
            {
                string[] T = TN.Tag.ToString().Split('*');

                if (T.Length == 2)
                {
                    if (T[0] == "F" && !FRename_List.Contains(T[1]))
                        FRename_List.Add(T[1]);
                }
            }
        }

        //Exportovat - MD5
        private void DataFiles_Menu_Mn06_Mn01_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Close();

            ToolStripMenuItem It = (ToolStripMenuItem)sender;

            if (It.Checked)
                It.Checked = false;
            else
                It.Checked = true;
        }

        //Exportovat - CRC32
        private void DataFiles_Menu_Mn06_Mn02_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Close();

            ToolStripMenuItem It = (ToolStripMenuItem)sender;

            if (It.Checked)
                It.Checked = false;
            else
                It.Checked = true;
        }

        //Exportovat - ED2K
        private void DataFiles_Menu_Mn06_Mn03_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Close();

            ToolStripMenuItem It = (ToolStripMenuItem)sender;

            if (It.Checked)
                It.Checked = false;
            else
                It.Checked = true;
        }

        //Exportovat - SHA1
        private void DataFiles_Menu_Mn06_Mn04_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Close();

            ToolStripMenuItem It = (ToolStripMenuItem)sender;

            if (It.Checked)
                It.Checked = false;
            else
                It.Checked = true;
        }

        //Exporotvat
        private void DataFiles_Menu_Mn06_Click(object sender, EventArgs e)
        {
            DataFiles_Menu.Close();

            StreamWriter ZapisMD5 = null;
            StreamWriter ZapisCRC = null;
            StreamWriter ZapisSHA1 = null;
            StreamWriter ZapisED2K = null;

            if (DataFiles_Menu_Mn06_Mn01.Checked || DataFiles_Menu_Mn06_Mn02.Checked || DataFiles_Menu_Mn06_Mn03.Checked || DataFiles_Menu_Mn06_Mn04.Checked)
                foreach (DataGridViewRow Row in DataFiles.SelectedRows)
                {
                    string[] Id = (string[])DataFiles[0, Row.Index].Value;
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + Id[0]);

                    if (File.Exists(DFiles.Rows[0]["files_localfile"].ToString()))
                    {
                        FileInfo Soubor = new FileInfo(DFiles.Rows[0]["files_localfile"].ToString());
                        DirectoryInfo AdresarNew = Soubor.Directory;

                        if (DataFiles_Menu_Mn06_Mn01.Checked)
                        {
                            try
                            {
                                ZapisMD5 = new StreamWriter(AdresarNew.FullName + @"\" + RemoveUnesesaryStrings(AdresarNew.Name) + ".md5", true, UTF8Encoding.UTF8);
                                ZapisMD5.WriteLine(DFiles.Rows[0]["files_md5"].ToString() + " *" + Soubor.Name);
                                ZapisMD5.Flush();
                                ZapisMD5.Close();
                            }
                            catch
                            {
                                LogAddError("EXPORT > Cant export " + AdresarNew.FullName + @"\" + AdresarNew.Name + ".md5");
                            }
                        }

                        if (DataFiles_Menu_Mn06_Mn02.Checked)
                        {
                            try
                            {
                                ZapisCRC = new StreamWriter(AdresarNew.FullName + @"\" + RemoveUnesesaryStrings(AdresarNew.Name) + ".sfv", true, UTF8Encoding.UTF8);
                                ZapisCRC.WriteLine(Soubor.Name + " " + DFiles.Rows[0]["files_crc32"].ToString());
                                ZapisCRC.Flush();
                                ZapisCRC.Close();
                            }
                            catch
                            {
                                LogAddError("EXPORT > Cant export " + AdresarNew.FullName + @"\" + AdresarNew.Name + ".sfv");
                            }
                        }

                        if (DataFiles_Menu_Mn06_Mn03.Checked)
                        {
                            try
                            {
                                ZapisED2K = new StreamWriter(AdresarNew.FullName + @"\" + RemoveUnesesaryStrings(AdresarNew.Name) + ".ed2k", true, UTF8Encoding.UTF8);
                                ZapisED2K.WriteLine("ed2k://|file|" + Soubor.Name + "|" + Soubor.Length + "|" + DFiles.Rows[0]["files_ed2k"].ToString() + "|");
                                ZapisED2K.Flush();
                                ZapisED2K.Close();
                            }
                            catch
                            {
                                LogAddError("EXPORT > Cant export " + AdresarNew.FullName + @"\" + AdresarNew.Name + ".ed2k");
                            }
                        }

                        if (DataFiles_Menu_Mn06_Mn04.Checked)
                        {
                            try
                            {
                                ZapisSHA1 = new StreamWriter(AdresarNew.FullName + @"\" + RemoveUnesesaryStrings(AdresarNew.Name) + ".sha1", true, UTF8Encoding.UTF8);
                                ZapisSHA1.WriteLine(DFiles.Rows[0]["files_sha1"].ToString() + " *" + Soubor.Name);
                                ZapisSHA1.Flush();
                                ZapisSHA1.Close();
                            }
                            catch
                            {
                                LogAddError("EXPORT > Cant export " + AdresarNew.FullName + @"\" + AdresarNew.Name + ".sha1");
                            }
                        }
                    }
                }
        }

        //Rehash
        private void DataFiles_Menu_Mn07_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in DataFiles.SelectedRows)
            {
                string[] Id = (string[])DataFiles[0, Row.Index].Value;
                DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + Id[0]);

                if (DFiles.Rows.Count > 0)
                    Nacti_Hash(DFiles.Rows[0]["files_localfile"].ToString());
            }
        }

        //Rehash
        private void DataFilesTree_Mn08_Click(object sender, EventArgs e)
        {
            if (DataFilesTree.SelectedNode != null)
            {
                if (DataFilesTree.SelectedNode.Checked)
                {
                    DataTable DataFile = DatabaseSelect("SELECT * FROM files WHERE id_files_local=" + DataFilesTree.SelectedNode.Name);

                    if (DataFile.Rows.Count > 0)
                        Nacti_Hash(DataFile.Rows[0]["files_localfile"].ToString());
                }

                else if (DataFilesTree.SelectedNode.Name != null)
                {
                    DataTable DataFile = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataFilesTree.SelectedNode.Name);

                    for (int i = 0; i < DataFile.Rows.Count; i++)
                        Nacti_Hash(DataFile.Rows[i]["files_localfile"].ToString());
                }
            }
        }

        //Filtry Tree
        private void DataFilesTree_CH01_CheckedChanged(object sender, EventArgs e)
        {
            if (DataFilesTree_CH01.Checked)
            {
                DataFilesTree_CH02.Checked = false;
                TabSelect(true);
            }
        }

        //Filtry Tree
        private void DataFilesTree_CH02_CheckedChanged(object sender, EventArgs e)
        {
            if (DataFilesTree_CH02.Checked)
            {
                DataFilesTree_CH01.Checked = false;
                TabSelect(true);
            }
        }
        #endregion

        #region DataAnime
        //Listování
        private void DataAnime_Page_ValueChanged(object sender, EventArgs e)
        {
            DatabaseSelectAnime();
        }

        //Rozevírání
        private void DataAnime_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = DataAnime.HitTest(e.X, e.Y);
            if (Hit.RowIndex >= 0 && Hit.ColumnIndex >= 0)
            {
                bool[] WTF = (bool[])DataAnime[0, Hit.RowIndex].Value;

                if (Hit.ColumnIndex == 1 && !WTF[0] && !WTF[1] && !WTF[2])
                    DataAnime_RozevritAnime(Hit.RowIndex);
                else if (Hit.ColumnIndex == 1 && WTF[0] && !WTF[1] && !WTF[2])
                    DataAnime_ZavritAnime(Hit.RowIndex);
                else if (Hit.ColumnIndex == 2 && !WTF[0] && WTF[1] && !WTF[2])
                    DataAnime_RozevritEpisodes(Hit.RowIndex);
                else if (Hit.ColumnIndex == 2 && WTF[1] && WTF[1] && !WTF[2])
                    DataAnime_ZavritEpisodes(Hit.RowIndex);
            }

            if (e.Button == MouseButtons.Right && Hit.RowIndex >= 0)
            {
                DataAnime.Rows[Hit.RowIndex].Selected = true;
                DataAnime_Menu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        //Anime podrobnosti
        private void DataAnime_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = DataAnime.HitTest(e.X, e.Y);

            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 4)
            {
                bool[] WTF = (bool[])DataAnime[0, Hit.RowIndex].Value;

                if (!WTF[1] && !WTF[2])
                    AnimeTree_Find(DataAnime[3, Hit.RowIndex].Value.ToString());
            }
        }

        //Rozevřít anime
        private void DataAnime_RozevritAnime(int RowIndex)
        {
            DataAnime[0, RowIndex].Value = new bool[3] { true, false, false };
            DataAnime[1, RowIndex].Value = Resources.i_Collapse;

            DataTable dataTable = DatabaseSelectAnimeID(DataAnime[3, RowIndex].Value.ToString());

            int k = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                DataTable dataTable2 = DatabaseSelect("SELECT files_size FROM files WHERE id_episodes=" + row["id_episodes"]);

                int SUM = 0;
                string SUMFilesSize = "-";

                for (int i = 0; i < dataTable2.Rows.Count; i++)
                {
                    try
                    {
                        SUM += Convert.ToInt32(dataTable2.Rows[i]["files_size"].ToString());
                    }
                    catch
                    {
                    }
                }

                SUMFilesSize = FilesSize(SUM.ToString());

                string Spec = "";
                if (row["episodes_spec"].ToString() != "0")
                    Spec = row["episodes_spec"].ToString();

                DataAnime.Rows.Insert(RowIndex + 1, 1);

                DataAnime[0, RowIndex + 1].Value = new bool[3] { false, true, false };
                DataAnime[1, RowIndex + 1].Value = new Bitmap(1, 1);
                DataAnime[2, RowIndex + 1].Value = Resources.i_Expand;
                DataAnime[3, RowIndex + 1].Value = row["id_episodes"].ToString();
                DataAnime[4, RowIndex + 1].Value = "    " + Spec + row["episodes_epn"].ToString() + " - " + row["episodes_nazeveng"].ToString();
                DataAnime[5, RowIndex + 1].Value = "    " + Spec + row["episodes_epn"].ToString() + " - " + row["episodes_nazevjap"].ToString();
                DataAnime[6, RowIndex + 1].Value = "-";
                DataAnime[7, RowIndex + 1].Value = "-";
                DataAnime[8, RowIndex + 1].Value = "-";
                DataAnime[9, RowIndex + 1].Value = "-";
                DataAnime[10, RowIndex + 1].Value = dataTable2.Rows.Count.ToString() + "/" + row["episodes_epn"].ToString() + "/" + DataAnime[10, RowIndex].Value.ToString();
                DataAnime[11, RowIndex + 1].Value = SUMFilesSize;
                DataAnime[12, RowIndex + 1].Value = "-";
                DataAnime[13, RowIndex + 1].Value = new Bitmap(1, 1);
                DataAnime[14, RowIndex + 1].Value = "-";
                DataAnime[15, RowIndex + 1].Value = "-";

                k++;

                DataAnime.Rows[RowIndex + 1].DefaultCellStyle.BackColor = Options_Color02.BackColor;
            }

        }

        //Rozevřít anime -> episody
        private void DataAnime_RozevritEpisodes(int RowIndex)
        {
            DataAnime[0, RowIndex].Value = new bool[3] { true, true, false };
            DataAnime[2, RowIndex].Value = Resources.i_Collapse;

            DataTable dataTable = DatabaseSelectEpisodeID(DataAnime[3, RowIndex].Value.ToString());

            foreach (DataRow row in dataTable.Rows)
            {
                DataAnime.Rows.Insert(RowIndex + 1, 1);

                Image Seen;

                if (row["files_watched"].ToString() == "1")
                    Seen = Resources.anidb_seen_yes;
                else
                    Seen = Resources.anidb_seen_no;

                int LenghtM = 0;

                try
                {
                    LenghtM = Convert.ToInt32(row["files_lenght"].ToString());
                }
                catch
                {
                }

                if (LenghtM > 60)
                    LenghtM = LenghtM / 60;

                string id_files = row["id_files"].ToString();
                string id_filesD = "10000000";

                while (id_filesD.Length - id_files.Length > 0)
                    id_files = "0" + id_files;

                DataAnime[0, RowIndex + 1].Value = new bool[3] { false, false, true };
                DataAnime[1, RowIndex + 1].Value = new Bitmap(1, 1);
                DataAnime[2, RowIndex + 1].Value = new Bitmap(1, 1);
                DataAnime[3, RowIndex + 1].Value = row["id_files"].ToString() + "/" + row["files_lid"].ToString();
                DataAnime[4, RowIndex + 1].Value = "     " + id_files + "     [" + row["groups_namezk"].ToString() + "]     (" + row["files_resultion"].ToString() + " " + row["files_typ"].ToString() + " " + row["files_video"].ToString() + " - " + row["files_audio"].ToString() + ")";
                DataAnime[5, RowIndex + 1].Value = null;
                DataAnime[6, RowIndex + 1].Value = null;
                DataAnime[7, RowIndex + 1].Value = null;
                DataAnime[8, RowIndex + 1].Value = row["files_dub"].ToString();
                DataAnime[9, RowIndex + 1].Value = row["files_sub"].ToString();
                DataAnime[10, RowIndex + 1].Value = null;
                DataAnime[11, RowIndex + 1].Value = FilesSize(row["files_size"].ToString());
                DataAnime[12, RowIndex + 1].Value = LenghtM.ToString() + "m";
                DataAnime[13, RowIndex + 1].Value = Seen;
                DataAnime[14, RowIndex + 1].Value = row["files_storage"].ToString();
                DataAnime[15, RowIndex + 1].Value = row["files_source"].ToString();
            }
        }

        //Sbalit anime
        private void DataAnime_ZavritAnime(int RowIndex)
        {
            DataAnime[0, RowIndex].Value = new bool[3] { false, false, false };
            DataAnime[1, RowIndex].Value = Resources.i_Expand;

            while (true)
            {
                if (RowIndex + 1 >= DataAnime.Rows.Count)
                    break;

                bool[] WTF = (bool[])DataAnime[0, RowIndex + 1].Value;

                if (WTF[1] || WTF[2])
                    DataAnime.Rows.RemoveAt(RowIndex + 1);
                else
                    break;
            }
        }

        //Sbalit anime -> episody
        private void DataAnime_ZavritEpisodes(int RowIndex)
        {
            DataAnime[0, RowIndex].Value = new bool[3] { false, true, false };
            DataAnime[2, RowIndex].Value = Resources.i_Expand;

            int k = 0;
            while (true)
            {
                if (RowIndex + 1 + k >= DataAnime.Rows.Count)
                    break;

                bool[] WTF = (bool[])DataAnime[0, RowIndex + 1 + k].Value;

                if (WTF[1])
                    break;

                if (WTF[2])
                    DataAnime.Rows.RemoveAt(RowIndex + 1 + k);
                else
                    k++;
            }
        }

        //Rozevřít anime
        private void DataAnime_Menu_Mn01_Mn01_Click(object sender, EventArgs e)
        {
            int k = 0;

            DataAnime.SuspendLayout();

            while (true)
            {
                bool Cancel = true;
                int j = 0;
                for (int i = k; i < DataAnime.Rows.Count; i++)
                {
                    j++;

                    bool[] WTF = (bool[])DataAnime[0, i].Value;

                    if (!WTF[0] && !WTF[1] && !WTF[2])
                    {
                        DataAnime_RozevritAnime(i);
                        Cancel = false;
                        k += j;
                        break;
                    }
                }

                if (Cancel)
                    break;
            }

            DataAnime.ResumeLayout();
        }

        //Rozevřít episody u anime
        private void DataAnime_Menu_Mn01_Mn02_Click(object sender, EventArgs e)
        {
            int k = 0;

            DataAnime.SuspendLayout();

            while (true)
            {
                bool[] WTF;
                int j = 0;
                if (DataAnime.SelectedRows[0].Index - k < 0)
                    WTF = (bool[])DataAnime[0, 0].Value;
                else
                {
                    j = DataAnime.SelectedRows[0].Index - k;
                    WTF = (bool[])DataAnime[0, j].Value;
                }

                if (!WTF[1] && !WTF[2])
                {
                    while (true)
                    {
                        WTF = (bool[])DataAnime[0, j + 1].Value;

                        if (!WTF[0] && WTF[1] && !WTF[2])
                            DataAnime_RozevritEpisodes(j + 1);
                        else if (!WTF[1] && !WTF[2])
                            break;

                        j++;
                    }

                    break;
                }

                k++;
            }

            DataAnime.ResumeLayout();
        }

        //Rozevřít vše
        private void DataAnime_Menu_Mn01_Mn03_Click(object sender, EventArgs e)
        {
            int k = 0;

            DataAnime.SuspendLayout();

            while (true)
            {
                bool Cancel = true;
                int j = 0;
                for (int i = k; i < DataAnime.Rows.Count; i++)
                {
                    j++;

                    bool[] WTF = (bool[])DataAnime[0, i].Value;

                    if (!WTF[0] && WTF[1] && !WTF[2])
                    {
                        DataAnime_RozevritEpisodes(i);
                        Cancel = false;
                        k += j;
                        break;
                    }

                    if (!WTF[0] && !WTF[1] && !WTF[2])
                    {
                        DataAnime_RozevritAnime(i);
                        Cancel = false;
                        k += j;
                        break;
                    }
                }

                if (Cancel)
                    break;
            }

            DataAnime.ResumeLayout();
        }

        //Sbalit episody u anime
        private void DataAnime_Menu_Mn01_Mn04_Click(object sender, EventArgs e)
        {
            int k = 0;

            DataAnime.SuspendLayout();

            while (true)
            {
                bool[] WTF;
                int j = 0;

                if (DataAnime.SelectedRows[0].Index - k < 0)
                    WTF = (bool[])DataAnime[0, 0].Value;
                else
                {
                    j = DataAnime.SelectedRows[0].Index - k;
                    WTF = (bool[])DataAnime[0, j].Value;
                }

                if (!WTF[1] && !WTF[2])
                {
                    while (true)
                    {
                        j++;

                        WTF = (bool[])DataAnime[0, j].Value;

                        if (!WTF[1] && !WTF[2])
                            break;
                        else if (WTF[1])
                            DataAnime_ZavritEpisodes(j);
                    }
                    break;
                }

                k++;
            }

            DataAnime.ResumeLayout();
        }

        //Sbalit všechny episody
        private void DataAnime_Menu_Mn01_Mn05_Click(object sender, EventArgs e)
        {
            int k = 0;

            DataAnime.SuspendLayout();

            while (true)
            {
                if (k >= DataAnime.Rows.Count)
                    break;

                bool[] WTF = (bool[])DataAnime[0, k].Value;

                if (WTF[0] && WTF[1] && !WTF[2])
                    DataAnime_ZavritEpisodes(k);

                k++;
            }

            DataAnime.ResumeLayout();
        }

        //Sbalit anime
        private void DataAnime_Menu_Mn01_Mn06_Click(object sender, EventArgs e)
        {
            DataAnime.SuspendLayout();

            for (int i = 0; i < DataAnime.Rows.Count; i++)
                DataAnime_ZavritAnime(i);

            DataAnime.ResumeLayout();
        }

        //Přidat / Upravit do MyListu
        private void DataAnime_Menu_Mn02_Mn01_Click(object sender, EventArgs e)
        {
            string MSource = "";
            string MStorage = "";
            string MState = "1";
            string MOther = "";
            string MWatched = "0";

            if (Options_MylistStorage.Text.Length > 0)
            {
                MSource = Options_MylistSource.Text;
                MStorage = Options_MylistStorage.Text;
                MOther = Options_MylistOther.Text;
                MState = Options_MylistState.SelectedIndex.ToString();
                if (Options_CH02.Checked)
                    MWatched = "1";
                else
                    MWatched = "0";
            }

            MyListAdd myListAdd = new MyListAdd(MState, MSource, MStorage, MOther, MWatched, GlobalMyList);

            myListAdd.ShowDialog();
            GlobalMyList = myListAdd.ML;

            if (myListAdd.DialogResult == DialogResult.OK)
            {
                MSource = myListAdd.Options_MylistSource.Text;
                MStorage = myListAdd.Options_MylistStorage.Text;
                MState = myListAdd.Options_MylistState.SelectedIndex.ToString();
                MOther = myListAdd.Options_MylistOther.Text;
                MWatched = "0";

                if (myListAdd.Options_CH02.Checked)
                    MWatched = "1";

                foreach (DataGridViewRow Row in DataAnime.SelectedRows)
                {
                    bool[] WTF = (bool[])DataAnime[0, Row.Index].Value;

                    if (!WTF[1] && !WTF[2])
                    {
                        DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataAnime[3, Row.Index].Value.ToString());

                        foreach (DataRow RowF in DFiles.Rows)
                            if (RowF["files_lid"].ToString() != "0")
                                ComunicationNewTask("MYLISTADD edit=1&fid=" + RowF["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                            else
                                ComunicationNewTask("MYLISTADD edit=0&fid=" + RowF["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                    }
                    else if (WTF[1] && !WTF[2])
                    {
                        DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + DataAnime[3, Row.Index].Value.ToString());

                        foreach (DataRow RowF in DFiles.Rows)
                            if (RowF["files_lid"].ToString() != "0")
                                ComunicationNewTask("MYLISTADD edit=1&fid=" + RowF["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                            else
                                ComunicationNewTask("MYLISTADD edit=0&fid=" + RowF["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                    }
                    else if (!WTF[1] && WTF[2])
                    {
                        string[] Id = DataAnime[3, Row.Index].Value.ToString().Split('/');

                        if (Id[1] != "0")
                            ComunicationNewTask("MYLISTADD edit=1&fid=" + Id[0] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                        else
                            ComunicationNewTask("MYLISTADD edit=0&fid=" + Id[0] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                    }
                }
            }
        }

        //Smazání z MyListu
        private void DataAnime_Menu_Mn02_Mn02_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in DataAnime.SelectedRows)
            {
                bool[] WTF = (bool[])DataAnime[0, Row.Index].Value;

                if (!WTF[1] && !WTF[2])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataAnime[3, Row.Index].Value.ToString());

                    foreach (DataRow RowF in DFiles.Rows)
                        ComunicationNewTask("MYLISTDEL fid=" + RowF["id_files"]);
                }

                if (WTF[1] && !WTF[2])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + DataAnime[3, Row.Index].Value.ToString());

                    foreach (DataRow RowF in DFiles.Rows)
                        ComunicationNewTask("MYLISTDEL fid=" + RowF["id_files"]);
                }

                if (!WTF[1] && WTF[2])
                {
                    string[] Id = DataAnime[3, Row.Index].Value.ToString().Split('/');

                    if (Id[1] != "0")
                        ComunicationNewTask("MYLISTDEL fid=" + Id[0]);
                }
            }
        }

        //Nastavit shlédnuto v MyListu
        private void DataAnime_Menu_Mn02_Mn03_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in DataAnime.SelectedRows)
            {
                bool[] WTF = (bool[])DataAnime[0, Row.Index].Value;

                if (!WTF[1] && !WTF[2])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataAnime[3, Row.Index].Value.ToString());

                    foreach (DataRow RowF in DFiles.Rows)
                        if (RowF["files_lid"].ToString() != "0")
                            ComunicationNewTask("MYLISTADD edit=1&fid=" + RowF["id_files"] + "&state=1&viewed=1");
                        else
                            ComunicationNewTask("MYLISTADD edit=0&fid=" + RowF["id_files"] + "&state=1&viewed=1");
                }

                if (WTF[1] && !WTF[2])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + DataAnime[3, Row.Index].Value.ToString());

                    foreach (DataRow RowF in DFiles.Rows)
                        if (RowF["files_lid"].ToString() != "0")
                            ComunicationNewTask("MYLISTADD edit=1&fid=" + RowF["id_files"] + "&state=1&viewed=1");
                        else
                            ComunicationNewTask("MYLISTADD edit=0&fid=" + RowF["id_files"] + "&state=1&viewed=1");
                }

                if (!WTF[1] && WTF[2])
                {
                    string[] Id = DataAnime[3, Row.Index].Value.ToString().Split('/');

                    if (Id[1] != "0")
                        ComunicationNewTask("MYLISTADD edit=1&fid=" + Id[0] + "&state=1&viewed=1");
                    else
                        ComunicationNewTask("MYLISTADD edit=0&fid=" + Id[0] + "&state=1&viewed=1");
                }
            }
        }

        //Aktualizace - Anime
        private void DataAnime_Menu_Mn04_Mn01_Click(object sender, EventArgs e)
        {
            DataAnime_Menu.Hide();

            foreach (DataGridViewRow Row in DataAnime.SelectedRows)
            {
                bool[] WTF = (bool[])DataAnime[0, Row.Index].Value;

                if (!WTF[1] && !WTF[2])
                    ComunicationNewTask("ANIME aid=" + DataAnime[3, Row.Index].Value.ToString() + "&amask=BEE0FE01");

                if (WTF[1] && !WTF[2])
                {
                    DataTable DEpisodes = DatabaseSelect("SELECT * FROM episodes WHERE id_episodes=" + DataAnime[3, Row.Index].Value.ToString());

                    ComunicationNewTask("ANIME aid=" + DEpisodes.Rows[0]["id_anime"].ToString() + "&amask=BEE0FE01");
                }

                if (!WTF[1] && WTF[2])
                {
                    string[] Id = DataAnime[3, Row.Index].Value.ToString().Split('/');
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files=" + Id[0]);

                    ComunicationNewTask("ANIME aid=" + DFiles.Rows[0]["id_anime"].ToString() + "&amask=BEE0FE01");
                }
            }
        }

        //Aktualizace - Episodes
        private void DataAnime_Menu_Mn04_Mn02_Click(object sender, EventArgs e)
        {
            DataAnime_Menu.Hide();

            foreach (DataGridViewRow Row in DataAnime.SelectedRows)
            {
                bool[] WTF = (bool[])DataAnime[0, Row.Index].Value;

                if (!WTF[1] && !WTF[2])
                {
                    DataTable DEpisodes = DatabaseSelect("SELECT * FROM episodes WHERE id_anime=" + DataAnime[3, Row.Index].Value.ToString());

                    for (int i = 0; i < DEpisodes.Rows.Count; i++)
                        ComunicationNewTask("EPISODE eid=" + DEpisodes.Rows[i]["id_episodes"].ToString());
                }

                if (WTF[1] && !WTF[2])
                    ComunicationNewTask("EPISODE eid=" + DataAnime[3, Row.Index].Value.ToString());

                if (!WTF[1] && WTF[2])
                {
                    string[] Id = DataAnime[3, Row.Index].Value.ToString().Split('/');
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files=" + Id[0]);

                    for (int i = 0; i < DFiles.Rows.Count; i++)
                        ComunicationNewTask("EPISODE eid=" + DFiles.Rows[i]["id_episodes"].ToString());
                }
            }
        }

        //Aktualizace - Files
        private void DataAnime_Menu_Mn04_Mn03_Click(object sender, EventArgs e)
        {
            DataAnime_Menu.Hide();

            foreach (DataGridViewRow Row in DataAnime.SelectedRows)
            {
                bool[] WTF = (bool[])DataAnime[0, Row.Index].Value;

                if (!WTF[1] && !WTF[2])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataAnime[3, Row.Index].Value.ToString());

                    for (int i = 0; i < DFiles.Rows.Count; i++)
                        ComunicationNewTask("FILE size=" + DFiles.Rows[i]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[i]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                }

                if (WTF[1] && !WTF[2])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + DataAnime[3, Row.Index].Value.ToString());

                    for (int i = 0; i < DFiles.Rows.Count; i++)
                        ComunicationNewTask("FILE size=" + DFiles.Rows[i]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[i]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                }

                if (!WTF[1] && WTF[2])
                {
                    string[] Id = DataAnime[3, Row.Index].Value.ToString().Split('/');
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files=" + Id[0]);

                    ComunicationNewTask("FILE size=" + DFiles.Rows[0]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[0]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                }
            }
        }

        //Aktualizace - MyList
        private void DataAnime_Menu_Mn04_Mn04_Click(object sender, EventArgs e)
        {
            DataAnime_Menu.Hide();

            foreach (DataGridViewRow Row in DataAnime.SelectedRows)
            {
                bool[] WTF = (bool[])DataAnime[0, Row.Index].Value;

                if (!WTF[1] && !WTF[2])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + DataAnime[3, Row.Index].Value.ToString());

                    for (int i = 0; i < DFiles.Rows.Count; i++)
                        ComunicationNewTask("MYLIST fid=" + DFiles.Rows[i]["id_files"].ToString());
                }

                if (WTF[1] && !WTF[2])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + DataAnime[3, Row.Index].Value.ToString());

                    for (int i = 0; i < DFiles.Rows.Count; i++)
                        ComunicationNewTask("MYLIST fid=" + DFiles.Rows[i]["id_files"].ToString());
                }

                if (!WTF[1] && WTF[2])
                {
                    string[] Id = DataAnime[3, Row.Index].Value.ToString().Split('/');
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files=" + Id[0]);

                    ComunicationNewTask("MYLIST fid=" + DFiles.Rows[0]["id_files"].ToString());
                }
            }
        }

        //Aktualizace - All
        private void DataAnime_Menu_Mn04_Mn05_Click(object sender, EventArgs e)
        {
            DataAnime_Menu.Hide();

            DataAnime_Menu_Mn04_Mn01_Click(sender, e);
            DataAnime_Menu_Mn04_Mn02_Click(sender, e);
            DataAnime_Menu_Mn04_Mn03_Click(sender, e);
            DataAnime_Menu_Mn04_Mn04_Click(sender, e);
        }

        //Smazání z databáze
        private void DataAnime_Menu_Mn03_Mn01_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.MessageBox_DeleteI, Language.MessageBox_Delete, MessageBoxButtons.YesNo) == DialogResult.Yes)

                foreach (DataGridViewRow Row in DataAnime.SelectedRows)
                {
                    bool[] WTF = (bool[])DataAnime[0, Row.Index].Value;

                    if (!WTF[1] && !WTF[2])
                    {
                        DatabaseAdd("DELETE FROM anime where id_anime=" + DataAnime[3, Row.Index].Value.ToString());
                        DatabaseAdd("DELETE FROM episodes where id_anime=" + DataAnime[3, Row.Index].Value.ToString());
                        DatabaseAdd("DELETE FROM files where id_anime=" + DataAnime[3, Row.Index].Value.ToString());
                    }

                    if (WTF[1] && !WTF[2])
                    {
                        DatabaseAdd("DELETE FROM episodes where id_episodes=" + DataAnime[3, Row.Index].Value.ToString());
                        DatabaseAdd("DELETE FROM files where id_episodes=" + DataAnime[3, Row.Index].Value.ToString());
                    }

                    if (!WTF[1] && WTF[2])
                    {
                        DatabaseAdd("DELETE FROM files where id_files=" + DataAnime[3, Row.Index].Value.ToString());
                    }
                }
        }
        #endregion

        #region Anime
        //Načtení informací o anime z uzlu
        private void AnimeTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (AnimeTree.SelectedNode == null)
                return;

            Anime_GR01.Visible = true;
            Anime_Rel.Visible = false;
            Anime_RelDel.Visible = false;

            DataTable DAnime = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + AnimeTree.SelectedNode.Name);
            DataTable DGenres = DatabaseSelect("SELECT * FROM genres INNER JOIN genres_relations ON genres.id_grenres = genres_relations.id_genres WHERE id_anime=" + AnimeTree.SelectedNode.Name + " ORDER BY genres_genre");
            DataTable DEpisodes = DatabaseSelect("SELECT * FROM episodes WHERE id_anime=" + AnimeTree.SelectedNode.Name + " ORDER BY episodes_spec ASC, episodes_epn ASC");
            DataTable DRelations = DatabaseSelect("SELECT * FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime=" + AnimeTree.SelectedNode.Name + " ORDER BY id_relation");
            DataTable DTags = DatabaseSelect("SELECT tags_name FROM tags_relation INNER JOIN tags ON tags.id_tags=tags_relation.id_tags WHERE id_anime=" + AnimeTree.SelectedNode.Name + " ORDER BY tags_name");
            DataTable DManga = DatabaseSelect("SELECT manga_anime.id_manga, manga_nazevjap FROM manga_anime INNER JOIN manga On manga.id_manga=manga_anime.id_manga WHERE manga_anime.id_anime=" + AnimeTree.SelectedNode.Name);

            try
            {
                DateTime Cas = DateTime.Parse(DAnime.Rows[0]["anime_seen"].ToString());
                Anime_Seen.Text = String.Format("{0:00}", Cas.Day) + "." + String.Format("{0:00}", Cas.Month) + "." + Cas.Year.ToString();
            }
            catch
            {
            }

            Anime_CB02.SelectedIndexChanged -= new EventHandler(Anime_CB02_SelectedIndexChanged);

            try
            {
                Anime_Rat.Value = Convert.ToInt32(DAnime.Rows[0]["anime_rating"].ToString());

                Anime_CB02.Items.Clear();
                for (int i = 0; i < DTags.Rows.Count; i++)
                    Anime_CB02.Items.Add(DTags.Rows[i]["tags_name"].ToString());

                Anime_CB02.Text = DTags.Rows[0]["tags_name"].ToString();
            }
            catch
            {
            }

            Anime_CB02.SelectedIndexChanged += new EventHandler(Anime_CB02_SelectedIndexChanged);

            if (Anime_CB02.Items.Count == 0)
                Anime_CB02.Visible = false;
            else
                Anime_CB02.Visible = true;

            Anime_GR01.Text = DAnime.Rows[0]["anime_nazevjap"].ToString();
            if (DAnime.Rows[0]["anime_nazeveng"].ToString() != "")
                Anime_LB01.Text = DAnime.Rows[0]["id_anime"].ToString() + ": " + DAnime.Rows[0]["anime_nazeveng"].ToString();
            else
                Anime_LB01.Text = DAnime.Rows[0]["id_anime"].ToString() + ": " + DAnime.Rows[0]["anime_nazevjap"].ToString();

            Anime_LB02.Text = "http://anidb.net/a" + DAnime.Rows[0]["id_anime"];

            AnimeData.Rows.Clear();

            foreach (DataRow RowE in DEpisodes.Rows)
            {
                string Spec = "";

                if (RowE["episodes_spec"].ToString() != "0")
                    Spec = RowE["episodes_spec"].ToString();

                AnimeData.Rows.Add(
                new bool[2] { false, false },
                Resources.i_Expand,
                Spec + RowE["episodes_epn"].ToString(),
                RowE["episodes_nazeveng"].ToString(),
                RowE["episodes_lenght"].ToString() + "m",
                RowE["id_episodes"].ToString(),
                new Bitmap(1, 1),
                new Bitmap(1, 1),
                new Bitmap(1, 1),
                new Bitmap(1, 1),
                new Bitmap(1, 1),
                new Bitmap(1, 1),
                new Bitmap(1, 1)
                );

                AnimeData.Rows[AnimeData.Rows.Count - 1].DefaultCellStyle.BackColor = Options_Color02.BackColor;
            }

            DateTime AStart = new DateTime(1800, 1, 1);
            DateTime AEnd = new DateTime(1800, 1, 1);
            string ADate = "";

            //Nevím proč ale je to kurva obráceně, prostě anime_date_end=anime_date_air a anime_date_air=anime_date_end
            try
            {
                AStart = (DateTime)DAnime.Rows[0]["anime_date_end"];
            }
            catch
            {
            }

            try
            {
                AEnd = (DateTime)DAnime.Rows[0]["anime_date_air"];
            }
            catch
            {
            }

            Anime_DateOK.Image = null;

            if (AStart.Year != 1800 && AStart.Year != 1970)
                ADate = AStart.ToString().Replace(" ", "").Replace("0:00:00", "");
            else
                ADate = "??.??.????";

            if (AEnd.Year != 1800 && AEnd.Year != 1970 && AEnd != AStart)
                ADate += " - " + AEnd.ToString().Replace(" ", "").Replace("0:00:00", "");

            string[] TRok = DAnime.Rows[0]["anime_rok"].ToString().Split('-');

            if (TRok.Length == 2)
                if (TRok[1] == TRok[0])
                    DAnime.Rows[0]["anime_rok"] = TRok[0];

            Anime_OP01.Text = DAnime.Rows[0]["anime_nazevkaj"].ToString();
            Anime_OP02.Text = DAnime.Rows[0]["anime_typ"].ToString();
            Anime_OP03.Text = DAnime.Rows[0]["anime_rok"].ToString();
            Anime_OP04.Text = DAnime.Rows[0]["anime_epn"].ToString();
            Anime_OP06.Text = ADate;
            Anime_OP07.Text = DAnime.Rows[0]["anime_length"].ToString();

            Anime_LB08.Text = DAnime.Rows[0]["anime_url"].ToString();

            Anime_LB08.Visible = true;

            if (Anime_LB08.Text == "")
                Anime_LB08.Visible = false;

            if (AEnd >= AStart)
            {
                Anime_DateOK.Image = Resources.i_Check;
                Anime_DateOK.Location = new Point(Anime_OP06.Size.Width + 10 + Anime_OP06.Location.X, Anime_DateOK.Location.Y);
            }

            Anime_CB01.Items.Clear();

            Anime_CB01.SelectedIndexChanged -= new EventHandler(Anime_CB01_SelectedIndexChanged);

            try
            {
                for (int i = 0; i < DGenres.Rows.Count; i++)
                    Anime_CB01.Items.Add(DGenres.Rows[i]["genres_genre"].ToString());

                Anime_CB01.Text = DGenres.Rows[0]["genres_genre"].ToString();
            }
            catch
            {
            }

            Anime_CB01.SelectedIndexChanged -= new EventHandler(Anime_CB01_SelectedIndexChanged);

            if (Anime_CB01.Items.Count == 0)
            {
                Anime_CB01.Visible = false;
                Anime_LB07.Visible = false;
            }
            else
            {
                Anime_CB01.Visible = true;
                Anime_LB07.Visible = true;
            }

            Anime_Img.BackgroundImage = null;
            if (DAnime.Rows[0]["anime_obr"].ToString() == "None.jpg")
            {
                if (File.Exists(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString()))
                {
                    StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());

                    Image img = Image.FromStream(Cti.BaseStream);

                    Cti.Close();
                    Cti.Dispose();

                    Anime_Img.BackgroundImage = img;
                }

            }
            else if (!File.Exists(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString()))
            {
                if (DAnime.Rows[0]["anime_obr"].ToString() != "")
                {
                    WebClient WBC = new WebClient();
                    WBC.DownloadFileAsync(new Uri(AniSubImgUrl + DAnime.Rows[0]["anime_obr"].ToString()), GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());
                    WBC.DownloadFileCompleted += new AsyncCompletedEventHandler(WBC_DownloadFileCompleted);
                }
                else
                    ComunicationNewTask("ANIME aid=" + DAnime.Rows[0]["id_anime"].ToString() + "&amask=BEE0FE01");
            }
            else
            {
                try
                {
                    StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());

                    Image img = Image.FromStream(Cti.BaseStream);

                    Cti.Close();
                    Cti.Dispose();

                    if (img.Height > 279 || img.Width > 255)
                    {
                        img = resizeImage(img, new Size(225, 279));

                        FileDelete(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());
                        img.Save(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString(), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                    Anime_Img.BackgroundImage = img;
                }
                catch
                {
                    FileDelete(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());
                }
            }

            Anime_RelationTree.Nodes.Clear();
            if (DRelations.Rows.Count > 0 || DManga.Rows.Count > 0)
            {
                Anime_RelationTree.Visible = true;

                if (DRelations.Rows.Count > 0)
                {
                    Anime_RelationTree.Nodes.Add("N", Language.MainTab_Mn03);

                    foreach (DataRow row in DRelations.Rows)
                    {
                        switch (row["id_relation"].ToString())
                        {
                            case "1":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn01 + row["anime_nazevjap"].ToString());
                                break;

                            case "2":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn02 + row["anime_nazevjap"].ToString());
                                break;

                            case "11":
                            case "12":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn03 + row["anime_nazevjap"].ToString());
                                break;

                            case "21":
                            case "22":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn04 + row["anime_nazevjap"].ToString());
                                break;

                            case "31":
                            case "32":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn05 + row["anime_nazevjap"].ToString());
                                break;

                            case "41":
                            case "42":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn06 + row["anime_nazevjap"].ToString());
                                break;

                            case "51":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn07 + row["anime_nazevjap"].ToString());
                                break;

                            case "52":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn08 + row["anime_nazevjap"].ToString());
                                break;

                            case "61":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn09 + row["anime_nazevjap"].ToString());
                                break;

                            case "62":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn10 + row["anime_nazevjap"].ToString());
                                break;

                            case "100":
                                Anime_RelationTree.Nodes.Add("A" + row["id_anime_related"].ToString(), Language.Anime_RelationTree_Mn11 + row["anime_nazevjap"].ToString());
                                break;
                        }
                    }
                }

                if (DRelations.Rows.Count > 0 && DManga.Rows.Count > 0)
                    Anime_RelationTree.Nodes.Add("N", "");

                if (DManga.Rows.Count > 0)
                {
                    Anime_RelationTree.Nodes.Add("N", Language.MainTab_Mn07);
                    foreach (DataRow row in DManga.Rows)
                        Anime_RelationTree.Nodes.Add("M" + row["id_manga"].ToString(), row["manga_nazevjap"].ToString());

                }
            }
            else
                Anime_RelationTree.Visible = false;
        }

        //Zobrazení obrázku po dokončení stahování
        void WBC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                DataTable DAnime = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + AnimeTree.SelectedNode.Name);
                StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());

                Image img = Image.FromStream(Cti.BaseStream);

                Cti.Close();
                Cti.Dispose();

                if (img.Height > 279 || img.Width > 255)
                {
                    img = resizeImage(img, new Size(225, 279));
                    FileDelete(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());
                    img.Save(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString(), System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                Anime_Img.BackgroundImage = img;
            }
            catch
            {
            }
        }

        //Otevření stránky s anime
        private void Anime_LB02_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Anime_LB02.Text);
        }

        //Kliknutí na link
        private void Anime_LB01_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Anime_LB02_LinkClicked(sender, e);
        }

        //Rozevírání
        private void AnimeData_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = AnimeData.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right && Hit.RowIndex >= 0)
            {
                bool[] WTF = (bool[])AnimeData[0, Hit.RowIndex].Value;

                AnimeData.Rows[Hit.RowIndex].Selected = true;

                if (WTF[1] && AnimeData.SelectedRows.Count == 1)
                    AnimeData_Menu_Mn04.Visible = true;
                else
                    AnimeData_Menu_Mn04.Visible = false;

                AnimeData_Menu.Show(MousePosition.X, MousePosition.Y);
            }
            else if (Hit.RowIndex >= 0 && Hit.ColumnIndex >= 0)
            {
                bool[] WTF = (bool[])AnimeData[0, Hit.RowIndex].Value;

                if (Hit.ColumnIndex == 1 && !WTF[0] && !WTF[1])
                    AnimeData_RozevritEpisody(Hit.RowIndex);
                else if (Hit.ColumnIndex == 1 && WTF[0] && !WTF[1])
                    AnimeData_ZavritEpisody(Hit.RowIndex);
            }
        }

        //Pouštění anime
        private void AnimeData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = AnimeData.HitTest(e.X, e.Y);
            if (Hit.RowIndex >= 0 && Hit.ColumnIndex >= 0)
            {
                bool[] WTF = (bool[])AnimeData[0, Hit.RowIndex].Value;

                if (Hit.ColumnIndex == 3 && WTF[1])
                    AnimeData_PustiAnime(Hit.RowIndex);
            }
        }

        //Spustit soubor
        private void AnimeData_PustiAnime(int RowIndex)
        {
            DataTable Files = DatabaseSelect("SELECT * FROM files WHERE id_files=" + AnimeData[5, RowIndex].Value.ToString());

            if (File.Exists(Files.Rows[0]["files_localfile"].ToString()))
                Process.Start(Files.Rows[0]["files_localfile"].ToString());
        }

        //Rozevřít episody
        private void AnimeData_RozevritEpisody(int RowIndex)
        {
            AnimeData[0, RowIndex].Value = new bool[2] { true, false };
            AnimeData[1, RowIndex].Value = Resources.i_Collapse;

            DataTable dataTable = DatabaseSelect("SELECT * FROM files INNER JOIN groups ON groups.id_groups=files.id_groups WHERE id_episodes=" + AnimeData[5, RowIndex].Value.ToString());

            foreach (DataRow row in dataTable.Rows)
            {
                AnimeData.Rows.Insert(RowIndex + 1, 1);

                Image Seen = new Bitmap(1, 1);
                Image Extension = new Bitmap(1, 1);
                Image Video = new Bitmap(1, 1);

                string Dcen = FilesState(row["files_state"].ToString());
                string Dver = "";
                string Dinv = "";

                if (Dcen.Contains("v5"))
                    Dver = "     v5";
                else if (Dcen.Contains("v4"))
                    Dver = "     v4";
                else if (Dcen.Contains("v3"))
                    Dver = "     v3";
                else if (Dcen.Contains("v2"))
                    Dver = "     v2";

                if (Dcen.Contains("CRC not match"))
                    Dinv = "     CRC not match";

                if (Dcen.Contains("cen"))
                    Dcen = "     {CEN}";
                else if (Dcen.Contains("UNC"))
                    Dcen = "     {UNC}";
                else
                    Dcen = "";

                if (row["files_watched"].ToString() == "1")
                    Seen = Resources.anidb_seen_yes;
                else
                    Seen = Resources.anidb_seen_no;

                switch (row["files_extension"].ToString())
                {
                    case "mkv":
                        Extension = Resources.anidb_ext_mkv;
                        break;

                    case "avi":
                        Extension = Resources.anidb_ext_avi;
                        break;

                    case "mp4":
                        Extension = Resources.anidb_ext_mp4;
                        break;

                    case "ogm":
                        Extension = Resources.anidb_ext_ogm;
                        break;

                    case "srt":
                        Extension = Resources.anidb_ext_srt;
                        break;

                    case "wmv":
                        Extension = Resources.anidb_ext_wmv;
                        break;

                    case "zip":
                        Extension = Resources.anidb_ext_zip;
                        break;
                }

                Image Stastus = new Bitmap(1, 1);
                Image Rip = new Bitmap(1, 1);

                switch (row["files_status"].ToString())
                {
                    case "0":
                        Stastus = Resources.anidb_state_unknown;
                        break;

                    case "1":
                        Stastus = Resources.anidb_state_onhdd;
                        break;

                    case "2":
                        Stastus = Resources.anidb_state_oncd;
                        break;

                    case "3":
                        Stastus = Resources.anidb_state_deleted;
                        break;
                }

                switch (row["files_typ"].ToString())
                {
                    case "Blu-ray":
                        Rip = Resources.anidb_atype_ova;
                        break;

                    case "HDTV":
                        Rip = Resources.anidb_atype_tv_special;
                        break;

                    case "DVD":
                        Rip = Resources.Anidb_filestate_ondvd;
                        break;

                    case "DTV":
                        Rip = Resources.anidb_atype_tv_series;
                        break;

                    case "www":
                        Rip = Resources.anidb_atype_web;
                        break;

                    case "unknown":
                        Rip = Resources.anidb_atype_other;
                        break;

                    case "VHS":
                        Rip = Resources.Anidb_filestate_onvhs;
                        break;

                    default:
                        Rip = Resources.anidb_atype_other;
                        break;
                }

                if (row["files_depth"].ToString().ToLower().Contains("10"))
                    Video = Resources.anidb_videoStream_h10p;
                else if (row["files_video"].ToString().ToLower().Contains("h264"))
                    Video = Resources.anidb_videoStream_h264;
                else if (row["files_video"].ToString().ToLower().Contains("xvid"))
                    Video = Resources.anidb_videoStream_xvid;
                else if (row["files_video"].ToString().ToLower().Contains("divx"))
                    Video = Resources.anidb_videoStream_divx;
                else if (row["files_video"].ToString().ToLower().Contains("real"))
                    Video = Resources.anidb_videoStream_real;
                else if (row["files_video"].ToString().ToLower().Contains("wmv"))
                    Video = Resources.anidb_videoStream_wmv;

                string id_files = row["id_files"].ToString();
                string id_filesD = "10000000";
                string id_date = (((DateTime)(row["files_date_air"])).Day < 10 ? "0" + ((DateTime)(row["files_date_air"])).Day.ToString() : ((DateTime)(row["files_date_air"])).Day.ToString()) + "." + (((DateTime)(row["files_date_air"])).Month < 10 ? "0" + ((DateTime)(row["files_date_air"])).Month.ToString() : ((DateTime)(row["files_date_air"])).Month.ToString()) + "." + ((DateTime)(row["files_date_air"])).Year;

                while (id_filesD.Length - id_files.Length > 0)
                    id_files = "0" + id_files;

                AnimeData[0, RowIndex + 1].Value = new bool[2] { false, true };
                AnimeData[1, RowIndex + 1].Value = new Bitmap(1, 1);
                AnimeData[2, RowIndex + 1].Value = null;
                AnimeData[3, RowIndex + 1].Value = id_files + "     [" + row["groups_namezk"].ToString() + "]     (" + row["files_resultion"].ToString() + " " + row["files_typ"].ToString() + " " + row["files_video"].ToString() + " " + row["files_audio"].ToString() + ")     *     " + row["files_storage"].ToString() + "     *     " + row["files_source"].ToString() + "     *     " + id_date + Dcen + Dver + Dinv;
                AnimeData[4, RowIndex + 1].Value = null;
                AnimeData[5, RowIndex + 1].Value = row["id_files"].ToString();
                AnimeData[6, RowIndex + 1].Value = Seen;
                AnimeData[7, RowIndex + 1].Value = Stastus;
                AnimeData[8, RowIndex + 1].Value = Rip;
                AnimeData[9, RowIndex + 1].Value = Extension;
                AnimeData[10, RowIndex + 1].Value = Video;
                AnimeData[11, RowIndex + 1].Value = FilesLangAudio(row["files_dub"].ToString());
                AnimeData[12, RowIndex + 1].Value = FilesLangSub(row["files_sub"].ToString());

                AnimeData.Rows[RowIndex + 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        //Zavřít episody
        private void AnimeData_ZavritEpisody(int RowIndex)
        {
            AnimeData[0, RowIndex].Value = new bool[2] { false, false };
            AnimeData[1, RowIndex].Value = Resources.i_Expand;

            while (RowIndex + 1 < AnimeData.Rows.Count)
            {
                bool[] WTF = (bool[])AnimeData[0, RowIndex + 1].Value;
                if (!WTF[1])
                    break;

                AnimeData.Rows.RemoveAt(RowIndex + 1);
            }
        }

        //Rozevřít episody
        private void AnimeData_Menu_Mn01_Mn01_Click(object sender, EventArgs e)
        {
            AnimeData.SuspendLayout();

            for (int i = 0; i < AnimeData.Rows.Count; i++)
            {
                bool[] WTF = (bool[])AnimeData[0, i].Value;

                if (!WTF[0] && !WTF[1])
                    AnimeData_RozevritEpisody(i);
            }

            AnimeData.ResumeLayout();
        }

        //Sbalit episody
        private void AnimeData_Menu_Mn01_Mn02_Click(object sender, EventArgs e)
        {
            AnimeData.SuspendLayout();

            for (int i = 0; i < AnimeData.Rows.Count; i++)
            {
                bool[] WTF = (bool[])AnimeData[0, i].Value;

                if (WTF[0] && !WTF[1])
                    AnimeData_ZavritEpisody(i);
            }

            AnimeData.ResumeLayout();
        }

        //Přidání do MyListu
        private void AnimeData_Menu_Mn02_Mn01_Click(object sender, EventArgs e)
        {
            string MSource = "";
            string MStorage = "";
            string MState = "1";
            string MOther = "";
            string MWatched = "0";

            if (Options_MylistStorage.Text.Length > 0)
            {
                MSource = Options_MylistSource.Text;
                MStorage = Options_MylistStorage.Text;
                MOther = Options_MylistOther.Text;
                MState = Options_MylistState.SelectedIndex.ToString();
                if (Options_CH02.Checked)
                    MWatched = "1";
                else
                    MWatched = "0";
            }
            else if (AnimeData.SelectedRows.Count > 0)
            {
                bool[] WTF = (bool[])AnimeData[0, AnimeData.SelectedRows[0].Index].Value;

                DataTable DataFile = null;

                if (!WTF[1])
                {
                    DataFile = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + AnimeData[5, AnimeData.SelectedRows[0].Index].Value.ToString());
                }
                else if (WTF[1])
                {
                    DataFile = DatabaseSelect("SELECT * FROM files WHERE id_files=" + AnimeData[5, AnimeData.SelectedRows[0].Index].Value.ToString());
                }

                if (DataFile.Rows.Count > 0)
                {
                    MSource = DataFile.Rows[0]["files_source"].ToString();
                    MStorage = DataFile.Rows[0]["files_storage"].ToString();
                    MOther = DataFile.Rows[0]["files_other"].ToString();
                    MWatched = DataFile.Rows[0]["files_watched"].ToString();
                    MState = DataFile.Rows[0]["files_status"].ToString();
                }
            }

            MyListAdd myListAdd = new MyListAdd(MState, MSource, MStorage, MOther, MWatched, GlobalMyList);

            myListAdd.ShowDialog();
            GlobalMyList = myListAdd.ML;

            if (myListAdd.DialogResult == DialogResult.OK)
            {
                MSource = myListAdd.Options_MylistSource.Text;
                MStorage = myListAdd.Options_MylistStorage.Text;
                MState = myListAdd.Options_MylistState.SelectedIndex.ToString();
                MOther = myListAdd.Options_MylistOther.Text;
                MWatched = "0";

                if (myListAdd.Options_CH02.Checked)
                    MWatched = "1";

                foreach (DataGridViewRow Row in AnimeData.SelectedRows)
                {
                    bool[] WTF = (bool[])AnimeData[0, Row.Index].Value;

                    if (!WTF[1])
                    {
                        DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + AnimeData[5, Row.Index].Value.ToString());

                        foreach (DataRow RowF in DFiles.Rows)
                            if (RowF["files_lid"].ToString() != "0")
                                ComunicationNewTask("MYLISTADD edit=1&fid=" + RowF["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                            else
                                ComunicationNewTask("MYLISTADD edit=0&fid=" + RowF["id_files"] + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                    }
                    else if (WTF[1])
                    {
                        DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files=" + AnimeData[5, Row.Index].Value.ToString());

                        if (DFiles.Rows[0]["files_lid"].ToString() != "0")
                            ComunicationNewTask("MYLISTADD edit=1&fid=" + AnimeData[5, Row.Index].Value.ToString() + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                        else
                            ComunicationNewTask("MYLISTADD edit=0&fid=" + AnimeData[5, Row.Index].Value.ToString() + "&source=" + MSource + "&storage=" + MStorage + "&other=" + MOther + "&state=" + MState + "&viewed=" + MWatched);
                    }
                }
            }
        }

        //Smazání z MyListu
        private void AnimeData_Menu_Mn02_Mn02_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in AnimeData.SelectedRows)
            {
                bool[] WTF = (bool[])AnimeData[0, Row.Index].Value;

                if (!WTF[1])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + AnimeData[5, Row.Index].Value.ToString());

                    foreach (DataRow RowF in DFiles.Rows)
                        ComunicationNewTask("MYLISTDEL fid=" + RowF["id_files"]);
                }

                if (WTF[1])
                {
                    ComunicationNewTask("MYLISTDEL fid=" + AnimeData[5, Row.Index].Value.ToString());
                }
            }
        }

        //Shlédnuto
        private void AnimeData_Menu_Mn02_Mn03_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in AnimeData.SelectedRows)
            {
                bool[] WTF = (bool[])AnimeData[0, Row.Index].Value;

                if (WTF[1])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files=" + AnimeData[5, Row.Index].Value.ToString());

                    if (DFiles.Rows[0]["files_lid"].ToString() != "0")
                        ComunicationNewTask("MYLISTADD edit=1&fid=" + DFiles.Rows[0]["id_files"].ToString() + "&state=1&viewed=1");
                    else
                        ComunicationNewTask("MYLISTADD edit=0&fid=" + DFiles.Rows[0]["id_files"].ToString() + "&state=1&viewed=1");
                }
                else if (!WTF[1])
                {
                    DataTable DEpisodes = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + AnimeData[5, Row.Index].Value.ToString());

                    for (int i = 0; i < DEpisodes.Rows.Count; i++)
                    {
                        if (DEpisodes.Rows[i]["files_lid"].ToString() != "0")
                            ComunicationNewTask("MYLISTADD edit=1&fid=" + DEpisodes.Rows[0]["id_files"].ToString() + "&state=1&viewed=1");
                        else
                            ComunicationNewTask("MYLISTADD edit=0&fid=" + DEpisodes.Rows[0]["id_files"].ToString() + "&state=1&viewed=1");
                    }
                }
            }
        }

        //Smazání z databáze
        private void AnimeData_Menu_Mn03_Mn01_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.MessageBox_DeleteI, Language.MessageBox_Delete, MessageBoxButtons.YesNo) == DialogResult.Yes)
                foreach (DataGridViewRow Row in AnimeData.SelectedRows)
                {
                    bool[] WTF = (bool[])AnimeData[0, Row.Index].Value;

                    if (!WTF[1])
                    {
                        DatabaseAdd("DELETE FROM episodes where id_episodes=" + AnimeData[5, Row.Index].Value.ToString());
                        DatabaseAdd("DELETE FROM files where id_episodes=" + AnimeData[5, Row.Index].Value.ToString());
                    }

                    if (WTF[1])
                    {
                        DatabaseAdd("DELETE FROM files where id_files=" + AnimeData[5, Row.Index].Value.ToString());
                    }
                }
        }

        //Otevření WIN kontextového menu
        private void AnimeData_Menu_Mn04_Click(object sender, EventArgs e)
        {
            if (AnimeData.SelectedRows.Count > 0)
            {
                DataTable Files = DatabaseSelect("SELECT * FROM files WHERE id_files=" + AnimeData[5, AnimeData.SelectedRows[0].Index].Value.ToString());

                if (Files.Rows.Count > 0)
                    if (File.Exists(Files.Rows[0]["files_localfile"].ToString()))
                    {
                        ShellContextMenu ctxMnu = new ShellContextMenu();
                        FileInfo[] arrFI = new FileInfo[1];
                        arrFI[0] = new FileInfo(Files.Rows[0]["files_localfile"].ToString());
                        ctxMnu.ShowContextMenu(arrFI, this.PointToScreen(new Point(MousePosition.X - 60, MousePosition.Y - 60)));
                    }
            }
        }

        //Rehash
        private void AnimeData_Menu_Mn06_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in AnimeData.SelectedRows)
            {
                bool[] WTF = (bool[])AnimeData[0, Row.Index].Value;

                if (WTF[1])
                {
                    DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_files=" + AnimeData[5, Row.Index].Value.ToString());

                    if (DFiles.Rows.Count > 0)
                        Nacti_Hash(DFiles.Rows[0]["files_localfile"].ToString());
                }
                else if (!WTF[1])
                {
                    DataTable DEpisodes = DatabaseSelect("SELECT * FROM files WHERE id_episodes=" + AnimeData[5, Row.Index].Value.ToString());

                    for (int i = 0; i < DEpisodes.Rows.Count; i++)
                        Nacti_Hash(DEpisodes.Rows[i]["files_localfile"].ToString());
                }
            }
        }

        //Aktualizace - Anime
        private void AnimeData_Menu_Mn05_Mn01_Click(object sender, EventArgs e)
        {
            AnimeData_Menu.Hide();

            ComunicationNewTask("ANIME aid=" + AnimeTree.SelectedNode.Name + "&amask=BEE0FE01");
        }

        //Aktualizace - Episodes
        private void AnimeData_Menu_Mn05_Mn02_Click(object sender, EventArgs e)
        {
            AnimeData_Menu.Hide();

            foreach (DataGridViewRow row in AnimeData.SelectedRows)
            {
                bool[] T = (bool[])AnimeData[0, row.Index].Value;

                if (!T[1])
                    ComunicationNewTask("EPISODE eid=" + AnimeData[5, row.Index].Value.ToString());
            }
        }

        //Aktualizace - Files
        private void AnimeData_Menu_Mn05_Mn03_Click(object sender, EventArgs e)
        {
            AnimeData_Menu.Hide();

            foreach (DataGridViewRow row in AnimeData.SelectedRows)
            {
                bool[] T = (bool[])AnimeData[0, row.Index].Value;

                if (T[1])
                    ComunicationNewTask("FILE fid=" + AnimeData[5, row.Index].Value.ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
            }
        }

        //Aktualizace - MyList
        private void AnimeData_Menu_Mn05_Mn04_Click(object sender, EventArgs e)
        {
            AnimeData_Menu.Hide();

            foreach (DataGridViewRow row in AnimeData.SelectedRows)
            {
                bool[] T = (bool[])AnimeData[0, row.Index].Value;

                if (T[1])
                    ComunicationNewTask("MYLIST fid=" + AnimeData[5, row.Index].Value.ToString());
            }
        }

        //Aktualizace - All
        private void AnimeData_Menu_Mn05_Mn05_Click(object sender, EventArgs e)
        {
            AnimeData_Menu.Hide();

            AnimeData_Menu_Mn05_Mn01_Click(sender, e);
            AnimeData_Menu_Mn05_Mn02_Click(sender, e);
            AnimeData_Menu_Mn05_Mn03_Click(sender, e);
            AnimeData_Menu_Mn05_Mn04_Click(sender, e);
        }

        //Změna jazyka Japanese Main
        private void Anime_Lang01_Click(object sender, EventArgs e)
        {
            DatabaseSelectAnimeTree(1);
        }

        //Změna jazyka English
        private void Anime_Lang02_Click(object sender, EventArgs e)
        {
            DatabaseSelectAnimeTree(2);
        }

        //Změna jazyka Japanese Kanji
        private void Anime_Lang03_Click(object sender, EventArgs e)
        {
            DatabaseSelectAnimeTree(3);
        }

        //Refresh obrázku
        private void Anime_Img_DoubleClick(object sender, EventArgs e)
        {
            DataTable DAnime = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + AnimeTree.SelectedNode.Name);

            Anime_Img.BackgroundImage = new Bitmap(1, 1);

            FileDelete(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());

            if (DAnime.Rows[0]["anime_obr"].ToString() != "")
            {
                WebClient WBC = new WebClient();
                WBC.DownloadFileAsync(new Uri(AniSubImgUrl + DAnime.Rows[0]["anime_obr"].ToString()), GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());
                WBC.DownloadFileCompleted += new AsyncCompletedEventHandler(WBC_DownloadFileCompleted);
            }
            else
                ComunicationNewTask("ANIME aid=" + DAnime.Rows[0]["id_anime"].ToString() + "&amask=BEE0FE01");
        }

        //Kliknutí na odkaz
        private void Anime_LB08_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel Link = (LinkLabel)sender;

            try
            {
                Process.Start(Link.Text);
            }
            catch
            {
            }
        }

        //Rozevření Related Anime
        private void Anime_RelationTree_DoubleClick(object sender, EventArgs e)
        {
            if (Anime_RelationTree.SelectedNode.Name.Length > 0)
            {
                if (Anime_RelationTree.SelectedNode.Name.Substring(0, 1) == "A")
                    AnimeTree_Find(Anime_RelationTree.SelectedNode.Name.Replace("A", ""));
                else if (Anime_RelationTree.SelectedNode.Name.Substring(0, 1) == "M")
                    MangaTree_Find(Anime_RelationTree.SelectedNode.Name.Replace("M", ""));
            }
        }

        //Aktualizace - Anime
        private void AnimeTree_Menu_Mn01_Mn01_Click(object sender, EventArgs e)
        {
            AnimeTree_Menu.Hide();

            ComunicationNewTask("ANIME aid=" + AnimeTree.SelectedNode.Name + "&amask=BEE0FE01");
        }

        //Aktualizace - Episodes
        private void AnimeTree_Menu_Mn01_Mn02_Click(object sender, EventArgs e)
        {
            AnimeTree_Menu.Hide();

            List<int> Dily = new List<int>();

            DataTable DAnime = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + AnimeTree.SelectedNode.Name);

            int x = 0;

            try
            {
                x = Convert.ToInt32(DAnime.Rows[0]["anime_epn"].ToString());
            }
            catch
            {
            }

            DataTable DEpisodes = DatabaseSelect("SELECT * FROM episodes WHERE id_anime=" + AnimeTree.SelectedNode.Name);

            for (int i = 0; i < DEpisodes.Rows.Count; i++)
            {
                try
                {
                    Dily.Add(Convert.ToInt32(DEpisodes.Rows[i]["episodes_epn"].ToString()));
                }
                catch
                {
                }

                ComunicationNewTask("EPISODE eid=" + DEpisodes.Rows[i]["id_episodes"].ToString());
            }

            for (int i = 1; i <= x; i++)
                if (!Dily.Contains(i))
                    ComunicationNewTask("EPISODE aid=" + AnimeTree.SelectedNode.Name + "&epno=" + i.ToString());
        }

        //Aktualizace - Files
        private void AnimeTree_Menu_Mn01_Mn03_Click(object sender, EventArgs e)
        {
            AnimeTree_Menu.Hide();

            DataTable DFiles = DatabaseSelect("SELECT * FROM files WHERE id_anime=" + AnimeTree.SelectedNode.Name);

            for (int i = 0; i < DFiles.Rows.Count; i++)
                ComunicationNewTask("FILE size=" + DFiles.Rows[i]["files_size"].ToString() + "&ed2k=" + DFiles.Rows[i]["files_ed2k"].ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
        }

        //Aktualizace - Mylist
        private void AnimeTree_Menu_Mn01_Mn04_Click(object sender, EventArgs e)
        {
            AnimeTree_Menu.Hide();

            List<int> Dily = new List<int>();

            DataTable DAnime = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + AnimeTree.SelectedNode.Name);

            int x = 0;

            try
            {
                x = Convert.ToInt32(DAnime.Rows[0]["anime_epn"].ToString());
            }
            catch
            {
            }

            DataTable DFiles = DatabaseSelect("SELECT * FROM files INNER JOIN episodes ON episodes.id_episodes=files.id_episodes WHERE files.id_anime=" + AnimeTree.SelectedNode.Name);

            for (int i = 0; i < DFiles.Rows.Count; i++)
            {
                try
                {
                    Dily.Add(Convert.ToInt32(DFiles.Rows[i]["episodes_epn"].ToString()));
                }
                catch
                {
                }

                ComunicationNewTask("MYLIST fid=" + DFiles.Rows[i]["id_files"].ToString());
            }

            for (int i = 1; i <= x; i++)
                if (!Dily.Contains(i))
                    ComunicationNewTask("MYLIST aid=" + AnimeTree.SelectedNode.Name + "&epno=" + i.ToString());
        }

        //Aktualizace - All
        private void AnimeTree_Menu_Mn01_Mn05_Click(object sender, EventArgs e)
        {
            AnimeTree_Menu.Hide();

            AnimeTree_Menu_Mn01_Mn01_Click(sender, e);
            AnimeTree_Menu_Mn01_Mn02_Click(sender, e);
            AnimeTree_Menu_Mn01_Mn03_Click(sender, e);
            AnimeTree_Menu_Mn01_Mn04_Click(sender, e);
        }

        //Smazání anime
        private void AnimeTree_Menu_Mn02_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.MessageBox_Anime, "Anime", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable DAnime = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + AnimeTree.SelectedNode.Name);

                DatabaseAdd("DELETE FROM anime WHERE id_anime=" + AnimeTree.SelectedNode.Name);
                DatabaseAdd("DELETE FROM anime_relations WHERE id_anime=" + AnimeTree.SelectedNode.Name);
                DatabaseAdd("DELETE FROM anime_relations WHERE id_relation=" + AnimeTree.SelectedNode.Name);
                DatabaseAdd("DELETE FROM episodes WHERE id_anime=" + AnimeTree.SelectedNode.Name);
                DatabaseAdd("DELETE FROM files WHERE id_anime=" + AnimeTree.SelectedNode.Name);
                DatabaseAdd("DELETE FROM genres_relations WHERE id_anime=" + AnimeTree.SelectedNode.Name);
                DatabaseAdd("DELETE FROM manga_anime WHERE id_anime=" + AnimeTree.SelectedNode.Name);

                if (DAnime.Rows.Count > 0)
                    FileDelete(GlobalAdresar + @"Accounts\!imgs\" + DAnime.Rows[0]["anime_obr"].ToString());

                DatabaseSelectAnimeTree(1);
            }
        }

        //Vybrání anime
        private void AnimeTree_Find(string ID)
        {
            if (ID != null)
            {
                if (ID != "")
                {
                    TreeNode[] TN = AnimeTree.Nodes.Find(ID, true);

                    if (TN.Length > 0)
                    {
                        MainTab.SelectedIndex = 4;
                        MainTabData.SelectedIndex = 3;
                        AnimeTree.SelectedNode = TN[0];
                    }
                    else
                    {
                        AnimeTree_CH01.CheckState = CheckState.Indeterminate;
                        AnimeTree_CH02.CheckState = CheckState.Unchecked;
                        DatabaseSelectAnimeTree(1);

                        TN = AnimeTree.Nodes.Find(ID, true);

                        if (TN.Length > 0)
                        {
                            MainTab.SelectedIndex = 4;
                            MainTabData.SelectedIndex = 3;
                            AnimeTree.SelectedNode = TN[0];
                        }
                    }
                }
            }
        }

        //Přidání tagů
        private void Anime_BT01_Click(object sender, EventArgs e)
        {
            DataTable DTags = DatabaseSelect("SELECT tags_name FROM tags_relation INNER JOIN tags ON tags.id_tags=tags_relation.id_tags WHERE id_anime=" + AnimeTree.SelectedNode.Name + " ORDER BY tags_name");
            DataTable DT = DatabaseSelect("SELECT tags_name FROM tags");

            Tags Tag = new Tags(DT, DTags);

            if (Tag.ShowDialog() == DialogResult.OK)
            {
                DatabaseAdd("DELETE FROM tags_relation WHERE id_anime=" + AnimeTree.SelectedNode.Name);

                for (int i = 0; i < Tag.Tagy.Count; i++)
                {
                    if (Tag.Tagy[i] != "")
                    {
                        DT = DatabaseSelect("SELECT id_tags FROM tags WHERE tags_name='" + Tag.Tagy[i] + "'");

                        if (DT.Rows.Count > 0)
                        {
                            DatabaseAdd("INSERT INTO tags_relation (id_tags, id_anime) VALUES(" + DT.Rows[0]["id_tags"].ToString() + ", " + AnimeTree.SelectedNode.Name + ")");
                        }
                        else
                        {
                            DatabaseAdd("INSERT INTO tags (tags_name) VALUES ('" + Tag.Tagy[i] + "')");
                            DT = DatabaseSelect("SELECT id_tags FROM tags WHERE tags_name='" + Tag.Tagy[i] + "'");
                            DatabaseAdd("INSERT INTO tags_relation (id_tags, id_anime) VALUES(" + DT.Rows[0]["id_tags"].ToString() + ", " + AnimeTree.SelectedNode.Name + ")");
                        }
                    }
                }
            }
        }

        //Vzhledej dle žánru
        private void Anime_CB01_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSearch.Rows.Clear();
            DataTable DTA = DatabaseSelect("SELECT anime.* FROM (anime INNER JOIN genres_relations ON anime.id_anime=genres_relations.id_anime) INNER JOIN genres ON genres.id_grenres=genres_relations.id_genres WHERE genres_genre='" + Anime_CB01.Text.Replace("'", "''") + "' ORDER BY anime_nazevjap");

            foreach (DataRow row in DTA.Rows)
            {
                DataSearch.Rows.Add(
                row["id_anime"].ToString(),
                row["anime_nazevjap"].ToString(),
                row["anime_nazeveng"].ToString(),
                row["anime_rok"].ToString(),
                row["anime_typ"].ToString()
                );
            }

            if (DataSearch.SortedColumn != null)
                DataSearch.Sort(DataSearch.SortedColumn, DataSearch.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);

            MainTabData.SelectedIndex = 6;
        }

        //Vyhledej dle tagu
        private void Anime_CB02_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSearch.Rows.Clear();

            DataTable DTA = DatabaseSelect("SELECT anime.* FROM (anime INNER JOIN tags_relation ON anime.id_anime=tags_relation.id_anime) INNER JOIN tags ON tags.id_tags=tags_relation.id_tags WHERE tags_name='" + Anime_CB02.Text.Replace("'", "''") + "' ORDER BY anime_nazevjap");

            foreach (DataRow row in DTA.Rows)
            {
                DataSearch.Rows.Add(
                row["id_anime"].ToString(),
                row["anime_nazevjap"].ToString(),
                row["anime_nazeveng"].ToString(),
                row["anime_rok"].ToString(),
                row["anime_typ"].ToString()
                );
            }

            if (DataSearch.SortedColumn != null)
                DataSearch.Sort(DataSearch.SortedColumn, DataSearch.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);

            MainTabData.SelectedIndex = 6;
        }

        //Výběr anime
        private void AnimeTags_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AnimeTags.SelectedNode != null)
                AnimeTree_Find(AnimeTags.SelectedNode.Name);
        }

        //Výběr anime
        private void AnimeRating_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AnimeRating.SelectedNode != null)
                AnimeTree_Find(AnimeRating.SelectedNode.Name);
        }

        //Výběr anime
        private void AnimeSeen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AnimeSeen.SelectedNode != null)
                AnimeTree_Find(AnimeSeen.SelectedNode.Name);
        }

        //Vykresli hodnocení
        private void Anime_Rat_ValueChanged(object sender, EventArgs e)
        {
            DatabaseAdd("UPDATE anime SET anime_rating=" + Anime_Rat.Value.ToString() + " WHERE id_anime=" + AnimeTree.SelectedNode.Name);

            Bitmap BMP = new Bitmap(Anime_RatImg.Width, Anime_RatImg.Height);
            using (Graphics g = Graphics.FromImage(BMP))
            {
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Anime_RatImg.Width, Anime_RatImg.Height));
                for (int i = 0; i < Anime_Rat.Value; i++)
                    g.DrawImage(resizeImage(Resources.i_Star, new Size(20, 20)), new Point(0 + i * 20, 0));

                for (int i = (int)Anime_Rat.Value; i < 10; i++)
                {
                    Bitmap res = (Bitmap)resizeImage(Resources.i_Star, new Size(20, 20));

                    ColorMatrix cm = new ColorMatrix();
                    cm.Matrix33 = 0.5f;
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetColorMatrix(cm);

                    g.DrawImage(res, new Rectangle(0 + i * 20, 0, res.Width, res.Height), 0, 0, res.Width, res.Height, GraphicsUnit.Pixel, ia);
                }
            }

            Anime_RatImg.BackgroundImage = BMP;
        }

        //Kalendář
        private void Anime_Seen_Click(object sender, EventArgs e)
        {
            Calendar Cal = new Calendar(DateTime.Parse(Anime_Seen.Text));

            Cal.ShowDialog();

            Anime_Seen.Text = String.Format("{0:00}", Cal.GetDate().Day) + "/" + String.Format("{0:00}", Cal.GetDate().Month) + "/" + Cal.GetDate().Year;
        }

        //Shlednuto
        private void Anime_Seen_TextChanged(object sender, EventArgs e)
        {
            DatabaseAdd("UPDATE anime SET anime_seen='" + Anime_Seen.Text + "' WHERE id_anime=" + AnimeTree.SelectedNode.Name);
        }

        //Relace
        private void Anime_RelationTree_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                Anime_RelImg();
        }

        private void Anime_RelImg()
        {
            int k = 0;
            DataTable DT;
            List<KeyValuePair<object[], int>> Anime = new List<KeyValuePair<object[], int>>();
            List<DataTable> AnimePre = new List<DataTable>();
            List<string> AnimePreID = new List<string>();
            List<Rectangle> PicRec = new List<Rectangle>();

            DT = DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime=" + AnimeTree.SelectedNode.Name + " ORDER BY anime_rok");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (!AnimePreID.Contains(DT.Rows[i]["id_anime_related"].ToString()))
                {
                    AnimePre.Add(DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime=" + DT.Rows[i]["id_anime_related"].ToString() + " ORDER BY anime_rok"));
                    AnimePre.Add(DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime_related=" + DT.Rows[i]["id_anime_related"].ToString() + " ORDER BY anime_rok"));

                    AnimePreID.Add(DT.Rows[i]["id_anime_related"].ToString());
                }
            }

            DT = DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime_related=" + AnimeTree.SelectedNode.Name + " ORDER BY anime_rok");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (!AnimePreID.Contains(DT.Rows[i]["id_anime_related"].ToString()))
                {
                    AnimePre.Add(DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime=" + DT.Rows[i]["id_anime_related"].ToString() + " ORDER BY anime_rok"));
                    AnimePre.Add(DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime_related=" + DT.Rows[i]["id_anime_related"].ToString() + " ORDER BY anime_rok"));

                    AnimePreID.Add(DT.Rows[i]["id_anime_related"].ToString());
                }
            }

            for (int j = 0; j < AnimePre.Count; j++)
            {
                for (int i = 0; i < AnimePre[j].Rows.Count; i++)
                {
                    if (!AnimePreID.Contains(AnimePre[j].Rows[i]["id_anime_related"].ToString()))
                    {
                        AnimePre.Add(DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime=" + AnimePre[j].Rows[i]["id_anime_related"].ToString() + " ORDER BY anime_rok"));
                        AnimePre.Add(DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime_related=" + AnimePre[j].Rows[i]["id_anime_related"].ToString() + " ORDER BY anime_rok"));

                        AnimePreID.Add(AnimePre[j].Rows[i]["id_anime_related"].ToString());
                    }
                }
            }

            for (int j = 0; j < AnimePre.Count; j++)
            {
                for (int i = 0; i < AnimePre[j].Rows.Count; i++)
                {
                    if (!AnimePreID.Contains(AnimePre[j].Rows[i]["id_anime_related"].ToString()))
                    {
                        AnimePre.Add(DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime=" + AnimePre[j].Rows[i]["id_anime_related"].ToString() + " ORDER BY anime_rok"));
                        AnimePre.Add(DatabaseSelect("SELECT anime_date_end, anime_rok, anime_obr, anime_nazevjap, id_anime_related, anime.id_anime FROM anime_relations INNER JOIN anime ON anime.id_anime=anime_relations.id_anime_related WHERE anime_relations.id_anime_related=" + AnimePre[j].Rows[i]["id_anime_related"].ToString() + " ORDER BY anime_rok"));

                        AnimePreID.Add(AnimePre[j].Rows[i]["id_anime_related"].ToString());
                    }
                }
            }

            AnimePreID.Clear();

            for (int j = 0; j < AnimePre.Count; j++)
            {
                for (int i = 0; i < AnimePre[j].Rows.Count; i++)
                {
                    if (!AnimePreID.Contains(AnimePre[j].Rows[i]["id_anime"].ToString()))
                    {
                        DateTime AStart = new DateTime(1800, 1, 1);

                        try
                        {
                            AStart = (DateTime)AnimePre[j].Rows[i]["anime_date_end"];
                        }
                        catch
                        {
                        }

                        object[] T = new object[4];
                        T[0] = AnimePre[j].Rows[i]["id_anime"].ToString();
                        T[1] = AnimePre[j].Rows[i]["anime_nazevjap"].ToString();
                        T[2] = AnimePre[j].Rows[i]["anime_obr"].ToString();
                        T[3] = AStart;

                        Anime.Add(new KeyValuePair<object[], int>(T, Convert.ToInt32(AnimePre[j].Rows[i]["anime_rok"].ToString().Split('-')[0])));
                        AnimePreID.Add(AnimePre[j].Rows[i]["id_anime"].ToString());
                    }
                }
            }

            AnimePreID.Clear();
            AnimePre.Clear();
            Anime_Rel.Controls.Clear();
            ToolTipAnimeRel.RemoveAll();

            Anime.Sort(delegate(KeyValuePair<object[], int> x, KeyValuePair<object[], int> y) { if (x.Value == y.Value) { return x.Key[1].ToString().CompareTo(y.Key[1].ToString()); } else { return x.Value - y.Value; } });

            if (Anime.Count > 0)
            {
                Anime_RelDel.Width = 100;
                Anime_RelDel.Height = 23;
                Anime_RelDel.Location = new Point(Anime_GR01.Location.X + 15, Anime_GR01.Height - 30);
                Anime_RelDel.Visible = true;

                Anime_GR01.Visible = false;
                Anime_Rel.Visible = true;

                Anime_Rel.Width = Anime_GR01.Width;
                Anime_Rel.Height = Anime_GR01.Height;

                Anime_Rel.Location = new Point(Anime_GR01.Location.X, Anime_GR01.Location.Y);

                int P = 0;
                int W = 255;
                int H = 279;
                int p = 0;
                int zW = 0;
                int zH = 0;
                int C = 0;

                while (Anime.Count > (P * P))
                    P++;

                C = Anime.Count == P ? P : P + 1;

                while (W * P > Anime_Rel.Width - ((C + 1) * 10))
                    W--;

                while (H * P > Anime_Rel.Height - ((int)Math.Round((float)(Anime.Count / C) + (Anime.Count % C), 0) * 30))
                    H--;

                if (W > H)
                {
                    while ((float)W / (float)H > (float)255 / (float)279)
                        W--;
                }

                zW = ((Anime_Rel.Width - ((C + 1) * 10)) - (W * C)) / 2;
                zH = ((Anime_Rel.Height - ((Anime.Count / C + 1) * 30)) - (H * (int)Math.Round((float)(Anime.Count / C) + (Anime.Count % C), 0))) / 2;

                zW = zW < 0 ? 0 : zW;
                zH = zH < 0 ? 0 : zH;

                Bitmap BMP = new Bitmap(Anime_Rel.Width, Anime_Rel.Height);

                using (Graphics g = Graphics.FromImage(BMP))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    for (int i = 0; i < Anime.Count; i++)
                    {
                        if (File.Exists(GlobalAdresar + @"Accounts\!imgs\" + Anime[i].Key[2].ToString()))
                        {
                            StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\!imgs\" + Anime[i].Key[2].ToString());
                            Bitmap res = (Bitmap)resizeImage(Image.FromStream(Cti.BaseStream), new Size(W, H));
                            int w = (W - res.Width) / 4;
                            int h = (H - res.Height) / 4;
                            w = w < 0 ? 0 : w;
                            h = h < 0 ? 0 : h;
                            Cti.Close();
                            Cti.Dispose();

                            NPanel PN = new NPanel();
                            PN.Location = new Point(p * 30 + p * W + w + zW, 30 + k * 30 + k * H + h + zH);
                            PN.Width = res.Width;
                            PN.Height = res.Height;
                            PN.Name = Anime[i].Key[0].ToString();
                            PN.BackColor = Color.Transparent;
                            PN.BorderStyle = BorderStyle.FixedSingle;
                            PN.BackgroundImage = res;
                            PN.Visible = true;
                            PN.R = k;
                            PN.S = p;
                            PN.MouseDoubleClick += new MouseEventHandler(PN_MouseDoubleClick);

                            ToolTipAnimeRel.SetToolTip(PN, Anime[i].Key[1].ToString() + " (" + ((DateTime)(Anime[i].Key[3])).ToShortDateString() + ")");
                            Anime_Rel.Controls.Add(PN);
                            PicRec.Add(new Rectangle(p * 30 + p * W + w + zW - 5, 30 + k * 30 + k * H + h + zH - 5, res.Width + 10, res.Height + 10));
                        }

                        p++;
                        if (p % (P + 1) == 0)
                        {
                            p = 0;
                            k++;
                        }
                    }

                    int off = 0;

                    foreach (Control Cont in Anime_Rel.Controls)
                    {
                        if (Cont is NPanel)
                        {
                            NPanel PN = (NPanel)Cont;

                            DT = DatabaseSelect("SELECT * FROM anime_relations WHERE anime_relations.id_anime=" + PN.Name + " ORDER BY id_relation");

                            for (int i = 0; i < DT.Rows.Count; i++)
                            {
                                foreach (Control ContR in Anime_Rel.Controls)
                                {
                                    if (ContR is NPanel)
                                    {
                                        NPanel PNR = (NPanel)ContR;

                                        if (PNR.Name == DT.Rows[i]["id_anime_related"].ToString() && PNR.Name != PN.Name)
                                        {
                                            if (!AnimePreID.Contains(PNR.Name + "*" + PN.Name) && !AnimePreID.Contains(PN.Name + "*" + PNR.Name))
                                            {
                                                AnimePreID.Add(PNR.Name + "*" + PN.Name);
                                                AnimePreID.Add(PN.Name + "*" + PNR.Name);

                                                Pen cX = new Pen(Color.White);

                                                switch (DT.Rows[i]["id_relation"].ToString())
                                                {
                                                    case "1":
                                                    case "2":
                                                        //Prequel - Sequel
                                                        cX = new Pen(new SolidBrush(Color.DeepSkyBlue), (float)1.5);
                                                        break;

                                                    case "11":
                                                    case "12":
                                                        //Same setting
                                                        cX = new Pen(new SolidBrush(Color.DarkCyan), (float)1.5);
                                                        break;

                                                    case "21":
                                                    case "22":
                                                        //Alternative setting
                                                        cX = new Pen(new SolidBrush(Color.DarkGoldenrod), (float)1.5);
                                                        break;

                                                    case "31":
                                                    case "32":
                                                        //Alternative version
                                                        cX = new Pen(new SolidBrush(Color.DarkGreen), (float)1.5);
                                                        break;

                                                    case "41":
                                                    case "42":
                                                        //Character
                                                        cX = new Pen(new SolidBrush(Color.DarkKhaki), (float)1.5);
                                                        break;

                                                    case "52":
                                                    case "51":
                                                        //Side story - Parent story
                                                        cX = new Pen(new SolidBrush(Color.DarkMagenta), (float)1.5);
                                                        break;

                                                    case "61":
                                                    case "62":
                                                        //Summary - Full story
                                                        cX = new Pen(new SolidBrush(Color.DarkOrange), (float)1.5);
                                                        break;

                                                    default:
                                                        //Other
                                                        cX = new Pen(new SolidBrush(Color.DarkRed), (float)1.5);
                                                        break;
                                                }

                                                off = off + 4;

                                                List<Point> Points = new List<Point>();

                                                Points.Add(new Point(PNR.Location.X + (int)(PNR.Width / 2) + off, PNR.Location.Y + (int)(PNR.Height / 2) + off));
                                                Points.Add(new Point(PNR.Location.X + (int)(PNR.Width / 2) + off, PNR.Location.Y + PNR.Height + off));
                                                Points.Add(new Point(PN.Location.X + PN.Width + off, PNR.Location.Y + PNR.Height + off));
                                                Points.Add(new Point(PN.Location.X + PN.Width + off, PN.Location.Y + (int)(PN.Height / 2) + off));
                                                Points.Add(new Point(PN.Location.X + (int)(PN.Width / 2) + off, PN.Location.Y + (int)(PN.Height / 2) + off));

                                                g.DrawLines(cX, Points.ToArray());

                                                if (off > 28)
                                                    off = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    g.FillRectangle(new SolidBrush(Color.FromArgb(50, 200, 200, 200)), BMP.Width - 250, BMP.Height - 210, 220, 190);

                    Font Fs = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);

                    g.DrawString((Language.Anime_RelationTree_Mn01 + " / " + Language.Anime_RelationTree_Mn02).Replace(": ", ""), Fs, new SolidBrush(Color.DeepSkyBlue), BMP.Width - 220, BMP.Height - 190);
                    g.DrawString((Language.Anime_RelationTree_Mn03).Replace(": ", ""), Fs, new SolidBrush(Color.DarkCyan), BMP.Width - 220, BMP.Height - 170);
                    g.DrawString((Language.Anime_RelationTree_Mn04).Replace(": ", ""), Fs, new SolidBrush(Color.DarkGoldenrod), BMP.Width - 220, BMP.Height - 150);
                    g.DrawString((Language.Anime_RelationTree_Mn05).Replace(": ", ""), Fs, new SolidBrush(Color.DarkGreen), BMP.Width - 220, BMP.Height - 130);
                    g.DrawString((Language.Anime_RelationTree_Mn06).Replace(": ", ""), Fs, new SolidBrush(Color.DarkKhaki), BMP.Width - 220, BMP.Height - 110);
                    g.DrawString((Language.Anime_RelationTree_Mn07 + " / " + Language.Anime_RelationTree_Mn08).Replace(": ", ""), Fs, new SolidBrush(Color.DarkMagenta), BMP.Width - 220, BMP.Height - 90);
                    g.DrawString((Language.Anime_RelationTree_Mn09 + " / " + Language.Anime_RelationTree_Mn10).Replace(": ", ""), Fs, new SolidBrush(Color.DarkOrange), BMP.Width - 220, BMP.Height - 70);
                    g.DrawString((Language.Anime_RelationTree_Mn11).Replace(": ", ""), Fs, new SolidBrush(Color.DarkRed), BMP.Width - 220, BMP.Height - 50);
                }

                Anime_Rel.BackgroundImage = BMP;
            }

        }

        //Kliknutí na relaci
        void PN_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Panel PN = (Panel)sender;
            AnimeTree_Find(PN.Name.Replace("AnimeRel", ""));
        }

        //Smazání relace
        private void Anime_RelDel_Click(object sender, EventArgs e)
        {
            DatabaseSelect("DELETE FROM anime_relations WHERE id_anime=" + AnimeTree.SelectedNode.Name);
            DatabaseSelect("DELETE FROM anime_relations WHERE id_anime_related=" + AnimeTree.SelectedNode.Name);

            AnimeTree_AfterSelect(null, null);
        }

        //Export XML
        private void Anime_ExportBT01_Click(object sender, EventArgs e)
        {
            SaveFileDialog OFD = new SaveFileDialog();
            OFD.FileName = @"Export.xml";

            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTable DT = DatabaseSelect("SELECT * FROM anime ORDER BY anime_nazevjap");

                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode Animes = doc.CreateElement("Animes");
                doc.AppendChild(Animes);

                foreach (DataRow Radek in DT.Rows)
                {
                    XmlNode Anime = doc.CreateElement("Anime");

                    if (Anime_ExportCH01.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("ID");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["id_anime"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH02.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("JAP");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_nazevjap"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH03.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("KAJ");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_nazevkaj"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH04.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("ENG");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_nazeveng"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH05.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Year");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_rok"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH06.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Type");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_typ"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH07.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Episodes");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_epn"].ToString() + "/" + Radek["anime_epn_spec"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH08.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Dub");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_dub"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH09.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Sub");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_sub"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH10.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Size");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_size"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH11.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Storage");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_storage"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH12.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Source");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_source"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH13.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("DateAir");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_date_air"].ToString().Replace(" 0:00:00", "")));
                        Anime.AppendChild(nameNode);

                        nameNode = doc.CreateElement("DateEnd");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_date_end"].ToString().Replace(" 0:00:00", "")));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH14.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("18");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_18"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH15.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Length");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_length"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH16.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Watched");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_watched"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH17.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("Rating");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_rating"].ToString()));
                        Anime.AppendChild(nameNode);
                    }

                    if (Anime_ExportCH18.Checked)
                    {
                        XmlNode nameNode = doc.CreateElement("SeenDate");
                        nameNode.AppendChild(doc.CreateTextNode(Radek["anime_seen"].ToString().Replace(" 0:00:00", "")));
                        Anime.AppendChild(nameNode);
                    }

                    Animes.AppendChild(Anime);
                }

                doc.Save(OFD.FileName);
            }
        }

        //Export CSV
        private void Anime_ExportBT02_Click(object sender, EventArgs e)
        {
            SaveFileDialog OFD = new SaveFileDialog();
            OFD.FileName = @"Export.csv";

            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTable DT = DatabaseSelect("SELECT * FROM anime ORDER BY anime_nazevjap");

                StreamWriter Zapis = new StreamWriter(OFD.FileName, false, Encoding.UTF8);
                Zapis.WriteLine("ID;JAP;KAJ;ENG;Year;Type;Episodes;Dub;Sub;Size;Storage;Source;DateAir;DateEnd;18+;Length;Watched;Rating;SeenDate;");

                foreach (DataRow Radek in DT.Rows)
                {

                    if (Anime_ExportCH01.Checked)
                        Zapis.Write(Radek["id_anime"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH02.Checked)
                        Zapis.Write(Radek["anime_nazevjap"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH03.Checked)
                        Zapis.Write(Radek["anime_nazevkaj"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH04.Checked)
                        Zapis.Write(Radek["anime_nazeveng"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH05.Checked)
                        Zapis.Write(Radek["anime_rok"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH06.Checked)
                        Zapis.Write(Radek["anime_typ"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH07.Checked)
                        Zapis.Write("'" + Radek["anime_epn"].ToString() + "/" + Radek["anime_epn_spec"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH08.Checked)
                        Zapis.Write(Radek["anime_dub"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH09.Checked)
                        Zapis.Write(Radek["anime_sub"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH10.Checked)
                        Zapis.Write(Radek["anime_size"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH11.Checked)
                        Zapis.Write(Radek["anime_storage"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH12.Checked)
                        Zapis.Write(Radek["anime_source"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH13.Checked)
                        Zapis.Write(Radek["anime_date_air"].ToString().Replace(" 0:00:00", "") + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH13.Checked)
                        Zapis.Write(Radek["anime_date_end"].ToString().Replace(" 0:00:00", "") + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH14.Checked)
                        Zapis.Write(Radek["anime_18"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH15.Checked)
                        Zapis.Write(Radek["anime_length"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH16.Checked)
                        Zapis.Write(Radek["anime_watched"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH17.Checked)
                        Zapis.Write(Radek["anime_rating"].ToString() + ";");
                    else
                        Zapis.Write(";");

                    if (Anime_ExportCH18.Checked)
                        Zapis.Write(Radek["anime_seen"].ToString().Replace(" 0:00:00", "") + ";");
                    else
                        Zapis.Write(";");

                    Zapis.Write("\n");

                    Zapis.Flush();
                }

                Zapis.Close();
                Zapis.Dispose();
            }
        }
        #endregion

        #region DataGenres
        //Listování
        private void DataGenres_Page_ValueChanged(object sender, EventArgs e)
        {
            DatabaseSelectGenres();
        }

        //Rozevírání
        private void DataGenres_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = DataGenres.HitTest(e.X, e.Y);
            if (Hit.RowIndex >= 0 && Hit.ColumnIndex >= 0)
            {
                bool[] WTF = (bool[])DataGenres[0, Hit.RowIndex].Value;

                if (Hit.ColumnIndex == 1 && !WTF[0] && !WTF[1])
                    DataGenres_RozevritAnime(Hit.RowIndex);
                else if (Hit.ColumnIndex == 1 && WTF[0] && !WTF[1])
                    DataGenres_ZavritAnime(Hit.RowIndex);
            }
        }

        //Anime podrobnosti
        private void DataGenres_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = DataGenres.HitTest(e.X, e.Y);

            if (Hit.RowIndex > 0 && Hit.ColumnIndex == 3)
            {
                bool[] WTF = (bool[])DataGenres[0, Hit.RowIndex].Value;

                if (WTF[1])
                    AnimeTree_Find(DataGenres[2, Hit.RowIndex].Value.ToString());
            }
        }

        //Rozevřít anime
        private void DataGenres_RozevritAnime(int RowIndex)
        {
            DataGenres.SuspendLayout();

            DataGenres[0, RowIndex].Value = new bool[2] { true, false };
            DataGenres[1, RowIndex].Value = Resources.i_Collapse;

            DataTable DAnimes = DatabaseSelect("SELECT anime.* FROM anime INNER JOIN genres_relations ON anime.id_anime = genres_relations.id_anime WHERE genres_relations.id_genres=" + DataGenres[2, RowIndex].Value.ToString() + " ORDER BY anime.anime_nazevjap");

            foreach (DataRow row in DAnimes.Rows)
            {
                DataGenres.Rows.Insert(RowIndex + 1, 1);

                DataGenres[0, RowIndex + 1].Value = new bool[2] { false, true };
                DataGenres[1, RowIndex + 1].Value = new Bitmap(1, 1);
                DataGenres[2, RowIndex + 1].Value = row["id_anime"].ToString();
                DataGenres[3, RowIndex + 1].Value = row["anime_nazevjap"].ToString();
                DataGenres[4, RowIndex + 1].Value = row["anime_nazeveng"].ToString();
                DataGenres[5, RowIndex + 1].Value = row["anime_rok"].ToString();
                DataGenres[6, RowIndex + 1].Value = row["anime_typ"].ToString();

                DataGenres.Rows[RowIndex + 1].DefaultCellStyle.BackColor = Options_Color02.BackColor;
            }

            DataGenres.ResumeLayout();
        }

        //Sbalit anime
        private void DataGenres_ZavritAnime(int RowIndex)
        {
            DataGenres[0, RowIndex].Value = new bool[2] { false, false };
            DataGenres[1, RowIndex].Value = Resources.i_Expand;

            DataGenres.SuspendLayout();

            while (true)
            {
                if (RowIndex + 1 >= DataGenres.Rows.Count)
                    break;

                bool[] WTF = (bool[])DataGenres[0, RowIndex + 1].Value;

                if (WTF[1])
                    DataGenres.Rows.RemoveAt(RowIndex + 1);
                else
                    break;
            }

            DataGenres.ResumeLayout();
        }
        #endregion

        #region DataGroups
        //Listování
        private void DataGroups_Page_ValueChanged(object sender, EventArgs e)
        {
            DatabaseSelectGroups();
        }

        //Rozevírání
        private void DataGroups_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = DataGroups.HitTest(e.X, e.Y);
            if (Hit.RowIndex >= 0 && Hit.ColumnIndex >= 0)
            {
                bool[] WTF = (bool[])DataGroups[0, Hit.RowIndex].Value;

                if (Hit.ColumnIndex == 1 && !WTF[0] && !WTF[1])
                    DataGroups_RozevritAnime(Hit.RowIndex);
                else if (Hit.ColumnIndex == 1 && WTF[0] && !WTF[1])
                    DataGroups_ZavritAnime(Hit.RowIndex);
            }
        }

        //Anime podrobnosti
        private void DataGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = DataGroups.HitTest(e.X, e.Y);

            if (Hit.RowIndex > 0 && Hit.ColumnIndex == 3)
            {
                bool[] WTF = (bool[])DataGroups[0, Hit.RowIndex].Value;

                if (WTF[1])
                    AnimeTree_Find(DataGroups[2, Hit.RowIndex].Value.ToString());
            }
        }

        //Rozevřít anime
        private void DataGroups_RozevritAnime(int RowIndex)
        {
            DataGroups.SuspendLayout();

            DataGroups[0, RowIndex].Value = new bool[2] { true, false };
            DataGroups[1, RowIndex].Value = Resources.i_Collapse;

            DataTable DAnimesID = DatabaseSelect("SELECT anime.id_anime FROM (groups INNER JOIN files ON groups.id_groups = files.id_groups) INNER JOIN anime ON files.id_anime = anime.id_anime WHERE groups.id_groups=" + DataGroups[2, RowIndex].Value.ToString() + " GROUP BY anime.id_anime");

            foreach (DataRow row in DAnimesID.Rows)
            {
                DataTable DAnime = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + row["id_anime"]);
                DataRow rowS = DAnime.Rows[0];

                DataGroups.Rows.Insert(RowIndex + 1, 1);

                DataGroups[0, RowIndex + 1].Value = new bool[2] { false, true };
                DataGroups[1, RowIndex + 1].Value = new Bitmap(1, 1);
                DataGroups[2, RowIndex + 1].Value = rowS["id_anime"].ToString();
                DataGroups[3, RowIndex + 1].Value = rowS["anime_nazevjap"].ToString();
                DataGroups[4, RowIndex + 1].Value = rowS["anime_nazeveng"].ToString();
                DataGroups[5, RowIndex + 1].Value = rowS["anime_rok"].ToString();
                DataGroups[6, RowIndex + 1].Value = rowS["anime_typ"].ToString();

                DataGroups.Rows[RowIndex + 1].DefaultCellStyle.BackColor = Options_Color02.BackColor;
            }

            DataGroups.ResumeLayout();
        }

        //Sbalit anime
        private void DataGroups_ZavritAnime(int RowIndex)
        {
            DataGroups[0, RowIndex].Value = new bool[2] { false, false };
            DataGroups[1, RowIndex].Value = Resources.i_Expand;

            while (true)
            {
                if (RowIndex + 1 >= DataGroups.Rows.Count)
                    break;

                bool[] WTF = (bool[])DataGroups[0, RowIndex + 1].Value;

                if (WTF[1])
                    DataGroups.Rows.RemoveAt(RowIndex + 1);
                else
                    break;
            }
        }
        #endregion

        #region Anime Vyhledávání
        //Vyhledat
        private void DataSearch_Select_Click(object sender, EventArgs e)
        {
            string SQL = "";

            if (DataSearch_NM01.Value > 0)
                SQL = "SELECT * FROM anime WHERE id_anime=" + DataSearch_NM01.Value.ToString();
            else if (DataSearch_NM02.Value > 0)
                SQL = "SELECT * FROM episodes INNER JOIN anime ON anime.id_anime=episodes.id_anime WHERE episodes.id_episodes=" + DataSearch_NM02.Value.ToString();
            else if (DataSearch_NM03.Value > 0)
                SQL = "SELECT * FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.id_files=" + DataSearch_NM03.Value.ToString();

            if (SQL == "")
            {
                if (DataSearch_TX01.Text.Length > 0)
                    SQL += "(anime.anime_nazevjap LIKE '%" + DataSearch_TX01.Text + "%' OR anime.anime_nazevkaj LIKE '%" + DataSearch_TX01.Text + "%' OR anime.anime_nazeveng LIKE '%" + DataSearch_TX01.Text + "%') AND ";

                if (DataSearch_TX02.Text.Length > 0)
                    SQL += "(episodes.episodes_nazeveng LIKE '%" + DataSearch_TX02.Text + "%' OR episodes.episodes_nazevkan LIKE '%" + DataSearch_TX02.Text + "%' OR episodes.episodes_nazevjap LIKE '%" + DataSearch_TX02.Text + "%') AND ";

                if (DataSearch_TX03.Text.Length > 0)
                    SQL += "files.files_storage LIKE '%" + DataSearch_TX03.Text + "%' AND ";

                if (DataSearch_TX04.Text.Length > 0)
                    SQL += "files.files_source LIKE '%" + DataSearch_TX04.Text + "%' AND ";

                if (DataSearch_TX05.Text.Length > 0)
                    SQL += "files.files_other LIKE '%" + DataSearch_TX05.Text + "%' AND ";

                if (DataSearch_TX06.Text.Length > 0)
                    SQL += "files.files_dub LIKE '%" + DataSearch_TX06.Text + "%' AND ";

                if (DataSearch_TX07.Text.Length > 0)
                    SQL += "files.files_sub LIKE '%" + DataSearch_TX07.Text + "%' AND ";

                if (DataSearch_TX08.Text.Length > 0)
                    SQL += "(groups.groups_name LIKE '%" + DataSearch_TX08.Text + "%' OR groups.groups_namezk LIKE '%" + DataSearch_TX08.Text + "%') AND ";

                if (DataSearch_NM04.Value > 0)
                    SQL += "files.files_lid=" + DataSearch_NM04.Value.ToString() + " AND ";

                if (DataSearch_NM05.Value > 0)
                    SQL += "anime.anime_epn=" + DataSearch_NM05.Value.ToString() + " AND ";

                if (DataSearch_CB01.Text.Length > 0)
                    SQL += "anime.anime_typ='" + DataSearch_CB01.Text + "' AND ";

                if (DataSearch_CB02.Text.Length > 0)
                    SQL += "files.files_typ='" + DataSearch_CB02.Text + "' AND ";

                if (DataSearch_CH01.Checked)
                {
                    if (DataSearch_CH02.Checked)
                        SQL += "files.files_watched=1 AND ";
                    else
                        SQL += "files.files_watched=0 AND ";
                }

                if (DataSearch_Genres.Items.Count > 0)
                {
                    string SQLgenres = "";

                    for (int i = 0; i < DataSearch_Genres.Items.Count; i++)
                    {
                        if (DataSearch_Genres.GetItemChecked(i))
                            SQLgenres += "genres.genres_genre='" + DataSearch_Genres.Items[i].ToString() + "' OR ";
                    }

                    if (SQLgenres.Length > 4)
                        SQLgenres = SQLgenres.Substring(0, SQLgenres.Length - 4);

                    if (SQLgenres.Length > 0)
                        SQL += "(" + SQLgenres + ") AND ";
                }

                if (SQL.Length > 4)
                    SQL = SQL.Substring(0, SQL.Length - 4);
            }

            DataTable dataTable = null;

            if (SQL.Length > 6)
            {
                if (SQL.Substring(0, 6) == "SELECT")
                    dataTable = DatabaseSelect(SQL);
                else
                    dataTable = DatabaseSelect("SELECT anime.id_anime FROM (groups INNER JOIN (genres INNER JOIN ((anime INNER JOIN files ON anime.id_anime = files.id_anime) INNER JOIN genres_relations ON anime.id_anime = genres_relations.id_anime) ON genres.id_grenres = genres_relations.id_genres) ON groups.id_groups = files.id_groups) INNER JOIN episodes ON (anime.id_anime = episodes.id_anime) AND (files.id_episodes = episodes.id_episodes) WHERE " + SQL + " GROUP BY anime.id_anime");

                int i = 0;

                while (i < dataTable.Rows.Count)
                {
                    SQL = "";

                    for (int j = i; j < i + 20; j++)
                    {
                        if (j < dataTable.Rows.Count)
                            SQL += "id_anime=" + dataTable.Rows[j]["id_anime"].ToString() + " OR ";
                        else
                            break;
                    }

                    i += 20;

                    if (SQL != "")
                    {
                        SQL = SQL.Substring(0, SQL.Length - 4);
                        DataTable DTA = DatabaseSelect("SELECT * FROM anime WHERE " + SQL + " ORDER BY anime_nazevjap");

                        foreach (DataRow row in DTA.Rows)
                        {
                            if (DataSearch_Genres.Items.Count > 0)
                            {
                                List<bool> anoG = new List<bool>();

                                DataTable DTAG = DatabaseSelect("SELECT genres_genre FROM genres, genres_relations WHERE genres.id_grenres=genres_relations.id_genres AND id_anime=" + row["id_anime"].ToString());

                                for (int j = 0; j < DataSearch_Genres.Items.Count; j++)
                                {
                                    foreach (DataRow rowG in DTAG.Rows)
                                    {
                                        if (DataSearch_Genres.Items[j].ToString() == rowG["genres_genre"].ToString() && DataSearch_Genres.GetItemChecked(j))
                                            anoG.Add(true);
                                    }
                                }

                                if (anoG.Count == DataSearch_Genres.CheckedItems.Count)
                                {
                                    DataSearch.Rows.Add(
                                    row["id_anime"].ToString(),
                                    row["anime_nazevjap"].ToString(),
                                    row["anime_nazeveng"].ToString(),
                                    row["anime_rok"].ToString(),
                                    row["anime_typ"].ToString()
                                    );
                                }
                            }
                            else
                            {
                                DataSearch.Rows.Add(
                                    row["id_anime"].ToString(),
                                    row["anime_nazevjap"].ToString(),
                                    row["anime_nazeveng"].ToString(),
                                    row["anime_rok"].ToString(),
                                    row["anime_typ"].ToString()
                                    );
                            }
                        }
                    }

                    Application.DoEvents();
                }

                if (DataSearch.SortedColumn != null)
                    DataSearch.Sort(DataSearch.SortedColumn, DataSearch.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }
        }

        //Vyčištění hledaných výrazů
        private void DataSearch_Clear_Click(object sender, EventArgs e)
        {
            DataSearch.Rows.Clear();
        }

        //Přejdi na anime
        private void DataSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = DataSearch.HitTest(e.X, e.Y);

            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 1)
                AnimeTree_Find(DataSearch[0, Hit.RowIndex].Value.ToString());
        }

        //Povolení vyhledávání pro shlédnuto
        private void DataSearch_CH01_CheckedChanged(object sender, EventArgs e)
        {
            if (!DataSearch_CH01.Checked)
                DataSearch_CH02.Checked = false;
        }

        //Povolení vyhledávání pro shlédnuto
        private void DataSearch_CH02_CheckedChanged(object sender, EventArgs e)
        {
            if (DataSearch_CH02.Checked)
                DataSearch_CH01.Checked = true;
        }
        #endregion

        #region Log
        //Zapnutí logování do souboru
        private void LogFileEnable()
        {
            FileInfo soubor = new FileInfo(GlobalAdresarAccount);

            if (ZapisLogA != null)
                ZapisLogA.Close();

            if (ZapisLogS != null)
                ZapisLogS.Close();

            if (ZapisLogE != null)
                ZapisLogE.Close();

            ZapisLogA = new StreamWriter(soubor.Directory.FullName + @"\L-AniDB.Log", true, Encoding.UTF8);
            ZapisLogS = new StreamWriter(soubor.Directory.FullName + @"\L-SQL.Log", true, Encoding.UTF8);
            ZapisLogE = new StreamWriter(soubor.Directory.FullName + @"\L-Error.Log", true, Encoding.UTF8);
        }

        //Zapnutí logování do souboru
        private void Options_CH21_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobalAdresarAccount != null)
                LogFileEnable();
        }

        //Logování AniDB
        private void LogAdd(string MessageString)
        {
            if (LogSQL.Text.Length + MessageString.Length > LogSQL.MaxLength)
                Log.Text = "";

            Log.Text = LogTime() + MessageString + "\r\n\r\n" + Log.Text;

            if (Options_CH21.Checked && ZapisLogA != null)
            {
                ZapisLogA.WriteLine(LogTime() + MessageString);
                ZapisLogA.WriteLine();
                ZapisLogA.Flush();
            }
        }

        //Logování SQL
        private void LogAddSQL(string MessageString)
        {
            if (LogSQL.Text.Length + MessageString.Length > LogSQL.MaxLength)
                LogSQL.Text = "";

            LogSQL.Text = LogTime() + MessageString + "\r\n\r\n" + LogSQL.Text;

            if (Options_CH21.Checked && ZapisLogS != null)
            {
                ZapisLogS.WriteLine(LogTime() + MessageString);
                ZapisLogS.WriteLine();
                ZapisLogS.Flush();
            }
        }

        //Získej čas
        private string LogTime()
        {
            return "[" + DateTime.Now.ToShortDateString().Replace(" ", "") + " " + DateTime.Now.ToShortTimeString() + "]\r\n";
        }

        //Logování Eroor
        private void LogAddError(string MessageString)
        {
            try
            {
                if (LogSQL.Text.Length + MessageString.Length > LogSQL.MaxLength)
                    LogError.Text = "";

                LogError.Text = LogTime() + MessageString + "\r\n\r\n" + LogError.Text;

                if (Options_CH21.Checked && ZapisLogE != null)
                {
                    ZapisLogE.WriteLine(LogTime() + MessageString);
                    ZapisLogE.WriteLine();
                    ZapisLogE.Flush();
                }
            }
            catch { }
        }

        //Vymazání úloh
        private void LogTasksDel_Click(object sender, EventArgs e)
        {
            List<string> Na_Smazani = new List<string>();

            foreach (string nazev in LogTasks.SelectedItems)
                Na_Smazani.Add(nazev);

            LogTasks.BeginUpdate();
            foreach (string nazev in Na_Smazani)
            {
                LogTasks.Items.Remove(nazev);
                DatabaseAdd("DELETE FROM task WHERE task_task='" + nazev + "'");
            }
            LogTasks.EndUpdate();

            Na_Smazani.Clear();

            StatusBar_Mn02.Text = LogTasks.Items.Count.ToString();
        }

        //Vymazání úloh
        private void LogTasksDelAll_Click(object sender, EventArgs e)
        {
            LogTasks.BeginUpdate();
            LogTasks.Items.Clear();
            LogTasks.EndUpdate();
            DatabaseAdd("DELETE FROM task");

            StatusBar_Mn02.Text = LogTasks.Items.Count.ToString();
        }
        #endregion

        #region Funkce
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

        //Ikonka  pro audio
        private Image FilesLangAudio(string Lang)
        {
            Lang = Lang.ToLower();
            string[] LangT = Lang.Replace(" (unspecified)", "").Split('\'');
            Image[] Audio = new Image[LangT.Length];

            for (int i = 0; i < LangT.Length; i++)
                switch (LangT[i])
                {
                    case "albanian":
                        Audio[i] = Resources.anidb_audio_albanian;
                        break;

                    case "arabic":
                        Audio[i] = Resources.anidb_audio_arabic;
                        break;

                    case "bengali":
                        Audio[i] = Resources.anidb_audio_bengali;
                        break;

                    case "brasilian":
                        Audio[i] = Resources.anidb_audio_brasilian;
                        break;

                    case "bulgarian":
                        Audio[i] = Resources.anidb_audio_bulgarian;
                        break;

                    case "cantonese":
                        Audio[i] = Resources.anidb_audio_cantonese;
                        break;

                    case "catalan":
                        Audio[i] = Resources.anidb_audio_catalan;
                        break;

                    case "croatian":
                        Audio[i] = Resources.anidb_audio_croatian;
                        break;

                    case "czech":
                        Audio[i] = Resources.anidb_audio_czech;
                        break;

                    case "danish":
                        Audio[i] = Resources.anidb_audio_danish;
                        break;

                    case "dutch":
                        Audio[i] = Resources.anidb_audio_dutch;
                        break;

                    case "estonian":
                        Audio[i] = Resources.anidb_audio_estonian;
                        break;

                    case "finnish":
                        Audio[i] = Resources.anidb_audio_finnish;
                        break;

                    case "french":
                        Audio[i] = Resources.anidb_audio_french;
                        break;

                    case "georgian":
                        Audio[i] = Resources.anidb_audio_georgian;
                        break;

                    case "german":
                        Audio[i] = Resources.anidb_audio_german;
                        break;

                    case "hebrew":
                        Audio[i] = Resources.anidb_audio_hebrew;
                        break;

                    case "hungarian":
                        Audio[i] = Resources.anidb_audio_hungarian;
                        break;

                    case "chinese":
                        Audio[i] = Resources.anidb_audio_chinese;
                        break;

                    case "icelandic":
                        Audio[i] = Resources.anidb_audio_icelandic;
                        break;

                    case "indonesian":
                        Audio[i] = Resources.anidb_audio_indonesian;
                        break;

                    case "instrumental":
                        Audio[i] = Resources.anidb_audio_instrumental;
                        break;

                    case "italian":
                        Audio[i] = Resources.anidb_audio_italian;
                        break;

                    case "korean":
                        Audio[i] = Resources.anidb_audio_korean;
                        break;

                    case "latin":
                        Audio[i] = Resources.anidb_audio_latin;
                        break;

                    case "lithuanian":
                        Audio[i] = Resources.anidb_audio_lithuanian;
                        break;

                    case "malay":
                        Audio[i] = Resources.anidb_audio_malay;
                        break;

                    case "mandarin":
                        Audio[i] = Resources.anidb_audio_mandarin;
                        break;

                    case "norwegian":
                        Audio[i] = Resources.anidb_audio_norwegian;
                        break;

                    case "polish":
                        Audio[i] = Resources.anidb_audio_polish;
                        break;

                    case "portuguese":
                        Audio[i] = Resources.anidb_audio_portuguese;
                        break;

                    case "romania":
                        Audio[i] = Resources.anidb_audio_romanian;
                        break;

                    case "serbian":
                        Audio[i] = Resources.anidb_audio_serbian;
                        break;

                    case "simplified":
                        Audio[i] = Resources.anidb_audio_simplified;
                        break;

                    case "slovak":
                        Audio[i] = Resources.anidb_audio_slovak;
                        break;

                    case "slovenian":
                        Audio[i] = Resources.anidb_audio_slovenian;
                        break;

                    case "spanish":
                        Audio[i] = Resources.anidb_audio_spanish;
                        break;

                    case "swedish":
                        Audio[i] = Resources.anidb_audio_swedish;
                        break;

                    case "taiwanese":
                        Audio[i] = Resources.anidb_audio_taiwanese;
                        break;

                    case "tamil":
                        Audio[i] = Resources.anidb_audio_tamil;
                        break;

                    case "tartar":
                        Audio[i] = Resources.anidb_audio_tartar;
                        break;

                    case "thai":
                        Audio[i] = Resources.anidb_audio_thai;
                        break;

                    case "traditional":
                        Audio[i] = Resources.anidb_audio_traditional;
                        break;

                    case "turkish":
                        Audio[i] = Resources.anidb_audio_turkish;
                        break;

                    case "ukrainian":
                        Audio[i] = Resources.anidb_audio_ukrainian;
                        break;

                    case "unknown":
                        Audio[i] = Resources.anidb_audio_unknown;
                        break;

                    case "vietnamese":
                        Audio[i] = Resources.anidb_audio_vietnamese;
                        break;

                    case "japanese":
                        Audio[i] = Resources.anidb_audio_japanese;
                        break;

                    case "english":
                        Audio[i] = Resources.anidb_audio_english;
                        break;

                    default:
                        Audio[i] = Resources.anidb_audio_unknown;
                        break;
                }

            int NWidth = 0;
            int NOffset = 0;

            for (int i = 0; i < LangT.Length; i++)
                NWidth += Audio[i].Width + 1;

            Bitmap ImgR = new Bitmap(NWidth, Audio[0].Height);

            using (Graphics g = Graphics.FromImage(ImgR))
            {
                for (int i = 0; i < LangT.Length; i++)
                {
                    g.DrawImage(Audio[i], new Point(NOffset, 0));
                    NOffset += Audio[i].Width + 1;
                }

                g.Save();
            }

            return ImgR;
        }

        //Ikonka pro titulky
        private Image FilesLangSub(string Lang)
        {
            Lang = Lang.ToLower();
            string[] LangT = Lang.Replace(" (unspecified)", "").Split('\'');
            Image[] Audio = new Image[LangT.Length];

            for (int i = 0; i < LangT.Length; i++)
                switch (LangT[i])
                {
                    case "albanian":
                        Audio[i] = Resources.anidb_sub_albanian;
                        break;

                    case "arabic":
                        Audio[i] = Resources.anidb_sub_arabic;
                        break;

                    case "bengali":
                        Audio[i] = Resources.anidb_sub_bengali;
                        break;

                    case "brasilian":
                        Audio[i] = Resources.anidb_sub_brasilian;
                        break;

                    case "bulgarian":
                        Audio[i] = Resources.anidb_sub_bulgarian;
                        break;

                    case "catalan":
                        Audio[i] = Resources.anidb_sub_catalan;
                        break;

                    case "croatian":
                        Audio[i] = Resources.anidb_sub_croatian;
                        break;

                    case "czech":
                        Audio[i] = Resources.anidb_sub_czech;
                        break;

                    case "danish":
                        Audio[i] = Resources.anidb_sub_danish;
                        break;

                    case "dutch":
                        Audio[i] = Resources.anidb_sub_dutch;
                        break;

                    case "estonian":
                        Audio[i] = Resources.anidb_sub_estonian;
                        break;

                    case "finnish":
                        Audio[i] = Resources.anidb_sub_finnish;
                        break;

                    case "french":
                        Audio[i] = Resources.anidb_sub_french;
                        break;

                    case "georgian":
                        Audio[i] = Resources.anidb_sub_georgian;
                        break;

                    case "german":
                        Audio[i] = Resources.anidb_sub_german;
                        break;

                    case "hebrew":
                        Audio[i] = Resources.anidb_sub_hebrew;
                        break;

                    case "hungarian":
                        Audio[i] = Resources.anidb_sub_hungarian;
                        break;

                    case "chinese":
                        Audio[i] = Resources.anidb_sub_chinese;
                        break;

                    case "icelandic":
                        Audio[i] = Resources.anidb_sub_icelandic;
                        break;

                    case "indonesian":
                        Audio[i] = Resources.anidb_sub_indonesian;
                        break;

                    case "italian":
                        Audio[i] = Resources.anidb_sub_italian;
                        break;

                    case "korean":
                        Audio[i] = Resources.anidb_sub_korean;
                        break;

                    case "latin":
                        Audio[i] = Resources.anidb_sub_latin;
                        break;

                    case "lithuanian":
                        Audio[i] = Resources.anidb_sub_lithuanian;
                        break;

                    case "malay":
                        Audio[i] = Resources.anidb_sub_malay;
                        break;

                    case "norwegian":
                        Audio[i] = Resources.anidb_sub_norwegian;
                        break;

                    case "polish":
                        Audio[i] = Resources.anidb_sub_polish;
                        break;

                    case "portuguese":
                        Audio[i] = Resources.anidb_sub_portuguese;
                        break;

                    case "romania":
                        Audio[i] = Resources.anidb_sub_romanian;
                        break;

                    case "serbian":
                        Audio[i] = Resources.anidb_sub_serbian;
                        break;

                    case "simplified":
                        Audio[i] = Resources.anidb_sub_simplified;
                        break;

                    case "slovak":
                        Audio[i] = Resources.anidb_sub_slovak;
                        break;

                    case "slovenian":
                        Audio[i] = Resources.anidb_sub_slovenian;
                        break;

                    case "spanish":
                        Audio[i] = Resources.anidb_sub_spanish;
                        break;

                    case "swedish":
                        Audio[i] = Resources.anidb_sub_swedish;
                        break;

                    case "taiwanese":
                        Audio[i] = Resources.anidb_sub_taiwanese;
                        break;

                    case "tamil":
                        Audio[i] = Resources.anidb_sub_tamil;
                        break;

                    case "tartar":
                        Audio[i] = Resources.anidb_sub_tartar;
                        break;

                    case "thai":
                        Audio[i] = Resources.anidb_sub_thai;
                        break;

                    case "traditional":
                        Audio[i] = Resources.anidb_sub_traditional;
                        break;

                    case "turkish":
                        Audio[i] = Resources.anidb_sub_turkish;
                        break;

                    case "ukrainian":
                        Audio[i] = Resources.anidb_sub_ukrainian;
                        break;

                    case "unknown":
                        Audio[i] = Resources.anidb_sub_unknown;
                        break;

                    case "vietnamese":
                        Audio[i] = Resources.anidb_sub_vietnamese;
                        break;

                    case "japanese":
                        Audio[i] = Resources.anidb_sub_japanese;
                        break;

                    case "english":
                        Audio[i] = Resources.anidb_sub_english;
                        break;

                    default:
                        Audio[i] = Resources.anidb_audio_unknown;
                        break;
                }

            int NWidth = 0;
            int NOffset = 0;

            for (int i = 0; i < LangT.Length; i++)
                NWidth += Audio[i].Width + 1;

            Bitmap ImgR = new Bitmap(NWidth, Audio[0].Height);

            using (Graphics g = Graphics.FromImage(ImgR))
            {
                for (int i = 0; i < LangT.Length; i++)
                {
                    g.DrawImage(Audio[i], new Point(NOffset, 0));
                    NOffset += Audio[i].Width + 1;
                }

                g.Save();
            }

            return ImgR;
        }

        //Aktualizace MyListu - Full
        private void Options_MyListRefresh_Click(object sender, EventArgs e)
        {
            if (AniDBSessions != null)
                if (AniDBSessions.Length > 0)
                    LogTasks.Items.Add("MYLISTSTATS s=" + AniDBSessions);

            Process.Start(GlobalAdresar + "AniDBUpdate.exe", GlobalAdresarAccount.Substring(0, GlobalAdresarAccount.Length - 3).Replace(" ", "?") + "mdb*" + Process.GetCurrentProcess().MainWindowHandle + "*full");
        }

        //Aktualizace MyListu - Min
        private void Options_MyListRefreshMin_Click(object sender, EventArgs e)
        {
            if (AniDBSessions != null)
                if (AniDBSessions.Length > 0)
                    LogTasks.Items.Add("MYLISTSTATS s=" + AniDBSessions);

            Process.Start(GlobalAdresar + "AniDBUpdate.exe", GlobalAdresarAccount.Substring(0, GlobalAdresarAccount.Length - 3).Replace(" ", "?") + "mdb*" + Process.GetCurrentProcess().MainWindowHandle + "*min");
        }

        //Přidat do seznamu nové věci
        private void Add_Add_Click(object sender, EventArgs e)
        {
            if (Add_Text02.Text.Length > 0)
            {
                try
                {
                    Add_Text02.Text = Convert.ToInt32(Add_Text02.Text).ToString();
                }
                catch
                {
                    Add_Text02.Text = "0";
                }

                if (Add_Text02.Text != "0")
                {
                    switch (Add_Text02.SelectedIndex)
                    {
                        case 0:
                            ComunicationNewTask("ANIME aid=" + Add_Text01.Text + "&amask=BEE0FE01");
                            break;

                        case 1:
                            ComunicationNewTask("FILE fid=" + Add_Text01.Text + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                            ComunicationNewTask("MYLIST fid=" + Add_Text01.Text);
                            break;

                        case 2:
                            ComunicationNewTask("EPISODE eid=" + Add_Text01.Text);
                            break;
                    }
                }
            }
        }

        //Přidat do seznamu nové přípony
        private void Options_ExtensionAdd_Click(object sender, EventArgs e)
        {
            if (!Options_ExtensionList.Items.Contains(Options_ExtensionList.Text))
                Options_ExtensionList.Items.Add(Options_ExtensionList.Text);
        }

        //Odebrání přípony ze seznamu
        private void Options_ExtensionRem_Click(object sender, EventArgs e)
        {
            if (Options_ExtensionList.SelectedIndex >= 0 && Options_ExtensionList.SelectedIndex < Options_ExtensionList.Items.Count)
                Options_ExtensionList.Items.RemoveAt(Options_ExtensionList.SelectedIndex);
        }

        //Otevřít domovskou stránku
        private void StatusBar_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.benda-11.cz");
        }

        //Licence
        private void About_LB02_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(GlobalAdresar + @"License.rtf");
        }

        //Vynulování vyhledávání
        private void Option_SearchNull()
        {
            DataSearch_NM01.Value = 0;
            DataSearch_NM02.Value = 0;
            DataSearch_NM03.Value = 0;
            DataSearch_NM04.Value = 0;
            DataSearch_NM05.Value = 0;

            DataSearch_TX01.Text = "";
            DataSearch_TX02.Text = "";
            DataSearch_TX03.Text = "";
            DataSearch_TX04.Text = "";
            DataSearch_TX05.Text = "";
            DataSearch_TX06.Text = "";
            DataSearch_TX07.Text = "";
            DataSearch_TX08.Text = "";

            DataSearch_CB01.Text = "";
            DataSearch_CB02.Text = "";

            DataSearch_CH01.Checked = false;
            DataSearch_CH02.Checked = false;

            for (int i = 0; i < DataSearch_Genres.Items.Count; i++)
                DataSearch_Genres.SetItemChecked(i, false);
        }

        //Změna jazyka
        private void Options_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Options_Language.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");
                    break;
            }

            InitializeComponentLanguage();
        }

        //Zmenšit obrázek
        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            if (nPercent > 1)
                nPercent = 1;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        //Odstranění nechtěných znaků
        private string RemoveUnesesaryStrings(string x)
        {
            x = x.Replace("\\", "");
            x = x.Replace("*", "");
            x = x.Replace(":", "");
            x = x.Replace("<", "");
            x = x.Replace(">", "");
            x = x.Replace("?", "");
            x = x.Replace("|", "");

            return x;
        }

        //Výběr adresáře
        private string OpenDirectoryDialog(string path)
        {
            if (Options_CH13.Checked)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = path;

                if (fbd.ShowDialog() == DialogResult.OK)
                    return fbd.SelectedPath;
                else
                    return "";
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = path;
                ofd.CheckPathExists = false;
                ofd.ShowReadOnly = false;
                ofd.CheckFileExists = false;
                ofd.ReadOnlyChecked = false;
                ofd.ValidateNames = false;
                ofd.FileName = "Folder";
                ofd.Filter = "Folders|no.files";

                try
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        return Path.GetDirectoryName(ofd.FileName);
                    else
                        return "";
                }
                catch
                {
                    return "";
                }
            }
        }

        //Refresh All
        private void StatusBar_Refresh_Click(object sender, EventArgs e)
        {
            TabSelect(true);
        }

        //Fullscreen
        

        //Změna barvy
        private void Options_Color01_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = ((Button)sender).BackColor;

            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ((Button)sender).BackColor = cd.Color;

                Option_ColorChange();
            }
        }

        //Změna vzhledu
        private void Options_CH17_CheckedChanged(object sender, EventArgs e)
        {
            Option_ColorChange();
        }

        //Změna barvy
        private void Option_ColorChange()
        {
            this.BackColor = Options_Color09.BackColor;
            Option_ColorChangeR(Controls);
        }

        //Změna barvy
        void Option_ColorChangeR(Control.ControlCollection c)
        {
            foreach (Control cc in c)
            {
                if (cc.Controls.Count > 0)
                    Option_ColorChangeR(cc.Controls);

                try
                {
                    if (cc is System.Windows.Forms.Label)
                    {
                        System.Windows.Forms.Label cl = cc as System.Windows.Forms.Label;
                        cl.ForeColor = Options_Color06.BackColor;

                        if (Options_CH17.Checked && cl.FlatStyle == FlatStyle.Standard)
                            cl.FlatStyle = FlatStyle.Flat;
                        else if (cl.FlatStyle == FlatStyle.Flat)
                            cl.FlatStyle = FlatStyle.Standard;
                    }

                    if (cc is System.Windows.Forms.CheckBox)
                    {
                        System.Windows.Forms.CheckBox cl = cc as System.Windows.Forms.CheckBox;
                        cl.ForeColor = Options_Color06.BackColor;

                        if (Options_CH17.Checked && cl.FlatStyle == FlatStyle.Standard)
                            cl.FlatStyle = FlatStyle.Flat;
                        else if (cl.FlatStyle == FlatStyle.Flat)
                            cl.FlatStyle = FlatStyle.Standard;
                    }

                    if (cc is System.Windows.Forms.RadioButton)
                    {
                        System.Windows.Forms.RadioButton cl = cc as System.Windows.Forms.RadioButton;
                        cl.ForeColor = Options_Color06.BackColor;

                        if (Options_CH17.Checked && cl.FlatStyle == FlatStyle.Standard)
                            cl.FlatStyle = FlatStyle.Flat;
                        else if (cl.FlatStyle == FlatStyle.Flat)
                            cl.FlatStyle = FlatStyle.Standard;
                    }

                    if (cc is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox cl = cc as System.Windows.Forms.TextBox;
                        cl.ForeColor = Options_Color07.BackColor;
                        cl.BackColor = Options_Color09.BackColor;
                    }

                    if (cc is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cl = cc as System.Windows.Forms.ComboBox;
                        cl.ForeColor = Options_Color07.BackColor;
                        cl.BackColor = Options_Color09.BackColor;

                        if (Options_CH17.Checked && cl.FlatStyle == FlatStyle.Standard)
                            cl.FlatStyle = FlatStyle.Flat;
                        else if (cl.FlatStyle == FlatStyle.Flat)
                            cl.FlatStyle = FlatStyle.Standard;
                    }

                    if (cc is System.Windows.Forms.NumericUpDown)
                    {
                        System.Windows.Forms.NumericUpDown cl = cc as System.Windows.Forms.NumericUpDown;
                        cl.ForeColor = Options_Color07.BackColor;
                        cl.BackColor = Options_Color09.BackColor;
                    }

                    if (cc is System.Windows.Forms.ListBox)
                    {
                        System.Windows.Forms.ListBox cl = cc as System.Windows.Forms.ListBox;
                        cl.ForeColor = Options_Color07.BackColor;
                        cl.BackColor = Options_Color09.BackColor;
                    }

                    if (cc is System.Windows.Forms.Panel)
                    {
                        System.Windows.Forms.Panel cl = cc as System.Windows.Forms.Panel;
                        cl.BackColor = Options_Color08.BackColor;
                    }

                    if (cc is System.Windows.Forms.GroupBox)
                    {
                        System.Windows.Forms.GroupBox cl = cc as System.Windows.Forms.GroupBox;
                        cl.ForeColor = Options_Color06.BackColor;
                        cl.BackColor = Options_Color08.BackColor;

                        if (Options_CH17.Checked && cl.FlatStyle == FlatStyle.Standard)
                            cl.FlatStyle = FlatStyle.Flat;
                        else if (cl.FlatStyle == FlatStyle.Flat)
                            cl.FlatStyle = FlatStyle.Standard;
                    }

                    if (cc is System.Windows.Forms.TabControl)
                    {
                        System.Windows.Forms.TabControl cl = cc as System.Windows.Forms.TabControl;
                        cl.ForeColor = Options_Color06.BackColor;
                        cl.BackColor = Options_Color08.BackColor;

                        if (Options_CH17.Checked && cl.Appearance == TabAppearance.Normal)
                            cl.Appearance = TabAppearance.FlatButtons;
                        else if (cl.Appearance == TabAppearance.FlatButtons)
                            cl.Appearance = TabAppearance.Normal;
                    }

                    if (cc is System.Windows.Forms.Button)
                    {
                        System.Windows.Forms.Button cl = cc as System.Windows.Forms.Button;

                        if (Options_CH17.Checked)
                            cl.FlatStyle = FlatStyle.Flat;
                        else if (cl.FlatStyle == FlatStyle.Flat)
                            cl.FlatStyle = FlatStyle.Standard;
                    }

                    if (cc is System.Windows.Forms.DataGridView)
                    {
                        System.Windows.Forms.DataGridView cl = cc as System.Windows.Forms.DataGridView;
                        cl.RowsDefaultCellStyle.SelectionBackColor = Options_Color05.BackColor;
                        cl.RowsDefaultCellStyle.ForeColor = Options_Color07.BackColor;
                        cl.ForeColor = Options_Color07.BackColor;
                        cl.GridColor = Options_Color09.BackColor;
                        cl.RowsDefaultCellStyle.BackColor = Options_Color09.BackColor;
                        cl.BackColor = Options_Color09.BackColor;
                        cl.BackgroundColor = Options_Color09.BackColor;
                    }

                    if (cc is System.Windows.Forms.TreeView)
                    {
                        System.Windows.Forms.TreeView cl = cc as System.Windows.Forms.TreeView;
                        cl.ForeColor = Options_Color07.BackColor;
                        cl.BackColor = Options_Color09.BackColor;
                    }

                    if (cc is ZedGraph.ZedGraphControl)
                    {
                        ZedGraph.ZedGraphControl cl = cc as ZedGraph.ZedGraphControl;
                        cl.ForeColor = Options_Color07.BackColor;
                        cl.BackColor = Options_Color09.BackColor;
                    }

                    if (cc is System.Windows.Forms.ProgressBar)
                    {
                        System.Windows.Forms.ProgressBar cl = cc as System.Windows.Forms.ProgressBar;
                        cl.ForeColor = Options_Color10.BackColor;
                    }
                }
                catch { }
            }
        }
        #endregion

        #region Hash
        //Vyber adresář
        private void Hash_Cesta_Click(object sender, EventArgs e)
        {
            Nacti_Hash(OpenDirectoryDialog(""));
        }

        private List<DirectoryInfo> Hash_Directories(string Cesta)
        {
            DirectoryInfo Adresar = new DirectoryInfo(Cesta);
            List<DirectoryInfo> Adresare = new List<DirectoryInfo>();

            foreach (DirectoryInfo SubAdresar in Adresar.GetDirectories(@"*", SearchOption.TopDirectoryOnly))
            {
                if (!SubAdresar.Attributes.ToString().Contains("System"))
                {
                    foreach (DirectoryInfo SubSubAdresar in Hash_Directories(SubAdresar.FullName))
                        Adresare.Add(SubSubAdresar);
                }
            }

            if (!Adresar.Attributes.ToString().Contains("System"))
                Adresare.Add(Adresar);

            return Adresare;
        }

        //Načti soubory
        private void Nacti_Hash(string pathName)
        {
            Hash_Nazvy_Souboru.BeginUpdate();

            Nacti_HashS(pathName);

            Hash_Nazvy_Souboru.EndUpdate();

            Hash_Check();
        }

        //Načti soubory
        private void Nacti_HashS(string pathName)
        {
            if (File.Exists(pathName))
            {
                FileInfo SouborF = new FileInfo(pathName);

                if (!SouborF.Attributes.ToString().Contains(FileAttributes.Hidden.ToString()))
                {
                    bool pridat = false;

                    if (Options_ExtensionList.Items.Contains(SouborF.Extension.ToLower()))
                        pridat = true;

                    if (!Options_CH15.Checked && Hash_Nazvy_Souboru.Items.Contains(SouborF.FullName))
                        pridat = false;

                    if (pridat)
                    {
                        if (Hash_W.IsBusy)
                            Hash_TotalLenght += SouborF.Length;

                        Hash_Nazvy_Souboru.Items.Add(SouborF.FullName);
                        DatabaseAdd("INSERT INTO hash_files (hash_files_file, hash_files_size) VALUES ('" + SouborF.FullName.ToString().Replace("'", "''") + "', '" + SouborF.Length + "')");
                    }
                }
            }
            else if (Directory.Exists(pathName))
            {
                try
                {
                    List<DirectoryInfo> Adresare = Hash_Directories(pathName);

                    foreach (DirectoryInfo Adresar in Adresare)
                    {
                        foreach (FileInfo Soubor in Adresar.GetFiles(@"*", SearchOption.TopDirectoryOnly))
                            Nacti_HashS(Soubor.FullName);
                    }
                }
                catch
                {
                }

                Application.DoEvents();
            }
        }

        //Hashování v novém threadu
        private void Hash_Click(object sender, EventArgs e)
        {
            if (!Hash_W.IsBusy)
            {
                Hash_Check();

                if (Hash.Enabled)
                {
                    Hash_CheckRun();
                    Hash_W.RunWorkerAsync();
                }
            }
        }

        //Zahájení nového Threadu
        private void Hash_W_DoWork(object sender, DoWorkEventArgs e)
        {
            int q = 0;

            while (Hash_Nazvy_Souboru.Items.Count > 0)
            {
                Hash_String = "";
                Hash_JeSmazano = true;

                if (Hash_W.CancellationPending)
                    return;

                try
                {
                    if (File.Exists(Hash_Nazvy_Souboru.Items[0].ToString()))
                    {
                        FileInfo Soubor = new FileInfo(Hash_Nazvy_Souboru.Items[0].ToString());

                        if (Hash_CH01.Checked && File.Exists(GlobalAdresar + @"avdump2\AVDump2CL.exe") && q < 10)
                        {
                            q++;

                            string Arguments = "";
                            if (Hash_CH02.Checked)
                                Arguments = " --Log=\"" + GlobalAdresar + @"avdumpLog.txt" + "\" ";

                            Process Proc = new Process();
                            Proc.StartInfo.FileName = GlobalAdresar + @"avdump2\AVDump2CL.exe";
                            Proc.StartInfo.Arguments = "\"" + Soubor.FullName + "\"" + Arguments + " --Exp=\"" + GlobalAdresar + "avdump.txt" + "\" --Auth=" + Options_User.Text + ":" + Options_Password.Text + " -a";

                            if (!Hash_CH03.Checked)
                            {
                                Proc.StartInfo.CreateNoWindow = true;
                                Proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            }

                            Thread.Sleep(2000);

                            Proc.Start();
                            Proc.WaitForExit();

                            Thread.Sleep((int)(Hash_Waiting.Value + 1));

                            if (File.Exists(GlobalAdresar + "avdump.txt"))
                            {
                                if (new FileInfo(GlobalAdresar + "avdump.txt").Length > 0)
                                {
                                    StreamReader Cti = new StreamReader(GlobalAdresar + "avdump.txt");

                                    Hash_String = Cti.ReadLine().Replace("\r", "").Replace("\n", "").Split('|')[4];

                                    Cti.Close();
                                    Cti.Dispose();

                                    FileDelete(GlobalAdresar + "avdump.txt");

                                    Hash_JeSmazano = false;

                                    Hash_TotalLenghtCast += Soubor.Length;
                                    Hash_W.ReportProgress(100, (int)((double)(Hash_TotalLenghtCast * 100) / Hash_TotalLenght));

                                    while (true)
                                    {
                                        if (Hash_JeSmazano)
                                            break;

                                        Thread.Sleep(1);
                                    }

                                    q = 0;
                                }
                            }
                        }
                        else
                        {
                            Stream stream = File.OpenRead(Soubor.FullName);
                            Ed2k ed2k = new Ed2k();

                            long Velikost = stream.Length;

                            byte[] buffer = new byte[32 * 1024];

                            long PrectenoCelkem = 0;

                            while (true)
                            {
                                int Precteno = stream.Read(buffer, 0, buffer.Length);
                                PrectenoCelkem += Precteno;
                                Hash_TotalLenghtCast += Precteno;

                                if (Precteno == 0)
                                {
                                    ed2k.TransformFinalBlock(buffer, 0, Precteno);
                                    break;
                                }

                                ed2k.TransformBlock(buffer, 0, Precteno, null, 0);

                                Hash_W.ReportProgress((int)((double)PrectenoCelkem * 100 / Velikost), (int)((double)(Hash_TotalLenghtCast * 100) / Hash_TotalLenght));

                                if (Hash_W.CancellationPending)
                                    return;

                                if (Hash_Waiting.Value > 0)
                                    Thread.Sleep((int)Hash_Waiting.Value);
                            }

                            if (Hash_W.CancellationPending)
                                return;

                            foreach (byte b in (byte[])ed2k.Hash)
                                Hash_String += b.ToString("X2");

                            if (!ed2k.BlueIsRed())
                            {
                                Hash_String += ";";
                                for (int j = 0; j < ed2k.BlueHash.Length; j++)
                                {
                                    Hash_String += ed2k.BlueHash[j].ToString("X2");
                                }
                            }

                            Hash_JeSmazano = false;
                            Hash_W.ReportProgress(100, 100);

                            while (true)
                            {
                                if (Hash_JeSmazano)
                                    break;

                                Thread.Sleep(1);
                            }

                            stream.Close();
                            stream.Dispose();

                            q = 0;
                        }
                    }
                    else
                    {
                        Hash_Chyba = true;

                        Hash_JeSmazano = false;
                        Hash_W.ReportProgress(100, 100);

                        while (true)
                        {
                            if (Hash_JeSmazano)
                                break;

                            Thread.Sleep(1);
                        }

                        q = 0;
                    }
                }
                catch
                {
                }
            }

            return;
        }

        //Odstranění hotových souborů
        private void Hash_W_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!Hash_Chyba)
            {
                if (!Hash_JeSmazano)
                {
                    DatabaseAdd("DELETE FROM hash_files WHERE hash_files_file='" + Hash_Nazvy_Souboru.Items[0].ToString().Replace("'", "''") + "'");

                    FileInfo Soubor = new FileInfo(Hash_Nazvy_Souboru.Items[0].ToString());
                    InitializeComponentArgs(Hash_String + "*" + Soubor.FullName + "*" + Soubor.Length);

                    Hash_Nazvy_Souboru.Items.RemoveAt(0);

                    Hash_JeSmazano = true;

                    Hash_GR01.Text = Language.Hash_GR01 + " (" + Hash_Nazvy_Souboru.Items.Count + ")";
                }

                int x = e.ProgressPercentage;
                int y = Convert.ToInt32(e.UserState.ToString());

                if (x > 100)
                    x = 100;
                else if (x < 0)
                    x = 0;

                if (y > 100)
                    y = 100;
                else if (y < 0)
                    y = 0;

                Hash_ProgressBar.Value = x;
                Hash_ProgressBar_Percent.Text = x + "%";

                StatusBar_ProgressBar.Value = y;
                Hash_ProgressBar_Total.Value = y;
                Hash_ProgressBar_Total_Percent.Text = y + "%";

                StatusBar_Mn06.Text = x + "%/" + y + "%";
            }
            else
            {
                DatabaseAdd("DELETE FROM hash_files WHERE hash_files_file='" + Hash_Nazvy_Souboru.Items[0].ToString().Replace("'", "''") + "'");

                Hash_Nazvy_Souboru.Items.RemoveAt(0);
                Hash_Chyba = false;
                Hash_JeSmazano = true;
            }
        }

        //Dokončení Threadu
        private void Hash_W_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StatusBar_ProgressBar.Value = 100;
            Hash_ProgressBar.Value = 100;
            Hash_ProgressBar_Total.Value = 100;
            Hash_ProgressBar_Percent.Text = "100%";
            Hash_ProgressBar_Total_Percent.Text = "100%";

            StatusBar_Mn06.Text = Hash_ProgressBar.Value + "%/" + Hash_ProgressBar_Total.Value + "%";

            Hash_TotalLenght = 0;
            Hash_TotalLenghtCast = 0;

            if (Hash_CH01.Checked && Hash_CH02.Checked && File.Exists(GlobalAdresar + @"avdumpLog.txt"))
                Process.Start(GlobalAdresar + @"avdumpLog.txt");

            Hash_CheckRun();
            Hash_Check();
        }

        //Zastavení vlákna
        private void Hash_Stop_Total_Click(object sender, EventArgs e)
        {
            Hash_W.CancelAsync();
        }

        //Hash DragDrop
        private void Hash_Nazvy_Souboru_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string Soubor in (string[])e.Data.GetData(DataFormats.FileDrop))
                    Nacti_Hash(Soubor);
            }
        }

        //Kontrola tlačítek
        private void Hash_Check()
        {
            if (!Hash_W.IsBusy)
            {
                if (Hash_Nazvy_Souboru.Items.Count > 0)
                {
                    Hash.Enabled = true;
                    Hash_Files.Enabled = true;
                    Hash_Delete.Enabled = true;
                    Hash_DeleteAll.Enabled = true;
                    StatusBar_Hash.Enabled = true;

                    Hash_GR01.Text = Language.Hash_GR01 + " (" + Hash_Nazvy_Souboru.Items.Count + ")";
                }
                else
                {
                    Hash_TotalLenght = 0;
                    Hash_TotalLenghtCast = 0;

                    StatusBar_Hash.Enabled = false;
                    Hash.Enabled = false;
                    Hash_Files.Enabled = false;
                    Hash_Delete.Enabled = false;
                    Hash_DeleteAll.Enabled = false;

                    Hash_GR01.Text = Language.Hash_GR01;
                }
            }

            if (Hash_Nazvy_Souboru.Items.Count > 0 && !Hash_W.IsBusy)
            {
                Hash_TotalLenght = 0;
                DataTable DT = DatabaseSelect("SELECT hash_files_size FROM hash_files");

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    try
                    {
                        Hash_TotalLenght += Convert.ToInt64(DT.Rows[i]["hash_files_size"].ToString());
                    }
                    catch
                    {
                    }
                }
            }
        }

        //Kontrola tlačítek
        private void Hash_CheckRun()
        {
            if (!Hash_W.IsBusy)
            {
                if (Hash.Enabled)
                {
                    Hash.Enabled = false;
                    StatusBar_Hash.Enabled = false;
                    Hash_DeleteAll.Enabled = false;
                    Hash_Delete.Enabled = false;
                    Hash_Stop_Total.Enabled = true;
                }
                else
                {
                    Hash.Enabled = true;
                    StatusBar_Hash.Enabled = true;
                    Hash_DeleteAll.Enabled = true;
                    Hash_Delete.Enabled = true;
                    Hash_Stop_Total.Enabled = false;
                }
            }
        }

        //Hash DragDrop
        private void Hash_Nazvy_Souboru_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        //Parsování
        private void Hash_Files_Click(object sender, EventArgs e)
        {
            List<string> List = new List<string>();

            foreach (string Radek in Hash_Nazvy_Souboru.Items)
                List.Add(Radek);

            foreach (string Radek in List)
            {
                Application.DoEvents();
                FileInfo Soubor = new FileInfo(Radek);

                if (Soubor.Extension.ToLower() == ".sfv")
                {
                    try
                    {
                        Hash_Nazvy_Souboru.Items.Remove(Radek);
                        DatabaseAdd("DELETE FROM hash_files WHERE hash_files_file='" + Radek.Replace("'", "''") + "'");

                        StreamReader Cti = new StreamReader(Soubor.FullName);

                        while (Cti.Peek() >= 0)
                        {
                            Application.DoEvents();
                            string CtiRadek = Cti.ReadLine();

                            if (CtiRadek != null)
                                if (CtiRadek.Length > 1)
                                    if (CtiRadek.Substring(0, 1) != ";")
                                    {
                                        string[] T = CtiRadek.Split(' ');

                                        if (T.Length > 1)
                                            if (File.Exists(Soubor.Directory + @"\" + CtiRadek.Replace(" " + T[T.Length - 1], "")))
                                            {
                                                DataTable dataTable = DatabaseSelect("SELECT * FROM files WHERE files_crc32='" + T[T.Length - 1] + "'");

                                                FileInfo CtiSoubor = new FileInfo(Soubor.Directory + @"\" + CtiRadek.Replace(" " + T[T.Length - 1], ""));

                                                if (dataTable.Rows.Count == 1)
                                                {
                                                    DatabaseAdd("UPDATE files set files_size='" + CtiSoubor.Length + "', files_localfile='" + CtiSoubor.FullName.Replace("'", "''") + "' WHERE files_crc32='" + T[T.Length - 1] + "'");
                                                    ComunicationNewTask("FILE size=" + CtiSoubor.Length + "&ed2k=" + dataTable.Rows[0]["files_ed2k"].ToString().ToLower() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                                                }
                                                else if (Options_ExtensionList.Items.Contains(CtiSoubor.Extension.ToLower()))
                                                {
                                                    Nacti_Hash(CtiSoubor.FullName);
                                                }
                                            }
                                    }
                        }

                        Cti.Close();
                        Cti.Dispose();
                    }
                    catch (Exception ee)
                    {
                        LogAddError("PARSER > E R O R R  I N  CRC32\r\n" + ee.ToString());
                    }
                }
                else if (Soubor.Extension.ToLower() == ".md5")
                {
                    try
                    {
                        Hash_Nazvy_Souboru.Items.Remove(Radek);
                        DatabaseAdd("DELETE FROM hash_files WHERE hash_files_file='" + Radek.Replace("'", "''") + "'");

                        StreamReader Cti = new StreamReader(Soubor.FullName);

                        while (Cti.Peek() >= 0)
                        {
                            Application.DoEvents();
                            string CtiRadek = Cti.ReadLine();

                            if (CtiRadek != null)
                                if (CtiRadek.Length > 1)
                                    if (CtiRadek.Substring(0, 1) != ";")
                                    {
                                        string[] T = CtiRadek.Split('*');

                                        if (T.Length == 2)
                                            if (File.Exists(Soubor.Directory + @"\" + T[1]))
                                            {
                                                DataTable dataTable = DatabaseSelect("SELECT * FROM files WHERE files_md5='" + T[0].Replace(" ", "").ToLower() + "'");

                                                FileInfo CtiSoubor = new FileInfo(Soubor.Directory + @"\" + T[1]);

                                                if (dataTable.Rows.Count == 1)
                                                {
                                                    DatabaseAdd("UPDATE files set files_size='" + CtiSoubor.Length + "', files_localfile='" + CtiSoubor.FullName.Replace("'", "''") + "' WHERE files_md5='" + T[0].Replace(" ", "").ToLower() + "'");
                                                    ComunicationNewTask("FILE size=" + CtiSoubor.Length + "&ed2k=" + dataTable.Rows[0]["files_ed2k"].ToString().ToLower() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                                                }
                                                else if (Options_ExtensionList.Items.Contains(CtiSoubor.Extension.ToLower()))
                                                {
                                                    Nacti_Hash(CtiSoubor.FullName);
                                                }
                                            }
                                    }
                        }

                        Cti.Close();
                        Cti.Dispose();
                    }
                    catch (Exception ee)
                    {
                        LogAddError("PARSER > E R O R R  I N  MD5\r\n" + ee.ToString());
                    }
                }
                else if (Soubor.Extension.ToLower() == ".ed2k")
                {
                    try
                    {
                        Hash_Nazvy_Souboru.Items.Remove(Radek);
                        DatabaseAdd("DELETE FROM hash_files WHERE hash_files_file='" + Radek.Replace("'", "''") + "'");

                        StreamReader Cti = new StreamReader(Soubor.FullName);

                        while (Cti.Peek() >= 0)
                        {
                            Application.DoEvents();
                            string CtiRadek = Cti.ReadLine();

                            if (CtiRadek != null)
                                if (CtiRadek.Length > 1)
                                    if (CtiRadek.Substring(0, 1) != ";")
                                    {
                                        string[] T = CtiRadek.Split('|');

                                        if (T.Length > 4)
                                            if (File.Exists(Soubor.Directory + @"\" + T[2]))
                                            {
                                                DataTable dataTable = DatabaseSelect("SELECT * FROM files WHERE files_ed2k='" + T[4].ToLower() + "'");

                                                FileInfo CtiSoubor = new FileInfo(Soubor.Directory + @"\" + T[2]);

                                                if (dataTable.Rows.Count == 1)
                                                {
                                                    DatabaseAdd("UPDATE files set files_size='" + CtiSoubor.Length + "', files_localfile='" + CtiSoubor.FullName.Replace("'", "''") + "' WHERE files_ed2k='" + T[4].ToLower() + "'");
                                                    ComunicationNewTask("FILE size=" + CtiSoubor.Length + "&ed2k=" + dataTable.Rows[0]["files_ed2k"].ToString().ToLower() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
                                                }
                                                else if (Options_ExtensionList.Items.Contains(CtiSoubor.Extension.ToLower()))
                                                    InitializeComponentArgs(T[4].ToLower() + "*" + CtiSoubor.FullName + "*" + CtiSoubor.Length);
                                            }
                                    }
                        }

                        Cti.Close();
                        Cti.Dispose();
                    }
                    catch (Exception ee)
                    {
                        LogAddError("PARSER > E R O R R  I N  ED2K\r\n" + ee.ToString());
                    }
                }
                else if (Soubor.Extension.ToLower() == ".xml")
                {
                    try
                    {
                        Hash_Nazvy_Souboru.Items.Remove(Radek);
                        DatabaseAdd("DELETE FROM hash_files WHERE hash_files_file='" + Radek.Replace("'", "''") + "'");

                        StreamReader xmlCti = new StreamReader(Soubor.FullName);

                        Dictionary<string, string> xmlTAnime = new Dictionary<string, string>();
                        Dictionary<string, string> xmlTEpisode = new Dictionary<string, string>();
                        Dictionary<string, string> xmlTFile = new Dictionary<string, string>();
                        Dictionary<string, string> xmlTGenres = new Dictionary<string, string>();
                        Dictionary<string, string> xmlTGroups = new Dictionary<string, string>();
                        string GroupID = "";
                        int k = 0;
                        bool[] xmlB = new bool[11];
                        xmlB[10] = false;

                        while (xmlCti.Peek() >= 0)
                        {
                            Application.DoEvents();
                            string xmlRadek = xmlCti.ReadLine().Replace("\r", "").Replace("\n", "").Replace("|", "").Replace("\t", "") + " ";

                            if (xmlRadek.Contains("<anime id=\""))
                            {
                                xmlTAnime.Add("id", Parse(xmlRadek, "<anime id=\"", "\"", false));
                                xmlTAnime.Add("type", Parse(xmlRadek, "type=\"", "\"", false));
                                xmlTAnime.Add("year", Parse(xmlRadek, "year=\"", "\"", false));
                            }
                            else if (xmlRadek.Contains("<neps user="))
                            {
                                xmlTAnime.Add("neps", Parse(xmlRadek, "cnt=\"", "\"", false));
                            }
                            else if (xmlRadek.Contains("<title type=\"main\" lang=\"x-jat\">"))
                            {
                                xmlTAnime.Add("jap", Parse(xmlRadek, "<![CDATA[", "]]>", false));
                            }
                            else if (xmlRadek.Contains("<title type=\"official\" lang=\"ja\">"))
                            {
                                xmlTAnime.Add("kaj", Parse(xmlRadek, "<![CDATA[", "]]", false));
                            }
                            else if (xmlRadek.Contains("<title type=\"official\" lang=\"en\">"))
                            {
                                xmlTAnime.Add("eng", Parse(xmlRadek, "<![CDATA[", "]]", false));
                            }
                            else if (xmlRadek.Contains("<cat id=\""))
                            {
                                xmlTGenres.Add(k.ToString(), Parse(xmlRadek, "\">", "</cat>", false));
                                k++;
                            }
                            else if (xmlRadek.Contains("<dates added=\""))
                            {
                                xmlTAnime.Add("air", Parse(xmlRadek, "start=\"", "\"", false));
                                xmlTAnime.Add("end", Parse(xmlRadek, "end=\"", "\"", false));
                                k++;
                            }
                            else if (xmlRadek.Contains("<resources>"))
                            {
                                xmlB[0] = true;
                            }
                            else if (xmlRadek.Contains("<url>") && xmlB[0])
                            {
                                xmlTAnime.Add("url", Parse(xmlRadek, "<url>", "</url>", false));
                                xmlB[0] = false;
                            }
                            else if (xmlRadek.Contains("<group id=\"") && xmlRadek.Contains("agid"))
                            {
                                GroupID = Parse(xmlRadek, "<group id=\"", "\"", false);
                                xmlTGroups.Add(GroupID + "I", Parse(xmlRadek, "<name>", "</name>", false));
                                xmlB[1] = true;
                            }
                            else if (xmlRadek.Contains("<name>") && xmlB[1])
                            {
                                xmlTGroups.Add(GroupID + "N", Parse(xmlRadek, "<name>", "</name>", false));
                            }
                            else if (xmlRadek.Contains("<sname>") && xmlB[1])
                            {
                                xmlTGroups.Add(GroupID + "S", Parse(xmlRadek, "<sname>", "</sname>", false));
                                xmlB[1] = false;
                            }
                            else if (xmlRadek.Contains("ep id=\""))
                            {
                                if (!xmlTAnime.Keys.Contains("jap"))
                                    xmlTAnime.Add("jap", "");

                                if (!xmlTAnime.Keys.Contains("eng"))
                                    xmlTAnime.Add("eng", "");

                                if (!xmlTAnime.Keys.Contains("kaj"))
                                    xmlTAnime.Add("kaj", "");

                                if (!xmlTAnime.Keys.Contains("url"))
                                    xmlTAnime.Add("url", "");


                                xmlTEpisode.Clear();
                                xmlTEpisode.Add("id", Parse(xmlRadek, "ep id=\"", "\"", false));
                            }
                            else if (xmlRadek.Contains("<title lang=\"en\"><![CDATA["))
                            {
                                xmlTEpisode.Add("eng", Parse(xmlRadek, "<![CDATA[", "]]>", false));
                            }
                            else if (xmlRadek.Contains("<title lang=\"x-jat\"><![CDATA["))
                            {
                                xmlTEpisode.Add("jap", Parse(xmlRadek, "<![CDATA[", "]]>", false));
                            }
                            else if (xmlRadek.Contains("<epno>"))
                            {
                                xmlTEpisode.Add("epn", Parse(xmlRadek, "<epno>", "</epno>", false));
                            }
                            else if (xmlRadek.Contains("<title lang=\"ja\"><![CDATA["))
                            {
                                xmlTEpisode.Add("kaj", Parse(xmlRadek, "<![CDATA[", "]]>", false));
                            }
                            else if (xmlRadek.Contains("file id=\""))
                            {
                                if (!xmlTEpisode.Keys.Contains("jap"))
                                    xmlTEpisode.Add("jap", "");

                                if (!xmlTEpisode.Keys.Contains("eng"))
                                    xmlTEpisode.Add("eng", "");

                                if (!xmlTEpisode.Keys.Contains("kaj"))
                                    xmlTEpisode.Add("kaj", "");

                                xmlTFile.Clear();
                                xmlTFile.Add("id", Parse(xmlRadek, "file id=\"", "\"", false));
                                xmlB[4] = true;
                                xmlB[5] = true;
                            }
                            else if (xmlRadek.Contains("<flags>") && xmlB[5])
                            {
                                xmlTFile.Add("flags", Parse(xmlRadek, "<flags>", "</flags>", false));
                                xmlB[5] = false;
                            }
                            else if (xmlRadek.Contains("<storage>"))
                            {
                                xmlTFile.Add("storage", Parse(xmlRadek, "<storage>", "</storage>", false));
                            }
                            else if (xmlRadek.Contains("<date viewed=\""))
                            {
                                string date = Parse(xmlRadek, "<date viewed=\"", "\"", false);
                                if (date == "-")
                                    xmlTFile.Add("dateviewed", "0");
                                else
                                {
                                    DateTime Date = new DateTime(1970, 1, 1);
                                    DateTime.TryParse(date, out Date);
                                    Date = Date.AddDays(1);

                                    string x = (TimeSpan.FromTicks(Date.Ticks - new DateTime(1970, 1, 1).Ticks).TotalSeconds).ToString();

                                    xmlTFile.Add("dateviewed", x);
                                }
                            }
                            else if (xmlRadek.Contains("<mystate>"))
                            {
                                xmlTFile.Add("mystate", Parse(xmlRadek, "<mystate>", "</mystate>", false));
                            }
                            else if (xmlRadek.Contains("<size>"))
                            {
                                xmlTFile.Add("size", Parse(xmlRadek, "<size>", "</size>", false));
                            }
                            else if (xmlRadek.Contains("<ftype>"))
                            {
                                xmlTFile.Add("ftype", Parse(xmlRadek, "<ftype>", "</ftype>", false));
                            }
                            else if (xmlRadek.Contains("<len>") && xmlB[4])
                            {
                                xmlTFile.Add("len", Parse(xmlRadek, "<len>", "</len>", false));
                                xmlB[4] = false;
                            }
                            else if (xmlRadek.Contains("<crc>"))
                            {
                                xmlTFile.Add("crc", Parse(xmlRadek, "<crc>", "</crc>", false));
                            }
                            else if (xmlRadek.Contains("<md5>"))
                            {
                                xmlTFile.Add("md5", Parse(xmlRadek, "<md5>", "</md5>", false));
                            }
                            else if (xmlRadek.Contains("<sha1>"))
                            {
                                xmlTFile.Add("sha1", Parse(xmlRadek, "<sha1>", "</sha1>", false));
                            }
                            else if (xmlRadek.Contains("<tth>"))
                            {
                                xmlTFile.Add("tth", Parse(xmlRadek, "<tth>", "</tth>", false));
                            }
                            else if (xmlRadek.Contains("<ed2k>"))
                            {
                                xmlTFile.Add("ed2k", Parse(xmlRadek, "<ed2k>", "</ed2k>", false));
                            }
                            else if (xmlRadek.Contains("<date update="))
                            {
                                string date = Parse(xmlRadek, ">", "</date>", false);
                                DateTime Date = new DateTime(1970, 1, 1);
                                DateTime.TryParse(date, out Date);
                                Date = Date.AddDays(1);

                                string x = (TimeSpan.FromTicks(Date.Ticks - new DateTime(1970, 1, 1).Ticks).TotalSeconds).ToString();

                                xmlTFile.Add("aired", x);
                            }
                            else if (xmlRadek.Contains("<qual>"))
                            {
                                xmlTFile.Add("qual", Parse(xmlRadek, "<qual>", "</qual>", false));
                            }
                            else if (xmlRadek.Contains("<source>"))
                            {
                                xmlTFile.Add("source", Parse(xmlRadek, "<source>", "</source>", false));
                            }
                            else if (xmlRadek.Contains("<group id=\""))
                            {
                                xmlTFile.Add("gid", Parse(xmlRadek, "<group id=\"", "\"", false));
                            }
                            else if (xmlRadek.Contains("<source>"))
                            {
                                xmlTFile.Add("source", Parse(xmlRadek, "<source>", "</source>", false));
                            }
                            else if (xmlRadek.Contains("<vid cnt="))
                            {
                                xmlB[2] = true;
                            }
                            else if (xmlRadek.Contains("<res>") && xmlB[2])
                            {
                                xmlTFile.Add("res", Parse(xmlRadek, "<res>", "</res>", false));
                            }
                            else if (xmlRadek.Contains("<br>") && xmlB[2])
                            {
                                xmlTFile.Add("vbr", Parse(xmlRadek, "<br>", "</br>", false));
                            }
                            else if (xmlRadek.Contains("<codec>") && xmlB[2])
                            {
                                xmlTFile.Add("vcodec", Parse(xmlRadek, "<codec>", "</codec>", false));
                                xmlB[2] = false;
                            }
                            else if (xmlRadek.Contains("<aud cnt="))
                            {
                                xmlB[3] = true;
                            }
                            else if (xmlRadek.Contains("<br>") && xmlB[3])
                            {
                                xmlTFile.Add("abr", Parse(xmlRadek, "<br>", "</br>", false));
                            }
                            else if (xmlRadek.Contains("<codec>") && xmlB[3])
                            {
                                xmlTFile.Add("acodec", Parse(xmlRadek, "<codec>", "</codec>", false));
                                xmlB[3] = false;
                            }
                            else if (xmlRadek.Contains("</file>"))
                            {
                                if (!xmlTFile.Keys.Contains("flags"))
                                    xmlTFile.Add("flags", "1");

                                if (!xmlTFile.Keys.Contains("sha1"))
                                    xmlTFile.Add("sha1", "");

                                if (!xmlTFile.Keys.Contains("md5"))
                                    xmlTFile.Add("md5", "");

                                if (!xmlTFile.Keys.Contains("storage"))
                                    xmlTFile.Add("storage", "");

                                if (!xmlTFile.Keys.Contains("acodec"))
                                    xmlTFile.Add("acodec", "");

                                if (!xmlTFile.Keys.Contains("abr"))
                                    xmlTFile.Add("abr", "0");

                                if (!xmlTFile.Keys.Contains("vcodec"))
                                    xmlTFile.Add("vcodec", "");

                                if (!xmlTFile.Keys.Contains("gid"))
                                    xmlTFile.Add("gid", "0");

                                if (!xmlTGroups.Keys.Contains(xmlTFile["gid"] + "N"))
                                    xmlTGroups.Add(xmlTFile["gid"] + "N", "");

                                if (!xmlTGroups.Keys.Contains(xmlTFile["gid"] + "S"))
                                    xmlTGroups.Add(xmlTFile["gid"] + "S", "");

                                if (!xmlTFile.Keys.Contains("qual"))
                                    xmlTFile.Add("qual", "");

                                if (!xmlTFile.Keys.Contains("source"))
                                    xmlTFile.Add("source", "");

                                if (!xmlTFile.Keys.Contains("vbr"))
                                    xmlTFile.Add("vbr", "0");

                                if (!xmlTFile.Keys.Contains("res"))
                                    xmlTFile.Add("res", "");

                                if (!xmlTFile.Keys.Contains("ftype"))
                                    xmlTFile.Add("ftype", "");

                                if (!xmlTFile.Keys.Contains("size"))
                                    xmlTFile.Add("size", "0");

                                if (!xmlTFile.Keys.Contains("ed2k"))
                                    xmlTFile.Add("ed2k", "");

                                if (!xmlTFile.Keys.Contains("md5"))
                                    xmlTFile.Add("md5", "");

                                if (!xmlTFile.Keys.Contains("sha1"))
                                    xmlTFile.Add("sha1", "");

                                if (!xmlTFile.Keys.Contains("crc"))
                                    xmlTFile.Add("crc", "");

                                if (!xmlTFile.Keys.Contains("len"))
                                    xmlTFile.Add("len", "0");

                                string Categories = "";

                                foreach (KeyValuePair<string, string> Genre in xmlTGenres)
                                    Categories += Genre.Value + ",";

                                string groupN = "";
                                string groupS = "";

                                if (xmlTFile["gid"] != "0")
                                {
                                    groupN = xmlTGroups[xmlTFile["gid"] + "N"];
                                    groupS = xmlTGroups[xmlTFile["gid"] + "S"];
                                }

                                if (Categories.Length > 0)
                                    Categories = Categories.Remove(Categories.Length - 1, 1);

                                ComunicationW_DataReceive = xmlTFile["id"] + "|";
                                ComunicationW_DataReceive += xmlTAnime["id"] + "|";
                                ComunicationW_DataReceive += xmlTEpisode["id"] + "|";
                                ComunicationW_DataReceive += xmlTFile["gid"] + "|";
                                ComunicationW_DataReceive += "0" + "|" + "" + "|" + "1" + "|";
                                ComunicationW_DataReceive += xmlTFile["flags"] + "|";
                                ComunicationW_DataReceive += xmlTFile["size"] + "|";
                                ComunicationW_DataReceive += xmlTFile["ed2k"] + "|";
                                ComunicationW_DataReceive += xmlTFile["md5"] + "|";
                                ComunicationW_DataReceive += xmlTFile["sha1"] + "|";
                                ComunicationW_DataReceive += xmlTFile["crc"] + "|";
                                ComunicationW_DataReceive += "|";
                                ComunicationW_DataReceive += xmlTFile["qual"] + "|";
                                ComunicationW_DataReceive += xmlTFile["source"] + "|";
                                ComunicationW_DataReceive += xmlTFile["acodec"] + "|";
                                ComunicationW_DataReceive += xmlTFile["abr"] + "|";
                                ComunicationW_DataReceive += xmlTFile["vcodec"] + "|";
                                ComunicationW_DataReceive += xmlTFile["vbr"] + "|";
                                ComunicationW_DataReceive += xmlTFile["res"] + "|";
                                ComunicationW_DataReceive += xmlTFile["ftype"] + "|";
                                ComunicationW_DataReceive += "" + "|" + "" + "|";
                                ComunicationW_DataReceive += xmlTFile["len"] + "|";
                                ComunicationW_DataReceive += "" + "|" + xmlTFile["aired"] + "|" + "" + "|";
                                ComunicationW_DataReceive += xmlTAnime["neps"] + "|";
                                ComunicationW_DataReceive += xmlTAnime["neps"] + "|";
                                ComunicationW_DataReceive += xmlTAnime["year"] + "|";
                                ComunicationW_DataReceive += xmlTAnime["type"] + "|";
                                if (!xmlB[10])
                                {
                                    ComunicationW_DataReceive += "" + "|" + "" + "|" + Categories + "|";
                                    xmlB[10] = true;
                                }
                                else
                                    ComunicationW_DataReceive += "" + "|" + "" + "|" + "|";
                                ComunicationW_DataReceive += xmlTAnime["jap"] + "|";
                                ComunicationW_DataReceive += xmlTAnime["kaj"] + "|";
                                ComunicationW_DataReceive += xmlTAnime["eng"] + "|";
                                ComunicationW_DataReceive += xmlTEpisode["epn"] + "|";
                                ComunicationW_DataReceive += xmlTEpisode["eng"] + "|";
                                ComunicationW_DataReceive += xmlTEpisode["jap"] + "|";
                                ComunicationW_DataReceive += xmlTEpisode["kaj"] + "|";
                                ComunicationW_DataReceive += groupN + "|";
                                ComunicationW_DataReceive += groupS + "|";
                                ComunicationW_DataReceive += xmlTFile["dateviewed"];

                                ComunicationW_DataReceive = ComunicationW_DataReceive.Replace("'", "''");

                                AniDBParserFiles();

                                string files_watched = "0";

                                if (xmlTFile["dateviewed"] != "0")
                                {
                                    DatabaseAdd("UPDATE files SET files_seen=#" + DatumFormat(GetDateFromSeconds(xmlTFile["dateviewed"])) + "# WHERE id_files=" + xmlTFile["id"]);

                                    files_watched = "1";
                                }

                                if (Categories.Contains("18 Restricted"))
                                    DatabaseAdd("UPDATE anime SET anime_18=1 WHERE id_anime=" + xmlTAnime["id"]);

                                DatabaseAdd("UPDATE files SET files_storage='" + xmlTFile["storage"].Replace("'", "''") + "', files_watched=" + files_watched + " WHERE id_files=" + xmlTFile["id"]);

                                DataTable DFile = DatabaseSelect("SELECT * FROM files WHERE id_files=" + xmlTFile["id"]);
                            }
                        }

                        DateTime Air = new DateTime(1970, 1, 1);
                        DateTime End = new DateTime(1970, 1, 1);

                        DateTime.TryParse(xmlTAnime["air"], out Air);
                        DateTime.TryParse(xmlTAnime["end"], out End);

                        Air = Air.AddDays(1);
                        End = End.AddDays(1);

                        string Airx = (TimeSpan.FromTicks(Air.Ticks - new DateTime(1970, 1, 1).Ticks).TotalSeconds).ToString();
                        string Endy = (TimeSpan.FromTicks(End.Ticks - new DateTime(1970, 1, 1).Ticks).TotalSeconds).ToString();

                        DatabaseAdd("UPDATE anime SET anime_epn=" + xmlTAnime["neps"] + ", anime_date_air=#" + DatumFormat(GetDateFromSeconds(Airx)) + "#, anime_date_end=#" + DatumFormat(GetDateFromSeconds(Endy)) + "# WHERE id_anime=" + xmlTAnime["id"]);

                        if (xmlTAnime["url"] != "")
                            DatabaseAdd("UPDATE anime SET anime_url='" + xmlTAnime["url"].Replace("'", "''") + "' WHERE id_anime=" + xmlTAnime["id"]);

                        xmlCti.Close();
                    }
                    catch (Exception ee)
                    {
                        LogAddError("PARSER > E R O R R  I N  XML\r\n" + ee.ToString());
                    }
                }
                else if (Soubor.Name == "mylist.txt")
                {
                    try
                    {
                        StreamReader Cti = new StreamReader(Soubor.FullName);

                        while (Cti.Peek() >= 0)
                        {
                            Application.DoEvents();

                            string[] T = Cti.ReadLine().Split('|');

                            if (T.Length > 2)
                            {
                                try
                                {
                                    Convert.ToInt32(T[0]);
                                    Convert.ToInt32(T[1]);

                                    DatabaseAdd("UPDATE files SET files_lid=" + T[0] + " WHERE id_files=" + T[1]);
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        LogAddError("PARSER > E R O R R\r\n" + ee.ToString());
                    }

                }
            }

            Hash_Check();
        }

        //Smazat soubory
        private void Hash_Delete_Click(object sender, EventArgs e)
        {
            List<int> List = new List<int>();

            foreach (string Radek in Hash_Nazvy_Souboru.SelectedItems)
            {
                int x = Hash_Nazvy_Souboru.Items.IndexOf(Radek);

                if (!List.Contains(x))
                    List.Add(x);
            }

            List.Sort();

            int k = 0;

            foreach (int Radek in List)
            {
                DatabaseAdd("DELETE FROM hash_files WHERE hash_files_file='" + Hash_Nazvy_Souboru.Items[Radek - k].ToString().Replace("'", "''") + "'");
                Hash_Nazvy_Souboru.Items.RemoveAt(Radek - k);
                k++;
            }

            Hash_Check();
        }

        //Vymazat vše
        private void Hash_DeleteAll_Click(object sender, EventArgs e)
        {
            DatabaseAdd("DELETE FROM hash_files");
            Hash_Nazvy_Souboru.Items.Clear();
            Hash_Check();
        }
        #endregion

        #region Focus
        private void AnimeTree_MouseEnter(object sender, EventArgs e)
        {
            AnimeTree.Focus();
        }

        private void AnimeData_MouseEnter(object sender, EventArgs e)
        {
            AnimeData.Focus();
        }

        private void Options_ExtensionList_MouseEnter(object sender, EventArgs e)
        {
            Options_ExtensionList.Focus();
        }

        private void Rules_Replace_MouseEnter(object sender, EventArgs e)
        {
            Rules_Replace.Focus();
        }

        private void Hash_Nazvy_Souboru_MouseEnter(object sender, EventArgs e)
        {
            Hash_Nazvy_Souboru.Focus();
        }

        private void DataFiles_MouseEnter(object sender, EventArgs e)
        {
            DataFiles.Focus();
        }

        private void DataAnime_MouseEnter(object sender, EventArgs e)
        {
            DataAnime.Focus();
        }

        private void DataGenres_MouseEnter(object sender, EventArgs e)
        {
            DataGenres.Focus();
        }

        private void MainTabData_MouseEnter(object sender, EventArgs e)
        {
            MainTabData.Focus();
        }

        private void DataSearch_Genres_MouseEnter(object sender, EventArgs e)
        {
            DataSearch.Focus();
        }

        private void DataSearch_MouseEnter(object sender, EventArgs e)
        {
            DataSearch.Focus();
        }

        private void Manga_Tree_MouseEnter(object sender, EventArgs e)
        {
            Manga_Tree.Focus();
        }

        private void Manga_Data_MouseEnter(object sender, EventArgs e)
        {
            Manga_Data.Focus();
        }

        private void MangaSearch_MouseEnter(object sender, EventArgs e)
        {
            MangaSearch.Focus();
        }
        #endregion

        #region Rename
        //Přejmenuj soubory
        private void FRename_W_DoWork(object sender, DoWorkEventArgs e)
        {
            FRename_W.ReportProgress(100);

            while (true)
            {
                if (!FRename_Wait)
                    break;

                Thread.Sleep(1000);
            }

            while (FRename_List.Count > 0)
            {
                Rules_Apply(FRename_List[0]);

                FRename_List.RemoveAt(0);
            }
        }

        //Zakaž přejmenování při prázdném poli
        private void FRename_W_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusBar_Mn04.Text = Language.StatusBar_Mn04_On;

            if (Rules_FilesRulesRename.Text.Length == 0)
                Rules_FilesRulesRename_RB02.Checked = true;

            if (Rules_FilesRulesMove.Text.Length == 0)
                Rules_FilesRulesMove_RB03.Checked = true;

            FRename_Wait = false;
        }

        //Dokončení přejmenování souborů
        private void FRename_W_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!DataFilesTree.Enabled)
                DatabaseSelectFiles();

            StatusBar_Mn04.Text = Language.StatusBar_Mn04_Off;
        }
        #endregion

        #region DataSQL
        //Aplikuj SQL dotaz
        private void DataSQL_Select_Click(object sender, EventArgs e)
        {
            DataSQL_SelectS();
        }

        //Aplikuj SQL dotaz
        private void DataSQL_SelectS()
        {
            DataSQL.SuspendLayout();
            DataFiles.ColumnHeadersVisible = false;

            DataSQL.Rows.Clear();

            DataSQL.DataSource = DatabaseSelect(DataSQL_Text.Text.Replace("'", "''"));

            if (!DataSQL_Text.Items.Contains(DataSQL_Text.Text))
                DataSQL_Text.Items.Add(DataSQL_Text.Text);

            DataFiles.ColumnHeadersVisible = true;
            DataSQL.ResumeLayout();
        }

        //Vyber názvy sloupců
        private void DataSQL_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSQL_Columns.Items.Clear();

            DataTable Sloupce = DatabaseSelect("SELECT TOP 1 * FROM " + DataSQL_Tables.Items[DataSQL_Tables.SelectedIndex]);

            foreach (DataColumn col in Sloupce.Columns)
                DataSQL_Columns.Items.Add(col.ColumnName);

            DataSQL_Text.Text = "SELECT * FROM " + DataSQL_Tables.Items[DataSQL_Tables.SelectedIndex];
        }

        //Vytvoř dotaz
        private void DataSQL_Columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSQL_Text.Text = "SELECT ";

            foreach (int Index in DataSQL_Columns.SelectedIndices)
                DataSQL_Text.Text += DataSQL_Columns.Items[Index].ToString() + ", ";

            DataSQL_Text.Text = DataSQL_Text.Text.Remove(DataSQL_Text.Text.Length - 2, 1);

            DataSQL_Text.Text += "FROM " + DataSQL_Tables.Items[DataSQL_Tables.SelectedIndex];
        }

        //Aktualizace anime
        private void DataSQL_BT01_Click(object sender, EventArgs e)
        {
            int x = -1;

            for (int i = 0; i < DataSQL.Columns.Count; i++)
                if (DataSQL.Columns[0].HeaderText == "id_anime")
                {
                    x = i;
                    break;
                }

            if (x != -1)
                foreach (DataGridViewRow row in DataSQL.SelectedRows)
                    ComunicationNewTask("ANIME aid=" + DataSQL[x, row.Index].Value.ToString() + "&amask=BEE0FE01");
        }

        //Aktualizace episod
        private void DataSQL_BT02_Click(object sender, EventArgs e)
        {
            int x = -1;

            for (int i = 0; i < DataSQL.Columns.Count; i++)
                if (DataSQL.Columns[0].HeaderText == "id_episodes")
                {
                    x = i;
                    break;
                }

            if (x != -1)
                foreach (DataGridViewRow row in DataSQL.SelectedRows)
                    ComunicationNewTask("EPISODE eid=" + DataSQL[x, row.Index].Value.ToString());
        }

        //Aktualizace souborů
        private void DataSQL_BT03_Click(object sender, EventArgs e)
        {
            int x = -1;

            for (int i = 0; i < DataSQL.Columns.Count; i++)
                if (DataSQL.Columns[0].HeaderText == "id_files")
                {
                    x = i;
                    break;
                }

            if (x != -1)
                foreach (DataGridViewRow row in DataSQL.SelectedRows)
                    ComunicationNewTask("FILE fid=" + DataSQL[x, row.Index].Value.ToString() + "&fmask=7FFAFFF9&amask=FEE0F0C1");
        }

        //Aktualizace Mylist
        private void DataSQL_BT04_Click(object sender, EventArgs e)
        {
            int x = -1;

            for (int i = 0; i < DataSQL.Columns.Count; i++)
                if (DataSQL.Columns[0].HeaderText == "id_files")
                {
                    x = i;
                    break;
                }

            if (x != -1)
                foreach (DataGridViewRow row in DataSQL.SelectedRows)
                    ComunicationNewTask("MYLIST fid=" + DataSQL[x, row.Index].Value.ToString());
        }

        //Apliku SQL dotaz
        private void DataSQL_Text_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DataSQL_Select_Click(null, null);
        }
        #endregion

        #region Watcher
        //Přidání adresáře
        private void Watcher_Add_Click(object sender, EventArgs e)
        {
            string path = OpenDirectoryDialog("");

            if (Directory.Exists(path))
            {
                if (!Watcher_List.Items.Contains(path))
                {
                    Watcher_List.Items.Add(path);
                    DatabaseAdd("INSERT INTO watcher (watcher_path) VALUES ('" + path.Replace("'", "''") + "')");
                }
            }
        }

        //Vymazání adresářů
        private void Watcher_Delete_Click(object sender, EventArgs e)
        {
            if (Watcher_List.SelectedIndex >= 0 && Watcher_List.SelectedIndex < Watcher_List.Items.Count)
            {
                DatabaseAdd("DELETE FROM watcher WHERE watcher_path='" + Watcher_List.Items[Watcher_List.SelectedIndex].ToString().Replace("'", "''") + "'");
                Watcher_List.Items.RemoveAt(Watcher_List.SelectedIndex);
            }
        }

        //Sputit hlídky
        private void Watcher_Run()
        {
            DataTable DWatcher = DatabaseSelect("SELECT * FROM watcher");

            foreach (DataRow row in DWatcher.Rows)
                Watcher_List.Items.Add(row["watcher_path"].ToString());

            if (Watcher_CH01.Checked && Watcher_List.Items.Count > 0)
            {
                foreach (string Radek in Watcher_List.Items)
                {
                    FileSystemWatcher Watcher = new FileSystemWatcher();
                    Watcher.IncludeSubdirectories = true;
                    Watcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.Size;

                    Watcher.Renamed += new RenamedEventHandler(Watcher_Renamed);
                    Watcher.Deleted += new FileSystemEventHandler(Watcher_Deleted);
                    Watcher.Created += new FileSystemEventHandler(Watcher_Created);

                    Watcher.Filter = "*";
                    Watcher.Path = Radek;
                    Watcher.EnableRaisingEvents = true;
                    this.components.Add(Watcher);
                }
            }
        }

        //Při změně hlídek
        void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (Watcher_SouborOldM != null)
            {
                if (Watcher_SouborOldM.Name == e.Name)
                {
                    if (File.Exists(e.FullPath))
                    {
                        DataTable DFile = DatabaseSelect("SELECT * FROM files WHERE files_localfile='" + Watcher_SouborOldM.FullName.Replace("'", "''") + "'");

                        if (DFile.Rows.Count > 0)
                            DatabaseAdd("UPDATE files SET files_localfile='" + e.FullPath.Replace("'", "''") + "' WHERE files_localfile='" + Watcher_SouborOldM.FullName.Replace("'", "''") + "'");
                        else
                            Nacti_Hash(e.FullPath);
                    }
                }
                else
                {
                    if (File.Exists(e.FullPath))
                        Nacti_Hash(e.FullPath);
                }
            }
            else
            {
                if (File.Exists(e.FullPath))
                    Nacti_Hash(e.FullPath);
            }

            Watcher_SouborOldM = null;
            Watcher_SouborOldR = new FileInfo(e.FullPath);
        }

        //Při změně hlídek
        void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (Watcher_SouborOldR != null)
            {
                FileInfo Soubor = new FileInfo(e.FullPath);

                if (Watcher_SouborOldR.Name == Soubor.Name)
                {
                    if (File.Exists(Watcher_SouborOldR.FullName))
                    {
                        DataTable DFile = DatabaseSelect("SELECT * FROM files WHERE files_localfile='" + e.FullPath.Replace("'", "''") + "'");

                        if (DFile.Rows.Count > 0)
                        {
                            DatabaseAdd("UPDATE files SET files_localfile='" + Watcher_SouborOldR.FullName.Replace("'", "''") + "' WHERE files_localfile='" + e.FullPath.Replace("'", "''") + "'");
                            Hash_Nazvy_Souboru.Items.Remove(Watcher_SouborOldR.FullName);
                            DatabaseAdd("DELETE FROM hash_files WHERE hash_files_file='" + Watcher_SouborOldR.FullName.Replace("'", "''") + "'");
                        }
                        else
                            Nacti_Hash(e.FullPath);
                    }
                }
                else
                    Nacti_Hash(e.FullPath);

                Watcher_SouborOldR = null;
                Watcher_SouborOldM = null;
            }
            else
            {
                Watcher_SouborOldM = new FileInfo(e.FullPath);
            }
        }

        //Při změně hlídek
        void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                DataTable DFile = DatabaseSelect("SELECT * FROM files WHERE files_localfile='" + e.OldFullPath.Replace("'", "''") + "'");

                if (DFile.Rows.Count > 0)
                    DatabaseAdd("UPDATE files SET files_localfile='" + e.FullPath.Replace("'", "''") + "' WHERE files_localfile='" + e.OldFullPath.Replace("'", "''") + "'");
                else
                    Nacti_Hash(e.FullPath);
            }
        }
        #endregion

        #region Manga
        //Vybrání mangy
        private void Manga_Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataTable DManga = DatabaseSelect("SELECT * FROM manga WHERE id_manga=" + Manga_Tree.SelectedNode.Name);
            DataTable DGenres = DatabaseSelect("SELECT * FROM manga_genres INNER JOIN genres ON genres.id_grenres=manga_genres.id_genres WHERE manga_genres.id_manga=" + Manga_Tree.SelectedNode.Name);
            DataTable DChapters = DatabaseSelect("SELECT manga_chatpers_volume FROM manga_chapters WHERE id_manga=" + Manga_Tree.SelectedNode.Name + " GROUP BY manga_chatpers_volume ORDER BY manga_chatpers_volume ASC");
            DataTable DAnime = DatabaseSelect("SELECT manga_anime.id_anime, anime_nazevjap FROM manga_anime INNER JOIN anime On anime.id_anime=manga_anime.id_anime WHERE id_manga=" + Manga_Tree.SelectedNode.Name);
            DataTable DMangaRel = DatabaseSelect("SELECT manga_relations.id_manga_related, manga_nazevjap FROM manga_relations INNER JOIN manga On manga.id_manga=manga_relations.id_manga_related WHERE manga_relations.id_manga=" + Manga_Tree.SelectedNode.Name);

            Manga_Gr01.Text = DManga.Rows[0]["manga_nazevjap"].ToString();

            Manga_LB12.Text = DManga.Rows[0]["manga_nazevjap"].ToString();
            Manga_LB04.Text = DManga.Rows[0]["manga_nazevkaj"].ToString();
            Manga_LB06.Text = DManga.Rows[0]["manga_nazeveng"].ToString();
            Manga_LB08.Text = DManga.Rows[0]["manga_rok"].ToString();
            Manga_LB10.Text = DManga.Rows[0]["manga_volume"].ToString();
            Manga_LB38.Text = DManga.Rows[0]["manga_author"].ToString();
            Manga_LB40.Text = DManga.Rows[0]["manga_artist"].ToString();
            Manga_LB45.Text = DManga.Rows[0]["manga_url"].ToString();

            if (Manga_LB45.Text.Length == 0)
                Manga_LB45.Visible = false;
            else
                Manga_LB45.Visible = true;

            if (DManga.Rows[0]["manga_18"].ToString() == "1")
                Manga_LB09.Visible = true;
            else
                Manga_LB09.Visible = false;

            if (DManga.Rows[0]["manga_MU"].ToString() == "0")
                Manga_LB14.Visible = false;
            else
                Manga_LB14.Visible = true;

            if (DManga.Rows[0]["manga_MT"].ToString() == "0")
                Manga_LB13.Visible = false;
            else
                Manga_LB13.Visible = true;

            if (DManga.Rows[0]["manga_MAL"].ToString() == "0")
                Manga_LB52.Visible = false;
            else
                Manga_LB52.Visible = true;

            if (DManga.Rows[0]["manga_MugiMugi"].ToString() == "0")
                Manga_LB53.Visible = false;
            else
                Manga_LB53.Visible = true;

            Manga_LB14.Text = "http://www.mangaupdates.com/series.html?id=" + DManga.Rows[0]["manga_MU"].ToString();
            Manga_LB13.Text = "http://www.mangatraders.com/manga/series/" + DManga.Rows[0]["manga_MT"].ToString();
            Manga_LB52.Text = "http://myanimelist.net/manga/" + DManga.Rows[0]["manga_MAL"].ToString() + "/";
            Manga_LB53.Text = "http://doujinshi.mugimugi.org/book/" + DManga.Rows[0]["manga_MugiMugi"].ToString() + "/";

            Manga_CB01.Items.Clear();
            Manga_CB01.SelectedIndexChanged -= new EventHandler(Manga_CB01_SelectedIndexChanged);

            try
            {
                for (int i = 0; i < DGenres.Rows.Count; i++)
                    Manga_CB01.Items.Add(DGenres.Rows[i]["genres_genre"].ToString());

                Manga_CB01.Text = DGenres.Rows[0]["genres_genre"].ToString();
            }
            catch
            {
            }

            Manga_CB01.SelectedIndexChanged += new EventHandler(Manga_CB01_SelectedIndexChanged);

            if (Manga_CB01.Items.Count == 0)
            {
                Manga_LB25.Visible = false;
                Manga_CB01.Visible = false;
            }
            else
            {
                Manga_LB25.Visible = true;
                Manga_CB01.Visible = true;
            }

            if (Manga_LB08.Text == "0")
            {
                Manga_LB07.Visible = false;
                Manga_LB08.Visible = false;
            }
            else
            {
                Manga_LB07.Visible = true;
                Manga_LB08.Visible = true;
            }

            if (Manga_LB10.Text == "0")
            {
                Manga_LB15.Visible = false;
                Manga_LB10.Visible = false;
            }
            else
            {
                Manga_LB15.Visible = true;
                Manga_LB10.Visible = true;
            }

            if (Manga_LB04.Text == "")
            {
                Manga_LB03.Visible = false;
                Manga_LB04.Visible = false;
            }
            else
            {
                Manga_LB03.Visible = true;
                Manga_LB04.Visible = true;
            }

            if (Manga_LB06.Text == "")
            {
                Manga_LB05.Visible = false;
                Manga_LB06.Visible = false;
            }
            else
            {
                Manga_LB05.Visible = true;
                Manga_LB06.Visible = true;
            }

            if (Manga_LB38.Text == "")
            {
                Manga_LB38.Visible = false;
                Manga_LB37.Visible = false;
            }
            else
            {
                Manga_LB38.Visible = true;
                Manga_LB37.Visible = true;
            }

            if (Manga_LB40.Text == "")
            {
                Manga_LB40.Visible = false;
                Manga_LB39.Visible = false;
            }
            else
            {
                Manga_LB40.Visible = true;
                Manga_LB39.Visible = true;
            }

            Manga_Picture.BackgroundImage = null;

            try
            {
                if (File.Exists(GlobalAdresar + @"Accounts\!imgsm\" + DManga.Rows[0]["manga_obr"].ToString()))
                {
                    StreamReader Cti = new StreamReader(GlobalAdresar + @"Accounts\!imgsm\" + DManga.Rows[0]["manga_obr"].ToString());

                    Image img = Image.FromStream(Cti.BaseStream);

                    Cti.Close();
                    Cti.Dispose();

                    Manga_Picture.BackgroundImage = img;
                }
            }
            catch
            {
            }

            Manga_Data.Rows.Clear();

            for (int i = 0; i < DChapters.Rows.Count; i++)
                Manga_Data.Rows.Add(
                new int[3] { 0, 0, 0 },
                Resources.i_Expand,
                DChapters.Rows[i]["manga_chatpers_volume"].ToString(),
                "",
                "",
                "",
                "",
                "",
                new Bitmap(1, 1),
                new Bitmap(1, 1)
                );

            Manga_RelationTree.Nodes.Clear();

            if (DAnime.Rows.Count > 0 || DMangaRel.Rows.Count > 0)
            {
                if (DMangaRel.Rows.Count > 0)
                {
                    Manga_RelationTree.Nodes.Add("N", Language.MainTab_Mn07);

                    for (int i = 0; i < DMangaRel.Rows.Count; i++)
                        Manga_RelationTree.Nodes.Add("M" + DMangaRel.Rows[i]["id_manga_related"].ToString(), DMangaRel.Rows[i]["manga_nazevjap"].ToString());
                }

                if (DAnime.Rows.Count > 0 && DMangaRel.Rows.Count > 0)
                    Manga_RelationTree.Nodes.Add("N", "");

                if (DAnime.Rows.Count > 0)
                {
                    Manga_RelationTree.Nodes.Add("N", Language.MainTab_Mn03);

                    for (int i = 0; i < DAnime.Rows.Count; i++)
                        Manga_RelationTree.Nodes.Add("A" + DAnime.Rows[i]["id_anime"].ToString(), DAnime.Rows[i]["anime_nazevjap"].ToString());
                }

                Manga_RelationTree.Visible = true;
            }
            else
                Manga_RelationTree.Visible = false;
        }

        //Kliknutí na link
        private void Manga_LB14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Manga_LB14.Text);
        }

        //Kliknutí na link
        private void Manga_LB13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Manga_LB13.Text);
        }

        //Kliknutí na link
        private void Manga_LB45_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Manga_LB45.Text);
            }
            catch
            {
            }
        }

        //Kliknutí na link
        private void Manga_LB52_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Manga_LB52.Text);
            }
            catch
            {
            }
        }

        //Kliknutí na link
        private void Manga_LB53_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Manga_LB53.Text);
            }
            catch
            {
            }
        }

        //Vybrání JAP
        private void Manga_Lang01_Click(object sender, EventArgs e)
        {
            DatabaseSelectMangaTree(1);
        }

        //Vybrání ENG
        private void Manga_Lang02_Click(object sender, EventArgs e)
        {
            DatabaseSelectMangaTree(3);
        }

        //Vybrání KAN
        private void Manga_Lang03_Click(object sender, EventArgs e)
        {
            DatabaseSelectMangaTree(2);
        }

        //Rozevírání volume
        private void Manga_Data_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = Manga_Data.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right && Hit.RowIndex >= 0)
            {
                Manga_Data.Rows[Hit.RowIndex].Selected = true;
                int[] WTF = (int[])Manga_Data[0, Hit.RowIndex].Value;
                Manga_Data_Menu.Show(MousePosition.X, MousePosition.Y);
            }
            else if (Hit.RowIndex >= 0 && Hit.ColumnIndex >= 0)
            {
                int[] WTF = (int[])Manga_Data[0, Hit.RowIndex].Value;

                if (Hit.ColumnIndex == 1 && WTF[0] == 0 && WTF[1] == 0)
                    Manga_Data_RozevritEpisody(Hit.RowIndex);
                else if (Hit.ColumnIndex == 1 && WTF[0] == 1 && WTF[1] == 0)
                    Manga_Data_ZavritEpisody(Hit.RowIndex);
            }
        }

        //Rozevřít volume
        private void Manga_Data_RozevritEpisody(int RowIndex)
        {
            Manga_Data[0, RowIndex].Value = new int[3] { 1, 0, 0 };
            Manga_Data[1, RowIndex].Value = Resources.i_Collapse;

            DataTable dataTable = DatabaseSelect("SELECT * FROM manga_chapters WHERE id_manga=" + Manga_Tree.SelectedNode.Name + " AND manga_chatpers_volume=" + Manga_Data[2, RowIndex].Value.ToString() + " ORDER BY manga_chatpers_chatper DESC");

            foreach (DataRow row in dataTable.Rows)
            {
                Manga_Data.Rows.Insert(RowIndex + 1, 1);

                Image Read = new Bitmap(1, 1);

                if (row["manga_chatpers_read"].ToString() == "1")
                    Read = Resources.anidb_seen_yes;
                else
                    Read = Resources.anidb_seen_no;

                Manga_Data[0, RowIndex + 1].Value = new int[3] { 0, 1, Convert.ToInt32(row["id_manga_chatpers"].ToString()) };
                Manga_Data[1, RowIndex + 1].Value = new Bitmap(1, 1);
                Manga_Data[2, RowIndex + 1].Value = "";
                Manga_Data[3, RowIndex + 1].Value = row["manga_chatpers_chatper"].ToString();
                Manga_Data[4, RowIndex + 1].Value = row["manga_chatpers_name"].ToString();
                Manga_Data[5, RowIndex + 1].Value = row["manga_chatpers_pages"].ToString() + "p";
                Manga_Data[6, RowIndex + 1].Value = FilesSize(row["manga_chatpers_size"].ToString());
                Manga_Data[7, RowIndex + 1].Value = row["manga_chatpers_file"].ToString();
                Manga_Data[8, RowIndex + 1].Value = Read;
                Manga_Data[9, RowIndex + 1].Value = FilesLangAudio(row["manga_chatpers_lang"].ToString());

                Manga_Data.Rows[RowIndex + 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        //Zavřít volume
        private void Manga_Data_ZavritEpisody(int RowIndex)
        {
            Manga_Data[0, RowIndex].Value = new int[3] { 0, 0, 0 };
            Manga_Data[1, RowIndex].Value = Resources.i_Expand;

            while (RowIndex + 1 < Manga_Data.Rows.Count)
            {
                int[] WTF = (int[])Manga_Data[0, RowIndex + 1].Value;
                if (WTF[1] == 0)
                    break;

                Manga_Data.Rows.RemoveAt(RowIndex + 1);
            }
        }

        //Přejití na mangymangu
        private void Manga_RelationTree_DoubleClick(object sender, EventArgs e)
        {
            if (Manga_RelationTree.SelectedNode.Name.Length > 0)
            {
                if (Manga_RelationTree.SelectedNode.Name.Substring(0, 1) == "A")
                    AnimeTree_Find(Manga_RelationTree.SelectedNode.Name.Replace("A", ""));
                else if (Manga_RelationTree.SelectedNode.Name.Substring(0, 1) == "M")
                    MangaTree_Find(Manga_RelationTree.SelectedNode.Name.Replace("M", ""));
            }
        }

        //Vyhledání dle žánru
        private void Manga_CB01_SelectedIndexChanged(object sender, EventArgs e)
        {
            MangaSearch.Rows.Clear();
            DataTable DTA = DatabaseSelect("SELECT manga.* FROM (manga INNER JOIN manga_genres ON manga.id_manga=manga_genres.id_manga) INNER JOIN genres ON genres.id_grenres=manga_genres.id_genres WHERE genres_genre='" + Manga_CB01.Text.Replace("'", "''") + "' ORDER BY manga_nazevjap");

            foreach (DataRow row in DTA.Rows)
            {
                MangaSearch.Rows.Add(
                row["id_manga"].ToString(),
                row["manga_nazevjap"].ToString(),
                row["manga_nazevkaj"].ToString(),
                row["manga_rok"].ToString()
                );
            }

            if (MangaSearch.SortedColumn != null)
                MangaSearch.Sort(MangaSearch.SortedColumn, MangaSearch.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);

            MainTabManga.SelectedIndex = 2;
        }
        #endregion

        #region Manga Edit
        //Vybrat obrázek
        private void Manga_Obr_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                if (OFD.FileName.ToLower().EndsWith(".jpg") ||
                OFD.FileName.ToLower().EndsWith(".png") ||
                OFD.FileName.ToLower().EndsWith(".gif") ||
                OFD.FileName.ToLower().EndsWith(".bmp") ||
                OFD.FileName.ToLower().EndsWith(".jpeg"))
                    Manga_Tx08.Text = OFD.FileName;
            }
        }

        //Vložit novou mangu
        private void Manga_Insert_Click(object sender, EventArgs e)
        {
            if (Manga_Tx01.Text != "" && Manga_Tx00.Text == "0")
            {
                DataTable DT = DatabaseSelect("SELECT id_manga FROM manga WHERE manga_nazevjap='" + Manga_Tx01.Text.Replace("'", "''") + "'");

                if (DT.Rows.Count == 0)
                {
                    DT = DatabaseSelect("SELECT Max(id_manga) FROM manga");

                    int x18 = 0;
                    int ID = 0;

                    try
                    {
                        ID = Convert.ToInt32(DT.Rows[0][0]) + 1;
                    }
                    catch
                    {
                        ID = 1;
                    }

                    if (Manga_CH01.Checked)
                        x18 = 1;

                    Manga_Tx05.Text = Manga_Tx05.Text.Replace("http://www.mangaupdates.com/series.html?id=", "");
                    Manga_Tx05.Text = Manga_Tx05.Text.Replace("/", "");

                    Manga_Tx06.Text = Manga_Tx06.Text.Replace("http://www.mangatraders.com/manga/series/", "");
                    Manga_Tx06.Text = Manga_Tx06.Text.Replace("/", "");

                    Manga_Tx23.Text = Manga_Tx23.Text.Replace("http://myanimelist.net/manga/", "");
                    Manga_Tx23.Text = Manga_Tx23.Text.Split('/')[0];

                    Manga_Tx24.Text = Manga_Tx24.Text.Replace("http://doujinshi.mugimugi.org/book/", "");
                    Manga_Tx24.Text = Manga_Tx24.Text.Split('/')[0];

                    try
                    {
                        Manga_Tx05.Text = Convert.ToInt32(Manga_Tx05.Text).ToString();
                    }
                    catch
                    {
                        Manga_Tx05.Text = "0";
                    }

                    try
                    {
                        Manga_Tx06.Text = Convert.ToInt32(Manga_Tx06.Text).ToString();
                    }
                    catch
                    {
                        Manga_Tx06.Text = "0";
                    }

                    try
                    {
                        Manga_Tx07.Text = Convert.ToInt32(Manga_Tx07.Text).ToString();
                    }
                    catch
                    {
                        Manga_Tx07.Text = "0";
                    }

                    try
                    {
                        Manga_Tx23.Text = Convert.ToInt32(Manga_Tx23.Text).ToString();
                    }
                    catch
                    {
                        Manga_Tx23.Text = "0";
                    }

                    try
                    {
                        Manga_Tx24.Text = Convert.ToInt32(Manga_Tx24.Text).ToString();
                    }
                    catch
                    {
                        Manga_Tx24.Text = "0";
                    }

                    if (Manga_Tx22.Text != "")
                    {
                        Manga_Tx22.Text = Manga_Tx22.Text.Replace("http://", "");
                        Manga_Tx22.Text = "http://" + Manga_Tx22.Text;
                    }

                    DatabaseAdd("INSERT INTO manga VALUES (" + ID + ", '" + Manga_Tx01.Text.Replace("'", "''") + "', '" + Manga_Tx02.Text.Replace("'", "''") + "', '" + Manga_Tx03.Text.Replace("'", "''") + "', '" + Manga_Tx04.Text.Replace("'", "''") + "', '', " + x18 + ", " + Manga_Tx05.Text + ", " + Manga_Tx06.Text + ", " + Manga_Tx07.Text + ", '" + Manga_Tx18.Text + "', '" + Manga_Tx17.Text + "', '" + Manga_Tx22.Text + "', " + Manga_Tx23.Text + ", " + Manga_Tx24.Text + ")");

                    if (Manga_Tx08.Text == "")
                        Manga_Tx08.Text = MangaUrlObr;
                    MangaUrlObr = "";

                    if (Manga_Tx08.Text != "")
                    {
                        try
                        {
                            if (Manga_Tx08.Text.Contains("http://"))
                            {
                                WebClient WB = new WebClient();
                                WB.Headers.Clear();
                                WB.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729;)");
                                WB.Headers.Add("Referer", Manga_Tx08.Text);
                                WB.DownloadFile(Manga_Tx08.Text, GlobalAdresar + @"\Accounts\!imgsm\" + ID.ToString() + ".jpg");
                                Manga_Tx08.Text = GlobalAdresar + @"\Accounts\!imgsm\" + ID.ToString() + ".jpg";
                            }

                            StreamReader Cti = new StreamReader(Manga_Tx08.Text);
                            Image img = Image.FromStream(Cti.BaseStream);
                            Cti.Close();
                            Cti.Dispose();

                            img = resizeImage(img, new Size(225, 279));
                            img.Save(GlobalAdresar + @"\Accounts\!imgsm\" + ID.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                            DatabaseAdd("UPDATE manga SET manga_obr='" + ID.ToString() + ".jpg' WHERE id_manga=" + ID.ToString());
                        }
                        catch
                        {
                        }
                    }

                    string SQL = "";

                    for (int i = 0; i < Manga_Genres.Items.Count; i++)
                    {
                        if (Manga_Genres.GetItemChecked(i))
                            SQL += "genres_genre='" + Manga_Genres.Items[i].ToString() + "' OR ";
                    }

                    if (SQL != "")
                    {
                        SQL = SQL.Substring(0, SQL.Length - 4);

                        DataTable Genres = DatabaseSelect("SELECT * FROM genres WHERE " + SQL);

                        for (int i = 0; i < Genres.Rows.Count; i++)
                            DatabaseAdd("INSERT INTO manga_genres (id_genres, id_manga) VALUES (" + Genres.Rows[i]["id_grenres"] + ", " + ID.ToString() + ")");
                    }

                    SQL = "";

                    for (int i = 0; i < Manga_Anime.Items.Count; i++)
                    {
                        if (Manga_Anime.GetItemChecked(i))
                            SQL += "anime_nazevjap='" + Manga_Anime.Items[i].ToString().Replace("'", "''") + "' OR ";
                    }

                    if (SQL != "")
                    {
                        SQL = SQL.Substring(0, SQL.Length - 4);

                        DataTable Anime = DatabaseSelect("SELECT id_anime FROM anime WHERE " + SQL);

                        for (int i = 0; i < Anime.Rows.Count; i++)
                            DatabaseAdd("INSERT INTO manga_anime (id_anime, id_manga) VALUES (" + Anime.Rows[i]["id_anime"] + ", " + ID.ToString() + ")");
                    }

                    SQL = "";

                    for (int i = 0; i < Manga_Manga.Items.Count; i++)
                    {
                        if (Manga_Manga.GetItemChecked(i))
                            SQL += "Manga_nazevjap='" + Manga_Manga.Items[i].ToString().Replace("'", "''") + "' OR ";
                    }

                    if (SQL != "")
                    {
                        SQL = SQL.Substring(0, SQL.Length - 4);

                        DataTable Manga = DatabaseSelect("SELECT id_manga FROM manga WHERE " + SQL);

                        for (int i = 0; i < Manga.Rows.Count; i++)
                            DatabaseAdd("INSERT INTO manga_relations (id_manga, id_manga_related) VALUES (" + ID.ToString() + ", " + Manga.Rows[i]["id_manga"] + ")");
                    }

                    for (int i = 0; i < Manga_Genres.Items.Count; i++)
                        Manga_Genres.SetItemChecked(i, false);

                    for (int i = 0; i < Manga_Anime.Items.Count; i++)
                        Manga_Anime.SetItemChecked(i, false);

                    for (int i = 0; i < Manga_Manga.Items.Count; i++)
                        Manga_Manga.SetItemChecked(i, false);

                    Manga_Tx00.Text = "0";
                    Manga_Tx01.Text = "";
                    Manga_Tx02.Text = "";
                    Manga_Tx03.Text = "";
                    Manga_Tx04.Text = "0";
                    Manga_Tx05.Text = "0";
                    Manga_Tx06.Text = "0";
                    Manga_Tx07.Text = "0";
                    Manga_Tx08.Text = "";
                    Manga_Tx22.Text = "";

                    MangaTree_Find(ID.ToString());

                    Manga_Genres.Items.Clear();
                    Manga_Anime.Items.Clear();
                    Manga_Manga.Items.Clear();
                }
            }
        }

        //Edit
        private void Manga_Edit_Click(object sender, EventArgs e)
        {
            Manga_Gr02.Dock = DockStyle.Fill;
            Manga_Gr02.Visible = true;
            Manga_Gr03.Visible = false;
            Manga_Gr03.Dock = DockStyle.None;

            bool Hentai = Manga_LB09.Visible;

            MainTabManga.SelectedIndex = 1;

            DataTable DGenres = DatabaseSelect("SELECT * FROM manga_genres INNER JOIN genres ON genres.id_grenres=manga_genres.id_genres WHERE manga_genres.id_manga=" + Manga_Tree.SelectedNode.Name);
            DataTable DManga = DatabaseSelect("SELECT manga_nazevjap FROM manga_relations INNER JOIN manga ON manga.id_manga=manga_relations.id_manga_related WHERE manga_relations.id_manga=" + Manga_Tree.SelectedNode.Name);
            DataTable DAnime = DatabaseSelect("SELECT anime_nazevjap FROM manga_anime INNER JOIN anime ON anime.id_anime=manga_anime.id_anime WHERE manga_anime.id_manga=" + Manga_Tree.SelectedNode.Name);

            Manga_Tx00.Text = Manga_Tree.SelectedNode.Name;
            Manga_Tx01.Text = Manga_LB12.Text;
            Manga_Tx02.Text = Manga_LB04.Text;
            Manga_Tx03.Text = Manga_LB06.Text;
            Manga_Tx04.Text = Manga_LB08.Text;
            Manga_Tx05.Text = Manga_LB14.Text;
            Manga_Tx06.Text = Manga_LB13.Text;
            Manga_Tx23.Text = Manga_LB52.Text;
            Manga_Tx24.Text = Manga_LB53.Text;
            Manga_Tx07.Text = Manga_LB10.Text;
            Manga_Tx08.Text = "";
            Manga_Tx17.Text = Manga_LB38.Text;
            Manga_Tx18.Text = Manga_LB40.Text;
            Manga_Tx22.Text = Manga_LB45.Text;

            Manga_CH01.Checked = Hentai;

            for (int i = 0; i < Manga_Genres.Items.Count; i++)
                Manga_Genres.SetItemChecked(i, false);

            for (int i = 0; i < Manga_Anime.Items.Count; i++)
                Manga_Anime.SetItemChecked(i, false);

            for (int i = 0; i < Manga_Manga.Items.Count; i++)
                Manga_Manga.SetItemChecked(i, false);

            foreach (DataRow GRow in DGenres.Rows)
            {
                int x = Manga_Genres.FindString(GRow["genres_genre"].ToString());

                if (x >= 0)
                    Manga_Genres.SetItemChecked(x, true);
            }

            foreach (DataRow GRow in DAnime.Rows)
            {
                int x = Manga_Anime.FindString(GRow["anime_nazevjap"].ToString());

                if (x >= 0)
                    Manga_Anime.SetItemChecked(x, true);
            }

            foreach (DataRow GRow in DManga.Rows)
            {
                int x = Manga_Manga.FindString(GRow["manga_nazevjap"].ToString());

                if (x >= 0)
                    Manga_Manga.SetItemChecked(x, true);
            }

            Manga_Insert.Visible = false;
            Manga_Update.Visible = true;
            Manga_Delete.Visible = true;
        }

        //Edit
        private void Manga_Update_Click(object sender, EventArgs e)
        {
            int x18 = 0;
            int ID = Convert.ToInt32(Manga_Tx00.Text);

            if (Manga_CH01.Checked)
                x18 = 1;

            Manga_Tx05.Text = Manga_Tx05.Text.Replace("http://www.mangaupdates.com/series.html?id=", "");
            Manga_Tx05.Text = Manga_Tx05.Text.Replace("/", "");

            Manga_Tx06.Text = Manga_Tx06.Text.Replace("http://www.mangatraders.com/manga/series/", "");
            Manga_Tx06.Text = Manga_Tx06.Text.Replace("/", "");

            Manga_Tx23.Text = Manga_Tx23.Text.Replace("http://myanimelist.net/manga/", "");
            Manga_Tx23.Text = Manga_Tx23.Text.Split('/')[0];

            Manga_Tx24.Text = Manga_Tx24.Text.Replace("http://doujinshi.mugimugi.org/book/", "");
            Manga_Tx24.Text = Manga_Tx24.Text.Split('/')[0];

            try
            {
                Manga_Tx05.Text = Convert.ToInt32(Manga_Tx05.Text).ToString();
            }
            catch
            {
                Manga_Tx05.Text = "0";
            }

            try
            {
                Manga_Tx06.Text = Convert.ToInt32(Manga_Tx06.Text).ToString();
            }
            catch
            {
                Manga_Tx06.Text = "0";
            }

            try
            {
                Manga_Tx07.Text = Convert.ToInt32(Manga_Tx07.Text).ToString();
            }
            catch
            {
                Manga_Tx07.Text = "0";
            }

            try
            {
                Manga_Tx23.Text = Convert.ToInt32(Manga_Tx23.Text).ToString();
            }
            catch
            {
                Manga_Tx23.Text = "0";
            }

            try
            {
                Manga_Tx24.Text = Convert.ToInt32(Manga_Tx24.Text).ToString();
            }
            catch
            {
                Manga_Tx24.Text = "0";
            }

            if (Manga_Tx22.Text != "")
            {
                Manga_Tx22.Text = Manga_Tx22.Text.Replace("http://", "");
                Manga_Tx22.Text = "http://" + Manga_Tx22.Text;
            }

            DatabaseAdd("UPDATE manga set manga_nazevjap='" + Manga_Tx01.Text.Replace("'", "''") + "', manga_nazevkaj='" + Manga_Tx02.Text.Replace("'", "''") + "', manga_nazeveng='" + Manga_Tx03.Text.Replace("'", "''") + "', manga_rok='" + Manga_Tx04.Text.Replace("'", "''") + "', manga_18=" + x18 + ", manga_MU=" + Manga_Tx05.Text + ", manga_MT=" + Manga_Tx06.Text + ", manga_volume=" + Manga_Tx07.Text + ", manga_artist='" + Manga_Tx18.Text.Replace("'", "''") + "', manga_author='" + Manga_Tx17.Text.Replace("'", "''") + "', manga_url='" + Manga_Tx22.Text + "', manga_MAL=" + Manga_Tx23.Text + ", manga_MugiMugi=" + Manga_Tx24.Text + " WHERE id_manga=" + ID);

            if (Manga_Tx08.Text != "")
            {
                if (File.Exists(Manga_Tx08.Text))
                {
                    StreamReader Cti = new StreamReader(Manga_Tx08.Text);

                    Image img = Image.FromStream(Cti.BaseStream);

                    Cti.Close();
                    Cti.Dispose();

                    img = resizeImage(img, new Size(225, 279));
                    Manga_Picture.BackgroundImage = img;

                    FileDelete(GlobalAdresar + @"\Accounts\!imgsm\" + ID.ToString() + ".jpg");
                    img.Save(GlobalAdresar + @"\Accounts\!imgsm\" + ID.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                    DatabaseAdd("UPDATE manga SET manga_obr='" + ID.ToString() + ".jpg' WHERE id_manga=" + ID.ToString());
                }
            }

            if (MangaUrlObr != "")
            {
                try
                {
                    DataTable Manga = DatabaseSelect("SELECT manga_obr FROM manga WHERE id_manga=" + ID.ToString());

                    if (Manga.Rows.Count > 0)
                        if (Manga.Rows[0]["manga_obr"].ToString().Length > 0)
                            MangaUrlObr = "";

                    if (Manga_Tx08.Text.Contains("http://"))
                    {

                        WebClient WB = new WebClient();
                        WB.Headers.Clear();
                        WB.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729;)");
                        WB.Headers.Add("Referer", Manga_Tx08.Text);
                        WB.DownloadFile(Manga_Tx08.Text, GlobalAdresar + @"\Accounts\!imgsm\" + ID.ToString() + ".jpg");
                        Manga_Tx08.Text = GlobalAdresar + @"\Accounts\!imgsm\" + ID.ToString() + ".jpg";
                    }
                }
                catch
                {
                }

                MangaUrlObr = "";
            }

            string SQL = "";
            DatabaseAdd("DELETE FROM manga_genres WHERE id_manga=" + ID);

            for (int i = 0; i < Manga_Genres.Items.Count; i++)
            {
                if (Manga_Genres.GetItemChecked(i))
                    SQL += "genres_genre='" + Manga_Genres.Items[i].ToString() + "' OR ";
            }

            if (SQL != "")
            {
                SQL = SQL.Substring(0, SQL.Length - 4);

                DataTable Genres = DatabaseSelect("SELECT * FROM genres WHERE " + SQL);

                for (int i = 0; i < Genres.Rows.Count; i++)
                    DatabaseAdd("INSERT INTO manga_genres (id_genres, id_manga) VALUES (" + Genres.Rows[i]["id_grenres"] + ", " + ID.ToString() + ")");
            }

            DatabaseAdd("DELETE FROM manga_anime WHERE id_manga=" + ID);
            SQL = "";

            for (int i = 0; i < Manga_Anime.Items.Count; i++)
            {
                if (Manga_Anime.GetItemChecked(i))
                    SQL += "anime_nazevjap='" + Manga_Anime.Items[i].ToString().Replace("'", "''") + "' OR ";
            }

            if (SQL != "")
            {
                SQL = SQL.Substring(0, SQL.Length - 4);

                DataTable Anime = DatabaseSelect("SELECT id_anime FROM anime WHERE " + SQL);

                for (int i = 0; i < Anime.Rows.Count; i++)
                    DatabaseAdd("INSERT INTO manga_anime (id_anime, id_manga) VALUES (" + Anime.Rows[i]["id_anime"] + ", " + ID.ToString() + ")");
            }

            DatabaseAdd("DELETE FROM manga_relations WHERE id_manga=" + ID);
            DatabaseAdd("DELETE FROM manga_relations WHERE id_manga_related=" + ID);
            SQL = "";

            for (int i = 0; i < Manga_Manga.Items.Count; i++)
            {
                if (Manga_Manga.GetItemChecked(i))
                    SQL += "manga_nazevjap='" + Manga_Manga.Items[i].ToString().Replace("'", "''") + "' OR ";
            }

            if (SQL != "")
            {
                SQL = SQL.Substring(0, SQL.Length - 4);

                DataTable Manga = DatabaseSelect("SELECT id_manga FROM manga WHERE " + SQL);

                for (int i = 0; i < Manga.Rows.Count; i++)
                {
                    DatabaseAdd("INSERT INTO manga_relations (id_manga, id_manga_related) VALUES (" + ID.ToString() + ", " + Manga.Rows[i]["id_manga"] + ")");
                    DatabaseAdd("INSERT INTO manga_relations (id_manga, id_manga_related) VALUES (" + Manga.Rows[i]["id_manga"] + ", " + ID.ToString() + ")");
                }
            }

            for (int i = 0; i < Manga_Genres.Items.Count; i++)
                Manga_Genres.SetItemChecked(i, false);

            for (int i = 0; i < Manga_Anime.Items.Count; i++)
                Manga_Anime.SetItemChecked(i, false);

            for (int i = 0; i < Manga_Manga.Items.Count; i++)
                Manga_Manga.SetItemChecked(i, false);

            Manga_Tx00.Text = "0";
            Manga_Tx01.Text = "";
            Manga_Tx02.Text = "";
            Manga_Tx03.Text = "";
            Manga_Tx04.Text = "0";
            Manga_Tx05.Text = "0";
            Manga_Tx06.Text = "0";
            Manga_Tx07.Text = "0";
            Manga_Tx22.Text = "";
            Manga_Tx08.Text = "";

            MangaTree_Find(ID.ToString());

            Manga_Genres.Items.Clear();
            Manga_Anime.Items.Clear();
            Manga_Manga.Items.Clear();
        }

        //Přidat chapter
        private void Manga_Chapter_Click(object sender, EventArgs e)
        {
            Manga_Gr02.Visible = false;
            Manga_Gr02.Dock = DockStyle.None;
            Manga_Gr03.Visible = true;
            Manga_Gr03.Dock = DockStyle.Fill;
            Manga_Tx12.Text = Manga_Tree.SelectedNode.Name;
            Manga_Tx21.SelectedIndex = 1;
            MainTabManga.SelectedIndex = 1;
        }

        //Smazání mangy
        private void Manga_Delete_Click(object sender, EventArgs e)
        {
            Manga_Remove(Manga_Tx00.Text);
        }

        //Přečetno
        private void Manga_Data_Menu_Mn02_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Manga_Data.SelectedRows)
            {
                int[] WTF = (int[])Manga_Data[0, row.Index].Value;

                if (WTF[1] == 1)
                    DatabaseAdd("UPDATE manga_chapters SET manga_chatpers_read=1 WHERE id_manga_chatpers=" + WTF[2]);
            }
        }

        //Nepřečteno
        private void Manga_Data_Menu_Mn03_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Manga_Data.SelectedRows)
            {
                int[] WTF = (int[])Manga_Data[0, row.Index].Value;

                if (WTF[1] == 1)
                    DatabaseAdd("UPDATE manga_chapters SET manga_chatpers_read=0 WHERE id_manga_chatpers=" + WTF[2]);
            }
        }

        //Smazat
        private void Manga_Data_Menu_Mn04_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Manga_Data.SelectedRows)
            {
                int[] WTF = (int[])Manga_Data[0, row.Index].Value;

                if (WTF[1] == 1)
                    DatabaseAdd("DELETE FROM manga_chapters WHERE id_manga_chatpers=" + WTF[2]);
            }
        }

        //Manga Traders - Povolení
        private void Manga_Tx06_TextChanged(object sender, EventArgs e)
        {
            if (Manga_Tx06.Text.Length > 0 && Manga_Tx06.Text != "0")
                Manga_Download.Enabled = true;
            else
                Manga_Download.Enabled = false;
        }

        //Odmazání nuly
        private void Manga_Tx04_Enter(object sender, EventArgs e)
        {
            if (Manga_Tx04.Text == "0")
                Manga_Tx04.Text = "";
        }

        //Odmazání nuly
        private void Manga_Tx05_Enter(object sender, EventArgs e)
        {
            if (Manga_Tx05.Text == "0")
                Manga_Tx05.Text = "";
        }

        //Odmazání nuly
        private void Manga_Tx06_Enter(object sender, EventArgs e)
        {
            if (Manga_Tx06.Text == "0")
                Manga_Tx06.Text = "";
        }

        //Odmazání nuly
        private void Manga_Tx24_Enter(object sender, EventArgs e)
        {
            if (Manga_Tx24.Text == "0")
                Manga_Tx24.Text = "";
        }

        //Odmazání nuly
        private void Manga_Tx23_Enter(object sender, EventArgs e)
        {
            if (Manga_Tx23.Text == "0")
                Manga_Tx23.Text = "";
        }

        //Odmazání nuly
        private void Manga_Tx07_Enter(object sender, EventArgs e)
        {
            if (Manga_Tx07.Text == "0")
                Manga_Tx07.Text = "";
        }

        //Manga Traders - Stažení
        private void Manga_Download_Click(object sender, EventArgs e)
        {
            Manga_Tx06.Text = Manga_Tx06.Text.Replace("http://www.mangatraders.com/manga/series/", "");
            Manga_Tx06.Text = Manga_Tx06.Text.Replace("/", "");

            WebClient WB = new WebClient();
            WB.Headers.Clear();
            WB.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729;)");
            WB.Headers.Add("Referer", "http://www.mangatraders.com/manga/series/" + Manga_Tx06.Text);

            try
            {
                byte[] WBData = WB.DownloadData("http://www.mangatraders.com/manga/series/" + Manga_Tx06.Text);
                string[] WBString = System.Text.Encoding.GetEncoding(WB.Encoding.CodePage).GetString(WBData).Split('\n');

                Manga_Tx01.Text = "";
                Manga_Tx07.Text = "0";
                Manga_Tx17.Text = "";
                Manga_Tx18.Text = "";

                foreach (string Radek in WBString)
                {
                    if (MangaUrlObr == "")
                    {
                        MangaUrlObr = Parse(Radek, "/seriesimages/", "\"", true);
                        if (MangaUrlObr != "")
                        {
                            MangaUrlObr = "http://www.mangatraders.com" + MangaUrlObr;
                            MangaUrlObr = MangaUrlObr.Replace("_thumb", "");
                        }
                        else
                            MangaUrlObr = "";
                    }

                    if (Manga_Tx01.Text.Length == 0)
                        Manga_Tx01.Text = Parse(Radek, "<title>Manga Traders - ", "</title", false);

                    if (Manga_Tx17.Text.Length == 0)
                        if (Radek.Contains("<strong>Author(s)</strong>"))
                            Manga_Tx17.Text = Parse(Radek, "showOnlyAuthor=1\">", "</a", false);

                    if (Manga_Tx18.Text.Length == 0)
                        if (Radek.Contains("<strong>Artist(s)</strong>"))
                            Manga_Tx18.Text = Parse(Radek, "showOnlyArtist=1\">", "</a", false);

                    if (Manga_Tx07.Text == "0")
                        if (Radek.Contains("<strong>Official Volumes</strong>"))
                            Manga_Tx07.Text = Parse(Radek, "<span id=\"volumes\">", "</span", false);

                    if (Radek.Contains("<strong>Genre(s)</strong>"))
                    {
                        string Zanry = CleanerHTML(Radek, "<", ">");
                        Zanry = Zanry.Replace("Genre(s)", "");
                        Zanry = Zanry.Replace("\t", "");
                        Zanry = Zanry.Replace(" : ", "");
                        Zanry = Zanry.Replace(", ", ",");

                        string[] T = Zanry.Split(',');

                        for (int j = 0; j < T.Length; j++)
                        {
                            for (int i = 0; i < Manga_Genres.Items.Count; i++)
                            {
                                if (Manga_Genres.Items[i].ToString().ToLower() == T[j].ToLower())
                                {
                                    Manga_Genres.SetItemCheckState(i, CheckState.Checked);
                                    break;
                                }
                            }
                        }
                    }

                    if (MangaUrlObr != "" && Manga_Tx17.Text.Length > 0 && Manga_Tx01.Text.Length > 0 && Manga_Tx07.Text != "0" && Manga_Tx18.Text.Length > 0)
                        break;
                }
            }
            catch
            {
            }
        }

        //Manga Updates - Povolení
        private void Manga_Tx05_TextChanged(object sender, EventArgs e)
        {
            if (Manga_Tx05.Text.Length > 0 && Manga_Tx05.Text != "0")
                Manga_Download_MU.Enabled = true;
            else
                Manga_Download_MU.Enabled = false;
        }

        //Manga Traders - Stažení
        private void Manga_Download_MU_Click(object sender, EventArgs e)
        {
            Manga_Tx05.Text = Manga_Tx05.Text.Replace("http://www.mangaupdates.com/series.html?id=", "");
            Manga_Tx05.Text = Manga_Tx05.Text.Replace("/", "");

            WebClient WB = new WebClient();
            WB.Headers.Clear();
            WB.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729;)");
            WB.Headers.Add("Referer", "http://www.mangaupdates.com/series.html?id=" + Manga_Tx05.Text);

            try
            {
                byte[] WBData = WB.DownloadData("http://www.mangaupdates.com/series.html?id=" + Manga_Tx05.Text);
                string WBString = System.Text.Encoding.GetEncoding(WB.Encoding.CodePage).GetString(WBData);

                Manga_Tx01.Text = "";
                Manga_Tx07.Text = "0";
                Manga_Tx17.Text = "";
                Manga_Tx18.Text = "";

                if (MangaUrlObr == "")
                {
                    MangaUrlObr = Parse(WBString, "<center><img", ">", true);
                    MangaUrlObr = Parse(MangaUrlObr, "src='", "'", false);

                    if (!MangaUrlObr.Contains("http://www.mangaupdates.com/image/"))
                        MangaUrlObr = "";
                }

                if (Manga_Tx01.Text.Length == 0)
                    Manga_Tx01.Text = Parse(WBString, "<span class=\"releasestitle tabletitle\">", "</span", false);

                if (Manga_Tx17.Text.Length == 0)
                {
                    Manga_Tx17.Text = Parse(WBString, "Author(s)", "<BR>", false);
                    Manga_Tx17.Text = Parse(Manga_Tx17.Text, "<u>", "</u>", false);
                }

                if (Manga_Tx18.Text.Length == 0)
                {
                    Manga_Tx18.Text = Parse(WBString, "Artist(s)", "<BR>", false);
                    Manga_Tx18.Text = Parse(Manga_Tx18.Text, "<u>", "</u>", false);
                }

                if (Manga_Tx04.Value == 0)
                {
                    string rok = Parse(WBString, "Year", "<br>", false);
                    Manga_Tx04.Text = Parse(rok, "\" >", "<", false);
                }

                if (Manga_Tx07.Text == "0")
                {
                    string vol = Parse(WBString, "Status in Country of Origin", "<br>", false);
                    Manga_Tx07.Text = Parse(vol, " >", " Volume", false);
                }

                string[] Zanry = Parse(WBString, "<b>Genre</b>", "Search for series of same genre(s)", false).Split('\'');

                foreach (string Zanr in Zanry)
                {
                    if (Zanr.Contains("<u>"))
                    {
                        string subZanr = Parse(Zanr, "<u>", "</u>", false);

                        for (int i = 0; i < Manga_Genres.Items.Count; i++)
                        {
                            if (Manga_Genres.Items[i].ToString().ToLower() == subZanr.ToLower())
                            {
                                Manga_Genres.SetItemCheckState(i, CheckState.Checked);
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        //MAL - Stažení
        private void Manga_Download_MAL_Click(object sender, EventArgs e)
        {
            Manga_Tx23.Text = Manga_Tx23.Text.Replace("http://myanimelist.net/manga/", "");
            Manga_Tx23.Text = Manga_Tx23.Text.Split('/')[0];

            WebClient WB = new WebClient();
            WB.Headers.Clear();
            WB.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729;)");
            WB.Headers.Add("Referer", "http://myanimelist.net/manga/" + Manga_Tx23.Text);

            try
            {
                byte[] WBData = WB.DownloadData("http://myanimelist.net/manga/" + Manga_Tx23.Text);
                string WBString = System.Text.Encoding.GetEncoding(WB.Encoding.CodePage).GetString(WBData);

                Manga_Tx01.Text = "";
                Manga_Tx07.Text = "0";
                Manga_Tx17.Text = "";
                Manga_Tx18.Text = "";

                if (MangaUrlObr == "")
                {
                    MangaUrlObr = Parse(WBString, "<img src=\"http://cdn.myanimelist.net/", "\"", true).Replace("<img src=\"", "");

                    if (!MangaUrlObr.Contains("http://cdn.myanimelist.net/"))
                        MangaUrlObr = "";
                }

                if (Manga_Tx01.Text.Length == 0)
                    Manga_Tx01.Text = Parse(WBString, "<title>", " - MyAnimeList.net", false);

                if (Manga_Tx17.Text.Length == 0)
                {
                    Manga_Tx17.Text = Parse(WBString, "Authors:</span>", "</div>", false);
                    Manga_Tx17.Text = Parse(Manga_Tx17.Text, "\">", "</a", false).Replace(",", "");
                    Manga_Tx18.Text = Manga_Tx17.Text;
                }

                if (Manga_Tx04.Value == 0)
                {
                    string[] T = Parse(WBString, "Published:</span>", "</div>", false).Split(' ');

                    foreach (string rok in T)
                    {
                        if (rok.Length == 4)
                        {
                            try
                            {
                                Manga_Tx04.Text = Convert.ToInt32(rok).ToString();
                                break;
                            }
                            catch
                            {
                            }
                        }
                    }
                }

                if (Manga_Tx07.Text == "0")
                    Manga_Tx07.Text = Parse(WBString, "Volumes:</span>", "</div>", false).Replace(" ", "").Replace("Unknown", "");

                string[] Zanry = Parse(WBString, "Genres:</span>", "</div>", false).Split(',');

                foreach (string Zanr in Zanry)
                {
                    string subZanr = Parse(Zanr, "\">", "</a>", false);

                    for (int i = 0; i < Manga_Genres.Items.Count; i++)
                    {
                        if (Manga_Genres.Items[i].ToString().ToLower() == subZanr.ToLower())
                        {
                            Manga_Genres.SetItemCheckState(i, CheckState.Checked);
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        //MugiMugi - Stažení
        private void Manga_Download_MugiMugi_Click(object sender, EventArgs e)
        {
            Manga_Tx24.Text = Manga_Tx24.Text.Replace("http://doujinshi.mugimugi.org/book/", "");
            Manga_Tx24.Text = Manga_Tx24.Text.Split('/')[0];

            WebClient WB = new WebClient();
            WB.Headers.Clear();
            WB.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729;)");
            WB.Headers.Add("Referer", "http://doujinshi.mugimugi.org/book/" + Manga_Tx24.Text);
            WB.Headers.Add("Cookie", "AGE=18");

            try
            {
                byte[] WBData = WB.DownloadData("http://doujinshi.mugimugi.org/book/" + Manga_Tx24.Text);
                string WBString = Encoding.UTF8.GetString(WBData);

                Manga_Tx01.Text = "";
                Manga_Tx07.Text = "0";
                Manga_Tx17.Text = "";
                Manga_Tx18.Text = "";

                if (MangaUrlObr == "")
                {
                    MangaUrlObr = Parse(WBString, "/'><img src='", "'></a><BR>", false);

                    if (!MangaUrlObr.Contains("http://img.mugimugi.org/"))
                        MangaUrlObr = "";
                }

                if (Manga_Tx01.Text.Length == 0)
                    Manga_Tx01.Text = Parse(WBString, "<B>Romanized title:</B></td><td>", "</td>", false);

                if (Manga_Tx02.Text.Length == 0)
                    Manga_Tx02.Text = Parse(WBString, "<B>Original title:</B></td><td>", "</td>", false);

                if (Manga_Tx03.Text.Length == 0)
                {
                    Manga_Tx03.Text = Parse(WBString, "Alt names:</div></td></tr>", "</tr>", false);
                    Manga_Tx03.Text = Parse(Manga_Tx03.Text.Replace("<tr>", ""), ">", "</td>", false);
                }

                if (Manga_Tx17.Text.Length == 0)
                {
                    Manga_Tx17.Text = Parse(WBString, "Authors:</div></td></tr>", "</td>", false);
                    Manga_Tx17.Text = Parse(Manga_Tx17.Text, "/\">", "</A", false);
                    Manga_Tx18.Text = Manga_Tx17.Text;
                }

                if (WBString.Contains("Adult:</B></td><td>Yes"))
                    Manga_CH01.Checked = true;

                if (Manga_Tx04.Value == 0)
                    Manga_Tx04.Text = Parse(WBString, "<B>Released:</B></td><td>", "</td>", false).Split('-')[0];

                if (Manga_Tx07.Text == "0")
                    Manga_Tx07.Text = "1";

                string[] Zanry = Parse(WBString, "Contents:</div></td></tr>", "<tr><td><BR></td><tr>", false).Split('>');

                foreach (string Zanr in Zanry)
                {
                    if (Zanr.Contains("</A"))
                    {
                        string[] subZanr = Zanr.Replace("</A", "").Replace(" (" + Parse(Zanr, " (", ")", false) + ")", "").Replace(", ", ",").Replace(" ,", ",").Split(',');

                        foreach (string subsubZanr in subZanr)
                        {
                            for (int i = 0; i < Manga_Genres.Items.Count; i++)
                            {
                                if (Manga_Genres.Items[i].ToString().ToLower() == subsubZanr.ToLower())
                                {
                                    Manga_Genres.SetItemCheckState(i, CheckState.Checked);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        //MAL - Povolení
        private void Manga_Tx23_TextChanged(object sender, EventArgs e)
        {
            if (Manga_Tx23.Text.Length > 0 && Manga_Tx23.Text != "0")
                Manga_Download_MAL.Enabled = true;
            else
                Manga_Download_MAL.Enabled = false;
        }

        //MugiMugi - Povolení
        private void Manga_Tx24_TextChanged(object sender, EventArgs e)
        {
            if (Manga_Tx24.Text.Length > 0 && Manga_Tx24.Text != "0")
                Manga_Download_MugiMugi.Enabled = true;
            else
                Manga_Download_MugiMugi.Enabled = false;
        }

        //Chapters Directory
        private void Manga_Obr_CHD_Click(object sender, EventArgs e)
        {
            string path = OpenDirectoryDialog(Manga_Tx19.Text);

            if (Directory.Exists(path))
            {
                Manga_ChaptersDT.Rows.Clear();

                Manga_Tx19.Text = path;
                DirectoryInfo Adresar = new DirectoryInfo(path);

                Manga_ChaptersDT.Rows.Add(true, "", "", false, "", "");

                foreach (FileInfo Soubor in Adresar.GetFiles("*", SearchOption.TopDirectoryOnly))
                {
                    Manga_ChaptersDT.Rows.Add(true, Manga_Chapters(Soubor.Name), Manga_List(Soubor), false, Soubor.Name.Replace("_", " ").Replace(Soubor.Extension, ""), Soubor.FullName);
                    Manga_Tx20.Text = Manga_Volumes(Soubor.FullName);
                }
            }
        }

        //Získání čísla chapteru
        private string Manga_Chapters(string Text)
        {
            Text = Text.Replace("_", "");
            Text = Text.Replace(" ", "");
            Text = Text.Replace("-", "");
            Text = Text.Replace("+", "");
            Text = Text.Replace(".", "");
            Text = Text.Replace("(", "");
            Text = Text.Replace(")", "");
            Text = Text.Replace("[", "");
            Text = Text.Replace("]", "");
            Text = Text.ToLower();

            MatchCollection Chapters;

            Chapters = Regex.Matches(Text, @"chapter([0-9]+)");

            if (Chapters.Count > 0)
                return Chapters[0].Value.Replace("chapter", "");

            Chapters = Regex.Matches(Text, @"chap([0-9]+)");

            if (Chapters.Count > 0)
                return Chapters[0].Value.Replace("chap", "");

            Chapters = Regex.Matches(Text, @"ch([0-9]+)");

            if (Chapters.Count > 0)
                return Chapters[0].Value.Replace("ch", "");

            Chapters = Regex.Matches(Text, @"c([0-9]+)");

            if (Chapters.Count > 0)
                return Chapters[0].Value.Replace("c", "");

            return "1";
        }

        //Získání čísla volume
        private string Manga_Volumes(string Text)
        {
            Text = Text.Replace("_", "");
            Text = Text.Replace(" ", "");
            Text = Text.Replace("-", "");
            Text = Text.Replace("+", "");
            Text = Text.Replace(".", "");
            Text = Text.Replace("(", "");
            Text = Text.Replace(")", "");
            Text = Text.Replace("[", "");
            Text = Text.Replace("]", "");
            Text = Text.ToLower();

            MatchCollection Chapters;

            Chapters = Regex.Matches(Text, @"volume([0-9]+)");

            if (Chapters.Count > 0)
                return Chapters[0].Value.Replace("volume", "");

            Chapters = Regex.Matches(Text, @"vol([0-9]+)");

            if (Chapters.Count > 0)
                return Chapters[0].Value.Replace("vol", "");

            Chapters = Regex.Matches(Text, @"v([0-9]+)");

            if (Chapters.Count > 0)
                return Chapters[0].Value.Replace("v", "");

            return "1";
        }

        //Počet souborů v archívu
        private int Manga_List(FileInfo Soubor)
        {
            List<string> List = new List<string>();

            switch (Soubor.Extension.ToLower())
            {
                case ".cbz":
                case ".zip":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Zip);
                    break;

                case ".7z":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.SevenZip);
                    break;

                case "arj":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Arj);
                    break;

                case "bZip2":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.BZip2);
                    break;

                case ".cab":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Cab);
                    break;

                case ".chm":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Chm);
                    break;

                case ".compound":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Compound);
                    break;

                case ".cpio":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Cpio);
                    break;

                case ".gzip":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.GZip);
                    break;

                case ".iso":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Iso);
                    break;

                case ".lzh":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Lzh);
                    break;

                case ".lzma":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Lzma);
                    break;

                case ".nsis":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Nsis);
                    break;

                case ".cbr":
                case ".rar":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Rar);
                    break;

                case ".rpm":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Split);
                    break;

                case ".split":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Zip);
                    break;

                case ".wim":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Wim);
                    break;

                case ".tar":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Tar);
                    break;

                case ".z":
                    List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Z);
                    break;
            }

            if (List.Count == 0)
            {
                switch (Soubor.Extension.ToLower())
                {
                    case ".cbr":
                    case ".rar":
                        List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Zip);
                        break;

                    case ".cbz":
                    case ".zip":
                        List = UnZip.List(Soubor.FullName, AniDB.Pack.KnownSevenZipFormat.Rar);
                        break;
                }

                return List.Count;
            }
            else
                return List.Count;
        }

        //Chapters Directory Add
        private void Manga_Insert_CHD_Click(object sender, EventArgs e)
        {
            DataTable DT = DatabaseSelect("SELECT Max(id_manga_chatpers) FROM manga_chapters");

            int ID = 1;

            try
            {
                ID = Convert.ToInt32(DT.Rows[0][0]) + 1;
            }
            catch
            {
            }

            for (int i = 1; i < Manga_ChaptersDT.Rows.Count; i++)
            {
                if ((bool)Manga_ChaptersDT[0, i].Value)
                {
                    FileInfo Soubor = new FileInfo(Manga_ChaptersDT[5, i].Value.ToString());

                    DatabaseAdd("INSERT INTO manga_chapters VALUES (" + ID + ", " + Manga_Tx12.Text + ", " + Manga_ChaptersDT[1, i].Value.ToString() + ", " + Manga_Tx20.Text + ", " + Soubor.Length + ", " + ((bool)Manga_ChaptersDT[3, i].Value ? "1" : "0") + ", " + Manga_ChaptersDT[2, i].Value.ToString() + ", '" + Manga_Tx21.Text.Replace("'", "''") + "', '" + Soubor.FullName.Replace("'", "''") + "', '" + Manga_ChaptersDT[4, i].Value.ToString().Replace("'", "''") + "')");
                    ID++;
                }
            }

            Manga_ChaptersDT.Rows.Clear();
            DatabaseSelectMangaTree(0);
            MangaTree_Find(Manga_Tx12.Text);

            Manga_Gr02.Visible = true;
            Manga_Gr02.Dock = DockStyle.Fill;
            Manga_Gr03.Visible = false;
            Manga_Gr03.Dock = DockStyle.None;
        }

        //Chapter vybrání všech
        private void Manga_ChaptersDT_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = Manga_ChaptersDT.HitTest(e.X, e.Y);

            if (Hit.RowIndex == 0 && Hit.ColumnIndex == 0)
            {
                Manga_ChaptersDT[0, 0].Value = !(bool)Manga_ChaptersDT[0, 0].Value;

                for (int i = 1; i < Manga_ChaptersDT.Rows.Count; i++)
                    Manga_ChaptersDT[0, i].Value = (bool)Manga_ChaptersDT[0, 0].Value;

            }
            else if (Hit.RowIndex == 0 && Hit.ColumnIndex == 3)
            {
                Manga_ChaptersDT[3, 0].Value = !(bool)Manga_ChaptersDT[3, 0].Value;

                for (int i = 1; i < Manga_ChaptersDT.Rows.Count; i++)
                    Manga_ChaptersDT[3, i].Value = (bool)Manga_ChaptersDT[3, 0].Value;
            }
        }

        //Chapters - smazání nepotřebných řádků
        private void Manga_ChaptersDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                List<int> Radky = new List<int>();
                int k = 0;

                for (int i = 0; i < Manga_ChaptersDT.SelectedRows.Count; i++)
                {
                    if (Manga_ChaptersDT.SelectedRows[i].Index > 0)
                        Radky.Add(Manga_ChaptersDT.SelectedRows[i].Index);
                }

                foreach (int Radek in Radky)
                {
                    Manga_ChaptersDT.Rows.RemoveAt(Radek + k);
                    k++;
                }
            }
        }

        //Smazat mangu
        private void Manga_Tree_Menu_Mn01_Click(object sender, EventArgs e)
        {
            Manga_Remove(Manga_Tree.SelectedNode.Name);
        }

        //Vybrání mangy
        private void MangaTree_Find(string ID)
        {
            if (ID != null)
            {
                if (ID != "")
                {
                    TreeNode[] TN = Manga_Tree.Nodes.Find(ID, true);

                    if (TN.Length > 0)
                    {
                        MainTab.SelectedIndex = 5;
                        MainTabManga.SelectedIndex = 0;
                        Manga_Tree.SelectedNode = TN[0];
                    }
                    else
                    {
                        MangaTree_CH01.CheckState = CheckState.Checked;

                        DatabaseSelectMangaTree(0);

                        TN = Manga_Tree.Nodes.Find(ID, true);

                        if (TN.Length > 0)
                        {
                            MainTab.SelectedIndex = 5;
                            MainTabManga.SelectedIndex = 0;
                            Manga_Tree.SelectedNode = TN[0];
                        }
                    }
                }
            }
        }

        //Smazání mangy
        private void Manga_Remove(string ID)
        {
            if (MessageBox.Show(Language.MessageBox_DeleteI, Language.MessageBox_Delete, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseAdd("DELETE FROM manga WHERE id_manga=" + ID);
                DatabaseAdd("DELETE FROM manga_chapters WHERE id_manga=" + ID);
                DatabaseAdd("DELETE FROM manga_genres WHERE id_manga=" + ID);
                DatabaseAdd("DELETE FROM manga_anime WHERE id_manga=" + ID);

                FileDelete(GlobalAdresar + @"\Accounts\!imgsm\" + ID + ".jpg");
                DatabaseSelectMangaTree(0);
                MainTabManga.SelectedIndex = 0;
            }
        }
        #endregion

        #region Manga Vyhledávání
        //Manga vyhledávání - Manga
        private void MangaSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hit = MangaSearch.HitTest(e.X, e.Y);

            if (Hit.RowIndex >= 0 && Hit.ColumnIndex == 1)
                MangaTree_Find(MangaSearch[0, Hit.RowIndex].Value.ToString());
        }

        //Manga vyhledávání - Nové
        private void MangaSearch_New_Click(object sender, EventArgs e)
        {
            MangaSearch.Rows.Clear();
        }

        //Manga vyhledávání 
        private void MangaSearch_Search_Click(object sender, EventArgs e)
        {
            string SQL = "";

            if (MangaSearch_NM01.Value > 0)
                SQL = "SELECT * FROM manga WHERE manga_MU=" + MangaSearch_NM01.Value.ToString();
            else if (MangaSearch_NM02.Value > 0)
                SQL = "SELECT * FROM manga WHERE manga_MT=" + MangaSearch_NM02.Value.ToString();

            if (SQL == "")
            {
                if (MangaSearch_TX01.Text.Length > 0)
                    SQL += "(manga_nazevjap LIKE '%" + MangaSearch_TX01.Text + "%' OR manga_nazevkaj LIKE '%" + MangaSearch_TX01.Text + "%' OR manga_nazeveng LIKE '%" + MangaSearch_TX01.Text + "%') AND ";

                if (MangaSearch_TX02.Text.Length > 0)
                    SQL += "(manga_nazevjap LIKE '%" + MangaSearch_TX02.Text + "%' OR manga_nazevkaj LIKE '%" + MangaSearch_TX02.Text + "%' OR manga_nazeveng LIKE '%" + MangaSearch_TX02.Text + "%') AND ";

                if (MangaSearch_TX03.Text.Length > 0)
                    SQL += "(manga_nazevjap LIKE '%" + MangaSearch_TX03.Text + "%' OR manga_nazevkaj LIKE '%" + MangaSearch_TX03.Text + "%' OR manga_nazeveng LIKE '%" + MangaSearch_TX03.Text + "%') AND ";

                if (MangaSearch_TX04.Text.Length > 0)
                    SQL += "manga_author LIKE '%" + MangaSearch_TX04.Text + "%' AND ";

                if (MangaSearch_TX05.Text.Length > 0)
                    SQL += "manga_artist LIKE '%" + MangaSearch_TX05.Text + "%' AND ";

                if (MangaSearch_NM03.Value > 0)
                    SQL += "manga_rok=" + MangaSearch_NM03.Value.ToString() + " AND ";

                if (MangaSearch_NM04.Value > 0)
                    SQL += "manga_volume=" + MangaSearch_NM04.Value.ToString() + " AND ";

                for (int i = 0; i < MangaSearch_Genres.Items.Count; i++)
                {
                    if (MangaSearch_Genres.GetItemChecked(i))
                        SQL += "genres.genres_genre='" + MangaSearch_Genres.Items[i].ToString() + "' AND ";
                }

                if (SQL.Length > 4)
                    SQL = SQL.Substring(0, SQL.Length - 4);
            }

            DataTable dataTable = null;

            if (SQL.Length > 6)
            {
                if (SQL.Substring(0, 6) == "SELECT")
                    dataTable = DatabaseSelect(SQL);
                else
                    dataTable = DatabaseSelect("SELECT * FROM manga WHERE " + SQL + " ORDER BY manga_nazevjap");

                foreach (DataRow row in dataTable.Rows)
                {
                    MangaSearch.Rows.Add(
                    row["id_manga"].ToString(),
                    row["manga_nazevjap"].ToString(),
                    row["manga_nazevkaj"].ToString(),
                    row["manga_rok"].ToString()
                    );
                }

                if (MangaSearch.SortedColumn != null)
                    MangaSearch.Sort(MangaSearch.SortedColumn, MangaSearch.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }

        }
        #endregion

        #region Grafy
        //Anime
        private void Zgc_GraphB01_Click(object sender, EventArgs e)
        {
            GraphPane Gp = Zgc_Graph.GraphPane;

            Gp.CurveList.Clear();
            Gp.GraphObjList.Clear();
            Gp.Chart.Fill = new Fill(Options_Color08.BackColor, Color.FromArgb(0, 118, 255), 45F);

            Gp.Title.IsVisible = false;
            Gp.XAxis.IsVisible = false;
            Gp.YAxis.IsVisible = false;
            Gp.Y2Axis.IsVisible = false;
            Gp.X2Axis.IsVisible = false;

            Gp.Legend.Border.IsVisible = false;
            Gp.Legend.FontSpec.Size = 12;

            DataTable dataTable = DatabaseSelect("SELECT * FROM mylist_local");
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                PieItem PI;

                PI = Gp.AddPieSlice(Convert.ToDouble(row["mylist_local_tv"].ToString()), Color.Silver, 0.1, Language.Options_VL07.Replace(":", ""));
                PI.LabelDetail.IsVisible = false;
                PI = Gp.AddPieSlice(Convert.ToDouble(row["mylist_local_tvs"].ToString()), Color.Green, 0.1, Language.Options_VL08.Replace(":", ""));
                PI.LabelDetail.IsVisible = false;
                PI = Gp.AddPieSlice(Convert.ToDouble(row["mylist_local_movies"].ToString()), Color.Orange, 0.1, Language.Options_VL09.Replace(":", ""));
                PI.LabelDetail.IsVisible = false;
                PI = Gp.AddPieSlice(Convert.ToDouble(row["mylist_local_ova"].ToString()), Color.Yellow, 0.1, Language.Options_VL10.Replace(":", ""));
                PI.LabelDetail.IsVisible = false;
                PI = Gp.AddPieSlice(Convert.ToDouble(row["mylist_local_web"].ToString()), Color.Navy, 0.1, Language.Options_VL11.Replace(":", ""));
                PI.LabelDetail.IsVisible = false;
                PI = Gp.AddPieSlice(Convert.ToDouble(row["mylist_local_others"].ToString()), Color.White, 0.1, Language.Options_VL66.Replace(":", ""));
                PI.LabelDetail.IsVisible = false;
                PI = Gp.AddPieSlice(Convert.ToDouble(row["mylist_local_unknown"].ToString()), Color.Violet, 0.1, Language.Options_VL12.Replace(":", ""));
                PI.LabelDetail.IsVisible = false;
                PI = Gp.AddPieSlice(Convert.ToDouble(row["mylist_local_music"].ToString()), Color.Purple, 0.1, Language.Options_VL13.Replace(":", ""));
                PI.LabelDetail.IsVisible = false;
            }

            Zgc_Graph.AxisChange();
            Zgc_Graph.Invalidate();
        }

        //Storage
        private void Zgc_GraphB02_Click(object sender, EventArgs e)
        {
            GraphPane Gp = Zgc_Graph.GraphPane;

            Gp.CurveList.Clear();
            Gp.GraphObjList.Clear();
            Gp.Chart.Fill = new Fill(Options_Color08.BackColor, Color.FromArgb(0, 118, 255), 45F);

            Gp.Title.IsVisible = false;
            Gp.XAxis.IsVisible = false;
            Gp.YAxis.IsVisible = false;
            Gp.Y2Axis.IsVisible = false;
            Gp.X2Axis.IsVisible = false;

            Gp.Legend.Border.IsVisible = false;
            Gp.Legend.FontSpec.Size = 12;

            DataTable dataTable = DatabaseSelect("SELECT * FROM mylist_storages");

            foreach (DataRow rowX in dataTable.Rows)
            {
                Random Rnd = new Random();
                int R = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                int G = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                int B = Rnd.Next(0, 255);
                PieItem PI;
                PI = Gp.AddPieSlice(Convert.ToDouble(rowX["mylist_storages_count"].ToString()), Color.FromArgb(R, G, B), 0.1, rowX["mylist_storages_storage"].ToString() + " (" + rowX["mylist_storages_percent"].ToString() + ")");
                PI.LabelDetail.IsVisible = false;
            }

            Zgc_Graph.AxisChange();
            Zgc_Graph.Invalidate();
        }

        //Source
        private void Zgc_GraphB03_Click(object sender, EventArgs e)
        {
            GraphPane Gp = Zgc_Graph.GraphPane;

            Gp.CurveList.Clear();
            Gp.GraphObjList.Clear();
            Gp.Chart.Fill = new Fill(Options_Color08.BackColor, Color.FromArgb(0, 118, 255), 45F);

            Gp.Title.IsVisible = false;
            Gp.XAxis.IsVisible = false;
            Gp.YAxis.IsVisible = false;
            Gp.Y2Axis.IsVisible = false;
            Gp.X2Axis.IsVisible = false;

            Gp.Legend.Border.IsVisible = false;
            Gp.Legend.FontSpec.Size = 12;

            DataTable dataTable = DatabaseSelect("SELECT * FROM mylist_sources");

            foreach (DataRow rowX in dataTable.Rows)
            {
                Random Rnd = new Random();
                int R = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                int G = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                int B = Rnd.Next(0, 255);
                PieItem PI;
                PI = Gp.AddPieSlice(Convert.ToDouble(rowX["mylist_sources_count"].ToString()), Color.FromArgb(R, G, B), 0.1, rowX["mylist_sources_source"].ToString() + " (" + rowX["mylist_sources_percent"].ToString() + ")");
                PI.LabelDetail.IsVisible = false;
            }

            Zgc_Graph.AxisChange();
            Zgc_Graph.Invalidate();
        }

        //Timeline
        private void Zgc_GraphB04_Click(object sender, EventArgs e)
        {
            GraphPane Gp = Zgc_Graph.GraphPane;

            Gp.CurveList.Clear();
            Gp.GraphObjList.Clear();
            Gp.Chart.Fill = new Fill(Options_Color08.BackColor, Color.FromArgb(0, 118, 255), 45F);

            Gp.Title.IsVisible = false;
            Gp.XAxis.IsVisible = false;
            Gp.YAxis.IsVisible = false;
            Gp.Y2Axis.IsVisible = false;
            Gp.X2Axis.IsVisible = false;

            Gp.Legend.Border.IsVisible = false;
            Gp.Legend.FontSpec.Size = 12;

            DataTable DT = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_seen FROM anime WHERE anime_watched=1 ORDER BY anime_seen");

            Random Rnd = new Random();
            int R = 0;
            int G = 0;
            int B = 0;
            DateTime Vd = DateTime.Today.AddMonths(10);
            int Vc = 0;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                try
                {
                    DateTime Cas = DateTime.Parse(DT.Rows[i]["anime_seen"].ToString());

                    if (Cas.Month != Vd.Month && Vc > 0)
                    {
                        Rnd = new Random();
                        R = Rnd.Next(0, 255);
                        Thread.Sleep(100);
                        Rnd = new Random();
                        G = Rnd.Next(0, 255);
                        Thread.Sleep(100);
                        Rnd = new Random();
                        B = Rnd.Next(0, 255);
                        Gp.AddBar(Vd.Month + "/" + Vd.Year + " (" + Vc + ")", null, new double[] { Vc }, Color.FromArgb(R, G, B));
                        Vc = 0;
                    }
                    else
                        Vc++;

                    Vd = Cas;
                }
                catch
                {
                }
            }

            if (Vc > 0)
            {
                Rnd = new Random();
                R = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                G = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                B = Rnd.Next(0, 255);
                Gp.AddBar(Vd.Month + "/" + Vd.Year + " (" + Vc + ")", null, new double[] { Vc }, Color.FromArgb(R, G, B));
                Vc = 0;
            }

            Zgc_Graph.AxisChange();
            Zgc_Graph.Invalidate();
        }

        //Tags
        private void Zgc_GraphB05_Click(object sender, EventArgs e)
        {
            GraphPane Gp = Zgc_Graph.GraphPane;

            Gp.CurveList.Clear();
            Gp.GraphObjList.Clear();
            Gp.Chart.Fill = new Fill(Options_Color08.BackColor, Color.FromArgb(0, 118, 255), 45F);

            Gp.Title.IsVisible = false;
            Gp.XAxis.IsVisible = false;
            Gp.YAxis.IsVisible = false;
            Gp.Y2Axis.IsVisible = false;
            Gp.X2Axis.IsVisible = false;

            Gp.Legend.Border.IsVisible = false;
            Gp.Legend.FontSpec.Size = 12;

            DataTable DT = DatabaseSelect("SELECT anime.id_anime, tags_name, anime_nazevjap FROM (anime INNER JOIN tags_relation ON tags_relation.id_anime=anime.id_anime) INNER JOIN tags ON tags.id_tags=tags_relation.id_tags ORDER BY tags_name, anime_nazevjap");

            Random Rnd = new Random();
            int R = 0;
            int G = 0;
            int B = 0;
            string Vm = "";
            int Vc = 0;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                try
                {
                    if (DT.Rows[i]["tags_name"].ToString() != Vm && Vm.Length > 0 && Vc > 0)
                    {
                        Rnd = new Random();
                        R = Rnd.Next(0, 255);
                        Thread.Sleep(100);
                        Rnd = new Random();
                        G = Rnd.Next(0, 255);
                        Thread.Sleep(100);
                        Rnd = new Random();
                        B = Rnd.Next(0, 255);
                        Gp.AddBar(Vm + " (" + Vc + ")", null, new double[] { Vc }, Color.FromArgb(R, G, B));
                        Vc = 0;
                    }
                    else
                    {
                        Vc++;
                    }

                    Vm = DT.Rows[i]["tags_name"].ToString();
                }
                catch
                {
                }
            }

            if (Vc > 0)
            {
                Rnd = new Random();
                R = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                G = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                B = Rnd.Next(0, 255);
                Gp.AddBar(Vm + " (" + Vc + ")", null, new double[] { Vc }, Color.FromArgb(R, G, B));
                Vc = 0;
            }

            Zgc_Graph.AxisChange();
            Zgc_Graph.Invalidate();
        }

        //Ratings
        private void Zgc_GraphB06_Click(object sender, EventArgs e)
        {
            GraphPane Gp = Zgc_Graph.GraphPane;

            Gp.CurveList.Clear();
            Gp.GraphObjList.Clear();
            Gp.Chart.Fill = new Fill(Options_Color08.BackColor, Color.FromArgb(0, 118, 255), 45F);

            Gp.Title.IsVisible = false;
            Gp.XAxis.IsVisible = false;
            Gp.YAxis.IsVisible = false;
            Gp.Y2Axis.IsVisible = false;
            Gp.X2Axis.IsVisible = false;

            Gp.Legend.Border.IsVisible = false;

            DataTable DT = DatabaseSelect("SELECT id_anime, anime_nazevjap, anime_rating FROM anime WHERE anime_rating>0 ORDER BY anime_rating, anime_nazevjap");

            Random Rnd = new Random();
            int R = 0;
            int G = 0;
            int B = 0;
            string Vm = "";
            int Vc = 0;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                try
                {
                    if (DT.Rows[i]["anime_rating"].ToString() != Vm && Vm.Length > 0 && Vc > 0)
                    {

                        R = Rnd.Next(0, 255);
                        Thread.Sleep(100);
                        Rnd = new Random();
                        G = Rnd.Next(0, 255);
                        Thread.Sleep(100);
                        Rnd = new Random();
                        B = Rnd.Next(0, 255);
                        Gp.AddBar(Vm + "/10 (" + Vc + ")", null, new double[] { Vc }, Color.FromArgb(R, G, B));
                        Vc = 0;
                    }
                    else
                    {
                        Vc++;
                    }

                    Vm = DT.Rows[i]["anime_rating"].ToString();
                }
                catch
                {
                }
            }

            if (Vc > 0)
            {
                Rnd = new Random();
                R = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                G = Rnd.Next(0, 255);
                Thread.Sleep(100);
                Rnd = new Random();
                B = Rnd.Next(0, 255);
                Gp.AddBar(Vm + "/10 (" + Vc + ")", null, new double[] { Vc }, Color.FromArgb(R, G, B));
            }

            Zgc_Graph.AxisChange();
            Zgc_Graph.Invalidate();
        }
        #endregion

        #region Webserver
        //Spuštění webserveru
        private void Options_CH13BT_Click(object sender, EventArgs e)
        {
            WebServerStart();

            string[] OP = Options_Network.SelectedItem.ToString().Split(new string[] { " * " }, StringSplitOptions.None);

            if (OP.Length != 3)
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface adapter in adapters)
                {
                    if (adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback && adapter.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                    {
                        foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                OP[0]= ip.Address.ToString();
                            }
                        }
                    }
                }
            } else
                OP[0] = OP[2];

            Process prc = new Process();
            prc.StartInfo.FileName = "http://" + OP[0] + ":" + WebServer_Port.Value + "/";
            prc.Start();
        }

        //Spuštění webserveru
        private void WebServerStart()
        {
            try { WebServer.Stop(); }
            catch { }

            WebServer = HttpListener.Create(IPAddress.Any, (int)WebServer_Port.Value);            

            WebServer.RequestReceived += WebServer_RequestReceived;
            WebServer.Start(5);
        }

        //Obsluha webserveru
        private void WebServer_RequestReceived(object sender, HttpServer.RequestEventArgs e)
        {
            IHttpClientContext context = (IHttpClientContext)sender;
            IHttpRequest request = e.Request;
            IHttpResponse response = request.CreateResponse(context);
            StreamWriter writer = new StreamWriter(response.Body);

            string sText = null;
            string uriReguire = request.UriPath.Replace("|", ".").Replace("*", ":");

            if (File.Exists(GlobalAdresar + @"Web\" + request.UriPath.Replace("|", ".").Replace("*", ":")))
                uriReguire = GlobalAdresar + @"Web\" + request.UriPath.Replace("|", ".").Replace("*", ":");

            if (request.UriPath.Length > 1)
            {
                if (File.Exists(request.UriPath.Substring(1, request.UriPath.Length - 1).Replace("|", ".").Replace("*", ":")))
                    uriReguire = request.UriPath.Substring(1, request.UriPath.Length - 1).Replace("|", ".").Replace("*", ":");
            }

            if (request.Method == "POST")
            {
                HttpServer.FormDecoders.FormDecoderProvider fdp = new HttpServer.FormDecoders.FormDecoderProvider();
                fdp.Add(new HttpServer.FormDecoders.MultipartDecoder());
                request.DecodeBody(fdp);

                if (request.Form.Contains("sText"))
                    sText = request.Form["sText"].Value.ToString().Replace("\r", "").Replace("\n", "");

                if (request.Form.Contains("sAll"))
                    uriReguire = "/";

                if (request.Form.Contains("sRemote"))
                    response.Redirect("/remote-control");
            }

            if (request.Method == "GET" || sText != null)
            {
                if (File.Exists(uriReguire))
                {
                    if (Options_ExtensionList.Items.Contains(new FileInfo(uriReguire).Extension.ToLower()))
                    {
                        Process prc = new Process();
                        prc.StartInfo.FileName = uriReguire;
                        prc.Start();
                    }

                    if (uriReguire.Length > 4)
                    {
                        switch (new FileInfo(uriReguire).Extension)
                        {
                            case ".js":
                                response.AddHeader("Content-Type", "text/javascript");
                                break;

                            case ".css":
                                response.AddHeader("Content-Type", "text/css");
                                break;

                            case ".jpe":
                            case ".jpeg":
                            case ".jpg":
                                response.AddHeader("Content-Type", "image/jpeg");
                                break;

                            case ".png":
                                response.AddHeader("Content-Type", "image/png");
                                break;

                            case ".gif":
                                response.AddHeader("Content-Type", "image/gif");
                                break;

                            case ".ico":
                                response.AddHeader("Content-Type", "image/ico");
                                break;

                            case ".bmp":
                                response.AddHeader("Content-Type", "image/bmp");
                                break;

                            case ".tiff":
                                response.AddHeader("Content-Type", "image/tiff");
                                break;
                        }
                    }

                    FileStream reader = File.OpenRead(uriReguire);

                    byte[] B = new byte[reader.Length];
                    reader.Read(B, 0, Convert.ToInt32(reader.Length));

                    response.Body.Write(B, 0, Convert.ToInt32(reader.Length));

                    reader.Close();
                }
                else
                {
                    response.AddHeader("Content-Type", "text/html");

                    StreamReader Cti = new StreamReader(GlobalAdresar + @"Web\index.html");
                    string TxO = Cti.ReadToEnd();
                    string TxP = "";
                    Cti.Close();
                    Cti.Dispose();

                    DataTable DT;

                    if (uriReguire.Contains("index-page-") || uriReguire == "/")
                    {
                        string lists = "";

                        int str = 1;
                        int nastr = 27;
                        int c = 1;

                        try { str = Convert.ToInt32(Parse(uriReguire, "/index-page-", ".html", false)); }
                        catch { }

                        DT = DatabaseSelect("SELECT count(id_anime) as pocet FROM anime");

                        try { c = Convert.ToInt32(DT.Rows[0]["pocet"].ToString()) / nastr + 1; }
                        catch { }

                        DT = DatabaseSelect("SELECT TOP " + nastr + " * FROM (SELECT TOP " + nastr + " * FROM (SELECT TOP " + (str * nastr) + " * FROM anime ORDER BY CStr([anime]![anime_nazevjap]) ASC) ORDER BY CStr([anime]![anime_nazevjap]) DESC) ORDER by CStr([anime]![anime_nazevjap]) ASC");

                        if (c > 1) { 
                        for (int i = 1; i <= c; i++)
                            lists += "<a href=\"index-page-" + i.ToString() + ".html\">" + i + "</a> ";
                        }

                        lists = "<div class=\"lists\">" + lists + "</div>";

                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            TxP += "<div class=\"anime\">";
                            TxP += "<a href=\"anime-" + DT.Rows[i]["id_anime"].ToString() + ".html\">";
                            if (File.Exists(GlobalAdresar + @"Accounts\!imgs\" + DT.Rows[i]["anime_obr"].ToString()))
                            {
                                string x = DT.Rows[i]["anime_nazevjap"].ToString().Substring(0, DT.Rows[i]["anime_nazevjap"].ToString().Length > 25 ? 25 : DT.Rows[i]["anime_nazevjap"].ToString().Length);

                                TxP += "<img src=\"||\\Accounts\\!imgs\\" + DT.Rows[i]["anime_obr"].ToString() + "\" alt=\"\" />";
                                TxP += "<br />" + x + "...</a>\r\n";
                            }
                            else
                                TxP += "<br />" + DT.Rows[i]["anime_nazevjap"].ToString() + "</a>\r\n";

                            TxP += "</div>";
                        }

                        string pages = "<div class=\"pages\">";
                        if (str > 1)
                            pages += "<a href=\"index-page-" + (str - 1).ToString() + ".html\">««««««</a>";
                        if (str < c)
                            pages += " <a href=\"index-page-" + (str + 1).ToString() + ".html\">»»»»»»</a>";
                        pages += "</div>";

                        TxP = "<hr class=\"cistic\" />" + TxP + "<hr class=\"cistic\" />" + pages + "<hr class=\"cistic\" />" + lists;
                    }
                    else if (uriReguire.Contains("search"))
                    {
                        string lists = "";

                        int str = 1;
                        int nastr = 27;
                        int c = 1;

                        try { str = Convert.ToInt32(Parse(uriReguire, "/index-page-", "-", false)); }
                        catch { }

                        if (sText == null)
                            sText = Parse(uriReguire, "/index-page-" + str + "-", ".html", false);

                        DT = DatabaseSelect("SELECT count(id_anime) as pocet FROM anime WHERE anime_nazevjap like '%" + sText + "%' OR anime_nazevkaj like '%" + sText + "%' OR anime_nazeveng like '%" + sText + "%'");

                        try { c = Convert.ToInt32(DT.Rows[0]["pocet"].ToString()) / nastr + 1; }
                        catch { }

                        DT = DatabaseSelect("SELECT TOP " + nastr + " * FROM (SELECT TOP " + nastr + " * FROM (SELECT TOP " + (str * nastr) + " * FROM anime WHERE anime_nazevjap like '%" + sText + "%' OR anime_nazevkaj like '%" + sText + "%' OR anime_nazeveng like '%" + sText + "%' ORDER BY CStr([anime]![anime_nazevjap]) ASC) ORDER BY CStr([anime]![anime_nazevjap]) DESC) ORDER by CStr([anime]![anime_nazevjap]) ASC");

                        if (c > 1) { 
                        for (int i = 1; i <= c; i++)
                            lists += "<a href=\"search-page-" + i.ToString() + "-" + sText + ".html\">" + i + "</a> ";
                        }

                        lists = "<div class=\"lists\">" + lists + "</div>";

                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            TxP += "<div class=\"anime\">";
                            TxP += "<a href=\"anime-" + DT.Rows[i]["id_anime"].ToString() + "-" + sText + ".html\">";
                            if (File.Exists(GlobalAdresar + @"Accounts\!imgs\" + DT.Rows[i]["anime_obr"].ToString()))
                            {
                                string x = DT.Rows[i]["anime_nazevjap"].ToString().Substring(0, DT.Rows[i]["anime_nazevjap"].ToString().Length > 25 ? 25 : DT.Rows[i]["anime_nazevjap"].ToString().Length);

                                TxP += "<img src=\"||\\Accounts\\!imgs\\" + DT.Rows[i]["anime_obr"].ToString() + "\" alt=\"\" />";
                                TxP += "<br />" + x + "...</a>\r\n";
                            }
                            else
                                TxP += "<br />" + DT.Rows[i]["anime_nazevjap"].ToString() + "</a>\r\n";

                            TxP += "</div>";
                        }

                        string pages = "<div class=\"pages\">";
                        if (str > 1)
                            pages += "<a href=\"search-page-" + (str - 1).ToString() + "-" + sText + ".html\">««««««</a>";
                        if (str < c)
                            pages += " <a href=\"search-page-" + (str + 1).ToString() + "-" + sText + ".html\">»»»»»»</a>";
                        pages += "</div>";

                        TxP = "<hr class=\"cistic\" />" + TxP + "<hr class=\"cistic\" />" + pages + "<hr class=\"cistic\" />" + lists;
                    }
                    else if (uriReguire.Contains("anime-"))
                    {
                        int anime = 0;

                        try { anime = Convert.ToInt32(Parse(uriReguire, "/anime-", ".html", false)); }
                        catch { }

                        DT = DatabaseSelect("SELECT * FROM anime WHERE id_anime=" + anime);

                        if (DT.Rows.Count > 0)
                        {
                            if (File.Exists(GlobalAdresar + @"Accounts\!imgs\" + DT.Rows[0]["anime_obr"].ToString()))
                                TxP += "<img src=\"||\\Accounts\\!imgs\\" + DT.Rows[0]["anime_obr"].ToString() + "\" alt=\"\" />";

                            TxP += "<br />" + DT.Rows[0]["anime_nazevjap"].ToString() + "\r\n";
                            TxP += "<br />" + DT.Rows[0]["anime_nazevkaj"].ToString() + "\r\n";
                            TxP += "<br />" + DT.Rows[0]["anime_nazeveng"].ToString() + "\r\n";
                            TxP += "<br />" + DT.Rows[0]["anime_rok"].ToString() + "\r\n";
                            TxP += "<br />" + DT.Rows[0]["anime_typ"].ToString() + "\r\n";
                            TxP += "<br />" + DT.Rows[0]["anime_epn"].ToString() + " + " + DT.Rows[0]["anime_epn_spec"].ToString() + "S\r\n";

                            DT = DatabaseSelect("SELECT * FROM (files INNER JOIN groups ON groups.id_groups=files.id_groups) INNER JOIN episodes ON episodes.id_episodes=files.id_episodes WHERE files.id_anime=" + anime + " ORDER BY episodes_spec, episodes_epn");

                            string epn = "";

                            TxP += "\r\n<br /><br /><table id=\"episodes\">\r\n";
                            for (int i = 0; i < DT.Rows.Count; i++)
                            {
                                string Spec = "";

                                if (DT.Rows[i]["episodes_spec"].ToString() != "0")
                                    Spec = DT.Rows[i]["episodes_spec"].ToString();

                                if (Spec + DT.Rows[i]["episodes_epn"].ToString() != epn)
                                {
                                    TxP = TxP.Replace("%" + epn + "%", "tr-last");

                                    epn = Spec + DT.Rows[i]["episodes_epn"].ToString();

                                    TxP += "<tr><td colspan=\"3\">&nbsp;</td></tr><tr>";
                                    TxP += "<td>" + Spec + DT.Rows[i]["episodes_epn"].ToString() + "</td>";
                                    TxP += "<td style=\"text-align: left; font-weight: bolder;\">" + DT.Rows[i]["episodes_nazeveng"].ToString() + "</td>";
                                    TxP += "<td>" + DT.Rows[i]["episodes_lenght"].ToString() + "m" + "</td>";
                                    TxP += "</tr>\r\n";                                    
                                }

                                string ex = "";

                                if (!File.Exists(DT.Rows[i]["files_localfile"].ToString()))
                                    ex = "!!! ";

                                TxP += "<tr class=\"%" + epn + "%\">";
                                TxP += "<td>»</td><td colspan=\"2\">" + ex + "<a href=\"" + DT.Rows[i]["files_localfile"].ToString().Replace(":", "*") + "\">[" + DT.Rows[i]["groups_namezk"].ToString() + "] (" + DT.Rows[i]["files_resultion"].ToString() + " " + DT.Rows[i]["files_typ"].ToString() + " " + DT.Rows[i]["files_video"].ToString() + " " + DT.Rows[i]["files_audio"].ToString() + ")</a></td>";
                                TxP += "</tr>\r\n";

                            }

                            TxP = TxP.Replace("%" + epn + "%", "tr-last");
                            TxP += "</table>";
                        }
                        else
                        {
                            TxP += "<h1>Anime not exists :(</h1>";
                        }
                    }
                    else if (uriReguire.Contains("remote-control"))
                    {
                        Cti = new StreamReader(GlobalAdresar + @"Web\remote.html");
                        TxO = Cti.ReadToEnd();
                        Cti.Close();
                        Cti.Dispose();

                        string[] OP = Options_Network.SelectedItem.ToString().Split(new string[] { " * " }, StringSplitOptions.None);

                        if (OP.Length != 3)
                        {
                            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

                            foreach (NetworkInterface adapter in adapters)
                            {
                                if (adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback && adapter.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                                {
                                    foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                                    {
                                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                        {
                                            OP[0] = ip.Address.ToString();
                                        }
                                    }
                                }
                            }
                        }
                        else
                            OP[0] = OP[2];

                        TxP = "";
                        TxO = TxO.Replace("%MPC-HC%", " http://" +  OP[0] + ":" + WebServer_MPCHC.Value + "/command.html");                        
                    }
                    else
                    {
                        TxP += "<h1>Page not exists :(</h1><br /><br />" + uriReguire;
                    }

                    TxO = TxO.Replace("%animes%", TxP);
                    byte[] B = Encoding.UTF8.GetBytes(TxO);
                    response.Body.Write(B, 0, B.Length);
                }
            }

            writer.Flush();
            response.Send();
        }
        #endregion
    }
}