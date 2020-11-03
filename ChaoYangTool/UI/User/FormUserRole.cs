using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaoYangTool.UI.User
{
    public partial class FormUserRole : UUI.Docking.DockContent
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FormUserRole()
        {
            InitializeComponent();
        } 
        #endregion

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormUserRole Singleton_ = null;

        public static FormUserRole CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormUserRole();
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
        private void FormUserRole_Load(object sender, EventArgs e)
        {
            SetListViewRole();
        }
        #endregion

        #region FormUserRole_Paint
        private void FormUserRole_Paint(object sender, PaintEventArgs e)
        {
            listViewRole.Columns[0].Width = listViewRole.Width;
        }
        #endregion

        #region UserId列表，按Ctrl+A实现全选
        /// <summary>
        /// UserId列表，按Ctrl+A实现全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUserIdList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
        #endregion

        #region 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void SetListViewRole()
        {
            listViewRole.View = View.Details;
            listViewRole.CheckBoxes = true;
            listViewRole.GridLines = true;
            listViewRole.FullRowSelect = true;
            listViewRole.HideSelection = true;
            listViewRole.Items.Clear();
            listViewRole.Columns.Add("RoleName", listViewRole.Width, HorizontalAlignment.Left);
            //listViewRole.Width = listViewRole.Columns[0].Width;

            DataTable dtRole = BLL.User.UserRole.GetRole();
            for (int i = 0; i < dtRole.Rows.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(dtRole.Rows[i]["RoleName"].ToString().Trim());
                listViewItem.Tag = dtRole.Rows[i]["RoleId"].ToString().Trim();
                listViewRole.Items.Add(listViewItem);
            }
        }
        #endregion

        #region 查找角色
        /// <summary>
        /// 查找角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFindRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < listViewRole.Items.Count; i++)
                {
                    listViewRole.Items[i].BackColor = Color.White;
                    listViewRole.Items[i].ForeColor = Color.Black;
                }

                ListViewItem founfitem = listViewRole.FindItemWithText(textBoxFindRole.Text, true, 0);
                if (founfitem != null)
                {
                    listViewRole.TopItem = founfitem;
                    founfitem.ForeColor = Color.Red;
                }
            }
        }
        #endregion        

        #region 添加用户角色
        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddUserRole_Click(object sender, EventArgs e)
        {
            List<string> userIdList = new List<string>();
            Dictionary<string, string> roleDic = new Dictionary<string, string>();

            StringBuilder sb = new StringBuilder();
            foreach (string s in textBoxUserIdList.Lines)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    continue;
                }

                sb.Clear();
                sb.Append(s.Trim());
                while (sb.Length < 6)
                {
                    sb.Insert(0, "0");
                }
                userIdList.Add(sb.ToString());
            }

            foreach (ListViewItem role in listViewRole.Items)
            {
                if (role.Checked == false)
                {
                    continue;
                }

                roleDic.Add(role.Tag.ToString().Trim(), role.Text.Trim());
            }

            textBoxSql.Text = BLL.User.UserRole.AddUserToRole(userIdList, roleDic);
        }
        #endregion

        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句
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
