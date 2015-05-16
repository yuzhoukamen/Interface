using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.OutHospitalSettlement
{
    /// <summary>
    /// 
    /// </summary>
    public class InParameter
    {
        #region 属性

        [Description("保存标志")]
        public string save_flag { get; set; }

        [Description("医疗机构编码")]
        public string hospital_id { get; set; }

        [Description("就医登记号")]
        public string serial_no { get; set; }

        [Description("个人电脑号")]
        public string indi_id { get; set; }

        [Description("本次业务个人帐户可用金额")]
        public string last_balance { get; set; }

        [Description("出院疾病")]
        public string end_disease { get; set; }

        [Description("出院诊断名称")]
        public string end_disease_name { get; set; }

        [Description("出院日期")]
        public string end_date { get; set; }

        [Description("第一副诊断")]
        public string fin_disease1 { get; set; }

        [Description("第二副诊断")]
        public string fin_disease2 { get; set; }

        [Description("出院详情")]
        public string fin_info { get; set; }

        [Description("操作员工号")]
        public string staff_id { get; set; }

        [Description("操作员姓名")]
        public string staff_name { get; set; }

        [Description("待遇类别")]
        public string treatment_type { get; set; }

        [Description("单据号")]
        public string bill_no { get; set; }

        [Description("生育就诊类型")]
        public string reg_flag { get; set; }

        [Description("生育疾病类型")]
        public string reg_info { get; set; }

        [Description("特殊情况对应的申请序号")]
        public string serial_apply { get; set; }

        [Description("胎儿数")]
        public string fetus { get; set; }

        [Description("实际刷卡人身份证")]
        public string fact_idcard { get; set; }

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
                case "save_flag"://保存标志
                    this.save_flag = value;
                    break;
                case "hospital_id"://医疗机构编码
                    this.hospital_id = value;
                    break;
                case "serial_no"://就医登记号
                    this.serial_no = value;
                    break;
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "last_balance"://本次业务个人帐户可用金额
                    this.last_balance = value;
                    break;
                case "end_disease"://出院疾病
                    this.end_disease = value;
                    break;
                case "end_disease_name"://出院诊断名称
                    this.end_disease_name = value;
                    break;
                case "end_date"://出院日期
                    this.end_date = value;
                    break;
                case "fin_disease1"://第一副诊断
                    this.fin_disease1 = value;
                    break;
                case "fin_disease2"://第二副诊断
                    this.fin_disease2 = value;
                    break;
                case "fin_info"://出院详情
                    this.fin_info = value;
                    break;
                case "staff_id"://操作员工号
                    this.staff_id = value;
                    break;
                case "staff_name"://操作员姓名
                    this.staff_name = value;
                    break;
                case "treatment_type"://待遇类别
                    this.treatment_type = value;
                    break;
                case "bill_no"://单据号
                    this.bill_no = value;
                    break;
                case "reg_flag"://生育就诊类型
                    this.reg_flag = value;
                    break;
                case "reg_info"://生育疾病类型
                    this.reg_info = value;
                    break;
                case "serial_apply"://特殊情况对应的申请序号
                    this.serial_apply = value;
                    break;
                case "fetus"://胎儿数
                    this.fetus = value;
                    break;
                case "fact_idcard"://实际刷卡人身份证
                    this.fact_idcard = value;
                    break;
                default:
                    break;
            }
        }
    }
}