using ERP_SOLUTION.Security;
using System.IO;

namespace ERP_SOLUTION.Server.Operations
{
    internal class LoginOp : Op
    {
        public override void Make(BinaryReader read, BinaryWriter write)
        {
            string user = read.ReadString();
            string password = read.ReadString();
            byte mode = read.ReadByte();
            if (Crypto.Instance.UserExist(user, password, mode))
            {
                Tokken tokken = Tokken.Generate(mode);
                tokken.OnTerminate += (Tokken sender) => tokkens.Remove(sender);
                tokkens.Add(tokken);
                write.Write(true);
                write.Write(tokken.data);
            }
            else
            {
                write.Write(false);
            }
        }
    }
}
