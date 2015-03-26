using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.PublicFunctions
{
    /// <summary>
    /// IC卡基础类
    /// </summary>
    public class Card
    {
        private string _cardNo = string.Empty;

        /// <summary>
        /// 医保卡号
        /// </summary>
        public string CardNo
        {
            get { return this._cardNo; }
            set { this._cardNo = value; }
        }

        private string _centerID = string.Empty;

        /// <summary>
        /// 分级统筹中心编码
        /// </summary>
        public string CenterID
        {
            get { return this._centerID; }
            set { this._centerID = value; }
        }

        private string _indiID = string.Empty;

        /// <summary>
        /// 个人电脑号
        /// </summary>
        public string IndiID
        {
            get { return this._indiID; }
            set { this._indiID = value; }
        }

        private string _insrCode = string.Empty;

        /// <summary>
        /// 保险号
        /// </summary>
        public string InsrCode
        {
            get { return this._insrCode; }
            set { this._insrCode = value; }
        }

        private string _birthday = string.Empty;

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday
        {
            get { return this._birthday; }
            set { this._birthday = value; }
        }

        private string _name = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private int _persType = 0;

        /// <summary>
        /// 人员类别
        /// </summary>
        public int PersType
        {
            get { return this._persType; }
            set { this._persType = value; }
        }

        private string _idcard = string.Empty;

        /// <summary>
        /// 公民身份号码
        /// </summary>
        public string Idcard
        {
            get { return this._idcard; }
            set { this._idcard = value; }
        }

        private int _sex = 0;

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        private int _indiSta = 0;

        /// <summary>
        /// 个人状态
        /// </summary>
        public int IndiSta
        {
            get { return this._indiSta; }
            set { this._indiSta = value; }
        }

        private string _officialCode = string.Empty;

        /// <summary>
        /// 公务员级别
        /// </summary>
        public string OfficialCode
        {
            get { return this._officialCode; }
            set { this._officialCode = value; }
        }

        private double _totalSalary = 0;

        /// <summary>
        /// 月平均工资(两位小数)
        /// </summary>
        public double TotalSalary
        {
            get { return this._totalSalary; }
            set { this._totalSalary = value; }
        }

        private string _corpID = string.Empty;

        /// <summary>
        /// 单位编号
        /// </summary>
        public string CorpID
        {
            get { return this._corpID; }
            set { this._corpID = value; }
        }

        private string _corpName = string.Empty;

        /// <summary>
        /// 单位名称
        /// </summary>
        public string CorpName
        {
            get { return this._corpName; }
            set { this._corpName = value; }
        }

        private string _corpCode = string.Empty;

        /// <summary>
        /// 单位编码
        /// </summary>
        public string CorpCode
        {
            get { return this._corpCode; }
            set { this._corpCode = value; }
        }

        private string _corpStaCode = string.Empty;

        /// <summary>
        /// 单位状态（0：无效 1：有效 2：异动 3：新参保）
        /// </summary>
        public string CorpStaCode
        {
            get { return this._corpStaCode; }
            set { this._corpStaCode = value; }
        }

        private double _lastBalance = 0;

        /// <summary>
        /// 个人帐户余额(两位小数)
        /// </summary>
        public double LastBalance
        {
            get { return this._lastBalance; }
            set { this._lastBalance = value; }
        }
    }
}
