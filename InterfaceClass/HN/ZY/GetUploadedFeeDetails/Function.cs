using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.GetUploadedFeeDetails
{
    /// <summary>
    /// 提取已保存的费用明细信息(BIZC131253)
    /// </summary>
    public class Function : BaseHN
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public Function(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 提取已保存费用明细信息
        /// </summary>
        /// <param name="hospital_id"></param>
        /// <param name="serial_no"></param>
        /// <returns></returns>
        public List<FeeInfo> GetUploadedFeeInfo(string hospital_id, string serial_no)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("serial_no", serial_no));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131253", listParameter);

            if (0 > value)
            {
                throw new Exception("提取已保存的费用明细信息(BIZC131253)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteFeeInfo(inter);
        }

        /// <summary>
        /// 写费用明细
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<FeeInfo> WriteFeeInfo(Interface inter)
        {
            List<FeeInfo> listFeeInfo = new List<FeeInfo>();
            string errorInfo = inter.GetMessage();
            string str = string.Empty;

            try
            {
                List<Parameter> listParameter = GetProperties<FeeInfo>(new FeeInfo());

                do
                {
                    FeeInfo feeInfo = new FeeInfo();

                    foreach (Parameter parameter in listParameter)
                    {
                        str = string.Empty;
                        inter.GetByName(parameter.Name, ref str);
                        feeInfo.SetAttributeValue(parameter.Name, str);
                    }

                    listFeeInfo.Add(feeInfo);
                }
                while (0 < inter.NextRow());
            }
            catch (Exception ex)
            {
                //throw new Exception(errorInfo + "\n" + ex.Message);
            }

            return listFeeInfo;
        }
    }
}