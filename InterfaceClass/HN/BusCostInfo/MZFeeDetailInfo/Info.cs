using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.BusCostInfo.MZFeeDetailInfo
{
    public class Info
    {
        #region 属性

        [Description("费用类别名称")]
        public string stat_name { get; set; }
        [Description("费用类别")]
        public string stat_type { get; set; }
        [Description("医院药品项目名称")]
        public string his_item_name { get; set; }
        [Description("中心药品项目编码")]
        public string item_code { get; set; }
        [Description("自付比例")]
        public string self_scale { get; set; }
        [Description("单位")]
        public string unit { get; set; }
        [Description("用量")]
        public string dosage { get; set; }
        [Description("费用发生时间")]
        public string fee_date { get; set; }
        [Description("金额")]
        public string money { get; set; }
        [Description("自付金额")]
        public string pay_first { get; set; }
        [Description("处方医生名称")]
        public string doctor_name { get; set; }
        [Description("处方号")]
        public string recipe_no { get; set; }
        [Description("中心药品项目名称")]
        public string item_name { get; set; }
        [Description("厂家")]
        public string factory { get; set; }
        [Description("计算标志")]
        public string calc_flag { get; set; }
        [Description("处方医生编号")]
        public string doctor_no { get; set; }
        [Description("单价")]
        public string price { get; set; }
        [Description("费用序列号")]
        public string serial_fee { get; set; }
        [Description("费用上传时间")]
        public string trans_date { get; set; }
        [Description("剂型")]
        public string model { get; set; }
        [Description("规格")]
        public string standard { get; set; }
        [Description("录入人")]
        public string input_man { get; set; }
        [Description("使用标志")]
        public string usage_flag { get; set; }
        #endregion

        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "stat_name"://费用类别名称
                    this.stat_name = value;
                    break;
                case "stat_type"://费用类别
                    this.stat_type = value;
                    break;
                case "his_item_name"://医院药品项目名称
                    this.his_item_name = value;
                    break;
                case "item_code"://中心药品项目编码
                    this.item_code = value;
                    break;
                case "self_scale"://自付比例
                    this.self_scale = value;
                    break;
                case "unit"://单位
                    this.unit = value;
                    break;
                case "dosage"://用量
                    this.dosage = value;
                    break;
                case "fee_date"://费用发生时间
                    this.fee_date = value;
                    break;
                case "money"://金额
                    this.money = value;
                    break;
                case "pay_first"://自付金额
                    this.pay_first = value;
                    break;
                case "doctor_name"://处方医生名称
                    this.doctor_name = value;
                    break;
                case "recipe_no"://处方号
                    this.recipe_no = value;
                    break;
                case "item_name"://中心药品项目名称
                    this.item_name = value;
                    break;
                case "factory"://厂家
                    this.factory = value;
                    break;
                case "calc_flag"://计算标志
                    this.calc_flag = value;
                    break;
                case "doctor_no"://处方医生编号
                    this.doctor_no = value;
                    break;
                case "price"://单价
                    this.price = value;
                    break;
                case "serial_fee"://费用序列号
                    this.serial_fee = value;
                    break;
                case "trans_date"://费用上传时间
                    this.trans_date = value;
                    break;
                case "model"://剂型
                    this.model = value;
                    break;
                case "standard"://规格
                    this.standard = value;
                    break;
                case "input_man"://录入人
                    this.input_man = value;
                    break;
                case "usage_flag"://使用标志
                    this.usage_flag = value;
                    break;
                default:
                    break;
            }
        }
    }
}