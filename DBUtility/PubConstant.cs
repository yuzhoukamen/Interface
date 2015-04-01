using System;
using System.Configuration;
using System.Xml;
namespace Alif.DBUtility
{
    /// <summary>
    /// 公共常量
    /// </summary>
    public class PubConstant
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }

        /// <summary>
        /// 是否记录日志
        /// </summary>
        public static string DBLog
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["DBLog"];
                }
                catch
                {
                    return "off";
                }
            }
        }

        /// <summary>
        /// 是否显示采购计划设置
        /// </summary>
        public static string ProPlan
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["ProPlan"];
                }
                catch
                {
                    return "off";
                }
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public static string projectName
        {
            get
            {
                return ConfigurationManager.AppSettings["projectName"];
            }
        }

        /// <summary>
        /// 欢迎标题
        /// </summary>
        public static string titleContent
        {
            get
            {
                return ConfigurationManager.AppSettings["titleContent"];
            }
        }

        /// <summary>
        /// odbc连接串
        /// </summary>
        public static string ODBCConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ODBCConnectionString"];
            }
        }

        /// <summary>
        /// 登录错误信息
        /// </summary>
        public static string LoginInfoError
        {
            get
            {
                return ConfigurationManager.AppSettings["loginInfoError"];
            }
        }

        /// <summary>
        /// 参数错误信息
        /// </summary>
        public static string ParaErrorInfo
        {
            get
            {
                return ConfigurationManager.AppSettings["paraErrorInfo"];
            }
        }

        /// <summary>
        /// 医疗收费项目统计报表名称
        /// </summary>
        public static string OperationReporterName
        {
            get
            {
                return ConfigurationManager.AppSettings["OperationReporterName"];
            }
        }

        /// <summary>
        /// 获取读写卡的sid信息
        /// </summary>
        public static string Clsid
        {
            get
            {
                return ConfigurationManager.AppSettings["clsid"];
            }
        }

        /// <summary>
        /// 获取web打印的sid值
        /// </summary>
        public static string WebPrintClsid
        {
            get
            {
                return ConfigurationManager.AppSettings["webPrintClsid"];
            }
        }

        /// <summary>
        /// 数据库sql语句出错的提示信息
        /// </summary>
        public static string DBSQLError
        {
            get
            {
                return ConfigurationManager.AppSettings["DBSQLError"];
            }
        }

        public static string HLT_OptionTips
        {
            get
            {
                return ConfigurationManager.AppSettings["HLT_OptionTips"];
            }
        }

        /// <summary>
        /// 页面主题深度
        /// </summary>
        public static string PageThemesDep
        {
            get
            {
                return ConfigurationManager.AppSettings["PageThemesDep"];
            }
        }

        /// <summary>
        /// 是否记录登陆日志
        /// </summary>
        public static string LoginLog
        {
            get
            {
                return ConfigurationManager.AppSettings["LoginLog"];
            }
        }

        /// <summary>
        /// 获取参数配置常量
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string GetPubConstant(PubConstantType pubConstantType, string path)
        {
            try
            {

                return ConfigurationManager.AppSettings[pubConstantType + "_" + path.Replace("/", "_")];
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// 应用程序日志路径
        /// </summary>
        public static string LogDir
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["LogDir"];
                }
                catch
                {
                    return @"C:\AlifDicomService.log";
                }
            }
        }

        /// <summary>
        /// 获取关键字的值
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns>关键词对应的值</returns>
        public static string GetKeyValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception e)
            {
                throw new Exception("获取关键字【" + key + "】的值失败，失败原因：" + e.Message);
            }
        }

        /// <summary>
        /// 更新配置文件信息
        /// </summary>
        /// <param name="name">配置文件字段名称</param>
        /// <param name="Xvalue">值</param>
        public static void UpdateConfig(string appPath, string name, string Xvalue)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(appPath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='" + name + "']");
            XmlElement ele = (XmlElement)node;
            ele.SetAttribute("value", Xvalue);
            doc.Save(appPath + ".config");
        }

        /// <summary>
        /// 系统管理员编号
        /// </summary>
        public static string SystemAdminID {
            get {
                {
                    try
                    {
                        return ConfigurationManager.AppSettings["SystemAdminID"];
                    }
                    catch
                    {
                        return @"71";
                    }
                }
            }
        }
    }
    public enum PubConstantType
    {
        javascript,
        css
    }
}