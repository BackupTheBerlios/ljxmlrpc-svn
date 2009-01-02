using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace LJClient
{
    static class Registry
    {
        public static void Write(string key, string value)
        {
            RegistryKey ourKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\"+ApplicationConfiguration.ApplicationName,true);
            if (ourKey == null)
            {
                ourKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software",true).CreateSubKey(ApplicationConfiguration.ApplicationName);
            }
            ourKey.SetValue(key, value);
        }

        public static string Read(string key)
        {
            RegistryKey ourKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\" + ApplicationConfiguration.ApplicationName, true);
            if (ourKey == null)
            {
                return string.Empty;
            }
            return ourKey.GetValue(key, "").ToString();
        }
    }
}
