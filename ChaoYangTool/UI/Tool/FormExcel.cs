using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaoYangTool.UI.Tool
{
    public partial class FormExcel : UUI.Docking.DockContent
    {
        public FormExcel()
        {
            InitializeComponent();
        }

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormExcel Singleton_ = null;

        public static FormExcel CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormExcel();
                    }
                }
            }
            return Singleton_;
        }
        #endregion

        private void buttonOpenExcel_Click(object sender, EventArgs e)
        {
            string path = GetExcelPath();
            if(string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            DataTable dt = Common.ExcelHellper.ExcelToDataTable(path, "Sheet1");
            dataGridView1.DataSource = dt;
        }

        private string GetExcelPath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.FileName;
            }

            return string.Empty;
        }
    }
}
