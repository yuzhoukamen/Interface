using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.OutHospitalSettlement
{
    /// <summary>
    /// 本次住院的就医登记号
    /// </summary>
    public class BizInfo
    {
        #region 属性

        [Description("就医登记号")]
        public string serial_no { get; set; }

        [Description("单据号")]
        public string bill_no { get; set; }

        #endregion

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "serial_no"://就医登记号
                    this.serial_no = value;
                    break;
                case "bill_no"://单据号
                    this.bill_no = value;
                    break;
                default:
                    break;
            }
        }
    }
}