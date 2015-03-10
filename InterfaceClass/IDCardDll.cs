using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace InterfaceClass
{
    /// <summary>
    /// 身份证dll调用方法
    /// (HG_IDcard.dll动态库是二代身份证接口调用的动态库)
    /// 使用的过程当中需要注意以下三点：
    /// 1、本接口采用VC编写，模式跟IC卡读卡类似。接口动态库名称：HG_IDcard.dll
    /// 2、如设备是USB口通讯的，必须安装厂家给的USB驱动，否则接口找不到设备。
    /// 3、本接口获取照片采用保存本地文件的模式，每次读完信息之后获取的照片文件名都是：idc_ph.bmp  格式为bmp的彩色图片在当前路径下面。
    /// 注意：确认公安部授权文件termb.lic在PC机C:\根目录下
    /// </summary>
    public class IDCardDll
    {
        /// <summary>
        /// 清空接口里面的信息，获取信息前先调用此函数清空接口里面的信息，避免信息重复或者张冠李戴现象。
        /// </summary>
        /// <returns>等于0成功 小于0失败</returns>
        [DllImport("HG_IDcard.dll")]
        public static extern int IDCReset();

        /// <summary>
        /// 启动设备读取二代身份证里面的文字信息，清空信息后调用。因为二代身份证读写器是接触式的，大概每5至6秒寻找一次二代身份证，6秒后自动报出找卡超时。
        /// </summary>
        /// <returns>等于0成功 小于0失败</returns>
        [DllImport("HG_IDcard.dll")]
        public static extern int IDCStart();

        /// <summary>
        /// 该函数获取信息
        /// </summary>
        /// <param name="IDCname">IDCname为要获取信息的名称</param>
        /// <param name="IDCvalue">IDCvalue为返回对应的信息的值指针</param>
        /// <returns>等于0成功 小于0失败</returns>
        [DllImport("HG_IDcard.dll")]
        public static extern int IDCGet(StringBuilder IDCname, StringBuilder IDCvalue);

        /// <summary>
        /// 当任何一个函数出错时，调用此函数获取错误信息
        /// </summary>
        /// <param name="msg">msg为返回的错误文字信息指针</param>
        /// <returns>小于0失败</returns>
        [DllImport("HG_IDcard.dll")]
        public static extern int IDCGeterrMsg(StringBuilder msg);
    }
}