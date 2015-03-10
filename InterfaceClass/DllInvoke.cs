using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace InterfaceClass
{
    /*
     * 下面是一个调用例子
     * public delegate int Compile(String command, StringBuilder inf)
     * {
     *      DllInvoke dll= new DllInvoke(Server.MapPath(@"~/Bin/Judge.dll"));
     *      
     *      Compile compile=(Compile)dll.Invoke("Compile",typeof(Compile));
     *      
     *      StringBuilder inf;
     *      
     *      compile(@"gcc a.c -o a.exe",inf);//这里是调用我的dll里定义的Compile函数
     * }
     * */

    /// <summary>
    /// 动态加载c、c++的dll
    /// </summary>
    public class DllInvoke
    {
        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(String path);

        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, String funcName);

        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);

        /// <summary>
        /// 句柄
        /// </summary>
        private IntPtr hLib;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dllPath"></param>
        public DllInvoke(String dllPath)
        {
            this.hLib = LoadLibrary(dllPath);
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~DllInvoke()
        {
            FreeLibrary(hLib);
        }

        /// <summary>
        /// 将要执行的函数转换成委托
        /// </summary>
        /// <param name="apiName">方法名称</param>
        /// <param name="t">类型</param>
        /// <returns>委托</returns>
        public Delegate Invoke(String apiName, Type t)
        {
            IntPtr api = GetProcAddress(hLib, apiName);

            return (Delegate)Marshal.GetDelegateForFunctionPointer(api, t);
        }
    }
}