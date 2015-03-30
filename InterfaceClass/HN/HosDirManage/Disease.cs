using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HosDirManage
{
    /// <summary>
    /// 中心疾病
    /// </summary>
    public class Disease
    {
        /// <summary>
        /// 疾病编码
        /// </summary>
        public string icd { get; set; }

        /// <summary>
        /// 疾病名称
        /// </summary>
        public string disease { get; set; }

        /// <summary>
        /// 疾病费用标准
        /// </summary>
        public string disease_fee { get; set; }

        /// <summary>
        /// 五笔码
        /// </summary>
        public string code_wb { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string code_py { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string EDIT_DATE { get; set; }

        /// <summary>
        /// 修改人工号
        /// </summary>
        public string EDIT_STAFF { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string EDIT_MAN { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public string VALID_FLAG { get; set; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public string EFFECT_DATE { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public string EXPIRE_DATE { get; set; }

        /// <summary>
        /// 审核标志
        /// </summary>
        public string AUDIT_FLAG { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public string AUDIT_DATE { get; set; }

        /// <summary>
        /// 审核人工号
        /// </summary>
        public string AUDIT_STAFF { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string AUDIT_MAN { get; set; }

        /// <summary>
        /// 疾病序列号
        /// </summary>
        public string SERIAL_ICD { get; set; }
    }
}
