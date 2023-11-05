using ERP_SOLUTION.Exceptions;
using ERP_SOLUTION.Server;
using System.IO;
using System.Net.Sockets;

namespace ERP_SOLUTION.Client
{
    internal class ClientListener
    {
        public static ClientListener Instance;
        TcpClient client;
        NetworkStream stream;
        public ClientListener(string server, int port)
        {
            try
            {
                client = new TcpClient(server, port);
                stream = client.GetStream();
            }
            catch
            {
                throw new ServerNotExistException(server, port);
            }
            Instance = this;
        }

        //Send packet to the server stream.
        void SendPacket(BinaryWriter w)
        {
            byte[] sendBuffer = new byte[w.BaseStream.Length];
            w.BaseStream.Read(sendBuffer, 0, sendBuffer.Length);
            w.BaseStream.Close();
            w.Close();
            stream.Write(sendBuffer, 0, sendBuffer.Length);
        }

        /// <summary>
        /// Send login request to the server.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(byte mode, string user, string password)
        {
            BinaryWriter s = new BinaryWriter(new MemoryStream());
            s.Write((byte)0);
            s.Write(mode);
            s.Write(user);
            s.Write(password);
            SendPacket(s);

            BinaryReader reader = new BinaryReader(stream);
            bool ret = reader.ReadBoolean();
            if(ret)
            {
                UserInfo.Connect(user, reader.ReadBytes(Tokken.TOKKEN_LENGTH), mode);
                return true;
            }
            return false;
        }
    }
}
