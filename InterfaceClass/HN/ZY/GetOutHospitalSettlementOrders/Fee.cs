using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders
{
    /// <summary>
    /// 分类统计本次业务的各项费用发生额
    /// </summary>
    public class Fee
    {
        #region 属性

        [Description("收费项目类型")]
        public string stat_type { get; set; }

        [Description("收费项目名称")]
        public string stat_name { get; set; }

        [Description("总费用")]
        public string zfy { get; set; }

        [Description("个人完全自费")]
        public string qzf { get; set; }

        [Description("个人部分自负")]
        public string blzf { get; set; }

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
                case "stat_type"://收费项目类型
                    this.stat_type = value;
                    break;
                case "stat_name"://收费项目名称
                    this.stat_name = value;
                    break;
                case "zfy"://总费用
                    this.zfy = value;
                    break;
                case "qzf"://个人完全自费
                    this.qzf = value;
                    break;
                case "blzf"://个人部分自负
                    this.blzf = value;
                    break;
                default:
                    break;
            }
        }
    }
}