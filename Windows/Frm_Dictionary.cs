using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InterfaceClass.HN.HosDirManage;

namespace Windows
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_Dictionary : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
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

            SetC1FlexGridAttribute(this.c1FlexGridProject, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridProject, C1.Win.C1FlexGrid.SelectionModeEnum.Row);

            SetC1FlexGridAttribute(this.c1FlexGridDisease, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridDisease, C1.Win.C1FlexGrid.SelectionModeEnum.Row);

            SetC1FlexGridAttribute(this.c1FlexGridModel, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridModel, C1.Win.C1FlexGrid.SelectionModeEnum.Row);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridMedical);
            SetC1FlexGridNullDataTable(this.c1FlexGridMedical);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridProject);
            SetC1FlexGridNullDataTable(this.c1FlexGridProject);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridDisease);
            SetC1FlexGridNullDataTable(this.c1FlexGridDisease);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridModel);
            SetC1FlexGridNullDataTable(this.c1FlexGridModel);

            this.pagerControlMedical.SetPageSize(20);
            this.pagerControlProject.SetPageSize(20);
            this.pagerControlDisease.SetPageSize(20);

            SetApplicationIco(this);
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
                DisplayTips();

                InterfaceClass.HN.HosDirManage.Info info = new InterfaceClass.HN.HosDirManage.Info(baseInterfaceHN);

                string centerID = baseInterfaceHN.Oper_centerid;
                string type = "version";
                string condition = "bs_catalog_match";
                string once_find = "1";
                string first_row = this.pagerControlMedical.GetFirstRow().ToString();
                string last_row = this.pagerControlMedical.GetLastRow().ToString();
                string first_version_id = "1";
                string last_version_id = "1000000";

                List<InterfaceClass.HN.HosDirManage.Medic> listMedical = info.GetCenterMedicDirPageInfo(centerID, type, condition, once_find, first_row, last_row, first_version_id, last_version_id);

                this.pagerControlMedical.SetRecordCount(int.Parse(info.MedicalTotalCounts));

                DataTable dt = new DataTable();

                dt.Columns.Add(AddDataColumn("medi_code", "药品编码"));
                dt.Columns.Add(AddDataColumn("medi_name", "药品名称"));
                dt.Columns.Add(AddDataColumn("english_name", "药品英名名"));
                dt.Columns.Add(AddDataColumn("model", "剂型编码"));
                dt.Columns.Add(AddDataColumn("medi_item_type", "药品类型"));
                dt.Columns.Add(AddDataColumn("stat_type", "药品费用分类"));
                dt.Columns.Add(AddDataColumn("code_wb", "五笔码"));
                dt.Columns.Add(AddDataColumn("code_py", "拼音码"));
                dt.Columns.Add(AddDataColumn("price", "标准单价"));
                dt.Columns.Add(AddDataColumn("staple_flag", "甲/乙标志"));
                dt.Columns.Add(AddDataColumn("effect_date", "生效日期"));
                dt.Columns.Add(AddDataColumn("expire_date", "失效日期"));
                dt.Columns.Add(AddDataColumn("otc", "处方用药标志"));
                dt.Columns.Add(AddDataColumn("mt_flag", "医疗目录"));
                dt.Columns.Add(AddDataColumn("wl_flag", "工伤补充目录"));
                dt.Columns.Add(AddDataColumn("bo_flag", "生育补充目录"));
                dt.Columns.Add(AddDataColumn("sp_flag", "特殊人群补充目录"));

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

                CloseTips();
            }
            catch (Exception ee)
            {
                CloseTips();
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
            this.btnMedicalQuery.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerControlProject_OnPageChanged(object sender, EventArgs e)
        {
            this.btnProjectQuery.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerControlDisease_OnPageChanged(object sender, EventArgs e)
        {
            this.btnDiseaseQuery.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiseaseQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayTips();

                InterfaceClass.HN.HosDirManage.Info info = new InterfaceClass.HN.HosDirManage.Info(baseInterfaceHN);

                string centerID = baseInterfaceHN.Oper_centerid;
                string type = "query";
                string condition = "";
                string once_find = "1";
                string first_row = this.pagerControlProject.GetFirstRow().ToString();
                string last_row = this.pagerControlProject.GetLastRow().ToString();

                List<InterfaceClass.HN.HosDirManage.Disease> listDisease = info.GetCenterDiseaseDirPageInfo(centerID, type, condition, once_find, first_row, last_row);

                this.pagerControlDisease.SetRecordCount(int.Parse(info.DiseaseTotalCounts));

                DataTable dt = new DataTable();

                dt.Columns.Add(AddDataColumn("icd", "疾病编码"));
                dt.Columns.Add(AddDataColumn("disease", "疾病名称"));
                dt.Columns.Add(AddDataColumn("disease_fee", "疾病费用标准"));
                dt.Columns.Add(AddDataColumn("code_wb", "五笔码"));
                dt.Columns.Add(AddDataColumn("code_py", "拼音码"));
                dt.Columns.Add(AddDataColumn("EDIT_DATE", "修改时间"));
                dt.Columns.Add(AddDataColumn("EDIT_STAFF", "修改人工号"));
                dt.Columns.Add(AddDataColumn("EDIT_MAN", "修改人"));
                dt.Columns.Add(AddDataColumn("VALID_FLAG", "有效标志"));
                dt.Columns.Add(AddDataColumn("EFFECT_DATE", "生效时间"));
                dt.Columns.Add(AddDataColumn("EXPIRE_DATE", "失效时间"));
                dt.Columns.Add(AddDataColumn("AUDIT_FLAG", "审核标志"));
                dt.Columns.Add(AddDataColumn("AUDIT_DATE", "审核时间"));
                dt.Columns.Add(AddDataColumn("AUDIT_STAFF", "审核人工号"));
                dt.Columns.Add(AddDataColumn("AUDIT_MAN", "审核人"));
                dt.Columns.Add(AddDataColumn("SERIAL_ICD", "疾病序列号"));

                foreach (InterfaceClass.HN.HosDirManage.Disease disease in listDisease)
                {
                    DataRow dr = dt.NewRow();

                    dr["icd"] = disease.icd;
                    dr["disease"] = disease.disease;
                    dr["disease_fee"] = disease.disease_fee;
                    dr["code_wb"] = disease.code_wb;
                    dr["code_py"] = disease.code_py;
                    dr["EDIT_DATE"] = disease.EDIT_DATE;
                    dr["EDIT_STAFF"] = disease.EDIT_STAFF;
                    dr["EDIT_MAN"] = disease.EDIT_MAN;
                    dr["VALID_FLAG"] = disease.VALID_FLAG;
                    dr["EFFECT_DATE"] = disease.EFFECT_DATE;
                    dr["EXPIRE_DATE"] = disease.EXPIRE_DATE;
                    dr["AUDIT_FLAG"] = disease.AUDIT_FLAG;
                    dr["AUDIT_DATE"] = disease.AUDIT_DATE;
                    dr["AUDIT_STAFF"] = disease.AUDIT_STAFF;
                    dr["AUDIT_MAN"] = disease.AUDIT_MAN;
                    dr["SERIAL_ICD"] = disease.SERIAL_ICD;

                    dt.Rows.Add(dr);
                }

                this.c1FlexGridDisease.DataSource = dt;

                CloseTips();
            }
            catch (Exception ee)
            {
                CloseTips();
                CommonFunctions.MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayTips();

                InterfaceClass.HN.HosDirManage.Info info = new InterfaceClass.HN.HosDirManage.Info(baseInterfaceHN);

                string centerID = baseInterfaceHN.Oper_centerid;
                string type = "version";
                string condition = "bs_item";
                string once_find = "1";
                string first_row = this.pagerControlProject.GetFirstRow().ToString();
                string last_row = this.pagerControlProject.GetLastRow().ToString();
                string first_version_id = "1";
                string last_version_id = "1000000";

                List<InterfaceClass.HN.HosDirManage.Project> listProject = info.GetCenterProjectDirPageInfo(centerID, type, condition, once_find, first_row, last_row, first_version_id, last_version_id);

                this.pagerControlProject.SetRecordCount(int.Parse(info.ProjectTotalCounts));

                DataTable dt = new DataTable();

                dt.Columns.Add(AddDataColumn("item_code", "项目编码"));
                dt.Columns.Add(AddDataColumn("item_name", "项目名称"));
                dt.Columns.Add(AddDataColumn("class_code", "项目分类编码"));
                dt.Columns.Add(AddDataColumn("unit", "标准单位"));
                dt.Columns.Add(AddDataColumn("price", "标准单价"));
                dt.Columns.Add(AddDataColumn("medi_item_type", "项目类型"));
                dt.Columns.Add(AddDataColumn("stat_type", "项目费用分类"));
                dt.Columns.Add(AddDataColumn("code_wb", "五笔码"));
                dt.Columns.Add(AddDataColumn("code_py", "拼音码"));
                dt.Columns.Add(AddDataColumn("self_scale", "标准单价"));
                dt.Columns.Add(AddDataColumn("effect_date", "生效日期"));
                dt.Columns.Add(AddDataColumn("expire_date", "失效日期"));
                dt.Columns.Add(AddDataColumn("mt_flag", "医疗目录"));
                dt.Columns.Add(AddDataColumn("wl_flag", "工伤补充目录"));
                dt.Columns.Add(AddDataColumn("bo_flag", "生育补充目录"));
                dt.Columns.Add(AddDataColumn("sp_flag", "特殊人群补充目录"));

                foreach (InterfaceClass.HN.HosDirManage.Project project in listProject)
                {
                    DataRow dr = dt.NewRow();

                    dr["item_code"] = project.item_code;
                    dr["item_name"] = project.item_name;
                    dr["class_code"] = project.class_code;
                    dr["unit"] = project.unit;
                    dr["price"] = project.price;
                    dr["medi_item_type"] = project.medi_item_type;
                    dr["stat_type"] = project.stat_type;
                    dr["code_wb"] = project.code_wb;
                    dr["code_py"] = project.code_py;
                    dr["self_scale"] = project.self_scale;
                    dr["effect_date"] = project.effect_date;
                    dr["effect_date"] = project.effect_date;
                    dr["mt_flag"] = project.mt_flag;
                    dr["wl_flag"] = project.wl_flag;
                    dr["bo_flag"] = project.bo_flag;
                    dr["sp_flag"] = project.sp_flag;

                    dt.Rows.Add(dr);
                }

                this.c1FlexGridProject.DataSource = dt;

                CloseTips();
            }
            catch (Exception ee)
            {
                CloseTips();
                CommonFunctions.MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMedicalDown_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("您真的要从中心药品服务器下载数据到HIS数据库吗？",
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (DialogResult.Yes != dialogResult)
                {
                    return;
                }

                DisplayTips("正在下载中心药品数据到HIS数据库(" + this.pagerControlMedical.RecordCount + "条记录)......");

                DataTable dt = DownloadAllMedicalData();

                if (dt == null || dt.Rows.Count <= 0)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("BEGIN TRANSACTION;");

                sb.AppendLine("DELETE  FROM [HIS_InterfaceHN].[dbo].[JC_Interface_CenterMedical];");

                foreach (DataRow dr in dt.Rows)
                {
                    string sql = InsertIntoMedicalSQL(dr);

                    sb.AppendLine(sql);

                    sb.AppendLine(string.Format(@"IF @@ERROR <> 0
                                              BEGIN 
                                                ROLLBACK; 
                                                RAISERROR('插入编号为{0}的记录发生错误！',16,1);
                                              END", dr["medi_code"]));
                }

                sb.AppendLine("COMMIT TRANSACTION;");

                int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(sb.ToString());

                CloseTips();

                if (temp > 0)
                {
                    CommonFunctions.MsgInfo("中心药品数据到HIS数据库(" + dt.Rows.Count + "条记录)，成功下载" + temp + "条记录(包含删除的记录)！！！");
                }
            }
            catch (Exception ee)
            {
                CloseTips();
                CommonFunctions.MsgError("下载中心药品数据到HIS数据库发生错误，错误原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 下载所有中心项目信息
        /// </summary>
        /// <returns></returns>
        private DataTable DownloadAllDiseaseData()
        {
            if (this.c1FlexGridDisease.Rows.Count <= 0 || this.pagerControlDisease.RecordCount <= 0)
            {
                CommonFunctions.MsgInfo("请先检索中心疾病数据，之后再进行【下载中心疾病数据到HIS数据库】操作！！！");
                return null;
            }

            try
            {
                InterfaceClass.HN.HosDirManage.Info info = new InterfaceClass.HN.HosDirManage.Info(baseInterfaceHN);

                string centerID = baseInterfaceHN.Oper_centerid;
                string type = "query";
                string condition = "";
                string once_find = "1";
                string first_row = "1";
                string last_row = this.pagerControlDisease.RecordCount.ToString();

                List<InterfaceClass.HN.HosDirManage.Disease> listDisease = info.GetCenterDiseaseDirPageInfo(centerID, type, condition, once_find, first_row, last_row);

                DataTable dt = new DataTable();

                dt.Columns.Add(AddDataColumn("icd", "疾病编码"));
                dt.Columns.Add(AddDataColumn("disease", "疾病名称"));
                dt.Columns.Add(AddDataColumn("disease_fee", "疾病费用标准"));
                dt.Columns.Add(AddDataColumn("code_wb", "五笔码"));
                dt.Columns.Add(AddDataColumn("code_py", "拼音码"));
                dt.Columns.Add(AddDataColumn("EDIT_DATE", "修改时间"));
                dt.Columns.Add(AddDataColumn("EDIT_STAFF", "修改人工号"));
                dt.Columns.Add(AddDataColumn("EDIT_MAN", "修改人"));
                dt.Columns.Add(AddDataColumn("VALID_FLAG", "有效标志"));
                dt.Columns.Add(AddDataColumn("EFFECT_DATE", "生效时间"));
                dt.Columns.Add(AddDataColumn("EXPIRE_DATE", "失效时间"));
                dt.Columns.Add(AddDataColumn("AUDIT_FLAG", "审核标志"));
                dt.Columns.Add(AddDataColumn("AUDIT_DATE", "审核时间"));
                dt.Columns.Add(AddDataColumn("AUDIT_STAFF", "审核人工号"));
                dt.Columns.Add(AddDataColumn("AUDIT_MAN", "审核人"));
                dt.Columns.Add(AddDataColumn("SERIAL_ICD", "疾病序列号"));

                foreach (InterfaceClass.HN.HosDirManage.Disease disease in listDisease)
                {
                    DataRow dr = dt.NewRow();

                    dr["icd"] = disease.icd;
                    dr["disease"] = disease.disease;
                    dr["disease_fee"] = disease.disease_fee;
                    dr["code_wb"] = disease.code_wb;
                    dr["code_py"] = disease.code_py;
                    dr["EDIT_DATE"] = disease.EDIT_DATE;
                    dr["EDIT_STAFF"] = disease.EDIT_STAFF;
                    dr["EDIT_MAN"] = disease.EDIT_MAN;
                    dr["VALID_FLAG"] = disease.VALID_FLAG;
                    dr["EFFECT_DATE"] = disease.EFFECT_DATE;
                    dr["EXPIRE_DATE"] = disease.EXPIRE_DATE;
                    dr["AUDIT_FLAG"] = disease.AUDIT_FLAG;
                    dr["AUDIT_DATE"] = disease.AUDIT_DATE;
                    dr["AUDIT_STAFF"] = disease.AUDIT_STAFF;
                    dr["AUDIT_MAN"] = disease.AUDIT_MAN;
                    dr["SERIAL_ICD"] = disease.SERIAL_ICD;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("下载中心项目数据到HIS数据库失败，失败原因：" + ee.Message);
                return null;
            }
        }

        /// <summary>
        /// 下载所有中心项目信息
        /// </summary>
        /// <returns></returns>
        private DataTable DownloadAllProjectData()
        {
            if (this.c1FlexGridProject.Rows.Count <= 0 || this.pagerControlProject.RecordCount <= 0)
            {
                CommonFunctions.MsgInfo("请先检索中心项目数据，之后再进行【下载中心项目数据到HIS数据库】操作！！！");
                return null;
            }

            try
            {
                InterfaceClass.HN.HosDirManage.Info info = new InterfaceClass.HN.HosDirManage.Info(baseInterfaceHN);

                string centerID = baseInterfaceHN.Oper_centerid;
                string type = "version";
                string condition = "bs_item";
                string once_find = "1";
                string first_row = "1";
                string last_row = this.pagerControlProject.RecordCount.ToString();
                string first_version_id = "1";
                string last_version_id = "1000000";

                List<InterfaceClass.HN.HosDirManage.Project> listProject = info.GetCenterProjectDirPageInfo(centerID, type, condition, once_find, first_row, last_row, first_version_id, last_version_id);

                DataTable dt = new DataTable();

                dt.Columns.Add(AddDataColumn("item_code", "项目编码"));
                dt.Columns.Add(AddDataColumn("item_name", "项目名称"));
                dt.Columns.Add(AddDataColumn("class_code", "项目分类编码"));
                dt.Columns.Add(AddDataColumn("unit", "标准单位"));
                dt.Columns.Add(AddDataColumn("price", "标准单价"));
                dt.Columns.Add(AddDataColumn("medi_item_type", "项目类型"));
                dt.Columns.Add(AddDataColumn("stat_type", "项目费用分类"));
                dt.Columns.Add(AddDataColumn("code_wb", "五笔码"));
                dt.Columns.Add(AddDataColumn("code_py", "拼音码"));
                dt.Columns.Add(AddDataColumn("self_scale", "标准单价"));
                dt.Columns.Add(AddDataColumn("effect_date", "生效日期"));
                dt.Columns.Add(AddDataColumn("expire_date", "失效日期"));
                dt.Columns.Add(AddDataColumn("mt_flag", "医疗目录"));
                dt.Columns.Add(AddDataColumn("wl_flag", "工伤补充目录"));
                dt.Columns.Add(AddDataColumn("bo_flag", "生育补充目录"));
                dt.Columns.Add(AddDataColumn("sp_flag", "特殊人群补充目录"));

                foreach (InterfaceClass.HN.HosDirManage.Project project in listProject)
                {
                    DataRow dr = dt.NewRow();

                    dr["item_code"] = project.item_code;
                    dr["item_name"] = project.item_name;
                    dr["class_code"] = project.class_code;
                    dr["unit"] = project.unit;
                    dr["price"] = project.price;
                    dr["medi_item_type"] = project.medi_item_type;
                    dr["stat_type"] = project.stat_type;
                    dr["code_wb"] = project.code_wb;
                    dr["code_py"] = project.code_py;
                    dr["self_scale"] = project.self_scale;
                    dr["effect_date"] = project.effect_date;
                    dr["effect_date"] = project.effect_date;
                    dr["mt_flag"] = project.mt_flag;
                    dr["wl_flag"] = project.wl_flag;
                    dr["bo_flag"] = project.bo_flag;
                    dr["sp_flag"] = project.sp_flag;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("下载中心项目数据到HIS数据库失败，失败原因：" + ee.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有药品信息
        /// </summary>
        /// <returns></returns>
        private DataTable DownloadAllMedicalData()
        {
            if (this.c1FlexGridMedical.Rows.Count <= 0 || this.pagerControlMedical.RecordCount <= 0)
            {
                CommonFunctions.MsgInfo("请先检索中心药品数据，之后再进行【下载中心药品数据到HIS数据库】操作！！！");
                return null;
            }

            try
            {
                InterfaceClass.HN.HosDirManage.Info info = new InterfaceClass.HN.HosDirManage.Info(baseInterfaceHN);

                string centerID = baseInterfaceHN.Oper_centerid;
                string type = "version";
                string condition = "bs_medi";
                string once_find = "1";
                string first_row = "1";
                string last_row = this.pagerControlMedical.RecordCount.ToString();
                string first_version_id = "1";
                string last_version_id = "1000000";

                List<InterfaceClass.HN.HosDirManage.Medic> listMedical = info.GetCenterMedicDirPageInfo(centerID, type, condition, once_find, first_row, last_row, first_version_id, last_version_id);

                DataTable dt = new DataTable();

                dt.Columns.Add(AddDataColumn("medi_code", "药品编码"));
                dt.Columns.Add(AddDataColumn("medi_name", "药品名称"));
                dt.Columns.Add(AddDataColumn("english_name", "药品英名名"));
                dt.Columns.Add(AddDataColumn("model", "剂型编码"));
                dt.Columns.Add(AddDataColumn("medi_item_type", "药品类型"));
                dt.Columns.Add(AddDataColumn("stat_type", "药品费用分类"));
                dt.Columns.Add(AddDataColumn("code_wb", "五笔码"));
                dt.Columns.Add(AddDataColumn("code_py", "拼音码"));
                dt.Columns.Add(AddDataColumn("price", "标准单价"));
                dt.Columns.Add(AddDataColumn("staple_flag", "甲/乙标志"));
                dt.Columns.Add(AddDataColumn("effect_date", "生效日期"));
                dt.Columns.Add(AddDataColumn("expire_date", "失效日期"));
                dt.Columns.Add(AddDataColumn("otc", "处方用药标志"));
                dt.Columns.Add(AddDataColumn("mt_flag", "医疗目录"));
                dt.Columns.Add(AddDataColumn("wl_flag", "工伤补充目录"));
                dt.Columns.Add(AddDataColumn("bo_flag", "生育补充目录"));
                dt.Columns.Add(AddDataColumn("sp_flag", "特殊人群补充目录"));

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
                return dt;
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("下载中心药品数据到HIS数据库失败，失败原因：" + ee.Message);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string InsertIntoModelSQL(DataRow dr)
        {
            return string.Format(@"INSERT  INTO [HIS_InterfaceHN].[dbo].[JC_Model]
                                            ( [Code], [Name] )
                                    VALUES  ( N'{0}'--<Code, nchar(20),>
                                                , N'{1}'--<Name, nchar(50),>
                                                );", dr["Code"], dr["Name"]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string InsertIntoDiseaseSQL(DataRow dr)
        {
            return string.Format(@"INSERT  INTO [HIS_InterfaceHN].[dbo].[JC_Interface_Disease]
                                            ( [icd] ,
                                              [disease] ,
                                              [disease_fee] ,
                                              [code_wb] ,
                                              [code_py] ,
                                              [EDIT_DATE] ,
                                              [EDIT_STAFF] ,
                                              [EDIT_MAN] ,
                                              [VALID_FLAG] ,
                                              [EFFECT_DATE] ,
                                              [EXPIRE_DATE] ,
                                              [AUDIT_FLAG] ,
                                              [AUDIT_DATE] ,
                                              [AUDIT_STAFF] ,
                                              [AUDIT_MAN] ,
                                              [SERIAL_ICD]
                                            )
                                    VALUES  ( N'{0}'--<icd, nchar(20),>
                                              ,
                                              N'{1}'--<disease, nchar(50),>
                                              ,
                                              N'{2}'--<disease_fee, nchar(12),>
                                              ,
                                              N'{3}'--<code_wb, nchar(20),>
                                              ,
                                              N'{4}'--<code_py, nchar(20),>
                                              ,
                                              N'{5}'--<EDIT_DATE, datetime,>
                                              ,
                                              N'{6}'--<EDIT_STAFF, nchar(10),>
                                              ,
                                              N'{7}'--<EDIT_MAN, nchar(30),>
                                              ,
                                              N'{8}'--<VALID_FLAG, char(1),>
                                              ,
                                              N'{9}'--<EFFECT_DATE, datetime,>
                                              ,
                                              N'{10}'--<EXPIRE_DATE, datetime,>
                                              ,
                                              N'{11}'--<AUDIT_FLAG, char(1),>
                                              ,
                                              N'{12}'--<AUDIT_DATE, datetime,>
                                              ,
                                              N'{13}'--<AUDIT_STAFF, nchar(10),>
                                              ,
                                              N'{14}'--<AUDIT_MAN, nchar(30),>
                                              ,
                                              N'{15}'--<SERIAL_ICD, nchar(10),>
                                            );",
                                                                             dr["icd"],
                                                                             dr["disease"],
                                                                             dr["disease_fee"],
                                                                             dr["code_wb"],
                                                                             dr["code_py"],
                                                                             dr["EDIT_DATE"],
                                                                             dr["EDIT_STAFF"],
                                                                             dr["EDIT_MAN"],
                                                                             dr["VALID_FLAG"],
                                                                             dr["EFFECT_DATE"],
                                                                             dr["EXPIRE_DATE"],
                                                                             dr["AUDIT_FLAG"],
                                                                             dr["AUDIT_DATE"],
                                                                             dr["AUDIT_STAFF"],
                                                                             dr["AUDIT_MAN"],
                                                                             dr["SERIAL_ICD"]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string InsertIntoMedicalSQL(DataRow dr)
        {
            return string.Format(@"INSERT INTO [HIS_InterfaceHN].[dbo].[JC_Interface_CenterMedical]
                                                ([medi_code]
                                                ,[medi_name]
                                                ,[english_name]
                                                ,[model]
                                                ,[medi_item_type]
                                                ,[stat_type]
                                                ,[code_wb]
                                                ,[code_py]
                                                ,[price]
                                                ,[staple_flag]
                                                ,[effect_date]
                                                ,[expire_date]
                                                ,[otc]
                                                ,[mt_flag]
                                                ,[wl_flag]
                                                ,[bo_flag]
                                                ,[sp_flag])
                                            VALUES
                                                (N'{0}'--<medi_code, nvarchar(20),>
                                                ,N'{1}'--<medi_name, nvarchar(50),>
                                                ,N'{2}'--<english_name, nvarchar(50),>
                                                ,N'{3}'--<model, nvarchar(20),>
                                                ,N'{4}'--<medi_item_type, tinyint,>
                                                ,N'{5}'--<stat_type, nvarchar(3),>
                                                ,N'{6}'--<code_wb, nvarchar(20),>
                                                ,N'{7}'--<code_py, nvarchar(20),>
                                                ,N'{8}'--<price, numeric,>
                                                ,N'{9}'--<staple_flag, tinyint,>
                                                ,N'{10}'--<effect_date, datetime,>
                                                ,N'{11}'--<expire_date, datetime,>
                                                ,N'{12}'--<otc, tinyint,>
                                                ,N'{13}'--<mt_flag, char(1),>
                                                ,N'{14}'--<wl_flag, char(1),>
                                                ,N'{15}'--<bo_flag, char(1),>
                                                ,N'{16}'--<sp_flag, char(1),>
                                                );",
                                                                             dr["medi_code"],
                                                                             dr["medi_name"],
                                                                             dr["english_name"],
                                                                             dr["model"],
                                                                             dr["medi_item_type"],
                                                                             dr["stat_type"],
                                                                             dr["code_wb"],
                                                                             dr["code_py"],
                                                                             dr["price"].ToString().Trim() == string.Empty ? "0" : dr["price"],
                                                                             dr["staple_flag"],
                                                                             dr["effect_date"],
                                                                             dr["expire_date"],
                                                                             dr["otc"],
                                                                             dr["mt_flag"],
                                                                             dr["wl_flag"],
                                                                             dr["bo_flag"],
                                                                             dr["sp_flag"]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string InsertIntoProjectSQL(DataRow dr)
        {
            return string.Format(@"INSERT INTO [HIS_InterfaceHN].[dbo].[JC_Interface_CenterProject]
                                                ([item_code]
                                                ,[item_name]
                                                ,[class_code]
                                                ,[unit]
                                                ,[medi_item_type]
                                                ,[stat_type]
                                                ,[code_wb]
                                                ,[code_py]
                                                ,[price]
                                                ,[self_scale]
                                                ,[effect_date]
                                                ,[expire_date]
                                                ,[mt_flag]
                                                ,[wl_flag]
                                                ,[bo_flag]
                                                ,[sp_flag])
                                            VALUES
                                                (N'{0}'--<item_code, nvarchar(20),>
                                                ,N'{1}'--<item_name, nvarchar(50),>
                                                ,N'{2}'--<class_code, nvarchar(50),>
                                                ,N'{3}'--<unit, nvarchar(20),>
                                                ,N'{4}'--<medi_item_type, tinyint,>
                                                ,N'{5}'--<stat_type, nvarchar(3),>
                                                ,N'{6}'--<code_wb, nvarchar(20),>
                                                ,N'{7}'--<code_py, nvarchar(20),>
                                                ,N'{8}'--<price, numeric,>
                                                ,N'{9}'--<self_scale, tinyint,>
                                                ,N'{10}'--<effect_date, datetime,>
                                                ,N'{11}'--<expire_date, datetime,>
                                                ,N'{12}'--<mt_flag, char(1),>
                                                ,N'{13}'--<wl_flag, char(1),>
                                                ,N'{14}'--<bo_flag, char(1),>
                                                ,N'{15}'--<sp_flag, char(1),>
                                                );",
                                                                             dr["item_code"],
                                                                             dr["item_name"],
                                                                             dr["class_code"],
                                                                             dr["unit"],
                                                                             dr["medi_item_type"],
                                                                             dr["stat_type"],
                                                                             dr["code_wb"],
                                                                             dr["code_py"],
                                                                             dr["price"].ToString().Trim() == string.Empty ? "0" : dr["price"],
                                                                             dr["self_scale"],
                                                                             dr["effect_date"],
                                                                             dr["expire_date"],
                                                                             dr["mt_flag"],
                                                                             dr["wl_flag"],
                                                                             dr["bo_flag"],
                                                                             dr["sp_flag"]);
        }

        /// <summary>
        /// 中心药品另存为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMedicalSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel文件|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DisplayTips("正在另存为中心药品目录信息......");

                    string fileName = sfd.FileName;

                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName += ".xls";
                    }

                    DataTable dt = DownloadAllMedicalData();

                    CommonFunctions.WriteExcel(dt, fileName);

                    CloseTips();

                    CommonFunctions.MsgInfo("文件" + fileName + "保存成功！！！");
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("另存为中心药品目录信息失败，失败原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectDown_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("您真的要从中心项目服务器下载数据到HIS数据库吗？",
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (DialogResult.Yes != dialogResult)
                {
                    return;
                }

                DisplayTips("正在下载中心项目数据到HIS数据库(" + this.pagerControlProject.RecordCount + "条记录)......");

                DataTable dt = DownloadAllProjectData();

                if (dt == null || dt.Rows.Count <= 0)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("BEGIN TRANSACTION;");

                sb.AppendLine("DELETE  FROM [HIS_InterfaceHN].[dbo].[JC_Interface_CenterProject];");

                foreach (DataRow dr in dt.Rows)
                {
                    string sql = InsertIntoProjectSQL(dr);

                    sb.AppendLine(sql);

                    sb.AppendLine(string.Format(@"IF @@ERROR <> 0
                                              BEGIN 
                                                ROLLBACK; 
                                                RAISERROR('插入编号为{0}的记录发生错误！',16,1);
                                              END", dr["item_code"]));
                }

                sb.AppendLine("COMMIT TRANSACTION;");

                int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(sb.ToString());

                CloseTips();

                if (temp > 0)
                {
                    CommonFunctions.MsgInfo("中心项目数据到HIS数据库(" + dt.Rows.Count + "条记录)，成功下载" + temp + "条记录(包含删除的记录)！！！");
                }

            }
            catch (Exception ee)
            {
                CloseTips();
                CommonFunctions.MsgError("下载中心项目数据到HIS数据库发生错误，错误原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel文件|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DisplayTips("正在另存为中心项目目录信息......");

                    string fileName = sfd.FileName;

                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName += ".xls";
                    }

                    DataTable dt = DownloadAllProjectData();

                    CommonFunctions.WriteExcel(dt, fileName);

                    CloseTips();

                    CommonFunctions.MsgInfo("文件" + fileName + "保存成功！！！");
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("另存为中心项目目录信息失败，失败原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiseaseDown_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("您真的要从中心疾病服务器下载数据到HIS数据库吗？",
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (DialogResult.Yes != dialogResult)
                {
                    return;
                }

                DisplayTips("正在下载中心疾病数据到HIS数据库(" + this.pagerControlDisease.RecordCount + "条记录)......");

                DataTable dt = DownloadAllDiseaseData();

                if (dt == null || dt.Rows.Count <= 0)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("BEGIN TRANSACTION;");

                sb.AppendLine("DELETE  FROM [HIS_InterfaceHN].[dbo].[JC_Interface_Disease];");

                foreach (DataRow dr in dt.Rows)
                {
                    string sql = InsertIntoDiseaseSQL(dr);

                    sb.AppendLine(sql);

                    sb.AppendLine(string.Format(@"IF @@ERROR <> 0
                                              BEGIN 
                                                ROLLBACK; 
                                                RAISERROR('插入编号为{0}的记录发生错误！',16,1);
                                              END", dr["icd"]));
                }

                sb.AppendLine("COMMIT TRANSACTION;");

                int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(sb.ToString());

                CloseTips();

                if (temp > 0)
                {
                    CommonFunctions.MsgInfo("中心疾病数据到HIS数据库(" + dt.Rows.Count + "条记录)，成功下载" + temp + "条记录(包含删除的记录)！！！");
                }

            }
            catch (Exception ee)
            {
                CloseTips();
                CommonFunctions.MsgError("下载中心疾病数据到HIS数据库发生错误，错误原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiseaseSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel文件|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DisplayTips("正在另存为中心疾病目录信息......");

                    string fileName = sfd.FileName;

                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName += ".xls";
                    }

                    DataTable dt = DownloadAllDiseaseData();

                    CommonFunctions.WriteExcel(dt, fileName);

                    CloseTips();

                    CommonFunctions.MsgInfo("文件" + fileName + "保存成功！！！");
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("另存为中心疾病目录信息失败，失败原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridDisease_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageMedical_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridMedical_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerControlMedical_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMedicalExcel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageProject_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridProject_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerControlProject_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectExcel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageDisease_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerControlDisease_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiseaseExcel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageModel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageModel_Enter(object sender, EventArgs e)
        {
            try
            {
                QueryModelData();
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryModelData()
        {
            string SQLString = string.Format(@"SELECT  [Code] ,
                                                        [Name]
                                                FROM    [HIS_InterfaceHN].[dbo].[JC_Model]");

            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                this.c1FlexGridModel.DataSource = ds.Tables[0];

                this.c1FlexGridModel.Cols["Code"].Caption = "剂型编码";
                this.c1FlexGridModel.Cols["Name"].Caption = "剂型名称";

                this.c1FlexGridModel.Cols["Name"].Width = this.c1FlexGridModel.Width - 160;
            }
            catch (Exception e)
            {
                throw new Exception("查询基础记性数据失败，失败原因：" + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModelQuery_Click(object sender, EventArgs e)
        {
            try
            {
                QueryModelData();
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModelExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Excel文件|*.xls";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DisplayTips("正在从Excel文件中导入省直目录的剂型(model)......");

                    string fileName = openFileDialog.FileName;

                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName += ".xls";
                    }

                    DataTable dt = null;

                    CommonFunctions.OpenExcelFile(ref dt, fileName);

                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("BEGIN TRANSACTION;");

                    sb.AppendLine("DELETE  FROM [HIS_InterfaceHN].[dbo].[JC_Model];");

                    foreach (DataRow dr in dt.Rows)
                    {
                        string sql = InsertIntoModelSQL(dr);

                        sb.AppendLine(sql);

                        sb.AppendLine(string.Format(@"IF @@ERROR <> 0
                                              BEGIN 
                                                ROLLBACK; 
                                                RAISERROR('插入编号为{0}的记录发生错误！',16,1);
                                              END", dr["Code"]));
                    }

                    sb.AppendLine("COMMIT TRANSACTION;");

                    int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(sb.ToString());

                    CloseTips();

                    if (temp > 0)
                    {
                        CommonFunctions.MsgInfo("基础剂型(" + dt.Rows.Count + "条记录)，成功导入" + temp + "条记录(包含删除的记录)！！！");
                    }
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("从Excel文件中导入省直目录的剂型(model)失败，失败原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModelSave_Click(object sender, EventArgs e)
        {
            if (this.c1FlexGridModel.Rows.Count <= 0)
            {
                CommonFunctions.MsgInfo("没有任何剂型数据，不能进行另存为操作！！！");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel文件|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DisplayTips("正在另存为基础剂型信息......");

                    string fileName = sfd.FileName;

                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName += ".xls";
                    }

                    DataTable dt = (DataTable)this.c1FlexGridModel.DataSource;

                    CommonFunctions.WriteExcel(dt, fileName);

                    CloseTips();

                    CommonFunctions.MsgInfo("文件" + fileName + "保存成功！！！");
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("另存为基础剂型信息失败，失败原因：" + ex.Message);
                }
            }
        }
    }
}