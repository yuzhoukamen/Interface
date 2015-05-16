using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.BIZC131204
{
    /// <summary>
    /// 住院登记多诊断的信息
    /// </summary>
    public class DiagnoseInfo
    {
        #region 属性

        [Description("诊断序号")]
        public string diagnose_sn { get; set; }

        [Description("诊断类型")]
        public string diagnose_code { get; set; }

        [Description("诊断编码")]
        public string icd { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "diagnose_sn"://诊断序号
                    this.diagnose_sn = value;
                    break;
                case "diagnose_code"://诊断类型
                    this.diagnose_code = value;
                    break;
                case "icd"://诊断编码
                    this.icd = value;
                    break;
                default:
                    break;
            }
        }
    }
}