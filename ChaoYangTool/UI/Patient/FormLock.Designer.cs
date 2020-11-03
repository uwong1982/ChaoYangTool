namespace ChaoYangTool.UI.Patient
{
    partial class FormLock
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewLockedPatient = new System.Windows.Forms.DataGridView();
            this.dataGridViewMachineLockedPatient = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPatInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLockedMinute = new System.Windows.Forms.TextBox();
            this.buttonUnlockAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLockedPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachineLockedPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewLockedPatient);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewMachineLockedPatient);
            this.splitContainer1.Size = new System.Drawing.Size(776, 399);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewLockedPatient
            // 
            this.dataGridViewLockedPatient.AllowUserToAddRows = false;
            this.dataGridViewLockedPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLockedPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLockedPatient.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLockedPatient.Name = "dataGridViewLockedPatient";
            this.dataGridViewLockedPatient.RowTemplate.Height = 23;
            this.dataGridViewLockedPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLockedPatient.Size = new System.Drawing.Size(776, 199);
            this.dataGridViewLockedPatient.TabIndex = 0;
            this.dataGridViewLockedPatient.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewLockedPatient_MouseDoubleClick);
            // 
            // dataGridViewMachineLockedPatient
            // 
            this.dataGridViewMachineLockedPatient.AllowUserToAddRows = false;
            this.dataGridViewMachineLockedPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMachineLockedPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMachineLockedPatient.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMachineLockedPatient.Name = "dataGridViewMachineLockedPatient";
            this.dataGridViewMachineLockedPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMachineLockedPatient.Size = new System.Drawing.Size(776, 196);
            this.dataGridViewMachineLockedPatient.TabIndex = 0;
            this.dataGridViewMachineLockedPatient.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewMachineLockedPatient_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "患者姓名或ID号：";
            // 
            // textBoxPatInfo
            // 
            this.textBoxPatInfo.Location = new System.Drawing.Point(119, 12);
            this.textBoxPatInfo.Name = "textBoxPatInfo";
            this.textBoxPatInfo.Size = new System.Drawing.Size(100, 21);
            this.textBoxPatInfo.TabIndex = 2;
            this.textBoxPatInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPatInfo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "锁定时长：";
            // 
            // textBoxLockedMinute
            // 
            this.textBoxLockedMinute.Location = new System.Drawing.Point(296, 12);
            this.textBoxLockedMinute.Name = "textBoxLockedMinute";
            this.textBoxLockedMinute.Size = new System.Drawing.Size(100, 21);
            this.textBoxLockedMinute.TabIndex = 4;
            this.textBoxLockedMinute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxLockedMinute_KeyDown);
            // 
            // buttonUnlockAll
            // 
            this.buttonUnlockAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUnlockAll.Location = new System.Drawing.Point(713, 10);
            this.buttonUnlockAll.Name = "buttonUnlockAll";
            this.buttonUnlockAll.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlockAll.TabIndex = 5;
            this.buttonUnlockAll.Text = "全部解锁";
            this.buttonUnlockAll.UseVisualStyleBackColor = true;
            this.buttonUnlockAll.Click += new System.EventHandler(this.buttonUnlockAll_Click);
            // 
            // FormLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonUnlockAll);
            this.Controls.Add(this.textBoxLockedMinute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPatInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormLock";
            this.Text = "FormLock";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLockedPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachineLockedPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPatInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLockedMinute;
        private System.Windows.Forms.Button buttonUnlockAll;
        private System.Windows.Forms.DataGridView dataGridViewLockedPatient;
        private System.Windows.Forms.DataGridView dataGridViewMachineLockedPatient;
    }
}