using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace AniDBClient
{
    public class AniDBClient2
    {
        private string _ServerName;
        private int _ServerPort;
        private int _LocalPort;
        private int _TimeOut;
        private string[] _netGW;

        public Socket SocketAniDB;
        public IPHostEntry localHostEntry;
        public IPEndPoint localIpEndPoint;
        public IPHostEntry remoteHostEntry;
        public IPEndPoint remoteIpEndPoint;
        public IPHostEntry receivedHostEntry;
        public IPEndPoint receivedEndPoint;
        public EndPoint senderRemote;
        public EndPoint receiverRemote;
        public SocketMsgs _Status = SocketMsgs.S_DISCONNECT;

        public AniDBClient2(string serverName, int serverPort, int localPort, int timeOut, string netGW)
        {
            this._ServerName = serverName;
            this._ServerPort = serverPort;
            this._LocalPort = localPort;
            this._TimeOut = timeOut * 1000;
            this._netGW = netGW.Split(new string[] { " * " }, StringSplitOptions.None);
        }

        //Připojení k serveru
        public void Connnect()
        {
            try
            {
                this.SocketAniDB = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                SocketAniDB.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _TimeOut);
                SocketAniDB.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontRoute, true);
                SocketAniDB.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                                
                this.localHostEntry = Dns.GetHostByName(Dns.GetHostName());

                int k = 0;

                if (_netGW.Length == 3)
                {
                    for (int i = 0; i < this.localHostEntry.AddressList.Length; i++)
                    {
                        if (this.localHostEntry.AddressList[i].ToString() == _netGW[2])
                        {
                            k = i;
                            break;
                        }
                    }
                }

                this.localIpEndPoint = new IPEndPoint(this.localHostEntry.AddressList[k], this._LocalPort);
                this.senderRemote = (EndPoint)this.localIpEndPoint;
                this.SocketAniDB.Bind(this.localIpEndPoint);

                this.remoteHostEntry = Dns.GetHostByName(this._ServerName);
                this.remoteIpEndPoint = new IPEndPoint(this.remoteHostEntry.AddressList[0], this._ServerPort);
                this.receiverRemote = (EndPoint)this.remoteIpEndPoint;
                this.SocketAniDB.Connect(this.remoteIpEndPoint);

                _Status = SocketMsgs.S_CONNECT;
            }
            catch (Exception e)
            {
                Close();
            }
        }

        //Ze String do Byte
        public byte[] ConvertToByte (string message)
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

                int startTickCount = Environment.TickCount;
                int sent = 0;  // how many bytes is already sent
                do
                {
                    if (Environment.TickCount > startTickCount + this._TimeOut)
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

                int startTickCount = Environment.TickCount;
                int received = 0;  // how many bytes is already received
                do
                {
                    if (Environment.TickCount > startTickCount + this._TimeOut)
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
            else
            {
                _Status = SocketMsgs.S_DISCONNECT;
                return ConvertToByte("DISCONNECT");
            }
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
    }
}
