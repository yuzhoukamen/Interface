using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders
{
    /// <summary>
    /// 出参
    /// </summary>
    public class OutParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public Info Info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Fee> _listFee = new List<Fee>();

        /// <summary>
        /// 
        /// </summary>
        public List<Fee> ListFee
        {
            get { return this._listFee; }
            set { this._listFee = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Seg> _listSeg = new List<Seg>();

        /// <summary>
        /// 
        /// </summary>
        public List<Seg> ListSeg
        {
            get { return this._listSeg; }
            set { this._listSeg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Fund Fund { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seg"></param>
        public void AddSeg(Seg seg)
        {
            if (this.ListSeg == null)
            {
                this.ListSeg = new List<Seg>();
            }

            this.ListSeg.Add(seg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fee"></param>
        public void AddFee(Fee fee)
        {
            if (this.ListFee == null)
            {
                this.ListFee = new List<Fee>();
            }

            this.ListFee.Add(fee);
        }
    }
}