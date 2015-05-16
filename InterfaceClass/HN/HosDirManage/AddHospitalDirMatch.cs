using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HosDirManage
{
    /// <summary>
    /// 新增医院目录匹配
    /// </summary>
    public class AddHospitalDirMatch : BaseHN
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public AddHospitalDirMatch(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listInsertInfo"></param>
        public List<Effectdetail> AddHISMatchToCenter(List<InsertInfo> listInsertInfo)
        {
            List<Parameter> listInsertInfoParameter = new List<Parameter>();

            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            Interface inter = new Interface(this.InterfaceHN);

            foreach (InsertInfo insertInfo in listInsertInfo)
            {
                List<Parameter> listParameter = GetProperties<InsertInfo>(insertInfo);

                listListParameter.Add(listParameter);
            }

            Parameter pInsertInfo = new Parameter();

            pInsertInfo.Name = "insertinfo";
            pInsertInfo.Object = listListParameter;

            listInsertInfoParameter.Add(pInsertInfo);

            if (0 != inter.ExecInterface("BIZC110201", null, listInsertInfoParameter))
            {
                throw new Exception("新增医院目录匹配到中心发生错误，错误原因：" + inter.GetMessage());
            }

            return AddHISMatchToCenterOutParameter(inter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<Effectdetail> AddHISMatchToCenterOutParameter(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                List<Effectdetail> listEffectdetail = new List<Effectdetail>();

                inter.SetResultset("effectdetail");

                string str = string.Empty;

                do
                {
                    Effectdetail effectdetail = new Effectdetail();

                    str = string.Empty;
                    inter.GetByName("serial_match", ref str);
                    effectdetail.serial_match = str;

                    str = string.Empty;
                    inter.GetByName("hosp_code", ref str);
                    effectdetail.hosp_code = str;

                    listEffectdetail.Add(effectdetail);

                } while (0 < inter.NextRow());

                return listEffectdetail;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }
    }
}