using ERP_SOLUTION.Server;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_SOLUTION.Transactions.Server
{
    public partial class MainMenu : Form
    {
        public MainMenu(string ip, int port)
        {
            InitializeComponent();
            Task.Run(() =>
            {
                ServerListener listener = new ServerListener(ip, port);
                listener.Start();
            });
        }
    }
}
