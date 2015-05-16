using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        StatusEvent vent = new StatusEvent();

        public Form1()
        {
            InitializeComponent();

            vent.OntempChange += new StatusEvent.tempChange(ven_OntempChange);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ven_OntempChange(object sender, EventArgs e)
        {
            MessageBox.Show(vent.Temp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vent.Temp = textBox1.Text;
        }
    }
}
