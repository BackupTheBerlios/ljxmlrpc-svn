using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LJXMLRPC;
using LJXMLRPC.Data;
using LJXMLRPC.Calls;
using LJXMLRPC.Utils;

namespace LJClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getFriends_Click(object sender, EventArgs e)
        {
            friendsList.Items.Clear();

            GetFriendsReply? friends = MakeCall.GetFriends();

            if (friends.HasValue)
            {
                foreach (Friend friend in friends.Value.friends)
                {
                    friendsList.Items.Add(UserDetails(friend, friends.Value.FriendGroups));
                }
            }
        }

        private ListViewItem UserDetails(Friend friend, SortedList<int, FriendGroup> groupList)
        {
            List<String> groups = Groups(groupList, friend);
            List<String> details = new List<string>();
            details.Add(friend.UserName ?? "Invalid User Name");
            details.Add(friend.type);
            details.Add(groups.Count.ToString());
            details.AddRange(groups);
            return new ListViewItem(details.ToArray());
        }

        private List<string> Groups(SortedList<int, FriendGroup> groupList, Friend friend)
        {
            double groupMask = friend.groupmask;
            List<string> groups = new List<string>();
            foreach (FriendGroup group in groupList.Values)
            {
                if ((group.bitwiseID & friend.groupmask) == group.bitwiseID)
                {
                    groups.Add(group.name);
                }
            }
            return groups;
        }

        private void ljName_Leave(object sender, EventArgs e)
        {
            LoginInfo.UserName = ljName.Text;
            Registry.Write("UserName", LoginInfo.UserName);
        }

        private void ljPassword_Leave(object sender, EventArgs e)
        {
            LoginInfo.PasswordHash =  MD5.Hash(ljPassword.Text);
            Registry.Write("Password", LoginInfo.PasswordHash);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginReply reply = MakeCall.Login();
            MessageBox.Show(reply.fullname);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ljName.Text = Registry.Read("UserName");
            LoginInfo.UserName = ljName.Text;
            LoginInfo.PasswordHash = Registry.Read("Password");
            if (!string.IsNullOrEmpty(LoginInfo.PasswordHash))
            {
                ljPassword.Text = "Retrieved";
            }
        }
    }
}