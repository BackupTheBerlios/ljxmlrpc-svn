namespace LJClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.getFriends = new System.Windows.Forms.Button();
			this.friendsList = new System.Windows.Forms.ListView();
			this.userName = new System.Windows.Forms.ColumnHeader();
			this.userType = new System.Windows.Forms.ColumnHeader();
			this.groupCount = new System.Windows.Forms.ColumnHeader();
			this.friendsGroup1 = new System.Windows.Forms.ColumnHeader();
			this.friendsGroup2 = new System.Windows.Forms.ColumnHeader();
			this.friendsGroup3 = new System.Windows.Forms.ColumnHeader();
			this.friendsGroup4 = new System.Windows.Forms.ColumnHeader();
			this.ljName = new System.Windows.Forms.TextBox();
			this.ljPassword = new System.Windows.Forms.TextBox();
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.btnPopulateFriends = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// getFriends
			// 
			this.getFriends.Location = new System.Drawing.Point(282, 77);
			this.getFriends.Name = "getFriends";
			this.getFriends.Size = new System.Drawing.Size(75, 23);
			this.getFriends.TabIndex = 0;
			this.getFriends.Text = "Get Friends";
			this.getFriends.UseVisualStyleBackColor = true;
			this.getFriends.Click += new System.EventHandler(this.getFriends_Click);
			// 
			// friendsList
			// 
			this.friendsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.userName,
            this.userType,
            this.groupCount,
            this.friendsGroup1,
            this.friendsGroup2,
            this.friendsGroup3,
            this.friendsGroup4});
			this.friendsList.FullRowSelect = true;
			this.friendsList.Location = new System.Drawing.Point(12, 120);
			this.friendsList.Name = "friendsList";
			this.friendsList.Size = new System.Drawing.Size(721, 460);
			this.friendsList.TabIndex = 3;
			this.friendsList.UseCompatibleStateImageBehavior = false;
			this.friendsList.View = System.Windows.Forms.View.Details;
			// 
			// userName
			// 
			this.userName.Text = "Name";
			this.userName.Width = 153;
			// 
			// userType
			// 
			this.userType.Text = "Type";
			this.userType.Width = 127;
			// 
			// groupCount
			// 
			this.groupCount.Text = "Groups";
			this.groupCount.Width = 73;
			// 
			// friendsGroup1
			// 
			this.friendsGroup1.Text = "Group 1";
			this.friendsGroup1.Width = 89;
			// 
			// friendsGroup2
			// 
			this.friendsGroup2.Text = "Group 2";
			// 
			// friendsGroup3
			// 
			this.friendsGroup3.Text = "Group 3";
			// 
			// friendsGroup4
			// 
			this.friendsGroup4.Text = "Group 4";
			// 
			// ljName
			// 
			this.ljName.Location = new System.Drawing.Point(120, 12);
			this.ljName.Name = "ljName";
			this.ljName.Size = new System.Drawing.Size(100, 20);
			this.ljName.TabIndex = 4;
			this.ljName.Leave += new System.EventHandler(this.ljName_Leave);
			// 
			// ljPassword
			// 
			this.ljPassword.Location = new System.Drawing.Point(120, 38);
			this.ljPassword.Name = "ljPassword";
			this.ljPassword.Size = new System.Drawing.Size(100, 20);
			this.ljPassword.TabIndex = 5;
			this.ljPassword.Leave += new System.EventHandler(this.ljPassword_Leave);
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(25, 15);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(60, 13);
			this.lblUserName.TabIndex = 6;
			this.lblUserName.Text = "User Name";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(25, 41);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(53, 13);
			this.lblPassword.TabIndex = 7;
			this.lblPassword.Text = "Password";
			// 
			// btnPopulateFriends
			// 
			this.btnPopulateFriends.Location = new System.Drawing.Point(438, 77);
			this.btnPopulateFriends.Name = "btnPopulateFriends";
			this.btnPopulateFriends.Size = new System.Drawing.Size(99, 23);
			this.btnPopulateFriends.TabIndex = 10;
			this.btnPopulateFriends.Text = "Populate Friends";
			this.btnPopulateFriends.UseVisualStyleBackColor = true;
			this.btnPopulateFriends.Click += new System.EventHandler(this.btnPopulateFriends_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(855, 592);
			this.Controls.Add(this.btnPopulateFriends);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.ljPassword);
			this.Controls.Add(this.ljName);
			this.Controls.Add(this.friendsList);
			this.Controls.Add(this.getFriends);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getFriends;
        private System.Windows.Forms.ListView friendsList;
        private System.Windows.Forms.ColumnHeader userName;
        private System.Windows.Forms.ColumnHeader userType;
        private System.Windows.Forms.ColumnHeader groupCount;
        private System.Windows.Forms.ColumnHeader friendsGroup1;
        private System.Windows.Forms.ColumnHeader friendsGroup2;
        private System.Windows.Forms.ColumnHeader friendsGroup3;
        private System.Windows.Forms.ColumnHeader friendsGroup4;
        private System.Windows.Forms.TextBox ljName;
        private System.Windows.Forms.TextBox ljPassword;
        private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Button btnPopulateFriends;
    }
}

