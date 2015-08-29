using System;
using System.IO;
using System.Text;

namespace AniDBClient.Utilities
{
    public class Logger
    {
        private readonly StreamWriter _logAniDb;
        private readonly StreamWriter _logError;
        private readonly StreamWriter _logSql;

        public Logger(string writePath)
        {
            if (_logAniDb != null)
                _logAniDb.Close();

            if (_logSql != null)
                _logSql.Close();

            if (_logError != null)
                _logError.Close();
            // soubor.Directory.FullName
            _logAniDb = new StreamWriter(writePath + @"\L-AniDB.Log", true, Encoding.UTF8);
            _logSql = new StreamWriter(writePath + @"\L-SQL.Log", true, Encoding.UTF8);
            _logError = new StreamWriter(writePath + @"\L-Error.Log", true, Encoding.UTF8);
            WriteAniDbLog = true;
            WriteErrorLog = true;
            WriteSqlLog = true;
            AniDbLog = string.Empty;
            ErrorLog = string.Empty;
            SqlLog = string.Empty;
        }

        public bool Enabled { get; set; }
        public bool WriteSqlLog { get; set; }
        public bool WriteAniDbLog { get; set; }
        public bool WriteErrorLog { get; set; }
        public string SqlLog { get; set; }
        public string ErrorLog { get; set; }
        public string AniDbLog { get; set; }
        //Logování AniDB
        public void LogAdd(string messageString)
        {
            /*if (LogSQL.Text.Length + MessageString.Length > LogSQL.MaxLength)
                Log.Text = "";*/

            AniDbLog = LogTime() + messageString + "\r\n\r\n" + AniDbLog;

            if (WriteAniDbLog)
            {
                _logAniDb.WriteLine(LogTime() + messageString);
                _logAniDb.WriteLine();
                _logAniDb.Flush();
            }
        }

        //Logování SQL
        public void LogAddSql(string messageString)
        {
            /*if (LogSQL.Text.Length + MessageString.Length > LogSQL.MaxLength)
                LogSQL.Text = "";

            LogSQL.Text = LogTime() + MessageString + "\r\n\r\n" + LogSQL.Text;*/
            SqlLog = LogTime() + messageString + "\r\n\r\n" + SqlLog;

            if (WriteSqlLog)
            {
                _logSql.WriteLine(LogTime() + messageString);
                _logSql.WriteLine();
                _logSql.Flush();
            }
        }

        //Získej čas
        public string LogTime()
        {
            return "[" + DateTime.Now.ToShortDateString().Replace(" ", "") + " " + DateTime.Now.ToShortTimeString() +
                   "]\r\n";
        }

        //Logování Eroor
        public void LogAddError(string messageString)
        {
            try
            {
                /*if (LogSQL.Text.Length + MessageString.Length > LogSQL.MaxLength)
                    LogError.Text = "";

                LogError.Text = LogTime() + MessageString + "\r\n\r\n" + LogError.Text;*/
                ErrorLog = LogTime() + messageString + "\r\n\r\n" + ErrorLog;
                if (WriteErrorLog)
                {
                    _logError.WriteLine(LogTime() + messageString);
                    _logError.WriteLine();
                    _logError.Flush();
                }
            }
            catch
            {
            }
        }
    }
}