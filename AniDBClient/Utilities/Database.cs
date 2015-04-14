using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using AniDBClient.Lang;

namespace AniDBClient.Utilities
{
    public class Database
    {
        private const int OdbcAddDsn = 1;
        public OleDbConnection AniDbDatabase;
        public Logger LoggerE { get; set; }

        [DllImport("ODBCCP32.DLL", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SQLConfigDataSource(IntPtr parent, int request, string driver, string attributes);

        //Formát data
        public static string DateFormat(DateTime datum)
        {
            return datum.Year + "-" + string.Format("{0:00}", datum.Month) + "-" + string.Format("{0:00}", datum.Day) +
                   " " + string.Format("{0:00}", datum.Hour) + ":" + string.Format("{0:00}", datum.Minute) + ":" +
                   string.Format("{0:00}", datum.Second);
        }

        //Komprimace databáze
        public void DatabaseCompact(string mdbFileName)
        {
            AniDbDatabase.Close();
            try
            {
                var cmd = string.Format("COMPACT_DB=\"{0}\" \"{0}\" General\0", mdbFileName);
                SQLConfigDataSource((IntPtr) 0, OdbcAddDsn, "Microsoft Access Driver (*.mdb)", cmd);

                LoggerE.LogAddError("DB > D A T A B A S E   W A S   C O M P R I M E D");
            }
            catch
            {
                LoggerE.LogAdd(Language.MessageBox_DBC);
            }
            AniDbDatabase.Open();
        }

        //Přidání/editace/mazání z/do databáze - VOID
        public void DatabaseAdd(string sqlString)
        {
            LoggerE.LogAddSql("MySQL > " + sqlString);

            var sqlCommand = new OleDbCommand();
            sqlCommand.CommandText = sqlString;
            sqlCommand.Connection = AniDbDatabase;

            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                LoggerE.LogAddError("MySQL ERROR > " + sqlString + "\r\n" + e);
            }

            sqlCommand.Dispose();
            AniDbDatabase.ResetState();
        }

        //Výběr z databáze
        public DataTable DatabaseSelect(string sqlString)
        {
            if (AniDbDatabase != null)
            {
                LoggerE.LogAddSql("MySQL < " + sqlString);

                var sqlQuery = new OleDbCommand();
                sqlQuery.CommandText = sqlString;
                sqlQuery.Connection = AniDbDatabase;
                sqlQuery.CommandTimeout = 30;

                var data = new DataTable();

                var dataAdapter = new OleDbDataAdapter(sqlQuery);

                try
                {
                    dataAdapter.Fill(data);
                }
                catch (Exception e)
                {
                    LoggerE.LogAddError("MySQL ERROR > " + sqlString + "\r\n" + e);
                }

                sqlQuery.Dispose();
                AniDbDatabase.ResetState();
                return data;
            }

            return new DataTable();
        }

        //Přidání/editace/mazání z/do databáze - VOID
        public void DatabaseAddNoLog(string sqlString)
        {
            AniDbDatabase.ResetState();

            var sqlCommand = new OleDbCommand();
            sqlCommand.CommandText = sqlString;
            sqlCommand.Connection = AniDbDatabase;

            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                LoggerE.LogAddError("MySQL ERROR > " + sqlString + "\r\n" + e);
            }

            sqlCommand.Dispose();

            AniDbDatabase.ResetState();
        }

        //Výběr z databáze
        public DataTable DatabaseSelectNoLog(string sqlString)
        {
            if (AniDbDatabase != null)
            {
                var sqlQuery = new OleDbCommand();
                sqlQuery.CommandText = sqlString;
                sqlQuery.Connection = AniDbDatabase;
                sqlQuery.CommandTimeout = 30;

                var data = new DataTable();

                var dataAdapter = new OleDbDataAdapter(sqlQuery);

                try
                {
                    dataAdapter.Fill(data);
                }
                catch (Exception e)
                {
                    LoggerE.LogAddError("MySQL ERROR > " + sqlString + "\r\n" + e);
                }

                sqlQuery.Dispose();
                return data;
            }

            return new DataTable();
        }
    }
}