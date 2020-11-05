//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Common
{
    public class ExcelHellper
    {
        #region 读取Excel，保存到DataTable中，并返回DataTable
        /// <summary>
        /// 读取Excel，保存到DataTable中，并返回DataTable
        /// </summary>
        /// <param name="paramPath"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string paramPath, string paramSheet)
        {

            DataTable dt = new DataTable();
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;
            Excel.Range range = null;

            excelApp.Visible = false;

            try
            {

                //string path = string.Format($@"{System.Threading.Thread.GetDomain().BaseDirectory}aaa.xlsx");
                workBook = excelApp.Workbooks.Open(paramPath);
                workSheet = (Excel.Worksheet)workBook.Sheets[paramSheet];

                for (int col = 1; col <= workSheet.UsedRange.Columns.Count; col++)
                {
                    dt.Columns.Add();
                }

                for (int row = 1; row <= workSheet.UsedRange.Rows.Count; row++)
                {
                    List<string> lis = new List<string>();
                    for (int col = 1; col <= workSheet.UsedRange.Columns.Count; col++)
                    {
                        range = (Excel.Range)workSheet.Cells[row, col];
                        lis.Add(range.Value2 == null ? null : range.Value2.ToString());
                    }
                    dt.Rows.Add(lis.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                workBook.Close();
                excelApp.Quit();
            }

            return dt;
        }
        #endregion

        #region 将DataTable导出到Excel中
        /// <summary>
        /// 将DataTable导出到Excel中
        /// </summary>
        /// <param name="paramDt"></param>
        /// <param name="paramPath"></param>
        /// <param name="paramSheet"></param>
        public static void DataTableToExcel(DataTable paramDt, string paramPath, string paramSheet)
        {
            //一般在操作中，都不开这下面四个：
            Excel.Application excelApp;
            Excel._Workbook workBook;
            Excel._Worksheet workSheet;
            Excel.Range range;

            //创建Excel对象
            excelApp = new Excel.Application();
            excelApp.Visible = false;    //是否可见

            //创建一个新的工作簿、工作表
            workBook = (Excel._Workbook)(excelApp.Workbooks.Add(Missing.Value));
            //workBook = (Excel._Workbook)(excelApp.Workbooks.Add(path));
            workSheet = (Excel._Worksheet)workBook.ActiveSheet;

            for (int rowIndex = 1; rowIndex < paramDt.Rows.Count; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < paramDt.Columns.Count; columnIndex++)
                {
                    workSheet.Cells[rowIndex, columnIndex] = paramDt.Rows[rowIndex][columnIndex].ToString().Trim();
                }
            }
            workBook.Save();
            string filePath = string.Format($@"{System.Threading.Thread.GetDomain().BaseDirectory}");
            string name = "a2.xlsx";
            workBook.SaveAs(paramPath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            workBook.Close();
            excelApp.Quit();
        }
        #endregion

        #region 根据DataTable创建临时表
        /// <summary>
        /// 根据DataTable创建临时表
        /// </summary>
        /// <param name="paramDt"></param>
        /// <returns></returns>
        public static string CreateTempTableSql(DataTable paramDt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"create global temporary table tmp_test(");
            sb.AppendLine();
            int i = 0;
            foreach (DataColumn dc in paramDt.Columns)
            {
                sb.AppendLine($@"  C{i.ToString()} varchar2(128),");
                i++;
            }
            var s1 = sb.ToString().Trim().Trim(',');
            sb.Clear().Append(s1);
            sb.Append(@") on commit preserve rows;");

            sb.AppendLine();
            sb.AppendLine();
            foreach (DataRow dr in paramDt.Rows)
            {
                //insert into twocs_nurseward values('000123','ICUR','333333', sysdate);
                sb.Append($@"insert into tmp_test values(");
                foreach (var v in dr.ItemArray)
                {
                    sb.Append($@"'{v.ToString().Trim()}',");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.AppendLine(@");");
            }

            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine(@"select * from tmp_test;");
            sb.AppendLine(@"--drop table tmp_test;");
            return sb.ToString();
        }
        #endregion
    }
}
