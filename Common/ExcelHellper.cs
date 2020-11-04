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
                        lis.Add(range.Value2==null?"null": range.Value2.ToString());
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
    }
}
