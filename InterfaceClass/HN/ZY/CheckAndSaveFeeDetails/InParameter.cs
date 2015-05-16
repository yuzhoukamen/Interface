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
    public class InParameter
    {
        #region 属性

        [Description("医疗机构编码")]
        public string hospital_id { get; set; }

        [Description("个人电脑号")]
        public string indi_id { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("就医登记号")]
        public string serial_no { get; set; }

        [Description("录入人工号")]
        public string input_staff { get; set; }

        [Description("录入人姓名")]
        public string input_man { get; set; }

        [Description("处方号")]
        public string recipe_no { get; set; }

        [Description("处方医生编号")]
        public string doctor_no { get; set; }

        [Description("处方医生姓名")]
        public string doctor_name { get; set; }

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
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "biz_type"://业务类型
                    this.biz_type = value;
                    break;
                case "serial_no"://就医登记号
                    this.serial_no = value;
                    break;
                case "input_staff"://录入人工号
                    this.input_staff = value;
                    break;
                case "input_man"://录入人姓名
                    this.input_man = value;
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
                default:
                    break;
            }
        }
    }
}