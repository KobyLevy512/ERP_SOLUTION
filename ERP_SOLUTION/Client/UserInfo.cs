using System;
using System.Net.Sockets;
using System.Net;

namespace ERP_SOLUTION.Client
{
    internal class UserInfo
    {
        static byte[] tokken;
        static string user;
        static byte mode;
        static DateTime connectTime;

        /// <summary>
        /// Connect the user to the system and update the info about this user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="tokkens"></param>
        /// <param name="m"></param>
        public static void Connect(string username, byte[] tokkens, byte m)
        {
            tokken = tokkens;
            user = username;
            mode = m;
            connectTime = DateTime.Now;
        }
        public static byte[] Tokken
        {
            get
            {
                byte[] ret = new byte[tokken.Length];
                Buffer.BlockCopy(tokken, 0, ret, 0, tokken.Length);
                return ret;
            }
        }

        public static string User
        {
            get => user;
        }

        public static byte Mode
        {
            get => mode;
        }

        public static DateTime ConnectTime
        {
            get => connectTime;
        }

        public static string Ip
        {
            get
            {
                string localIp = "";
                try
                {
                    // Get the local machine's IP addresses
                    IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                    foreach (IPAddress ip in host.AddressList)
                    {
                        // Check for IPv4 addresses only
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            localIp = ip.ToString();
                            break;
                        }
                    }
                }
                catch
                {
                    
                }
                return localIp;
            }
        }
    }
}
