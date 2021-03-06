﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Windows
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_Login : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public Frm_Login()
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
        private void Frm_Login_Load(object sender, EventArgs e)
        {
            InitFormInfo(this);

            this.lblAppTitle.Text = AppTitle();
            SetApplicationIco(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxUnitID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtBoxUserID.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Login_Shown(object sender, EventArgs e)
        {
            this.txtBoxUnitID.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtBoxPasswd.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin.PerformClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string unitID = this.txtBoxUnitID.Text.Trim();
            string userID = this.txtBoxUserID.Text.Trim();
            string passwd = this.txtBoxPasswd.Text.Trim();

            if (unitID == string.Empty)
            {
                this.txtBoxUnitID.Clear();
                this.txtBoxUnitID.Focus();

                return;
            }

            if (userID == string.Empty)
            {
                this.txtBoxUserID.Clear();
                this.txtBoxUserID.Focus();

                return;
            }

            if (passwd == string.Empty)
            {
                this.txtBoxPasswd.Clear();
                this.txtBoxPasswd.Focus();

                return;
            }

            Login(unitID, userID, passwd);
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="userID"></param>
        /// <param name="passwd"></param>
        private void Login(string unitID, string userID, string passwd)
        {
            passwd = DEncrypt.DESEncrypt.Encrypt(passwd);

            long id = 0;

            try
            {
                IDataParameter[] parameter = new IDataParameter[3];

                parameter[0] = new SqlParameter("@UnitID", unitID);
                parameter[1] = new SqlParameter("@UserID", userID);
                parameter[2] = new SqlParameter("@UserPasswd", passwd);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_CheckUser", parameter, "P_CheckUser");

                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
                {
                    id = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString().Trim());
                }
                else
                {
                    throw new Exception(string.Empty);
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
                return;
            }

            try
            {
                this.Hide();

                Frm_Interface frm = new Frm_Interface(id);

                frm.ShowDialog();

                frm = null;

                this.Close();
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
                this.Close();
            }
        }
    }
}