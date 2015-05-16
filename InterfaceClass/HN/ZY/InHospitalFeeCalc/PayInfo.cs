using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.InHospitalFeeCalc
{
    public class PayInfo
    {
        #region 属性

        [Description("基金编码")]
        public string fund_id { get; set; }

        [Description("基金名称")]
        public string fund_name { get; set; }

        [Description("支付金额")]
        public string real_pay { get; set; }

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
                case "fund_id"://基金编码
                    this.fund_id = value;
                    break;
                case "fund_name"://基金名称
                    this.fund_name = value;
                    break;
                case "real_pay"://支付金额
                    this.real_pay = value;
                    break;
                default:
                    break;
            }
        }
    }
}