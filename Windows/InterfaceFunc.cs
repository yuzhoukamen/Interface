using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Windows
{
    /// <summary>
    /// 接口功能
    /// </summary>
    public class InterfaceFunc
    {
        /// <summary>
        /// 获取接口功能实例
        /// </summary>
        /// <returns></returns>
        public static InterfaceFunc GetInstance()
        {
            return new InterfaceFunc();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public InterfaceFunc() { }

        /// <summary>
        /// 获取接口功能数据集
        /// </summary>
        /// <param name="id">功能编码</param>
        /// <param name="name">功能名称</param>
        /// <returns></returns>
        public DataSet GetInterfaceFunc(string id, string name, bool fuzzy)
        {
            DataSet ds = new DataSet();

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(@"SELECT  ID AS 编码,Name AS 名称
                                    FROM    HIS_InterfaceHN.dbo.Func
                                    WHERE   ID LIKE '{2}{0}%'
                                            AND Name LIKE '{2}{1}%'
                                    ORDER BY ID", id, name, fuzzy ? "%" : string.Empty);

                ds = Alif.DBUtility.DbHelperSQL.Query(sb.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("获取接口功能数据集失败，失败原因：", e.Message));
            }

            return ds;
        }
    }
}