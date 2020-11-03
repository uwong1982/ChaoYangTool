using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.User
{
    public class MainDiagnosisGroup
    {
        /// <summary>
        /// 日志名称
        /// </summary>
        static string logName = "MainDiagnosisGroup_主诊组";

        #region 获取指定科室的病区
        /// <summary>
        /// 获取指定科室的病区
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWard(string paramWardCode = null)
        {
            StringBuilder sb = new StringBuilder($@"select wardcode, wardname from twbas_ward");
            sb.AppendLine();
            sb.AppendLine("where 1=1");
            if (!string.IsNullOrWhiteSpace(paramWardCode))
            {
                if (Regex.IsMatch(paramWardCode.Trim(), @"^[a-zA-Z]*$"))
                {
                    sb.AppendLine($@" and upper(trim(wardcode)) like upper(trim('%{paramWardCode.Trim()}%'))");
                }
                else
                {
                    sb.AppendLine($@" and upper(trim(wardname)) like upper(trim('%{paramWardCode.Trim()}%'))");
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("wardcode"), new DataColumn("wardname") });

            LogUtility.LogHelper.WriteLog($@"------------------------获取指定科室的病区：{DateTime.Now.ToString()}------------------------", logName);
            LogUtility.LogHelper.WriteLog(sb.ToString(), logName);
            Oracle.ManagedDataAccess.Client.OracleDataReader reader = DBUtility.DBHelperList.Oracle58.ExecuteReader(sb.ToString().Trim());
            //dt.Rows.Add(string.Empty, string.Empty);
            while (reader.Read())
            {
                dt.Rows.Add(reader["wardcode"].ToString().Trim(), reader["wardname"].ToString().Trim());
            }
            return dt;
        }
        #endregion

        #region 获取科室列表
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable getDept(string paramDeptCode = null)
        {
            StringBuilder sb = new StringBuilder($@"select deptcode, deptnamek from twbas_dept");
            sb.AppendLine();
            sb.AppendLine("where 1=1");
            if (!string.IsNullOrWhiteSpace(paramDeptCode))
            {
                if (Regex.IsMatch(paramDeptCode.Trim(), @"^[a-zA-Z]*$"))
                {
                    sb.AppendLine($@" and upper(trim(deptcode)) like upper(trim('%{paramDeptCode.Trim()}%'))");
                }
                else
                {
                    sb.AppendLine($@" and upper(trim(deptnamek)) like upper(trim('%{paramDeptCode.Trim()}%'))");
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("deptcode"), new DataColumn("deptnamek") });

            LogUtility.LogHelper.WriteLog($@"------------------------获取科室列表：{DateTime.Now.ToString()}------------------------", logName);
            LogUtility.LogHelper.WriteLog(sb.ToString(), logName);
            Oracle.ManagedDataAccess.Client.OracleDataReader reader = DBUtility.DBHelperList.Oracle58.ExecuteReader(sb.ToString().Trim());
            //dt.Rows.Add(string.Empty, string.Empty);
            while (reader.Read())
            {
                dt.Rows.Add(reader["deptcode"].ToString().Trim(), reader["deptnamek"].ToString().Trim());
            }
            return dt;
        }
        #endregion

        #region 获取指定的病区的床位列表
        /// <summary>
        /// 获取指定的病区的床位列表
        /// </summary>
        /// <param name="paramWardCode"></param>
        /// <returns></returns>
        public static DataTable GetWardBed(string paramWardCode)
        {
            string sql = $@"
select r.rowid, d.deptnamek, r.BedNo, b.codename, r.dmgcode
  from twbas_room r
  left outer join twbas_dept d
    on lower(trim(r.deptcode)) = lower(trim(d.deptcode))
  left outer join twbas_basecode b
    on r.dmgcode = b.code
   and b.business = '住院服务中心'
   and b.bun = '疾病主诊疗组'
 where r.wardcode = '{paramWardCode.Trim()}'
   and r.gbuse = '0'
   and r.inpatiservecenter = '0'
 order by r.bedno";

            LogUtility.LogHelper.WriteLog($@"------------------------获取指定的病区的床位列表：{DateTime.Now.ToString()}------------------------", logName);
            LogUtility.LogHelper.WriteLog(sql, logName);
            return DBUtility.DBHelperList.Oracle58.Query(sql.Trim()).Tables[0];
        }
        #endregion

        #region 获取指定科室的主诊组列表
        /// <summary>
        /// 获取指定科室的主诊组列表
        /// </summary>
        /// <param name="paramDetp"></param>
        /// <returns></returns>
        public static DataTable GetDm(string paramDetp)
        {
            string sql = $@"
select d.deptnamek, b.*
  from twbas_basecode b
  left outer join twbas_dept d
    on lower(trim(b.codename_ex)) = lower(trim(d.deptcode))
 where b.business = '住院服务中心'
   and b.bun = '疾病主诊疗组'
   and upper(trim(b.codename_ex)) like '%{paramDetp.Trim()}%'
 order by code";

            LogUtility.LogHelper.WriteLog($@"------------------------获取指定科室的主诊组列表：{DateTime.Now.ToString()}------------------------", logName);
            LogUtility.LogHelper.WriteLog(sql, logName);
            return DBUtility.DBHelperList.Oracle58.Query(sql.Trim()).Tables[0];
        }
        #endregion

        #region 设置床位的负责医生
        /// <summary>
        /// 设置床位的负责医生
        /// </summary>
        /// <param name="paramMdg"></param>
        /// <param name="paramWhere"></param>
        public static void SetMdg(string paramMdg, List<string> paramWhere)
        {
            if (paramWhere == null)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (string kv in paramWhere)
            {
                sb.Append($@",'{kv}'");
            }
            sb.Remove(0, 1);

            string sql = $@"update twbas_room set dmgcode = '{paramMdg}' where rowid in ({sb.ToString()})";
            LogUtility.LogHelper.WriteLog($@"------------------------设置床位的负责医生：{DateTime.Now.ToString()}------------------------", logName);
            LogUtility.LogHelper.WriteLog(sql, logName);
            DBUtility.DBHelperList.Oracle58.ExecuteSql(sql);
        } 
        #endregion
    }
}
