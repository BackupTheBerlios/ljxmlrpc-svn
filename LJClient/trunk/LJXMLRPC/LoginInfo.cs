using System;
using System.Collections.Generic;
using System.Text;
using LJXMLRPC.Calls;
using LJXMLRPC.Utils;

namespace LJXMLRPC
{
    public static class LoginInfo
    {
        public static void Populate<T>(ref T call) where T:ICallWithLogin
        {
            call.username = UserName;
            call.auth_method = "challenge";
            GetChallengeReply reply = MakeCall.GetChallenge();
            call.auth_challenge = reply.challenge;
            call.auth_response = MD5.Hash(reply.challenge + PasswordHash);
            call.clientversion = ClientVersion;
        }

        public static string UserName = "";
        public static string PasswordHash = "";
        public static string ClientVersion;
    }
}
