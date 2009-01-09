using System;
using System.Collections.Generic;
using System.Text;
using LJXMLRPC.Data;
using CookComputing.XmlRpc;

namespace LJXMLRPC.Calls
{
    [XmlRpcUrl(@"http://www.livejournal.com/interface/xmlrpc")]
    public interface ILJEditFriends : IXmlRpcProxy
    {
        [XmlRpcMethod("LJ.XMLRPC.getfriends")]
        EditFriendsReply EditFriends(EditFriendsRequest getFriendsRequest);
    }

	public class EditFriendsRequest : CallLoginInfo
	{
		public Friend[] add { get; set; }
	}

	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public struct EditFriendsReply
	{
		public Friend[] added { get; set; }
	}
}
