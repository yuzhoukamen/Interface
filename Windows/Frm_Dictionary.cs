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

            SetC1FlexGridAttribute(this.c1FlexGridProject, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridProject, C1.Win.C1FlexGrid.SelectionModeEnum.Row);

            SetC1FlexGridAttribute(this.c1FlexGridDisease, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridDisease, C1.Win.C1FlexGrid.SelectionModeEnum.Row);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridMedical);
            SetC1FlexGridNullDataTable(this.c1FlexGridMedical);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridProject);
            SetC1FlexGridNullDataTable(this.c1FlexGridProject);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridDisease);
            SetC1FlexGridNullDataTable(this.c1FlexGridDisease);

            this.pagerControlMedical.SetPageSize(20);
            this.pagerControlProject.SetPageSize(20);
            this.pagerControlDisease.SetPageSize(20);
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
                string condition = "bs_medi";
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

                if (temp > 0)
                {
                    CommonFunctions.MsgInfo("成功下载中心药品数据到HIS数据库(" + dt.Rows.Count + "条记录)，成功下载" + temp + "条记录！！！");
                }

            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("下载中心药品数据到HIS数据库发生错误，错误原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 查询所有药品信息
        /// </summary>
        /// <returns></returns>
        private DataTable DownloadAllMedicalData()
        {
            if (this.c1FlexGridMedical.Rows.Count <= 0 || this.pagerControlMedical.PageCount <= 0)
            {
                CommonFunctions.MsgInfo("请先检索中心药品数据，之后再进行【下载中心药品数据到HIS数据库】操作！！！");
                return null;
            }

            try
            {
                DisplayTips("正在下载中心药品数据到HIS数据库(" + this.pagerControlMedical.RecordCount + "条记录)......");

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
                CloseTips();

                return dt;
            }
            catch (Exception ee)
            {
                CloseTips();
                CommonFunctions.MsgError("下载中心药品数据到HIS数据库失败，失败原因：" + ee.Message);
                return null;
            }
        }

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
    }
}
