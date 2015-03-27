using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HosDirManage
{
    /// <summary>
    /// 
    /// </summary>
    public class Info
    {
        private InterfaceHN _interfaceHN = null;

        public InterfaceHN InterfaceHN
        {
            get { return this._interfaceHN; }
            set { this._interfaceHN = value; }
        }

        public Info(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 取中心药品目录分页信息(BIZC110118)
        /// </summary>
        /// <param name="centerID"></param>
        /// <param name="type"></param>
        /// <param name="condition"></param>
        /// <param name="once_find"></param>
        /// <param name="first_row"></param>
        /// <param name="last_row"></param>
        /// <param name="first_version_id"></param>
        /// <param name="last_version_id"></param>
        /// <returns></returns>
        public List<Medic> GetCenterMedicDirPageInfo(string centerID, string type, string condition,
            string once_find, string first_row, string last_row, string first_version_id, string last_version_id)
        {
            List<Medic> list = new List<Medic>();
            Interface inter = new Interface(this.InterfaceHN);
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("center_id", centerID));
            listPara.Add(new Parameter("type", type));
            listPara.Add(new Parameter("condition", condition));
            listPara.Add(new Parameter("once_find", once_find));
            listPara.Add(new Parameter("first_row", first_row));
            listPara.Add(new Parameter("last_row", last_row));
            listPara.Add(new Parameter("first_version_id", first_version_id));
            listPara.Add(new Parameter("last_version_id", last_version_id));


            long value = inter.ExecInterface("BIZC110118", listPara);

            if (value < 0)
            {
                throw new Exception("取中心药品目录分页信息失败，失败原因：" + inter.GetMessage());
            }

            inter.SetResultset("");

            return list;
        }
    }
}
