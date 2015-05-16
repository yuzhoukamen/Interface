using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders
{
    /// <summary>
    /// 记录病人的基本信息
    /// </summary>
    public class Info
    {
        #region 属性

        [Description("个人电脑号")]
        public string indi_id { get; set; }

        [Description("姓名")]
        public string name { get; set; }

        [Description("性别")]
        public string sex { get; set; }

        [Description("出生日期")]
        public string birthday { get; set; }

        [Description("IC卡号")]
        public string ic_no { get; set; }

        [Description("身份证号码")]
        public string idcard { get; set; }

        [Description("人员类别名称")]
        public string pers_name { get; set; }

        [Description("公务员级别")]
        public string office_grade { get; set; }

        [Description("公务员级别名称")]
        public string Official_name { get; set; }

        [Description("住院号")]
        public string patient_id { get; set; }

        [Description("医疗机构名称")]
        public string hospital_name { get; set; }

        [Description("医疗机构级别")]
        public string hosp_level_name { get; set; }

        [Description("医疗机构等级")]
        public string hosp_grade_name { get; set; }

        [Description("单位名称")]
        public string corp_name { get; set; }

        [Description("入院诊断")]
        public string in_disease { get; set; }

        [Description("出院诊断")]
        public string fin_disease { get; set; }

        [Description("入院日期")]
        public string begin_date { get; set; }

        [Description("出院日期")]
        public string end_date { get; set; }

        [Description("住院天数")]
        public string days { get; set; }

        [Description("科室名称")]
        public string in_dept_name { get; set; }

        [Description("待遇类型")]
        public string treatment_type { get; set; }

        [Description("待遇类型名称")]
        public string treatment_name { get; set; }

        [Description("生育凭证号")]
        public string injury_borth_sn { get; set; }

        [Description("个人账户余额")]
        public string last_balance { get; set; }

        [Description("结算时间")]
        public string fin_date { get; set; }

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
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "name"://姓名
                    this.name = value;
                    break;
                case "sex"://性别
                    this.sex = value;
                    break;
                case "birthday"://出生日期
                    this.birthday = value;
                    break;
                case "ic_no"://IC卡号
                    this.ic_no = value;
                    break;
                case "idcard"://身份证号码
                    this.idcard = value;
                    break;
                case "pers_name"://人员类别名称
                    this.pers_name = value;
                    break;
                case "office_grade"://公务员级别
                    this.office_grade = value;
                    break;
                case "Official_name"://公务员级别名称
                    this.Official_name = value;
                    break;
                case "patient_id"://住院号
                    this.patient_id = value;
                    break;
                case "hospital_name"://医疗机构名称
                    this.hospital_name = value;
                    break;
                case "hosp_level_name"://医疗机构级别
                    this.hosp_level_name = value;
                    break;
                case "hosp_grade_name"://医疗机构等级
                    this.hosp_grade_name = value;
                    break;
                case "corp_name"://单位名称
                    this.corp_name = value;
                    break;
                case "in_disease"://入院诊断
                    this.in_disease = value;
                    break;
                case "fin_disease"://出院诊断
                    this.fin_disease = value;
                    break;
                case "begin_date"://入院日期
                    this.begin_date = value;
                    break;
                case "end_date"://出院日期
                    this.end_date = value;
                    break;
                case "days"://住院天数
                    this.days = value;
                    break;
                case "in_dept_name"://科室名称
                    this.in_dept_name = value;
                    break;
                case "treatment_type"://待遇类型
                    this.treatment_type = value;
                    break;
                case "treatment_name"://待遇类型名称
                    this.treatment_name = value;
                    break;
                case "injury_borth_sn"://生育凭证号
                    this.injury_borth_sn = value;
                    break;
                case "last_balance"://个人账户余额
                    this.last_balance = value;
                    break;
                case "fin_date"://结算时间
                    this.fin_date = value;
                    break;
                default:
                    break;
            }
        }
    }
}