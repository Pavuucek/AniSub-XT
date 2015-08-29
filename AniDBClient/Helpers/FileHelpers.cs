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

        //Obrázek přípona
        public static int FExtension(string Ext)
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
    }
}