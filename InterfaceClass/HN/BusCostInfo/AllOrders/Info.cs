using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.BusCostInfo.AllOrders
{
    public class Info
    {
        #region 属性

        [Description("医院编号")]
        public string hospital_id { get; set; }
        [Description("医疗机构名称")]
        public string hospital_name { get; set; }
        [Description("个人电脑号")]
        public string indi_id { get; set; }
        [Description("业务序列号")]
        public string serial_no { get; set; }
        [Description("业务类别")]
        public string biz_type { get; set; }
        [Description("疾病名称")]
        public string disease { get; set; }
        [Description("登记人")]
        public string reg_man { get; set; }
        [Description("业务开始时间")]
        public string begin_date { get; set; }
        [Description("业务结束时间")]
        public string end_date { get; set; }
        [Description("姓名")]
        public string name { get; set; }
        [Description("性别")]
        public string sex { get; set; }
        [Description("身份证号")]
        public string idcard { get; set; }
        [Description("人员类别")]
        public string pers_type { get; set; }
        [Description("公务员级别")]
        public string office_grade { get; set; }
        [Description("病区名称")]
        public string in_area_name { get; set; }
        [Description("科室名称")]
        public string in_dept_name { get; set; }
        [Description("床位号")]
        public string in_bed { get; set; }
        [Description("床位类型")]
        public string bed_type { get; set; }
        [Description("单位名称")]
        public string corp_name { get; set; }
        [Description("结算时间")]
        public string fin_date { get; set; }
        [Description("出院诊断")]
        public string fin_disease { get; set; }
        [Description("零报标志")]
        public string reimburse_flag { get; set; }
        [Description("医院业务号")]
        public string patient_id { get; set; }
        [Description("区域编码")]
        public string district_code { get; set; }
        [Description("病例分行序号")]
        public string case_id { get; set; }
        [Description("总费用")]
        public string fees { get; set; }
        [Description("待遇类别")]
        public string treatment_type { get; set; }
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
                case "hospital_id"://医院编号
                    this.hospital_id = value;
                    break;
                case "hospital_name"://医疗机构名称
                    this.hospital_name = value;
                    break;
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "serial_no"://业务序列号
                    this.serial_no = value;
                    break;
                case "biz_type"://业务类别
                    this.biz_type = value;
                    break;
                case "disease"://疾病名称
                    this.disease = value;
                    break;
                case "reg_man"://登记人
                    this.reg_man = value;
                    break;
                case "begin_date"://业务开始时间
                    this.begin_date = value;
                    break;
                case "end_date"://业务结束时间
                    this.end_date = value;
                    break;
                case "name"://姓名
                    this.name = value;
                    break;
                case "sex"://性别
                    this.sex = value;
                    break;
                case "idcard"://身份证号
                    this.idcard = value;
                    break;
                case "pers_type"://人员类别
                    this.pers_type = value;
                    break;
                case "office_grade"://公务员级别
                    this.office_grade = value;
                    break;
                case "in_area_name"://病区名称
                    this.in_area_name = value;
                    break;
                case "in_dept_name"://科室名称
                    this.in_dept_name = value;
                    break;
                case "in_bed"://床位号
                    this.in_bed = value;
                    break;
                case "bed_type"://床位类型
                    this.bed_type = value;
                    break;
                case "corp_name"://单位名称
                    this.corp_name = value;
                    break;
                case "fin_date"://结算时间
                    this.fin_date = value;
                    break;
                case "fin_disease"://出院诊断
                    this.fin_disease = value;
                    break;
                case "reimburse_flag"://零报标志
                    this.reimburse_flag = value;
                    break;
                case "patient_id"://医院业务号
                    this.patient_id = value;
                    break;
                case "district_code"://区域编码
                    this.district_code = value;
                    break;
                case "case_id"://病例分行序号
                    this.case_id = value;
                    break;
                case "fees"://总费用
                    this.fees = value;
                    break;
                case "treatment_type"://待遇类别
                    this.treatment_type = value;
                    break;
                default:
                    break;
            }
        }
    }
}