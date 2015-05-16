using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass
{
    /// <summary>
    /// 
    /// </summary>
    public class Interface
    {
        /// <summary>
        /// 湖南创智接口
        /// </summary>
        private InterfaceHN _interfaceHN = null;

        /// <summary>
        /// 
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
        public Interface(InterfaceHN interfaceHN)
        {
            this.InterfaceHN = interfaceHN;
        }

        /// <summary>
        /// 执行接口
        /// </summary>
        /// <param name="funcID"></param>
        public long ExecInterface(string funcID)
        {
            this.InterfaceHN.Func_ID = funcID;

            this.InterfaceHN.Start();

            return this.InterfaceHN.Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcID"></param>
        /// <param name="listParameter"></param>
        /// <returns></returns>
        public long ExecInterface(string funcID, List<Parameter> listParameter)
        {
            this.InterfaceHN.Func_ID = funcID;

            this.InterfaceHN.Start();

            this.InterfaceHN.ClearParameterList();

            foreach (Parameter para in listParameter)
            {
                this.InterfaceHN.AddParameter(para.Name, para.Value);
            }

            this.InterfaceHN.PutCols();

            return this.InterfaceHN.Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcID"></param>
        /// <param name="listParameter"></param>
        /// <param name="listResultsetAndParameters"></param>
        /// <returns></returns>
        public long ExecInterface(string funcID, List<Parameter> listParameter, List<Parameter> listResultsetAndParameters)
        {
            this.InterfaceHN.Func_ID = funcID;
            this.InterfaceHN.Start();
            this.InterfaceHN.ClearParameterList();

            if (listParameter != null)
            {
                foreach (Parameter para in listParameter)
                {
                    this.InterfaceHN.AddParameter(para.Name, para.Value);
                }
            }

            this.InterfaceHN.PutCols();

            foreach (Parameter parameterResultsetAndParameter in listResultsetAndParameters)
            {
                string result_name = parameterResultsetAndParameter.Name;
                List<List<Parameter>> listListParameter = (List<List<Parameter>>)parameterResultsetAndParameter.Object;

                this.InterfaceHN.Puts(result_name, listListParameter);
            }
            return this.InterfaceHN.Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceHN"></param>
        /// <returns></returns>
        public string GetMessage()
        {
            return this.InterfaceHN.GetMessage();
        }

        /// <summary>
        /// 获取异常信息
        /// </summary>
        /// <returns></returns>
        public string GetException() {
            return this.InterfaceHN.GetException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceHN"></param>
        /// <param name="result_Name"></param>
        public void SetResultset(string result_Name)
        {
            this.InterfaceHN.SetResultset(result_Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void GetByName(string name, ref string value)
        {
            this.InterfaceHN.GetByName(name, ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="length"></param>
        public void GetByName(string name, ref string value, int length)
        {
            this.InterfaceHN.GetByName(name, ref value, length);
        }

        /// <summary>
        /// 跳到结果集后一行记录
        /// </summary>
        /// <returns></returns>
        public int NextRow()
        {
            return this.InterfaceHN.NextRow();
        }

        /// <summary>
        /// 从接口取得返回的当前记录集的记录行数
        /// </summary>
        /// <returns></returns>
        public long GetRowCount() {
            return this.InterfaceHN.GetRowCount();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetByIndex(int index, ref string name, ref string value)
        {
            return this.InterfaceHN.GetByIndex(index, ref name, ref value);
        }

        /// <summary>
        /// 设置IC卡设备的串口号
        /// </summary>
        /// <param name="port">串口号</param>
        /// <returns></returns>
        public long SetICCommPort(int port)
        {
            return this.InterfaceHN.SetICCommPort(port);
        }
    }
}
