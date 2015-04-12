using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AniDBClient
{
    public class AniDBClient2
    {
        //Zprávy
        public enum SocketMsgs
        {
            S_DISCONNECT = 0x0000,
            S_CONNECT = 0x0001,
            S_SEND = 0x0002,
            S_RECEIVE = 0x0003,
            S_SENDING = 0x0004,
            S_RECEIVEING = 0x0005
        }

        public SocketMsgs _Status = SocketMsgs.S_DISCONNECT;
        public IPHostEntry localHostEntry;
        public IPEndPoint localIpEndPoint;
        public IPEndPoint receivedEndPoint;
        public IPHostEntry receivedHostEntry;
        public EndPoint receiverRemote;
        public IPHostEntry remoteHostEntry;
        public IPEndPoint remoteIpEndPoint;
        public EndPoint senderRemote;
        public Socket SocketAniDB;
        private readonly int _LocalPort;
        private readonly string[] _netGW;
        private readonly string _ServerName;
        private readonly int _ServerPort;
        private readonly int _TimeOut;

        public AniDBClient2(string serverName, int serverPort, int localPort, int timeOut, string netGW)
        {
            _ServerName = serverName;
            _ServerPort = serverPort;
            _LocalPort = localPort;
            _TimeOut = timeOut*1000;
            _netGW = netGW.Split(new[] {" * "}, StringSplitOptions.None);
        }

        //Připojení k serveru
        public void Connnect()
        {
            try
            {
                SocketAniDB = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                SocketAniDB.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _TimeOut);
                SocketAniDB.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontRoute, true);
                SocketAniDB.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                localHostEntry = Dns.GetHostByName(Dns.GetHostName());

                var k = 0;

                if (_netGW.Length == 3)
                {
                    for (var i = 0; i < localHostEntry.AddressList.Length; i++)
                    {
                        if (localHostEntry.AddressList[i].ToString() == _netGW[2])
                        {
                            k = i;
                            break;
                        }
                    }
                }

                localIpEndPoint = new IPEndPoint(localHostEntry.AddressList[k], _LocalPort);
                senderRemote = localIpEndPoint;
                SocketAniDB.Bind(localIpEndPoint);

                remoteHostEntry = Dns.GetHostByName(_ServerName);
                remoteIpEndPoint = new IPEndPoint(remoteHostEntry.AddressList[0], _ServerPort);
                receiverRemote = remoteIpEndPoint;
                SocketAniDB.Connect(remoteIpEndPoint);

                _Status = SocketMsgs.S_CONNECT;
            }
            catch (Exception e)
            {
                Close();
            }
        }

        //Ze String do Byte
        public byte[] ConvertToByte(string message)
        {
            return Encoding.UTF8.GetBytes(message.ToCharArray());
        }

        //Z Byte do String
        public string ConvertFromByte(byte[] buffer)
        {
            return Encoding.UTF8.GetString(buffer);
        }

        //Odeslání dat
        public void Send(byte[] buffer, int offset, int size)
        {
            if (SocketAniDB != null)
            {
                _Status = SocketMsgs.S_SENDING;

                var startTickCount = Environment.TickCount;
                var sent = 0; // how many bytes is already sent
                do
                {
                    if (Environment.TickCount > startTickCount + _TimeOut)
                        break;
                    try
                    {
                        sent += SocketAniDB.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.WouldBlock ||
                            ex.SocketErrorCode == SocketError.IOPending ||
                            ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                        {
                            // socket buffer is probably full, wait and try again
                            Thread.Sleep(30);
                        }
                    }
                } while (sent < size);

                _Status = SocketMsgs.S_SEND;
            }
            else
                _Status = SocketMsgs.S_DISCONNECT;
        }

        //Příjem dat
        public byte[] Receive(byte[] buffer, int offset, int size)
        {
            if (SocketAniDB.Connected)
            {
                _Status = SocketMsgs.S_RECEIVEING;

                var startTickCount = Environment.TickCount;
                var received = 0; // how many bytes is already received
                do
                {
                    if (Environment.TickCount > startTickCount + _TimeOut)
                        break;
                    try
                    {
                        received += SocketAniDB.Receive(buffer, offset + received, size - received, SocketFlags.None);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.WouldBlock ||
                            ex.SocketErrorCode == SocketError.IOPending ||
                            ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                        {
                            // socket buffer is probably empty, wait and try again
                            Thread.Sleep(30);
                        }
                    }
                } while (received < size);

                _Status = SocketMsgs.S_RECEIVE;

                return buffer;
            }
            _Status = SocketMsgs.S_DISCONNECT;
            return ConvertToByte("DISCONNECT");
        }

        //Ukončení spojení
        public void Close()
        {
            try
            {
                SocketAniDB.Shutdown(SocketShutdown.Both);
                SocketAniDB.Close();
                SocketAniDB = null;
            }
            catch
            {
                SocketAniDB = null;
            }

            _Status = SocketMsgs.S_DISCONNECT;
        }
    }
}