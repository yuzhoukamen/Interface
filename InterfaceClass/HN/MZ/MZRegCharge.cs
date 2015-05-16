using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 普通门诊业务正常收费
    /// </summary>
    public class MZRegCharge
    {
        [Description("中心编码")]
        public string center_id { get; set; }

        [Description("医疗机构编码")]
        public string hospital_id { get; set; }

        [Description("个人编号")]
        public string indi_id { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("待遇类型")]
        public string treatment_type { get; set; }

        [Description("登记人员工号")]
        public string reg_staff { get; set; }

        [Description("登记人姓名")]
        public string reg_man { get; set; }

        [Description("就诊时间")]
        public string diagnose_date { get; set; }

        [Description("登记诊断")]
        public string diagnose { get; set; }

        [Description("登记诊断名称")]
        public string in_disease_name { get; set; }

        [Description("计算保存标志")]
        public string save_flag { get; set; }

        [Description("个人帐户支付金额")]
        public string last_balance { get; set; }

        [Description("生育（工伤）个人业务序号")]
        public string injury_borth_sn { get; set; }

        [Description("处方号")]
        public string recipe_no { get; set; }

        [Description("处方医生编号")]
        public string doctor_no { get; set; }

        [Description("处方医生姓名")]
        public string doctor_name { get; set; }

        [Description("备注")]
        public string note { get; set; }

        [Description("门诊特殊病业务申请号")]
        public string serial_apply { get; set; }

        [Description("单据号")]
        public string bill_no { get; set; }

        [Description("实际刷身份证号码")]
        public string fact_idcard { get; set; }

        [Description("正向退费标志")]
        public string query_flag { get; set; }
    }
}