using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 门诊费用明细信息
    /// </summary>
    public class FeeInfo
    {
        [Description("项目药品类型")]
        public string medi_item_type { get; set; }

        [Description("费用统计类别")]
        public string stat_type { get; set; }

        [Description("医院药品项目编码")]
        public string his_item_code { get; set; }

        [Description("中心药品项目编码")]
        public string item_code { get; set; }

        [Description("医院药品项目名称")]
        public string his_item_name { get; set; }

        [Description("剂型")]
        public string model { get; set; }

        [Description("厂家")]
        public string factory { get; set; }

        [Description("规格")]
        public string standard { get; set; }

        [Description("费用发生时间")]
        public string fee_date { get; set; }

        [Description("计量单位	")]
        public string unit { get; set; }

        [Description("单价")]
        public string price { get; set; }

        [Description("用量")]
        public string dosage { get; set; }

        [Description("金额")]
        public string money { get; set; }

        [Description("用药标志")]
        public string usage_flag { get; set; }

        [Description("出院带药天数")]
        public string usage_days { get; set; }

        [Description("对应费用序列号")]
        public string opp_serial_fee { get; set; }

        [Description("医院费用序列号")]
        public string hos_serial { get; set; }

        [Description("录入工号")]
        public string input_staff { get; set; }

        [Description("录入人")]
        public string input_man { get; set; }

        [Description("录入日期")]
        public string input_date { get; set; }

        [Description("处方号")]
        public string recipe_no { get; set; }

        [Description("处方医生编号")]
        public string doctor_no { get; set; }

        [Description("处方医生姓名")]
        public string doctor_name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "medi_item_type":
                    this.medi_item_type = value;
                    break;
                case "stat_type":
                    this.stat_type = value;
                    break;
                case "his_item_code":
                    this.his_item_code = value;
                    break;
                case "item_code":
                    this.item_code = value;
                    break;
                case "his_item_name":
                    this.his_item_name = value;
                    break;
                case "model":
                    this.model = value;
                    break;
                case "factory":
                    this.factory = value;
                    break;
                case "standard":
                    this.standard = value;
                    break;
                case "fee_date":
                    this.fee_date = value;
                    break;
                case "unit":
                    this.unit = value;
                    break;
                case "price":
                    this.price = value;
                    break;
                case "dosage":
                    this.dosage = value;
                    break;
                case "money":
                    this.money = value;
                    break;
                case "usage_flag":
                    this.usage_flag = value;
                    break;
                case "usage_days":
                    this.usage_days = value;
                    break;
                case "opp_serial_fee":
                    this.opp_serial_fee = value;
                    break;
                case "hos_serial":
                    this.hos_serial = value;
                    break;
                case "input_staff":
                    this.input_staff = value;
                    break;
                case "input_man":
                    this.input_man = value;
                    break;
                case "input_date":
                    this.input_date = value;
                    break;
                case "recipe_no":
                    this.recipe_no = value;
                    break;
                case "doctor_no":
                    this.doctor_no = value;
                    break;
                case "doctor_name":
                    this.doctor_name = value;
                    break;
                default:
                    break;
            }
        }
    }
}