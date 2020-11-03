using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UUI.Docking;

namespace ChaoYangTool
{
    public partial class FormMain : Form
    {
        UUI.ThemeVS2015.VS2015LightTheme _VS2015LightTheme1 = new UUI.ThemeVS2015.VS2015LightTheme();
        UUI.ThemeVS2015.VS2015BlueTheme _VS2015LightTheme2 = new UUI.ThemeVS2015.VS2015BlueTheme();
        DocumentStyle _DocumentStyle = DocumentStyle.DockingWindow;
        Action<string> _Action;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载函数
        /// <summary>
        /// 窗体家在函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            _Action = CreateForm;
            DockPanelStyle();            
            Menu();
        }

        /// <summary>
        /// 设置DockPanel Style
        /// </summary>
        private void DockPanelStyle()
        {
            dockPanel1.Theme = _VS2015LightTheme1;
            dockPanel1.DocumentStyle = _DocumentStyle;
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        private new void Menu()
        {
            FormMenu formMenu = FormMenu.CreateSingleton();
            formMenu.mAction = CreateForm;
            formMenu.Show(dockPanel1, DockState.DockLeft);
        }

        #endregion

        #region 显示菜单 - toolStripMenuItemMenu_Click(object sender, EventArgs e)
        /// <summary>
        /// 显示菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemMenu_Click(object sender, EventArgs e)
        {
            Menu();
        }
        #endregion

        #region 维护用户病区
        /// <summary>
        /// 维护用户病区
        /// </summary>
        private void UserWard()
        {
            UI.User.FormUserWard form = UI.User.FormUserWard.CreateSingleton();
            form.WindowState = FormWindowState.Normal;
            form.Show(dockPanel1, DockState.Document);

        }
        #endregion

        #region 解锁患者
        /// <summary>
        /// 解锁患者
        /// </summary>
        private void PatientLock()
        {
            UI.Patient.FormLock form = UI.Patient.FormLock.CreateSingleton();
            form.WindowState = FormWindowState.Normal;
            form.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region 创建窗体
        /// <summary>
        /// 创建窗体
        /// </summary>
        /// <param name="paramFormName">窗体的类名（例如：ChaoYangTool.UI.Patient.FormLock）。</param>
        public void CreateForm(string paramFormName)
        {
            UUI.Docking.DockContent from = Type.GetType(paramFormName).GetMethod("CreateSingleton").Invoke(null, null) as UUI.Docking.DockContent;
            from.WindowState = FormWindowState.Normal;
            from.Show(dockPanel1, DockState.Document);
        } 
        #endregion
    }
}