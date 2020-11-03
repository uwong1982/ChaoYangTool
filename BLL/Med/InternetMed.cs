using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Med
{
    public class InternetMed
    {
        /// <summary>
        /// InternetMed类使用的日志名称
        /// </summary>
        static string LogName = "互联网用药";

        #region 根据传入的OrderCodeList与PumCodeList，生成添加互联网药品的Sql语句并返回
        /// <summary>
        /// 根据传入的OrderCodeList与PumCodeList，生成添加互联网药品的Sql语句并返回
        /// </summary>
        /// <param name="paramOrderCodeList">OrderCode - twocs_ordercode表字段</param>
        /// <param name="paramPumCodeList">PumCode - twbas_tsuga表字段</param>
        /// <returns>添加互联网药品的Sql语句</returns>
        public static string CreateSqlOfAddInternetMed(List<string> paramOrderCodeList, List<string> paramPumCodeList)
        {
            List<(string orderCode, string orderNameK)> orderList = new List<(string orderCode, string orderNameK)>();
            StringBuilder sqlStrbuider = new StringBuilder();
            sqlStrbuider.AppendLine("begin");

            (List<(string orderCode, string orderNameK)> OrderCodeList, string Info) OrderListByOrderCodeList = GetOrderListByOrderCodeList(paramOrderCodeList);
            orderList.AddRange(OrderListByOrderCodeList.OrderCodeList);
            sqlStrbuider.AppendLine(OrderListByOrderCodeList.Info);
            sqlStrbuider.AppendLine();
            LogUtility.LogHelper.WriteLog("", LogName);

           (List<(string orderCode, string orderNameK)> OrderCodeList, string Info) OrderListByPumCodeList = GetOrderListByPumCodeList(paramPumCodeList);
            orderList.AddRange(OrderListByPumCodeList.OrderCodeList);
            sqlStrbuider.AppendLine(OrderListByPumCodeList.Info);
            sqlStrbuider.AppendLine();
            LogUtility.LogHelper.WriteLog("", LogName);

            foreach ((string orderCode, string orderNameK) order in orderList)
            {
                string sqlIsExistInOrderSub = $@"select * from twocs_ordercode_sub where upper(trim(ordercode)) = '{order.orderCode.Trim().ToUpper()}'";
                if (DBUtility.DBHelperList.Oracle58.Exists(sqlIsExistInOrderSub) == false)
                {
                    string sql1 = $@"-----------插入'{order.orderCode.Trim()}'  '{order.orderNameK.Trim()} {DateTime.Now.ToString()}'-----------";
                    string sql2 = $@"delete from twocs_ordercode_sub where ordercode = '{order.orderCode.Trim()}';";
                    string sql3 = $@"insert into twocs_ordercode_sub values ('{order.orderCode.Trim()}', 0, '20190730142028880047', '0.00', '1');";

                    sqlStrbuider.AppendLine(sql1);
                    sqlStrbuider.AppendLine(sql2);
                    sqlStrbuider.AppendLine(sql3);

                    LogUtility.LogHelper.WriteLog(sql1, LogName);
                    LogUtility.LogHelper.WriteLog(sql2, LogName);
                    LogUtility.LogHelper.WriteLog(sql3, LogName);
                }
                else
                {
                    string sql1 = $@"-----------更新'{order.orderCode.Trim()}'  '{order.orderNameK.Trim()}' {DateTime.Now.ToString()}-----------";
                    string sql2 = $@"update twocs_ordercode_sub set ordertype = 1 where upper(trim(ordercode)) = '{order.orderCode.Trim()}';";

                    sqlStrbuider.AppendLine(sql1);
                    sqlStrbuider.AppendLine(sql2);

                    LogUtility.LogHelper.WriteLog(sql1, LogName);
                    LogUtility.LogHelper.WriteLog(sql2, LogName);
                }
            }
            sqlStrbuider.AppendLine("end;");

            return sqlStrbuider.ToString().Trim();
        }
        #endregion

        #region 检验传入的OrderCodeList中的OrderCode是否在twocs_ordercode表中存在；返回存在的OrderCode；提示不存在的OrderCode；
        /// <summary>
        /// 检验传入的OrderCodeList中的OrderCode是否在twocs_ordercode表中存在；返回存在的OrderCode；提示不存在的OrderCode；
        /// </summary>
        /// <param name="paramOrderCodeList">OrderCode - twocs_ordercode字段</param>
        /// <returns></returns>
        private static (List<(string orderCode, string orderNameK)> OrderCodeList, string Info) GetOrderListByOrderCodeList(List<string> paramOrderCodeList)
        {
            List<(string orderCode, string orderNameK)> orderist = new List<(string orderCode, string orderNameK)>();
            StringBuilder infoStrBuilder = new StringBuilder();

            if (paramOrderCodeList == null || paramOrderCodeList.Count <= 0)
            {
                return (orderist, infoStrBuilder.ToString());
            }

            StringBuilder sqlStrBuilder = new StringBuilder();
            LogUtility.LogHelper.WriteLog($@"---------------------------------检查ordercode是否存在：{DateTime.Now.ToString()}---------------------------------", LogName);
            foreach (string orderCode in paramOrderCodeList)
            {
                string sqlIsExistOrderCode = $@"select ordercode, ordernamek from twocs_ordercode where upper(trim(ordercode)) = '{orderCode.Trim().ToUpper()}'";                
                if (DBUtility.DBHelperList.Oracle58.Exists(sqlIsExistOrderCode) == false)
                {
                    infoStrBuilder.AppendLine($@"--在twocs_ordercode不存在的ordercode：{orderCode}");
                    LogUtility.LogHelper.WriteLog($@"{sqlIsExistOrderCode} --不存在", LogName);
                    LogUtility.LogHelper.WriteLog(orderCode, $@"{LogName}_在twocs_ordercode不存在的ordercode");
                    continue;
                }

                sqlStrBuilder.Append($@"'{orderCode.Trim().ToUpper()}',");
                LogUtility.LogHelper.WriteLog($@"{sqlIsExistOrderCode}", LogName);
            }

            if (sqlStrBuilder.Length <= 0)
            {
                return (orderist, infoStrBuilder.ToString());
            }

            sqlStrBuilder.Insert(0, "select ordercode, ordernamek from twocs_ordercode where upper(trim(ordercode)) in (");
            sqlStrBuilder.Remove(sqlStrBuilder.Length - 1, 1);
            sqlStrBuilder.Append(")");


            LogUtility.LogHelper.WriteLog($@"---------------------------------根据paramOrderCodeList获取OrderCodeList：{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sqlStrBuilder.ToString().Trim(), LogName);
            Oracle.ManagedDataAccess.Client.OracleDataReader reader = DBUtility.DBHelperList.Oracle58.ExecuteReader(sqlStrBuilder.ToString().Trim());
            while (reader.Read())
            {
                orderist.Add((reader["ordercode"].ToString().Trim(), reader["ordernamek"].ToString().Trim()));
            }

            return (orderist, infoStrBuilder.ToString());
        }
        #endregion

        #region 检验传入的PumCodeArray的PumCode是否在twbas_tsuga表中存在；返回存在的OrderCode；提示不存在的PumCode；
        /// <summary>
        /// 检验传入的PumCodeArray的PumCode是否在twbas_tsuga表中存在；返回存在的OrderCode；提示不存在的PumCode；
        /// </summary>
        /// <param name="paramPumCodeList">PumCode - twbas_tsuga表字段</param>
        /// <returns></returns>
        private static (List<(string orderCode, string orderNameK)> GetOrderCodeList, string Info) GetOrderListByPumCodeList(List<string> paramPumCodeList)
        {
            List<(string orderCode, string orderNameK)> orderList = new List<(string orderCode, string orderNameK)>();
            StringBuilder infoStrBuilder = new StringBuilder();

            if (paramPumCodeList == null || paramPumCodeList.Count <= 0)
            {
                return (orderList, infoStrBuilder.ToString());
            }

            StringBuilder sqlStrbuider = new StringBuilder();
            LogUtility.LogHelper.WriteLog($@"---------------------------------检查pumcode是否存在：{DateTime.Now.ToString()}---------------------------------", LogName);
            foreach (string pumcode in paramPumCodeList)
            {
                string sqlIsExistPumCode = $@"select sucode from twbas_tsuga where upper(trim(pumcode)) = '{pumcode.Trim().ToUpper()}'";
                if (DBUtility.DBHelperList.Oracle58.Exists(sqlIsExistPumCode) == false)
                {
                    infoStrBuilder.AppendLine($@"--在twbas_tsuga不存在的pumcode：{pumcode}");
                    LogUtility.LogHelper.WriteLog($@"{sqlIsExistPumCode} --不存在", LogName);
                    LogUtility.LogHelper.WriteLog(pumcode, $@"{LogName}_在twbas_tsuga不存在的pumcode");
                    continue;
                }

                sqlStrbuider.Append($@"'{pumcode.Trim().ToUpper()}',");
                LogUtility.LogHelper.WriteLog($@"{sqlIsExistPumCode}", LogName);
            }

            if (sqlStrbuider.Length <= 0)
            {
                return (orderList, infoStrBuilder.ToString());
            }

            sqlStrbuider.Insert(0, $@"select distinct ordercode, ordernamek
  from twocs_ordercode
 where gbinput = '1'
   and sucode in (select sucode
                    from twbas_tsuga
                   where pumcode in
(");
            sqlStrbuider.Remove(sqlStrbuider.Length - 1, 1);
            sqlStrbuider.Append("))");

            LogUtility.LogHelper.WriteLog($@"---------------------------------根据paramPumCodeArray获取OrderCodeList：{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sqlStrbuider.ToString(), LogName);
            Oracle.ManagedDataAccess.Client.OracleDataReader reader = DBUtility.DBHelperList.Oracle58.ExecuteReader(sqlStrbuider.ToString().Trim());
            while (reader.Read())
            {
                orderList.Add((reader["ordercode"].ToString().Trim(), reader["ordernamek"].ToString().Trim()));
            }

            return (orderList, infoStrBuilder.ToString());
        } 
        #endregion
    }
}