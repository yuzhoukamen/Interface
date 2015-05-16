using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HosDirManage
{
    public class GetHospitalDirMatchedInfo : BaseHN
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public GetHospitalDirMatchedInfo(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 根据查询条件，取药品和诊疗项目目录匹配审核通过信息。
        /// </summary>
        /// <param name="center_id"></param>
        /// <param name="type"></param>
        /// <param name="condition"></param>
        /// <param name="once_find"></param>
        /// <param name="first_row"></param>
        /// <param name="last_row"></param>
        /// <param name="first_version_id"></param>
        /// <param name="last_version_id"></param>
        /// <returns></returns>
        public MatchedOutParameter GetHospitalDirMatchedPageInfo(string center_id, string type,
            string condition, string once_find, string first_row, string last_row,
            string first_version_id, string last_version_id)
        {
            Interface inter = new Interface(this.InterfaceHN);

            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("center_id", center_id));
            listParameter.Add(new Parameter("type", type));
            listParameter.Add(new Parameter("condition", condition));
            listParameter.Add(new Parameter("once_find", once_find));
            listParameter.Add(new Parameter("first_row", first_row));
            listParameter.Add(new Parameter("last_row", last_row));
            listParameter.Add(new Parameter("first_version_id", first_version_id));
            listParameter.Add(new Parameter("last_version_id", last_version_id));

            if (0 > inter.ExecInterface("BIZC110118", listParameter))
            {
                throw new Exception("取医院目录审核通过匹配信息发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteMatchedOutparameter(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private MatchedOutParameter WriteMatchedOutparameter(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                MatchedOutParameter matchedOutParameter = new MatchedOutParameter();

                List<MatchedPageInfo> list = new List<MatchedPageInfo>();

                string str = string.Empty;

                do
                {
                    MatchedPageInfo matchedPageInfo = new MatchedPageInfo();

                    str = string.Empty;
                    inter.GetByName("serial_match", ref str);
                    matchedPageInfo.serial_match = str;

                    str = string.Empty;
                    inter.GetByName("match_type", ref str);
                    matchedPageInfo.match_type = str;

                    str = string.Empty;
                    inter.GetByName("item_code", ref str);
                    matchedPageInfo.item_code = str;

                    str = string.Empty;
                    inter.GetByName("item_name", ref str);
                    matchedPageInfo.item_name = str;

                    str = string.Empty;
                    inter.GetByName("model", ref str);
                    matchedPageInfo.model = str;

                    str = string.Empty;
                    inter.GetByName("hospital_id", ref str);
                    matchedPageInfo.hospital_id = str;

                    str = string.Empty;
                    inter.GetByName("hosp_code", ref str);
                    matchedPageInfo.hosp_code = str;

                    str = string.Empty;
                    inter.GetByName("hosp_name", ref str);
                    matchedPageInfo.hosp_name = str;

                    str = string.Empty;
                    inter.GetByName("hosp_model", ref str);
                    matchedPageInfo.hosp_model = str;

                    str = string.Empty;
                    inter.GetByName("hosp_standard", ref str);
                    matchedPageInfo.hosp_standard = str;

                    str = string.Empty;
                    inter.GetByName("hosp_price", ref str);
                    matchedPageInfo.hosp_price = str;

                    str = string.Empty;
                    inter.GetByName("staple_flag", ref str);
                    matchedPageInfo.staple_flag = str;

                    str = string.Empty;
                    inter.GetByName("effect_date", ref str);
                    matchedPageInfo.effect_date = str;

                    str = string.Empty;
                    inter.GetByName("expire_date", ref str);
                    matchedPageInfo.expire_date = str;

                    str = string.Empty;
                    inter.GetByName("audit_flag", ref str);
                    matchedPageInfo.audit_flag = str;

                    list.Add(matchedPageInfo);
                } while (0 < inter.NextRow());

                return matchedOutParameter;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }
    }
}