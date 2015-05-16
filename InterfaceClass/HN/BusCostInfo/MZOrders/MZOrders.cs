using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.BusCostInfo.MZOrders
{
    /// <summary>
    /// 提取门诊结算单
    /// </summary>
    public class MZOrders : BaseHN
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public MZOrders(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospital_id"></param>
        /// <param name="serial_no"></param>
        /// <param name="ver_query_xn"></param>
        /// <returns></returns>
        public GetMZOrdersOutParameters GetMZOrders(string hospital_id, string serial_no, string ver_query_xn)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("serial_no", serial_no));
            listParameter.Add(new Parameter("ver_query_xn", ver_query_xn));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC200102", listParameter);

            if (0 > value)
            {
                throw new Exception("提取门诊结算单信息失败，失败原因：" + inter.GetMessage());
            }

            return WriteMZOrdersOutParameters(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private GetMZOrdersOutParameters WriteMZOrdersOutParameters(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                inter.SetResultset("info");

                GetMZOrdersOutParameters outParameters = new GetMZOrdersOutParameters();
                List<Info> listInfo = new List<Info>();
                Fund fund = new Fund();

                string str = string.Empty;

                do
                {
                    Info info = new Info();

                    List<Parameter> listParameter = GetProperties<Info>(info);

                    foreach (Parameter p in listParameter)
                    {
                        str = string.Empty;

                        inter.GetByName(p.Name, ref str);

                        info.SetAttributeValue(p.Name, str);
                    }

                    listInfo.Add(info);

                } while (0 < inter.NextRow());

                List<Parameter> list = GetProperties<Fund>(fund);

                inter.SetResultset("fund");

                foreach (Parameter p in list)
                {
                    str = string.Empty;

                    inter.GetByName(p.Name, ref str);

                    fund.SetAttributeValue(p.Name, str);
                }

                outParameters.ListInfo = listInfo;
                outParameters.fund = fund;

                return outParameters;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }
    }
}