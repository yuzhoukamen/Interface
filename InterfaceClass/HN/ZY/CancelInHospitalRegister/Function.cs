using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.CancelInHopitalRegister
{
    /// <summary>
    /// 取消住院登记
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
        /// <param name="fin_staff"></param>
        /// <param name="fin_man"></param>
        /// <param name="trade_no"></param>
        public string CancelInHospitalRegister(string hospital_id, string serial_no, string fin_staff, string fin_man, string trade_no)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("serial_no", serial_no));
            listParameter.Add(new Parameter("fin_staff", fin_staff));
            listParameter.Add(new Parameter("fin_man", fin_man));
            listParameter.Add(new Parameter("trade_no", trade_no));

            Interface inter = new Interface(this.InterfaceHN);

            long value=inter.ExecInterface("BIZC131206", listParameter);

            if (0 > value)
            {
                throw new Exception("取消住院登记(BIZC131206)发生错误，错误原因：" + inter.GetMessage());
            }

            return inter.GetMessage();
        }
    }
}