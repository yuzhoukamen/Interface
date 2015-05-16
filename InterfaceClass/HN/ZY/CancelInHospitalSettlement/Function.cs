using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.CancelInHospitalSettlement
{
    /// <summary>
    /// 取消出院结算
    /// </summary>
    public class Function : BaseHN
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="interfaceHN"></param>
        public Function(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 取消出院结算
        /// </summary>
        /// <param name="save_flag"></param>
        /// <param name="hospital_id"></param>
        /// <param name="serial_no"></param>
        /// <param name="treatment_type"></param>
        /// <param name="bill_no"></param>
        /// <returns></returns>
        public string CancelInHospitalSettlement(string save_flag, string hospital_id, string serial_no, string treatment_type, string indi_id)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("save_flag", save_flag));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("serial_no", serial_no));
            listParameter.Add(new Parameter("treatment_type", treatment_type));
            listParameter.Add(new Parameter("indi_id", indi_id));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131259", listParameter);

            if (0 > value)
            {
                throw new Exception("取消出院结算(BIZC131259)发生错误，错误原因：" + inter.GetMessage());
            }

            return inter.GetMessage();
        }
    }
}