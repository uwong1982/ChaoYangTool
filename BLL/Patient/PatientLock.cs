using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Patient
{
    public class PatientLock
    {
        /// <summary>
        /// PatientLock类使用的日志名称
        /// </summary>
        private static string LogName = "患者锁";

        #region 根据传入的Where条件列表，获取锁定的用户列表
        /// <summary>
        /// 根据传入的Where条件列表，获取锁定的用户列表
        /// </summary>
        /// <param name="paramWhereList"></param>
        /// <returns></returns>
        public static DataTable GetLockPatient(List<string> paramWhereList)
        {
            StringBuilder sqlStrBuilder = new StringBuilder(@"select l.gbdata,
       l.ptno,
       p.sname,
       l.seqno,
       l.username,
       l.remark,
       l.wrttime,
       l.ip,
       l.ver,
       l.pcname
  from twbas_lock l
  left outer join twbas_patient p
    on l.ptno = p.ptno
 where 1=1 ");
            sqlStrBuilder.AppendLine();

            if (paramWhereList != null || paramWhereList.Count > 0)
            {
                foreach (string condition in paramWhereList)
                {
                    sqlStrBuilder.AppendLine($@"   and {condition}");
                }
            }

            LogUtility.LogHelper.WriteLog($@"---------------------------------获取锁定用户列表:{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sqlStrBuilder.ToString(), LogName);
            return DBUtility.DBHelperList.Oracle58.Query(sqlStrBuilder.ToString()).Tables[0];
        }
        #endregion

        #region 根据传入的Where条件列表，获取自助机锁定的用户列表
        /// <summary>
        /// 根据传入的Where条件列表，获取自助机锁定的用户列表
        /// </summary>
        /// <param name="paramWhere"></param>
        /// <returns></returns>
        public static DataTable GetLockAutoPatient(List<string> paramWhere)
        {
            StringBuilder sqlStrBuilder = new StringBuilder(@"select k.lockid,
       p.ptno,
       p.sname,
       '自助机' ip,
       '' version,
       k.opuser,
       k.lockedtime,
       round((sysdate - k.lockedtime) / (1 / 24 / 60)) pasttime
  from twopd_ssp_lock k
  left join twopd_jupmst p
    on k.regno = p.regno
 where k.status = 'L'
   and p.regno is not null
   and k.lockedtime > trunc(sysdate)");
            sqlStrBuilder.AppendLine();

            #region 旧的Sql语句
            /*
                StringBuilder sql1 = new StringBuilder(@"
    select p.ptno, p.sname, k.lockedtime, ps.name, k.lockid, k.regno
      from twopd_ssp_lock k
     inner join twopd_ssp_order o
        on k.lockid = o.orderid
     inner join twbas_patient p
        on o.patientid = p.ptno
     inner join twbas_pass ps
        on k.opuser = ps.idnumber
     where k.status = 'L'
       and k.lockedtime >= trunc(sysdate)");
                */
            #endregion

            if (paramWhere != null)
            {
                foreach (string condition in paramWhere)
                {
                    sqlStrBuilder.AppendLine($@"   and {condition}");
                }
            }

            LogUtility.LogHelper.WriteLog($@"---------------------------------获取自助机锁定用户:{DateTime.Now.ToString()}---------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sqlStrBuilder.ToString(), LogName);
            return DBUtility.DBHelperList.Oracle58.Query(sqlStrBuilder.ToString()).Tables[0];
        }
        #endregion

        #region 根据给定的PtNo列表，解锁患者
        /// <summary>
        /// 根据传入的PtNo列表，解锁患者
        /// </summary>
        /// <param name="paramPtNoList">twbas_lock表中的PtNo列表</param>
        public static void GetDeleteLock(List<string> paramPtNoList)
        {
            if (paramPtNoList == null || paramPtNoList.Count <= 0)
            {
                return;
            }

            StringBuilder sqlStrBuilder = new StringBuilder();
            foreach (string condition in paramPtNoList)
            {
                sqlStrBuilder.Append($@",'{condition}'");
            }
            sqlStrBuilder.Remove(0, 1);

            string sql = $@"delete from twbas_lock where ptno in ({sqlStrBuilder.ToString()})";
            LogUtility.LogHelper.WriteLog("--------------------解锁用户-------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sql.ToString(), LogName);
            DBUtility.DBHelperList.Oracle58.ExecuteSql(sql);
        }
        #endregion

        #region 根据给定的LockId列表，解锁自助机患者
        /// <summary>
        /// 根据给定的LockId列表，解锁自助机患者
        /// </summary>
        /// <param name="paramLockIdList">twopd_ssp_lock表中的LockId列表</param>
        public static void GetDeleteAutoLock(List<string> paramLockIdList)
        {
            if (paramLockIdList == null)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (string condition in paramLockIdList)
            {
                sb.Append($@",'{condition}'");
            }
            sb.Remove(0, 1);

            string sql = $@"update twopd_ssp_lock set status = 'U' where lockid in ({sb.ToString()})";

            LogUtility.LogHelper.WriteLog("--------------------解锁自助机用户-------------------------------", LogName);
            LogUtility.LogHelper.WriteLog(sql.ToString(), LogName);
            DBUtility.DBHelperList.Oracle58.ExecuteSql(sql);
        }
        #endregion
    }
}
