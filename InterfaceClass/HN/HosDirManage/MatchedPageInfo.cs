using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.HosDirManage
{
    /// <summary>
    /// 审核通过匹配结果信息
    /// </summary>
    public class MatchedPageInfo
    {
        [Description("匹配序列号")]
        public string serial_match { get; set; }

        [Description("匹配类型")]
        public string match_type { get; set; }

        [Description("中心项目编码")]
        public string item_code { get; set; }

        [Description("中心项目名称")]
        public string item_name { get; set; }

        [Description("中心剂型编码")]
        public string model { get; set; }

        [Description("医院编号")]
        public string hospital_id { get; set; }

        [Description("医院目录编码")]
        public string hosp_code { get; set; }

        [Description("医院目录名称")]
        public string hosp_name { get; set; }

        [Description("医院目录剂型")]
        public string hosp_model { get; set; }

        [Description("医院目录规格")]
        public string hosp_standard { get; set; }

        [Description("医院目录单价")]
        public string hosp_price { get; set; }

        [Description("甲/乙标志")]
        public string staple_flag { get; set; }

        [Description("生效日期")]
        public string effect_date { get; set; }

        [Description("失效日期")]
        public string expire_date { get; set; }

        [Description("审核标志")]
        public string audit_flag { get; set; }
    }
}