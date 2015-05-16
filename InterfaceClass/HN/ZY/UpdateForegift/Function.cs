using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.UpdateForegift
{
    /// <summary>
    /// 保存预付款信息(BIZC131203)
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
        /// 保存预付款信息(BIZC131203)
        /// </summary>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="serial_no">就医登记号</param>
        /// <param name="foregift_remain">预付款余额</param>
        public void SaveForegift(string hospital_id, string serial_no, string foregift_remain)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("serial_no", serial_no));
            listParameter.Add(new Parameter("foregift_remain", foregift_remain));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131203", listParameter);

            if (0 > value)
            {
                throw new Exception("保存预付款信息(BIZC131203)发生错误，错误原因：" + inter.GetMessage());
            }
        }
    }
}