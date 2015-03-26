using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows
{
    /// <summary>
    /// 通用函数
    /// </summary>
    public class CommonFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public static void MsgError(string msg)
        {
            MessageBox.Show(msg.Trim(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public static void MsgInfo(string msg)
        {
            MessageBox.Show(msg.Trim(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
