using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.InHospitalFeeCalc
{
    /// <summary>
    /// 住院费用计算(BIZC131255)
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
        /// 住院费用计算
        /// </summary>
        /// <param name="inParameter"></param>
        /// <returns></returns>
        public List<PayInfo> InHospitalFeeDetailsCalc(InParameter inParameter)
        {
            List<Parameter> listParameter = GetProperties<InParameter>(inParameter);

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131255", listParameter);

            if (0 > value)
            {
                throw new Exception("住院费用计算(BIZC131255)发生错误，错误原因：" + inter.GetMessage());
            }

            return WritePayInfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<PayInfo> WritePayInfo(Interface inter)
        {
            List<PayInfo> listPayInfo = new List<PayInfo>();

            string errorInfo = inter.GetMessage();
            string str = string.Empty;

            inter.SetResultset("payinfo");

            try
            {
                do
                {
                    PayInfo payInfo = new PayInfo();

                    List<Parameter> listParameter = GetProperties<PayInfo>(payInfo);

                    foreach (Parameter parameter in listParameter)
                    {
                        str = string.Empty;

                        inter.GetByName(parameter.Name, ref str);
                        payInfo.SetAttributeValue(parameter.Name, str);
                    }

                    listPayInfo.Add(payInfo);
                } while (0 < inter.NextRow());

                return listPayInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }
    }
}