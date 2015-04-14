using System.Threading;
using AniDBClient.Utilities;

namespace AniDBClient.Forms
{
    public class Communication
    {
        private Main _main;

        public Communication(Main main)
        {
            _main = main;
        }

        public void CommunicationSend(string message)
        {
            while (true)
            {
                if (_main.aniDBClient.Status != AniDbClient2.SocketMsgs.SSending)
                    break;

                Thread.Sleep(500);
            }

            if (!message.Contains("PING") &&
                !message.Contains("AUTH") &&
                !message.Contains("LOGOUT") &&
                !message.Contains("MYLISTSTATS"))
                message += "&s=" + _main.AniDBSessions;

            byte[] buffer = _main.aniDBClient.ConvertToByte(message);
            _main.aniDBClient.Send(buffer, 0, buffer.Length);
        }

        public string CommunicationReceive()
        {
            if (_main.aniDBClient.SocketAniDb != null)
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (_main.aniDBClient.Status != AniDbClient2.SocketMsgs.SReceiveing)
                        break;
                }

                Thread.Sleep(500);

                int nBytesReceive = _main.aniDBClient.SocketAniDb.Available;

                int k = 0;

                while (nBytesReceive == 0)
                {
                    nBytesReceive = _main.aniDBClient.SocketAniDb.Available;
                    Thread.Sleep(500);
                    k++;
                    if (k > 10)
                    {
                        nBytesReceive = 10240;
                        break;
                    }
                }

                byte[] buffer = new byte[nBytesReceive];


                buffer = _main.aniDBClient.Receive(buffer, 0, nBytesReceive);

                string message = _main.aniDBClient.ConvertFromByte(buffer);

                if (message != null)
                {
                    message = message.Replace("\0", "");
                    message = message.Replace("\n", "\r\n");
                }
                else
                    message = "";

                AniDBMsgsParser(message);

                return message;
            }

