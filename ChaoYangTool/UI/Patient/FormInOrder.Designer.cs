namespace ChaoYangTool.UI.Patient
{
    partial class FormInOrder
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOrderName = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPatInfo = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBoxTrans = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOutInfo = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewPatOrderInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderNoDetail = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewSlip = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewIpdZytzd = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewIpdMaster = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAllowPrintZytzd = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemStopOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCancelStopOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAllowCharging = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatOrderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderNoDetail)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSlip)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIpdZytzd)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIpdMaster)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "医嘱名：";
            // 
            // textBoxOrderName
            // 
            this.textBoxOrderName.Location = new System.Drawing.Point(381, 12);
            this.textBoxOrderName.Name = "textBoxOrderName";
            this.textBoxOrderName.Size = new System.Drawing.Size(245, 21);
            this.textBoxOrderName.TabIndex = 11;
            this.textBoxOrderName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOrderName_KeyDown);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(177, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 21);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "患者ID：";
            // 
            // textBoxPatInfo
            // 
            this.textBoxPatInfo.Location = new System.Drawing.Point(71, 12);
            this.textBoxPatInfo.Name = "textBoxPatInfo";
            this.textBoxPatInfo.Size = new System.Drawing.Size(100, 21);
            this.textBoxPatInfo.TabIndex = 8;
            this.textBoxPatInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPatInfo_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 399);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "转科";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxTrans, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxOutInfo, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // richTextBoxTrans
            // 
            this.richTextBoxTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxTrans.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxTrans.Name = "richTextBoxTrans";
            this.richTextBoxTrans.Size = new System.Drawing.Size(375, 361);
            this.richTextBoxTrans.TabIndex = 0;
            this.richTextBoxTrans.Text = "";
            // 
            // richTextBoxOutInfo
            // 
            this.richTextBoxOutInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutInfo.Location = new System.Drawing.Point(384, 3);
            this.richTextBoxOutInfo.Name = "richTextBoxOutInfo";
            this.richTextBoxOutInfo.Size = new System.Drawing.Size(375, 361);
            this.richTextBoxOutInfo.TabIndex = 1;
            this.richTextBoxOutInfo.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "医嘱";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewPatOrderInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewOrderNoDetail);
            this.splitContainer1.Size = new System.Drawing.Size(762, 367);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewPatOrderInfo
            // 
            this.dataGridViewPatOrderInfo.AllowUserToAddRows = false;
            this.dataGridViewPatOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatOrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPatOrderInfo.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPatOrderInfo.Name = "dataGridViewPatOrderInfo";
            this.dataGridViewPatOrderInfo.RowTemplate.Height = 23;
            this.dataGridViewPatOrderInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPatOrderInfo.Size = new System.Drawing.Size(762, 254);
            this.dataGridViewPatOrderInfo.TabIndex = 0;
            this.dataGridViewPatOrderInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPatOrderInfo_CellClick);
            // 
            // dataGridViewOrderNoDetail
            // 
            this.dataGridViewOrderNoDetail.AllowUserToAddRows = false;
            this.dataGridViewOrderNoDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderNoDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOrderNoDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOrderNoDetail.Name = "dataGridViewOrderNoDetail";
            this.dataGridViewOrderNoDetail.ReadOnly = true;
            this.dataGridViewOrderNoDetail.RowTemplate.Height = 23;
            this.dataGridViewOrderNoDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderNoDetail.Size = new System.Drawing.Size(762, 109);
            this.dataGridViewOrderNoDetail.TabIndex = 0;
            this.dataGridViewOrderNoDetail.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOrderNoDetail_CellMouseDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewSlip);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 373);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "twipd_slip";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSlip
            // 
            this.dataGridViewSlip.AllowUserToAddRows = false;
            this.dataGridViewSlip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSlip.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSlip.Name = "dataGridViewSlip";
            this.dataGridViewSlip.RowTemplate.Height = 23;
            this.dataGridViewSlip.Size = new System.Drawing.Size(762, 367);
            this.dataGridViewSlip.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Controls.Add(this.buttonAllowPrintZytzd);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 373);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "允许补打住院通知单";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewIpdZytzd);
            this.groupBox2.Location = new System.Drawing.Point(6, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "twipd_zytzd";
            // 
            // dataGridViewIpdZytzd
            // 
            this.dataGridViewIpdZytzd.AllowUserToAddRows = false;
            this.dataGridViewIpdZytzd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIpdZytzd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIpdZytzd.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewIpdZytzd.Name = "dataGridViewIpdZytzd";
            this.dataGridViewIpdZytzd.RowTemplate.Height = 23;
            this.dataGridViewIpdZytzd.Size = new System.Drawing.Size(750, 80);
            this.dataGridViewIpdZytzd.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewIpdMaster);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twipd_master";
            // 
            // dataGridViewIpdMaster
            // 
            this.dataGridViewIpdMaster.AllowUserToAddRows = false;
            this.dataGridViewIpdMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIpdMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIpdMaster.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewIpdMaster.Name = "dataGridViewIpdMaster";
            this.dataGridViewIpdMaster.RowTemplate.Height = 23;
            this.dataGridViewIpdMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIpdMaster.Size = new System.Drawing.Size(750, 80);
            this.dataGridViewIpdMaster.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 218);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(756, 21);
            this.textBox1.TabIndex = 1;
            // 
            // buttonAllowPrintZytzd
            // 
            this.buttonAllowPrintZytzd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAllowPrintZytzd.Location = new System.Drawing.Point(607, 245);
            this.buttonAllowPrintZytzd.Name = "buttonAllowPrintZytzd";
            this.buttonAllowPrintZytzd.Size = new System.Drawing.Size(155, 23);
            this.buttonAllowPrintZytzd.TabIndex = 0;
            this.buttonAllowPrintZytzd.Text = "允许打印住院通知单";
            this.buttonAllowPrintZytzd.UseVisualStyleBackColor = true;
            this.buttonAllowPrintZytzd.Click += new System.EventHandler(this.buttonAllowPrintZytzd_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemStopOrder,
            this.toolStripMenuItemCancelStopOrder,
            this.toolStripMenuItemAllowCharging});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItemStopOrder
            // 
            this.toolStripMenuItemStopOrder.Name = "toolStripMenuItemStopOrder";
            this.toolStripMenuItemStopOrder.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemStopOrder.Text = "停嘱";
            this.toolStripMenuItemStopOrder.Click += new System.EventHandler(this.toolStripMenuItemStopOrder_Click);
            // 
            // toolStripMenuItemCancelStopOrder
            // 
            this.toolStripMenuItemCancelStopOrder.Name = "toolStripMenuItemCancelStopOrder";
            this.toolStripMenuItemCancelStopOrder.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemCancelStopOrder.Text = "取消停嘱";
            this.toolStripMenuItemCancelStopOrder.Click += new System.EventHandler(this.toolStripMenuItemCancelStopOrder_Click);
            // 
            // toolStripMenuItemAllowCharging
            // 
            this.toolStripMenuItemAllowCharging.Name = "toolStripMenuItemAllowCharging";
            this.toolStripMenuItemAllowCharging.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemAllowCharging.Text = "允许轮训";
            this.toolStripMenuItemAllowCharging.Click += new System.EventHandler(this.toolStripMenuItemAllowCharging_Click);
            // 
            // FormInOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxOrderName);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPatInfo);
            this.Name = "FormInOrder";
            this.Text = "FormInOrder";
            this.Load += new System.EventHandler(this.FormInOrder_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatOrderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderNoDetail)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSlip)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIpdZytzd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIpdMaster)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOrderName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPatInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBoxTrans;
        private System.Windows.Forms.RichTextBox richTextBoxOutInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewPatOrderInfo;
        private System.Windows.Forms.DataGridView dataGridViewOrderNoDetail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStopOrder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCancelStopOrder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAllowCharging;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonAllowPrintZytzd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewIpdZytzd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewIpdMaster;
        private System.Windows.Forms.DataGridView dataGridViewSlip;
    }
}