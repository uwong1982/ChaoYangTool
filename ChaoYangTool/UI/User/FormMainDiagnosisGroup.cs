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
    public partial class FormMainDiagnosisGroup : UUI.Docking.DockContent
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FormMainDiagnosisGroup()
        {
            InitializeComponent();
        }
        #endregion

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormMainDiagnosisGroup Singleton_ = null;

        public static FormMainDiagnosisGroup CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormMainDiagnosisGroup();
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
        private void FormMainDiagnosisGroup_Load(object sender, EventArgs e)
        {
            GetDetp();
            GetWard();

            /*
             * AlternatingRowsDefaultCellStyle 属性
             * 获取或设置应用于 DataGridView 的奇数行的默认单元格样式。
             * RowsDefaultCellStyle 属性
             * 获取或设置应用于 DataGridView 的行单元格的默认样式。
             * 只需要增加以下代码即可实现隔行变色
            */
            dataGridViewMdg.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridViewMdg.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dataGridViewBed.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridViewBed.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }
        #endregion

        #region 获取科室列表
        /// <summary>
        /// 获取科室列表
        /// </summary>
        private void GetDetp()
        {
            comboBoxDept.DisplayMember = "deptnamek";
            comboBoxDept.ValueMember = "deptcode";
            comboBoxDept.DataSource = BLL.User.MainDiagnosisGroup.getDept();
        }
        #endregion

        #region 获取床位列表
        /// <summary>
        /// 获取床位列表
        /// </summary>
        private void GetWard()
        {
            comboBoxWard.DisplayMember = "wardname";
            comboBoxWard.ValueMember = "wardcode";
            comboBoxWard.DataSource = BLL.User.MainDiagnosisGroup.GetWard();
        }
        #endregion

        #region comboBoxWard回车时间 - 搜索病区床位
        /// <summary>
        /// comboBoxWard回车时间 - 搜索病区床位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxWard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            comboBoxWard.DataSource = BLL.User.MainDiagnosisGroup.GetWard(comboBoxWard.Text.Trim());

            if (comboBoxWard.SelectedValue != null)
            {
                dataGridViewBed.DataSource = BLL.User.MainDiagnosisGroup.GetWardBed(comboBoxWard.SelectedValue.ToString().Trim());
            }
        }
        #endregion

        #region comboBoxDept按下回车键，过滤科室
        /// <summary>
        /// comboBoxDept按下回车键，过滤科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            comboBoxDept.DataSource = BLL.User.MainDiagnosisGroup.getDept(comboBoxDept.Text.Trim());

            if (comboBoxDept.SelectedValue != null)
            {
                dataGridViewMdg.DataSource = BLL.User.MainDiagnosisGroup.GetDm(comboBoxDept.SelectedValue.ToString().Trim());
            }
        }
        #endregion

        #region comboBoxWard_SelectedIndexChanged，搜索床位列表
        /// <summary>
        /// comboBoxWard_SelectedIndexChanged，搜索床位列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWard.SelectedValue != null)
            {
                dataGridViewBed.DataSource = BLL.User.MainDiagnosisGroup.GetWardBed(comboBoxWard.SelectedValue.ToString().Trim());
            }
        }
        #endregion

        #region comboBoxDept_SelectedIndexChanged，搜索科室
        /// <summary>
        /// comboBoxDept_SelectedIndexChanged，搜索科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDept.SelectedValue != null)
            {
                dataGridViewMdg.DataSource = BLL.User.MainDiagnosisGroup.GetWardBed(comboBoxDept.SelectedValue.ToString().Trim());
            }
        }
        #endregion

        #region dataGridViewMdg_MouseDoubleClick事件，确定床位负责医生
        /// <summary>
        /// dataGridViewMdg_MouseDoubleClick事件，确定床位负责医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMdg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("是否确定要设置主诊组啊", "危险的操作啊", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            string mdg = dataGridViewMdg.SelectedRows[0].Cells["code"].Value.ToString().Trim();

            List<string> mdgList = new List<string>();
            foreach (DataGridViewRow dr in dataGridViewBed.SelectedRows)
            {
                mdgList.Add(dr.Cells["RowId"].Value.ToString().Trim());
            }

            BLL.User.MainDiagnosisGroup.SetMdg(mdg, mdgList);

            if (comboBoxDept.SelectedValue != null)
            {
                dataGridViewMdg.DataSource = BLL.User.MainDiagnosisGroup.GetDm(comboBoxDept.SelectedValue.ToString().Trim());
            }

            if (comboBoxWard.SelectedValue != null)
            {
                dataGridViewBed.DataSource = BLL.User.MainDiagnosisGroup.GetWardBed(comboBoxWard.SelectedValue.ToString().Trim());
            }
        } 
        #endregion
    }
}
