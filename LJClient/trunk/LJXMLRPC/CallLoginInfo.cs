using System;
using System.Collections.Generic;
using System.Text;

namespace LJXMLRPC
{
    public class CallLoginInfo
    {
        public string username { get; set; }
        public string auth_method { get; set; }
        public string auth_challenge { get; set; }
        public string auth_response { get; set; }
        public string clientversion { get; set; }
    }
}
