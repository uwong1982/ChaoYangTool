using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaoYangTool.UI.Med
{
    public partial class FormInternetMed : UUI.Docking.DockContent
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FormInternetMed()
        {
            InitializeComponent();
        } 
        #endregion

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormInternetMed Singleton_ = null;

        public static FormInternetMed CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormInternetMed();
                    }
                }
            }
            return Singleton_;
        }
        #endregion

        #region 窗体加载函数
        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInternetMed_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region buttonAddMed_Click事件 - 根据“textBoxOrderCode”与“textBoxPumCode”添加互联网用药
        /// <summary>
        /// 根据“textBoxOrderCode”与“textBoxPumCode”添加互联网用药
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddMed_Click(object sender, EventArgs e)
        {
            buttonAddMed.Enabled = false;

            List<string> orderCodeList = new List<string>();
            foreach (string orderCode in textBoxOrderCode.Lines)
            {
                if (string.IsNullOrWhiteSpace(orderCode))
                {
                    continue;
                }

                orderCodeList.Add(orderCode.Trim());
            }

            List<string> pumCodeList = new List<string>();
            foreach (string pumCode in textBoxPumCode.Lines)
            {
                if (string.IsNullOrWhiteSpace(pumCode))
                {
                    continue;
                }

                pumCodeList.Add(pumCode.Trim());
            }

            textBoxSql.Text=BLL.Med.InternetMed.CreateSqlOfAddInternetMed(orderCodeList, pumCodeList);
            buttonAddMed.Enabled = true;
        }

        #endregion

        #region 在“textBoxOrderCode”与“textBoxPumCode”文本框上，按Ctrl+A实现全选
        /// <summary>
        /// 在textBoxOrderCode文本框上，按Ctrl+A实现全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxOrderCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 在textBoxPumCode文本框上，按Ctrl+A实现全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPumCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
        #endregion

        #region 执行textBoxSql中的SQL语句
        /// <summary>
        /// 执行textBoxSql中的SQL语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExecuteSql_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否将数据更新到数据库", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            DBUtility.DBHelperList.Oracle58.ExecuteSql(textBoxSql.Text);
            MessageBox.Show("执行成功");
        } 
        #endregion
    }
}
