using System;


namespace ERP_SOLUTION.Exceptions
{
    internal class ServerListenerException : Exception
    {
        public ServerListenerException():base("Server listener exception reach.\nPlease validate your port and ip.") { }
    }
}
