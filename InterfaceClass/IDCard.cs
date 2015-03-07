using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    /// <summary>
    /// 身份证接口
    /// </summary>
    public class IDCard
    {
        /// <summary>
        /// 姓名
        /// </summary>
        private StringBuilder _Name=new StringBuilder();

        /// <summary>
        /// 错误信息
        /// </summary>
        private StringBuilder _ErrorInfo=new StringBuilder();

        /// <summary>
        /// 获取身份证接口实例
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IDCard GetInstance(string name)
        {
            return new IDCard (name);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public IDCard(string name)
        {
            this._Name.Append(name);
        }

        /// <summary>
        /// 身份证的所有信息
        /// </summary>
        /// <returns></returns>
        public string AllInfo()
        {
            try
            {
                string msg = string.Empty;
                StringBuilder valueArray = new StringBuilder();

                if (IDCardDll.IDCReset() == 0)
                {
                    if (IDCardDll.IDCStart() == 0)
                    {
                        if (IDCardDll.IDCGet(this._Name, valueArray) == 0)
                        {
                            msg += valueArray.ToString() + "\n";
                        }
                        else
                        {
                            IDCardDll.IDCGeterrMsg(this._ErrorInfo);

                            string temp = this._ErrorInfo.ToString();
                            this._ErrorInfo.Clear();

                            this._ErrorInfo.Append("获取身份证信息失败,错误原因：" + temp);
                        }
                    }
                    else
                    {
                        IDCardDll.IDCGeterrMsg(this._ErrorInfo);

                        string temp = this._ErrorInfo.ToString();
                        this._ErrorInfo.Clear();

                        this._ErrorInfo.Append("启动身份证设备失败,错误原因：" + temp);
                    }
                }
                else
                {
                    IDCardDll.IDCGeterrMsg(this._ErrorInfo);

                    string temp = this._ErrorInfo.ToString();
                    this._ErrorInfo.Clear();

                    this._ErrorInfo.Append("清空身份证接口信息失败，失败原因：" +temp);
                }

                return this._ErrorInfo.ToString() != string.Empty ? this._ErrorInfo.ToString() : msg;
            }
            catch (Exception e)
            {
                return "获取身份证的所有信息失败，失败原因：" + e.Message;
            }
        }
    }
}