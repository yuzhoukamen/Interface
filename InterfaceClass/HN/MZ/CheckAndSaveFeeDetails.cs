using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 校验计算并保存录入的费用明细信息
    /// </summary>
    public class CheckAndSaveFeeDetails : BaseHN
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN">湖南创智接口</param>
        public CheckAndSaveFeeDetails(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 写门诊收费输出参数
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private MZRegOutParameter WriteMZRegOutParameter(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                MZRegOutParameter mz_ChargeOutParameter = new MZRegOutParameter();

                inter.SetResultset("bizinfo");

                string str = string.Empty;

                mz_ChargeOutParameter.BizInfo = new BizInfo();

                str = string.Empty;
                inter.GetByName("serial_no", ref str);
                mz_ChargeOutParameter.BizInfo.serial_no = str;

                inter.SetResultset("payinfo");

                mz_ChargeOutParameter.ListPayInfo = new List<PayInfo>();

                do
                {
                    PayInfo payInfo = new PayInfo();

                    str = string.Empty;
                    inter.GetByName("fund_name", ref str);
                    payInfo.fund_name = str;

                    str = string.Empty;
                    inter.GetByName("real_pay", ref str);
                    payInfo.real_pay = str;

                    mz_ChargeOutParameter.ListPayInfo.Add(payInfo);
                } while (0 < inter.NextRow());

                return mz_ChargeOutParameter;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// 门诊收费
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public MZRegOutParameter CheckCalcAndSaveWrittenFeeDetails(MZ_ChargeParameter parameter)
        {
            List<Parameter> listParameterMain = new List<Parameter>();
            List<Parameter> listParameterMainParameter = GetProperties<MZRegCharge>(parameter.MZRegCharge);
            List<Parameter> listParameterFeeInfoParameter = new List<Parameter>();

            Interface inter = new Interface(this.InterfaceHN);

            foreach (Parameter p in listParameterMainParameter)
            {
                listParameterMain.Add(new Parameter(p.Name, p.Value));
            }

            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            foreach (FeeInfo feeInfo in parameter.ListFeeInfo)
            {
                List<Parameter> listParameter = GetProperties<FeeInfo>(feeInfo);

                listListParameter.Add(listParameter);
            }

            Parameter pFeeInfo = new Parameter();

            pFeeInfo.Name = "feeinfo";
            pFeeInfo.Object = listListParameter;

            listParameterFeeInfoParameter.Add(pFeeInfo);

            long value = inter.ExecInterface("BIZC131104", listParameterMainParameter, listParameterFeeInfoParameter);
            if (0 > value)
            {
                throw new Exception(string.Format("普通门诊收费校验计算并保存录入的费用明细信息（含改费）发生错误，错误原因：【{0}:{1}】", value, inter.GetMessage()));
            }

            return WriteMZRegOutParameter(inter);
        }

        /// <summary>
        /// 门诊改费
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public MZRegOutParameter CheckCalcAndSaveWrittenFeeDetails(MZ_ChangeParameter parameter)
        {
            List<Parameter> listParameterMain = new List<Parameter>();
            List<Parameter> listParameterMainParameter = GetProperties<MZRegChange>(parameter.MZRegChange);
            List<Parameter> listParameterFeeInfoParameter = new List<Parameter>();

            Interface inter = new Interface(this.InterfaceHN);

            foreach (Parameter p in listParameterMainParameter)
            {
                listParameterMain.Add(new Parameter(p.Name, p.Value));
            }

            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            foreach (FeeInfo feeInfo in parameter.ListFeeInfo)
            {
                List<Parameter> listParameter = GetProperties<FeeInfo>(feeInfo);

                listListParameter.Add(listParameter);
            }

            Parameter pFeeInfo = new Parameter();

            pFeeInfo.Name = "feeinfo";
            pFeeInfo.Object = listListParameter;

            listParameterFeeInfoParameter.Add(pFeeInfo);

            long value = inter.ExecInterface("BIZC131104", listParameterMainParameter, listParameterFeeInfoParameter);

            if (0 > value)
            {
                throw new Exception(string.Format("普通门诊改费校验计算并保存录入的费用明细信息（含改费）发生错误，错误原因：【{0}:{1}】", value, inter.GetMessage()));
            }

            return WriteMZRegOutParameter(inter);
        }
    }
}