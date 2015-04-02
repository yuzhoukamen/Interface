using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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

        /// <summary>
        /// DataTable生成Excel文件
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void WriteExcel(DataTable dt, string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    sb.Append(dt.Columns[k].ColumnName.ToString() + "\t");
                }
                sb.Append(Environment.NewLine);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sb.Append(dt.Rows[i][j].ToString() + "\t");
                    }
                    sb.Append(Environment.NewLine);//每写一行数据后换行
                }
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();//释放资源
            }
            catch (Exception ex)
            {
                throw new Exception("生成excel文件失败，失败原因：" + ex.Message);
            }
        }
    }
}
