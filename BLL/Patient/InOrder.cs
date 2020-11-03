using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Patient
{
    public class InOrder
    {
        /// <summary>
        /// InOrder类使用的日志名称
        /// </summary>
        static string LogName = "住院医嘱";

        #region 根据传入的Where条件列表，获取患者医嘱信息
        /// <summary>
        /// 根据传入的Where条件列表，获取患者医嘱信息
        /// </summary>
        /// <param name="paramWhereList">where条件列表</param>
        /// <returns></returns>
        public static DataTable GetPatOrderInfo(List<string> paramWhereList)
        {
            StringBuilder sqlStrbuider = new StringBuilder(@"select p.sname,
       zg.bdate,
       zg.orderno,
       zg.sunsunap,
       zg.jupsu,
       zg.sunap,
       b.ordernamek,
       i.outdate    as 发药日期,
       i.outtime    as 发药时间,
       ba.codename  as 发药药房,
       zg.*
  from twocs_iorder_zg zg
  left outer join twocs_ordercode b
    on zg.ordercode = b.ordercode
  left outer join twbas_patient p
    on zg.ptno = p.ptno
  left outer join twocs_iprslip i
    on zg.orderno = i.orderno
  left outer join twbas_basecode ba
    on trim(zg.senddept1) = trim(ba.code)
   and ba.bun = 'SENDDEPT'
 where 1 = 1");
            sqlStrbuider.AppendLine();
            foreach (string condition in paramWhereList)
            {
                sqlStrbuider.AppendLine($@"   and {condition}");
            }
            sqlStrbuider.AppendLine(" order by zg.bdate desc");

            LogUtility.LogHelper.WriteLog($@"---------------------------------获取患者医嘱信息：{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sqlStrbuider.ToString(), LogName);
            return DBUtility.DBHelperList.Oracle58.Query(sqlStrbuider.ToString()).Tables[0];
        }
        #endregion

        #region 根据传入OrderNo获取包含RowId字段的医嘱DataTable，以便通过RowId对医嘱进行操作（例如：停嘱，取消停嘱，允许轮训 等操作）
        /// <summary>
        /// 根据传入OrderNo获取包含RowId字段的医嘱DataTable，以便通过RowId对医嘱进行操作（例如：停嘱，取消停嘱，允许轮训 等操作）
        /// </summary>
        /// <param name="paramOrderNo">twocs_iorder_zg表中的OrderNo</param>
        /// <returns></returns>
        public static DataTable GetOrderNoDetail(string paramOrderNo)
        {
            StringBuilder sqlStrbuider = new StringBuilder($@"select rowid,
       orderno,
       sunsunap,
       jupsu,
       sunap,
       insertid,
       insertbuse,
       insertdate,
       inserttime,
       pickupid,
       pickupbuse,
       pickupdate,
       pickuptime,
       stopid,
       stopbuse,
       stopdate,
       stoptime,
       stopchkid,
       stopchkbuse,
       stopchkdate,
       stopchktime
  from twocs_iorder_zg
 where orderno = '{paramOrderNo}'
 order by bdate desc");

            LogUtility.LogHelper.WriteLog($@"---------------------------------获取医嘱详情:{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sqlStrbuider.ToString(), LogName);
            return DBUtility.DBHelperList.Oracle58.Query(sqlStrbuider.ToString()).Tables[0];
        }
        #endregion

        #region 根据传入的RowId，停止（或取消停止）此条医嘱
        /// <summary>
        /// 根据传入的RowId，停止（或取消停止）此条医嘱
        /// </summary>
        /// <param name="paramStop">true:停嘱；false:取消停嘱 </param>
        /// <param name="paramRowId">RowId</param>
        /// <returns></returns>
        public static bool StopOrder(bool paramStop, string paramRowId)
        {
            string stopSql = $@"update twocs_iorder_zg
   set stopid      = insertid,
       stopbuse    = insertbuse,
       stopdate    = insertdate,
       stoptime    = to_char(to_date(inserttime, 'hh24:mi:ss') + 1 / (24 * 60), 'hh24:mi:ss'),
       stopchkid   = pickupid,
       stopchkbuse = pickupbuse,
       stopchkdate = pickupdate,
       stopchktime = to_char(to_date(pickuptime, 'hh24:mi:ss') + 1 / (24 * 60), 'hh24:mi:ss')
 where rowid = '{paramRowId}'";

            string cancelStopSql = $@"update twocs_iorder_zg
   set stopid      = '',
       stopbuse    = '',
       stopdate    = '',
       stoptime    = '',
       stopchkid   = '',
       stopchkbuse = '',
       stopchkdate = '',
       stopchktime = ''
 where rowid = '{paramRowId}'";

            if (paramStop == true)
            {
                LogUtility.LogHelper.WriteLog($@"---------------------------------停嘱：{DateTime.Now.ToString()}---------------------------------", LogName);
                LogUtility.LogHelper.WriteLog(stopSql.ToString(), LogName);

                if (DBUtility.DBHelperList.Oracle58.ExecuteSql(stopSql) > 0)
                {
                    return true;
                }
            }
            else
            {
                LogUtility.LogHelper.WriteLog($@"---------------------------------取消停嘱：{DateTime.Now.ToString()}---------------------------------", LogName);
                LogUtility.LogHelper.WriteLog(cancelStopSql.ToString(), LogName);

                if (DBUtility.DBHelperList.Oracle58.ExecuteSql(cancelStopSql) > 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 根据RowId，允许此条医嘱进行轮训计费
        /// <summary>
        /// 根据传入的RowId，允许此条医嘱进行轮训计费
        /// </summary>
        /// <param name="paramRowId"></param>
        /// <returns></returns>
        public static bool AllowCharging(string paramRowId)
        {
            string sql = $@"update twocs_iorder_zg set jupsu = sunsunap where rowid = '{paramRowId}'";

            LogUtility.LogHelper.WriteLog($@"---------------------------------允许轮训：{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sql.ToString(), LogName);
            if (DBUtility.DBHelperList.Oracle58.ExecuteSql(sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 根据给定的Ptno，查询此患者的转科信息
        /// <summary>
        /// 根据给定的Ptno，查询此患者的转科信息
        /// </summary>
        /// <param name="paramPtno"></param>
        /// <returns></returns>
        public static string GetTrans(string paramPtno)
        {
            string sql = $@"select to_char(t.trsdate, 'YYYY/MM/DD HH24:MI:SS') as trsdate,
       t.todeptcode,
       d.deptnamek,
       t.toward,
       w.wardname,
       t.toroom,
       t.tobed
  from twipd_transfer t
 inner join twbas_dept d
    on t.todeptcode = d.deptcode
 inner join twbas_ward w
    on t.toward = w.wardcode
 where ptno = '{paramPtno}'
    order by t.trsdate desc";

            LogUtility.LogHelper.WriteLog($@"---------------------------------查询患者转科信息：{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sql.ToString(), LogName);
            Oracle.ManagedDataAccess.Client.OracleDataReader reader = DBUtility.DBHelperList.Oracle58.ExecuteReader(sql.Trim());

            StringBuilder transStrBuilder = new StringBuilder();
            while (reader.Read())
            {
                transStrBuilder.AppendLine($@"{reader["trsdate"]}=");
                transStrBuilder.AppendLine($@"({reader["todeptcode"].ToString().Trim()}){reader["deptnamek"].ToString().Trim()}-({reader["toward"].ToString().Trim()}){reader["wardname"].ToString().Trim()}-{reader["tobed"].ToString().Trim()}");
            }

            return transStrBuilder.ToString().Trim();
        }
        #endregion

        #region 根据给定的Ptno，查询此患者的出院信息
        /// <summary>
        /// 根据给定的Ptno，查询此患者的出院信息
        /// </summary>
        /// <param name="paramPtno"></param>
        /// <returns></returns>
        public static string GetOutInfo(string paramPtno)
        {
            string sql = $@"select to_char(outdate, 'YYYY/MM/DD') || ' ' ||outtime as aaa from twipd_master where ptno = '{paramPtno}' order by outtime desc";

            LogUtility.LogHelper.WriteLog($@"---------------------------------查询出院：{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sql.ToString(), LogName);
            Oracle.ManagedDataAccess.Client.OracleDataReader reader = DBUtility.DBHelperList.Oracle58.ExecuteReader(sql);

            StringBuilder outStrBuilder = new StringBuilder();
            while (reader.Read())
            {
                if (!string.IsNullOrWhiteSpace(reader["aaa"].ToString().Trim()))
                {
                    outStrBuilder.Append($@"{reader["aaa"]}=");
                    outStrBuilder.AppendLine($@"出院");
                }
            }

            return outStrBuilder.ToString().Trim();
        }
        #endregion

        #region 获取指定患者的最新的twipd_master与twipd_zytzd最新的一条信息，用户判断是否可以给twipd_zytzd表的HOSPITALIZEDUID字段赋值，来允许服务中心补打医嘱
        /// <summary>
        /// 获取指定患者的最新的twipd_master与twipd_zytzd最新的一条信息，用户判断是否可以给twipd_zytzd表的HOSPITALIZEDUID字段赋值，来允许服务中心补打医嘱
        /// </summary>
        /// <param name="paramPtno"></param>
        /// <returns></returns>
        public static (DataTable DtMast, DataTable DtZytzd) GetZYTZD(string paramPtno)
        {
            //string sqlMaster = $@"select * from (select * from twipd_master where ptno = '{paramPtno}' order by indate desc) where rownum = 1";
            //string sqlZytzd = $@"select * from (select* from twipd_zytzd where ptno = '{paramPtno}' order by indate desc) where rownum = 1";

            string sqlMaster = $@"select m.HOSPITALIZEDUID, m.* from (select * from twipd_master where ptno = '{paramPtno}' order by indate desc) m where rownum = 1";
            string sqlZytzd = $@"select  z.HOSPITALIZEDUID, z.* from (select * from twipd_zytzd where ptno = '{paramPtno}' order by indate desc) z where rownum = 1";

            DataTable dtMast = DBUtility.DBHelperList.Oracle58.Query(sqlMaster).Tables[0];
            DataTable dtZytzd = DBUtility.DBHelperList.Oracle58.Query(sqlZytzd).Tables[0];
            return (dtMast, dtZytzd);
        }
        #endregion

        #region 使twipd_zytzd表HOSPITALIZEDUID字段 = twipd_master表的HOSPITALIZEDUID字段，使服务中心可以补打住院通知单
        /// <summary>
        /// 使twipd_zytzd表HOSPITALIZEDUID字段 = twipd_master表的HOSPITALIZEDUID字段，使服务中心可以补打住院通知单
        /// </summary>
        /// <param name="paramPtno"></param>
        /// <returns></returns>
        public static string AllowPrintZYTZD(string paramPtno)
        {
            //select * from (select * from twipd_zytzd  where ptno = '0020829794' order by indate desc) where rownum = 1;
            //select* from(select* from twipd_master where ptno = '0020829794' order by indate desc) where rownum = 1;

            string sqlMaster = $@"select * from(select * from twipd_master where ptno = '{paramPtno}' order by indate desc) where rownum = 1";
            string sqlZytzd = $@"select* from(select * from twipd_zytzd where ptno = '{paramPtno}' order by indate desc) where rownum = 1";
            LogUtility.LogHelper.WriteLog($@"---------------------------------补打住院通知单：{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sqlMaster.ToString(), LogName);
            LogUtility.LogHelper.WriteLog(sqlZytzd.ToString(), LogName);

            Oracle.ManagedDataAccess.Client.OracleDataReader readerMaster = DBUtility.DBHelperList.Oracle58.ExecuteReader(sqlMaster);
            Oracle.ManagedDataAccess.Client.OracleDataReader readerZytzd = DBUtility.DBHelperList.Oracle58.ExecuteReader(sqlZytzd);

            while (readerMaster.Read() && readerZytzd.Read())
            {
                if (!string.IsNullOrWhiteSpace(readerZytzd["HOSPITALIZEDUID"].ToString().Trim()))
                {
                    string info = "twipd_zytzd表的HOSPITALIZEDUID字段不为空";
                    LogUtility.LogHelper.WriteLog(info, LogName);
                    return info;
                }

                if (!string.Equals(readerMaster["WARDCODE"].ToString().Trim(), readerZytzd["WARDCODE"].ToString().Trim()))
                {
                    string info = "未找到twipd_zytzd表与twipd_master表相同的WARDCODE字段";
                    LogUtility.LogHelper.WriteLog(info, LogName);
                    return info;
                }

                string sql = $@"update twipd_zytzd
   set HOSPITALIZEDUID = '{readerMaster["HOSPITALIZEDUID"].ToString().Trim()}'
 where ptno = '{paramPtno.Trim()}'
   and entdate = to_date('{readerZytzd["ENTDATE"].ToString().Trim()}', 'YYYY/MM/DD HH24:MI:SS')";

                LogUtility.LogHelper.WriteLog(sql.ToString(), LogName);
                DBUtility.DBHelperList.Oracle58.ExecuteSql(sql);

                return "更新成功！";
            }

            return "No成功！";
        }
        #endregion

        #region 根据医嘱编号，获取交费情况
        /// <summary>
        /// 根据医嘱编号，获取交费情况
        /// </summary>
        /// <param name="paramPtno"></param>
        /// <returns></returns>
        public static DataTable GetSlip(string paramOrderNo)
        {
            string sql = $@"select * from twipd_slip where orderno = '{paramOrderNo}'";
            LogUtility.LogHelper.WriteLog($@"---------------------------------交费单：{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sql.ToString(), LogName);
            return DBUtility.DBHelperList.Oracle58.Query(sql).Tables[0];
        } 
        #endregion
    }
}