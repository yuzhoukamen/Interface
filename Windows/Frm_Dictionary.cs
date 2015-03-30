using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows
{
    public partial class Frm_Dictionary : BaseForm
    {
        public Frm_Dictionary()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Dictionary_Load(object sender, EventArgs e)
        {
            SetC1FlexGridAttribute(this.c1FlexGridMedical, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridMedical, C1.Win.C1FlexGrid.SelectionModeEnum.Row);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridMedical);
            SetC1FlexGridNullDataTable(this.c1FlexGridMedical);

            this.pagerControlMedical.SetPageSize(20);
        }

        /// <summary>
        /// 检索中心药品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMedicalQuery_Click(object sender, EventArgs e)
        {
            try
            {
                InterfaceClass.HN.HosDirManage.Info info = new InterfaceClass.HN.HosDirManage.Info(baseInterfaceHN);

                string centerID = baseInterfaceHN.Oper_centerid;
                string type = "version";
                string condition = "bs_medi";
                string once_find = "1";
                string first_row = this.pagerControlMedical.GetFirstRow().ToString();
                string last_row = this.pagerControlMedical.GetLastRow().ToString();
                string first_version_id = "1";
                string last_version_id = "1000000";

                List<InterfaceClass.HN.HosDirManage.Medic> listMedical = info.GetCenterMedicDirPageInfo(centerID, type, condition, once_find, first_row, last_row, first_version_id, last_version_id);

                this.pagerControlMedical.SetRecordCount(int.Parse(info.MedicalTotalCounts));

                DataTable dt = new DataTable();

                dt.Columns.Add(GetDataColumn("medi_code", "药品编码"));
                dt.Columns.Add(GetDataColumn("medi_name", "药品名称"));
                dt.Columns.Add(GetDataColumn("english_name", "药品英名名"));
                dt.Columns.Add(GetDataColumn("model", "剂型编码"));
                dt.Columns.Add(GetDataColumn("medi_item_type", "药品类型"));
                dt.Columns.Add(GetDataColumn("stat_type", "药品费用分类"));
                dt.Columns.Add(GetDataColumn("code_wb", "五笔码"));
                dt.Columns.Add(GetDataColumn("code_py", "拼音码"));
                dt.Columns.Add(GetDataColumn("price", "标准单价"));
                dt.Columns.Add(GetDataColumn("staple_flag", "甲/乙标志"));
                dt.Columns.Add(GetDataColumn("effect_date", "生效日期"));
                dt.Columns.Add(GetDataColumn("expire_date", "失效日期"));
                dt.Columns.Add(GetDataColumn("otc", "处方用药标志"));
                dt.Columns.Add(GetDataColumn("mt_flag", "医疗目录"));
                dt.Columns.Add(GetDataColumn("wl_flag", "工伤补充目录"));
                dt.Columns.Add(GetDataColumn("bo_flag", "生育补充目录"));
                dt.Columns.Add(GetDataColumn("sp_flag", "特殊人群补充目录"));

                foreach (InterfaceClass.HN.HosDirManage.Medic medic in listMedical)
                {
                    DataRow dr = dt.NewRow();

                    dr["medi_code"] = medic.medi_code;
                    dr["medi_name"] = medic.medi_name;
                    dr["english_name"] = medic.english_name;
                    dr["model"] = medic.model;
                    dr["medi_item_type"] = medic.medi_item_type;
                    dr["stat_type"] = medic.stat_type;
                    dr["code_wb"] = medic.code_wb;
                    dr["code_py"] = medic.code_py;
                    dr["price"] = medic.price;
                    dr["staple_flag"] = medic.staple_flag;
                    dr["effect_date"] = medic.effect_date;
                    dr["effect_date"] = medic.effect_date;
                    dr["otc"] = medic.otc;
                    dr["mt_flag"] = medic.mt_flag;
                    dr["wl_flag"] = medic.wl_flag;
                    dr["bo_flag"] = medic.bo_flag;
                    dr["sp_flag"] = medic.sp_flag;

                    dt.Rows.Add(dr);
                }

                this.c1FlexGridMedical.DataSource = dt;
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
            }
        }



        /// <summary>
        /// 页面改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerControlMedical_OnPageChanged(object sender, EventArgs e)
        {
            LoadMedicalInfo();
        }

        /// <summary>
        /// 加载药品信息
        /// </summary>
        private void LoadMedicalInfo()
        {
            this.btnMedicalQuery.PerformClick();
        }
    }
}
