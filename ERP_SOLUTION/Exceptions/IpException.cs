using System;

namespace ERP_SOLUTION.Exceptions
{
    internal class IpException : Exception
    {
        public IpException(string ip):base("Ip address is not valid.")
        {
            this.Source = ip;
        }
    }
}
