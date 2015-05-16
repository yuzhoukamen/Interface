using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.DeleteInHospitalFeeDetails
{
    /// <summary>
    /// 删除住院费用信息
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
        /// 删除全部已经上传的住院费用
        /// </summary>
        /// <param name="hospital_id"></param>
        /// <param name="serial_no"></param>
        /// <param name="fin_staff"></param>
        /// <param name="fin_man"></param>
        /// <returns></returns>
        public string DeleteUploadedInHospitalFeeDetails(string hospital_id, string serial_no, string fin_staff, string fin_man)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("serial_no", serial_no));
            listParameter.Add(new Parameter("fin_staff", fin_staff));
            listParameter.Add(new Parameter("fin_man", fin_man));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131274", listParameter);

            if (0 > value)
            {
                throw new Exception("删除全部已经上传的住院费用发生错误，错误原因：" + inter.GetMessage());
            }

            return inter.GetMessage();
        }
    }
}