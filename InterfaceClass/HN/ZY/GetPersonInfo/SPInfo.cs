using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetPersonInfo
{
    /// <summary>
    /// 业务申请信息
    /// </summary>
    public class SPInfo
    {
        #region 属性

        [Description("业务申请序列号")]
        public string serial_apply { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("业务名称")]
        public string biz_name { get; set; }

        [Description("申请内容编码")]
        public string apply_content { get; set; }

        [Description("申请内容名称")]
        public string apply_content_name { get; set; }

        [Description("待遇类型")]
        public string treatment_type { get; set; }

        [Description("待遇名称")]
        public string treatment_name { get; set; }

        [Description("申请生效日期")]
        public string admit_effect { get; set; }

        [Description("申请失效日期")]
        public string admit_date { get; set; }

        [Description("申请病种编码")]
        public string icd { get; set; }

        [Description("申请病种名称")]
        public string disease { get; set; }

        [Description("工伤生育序列号")]
        public string injury_borth_sn { get; set; }

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
                case "serial_apply"://业务申请序列号
                    this.serial_apply = value;
                    break;
                case "biz_type"://业务类型
                    this.biz_type = value;
                    break;
                case "biz_name"://业务名称
                    this.biz_name = value;
                    break;
                case "apply_content"://申请内容编码
                    this.apply_content = value;
                    break;
                case "apply_content_name"://申请内容名称
                    this.apply_content_name = value;
                    break;
                case "treatment_type"://待遇类型
                    this.treatment_type = value;
                    break;
                case "treatment_name"://待遇名称
                    this.treatment_name = value;
                    break;
                case "admit_effect"://申请生效日期
                    this.admit_effect = value;
                    break;
                case "admit_date"://申请失效日期
                    this.admit_date = value;
                    break;
                case "icd"://申请病种编码
                    this.icd = value;
                    break;
                case "disease"://申请病种名称
                    this.disease = value;
                    break;
                case "injury_borth_sn"://工伤生育序列号
                    this.injury_borth_sn = value;
                    break;
                default:
                    break;
            }
        }
    }
}