using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders
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

        [Description("大病支付")]
        public string db_pay { get; set; }

        [Description("个人全自费")]
        public string self_pay { get; set; }

        [Description("个人部分自付")]
        public string Part_pay { get; set; }

        [Description("部分自付公务员补助")]
        public string part_pay_offi { get; set; }

        [Description("起伏线")]
        public string start_pay { get; set; }

        [Description("起伏线公务员补助")]
        public string start_pay_offi { get; set; }

        [Description("统筹段费用")]
        public string base_pay { get; set; }

        [Description("统筹段个人自付")]
        public string self_pay_seg { get; set; }

        [Description("统筹段公务员补助")]
        public string official_pay_seg { get; set; }

        [Description("大病段费用")]
        public string additional_pay { get; set; }

        [Description("大病段个人自付")]
        public string additional_pay_cash { get; set; }

        [Description("大病段公务员补助")]
        public string additional_pay_offi { get; set; }

        [Description("申报费用")]
        public string declare_pay { get; set; }

        [Description("超标个人自付")]
        public string self_pay_exceed { get; set; }

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
                case "total_pay"://总费用
                    this.total_pay = value;
                    break;
                case "fund_pay"://统筹支付
                    this.fund_pay = value;
                    break;
                case "db_pay"://大病支付
                    this.db_pay = value;
                    break;
                case "self_pay"://个人全自费
                    this.self_pay = value;
                    break;
                case "Part_pay"://个人部分自付
                    this.Part_pay = value;
                    break;
                case "part_pay_offi"://部分自付公务员补助
                    this.part_pay_offi = value;
                    break;
                case "start_pay"://起伏线
                    this.start_pay = value;
                    break;
                case "start_pay_offi"://起伏线公务员补助
                    this.start_pay_offi = value;
                    break;
                case "base_pay"://统筹段费用
                    this.base_pay = value;
                    break;
                case "self_pay_seg"://统筹段个人自付
                    this.self_pay_seg = value;
                    break;
                case "official_pay_seg"://统筹段公务员补助
                    this.official_pay_seg = value;
                    break;
                case "additional_pay"://大病段费用
                    this.additional_pay = value;
                    break;
                case "additional_pay_cash"://大病段个人自付
                    this.additional_pay_cash = value;
                    break;
                case "additional_pay_offi"://大病段公务员补助
                    this.additional_pay_offi = value;
                    break;
                case "declare_pay"://申报费用
                    this.declare_pay = value;
                    break;
                case "self_pay_exceed"://超标个人自付
                    this.self_pay_exceed = value;
                    break;
                default:
                    break;
            }
        }
    }
}