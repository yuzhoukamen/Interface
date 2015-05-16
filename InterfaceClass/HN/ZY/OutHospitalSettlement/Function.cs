using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.OutHospitalSettlement
{
    /// <summary>
    /// 
    /// </summary>
    public class Function : BaseHN
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceHN"></param>
        public Function(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public OutParameter PatientOutHospitalSettlement(InParameter para)
        {
            List<Parameter> listParameter = GetProperties<InParameter>(para);

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131256", listParameter);

            if (0 > value)
            {
                throw new Exception("住院出院结算(BIZC131256)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteOutParameter(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        private OutParameter WriteOutParameter(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {

                OutParameter outParameter = new OutParameter();

                List<PayInfo> listPayInfo = new List<PayInfo>();

                string str = string.Empty;

                inter.SetResultset("payinfo");

                do
                {
                    PayInfo payInfo = new PayInfo();



                    List<Parameter> listParameter = GetProperties<PayInfo>(payInfo);

                    foreach (Parameter p in listParameter)
                    {
                        str = string.Empty;
                        inter.GetByName(p.Name, ref str);

                        payInfo.SetAttributeValue(p.Name, str);
                    }

                    listPayInfo.Add(payInfo);
                } while (0 < inter.NextRow());

                inter.SetResultset("bizinfo");

                BizInfo bizInfo = new BizInfo();

                List<Parameter> listBizInfo = GetProperties<BizInfo>(bizInfo);

                foreach (Parameter p in listBizInfo)
                {
                    str = string.Empty;
                    inter.GetByName(p.Name, ref str);

                    bizInfo.SetAttributeValue(p.Name, str);
                }

                outParameter._listPayInfo = listPayInfo;
                outParameter.BizInfo = bizInfo;

                return outParameter;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo);
            }
        }
    }
}