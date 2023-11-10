using ERP_SOLUTION.Exceptions;
using System.Collections.Generic;
using System.IO;

namespace ERP_SOLUTION.Server.Operations
{
    internal class Op
    {
        /// <summary>
        /// List of all the tokkens connected to this server. 
        /// </summary>
        protected static List<Tokken> tokkens = new List<Tokken>();
        /// <summary>
        /// The current tokken used in the make function.
        /// </summary>
        protected static Tokken tokken;

        /// <summary>
        /// Apply this operation.
        /// </summary>
        /// <param name="read"></param>
        /// <param name="write"></param>
        public virtual void Make(BinaryReader read, BinaryWriter write, string ip)
        {
            tokken = null;
            byte[] tok = read.ReadBytes(20);
            for(int i = 0; i<tokkens.Count; i++)
            {
                if (tokkens[i] == tok && tokkens[i].Ip == ip)
                {
                    tokken = tokkens[i];
                    tokken.Update();
                    return;
                }
            }
            write.Write(false);
            write.Write(OpException.Login_Expired);
        }
    }
}
