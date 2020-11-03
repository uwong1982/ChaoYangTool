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
    public partial class FormInOrder : UUI.Docking.DockContent
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        private FormInOrder()
        {
            InitializeComponent();
        }
        #endregion

        #region Singleton
        private static readonly object Singleton_Lock = new object();
        private static volatile FormInOrder Singleton_ = null;

        public static FormInOrder CreateSingleton()
        {
            if (Singleton_ == null || Singleton_.IsDisposed)
            {
                lock (Singleton_Lock)
                {
                    if (Singleton_ == null || Singleton_.IsDisposed)
                    {
                        Singleton_ = new FormInOrder();
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
        private void FormInOrder_Load(object sender, EventArgs e)
        {
            SetDataGridViewColor();
        }
        #endregion

        #region 设置DataGridView隔行变色
        /// <summary>
        /// 设置DataGridView隔行变色
        /// </summary>
        private void SetDataGridViewColor()
        {
            /*
             * AlternatingRowsDefaultCellStyle 属性
             * 获取或设置应用于 DataGridView 的奇数行的默认单元格样式。
             * RowsDefaultCellStyle 属性
             * 获取或设置应用于 DataGridView 的行单元格的默认样式。
             * 只需要增加以下代码即可实现隔行变色
            */
            dataGridViewPatOrderInfo.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridViewPatOrderInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dataGridViewOrderNoDetail.RowsDefaultCellStyle.BackColor = Color.Silver;
            dataGridViewOrderNoDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dataGridViewSlip.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridViewSlip.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }
        #endregion

        #region textBoxPatInfo_KeyDown & textBoxOrderName_KeyDown 事件 - 查询患者信息
        /// <summary>
        /// 查询患者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPatInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            GetPatInfo();
        }

        /// <summary>
        /// 查询患者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxOrderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            GetPatInfo();
        }
        #endregion

        #region 获取患者信息
        /// <summary>
        /// 获取患者信息
        /// </summary>
        private void GetPatInfo()
        {

            if (IsPtNoIsNumber() == false)
            {
                return;
            }

            FillZero();
            GetTransInfo(textBoxPatInfo.Text.Trim());
            GetOutInfo(textBoxPatInfo.Text.Trim());
            GetOrderInfo(textBoxPatInfo.Text.Trim());
            GetZytzdInfo();
        }
        #endregion

        #region 获取住院通知单信息
        /// <summary>
        /// 获取住院通知单信息
        /// </summary>
        private void GetZytzdInfo()
        {
            (DataTable DtMast, DataTable DtZytzd) aaa = BLL.Patient.InOrder.GetZYTZD(textBoxPatInfo.Text.Trim());
            dataGridViewIpdMaster.DataSource = aaa.DtMast;
            dataGridViewIpdZytzd.DataSource = aaa.DtZytzd;

            dataGridViewIpdMaster.Columns["HOSPITALIZEDUID"].DefaultCellStyle.BackColor = Color.DarkOrange;
            dataGridViewIpdZytzd.Columns["HOSPITALIZEDUID"].DefaultCellStyle.BackColor = Color.DarkOrange;
            dataGridViewIpdMaster.Columns[0].DefaultCellStyle.BackColor = Color.DarkOrange;
            dataGridViewIpdZytzd.Columns[0].DefaultCellStyle.BackColor = Color.DarkOrange;

            dataGridViewIpdMaster.Columns[0].Width = 150;
            dataGridViewIpdZytzd.Columns[0].Width = 150;
            dataGridViewIpdZytzd.ClearSelection();
        } 
        #endregion

        #region 判断患者ID是否合法
        /// <summary>
        /// 判断患者ID是否合法
        /// </summary>
        /// <returns></returns>
        private bool IsPtNoIsNumber()
        {
            if (string.IsNullOrWhiteSpace(textBoxPatInfo.Text.Trim()))
            {
                return false;
            }

            if (!Regex.IsMatch(textBoxPatInfo.Text.Trim(), @"^[0-9]*$"))
            {
                MessageBox.Show("患者ID只能是数字");
                return false; ;
            }

            return true;
        }
        #endregion

        #region 患者ID补“0”
        /// <summary>
        /// 患者编号补“0”
        /// </summary>
        private void FillZero()
        {
            StringBuilder ptno = new StringBuilder();
            ptno.Append(textBoxPatInfo.Text.Trim());
            while (ptno.Length < 10)
            {
                ptno.Insert(0, "0");
            }
            textBoxPatInfo.Text = ptno.ToString().Trim();
        }
        #endregion

        #region 获取患者转科信息
        /// <summary>
        /// 获取患者转科信息
        /// </summary>
        /// <param name="paramPtno"></param>
        private void GetTransInfo(string paramPtno)
        {
            richTextBoxTrans.Text = string.Empty;
            richTextBoxTrans.Text = BLL.Patient.InOrder.GetTrans(paramPtno.Trim());
            int index = 0;
            int length = 20;
            foreach (char s in richTextBoxTrans.Text)
            {
                index++;
                if (s == '=')
                {
                    richTextBoxTrans.Select((index - length) < 0 ? 0 : (index - length), length);
                    richTextBoxTrans.SelectionColor = Color.Red;
                }
            }
        }
        #endregion

        #region 出院信息
        /// <summary>
        /// 出院信息
        /// </summary>
        /// <param name="paramPtno"></param>
        private void GetOutInfo(string paramPtno)
        {
            richTextBoxOutInfo.Text = string.Empty;
            richTextBoxOutInfo.Text = BLL.Patient.InOrder.GetOutInfo(paramPtno.Trim());
            int index = 0;
            int length = 17;
            foreach (char s in richTextBoxOutInfo.Text)
            {
                index++;
                if (s == '=')
                {
                    richTextBoxOutInfo.Select((index - length) < 0 ? 0 : (index - length), length);
                    richTextBoxOutInfo.SelectionColor = Color.Red;
                }
            }
        }
        #endregion

        #region 获取患者医嘱信息
        /// <summary>
        /// 获取患者医嘱信息
        /// </summary>
        /// <param name="paramPtno"></param>
        private void GetOrderInfo(string paramPtno)
        {
            #region sql语句示范
            /*
            string sql = @"
select p.sname,
       zg.bdate,
       zg.orderno,
       zg.sunsunap,
       zg.jupsu,
       zg.sunap,
       b.ordernamek,
       i.outdate    as 发药日期,
       i.outtime    as 发药时间,
       zg.*
  from twocs_iorder_zg zg
  left outer join twocs_ordercode b
    on zg.ordercode = b.ordercode
  left outer join twbas_patient p
    on zg.ptno = p.ptno
  left outer join twocs_iprslip i
    on zg.orderno = i.orderno
 where 1 = 1
   and zg.ptno = '0002877825'
--and zg.bdate = date '2020-8-10'
--and bdate = trunc(sysdate)
--and zg.sunap = 1
--and zg.jsqty = 0
--and trim(zg.roomcode) = 'F1011'
--and b.ordernamek like '%颗粒%'
--and b.ordernamek in ('手术标本病理诊断')
--and zg.orderno = '15793653'
 order by zg.bdate desc";
            */
            #endregion

            List<string> where = new List<string>();

            where.Add($@"zg.ptno = '{textBoxPatInfo.Text.Trim()}'");

            if (dateTimePicker1.Checked == true)
            {
                where.Add($@"zg.bdate = date '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'");
            }

            if (!string.IsNullOrWhiteSpace(textBoxOrderName.Text.Trim()))
            {
                string orders = textBoxOrderName.Text.Trim().Replace('，', ',');
                string[] ss = orders.Split(',');

                StringBuilder sb = new StringBuilder();
                sb.Append("(");
                foreach (string s in ss)
                {
                    sb.Append($@"b.ordernamek like '%{s}%' or ");
                }
                sb.Remove(sb.Length - 3, 3);
                sb.Append(")");
                where.Add(sb.ToString());
            }

            dataGridViewPatOrderInfo.DataSource = BLL.Patient.InOrder.GetPatOrderInfo(where);
        }
        #endregion

        #region dataGridViewPatOrderInfo_CellClick 事件 - 获取OrderNo详细信息
        /// <summary>
        /// 获取OrderNo详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewPatOrderInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetOrderDeteil();
        }
        #endregion

        #region 获取OrderNo详细信息
        /// <summary>
        /// 获取OrderNo详细信息
        /// </summary>
        private void GetOrderDeteil()
        {
            string orderNo = dataGridViewPatOrderInfo.CurrentRow.Cells["orderno"].Value.ToString().Trim();

            dataGridViewOrderNoDetail.DataSource = null;
            dataGridViewOrderNoDetail.DataSource = BLL.Patient.InOrder.GetOrderNoDetail(orderNo);

            dataGridViewSlip.DataSource = null;
            dataGridViewSlip.DataSource = BLL.Patient.InOrder.GetSlip(orderNo);
        }
        #endregion

        #region toolStripMenuItemStopOrder_Click 事件 - 停嘱
        /// <summary>
        /// 停嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemStopOrder_Click(object sender, EventArgs e)
        {
            string rowid = dataGridViewOrderNoDetail.SelectedRows[0].Cells["rowId"].Value.ToString().Trim();
            BLL.Patient.InOrder.StopOrder(true, rowid);
            GetOrderDeteil();
            SelectCurrentRow(rowid);
        }
        #endregion

        #region toolStripMenuItemCancelStopOrder_Click 事件 - 取消停嘱
        /// <summary>
        /// 取消停嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemCancelStopOrder_Click(object sender, EventArgs e)
        {
            string rowid = dataGridViewOrderNoDetail.SelectedRows[0].Cells["rowId"].Value.ToString().Trim();
            BLL.Patient.InOrder.StopOrder(false, rowid);
            GetOrderDeteil();
            SelectCurrentRow(rowid);
        }
        #endregion

        #region toolStripMenuItemAllowCharging_Click 事件 - 允许轮训
        /// <summary>
        /// 允许轮训
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAllowCharging_Click(object sender, EventArgs e)
        {
            string rowid = dataGridViewOrderNoDetail.SelectedRows[0].Cells["rowId"].Value.ToString().Trim();
            BLL.Patient.InOrder.AllowCharging(rowid);
            GetOrderDeteil();
            SelectCurrentRow(rowid);
        }
        #endregion

        #region 选择当前行
        /// <summary>
        /// 选择当前行
        /// </summary>
        /// <param name="rowid"></param>
        private void SelectCurrentRow(string rowid)
        {
            foreach (DataGridViewRow r in dataGridViewOrderNoDetail.Rows)
            {
                r.Selected = false;

                if (r.Cells["rowId"].Value.ToString().Equals(rowid))
                {
                    r.Selected = true;
                    dataGridViewOrderNoDetail.CurrentCell = r.Cells["rowId"];
                }
            }
        }
        #endregion

        #region 右键单击，弹出快捷菜单
        /// <summary>
        /// 右键单击，弹出快捷菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewOrderNoDetail_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (dataGridViewPatOrderInfo.Rows[e.RowIndex].Selected == false)//若行已是选中状态就不再进行设置
                    {
                        dataGridViewOrderNoDetail.ClearSelection();
                        dataGridViewOrderNoDetail.Rows[e.RowIndex].Selected = true;
                    }

                    if (dataGridViewOrderNoDetail.SelectedRows.Count == 1)//只选中一行时设置活动单元格
                    {
                        dataGridViewOrderNoDetail.CurrentCell = dataGridViewOrderNoDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }

                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);//弹出操作菜单
                }
            }
        }
        #endregion

        #region buttonAllowPrintZytzd_Click事件 - 允许打印住院通知单
        /// <summary>
        /// 允许打印住院通知单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAllowPrintZytzd_Click(object sender, EventArgs e)
        {
            textBox1.Text = BLL.Patient.InOrder.AllowPrintZYTZD(textBoxPatInfo.Text.Trim());
        }
        #endregion

    }
}