namespace LogUtility
{
    public class LogHelper
    {
        #region 成员变量
        /// <summary>
        /// 日志目录
        /// </summary>
        private const string FolderName = "EventLog";
        /// <summary>
        /// 日志文件名
        /// </summary>
        private const string logFileName = ".Log";
        #endregion

        #region 私有构造函数
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private LogHelper()
        {

        }
        #endregion

        #region 写日志 (按月份创建日志文件夹，按月份创建日志文件)
        /// <summary>
        /// 写日志 (按年份创建日志文件夹，按天创建日志文件)
        /// </summary>
        /// <param name="paramText">日志内容</param>
        public static void WriteLog(string paramText)
        {
            WriteLog(paramText, null);
        }

        /// <summary>
        /// 写日志 (按年份创建日志文件夹，按月份创建日志文件)
        /// </summary>
        /// <param name="paramText">日志内容</param>
        /// <param name="paramLogName">日志标题</param>
        /// <param name="paramLogType">日志类型：1-Wpf or Winform Application; 2-WebApplication</param>
        public static void WriteLog(string paramText, string paramLogName = null, int paramLogType = 1)
        {
            string folderPath = string.Empty;
            if (paramLogType == 1)
            {
                //folderPath = string.Format($@"{Environment.CurrentDirectory}\{FolderName}_{System.DateTime.Now.ToString("yyyy")}");
                folderPath = string.Format($@"{System.Threading.Thread.GetDomain().BaseDirectory}{FolderName}_{System.DateTime.Now.ToString("yyyy")}");
            }
            else if (paramLogType == 2)
            {
                //folderPath = string.Format($@"{System.Web.HttpContext.Current.Server.MapPath(FolderName)}_{System.DateTime.Now.ToString("yyyy")}");
            }

            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }

            string filePath = string.IsNullOrWhiteSpace(paramLogName) ? string.Format($@"{folderPath}\{System.DateTime.Today.ToString("yyyy_MM_dd")}{logFileName}") : string.Format($@"{folderPath}\{System.DateTime.Today.ToString("yyyy_MM_dd")}_{paramLogName}{logFileName}");

            System.IO.StreamWriter stremWriter = null;
            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    stremWriter = System.IO.File.CreateText(filePath);
                }
                else
                {
                    stremWriter = System.IO.File.AppendText(filePath);
                }

                //stremWriter.WriteLine(string.Format($"\r\n---------Log Time:{System.DateTime.Now.ToString()}--------\r\n{ paramText}"));
                stremWriter.WriteLine(string.Format($"{paramText}"));
            }
            finally
            {
                if (stremWriter != null)
                {
                    stremWriter.Close();
                    stremWriter = null;
                }
            }
        }
        #endregion
    }
}