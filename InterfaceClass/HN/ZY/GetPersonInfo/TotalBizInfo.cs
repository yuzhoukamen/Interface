using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetPersonInfo
{
    /// <summary>
    /// 个人业务累计信息
    /// </summary>
    public class Totalbizinfo
    {
        #region 属性

        [Description("本年业务总次数")]
        public string biz_year { get; set; }

        [Description("本年购药次数")]
        public string drug_year { get; set; }

        [Description("本年门诊次数")]
        public string diag_year { get; set; }

        [Description("本年住院次数")]
        public string inhosp_year { get; set; }

        [Description("本年门诊特殊病次数")]
        public string special_year { get; set; }

        [Description("本年总费用")]
        public string fee_year { get; set; }

        [Description("本年统筹基金累计支出")]
        public string fund_year { get; set; }

        [Description("本年个人帐户累计支出")]
        public string acct_year { get; set; }

        [Description("本年大病互助金累计支出")]
        public string additional_year { get; set; }

        [Description("本年离休基金累计支出")]
        public string retire_year { get; set; }

        [Description("本年公务员补助累计支出")]
        public string official_year { get; set; }

        [Description("本年住院起付线支出")]
        public string qfx_year { get; set; }

        [Description("本年申报费用累计")]
        public string declare_year { get; set; }

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
                case "biz_year"://本年业务总次数
                    this.biz_year = value;
                    break;
                case "drug_year"://本年购药次数
                    this.drug_year = value;
                    break;
                case "diag_year"://本年门诊次数
                    this.diag_year = value;
                    break;
                case "inhosp_year"://本年住院次数
                    this.inhosp_year = value;
                    break;
                case "special_year"://本年门诊特殊病次数
                    this.special_year = value;
                    break;
                case "fee_year"://本年总费用
                    this.fee_year = value;
                    break;
                case "fund_year"://本年统筹基金累计支出
                    this.fund_year = value;
                    break;
                case "acct_year"://本年个人帐户累计支出
                    this.acct_year = value;
                    break;
                case "additional_year"://本年大病互助金累计支出
                    this.additional_year = value;
                    break;
                case "retire_year"://本年离休基金累计支出
                    this.retire_year = value;
                    break;
                case "official_year"://本年公务员补助累计支出
                    this.official_year = value;
                    break;
                case "qfx_year"://本年住院起付线支出
                    this.qfx_year = value;
                    break;
                case "declare_year"://本年申报费用累计
                    this.declare_year = value;
                    break;
                default:
                    break;
            }
        }
    }
}