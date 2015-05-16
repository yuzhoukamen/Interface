using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.BusCostInfo.MZBigClassFeeInfo
{
    /// <summary>
    /// 提取大类费用信息
    /// </summary>
    public class GetBigClassFeeInfo : BaseHN
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public GetBigClassFeeInfo(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospital_id"></param>
        /// <param name="serial_no"></param>
        /// <param name="exec_flag"></param>
        /// <param name="center_flag"></param>
        /// <returns></returns>
        public List<Info> GetBigCassFeeInfoDesc(string hospital_id, string serial_no, string exec_flag, string center_flag)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("serial_no", serial_no));
            listParameter.Add(new Parameter("exec_flag", exec_flag));
            listParameter.Add(new Parameter("center_flag", center_flag));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC200301", listParameter);

            if (0 > value)
            {
                throw new Exception("提取大类费用信息(BIZC200301)失败，失败原因：" + inter.GetMessage());
            }

            return WriteInfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<Info> WriteInfo(Interface inter)
        {
            List<Info> listInfo = new List<Info>();
            string errorInfo = inter.GetMessage();

            try
            {
                inter.SetResultset("info");

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

                return listInfo;
            }
            catch (Exception ex)
            {
                //throw new Exception(errorInfo + "\n" + ex.Message);
            }

            return listInfo;
        }
    }
}