using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.CheckAndSaveFeeDetails
{
    /// <summary>
    /// 
    /// </summary>
    public class FeeInfo
    {
        #region 属性

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

        [Description("计量单位")]
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

        [Description("备注")]
        public string remark { get; set; }

        [Description("特治特检申请序号")]
        public string serial_apply { get; set; }

        [Description("非工伤费用标志")]
        public string make_flag { get; set; }

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
                case "medi_item_type"://项目药品类型
                    this.medi_item_type = value;
                    break;
                case "stat_type"://费用统计类别
                    this.stat_type = value;
                    break;
                case "his_item_code"://医院药品项目编码
                    this.his_item_code = value;
                    break;
                case "item_code"://中心药品项目编码
                    this.item_code = value;
                    break;
                case "his_item_name"://医院药品项目名称
                    this.his_item_name = value;
                    break;
                case "model"://剂型
                    this.model = value;
                    break;
                case "factory"://厂家
                    this.factory = value;
                    break;
                case "standard"://规格
                    this.standard = value;
                    break;
                case "fee_date"://费用发生时间
                    this.fee_date = value;
                    break;
                case "unit"://计量单位
                    this.unit = value;
                    break;
                case "price"://单价
                    this.price = value;
                    break;
                case "dosage"://用量
                    this.dosage = value;
                    break;
                case "money"://金额
                    this.money = value;
                    break;
                case "usage_flag"://用药标志
                    this.usage_flag = value;
                    break;
                case "usage_days"://出院带药天数
                    this.usage_days = value;
                    break;
                case "opp_serial_fee"://对应费用序列号
                    this.opp_serial_fee = value;
                    break;
                case "hos_serial"://医院费用序列号
                    this.hos_serial = value;
                    break;
                case "remark"://备注
                    this.remark = value;
                    break;
                case "serial_apply"://特治特检申请序号
                    this.serial_apply = value;
                    break;
                case "make_flag"://非工伤费用标志
                    this.make_flag = value;
                    break;
                default:
                    break;
            }
        }
    }
}