using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Reflection;
using System.IO;

namespace AniSubW
{
    public partial class Main : Form
    {
        private string GlobalAdresar = null;
        private string GlobalAdresarAccount = null;
        private bool Loading = false;
        private int SQLPage = 1;
        private int SQLCount = 50;
        private int TabStop = 0;
        private OleDbConnection AniDBDatabase = null;
        private List<string> AnimeID = new List<string>();
        private List<string> EpisodesID = new List<string>();
        private Color DesignColor = Color.FromArgb(75, 136, 173);

        public Main(string globalAdresarAccount, string globalAdresar)
        {
            InitializeComponent();

            GlobalAdresarAccount = globalAdresarAccount;
            GlobalAdresar = globalAdresar;
        }

        //Při načtení
        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            LoadBackground();
            LoadAccount();
            LoadAnime();

            AnimeS_BT01.Focus();
            AnimeS_BT01.Select();

            AnimeS.MouseWheel += new MouseEventHandler(AnimeS_MouseWheel);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.Enter:
                    if (TabStop == 3)
                        EpisodesPlay();
                    break;

                case Keys.Right:
                case Keys.Left:
                    ControlSelectIn(e.KeyData);
                    break;

                case Keys.PageDown:
                case Keys.Down:
                    TabStop++;
                    ControlSelect();
                    break;

