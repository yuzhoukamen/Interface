using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 个人基本信息
    /// </summary>
    public class PersonInfo
    {
        [Description("个人电脑号")]
        public string indi_id { get; set; }

        [Description("分级统筹中心编码")]
        public string center_id { get; set; }

        [Description("分级统筹中心名称")]
        public string center_name { get; set; }

        [Description("姓名")]
        public string name { get; set; }

        [Description("性别")]
        public string sex { get; set; }

        [Description("人员类别编码")]
        public string pers_type { get; set; }

        [Description("人员类别名称")]
        public string pers_name { get; set; }

        [Description("人员状态编码")]
        public string indi_join_sta { get; set; }

        [Description("人员状态名称")]
        public string indi_sta_name { get; set; }

        [Description("公务员级别编码")]
        public string official_code { get; set; }

        [Description("公务员级别名称")]
        public string official_name { get; set; }

        [Description("用工形式编码")]
        public string hire_type { get; set; }

        [Description("用工形式名称")]
        public string hire_name { get; set; }

        [Description("公民身份号码")]
        public string idcard { get; set; }

        [Description("社会保障号码")]
        public string insr_code { get; set; }

        [Description("联系电话")]
        public string telephone { get; set; }

        [Description("出生日期")]
        public string birthday { get; set; }

        [Description("地区编码")]
        public string post_code { get; set; }

        [Description("单位编码")]
        public string corp_id { get; set; }

        [Description("单位名称")]
        public string corp_name { get; set; }

        [Description("基金冻结状态")]
        public string freeze_sta { get; set; }

        [Description("个人帐户余额")]
        public string last_balance { get; set; }
    }
}