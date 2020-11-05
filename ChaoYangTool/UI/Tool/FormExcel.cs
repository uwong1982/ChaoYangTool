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
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FormExcel()
        {
            InitializeComponent();
        } 
        #endregion

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

        #region buttonOpenExcel_Click事件，打开Excel，并将Excel数据导入到DataTable中，并在DataGridView1中显示
        /// <summary>
        /// buttonOpenExcel_Click事件，打开Excel，并将Excel数据导入到DataTable中，并在DataGridView1中显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenExcel_Click(object sender, EventArgs e)
        {
            string path = GetExcelPath();
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            DataTable dt = Common.ExcelHellper.ExcelToDataTable(path, "Sheet1");
            dataGridView1.DataSource = dt;

            textBox1.Text = Common.ExcelHellper.CreateTempTableSql(dt);
        }
        #endregion

        #region 获取Excel文件的路径
        /// <summary>
        /// 获取Excel文件的路径
        /// </summary>
        /// <returns></returns>
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
        #endregion

        #region 将DataGridView1中的数据保存到Excel中
        /// <summary>
        /// 将DataGridView1中的数据保存到Excel中
        /// </summary>
        /// <returns></returns>
        private string SaveExcelPath()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文件类型（*.xlsx）|*.xlsx|文件类型（*.xls）|*.xls";//设置文件类型 
            sfd.FilterIndex = 1;    //设置默认文件类型显示顺序
            sfd.RestoreDirectory = true;    //保存对话框是否记忆上次打开的目录

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                return sfd.FileName.ToString();
            }

            return string.Empty;
        }
        #endregion

        #region buttonSaveExcel_Click事件，将dataGridView1中的数据导出到Excel中
        /// <summary>
        /// buttonSaveExcel_Click事件，将dataGridView1中的数据导出到Excel中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveExcel_Click(object sender, EventArgs e)
        {
            string path = SaveExcelPath();
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            DataTable dt = dataGridView1.DataSource as DataTable;
            Common.ExcelHellper.DataTableToExcel(dt, path, "Sheet1");
        } 
        #endregion
    }
}