                case Keys.PageUp:
                case Keys.Up:
                    TabStop--;
                    ControlSelect();
                    break;
            }
        }

        //Výběr dalšího controlu
        private void ControlSelect()
        {
            if (TabStop > 3)
                TabStop = 0;

            if (TabStop < 0)
                TabStop = 3;

            switch (TabStop)
            {
                case 0:
                    AnimeS_BT01.Focus();
                    AnimeS_BT01.Select();
                    break;

                case 1:
                    AnimeS.Focus();
                    AnimeS.Select();
                    
                    break;

                case 2:
                    AnimeS_BT02.Focus();
                    AnimeS_BT02.Select();
                    break;

                case 3:
                    Episodes.Focus();
                    Episodes.Select();
                    break;
            }
        }

        //Výběr řádku
        private void ControlSelectIn(Keys x)
        {
            int i = 0;          

            if (TabStop == 1)
            {
                if (x == Keys.Left)
                {
                    if (AnimeS.SelectedColumns.Count > 0)
                        i = AnimeS.SelectedColumns[0].Index - 1;
                }
                else
                {
                    if (AnimeS.SelectedColumns.Count > 0)
                        i = AnimeS.SelectedColumns[0].Index + 1;
                }

                if (i < 0)
                    i = AnimeS.Columns.Count - 1;

                if (i > AnimeS.Columns.Count)
                    i = 0;

                AnimeS.Columns[i].Selected = true;
            }

            if (TabStop == 3)
            {
                if (x == Keys.Left)
                    i = Episodes.SelectedIndex - 1;
                else
                    i = Episodes.SelectedIndex + 1;

                if (i < 0)
                    i = Episodes.Items.Count - 1;

                if (i > Episodes.Items.Count)
                    i = 0;

                Episodes.SelectedIndex = i;
            }
        }

        //Načtení účtu
        private void LoadAccount()
        {
            try
            {
                string AniDatabasePripojeni = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + GlobalAdresarAccount + "\";User Id=Admin;Password=;";
                this.AniDBDatabase = new OleDbConnection();
                this.AniDBDatabase.ConnectionString = AniDatabasePripojeni;
                this.AniDBDatabase.Open();
            }
            catch
            {
            }
        }

        //Pozadí
        private void LoadBackground()
        {
            LinearGradientBrush xhb;
            Bitmap bmp;
            Graphics g;

            xhb = new LinearGradientBrush(new Rectangle(0, 0, Menu.Width, 10), DesignColor, Color.Transparent, 270F, false);
            bmp = new Bitmap(Menu.Width, Menu.Height);

            g = Graphics.FromImage(bmp);

            g.FillRectangle(xhb, 0, Menu.Height - 10, Menu.Width, 10);
            g.Save();
            g.Dispose();

            Menu.BackgroundImage = bmp;

            xhb = new LinearGradientBrush(new Rectangle(0, 0, AnimeS_BT01.Width, AnimeS_BT01.Height), DesignColor, Color.Transparent, 0F, false);
            bmp = new Bitmap(AnimeS_BT01.Width, AnimeS_BT01.Height);

            g = Graphics.FromImage(bmp);

            g.FillRectangle(xhb, 0, 0, AnimeS_BT01.Width, AnimeS_BT01.Height);
            g.Save();
            g.Dispose();

            AnimeS_BT01.BackgroundImage = bmp;

            
            xhb = new LinearGradientBrush(new Rectangle(0, 0, AnimeS_BT02.Width, AnimeS_BT02.Height), DesignColor, Color.Transparent, 180F, false);
            bmp = new Bitmap(AnimeS_BT02.Width, AnimeS_BT02.Height);

            g = Graphics.FromImage(bmp);

            g.FillRectangle(xhb, 1, 0, AnimeS_BT02.Width, AnimeS_BT02.Height);
            g.Save();
            g.Dispose();

            AnimeS_BT02.BackgroundImage = bmp;
        }

        //Načtení anime
        private void LoadAnime()
        {
            Main_LB01.Visible = true;
            AnimeS.Columns.Clear();
            AnimeS.Rows.Clear();
            AnimeID.Clear();

            AnimeS.Width = Convert.ToInt32(Math.Truncate((float)this.Width / 250) * 250);
            AnimeS.Height = 240;
            AnimeS.Location = new Point((this.Width - AnimeS.Width) / 2, AnimeS.Location.Y);

            Anime.Location = new Point((this.Width - Anime.Width) / 2, AnimeS.Location.Y + AnimeS.Height + 20);

            AnimeS.Columns.Add(new DataGridViewImageColumn());
            AnimeS.Rows.Add();
            AnimeS.Rows[0].Height = 230;

            AnimeS.Rows.Add();
            AnimeS.Rows[1].Height = 5;

            AnimeS.Rows[1].DefaultCellStyle.SelectionBackColor = DesignColor;
            AnimeS.Rows[1].DefaultCellStyle.SelectionForeColor = DesignColor;

            if (BW.IsBusy)
            {
                BW.CancelAsync();
                Thread.Sleep(3000);
            }

            BW.RunWorkerAsync();
        }

        //Načtení anime
        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable DT = DatabaseSelect("SELECT TOP " + SQLCount + " * FROM (SELECT TOP " + SQLCount + " * FROM (SELECT TOP " + (SQLPage * SQLCount) + " * FROM anime ORDER BY CStr([anime]![anime_nazevjap]) ASC) ORDER BY CStr([anime]![anime_nazevjap]) DESC) ORDER by CStr([anime]![anime_nazevjap]) ASC", null, false);
            
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (BW.CancellationPending)
                    break;

                Loading = false;

                AnimeID.Add(DT.Rows[i]["id_anime"].ToString());

                if (File.Exists(GlobalAdresar + @"Accounts\!imgs\" + DT.Rows[i]["anime_obr"].ToString()))
                {
                    StreamReader cti = new StreamReader(GlobalAdresar + @"Accounts\!imgs\" + DT.Rows[i]["anime_obr"].ToString());
                    Image img = Image.FromStream(cti.BaseStream);

                    if (BW.CancellationPending)
                        break;

                    img = RoundCorners(img, 10, Color.Transparent);

                    if (BW.CancellationPending)
                        break;
                    img = resizeImage(img, new Size(250, 200));

                    if (BW.CancellationPending)
                        break;

                    img = Lighter(img);

                    if (BW.CancellationPending)
                        break;

                    BW.ReportProgress(i, img);

                    cti.Close();                    
                }
                else
                    BW.ReportProgress(i, new Bitmap(1, 1));

                while (true)
                {
                    if (Loading)
                        break;

                    if (BW.CancellationPending)
                        break;

                    Thread.Sleep(1);
                }
            }
        }

        //Načtení anime
        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AnimeS.Columns.Add(new DataGridViewImageColumn());

            try
            {
                AnimeS[e.ProgressPercentage, 0].Value = e.UserState;
            }
            catch
            {
                AnimeS[e.ProgressPercentage, 0].Value = new Bitmap(1, 1);
            }

            try
            {
                if (((Bitmap)AnimeS[e.ProgressPercentage, 0].Value).Width < 2)
                    AnimeS[e.ProgressPercentage, 0].Value = new Bitmap(1, 1);
            }
            catch
            {
                AnimeS[e.ProgressPercentage, 0].Value = new Bitmap(1, 1);
            }

            AnimeS[e.ProgressPercentage, 1].Value = new Bitmap(1, 1);

            AnimeS.Columns[e.ProgressPercentage].Width = 250;
            AnimeS.Columns[e.ProgressPercentage].FillWeight = 1;

            if (e.ProgressPercentage % 4 == 0)
                Main_LB01.Text = "Loading";
            else if (e.ProgressPercentage % 4 == 1)
                Main_LB01.Text = "Loading.";
            else if (e.ProgressPercentage % 4 == 2)
                Main_LB01.Text = "Loading..";
            else if (e.ProgressPercentage % 4 == 3)
                Main_LB01.Text = "Loading...";

            if (e.ProgressPercentage == 0)
                Anime_Select();

            Loading = true;
        }

        //Načtení anime
        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimeS.Columns.Count > 1)
                AnimeS.Columns.RemoveAt(AnimeS.Columns.Count - 1);

            Main_LB01.Visible = false;            
        }

        //Zaoblení rohů
        private Image RoundCorners(Image StartImage, int CornerRadius, Color BackgroundColor)
        {
            try
            {
                CornerRadius *= 2;
                Bitmap RoundedImage = new Bitmap(StartImage.Width, StartImage.Height);
                Graphics g = Graphics.FromImage(RoundedImage);
                g.Clear(BackgroundColor);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Brush brush = new TextureBrush(StartImage);
                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                g.FillPath(brush, gp);
                g.Save();
                g.Dispose();
                return RoundedImage;
            }
            catch
            {
                return new Bitmap(1, 1);
            }
        }

        //Zmenšit obrázek
        private Image resizeImage(Image imgToResize, Size size)
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
            g.Save();
            g.Dispose();

            return (Image)b;
        }

        //Prolnutí
        private Image Lighter(Image imgLight)
        {
            LinearGradientBrush xhb = new LinearGradientBrush(new Rectangle(0, imgLight.Height + 5, imgLight.Width, 35), Color.Black, Color.Transparent, -90F, false);

            Bitmap bmp = new Bitmap(imgLight.Width, imgLight.Height + 30);

            Graphics g = Graphics.FromImage(bmp);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgLight, 0, 0);

            imgLight.RotateFlip(RotateFlipType.Rotate180FlipX);

            g.DrawImage(imgLight, 0, imgLight.Height + 5);
            g.Save();

            for (int i = 0; i < 5;i++ )
                g.FillRectangle(xhb, 0, imgLight.Height + 5, imgLight.Width, 35);

            g.Save();
            g.Dispose();

            return bmp;
        }

        //Přidání/editace/mazání z/do databáze - VOID
        private void DatabaseAdd(string SQLString, OleDbCommand Parametry, bool ParametryUse)
        {
            OleDbCommand SQLCommand = new OleDbCommand();
            SQLCommand.CommandText = SQLString;
            SQLCommand.Connection = this.AniDBDatabase;

            if (ParametryUse)
                foreach (OleDbParameter Parametr in Parametry.Parameters)
                {
                    try
                    {
                        SQLCommand.Parameters.Add(Parametr.ParameterName, Parametr.DbType).Value = Parametr.Value;
                    }
                    catch
                    {
                    }
                }

            int response = -1;

            try
            {
                response = SQLCommand.ExecuteNonQuery();
            }
            catch
            {
            }

            SQLCommand.Dispose();
            AniDBDatabase.ResetState();
        }

        //Výběr z databáze
        private DataTable DatabaseSelect(string SQLString, OleDbCommand Parametry, bool ParametryUse)
        {
            if (AniDBDatabase != null)
            {
                OleDbCommand SQLQuery = new OleDbCommand();
                SQLQuery.CommandText = SQLString;
                SQLQuery.Connection = AniDBDatabase;
                SQLQuery.CommandTimeout = 30;

                if (ParametryUse)
                    foreach (OleDbParameter Parametr in Parametry.Parameters)
                    {
                        try
                        {
                            SQLQuery.Parameters.Add(Parametr.ParameterName, Parametr.DbType).Value = Parametr.Value;
                        }
                        catch
                        {
                        }
                    }

                DataTable Data = new DataTable();

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(SQLQuery);

                try
                {
                    dataAdapter.Fill(Data);
                }
                catch
                {
                }

                SQLQuery.Dispose();
                AniDBDatabase.ResetState();
                return Data;
            }

            return new DataTable();
        }

        //Výběr anime
        private void Anime_SelectionChanged(object sender, EventArgs e)
        {
            Anime_Select();
        }

        //Výběr anime
        private void Anime_Select()
        {
            if (AnimeS.SelectedCells.Count > 0 && AnimeID.Count > 0)
            {
                DataTable DTA = DatabaseSelect("select * from anime where id_anime=" + AnimeID[AnimeS.SelectedCells[0].ColumnIndex], null, false);
                DataTable DTE = DatabaseSelect("select * from episodes where id_anime=" + AnimeID[AnimeS.SelectedCells[0].ColumnIndex] + " order by episodes_spec, episodes_epn", null, false);

                if (DTA.Rows.Count > 0)
                {
                    if (File.Exists(GlobalAdresar + @"Accounts\!imgs\" + DTA.Rows[0]["anime_obr"].ToString()))
                    {
                        StreamReader cti = new StreamReader(GlobalAdresar + @"Accounts\!imgs\" + DTA.Rows[0]["anime_obr"].ToString());

                        Bitmap bmp = new Bitmap(Anime.Width, Anime.Height);
                        Image img = Image.FromStream(cti.BaseStream);

                        Graphics g = Graphics.FromImage(bmp);

                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = TextRenderingHint.AntiAlias;

                        g.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, Anime.Width, Anime.Height);
                        g.DrawImage(RoundCorners(img, 10, Color.Transparent), new Point((Anime.Width - Episodes.Width - img.Width) / 2, 10));
                        g.Flush();

                        Anime.BackgroundImage = bmp;
                        cti.Close();
                    }
                    else
                        Anime.BackgroundImage = null;

                    Main_LB04.Location = new Point(10, Episodes.Height + 25);
                    Main_LB04.Text = DTA.Rows[0]["anime_nazevjap"].ToString();

                    Main_LB05.Location = new Point(10, Main_LB04.Height + Main_LB04.Location.Y);
                    Main_LB05.Text = DTA.Rows[0]["anime_nazevkaj"].ToString();

                    DateTime AStart = new DateTime(1800, 1, 1);
                    DateTime AEnd = new DateTime(1800, 1, 1);
                    string ADate = "Air: ";

                    try
                    {
                        AStart = (DateTime)DTA.Rows[0]["anime_date_end"];
                    }
                    catch
                    {
                    }

                    try
                    {
                        AEnd = (DateTime)DTA.Rows[0]["anime_date_air"];
                    }
                    catch
                    {
                    }

                    if (AStart.Year != 1800 && AStart.Year != 1970)
                        ADate = AStart.ToString().Split(' ')[0];

                    if (AEnd.Year != 1800 && AEnd.Year != 1970 && AEnd != AStart)
                        ADate += " - " + AEnd.ToString().Split(' ')[0];

                    Main_LB06.Location = new Point(10, Main_LB05.Height + Main_LB05.Location.Y);
                    Main_LB06.Text = ADate;

                    Main_LB07.Location = new Point(Main_LB07.Location.X, Main_LB04.Height + Main_LB04.Location.Y);
                    Main_LB07.Text = "Episodes: " + DTA.Rows[0]["anime_epn"].ToString();

                    if (DTA.Rows[0]["anime_epn_spec"].ToString() != "0")
                        Main_LB07.Text += " (" + DTA.Rows[0]["anime_epn_spec"].ToString() + ")";

                    Main_LB08.Location = new Point(Main_LB08.Location.X, Main_LB05.Height + Main_LB05.Location.Y);
                    Main_LB08.Text = "Duration: " + DTA.Rows[0]["anime_length"].ToString();

                    Episodes.Items.Clear();
                    EpisodesID.Clear();

                    for (int i = 0; i < DTE.Rows.Count; i++)
                    {
                        string e = DTE.Rows[i]["episodes_epn"].ToString() + ": " + DTE.Rows[i]["episodes_nazeveng"].ToString();
                        if (DTE.Rows[i]["episodes_spec"].ToString() != "0")
                            e = DTE.Rows[i]["episodes_spec"].ToString() + e;

                        Episodes.Items.Add(e);
                        EpisodesID.Add(DTE.Rows[i]["id_episodes"].ToString());
                    }

                    Main_LB04.Visible = true;
                    Main_LB05.Visible = true;
                    Main_LB06.Visible = true;
                    Main_LB07.Visible = true;
                    Main_LB08.Visible = true;
                    Episodes.Visible = true;
                }
            }
        }

        //Nastav čas
        private void Time_Tick(object sender, EventArgs e)
        {
            Main_LB03.Text = DateTime.Now.Day +"/"+ DateTime.Now.Month + " " + string.Format("{0:00}", DateTime.Now.Hour) + ":" + string.Format("{0:00}", DateTime.Now.Minute) + ":" + string.Format("{0:00}", DateTime.Now.Second);
        }

        //Vykreslení epizod
        private void Episodes_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) != 0)
            {
                LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.Black, DesignColor, LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brush, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush textBrush = new SolidBrush(e.ForeColor);
            Font drawFont = e.Font;

            if ((e.State & DrawItemState.Selected) > 0)
            {
                if ((e.State & DrawItemState.Selected) > 0)
                    drawFont = new Font(drawFont.FontFamily, drawFont.Size, FontStyle.Bold);
            }

            e.Graphics.DrawString(Episodes.Items[e.Index].ToString(), drawFont, textBrush, e.Bounds);
        }

        //Další anime
        private void AnimeS_BT01_Click(object sender, EventArgs e)
        {
            if (AnimeS.SelectedColumns.Count > 0) {
                if (AnimeS.SelectedColumns[0].Index - 1 >= 0)
                {
                    AnimeS.Columns[AnimeS.SelectedColumns[0].Index - 1].Selected = true;
                    AnimeS.FirstDisplayedScrollingColumnIndex = AnimeS.SelectedColumns[0].Index - 2 < 0 ? 0 : AnimeS.SelectedColumns[0].Index - 2;
                }
                else
                {
                    SQLPage--;

                    if (SQLPage < 1)
                        SQLPage = 1;
                    else
                        LoadAnime();
                }
            }            
        }

        //Další anime
        private void AnimeS_BT02_Click(object sender, EventArgs e)
        {
            if (AnimeS.SelectedColumns.Count > 0)
            {
                if (AnimeS.SelectedColumns[0].Index + 1 < AnimeS.Columns.Count)
                {
                    AnimeS.Columns[AnimeS.SelectedColumns[0].Index + 1].Selected = true;
                    AnimeS.FirstDisplayedScrollingColumnIndex = AnimeS.SelectedColumns[0].Index - 2 < 0 ? 0 : AnimeS.SelectedColumns[0].Index - 2;
                }
                else
                {
                    SQLPage++;

                    LoadAnime();
                }
            }
        }

        //Další anime
        void AnimeS_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                AnimeS.FirstDisplayedScrollingColumnIndex = AnimeS.FirstDisplayedScrollingColumnIndex - 1 < 0 ? 0 : AnimeS.FirstDisplayedScrollingColumnIndex - 1;
            else
                AnimeS.FirstDisplayedScrollingColumnIndex = AnimeS.FirstDisplayedScrollingColumnIndex + 1 < AnimeS.Columns.Count ? AnimeS.FirstDisplayedScrollingColumnIndex + 1 : AnimeS.Columns.Count - 2;
        }

        //Přehrání videa
        private void Episodes_DoubleClick(object sender, EventArgs e)
        {
            EpisodesPlay();
        }

        //Přehrání videa
        private void EpisodesPlay()
        {
            if (Episodes.SelectedIndex >= 0)
            {
                DataTable DT = DatabaseSelect("select * from files where id_episodes=" + EpisodesID[Episodes.SelectedIndex], null, false);

                if (DT.Rows.Count > 0)
                {
                    if (File.Exists(DT.Rows[0]["files_localfile"].ToString()))
                        Process.Start(DT.Rows[0]["files_localfile"].ToString());
                }
            }
        }

        //Ukončení programu
        private void Main_LB02_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
