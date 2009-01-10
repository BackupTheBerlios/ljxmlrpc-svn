using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;

namespace LJXMLRPC.Data
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Friend
    {
        public object username;
        public string UserName;
        public string type;
        public string fgcolor;
        public string bgcolor;
        public int? groupmask;
		public string fullname;
    }
}
