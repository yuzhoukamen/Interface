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
    public partial class Frm_InterfaceFuncAdd : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Frm_InterfaceFuncAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = this.txtBoxID.Text.Trim();
            string name = this.txtBoxName.Text.Trim();

            if (string.Empty == id)
            {
                CommonFunctions.MsgInfo("接口函数编码不能为空！！！");

                this.txtBoxID.Focus();

                return;
            }
            if (string.Empty == name)
            {
                CommonFunctions.MsgInfo("接口函数名称不能为空！！！");

                this.txtBoxName.Focus();

                return;
            }
            try
            {
                string SQLString = string.Empty;

                SQLString = string.Format(@"IF EXISTS ( SELECT  *
                                                FROM    HIS_InterfaceHN.dbo.Func
                                                WHERE   FuncID = '{0}' AND Name='{1}' )
                                        BEGIN
                                            RAISERROR('已经存在对应编号和名称的接口编码！！！',16,1);
                                        END
                                    ELSE
                                        BEGIN
                                            INSERT  INTO HIS_InterfaceHN.dbo.Func
                                                    ( FuncID ,
                                                        Name ,
                                                        Details
		                                            )
                                            VALUES  ( N'{0}' , -- ID - nvarchar(50)
                                                        N'{1}' , -- Name - nvarchar(50)
                                                        N''  -- Details - nvarchar(512)
		                                            )
                                        END", id, name);

                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                CommonFunctions.MsgInfo("添加成功！！！");

                this.txtBoxID.Clear();
                this.txtBoxName.Clear();

                this.txtBoxID.Focus();
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("添加接口函数失败失败原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_InterfaceFuncAdd_Shown(object sender, EventArgs e)
        {
            this.txtBoxID.Focus();
        }
    }
}