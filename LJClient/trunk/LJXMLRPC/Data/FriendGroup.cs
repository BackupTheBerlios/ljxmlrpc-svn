using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;

namespace LJXMLRPC.Data
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class FriendGroup
    {
        [XmlRpcMember("public")]
        public int Public;
        public string name;
        public int id;
        public int sortorder;
		public int BitmapID;
    }
}
