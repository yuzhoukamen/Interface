using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace InterfaceClass
{
    /// <summary>
    /// 湖南创智接口
    /// </summary>
    public class InterfaceHN
    {
        /// <summary>
        /// 
        /// </summary>
        public InterfaceHN()
        {
            InitPara();

            NewInterfaceAfterInit();
        }

        /// <summary>
        /// 设置接口的运行模式
        /// </summary>
        public int SetDebug(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(filePath);

            return InterfaceHNDll.setdebug(this.P_inter, 1, sb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="servlet"></param>
        /// <param name="operCenterID"></param>
        /// <param name="operHospitalID"></param>
        /// <param name="operStaffID"></param>
        public InterfaceHN(string ip, int port, string servlet, string operCenterID, string operHospitalID, string operStaffID)
        {
            this.Addr = ip;
            this.Port = port;
            this.Servlet = servlet;
            this.Oper_centerid = operCenterID;
            this.Oper_hospitalid = operHospitalID;
            this.Oper_staffid = operStaffID;

            NewInterfaceWithInit();
        }

        #region 属性

        /// <summary>
        /// 接口指针
        /// </summary>
        private IntPtr _p_inter;

        /// <summary>
        /// 获取或设置接口指针
        /// </summary>
        public IntPtr P_inter
        {
            get { return this._p_inter; }
            set { this._p_inter = value; }
        }

        /// <summary>
        /// 端口
        /// </summary>
        private int _Port;

        /// <summary>
        /// 获取或设置端口
        /// </summary>
        public int Port
        {
            get { return this._Port; }
            set { this._Port = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        private string _Addr = string.Empty;

        /// <summary>
        /// 获取和设置地址
        /// </summary>
        public string Addr
        {
            get { return this._Addr; }
            set { this._Addr = value; }
        }

        /// <summary>
        /// 应用服务器入口Servlet的名称
        /// </summary>
        private string _Servlet = string.Empty;

        /// <summary>
        /// 获取或设置应用服务器入口Servlet的名称
        /// </summary>
        public string Servlet
        {
            get { return this._Servlet; }
            set { this._Servlet = value; }
        }

        /// <summary>
        /// 业务的功能号
        /// </summary>
        private string _Func_ID = string.Empty;

        /// <summary>
        /// 获取或设置业务的功能号
        /// </summary>
        public string Func_ID
        {
            get { return this._Func_ID; }
            set { this._Func_ID = value; }
        }

        /// <summary>
        /// 操作中心编号
        /// </summary>
        private string _oper_centerid = string.Empty;

        /// <summary>
        /// 操作中心编号
        /// </summary>
        public string Oper_centerid
        {
            get { return this._oper_centerid; }
            set { this._oper_centerid = value; }
        }

        /// <summary>
        /// 操作医院编号
        /// </summary>
        private string _oper_hospitalid = string.Empty;

        /// <summary>
        /// 操作医院编号
        /// </summary>
        public string Oper_hospitalid
        {
            get { return this._oper_hospitalid; }
            set { this._oper_hospitalid = value; }
        }


        /// <summary>
        /// 操作员工号
        /// </summary>
        private string _oper_staffid = string.Empty;

        /// <summary>
        /// 操作员工号
        /// </summary>
        public string Oper_staffid
        {
            get { return this._oper_staffid; }
            set { this._oper_staffid = value; }
        }

        /// <summary>
        /// 参数列表
        /// </summary>
        private List<Parameter> _ParameterList = new List<Parameter>();

        /// <summary>
        /// 获取或设置参数列表
        /// </summary>
        public List<Parameter> ParameterList
        {
            get { return this._ParameterList; }
            set { this._ParameterList = value; }
        }

        #endregion

        #region 参数处理

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public void AddParameter(string name, string value)
        {
            StringBuilder sbName = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();

            sbName.Append(name);
            sbValue.Append(value);

            this.ParameterList.Add(new Parameter(name, value));
        }

        /// <summary>
        /// 清空和释放参数列表
        /// </summary>
        public void ClearParameterList()
        {
            if (this.ParameterList != null && this.ParameterList.Count > 0)
            {
                this.ParameterList.Clear();
            }
        }

        #endregion

        #region 创建和初始化接口

        /// <summary>
        /// 创建接口之后初始化
        /// </summary>
        public void NewInterfaceAfterInit()
        {
            this.P_inter = InterfaceHNDll.newinterface();

            if (null == this.P_inter || 0 > (int)this.P_inter)
            {
                throw new Exception("创建接口失败！！！");
            }

            long value = InterfaceHNDll.init(this.P_inter, this.Addr, this.Port, this.Servlet);

            if (0 > value)
            {
                throw new Exception("初始化接口失败！！！");
            }
        }

        /// <summary>
        /// 创建并初始化接口
        /// </summary>
        public void NewInterfaceWithInit()
        {
            this.P_inter = InterfaceHNDll.newinterfacewithinit(this.Addr, this.Port, this.Servlet);

            if (null == this.P_inter || 0 > (int)this.P_inter)
            {
                throw new Exception("创建并初始化接口失败！！！");
            }
        }

        #endregion

        #region 获取错误消息和异常

        /// <summary>
        /// 获取错误消息
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            StringBuilder sbError = new StringBuilder();

            long value = InterfaceHNDll.getmessage(this.P_inter, sbError);

            if (0 > value)
            {
                throw new Exception("执行函数getmessage出错！！！");
            }

            return sbError.ToString();
        }

        /// <summary>
        /// 获取异常信息
        /// </summary>
        /// <returns></returns>
        public string GetException()
        {
            StringBuilder sbException = new StringBuilder();

            long value = InterfaceHNDll.getexception(this.P_inter, sbException);

            if (0 > value)
            {
                throw new Exception("执行函数getexception错误！！！");
            }

            return sbException.ToString();
        }

        #endregion

        /// <summary>
        /// 开始
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            List<Parameter> listParameters = new List<Parameter>();

            listParameters.Add(new Parameter("oper_centerid", this.Oper_centerid));
            listParameters.Add(new Parameter("oper_hospitalid", this.Oper_hospitalid));
            listParameters.Add(new Parameter("oper_staffid", this.Oper_staffid));

            long value = InterfaceHNDll.start(this.P_inter, this.Func_ID);

            if (-1 == value)
            {
                throw new Exception("接口调用开始失败，错误原因：" + GetMessage());
            }
        }

        /// <summary>
        /// 放置参数
        /// </summary>
        /// <param name="row"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Put(long row, string name, string value)
        {
            return InterfaceHNDll.put(this.P_inter, (int)row, name, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public long PutCol(string name, string value)
        {
            long temp = InterfaceHNDll.putcol(this.P_inter, name, value);

            if (temp < 0)
            {
                throw new Exception("执行函数putcol错误，错误原因：" + GetMessage());
            }

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        public void PutCols()
        {
            foreach (Parameter parameter in this.ParameterList)
            {
                long value = PutCol(parameter.Name, parameter.Value);

                if (0 > value)
                {
                    throw new Exception("传入业务所需的参数\"" + parameter.Name + ":" + parameter.Value + "\"失败!!!");
                }
            }
        }

        /// <summary>
        /// 传入业务所需的参数 没有返回值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void PutNoReturnValue(long row, string name, string value)
        {
            long returnValue = Put(row, name, value);

            if (-1 == returnValue)
            {
                throw new Exception("传入业务所需的参数失败，失败原因：" + GetMessage());
            }
        }

        public void Puts(long row, List<Parameter> listParameters)
        {
            foreach (Parameter parameter in listParameters)
            {
                long value = Put(row, parameter.Name, parameter.Value);

                if (0 > value)
                {
                    throw new Exception("传入业务所需的参数\"" + parameter.Name + ":" + parameter.Value + "\"失败!!!");
                }
            }
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <returns></returns>
        public long Run()
        {
            return InterfaceHNDll.run(this.P_inter);
        }

        /// <summary>
        /// 取结果或设置入参
        /// </summary>
        /// <param name="result_Name"></param>
        /// <returns></returns>
        public void SetResultset(string result_Name)
        {
            long value = InterfaceHNDll.setresultset(this.P_inter, result_Name);

            if (-1 == value)
            {
                throw new Exception("取结果或设置入参错误，错误原因：" + GetMessage());
            }
        }

        /// <summary>
        /// 从接口取得返回的参数值
        /// </summary>
        /// <param name="name">要取得参数名称</param>
        /// <param name="value">获取的值</param>
        /// <returns>返回值小于零, 表示没有Get成功，返回大于零表示为参数值的长度。用getmessage可以取得最近一次出错的错误信息</returns>
        public void GetByName(string name, ref string value)
        {
            StringBuilder sbValue = new StringBuilder(1024);

            int returnValue = InterfaceHNDll.getbyname(this.P_inter, name, sbValue);

            value = sbValue.ToString();

            if (0 > returnValue)
            {
                throw new Exception("执行函数getbyname发生错误，错误原因：" + GetMessage());
            }
        }

        /// <summary>
        /// 跳到结果集后一行记录
        /// </summary>
        public int NextRow()
        {
            return InterfaceHNDll.nextrow(this.P_inter);
        }

        /// <summary>
        /// 获取名称对应的值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="listValue"></param>
        public void GetsByName(string name, ref List<string> listValue)
        {
            do
            {
                string value = string.Empty;

                GetByName(name, ref value);

                listValue.Add(value);
            }
            while (0 < NextRow());
        }

        /// <summary>
        /// 记录集的记录行数
        /// </summary>
        /// <returns></returns>
        public long GetRowCount()
        {
            long value = InterfaceHNDll.getrowcount(this.P_inter);

            if (0 > value)
            {
                throw new Exception("执行函数getrowcount错误，错误原因：" + GetMessage());
            }

            return value;
        }

        /// <summary>
        /// 释放接口实例
        /// </summary>
        public void DestoryInterface()
        {
            if (this.P_inter != null)
            {
                InterfaceHNDll.destoryinterface(this.P_inter);
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~InterfaceHN()
        {
            ClearParameterList();
            //DestoryInterface();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitPara()
        {
            string SQLString = string.Format(@"SELECT  [IP] ,
                                                    [Port] ,
                                                    [Servlet] ,
                                                    [OperCenterID] ,
                                                    [OperHospitalID] ,
                                                    [OperStaffID]
                                            FROM    [HIS_InterfaceHN].[dbo].[JC_ServerInfo]");

            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                this.Addr = ds.Tables[0].Rows[0]["IP"].ToString().Trim();
                this.Port = int.Parse(ds.Tables[0].Rows[0]["Port"].ToString().Trim());
                this.Servlet = ds.Tables[0].Rows[0]["Servlet"].ToString().Trim();
                this.Oper_centerid = ds.Tables[0].Rows[0]["OperCenterID"].ToString().Trim();
                this.Oper_hospitalid = ds.Tables[0].Rows[0]["OperHospitalID"].ToString().Trim();
                this.Oper_staffid = ds.Tables[0].Rows[0]["OperStaffID"].ToString().Trim();

            }
            catch (Exception e)
            {
                throw new Exception("初始化接口服务器参数失败," + e.Message);
            }
        }
    }
}