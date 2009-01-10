using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;

namespace LJXMLRPC.Data
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Friend
    {
        public object username;
        public string UserName;
        public string type;
        public string fgcolor;
        public string bgcolor;
        public int? groupmask;
		public object fullname;
		public string FullName;

		/// <summary>
		/// Call after fetching data, because LJ will return all-numeric friend name as an int rather than a string.
		/// </summary>
		public void PostProcess()
		{
			UserName = username as string ?? username.ToString();
			FullName = fullname as string ?? fullname.ToString();

		}
	}
}
