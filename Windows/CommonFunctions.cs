using System;
using System.Collections.Generic;
using System.Drawing;
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

        /// <summary>
        /// 设置应用程序的图标
        /// </summary>
        /// <returns></returns>
        public static Icon ApplicationIcon()
        {
            string path = System.IO.Path.Combine(Application.StartupPath, "Pictures/Interface.ico");

            Icon icon = new Icon(path);

            return icon;
        }
    }
}
