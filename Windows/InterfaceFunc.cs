using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Windows
{
    /// <summary>
    /// 接口功能
    /// </summary>
    public class InterfaceFunc
    {
        /// <summary>
        /// 获取接口功能实例
        /// </summary>
        /// <returns></returns>
        public static InterfaceFunc GetInstance()
        {
            return new InterfaceFunc();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public InterfaceFunc() { }

        public DataSet GetInterfaceFunc() {
            DataSet ds = new DataSet();

            return ds;
        }
    }
}
