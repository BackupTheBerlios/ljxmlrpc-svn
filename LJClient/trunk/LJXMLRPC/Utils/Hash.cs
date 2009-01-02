using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace LJXMLRPC.Utils
{
    public static class MD5
    {
        public static string Hash(string plainText)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(plainText, "MD5").ToLower();
        }

    }
}
