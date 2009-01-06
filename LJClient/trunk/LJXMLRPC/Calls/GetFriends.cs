using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;
using LJXMLRPC.Data;

namespace LJXMLRPC.Calls
{
    [XmlRpcUrl(@"http://www.livejournal.com/interface/xmlrpc")]
    public interface ILJGetFriends : IXmlRpcProxy
    {
        [XmlRpcMethod("LJ.XMLRPC.getfriends")]
        GetFriendsReply GetFriends(GetFriendsRequest getFriendsRequest);
    }

    public struct GetFriendsRequest:ICallWithLogin
    {
        public GetFriendsRequest(bool includefriendsof, bool includegroups):this()
        {
            if (includefriendsof)
                this.includefriendof = 1;
            else
                this.includefriendof = 0;

            if (includegroups)
                this.includegroups = 1;
            else
                this.includegroups = 0;

        }
        public string username { get; set; }
        public string auth_method { get; set; }
        public string auth_challenge { get; set; }
        public string auth_response { get; set; }
        public string clientversion { get; set; }
        public int includefriendof;
        public int includegroups;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct GetFriendsReply
    {
        public Friend[] friends;
        public FriendGroup[] friendgroups;
        public Friend[] friendofs;

        public SortedList<int, FriendGroup> FriendGroups
        {
            get
            {
                SortedList<int, FriendGroup> friendGroups = new SortedList<int, FriendGroup>();
                foreach (FriendGroup group in friendgroups)
                {
                    friendGroups.Add(group.id, group);
                }
                return friendGroups;
            }
        }

        public void PostProcess()
        {
            for (int i = 0; i < friends.Length; i++)
            {
                friends[i].UserName = friends[i].username as string;
            }

            for (int i = 0; i < friendofs.Length; i++)
            {
                friendofs[i].UserName = friendofs[i].username as string;
            }

			for (int i = 0; i < friendgroups.Length; i++)
			{
				friendgroups[i].BitmapID = (int)Math.Pow(2, friendgroups[i].id);
			}
        }
    }
}
