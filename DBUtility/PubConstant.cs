using System;

namespace DBUtility
{
    class PubConstant
    {
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        internal static string GetConnectionString(string configName)
        {
            //string connectionString = System.Configuration.ConfigurationManager.AppSettings[configName];
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[configName].ConnectionString;
            string ConStringEncrypt = System.Configuration.ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                connectionString = DEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }
    }
}