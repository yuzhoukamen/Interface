using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HosDirManage
{
    public class Medic
    {
        /// <summary>
        /// 药品编码
        /// </summary>
        public string medi_code { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string medi_name { get; set; }

        /// <summary>
        /// 药品英名名
        /// </summary>
        public string english_name { get; set; }

        /// <summary>
        /// 剂型编码
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// 药品类型
        /// </summary>
        public string medi_item_type { get; set; }

        /// <summary>
        /// 药品费用分类
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
        public string price { get; set; }

        /// <summary>
        /// 甲/乙标志
        /// </summary>
        public string staple_flag { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public string effect_date { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        public string expire_date { get; set; }

        /// <summary>
        /// 处方用药标志
        /// </summary>
        public string otc { get; set; }

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
