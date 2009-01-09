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


    public class LoginRequest:CallLoginInfo
    {
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class LoginReply
    {
        public string fullname;
        public string message;
        public FriendGroup[] friendgroups;
    }
}
