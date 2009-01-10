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

    public class GetFriendsRequest:CallLoginInfo
    {
        public GetFriendsRequest(bool includefriendsof, bool includegroups)
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
        public int includefriendof;
        public int includegroups;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class GetFriendsReply
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
			foreach (Friend friend in friends)
			{
				friend.PostProcess();
			}
			foreach (Friend friend in friendofs)
			{
				friend.PostProcess();
			}
			for (int i = 0; i < friendgroups.Length; i++)
			{
				friendgroups[i].BitmapID = (int)Math.Pow(2, friendgroups[i].id);
			}
        }
    }
}
