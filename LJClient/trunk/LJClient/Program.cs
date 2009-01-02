using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LJXMLRPC;

namespace LJClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			LoginInfo.ClientVersion = ".Net-AndrewDucker/0.0.1";
			
			Application.Run(new Form1());
        }
    }
}