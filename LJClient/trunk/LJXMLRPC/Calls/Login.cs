using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;
using LJXMLRPC.Data;

namespace LJXMLRPC.Calls
{
    [XmlRpcUrl(@"http://www.livejournal.com/interface/xmlrpc")]
    public interface ILJLogin : IXmlRpcProxy
    {
        [XmlRpcMethod("LJ.XMLRPC.login")]
        LoginReply Login(LoginRequest request);
    }


    public struct LoginRequest:ICallWithLogin
    {
        public string username { get; set; }
        public string auth_method { get; set; }
        public string auth_challenge { get; set; }
        public string auth_response { get; set; }
        public string clientversion { get; set; }
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct LoginReply
    {
        public string fullname;
        public string message;
        public FriendGroup[] friendgroups;
    }
}
