using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceClass;

namespace Windows
{
    public class BaseForm : Form
    {
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
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BaseForm";
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

            DataRow dr=dt.NewRow();

            dr["内容"]="无数据，请通过条件检索数据......";

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
        public DataColumn GetDataColumn(string columnName, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.Caption = caption;

            return dc;
        }
    }
}