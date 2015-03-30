using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HosDirManage
{
    /// <summary>
    /// 医院目录管理信息
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
        /// 药品总记录数
        /// </summary>
        public string MedicalTotalCounts { get; set; }

        /// <summary>
        /// 项目总记录数
        /// </summary>
        public string ProjectTotalCounts { get; set; }

        /// <summary>
        /// 疾病总记录数
        /// </summary>
        public string DiseaseTotalCounts { get; set; }

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

            inter.SetResultset("count");

            string str = string.Empty;

            inter.GetByName("count", ref str);
            this.MedicalTotalCounts = str;

            inter.SetResultset("pageinfo");

            do
            {
                Medic medic = new Medic();

                str = string.Empty;
                inter.GetByName("medi_code", ref str);
                medic.medi_code = str;

                str = string.Empty;
                inter.GetByName("medi_name", ref str);
                medic.medi_name = str;

                str = string.Empty;
                inter.GetByName("english_name", ref str);
                medic.english_name = str;

                str = string.Empty;
                inter.GetByName("model", ref str);
                medic.model = str;

                str = string.Empty;
                inter.GetByName("medi_item_type", ref str);
                medic.medi_item_type = str;

                str = string.Empty;
                inter.GetByName("stat_type", ref str);
                medic.stat_type = str;

                str = string.Empty;
                inter.GetByName("code_wb", ref str);
                medic.code_wb = str;

                str = string.Empty;
                inter.GetByName("code_py", ref str);
                medic.code_py = str;

                str = string.Empty;
                inter.GetByName("price", ref str);
                medic.price = str;

                str = string.Empty;
                inter.GetByName("staple_flag", ref str);
                medic.staple_flag = str;

                str = string.Empty;
                inter.GetByName("effect_date", ref str);
                medic.effect_date = str;

                str = string.Empty;
                inter.GetByName("expire_date", ref str);
                medic.expire_date = str;

                str = string.Empty;
                inter.GetByName("otc", ref str);
                medic.otc = str;

                str = string.Empty;
                inter.GetByName("mt_flag", ref str);
                medic.mt_flag = str;

                str = string.Empty;
                inter.GetByName("wl_flag", ref str);
                medic.wl_flag = str;

                str = string.Empty;
                inter.GetByName("bo_flag", ref str);
                medic.bo_flag = str;

                str = string.Empty;
                inter.GetByName("sp_flag", ref str);
                medic.sp_flag = str;

                list.Add(medic);
            } while (0 < inter.NextRow());

            return list;
        }

        /// <summary>
        /// 获取中心项目目录分页信息
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
        public List<Project> GetCenterProjectDirPageInfo(string center_id, string type, string condition,
            string once_find, string first_row, string last_row, string first_version_id, string last_version_id)
        {
            List<Project> list = new List<Project>();
            Interface inter = new Interface(this.InterfaceHN);
            List<Parameter> listPara = new List<Parameter>();

            listPara.Add(new Parameter("center_id", center_id));
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
                throw new Exception("取中心项目目录分页信息失败，失败原因：" + inter.GetMessage());
            }

            inter.SetResultset("count");

            string str = string.Empty;

            inter.GetByName("count", ref str);
            this.ProjectTotalCounts = str;

            inter.SetResultset("pageinfo");

            do
            {
                Project project = new Project();

                str = string.Empty;
                inter.GetByName("item_code", ref str);
                project.item_code = str;

                str = string.Empty;
                inter.GetByName("item_name", ref str);
                project.item_name = str;

                str = string.Empty;
                inter.GetByName("class_code", ref str);
                project.class_code = str;

                str = string.Empty;
                inter.GetByName("unit", ref str);
                project.unit = str;

                str = string.Empty;
                inter.GetByName("price", ref str);
                project.price = str;

                str = string.Empty;
                inter.GetByName("medi_item_type", ref str);
                project.medi_item_type = str;

                str = string.Empty;
                inter.GetByName("stat_type", ref str);
                project.stat_type = str;

                str = string.Empty;
                inter.GetByName("code_wb", ref str);
                project.code_wb = str;

                str = string.Empty;
                inter.GetByName("code_py", ref str);
                project.code_py = str;

                str = string.Empty;
                inter.GetByName("self_scale", ref str);
                project.self_scale = str;

                str = string.Empty;
                inter.GetByName("effect_date", ref str);
                project.effect_date = str;

                str = string.Empty;
                inter.GetByName("expire_date", ref str);
                project.expire_date = str;

                str = string.Empty;
                inter.GetByName("mt_flag", ref str);
                project.mt_flag = str;

                str = string.Empty;
                inter.GetByName("wl_flag", ref str);
                project.wl_flag = str;

                str = string.Empty;
                inter.GetByName("bo_flag", ref str);
                project.bo_flag = str;

                str = string.Empty;
                inter.GetByName("sp_flag", ref str);
                project.sp_flag = str;

                list.Add(project);
            } while (0 < inter.NextRow());

            return list;
        }
    }
}