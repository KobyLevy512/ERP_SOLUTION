
using ERP_SOLUTION.Server;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ERP_SOLUTION.Transactions.Server
{

    internal class ServerConsole
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public ServerConsole()
        {
            if(!AllocConsole())
            {
                System.Windows.Forms.MessageBox.Show("Cant open console window in this context.");
            }
            else
            {
                ServerListener listener = new ServerListener("", 3000);
                Task.Run(() =>
                {
                    listener.Start();
                });

                while(true)
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
