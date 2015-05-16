using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InterfaceClass.HN.ZY.GetPersonInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class PersonInfo
    {
        #region 属性

        [Description("个人电脑号")]
        public string indi_id { get; set; }

        [Description("分级统筹中心编码")]
        public string center_id { get; set; }

        [Description("分级统筹中心名称")]
        public string center_name { get; set; }

        [Description("姓名")]
        public string name { get; set; }

        [Description("性别")]
        public string sex { get; set; }

        [Description("人员类别编码")]
        public string pers_type { get; set; }

        [Description("人员类别名称")]
        public string pers_name { get; set; }

        [Description("人员状态编码")]
        public string indi_join_sta { get; set; }

        [Description("人员状态名称")]
        public string indi_sta_name { get; set; }

        [Description("公务员级别编码")]
        public string official_code { get; set; }

        [Description("公务员级别名称")]
        public string official_name { get; set; }

        [Description("用工形式编码")]
        public string hire_type { get; set; }

        [Description("用工形式名称")]
        public string hire_name { get; set; }

        [Description("公民身份号码")]
        public string idcard { get; set; }

        [Description("社会保障号码")]
        public string insr_code { get; set; }

        [Description("联系电话")]
        public string telephone { get; set; }

        [Description("出生日期")]
        public string birthday { get; set; }

        [Description("地区编码")]
        public string post_code { get; set; }

        [Description("单位编码")]
        public string corp_id { get; set; }

        [Description("单位名称")]
        public string corp_name { get; set; }

        [Description("基金冻结状态")]
        public string freeze_sta { get; set; }

        [Description("个人帐户余额")]
        public string last_balance { get; set; }

        #endregion

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public void SetAttributeValue(string name, string value)
        {
            switch (name)
            {
                case "indi_id"://个人电脑号
                    this.indi_id = value;
                    break;
                case "center_id"://分级统筹中心编码
                    this.center_id = value;
                    break;
                case "center_name"://分级统筹中心名称
                    this.center_name = value;
                    break;
                case "name"://姓名
                    this.name = value;
                    break;
                case "sex"://性别
                    this.sex = value;
                    break;
                case "pers_type"://人员类别编码
                    this.pers_type = value;
                    break;
                case "pers_name"://人员类别名称
                    this.pers_name = value;
                    break;
                case "indi_join_sta"://人员状态编码
                    this.indi_join_sta = value;
                    break;
                case "indi_sta_name"://人员状态名称
                    this.indi_sta_name = value;
                    break;
                case "official_code"://公务员级别编码
                    this.official_code = value;
                    break;
                case "official_name"://公务员级别名称
                    this.official_name = value;
                    break;
                case "hire_type"://用工形式编码
                    this.hire_type = value;
                    break;
                case "hire_name"://用工形式名称
                    this.hire_name = value;
                    break;
                case "idcard"://公民身份号码
                    this.idcard = value;
                    break;
                case "insr_code"://社会保障号码
                    this.insr_code = value;
                    break;
                case "telephone"://联系电话
                    this.telephone = value;
                    break;
                case "birthday"://出生日期
                    this.birthday = value;
                    break;
                case "post_code"://地区编码
                    this.post_code = value;
                    break;
                case "corp_id"://单位编码
                    this.corp_id = value;
                    break;
                case "corp_name"://单位名称
                    this.corp_name = value;
                    break;
                case "freeze_sta"://基金冻结状态
                    this.freeze_sta = value;
                    break;
                case "last_balance"://个人帐户余额
                    this.last_balance = value;
                    break;
                default:
                    break;
            }
        }
    }
}