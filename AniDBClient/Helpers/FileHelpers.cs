using System.IO;
using System.Windows.Forms;

namespace AniDBClient.Helpers
{
    public static class FileHelpers
    {
        //Smazání souboru
        public static void FileDelete(string path)
        {
            if (!File.Exists(path)) return;
            try
            {
                File.Delete(path);
            }
            catch
            {
            }
        }

        //Výběr adresáře
        public static string OpenDirectoryDialog(string path, bool folder)
        {
            // Options_CH13 
            // kurnik kdo se v tom ma vyznat co ktery numero znamena...?
            if (folder)
            {
                var fbd = new FolderBrowserDialog();
                fbd.SelectedPath = path;

                if (fbd.ShowDialog() != DialogResult.OK) return string.Empty;
                return fbd.SelectedPath;
            }
            var ofd = new OpenFileDialog
            {
                InitialDirectory = path,
                CheckPathExists = false,
                ShowReadOnly = false,
                CheckFileExists = false,
                ReadOnlyChecked = false,
                ValidateNames = false,
                FileName = "Folder",
                Filter = "Folders|no.files"
            };

            try
            {
                if (ofd.ShowDialog() != DialogResult.OK) return string.Empty;
                return Path.GetDirectoryName(ofd.FileName);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}