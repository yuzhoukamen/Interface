using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.MZ
{
    /// <summary>
    /// 
    /// </summary>
    public class MZ_ChangeParameter
    {
        /// <summary>
        /// 门诊普通业务正常收费主参数
        /// </summary>
        private MZRegChange _mzRegChange = new MZRegChange();

        /// <summary>
        /// 门诊普通业务正常收费主参数
        /// </summary>
        public MZRegChange MZRegChange
        {
            get { return this._mzRegChange; }
            set { this._mzRegChange = value; }
        }

        /// <summary>
        /// 门诊普通业务正常收费费用明细信息
        /// </summary>
        public List<FeeInfo> _listFeeInfo = null;

        /// <summary>
        /// 门诊普通业务正常收费费用明细信息
        /// </summary>
        public List<FeeInfo> ListFeeInfo
        {
            get { return this._listFeeInfo; }
            set { this._listFeeInfo = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MZ_ChangeParameter() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mzRegCharge"></param>
        /// <param name="listFeeInfo"></param>
        public MZ_ChangeParameter(MZRegChange mzRegChange, List<FeeInfo> listFeeInfo)
        {
            this.MZRegChange = mzRegChange;
            this.ListFeeInfo = listFeeInfo;
        }

        /// <summary>
        /// 添加费用明细信息
        /// </summary>
        /// <param name="feeInfo"></param>
        public void AddFeeInfo(FeeInfo feeInfo)
        {
            if (this.ListFeeInfo == null)
            {
                this.ListFeeInfo = new List<FeeInfo>();
            }
            this.ListFeeInfo.Add(feeInfo);
        }
    }
}
