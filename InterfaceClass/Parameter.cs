﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    /// <summary>
    /// 参数
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// 名称
        /// </summary>
        private string _name = string.Empty;

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// 值
        /// </summary>
        private string _value = string.Empty;

        /// <summary>
        /// 获取或设置值
        /// </summary>
        public string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public Parameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Parameter()
        {

        }
    }
}