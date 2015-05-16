using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 门诊登记信息
    /// </summary>
    public class BizInfo
    {
        [Description("就医登记号")]
        public string serial_no { get; set; }

        //    [Description("发送方交易流水号")]
        //    public string trade_no { get; set; }

        //    [Description("单据号")]
        //    public string bill_no { get; set; }
    }
}