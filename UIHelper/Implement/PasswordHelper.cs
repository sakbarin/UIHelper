using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Helper
{
    public class PasswordHelper : IPasswordHelper
    {
        public string HashPassword(string Password)
        {
            try
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] hashedData = sha.ComputeHash(Encoding.Unicode.GetBytes(Password));

                string hashedPassword = "";

                foreach (byte data in hashedData)
                {
                    hashedPassword += String.Format("{0,2:X2}", data);
                }

                return hashedPassword;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}