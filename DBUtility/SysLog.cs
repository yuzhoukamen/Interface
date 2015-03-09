using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Alif.DBUtility
{
    /// <summary>
    ///  系统日志类
    /// </summary>
    public class SysLog
    {
        /// <summary>
        /// 数据库日志
        /// </summary>
        public static string dbLog
        {
            get
            {
                try
                {
                    string str = System.IO.Path.Combine(PubConstant.LogDir, "log/DBLog/");

                    return str;
                }
                catch
                {
                    return "log/DBLog/";
                }
            }
        }

        /// <summary>
        /// 添加数据库查询日志
        /// </summary>
        /// <param name="message">查询内容</param>
        public static bool AddDBLog(string message)
        {
            try
            {
                if (PubConstant.DBLog.Equals("off"))
                {
                    return false;
                }
                DateTime dt = DateTime.Now;
                string filePath = GetFilePath(dbLog, dt);
                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }
                filePath = System.IO.Path.Combine(filePath, "DBlog_" + dt.Day.ToString() + ".log");
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true);
                sw.WriteLine(dt.ToString("HH:mm:ss") + "  " + message);
                sw.Close();
                sw.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 生成文件存放路径
        /// </summary>
        /// <param name="mdir"></param>
        /// <param name="dtadd"></param>
        /// <returns></returns>
        public static string GetFilePath(string directory, DateTime dTime)
        {
            if (directory == null) return dTime.ToString("yyyy-MM");
            else return System.IO.Path.Combine(directory, dTime.ToString("yyyy-MM"));
        }
    }
}