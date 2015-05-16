using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 个人业务累计信息
    /// </summary>
    public class TotalbizInfo
    {
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
    }
}