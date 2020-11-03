using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaoYangTool.UI.User
{
    public partial class FormUserWard : UUI.Docking.DockContent
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        private FormUserWard()
        {
            InitializeComponent();
        }
        #endregion

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormUserWard Singleton_ = null;

        public static FormUserWard CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormUserWard();
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
        private void FormUserWard_Load(object sender, EventArgs e)
        {
            //AutoScaleMode = AutoScaleMode.Dpi;
            DoubleBuff();
            //Task.Run(SetListVieWard);
            Thread t = new Thread(()=>SetListVieWard());
            t.IsBackground = true;
            t.Start();
            //SetListVieWard();
        }
        #endregion

        #region 双缓冲，防止闪烁
        /// <summary>
        /// 双缓冲，防止闪烁
        /// </summary>
        private void DoubleBuff()
        {
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            //SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
        #endregion

        #region 在用户列表文本框上，按Ctrl+A实现全选
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUserIdList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        /// <summary>
        /// 在用户列表文本框上，按Ctrl+A实现全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 在用户列表文本框上，按Ctrl+A实现全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        #endregion

        #region 在病区搜索框回车，实现搜索
        /// <summary>
        /// 在病区搜索框回车，实现搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFindWard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            for (int i = 0; i < listViewWard.Items.Count; i++)
            {
                listViewWard.Items[i].BackColor = Color.White;
                listViewWard.Items[i].ForeColor = Color.Black;
            }

            ListViewItem founfitem = listViewWard.FindItemWithText(textBoxFindWard.Text, true, 0);
            if (founfitem != null)
            {
                listViewWard.TopItem = founfitem;
                founfitem.ForeColor = Color.Red;
            }
        }
        #endregion

        #region 初始化病区列表 listViewWard
        /// <summary>
        /// 初始化病区列表 listViewWard
        /// </summary>
        private void SetListVieWard()
        {
            //Thread.Sleep(5000);
            listViewWard.Invoke(new Action(() =>
            {
                listViewWard.View = View.Details;
                listViewWard.CheckBoxes = true;
                listViewWard.GridLines = true;
                listViewWard.FullRowSelect = true;
                listViewWard.HideSelection = true;
                listViewWard.Items.Clear();
                listViewWard.Columns.Add("RoleName", listViewWard.Width, HorizontalAlignment.Left);
                //listViewWard.Width = listViewWard.Columns[0].Width;

                DataTable dtRole = BLL.User.UserWard.GetWard();
                for (int i = 0; i < dtRole.Rows.Count; i++)
                {
                    ListViewItem listViewItem = new ListViewItem(dtRole.Rows[i]["WardName"].ToString().Trim());
                    listViewItem.Tag = dtRole.Rows[i]["WardCode"].ToString().Trim();
                    listViewWard.Items.Add(listViewItem);
                }
            }));
        }
        #endregion

        #region 根据用户的录入，生成用户的 (Id List) - (ward List) 元组
        /// <summary>
        /// 根据用户的录入，生成用户的 (Id List) - (ward List) 元组
        /// </summary>
        /// <returns></returns>
        private (List<string> UserIdList, Dictionary<string, string> WardDic) GetUserIdWardTuple()
        {
            List<string> userIdList = new List<string>();
            Dictionary<string, string> wardDic = new Dictionary<string, string>();

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

            foreach (ListViewItem ward in listViewWard.Items)
            {
                if (ward.Checked == false)
                {
                    continue;
                }

                wardDic.Add(ward.Tag.ToString().Trim(), ward.Text.Trim());
            }

            return (userIdList, wardDic);
        }
        #endregion

        #region 绘制窗体的时候发生
        /// <summary>
        /// 绘制窗体的时候发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormUserWard_Paint(object sender, PaintEventArgs e)
        {
            if (listViewWard.Columns.Count <= 0)
            {
                return;
            }
            listViewWard.Columns[0].Width = listViewWard.Width; //设置listViewWard的宽度
        }

        #endregion

        #region 生成“给用户添加病区”的Sql语句
        /// <summary>
        /// 生成“给用户添加病区”的Sql语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddUserWard_Click(object sender, EventArgs e)
        {
            textBoxSql.Clear();
            (List<string> UserIdList, Dictionary<string, string> WardDic) tuple = GetUserIdWardTuple();
            textBoxSql.Text = BLL.User.UserWard.AddUserToWard(tuple.UserIdList, tuple.WardDic);
        }
        #endregion

        #region 执行Sql语句
        /// <summary>
        /// 执行Sql语句
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

        #region 生成“保留病区的指定用户，未指定的删除”的Sql语句
        /// <summary>
        /// 生成“保留病区的指定用户，未指定的删除”的Sql语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRetainWardUser_Click(object sender, EventArgs e)
        {
            textBoxSql.Clear();
            (List<string> UserIdList, Dictionary<string, string> WardDic) tuple = GetUserIdWardTuple();
            textBoxSql.Text = BLL.User.UserWard.RetainWardUser(tuple.UserIdList, tuple.WardDic);
        }
        #endregion

        #region 删除用户病区
        /// <summary>
        /// 删除用户病区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelUserWard_Click(object sender, EventArgs e)
        {
            textBoxSql.Clear();
            (List<string> UserIdList, Dictionary<string, string> WardDic) tuple = GetUserIdWardTuple();
            textBoxSql.Text = BLL.User.UserWard.AddUserToWard(tuple.UserIdList, tuple.WardDic).Replace("insert", "--insert");
        }
        #endregion        
    }
}
