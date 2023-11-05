using ERP_SOLUTION.Exceptions;
using System.IO;

namespace ERP_SOLUTION.Server.Operations
{
    internal class CreateProgramOp : Op
    {
        public override void Make(BinaryReader read, BinaryWriter write)
        {
            base.Make(read, write);
            if (tokken.Equals(null)) return;
            if(tokken.Mode != 2)
            {
                write.Write(false);
                write.Write(OpException.Permission);
                return;
            }
            string name = read.ReadString();
            string fullPath = Login.Instance.ServerPath + "\\Programs\\Sources" + name + ".cs";
            if(File.Exists(fullPath))
            {
                write.Write(false);
                write.Write(OpException.File_Exist);
            }
            StreamWriter s = File.CreateText(fullPath);
            s.Write(Properties.Resources.EmptyTransaction);
            //s.WriteLine("using System;");
            //s.WriteLine();
            //s.WriteLine("namespace " + name);
            //s.WriteLine("{");
            //s.WriteLine("\tpublic class Program");
            //s.WriteLine("\t{");
            //s.WriteLine();
            //s.WriteLine("\t\tpublic static void Main(object[] params)");
            //s.WriteLine("\t\t{");
            //s.WriteLine();
            //s.WriteLine("\t\t}");
            //s.WriteLine("\t}");
            //s.WriteLine("}");
            s.Close();
            File.Encrypt(fullPath);
            write.Write(true);
        }
    }
}
