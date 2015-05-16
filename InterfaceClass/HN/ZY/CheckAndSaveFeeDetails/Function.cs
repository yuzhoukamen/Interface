using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.CheckAndSaveFeeDetails
{
    /// <summary>
    /// 
    /// </summary>
    public class Function : BaseHN
    {
        /// <summary>
        /// 校验保存录入的费用明细信息(BIZC131252)
        /// </summary>
        /// <param name="interfaceHN"></param>
        public Function(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 校验保存录入的费用明细信息(BIZC131252)
        /// </summary>
        /// <param name="inParameter"></param>
        /// <param name="listFeeInfo"></param>
        public string CheckAndSaveFeeDetails(InParameter inParameter, List<FeeInfo> listFeeInfo)
        {
            List<Parameter> listMainParameter = GetProperties<InParameter>(inParameter);

            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            foreach (FeeInfo feeInfo in listFeeInfo)
            {
                List<Parameter> listParameter = GetProperties<FeeInfo>(feeInfo);

                listListParameter.Add(listParameter);
            }

            List<Parameter> listParameters = new List<Parameter>();

            listParameters.Add(new Parameter("feeinfo", listListParameter));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131252", listMainParameter, listParameters);

            if (0 > value)
            {
                throw new Exception("校验保存录入的费用明细信息(BIZC131252)发生错误，错误原因：" + inter.GetMessage());
            }

            return inter.GetMessage();
        }

        /// <summary>
        /// 校验保存录入的费用明细信息(BIZC131272)
        /// </summary>
        /// <param name="inParameter"></param>
        /// <param name="listFeeInfo"></param>
        public string CheckAndSaveUploadedFeeDetails(InParameter inParameter, List<FeeInfo> listFeeInfo)
        {
            List<Parameter> listMainParameter = GetProperties<InParameter>(inParameter);

            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            foreach (FeeInfo feeInfo in listFeeInfo)
            {
                List<Parameter> listParameter = GetProperties<FeeInfo>(feeInfo);

                listListParameter.Add(listParameter);
            }

            List<Parameter> listParameters = new List<Parameter>();

            listParameters.Add(new Parameter("feeinfo", listListParameter));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131272", listMainParameter, listParameters);

            if (0 > value)
            {
                throw new Exception("校验保存住院费用明细信息(BIZC131272)发生错误，错误原因：" + inter.GetMessage());
            }

            return inter.GetMessage();
        }
    }
}