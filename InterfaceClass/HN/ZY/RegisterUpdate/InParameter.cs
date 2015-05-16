using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.RegisterUpdate
{
    /// <summary>
    /// 住院信息修改参数
    /// </summary>
    public class InParameter
    {
        #region 属性

        [Description("医疗机构编码")]
        public string hospital_id { get; set; }

        [Description("就医登记号")]
        public string serial_no { get; set; }

        [Description("个人电脑号")]
        public string indi_id { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("操作员工号")]
        public string reg_staff { get; set; }

        [Description("操作员姓名")]
        public string reg_man { get; set; }

        [Description("业务开始日期")]
        public string begin_date { get; set; }

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

        [Description("原住院号")]
        public string old_patient_id { get; set; }

        [Description("入院诊断")]
        public string in_disease { get; set; }

        [Description("入院诊断名称")]
        public string disease { get; set; }

        [Description("备注")]
        public string remark { get; set; }

        [Description("待遇类别")]
        public string treatment_type { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "hospital_id"://医疗机构编码
                    this.hospital_id = value;
                    break;
                case "serial_no"://就医登记号
                    this.serial_no = value;
                    break;
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "biz_type"://业务类型
                    this.biz_type = value;
                    break;
                case "reg_staff"://操作员工号
                    this.reg_staff = value;
                    break;
                case "reg_man"://操作员姓名
                    this.reg_man = value;
                    break;
                case "begin_date"://业务开始日期
                    this.begin_date = value;
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
                case "old_patient_id"://原住院号
                    this.old_patient_id = value;
                    break;
                case "in_disease"://入院诊断
                    this.in_disease = value;
                    break;
                case "disease"://入院诊断名称
                    this.disease = value;
                    break;
                case "remark"://备注
                    this.remark = value;
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
