using System.Drawing;
using System.Drawing.Drawing2D;
using AniDBClient.Properties;

namespace AniDBClient.Helpers
{
    public static class ImageHelpers
    {
        //Ikonka  pro audio
        public static Image FilesLangAudio(string lang)
        {
            lang = lang.ToLower();
            var langT = lang.Replace(" (unspecified)", "").Split('\'');
            var audio = new Image[langT.Length];

            for (var i = 0; i < langT.Length; i++)
                switch (langT[i])
                {
                    case "albanian":
                        audio[i] = Resources.anidb_audio_albanian;
                        break;

                    case "arabic":
                        audio[i] = Resources.anidb_audio_arabic;
                        break;

                    case "bengali":
                        audio[i] = Resources.anidb_audio_bengali;
                        break;

                    case "brasilian":
                        audio[i] = Resources.anidb_audio_brasilian;
                        break;

                    case "bulgarian":
                        audio[i] = Resources.anidb_audio_bulgarian;
                        break;

                    case "cantonese":
                        audio[i] = Resources.anidb_audio_cantonese;
                        break;

                    case "catalan":
                        audio[i] = Resources.anidb_audio_catalan;
                        break;

                    case "croatian":
                        audio[i] = Resources.anidb_audio_croatian;
                        break;

                    case "czech":
                        audio[i] = Resources.anidb_audio_czech;
                        break;

                    case "danish":
                        audio[i] = Resources.anidb_audio_danish;
                        break;

                    case "dutch":
                        audio[i] = Resources.anidb_audio_dutch;
                        break;

                    case "estonian":
                        audio[i] = Resources.anidb_audio_estonian;
                        break;

                    case "finnish":
                        audio[i] = Resources.anidb_audio_finnish;
                        break;

                    case "french":
                        audio[i] = Resources.anidb_audio_french;
                        break;

                    case "georgian":
                        audio[i] = Resources.anidb_audio_georgian;
                        break;

                    case "german":
                        audio[i] = Resources.anidb_audio_german;
                        break;

                    case "hebrew":
                        audio[i] = Resources.anidb_audio_hebrew;
                        break;

                    case "hungarian":
                        audio[i] = Resources.anidb_audio_hungarian;
                        break;

                    case "chinese":
                        audio[i] = Resources.anidb_audio_chinese;
                        break;

                    case "icelandic":
                        audio[i] = Resources.anidb_audio_icelandic;
                        break;

                    case "indonesian":
                        audio[i] = Resources.anidb_audio_indonesian;
                        break;

                    case "instrumental":
                        audio[i] = Resources.anidb_audio_instrumental;
                        break;

                    case "italian":
                        audio[i] = Resources.anidb_audio_italian;
                        break;

                    case "korean":
                        audio[i] = Resources.anidb_audio_korean;
                        break;

                    case "latin":
                        audio[i] = Resources.anidb_audio_latin;
                        break;

                    case "lithuanian":
                        audio[i] = Resources.anidb_audio_lithuanian;
                        break;

                    case "malay":
                        audio[i] = Resources.anidb_audio_malay;
                        break;

                    case "mandarin":
                        audio[i] = Resources.anidb_audio_mandarin;
                        break;

                    case "norwegian":
                        audio[i] = Resources.anidb_audio_norwegian;
                        break;

                    case "polish":
                        audio[i] = Resources.anidb_audio_polish;
                        break;

                    case "portuguese":
                        audio[i] = Resources.anidb_audio_portuguese;
                        break;

                    case "romania":
                        audio[i] = Resources.anidb_audio_romanian;
                        break;

                    case "serbian":
                        audio[i] = Resources.anidb_audio_serbian;
                        break;

                    case "simplified":
                        audio[i] = Resources.anidb_audio_simplified;
                        break;

                    case "slovak":
                        audio[i] = Resources.anidb_audio_slovak;
                        break;

                    case "slovenian":
                        audio[i] = Resources.anidb_audio_slovenian;
                        break;

                    case "spanish":
                        audio[i] = Resources.anidb_audio_spanish;
                        break;

                    case "swedish":
                        audio[i] = Resources.anidb_audio_swedish;
                        break;

                    case "taiwanese":
                        audio[i] = Resources.anidb_audio_taiwanese;
                        break;

                    case "tamil":
                        audio[i] = Resources.anidb_audio_tamil;
                        break;

                    case "tartar":
                        audio[i] = Resources.anidb_audio_tartar;
                        break;

                    case "thai":
                        audio[i] = Resources.anidb_audio_thai;
                        break;

                    case "traditional":
                        audio[i] = Resources.anidb_audio_traditional;
                        break;

                    case "turkish":
                        audio[i] = Resources.anidb_audio_turkish;
                        break;

                    case "ukrainian":
                        audio[i] = Resources.anidb_audio_ukrainian;
                        break;

                    case "unknown":
                        audio[i] = Resources.anidb_audio_unknown;
                        break;

                    case "vietnamese":
                        audio[i] = Resources.anidb_audio_vietnamese;
                        break;

                    case "japanese":
                        audio[i] = Resources.anidb_audio_japanese;
                        break;

                    case "english":
                        audio[i] = Resources.anidb_audio_english;
                        break;

                    default:
                        audio[i] = Resources.anidb_audio_unknown;
                        break;
                }

            var nWidth = 0;
            var nOffset = 0;

            for (var i = 0; i < langT.Length; i++)
                nWidth += audio[i].Width + 1;

            var imgR = new Bitmap(nWidth, audio[0].Height);

            using (var g = Graphics.FromImage(imgR))
            {
                for (var i = 0; i < langT.Length; i++)
                {
                    g.DrawImage(audio[i], new Point(nOffset, 0));
                    nOffset += audio[i].Width + 1;
                }

                g.Save();
            }

            return imgR;
        }

