using System;
using System.Collections.Generic;
using System.Text;

namespace LJXMLRPC
{
    public interface ICallWithLogin
    {
        string username { get; set; }
        string auth_method { get; set; }
        string auth_challenge { get; set; }
        string auth_response { get; set; }
        string clientversion { get; set; }
    }
}
