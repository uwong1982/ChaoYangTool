//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Common
{
    public class ExcelHellper 
    {
        /// <summary>
        /// 读取Excel，并保存到DataTable中 
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

        public static void DataTableToExcel(DataTable paramDt,string paramPath, string paramSheet)
        {

        }
    }
}
