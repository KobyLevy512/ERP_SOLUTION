using System;

namespace ERP_SOLUTION.Exceptions
{
    internal class PortException : Exception
    {
        public PortException(string port) : base("Port number is invalid.")
        {
            this.Source = port;
        }
    }
}