            return "";
        }

        private void AniDBMsgsParser(string message)
        {
            if (message != null)
            {
                if (message.Length > 0)
                {
                    if (message.Contains("\n"))
                    {
                        _main.AniDBStatus = AniDbMsgs.A__NOTHING_;

                        string[] T = message.Split('\n');

                        if (T[0].Contains("CONNECT"))
                            _main.AniDBStatus = AniDbMsgs.A_CONNECT;

                        if (T[0].Contains("DISCONNECT"))
                            _main.AniDBStatus = AniDbMsgs.A_DISCONNECT;

                        if (T[0].Contains("ILLEGAL INPUT"))
                            _main.AniDBStatus = AniDbMsgs.A_ILLEGAL_INPUT;

                        if (T[0].Contains("BANNED"))
                            _main.AniDBStatus = AniDbMsgs.A_BANNED;

                        if (T[0].Contains("UNKNOWN COMMAND"))
                            _main.AniDBStatus = AniDbMsgs.A_UNKNOWN_COMMAND;

                        if (T[0].Contains("INTERNAL SERVER ERROR"))
                            _main.AniDBStatus = AniDbMsgs.A_INTERNAL_SERVER_ERROR;

                        if (T[0].Contains("OUT OF SERVICE"))
                            _main.AniDBStatus = AniDbMsgs.A_OUT_OF_SERVICE;

                        if (T[0].Contains("SERVER BUSY"))
                            _main.AniDBStatus = AniDbMsgs.A_SERVER_BUSY;

                        if (T[0].Contains("LOGIN FIRST"))
                            _main.AniDBStatus = AniDbMsgs.A_LOGIN_FIRST;

                        if (T[0].Contains("ACCESS DENIED"))
                            _main.AniDBStatus = AniDbMsgs.A_ACCESS_DENIED;

                        if (T[0].Contains("INVALID SESSION"))
                            _main.AniDBStatus = AniDbMsgs.A_INVALID_SESSION;

                        if (T[0].Contains("ERROR"))
                            _main.AniDBStatus = AniDbMsgs.A_ERROR;

                        if (T[0].Contains("AUTH"))
                            _main.AniDBStatus = AniDbMsgs.A_AUTH;

                        if (T[0].Contains("A_AUTH"))
                            _main.AniDBStatus = AniDbMsgs.A_SERVER_BUSY;

                        if (T[0].Contains("LOGOUT"))
                            _main.AniDBStatus = AniDbMsgs.A_LOGOUT;

                        if (T[0].Contains("LOGGED OUT"))
                            _main.AniDBStatus = AniDbMsgs.A_LOGGED_OUT;

                        if (T[0].Contains("LOGIN ACCEPTED"))
                            _main.AniDBStatus = AniDbMsgs.A_LOGIN_ACCEPTED;

                        if (T[0].Contains("LOGIN ACCEPTED NEW VER"))
                            _main.AniDBStatus = AniDbMsgs.A_LOGIN_ACCEPTED_NEW_VER;

                        if (T[0].Contains("LOGIN FAILED"))
                            _main.AniDBStatus = AniDbMsgs.A_LOGIN_FAILED;

                        if (T[0].Contains("CLIENT BANNED"))
                            _main.AniDBStatus = AniDbMsgs.A_CLIENT_BANNED;

                        if (T[0].Contains("NOT LOGGED"))
                            _main.AniDBStatus = AniDbMsgs.A_NOT_LOGGED;

                        if (T[0].Contains("NOTIFICATION ENABLED"))
                            _main.AniDBStatus = AniDbMsgs.A_NOTIFICATION_ENABLED;

                        if (T[0].Contains("NOTIFICATION DISABLED"))
                            _main.AniDBStatus = AniDbMsgs.A_NOTIFICATION_DISABLED;

                        if (T[0].Contains("NOTIFYLIST"))
                            _main.AniDBStatus = AniDbMsgs.A_NOTIFYLIST;

                        if (T[0].Contains("NOTIFYGET"))
                            _main.AniDBStatus = AniDbMsgs.A_NOTIFYGET;

                        if (T[0].Contains("NO SUCH ENTRY"))
                            _main.AniDBStatus = AniDbMsgs.A_NO_SUCH_ENTRY;

                        if (T[0].Contains("NOTIFYACK"))
                            _main.AniDBStatus = AniDbMsgs.A_NOTIFYACK;

                        if (T[0].Contains("BUDDYDEL"))
                            _main.AniDBStatus = AniDbMsgs.A_BUDDYDEL;

                        if (T[0].Contains("BUDDYACCEPT"))
                            _main.AniDBStatus = AniDbMsgs.A_BUDDYACCEPT;

                        if (T[0].Contains("BUDDYDENY"))
                            _main.AniDBStatus = AniDbMsgs.A_BUDDYDENY;

                        if (T[0].Contains("BUDDYLIST"))
                            _main.AniDBStatus = AniDbMsgs.A_BUDDYLIST;

                        if (T[0].Contains("ANIME"))
                            _main.AniDBStatus = AniDbMsgs.A_ANIME;

                        if (T[0].Contains("NO SUCH ANIME"))
                            _main.AniDBStatus = AniDbMsgs.A_NO_SUCH_ANIME;

                        if (T[0].Contains("EPISODE"))
                            _main.AniDBStatus = AniDbMsgs.A_EPISODE;

                        if (T[0].Contains("NO SUCH EPISODE"))
                            _main.AniDBStatus = AniDbMsgs.A_NO_SUCH_EPISODE;

                        if (T[0].Contains("FILE"))
                            _main.AniDBStatus = AniDbMsgs.A_FILE;

                        if (T[0].Contains("NO SUCH FILE"))
                            _main.AniDBStatus = AniDbMsgs.A_NO_SUCH_FILE;

                        if (T[0].Contains("MULTIPLE FILES FOUND"))
                            _main.AniDBStatus = AniDbMsgs.A_MULTIPLE_FILES_FOUND;

                        if (T[0].Contains("GROUP"))
                            _main.AniDBStatus = AniDbMsgs.A_GROUP;

                        if (T[0].Contains("NO SUCH GROUP"))
                            _main.AniDBStatus = AniDbMsgs.A_NO_SUCH_GROUP;

                        if (T[0].Contains("GROUPSTATUS"))
                            _main.AniDBStatus = AniDbMsgs.A_GROUPSTATUS;

                        if (T[0].Contains("MYLIST"))
                            _main.AniDBStatus = AniDbMsgs.A_MYLIST;

                        if (T[0].Contains("NO SUCH MYLIST ENTRY"))
                            _main.AniDBStatus = AniDbMsgs.A_NO_SUCH_MYLIST_ENTRY;

                        if (T[0].Contains("MULTIPLE MYLIST ENTRIES"))
                            _main.AniDBStatus = AniDbMsgs.A_MULTIPLE_MYLIST_ENTRIES;

                        if (T[0].Contains("MYLISTADD"))
                            _main.AniDBStatus = AniDbMsgs.A_MYLISTADD;

                        if (T[0].Contains("MYLIST ENTRY ADDED"))
                            _main.AniDBStatus = AniDbMsgs.A_MYLIST_ENTRY_ADDED;

                        if (T[0].Contains("FILE ALREADY IN MYLIST"))
                            _main.AniDBStatus = AniDbMsgs.A_FILE_ALREADY_IN_MYLIST;

                        if (T[0].Contains("MULTIPLE FILES FOUND"))
                            _main.AniDBStatus = AniDbMsgs.A_MULTIPLE_FILES_FOUND;

                        if (T[0].Contains("MYLISTDEL"))
                            _main.AniDBStatus = AniDbMsgs.A_MYLISTDEL;

                        if (T[0].Contains("MYLIST ENTRY DELETED"))
                            _main.AniDBStatus = AniDbMsgs.A_MYLIST_ENTRY_DELETED;

                        if (T[0].Contains("MYLIST STATS"))
                            _main.AniDBStatus = AniDbMsgs.A_MYLISTSTATS;

                        if (T[0].Contains("VOTE"))
                            _main.AniDBStatus = AniDbMsgs.A_VOTE;

                        if (T[0].Contains("INVALID VOTE TYPE"))
                            _main.AniDBStatus = AniDbMsgs.A_INVALID_VOTE_TYPE;

                        if (T[0].Contains("PERMVOTE NOT ALLOWED"))
                            _main.AniDBStatus = AniDbMsgs.A_PERMVOTE_NOT_ALLOWED;

                        if (T[0].Contains("RANDOMANIME"))
                            _main.AniDBStatus = AniDbMsgs.A_RANDOMANIME;

                        if (T[0].Contains("MYLISTEXPORT"))
                            _main.AniDBStatus = AniDbMsgs.A_MYLISTEXPORT;

                        if (T[0].Contains("PING"))
                            _main.AniDBStatus = AniDbMsgs.A_VOTE;

                        if (T[0].Contains("PONG"))
                            _main.AniDBStatus = AniDbMsgs.A_PONG;

                        if (T[0].Contains("VERSION"))
                            _main.AniDBStatus = AniDbMsgs.A_VERSION;

                        if (T[0].Contains("UPTIME"))
                            _main.AniDBStatus = AniDbMsgs.A_UPTIME;

                        if (T[0].Contains("USER"))
                            _main.AniDBStatus = AniDbMsgs.A_USER;

                        if (T[0].Contains("UNKNOWN COMMAND"))
                            _main.AniDBStatus = AniDbMsgs.A_UNKNOWN_COMMAND;

                        if (T[0].Contains("LOGIN FIRST"))
                            _main.AniDBStatus = AniDbMsgs.A_LOGIN_FIRST;

                        if (T[0].Contains("MYLIST ENTRY EDITED"))
                            _main.AniDBStatus = AniDbMsgs.A_MYLIST_ENTRY_EDITED;
                    }
                    else
                        _main.AniDBStatus = AniDbMsgs.A_DISCONNECT;
                }
                else
                    _main.AniDBStatus = AniDbMsgs.A_DISCONNECT;
            }
            else
                _main.AniDBStatus = AniDbMsgs.A_DISCONNECT;
        }

        public void ComunicationNewTask(string Task)
        {
            if (!_main.LogTasks.Items.Contains(Task))
            {
                _main.LogTasks.Items.Add(Task);
                _main.StatusBar_Mn02.Text = _main.LogTasks.Items.Count.ToString();

                _main.db.DatabaseAdd("INSERT INTO task (task_task) VALUES ('" + Task + "')");
            }
        }

        public void ComunicationNewTaskKO(string Task)
        {
            if (!_main.LogTasks.Items.Contains(Task))
            {
                _main.StatusBar_Mn02.Text = _main.LogTasks.Items.Count.ToString();
                _main.LogTasks.Items.Add(Task);
            }
        }
    }
}