using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace InterfaceClass.Func
{
    public class Func
    {
        public static DataSet Functions(string id)
        {
            string SQLString = string.Format(@"SELECT  ID ,
                                                    FuncID ,
                                                    Name
                                            FROM    HIS_InterfaceHN.dbo.Func
                                            WHERE
                                                    FuncID like '%{0}%'", id);

            try
            {
                return Alif.DBUtility.DbHelperSQL.Query(SQLString);
            }
            catch (Exception e)
            {
                throw new Exception("获取接口函数列表发生错误，错误原因：" + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static DataSet QueryFuncDetails(string id)
        {
            DataSet ds = new DataSet();

            return ds;
        }
    }
}
