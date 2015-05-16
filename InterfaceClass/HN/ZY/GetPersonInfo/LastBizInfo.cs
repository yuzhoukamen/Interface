using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetPersonInfo
{
    /// <summary>
    /// 上次住院业务信息
    /// </summary>
    public class Lastbizinfo
    {
        #region 属性

        [Description("医疗机构编号")]
        public string hospital_id { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("待遇类别")]
        public string treatment_type { get; set; }

        [Description("业务登记日期")]
        public string reg_date { get; set; }

        [Description("业务开始时间")]
        public string begin_date { get; set; }

        [Description("疾病名称")]
        public string disease { get; set; }

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
                case "biz_type"://业务类型
                    this.biz_type = value;
                    break;
                case "treatment_type"://待遇类别
                    this.treatment_type = value;
                    break;
                case "reg_date"://业务登记日期
                    this.reg_date = value;
                    break;
                case "begin_date"://业务开始时间
                    this.begin_date = value;
                    break;
                case "disease"://疾病名称
                    this.disease = value;
                    break;
                default:
                    break;
            }
        }
    }
}