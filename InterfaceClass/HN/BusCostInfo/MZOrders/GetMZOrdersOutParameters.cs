using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.BusCostInfo.MZOrders
{
    public class GetMZOrdersOutParameters
    {
        /// <summary>
        /// 本次业务各基金(含个人帐户和现金)支付信息
        /// </summary>
        public Fund fund { get; set; }

        /// <summary>
        /// 记录病人的基本信息
        /// </summary>
        public List<Info> ListInfo { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public GetMZOrdersOutParameters() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bizInfo">本次业务各基金(含个人帐户和现金)支付信息</param>
        /// <param name="listPayInfo">记录病人的基本信息</param>
        public GetMZOrdersOutParameters(Fund fund, List<Info> listInfo)
        {
            this.fund = fund;
            this.ListInfo = listInfo;
        }

        /// <summary>
        /// 添加记录病人的基本信息
        /// </summary>
        /// <param name="payInfo">记录病人的基本信息</param>
        public void AddInfo(Info info)
        {
            if (this.ListInfo == null)
            {
                this.ListInfo = new List<Info>();
            }
            this.ListInfo.Add(info);
        }
    }
}