using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.BusCostInfo.MZBigClassFeeInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Info
    {
        #region 属性

        [Description("费用类别名称")]
        public string stat_name { get; set; }

        [Description("费用类别")]
        public string stat_type { get; set; }

        [Description("总费用")]
        public string zfy { get; set; }

        [Description("部分自费")]
        public string blzf { get; set; }

        [Description("全自费")]
        public string qzf { get; set; }

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
                case "stat_name"://费用类别名称
                    this.stat_name = value;
                    break;
                case "stat_type"://费用类别
                    this.stat_type = value;
                    break;
                case "zfy"://总费用
                    this.zfy = value;
                    break;
                case "blzf"://部分自费
                    this.blzf = value;
                    break;
                case "qzf"://全自费
                    this.qzf = value;
                    break;
                default:
                    break;
            }
        }
    }
}