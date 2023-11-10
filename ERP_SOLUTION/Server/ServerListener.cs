using ERP_SOLUTION.Exceptions;
using ERP_SOLUTION.Server.Operations;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ERP_SOLUTION.Server
{
    internal class ServerListener
    {
        TcpListener listener;
        bool stop = true;
        Op[] operations =
        {
            new LoginOp(),
            new CreateProgramOp()
        };
        public ServerListener(string ip, int port) 
        {
            try
            {
                IPAddress address = IPAddress.Parse(ip);
            }
            catch 
            {
                throw new IpException(ip);
            }
            try
            {
                listener = new TcpListener(IPAddress.Parse(ip), port);
            }
            catch
            {
                throw new ServerListenerException();
            }

        }
        /// <summary>
        /// Start the server and wait for request to responce
        /// </summary>
        public void Start()
        {
            listener.Start();
            stop = false;
            while (!stop)
            {
                TcpClient client;
                NetworkStream stream;
                try
                {
                    client = listener.AcceptTcpClient();
                    stream = client.GetStream();
                    BinaryReader reader = new BinaryReader(stream);
                    BinaryWriter writte = new BinaryWriter(new MemoryStream());
                    try
                    {
                        operations[reader.ReadByte()].Make(reader, writte, ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
                    }
                    catch
                    {
                        writte.Write(false);
                        writte.Write(OpException.Packet_Error);
                    }
                    byte[] sendBuffer = new byte[writte.BaseStream.Length];
                    writte.BaseStream.Read(sendBuffer, 0, sendBuffer.Length);
                    writte.BaseStream.Close();
                    writte.Close();
                    stream.Write(sendBuffer, 0, sendBuffer.Length);
                }
                catch
                {
                    continue;
                }
            }
        }
        /// <summary>
        /// Stop the server for requests
        /// </summary>
        public void Stop()
        {
            stop = true;
            listener.Stop();
        }
    }
}
