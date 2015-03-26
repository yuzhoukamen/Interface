using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.HN.PublicFunctions
{
    /// <summary>
    /// IC卡
    /// </summary>
    public class ICCard
    {
        /// <summary>
        /// 读卡
        /// </summary>
        /// <returns>卡信息</returns>
        public static Card ReadICCard()
        {
            Card card = new Card();

            return card;
        }
    }
}