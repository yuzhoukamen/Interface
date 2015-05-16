using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 通过个人标识取人员信息
    /// </summary>
    public class GetPersonInfoByFlag : BaseHN
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public GetPersonInfoByFlag(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 通过参保人电脑号
        /// </summary>
        /// <param name="indi_id">个人电脑号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public List<PersonInfo> GetPersonInfoByindi_id(string indi_id, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("indi_id", indi_id));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfo(listPara);
        }

        /// <summary>
        /// 通过参保人的姓名
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public List<PersonInfo> GetPersonInfoByname(string name, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("name", name));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfo(listPara);
        }

        /// <summary>
        /// 通过参保人的公民身份号码
        /// </summary>
        /// <param name="idcard">公民身份号码</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public List<PersonInfo> GetPersonInfoByidcard(string idcard, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("idcard", idcard));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfo(listPara);
        }

        /// <summary>
        /// 通过参保人的IC卡号
        /// </summary>
        /// <param name="iccardno">IC卡号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public List<PersonInfo> GetPersonInfoByiccardno(string iccardno, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("iccardno", iccardno));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfo(listPara);
        }

        /// <summary>
        /// 通过参保人的保险号
        /// </summary>
        /// <param name="insr_code">保险号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public List<PersonInfo> GetPersonInfoByinsr_code(string insr_code, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("insr_code", insr_code));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfo(listPara);
        }

        /// <summary>
        /// 获取病人的个人基本信息
        /// </summary>
        /// <param name="listPara">参数列表</param>
        /// <returns>获取病人的个人基本信息</returns>
        public List<PersonInfo> GetPersonInfo(List<Parameter> listPara)
        {
            Interface inter = new Interface(this.InterfaceHN);
            List<PersonInfo> list = new List<PersonInfo>();

            long value = inter.ExecInterface("BIZC131101", listPara);
            string errorInfo = inter.GetMessage();

            if (0 > value)
            {
                throw new Exception("通过个人标识（电脑号、姓名、公民身份号、IC卡号）取参保人信息失败，失败原因：" + inter.GetMessage());
            }

            inter.SetResultset("personinfo");

            string str = string.Empty;
            try
            {

                do
                {
                    PersonInfo personInfo = new PersonInfo();

                    str = string.Empty;
                    inter.GetByName("indi_id", ref str);
                    personInfo.indi_id = str;

                    str = string.Empty;
                    inter.GetByName("center_id", ref str);
                    personInfo.center_id = str;

                    str = string.Empty;
                    inter.GetByName("center_name", ref str);
                    personInfo.center_name = str;

                    str = string.Empty;
                    inter.GetByName("name", ref str);
                    personInfo.name = str;

                    str = string.Empty;
                    inter.GetByName("sex", ref str);
                    personInfo.sex = str;

                    str = string.Empty;
                    inter.GetByName("pers_type", ref str);
                    personInfo.pers_type = str;

                    str = string.Empty;
                    inter.GetByName("pers_name", ref str);
                    personInfo.pers_name = str;

                    str = string.Empty;
                    inter.GetByName("indi_join_sta", ref str);
                    personInfo.indi_join_sta = str;

                    str = string.Empty;
                    inter.GetByName("indi_sta_name", ref str);
                    personInfo.indi_sta_name = str;

                    str = string.Empty;
                    inter.GetByName("official_code", ref str);
                    personInfo.official_code = str;

                    str = string.Empty;
                    inter.GetByName("official_name", ref str);
                    personInfo.official_name = str;

                    str = string.Empty;
                    inter.GetByName("hire_type", ref str);
                    personInfo.hire_type = str;

                    str = string.Empty;
                    inter.GetByName("hire_name", ref str);
                    personInfo.hire_name = str;

                    str = string.Empty;
                    inter.GetByName("idcard", ref str);
                    personInfo.idcard = str;

                    str = string.Empty;
                    inter.GetByName("insr_code", ref str);
                    personInfo.insr_code = str;

                    str = string.Empty;
                    inter.GetByName("telephone", ref str);
                    personInfo.telephone = str;

                    str = string.Empty;
                    inter.GetByName("birthday", ref str);
                    personInfo.birthday = str;

                    str = string.Empty;
                    inter.GetByName("post_code", ref str);
                    personInfo.post_code = str;

                    str = string.Empty;
                    inter.GetByName("corp_id", ref str);
                    personInfo.corp_id = str;

                    str = string.Empty;
                    inter.GetByName("corp_name", ref str);
                    personInfo.corp_name = str;

                    str = string.Empty;
                    inter.GetByName("freeze_sta", ref str);
                    personInfo.freeze_sta = str;

                    str = string.Empty;
                    inter.GetByName("last_balance", ref str);
                    personInfo.last_balance = str;

                    list.Add(personInfo);

                } while (0 < inter.NextRow());

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// 通过参保人电脑号
        /// </summary>
        /// <param name="indi_id">个人电脑号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人详细信息</returns>
        public PersonInfoDetail GetPersonInfoDetailByindi_id(string indi_id, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("indi_id", indi_id));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfoDetail(listPara);
        }

        /// <summary>
        /// 通过参保人的姓名
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public PersonInfoDetail GetPersonInfoDetailByname(string name, string hospital_id, string biz_type, string center_id)
        {

            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("name", name));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfoDetail(listPara);
        }

        /// <summary>
        /// 通过参保人的公民身份号码
        /// </summary>
        /// <param name="idcard">公民身份号码</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public PersonInfoDetail GetPersonInfoDetailByidcard(string idcard, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("idcard", idcard));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfoDetail(listPara);
        }

        /// <summary>
        /// 通过参保人的IC卡号
        /// </summary>
        /// <param name="iccardno">IC卡号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public PersonInfoDetail GetPersonInfoDetailByiccardno(string iccardno, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("iccardno", iccardno));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfoDetail(listPara);
        }

        /// <summary>
        /// 通过参保人的保险号
        /// </summary>
        /// <param name="insr_code">保险号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <param name="center_id">医保中心编号</param>
        /// <returns>获取病人的个人基本信息</returns>
        public PersonInfoDetail GetPersonInfoDetailByinsr_code(string insr_code, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("insr_code", insr_code));
            listPara.Add(new Parameter("hospital_id", hospital_id));
            listPara.Add(new Parameter("biz_type", biz_type));
            listPara.Add(new Parameter("center_id", center_id));

            return GetPersonInfoDetail(listPara);
        }

        /// <summary>
        /// 获取病人的个人基本信息
        /// </summary>
        /// <param name="listPara">参数列表</param>
        /// <returns>获取病人的个人基本信息</returns>
        public PersonInfoDetail GetPersonInfoDetail(List<Parameter> listPara)
        {
            Interface inter = new Interface(this.InterfaceHN);
            PersonInfoDetail personInfoDetail = new PersonInfoDetail();

            long value = inter.ExecInterface("BIZC131101", listPara);

            if (0 > value)
            {
                throw new Exception("通过个人标识（电脑号、姓名、公民身份号、IC卡号）取参保人详细信息失败，失败原因：" + inter.GetMessage());
            }

            personInfoDetail.ListPersonInfo = GetInterfacePersonInfo("personinfo", inter);

            if (personInfoDetail.ListPersonInfo.Count == 1)
            {
                personInfoDetail.ListFreezeinfo = GetInterfaceFreezeInfo("freezeinfo", inter);
                personInfoDetail.TotalbizInfo = GetInterfaceTotalbizInfo("totalbizinfo", inter);
            }

            return personInfoDetail;
        }

        /// <summary>
        /// 从接口获取个人业务累计信息
        /// </summary>
        /// <param name="datasetName"></param>
        /// <param name="inter"></param>
        /// <returns></returns>
        private TotalbizInfo GetInterfaceTotalbizInfo(string datasetName, Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                TotalbizInfo totalbizInfo = new TotalbizInfo();

                string str = string.Empty;

                inter.SetResultset(datasetName);

                str = string.Empty;
                inter.GetByName("biz_year", ref str);
                totalbizInfo.biz_year = str;

                str = string.Empty;
                inter.GetByName("drug_year", ref str);
                totalbizInfo.drug_year = str;

                str = string.Empty;
                inter.GetByName("diag_year", ref str);
                totalbizInfo.diag_year = str;

                str = string.Empty;
                inter.GetByName("inhosp_year", ref str);
                totalbizInfo.inhosp_year = str;

                str = string.Empty;
                inter.GetByName("special_year", ref str);
                totalbizInfo.special_year = str;

                str = string.Empty;
                inter.GetByName("fee_year", ref str);
                totalbizInfo.fee_year = str;

                str = string.Empty;
                inter.GetByName("fund_year", ref str);
                totalbizInfo.fund_year = str;

                str = string.Empty;
                inter.GetByName("acct_year", ref str);
                totalbizInfo.acct_year = str;

                str = string.Empty;
                inter.GetByName("additional_year", ref str);
                totalbizInfo.additional_year = str;

                str = string.Empty;
                inter.GetByName("retire_year", ref str);
                totalbizInfo.retire_year = str;

                str = string.Empty;
                inter.GetByName("official_year", ref str);
                totalbizInfo.official_year = str;

                str = string.Empty;
                inter.GetByName("qfx_year", ref str);
                totalbizInfo.qfx_year = str;

                str = string.Empty;
                inter.GetByName("declare_year", ref str);
                totalbizInfo.declare_year = str;

                return totalbizInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// 从接口获取个人基金冻结信息
        /// </summary>
        /// <param name="datasetName"></param>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<FreezeInfo> GetInterfaceFreezeInfo(string datasetName, Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                List<FreezeInfo> list = new List<FreezeInfo>();

                inter.SetResultset(datasetName);
                string str = string.Empty;

                do
                {
                    FreezeInfo freezeInfo = new FreezeInfo();

                    str = string.Empty;
                    inter.GetByName("fund_id", ref str);
                    freezeInfo.fund_id = str;

                    str = string.Empty;
                    inter.GetByName("fund_name", ref str);
                    freezeInfo.fund_name = str;

                    str = string.Empty;
                    inter.GetByName("indi_freeze_status", ref str);
                    freezeInfo.indi_freeze_status = str;

                    list.Add(freezeInfo);
                }
                while (0 < inter.NextRow());

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// 从接口获取人员信息
        /// </summary>
        /// <param name="datasetName"></param>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<PersonInfo> GetInterfacePersonInfo(string datasetName, Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                List<PersonInfo> list = new List<PersonInfo>();

                inter.SetResultset(datasetName);

                string str = string.Empty;

                long rowTotalCount = inter.GetRowCount();

                do
                {
                    PersonInfo personInfo = new PersonInfo();

                    str = string.Empty;
                    inter.GetByName("indi_id", ref str);
                    personInfo.indi_id = str;

                    str = string.Empty;
                    inter.GetByName("center_id", ref str);
                    personInfo.center_id = str;

                    str = string.Empty;
                    inter.GetByName("center_name", ref str);
                    personInfo.center_name = str;

                    str = string.Empty;
                    inter.GetByName("name", ref str);
                    personInfo.name = str;

                    str = string.Empty;
                    inter.GetByName("sex", ref str);
                    personInfo.sex = str;

                    str = string.Empty;
                    inter.GetByName("pers_type", ref str);
                    personInfo.pers_type = str;

                    str = string.Empty;
                    inter.GetByName("pers_name", ref str);
                    personInfo.pers_name = str;

                    str = string.Empty;
                    inter.GetByName("indi_join_sta", ref str);
                    personInfo.indi_join_sta = str;

                    str = string.Empty;
                    inter.GetByName("indi_sta_name", ref str);
                    personInfo.indi_sta_name = str;

                    str = string.Empty;
                    inter.GetByName("official_code", ref str);
                    personInfo.official_code = str;

                    str = string.Empty;
                    inter.GetByName("official_name", ref str);
                    personInfo.official_name = str;

                    str = string.Empty;
                    inter.GetByName("hire_type", ref str);
                    personInfo.hire_type = str;

                    str = string.Empty;
                    inter.GetByName("hire_name", ref str);
                    personInfo.hire_name = str;

                    str = string.Empty;
                    inter.GetByName("idcard", ref str);
                    personInfo.idcard = str;

                    str = string.Empty;
                    inter.GetByName("insr_code", ref str);
                    personInfo.insr_code = str;

                    str = string.Empty;
                    inter.GetByName("telephone", ref str);
                    personInfo.telephone = str;

                    str = string.Empty;
                    inter.GetByName("birthday", ref str);
                    personInfo.birthday = str;

                    str = string.Empty;
                    inter.GetByName("post_code", ref str);
                    personInfo.post_code = str;

                    str = string.Empty;
                    inter.GetByName("corp_id", ref str);
                    personInfo.corp_id = str;

                    str = string.Empty;
                    inter.GetByName("corp_name", ref str);
                    personInfo.corp_name = str;

                    str = string.Empty;
                    inter.GetByName("freeze_sta", ref str);
                    personInfo.freeze_sta = str;

                    str = string.Empty;
                    inter.GetByName("last_balance", ref str);
                    personInfo.last_balance = str;

                    list.Add(personInfo);

                } while (0 < inter.NextRow());

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }
    }

    /// <summary>
    /// 获取人员信息列表
    /// </summary>
    public class PersonInfoDetail
    {
        public List<PersonInfo> ListPersonInfo { get; set; }
        public List<FreezeInfo> ListFreezeinfo { get; set; }
        public TotalbizInfo TotalbizInfo { get; set; }

        public PersonInfoDetail() { }

        public PersonInfoDetail(List<PersonInfo> listPersonInfo, List<FreezeInfo> listFreezeInfo, TotalbizInfo totalbizInfo)
        {
            this.ListPersonInfo = listPersonInfo;
            this.ListFreezeinfo = listFreezeInfo;
            this.TotalbizInfo = totalbizInfo;
        }
    }
}