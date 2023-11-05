using System;

namespace ERP_SOLUTION.Exceptions
{
    internal class LoadServerException : Exception
    {
        public LoadServerException(string path):base("Can't load the server.\nPlease validate server files.")
        {
            this.Source = path;
        }
    }
}
