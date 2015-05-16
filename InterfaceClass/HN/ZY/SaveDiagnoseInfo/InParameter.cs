using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.SaveDiagnoseInfo
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

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("操作员工号")]
        public string input_staff { get; set; }

        [Description("操作员姓名")]
        public string input_man { get; set; }

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
                case "biz_type"://业务类型
                    this.biz_type = value;
                    break;
                case "input_staff"://操作员工号
                    this.input_staff = value;
                    break;
                case "input_man"://操作员姓名
                    this.input_man = value;
                    break;
                default:
                    break;
            }
        }
    }
}