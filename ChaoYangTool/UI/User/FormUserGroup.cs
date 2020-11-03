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
    public partial class FormUserGroup : UUI.Docking.DockContent
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FormUserGroup()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载函数
        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormUserGroup_Load(object sender, EventArgs e)
        {
            SetlistViewGroup();
        }
        #endregion

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormUserGroup Singleton_ = null;

        public static FormUserGroup CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormUserGroup();
                    }
                }
            }
            return Singleton_;
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

        #region 设置用户组
        /// <summary>
        /// 设置用户组
        /// </summary>
        private void SetlistViewGroup()
        {
            listViewGroup.View = View.Details;
            listViewGroup.CheckBoxes = true;
            listViewGroup.GridLines = true;
            listViewGroup.FullRowSelect = true;
            listViewGroup.HideSelection = true;
            listViewGroup.Items.Clear();
            listViewGroup.Columns.Add("GroupName", listViewGroup.Width, HorizontalAlignment.Left);
            //listViewGroup.Width = listViewGroup.Columns[0].Width;

            DataTable dtRole = BLL.User.UserGroup.GetGroup();
            for (int i = 0; i < dtRole.Rows.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(dtRole.Rows[i]["GroupName"].ToString().Trim());
                listViewItem.Tag = dtRole.Rows[i]["GroupId"].ToString().Trim();
                listViewGroup.Items.Add(listViewItem);
            }
        }
        #endregion

        #region FormUserGroup_Paint 事件
        /// <summary>
        /// FormUserGroup_Paint 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormUserGroup_Paint(object sender, PaintEventArgs e)
        {
            listViewGroup.Columns[0].Width = listViewGroup.Width;
        }
        #endregion

        #region textBoxFindGroup_KeyDown - 查询Group
        /// <summary>
        /// 查询Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFindGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < listViewGroup.Items.Count; i++)
                {
                    listViewGroup.Items[i].BackColor = Color.White;
                    listViewGroup.Items[i].ForeColor = Color.Black;
                }

                ListViewItem founfitem = listViewGroup.FindItemWithText(textBoxFindGroup.Text, true, 0);
                if (founfitem != null)
                {
                    listViewGroup.TopItem = founfitem;
                    founfitem.ForeColor = Color.Red;
                }
            }
        }
        #endregion

        #region buttonAddUserGroup_Click事件 - 添加用户到组
        /// <summary>
        /// 添加用户到组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddUserGroup_Click(object sender, EventArgs e)
        {
            textBoxSql.Clear();
            (List<string> UserIdList, Dictionary<string, string> WardDic) tuple = GetUserIdWTuple();
            textBoxSql.Text = BLL.User.UserGroup.AddUserToGroup(tuple.UserIdList, tuple.WardDic);
        }
        #endregion


        private (List<string> UserIdList, Dictionary<string, string> GrpupDic) GetUserIdWTuple()
        {
            List<string> userIdList = new List<string>();
            Dictionary<string, string> groupDic = new Dictionary<string, string>();

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

            foreach (ListViewItem ward in listViewGroup.Items)
            {
                if (ward.Checked == false)
                {
                    continue;
                }

                groupDic.Add(ward.Tag.ToString().Trim(), ward.Text.Trim());
            }

            return (userIdList, groupDic);
        }

        private void buttonExecuteSql_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否将数据更新到数据库", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            DBUtility.DBHelperList.Oracle58.ExecuteSql(textBoxSql.Text);
            MessageBox.Show("执行成功");
        }

        private void buttonDelUserGroup_Click(object sender, EventArgs e)
        {
            textBoxSql.Clear();
            (List<string> UserIdList, Dictionary<string, string> WardDic) tuple = GetUserIdWTuple();
            textBoxSql.Text = BLL.User.UserGroup.AddUserToGroup(tuple.UserIdList, tuple.WardDic).Replace("insert", "--insert"); ;
        }
    }
}
