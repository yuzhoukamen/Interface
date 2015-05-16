using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders
{
    /// <summary>
    /// 本次业务的政策自付和分段支付信息
    /// </summary>
    public class Seg
    {
        #region 属性

        [Description("支付名称")]
        public string policy_type { get; set; }

        [Description("总费用")]
        public string total_pay { get; set; }

        [Description("现金")]
        public string cash_pay { get; set; }

        [Description("个人帐户支付")]
        public string acct_pay { get; set; }

        [Description("统筹支付")]
        public string base_pay { get; set; }

        [Description("大病救助（大额）")]
        public string additional_pay { get; set; }

        [Description("公务员补助")]
        public string official_pay { get; set; }

        [Description("医院支付")]
        public string hosp_pay { get; set; }

        [Description("企业补助")]
        public string corp_pay { get; set; }

        [Description("大病补助基金")]
        public string zhaogu_pay { get; set; }

        [Description("公务员特殊补助")]
        public string offi_tsbt { get; set; }

        [Description("二次补助基金")]
        public string fund402_pay { get; set; }

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
                case "policy_type"://支付名称
                    this.policy_type = value;
                    break;
                case "total_pay"://总费用
                    this.total_pay = value;
                    break;
                case "cash_pay"://现金
                    this.cash_pay = value;
                    break;
                case "acct_pay"://个人帐户支付
                    this.acct_pay = value;
                    break;
                case "base_pay"://统筹支付
                    this.base_pay = value;
                    break;
                case "additional_pay"://大病救助（大额）
                    this.additional_pay = value;
                    break;
                case "official_pay"://公务员补助
                    this.official_pay = value;
                    break;
                case "hosp_pay"://医院支付
                    this.hosp_pay = value;
                    break;
                case "corp_pay"://企业补助
                    this.corp_pay = value;
                    break;
                case "zhaogu_pay"://大病补助基金
                    this.zhaogu_pay = value;
                    break;
                case "offi_tsbt"://公务员特殊补助
                    this.offi_tsbt = value;
                    break;
                case "fund402_pay"://二次补助基金
                    this.fund402_pay = value;
                    break;
                default:
                    break;
            }
        }
    }
}