using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.BIZC131204
{
    /// <summary>
    /// 住院登记保存参数部分
    /// </summary>
    public class InParameter
    {
        #region 属性

        [Description("中心编码")]
        public string center_id { get; set; }

        [Description("医疗机构编码")]
        public string hospital_id { get; set; }

        [Description("个人电脑号")]
        public string indi_id { get; set; }

        [Description("人员类别")]
        public string pers_type { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("待遇类型")]
        public string treatment_type { get; set; }

        [Description("入院登记时间")]
        public string reg_date { get; set; }

        [Description("登记人员工号")]
        public string reg_staff { get; set; }

        [Description("登记人姓名")]
        public string reg_man { get; set; }

        [Description("入院方式")]
        public string reg_flag { get; set; }

        [Description("业务申请序列号")]
        public string serial_apply { get; set; }

        [Description("关联医疗机构编码")]
        public string rela_hospital_id { get; set; }

        [Description("关联就医登记号")]
        public string rela_serial_no { get; set; }

        [Description("入院时间")]
        public string begin_date { get; set; }

        [Description("工伤（生育）个人业务序号")]
        public string injury_borth_sn { get; set; }

        [Description("本年住院次数")]
        public string biz_times { get; set; }

        [Description("入院科室编号")]
        public string in_dept { get; set; }

        [Description("入院科室名称")]
        public string in_dept_name { get; set; }

        [Description("入院病区编号")]
        public string in_area { get; set; }

        [Description("入院病区名称")]
        public string in_area_name { get; set; }

        [Description("入院病床编号")]
        public string in_bed { get; set; }

        [Description("床位类型")]
        public string bed_type { get; set; }

        [Description("住院号")]
        public string patient_id { get; set; }

        [Description("预付款总额")]
        public string foregift { get; set; }

        [Description("入院诊断")]
        public string in_disease { get; set; }

        [Description("入院诊断名称")]
        public string disease { get; set; }

        [Description("用卡标志")]
        public string ic_flag { get; set; }

        [Description("IC卡号")]
        public string ic_no { get; set; }

        [Description("实际刷卡人身份证")]
        public string fact_idcard { get; set; }

        [Description("病情备注")]
        public string remark { get; set; }

        #endregion

        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "center_id"://中心编码
                    this.center_id = value;
                    break;
                case "hospital_id"://医疗机构编码
                    this.hospital_id = value;
                    break;
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "pers_type"://人员类别
                    this.pers_type = value;
                    break;
                case "biz_type"://业务类型
                    this.biz_type = value;
                    break;
                case "treatment_type"://待遇类型
                    this.treatment_type = value;
                    break;
                case "reg_date"://入院登记时间
                    this.reg_date = value;
                    break;
                case "reg_staff"://登记人员工号
                    this.reg_staff = value;
                    break;
                case "reg_man"://登记人姓名
                    this.reg_man = value;
                    break;
                case "reg_flag"://入院方式
                    this.reg_flag = value;
                    break;
                case "serial_apply"://业务申请序列号
                    this.serial_apply = value;
                    break;
                case "rela_hospital_id"://关联医疗机构编码
                    this.rela_hospital_id = value;
                    break;
                case "rela_serial_no"://关联就医登记号
                    this.rela_serial_no = value;
                    break;
                case "begin_date"://入院时间
                    this.begin_date = value;
                    break;
                case "injury_borth_sn"://工伤（生育）个人业务序号
                    this.injury_borth_sn = value;
                    break;
                case "biz_times"://本年住院次数
                    this.biz_times = value;
                    break;
                case "in_dept"://入院科室编号
                    this.in_dept = value;
                    break;
                case "in_dept_name"://入院科室名称
                    this.in_dept_name = value;
                    break;
                case "in_area"://入院病区编号
                    this.in_area = value;
                    break;
                case "in_area_name"://入院病区名称
                    this.in_area_name = value;
                    break;
                case "in_bed"://入院病床编号
                    this.in_bed = value;
                    break;
                case "bed_type"://床位类型
                    this.bed_type = value;
                    break;
                case "patient_id"://住院号
                    this.patient_id = value;
                    break;
                case "foregift"://预付款总额
                    this.foregift = value;
                    break;
                case "in_disease"://入院诊断
                    this.in_disease = value;
                    break;
                case "disease"://入院诊断名称
                    this.disease = value;
                    break;
                case "ic_flag"://用卡标志
                    this.ic_flag = value;
                    break;
                case "ic_no"://IC卡号
                    this.ic_no = value;
                    break;
                case "fact_idcard"://实际刷卡人身份证
                    this.fact_idcard = value;
                    break;
                case "remark"://病情备注
                    this.remark = value;
                    break;
                default:
                    break;
            }
        }
    }
}