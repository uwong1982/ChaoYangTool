using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.User
{
    public class UserRole
    {
        /// <summary>
        /// 日志名称
        /// </summary>
        static string logName = "UserRole_用户角色";

        #region 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRole()
        {
            string sql = "select * from t_security_roles";
            return DBUtility.DBHelperList.Oracle58.Query(sql).Tables[0];
        }
        #endregion

        #region 添加用户到角色
        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="paramUserIdList"></param>
        /// <param name="paramRoleDic"></param>
        public static string AddUserToRole(List<string> paramUserIdList, Dictionary<string, string> paramRoleDic)
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

                    string sql1 = $"delete from t_security_usersinroles where trim(userId) = '{dt.Rows[0]["userid"].ToString().Trim()}' and trim(roleId) = '{roleId}';";
                    string sql2 = $"insert into t_security_usersinroles values('{dt.Rows[0]["userid"].ToString().Trim()}','{roleId}');";
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

            stringBuilder.Append("end;");
            LogUtility.LogHelper.WriteLog("Commit;", logName);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 与AddUserToRole()的区别为：只生成Insert语句，不生成Delete语句
        /// </summary>
        /// <param name="paramUserIdList"></param>
        /// <param name="paramRoleDic"></param>
        public static void AddUserToRole_2(List<string> paramUserIdList, Dictionary<string, string> paramRoleDic)
        {
            foreach (string user in paramUserIdList)
            {
                if (DBUtility.DBHelperList.Oracle58.Exists($@"select * from twbas_pass where idnumber = '{user}'") == false)
                {
                    LogUtility.LogHelper.WriteLog($@"'{user}',", "UserRole_OCS未添加");
                    continue;
                }

                if (DBUtility.DBHelperList.Oracle58.Exists($@"select * from t_security_users where UserName = '{user}'") == false) //select * from t_security_users
                {
                    LogUtility.LogHelper.WriteLog($@"'{user}',", "UserRole_His未添加");
                    continue;
                }

                LogUtility.LogHelper.WriteLog($@"'{user}',", "roleName_备份");

                foreach (KeyValuePair<string, string> roleDic in paramRoleDic)
                {
                    string roleId = roleDic.Key.ToString().Trim();
                    string roleName = roleDic.Value.ToString().Trim();

                    string sql = $@"
select *
  from t_security_users us
  left join t_security_usersinroles ur
    on us.userid = ur.userid
 where us.username = '{user}'
 and ur.roleid = '{roleId}'";

                    //LogUtility.LogHelper.WriteLog($"{sql};", "sql");


                    if (DBUtility.DBHelperList.Oracle58.Query(sql).Tables[0].Rows.Count <= 0)
                    {
                        DataTable dt = DBUtility.DBHelperList.Oracle58.Query($@"select * from t_security_users where username = '{user}'").Tables[0];
                        string sql2 = $@"insert into t_security_usersinroles values('{dt.Rows[0][0].ToString()}','{roleId}');";
                        LogUtility.LogHelper.WriteLog(sql2, $"{roleName}_insert");
                        DBUtility.DBHelperList.Oracle58.ExecuteSql(sql2);
                    }
                }
            }
        }
        #endregion
    }
}
