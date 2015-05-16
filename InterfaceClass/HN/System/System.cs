using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.System
{
    /// <summary>
    /// 系统
    /// </summary>
    public class System
    {
        private InterfaceHN _interfaceHN = null;

        public InterfaceHN InterfaceHN
        {
            get { return this._interfaceHN; }
            set { this._interfaceHN = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public System(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 登陆到中心(0)
        /// </summary>
        /// <param name="loginID">登陆ID</param>
        /// <param name="loginPasswd">登陆密码</param>
        public string Login(string loginID, string loginPasswd)
        {
            Interface inter = new Interface(this.InterfaceHN);

            List<Parameter> list = new List<Parameter>();

            list.Add(new Parameter("login_id", loginID));
            list.Add(new Parameter("login_password", loginPasswd));

            long value = inter.ExecInterface("0", list);

            if (value < 0)
            {
                throw new Exception("登陆到医保接口中心失败，失败原因：" + inter.GetMessage());
            }

            return inter.GetMessage();
        }

        /// <summary>
        /// 修改登陆密码
        /// </summary>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <param name="confirmPwd"></param>
        /// <param name="staffName"></param>
        public void UpdateLoginPasswd(string oldPwd, string newPwd, string confirmPwd, string staffName)
        {
            Interface inter = new Interface(this.InterfaceHN);

            List<Parameter> list = new List<Parameter>();

            list.Add(new Parameter("hospital_id", this.InterfaceHN.Oper_hospitalid));
            list.Add(new Parameter("old_pwd", oldPwd));
            list.Add(new Parameter("new_pwd", newPwd));
            list.Add(new Parameter("confirm_pwd", confirmPwd));
            list.Add(new Parameter("staff_name", staffName));

            long value = inter.ExecInterface("BIZC000001", list);

            if (value < 0)
            {
                throw new Exception("修改密码失败，失败原因：" + inter.GetMessage());
            }
        }
    }
}