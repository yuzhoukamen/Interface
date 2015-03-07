using InterfaceClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class Frm_Main : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Frm_Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.btnCheck.Enabled = false;

            string name = this.txtBoxName.Text.Trim();

            this.richBoxResult.AppendText(IDCard.GetInstance(name).AllInfo() + "\n");
            this.pictureBoxPerson.ImageLocation = System.IO.Path.Combine(Application.StartupPath, "idc_ph.bmp");

            this.richBoxResult.Focus();
            this.richBoxResult.Select(this.richBoxResult.TextLength, 0);

            this.btnCheck.Enabled = true;
        }
    }
}