using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.HosDirManage
{
    /// <summary>
    /// 匹配成功的数据
    /// </summary>
    public class Effectdetail
    {
        [Description("匹配序列号")]
        public string serial_match { get; set; }

        [Description("医院目录编码")]
        public string hosp_code { get; set; }
    }
}