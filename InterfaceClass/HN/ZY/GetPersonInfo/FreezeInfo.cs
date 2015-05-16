using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetPersonInfo
{
    /// <summary>
    /// 个人基金冻结信息
    /// </summary>
    public class FreezeInfo
    {
        #region 属性

        [Description("基金编号")]
        public string fund_id { get; set; }

        [Description("基金名称")]
        public string fund_name { get; set; }

        [Description("基金状态标志")]
        public string indi_freeze_status { get; set; }

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
                case "fund_id"://基金编号
                    this.fund_id = value;
                    break;
                case "fund_name"://基金名称
                    this.fund_name = value;
                    break;
                case "indi_freeze_status"://基金状态标志
                    this.indi_freeze_status = value;
                    break;
                default:
                    break;
            }
        }
    }
}