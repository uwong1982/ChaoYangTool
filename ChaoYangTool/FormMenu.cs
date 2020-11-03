using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaoYangTool
{
    public partial class FormMenu : UUI.Docking.DockContent
    {
        public Action<string> mAction { get; set; }

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        private FormMenu()
        {
            InitializeComponent();
        } 
        #endregion

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormMenu Singleton_ = null;

        public static FormMenu CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormMenu();
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
        private void FormMenu_Load(object sender, EventArgs e)
        {
            treeViewMenu.ExpandAll();
        }
        #endregion

        #region 单击 Menu treeView 节点，打开相应的窗体
        /// <summary>
        /// 单击 Menu treeView 节点，打开相应的窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            if (e.Node.Tag == null)
            {
                MessageBox.Show($@"未设置 ""{e.Node.Text.Trim()}"" 结点的Tag");
                return;
            }

            mAction(e.Node.Tag.ToString().Trim());
        } 
        #endregion
    }
}
