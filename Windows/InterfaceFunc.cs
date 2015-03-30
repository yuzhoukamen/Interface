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

                sb.AppendFormat(@"SELECT    ID,FuncID AS 编码,Name AS 名称
                                    FROM    HIS_InterfaceHN.dbo.Func
                                    WHERE   FuncID LIKE '{2}{0}%'
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

        /// <summary>
        /// 获取接口编码对应的详细信息
        /// </summary>
        /// <param name="id">接口功能编码</param>
        /// <returns></returns>
        public DataSet GetInterfaceFuncDetails(string id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"SELECT    ID,
                                        FuncID ,
                                        Name ,
                                        Details
                                FROM    HIS_InterfaceHN.dbo.Func
                                WHERE   ID = '{0}';

                                SELECT  ReturnValueDesc AS 返回值说明
                                FROM    HIS_InterfaceHN.dbo.FuncReturnValue
                                WHERE   HIS_InterfaceHN.dbo.FuncReturnValue.FuncID = '{0}';

                                SELECT  
                                        CASE WHEN HIS_InterfaceHN.dbo.FuncPara.NAME IS NULL THEN '默认参数'
                                             ELSE HIS_InterfaceHN.dbo.FuncPara.NAME
                                        END AS 参数说明 ,
                                        HIS_InterfaceHN.dbo.FuncParaList.ID ,
                                        HIS_InterfaceHN.dbo.FuncParaList.NAME AS 入参 ,
                                        HIS_InterfaceHN.dbo.FuncParaList.NameDesc AS 入参说明 ,
                                        HIS_InterfaceHN.dbo.FuncParaList.DefaultValue AS 默认值 ,
                                        HIS_InterfaceHN.dbo.FuncParaList.MaxLength AS 最大长度 ,
                                        HIS_InterfaceHN.dbo.FuncParaList.IsNull AS 是否为空 ,
                                        CASE WHEN HIS_InterfaceHN.dbo.FuncParaList.Details IS NULL THEN ''
                                             ELSE HIS_InterfaceHN.dbo.FuncParaList.Details
                                        END AS 备注
                                FROM    HIS_InterfaceHN.dbo.FuncPara
                                        INNER JOIN HIS_InterfaceHN.dbo.FuncParaList ON HIS_InterfaceHN.dbo.FuncPara.ID = His_InterfaceHN.dbo.FuncParaList.ParaID
                                WHERE   HIS_InterfaceHN.dbo.FuncPara.FuncID = '{0}';

                                SELECT  HIS_InterfaceHN.dbo.FuncDatasetList.ID ,
                                        HIS_InterfaceHN.dbo.FuncDataset.NAME AS 数据集 ,
                                        HIS_InterfaceHN.dbo.FuncDatasetList.NAME AS 字段 ,
                                        HIS_InterfaceHN.dbo.FuncDatasetList.NameDesc AS 字段说明 ,
                                        HIS_InterfaceHN.dbo.FuncDatasetList.MaxLength AS 最大长度 ,
                                        HIS_InterfaceHN.dbo.FuncDatasetList.Details AS 备注
                                FROM    HIS_InterfaceHN.dbo.FuncDataset
                                        INNER JOIN HIS_InterfaceHN.dbo.FuncDatasetList ON HIS_InterfaceHN.dbo.FuncDatasetList.DatasetID = HIS_InterfaceHN.dbo.FuncDataset.ID
                                WHERE   HIS_InterfaceHN.dbo.FuncDataset.FuncID = '{0}';

                                SELECT  *
                                FROM    HIS_InterfaceHN.dbo.FuncDataset
                                WHERE   FuncID = {0}", id);

            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(sb.ToString());

                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("获取接口编码【{0}】的详细信息失败，失败原因：{1}", id, e.Message));
            }
        }
    }
}