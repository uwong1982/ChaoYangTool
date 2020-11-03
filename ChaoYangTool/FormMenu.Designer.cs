namespace ChaoYangTool
{
    partial class FormMenu
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("住院医嘱");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("解锁患者");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("患者", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("用户病区");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("用户主诊组");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("用户组");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("用户角色");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("用户", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("添加互联网用药");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Med", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Excel");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Tool", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewMenu
            // 
            this.treeViewMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMenu.Location = new System.Drawing.Point(0, 0);
            this.treeViewMenu.Name = "treeViewMenu";
            treeNode1.Name = "NodeInOrder";
            treeNode1.Tag = "ChaoYangTool.UI.Patient.FormInOrder";
            treeNode1.Text = "住院医嘱";
            treeNode2.Name = "NodePatientLock";
            treeNode2.Tag = "ChaoYangTool.UI.Patient.FormLock";
            treeNode2.Text = "解锁患者";
            treeNode3.Name = "Node0";
            treeNode3.Tag = "";
            treeNode3.Text = "患者";
            treeNode4.Name = "NodeUserWard";
            treeNode4.Tag = "ChaoYangTool.UI.User.FormUserWard";
            treeNode4.Text = "用户病区";
            treeNode5.Name = "NodeMainDiagnosisGroup";
            treeNode5.Tag = "ChaoYangTool.UI.User.FormMainDiagnosisGroup";
            treeNode5.Text = "用户主诊组";
            treeNode6.Name = "NodeUserGroup";
            treeNode6.Tag = "ChaoYangTool.UI.User.FormUserGroup";
            treeNode6.Text = "用户组";
            treeNode7.Name = "NodeUserRole";
            treeNode7.Tag = "ChaoYangTool.UI.User.FormUserRole";
            treeNode7.Text = "用户角色";
            treeNode8.Name = "Node0";
            treeNode8.Text = "用户";
            treeNode9.Name = "Node1";
            treeNode9.Tag = "ChaoYangTool.UI.Med.FormInternetMed";
            treeNode9.Text = "添加互联网用药";
            treeNode10.Name = "Node2";
            treeNode10.Text = "Med";
            treeNode11.Name = "Node1";
            treeNode11.Tag = "ChaoYangTool.UI.Tool.FormExcel";
            treeNode11.Text = "Excel";
            treeNode12.Name = "Node0";
            treeNode12.Text = "Tool";
            this.treeViewMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode8,
            treeNode10,
            treeNode12});
            this.treeViewMenu.Size = new System.Drawing.Size(800, 450);
            this.treeViewMenu.TabIndex = 0;
            this.treeViewMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewMenu_NodeMouseClick);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeViewMenu);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewMenu;
    }
}