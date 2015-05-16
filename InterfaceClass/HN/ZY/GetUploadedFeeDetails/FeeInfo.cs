using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetUploadedFeeDetails
{
    /// <summary>
    /// 
    /// </summary>
    public class FeeInfo
    {
        #region 属性

        [Description("医疗机构编号")]
        public string hospital_id { get; set; }

        [Description("费用序列号")]
        public string serial_fee { get; set; }

        [Description("申请序列号")]
        public string serial_apply { get; set; }

        [Description("就医登记号")]
        public string serial_no { get; set; }

        [Description("处方号")]
        public string recipe_no { get; set; }

        [Description("处方医生编号")]
        public string doctor_no { get; set; }

        [Description("处方医生姓名")]
        public string doctor_name { get; set; }

        [Description("费用统计类别")]
        public string stat_type { get; set; }

        [Description("项目药品类型")]
        public string medi_item_type { get; set; }

        [Description("待遇支付类型")]
        public string defray_type { get; set; }

        [Description("医院药品项目编码")]
        public string his_item_code { get; set; }

        [Description("医院药品项目名称")]
        public string his_item_name { get; set; }

        [Description("中心药品项目编码")]
        public string item_code { get; set; }

        [Description("中心药品项目名称")]
        public string item_name { get; set; }

        [Description("剂型")]
        public string model { get; set; }

        [Description("厂家")]
        public string factory { get; set; }

        [Description("规格")]
        public string standard { get; set; }

        [Description("计量单位")]
        public string unit { get; set; }

        [Description("金额")]
        public string money { get; set; }

        [Description("已退费金额")]
        public string reduce_money { get; set; }

        [Description("费用发生时间")]
        public string fee_date { get; set; }

        [Description("出院带药标志")]
        public string usage_flag { get; set; }

        [Description("出院带药天数")]
        public string usage_days { get; set; }

        [Description("录入人工号")]
        public string input_staff { get; set; }

        [Description("录入时间")]
        public string input_date { get; set; }

        [Description("医院费用序列号")]
        public string hos_serial { get; set; }

        [Description("上传时间")]
        public string trans_date { get; set; }

        [Description("录入人姓名")]
        public string input_man { get; set; }

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
                case "serial_fee"://费用序列号
                    this.serial_fee = value;
                    break;
                case "serial_apply"://申请序列号
                    this.serial_apply = value;
                    break;
                case "serial_no"://就医登记号
                    this.serial_no = value;
                    break;
                case "recipe_no"://处方号
                    this.recipe_no = value;
                    break;
                case "doctor_no"://处方医生编号
                    this.doctor_no = value;
                    break;
                case "doctor_name"://处方医生姓名
                    this.doctor_name = value;
                    break;
                case "stat_type"://费用统计类别
                    this.stat_type = value;
                    break;
                case "medi_item_type"://项目药品类型
                    this.medi_item_type = value;
                    break;
                case "defray_type"://待遇支付类型
                    this.defray_type = value;
                    break;
                case "his_item_code"://医院药品项目编码
                    this.his_item_code = value;
                    break;
                case "his_item_name"://医院药品项目名称
                    this.his_item_name = value;
                    break;
                case "item_code"://中心药品项目编码
                    this.item_code = value;
                    break;
                case "item_name"://中心药品项目名称
                    this.item_name = value;
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
                case "unit"://计量单位
                    this.unit = value;
                    break;
                case "money"://金额
                    this.money = value;
                    break;
                case "reduce_money"://已退费金额
                    this.reduce_money = value;
                    break;
                case "fee_date"://费用发生时间
                    this.fee_date = value;
                    break;
                case "usage_flag"://出院带药标志
                    this.usage_flag = value;
                    break;
                case "usage_days"://出院带药天数
                    this.usage_days = value;
                    break;
                case "input_staff"://录入人工号
                    this.input_staff = value;
                    break;
                case "input_date"://录入时间
                    this.input_date = value;
                    break;
                case "hos_serial"://医院费用序列号
                    this.hos_serial = value;
                    break;
                case "trans_date"://上传时间
                    this.trans_date = value;
                    break;
                case "input_man"://录入人姓名
                    this.input_man = value;
                    break;
                default:
                    break;
            }
        }
    }
}