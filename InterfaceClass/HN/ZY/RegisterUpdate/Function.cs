using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.RegisterUpdate
{
    /// <summary>
    /// 校验保存住院信息修改(BIZC131205)
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
        /// 校验和保存住院信息修改
        /// </summary>
        /// <param name="inParameter">入参</param>
        public void CheckAndSaveInHospitalInfoUpdate(InParameter inParameter)
        {
            List<Parameter> listParameter = GetProperties<InParameter>(inParameter);

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131205", listParameter);

            if (0 > value)
            {
                throw new Exception("校验保存住院信息修改(BIZC131205)发生错误，错误原因：" + inter.GetMessage());
            }
        }
    }
}