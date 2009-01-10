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
using System.Collections;

namespace LJClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		Friend[] friends;
		SortedList<int,FriendGroup> groups;

        private void getFriends_Click(object sender, EventArgs e)
        {
            GetFriendsReply friendsReply = MakeCall.GetFriends();

			friends = friendsReply.friends;
			groups = friendsReply.FriendGroups;
			
        }


		private void btnPopulateFriends_Click(object sender, EventArgs e)
		{
			friendsList.Items.Clear();

			List<ListViewItem> friendCollection = new List<ListViewItem>();
			foreach (Friend friend in friends)
			{
				friendCollection.Add(UserDetails(friend, groups));
			}
			friendsList.Items.AddRange(friendCollection.ToArray());
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
            List<string> groups = new List<string>();
			if (friend.groupmask.HasValue)
			{
				BitArray group = new BitArray(new int[] { friend.groupmask.Value });
				//We skip group 0 - it's the default group for all people...
				for (int i = 1; i < group.Length; i++)
				{
					if (group[i])
					{
						groups.Add(groupList[i].name);
					}
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

		private void btnGroupsVsUsers_Click(object sender, EventArgs e)
		{
			DataTable table = new DataTable();
			table.Columns.Add("User Name",typeof(string));
			desiredColumnWidths = new Dictionary<string, int>();
			dataGridGroupsVsUsers.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridGroupsVsUsers.Font.Name, 8);
			foreach (KeyValuePair<int, FriendGroup> group in groups)
			{
				DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
				column.HeaderText = group.Value.name;
				table.Columns.Add(group.Value.name,typeof(bool));
				dataGridGroupsVsUsers.Columns.Add(column);
				column.DataPropertyName = column.HeaderText;
				desiredColumnWidths.Add(column.HeaderText,column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells,true));
			}
			SetMinimumWidthsForColumns();
			foreach (Friend friend in friends)
			{
				DataRow row = table.NewRow();
				row["User Name"] = friend.UserName;
				foreach (FriendGroup group in groups.Values)
				{
					row[group.name] = ((group.BitmapID & friend.groupmask) == group.BitmapID);
				}
				table.Rows.Add(row);
			}
			dataGridGroupsVsUsers.DataSource = table;
		}

		private void dataGridGroupsVsUsers_Resize(object sender, EventArgs e)
		{
			SetMinimumWidthsForColumns();
		}

		Dictionary<string, int> desiredColumnWidths = new Dictionary<string, int>();

		private void SetMinimumWidthsForColumns()
		{
			int pixelstoSpend = dataGridGroupsVsUsers.Width -(dataGridGroupsVsUsers.Columns[0].Width + 60);
			int minWidth = pixelstoSpend / groups.Count+1;
			int pixelsToSpendThisRound = pixelstoSpend;
			bool oneChanged = true;

			while (pixelsToSpendThisRound > groups.Count && oneChanged)
			{
				pixelsToSpendThisRound = pixelstoSpend;
				oneChanged = false;
				minWidth++;
				for (int i = 1; i < dataGridGroupsVsUsers.Columns.Count; i++)
				{
					DataGridViewColumn column = dataGridGroupsVsUsers.Columns[i];
					if (desiredColumnWidths[column.HeaderText] < minWidth)
					{
						column.MinimumWidth = desiredColumnWidths[column.HeaderText];
					}
					else
					{
						column.MinimumWidth = minWidth;
						oneChanged = true;
					}
					pixelsToSpendThisRound -= column.MinimumWidth;
				}
			}

			foreach (DataGridViewColumn column in dataGridGroupsVsUsers.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
			}
		}

		private void btnAddFriend_Click(object sender, EventArgs e)
		{
			EditFriendsReply reply = MakeCall.EditFriends();
			foreach (Friend friend in reply.added)
			{
				MessageBox.Show(friend.fullname);
			}
		}

		private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
		{
			MakeCall.UseProxy = chkUseProxy.Checked;
		}

    }
}