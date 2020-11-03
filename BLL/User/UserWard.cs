using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.User
{
    public class UserWard
    {
        /// <summary>
        /// 病区名称
        /// </summary>
        static string logName = "UserWard";

        #region 获取病区列表
        /// <summary>
        /// 获取病区列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWard()
        {
            string sql = "select * from twbas_ward order by WardName";
            LogUtility.LogHelper.WriteLog($"-------------------------获取病区列表-------------------------", logName);
            LogUtility.LogHelper.WriteLog(sql, logName);
            return DBUtility.DBHelperList.Oracle58.Query(sql).Tables[0];
        }
        #endregion

        #region 保留给定的病区用户，其他的都删除
        /// <summary>
        /// 保留给定的病区用户，其他的都删除
        /// </summary>
        /// <param name="paramUserIdList"></param>
        /// <param name="paramWardDic"></param>
        public static string RetainWardUser(List<string> paramUserIdList, Dictionary<string, string> paramWardDic)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("begin");
            stringBuilder.AppendLine();

            foreach (KeyValuePair<string, string> wardDic in paramWardDic)
            {
                string wardId = wardDic.Key.ToString().Trim();
                string wardName = wardDic.Value.ToString().Trim();
                string sql11 = $"delete from twocs_nurseward where trim(wardCode) = '{wardId}';";
                LogUtility.LogHelper.WriteLog($"-------------------------删除{wardName}所有都用户-------------------------", logName);
                LogUtility.LogHelper.WriteLog(sql11, logName);
                stringBuilder.Append(sql11);
                stringBuilder.AppendLine();
            }
            LogUtility.LogHelper.WriteLog("Commit;", logName);

            stringBuilder.AppendLine();
            StringBuilder sb = new StringBuilder(AddUserToWard(paramUserIdList, paramWardDic));
            sb.Replace("begin", "");
            sb.Replace("end;", "");
            stringBuilder.Append(sb.ToString());
            stringBuilder.Append("end;");
            return stringBuilder.ToString();
        }
        #endregion

        #region 添加用户到病区
        /// <summary>
        /// 添加用户到病区
        /// </summary>
        /// <param name="paramUserIdList"></param>
        /// <param name="paramWardDic"></param>
        public static string AddUserToWard(List<string> paramUserIdList, Dictionary<string, string> paramWardDic)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("begin");
            stringBuilder.AppendLine();

            foreach (string user in paramUserIdList)
            {
                if (DBUtility.DBHelperList.Oracle58.Exists($@"select * from twbas_pass where idnumber = '{user}'") == false)
                {
                    LogUtility.LogHelper.WriteLog($@"'{user}',", "UserRole_OCS未添加");
                    stringBuilder.Insert(0, new StringBuilder($@"----'{user}' UserRole_OCS未添加").AppendLine());
                    continue;
                }

                if (DBUtility.DBHelperList.Oracle58.Exists($@"select * from t_security_users where UserName = '{user}'") == false) //select * from t_security_users
                {
                    LogUtility.LogHelper.WriteLog($@"'{user}',", "UserRole_His未添加");
                    stringBuilder.Insert(0, new StringBuilder($@"----'{user}' UserRole_His未添加").AppendLine());
                    continue;
                }

                //LogUtility.LogHelper.WriteLog($@"'{user}',", "WardName_备份");

                foreach (KeyValuePair<string, string> wardDic in paramWardDic)
                {
                    string wardId = wardDic.Key.ToString().Trim();
                    string wardName = wardDic.Value.ToString().Trim();

                    DataTable dt = DBUtility.DBHelperList.Oracle58.Query($"select idnumber, name from twbas_pass where trim(idnumber) = '{user}'").Tables[0];

                    string sql1 = $"delete from twocs_nurseward where trim(nurseCode) = '{dt.Rows[0]["idnumber"].ToString().Trim()}' and trim(wardCode) = '{wardId}';";
                    string sql2 = $"insert into twocs_nurseward values('{dt.Rows[0]["idnumber"].ToString().Trim()}','{wardId}','333333', sysdate);";

                    LogUtility.LogHelper.WriteLog($"-------------------------{user}\t{dt.Rows[0]["name"].ToString()}\t{wardName}-------------------------", logName);
                    LogUtility.LogHelper.WriteLog(sql1, logName);
                    LogUtility.LogHelper.WriteLog(sql2, logName);

                    stringBuilder.Append($"-------------------------{user}\t{dt.Rows[0]["name"].ToString()}\t{wardName}-------------------------");
                    stringBuilder.AppendLine();
                    stringBuilder.Append(sql1);
                    stringBuilder.AppendLine();
                    stringBuilder.Append(sql2);
                    stringBuilder.AppendLine();
                }
            }
            LogUtility.LogHelper.WriteLog("Commit;", logName);

            stringBuilder.Append("end;");
            return stringBuilder.ToString();
        }
        #endregion

    }
}