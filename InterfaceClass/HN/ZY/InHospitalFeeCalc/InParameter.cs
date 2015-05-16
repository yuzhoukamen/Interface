using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.InHospitalFeeCalc
{
    /// <summary>
    /// 
    /// </summary>
    public class InParameter
    {
        #region 属性

        [Description("医疗机构编码")]
        public string hospital_id { get; set; }

        [Description("就医登记号")]
        public string serial_no { get; set; }

        [Description("本次业务个人帐户可用金额")]
        public string last_balance { get; set; }

        [Description("保存标志")]
        public string save_flag { get; set; }

        [Description("待遇类别")]
        public string treatment_type { get; set; }

        [Description("出院诊断")]
        public string end_disease { get; set; }

        [Description("生育就诊类型")]
        public string reg_flag { get; set; }

        [Description("出院时间")]
        public string end_date { get; set; }

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
                case "hospital_id"://医疗机构编码
                    this.hospital_id = value;
                    break;
                case "serial_no"://就医登记号
                    this.serial_no = value;
                    break;
                case "last_balance"://本次业务个人帐户可用金额
                    this.last_balance = value;
                    break;
                case "save_flag"://保存标志
                    this.save_flag = value;
                    break;
                case "treatment_type"://待遇类别
                    this.treatment_type = value;
                    break;
                case "end_disease"://出院诊断
                    this.end_disease = value;
                    break;
                case "reg_flag"://生育就诊类型
                    this.reg_flag = value;
                    break;
                case "end_date"://出院时间
                    this.end_date = value;
                    break;
                default:
                    break;
            }
        }
    }
}