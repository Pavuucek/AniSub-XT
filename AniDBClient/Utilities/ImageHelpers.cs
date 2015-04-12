using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using AniDBClient.Properties;

namespace AniDBClient.Utilities
{
    public static class ImageHelpers
    {
        //Ikonka  pro audio
        public static Image FilesLangAudio(string Lang)
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
        public static Image FilesLangSub(string Lang)
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

        //Zmenšit obrázek
        public static Image resizeImage(Image imgToResize, Size size)
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
    }
}
