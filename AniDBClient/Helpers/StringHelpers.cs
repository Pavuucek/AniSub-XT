namespace AniDBClient.Helpers
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
