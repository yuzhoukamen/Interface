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
    public partial class Frm_Interface : BaseForm
    {
        public Frm_Interface(long userID)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Interface_Load(object sender, EventArgs e)
        {
            InitFormInfo(this);

            this.menuStripInterface.Renderer = new Class.MyMenuRender();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemInterfaceFunc_Click(object sender, EventArgs e)
        {
            Frm_InterfaceFunc frm = new Frm_InterfaceFunc();

            AddFormToPanelInterface(frm);
        }

        private void ToolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            Frm_Main frm = new Frm_Main(71);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            this.lblCurrentTime.Text = string.Format("当前时间：{0}", dateTime.ToString());
        }

        private void AddFormToPanelInterface(Form frm)
        {
            Frm_Tips frm_tips = new Frm_Tips();

            frm_tips.Show();
            Application.DoEvents();

            this.panelInterface.Controls.Clear();

            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;

            frm.Dock = DockStyle.Fill;

            this.panelInterface.Controls.Add(frm);

            frm.Show();

            frm_tips.Close();
        }
    }
}
