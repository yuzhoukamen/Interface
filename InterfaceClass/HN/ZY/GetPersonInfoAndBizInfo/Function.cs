using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo
{
    /// <summary>
    /// 通过就医登记号或个人标识提取病人个人信息、业务信息 (BIZC131251)
    /// </summary>
    public class Function : BaseHN
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public Function(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 通过就医登记号提取病人个人信息、业务信息 (BIZC131251)
        /// </summary>
        /// <param name="serial_no">就医登记号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <returns>个人基本信息、住院业务信息</returns>
        public BizInfo GetPersonInfoAndInHospitalBizInfoBy_serial_no(string serial_no, string hospital_id, string biz_type)
        {
            string info = string.Empty;

            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("serial_no", serial_no));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));

            return GetPersonInfoAndInHospitalBizInfo(listParameter, "就医登记号");
        }

        /// <summary>
        /// 通过个人电脑号提取病人个人信息、业务信息 (BIZC131251)
        /// </summary>
        /// <param name="indi_id">个人电脑号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <returns>个人基本信息、住院业务信息</returns>
        public BizInfo GetPersonInfoAndInHospitalBizInfoBy_indi_id(string indi_id, string hospital_id, string biz_type)
        {
            string info = string.Empty;

            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("indi_id", indi_id));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));

            return GetPersonInfoAndInHospitalBizInfo(listParameter, "个人电脑号");
        }

        /// <summary>
        /// 通过姓名提取病人个人信息、业务信息 (BIZC131251)
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <returns>个人基本信息、住院业务信息</returns>
        public BizInfo GetPersonInfoAndInHospitalBizInfoBy_name(string name, string hospital_id, string biz_type)
        {
            string info = string.Empty;

            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("name", name));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));

            return GetPersonInfoAndInHospitalBizInfo(listParameter, "姓名");
        }

        /// <summary>
        /// 通过公民身份号码提取病人个人信息、业务信息 (BIZC131251)
        /// </summary>
        /// <param name="idcard">公民身份号码</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <returns>个人基本信息、住院业务信息</returns>
        public BizInfo GetPersonInfoAndInHospitalBizInfoBy_idcard(string idcard, string hospital_id, string biz_type)
        {
            string info = string.Empty;

            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("idcard", idcard));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));

            return GetPersonInfoAndInHospitalBizInfo(listParameter, "公民身份号码");
        }

        /// <summary>
        /// 通过IC卡号提取病人个人信息、业务信息 (BIZC131251)
        /// </summary>
        /// <param name="ic_no">IC卡号</param>
        /// <param name="hospital_id">医疗机构编码</param>
        /// <param name="biz_type">业务类型</param>
        /// <returns>个人基本信息、住院业务信息</returns>
        public BizInfo GetPersonInfoAndInHospitalBizInfoBy_ic_no(string ic_no, string hospital_id, string biz_type)
        {
            string info = string.Empty;

            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("ic_no", ic_no));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));

            return GetPersonInfoAndInHospitalBizInfo(listParameter, "IC卡号");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listParameter"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public BizInfo GetPersonInfoAndInHospitalBizInfo(List<Parameter> listParameter, string info)
        {
            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131251", listParameter);

            if (0 > value)
            {
                throw new Exception("通过" + info + "提取病人个人信息、业务信息 (BIZC131251)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteBizInfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private BizInfo WriteBizInfo(Interface inter)
        {
            List<Parameter> listParameter = GetProperties<BizInfo>(new BizInfo());

            string errorInfo = inter.GetMessage();

            try
            {
                inter.SetResultset("bizinfo");

                BizInfo bizInfo = new BizInfo();

                string str = string.Empty;

                foreach (Parameter p in listParameter)
                {
                    str = string.Empty;

                    inter.GetByName(p.Name, ref str);

                    bizInfo.SetAttributeValue(p.Name, str);
                }

                return bizInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }
    }
}