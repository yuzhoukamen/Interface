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
        /// 湖南创智接口
        /// </summary>
        private InterfaceHN _interfaceHN = null;

        /// <summary>
        /// 湖南创智接口
        /// </summary>
        public InterfaceHN InterfaceHN
        {
            get { return this._interfaceHN; }
            set { this._interfaceHN = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceHN"></param>
        public ICCard(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 读IC卡（BIZC200900）
        /// </summary>
        /// <returns>卡信息</returns>
        public Card ReadICCard()
        {
            Interface inter = new Interface(this.InterfaceHN);

            long value = inter.ExecInterface("BIZC200900");

            if (value < 0)
            {
                throw new Exception("读卡失败，失败原因：" + inter.GetMessage());
            }

            Card card = new Card();

            try
            {
                inter.SetResultset("icinfo");

                string str = string.Empty;

                inter.GetByName("card_no", ref str);
                card.CardNo = str;

                str = string.Empty;
                inter.GetByName("center_id", ref str);
                card.CenterID = str;

                str = string.Empty;
                inter.GetByName("indi_id", ref str);
                card.IndiID = str;

                str = string.Empty;
                inter.GetByName("insr_code", ref str);
                card.InsrCode = str;

                str = string.Empty;
                inter.GetByName("birthday", ref str);
                card.Birthday = str;

                str = string.Empty;
                inter.GetByName("name", ref str);
                card.Name = str;

                str = string.Empty;
                inter.GetByName("pers_type", ref str);
                card.PersType = int.Parse(str);

                str = string.Empty;
                inter.GetByName("idcard", ref str);
                card.Idcard = str;

                str = string.Empty;
                inter.GetByName("sex", ref str);
                card.Sex = int.Parse(str);

                str = string.Empty;
                inter.GetByName("indi_sta", ref str);
                card.IndiSta = int.Parse(str);

                str = string.Empty;
                inter.GetByName("official_code", ref str);
                card.OfficialCode = str;

                str = string.Empty;
                inter.GetByName("total_salary", ref str);
                card.TotalSalary = double.Parse(str);

                str = string.Empty;
                inter.GetByName("corp_id", ref str);
                card.CorpID = str;

                str = string.Empty;
                inter.GetByName("corp_name", ref str);
                card.CorpName = str;

                str = string.Empty;
                inter.GetByName("corp_code", ref str);
                card.CorpCode = str;

                str = string.Empty;
                inter.GetByName("corp_sta_code", ref str);
                card.CorpStaCode = str;

                str = string.Empty;
                inter.GetByName("last_balance", ref str);
                card.LastBalance = double.Parse(str);
            }
            catch (Exception e)
            {
                throw new Exception("通过设置读卡数据集获取数据失败，失败原因：" + e.Message);
            }

            return card;
        }

        /// <summary>
        /// IC卡密码修改(BIZC200903)
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="newPwd"></param>
        /// <param name="oldPwd"></param>
        public void UpdateICCardPasswd(string CardNo, string newPwd, string oldPwd)
        {
            Interface inter = new Interface(this.InterfaceHN);

            List<Parameter> list = new List<Parameter>();

            list.Add(new Parameter("card_no", CardNo));
            list.Add(new Parameter("hospital_id", this.InterfaceHN.Oper_hospitalid));
            list.Add(new Parameter("newpwd", newPwd));
            list.Add(new Parameter("oldpwd", oldPwd));
            list.Add(new Parameter("center_id", this.InterfaceHN.Oper_centerid));

            long value = inter.ExecInterface("BIZC200903", list);

            if (value < 0)
            {
                throw new Exception("修改密码发生错误，错误原因：" + inter.GetMessage());
            }
        }
    }
}