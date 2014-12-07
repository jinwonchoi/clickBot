using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

namespace WeDoCommon
{
    class SocketHandler
    {

        public event EventHandler<StringEventArgs> LogWriteHandler;

        public const int MYSQL_PORT = 3306;

        public bool SendUDP(int sendPort, string receiveIP, int receivePort, string msg)
        {
            byte[] data = new byte[1024];
            string input, output;
            bool result = false;

            try
            {
                IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, sendPort);
                IPEndPoint receiverEP = new IPEndPoint(IPAddress.Parse(receiveIP), receivePort);

                UdpClient senderSock = new UdpClient(senderEP);

                senderSock.Client.SendTimeout = 5000;
                senderSock.Client.ReceiveTimeout = 5000;

                input = "1|0001";// 공지사항 쿼리
                data = Encoding.UTF8.GetBytes(input);
                senderSock.Send(data, data.Length, receiverEP);
                OnWriteLog(string.Format("메시지전송 to {0}:{1}", receiverEP.ToString(), input));

                data = senderSock.Receive(ref receiverEP);

                output = Encoding.UTF8.GetString(data, 0, data.Length);
                OnWriteLog(string.Format("메시지전송확인 from {0}:{1}", receiverEP.ToString(), output));

                result = true;
            }
            catch (Exception e)
            {
                //CHOI_DEBUG 테스트위해 if막음
                //if (connected == true)
                OnWriteLog("전송 에러 : " + e.ToString());
            }

            return result;
        }

        public bool ReceiveUDP(int receivePort)
        {
            IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);// = new IPEndPoint(IPAddress.Any, 8883);
            IPEndPoint listenEP = new IPEndPoint(IPAddress.Any, receivePort);
            UdpClient listenSock = new UdpClient(listenEP);
            bool result = false;
            byte[] buffer = null;

            listenSock.Client.SendTimeout = 5000;
            listenSock.Client.ReceiveTimeout = 5000;

            try
            {

                while (true)
                {
                    OnWriteLog("응답 수신대기 ");
                    if (listenSock != null)
                    {
                        buffer = listenSock.Receive(ref senderEP);
                    }
                    OnWriteLog("수신! ");
                    if (buffer != null && buffer.Length != 0)
                    {
                        OnWriteLog(string.Format("sender IP[{0}] poert[{1}] : "
                            , senderEP.Address.ToString()
                            , senderEP.Port.ToString()));

                        listenSock.Send(buffer, buffer.Length, senderEP);  //정상적으로 메시지 수신하면 응답(udp통신의 실패방지)

                        string msg = Encoding.UTF8.GetString(buffer);

                        OnWriteLog("수신 메시지 : " + msg);
                    }
                    break;
                }
                result = true;
            }
            catch (Exception e)
            {
                //CHOI_DEBUG 테스트위해 if막음
                //if (connected == true)
                OnWriteLog("수신 에러 : " + e.ToString());
            }

            return result;
        }

        public bool SendTCP(string receiveIP, int receivePort, string msg, bool needReceive)
        {
            bool result = false;
            TcpClient client = null;
            NetworkStream stream = null;
            try
            {
                client = new TcpClient(receiveIP, receivePort);
                client.ReceiveTimeout = 5000;

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = Encoding.UTF8.GetBytes(msg);

                stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                OnWriteLog(string.Format("메시지전송[{0}] 포트[{1}]", msg, receivePort));

                if (needReceive)
                {
                    data = new Byte[256];
                    String responseData = String.Empty;

                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = Encoding.UTF8.GetString(data, 0, bytes);
                    OnWriteLog(string.Format("메시지수신: {0}", responseData));
                }
                result = true;
            }
            catch (Exception e)
            {
                OnWriteLog("TCP 전송에러 : " + e.ToString());

            }
            finally
            {
                if (client != null) client.Close();
                if (stream != null) stream.Close();
            }
            return result;

        }

        public bool IsUdpPortInUse(int port)
        {
            bool result = false;
            Socket socket = null;
            try
            {
                string strIP = "0.0.0.0";

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                IPAddress ip = IPAddress.Parse(strIP);
                IPEndPoint endPoint = new IPEndPoint(ip, port);

                socket.Bind(endPoint);
            }
            catch (Exception ex)
            {
                OnWriteLog(string.Format("port[{0}]는 이미 사용중.", port) + ex.ToString());
                result = true;
            }
            finally
            {
                if (socket != null)
                {
                    socket.Close();
                }
            }
            return result;
        }


        public bool IsTcpPortInUse(int port)
        {
            bool result = false;
            string server = "127.0.0.1";
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(server, port);
                    result = true;
                }
                catch (SocketException ex)
                {
                    OnWriteLog(string.Format("port[{0}]는 이미 사용중.", port) + ex.ToString());
                }
                finally
                {
                    client.Close();
                }
                return result;
            }
        }


        public virtual void OnWriteLog(string msg)
        {
            EventHandler<StringEventArgs> handler = this.LogWriteHandler;
            if (this.LogWriteHandler != null)
            {
                handler(this, new StringEventArgs(msg));
            }
        }
    }

}