        //Ikonka pro titulky
        public static Image FilesLangSub(string lang)
        {
            lang = lang.ToLower();
            var langT = lang.Replace(" (unspecified)", "").Split('\'');
            var audio = new Image[langT.Length];

            for (var i = 0; i < langT.Length; i++)
                switch (langT[i])
                {
                    case "albanian":
                        audio[i] = Resources.anidb_sub_albanian;
                        break;

                    case "arabic":
                        audio[i] = Resources.anidb_sub_arabic;
                        break;

                    case "bengali":
                        audio[i] = Resources.anidb_sub_bengali;
                        break;

                    case "brasilian":
                        audio[i] = Resources.anidb_sub_brasilian;
                        break;

                    case "bulgarian":
                        audio[i] = Resources.anidb_sub_bulgarian;
                        break;

                    case "catalan":
                        audio[i] = Resources.anidb_sub_catalan;
                        break;

                    case "croatian":
                        audio[i] = Resources.anidb_sub_croatian;
                        break;

                    case "czech":
                        audio[i] = Resources.anidb_sub_czech;
                        break;

                    case "danish":
                        audio[i] = Resources.anidb_sub_danish;
                        break;

                    case "dutch":
                        audio[i] = Resources.anidb_sub_dutch;
                        break;

                    case "estonian":
                        audio[i] = Resources.anidb_sub_estonian;
                        break;

                    case "finnish":
                        audio[i] = Resources.anidb_sub_finnish;
                        break;

                    case "french":
                        audio[i] = Resources.anidb_sub_french;
                        break;

                    case "georgian":
                        audio[i] = Resources.anidb_sub_georgian;
                        break;

                    case "german":
                        audio[i] = Resources.anidb_sub_german;
                        break;

                    case "hebrew":
                        audio[i] = Resources.anidb_sub_hebrew;
                        break;

                    case "hungarian":
                        audio[i] = Resources.anidb_sub_hungarian;
                        break;

                    case "chinese":
                        audio[i] = Resources.anidb_sub_chinese;
                        break;

                    case "icelandic":
                        audio[i] = Resources.anidb_sub_icelandic;
                        break;

                    case "indonesian":
                        audio[i] = Resources.anidb_sub_indonesian;
                        break;

                    case "italian":
                        audio[i] = Resources.anidb_sub_italian;
                        break;

                    case "korean":
                        audio[i] = Resources.anidb_sub_korean;
                        break;

                    case "latin":
                        audio[i] = Resources.anidb_sub_latin;
                        break;

                    case "lithuanian":
                        audio[i] = Resources.anidb_sub_lithuanian;
                        break;

                    case "malay":
                        audio[i] = Resources.anidb_sub_malay;
                        break;

                    case "norwegian":
                        audio[i] = Resources.anidb_sub_norwegian;
                        break;

                    case "polish":
                        audio[i] = Resources.anidb_sub_polish;
                        break;

                    case "portuguese":
                        audio[i] = Resources.anidb_sub_portuguese;
                        break;

                    case "romania":
                        audio[i] = Resources.anidb_sub_romanian;
                        break;

                    case "serbian":
                        audio[i] = Resources.anidb_sub_serbian;
                        break;

                    case "simplified":
                        audio[i] = Resources.anidb_sub_simplified;
                        break;

                    case "slovak":
                        audio[i] = Resources.anidb_sub_slovak;
                        break;

                    case "slovenian":
                        audio[i] = Resources.anidb_sub_slovenian;
                        break;

                    case "spanish":
                        audio[i] = Resources.anidb_sub_spanish;
                        break;

                    case "swedish":
                        audio[i] = Resources.anidb_sub_swedish;
                        break;

                    case "taiwanese":
                        audio[i] = Resources.anidb_sub_taiwanese;
                        break;

                    case "tamil":
                        audio[i] = Resources.anidb_sub_tamil;
                        break;

                    case "tartar":
                        audio[i] = Resources.anidb_sub_tartar;
                        break;

                    case "thai":
                        audio[i] = Resources.anidb_sub_thai;
                        break;

                    case "traditional":
                        audio[i] = Resources.anidb_sub_traditional;
                        break;

                    case "turkish":
                        audio[i] = Resources.anidb_sub_turkish;
                        break;

                    case "ukrainian":
                        audio[i] = Resources.anidb_sub_ukrainian;
                        break;

                    case "unknown":
                        audio[i] = Resources.anidb_sub_unknown;
                        break;

                    case "vietnamese":
                        audio[i] = Resources.anidb_sub_vietnamese;
                        break;

                    case "japanese":
                        audio[i] = Resources.anidb_sub_japanese;
                        break;

                    case "english":
                        audio[i] = Resources.anidb_sub_english;
                        break;

                    default:
                        audio[i] = Resources.anidb_audio_unknown;
                        break;
                }

            var nWidth = 0;
            var nOffset = 0;

            for (var i = 0; i < langT.Length; i++)
                nWidth += audio[i].Width + 1;

            var imgR = new Bitmap(nWidth, audio[0].Height);

            using (var g = Graphics.FromImage(imgR))
            {
                for (var i = 0; i < langT.Length; i++)
                {
                    g.DrawImage(audio[i], new Point(nOffset, 0));
                    nOffset += audio[i].Width + 1;
                }

                g.Save();
            }

            return imgR;
        }

        //Zmenšit obrázek
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            var sourceWidth = imgToResize.Width;
            var sourceHeight = imgToResize.Height;

            float nPercent;

            var nPercentW = (size.Width/(float) sourceWidth);
            var nPercentH = (size.Height/(float) sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            if (nPercent > 1)
                nPercent = 1;

            var destWidth = (int) (sourceWidth*nPercent);
            var destHeight = (int) (sourceHeight*nPercent);

            var b = new Bitmap(destWidth, destHeight);
            var g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }
    }
}