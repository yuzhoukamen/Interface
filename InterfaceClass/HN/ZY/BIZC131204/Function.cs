using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.BIZC131204
{
    /// <summary>
    /// 校验保存普通住院入院信息，中心自动处理转院病人。
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
        /// 校验保存普通住院入院信息，中心自动处理转院病人。
        /// </summary>
        /// <param name="inParameter"></param>
        /// <param name="diagnoseInfo"></param>
        /// <returns></returns>
        public BizInfo CheckAndSaveInHospitalInfo(InParameter inParameter, List<DiagnoseInfo> listDiagnoseInfo)
        {
            List<Parameter> listParameter = GetProperties<InParameter>(inParameter);
            List<Parameter> listResultsetAndParameters = new List<Parameter>();
            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            foreach (DiagnoseInfo dia in listDiagnoseInfo)
            {
                listListParameter.Add(GetProperties<DiagnoseInfo>(dia));
            }

            Interface inter = new Interface(this.InterfaceHN);

            listResultsetAndParameters.Add(new Parameter("diagnoseinfo", listListParameter));

            long value = inter.ExecInterface("BIZC131204", listParameter, listResultsetAndParameters);

            if (0 > value)
            {
                throw new Exception("校验保存普通住院入院信息(BIZC131204)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteBizInfo(inter);
        }

        /// <summary>
        /// 本次住院的就医登记号
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private BizInfo WriteBizInfo(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                inter.SetResultset("bizinfo");
                string str = string.Empty;

                BizInfo bizInfo = new BizInfo();

                List<Parameter> listParameter = GetProperties<BizInfo>(bizInfo);

                foreach (Parameter p in listParameter)
                {
                    str = string.Empty;
                    inter.GetByName(p.Name, ref str);
                    bizInfo.SetAttributeValue(p.Name, str);
                }

                return bizInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo);
            }
        }
    }
}