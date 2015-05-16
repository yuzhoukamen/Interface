using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Windows
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool pblnGotOwnership = true;
            System.Threading.Mutex pobjMyMutex = null;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                //pobjMyMutex = new System.Threading.Mutex(true, "只能运行一个登陆进程", out   pblnGotOwnership);
                if (pblnGotOwnership)
                {
                    Application.Run(new Frm_Interface(71));
                }
                else
                {
                    MessageBox.Show("只能运行一个应用程序", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (pobjMyMutex != null)
                {
                    pobjMyMutex.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "提示",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
            }
        }
    }
}
