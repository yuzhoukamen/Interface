using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

namespace Windows
{
    public partial class Frm_DirCompare : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public Frm_DirCompare()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_DirCompare_Load(object sender, EventArgs e)
        {
            SetC1FlexGridAttribute(this.c1FlexGridAddMatch, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridAddMatch, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridAddMatch);
            SetC1FlexGridNullDataTable(this.c1FlexGridAddMatch);

            SetC1FlexGridAttribute(this.c1FlexGridInterfaceJC, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridInterfaceJC, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridInterfaceJC);
            SetC1FlexGridNullDataTable(this.c1FlexGridInterfaceJC);

            InitBindData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetC1FlexGridRowBackGroundColor()
        {
            this.c1FlexGridAddMatch.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;

            this.c1FlexGridAddMatch.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(
                delegate(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
                {
                    if (e.Row >= this.c1FlexGridAddMatch.Rows.Fixed)
                    {
                        string staple_flag = this.c1FlexGridAddMatch.Rows[e.Row]["staple_flag"].ToString().Trim();
                        string match_type = this.c1FlexGridAddMatch.Rows[e.Row]["match_type"].ToString().Trim();
                        string status = this.c1FlexGridAddMatch.Rows[e.Row]["STATUS"].ToString().Trim();

                        if (match_type != "诊疗项目" && staple_flag != string.Empty)
                        {
                            Color color;

                            switch (staple_flag)
                            {
                                case "1":
                                    color = Color.White;
                                    break;
                                case "2":
                                    color = Color.LightGreen;
                                    break;
                                case "9":
                                    color = Color.LightCoral;
                                    break;
                                default:
                                    color = Color.LightYellow;
                                    break;
                            }

                            CellStyle mystyle = this.c1FlexGridAddMatch.Styles.Add("MyStyle");
                            mystyle.BackColor = color;
                            this.c1FlexGridAddMatch.Rows[e.Row].Style = mystyle;
                        }
                    }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitBindData()
        {
            string sql = string.Format(@"SELECT  Code AS Value ,
                                                Value AS Name
                                        FROM    HIS_InterfaceHN.dbo.JC_AuditFlag");

            InitComboBox(this.cBoxAuditFlag, sql);

            sql = string.Format(@"SELECT  HIS_InterfaceHN.dbo.JC_TypeCompareTable.Name AS 'Value' ,
                                            HIS_InterfaceHN.dbo.JC_TypeCompareTable.Value AS 'Name'
                                    FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                            INNER JOIN HIS_InterfaceHN.dbo.JC_Type ON HIS_InterfaceHN.dbo.JC_Type.ID = HIS_InterfaceHN.dbo.JC_TypeCompareTable.TypeID
                                    WHERE   HIS_InterfaceHN.dbo.JC_Type.TableID = N'medi_item_type'");

            InitComboBox(this.cBoxMatchType, sql);

            QueryAddMatchInfo();
        }

        /// <summary>
        /// 查询新增医院目录匹配
        /// </summary>
        private void QueryAddMatchInfo()
        {
            string matchType = this.cBoxMatchType.SelectedValue.ToString().Trim();
            string auditFlag = this.cBoxAuditFlag.SelectedValue.ToString().Trim();

            if (matchType == string.Empty)
            {
                CommonFunctions.MsgError("请选择匹配类别！！！");
                return;
            }
            if (auditFlag == string.Empty)
            {
                CommonFunctions.MsgError("请选择审核标志！！！");
                return;
            }

            try
            {
                DisplayTips();

                IDataParameter[] parameters = new IDataParameter[2];

                parameters[0] = new SqlParameter("@MatchType", matchType);
                parameters[1] = new SqlParameter("AuditFlag", auditFlag);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_GetAddMatch", parameters, "AddMatch");

                this.c1FlexGridAddMatch.DataSource = ds.Tables["AddMatch"];

                SetC1FlexGridColumnsInfo(this.c1FlexGridAddMatch);
                SetDirCompareMainInfo(ds);
                SetC1FlexGridRowBackGroundColor();

                CloseTips();
            }
            catch (Exception ex)
            {
                CloseTips();
                CommonFunctions.MsgError("获取新增医院目录匹配发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 设置目录对照主信息
        /// </summary>
        /// <param name="ds"></param>
        private void SetDirCompareMainInfo(DataSet ds)
        {
            if (ds.Tables.Contains("AddMatch") && ds.Tables["AddMatch"].Rows.Count > 0)
            {
                this.lblCenterID.Text = ds.Tables["AddMatch"].Rows[0]["center_id"].ToString().Trim();
                this.lblHospitalID.Text = ds.Tables["AddMatch"].Rows[0]["hospital_id"].ToString().Trim();
            }
            else
            {
                this.lblCenterID.Text = string.Empty;
                this.lblHospitalID.Text = string.Empty;
            }
        }

        /// <summary>
        /// 设置C1FlexGrid列信息
        /// </summary>
        /// <param name="c1FlexGrid"></param>
        private void SetC1FlexGridColumnsInfo(C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid)
        {
            this.c1FlexGridAddMatch.Cols["ID"].Visible = false;
            this.c1FlexGridAddMatch.Cols["center_id"].Visible = false;
            this.c1FlexGridAddMatch.Cols["hospital_id"].Visible = false;

            this.c1FlexGridAddMatch.Cols["match_type"].Caption = "匹配类型";
            this.c1FlexGridAddMatch.Cols["match_type"].Width = 60;

            this.c1FlexGridAddMatch.Cols["hosp_code"].Caption = "医院目录编码";
            this.c1FlexGridAddMatch.Cols["hosp_code"].Width = 80;

            this.c1FlexGridAddMatch.Cols["hosp_name"].Caption = "医院目录名称";
            this.c1FlexGridAddMatch.Cols["hosp_name"].Width = 200;

            this.c1FlexGridAddMatch.Cols["hosp_model"].Caption = "医院目录剂型";
            this.c1FlexGridAddMatch.Cols["hosp_model"].Width = 80;

            this.c1FlexGridAddMatch.Cols["price"].Caption = "单价";
            this.c1FlexGridAddMatch.Cols["price"].Width = 50;
            this.c1FlexGridAddMatch.Cols["price"].Visible = false;

            this.c1FlexGridAddMatch.Cols["item_code"].Caption = "中心目录编码";
            this.c1FlexGridAddMatch.Cols["item_name"].Caption = "中心目录名称";
            this.c1FlexGridAddMatch.Cols["model_name"].Caption = "中心目录剂型";
            this.c1FlexGridAddMatch.Cols["effect_date"].Caption = "生效日期";
            this.c1FlexGridAddMatch.Cols["expire_date"].Caption = "失效日期";
            this.c1FlexGridAddMatch.Cols["edit_staff"].Caption = "操作员工号";
            this.c1FlexGridAddMatch.Cols["edit_man"].Caption = "操作员姓名";
            this.c1FlexGridAddMatch.Cols["valid_flag"].Caption = "有效标志";
            this.c1FlexGridAddMatch.Cols["audit_flag"].Caption = "审核标志";


        }

        private void btnQueryData_Click(object sender, EventArgs e)
        {
            QueryAddMatchInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoMatch_Click(object sender, EventArgs e)
        {
            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql("EXEC HIS_InterfaceHN.dbo.P_AutoMatch");

                CommonFunctions.MsgInfo("自动匹医院目录配成功！！！");
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("自动医院目录匹配失败，失败原因：" + ex.Message);
            }
        }

        private void c1FlexGridAddMatch_RowColChange(object sender, EventArgs e)
        {

        }
    }
}
