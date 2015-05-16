using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.BusCostInfo.AllOrders
{
    /// <summary>
    /// 提取所有的业务信息
    /// </summary>
    public class AllOrders : BaseHN
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceHN"></param>
        public AllOrders(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<Info> GetAllOrders(GetAllOrdersParameters parameter)
        {
            List<Info> listInfo = new List<Info>();
            List<Parameter> listMainParameter = GetProperties<GetAllOrdersParameters>(parameter);

            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC200301", listMainParameter);

            if (0 > value)
            {
                throw new Exception("从中心服务器提取所有的业务信息失败，失败原因：" + inter.GetMessage());
            }

            return WriteAllOrders(inter);
        }

        /// <summary>
        /// 写所有业务信息
        /// </summary>
        /// <param name="inter"></param>
        /// <returns></returns>
        private List<Info> WriteAllOrders(Interface inter)
        {
            string errorInfo = inter.GetMessage();

            try
            {
                List<Info> listInfo = new List<Info>();

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
                throw new Exception(errorInfo + "\n" + ex.Message);
            }
        }
    }
}