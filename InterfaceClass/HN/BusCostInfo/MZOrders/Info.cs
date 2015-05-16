using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.BusCostInfo.MZOrders
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

        [Description("IC卡号")]
        public string card_no { get; set; }

        [Description("身份证号码")]
        public string idcard { get; set; }

        [Description("医疗机构名称")]
        public string hospital_name { get; set; }

        [Description("医疗机构级别")]
        public string hospital_level { get; set; }

        [Description("业务序列号")]
        public string serial_no { get; set; }

        [Description("药品或项目名称")]
        public string medi_name { get; set; }

        [Description("单位规格")]
        public string unit { get; set; }

        [Description("单价")]
        public string price { get; set; }

        [Description("数量")]
        public string dosage { get; set; }

        [Description("金额")]
        public string money { get; set; }

        [Description("完成时间")]
        public string fin_date { get; set; }

        [Description("个人账户余额")]
        public string last_balance { get; set; }

        #endregion

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "name"://
                    this.name = value;
                    break;
                case "card_no"://
                    this.card_no = value;
                    break;
                case "idcard"://
                    this.idcard = value;
                    break;
                case "hospital_name"://
                    this.hospital_name = value;
                    break;
                case "hospital_level"://
                    this.hospital_level = value;
                    break;
                case "serial_no"://
                    this.serial_no = value;
                    break;
                case "medi_name"://
                    this.medi_name = value;
                    break;
                case "unit"://
                    this.unit = value;
                    break;
                case "price"://
                    this.price = value;
                    break;
                case "dosage"://
                    this.dosage = value;
                    break;
                case "money"://
                    this.money = value;
                    break;
                case "fin_date"://
                    this.fin_date = value;
                    break;
                case "last_balance"://
                    this.last_balance = value;
                    break;
                default:
                    break;
            }
        }
    }
}