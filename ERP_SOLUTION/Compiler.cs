using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;

namespace ERP_SOLUTION
{
    internal class Compiler
    {
        public static (bool success, string[] error) Compile(string src, string dest)
        {
            File.Decrypt(src);
            string code = File.ReadAllText(src);
            File.Encrypt(src);
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.OutputAssembly = dest;
            cp.GenerateInMemory = false;
            cp.TreatWarningsAsErrors = false;
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            cp.ReferencedAssemblies.Add("System.Data.dll");
            cp.ReferencedAssemblies.Add("System.Drawing.dll");
            cp.ReferencedAssemblies.Add("System.Net.Http.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            cp.ReferencedAssemblies.Add("System.Xml.Linq.dll");
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults result = provider.CompileAssemblyFromSource(cp, code);
            if(result.Errors.Count > 0 )
            {
                string[] errors = new string[result.Errors.Count];
                int index = 0;
                foreach(CompilerError error in result.Errors)
                {
                    errors[index] = "Syntax error at line:" + error.Line + ".\n" + error.ErrorText;
                    index++;
                }
                return (false, errors);
            }
            return (true, new string[0]);
        }
    }
}
