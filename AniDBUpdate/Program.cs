using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WinAPI;
using System.Diagnostics;
using System.Threading;

namespace AniDBUpdate
{
    class Program
    {
        public static OleDbConnection AniDBDatabase = null;
        public static StreamWriter Zapis = new StreamWriter(@"AniSub-MyList.log", false);
        public static long k = 0;
        public static string Ss = "1";

        static void Main(string[] args)
        {
            Zapis.AutoFlush = true;

            if (args.Length == 0)
                return;

            args[0] = args[0].Replace("?", " ");
            args = args[0].Split('*');

            Console.WriteLine("Connect to database...");

            do
            {
                try
                {
                    string AniDatabasePripojeni = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + args[0] + "\"";
                    AniDBDatabase = new OleDbConnection(AniDatabasePripojeni);
                    AniDBDatabase.Open();
                    break;
                }
                catch (Exception e)
                {
                    Zapis.WriteLine(e.ToString());
                    Console.WriteLine(e.ToString());
                    Console.ReadKey();
                }

            } while (args.Length > 3);

            Console.Clear();
            Console.WriteLine("M A I N T E N A N C E");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("AniSub (c) Created by Benda_11");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Update and optimalize database...");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Process: ");

            DataTable DT = DatabaseSelect("SELECT * FROM mylist_local");
            string[] T = DT.Rows[0]["mylist_local_update"].ToString().Split('*');
            string Smin = "1";
            string Sfull = "1";

            try
            {
                Sfull = T[0];
                Smin = T[1];
            }
            catch
            {
            }

            switch (args[2])
            {
                case "full":
                    Ss = Sfull;

                    try
                    {
                        MyListUpdate();
                    }
                    catch (Exception e)
                    {
                        Zapis.WriteLine(e.ToString());
                        Console.WriteLine(e.ToString());
                        Console.ReadKey();
                    }

                    try
                    {
                        MyListUpdate2();
                    }
                    catch (Exception e)
                    {
                        Zapis.WriteLine(e.ToString());
                        Console.WriteLine(e.ToString());
                        Console.ReadKey();
                    }

                    try
                    {
                        MyListUpdate3();
                    }
                    catch (Exception e)
                    {
                        Zapis.WriteLine(e.ToString());
                        Console.WriteLine(e.ToString());
                        Console.ReadKey();
                    }

                    k++;
                    DatabaseAdd("UPDATE mylist_local SET mylist_local_update='" + k + "*" + Smin + "'", null, false);
                    break;

                case "min":
                    Ss = Smin;

                    try
                    {
                        MyListUpdate3();
                    }
                    catch (Exception e)
                    {
                        Zapis.WriteLine(e.ToString());
                        Console.WriteLine(e.ToString());
                        Console.ReadKey();
                    }
                    try
                    {
                        MyListUpdate();
                    }
                    catch (Exception e)
                    {
                        Zapis.WriteLine(e.ToString());
                        Console.WriteLine(e.ToString());
                        Console.ReadKey();
                    }

                    k++;
                    DatabaseAdd("UPDATE mylist_local SET mylist_local_update='" + Sfull + "*" + k + "'", null, false);
                    break;
            }

            try
            {
                WinApi.SendMessage(Convert.ToInt32(args[1]), WinApi.SGUI_Show, 0, 0);
            }
            catch
            {
            }
        }

