using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HealthNews
{
    /// <summary>
    /// 医保中心消息
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public string ms_id { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string ms_type { get; set; }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string ms_title { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string ms_content { get; set; }

        /// <summary>
        /// 发件人中心
        /// </summary>
        public string center_id { get; set; }

        /// <summary>
        /// 发件人组织编号
        /// </summary>
        public string sender_org { get; set; }

        /// <summary>
        /// 发件人名称
        /// </summary>
        public string sender_man { get; set; }

        /// <summary>
        /// 发件时间
        /// </summary>
        public string send_date { get; set; }
    }
}
