using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using AniDBClient.Properties;

namespace AniDBClient.Utilities
{
    public static class FileHelpers
    {
        //Smazání souboru
        public static void FileDelete(string Path)
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
