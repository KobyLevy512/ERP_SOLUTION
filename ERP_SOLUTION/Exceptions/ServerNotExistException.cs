using System;

namespace ERP_SOLUTION.Exceptions
{
    internal class ServerNotExistException : Exception
    {
        public ServerNotExistException(string server, int port):base("Server with this ip and port is invalid,\nPlease make validate them.\nIf this not help,contact your server support.")
        {
            this.Source = server + " Port:" + port;
        }
    }
}
