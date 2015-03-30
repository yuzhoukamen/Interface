using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HosDirManage
{
    /// <summary>
    /// 中心项目
    /// </summary>
    public class Project
    {
        /// <summary>
        /// 项目编码
        /// </summary>
        public string item_code { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string item_name { get; set; }

        /// <summary>
        /// 项目分类编码
        /// </summary>
        public string class_code { get; set; }

        /// <summary>
        /// 标准单位
        /// </summary>
        public string unit { get; set; }

        /// <summary>
        /// 标准单价
        /// </summary>
        public string price { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>
        public string medi_item_type { get; set; }

        /// <summary>
        /// 项目费用分类
        /// </summary>
        public string stat_type { get; set; }

        /// <summary>
        /// 五笔码
        /// </summary>
        public string code_wb { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string code_py { get; set; }

        /// <summary>
        /// 标准单价
        /// </summary>
        public string self_scale { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public string effect_date { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        public string expire_date { get; set; }

        /// <summary>
        /// 医疗目录
        /// </summary>
        public string mt_flag { get; set; }

        /// <summary>
        /// 工伤补充目录
        /// </summary>
        public string wl_flag { get; set; }

        /// <summary>
        /// 生育补充目录
        /// </summary>
        public string bo_flag { get; set; }

        /// <summary>
        /// 特殊人群补充目录
        /// </summary>
        public string sp_flag { get; set; }
    }
}
