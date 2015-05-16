using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetPersonInfo
{
    /// <summary>
    /// 住院业务相关信息
    /// </summary>
    public class Elseinfo
    {
        #region 属性

        [Description("本年度住院次数")]
        public string biz_times { get; set; }

        [Description("本能住院申报累计")]
        public string declare_year { get; set; }

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
                case "biz_times"://本年度住院次数
                    this.biz_times = value;
                    break;
                case "declare_year"://本能住院申报累计
                    this.declare_year = value;
                    break;
                default:
                    break;
            }
        }
    }
}