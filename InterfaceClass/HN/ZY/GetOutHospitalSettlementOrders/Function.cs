using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders
{
    /// <summary>
    /// 提取住院结算单(BIZC200101)
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
        /// 
        /// </summary>
        /// <param name="hospital_id"></param>
        /// <param name="serial_no"></param>
        /// <returns></returns>
        public OutParameter GetOutHospitalSettlementOrder(string hospital_id, string serial_no)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("serial_no", serial_no));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC200101", listParameter);

            if (0 > value)
            {
                throw new Exception("提取住院结算单(BIZC200101)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteOutParameters(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private OutParameter WriteOutParameters(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                OutParameter outParameter = new OutParameter();

                outParameter.Info = WriteInfo(inter);
                outParameter.ListFee = WriteFee(inter);
                outParameter.ListSeg = WriteSeg(inter);
                outParameter.Fund = WriteFund(inter);

                return outParameter;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private Fund WriteFund(Interface inter)
        {
            Fund fund = new Fund();
            string str = string.Empty;

            inter.SetResultset("fund");

            List<Parameter> listParameter = GetProperties<Fund>(fund);

            foreach (Parameter parameter in listParameter)
            {
                str = string.Empty;
                inter.GetByName(parameter.Name, ref str);

                fund.SetAttributeValue(parameter.Name, str);
            }

            return fund;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<Seg> WriteSeg(Interface inter)
        {
            List<Seg> listSeg = new List<Seg>();

            string str = string.Empty;

            inter.SetResultset("seg");

            do
            {
                Seg seg = new Seg();

                List<Parameter> listParameter = GetProperties<Seg>(seg);

                foreach (Parameter parameter in listParameter)
                {
                    str = string.Empty;
                    inter.GetByName(parameter.Name, ref str);

                    seg.SetAttributeValue(parameter.Name, str);
                }

                listSeg.Add(seg);

            } while (0 < inter.NextRow());

            return listSeg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<Fee> WriteFee(Interface inter)
        {
            List<Fee> listFee = new List<Fee>();

            string str = string.Empty;

            inter.SetResultset("fee");

            do
            {
                Fee fee = new Fee();

                List<Parameter> listParameter = GetProperties<Fee>(fee);

                foreach (Parameter parameter in listParameter)
                {
                    str = string.Empty;
                    inter.GetByName(parameter.Name, ref str);

                    fee.SetAttributeValue(parameter.Name, str);
                }

                listFee.Add(fee);

            } while (0 < inter.NextRow());

            return listFee;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private Info WriteInfo(Interface inter)
        {
            Info info = new Info();
            string str = string.Empty;

            inter.SetResultset("info");

            List<Parameter> listParameter = GetProperties<Info>(info);

            foreach (Parameter parameter in listParameter)
            {
                str = string.Empty;
                inter.GetByName(parameter.Name, ref str);

                info.SetAttributeValue(parameter.Name, str);
            }

            return info;
        }
    }
}