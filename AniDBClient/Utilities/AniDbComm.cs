using System.Threading;
using AniDBClient.Forms;

namespace AniDBClient.Utilities
{
    public class AniDbComm
    {
        private readonly Main _main;

        public AniDbComm(Main main)
        {
            _main = main;
        }

        public void Send(string message)
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

            var buffer = _main.aniDBClient.ConvertToByte(message);
            _main.aniDBClient.Send(buffer, 0, buffer.Length);
        }

        public string Receive()
        {
            if (_main.aniDBClient.SocketAniDb == null) return "";
            while (true)
            {
                Thread.Sleep(500);
                if (_main.aniDBClient.Status != AniDbClient2.SocketMsgs.SReceiveing)
                    break;
            }

            Thread.Sleep(500);

            var nBytesReceive = _main.aniDBClient.SocketAniDb.Available;

            var k = 0;

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

            var buffer = new byte[nBytesReceive];


            buffer = _main.aniDBClient.Receive(buffer, 0, nBytesReceive);

            var message = _main.aniDBClient.ConvertFromByte(buffer);

            if (message != null)
            {
                message = message.Replace("\0", "");
                message = message.Replace("\n", "\r\n");
            }
            else
                message = "";

            MessageParser(message);

            return message;
        }

        private void MessageParser(string message)
        {
            if (message != null)
            {
                if (message.Length > 0)
                {
                    if (message.Contains("\n"))
                    {
                        _main.AniDBStatus = AniDbMsgs.ANothing;

                        var T = message.Split('\n');

                        if (T[0].Contains("CONNECT"))
                            _main.AniDBStatus = AniDbMsgs.AConnect;

                        if (T[0].Contains("DISCONNECT"))
                            _main.AniDBStatus = AniDbMsgs.ADisconnect;

                        if (T[0].Contains("ILLEGAL INPUT"))
                            _main.AniDBStatus = AniDbMsgs.AIllegalInput;

                        if (T[0].Contains("BANNED"))
                            _main.AniDBStatus = AniDbMsgs.ABanned;

                        if (T[0].Contains("UNKNOWN COMMAND"))
                            _main.AniDBStatus = AniDbMsgs.AUnknownCommand;

                        if (T[0].Contains("INTERNAL SERVER ERROR"))
                            _main.AniDBStatus = AniDbMsgs.AInternalServerError;

                        if (T[0].Contains("OUT OF SERVICE"))
                            _main.AniDBStatus = AniDbMsgs.AOutOfService;

                        if (T[0].Contains("SERVER BUSY"))
                            _main.AniDBStatus = AniDbMsgs.AServerBusy;

                        if (T[0].Contains("LOGIN FIRST"))
                            _main.AniDBStatus = AniDbMsgs.ALoginFirst;

                        if (T[0].Contains("ACCESS DENIED"))
                            _main.AniDBStatus = AniDbMsgs.AAccessDenied;

                        if (T[0].Contains("INVALID SESSION"))
                            _main.AniDBStatus = AniDbMsgs.AInvalidSession;

                        if (T[0].Contains("ERROR"))
                            _main.AniDBStatus = AniDbMsgs.AError;

                        if (T[0].Contains("AUTH"))
                            _main.AniDBStatus = AniDbMsgs.AAuth;

                        if (T[0].Contains("A_AUTH"))
                            _main.AniDBStatus = AniDbMsgs.AServerBusy;

                        if (T[0].Contains("LOGOUT"))
                            _main.AniDBStatus = AniDbMsgs.ALogout;

                        if (T[0].Contains("LOGGED OUT"))
                            _main.AniDBStatus = AniDbMsgs.ALoggedOut;

                        if (T[0].Contains("LOGIN ACCEPTED"))
                            _main.AniDBStatus = AniDbMsgs.ALoginAccepted;

                        if (T[0].Contains("LOGIN ACCEPTED NEW VER"))
                            _main.AniDBStatus = AniDbMsgs.ALoginAcceptedNewVer;

                        if (T[0].Contains("LOGIN FAILED"))
                            _main.AniDBStatus = AniDbMsgs.ALoginFailed;

                        if (T[0].Contains("CLIENT BANNED"))
                            _main.AniDBStatus = AniDbMsgs.AClientBanned;

                        if (T[0].Contains("NOT LOGGED"))
                            _main.AniDBStatus = AniDbMsgs.ANotLogged;

                        if (T[0].Contains("NOTIFICATION ENABLED"))
                            _main.AniDBStatus = AniDbMsgs.ANotificationEnabled;

                        if (T[0].Contains("NOTIFICATION DISABLED"))
                            _main.AniDBStatus = AniDbMsgs.ANotificationDisabled;

                        if (T[0].Contains("NOTIFYLIST"))
                            _main.AniDBStatus = AniDbMsgs.ANotifyList;

                        if (T[0].Contains("NOTIFYGET"))
                            _main.AniDBStatus = AniDbMsgs.ANotifyGet;

                        if (T[0].Contains("NO SUCH ENTRY"))
                            _main.AniDBStatus = AniDbMsgs.ANoSuchEntry;

                        if (T[0].Contains("NOTIFYACK"))
                            _main.AniDBStatus = AniDbMsgs.ANotifyAck;

                        if (T[0].Contains("BUDDYDEL"))
                            _main.AniDBStatus = AniDbMsgs.ABuddyDel;

                        if (T[0].Contains("BUDDYACCEPT"))
                            _main.AniDBStatus = AniDbMsgs.ABuddyAccept;

                        if (T[0].Contains("BUDDYDENY"))
                            _main.AniDBStatus = AniDbMsgs.ABuddyDeny;

                        if (T[0].Contains("BUDDYLIST"))
                            _main.AniDBStatus = AniDbMsgs.ABuddyList;

                        if (T[0].Contains("ANIME"))
                            _main.AniDBStatus = AniDbMsgs.AAnime;

                        if (T[0].Contains("NO SUCH ANIME"))
                            _main.AniDBStatus = AniDbMsgs.ANoSuchAnime;

                        if (T[0].Contains("EPISODE"))
                            _main.AniDBStatus = AniDbMsgs.AEpisode;

                        if (T[0].Contains("NO SUCH EPISODE"))
                            _main.AniDBStatus = AniDbMsgs.ANoSuchEpisode;

                        if (T[0].Contains("FILE"))
                            _main.AniDBStatus = AniDbMsgs.AFile;

                        if (T[0].Contains("NO SUCH FILE"))
                            _main.AniDBStatus = AniDbMsgs.ANoSuchFile;

                        if (T[0].Contains("MULTIPLE FILES FOUND"))
                            _main.AniDBStatus = AniDbMsgs.AMultipleFilesFound;

                        if (T[0].Contains("GROUP"))
                            _main.AniDBStatus = AniDbMsgs.AGroup;

                        if (T[0].Contains("NO SUCH GROUP"))
                            _main.AniDBStatus = AniDbMsgs.ANoSuchGroup;

                        if (T[0].Contains("GROUPSTATUS"))
                            _main.AniDBStatus = AniDbMsgs.AGroupStatus;

                        if (T[0].Contains("MYLIST"))
                            _main.AniDBStatus = AniDbMsgs.AMylist;

                        if (T[0].Contains("NO SUCH MYLIST ENTRY"))
                            _main.AniDBStatus = AniDbMsgs.ANoSuchMylistEntry;

                        if (T[0].Contains("MULTIPLE MYLIST ENTRIES"))
                            _main.AniDBStatus = AniDbMsgs.AMultipleMylistEntries;

                        if (T[0].Contains("MYLISTADD"))
                            _main.AniDBStatus = AniDbMsgs.AMylistadd;

                        if (T[0].Contains("MYLIST ENTRY ADDED"))
                            _main.AniDBStatus = AniDbMsgs.AMylistEntryAdded;

                        if (T[0].Contains("FILE ALREADY IN MYLIST"))
                            _main.AniDBStatus = AniDbMsgs.AFileAlreadyInMylist;

                        if (T[0].Contains("MULTIPLE FILES FOUND"))
                            _main.AniDBStatus = AniDbMsgs.AMultipleFilesFound;

                        if (T[0].Contains("MYLISTDEL"))
                            _main.AniDBStatus = AniDbMsgs.AMylistdel;

                        if (T[0].Contains("MYLIST ENTRY DELETED"))
                            _main.AniDBStatus = AniDbMsgs.AMylistEntryDeleted;

                        if (T[0].Contains("MYLIST STATS"))
                            _main.AniDBStatus = AniDbMsgs.AMyliststats;

                        if (T[0].Contains("VOTE"))
                            _main.AniDBStatus = AniDbMsgs.AVote;

                        if (T[0].Contains("INVALID VOTE TYPE"))
                            _main.AniDBStatus = AniDbMsgs.AInvalidVoteType;

                        if (T[0].Contains("PERMVOTE NOT ALLOWED"))
                            _main.AniDBStatus = AniDbMsgs.APermvoteNotAllowed;

                        if (T[0].Contains("RANDOMANIME"))
                            _main.AniDBStatus = AniDbMsgs.ARandomAnime;

                        if (T[0].Contains("MYLISTEXPORT"))
                            _main.AniDBStatus = AniDbMsgs.AMylistExport;

                        if (T[0].Contains("PING"))
                            _main.AniDBStatus = AniDbMsgs.AVote;

                        if (T[0].Contains("PONG"))
                            _main.AniDBStatus = AniDbMsgs.APong;

                        if (T[0].Contains("VERSION"))
                            _main.AniDBStatus = AniDbMsgs.AVersion;

                        if (T[0].Contains("UPTIME"))
                            _main.AniDBStatus = AniDbMsgs.AUptime;

                        if (T[0].Contains("USER"))
                            _main.AniDBStatus = AniDbMsgs.AUser;

                        if (T[0].Contains("UNKNOWN COMMAND"))
                            _main.AniDBStatus = AniDbMsgs.AUnknownCommand;

                        if (T[0].Contains("LOGIN FIRST"))
                            _main.AniDBStatus = AniDbMsgs.ALoginFirst;

                        if (T[0].Contains("MYLIST ENTRY EDITED"))
                            _main.AniDBStatus = AniDbMsgs.AMylistEntryEdited;
                    }
                    else
                        _main.AniDBStatus = AniDbMsgs.ADisconnect;
                }
                else
                    _main.AniDBStatus = AniDbMsgs.ADisconnect;
            }
            else
                _main.AniDBStatus = AniDbMsgs.ADisconnect;
        }

        public void NewTask(string task)
        {
            if (!_main.LogTasks.Items.Contains(task))
            {
                _main.LogTasks.Items.Add(task);
                _main.StatusBar_Mn02.Text = _main.LogTasks.Items.Count.ToString();

                _main.db.DatabaseAdd("INSERT INTO task (task_task) VALUES ('" + task + "')");
            }
        }

        public void NewTaskKo(string task)
        {
            if (_main.LogTasks.Items.Contains(task)) return;
            _main.StatusBar_Mn02.Text = _main.LogTasks.Items.Count.ToString();
            _main.LogTasks.Items.Add(task);
        }
    }
}