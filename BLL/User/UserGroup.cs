using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.User
{
    public class UserGroup
    {
        /// <summary>
        /// 日志名称
        /// </summary>
        static string logName = "UserGroup_用户组";

        #region 获取组列表
        /// <summary>
        /// 获取组列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetGroup()
        {
            string sql = "select * from t_security_groups order by GroupName";
            LogUtility.LogHelper.WriteLog($"-------------------------获取组列表：{DateTime.Now.ToString()}-------------------------", logName);
            LogUtility.LogHelper.WriteLog(sql, logName);
            return DBUtility.DBHelperList.Oracle58.Query(sql).Tables[0];
        }
        #endregion

        #region 添加用户到组
        /// <summary>
        /// 添加用户到组
        /// </summary>
        /// <param name="paramUserIdList"></param>
        /// <param name="paramRoleDic"></param>
        public static string AddUserToGroup(List<string> paramUserIdList, Dictionary<string, string> paramRoleDic)
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

                //LogUtility.LogHelper.WriteLog($@"'{user}',", "roleName_备份");

                foreach (KeyValuePair<string, string> roleDic in paramRoleDic)
                {
                    string roleId = roleDic.Key.ToString().Trim();
                    string roleName = roleDic.Value.ToString().Trim();

                    string sql0 = $@"
select inn.userid, p.idnumber, p.name
  from t_security_users inn
 inner join twbas_pass p
    on inn.userName = p.idnumber
 where inn.username = '{user}'";
                    DataTable dt = DBUtility.DBHelperList.Oracle58.Query(sql0).Tables[0];

                    string sql1 = $"delete from t_security_usersingroups where trim(userId) = '{dt.Rows[0]["userid"].ToString().Trim()}' and trim(groupId) = '{roleId}';";
                    string sql2 = $"insert into t_security_usersingroups values('{dt.Rows[0]["userid"].ToString().Trim()}','{roleId}');";

                    LogUtility.LogHelper.WriteLog($"-------------------------{user}\t{dt.Rows[0]["name"].ToString()}\t{roleName}-------------------------", logName);
                    LogUtility.LogHelper.WriteLog(sql1, logName);
                    LogUtility.LogHelper.WriteLog(sql2, logName);

                    stringBuilder.Append($"-------------------------{user}\t{dt.Rows[0]["name"].ToString()}\t{roleName}-------------------------");
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