        public static void MyListUpdate3()
        {
            OleDbCommand Parametry = new OleDbCommand();
            DataTable DT1;
            long mylist_manga_manga = 0;
            long mylist_manga_manga_read = 0;
            long mylist_manga_manga_18 = 0;
            long mylist_manga_pages_read = 0;
            long mylist_manga_pages = 0;

            DT1 = DatabaseSelect("SELECT COUNT(manga.id_manga) AS pocet FROM manga");
            if (DT1.Rows.Count > 0)
            {
                try
                {
                    mylist_manga_manga = Convert.ToInt32(DT1.Rows[0]["pocet"].ToString());
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga='" + DT1.Rows[0]["pocet"].ToString() + "' WHERE id_mylist_manga=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga='0' WHERE id_mylist_manga=1", Parametry, false);
                }
            }
            else
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga='0' WHERE id_mylist_manga=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT SUM(manga.manga_volume) AS pocet FROM manga");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_volumes='" + DT1.Rows[0]["pocet"].ToString() + "' WHERE id_mylist_manga=1", Parametry, false);
            else
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_volumes='0' WHERE id_mylist_manga=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(id_manga_chatpers) AS pocet FROM manga_chapters");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_chapters='" + DT1.Rows[0]["pocet"].ToString() + "' WHERE id_mylist_manga=1", Parametry, false);
            else
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_chapters='0' WHERE id_mylist_manga=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT SUM(manga_chatpers_size) AS pocet FROM manga_chapters");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_size_files='" + FilesSize(DT1.Rows[0]["pocet"].ToString()) + "' WHERE id_mylist_manga=1", Parametry, false);
            else
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_size_files='0' WHERE id_mylist_manga=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(pocet2) AS pocet FROM (SELECT COUNT(id_manga_chatpers) AS pocet2 FROM manga_chapters WHERE manga_chatpers_read=1 GROUP BY id_manga)");
            if (DT1.Rows.Count > 0)
            {
                try
                {
                    mylist_manga_manga_read = Convert.ToInt32(DT1.Rows[0]["pocet"].ToString());
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga_read='" + DT1.Rows[0]["pocet"].ToString() + "' WHERE id_mylist_manga=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga_read='0' WHERE id_mylist_manga=1", Parametry, false);
                }
            }
            else
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga_read='0' WHERE id_mylist_manga=1", Parametry, false);

            double mylist_manga_manga_readP = 0;

            try
            {
                mylist_manga_manga_readP = (mylist_manga_manga_read * 100) / mylist_manga_manga;
            }
            catch
            {
            }

            if (double.IsNaN(mylist_manga_manga_readP))
                mylist_manga_manga_readP = 0;

            mylist_manga_manga_readP = Math.Round((double)mylist_manga_manga_readP, 2);

            DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga_readP='" + mylist_manga_manga_readP + "%' WHERE id_mylist_manga=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT SUM(manga_chatpers_pages) AS pocet FROM manga_chapters");
            if (DT1.Rows.Count > 0)
            {
                try
                {
                    mylist_manga_pages = Convert.ToInt32(DT1.Rows[0]["pocet"].ToString());
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_pages='" + DT1.Rows[0]["pocet"].ToString() + "' WHERE id_mylist_manga=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_pages='0' WHERE id_mylist_manga=1", Parametry, false);
                }
            }
            else
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_pages='0' WHERE id_mylist_manga=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(id_manga) AS pocet FROM manga WHERE manga_18=1");
            if (DT1.Rows.Count > 0)
            {
                try
                {
                    mylist_manga_manga_18 = Convert.ToInt32(DT1.Rows[0]["pocet"].ToString());
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga_18='" + DT1.Rows[0]["pocet"].ToString() + "' WHERE id_mylist_manga=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga_18='0' WHERE id_mylist_manga=1", Parametry, false);
                }
            }
            else
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga_18='0' WHERE id_mylist_manga=1", Parametry, false);

            double mylist_manga_manga_18P = 0;

            try
            {
                mylist_manga_manga_18P = (mylist_manga_manga_18 * 100) / mylist_manga_manga;
            }
            catch
            {
            }

            if (double.IsNaN(mylist_manga_manga_18P))
                mylist_manga_manga_18P = 0;

            mylist_manga_manga_18P = Math.Round((double)mylist_manga_manga_18P, 2);

            DatabaseAdd("UPDATE mylist_manga SET mylist_manga_manga_18P='" + mylist_manga_manga_18P + "%' WHERE id_mylist_manga=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT SUM(manga_chatpers_pages) AS pocet FROM manga_chapters WHERE manga_chatpers_read=1");
            if (DT1.Rows.Count > 0)
            {
                try
                {
                    mylist_manga_pages_read = Convert.ToInt32(DT1.Rows[0]["pocet"].ToString());
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_pages_read='" + DT1.Rows[0]["pocet"].ToString() + "' WHERE id_mylist_manga=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_manga SET mylist_manga_pages_read='0' WHERE id_mylist_manga=1", Parametry, false);
                }
            }
            else
                DatabaseAdd("UPDATE mylist_manga SET mylist_manga_pages_read='0' WHERE id_mylist_manga=1", Parametry, false);

            double mylist_manga_pages_readP = 0;

            try
            {
                mylist_manga_pages_readP = (mylist_manga_pages_read * 100) / mylist_manga_pages;
            }
            catch
            {
            }

            if (double.IsNaN(mylist_manga_pages_readP))
                mylist_manga_pages_readP = 0;

            mylist_manga_pages_readP = Math.Round((double)mylist_manga_pages_readP, 2);

            DatabaseAdd("UPDATE mylist_manga SET mylist_manga_pages_readP='" + mylist_manga_pages_readP + "%' WHERE id_mylist_manga=1", Parametry, false);
        }

        public static void MyListUpdate2()
        {
            DataTable DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime, SUM(files.files_lenght) AS SumOffiles_lenght FROM anime INNER JOIN files ON anime.id_anime = files.id_anime GROUP BY anime.id_anime;");

            foreach (DataRow row in DT1.Rows)
            {
                OleDbCommand Parametry = new OleDbCommand();

                DataTable dataTableFileDub = DatabaseSelect("SELECT files_dub FROM files WHERE id_anime=" + row["id_anime"] + " AND files_lid>0 GROUP BY files_dub");
                DataTable dataTableFileSub = DatabaseSelect("SELECT files_sub FROM files WHERE id_anime=" + row["id_anime"] + " AND files_lid>0 GROUP BY files_sub");
                DataTable dataTableFileSource = DatabaseSelect("SELECT files_source FROM files WHERE id_anime=" + row["id_anime"] + " AND files_lid>0 GROUP BY files_source");
                DataTable dataTableFileStorage = DatabaseSelect("SELECT files_storage FROM files WHERE id_anime=" + row["id_anime"] + " AND files_lid>0 GROUP BY files_storage");
                DataTable dataTableFileWatched = DatabaseSelect("SELECT files_watched FROM files WHERE id_anime=" + row["id_anime"] + " AND files_lid>0 GROUP BY files_watched");                

                List<string> FileList = new List<string>();

                string FilesWatched = "0";
                string FilesLeght = "0s";
                string FilesSizeSum = "-";
                string FilesDub = "";
                string FilesSub = "";
                string FilesSource = "";
                string FilesStorage = "";

                foreach (DataRow row2 in dataTableFileWatched.Rows)
                {
                    if (row2[0].ToString() == "1")
                    {
                        FilesWatched = "1";
                            break;
                    }
                }

                FilesSizeSum = FilesSize(row["SumOffiles_size"].ToString());
                FilesLeght = (" " + GetLenght(row["SumOffiles_lenght"].ToString())).Replace(" 0D ", " ").Replace(" 0H ", " ").Replace(" 0m ", " ").Replace(" 0s", "");

                if (FilesLeght.Length > 1)
                    if (FilesLeght.Substring(0, 1) == " ")
                        FilesLeght = FilesLeght.Remove(0, 1);

                foreach (DataRow row2 in dataTableFileDub.Rows)
                {
                    string[] T = row2[0].ToString().Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string TT in T)
                        if (TT != "" && !FileList.Contains(TT))
                            FileList.Add(TT);
                }
                foreach (string TT in FileList)
                    FilesDub += TT + ", ";
                FileList.Clear();

                foreach (DataRow row2 in dataTableFileSub.Rows)
                {
                    string[] T = row2[0].ToString().Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string TT in T)
                        if (TT != "" && !FileList.Contains(TT))
                            FileList.Add(TT);
                }
                foreach (string TT in FileList)
                    FilesSub += TT + ", ";
                FileList.Clear();

                foreach (DataRow row2 in dataTableFileSource.Rows)
                {
                    string[] T = row2[0].ToString().Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string TT in T)
                        if (TT != "" && !FileList.Contains(TT))
                            FileList.Add(TT);
                }
                foreach (string TT in FileList)
                    FilesSource += TT + ", ";
                FileList.Clear();

                foreach (DataRow row2 in dataTableFileStorage.Rows)
                {
                    string[] T = row2[0].ToString().Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string TT in T)
                        if (TT != "" && !FileList.Contains(TT))
                            FileList.Add(TT);
                }
                foreach (string TT in FileList)
                    FilesStorage += TT + ", ";
                FileList.Clear();

                if (FilesSource.Length >= 2)
                    FilesSource = FilesSource.Substring(0, FilesSource.Length - 2);
                if (FilesStorage.Length >= 2)
                    FilesStorage = FilesStorage.Substring(0, FilesStorage.Length - 2);
                if (FilesDub.Length >= 2)
                    FilesDub = FilesDub.Substring(0, FilesDub.Length - 2);
                if (FilesSub.Length >= 2)
                    FilesSub = FilesSub.Substring(0, FilesSub.Length - 2);

                FilesSource = FilesSource.Replace("'", "''");
                FilesStorage = FilesStorage.Replace("'", "''");
                FilesDub = FilesDub.Replace("'", "''");
                FilesSub = FilesSub.Replace("'", "''");

                DatabaseAdd("UPDATE anime SET anime_watched=" + FilesWatched + ", anime_length='" + FilesLeght + "', anime_dub='" + FilesDub + "', anime_sub='" + FilesSub + "', anime_size='" + FilesSizeSum + "', anime_storage='" + FilesStorage + "', anime_source='" + FilesSource + "' WHERE id_anime=" + row["id_anime"], Parametry, false);
            }
        }

        public static void MyListUpdate()
        {
            OleDbCommand Parametry = new OleDbCommand();

            DataTable DT1;
            DataTable DT2;
            int k = 0;
            long s = 0;
            long st = 0;
            long W_TV = 0;
            long W_TVS = 0;
            long W_OVA = 0;
            long W_MOVIE = 0;
            long W_OTHER = 0;
            long W_WWW = 0;
            long W_UNKNOWN = 0;
            long W_MUSIC = 0;
            long W_TVL = 0;
            long W_TVSL = 0;
            long W_OVAL = 0;
            long W_MOVIEL = 0;
            long W_OTHERL = 0;
            long W_WWWL = 0;
            long W_UNKNOWNL = 0;
            long W_MUSICL = 0;
            long W_TVLW = 0;
            long W_TVSLW = 0;
            long W_OVALW = 0;
            long W_MOVIELW = 0;
            long W_OTHERLW = 0;
            long W_WWWLW = 0;
            long W_UNKNOWNLW = 0;
            long W_MUSICLW = 0;
            long mylist_local_sum = 0;
            long mylist_local_sumL = 0;
            long mylist_local_sumLW = 0;
            long mylist_local_sumW = 0;
            long mylist_local_sumSize = 0;
            long mylist_local_sumSizeW = 0;
            long mylist_local_countsum = 0;
            long mylist_local_sizesum = 0;
            long mylist_local_lensum = 0;
            long mylist_local_watchedsum = 0;
            long mylist_local_countunknown = 0;
            long mylist_local_counthdd = 0;
            long mylist_local_countcd = 0;
            long mylist_local_countdeleted = 0;
            long Count_IDataAdapter_files = 0;

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON files.id_anime=anime.id_anime WHERE files.files_lid>0 GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_anime='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(id_files) FROM files WHERE files_lid>0");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_files='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);

                try
                {
                    Count_IDataAdapter_files = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT COUNT(episodes.id_episodes) FROM episodes INNER JOIN files ON episodes.id_episodes=files.id_episodes WHERE files.files_lid>0 GROUP BY files.id_episodes");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_episodes='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(groups.id_groups) FROM groups INNER JOIN files ON files.id_groups=groups.id_groups WHERE files.files_lid>0 GROUP BY files.id_groups");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_groups='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT SUM(files_size) FROM files WHERE files.files_lid>0");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_sizetotal='" + FilesSize(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    st = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT SUM(files_size) FROM files WHERE files_status=1 AND files.files_lid>0");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_sizehdd='" + FilesSize(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_sizesum = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT SUM(files_size) FROM files WHERE files_status=2 AND files.files_lid>0");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_sizecd='" + FilesSize(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_sizesum = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT SUM(files_size) FROM files WHERE files_status=3 AND files.files_lid>0");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_sizedeleted='" + FilesSize(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_sizesum = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT SUM(files_size) FROM files WHERE files_status=0 AND files.files_lid>0");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_sizeunknown='" + FilesSize(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_sizesum = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DatabaseAdd("UPDATE mylist_local SET mylist_local_sizesum='" + FilesSize(mylist_local_sizesum.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON files.id_anime=anime.id_anime WHERE files_watched=1 AND files.files_lid>0 GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedanime='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(episodes.id_episodes) FROM episodes INNER JOIN files ON episodes.id_episodes=files.id_episodes WHERE files_watched=1  AND files.files_lid>0 GROUP BY files.id_episodes");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedapisodes='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(id_files) FROM files WHERE files_watched=1  AND files.files_lid>0");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedfiles='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT SUM(files_size) FROM files WHERE files_watched=1  AND files.files_lid>0");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedsize='" + FilesSize(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='TV Series' GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_tv='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                mylist_local_sum += DT1.Rows.Count;
            }

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Music Video' GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_music='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                mylist_local_sum += DT1.Rows.Count;
            }

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Movie' GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_movies='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                mylist_local_sum += DT1.Rows.Count;
            }

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='OVA' GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_ova='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                mylist_local_sum += DT1.Rows.Count;
            }

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Web' GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_web='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                mylist_local_sum += DT1.Rows.Count;
            }

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Other' GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_others='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                mylist_local_sum += DT1.Rows.Count;
            }

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='TV Special' GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvs='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                mylist_local_sum += DT1.Rows.Count;
            }

            DT1 = DatabaseSelect("SELECT COUNT(anime.id_anime) FROM anime INNER JOIN files ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Unknown' GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_unknown='" + DT1.Rows.Count.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                mylist_local_sum += DT1.Rows.Count;
            }

            DatabaseAdd("UPDATE mylist_local SET mylist_local_sum='" + mylist_local_sum.ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            /**/

            DT1 = DatabaseSelect("SELECT SUM(files.files_size) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='TV Series'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvSize='" + FilesSize(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_TV = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_size) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Music Video'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_musicSize='" + FilesSize(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_MUSIC = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_size) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='TV Special'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvsSize='" + FilesSize(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_TVS = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_size) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Movie'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_moviesSize='" + FilesSize(x) + "' WHERE id_mylist_local=1", Parametry, false);

                W_MOVIE = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_size) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='OVA'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_ovaSize='" + FilesSize(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_OVA = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_size) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Web'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_webSize='" + FilesSize(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_WWW = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_size) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Other'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_othersSize='" + FilesSize(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_OTHER = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_size) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Unknown'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownSize='" + FilesSize(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_UNKNOWN = Convert.ToInt64(x);
            }

            mylist_local_sumSize = W_TV + W_TVS + W_OVA + W_MOVIE + W_OTHER + W_WWW + W_UNKNOWN + +W_MUSIC;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_sumSize='" + FilesSize(mylist_local_sumSize.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            /**/

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='TV Series'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvL='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_TVL = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Music Video'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_musicL='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_MUSICL = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='TV Special'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvsL='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_TVSL = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Movie'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_moviesL='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);

                W_MOVIEL = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='OVA'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_ovaL='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_OVAL = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Web'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_webL='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_WWWL = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Other'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_othersL='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_OTHERL = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Unknown'");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownL='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_UNKNOWNL = Convert.ToInt64(x);
            }

            mylist_local_sumL = W_TVL + W_TVSL + W_OVAL + W_MOVIEL + W_OTHERL + W_WWWL + W_UNKNOWNL + W_MUSICL;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_sumL='" + GetLenght(mylist_local_sumL.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            /**/

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='TV Series' AND files.files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvLW='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_TVLW = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Music Video' AND files.files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_musicLW='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_MUSICLW = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='TV Special' AND files.files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvsLW='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_TVSLW = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Movie' AND files.files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_moviesLW='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);

                W_MOVIELW = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='OVA' AND files.files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_ovaLW='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_OVALW = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Web' AND files.files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_webLW='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_WWWLW = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Other' AND files.files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_othersLW='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_OTHERLW = Convert.ToInt64(x);
            }

            DT1 = DatabaseSelect("SELECT SUM(files.files_lenght) FROM files INNER JOIN anime ON anime.id_anime=files.id_anime WHERE files.files_lid>0 AND anime_typ='Unknown' AND files.files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                string x = DT1.Rows[0][0].ToString();

                if (x == "")
                    x = "0";

                DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownLW='" + GetLenght(x) + "' WHERE id_mylist_local=1", Parametry, false);
                W_UNKNOWNLW = Convert.ToInt64(x);
            }

            mylist_local_sumLW = W_TVLW + W_TVSLW + W_OVALW + W_MOVIELW + W_OTHERLW + W_WWWLW + W_UNKNOWNLW + W_MUSICLW;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_sumLW='" + GetLenght(mylist_local_sumLW.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            /**/

            double W_TVLP = 0;
            double W_TVSLP = 0;
            double W_OVALP = 0;
            double W_MOVIELP = 0;
            double W_OTHERLP = 0;
            double W_WWWLP = 0;
            double W_UNKNOWNLP = 0;
            double W_MUSICLP = 0;
            double W_MUSICLSUM = 0;

            try
            {
                W_WWWLP = Math.Round(((double)W_WWWLW * 100) / (double)W_WWWL, 2);
            }
            catch
            {
                W_WWWLP = 0;
            }

            try
            {
                W_TVLP = Math.Round(((double)W_TVLW * 100) / (double)W_TVL, 2);
            }
            catch
            {
                W_TVLP = 0;
            }

            try
            {
                W_TVSLP = Math.Round(((double)W_TVSLW * 100) / (double)W_TVSL, 2);
            }
            catch
            {
                W_TVSLP = 0;
            }

            try
            {
                W_OVALP = Math.Round(((double)W_OVALW * 100) / (double)W_OVAL, 2);
            }
            catch
            {
                W_OVALP = 0;
            }

            try
            {
                W_MOVIELP = Math.Round(((double)W_MOVIELW * 100) / (double)W_MOVIEL, 2);
            }
            catch
            {
                W_MOVIELP = 0;
            }

            try
            {
                W_OTHERLP = Math.Round(((double)W_OTHERLW * 100) / (double)W_OTHERL, 2);
            }
            catch
            {
                W_OTHERLP = 0;
            }

            try
            {
                W_UNKNOWNLP = Math.Round(((double)W_UNKNOWNLW * 100) / (double)W_UNKNOWNL, 2);
            }
            catch
            {
                W_UNKNOWNLP = 0;
            }

            try
            {
                W_MUSICLP = Math.Round(((double)W_MUSICLW * 100) / (double)W_MUSICL, 2);
            }
            catch
            {
                W_MUSICLP = 0;
            }


            try
            {
                W_MUSICLSUM = Math.Round(((double)mylist_local_sumLW * 100) / (double)mylist_local_sumL, 2);
            }
            catch
            {
                W_MUSICLSUM = 0;
            }

            if (double.IsNaN(W_TVLP))
                W_TVLP = 0;

            if (double.IsNaN(W_TVSLP))
                W_TVSLP = 0;

            if (double.IsNaN(W_MOVIELP))
                W_MOVIELP = 0;

            if (double.IsNaN(W_OVALP))
                W_OVALP = 0;

            if (double.IsNaN(W_WWWLP))
                W_WWWLP = 0;

            if (double.IsNaN(W_OTHERLP))
                W_OTHERLP = 0;

            if (double.IsNaN(W_UNKNOWNLP))
                W_UNKNOWNLP = 0;

            if (double.IsNaN(W_MUSICLP))
                W_MUSICLP = 0;

            if (double.IsNaN(W_MUSICLSUM))
                W_MUSICLSUM = 0;

            DatabaseAdd("UPDATE mylist_local SET mylist_local_tvLP='" + W_TVLP.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_tvsLP='" + W_TVSLP.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_moviesLP='" + W_MOVIELP.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_ovaLP='" + W_OVALP.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_webLP='" + W_WWWLP.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_othersLP='" + W_OTHERLP.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownLP='" + W_UNKNOWNLP.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_musicLP='" + W_MUSICLP.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_sumLP='" + W_MUSICLSUM.ToString() + "%' WHERE id_mylist_local=1", Parametry, false);

            /**/

            s = 0;
            DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime FROM anime INNER JOIN files ON anime.id_anime = files.id_anime WHERE (((anime.anime_typ)='TV Series') AND ((files.files_lid)>0) AND ((files.files_watched)=1)) GROUP BY anime.id_anime");
            k = DT1.Rows.Count;
            foreach (DataRow row in DT1.Rows)
            {
                try
                {
                    s += Convert.ToInt64(row[0].ToString());
                }
                catch
                {
                }
            }
            DatabaseAdd("UPDATE mylist_local SET mylist_local_tvW='" + k.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumW += k;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_tvSizeW='" + FilesSize(s.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumSizeW += s;
            try
            {
                double y = Math.Round((double)(100 * s) / (double)W_TV, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvpercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvpercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            s = 0;
            DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime FROM anime INNER JOIN files ON anime.id_anime = files.id_anime WHERE (((anime.anime_typ)='Music Video') AND ((files.files_lid)>0) AND ((files.files_watched)=1)) GROUP BY anime.id_anime");
            k = DT1.Rows.Count;
            foreach (DataRow row in DT1.Rows)
            {
                try
                {
                    s += Convert.ToInt64(row[0].ToString());
                }
                catch
                {
                }
            }
            DatabaseAdd("UPDATE mylist_local SET mylist_local_musicW='" + k.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumW += k;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_musicSizeW='" + FilesSize(s.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumSizeW += s;
            try
            {
                double y = Math.Round((double)(100 * s) / (double)W_MUSIC, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_musicpercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_musicpercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            s = 0;
            DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime FROM anime INNER JOIN files ON anime.id_anime = files.id_anime WHERE (((anime.anime_typ)='TV Special') AND ((files.files_lid)>0) AND ((files.files_watched)=1)) GROUP BY anime.id_anime");
            k = DT1.Rows.Count;
            foreach (DataRow row in DT1.Rows)
            {
                try
                {
                    s += Convert.ToInt64(row[0].ToString());
                }
                catch
                {
                }
            }
            DatabaseAdd("UPDATE mylist_local SET mylist_local_tvsW='" + k.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumW += k;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_tvsSizeW='" + FilesSize(s.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumSizeW += s;
            try
            {
                double y = Math.Round((double)(100 * s) / (double)W_TVS, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvspercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_tvspercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            s = 0;
            DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime FROM anime INNER JOIN files ON anime.id_anime = files.id_anime WHERE (((anime.anime_typ)='Movie') AND ((files.files_lid)>0) AND ((files.files_watched)=1)) GROUP BY anime.id_anime");
            k = DT1.Rows.Count;
            foreach (DataRow row in DT1.Rows)
            {
                try
                {
                    s += Convert.ToInt64(row[0].ToString());
                }
                catch
                {
                }
            }
            DatabaseAdd("UPDATE mylist_local SET mylist_local_moviesW='" + k.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumW += k;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_moviesSizeW='" + FilesSize(s.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumSizeW += s;
            try
            {
                double y = Math.Round((double)(100 * s) / (double)W_MOVIE, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_moviespercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_moviespercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            s = 0;
            DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime FROM anime INNER JOIN files ON anime.id_anime = files.id_anime WHERE (((anime.anime_typ)='OVA') AND ((files.files_lid)>0) AND ((files.files_watched)=1)) GROUP BY anime.id_anime");
            k = DT1.Rows.Count;
            foreach (DataRow row in DT1.Rows)
            {
                try
                {
                    s += Convert.ToInt64(row[0].ToString());
                }
                catch
                {
                }
            }
            DatabaseAdd("UPDATE mylist_local SET mylist_local_ovaW='" + k.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumW += k;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_ovaSizeW='" + FilesSize(s.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumSizeW += s;
            try
            {
                double y = Math.Round((double)(100 * s) / (double)W_OVA, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_ovapercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_ovapercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            s = 0;
            DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime FROM anime INNER JOIN files ON anime.id_anime = files.id_anime WHERE (((anime.anime_typ)='Web') AND ((files.files_lid)>0) AND ((files.files_watched)=1)) GROUP BY anime.id_anime");
            k = DT1.Rows.Count;
            foreach (DataRow row in DT1.Rows)
            {
                try
                {
                    s += Convert.ToInt64(row[0].ToString());
                }
                catch
                {
                }
            }
            DatabaseAdd("UPDATE mylist_local SET mylist_local_webW='" + k.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumW += k;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_webSizeW='" + FilesSize(s.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumSizeW += s;
            try
            {
                double y = Math.Round((double)(100 * s) / (double)W_WWW, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_webpercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_webpercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            s = 0;
            DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime FROM anime INNER JOIN files ON anime.id_anime = files.id_anime WHERE (((anime.anime_typ)='Other') AND ((files.files_lid)>0) AND ((files.files_watched)=1)) GROUP BY anime.id_anime");
            k = DT1.Rows.Count;
            foreach (DataRow row in DT1.Rows)
            {
                try
                {
                    s += Convert.ToInt64(row[0].ToString());
                }
                catch
                {
                }
            }
            DatabaseAdd("UPDATE mylist_local SET mylist_local_othersW='" + k.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumW += k;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_othersSizeW='" + FilesSize(s.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumSizeW += s;
            try
            {
                double y = Math.Round((double)(100 * s) / (double)W_OTHER, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_otherspercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_otherspercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            s = 0;
            DT1 = DatabaseSelect("SELECT Sum(files.files_size) AS SumOffiles_size, anime.id_anime FROM anime INNER JOIN files ON anime.id_anime = files.id_anime WHERE (((anime.anime_typ)='Unknown') AND ((files.files_lid)>0) AND ((files.files_watched)=1)) GROUP BY anime.id_anime");
            k = DT1.Rows.Count;
            foreach (DataRow row in DT1.Rows)
            {
                try
                {
                    s += Convert.ToInt64(row[0].ToString());
                }
                catch
                {
                }
            }
            DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownW='" + k.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumW += k;
            DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownSizeW='" + FilesSize(s.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
            mylist_local_sumSizeW += s;
            try
            {
                double y = Math.Round((double)(100 * s) / (double)W_UNKNOWN, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownpercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownpercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            DatabaseAdd("UPDATE mylist_local SET mylist_local_sumW='" + mylist_local_sumW.ToString() + "' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_sumSizeW='" + FilesSize(mylist_local_sumSizeW.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            try
            {
                double y = Math.Round((double)(100 * mylist_local_sumW) / (double)mylist_local_sum, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_sumpercent='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_sumpercent='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            try
            {
                double y = Math.Round((double)(100 * mylist_local_sumSizeW) / (double)mylist_local_sumSize, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_sumpercentsize='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_sumpercentsize='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            /**/

            DT1 = DatabaseSelect("SELECT COUNT(files_size) FROM files WHERE files.files_lid>0 AND files_status=1");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_counthdd='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_countsum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                    mylist_local_counthdd = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT COUNT(files_size) FROM files WHERE files.files_lid>0 AND files_status=2");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_countcd='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_countsum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                    mylist_local_countcd = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT COUNT(files_size) FROM files WHERE files.files_lid>0 AND files_status=3");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_countdeleted='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_countsum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                    mylist_local_countdeleted = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT COUNT(files_size) FROM files WHERE files.files_lid>0 AND files_status=0");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_countunknown='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_countsum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                    mylist_local_countunknown = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DatabaseAdd("UPDATE mylist_local SET mylist_local_countsum='" + mylist_local_countsum.ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT SUM(files_lenght) FROM files WHERE files.files_lid>0 AND files_status=1");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_lenhdd='" + GetLenght(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_lensum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT SUM(files_lenght) FROM files WHERE files.files_lid>0 AND files_status=2");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_lencd='" + GetLenght(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_lensum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT SUM(files_lenght) FROM files WHERE files.files_lid>0 AND files_status=3");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_lendeleted='" + GetLenght(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_lensum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DT1 = DatabaseSelect("SELECT SUM(files_lenght) FROM files WHERE files.files_lid>0 AND files_status=0");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_lenunknown='" + GetLenght(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);
                try
                {
                    mylist_local_lensum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }
            }

            DatabaseAdd("UPDATE mylist_local SET mylist_local_lensum='" + GetLenght(mylist_local_lensum.ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT SUM(files_lenght) FROM files");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_lenght='" + GetLenght(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT COUNT(files_size) FROM files WHERE files.files_lid>0 AND files_status=1 AND files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedhdd='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                long x = 0;

                try
                {
                    mylist_local_watchedsum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                    x = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }

                try
                {
                    double y = Math.Round((double)(x * 100) / (double)mylist_local_counthdd, 2);

                    if (double.IsNaN(y))
                        y = 0;

                    DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedhddpercent='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedhddpercent='0%' WHERE id_mylist_local=1", Parametry, false);
                }
            }

            DT1 = DatabaseSelect("SELECT COUNT(files_size) FROM files WHERE files.files_lid>0 AND files_status=2 AND files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedcd='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                long x = 0;

                try
                {
                    mylist_local_watchedsum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                    x = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }

                try
                {
                    double y = Math.Round((double)(x * 100) / (double)mylist_local_countcd, 2);

                    if (double.IsNaN(y))
                        y = 0;

                    DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedcdpercent='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedcdpercent='0%' WHERE id_mylist_local=1", Parametry, false);
                }
            }

            DT1 = DatabaseSelect("SELECT COUNT(files_size) FROM files WHERE files.files_lid>0 AND files_status=3 AND files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watcheddeleted='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                long x = 0;

                try
                {
                    mylist_local_watchedsum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                    x = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }

                try
                {
                    double y = Math.Round((double)(x * 100) / (double)mylist_local_countdeleted, 2);

                    if (double.IsNaN(y))
                        y = 0;

                    DatabaseAdd("UPDATE mylist_local SET mylist_local_watcheddeletedpercent='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_local SET mylist_local_watcheddeletedpercent='0%' WHERE id_mylist_local=1", Parametry, false);
                }
            }

            DT1 = DatabaseSelect("SELECT COUNT(files_size) FROM files WHERE files.files_lid>0 AND files_status=0 AND files_watched=1");
            if (DT1.Rows.Count > 0)
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedunknown='" + DT1.Rows[0][0].ToString() + "' WHERE id_mylist_local=1", Parametry, false);
                long x = 0;
                try
                {
                    mylist_local_watchedsum += Convert.ToInt64(DT1.Rows[0][0].ToString());
                    x = Convert.ToInt64(DT1.Rows[0][0].ToString());
                }
                catch
                {
                }

                try
                {
                    double y = Math.Round((double)(100 * x) / (double)mylist_local_countunknown, 2);

                    if (double.IsNaN(y))
                        y = 0;

                    DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedunknownpercent='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
                }
                catch
                {
                    DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedunknownpercent='0%' WHERE id_mylist_local=1", Parametry, false);
                }
            }

            DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedsum='" + mylist_local_watchedsum.ToString() + "' WHERE id_mylist_local=1", Parametry, false);

            try
            {
                double y = Math.Round((double)(mylist_local_watchedsum * 100) / (double)mylist_local_countsum, 2);

                if (double.IsNaN(y))
                    y = 0;

                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedsumpercent='" + (y).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            }
            catch
            {
                DatabaseAdd("UPDATE mylist_local SET mylist_local_watchedsumpercent='0%' WHERE id_mylist_local=1", Parametry, false);
            }

            DT1 = DatabaseSelect("SELECT SUM(files_lenght) FROM files WHERE files.files_lid>0");
            if (DT1.Rows.Count > 0)
                DatabaseAdd("UPDATE mylist_local SET mylist_local_lenghtwatched='" + GetLenght(DT1.Rows[0][0].ToString()) + "' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT * FROM mylist_local");
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            double f = 0;
            double g = 0;
            double h = 0;
            double i = 0;

            try
            {
                a = (Math.Round((Convert.ToDouble(DT1.Rows[0]["mylist_local_tvW"].ToString()) * 100) / Convert.ToDouble(DT1.Rows[0]["mylist_local_tv"].ToString()), 2));
            }
            catch
            {
            }

            try
            {
                b = (Math.Round((Convert.ToDouble(DT1.Rows[0]["mylist_local_tvsW"].ToString()) * 100) / Convert.ToDouble(DT1.Rows[0]["mylist_local_tvs"].ToString()), 2));
            }
            catch
            {
            }

            try
            {
                c = (Math.Round((Convert.ToDouble(DT1.Rows[0]["mylist_local_moviesW"].ToString()) * 100) / Convert.ToDouble(DT1.Rows[0]["mylist_local_movies"].ToString()), 2));
            }
            catch
            {
            }

            try
            {
                d = (Math.Round((Convert.ToDouble(DT1.Rows[0]["mylist_local_ovaW"].ToString()) * 100) / Convert.ToDouble(DT1.Rows[0]["mylist_local_ova"].ToString()), 2));
            }
            catch
            {
            }

            try
            {
                f = (Math.Round((Convert.ToDouble(DT1.Rows[0]["mylist_local_webW"].ToString()) * 100) / Convert.ToDouble(DT1.Rows[0]["mylist_local_web"].ToString()), 2));
            }
            catch
            {
            }

            try
            {
                g = (Math.Round((Convert.ToDouble(DT1.Rows[0]["mylist_local_othersW"].ToString()) * 100) / Convert.ToDouble(DT1.Rows[0]["mylist_local_others"].ToString()), 2));
            }
            catch
            {
            }

            try
            {
                h = (Math.Round((Convert.ToDouble(DT1.Rows[0]["mylist_local_unknownW"].ToString()) * 100) / Convert.ToDouble(DT1.Rows[0]["mylist_local_unknown"].ToString()), 2));
            }
            catch
            {
            }

            try
            {
                i = (Math.Round((Convert.ToDouble(DT1.Rows[0]["mylist_local_musicW"].ToString()) * 100) / Convert.ToDouble(DT1.Rows[0]["mylist_local_music"].ToString()), 2));
            }
            catch
            {
            }

            if (double.IsNaN(a))
                a = 0;
            if (double.IsNaN(b))
                b = 0;
            if (double.IsNaN(c))
                c = 0;
            if (double.IsNaN(d))
                d = 0;
            if (double.IsNaN(f))
                f = 0;
            if (double.IsNaN(h))
                h = 0;
            if (double.IsNaN(g))
                g = 0;
            if (double.IsNaN(i))
                i = 0;

            DatabaseAdd("UPDATE mylist_local SET mylist_local_tvpercent='" + (a).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_tvspercent='" + (b).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_moviespercent='" + (c).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_ovapercent='" + (d).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_webpercent='" + (f).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_otherspercent='" + (g).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_unknownpercent='" + (h).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);
            DatabaseAdd("UPDATE mylist_local SET mylist_local_musicpercent='" + (i).ToString() + "%' WHERE id_mylist_local=1", Parametry, false);

            DT1 = DatabaseSelect("SELECT files.files_storage, Count(files.files_storage) AS CountOffiles_storage, Sum(files.files_size) AS SumOffiles_size FROM files GROUP BY files.files_storage;");
            DatabaseAdd("DELETE FROM mylist_storages", null, false);

            foreach (DataRow row in DT1.Rows)
            {
                if (row[0].ToString() != "")
                {
                    long x = 0;

                    try
                    {
                        x = Convert.ToInt64(row[1]);
                    }
                    catch
                    {
                    }

                    string q = FilesSize(row[2].ToString());

                    double y = Math.Round((double)(x * 100) / (double)Count_IDataAdapter_files, 2);

                    if (double.IsNaN(y))
                        y = 0;

                    try
                    {
                        DatabaseAdd("INSERT INTO mylist_storages (mylist_storages_storage, mylist_storages_count, mylist_storages_percent, mylist_storages_size) VALUES ('" + row[0].ToString() + "', '" + x + "', '" + (y).ToString() + "%', '" + q + "')", null, false);
                    }
                    catch
                    {
                        DatabaseAdd("INSERT INTO mylist_storages (mylist_storages_storage, mylist_storages_count, mylist_storages_percent, mylist_storages_size) VALUES ('" + row[0].ToString() + "', '" + x + "', '0%', '" + q + "')", null, false);
                    }
                }
            }

            DT1 = DatabaseSelect("SELECT files.files_source, Count(files.files_source) AS CountOffiles_source, Sum(files.files_size) AS SumOffiles_size FROM files GROUP BY files.files_source;");
            DatabaseAdd("DELETE FROM mylist_sources", null, false);

            foreach (DataRow row in DT1.Rows)
            {
                if (row[0].ToString() != "")
                {
                    long x = 0;

                    try
                    {
                        x = Convert.ToInt64(row[1]);
                    }
                    catch
                    {
                    }

                    double y = Math.Round((double)(x * 100) / (double)Count_IDataAdapter_files, 2);

                    if (double.IsNaN(y))
                        y = 0;

                    string q = FilesSize(row[2].ToString());

                    try
                    {
                        DatabaseAdd("INSERT INTO mylist_sources (mylist_sources_source, mylist_sources_count, mylist_sources_percent, mylist_sources_size) VALUES ('" + row[0].ToString() + "', '" + x + "', '" + (y).ToString() + "%', '" + q + "')", null, false);
                    }
                    catch
                    {
                        DatabaseAdd("INSERT INTO mylist_sources (mylist_sources_source, mylist_sources_count, mylist_sources_percent, mylist_sources_size) VALUES ('" + row[0].ToString() + "', '" + x + "', '0%', '" + q + "')", null, false);
                    }
                }
            }

            DT1 = DatabaseSelect("SELECT Count(anime.anime_18) FROM anime INNER JOIN files ON files.id_anime=anime.id_anime WHERE files.files_lid>0 AND anime.anime_18=1 GROUP BY files.id_anime");
            if (DT1.Rows.Count > 0)
            {
                int y = DT1.Rows.Count;
                DT1 = DatabaseSelect("SELECT Count(anime.id_anime) FROM anime INNER JOIN files ON files.id_anime=anime.id_anime WHERE files.files_lid>0 GROUP BY files.id_anime");

                double x = 0;

                try
                {
                    x = Math.Round((Convert.ToDouble(y) * 100) / Convert.ToDouble(DT1.Rows.Count), 2);
                }
                catch
                {
                    x = 0;
                }

                DatabaseAdd("UPDATE mylist_local SET mylist_local_18='" + y.ToString() + "', mylist_local_18P='" + x.ToString() + "%'  WHERE id_mylist_local=1", null, false);
            }
            else
                DatabaseAdd("UPDATE mylist_local SET mylist_local_18='0', mylist_local_18P='0%'  WHERE id_mylist_local=1", null, false);

            DT1 = DatabaseSelect("SELECT id_tags FROM tags_relation GROUP BY id_tags");

            DT2 = DatabaseSelect("SELECT * FROM tags");

            for (int q=0; q< DT2.Rows.Count;q++)
            {
                k = 0;

                for (int j=0; j< DT1.Rows.Count;j++)
                {
                    if (DT2.Rows[q]["id_tags"].ToString() == DT1.Rows[j]["id_tags"].ToString())
                    {
                        k++;
                        break;
                    }
                }

                if (k == 0)
                    DatabaseAdd("DELETE FROM tags WHERE id_tags=" + DT2.Rows[q]["id_tags"].ToString(), null, false);
            }
        }

        //Přidání/editace/mazání z/do databáze - VOID
        public static void DatabaseAdd(string SQLString, OleDbCommand Parametry, bool ParametryUse)
        {
            AniDBDatabase.ResetState();

            k++;
            ShowInfo();

            OleDbCommand SQLCommand = new OleDbCommand();
            SQLCommand.CommandText = SQLString;
            SQLCommand.Connection = AniDBDatabase;

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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            SQLCommand.Dispose();
        }

        //Výběr z databáze
        public static DataTable DatabaseSelect(string SQLString)
        {
            k++;
            ShowInfo();

            OleDbCommand SQLQuery = new OleDbCommand();
            SQLQuery.CommandText = SQLString;
            SQLQuery.Connection = AniDBDatabase;
            SQLQuery.CommandTimeout = 5;

            DataTable Data = new DataTable();

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(SQLQuery);
            try
            {
                dataAdapter.Fill(Data);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("MySQL = NULL");

                Zapis.WriteLine(e.ToString());
                Zapis.WriteLine("MySQL = NULL");
            }

            SQLQuery.Dispose();
            return Data;
        }

        //Parsování
        private static string Parse(string Radek, string Start, string Cil, bool StartAno)
        {
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

            return null;
        }

        //Získej čas ze sekund
        private static DateTime GetDateFromSeconds(string sString)
        {
            if (sString == "")
                return new DateTime(1970, 1, 1, 0, 0, 0);

            long s = Convert.ToInt64(sString);
            if (s == 0)
                return new DateTime(1970, 1, 1, 0, 0, 0);

            int y = 1970;
            long m = 0;
            long h = 0;
            long d = 0;
            long M = 1;

            m = s / 60;
            s -= m * 60;
            h = m / 60;
            m -= h * 60;
            d = h / 24;
            h -= d * 24;

            while (true)
            {
                if (d < 365)
                    break;

                if (DateTime.IsLeapYear(y))
                    d -= 366;
                else
                    d -= 365;

                y++;
            }

            long[] Marray = new long[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (DateTime.IsLeapYear(y))
                Marray[1] = 29;

            for (int i = 0; i < Marray.Length; i++)
            {
                if (d < Marray[i])
                    break;

                d -= Marray[i];

                M++;
            }

            return new DateTime((int)y, (int)M, (int)d, (int)h, (int)m, (int)s);
        }

        //Získej délku videa
        private static string GetLenght(string sString)
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

                m = s / 60;
                s -= m * 60;
                h = m / 60;
                m -= 60 * h;
                d = h / 24;
                h -= d * 24;

                return d.ToString() + "D " + h.ToString() + "H " + m.ToString() + "m " + s.ToString() + "s";
            }
            catch
            {
                return "0s";
            }
        }

        //Převod jednotek
        private static string FilesSize(string size)
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
        private static string FilesState(string state)
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

        //Zobray průběh
        private static void ShowInfo()
        {
            Console.SetCursorPosition(9, 12);
            Console.Write(k + " / " + Ss);
        }
    }
}
