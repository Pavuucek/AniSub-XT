using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniDBClient.Utilities
{
    public static class StringHelpers
    {
        //Odstranění nechtěných znaků

        public static string RemoveUnesesaryStrings(string x)
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
    }
}
