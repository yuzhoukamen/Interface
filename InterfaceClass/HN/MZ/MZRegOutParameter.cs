using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 普通门诊收费出参
    /// </summary>
    public class MZRegOutParameter
    {
        /// <summary>
        /// 门诊登记信息
        /// </summary>
        public BizInfo BizInfo { get; set; }

        /// <summary>
        /// 支付信息
        /// </summary>
        public List<PayInfo> ListPayInfo { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MZRegOutParameter() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bizInfo">门诊登记信息</param>
        /// <param name="listPayInfo">支付信息</param>
        public MZRegOutParameter(BizInfo bizInfo,List<PayInfo> listPayInfo) {
            this.BizInfo = bizInfo;
            this.ListPayInfo = listPayInfo;
        }

        /// <summary>
        /// 添加支付信息
        /// </summary>
        /// <param name="payInfo">支付信息</param>
        public void AddPayInfo(PayInfo payInfo)
        {
            if (this.ListPayInfo == null)
            {
                this.ListPayInfo = new List<PayInfo>();
            }
            this.ListPayInfo.Add(payInfo);
        }
    }
}