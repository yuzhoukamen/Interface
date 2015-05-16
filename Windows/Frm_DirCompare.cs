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
using System.Threading;
using InterfaceClass;
using Windows.Class;

namespace Windows
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_DirCompare : BaseForm
    {
        #region 属性
        private Thread _threadInitAddMatch = null;
        private Thread _threadInitBindData = null;
        private Thread _threadQueryData = null;
        private Thread _threadQueryDir = null;
        private Thread _thread = null;
        private Thread _threadInitDir = null;

        private string _matchType = string.Empty;
        private string _auditFlag = string.Empty;
        private string _keyWords = string.Empty;
        private string _addMatchID = string.Empty;
        private string _medi_item_type = string.Empty;
        private string _itemName = string.Empty;

        private DataTable _dtAddMatch = null;

        private Parameter _SelectValueParameter = null;

        private int _selectedC1FlexGridAddMatchRowIndex = 0;
        private int _selectedC1FlexGridJCCenterDirRowIndex = 0;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Frm_DirCompare(long userID)
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;
            this._userID = userID;
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

            SetDirAutoCompareIsJump();

            InitDropList();
            InitBindDataThread();
            SetApplicationIco(this);

            QueryAndSetUserInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitInterfaceDir()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在初始化中心字典，请稍后......");

                Alif.DBUtility.DbHelperSQL.Query("exec HIS_InterfaceHN.dbo.P_InitInterfaceDir");

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgInfo, "初始化中心字典成功！！！");
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "执行存储过程P_InitInterfaceDir发生错误，错误原因：" + ex.Message);
            }
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
                        SetRowBackground(e.Row);
                    }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        private void SetRowBackground(int rowIndex)
        {
            try
            {
                string staple_flag = this.c1FlexGridAddMatch.Rows[rowIndex]["staple_flag"].ToString().Trim();
                string match_type = this.c1FlexGridAddMatch.Rows[rowIndex]["match_type"].ToString().Trim();
                string status = this.c1FlexGridAddMatch.Rows[rowIndex]["CompareStatus"].ToString().Trim();

                if (match_type != "诊疗项目")
                {
                    Color color;
                    CellStyle mystyle;
                    string name = string.Empty;

                    switch (staple_flag)
                    {
                        //甲类
                        case "1":
                            color = Color.LightGreen;
                            name = "MyStyleLightGreen";
                            break;
                        //乙类
                        case "2":
                            color = Color.LightCoral;
                            name = "MyStyleLightCoral";
                            break;
                        //全自费
                        case "9":
                            color = Color.LightYellow;
                            name = "MyStyleLightYellow";
                            break;
                        //无定义
                        default:
                            color = Color.White;
                            name = "MyStyleWhite";
                            break;
                    }

                    mystyle = this.c1FlexGridAddMatch.Styles.Add(name);
                    mystyle.BackColor = color;
                    this.c1FlexGridAddMatch.Rows[rowIndex].Style = mystyle;
                }
                else
                {
                    Color color = Color.Goldenrod;
                    CellStyle myStyle = this.c1FlexGridAddMatch.Styles.Add("MyStyleGoldenrod");
                    myStyle.BackColor = color;

                    this.c1FlexGridAddMatch.Rows[rowIndex].Style = myStyle;
                }
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitBindDataThread()
        {
            _matchType = this.cBoxMatchType.SelectedValue.ToString().Trim();
            _auditFlag = this.cBoxAuditFlag.SelectedValue.ToString().Trim();
            _keyWords = this.txtBoxKeyWords.Text.Trim();

            CreateAndStartThread(this._threadInitBindData, InitBindData);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitBindData()
        {
            try
            {
                QueryAddMatchInfo();

                BindGetAllInterfaceDir();
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitDropList()
        {
            try
            {
                string sql = string.Format(@"SELECT  Code AS Value ,
                                                Value AS Name
                                        FROM    HIS_InterfaceHN.dbo.JC_AuditFlag");

                InitComboBox(this.cBoxAuditFlag, sql);

                this.cBoxAuditFlag.SelectedValue = "-1";

                sql = string.Format(@"SELECT  HIS_InterfaceHN.dbo.JC_TypeCompareTable.Name AS 'Value' ,
                                            HIS_InterfaceHN.dbo.JC_TypeCompareTable.Value AS 'Name'
                                    FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                            INNER JOIN HIS_InterfaceHN.dbo.JC_Type ON HIS_InterfaceHN.dbo.JC_Type.ID = HIS_InterfaceHN.dbo.JC_TypeCompareTable.TypeID
                                    WHERE   HIS_InterfaceHN.dbo.JC_Type.TableID = N'medi_item_type'");

                InitComboBox(this.cBoxMatchType, sql);

                this.cBoxMatchType.SelectedValue = "-1";

                sql = string.Format(@"SELECT  Name AS 'Value' ,
                                                Value AS 'Name'
                                        FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                        WHERE   TypeID = 6");
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError(e.Message);
            }
        }

        /// <summary>
        /// 查询新增医院目录匹配
        /// </summary>
        private void QueryAddMatchInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在检索新增医院目录匹配数据，请稍候......");

                IDataParameter[] parameters = new IDataParameter[3];

                parameters[0] = new SqlParameter("@MatchType", _matchType);
                parameters[1] = new SqlParameter("AuditFlag", _auditFlag);
                parameters[2] = new SqlParameter("@ItemName", _itemName);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_GetAddMatch", parameters, "AddMatch");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string upload = ds.Tables[0].Rows[i]["UploadStatus"].ToString().Trim();

                    if (upload == "0")
                    {
                        ds.Tables[0].Rows[i]["UploadStatus"] = "未上传";
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["UploadStatus"] = "已上传";
                    }
                }

                SendUIMsg(DirCompareUIMsg.c1FlexGridAddMatchDataSource, ds);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "获取新增医院目录匹配发生错误，错误原因：" + ex.Message);
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
            this.c1FlexGridAddMatch.Cols["match_type"].Visible = false;

            this.c1FlexGridAddMatch.Cols["hosp_code"].Caption = "医院目录编码";
            this.c1FlexGridAddMatch.Cols["hosp_code"].Width = 80;

            this.c1FlexGridAddMatch.Cols["hosp_name"].Caption = "医院目录名称";
            this.c1FlexGridAddMatch.Cols["hosp_name"].Width = 200;

            this.c1FlexGridAddMatch.Cols["hosp_model"].Caption = "医院目录剂型";
            this.c1FlexGridAddMatch.Cols["hosp_model"].Width = 80;

            this.c1FlexGridAddMatch.Cols["price"].Caption = "单价";
            this.c1FlexGridAddMatch.Cols["price"].Width = 50;
            this.c1FlexGridAddMatch.Cols["price"].Visible = false;

            this.c1FlexGridAddMatch.Cols["CompareStatus"].Caption = "对照状态";
            this.c1FlexGridAddMatch.Cols["UploadStatus"].Caption = "上传状态";

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryData_Click(object sender, EventArgs e)
        {
            this._matchType = this.cBoxMatchType.SelectedValue.ToString();
            this._auditFlag = this.cBoxAuditFlag.SelectedValue.ToString();
            this._itemName = this.txtBoxAddMatchItemName.Text.Trim();

            CreateAndStartThread(this._threadQueryData, QueryAddMatchInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoMatch_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("您真的要进行自动匹配吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (dr == DialogResult.Yes)
            {
                this._dtAddMatch = (DataTable)this.c1FlexGridAddMatch.DataSource;

                this._thread = null;

                CreateAndStartThread(ref this._thread, ThreadAutoMatch);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadAutoMatch()
        {
            SendUIMsg(DirCompareUIMsg.disableBtnAutoMatch);

            AutoMatch();

            QueryAddMatchInfo();

            UpdateHospitalJPM();

            this._thread = null;

            SendUIMsg(DirCompareUIMsg.enableBtnAutoMatch);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateHospitalJPM()
        {
            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query("select * from HIS_InterfaceHN.dbo.Interface_AddMatch");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string id = ds.Tables[0].Rows[i]["ID"].ToString();
                    string hosp_name = ds.Tables[0].Rows[i]["hosp_name"].ToString().Trim();

                    string hosp_jpm = Function.GetChineseSpell(hosp_name);

                    Alif.DBUtility.DbHelperSQL.ExecuteSql(string.Format("update HIS_InterfaceHN.dbo.Interface_AddMatch set hosp_jpm=N'{0}' where ID={1}", hosp_jpm, id));
                }
            }
            catch { }
        }

        /// <summary>
        /// 获取自动匹配的中心目录字典
        /// </summary>
        /// <param name="hosp_name"></param>
        /// <returns></returns>
        private DataSet GetAutoMatchInterfaceCenterDir(string hosp_name)
        {
            string SQLString = string.Format(@"SELECT  ID,medi_item_type,item_code,item_name,modelID,stat_type,staple_flag
                                                            FROM    HIS_InterfaceHN.dbo.JC_Interface_CenterDir
                                                            WHERE   item_name = '{0}'", hosp_name);

            DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count <= 0)
            {
                hosp_name = hosp_name.Replace("注射用", "");
                hosp_name = hosp_name.Replace("注射液", "");
                hosp_name = hosp_name.Replace("盐酸", "");
                hosp_name = hosp_name.Replace("硫酸", "");
                hosp_name = hosp_name.Replace("硝酸", "");
                hosp_name = hosp_name.Replace("醋酸", "");
                hosp_name = hosp_name.Replace("肠溶胶囊", "");
                hosp_name = hosp_name.Replace("分散片", "");
                hosp_name = hosp_name.Replace("缓释片", "");
                hosp_name = hosp_name.Replace("乳膏", "");
                hosp_name = hosp_name.Replace("胶囊", "");
                hosp_name = hosp_name.Replace("颗粒", "");
                hosp_name = hosp_name.Replace("滴眼液", "");
                hosp_name = hosp_name.Replace("肠溶片", "");
                hosp_name = hosp_name.Replace("{基}", "");
                hosp_name = hosp_name.Replace("片", "");
                hosp_name = hosp_name.Replace("缓释", "");
                hosp_name = hosp_name.Replace("软膏", "");
                hosp_name = hosp_name.Replace("眼膏", "");
                hosp_name = hosp_name.Replace("口服液", "");

                SQLString = string.Format(@"SELECT  ID,medi_item_type,item_code,item_name,modelID,stat_type,staple_flag
                                                            FROM    HIS_InterfaceHN.dbo.JC_Interface_CenterDir
                                                            WHERE   item_name = '{0}'", hosp_name);
                ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);
            }

            return ds;
        }

        /// <summary>
        /// 处理诊疗项目
        /// </summary>
        /// <param name="medi_item_type"></param>
        private void Dealmedi_item_type(ref string medi_item_type)
        {
            switch (medi_item_type)
            {
                case "诊疗项目":
                    medi_item_type = "0";
                    break;
                case "西药":
                    medi_item_type = "1";
                    break;
                case "中成药":
                    medi_item_type = "2";
                    break;
                case "中草药":
                    medi_item_type = "3";
                    break;
            }
        }

        /// <summary>
        /// 更新新增医院目录匹配
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="i"></param>
        /// <param name="hosp_code"></param>
        /// <param name="hosp_name"></param>
        /// <param name="item_code"></param>
        /// <param name="item_name"></param>
        /// <param name="model_name"></param>
        /// <param name="medi_item_type"></param>
        private void UpdateAddMatch(int flag, int i, string hosp_code, string hosp_name, string item_code, string item_name, string model_name, string medi_item_type)
        {
            string tempSql = string.Format(@"UPDATE  HIS_InterfaceHN.dbo.Interface_AddMatch
                                                                    SET     item_code = '{0}' ,
                                                                            item_name = '{1}' ,
                                                                            model_name = '{2}' ,
                                                                            CompareStatus = '{3}' ,
                                                                            match_type = '{5}'
                                                                    WHERE   ID = {4} 
                                                                            AND CompareStatus <> 3
                                                                            AND edit_staff = {6}
                                                                            AND edit_man = N'{7}'",
                                                            item_code, item_name, model_name, 3, this._addMatchID, medi_item_type, this._userID, this._userName);
            int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(tempSql);

            if (temp == 1)
            {
                SendUIMsg(UIMsg.WriteMsg, string.Format(@"第{0}条数据【{1}】【{2}】【{3}】匹配成功！！！",
                                                     i + 1, this._addMatchID, hosp_code, hosp_name));
                if (flag == 1)
                {
                    SendUIMsg(UIMsg.Close);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AutoMatch()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在自动匹配医院目录，请稍后......");

                for (int i = 0; i < this._dtAddMatch.Rows.Count; i++)
                {
                    this._addMatchID = this._dtAddMatch.Rows[i]["ID"].ToString().Trim();
                    string hosp_code = this._dtAddMatch.Rows[i]["hosp_code"].ToString().Trim();
                    string hosp_name = this._dtAddMatch.Rows[i]["hosp_name"].ToString().Trim();

                    SendUIMsg(UIMsg.WriteMsg, string.Format(@"正在自动匹配第{0}条数据【{1}】【{2}】【{3}】",
                        i + 1, this._addMatchID, hosp_code, hosp_name));

                    DataSet ds = GetAutoMatchInterfaceCenterDir(hosp_name);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        string item_code = ds.Tables[0].Rows[0]["item_code"].ToString().Trim();
                        string item_name = ds.Tables[0].Rows[0]["item_name"].ToString().Trim();
                        string model_name = ds.Tables[0].Rows[0]["modelID"].ToString().Trim();
                        string medi_item_type = ds.Tables[0].Rows[0]["medi_item_type"].ToString().Trim();
                        string staple_flag = ds.Tables[0].Rows[0]["staple_flag"].ToString().Trim();

                        Dealmedi_item_type(ref medi_item_type);

                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            UpdateAddMatch(0, i, hosp_code, hosp_name, item_code, item_name, model_name, medi_item_type);
                        }
                        else
                        {
                            if (this.DirAutoCompareIsJump == 0)
                            {

                                SendUIMsg(UIMsg.Close);

                                SendUIMsg(DirCompareUIMsg.suspendAutoMatchThread);

                                if (this._SelectValueParameter != null)
                                {
                                    item_code = this._SelectValueParameter.Name;
                                    item_name = this._SelectValueParameter.Value;
                                    model_name = string.Empty;
                                    medi_item_type = this._SelectValueParameter.Object.ToString();

                                    Dealmedi_item_type(ref medi_item_type);

                                    UpdateAddMatch(1, i, hosp_code, hosp_name, item_code, item_name, model_name, medi_item_type);
                                }

                                SendUIMsg(UIMsg.Display, "正在处理，请稍后......");
                            }
                        }
                        ds.Clear();
                        ds.Dispose();
                    }
                    else
                    {
                        SendUIMsg(UIMsg.WriteMsg, "这条记录在中心目录字典中没有任何对应的记录！！！");
                    }
                }

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "自动匹配医院目录发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitAddMatch_Click(object sender, EventArgs e)
        {
            CreateAndStartThread(this._threadInitAddMatch, ThreadInitAddMatch);
        }

        /// <summary>
        /// 初始化新增医院目录匹配线程
        /// </summary>
        private void ThreadInitAddMatch()
        {
            SendUIMsg("disablebtnInitAddMatch");

            InitAddMatch();
            QueryAddMatchInfo();
            UpdateHospitalJPM();

            SendUIMsg("enablebtnInitAddMatch");
        }

        /// <summary>
        /// 初始化医院目录匹配信息
        /// </summary>
        private void InitAddMatch()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在初始化新增医院目录匹配，请稍后......");

                IDataParameter[] parameters = new IDataParameter[2];

                parameters[0] = new SqlParameter("@CenterID", baseInterfaceHN.Oper_centerid);
                parameters[1] = new SqlParameter("@HospitalID", baseInterfaceHN.Oper_hospitalid);

                Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_InitMatch", parameters, "InitMatch");

                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgInfo, "初始化新增医院目录匹配成功！！！");

            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "始化新增医院目录匹配失败，失败原因:" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void BindGetAllInterfaceDir()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在检索字典，请稍后......");

                IDataParameter[] parameters = new IDataParameter[1];
                string name = _keyWords;


                parameters[0] = new SqlParameter("@Name", name);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_GetAllInterfaceDir", parameters, "GetAllInterfaceDir");

                SendUIMsg(DirCompareUIMsg.c1FlexGridInterfaceJCDataSource, ds);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "获取所有中心基础目录字典发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadQueryDir()
        {

            CreateAndStartThread(this._threadQueryDir, GetAllInterfaceDir);
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetAllInterfaceDir()
        {
            SendUIMsg(DirCompareUIMsg.disableQueryDic);

            BindGetAllInterfaceDir();

            SendUIMsg(DirCompareUIMsg.enableQueryDir);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryJC_Click(object sender, EventArgs e)
        {
            this._keyWords = this.txtBoxKeyWords.Text.Trim();

            ThreadQueryDir();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            CreateAndStartThread(this._thread, ThreadUpload);
        }

        /// <summary>
        /// 上传线程
        /// </summary>
        private void ThreadUpload() {
            SendUIMsg(DirCompareUIMsg.DisabledUploadButton);

            UploadAddMatchToCenter();

            SendUIMsg(DirCompareUIMsg.EnabledUploadButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UploadAddMatchToCenter()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从HIS服务器获取要上传的新增目录匹配信息，请稍后......");

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query("EXEC HIS_InterfaceHN.dbo.P_UploadMatchToCenter");

                InterfaceClass.HN.HosDirManage.AddHospitalDirMatch addHospitalDirMatch = new InterfaceClass.HN.HosDirManage.AddHospitalDirMatch(baseInterfaceHN);

                List<InterfaceClass.HN.HosDirManage.InsertInfo> listInsertInfo = GetListIntsertInfoFromDataSet(ds);

                SendUIMsg(UIMsg.WriteMsg, "正在往中心服务器上传新增目录匹配信息，请稍后......");

                List<InterfaceClass.HN.HosDirManage.Effectdetail> listEffectdetail = addHospitalDirMatch.AddHISMatchToCenter(listInsertInfo);


                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "上传新增目录匹配信息到中心发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private List<InterfaceClass.HN.HosDirManage.InsertInfo> GetListIntsertInfoFromDataSet(DataSet ds)
        {
            List<InterfaceClass.HN.HosDirManage.InsertInfo> listHosDirManage=new List<InterfaceClass.HN.HosDirManage.InsertInfo>();

            int i = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i++;

                if (i > 1)
                {
                    break;
                }

                InterfaceClass.HN.HosDirManage.InsertInfo insertInfo=new InterfaceClass.HN.HosDirManage.InsertInfo();

                List<Parameter> listParameter = GetProperties<InterfaceClass.HN.HosDirManage.InsertInfo>(insertInfo);

                foreach(Parameter p in listParameter)
                {
                    string value = dr[p.Name].ToString().Trim();

                    insertInfo.SetAttributeValue(p.Name, value);
                }

                listHosDirManage.Add(insertInfo);
            }

            return listHosDirManage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            CreateAndStartThread(this._thread, ThreadDownload);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ThreadDownload(){
            SendUIMsg(DirCompareUIMsg.DisabledUploadButton);

            Download();

            SendUIMsg(DirCompareUIMsg.EnabledDownloadButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Download()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器下载医院目录审核通过匹配信息，请稍后......");

                InterfaceClass.HN.HosDirManage.GetHospitalDirMatchedInfo getHospitalDirMatchedInfo = new InterfaceClass.HN.HosDirManage.GetHospitalDirMatchedInfo(baseInterfaceHN);

                InterfaceClass.HN.HosDirManage.MatchedOutParameter matchedOutParameter = getHospitalDirMatchedInfo.GetHospitalDirMatchedPageInfo(baseInterfaceHN.Oper_centerid,
                    "version", "bs_catalog_match", "1", "1", "10", "1", "1000000");

                matchedOutParameter = getHospitalDirMatchedInfo.GetHospitalDirMatchedPageInfo(baseInterfaceHN.Oper_centerid,
                    "version", "bs_catalog_match", "1", "1", matchedOutParameter.Count, "1", "1000000");

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgError, "下载医院目录审核通过匹配信息发送错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void UpdateUIControlContext(object context)
        {
            try
            {
                base.UpdateUIControlContext(context);

                Parameter parameter = (Parameter)context;

                switch (parameter.Name)
                {
                    case DirCompareUIMsg.disablebtnInitAddMatch:
                        this.btnInitAddMatch.Enabled = false;
                        break;
                    case DirCompareUIMsg.enablebtnInitAddMatch:
                        this.btnInitAddMatch.Enabled = true;
                        break;
                    case DirCompareUIMsg.c1FlexGridInterfaceJCDataSource:
                        this.c1FlexGridInterfaceJC.DataSource = ((DataSet)parameter.Object).Tables[0];

                        this.c1FlexGridInterfaceJC.Cols["item_name"].Width = 170;
                        this.c1FlexGridInterfaceJC.Cols["medi_item_type"].Width = 55;
                        this.c1FlexGridInterfaceJC.Cols["price"].Width = 35;
                        this.c1FlexGridInterfaceJC.Cols["ID"].Visible = false;
                        this.c1FlexGridInterfaceJC.Cols["item_name"].Caption = "名称";
                        this.c1FlexGridInterfaceJC.Cols["medi_item_type"].Caption = "匹配类别";
                        this.c1FlexGridInterfaceJC.Cols["price"].Caption = "价格";
                        break;
                    case DirCompareUIMsg.c1FlexGridAddMatchDataSource:
                        this.c1FlexGridAddMatch.DataSource = ((DataSet)parameter.Object).Tables["AddMatch"];

                        SetC1FlexGridColumnsInfo(this.c1FlexGridAddMatch);
                        SetDirCompareMainInfo((DataSet)parameter.Object);
                        SetC1FlexGridRowBackGroundColor();
                        break;
                    case DirCompareUIMsg.disableBtnAutoMatch:
                        this.btnAutoMatch.Enabled = false;
                        break;
                    case DirCompareUIMsg.enableBtnAutoMatch:
                        this.btnAutoMatch.Enabled = true;
                        break;
                    case DirCompareUIMsg.openSelectDirCompareForm:
                        OpenSelectDirCompareForm();
                        break;
                    case DirCompareUIMsg.suspendAutoMatchThread:
                        SuspendAutoMatchThread();
                        break;
                    case DirCompareUIMsg.enableQueryDir:
                        this.btnQueryJC.Enabled = true;
                        break;
                    case DirCompareUIMsg.disableQueryDic:
                        this.btnQueryJC.Enabled = false;
                        break;
                    case DirCompareUIMsg.enableInitDir:
                        this.btnInitDir.Enabled = true;
                        break;
                    case DirCompareUIMsg.disableInitDir:
                        this.btnInitDir.Enabled = false;
                        break;
                    case DirCompareUIMsg.DisabledUploadButton:
                        this.btnUpload.Enabled = false;
                        break;
                    case DirCompareUIMsg.EnabledUploadButton:
                        this.btnUpload.Enabled = true;
                        break;
                    case DirCompareUIMsg.EnabledDownloadButton:
                        this.btnDownload.Enabled = true;
                        break;
                    case DirCompareUIMsg.DisabledDownloadButton:
                        this.btnDownload.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SuspendAutoMatchThread()
        {
            if (this._thread != null)
            {
                this._thread.Suspend();

                OpenSelectDirCompareForm();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenSelectDirCompareForm()
        {
            Frm_SelectDirCompare frm = new Frm_SelectDirCompare(this._addMatchID, this._medi_item_type);

            frm.ShowDialog();

            this._SelectValueParameter = frm.SelectValueParemeter;

            frm = null;

            if (this._thread != null)
            {
                this._thread.Resume();
            }
        }

        /// <summary>
        /// 目录对照消息类
        /// </summary>
        public class DirCompareUIMsg
        {
            public const string disablebtnInitAddMatch = "disablebtnInitAddMatch";
            public const string enablebtnInitAddMatch = "enablebtnInitAddMatch";
            public const string c1FlexGridInterfaceJCDataSource = "c1FlexGridInterfaceJCDataSource";
            public const string c1FlexGridAddMatchDataSource = "c1FlexGridAddMatchDataSource";
            public const string disableBtnAutoMatch = "disableBtnAutoMatch";
            public const string enableBtnAutoMatch = "enableBtnAutoMatch";
            public const string openSelectDirCompareForm = "openSelectDirCompareForm";
            public const string suspendAutoMatchThread = "suspendAutoMatchThread";
            public const string disableQueryDic = "diableQueryDic";
            public const string enableQueryDir = "enableQueryDir";
            public const string enableInitDir = "enableInitDir";
            public const string disableInitDir = "disableInitDir";
            public const string EnabledUploadButton = "EnabledUploadButton";
            public const string DisabledUploadButton = "DisabledUploadButton";
            public const string EnabledDownloadButton = "EnabledDownloadButton";
            public const string DisabledDownloadButton = "DisabledDownloadButton";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridAddMatch_SelChange(object sender, EventArgs e)
        {
            this._selectedC1FlexGridAddMatchRowIndex = this.c1FlexGridAddMatch.MouseRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridAddMatch_MouseClick(object sender, MouseEventArgs e)
        {
            if (this._selectedC1FlexGridAddMatchRowIndex > 0)
            {
                string match_type = this.c1FlexGridAddMatch.Rows[this._selectedC1FlexGridAddMatchRowIndex]["match_type"].ToString().Trim();
                string hosp_name = this.c1FlexGridAddMatch.Rows[this._selectedC1FlexGridAddMatchRowIndex]["hosp_name"].ToString().Trim();

                this.txtBoxKeyWords.Text = hosp_name;

                this.btnQueryJC.PerformClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitDir_Click(object sender, EventArgs e)
        {
            CreateAndStartThread(this._threadInitDir, ThreadInitDir);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadInitDir()
        {
            SendUIMsg(DirCompareUIMsg.disableInitDir);

            InitInterfaceDir();

            SendUIMsg(DirCompareUIMsg.enableInitDir);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCompare_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("你真的要清除已对照标志吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (dr == DialogResult.Yes)
            {
                string SQLString = string.Format(@"UPDATE  HIS_InterfaceHN.dbo.Interface_AddMatch
                                                    SET     CompareStatus = 2");

                try
                {
                    int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                    if (temp > 0)
                    {
                        CommonFunctions.MsgInfo("清除已对照记录成功，清除已对照记录" + temp + "条！！！");
                        return;
                    }
                    CommonFunctions.MsgError("没有清除任何已对照记录，请查看是否存在医院目录匹配信息！！！");
                }
                catch (Exception ex)
                {
                    CommonFunctions.MsgError("清除已对照标志发生错误，错误原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxKeyWords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnQueryJC.PerformClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxAuditFlag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxStaple_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel文件|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DisplayTips("正在导出新增医院目录匹配信息......");

                    string fileName = sfd.FileName;

                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName += ".xls";
                    }

                    this.c1FlexGridAddMatch.SaveGrid(fileName, FileFormatEnum.Excel, FileFlags.IncludeFixedCells);

                    CloseTips();

                    CommonFunctions.MsgInfo("文件" + fileName + "导出成功！！！");
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("导出新增医院目录匹配信息失败，失败原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridInterfaceJC_SelChange(object sender, EventArgs e)
        {
            this._selectedC1FlexGridJCCenterDirRowIndex = this.c1FlexGridInterfaceJC.MouseRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridInterfaceJC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._selectedC1FlexGridAddMatchRowIndex > 0 && this._selectedC1FlexGridJCCenterDirRowIndex > 0)
            {
                string addMatchID = this.c1FlexGridAddMatch.Rows[this._selectedC1FlexGridAddMatchRowIndex]["ID"].ToString().Trim();
                string jcDirID = this.c1FlexGridInterfaceJC.Rows[this._selectedC1FlexGridJCCenterDirRowIndex]["ID"].ToString().Trim();
                string compareStatus = this.c1FlexGridAddMatch.Rows[this._selectedC1FlexGridAddMatchRowIndex]["CompareStatus"].ToString().Trim();
                string uploadStatus = this.c1FlexGridAddMatch.Rows[this._selectedC1FlexGridAddMatchRowIndex]["UploadStatus"].ToString().Trim();

                if ("已对照" == compareStatus && "已上传" == uploadStatus)
                {
                    return;
                }

                if ("已对照" == compareStatus)
                {
                    DialogResult dr = MessageBox.Show("你真的要更新这条已对照的匹配信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                    if (dr != DialogResult.Yes)
                    {
                        return;
                    }
                }

                try
                {
                    DisplayTips("正在更新新增医院目录匹配信息，请稍后......");

                    IDataParameter[] parameters = new IDataParameter[2];

                    parameters[0] = new SqlParameter("@addMatchID", addMatchID);
                    parameters[1] = new SqlParameter("@CenterDirID", jcDirID);

                    Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_UpdateAddMatch", parameters, "P_UpdateAddMatch");

                    CloseTips();

                    CommonFunctions.MsgInfo("正在更新新增医院目录匹配信息成功！！！");

                    this.btnQueryData.PerformClick();
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("更新新增医院目录匹配信息错误，错误原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxAddMatchItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnQueryData.PerformClick();
            }
        }
    }
}