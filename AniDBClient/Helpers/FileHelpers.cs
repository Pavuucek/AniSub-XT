using System.IO;

namespace AniDBClient.Helpers
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
