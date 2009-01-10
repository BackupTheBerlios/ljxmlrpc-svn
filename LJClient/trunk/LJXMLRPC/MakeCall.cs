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
		public static bool UseProxy;
        internal static GetChallengeReply GetChallenge()
        {
            ILJGetChallenge getChallengeProxy = CreateProxy<ILJGetChallenge>();
            GetChallengeReply reply = getChallengeProxy.GetChallenge();
            return reply;
        }

        public static LoginReply Login()
        {
            ILJLogin loginProxy = CreateProxy<ILJLogin>();
            LoginRequest request = new LoginRequest();
			request.PopulateWithLoginInfo();
			LoginReply reply = loginProxy.Login(request);
            return reply;
        }

		public static GetFriendsReply GetFriends()
		{
			ILJGetFriends getFriendsProxy = CreateProxy<ILJGetFriends>();
			GetFriendsRequest request = new GetFriendsRequest(true, true);
			request.PopulateWithLoginInfo();
			GetFriendsReply reply = getFriendsProxy.GetFriends(request);

			reply.PostProcess();

			return reply;
		}

		public static EditFriendsReply EditFriends(Friend[] friendsToAddOrEdit, Friend[] friendsToDelete)
		{
			ILJEditFriends editFriendsProxy = CreateProxy<ILJEditFriends>();
			EditFriendsRequest request = new EditFriendsRequest();
			request.PopulateWithLoginInfo();
			request.add = friendsToAddOrEdit;
			EditFriendsReply reply = editFriendsProxy.EditFriends(request);
			return reply;
		}

		private static T CreateProxy<T>() where T:IXmlRpcProxy
		{
			T proxy = XmlRpcProxyGen.Create<T>();
			if (UseProxy)
			{
				proxy.Proxy = new WebProxy("http://127.0.0.1:9999");
			}
			return proxy;
		}
    }
}