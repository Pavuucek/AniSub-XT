using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AniDBTimeline
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("animedb.txt"))
            {
                List<string> Seznam = new List<string>();

                StreamReader Cti = new StreamReader("animedb.txt");

                while (Cti.Peek() >= 0)
                {
                    string Radek = Cti.ReadLine();

                    if (Radek.Contains("<ul") && Radek.Contains("<li") && Radek.Contains("<a href=") && Radek.Contains("<span"))
                    {
                        while (true)
                        {
                            string Vystup = Parse(Radek, "<a href=", ">", true);

                            if (Vystup != null)
                            {
                                Seznam.Add(Vystup);
                                Radek = Radek.Replace(Vystup, "");
                                Console.WriteLine();
                                Console.WriteLine(Vystup);
                            }
                            else
                                break;
                        }
                    }
                }

                Cti.Close();
                Cti.Dispose();

                StreamWriter Zapis = new StreamWriter("Update.sql");

                foreach (string Radek in Seznam)
                {
                    string aID = Parse(Radek, "aid=", "\"", false);
                    string dID = Parse(Radek, "- ", ")\"", false);

                    Zapis.WriteLine("UPDATE anime SET anime_seen='" + dID + "' WHERE id_anime=" + aID);
                    Console.WriteLine();
                    Console.WriteLine("UPDATE anime SET anime_seen='" + dID + "' WHERE id_anime=" + aID);
                }

                Zapis.Close();
                Zapis.Dispose();
            }
            else
                Console.WriteLine("File animedb.txt dont exist");

            Console.WriteLine();
            Console.WriteLine("Complete");
            Console.ReadKey();           
        }

        public static string Parse(string Radek, string Start, string Cil, bool StartAno)
        {
            if (Radek != null)
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
            }
            return null;
        }
    }
}
