using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InterfaceClass;

namespace Windows
{
    public class BaseForm : Form
    {
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
        /// 设置选择模式
        /// </summary>
        /// <param name="flexGrid"></param>
        /// <param name="selectionMode"></param>
        public void SetC1FlexGridSelectionMode(C1.Win.C1FlexGrid.C1FlexGrid flexGrid, C1.Win.C1FlexGrid.SelectionModeEnum selectionMode)
        {
            flexGrid.SelectionMode = selectionMode;
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
    }
}