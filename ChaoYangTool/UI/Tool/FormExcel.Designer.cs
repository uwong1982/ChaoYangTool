namespace ChaoYangTool.UI.Tool
{
    partial class FormExcel
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
            this.buttonOpenExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDo = new System.Windows.Forms.Button();
            this.buttonSaveExcel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxCreateTempTable = new System.Windows.Forms.TextBox();
            this.textBoxSheetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenExcel
            // 
            this.buttonOpenExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenExcel.Location = new System.Drawing.Point(189, 415);
            this.buttonOpenExcel.Name = "buttonOpenExcel";
            this.buttonOpenExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenExcel.TabIndex = 0;
            this.buttonOpenExcel.Text = "OpenExcel";
            this.buttonOpenExcel.UseVisualStyleBackColor = true;
            this.buttonOpenExcel.Click += new System.EventHandler(this.buttonOpenExcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(258, 397);
            this.dataGridView1.TabIndex = 2;
            // 
            // buttonDo
            // 
            this.buttonDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDo.Location = new System.Drawing.Point(270, 415);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(75, 23);
            this.buttonDo.TabIndex = 3;
            this.buttonDo.Text = "Do";
            this.buttonDo.UseVisualStyleBackColor = true;
            // 
            // buttonSaveExcel
            // 
            this.buttonSaveExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveExcel.Location = new System.Drawing.Point(351, 415);
            this.buttonSaveExcel.Name = "buttonSaveExcel";
            this.buttonSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveExcel.TabIndex = 4;
            this.buttonSaveExcel.Text = "SaveExcel";
            this.buttonSaveExcel.UseVisualStyleBackColor = true;
            this.buttonSaveExcel.Click += new System.EventHandler(this.buttonSaveExcel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxCreateTempTable);
            this.splitContainer1.Size = new System.Drawing.Size(776, 397);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 5;
            // 
            // textBoxCreateTempTable
            // 
            this.textBoxCreateTempTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCreateTempTable.Location = new System.Drawing.Point(0, 0);
            this.textBoxCreateTempTable.Multiline = true;
            this.textBoxCreateTempTable.Name = "textBoxCreateTempTable";
            this.textBoxCreateTempTable.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCreateTempTable.Size = new System.Drawing.Size(514, 397);
            this.textBoxCreateTempTable.TabIndex = 0;
            this.textBoxCreateTempTable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCreateTempTable_KeyPress);
            // 
            // textBoxSheetName
            // 
            this.textBoxSheetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSheetName.Location = new System.Drawing.Point(83, 415);
            this.textBoxSheetName.Name = "textBoxSheetName";
            this.textBoxSheetName.Size = new System.Drawing.Size(100, 21);
            this.textBoxSheetName.TabIndex = 6;
            this.textBoxSheetName.Text = "Sheet1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "SheetName:";
            // 
            // FormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSheetName);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonSaveExcel);
            this.Controls.Add(this.buttonDo);
            this.Controls.Add(this.buttonOpenExcel);
            this.Name = "FormExcel";
            this.Text = "FormExcel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.Button buttonSaveExcel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxCreateTempTable;
        private System.Windows.Forms.TextBox textBoxSheetName;
        private System.Windows.Forms.Label label1;
    }
}