using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AniDBClient.Utilities
{
    public class AniDbClient2
    {
        //Zprávy
        public enum SocketMsgs
        {
            SDisconnect = 0x0000,
            SConnect = 0x0001,
            SSend = 0x0002,
            SReceive = 0x0003,
            SSending = 0x0004,
            SReceiveing = 0x0005
        }

        public SocketMsgs Status = SocketMsgs.SDisconnect;
        public IPHostEntry LocalHostEntry;
        public IPEndPoint LocalIpEndPoint;
        public IPEndPoint ReceivedEndPoint;
        public IPHostEntry ReceivedHostEntry;
        public EndPoint ReceiverRemote;
        public IPHostEntry RemoteHostEntry;
        public IPEndPoint RemoteIpEndPoint;
        public EndPoint SenderRemote;
        public Socket SocketAniDb;
        private readonly int _localPort;
        private readonly string[] _netGw;
        private readonly string _serverName;
        private readonly int _serverPort;
        private readonly int _timeOut;

        public AniDbClient2(string serverName, int serverPort, int localPort, int timeOut, string netGW)
        {
            _serverName = serverName;
            _serverPort = serverPort;
            _localPort = localPort;
            _timeOut = timeOut*1000;
            _netGw = netGW.Split(new[] {" * "}, StringSplitOptions.None);
        }

        //Připojení k serveru
        public void Connnect()
        {
            try
            {
                SocketAniDb = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                SocketAniDb.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _timeOut);
                SocketAniDb.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontRoute, true);
                SocketAniDb.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                LocalHostEntry = Dns.GetHostByName(Dns.GetHostName());

                var k = 0;

                if (_netGw.Length == 3)
                {
                    for (var i = 0; i < LocalHostEntry.AddressList.Length; i++)
                    {
                        if (LocalHostEntry.AddressList[i].ToString() == _netGw[2])
                        {
                            k = i;
                            break;
                        }
                    }
                }

                LocalIpEndPoint = new IPEndPoint(LocalHostEntry.AddressList[k], _localPort);
                SenderRemote = LocalIpEndPoint;
                SocketAniDb.Bind(LocalIpEndPoint);

                RemoteHostEntry = Dns.GetHostByName(_serverName);
                RemoteIpEndPoint = new IPEndPoint(RemoteHostEntry.AddressList[0], _serverPort);
                ReceiverRemote = RemoteIpEndPoint;
                SocketAniDb.Connect(RemoteIpEndPoint);

                Status = SocketMsgs.SConnect;
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
            if (SocketAniDb != null)
            {
                Status = SocketMsgs.SSending;

                var startTickCount = Environment.TickCount;
                var sent = 0; // how many bytes is already sent
                do
                {
                    if (Environment.TickCount > startTickCount + _timeOut)
                        break;
                    try
                    {
                        sent += SocketAniDb.Send(buffer, offset + sent, size - sent, SocketFlags.None);
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

                Status = SocketMsgs.SSend;
            }
            else
                Status = SocketMsgs.SDisconnect;
        }

        //Příjem dat
        public byte[] Receive(byte[] buffer, int offset, int size)
        {
            if (SocketAniDb.Connected)
            {
                Status = SocketMsgs.SReceiveing;

                var startTickCount = Environment.TickCount;
                var received = 0; // how many bytes is already received
                do
                {
                    if (Environment.TickCount > startTickCount + _timeOut)
                        break;
                    try
                    {
                        received += SocketAniDb.Receive(buffer, offset + received, size - received, SocketFlags.None);
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

                Status = SocketMsgs.SReceive;

                return buffer;
            }
            Status = SocketMsgs.SDisconnect;
            return ConvertToByte("DISCONNECT");
        }

        //Ukončení spojení
        public void Close()
        {
            try
            {
                SocketAniDb.Shutdown(SocketShutdown.Both);
                SocketAniDb.Close();
                SocketAniDb = null;
            }
            catch
            {
                SocketAniDb = null;
            }

            Status = SocketMsgs.SDisconnect;
        }
    }
}