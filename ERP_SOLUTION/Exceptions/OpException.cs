using System;

namespace ERP_SOLUTION.Exceptions
{
    internal class OpException : Exception
    {
        public static string Packet_Error
        {
            get => "Something went wrong with the packet that sent to the server.\n" +
                   "Please contact server supplier for help.";
        }
        public static string Login_Expired
        {
            get => "Login session expired.\nPlease re-login.";
        }
        public static string Permission
        {
            get => "User dont have Permission to do this.";
        }
        public static string File_Exist
        {
            get => "File with this name already exist.";
        }
        public OpException():base("Operation exception reach.") { }
    }
}
