namespace ChaoYangTool.UI.User
{
    partial class FormMainDiagnosisGroup
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxWard = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewBed = new System.Windows.Forms.DataGridView();
            this.dataGridViewMdg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMdg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "主诊组：";
            // 
            // comboBoxDept
            // 
            this.comboBoxDept.FormattingEnabled = true;
            this.comboBoxDept.Location = new System.Drawing.Point(62, 3);
            this.comboBoxDept.Name = "comboBoxDept";
            this.comboBoxDept.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDept.TabIndex = 0;
            this.comboBoxDept.SelectedIndexChanged += new System.EventHandler(this.comboBoxDept_SelectedIndexChanged);
            this.comboBoxDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxDept_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "床位：";
            // 
            // comboBoxWard
            // 
            this.comboBoxWard.FormattingEnabled = true;
            this.comboBoxWard.Location = new System.Drawing.Point(50, 3);
            this.comboBoxWard.Name = "comboBoxWard";
            this.comboBoxWard.Size = new System.Drawing.Size(121, 20);
            this.comboBoxWard.TabIndex = 3;
            this.comboBoxWard.SelectedIndexChanged += new System.EventHandler(this.comboBoxWard_SelectedIndexChanged);
            this.comboBoxWard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxWard_KeyDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewBed);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.comboBoxWard);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridViewMdg);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.comboBoxDept);
            this.splitContainer2.Size = new System.Drawing.Size(800, 450);
            this.splitContainer2.SplitterDistance = 369;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridViewBed
            // 
            this.dataGridViewBed.AllowUserToAddRows = false;
            this.dataGridViewBed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBed.Location = new System.Drawing.Point(3, 29);
            this.dataGridViewBed.Name = "dataGridViewBed";
            this.dataGridViewBed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBed.Size = new System.Drawing.Size(366, 418);
            this.dataGridViewBed.TabIndex = 0;
            // 
            // dataGridViewMdg
            // 
            this.dataGridViewMdg.AllowUserToAddRows = false;
            this.dataGridViewMdg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMdg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMdg.Location = new System.Drawing.Point(3, 29);
            this.dataGridViewMdg.MultiSelect = false;
            this.dataGridViewMdg.Name = "dataGridViewMdg";
            this.dataGridViewMdg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMdg.Size = new System.Drawing.Size(421, 418);
            this.dataGridViewMdg.TabIndex = 0;
            this.dataGridViewMdg.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMdg_CellDoubleClick);
            // 
            // FormMainDiagnosisGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FormMainDiagnosisGroup";
            this.Text = "FormMainDiagnosisGroup";
            this.Load += new System.EventHandler(this.FormMainDiagnosisGroup_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMdg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxWard;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridViewBed;
        private System.Windows.Forms.DataGridView dataGridViewMdg;
    }
}