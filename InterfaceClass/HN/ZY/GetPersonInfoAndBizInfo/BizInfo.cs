using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo
{
    /// <summary>
    /// 个人基本信息、住院业务信息
    /// </summary>
    public class BizInfo
    {
        #region 属性

        [Description("医疗机构编号")]
        public string hospital_id { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("中心编码")]
        public string center_id { get; set; }

        [Description("个人电脑号")]
        public string indi_id { get; set; }

        [Description("姓名")]
        public string name { get; set; }

        [Description("性别")]
        public string sex { get; set; }

        [Description("公民身份号码")]
        public string idcard { get; set; }

        [Description("医保卡号")]
        public string ic_no { get; set; }

        [Description("出生日期")]
        public string birthday { get; set; }

        [Description("联系电话")]
        public string telephone { get; set; }

        [Description("人员类别")]
        public string pers_type { get; set; }

        [Description("人员类别名称")]
        public string pers_name { get; set; }

        [Description("单位编码")]
        public string corp_id { get; set; }

        [Description("单位名称")]
        public string corp_name { get; set; }

        [Description("待遇类别")]
        public string treatment_type { get; set; }

        [Description("业务登记日期")]
        public string reg_date { get; set; }

        [Description("登记人工号")]
        public string reg_staff { get; set; }

        [Description("登记人")]
        public string reg_man { get; set; }

        [Description("登记标志")]
        public string reg_flag { get; set; }

        [Description("业务开始时间")]
        public string begin_date { get; set; }

        [Description("业务开始情况")]
        public string reg_info { get; set; }

        [Description("入院科室")]
        public string in_dept { get; set; }

        [Description("入院科室名称")]
        public string in_dept_name { get; set; }

        [Description("入院病区")]
        public string in_area { get; set; }

        [Description("入院病区名称")]
        public string in_area_name { get; set; }

        [Description("入院床位号")]
        public string in_bed { get; set; }

        [Description("医院业务号(挂号)")]
        public string patient_id { get; set; }

        [Description("入院疾病诊断（icd码）")]
        public string in_disease { get; set; }

        [Description("入院诊断疾病名称")]
        public string in_disease_name { get; set; }

        [Description("确认疾病诊断（icd码）")]
        public string diagnose { get; set; }

        [Description("确认诊断名称")]
        public string diagnose_name { get; set; }

        [Description("确诊日期")]
        public string diagnose_date { get; set; }

        [Description("出院疾病诊断（icd码）")]
        public string fin_disease { get; set; }

        [Description("出院诊断名称")]
        public string fin_disease_name { get; set; }

        [Description("出院日期")]
        public string end_date { get; set; }

        [Description("住院天数")]
        public string in_days { get; set; }

        [Description("出院登记人工号")]
        public string end_staff { get; set; }

        [Description("出院登记人")]
        public string end_man { get; set; }

        [Description("出院标志")]
        public string finish_flag { get; set; }

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
                case "hospital_id"://医疗机构编号
                    this.hospital_id = value;
                    break;
                case "biz_type"://业务类型
                    this.biz_type = value;
                    break;
                case "center_id"://中心编码
                    this.center_id = value;
                    break;
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "name"://姓名
                    this.name = value;
                    break;
                case "sex"://性别
                    this.sex = value;
                    break;
                case "idcard"://公民身份号码
                    this.idcard = value;
                    break;
                case "ic_no"://医保卡号
                    this.ic_no = value;
                    break;
                case "birthday"://出生日期
                    this.birthday = value;
                    break;
                case "telephone"://联系电话
                    this.telephone = value;
                    break;
                case "pers_type"://人员类别
                    this.pers_type = value;
                    break;
                case "pers_name"://人员类别名称
                    this.pers_name = value;
                    break;
                case "corp_id"://单位编码
                    this.corp_id = value;
                    break;
                case "corp_name"://单位名称
                    this.corp_name = value;
                    break;
                case "treatment_type"://待遇类别
                    this.treatment_type = value;
                    break;
                case "reg_date"://业务登记日期
                    this.reg_date = value;
                    break;
                case "reg_staff"://登记人工号
                    this.reg_staff = value;
                    break;
                case "reg_man"://登记人
                    this.reg_man = value;
                    break;
                case "reg_flag"://登记标志
                    this.reg_flag = value;
                    break;
                case "begin_date"://业务开始时间
                    this.begin_date = value;
                    break;
                case "reg_info"://业务开始情况
                    this.reg_info = value;
                    break;
                case "in_dept"://入院科室
                    this.in_dept = value;
                    break;
                case "in_dept_name"://入院科室名称
                    this.in_dept_name = value;
                    break;
                case "in_area"://入院病区
                    this.in_area = value;
                    break;
                case "in_area_name"://入院病区名称
                    this.in_area_name = value;
                    break;
                case "in_bed"://入院床位号
                    this.in_bed = value;
                    break;
                case "patient_id"://医院业务号(挂号)
                    this.patient_id = value;
                    break;
                case "in_disease"://入院疾病诊断（icd码）
                    this.in_disease = value;
                    break;
                case "in_disease_name"://入院诊断疾病名称
                    this.in_disease_name = value;
                    break;
                case "diagnose"://确认疾病诊断（icd码）
                    this.diagnose = value;
                    break;
                case "diagnose_name"://确认诊断名称
                    this.diagnose_name = value;
                    break;
                case "diagnose_date"://确诊日期
                    this.diagnose_date = value;
                    break;
                case "fin_disease"://出院疾病诊断（icd码）
                    this.fin_disease = value;
                    break;
                case "fin_disease_name"://出院诊断名称
                    this.fin_disease_name = value;
                    break;
                case "end_date"://出院日期
                    this.end_date = value;
                    break;
                case "in_days"://住院天数
                    this.in_days = value;
                    break;
                case "end_staff"://出院登记人工号
                    this.end_staff = value;
                    break;
                case "end_man"://出院登记人
                    this.end_man = value;
                    break;
                case "finish_flag"://出院标志
                    this.finish_flag = value;
                    break;
                default:
                    break;
            }
        }
    }
}