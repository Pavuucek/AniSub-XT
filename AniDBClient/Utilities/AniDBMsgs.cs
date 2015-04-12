using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniDBClient.Utilities
{
    #region AniDbMsgs
    //Zprávy
    public enum AniDbMsgs
    {
        A__NOTHING_ = 0x1000,
        A_DISCONNECT = 0x0000,
        A_CONNECT = 0x0001,
        A_ILLEGAL_INPUT = 0x0002,
        A_BANNED = 0x0003,
        A_UNKNOWN_COMMAND = 0x0004,
        A_INTERNAL_SERVER_ERROR = 0x0005,
        A_OUT_OF_SERVICE = 0x0006,
        A_SERVER_BUSY = 0x0007,
        A_LOGIN_FIRST = 0x0008,
        A_ACCESS_DENIED = 0x0009,
        A_INVALID_SESSION = 0x0010,
        A_ERROR = 0x0011,
        A_AUTH = 0x0012,
        A_LOGOUT = 0x0013,
        A_LOGIN_ACCEPTED = 0x0014,
        A_LOGIN_FAILED = 0x0015,
        A_VERSION_OUTDATED = 0x0016,
        A_CLIENT_BANNED = 0x0017,
        A_NOT_LOGGED = 0x0018,
        A_NOTIFICATION_ENABLED = 0x0019,
        A_NOTIFICATION_DISABLED = 0x0020,
        A_NOTIFYLIST = 0x0021,
        A_NOTIFYGET = 0x0022,
        A_NO_SUCH_ENTRY = 0x0023,
        A_NOTIFYACK = 0x0024,
        A_BUDDYADD = 0x0025,
        A_BUDDYDEL = 0x0026,
        A_BUDDYACCEPT = 0x0027,
        A_BUDDYDENY = 0x0028,
        A_BUDDYLIST = 0x0029,
        A_ANIME = 0x0030,
        A_NO_SUCH_ANIME = 0x0031,
        A_ANIMEDESC = 0x0032,
        A_EPISODE = 0x0033,
        A_NO_SUCH_EPISODE = 0x0034,
        A_FILE = 0x0035,
        A_NO_SUCH_FILE = 0x0036,
        A_MULTIPLE_FILES_FOUND = 0x0037,
        A_GROUP = 0x0038,
        A_NO_SUCH_GROUP = 0x0039,
        A_GROUPSTATUS = 0x0040,
        A_MYLIST = 0x0041,
        A_MULTIPLE_MYLIST_ENTRIES = 0x0042,
        A_MYLISTADD = 0x0043,
        A_MYLIST_ENTRY_ADDED = 0x0044,
        A_FILE_ALREADY_IN_MYLIST = 0x0045,
        A_USER = 0x0046,
        A_MYLIST_ENTRY_EDITED = 0x0047,
        A_MYLISTDEL = 0x0048,
        A_MYLIST_ENTRY_DELETED = 0x0049,
        A_MYLISTSTATS = 0x0050,
        A_VOTE = 0x0051,
        A_INVALID_VOTE_TYPE = 0x0052,
        A_PERMVOTE_NOT_ALLOWED = 0x0053,
        A_ALREADY_PERMVOTED = 0x0054,
        A_RANDOMANIME = 0x0055,
        A_MYLISTEXPORT = 0x0056,
        A_PING = 0x0057,
        A_PONG = 0x0058,
        A_VERSION = 0x0059,
        A_UPTIME = 0x0060,
        A_NO_SUCH_MYLIST_ENTRY = 0x0061,
        A_LOGGED_OUT = 0x0062,
        A_LOGIN_ACCEPTED_NEW_VER = 0x0063
    }
    #endregion
}
