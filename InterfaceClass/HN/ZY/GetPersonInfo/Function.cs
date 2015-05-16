using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.GetPersonInfo
{
    /// <summary>
    /// 通过个人标识取人员信息(BIZC131201)
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
        /// 通过个人电脑号取人员信息
        /// </summary>
        /// <param name="indi_id"></param>
        /// <param name="hospital_id"></param>
        /// <param name="biz_type"></param>
        /// <param name="center_id"></param>
        /// <returns></returns>
        public PersonInfo GetPersonInfoBy_indi_id(string indi_id, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("indi_id", indi_id));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));
            listParameter.Add(new Parameter("center_id", center_id));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131201", listParameter);

            if (0 > value)
            {
                throw new Exception("通过个人电脑号取人员信息(BIZC131201)发生错误，错误原因：" + inter.GetMessage());
            }

            return WritePersonInfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indi_id"></param>
        /// <param name="hospital_id"></param>
        /// <param name="biz_type"></param>
        /// <param name="center_id"></param>
        /// <returns></returns>
        public Elseinfo GetElseinfoBy_indi_id(string indi_id, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("indi_id", indi_id));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));
            listParameter.Add(new Parameter("center_id", center_id));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131201", listParameter);

            if (0 > value)
            {
                throw new Exception("通过个人电脑号取人员信息(BIZC131201)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteElseinfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indi_id"></param>
        /// <param name="hospital_id"></param>
        /// <param name="biz_type"></param>
        /// <param name="center_id"></param>
        /// <returns></returns>
        public List<FreezeInfo> GetFreezeInfoBy_indi_id(string indi_id, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("indi_id", indi_id));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));
            listParameter.Add(new Parameter("center_id", center_id));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131201", listParameter);

            if (0 > value)
            {
                throw new Exception("通过个人电脑号取人员信息(BIZC131201)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteFreezeInfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indi_id"></param>
        /// <param name="hospital_id"></param>
        /// <param name="biz_type"></param>
        /// <param name="center_id"></param>
        /// <returns></returns>
        public Lastbizinfo GetLastbizinfoBy_indi_id(string indi_id, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("indi_id", indi_id));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));
            listParameter.Add(new Parameter("center_id", center_id));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131201", listParameter);

            if (0 > value)
            {
                throw new Exception("通过个人电脑号取人员信息(BIZC131201)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteLastbizinfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indi_id"></param>
        /// <param name="hospital_id"></param>
        /// <param name="biz_type"></param>
        /// <param name="center_id"></param>
        /// <returns></returns>
        public List<SPInfo> GetSPInfoBy_indi_id(string indi_id, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("indi_id", indi_id));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));
            listParameter.Add(new Parameter("center_id", center_id));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131201", listParameter);

            if (0 > value)
            {
                throw new Exception("通过个人电脑号取人员信息(BIZC131201)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteSPInfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indi_id"></param>
        /// <param name="hospital_id"></param>
        /// <param name="biz_type"></param>
        /// <param name="center_id"></param>
        /// <returns></returns>
        public Totalbizinfo GetTotalbizinfoBy_indi_id(string indi_id, string hospital_id, string biz_type, string center_id)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("indi_id", indi_id));
            listParameter.Add(new Parameter("hospital_id", hospital_id));
            listParameter.Add(new Parameter("biz_type", biz_type));
            listParameter.Add(new Parameter("center_id", center_id));

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC131201", listParameter);

            if (0 > value)
            {
                throw new Exception("通过个人电脑号取人员信息(BIZC131201)发生错误，错误原因：" + inter.GetMessage());
            }

            return WriteTotalbizinfo(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private PersonInfo WritePersonInfo(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            inter.SetResultset("personinfo");

            try
            {
                PersonInfo personInfo = new PersonInfo();
                string str = string.Empty;

                List<Parameter> listParameter = GetProperties<PersonInfo>(personInfo);

                foreach (Parameter p in listParameter)
                {
                    str = string.Empty;

                    inter.GetByName(p.Name, ref str);
                    personInfo.SetAttributeValue(p.Name, str);
                }

                return personInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private Elseinfo WriteElseinfo(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            inter.SetResultset("elseinfo");

            try
            {
                Elseinfo elseInfo = new Elseinfo();
                string str = string.Empty;

                List<Parameter> listParameter = GetProperties<Elseinfo>(elseInfo);

                foreach (Parameter p in listParameter)
                {
                    str = string.Empty;

                    inter.GetByName(p.Name, ref str);
                    elseInfo.SetAttributeValue(p.Name, str);
                }

                return elseInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<SPInfo> WriteSPInfo(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            inter.SetResultset("spinfo");

            List<SPInfo> listSPInfo = new List<SPInfo>();

            try
            {
                do
                {
                    SPInfo spInfo = new SPInfo();
                    string str = string.Empty;

                    List<Parameter> listParameter = GetProperties<SPInfo>(spInfo);

                    foreach (Parameter p in listParameter)
                    {
                        str = string.Empty;

                        inter.GetByName(p.Name, ref str);
                        spInfo.SetAttributeValue(p.Name, str);
                    }

                    listSPInfo.Add(spInfo);
                } while (0 < inter.NextRow());

                return listSPInfo;
            }
            catch (Exception ex)
            {
                return listSPInfo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<FreezeInfo> WriteFreezeInfo(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            inter.SetResultset("freezeinfo");

            List<FreezeInfo> listFreezeInfo = new List<FreezeInfo>();

            try
            {
                do
                {
                    FreezeInfo freezeInfo = new FreezeInfo();
                    string str = string.Empty;

                    List<Parameter> listParameter = GetProperties<FreezeInfo>(freezeInfo);

                    foreach (Parameter p in listParameter)
                    {
                        str = string.Empty;

                        inter.GetByName(p.Name, ref str);
                        freezeInfo.SetAttributeValue(p.Name, str);
                    }

                    listFreezeInfo.Add(freezeInfo);
                } while (0 < inter.NextRow());

                return listFreezeInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private Lastbizinfo WriteLastbizinfo(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            inter.SetResultset("lastbizinfo");

            try
            {
                Lastbizinfo lastBizInfo = new Lastbizinfo();
                string str = string.Empty;

                List<Parameter> listParameter = GetProperties<Lastbizinfo>(lastBizInfo);

                foreach (Parameter p in listParameter)
                {
                    str = string.Empty;

                    inter.GetByName(p.Name, ref str);
                    lastBizInfo.SetAttributeValue(p.Name, str);
                }

                return lastBizInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private Totalbizinfo WriteTotalbizinfo(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            inter.SetResultset("totalbizinfo");

            try
            {
                Totalbizinfo totalbizinfo = new Totalbizinfo();
                string str = string.Empty;

                List<Parameter> listParameter = GetProperties<Totalbizinfo>(totalbizinfo);

                foreach (Parameter p in listParameter)
                {
                    str = string.Empty;

                    inter.GetByName(p.Name, ref str);
                    totalbizinfo.SetAttributeValue(p.Name, str);
                }

                return totalbizinfo;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }
    }
}