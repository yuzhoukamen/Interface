using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.HosDirManage
{
    /// <summary>
    /// 新增医院目录匹配信息
    /// </summary>
    public class InsertInfo
    {
        [Description("中心编码")]
        public string center_id { get; set; }

        [Description("医院编码")]
        public string hospital_id { get; set; }

        [Description("匹配类型")]
        public string match_type { get; set; }

        [Description("医院目录编码")]
        public string hosp_code { get; set; }

        [Description("医院目录名称")]
        public string hosp_name { get; set; }

        [Description("医院目录剂型")]
        public string hosp_model { get; set; }

        [Description("单价")]
        public string price { get; set; }

        [Description("中心目录编码")]
        public string item_code { get; set; }

        [Description("中心目录名称")]
        public string item_name { get; set; }

        [Description("中心目录剂型")]
        public string model_name { get; set; }

        [Description("生效日期")]
        public string effect_date { get; set; }

        [Description("失效日期")]
        public string expire_date { get; set; }

        [Description("操作员工号")]
        public string edit_staff { get; set; }

        [Description("操作员姓名")]
        public string edit_man { get; set; }

        [Description("有效标志")]
        public string valid_flag { get; set; }

        [Description("审核标志")]
        public string audit_flag { get; set; }

        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "center_id":
                    this.center_id = value;
                    break;
                case "hospital_id":
                    this.hospital_id = value;
                    break;
                case "match_type":
                    this.match_type = value;
                    break;
                case "hosp_code":
                    this.hosp_code = value;
                    break;
                case "hosp_name":
                    this.hosp_name = value;
                    break;
                case "hosp_model":
                    this.hosp_model = value;
                    break;
                case "price":
                    this.price = value;
                    break;
                case "item_code":
                    this.item_code = value;
                    break;
                case "item_name":
                    this.item_name = value;
                    break;
                case "model_name":
                    this.model_name = value;
                    break;
                case "effect_date":
                    this.effect_date = value;
                    break;
                case "expire_date":
                    this.expire_date = value;
                    break;
                case "edit_staff":
                    this.edit_staff = value;
                    break;
                case "edit_man":
                    this.edit_man = value;
                    break;
                case "valid_flag":
                    this.valid_flag = value;
                    break;
                case "audit_flag":
                    this.audit_flag = value;
                    break;
                default:
                    break;
            }
        }
    }
}