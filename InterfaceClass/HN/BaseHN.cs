using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace InterfaceClass.HN
{
    public class BaseHN
    {
        /// <summary>
        /// 
        /// </summary>
        public InterfaceHN _interfaceHN = null;

        /// <summary>
        /// 
        /// </summary>
        public InterfaceHN InterfaceHN
        {
            get { return this._interfaceHN; }
            set { this._interfaceHN = value; }
        }

        /// <summary>
        /// 获取对象的属性名称、值和描述
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns>对象列表</returns>
        public List<Parameter> GetProperties<T>(T t)
        {
            List<Parameter> list = new List<Parameter>();

            if (t == null)
            {
                return list;
            }
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return list;
            }
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name; //名称
                object value = item.GetValue(t, null);  //值
                string des = ((DescriptionAttribute)Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute))).Description;// 属性值

                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    Parameter parameter = new Parameter();

                    parameter.Name = name;
                    parameter.Value = value == null ? "" : value.ToString();
                    parameter.Object = des;

                    list.Add(parameter);
                }
                else
                {
                    GetProperties(value);
                }
            }
            return list;
        }
    }
}
