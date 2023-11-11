using ERP_SOLUTION.Client;
using ERP_SOLUTION.Exceptions;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace ERP_SOLUTION
{
    
    public partial class Login : Form
    {
        public string ServerPath;
        public static Login Instance;

        public Login()
        {
            Instance = this;
            InitializeComponent();
            Init();
        }

        void Init()
        {
            ModeComboBox.SelectedIndex = 0;
            if(Properties.Settings.Default.Ip.Length != 0)
            {
                IpInput.Text = Properties.Settings.Default.Ip;
            }
            if (Properties.Settings.Default.Port != 0)
            {
                PortInput.Text = Properties.Settings.Default.Port.ToString();
            }
            if (Properties.Settings.Default.User.Length != 0)
            {
                UserInput.Text = Properties.Settings.Default.User;
            }
        }

        void ValidateData()
        {
            //Validate Port
            try { uint.Parse(PortInput.Text); }
            catch { throw new PortException(PortInput.Text); }
        }

        void CreateNewServerFiles()
        {
            DirectoryInfo dev = Directory.CreateDirectory(ServerPath + "\\Development");
            DirectoryInfo prod = Directory.CreateDirectory(ServerPath + "\\Production");
            DirectoryInfo test = Directory.CreateDirectory(ServerPath + "\\Test");
            DirectoryInfo[] info = { dev, test, prod };
            for (int i = 0; i < info.Length;i++)
            {
                File.Create(info[i].FullName + "\\Permissions.aut").Close();
                File.Encrypt(info[i].FullName + "\\Permissions.aut");
                info[i].CreateSubdirectory("Programs").CreateSubdirectory("Sources");
                info[i].CreateSubdirectory("Tables");
                info[i].CreateSubdirectory("Assets");
                info[i].CreateSubdirectory("Transports");
            }
        }
        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            ClientListener listener;
            try
            {
                listener = new ClientListener(IpInput.Text, int.Parse(PortInput.Text));
            }
            catch(ServerNotExistException ex)
            {
                MessageBox.Show(ex.Message + "\nSource:" + ex.Source);
                return;
            }
            if(listener.Login((byte)ModeComboBox.SelectedIndex, UserInput.Text, PasswordInput.Text))
            {
                //Open client
                Transactions.Client.MainMenu screen = new Transactions.Client.MainMenu();
                screen.ShowDialog();
            }
        }

        private void ServerButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ValidateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (MessageBox.Show("Create new server are you sure ?", "New Server", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {   
                    //Open in server mode
                    ServerPath = folderBrowserDialog1.SelectedPath;
                    CreateNewServerFiles();
                    Transactions.Server.MainMenu screen = new Transactions.Server.MainMenu(UserInfo.Ip, int.Parse(PortInput.Text));
                    screen.ShowDialog();
                }
            }
            else if(MessageBox.Show("Do you want to re-run an existing server", "Existing Server", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    ServerPath = folderBrowserDialog1.SelectedPath;
                    //Validate server directories
                    if(
                        !Directory.Exists(ServerPath + "\\Development") || 
                        !Directory.Exists(ServerPath + "\\Production") || 
                        !Directory.Exists(ServerPath + "\\Test")
                      ) 
                    {
                        LoadServerException ex = new LoadServerException(ServerPath);
                        MessageBox.Show(ex.Message + "\nPath:" + ex.Source);
                    }
                    //Open in server mode
                    Transactions.Server.MainMenu screen = new Transactions.Server.MainMenu(UserInfo.Ip, int.Parse(PortInput.Text));
                    screen.ShowDialog();
                }
            }
        }
    }
}
