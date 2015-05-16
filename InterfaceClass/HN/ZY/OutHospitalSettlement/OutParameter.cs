using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.OutHospitalSettlement
{
    /// <summary>
    /// 
    /// </summary>
    public class OutParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PayInfo> _listPayInfo = new List<PayInfo>();

        /// <summary>
        /// 
        /// </summary>
        public List<PayInfo> ListPayInfo
        {
            get { return this._listPayInfo; }
            set { this._listPayInfo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BizInfo BizInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payInfo"></param>
        public void AddPayInfo(PayInfo payInfo)
        {
            if (this._listPayInfo == null)
            {
                this._listPayInfo = new List<PayInfo>();
            }
            this._listPayInfo.Add(payInfo);
        }
    }
}