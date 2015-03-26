using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows
{
    public class BaseForm : Form
    {
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
    }
}