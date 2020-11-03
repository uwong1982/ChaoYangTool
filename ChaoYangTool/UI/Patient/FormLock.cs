using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaoYangTool.UI.Patient
{
    public partial class FormLock : UUI.Docking.DockContent
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        private FormLock()
        {
            InitializeComponent();
        }
        #endregion

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormLock Singleton_ = null;

        public static FormLock CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormLock();
                    }
                }
            }
            return Singleton_;
        }
        #endregion

        #region 患者信息文本框回车，搜索锁定患者
        /// <summary>
        /// 患者信息文本框回车，搜索锁定患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPatInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxLockedMinute.Text = string.Empty;
                SearchLockedPatient();
            }
        }
        #endregion

        #region 搜索锁定的患者
        /// <summary>
        /// 搜索锁定的患者
        /// </summary>
        private void SearchLockedPatient()
        {
            List<string> whereList = new List<string>();

            if (!string.IsNullOrWhiteSpace(textBoxLockedMinute.Text.Trim()))
            {
                if (!Regex.IsMatch(textBoxLockedMinute.Text.Trim(), @"^[0-9]*$"))
                {
                    MessageBox.Show("时间必须是纯数字");
                    return;
                }

                whereList.Add($"sysdate - wrttime > 1 / 24 / 60 * {textBoxLockedMinute.Text.Trim()}");
                dataGridViewLockedPatient.DataSource = BLL.Patient.PatientLock.GetLockPatient(whereList);
                dataGridViewMachineLockedPatient.DataSource = null;
            }
            else
            {
                if (Regex.IsMatch(textBoxPatInfo.Text.Trim(), @"^[0-9]*$"))
                {
                    whereList.Add($@"p.ptno like '%{textBoxPatInfo.Text.Trim()}%'");
                }
                else
                {
                    whereList.Add($@"p.sname like '%{textBoxPatInfo.Text.Trim()}%'");
                }
                dataGridViewLockedPatient.DataSource = BLL.Patient.PatientLock.GetLockPatient(whereList);
                dataGridViewMachineLockedPatient.DataSource = BLL.Patient.PatientLock.GetLockAutoPatient(whereList);
            }
        }
        #endregion

        #region 锁定时间文本框回车，搜索锁定患者
        /// <summary>
        /// 锁定时间文本框回车，搜索锁定患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxLockedMinute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPatInfo.Text = string.Empty;
                SearchLockedPatient();
            }
        }
        #endregion

        #region 批量解锁患者
        /// <summary>
        /// 批量解锁患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUnlockAll_Click(object sender, EventArgs e)
        {
            List<string> ptList = new List<string>();
            foreach (DataGridViewRow dr in dataGridViewLockedPatient.Rows)
            {
                ptList.Add(dr.Cells["PtNo"].Value.ToString().Trim());
            }
            BLL.Patient.PatientLock.GetDeleteLock(ptList);
            dataGridViewLockedPatient.DataSource = null;
            MessageBox.Show("OK");
        }
        #endregion

        #region 双击解锁患者
        /// <summary>
        /// 双击解锁患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewLockedPatient_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<string> ptList = new List<string>();
            ptList.Add(dataGridViewLockedPatient.SelectedRows[0].Cells["PtNo"].Value.ToString().Trim());
            BLL.Patient.PatientLock.GetDeleteLock(ptList);
            dataGridViewLockedPatient.Rows.Remove(dataGridViewLockedPatient.SelectedRows[0]);
            MessageBox.Show("OK");
        }
        #endregion

        #region 双击解锁自助机患者
        /// <summary>
        /// 双击解锁自助机患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMachineLockedPatient_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<string> ptList = new List<string>();
            ptList.Add(dataGridViewMachineLockedPatient.SelectedRows[0].Cells["lockid"].Value.ToString().Trim());
            BLL.Patient.PatientLock.GetDeleteAutoLock(ptList);
            dataGridViewMachineLockedPatient.Rows.Remove(dataGridViewMachineLockedPatient.SelectedRows[0]);
            MessageBox.Show("OK");
        } 
        #endregion
    }
}
