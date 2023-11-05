using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ERP_SOLUTION.Security
{
    internal class Crypto
    {
        SHA512CryptoServiceProvider cryp;
        public static Crypto Instance;

        public Crypto()
        {
            Instance = this;
            cryp = new SHA512CryptoServiceProvider();
        }

        /// <summary>
        /// Return hashed string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] GetHash(string str)
        {
            return cryp.ComputeHash(Encoding.ASCII.GetBytes(str));
        }

        /// <summary>
        /// Check if user is exist in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool UserExist(string user, string password, byte mode)
        {
            File.Decrypt(Login.Instance.ServerPath + "\\Permissions.aut");
            byte[] hash = File.ReadAllBytes(Login.Instance.ServerPath + "\\Permissions.aut");
            File.Encrypt(Login.Instance.ServerPath + "\\Permissions.aut");

            byte[] hashUser = GetHash(user);
            byte[] hashPass = GetHash(password);
            while(hash.Length >= 129)
            {
                if (hash[0] == mode)
                {
                    if
                    (
                        IsEqual(hashUser, 0, hash, 1, hashUser.Length) &&
                        IsEqual(hashPass, 0, hash, 129, hashPass.Length)
                    )
                        return true;
                }

                //Remove this user
                byte[] newHash = new byte[hash.Length - 129];
                Buffer.BlockCopy(hash, 129, newHash, 0, newHash.Length);
                hash = newHash;
            }
            return false;
        }

        //Check if array is equal to other array
        bool IsEqual(byte[] arr1, int offset1, byte[] arr2, int offset2, int count)
        {
            for(int i = 0; i<count;i++)
            {
                if (arr1[i + offset1] != arr2[i + offset2]) return false;
            }
            return true;
        }
    }
}
