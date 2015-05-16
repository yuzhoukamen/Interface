using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Windows.Class
{
    /// <summary>
    /// 一卡通信息
    /// </summary>
    public class CardInfo
    {
        #region 属性

        /// <summary>
        /// 一卡通相关信息配置
        /// </summary>
        private const string _CardMainInfoConfigCode = "000002001001";

        /// <summary>
        /// 一卡通相关信息配置
        /// </summary>
        public string CardMainInfoConfigCode
        {
            get { return _CardMainInfoConfigCode; }
        }

        /// <summary>
        /// 一卡通相关信息配置
        /// </summary>
        private string _CardMainInfoConfigValue = string.Empty;

        /// <summary>
        /// 一卡通相关信息配置
        /// </summary>
        public string CardMainInfoConfigValue
        {
            get { return _CardMainInfoConfigValue; }
            set { _CardMainInfoConfigValue = value; }
        }

        /// <summary>
        /// 一卡通读卡是否3位校验（0:不校验 1:必须校验 3:校验和不校验均可）
        /// </summary>
        private const string _CardIsCheckCode = "000002001001001";

        /// <summary>
        /// 一卡通读卡是否3位校验（0:不校验 1:必须校验 3:校验和不校验均可）
        /// </summary>
        public string CardIsCheckCode
        {
            get { return _CardIsCheckCode; }
        }

        /// <summary>
        /// 3位校验（0:不校验 1:必须校验 3:校验和不校验均可）
        /// </summary>
        private string _CardIsCheckValue = string.Empty;

        /// <summary>
        /// 3位校验（0:不校验 1:必须校验 3:校验和不校验均可）
        /// </summary>
        public string CardIsCheckValue
        {
            get { return _CardIsCheckValue; }
            set { _CardIsCheckValue = value; }
        }

        /// <summary>
        /// 一卡通默认前缀
        ///// </summary>
        private const string _CardDefaultPrefixCode = "000002001001002";

        /// <summary>
        /// 一卡通默认前缀
        /// </summary>
        private string _CardDefaultPrefixValue = string.Empty;

        /// <summary>
        /// 一卡通默认前缀
        /// </summary>
        public string CardDefaultPrefixValue
        {
            get { return _CardDefaultPrefixValue; }
            set { _CardDefaultPrefixValue = value; }
        }
        /// <summary>
        /// 一卡通默认前缀
        /// </summary>
        public string CardDefaultPrefixCode
        {
            get { return _CardDefaultPrefixCode; }
        }

        /// <summary>
        /// 一卡通卡号长度
        /// </summary>
        private const string _CardLengthCode = "000002001001003";

        /// <summary>
        /// 一卡通卡号长度
        /// </summary>
        public string CardLengthCode
        {
            get { return _CardLengthCode; }
        }

        /// <summary>
        /// 一卡通卡号长度
        /// </summary>
        private string _CardLengthValue = string.Empty;

        /// <summary>
        /// 一卡通卡号长度
        /// </summary>
        public string CardLengthValue
        {
            get { return _CardLengthValue; }
            set { _CardLengthValue = value; }
        }

        /// <summary>
        /// 一卡通跳号
        /// </summary>
        private const string _CardJumpNumbersCode = "000002001001004";

        /// <summary>
        /// 一卡通跳号
        /// </summary>
        public string CardJumpNumbersCode
        {
            get { return _CardJumpNumbersCode; }
        }

        /// <summary>
        /// 一卡通跳号
        /// </summary>
        private string _CardJumpNumbersValue = string.Empty;

        /// <summary>
        /// 一卡通跳号
        /// </summary>
        public string CardJumpNumbersValue
        {
            get { return _CardJumpNumbersValue; }
            set { _CardJumpNumbersValue = value; }
        }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public CardInfo()
        {
            InitCardInfo();
        }

        /// <summary>
        /// 初始化卡信息
        /// </summary>
        public void InitCardInfo()
        {
            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query("select * from his.dbo.setup where code like '000002001001%'");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string value = ds.Tables[0].Rows[i]["CodeValue"].ToString().Trim();
                    switch (ds.Tables[0].Rows[i]["Code"].ToString().Trim())
                    {
                        case _CardMainInfoConfigCode:
                            this.CardMainInfoConfigValue = value;
                            break;
                        case _CardIsCheckCode:
                            this.CardIsCheckValue = value;
                            break;
                        case _CardDefaultPrefixCode:
                            this.CardDefaultPrefixValue = value;
                            break;
                        case _CardLengthCode:
                            this.CardLengthValue = value;
                            break;
                        case _CardJumpNumbersCode:
                            this.CardJumpNumbersValue = value;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                string errorInfo = "初始化获取卡信息失败，失败原因：" + e.Message;
                throw new Exception(errorInfo);
            }
        }

        /// <summary>
        /// 获取卡信息实例
        /// </summary>
        /// <returns>CardInfo</returns>
        public static CardInfo GetInstance()
        {
            return new CardInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardNumbers"></param>
        /// <returns></returns>
        public string DealInputCardNumber(string cardNumbers)
        {
            string temp = "";
            if (cardNumbers.IndexOf("=") > 0)
            {
                if (cardNumbers.Substring(0, 10) != this.CardDefaultPrefixValue)
                {
                    throw new Exception("非本院卡!!!");
                }
                return cardNumbers;
            }
            if (cardNumbers.Length >= 10 && cardNumbers.Substring(0, 10) == this.CardDefaultPrefixValue)
            {
                return cardNumbers + "=" + GetCheckValue(cardNumbers);
            }
            else
            {
                for (var i = 0; i < 10 - cardNumbers.Length; i++)
                {
                    temp += "0";
                }
                temp = this.CardDefaultPrefixValue + temp + cardNumbers;
                return temp + "=" + GetCheckValue(temp);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardNumberNoEqual"></param>
        /// <returns></returns>
        private long GetCheckValue(string cardNumberNoEqual)
        {
            long sum = 0;
            for (int i = 0; i < cardNumberNoEqual.Length; i += 3)
            {
                if (cardNumberNoEqual.Length - i < 3)
                {
                    sum += int.Parse(cardNumberNoEqual.Substring(i, cardNumberNoEqual.Length - i));
                    break;
                }
                sum += int.Parse(cardNumberNoEqual.Substring(i, 3));
            }
            sum = sum % 1000;
            return sum;
        }
    }
}
