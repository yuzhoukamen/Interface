using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.BusCostInfo.MZOrders
{
    /// <summary>
    /// 本次业务各基金(含个人帐户和现金)支付信息
    /// </summary>
    public class Fund
    {
        #region 属性

        [Description("总费用")]
        public string total_pay { get; set; }

        [Description("统筹支付")]
        public string fund_pay { get; set; }

        [Description("个人现金支付")]
        public string self_pay { get; set; }

        [Description("个人帐户支付")]
        public string acct_pay { get; set; }

        [Description("医院支付")]
        public string hosp_pay { get; set; }

        [Description("公务员补助")]
        public string offi_pay { get; set; }

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
                case "total_pay"://总费用
                    this.total_pay = value;
                    break;
                case "fund_pay"://统筹支付
                    this.fund_pay = value;
                    break;
                case "self_pay"://个人现金支付
                    this.self_pay = value;
                    break;
                case "acct_pay"://个人帐户支付
                    this.acct_pay = value;
                    break;
                case "hosp_pay"://医院支付
                    this.hosp_pay = value;
                    break;
                case "offi_pay"://公务员补助
                    this.offi_pay = value;
                    break;
                default:
                    break;
            }
        }
    }
}