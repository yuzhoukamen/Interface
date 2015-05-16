using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class StatusEvent
    {
        public delegate void tempChange(object sender, EventArgs e);

        public event tempChange OntempChange;

        string temp;

        public string Temp
        {
            get { return this.temp; }
            set
            {
                if (temp != value)
                {
                    OntempChange(this, new EventArgs());
                }
                temp = value;
            }
        }
    }
}