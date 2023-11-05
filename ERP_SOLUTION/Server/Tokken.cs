using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERP_SOLUTION.Server
{
    internal class Tokken
    {
        public delegate void TerminateTokken(Tokken sender);
        /// <summary>
        /// Represent the tokken string length.
        /// </summary>
        public const byte TOKKEN_LENGTH = 20;
        /// <summary>
        /// Calculate the time of user without use of the server.
        /// If the time is reach than is going to log out this user.
        /// </summary>
        public const byte LOG_OUT_TIME = 1; //Log out the tokken after 1 minute

        /// <summary>
        /// Event occured on the tokken has reach expiration time
        /// </summary>
        public event TerminateTokken OnTerminate;
        /// <summary>
        /// The data of the tokken
        /// </summary>
        public byte[] data;
        /// <summary>
        /// Last request from server time
        /// </summary>
        DateTime lastRequest;
        /// <summary>
        /// Which mode this tokken is assign to.
        /// Production / Test / Development.
        /// </summary>
        public byte Mode = 255;
        public Tokken(byte[] data)
        {
            this.data = data;
            lastRequest = DateTime.Now;
            Task.Run(() =>
            {
                while(true)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(LOG_OUT_TIME - (DateTime.Now - lastRequest).TotalMinutes));
                    if ((DateTime.Now - lastRequest).TotalMinutes >= LOG_OUT_TIME)
                    {
                        OnTerminate?.Invoke(this);
                        break;
                    }
                }
            });
        }

        /// <summary>
        /// Update last request time from the sever of this tokken.
        /// </summary>
        public void Update()
        {
            lastRequest = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if(obj is Tokken)
            {
                return this == (Tokken)obj;
            }
            if(obj is byte[])
            {
                return this == (byte[])obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Generate a random tokken.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Tokken Generate(byte mode)
        {
            Random rnd = new Random();
            string ret = "";
            for (int i = 0; i < TOKKEN_LENGTH; i++)
            {
                ret += ((char)rnd.Next(36, 126)).ToString();
            }
            return new Tokken(Encoding.ASCII.GetBytes(ret)) { Mode = mode };
        }
        public static bool operator ==(Tokken x, byte[] y)
        {
            if (x.data.Length != y.Length) return false;
            for (int i = 0; i < x.data.Length; i++)
            {
                if (x.data[i] != y[i]) return false;
            }
            return true;
        }
        public static bool operator !=(Tokken x, byte[] y)
        {
            return !(x == y);
        }
        public static bool operator ==( Tokken x, Tokken y )
        {
            if (x.data.Length != y.data.Length) return false;
            for(int i = 0; i<x.data.Length; i++)
            {
                if (x.data[i] != y.data[i]) return false;
            }
            return true;
        }
        public static bool operator !=(Tokken x, Tokken y)
        {
            return !(x == y);
        }
    }
}
