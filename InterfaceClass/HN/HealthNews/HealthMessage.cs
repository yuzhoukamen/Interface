using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HealthNews
{
    /// <summary>
    /// 获取医保中心消息
    /// </summary>
    public class HealthMessage
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
        public HealthMessage(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 取中心针对本单位消息记录数（SYSC980003）
        /// </summary>
        /// <param name="receiveMan"></param>
        /// <returns></returns>
        public long GetMessageCount(string receiveMan)
        {
            Interface inter = new Interface(this.InterfaceHN);

            List<Parameter> list = new List<Parameter>();

            list.Add(new Parameter("center_id", this.InterfaceHN.Oper_centerid));
            list.Add(new Parameter("receive_org", this.InterfaceHN.Oper_hospitalid));
            list.Add(new Parameter("receive_staff", this.InterfaceHN.Oper_staffid));
            list.Add(new Parameter("receive_man", receiveMan));

            long value = inter.ExecInterface("SYSC980003", list);

            if (value < 0)
            {
                throw new Exception("取中心针对本单位消息记录数失败，失败原因：" + inter.GetMessage());
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveMan"></param>
        /// <returns></returns>
        public Message GetMessage(string receiveMan)
        {
            Interface inter = new Interface(this.InterfaceHN);

            List<Parameter> list = new List<Parameter>();

            list.Add(new Parameter("center_id", this.InterfaceHN.Oper_centerid));
            list.Add(new Parameter("receive_org", this.InterfaceHN.Oper_hospitalid));
            list.Add(new Parameter("receive_staff", this.InterfaceHN.Oper_staffid));
            list.Add(new Parameter("receive_man", receiveMan));

            long value = inter.ExecInterface("SYSC980001", list);

            if (value < 0)
            {
                throw new Exception("取中心针对本单位消息失败，失败原因：" + inter.GetMessage());
            }


            Message msg = new Message();

            try
            {
                inter.SetResultset("info");

                string str = string.Empty;
                inter.GetByName("ms_id", ref str);
                msg.ms_id = str;

                str = string.Empty;
                inter.GetByName("ms_type", ref str);
                msg.ms_type = str;

                str = string.Empty;
                inter.GetByName("ms_title", ref str);
                msg.ms_title = str;

                str = string.Empty;
                inter.GetByName("ms_content", ref str);
                msg.ms_content = str;

                str = string.Empty;
                inter.GetByName("center_id", ref str);
                msg.center_id = str;

                str = string.Empty;
                inter.GetByName("sender_org", ref str);
                msg.sender_org = str;

                str = string.Empty;
                inter.GetByName("sender_man", ref str);
                msg.sender_man = str;

                str = string.Empty;
                inter.GetByName("sender_man", ref str);
                msg.sender_man = str;
            }
            catch (Exception e)
            {
                throw new Exception("通过设置数据集获取中心消息的数据失败，失败原因:" + e.Message);
            }

            return msg;
        }
    }
}