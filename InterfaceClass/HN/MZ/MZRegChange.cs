using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 普通门诊改费
    /// </summary>
    public class MZRegChange
    {
        [Description("中心编码")]
        public string center_id { get; set; }

        [Description("医疗机构编码")]
        public string hospital_id { get; set; }

        [Description("就医登记号")]
        public string serial_no { get; set; }

        [Description("个人编号")]
        public string indi_id { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("待遇类型")]
        public string treatment_type { get; set; }

        [Description("登记人员工号")]
        public string reg_staff { get; set; }

        [Description("登记人姓名")]
        public string reg_man { get; set; }

        [Description("计算保存标志")]
        public string save_flag { get; set; }

        [Description("单据号")]
        public string bill_no { get; set; }

        [Description("发送方交易号")]
        public string trade_no { get; set; }

        [Description("疾病名称")]
        public string diagnose { get; set; }

        [Description("疾病时间")]
        public string diagnose_date { get; set; }

        [Description("正向退费标志")]
        public string query_flag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "center_id":
                    this.center_id = value;
                    break;
                case "hospital_id":
                    this.hospital_id = value;
                    break;
                case "serial_no":
                    this.serial_no = value;
                    break;
                case "indi_id":
                    this.indi_id = value;
                    break;
                case "biz_type":
                    this.biz_type = value;
                    break;
                case "treatment_type":
                    this.treatment_type = value;
                    break;
                case "reg_staff":
                    this.reg_staff = value;
                    break;
                case "reg_man":
                    this.reg_man = value;
                    break;
                case "save_flag":
                    this.save_flag = value;
                    break;
                case "bill_no":
                    this.bill_no = value;
                    break;
                case "trade_no":
                    this.trade_no = value;
                    break;
                case "diagnose":
                    this.diagnose = value;
                    break;
                case "diagnose_date":
                    this.diagnose_date = value;
                    break;
                case "query_flag":
                    this.query_flag = value;
                    break;
                default:
                    break;
            }
        }
    }
}