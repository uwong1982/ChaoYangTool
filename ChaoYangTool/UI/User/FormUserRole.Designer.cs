namespace ChaoYangTool.UI.User
{
    partial class FormUserRole
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
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxUserIdList = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewRole = new System.Windows.Forms.ListView();
            this.textBoxFindRole = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExecuteSql = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddUserRole = new System.Windows.Forms.Button();
            this.buttonRetainWardUser = new System.Windows.Forms.Button();
            this.buttonDelUserWard = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSql
            // 
            this.textBoxSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSql.Location = new System.Drawing.Point(3, 17);
            this.textBoxSql.Multiline = true;
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSql.Size = new System.Drawing.Size(508, 375);
            this.textBoxSql.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxUserIdList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(86, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UserId";
            // 
            // textBoxUserIdList
            // 
            this.textBoxUserIdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUserIdList.Location = new System.Drawing.Point(3, 17);
            this.textBoxUserIdList.Multiline = true;
            this.textBoxUserIdList.Name = "textBoxUserIdList";
            this.textBoxUserIdList.Size = new System.Drawing.Size(80, 375);
            this.textBoxUserIdList.TabIndex = 0;
            this.textBoxUserIdList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserIdList_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewRole);
            this.groupBox2.Controls.Add(this.textBoxFindRole);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 395);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Role";
            // 
            // listViewRole
            // 
            this.listViewRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewRole.HideSelection = false;
            this.listViewRole.Location = new System.Drawing.Point(6, 47);
            this.listViewRole.Name = "listViewRole";
            this.listViewRole.Size = new System.Drawing.Size(156, 342);
            this.listViewRole.TabIndex = 1;
            this.listViewRole.UseCompatibleStateImageBehavior = false;
            // 
            // textBoxFindRole
            // 
            this.textBoxFindRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFindRole.Location = new System.Drawing.Point(6, 20);
            this.textBoxFindRole.Name = "textBoxFindRole";
            this.textBoxFindRole.Size = new System.Drawing.Size(156, 21);
            this.textBoxFindRole.TabIndex = 0;
            this.textBoxFindRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindRole_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxSql);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(514, 395);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SQL";
            // 
            // buttonExecuteSql
            // 
            this.buttonExecuteSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExecuteSql.Location = new System.Drawing.Point(204, 3);
            this.buttonExecuteSql.Name = "buttonExecuteSql";
            this.buttonExecuteSql.Size = new System.Drawing.Size(64, 23);
            this.buttonExecuteSql.TabIndex = 1;
            this.buttonExecuteSql.Text = "执行SQL";
            this.buttonExecuteSql.UseVisualStyleBackColor = true;
            this.buttonExecuteSql.Click += new System.EventHandler(this.buttonExecuteSql_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAddUserRole, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonRetainWardUser, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonExecuteSql, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelUserWard, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(517, 411);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(271, 29);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // buttonAddUserRole
            // 
            this.buttonAddUserRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddUserRole.Location = new System.Drawing.Point(3, 3);
            this.buttonAddUserRole.Name = "buttonAddUserRole";
            this.buttonAddUserRole.Size = new System.Drawing.Size(61, 23);
            this.buttonAddUserRole.TabIndex = 2;
            this.buttonAddUserRole.Text = "添加角色";
            this.buttonAddUserRole.UseVisualStyleBackColor = true;
            this.buttonAddUserRole.Click += new System.EventHandler(this.buttonAddUserRole_Click);
            // 
            // buttonRetainWardUser
            // 
            this.buttonRetainWardUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRetainWardUser.Location = new System.Drawing.Point(70, 3);
            this.buttonRetainWardUser.Name = "buttonRetainWardUser";
            this.buttonRetainWardUser.Size = new System.Drawing.Size(61, 23);
            this.buttonRetainWardUser.TabIndex = 3;
            this.buttonRetainWardUser.Text = "保留用户";
            this.buttonRetainWardUser.UseVisualStyleBackColor = true;
            // 
            // buttonDelUserWard
            // 
            this.buttonDelUserWard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelUserWard.Location = new System.Drawing.Point(137, 3);
            this.buttonDelUserWard.Name = "buttonDelUserWard";
            this.buttonDelUserWard.Size = new System.Drawing.Size(61, 23);
            this.buttonDelUserWard.TabIndex = 4;
            this.buttonDelUserWard.Text = "删除角色";
            this.buttonDelUserWard.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(776, 395);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 13;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(258, 395);
            this.splitContainer2.SplitterDistance = 86;
            this.splitContainer2.TabIndex = 0;
            // 
            // FormUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormUserRole";
            this.Text = "FormUserRole";
            this.Load += new System.EventHandler(this.FormUserRole_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormUserRole_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSql;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxUserIdList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewRole;
        private System.Windows.Forms.TextBox textBoxFindRole;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonExecuteSql;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAddUserRole;
        private System.Windows.Forms.Button buttonRetainWardUser;
        private System.Windows.Forms.Button buttonDelUserWard;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}