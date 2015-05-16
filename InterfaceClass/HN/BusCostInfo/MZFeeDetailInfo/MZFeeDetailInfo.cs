using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.BusCostInfo.MZFeeDetailInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class MZFeeDetailInfo : BaseHN
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceHN"></param>
        public MZFeeDetailInfo(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 获取提取明细费用信息(BIZC200301)
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public List<Info> GetMZFeeDetailInfo(InParameters parameter)
        {
            List<Parameter> listMainParameter = GetProperties<InParameters>(parameter);

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC200301", listMainParameter);

            if (0 > value)
            {
                throw new Exception("提取明细费用信息(BIZC200301)失败，失败原因：" + inter.GetMessage());
            }

            return WriteInfo(inter);
        }

        /// <summary>
        /// 获取提取明细费用信息(BIZC200301)
        /// </summary>
        /// <param name="hospital_id"></param>
        /// <param name="serial_no"></param>
        /// <param name="exec_flag"></param>
        /// <param name="center_flag"></param>
        /// <param name="stat_type"></param>
        /// <returns></returns>
        public List<Info> GetMZFeeDetailInfo(string hospital_id, string serial_no, string exec_flag, string center_flag, string stat_type)
        {
            InParameters parameter = new InParameters();

            parameter.hospital_id = hospital_id;
            parameter.serial_no = serial_no;
            parameter.exec_flag = exec_flag;
            parameter.center_flag = center_flag;
            parameter.stat_type = stat_type;

            return GetMZFeeDetailInfo(parameter);
        }

        /// <summary>
        /// 写信息
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<Info> WriteInfo(Interface inter)
        {
            List<Info> listInfo = new List<Info>();
            string errorInfo = inter.GetMessage();

            try
            {
                inter.SetResultset("info");

                string str = string.Empty;

                do
                {
                    Info info = new Info();

                    List<Parameter> listParameter = GetProperties<Info>(info);

                    foreach (Parameter p in listParameter)
                    {
                        str = string.Empty;
                        inter.GetByName(p.Name, ref str);
                        info.SetAttributeValue(p.Name, str);
                    }

                    listInfo.Add(info);
                } while (0 < inter.NextRow());

                return listInfo;
            }
            catch (Exception ex)
            {
                //throw new Exception(errorInfo + "\n" + ex.Message);
            }

            return listInfo;
        }
    }
}