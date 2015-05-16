using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 个人基金冻结信息
    /// </summary>
    public class FreezeInfo
    {
        [Description("编号")]
        public string fund_id { get; set; }

        [Description("名称")]
        public string fund_name { get; set; }

        [Description("状态")]
        public string indi_freeze_status { get; set; }
    }
}
