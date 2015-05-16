using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 支付信息
    /// </summary>
    public class PayInfo
    {
        [Description("基金支付名称")]
        public string fund_name { get; set; }

        [Description("基金支付金额")]
        public string real_pay { get; set; }
    }
}