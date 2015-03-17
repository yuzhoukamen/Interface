using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace InterfaceClass
{
    /// <summary>
    /// 湖南创智和宇信息系统Hygeia城镇职工基本医疗保险管理信息系统接口类
    /// </summary>
    public class InterfaceHNDll
    {
        /// <summary>
        /// 该函数创建一个新的接口实例，
        /// 但这个函数没有初始化接口，必须再调用init函数初始化接口，
        /// 此函数返回接口指针p_inter，它将作为其他函数入口参数
        /// </summary>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll")]
        public static extern IntPtr newinterface();

        /// <summary>
        /// 该函数建立一个新的接口实例并将接口初始化，不需要再调用init函数。
        /// </summary>
        /// <param name="Addr">参数Addr为应用服务器IP地址</param>
        /// <param name="Port">Port为应用服务器端口号</param>
        /// <param name="Servlet">Servlet为应用服务器入口Servlet的名称</param>
        /// <returns>此函数返回接口指针p_inter，它将作为其他函数入口参数。</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern IntPtr newinterfacewithinit(string Addr, int Port, string Servlet);

        /// <summary>
        /// 初始化接口
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="Addr">参数Addr为应用服务器IP地址</param>
        /// <param name="Port">Port为应用服务器端口号</param>
        /// <param name="Servlet">Servlet为应用服务器入口Servlet的名称</param>
        /// <returns>返回-1表示没有Start成功，返回1表示调用成功</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long init(IntPtr p_inter, string Addr, int Port, string Servlet);

        /// <summary>
        /// 从内存中释放接口的实例
        /// </summary>
        /// <param name="p_inter">接口指针</param>
        [DllImport("InterfaceHN.dll")]
        public static extern void destoryinterface(IntPtr p_inter);

        /// <summary>
        /// 该函数为一次接口调用的开始
        /// </summary>
        /// <param name="p_inter">入口参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="FUNC_ID">参数FUNC_ID为要进行的业务的功能号，在上一次Start的业务没有进行完之前不能进行下一次Start</param>
        /// <returns>返回-1表示没有Start成功，返回1表示调用成功</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long start(IntPtr p_inter, string FUNC_ID);

        /// <summary>
        /// 该函数用来在一次接口调用中传入业务所需的参数
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="row">row为多行参数的行号</param>
        /// <param name="p_name">p_name为参数名称，以字符串小写表示</param>
        /// <param name="p_value">p_value为参数值，可以是字符串和数值型</param>
        /// <returns>返回-1表示没有Put成功，返回大于零表示Put成功 ，此值同时为当前的行号。如果入参有多个记录集，可用setresultset函数设置要传参数的记录集</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long put(IntPtr p_inter, int row, string p_name, string p_value);

        /// <summary>
        /// 该函数用来在一次接口调用中传入业务所需的参数
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="p_name">在当前的行，p_name为参数名称，以字符串小写表示</param>
        /// <param name="p_value">p_value为参数值，可以是字符串和数值型</param>
        /// <returns>返回-1表示没有Put成功，返回大于零表示Put成功，此值同时为当前的行号</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long putcol(IntPtr p_inter, string p_name, string p_value);

        /// <summary>
        /// 该函数开始一次接口运行，直接将参数打包成送往Servlet，如果出错，将返回一个错误
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns>返回-1表示没有Run成功，返回大于零的值为返回参数的记录条数</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long run(IntPtr p_inter);

        /// <summary>
        /// 参数p_inter为函数newinterface()或者newinterfacewithinit的返回值
        /// 当取结果时：
        ///     将当前记录集设置为由result_name指定的记录集，
        ///     如果指的记录集不存在，则不会改变当前记录集。
        ///     返回－1表示不成功，返回大于等于零的值为记录集记录数。
        /// 当设置入参时：
        ///     将当前记录集设置为由result_name指定的记录集，
        ///     如果指的记录集存在，则改变当前记录集为存在的记录集，
        ///     其中有个特殊的记录集Parameters, 它是个参数集，
        ///     没有记录行，其他都有记录行，通过nextrow, prevrow, firstrow, lastrow。
        ///     返回－1表示不成功，返回大于等于零的值为记录集记录数
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="result_name"></param>
        /// <returns></returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long setresultset(IntPtr p_inter, string result_name);

        /// <summary>
        /// 跳到结果集后一行记录
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns>返回－1表示调用不成功，返回大于零表示调用成功，同时此值为当前的行号</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern int nextrow(IntPtr p_inter);

        /// <summary>
        /// 跳到结果集前一行记录
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns>返回－1表示调用不成功，返回大于零表示调用成功，同时此值为当前的行号</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern int prevrow(IntPtr p_inter);

        /// <summary>
        /// 跳到结果集第一行记录
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns>返回－1表示调用不成功，返回1表示调 用成功</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern int firstrow(IntPtr p_inter);

        /// <summary>
        /// 跳到结果集最后一行记录
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns>返回－1表示调用不成功，返回大于零表示为当前记录集记录数</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern int lastrow(IntPtr p_inter);

        /// <summary>
        /// 函数用来从接口取得返回的参数值
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="p_name">参数p_name为需要接口返回的字段名，需要用小写表示</param>
        /// <param name="p_value">参数p_value为接口返回的数值，
        /// 必须在客户端分配足够大的内存，长度单位为sizeof(char)。
        /// 如果送入的参数p_value为空指针(NULL)，返回该字段的长度，可以根据这个长度分配空间</param>
        /// <returns>返回值小于零, 表示没有Get成功，返回大于零表示为参数值的长度。用getmessage可以取得最近一次出错的错误信息</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern int getbyname(IntPtr p_inter, string p_name, StringBuilder p_value);

        /// <summary>
        /// 该函数用来从接口取得返回的参数值
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="index">参数index表示列的顺序号，从1开始</param>
        /// <param name="p_name">参数p_name为接口返回的字段名,必须分配足够空间，如果没有分配空间将不返回字段名</param>
        /// <param name="p_value">参数p_value为接口返回的数值，
        /// 必须在客户端分配足够大的内存，长度单位为sizeof(char)。
        /// 如果送入的参数p_value为为空指针(NULL)，返回该字段的长度，可以根据这个长度分配空间</param>
        /// <returns>返回值小于零, 表示没有调用成功，返回值大于零, 表示参数值的长度。用getmessage可以取得最近一次出错的错误信息</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern int getbyindex(IntPtr p_inter, int index, string p_name, StringBuilder p_value);

        /// <summary>
        /// 函数在所有函数出错时，调用它，
        /// 将得到一个错误信息，错误信息存放在err指向的一片内存空间中，
        /// 当入参err为空指针(NULL)时，将返回message的长度。
        /// 调用此函数应保证err指向的内存有足够的长度存放返回的错误信息。
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="err">错误信息</param>
        /// <returns>函数返回值小于零时，函数执行不成功</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long getmessage(IntPtr p_inter, StringBuilder err);

        /// <summary>
        /// 该函数在所有函数出错时，调用它，将得到一个详细的错误信息，通过exception串返回
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="exception">当exception为NULL时，将返回message的长度</param>
        /// <returns>函数返回值小于零时，函数执行不成功</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long getexception(IntPtr p_inter, StringBuilder exception);

        /// <summary>
        /// 该函数用来从接口取得返回的当前记录集的记录行数
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <returns>返回值小于零, 表示没有Get成功，返回值大于零, 表示当前记录集的记录行数</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long getrowcount(IntPtr p_inter);

        /// <summary>
        /// 该函数用来设置IC卡设备的串口号
        /// </summary>
        /// <param name="p_inter">参数p_inter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="comm">参数comm为与IC卡连接的串口号，com1表示1，com2表示2…</param>
        /// <returns>返回值小于零, 表示没有成功，返回值大于等于零, 表示调用成功</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long set_ic_commport(IntPtr p_inter, int comm);

        /// <summary>
        /// 该函数用来将数据按base64格式编码
        /// </summary>
        /// <param name="pSrc">参数pSrc为源数据</param>
        /// <param name="nSize">nSize为源数据长度</param>
        /// <param name="pDest">pDest为编码后的数据</param>
        /// <returns>返回值小于零, 表示没有成功，返回值大于等于零, 表示为编码后的字节数</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long encode64(StringBuilder pSrc, int nSize, StringBuilder pDest);

        /// <summary>
        /// 该函数用来将数据按base64格式解码
        /// </summary>
        /// <param name="pSrc">参数pSrc为源数据</param>
        /// <param name="nSize">nSize为源数据长度</param>
        /// <param name="pDest">pDest为解码后的数据</param>
        /// <returns>返回值小于零, 表示没有成功，返回值大于等于零, 表示为解码后的字节数</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long decode64(StringBuilder pSrc, int nSize, StringBuilder pDest);

        /// <summary>
        /// 该函数用来将数据按base64格式编码时，用源数据长度来获得编码后的数据长度
        /// </summary>
        /// <param name="nSize">参数nSize为源数据长度</param>
        /// <returns>返回值小于零, 表示没有成功，返回值大于等于零, 表示为编码后的字节数</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long encodesize(int nSize);

        /// <summary>
        /// 该函数用来将数据按base64格式解码时，用源数据长度来获得解码后的数据长度
        /// </summary>
        /// <param name="nSize">参数nSize为源数据长度</param>
        /// <returns>返回值小于零, 表示没有成功，返回值大于等于零, 表示为解码后的字节数</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long decodesize(int nSize);

        /// <summary>
        /// 该函数用来将数据按base64格式解码，并将解码后的数据存到filename文件里
        /// </summary>
        /// <param name="pSrc">参数pSrc为源数据</param>
        /// <param name="nSize">nSize为源数据长度</param>
        /// <param name="filename">filename为解码后的数据要保存的文件名</param>
        /// <returns>返回值小于零, 表示没有成功，返回值大于等于零, 表示为解码后的字节数</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern long decode64_tofile(StringBuilder pSrc, int nSize, StringBuilder filename);

        /// <summary>
        /// 该函数用来设置接口的运行模式，当flag为1时将产生调试信息并且写入指定目录direct下的日志文件中
        /// </summary>
        /// <param name="pinter">参数pinter为函数newinterface()或者newinterfacewithinit的返回值</param>
        /// <param name="flag">flag 为调试标志,0表示不作调试，1表示记录出参和出错的信息，2表示记录所有信息</param>
        /// <param name="direct">direct为存放调试信息日志文件的目录</param>
        /// <returns>返回值小于零, 表示没有成功，返回值大于等于零, 表示成功</returns>
        [DllImport("InterfaceHN.dll")]
        public static extern int setdebug(IntPtr pinter, int flag, StringBuilder direct);
    }
}