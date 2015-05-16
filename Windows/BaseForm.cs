using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InterfaceClass;
using Windows.Class;
using System.ComponentModel;

namespace Windows
{
    /// <summary>
    /// 基类
    /// </summary>
    public class BaseForm : Form
    {
        #region 属性

        /// <summary>
        /// 个人电脑号
        /// </summary>
        public string Indi_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WebBrowser _webBrowserPrint = new WebBrowser();

        /// <summary>
        /// 用户编号
        /// </summary>
        public long _userID = 0;

        public string _unitName = string.Empty;
        public string _userName = string.Empty;

        /// <summary>
        /// 目录对照是否跳过多个记录自动匹配(0:不跳过 1：跳过)
        /// </summary>
        public int DirAutoCompareIsJump = 0;

        /// <summary>
        /// 
        /// </summary>
        public SynchronizationContext _SynchronizationContext = null;

        /// <summary>
        /// 
        /// </summary>
        private Image m_Image = null;

        /// <summary>
        /// 
        /// </summary>
        private EventHandler evtHandler = null;

        /// <summary>
        /// 
        /// </summary>
        private Frm_Tips _frmTips = null;

        /// <summary>
        /// 
        /// </summary>
        public Frm_Tips FormTips
        {
            get { return this._frmTips; }
            set { this._frmTips = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static InterfaceClass.InterfaceHN baseInterfaceHN = null;

        #endregion

        #region 应用和窗体设置

        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(801, 286);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 设置应用程序图标
        /// </summary>
        /// <param name="frm"></param>
        public void SetApplicationIco(Form frm)
        {
            frm.Icon = CommonFunctions.ApplicationIcon();
        }

        /// <summary>
        /// 应用程序信息
        /// </summary>
        /// <returns></returns>
        public string AppInfo()
        {
            try
            {
                return Alif.DBUtility.PubConstant.GetKeyValue("AppInfo");
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("获取应用程序信息失败，失败原因：" + e.Message);

                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AppTitle()
        {
            try
            {
                return Alif.DBUtility.PubConstant.GetKeyValue("AppTitle");
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("获取应用程序标题失败，失败原因：" + e.Message);

                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        public void InitFormInfo(Form frm)
        {
            SetApplicationIco(frm);

            frm.Text = AppInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetDebug()
        {
            int value = 0;
            try
            {
                string filePath = System.IO.Path.Combine(Application.StartupPath, "log/" + DateTime.Now.ToString("yy-MM-dd"));

                if ((!System.IO.Directory.Exists(filePath)))
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }

                value = baseInterfaceHN.SetDebug(filePath);
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("设置调试模式出错，错误原因：" + e.Message);
            }
            if (value < 0)
            {
                CommonFunctions.MsgError("设置调试模式失败！！！");
            }
        }

        #endregion

        #region 操作C1FlexGrid控件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flexGrid"></param>
        public void BindC1FlexGridDisplayLineNumbers(C1.Win.C1FlexGrid.C1FlexGrid flexGrid)
        {
            flexGrid.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;

            flexGrid.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(
                delegate(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
                {
                    if (e.Row >= flexGrid.Rows.Fixed)
                    {
                        // 添加行号
                        flexGrid.Rows[e.Row][0] = e.Row - flexGrid.Rows.Fixed + 1;
                    }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flexGrid"></param>
        /// <param name="allowEditing"></param>
        public void SetC1FlexGridAttribute(C1.Win.C1FlexGrid.C1FlexGrid flexGrid, bool allowEditing)
        {
            flexGrid.AllowEditing = allowEditing;
        }

        /// <summary>
        /// 设置C1FlexGrid默认属性
        /// </summary>
        /// <param name="flexGrid">要设置的FlexGrid</param>
        public void SetC1FlexGridDefaultAttribute(C1.Win.C1FlexGrid.C1FlexGrid flexGrid)
        {
            SetC1FlexGridAttribute(flexGrid, false);
            SetC1FlexGridSelectionMode(flexGrid, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(flexGrid);
            SetC1FlexGridNullDataTable(flexGrid);
        }

        /// <summary>
        /// 设置C1FlexGrid默认属性
        /// </summary>
        /// <param name="flexGrid"></param>
        /// <param name="msg"></param>
        public void SetC1FlexGridDefaultAttribute(C1.Win.C1FlexGrid.C1FlexGrid flexGrid, string msg)
        {
            SetC1FlexGridAttribute(flexGrid, false);
            SetC1FlexGridSelectionMode(flexGrid, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(flexGrid);
            SetC1FlexGridNullDataTable(flexGrid, msg);
        }

        /// <summary>
        /// 设置选择模式
        /// </summary>
        /// <param name="flexGrid"></param>
        /// <param name="selectionMode"></param>
        public void SetC1FlexGridSelectionMode(C1.Win.C1FlexGrid.C1FlexGrid flexGrid, C1.Win.C1FlexGrid.SelectionModeEnum selectionMode)
        {
            flexGrid.SelectionMode = selectionMode;
        }

        /// <summary>
        /// 空表格
        /// </summary>
        /// <param name="flexGrid"></param>
        public void SetC1FlexGridNullDataTable(C1.Win.C1FlexGrid.C1FlexGrid flexGrid)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("内容");

            DataRow dr = dt.NewRow();

            dr["内容"] = "无数据，请通过条件检索数据......";

            dt.Rows.Add(dr);

            flexGrid.DataSource = dt;
            flexGrid.Cols["内容"].Width = flexGrid.Width;
        }

        /// <summary>
        /// 空表格
        /// </summary>
        /// <param name="flexGrid"></param>
        /// <param name="msg">填写的内容</param>
        public void SetC1FlexGridNullDataTable(C1.Win.C1FlexGrid.C1FlexGrid flexGrid, string msg)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("内容");

            DataRow dr = dt.NewRow();

            dr["内容"] = msg;

            dt.Rows.Add(dr);

            flexGrid.DataSource = dt;
            flexGrid.Cols["内容"].Width = flexGrid.Width;
        }

        #endregion

        #region 动画操作

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_Image != null)
            {

                //获得当前gif动画下一步要渲染的帧。

                UpdateImage();

                //将获得的当前gif动画需要渲染的帧显示在界面上的某个位置。

                e.Graphics.DrawImage(m_Image, new Rectangle(5, 5, m_Image.Width, m_Image.Height));

            }
        }

        /// <summary>
        /// 开始动画方法
        /// </summary>
        private void BeginAnimate()
        {

            if (m_Image != null)
            {

                //当gif动画每隔一定时间后，都会变换一帧，那么就会触发一事件，该方法就是将当前image每变换一帧时，都会调用当前这个委托所关联的方法。

                ImageAnimator.Animate(m_Image, evtHandler);

            }

        }

        /// <summary>
        /// 委托所关联的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnImageAnimate(Object sender, EventArgs e)
        {

            //该方法中，只是使得当前这个winfor重绘，然后去调用该winform的OnPaint（）方法进行重绘)

            this.Invalidate();

        }

        /// <summary>
        /// 获得当前gif动画的下一步需要渲染的帧，当下一步任何对当前gif动画的操作都是对该帧进行操作)
        /// </summary>
        private void UpdateImage()
        {

            ImageAnimator.UpdateFrames(m_Image);

        }

        /// <summary>
        /// 关闭显示动画，该方法可以在winform关闭时，或者某个按钮的触发事件中进行调用，以停止渲染当前gif动画。
        /// </summary>
        private void StopAnimate()
        {

            m_Image = null;

            ImageAnimator.StopAnimate(m_Image, evtHandler);

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            BindInitTips();
        }

        /// <summary>
        /// 绑定初始化信息
        /// </summary>
        private void BindInitTips()
        {
            //为委托关联一个处理方法

            evtHandler = new EventHandler(OnImageAnimate);

            //获取要加载的gif动画文件

            m_Image = Image.FromFile(Application.StartupPath + "\\Pictures\\tips.gif");

            //调用开始动画方法

            BeginAnimate();
        }

        #endregion

        #region 初始化下拉列表

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cBox"></param>
        /// <param name="comboBoxDisplayMember"></param>
        /// <param name="comboBoxValueMember"></param>
        /// <param name="sql"></param>
        public void InitComboBox(ComboBox cBox, string comboBoxDisplayMember, string comboBoxValueMember, string sql, bool noAll)
        {
            try
            {
                if (!noAll)
                {
                    sql += string.Format(@" UNION ALL
                                        SELECT  '-1' ,
                                                N'全部'
                                                ORDER BY Value ");

                }

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(sql);

                cBox.DataSource = ds.Tables[0];

                cBox.DisplayMember = comboBoxDisplayMember;
                cBox.ValueMember = comboBoxValueMember;
            }
            catch (Exception e)
            {
                throw new Exception("绑定" + cBox.Name + "ComboBox发生错误，错误原因：" + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cBox"></param>
        /// <param name="sql"></param>
        public void InitComboBox(ComboBox cBox, string sql)
        {
            InitComboBox(cBox, "Name", "Value", sql, false);
        }

        #endregion

        #region 向UI线程发送消息

        /// <summary>
        /// 
        /// </summary>
        public void DisplayTips()
        {
            DisplayTips("正在处理，请稍后......");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void DisplayTips(string msg)
        {
            try
            {
                if (this.FormTips == null || this.FormTips.IsDisposed)
                {
                    this.FormTips = null;
                    this.FormTips = new Frm_Tips();
                }

                this.FormTips.StartPosition = FormStartPosition.CenterScreen;
                this.FormTips.WriteMsg(msg);

                this.FormTips.Show();
                Application.DoEvents();
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void WriteTips(string msg)
        {
            this.FormTips.WriteMsg(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseTips()
        {
            try
            {
                this.FormTips.Close();
            }
            catch
            { }
        }

        /// <summary>
        /// 更新UI控件中的内容
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="context"></param>
        public virtual void UpdateUIControlContext(object context)
        {
            Parameter parameter = (Parameter)context;

            if (parameter.Object == null)
            {
                switch (parameter.Name)
                {
                    case UIMsg.Close:
                        CloseTips();
                        break;
                    case UIMsg.Display:
                        DisplayTips(parameter.Value);
                        break;
                    case UIMsg.MsgError:
                        CommonFunctions.MsgError(parameter.Value);
                        break;
                    case UIMsg.MsgInfo:
                        CommonFunctions.MsgInfo(parameter.Value);
                        break;
                    case UIMsg.WriteMsg:
                        WriteTips(parameter.Value);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public virtual void SendUIMsg(object context)
        {
            this._SynchronizationContext.Send(UpdateUIControlContext, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public virtual void SendUIMsg(string name, string value)
        {
            Parameter parameter = new Parameter(name, value);

            SendUIMsg(parameter);
        }

        public virtual void SendUIMsg(string name, object obj)
        {
            Parameter parameter = new Parameter(name, obj);

            SendUIMsg(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public virtual void SendUIMsg(string name)
        {
            SendUIMsg(name, string.Empty);
        }

        #endregion

        #region 创建和开始线程

        /// <summary>
        /// 线程委托
        /// </summary>
        public delegate void ThreadDelegate();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        /// <param name="threadDelegate"></param>
        public virtual void CreateAndStartThread(ref Thread thread, ThreadDelegate threadDelegate)
        {
            if (thread == null)
            {
                thread = new Thread(new ThreadStart(threadDelegate));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        /// <param name="threadDelegate"></param>
        public virtual void CreateAndStartThread(Thread thread, ThreadDelegate threadDelegate)
        {
            if (thread == null)
            {
                thread = new Thread(new ThreadStart(threadDelegate));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        #endregion

        #region 获取对象和对象转换成DataTable

        /// <summary>
        /// 返回数据列
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public DataColumn AddDataColumn(string columnName, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.Caption = caption;

            return dc;
        }

        /// <summary>
        /// 获取表格的数据列
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public DataColumn GetColumn(string name, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = name;
            dc.Caption = caption;

            return dc;
        }

        /// <summary>
        /// 获取对象的属性名称、值和描述
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns>对象列表</returns>
        public List<Parameter> GetProperties<T>(T t)
        {
            List<Parameter> list = new List<Parameter>();

            if (t == null)
            {
                return list;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return list;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name; //名称
                object value = item.GetValue(t, null);  //值
                string des = ((DescriptionAttribute)Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute))).Description;// 属性值

                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    Parameter parameter = new Parameter();

                    parameter.Name = name;
                    parameter.Value = value == null ? string.Empty : value.ToString();
                    parameter.Object = des;

                    list.Add(parameter);
                }
                else
                {
                    GetProperties(value);
                }
            }
            return list;
        }

        /// <summary>
        /// 类型对象生成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public DataTable TToDataTable<T>(T obj, List<T> listT)
        {
            DataTable dt = new DataTable();

            int flag = 0;

            if (listT != null)
            {
                foreach (T t in listT)
                {
                    List<Parameter> listProperty = GetProperties<T>(t);

                    if (flag <= 0)
                    {
                        foreach (Parameter parameter in listProperty)
                        {
                            flag++;

                            dt.Columns.Add(GetColumn(parameter.Name, parameter.Object.ToString()));
                        }
                    }

                    DataRow dr = dt.NewRow();

                    foreach (Parameter parameter in listProperty)
                    {
                        dr[parameter.Name] = parameter.Value;
                    }

                    dt.Rows.Add(dr);
                }
            }
            else
            {
                List<Parameter> listProperty = GetProperties<T>(obj);

                foreach (Parameter parameter in listProperty)
                {
                    dt.Columns.Add(GetColumn(parameter.Name, parameter.Object.ToString()));
                }

                DataRow dr = dt.NewRow();

                foreach (Parameter parameter in listProperty)
                {
                    dr[parameter.Name] = parameter.Value;
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataTable TToDataTable<T>(T obj)
        {
            return TToDataTable<T>(obj, null);
        }

        /// <summary>
        /// 类型对象生成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listT"></param>
        /// <returns></returns>
        public DataTable TToDataTable<T>(List<T> listT)
        {
            return TToDataTable<T>(default(T), listT);
        }

        /// <summary>
        /// 生成参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Parameter GetParameter(string name, string value)
        {
            Parameter parameter = new Parameter();

            parameter.Name = name;
            parameter.Value = value;

            return parameter;
        }

        #endregion

        #region 查询和设置用户信息

        /// <summary>
        /// 获取医保中中心名称
        /// </summary>
        /// <param name="centerID"></param>
        /// <returns></returns>
        public string GetCenterName(string centerID)
        {
            try
            {
                string SQLString = string.Format(@"SELECT  ID ,
                                                                Name
                                                        FROM    HIS_InterfaceHN.dbo.JC_Center
                                                        WHERE   ID = N'{0}'", centerID);

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                return ds.Tables[0].Rows[0]["Name"].ToString().Trim();


            }
            catch (Exception ex)
            {
                throw new Exception("通过医保中心编号" + centerID + "获取医保中中心名称发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取医疗机构名称
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        public string GetHospitalName(string hospitalID)
        {
            try
            {
                string SQLString = string.Format(@"SELECT  ID ,
                                                                Name
                                                        FROM    HIS_InterfaceHN.dbo.JC_Hospital
                                                        WHERE   ID = N'{0}'", hospitalID);

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                return ds.Tables[0].Rows[0]["Name"].ToString().Trim();


            }
            catch (Exception ex)
            {
                throw new Exception("通过医疗机构编码" + hospitalID + "获取医疗机构名称发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 查询和设置用户信息
        /// </summary>
        public virtual void QueryAndSetUserInfo(long userID, ref string unitName, ref string userName)
        {
            string SQLString = string.Format(@"SELECT  UnitName ,
                                                        UserName
                                                FROM    alfHospital.dbo.TbMedicalPersonInfo
                                                        INNER JOIN alfHospital.dbo.TbUnitInfo ON alfHospital.dbo.TbUnitInfo.UnitID = alfHospital.dbo.TbMedicalPersonInfo.UnitID
                                                WHERE   ID = {0}", userID);

            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                unitName = string.Format("{0}", ds.Tables[0].Rows[0]["UnitName"].ToString().Trim());

                userName = string.Format("{0}", ds.Tables[0].Rows[0]["UserName"].ToString().Trim());
            }
            catch (Exception e)
            {
                throw new Exception("获取用户信息失败，失败原因：" + e.Message);
            }
        }

        /// <summary>
        /// 查询和设置用户信息
        /// </summary>
        public void QueryAndSetUserInfo(ref string unitName, ref string userName)
        {
            string SQLString = string.Format(@"SELECT  UnitName ,
                                                        UserName
                                                FROM    alfHospital.dbo.TbMedicalPersonInfo
                                                        INNER JOIN alfHospital.dbo.TbUnitInfo ON alfHospital.dbo.TbUnitInfo.UnitID = alfHospital.dbo.TbMedicalPersonInfo.UnitID
                                                WHERE   ID = {0}", this._userID);

            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                unitName = string.Format("{0}", ds.Tables[0].Rows[0]["UnitName"].ToString().Trim());

                userName = string.Format("{0}", ds.Tables[0].Rows[0]["UserName"].ToString().Trim());
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("获取用户信息失败，失败原因：" + e.Message);
            }
        }

        /// <summary>
        /// 查询和设置用户信息
        /// </summary>
        public void QueryAndSetUserInfo()
        {
            string SQLString = string.Format(@"SELECT  UnitName ,
                                                        UserName
                                                FROM    alfHospital.dbo.TbMedicalPersonInfo
                                                        INNER JOIN alfHospital.dbo.TbUnitInfo ON alfHospital.dbo.TbUnitInfo.UnitID = alfHospital.dbo.TbMedicalPersonInfo.UnitID
                                                WHERE   ID = {0}", this._userID);

            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                this._unitName = string.Format("{0}", ds.Tables[0].Rows[0]["UnitName"].ToString().Trim());

                this._userName = string.Format("{0}", ds.Tables[0].Rows[0]["UserName"].ToString().Trim());
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("获取用户信息失败，失败原因：" + e.Message);
            }
        }

        #endregion

        #region 目录对照方法

        /// <summary>
        /// 设置目录对照是否自动跳跃
        /// </summary>
        public void SetDirAutoCompareIsJump()
        {
            try
            {
                string SQLString = string.Format(@"select CodeValue from HIS_InterfaceHN.dbo.Setup where Code='100001001'");

                this.DirAutoCompareIsJump = int.Parse(Alif.DBUtility.DbHelperSQL.Query(SQLString).Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
                CommonFunctions.MsgError("没有在HIS_InterfaceHN.dbo.Setup数据表中设置100001001(目录对照是否跳过多个记录自动匹配)记录!!!");
            }
        }

        #endregion

        #region 打印

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="dataSet"></param>
        /// <param name="errorInfo"></param>
        public void Print(string code, DataSet dataSet, string errorInfo)
        {
            Print(code, null, dataSet, errorInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="dataSet"></param>
        public void Print(string code, DataSet dataSet)
        {
            Print(code, dataSet, "请在HIS_InterfaceHN.dbo.Setup表中配置Code为100001003的普通门诊收费打印结算单编号！！！");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="listParameter"></param>
        /// <param name="dataSet"></param>
        public void Print(string code, List<Parameter> listParameter, DataSet dataSet)
        {
            Print(code, listParameter, dataSet, "请在HIS_InterfaceHN.dbo.Setup表中配置Code为100001003的普通门诊收费打印结算单编号！！！");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        /// <param name="listParameter"></param>
        /// <param name="dataSet"></param>
        /// <param name="errorInfo"></param>
        public void Print(string code, List<Parameter> listParameter, DataSet dataSet, string errorInfo)
        {
            Print(true, code, listParameter, dataSet, errorInfo);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        /// <param name="listParameter"></param>
        /// <param name="errorInfo"></param>
        public void Print(bool flag, string code, List<Parameter> listParameter, DataSet dataSet, string errorInfo)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat(@"SELECT  ID ,
                                        Name ,
                                        Style ,
                                        Html ,
                                        SQL ,
                                        PageSize ,
                                        Details
                                FROM    HIS_InterfaceHN.dbo.PrintHtml
                                WHERE   ID = ( SELECT   CodeValue
                                               FROM     HIS_InterfaceHN.dbo.Setup
                                               WHERE    Code = '{0}'
                                             )", code);

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(sb.ToString());

                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
                {

                    string html = ds.Tables[0].Rows[0]["Html"].ToString().Trim();
                    string sql = ds.Tables[0].Rows[0]["SQL"].ToString().Trim();
                    string pageSize = ds.Tables[0].Rows[0]["PageSize"].ToString().Trim();

                    sql = DealSql(sql, listParameter);

                    html = ExecuteSqlAndReplace(html, sql, dataSet);

                    ToPrintHtml(html, pageSize, flag);

                    return;
                }
                throw new Exception(errorInfo);
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html">要打印的Html</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="flag">是否打印预览</param>
        public void ToPrintHtml(string html, string pageSize, bool flag)
        {
            if (flag)
            {
                Frm_PrintHtml frm = new Frm_PrintHtml(html, pageSize);

                frm.ShowDialog();
                frm = null;
            }
            else
            {
                PrintHtml(html);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        public void PrintHtml(string html)
        {
            this._webBrowserPrint.DocumentText = html;

            this._webBrowserPrint.Print();
        }

        /// <summary>
        /// 执行sql语句，并且进行替换操作
        /// </summary>
        /// <param name="html"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteSqlAndReplace(string html, string sql, DataSet dataSet)
        {
            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(sql);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                    {
                        foreach (DataColumn dc in ds.Tables[i].Columns)
                        {
                            string columnName = dc.ColumnName;
                            string replaceHtml = string.Format("<!--^{0}^{1}^{2}^-->", i, j, columnName);
                            string replaceDisplayHtml = string.Format("<!--^Display^{0}^-->", j + 1);
                            string replaceValue = ds.Tables[i].Rows[j][columnName].ToString().Trim();

                            html = html.Replace(replaceHtml, replaceValue).Replace(replaceDisplayHtml, (j + 1).ToString());
                        }
                    }
                }

                ds.Clear();
                ds.Dispose();

                for (int i = 0; i < dataSet.Tables.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[i].Rows.Count; j++)
                    {
                        foreach (DataColumn dc in dataSet.Tables[i].Columns)
                        {
                            string columnName = dc.ColumnName;
                            string replaceHtml = string.Format("<!--^{0}^{1}^{2}^-->", i, j, columnName);
                            string replaceDisplayHtml = string.Format("<!--^Display^{0}^-->", j + 1);
                            string replaceValue = dataSet.Tables[i].Rows[j][columnName].ToString().Trim();

                            html = html.Replace(replaceHtml, replaceValue).Replace(replaceDisplayHtml, (j + 1).ToString());
                        }
                    }
                }

                return html;
            }
            catch (Exception ex)
            {
                throw new Exception("执行sql语句，并且进行替换操作的过程当中发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 处理sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="listParameter"></param>
        /// <returns></returns>
        public string DealSql(string sql, List<Parameter> listParameter)
        {
            try
            {
                if (listParameter != null)
                {
                    foreach (Parameter parameter in listParameter)
                    {
                        sql = sql.Replace("^" + parameter.Name + "^", parameter.Value);
                    }

                    return sql;
                }

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception("处理sql语句时发生错误，错误原因：" + ex.Message);
            }
        }

        #endregion

        #region 设置TextBox内容

        /// <summary>
        /// 清空TextBox内容
        /// </summary>
        /// <param name="containControl">包含的控件</param>
        /// <param name="prefix">前缀</param>
        /// <param name="listListParameter">对象参数列表</param>
        public void SetTextBoxText(System.Windows.Forms.Control containControl, string prefix, List<List<Parameter>> listListParameter)
        {
            foreach (System.Windows.Forms.Control control in containControl.Controls)
            {
                if (control is TextBox && control.Name.Contains(prefix))
                {
                    foreach (List<Parameter> listParameter in listListParameter)
                    {
                        foreach (Parameter p in listParameter)
                        {
                            if (control.Name == string.Format(prefix + p.Name))
                            {
                                control.Text = p.Value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 清空TextBox内容(默认TextBox的名称的前缀为"txtBox_")
        /// </summary>
        /// <param name="containControl">包含的控件</param>
        /// <param name="listListParameter">对象参数列表</param>
        public void SetTextBoxText(System.Windows.Forms.Control containControl, List<List<Parameter>> listListParameter)
        {
            SetTextBoxText(containControl, "txtBox_", listListParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containControl"></param>
        /// <param name="listParameter"></param>
        public void SetTextBoxText(System.Windows.Forms.Control containControl, List<Parameter> listParameter)
        {
            List<List<Parameter>> lisListParameter = new List<List<Parameter>>();

            lisListParameter.Add(listParameter);

            SetTextBoxText(containControl, "txtBox_", lisListParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containControl"></param>
        /// <param name="listParameter"></param>
        public void SetTextBoxText(System.Windows.Forms.Control containControl, string prefix, List<Parameter> listParameter)
        {
            List<List<Parameter>> lisListParameter = new List<List<Parameter>>();

            lisListParameter.Add(listParameter);

            SetTextBoxText(containControl, prefix, lisListParameter);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="containControl"></param>
        /// <param name="listListParameter"></param>
        public void GetTextBoxText(System.Windows.Forms.Control containControl, ref List<List<Parameter>> listListParameter)
        {
            GetTextBoxText(containControl, "txtBox_", ref listListParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containControl"></param>
        /// <param name="prefix"></param>
        /// <param name="listListParameter"></param>
        public void GetTextBoxText(System.Windows.Forms.Control containControl, string prefix, ref List<List<Parameter>> listListParameter)
        {
            foreach (System.Windows.Forms.Control control in containControl.Controls)
            {
                if (control is TextBox && control.Name.Contains(prefix))
                {
                    for (int i = 0; i < listListParameter.Count; i++)
                    {
                        List<Parameter> listParameter = listListParameter[i];

                        for (int j = 0; j < listParameter.Count; j++)
                        {
                            Parameter p = listParameter[j];

                            if (control.Name == string.Format(prefix + p.Name))
                            {
                                listListParameter[i][j].Value = control.Text.Trim();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置此控件里面包含的所有TextBox控件只读
        /// </summary>
        /// <param name="ctrl"></param>
        public virtual void SetTextBoxReadonly(System.Windows.Forms.Control containControl)
        {
            foreach (System.Windows.Forms.Control control in containControl.Controls)
            {
                if (control is TextBox)
                {
                    ((System.Windows.Forms.TextBox)control).ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 设置此控件里面所有前缀为prefix的TextBox只读
        /// </summary>
        /// <param name="containControl"></param>
        /// <param name="prefix"></param>
        public void SetTextBoxReadonly(System.Windows.Forms.Control containControl, string prefix)
        {
            foreach (System.Windows.Forms.Control control in containControl.Controls)
            {
                if (control is TextBox && control.Name.Contains(prefix))
                {
                    ((System.Windows.Forms.TextBox)control).ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containControl"></param>
        /// <param name="prefix"></param>
        /// <param name="listListParameter"></param>
        public void SetTextBoxReadonly(System.Windows.Forms.Control containControl, string prefix, List<List<Parameter>> listListParameter)
        {
            foreach (System.Windows.Forms.Control control in containControl.Controls)
            {
                if (control is TextBox && control.Name.Contains(prefix))
                {
                    foreach (List<Parameter> listParameter in listListParameter)
                    {
                        foreach (Parameter p in listParameter)
                        {
                            if (control.Name == string.Format(prefix + p.Name))
                            {
                                ((System.Windows.Forms.TextBox)control).ReadOnly = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containControl"></param>
        /// <param name="listListParameter"></param>
        public void SetTextBoxReadonly(System.Windows.Forms.Control containControl, List<List<Parameter>> listListParameter)
        {
            SetTextBoxReadonly(containControl, "txtBox_", listListParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containControl"></param>
        public void ClearTextBoxValue(System.Windows.Forms.Control containControl)
        {
            foreach (System.Windows.Forms.Control control in containControl.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }
        }
        #endregion

        #region 状态改变事件

        /// <summary>
        /// 
        /// </summary>
        public StatusEvent _statusEvent = new StatusEvent();

        /// <summary>
        /// 虚方法（状态改变事件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void StatusEvent_OnStatusChange(object sender, EventArgs e) { }

        /// <summary>
        /// 绑定状态改变事件
        /// </summary>
        public void BindStatusChangeEvents()
        {
            this._statusEvent.OnStatusChange += new StatusEvent.StatusChange(StatusEvent_OnStatusChange);
        }

        #endregion
    }
}