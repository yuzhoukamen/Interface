using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.SaveDiagnoseInfo
{
    /// <summary>
    /// 校验保存住院诊断信息(BIZC200024)
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
        /// 校验保存住院诊断信息(BIZC200024)
        /// </summary>
        /// <param name="inParameter">参数部分</param>
        /// <param name="listDiagnoseInfo">诊断的信息</param>
        public void CheckAndSaveDiagnoseInfo(InParameter inParameter, List<DiagnoseInfo> listDiagnoseInfo)
        {
            List<Parameter> listMainParameter = GetProperties<InParameter>(inParameter);

            Interface inter = new Interface(this.InterfaceHN);

            List<Parameter> listDatasetAndParameters = new List<Parameter>();
            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            foreach (DiagnoseInfo diagnoseInfo in listDiagnoseInfo)
            {
                List<Parameter> list = GetProperties<DiagnoseInfo>(diagnoseInfo);

                listListParameter.Add(list);
            }

            listDatasetAndParameters.Add(new Parameter("diagnoseinfo", listListParameter));

            long value = inter.ExecInterface("BIZC200024", listMainParameter, listDatasetAndParameters);

            if (0 > value)
            {
                throw new Exception("校验保存住院诊断信息(BIZC200024)发生错误，错误原因：" + inter.GetMessage());
            }
        }
    }
}