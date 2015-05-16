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
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_PrintHtml : BaseForm
    {
        private string _Html = string.Empty;

        private string _PageSize = "580,410";

        /// <summary>
        /// 
        /// </summary>
        public Frm_PrintHtml(string html,string pageSize)
        {
            InitializeComponent();

            this._Html = html;
            this._PageSize = pageSize;

            ResizeThisForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        public Frm_PrintHtml(string html)
        {
            new Frm_PrintHtml(html, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResizeThisForm()
        {
            try
            {
                string[] strArray = this._PageSize.Replace("，", ",").Split(',');

                this.Width = int.Parse(strArray[0]);
                this.Height = int.Parse(strArray[1]);
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("重置打印窗体大小发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_PrintHtml_Load(object sender, EventArgs e)
        {
            this.webBrowserPrintHtml.DocumentText = this._Html;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.webBrowserPrintHtml.Print();
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print() {
            this.webBrowserPrintHtml.Print();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_PrintHtml_Shown(object sender, EventArgs e)
        {
            this.btnPrint.PerformClick();
        }
    }
}
