using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.BusCostInfo.MZFeeDetailInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class InParameters
    {
        #region 属性

        [Description("医院编码")]
        public string hospital_id { get; set; }
        [Description("业务序列号")]
        public string serial_no { get; set; }
        [Description("执行标志")]
        public string exec_flag { get; set; }
        [Description("中心标志")]
        public string center_flag { get; set; }
        [Description("费用类别")]
        public string stat_type { get; set; }
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
                case "hospital_id"://医院编码
                    this.hospital_id = value;
                    break;
                case "serial_no"://业务序列号
                    this.serial_no = value;
                    break;
                case "exec_flag"://执行标志
                    this.exec_flag = value;
                    break;
                case "center_flag"://中心标志
                    this.center_flag = value;
                    break;
                case "stat_type"://费用类别
                    this.stat_type = value;
                    break;
                default:
                    break;
            }
        }
    }
}