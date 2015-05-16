using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.BusCostInfo.AllOrders
{
    /// <summary>
    /// 提取所有的业务信息的入参
    /// </summary>
    public class GetAllOrdersParameters
    {
        #region 属性
        [Description("中心编码")]
        public string center_id { get; set; }

        [Description("查询起始时间")]
        public string from_date { get; set; }

        [Description("查询终止时间")]
        public string to_date { get; set; }

        [Description("业务类型")]
        public string biz_type { get; set; }

        [Description("中心查询标志")]
        public string center_flag { get; set; }

        [Description("结算标志")]
        public string fin_flag { get; set; }

        [Description("执行标志")]
        public string exec_flag { get; set; }

        [Description("查询方式")]
        public string query_type { get; set; }

        [Description("医院编码")]
        public string hospital_id { get; set; }

        [Description("疾病编码")]
        public string in_disease { get; set; }

        [Description("人员类别")]
        public string pers_type { get; set; }

        [Description("单位名称")]
        public string corp_name { get; set; }

        [Description("参数值")]
        public string arg_value { get; set; }

        [Description("参数名")]
        public string arg_name { get; set; }

        [Description("结束标志")]
        public string in_flag { get; set; }

        [Description("出院标志")]
        public string outhosp_flag { get; set; }

        [Description("零报标志")]
        public string reimburse_flag { get; set; }

        [Description("待遇类别")]
        public string treatment_type { get; set; }

        [Description("疾病编码")]
        public string disease { get; set; }

        [Description("抢救费用")]
        public string first_aid { get; set; }

        [Description("单页行数")]
        public string viewrows { get; set; }

        [Description("页数")]
        public string page { get; set; }

        [Description("信息总数")]
        public string query_row_sum { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "center_id":
                    this.center_id = value;
                    break;
                case "from_date":
                    this.from_date = value;
                    break;
                case "to_date":
                    this.to_date = value;
                    break;
                case "biz_type":
                    this.biz_type = value;
                    break;
                case "center_flag":
                    this.center_flag = value;
                    break;
                case "fin_flag":
                    this.fin_flag = value;
                    break;
                case "exec_flag":
                    this.exec_flag = value;
                    break;
                case "query_type":
                    this.query_type = value;
                    break;
                case "hospital_id":
                    this.hospital_id = value;
                    break;
                case "in_disease":
                    this.in_disease = value;
                    break;
                case "pers_type":
                    this.pers_type = value;
                    break;
                case "corp_name":
                    this.corp_name = value;
                    break;
                case "arg_value":
                    this.arg_value = value;
                    break;
                case "arg_name":
                    this.arg_name = value;
                    break;
                case "in_flag":
                    this.in_flag = value;
                    break;
                case "outhosp_flag":
                    this.outhosp_flag = value;
                    break;
                case "reimburse_flag":
                    this.reimburse_flag = value;
                    break;
                case "treatment_type":
                    this.treatment_type = value;
                    break;
                case "disease":
                    this.disease = value;
                    break;
                case "first_aid":
                    this.first_aid = value;
                    break;
                case "viewrows":
                    this.viewrows = value;
                    break;
                case "page":
                    this.page = value;
                    break;
                case "query_row_sum":
                    this.query_row_sum = value;
                    break;
                default:
                    break;
            }
        }
    }
}