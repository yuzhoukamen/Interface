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
    public partial class Frm_Validata : BaseForm
    {
        public bool _isValidata = false;

        public Frm_Validata()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string passwd = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();

            if (this.txtBoxPasswd.Text.Trim() == passwd)
            {
                this._isValidata = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("密码输入错误！！！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.txtBoxPasswd.Clear();
                this.txtBoxPasswd.Focus();
            }
        }
    }
}