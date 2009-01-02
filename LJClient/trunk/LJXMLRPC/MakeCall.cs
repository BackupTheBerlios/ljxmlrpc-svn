using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using CookComputing.XmlRpc;
using System.Windows.Forms;
using LJXMLRPC.Calls;
using LJXMLRPC.Utils;

namespace LJXMLRPC
{
    public static class MakeCall
    {
        internal static GetChallengeReply GetChallenge()
        {
            ILJGetChallenge getChallengeProxy = XmlRpcProxyGen.Create<ILJGetChallenge>();
            GetChallengeReply reply = getChallengeProxy.GetChallenge();
            return reply;
        }

        public static LoginReply Login()
        {
            ILJLogin loginProxy = XmlRpcProxyGen.Create<ILJLogin>();
            LoginRequest loginRequest = new LoginRequest();
            LoginInfo.Populate(ref loginRequest);
            LoginReply reply = loginProxy.Login(loginRequest);
            return reply;
        }

		public static GetFriendsReply GetFriends()
		{
			ILJGetFriends getFriendsProxy = XmlRpcProxyGen.Create<ILJGetFriends>();
			//Need to run Fiddler so that it redirects this request...
			//proxy2.Proxy = new WebProxy("http://127.0.0.1:9999");

			GetFriendsRequest request = new GetFriendsRequest(true, true);
			LoginInfo.Populate(ref request);
			GetFriendsReply reply = getFriendsProxy.GetFriends(request);

			reply.PostProcess();

			return reply;
		}
    }
}