using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.HosDirManage
{
    public class MatchedOutParameter
    {
        /// <summary>
        /// 记录数信息
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public List<MatchedPageInfo> ListMatchedPageInfo { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MatchedOutParameter() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bizInfo">门诊登记信息</param>
        /// <param name="listPayInfo">支付信息</param>
        public MatchedOutParameter(string count, List<MatchedPageInfo> listMatchedPageInfo)
        {
            this.Count = count;
            this.ListMatchedPageInfo = listMatchedPageInfo;
        }

        /// <summary>
        /// 添加匹配信息
        /// </summary>
        /// <param name="payInfo">匹配信息</param>
        public void AddMatchedPageInfo(MatchedPageInfo matchedPageInfo)
        {
            if (this.ListMatchedPageInfo == null)
            {
                this.ListMatchedPageInfo = new List<MatchedPageInfo>();
            }
            this.ListMatchedPageInfo.Add(matchedPageInfo);
        }
    }
}