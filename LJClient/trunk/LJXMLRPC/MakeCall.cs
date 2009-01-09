using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using CookComputing.XmlRpc;
using System.Windows.Forms;
using LJXMLRPC.Calls;
using LJXMLRPC.Utils;
using LJXMLRPC.Data;

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
            LoginRequest request = new LoginRequest();
			request.PopulateWithLoginInfo();
			LoginReply reply = loginProxy.Login(request);
            return reply;
        }

		public static GetFriendsReply GetFriends()
		{
			ILJGetFriends getFriendsProxy = XmlRpcProxyGen.Create<ILJGetFriends>();
			//Need to run Fiddler so that it redirects this request...
			//proxy2.Proxy = new WebProxy("http://127.0.0.1:9999");

			GetFriendsRequest request = new GetFriendsRequest(true, true);
			request.PopulateWithLoginInfo();
			GetFriendsReply reply = getFriendsProxy.GetFriends(request);

			reply.PostProcess();

			return reply;
		}

		public static EditFriendsReply EditFriends()
		{
			ILJEditFriends editFriendsProxy = XmlRpcProxyGen.Create<ILJEditFriends>();
			EditFriendsRequest request = new EditFriendsRequest();
			request.PopulateWithLoginInfo();
			request.add = new Friend[1];
			request.add[0] = new Friend();
			request.add[0].username = "AndrewDucker";
			EditFriendsReply reply = editFriendsProxy.EditFriends(request);
			return reply;
		}
    }
}