using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;

namespace LJXMLRPC.Calls
{
    [XmlRpcUrl(@"http://www.livejournal.com/interface/xmlrpc")]
    public interface ILJGetChallenge : IXmlRpcProxy
    {
        [XmlRpcMethod("LJ.XMLRPC.getchallenge")]
        GetChallengeReply GetChallenge();
    }


    public class GetChallengeReply
    {
        public string auth_scheme;
        public string challenge;
        public int expire_time;
        public int server_time;
    }
}
