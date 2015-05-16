using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using InterfaceClass;
using Windows.Class;

namespace Windows
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_ReadCard : BaseForm
    {
        /// <summary>
        /// 个人电脑号
        /// </summary>
        private string _CardNumbers = string.Empty;

        /// <summary>
        /// 个人电脑号
        /// </summary>
        public string CardNumbers
        {
            get { return this._CardNumbers; }
            set { this._CardNumbers = value; }
        }

        /// <summary>
        /// 是否每次一打开窗口就设置串口号
        /// </summary>
        private bool _isReSetCommPort = false;

        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 
        /// </summary>
        public Frm_ReadCard(long userID)
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;
            this._userID = userID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_ReadCard_Load(object sender, EventArgs e)
        {
            SetTextBoxReadonly(this.flowLayoutPanel1);

            BoolReSetCommPort();

            this.txtBox_IndiID.ReadOnly = false;
        }

        /// <summary>
        /// 是否重新设置串口号
        /// </summary>
        private void BoolReSetCommPort()
        {
            string SQLString = string.Format(@"SELECT  CodeValue
                                                    FROM    HIS_InterfaceHN.dbo.Setup
                                                    WHERE   Code = '100001002'");

            try
            {
                int value = int.Parse(Alif.DBUtility.DbHelperSQL.Query(SQLString).Tables[0].Rows[0][0].ToString().Trim());

                if (value == 0)
                {
                    this._isReSetCommPort = false;
                }
                else
                {
                    this._isReSetCommPort = true;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("没有设置Code为100001002的字段或字段值是0或1之外的其他字符，详细错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CardNumbers = this.txtBox_IndiID.Text.Trim();

            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_ReadCard_Shown(object sender, EventArgs e)
        {
            SetCommPort();
            CreateAndStartThread(this._thread, ThreadReadCard);
        }

        /// <summary>
        /// 设置串口
        /// </summary>
        private void SetCommPort()
        {
            try
            {
                this.lblCommPort.Text = "当前串口号：" + Alif.DBUtility.PubConstant.GetKeyValue("CommPort");
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("没有在App.config文件中配置CommPort信息，异常原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadReadCard()
        {
            SendUIMsg(ReadCardUIMsg.disableOK);
            SendUIMsg(ReadCardUIMsg.disableCancel);

            ReadCardInfo();

            SendUIMsg(ReadCardUIMsg.enableOK);
            SendUIMsg(ReadCardUIMsg.enableCancel);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadCardInfo()
        {
            bool status = false;

            SetICCardCommPort(ref status);

            if (status)
            {
                ReadICCard();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadICCard()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在获取IC卡设备信息(请插入IC卡)，请稍后......");

                InterfaceClass.HN.PublicFunctions.Card card = new InterfaceClass.HN.PublicFunctions.Card();
                InterfaceClass.HN.PublicFunctions.ICCard icCard = new InterfaceClass.HN.PublicFunctions.ICCard(baseInterfaceHN);

                card = icCard.ReadICCard();

                SaveICCardInfo(card);

                Parameter parameter = new Parameter(ReadCardUIMsg.setICCaradInfo, card);

                SendUIMsg(ReadCardUIMsg.setICCaradInfo, parameter);

                SendUIMsg(UIMsg.Close);

                this._CardNumbers = card.CardNo;

                SendUIMsg(ReadCardUIMsg.closeReadCard);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 存储IC卡信息
        /// </summary>
        /// <param name="card"></param>
        private void SaveICCardInfo(InterfaceClass.HN.PublicFunctions.Card card)
        {
            try
            {

                string unitName = string.Empty;
                string userName = string.Empty;

                QueryAndSetUserInfo(this._userID, ref unitName, ref userName);

                string SQLString = string.Format(@"IF NOT EXISTS ( SELECT  *
                                                                        FROM    HIS_InterfaceHN.dbo.ICInfo
                                                                        WHERE   card_no = N'{0}' )
                                                            BEGIN
                                                                INSERT  INTO [HIS_InterfaceHN].[dbo].[ICInfo]
                                                                ( [card_no] ,
                                                                  [center_id] ,
                                                                  [indi_id] ,
                                                                  [insr_code] ,
                                                                  [birthday] ,
                                                                  [name] ,
                                                                  [pers_type] ,
                                                                  [idcard] ,
                                                                  [sex] ,
                                                                  [indi_sta] ,
                                                                  [official_code] ,
                                                                  [total_salary] ,
                                                                  [corp_id] ,
                                                                  [corp_name] ,
                                                                  [corp_code] ,
                                                                  [corp_sta_code] ,
                                                                  [last_balance]
                                                                )
                                                                VALUES  (N'{0}'--, nvarchar(50),>
                                                                   ,N'{1}'--, nvarchar(10),>
                                                                   ,N'{2}'--, nvarchar(12),>
                                                                   ,N'{3}'--, nvarchar(20),>
                                                                   ,N'{4}'--, datetime,>
                                                                   ,N'{5}'--, nvarchar(20),>
                                                                   ,N'{6}'--, nvarchar(2),>
                                                                   ,N'{7}'--, nvarchar(18),>
                                                                   ,N'{8}'--, char(1),>
                                                                   ,N'{9}'--, char(1),>
                                                                   ,N'{10}'--, nvarchar(3),>
                                                                   ,N'{11}'--, numeric(18,4),>
                                                                   ,N'{12}'--, nvarchar(12),>
                                                                   ,N'{13}'--, nvarchar(100),>
                                                                   ,N'{14}'--, nvarchar(20),>
                                                                   ,N'{15}'--, char(1),>
                                                                   ,N'{16}'--, numeric(18,4),>
                                                                   ,N'{17}'--, nvarchar(50),>
                                                                   ,GETDATE()--, datetime,>
                                                               );
                                                            END
                                                            INSERT  INTO HIS_InterfaceHN.dbo.ICInfoLogin
                                                                    ( card_no, LoginUser, LoginTime )
                                                            VALUES  ( N'{0}', -- card_no - nvarchar(50)
                                                                      N'{18}', -- LoginUser - nvarchar(50)
                                                                      getdate()  -- LoginTime - datetime
                                                                      );", card.CardNo, card.CenterID, card.IndiID, card.InsrCode, card.Birthday, card.Name, card.PersType, card.Idcard, card.Sex,
                                                                  card.IndiSta, card.OfficialCode, card.TotalSalary, card.CorpID, card.CorpName, card.CorpStaCode, card.LastBalance, userName);

                int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                if (temp == 1)
                {
                    SendUIMsg(UIMsg.WriteMsg, "成功保存IC卡信息！！！");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("存储IC卡信息失败,失败原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetICCardCommPort(ref bool status)
        {
            try
            {
                if (this._isReSetCommPort)
                {
                    SendUIMsg(UIMsg.Display, "正在设置IC卡设备的串口号，请稍后......");

                    InterfaceClass.HN.PublicFunctions.ICCard icCard = new InterfaceClass.HN.PublicFunctions.ICCard(baseInterfaceHN);

                    int port = int.Parse(Alif.DBUtility.PubConstant.GetKeyValue("CommPort"));

                    icCard.SetICCommPort(port);

                    SendUIMsg("设置IC卡设备的串口号成功......");
                    SendUIMsg(UIMsg.Close);

                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        private void SetICCardInfo(InterfaceClass.HN.PublicFunctions.Card card)
        {
            this.txtBox_CardNo.Text = card.CardNo;
            this.txtBox_CenterID.Text = card.CenterID;
            this.txtBox_IndiID.Text = card.IndiID;
            this.txtBox_InsrCode.Text = card.InsrCode;
            this.txtBox_Birthday.Text = card.Birthday;
            this.txtBox_Name.Text = card.Name;
            this.txtBox_PersType.Text = card.PersType.ToString().Trim();
            this.txtBox_Idcard.Text = card.Idcard;
            this.txtBox_Sex.Text = card.Sex.ToString().Trim();
            this.txtBox_IndiSta.Text = card.IndiSta.ToString().Trim();
            this.txtBox_OfficialCode.Text = card.OfficialCode;
            this.txtBox_TotalSalary.Text = card.TotalSalary.ToString().Trim();
            this.txtBox_CorpID.Text = card.CorpID;
            this.txtBox_CorpName.Text = card.CorpName;
            this.txtBox_CorpCode.Text = card.CorpCode;
            this.txtBox_CorpStaCode.Text = card.CorpStaCode;
            this.txtBox_LastBalance.Text = card.LastBalance.ToString().Trim();
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void CloseReadCard()
        {
            if (this._CardNumbers == string.Empty)
            {
                CommonFunctions.MsgError("获取的社保卡号为空，请重试！！！");
                return;
            }

            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            CreateAndStartThread(this._thread, ThreadReadCard);
        }

        /// <summary>
        /// 
        /// </summary>
        public class ReadCardUIMsg
        {
            public const string enableOK = "enableOK";
            public const string enableCancel = "enableCancel";
            public const string disableOK = "disableOK";
            public const string disableCancel = "disableCancel";
            public const string setICCaradInfo = "setICCaradInfo";
            public const string closeReadCard = "closeReadCard";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void UpdateUIControlContext(object context)
        {
            try
            {
                base.UpdateUIControlContext(context);

                Parameter parameter = (Parameter)context;

                switch (parameter.Name)
                {
                    case ReadCardUIMsg.enableOK:
                        this.btnOK.Enabled = true;
                        break;
                    case ReadCardUIMsg.disableOK:
                        this.btnOK.Enabled = false;
                        break;
                    case ReadCardUIMsg.enableCancel:
                        this.btnCancel.Enabled = true;
                        break;
                    case ReadCardUIMsg.disableCancel:
                        this.btnCancel.Enabled = false;
                        break;
                    case ReadCardUIMsg.setICCaradInfo:
                        SetICCardInfo((InterfaceClass.HN.PublicFunctions.Card)parameter.Object);
                        break;
                    case ReadCardUIMsg.closeReadCard:
                        CloseReadCard();
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
            }
        }
    }
}