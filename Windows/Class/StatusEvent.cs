using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows.Class
{
    /// <summary>
    /// 
    /// </summary>
    public class StatusEvent
    {
        /// <summary>
        /// 状态改变委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void StatusChange(object sender, EventArgs e);

        /// <summary>
        /// 状态改变事件
        /// </summary>
        public event StatusChange OnStatusChange;

        /// <summary>
        /// 状态
        /// </summary>
        private string _status = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get { return this._status; }
            set
            {
                this._status = value;

                OnStatusChange(this, new EventArgs());
            }
        }
    }
}