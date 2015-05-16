using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Globalization;

namespace Windows.Class
{
    public class Function
    {
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="sNumeric"></param>
        /// <returns></returns>
        public static bool IsNumeric(string sNumeric)
        {
            if (sNumeric == null || sNumeric.Trim() == "") { return false; }

            return (new Regex("^[\\+\\-]?[0-9]*\\.?[0-9]+$")).IsMatch(sNumeric);
        }
        /// <summary>
        /// 判断是否是日期
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static bool IsDate(string sDate)
        {
            if (sDate != null && sDate.Trim() != "")
            {
                try
                {
                    DateTime dt = DateTime.Parse(sDate.Trim());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断字符串是否是bigint数据
        /// </summary>
        /// <param name="sBigInt">要转换的bigint字符串</param>
        /// <returns>是或不是</returns>
        public static bool isBigInt(string sBigInt)
        {
            if (sBigInt != null && sBigInt.Trim() != "")
            {
                try
                {
                    long value = long.Parse(sBigInt.Trim());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 检查对象是否为空
        /// </summary>
        /// <param name="obj">要检查的对象</param>
        /// <returns>是或不是</returns>
        public static bool IsNull(object obj)
        {
            if (obj != null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 检查字符串是否为空字符串
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        /// <returns>是或不是</returns>
        public static bool IsEmptyString(string str)
        {
            if (str != null && str.Trim() != string.Empty)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 检查字符串是否是true或false的bool值
        /// </summary>
        /// <param name="sBool">要检查的字符串值</param>
        /// <returns>返回是或不是</returns>
        public static bool IsBool(string sBool)
        {
            if (sBool != null && sBool.Trim() != string.Empty)
            {
                try
                {
                    bool value = bool.Parse(sBool.Trim().ToLower());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 是不是整型数字
        /// </summary>
        /// <param name="sInt">要测试的字符串</param>
        /// <returns>返回是或不是</returns>
        public static bool IsInt(string sInt)
        {
            if (sInt != null && sInt != string.Empty)
            {
                try
                {
                    int value = int.Parse(sInt.Trim());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public static bool IsDateTime(string sDateTime)
        {
            if (sDateTime != null && sDateTime != string.Empty)
            {
                try
                {
                    DateTime value = DateTime.Parse(sDateTime.Trim());

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 是不是double类型的数据
        /// </summary>
        /// <param name="sDouble">要检查的数据</param>
        /// <returns>是或不是</returns>
        public static bool IsDouble(string sDouble)
        {
            if (sDouble != null && sDouble != string.Empty)
            {
                try
                {
                    double value = double.Parse(sDouble.Trim());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 取数据集中的子集
        /// </summary>
        /// <param name="ds">要处理的数据集</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns>分页之后的数据集</returns>
        public static DataSet SplitDataSet(DataSet ds, int pageSize, int pageIndex)
        {
            DataSet vds = new DataSet();
            vds = ds.Clone();
            if (pageIndex < 1) pageIndex = 1;//如果小于1，取第一页
            if ((ds.Tables[0].Rows.Count + pageSize) <= (pageSize * pageIndex)) pageIndex = 1;

            int fromIndex = pageSize * (pageIndex - 1);//开始行
            int toIndex = pageSize * pageIndex - 1; //结束行

            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i >= (ds.Tables[0].Rows.Count)) //到达这一行，退出
                    break;
                vds.Tables[0].ImportRow(ds.Tables[0].Rows[i]);
            }
            ds.Dispose();
            return vds;
        }
        /// <summary>
        /// 根据所具有的Unicode编码用C#语言把它转换成汉字的代码
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        /// <returns>生成的字符串</returns>
        public static string UnicodeToGB(string text)
        {
            System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(text, "\\\\u([\\w]{4})");
            if (mc != null && mc.Count > 0)
            {
                foreach (System.Text.RegularExpressions.Match m2 in mc)
                {
                    string v = m2.Value;
                    string word = v.Substring(2);
                    byte[] codes = new byte[2];
                    int code = Convert.ToInt32(word.Substring(0, 2), 16);
                    int code2 = Convert.ToInt32(word.Substring(2), 16);
                    codes[0] = (byte)code2;
                    codes[1] = (byte)code;
                    text = text.Replace(v, Encoding.Unicode.GetString(codes));
                }
            }
            else
            {

            }
            return text;
        }
        /// <summary>
        /// 质数就是在所有比1大的整数中，除了1和它本身以外，不再有别的约数，这种整数叫做质数，质数又叫做素数
        /// 查询前给定数量的质数
        /// </summary>
        /// <param name="primeNum">数量</param>
        public List<int> GetPrimes(int primeNum)
        {
            int num;
            int i;
            int primes = 1;
            bool isprime;
            List<int> primeList = new List<int>();

            for (num = 2; primes <= primeNum; num++)
            {
                isprime = true;

                // 判断是否为质数
                for (i = 2; i <= num / 2; i++)
                {
                    if ((num % i) == 0)
                    {
                        isprime = false;
                    }
                }
                if (isprime)
                {
                    primeList.Add(num);
                    primes += 1;
                }
            }
            return primeList;
        }
        /// <summary>
        /// 质数就是在所有比1大的整数中，除了1和它本身以外，不再有别的约数，这种整数叫做质数，质数又叫做素数
        /// 2-MaxValue之间的所有质数
        /// </summary>
        /// <param name="maxValue">要求得的MaxValue</param>
        /// <param name="maxPrime">最大质数</param>
        /// <returns>所有的质数</returns>
        public List<int> GetPrimes(int maxValue, out int maxPrime)
        {
            int num;
            int i;
            int primes = 1;
            bool isprime;
            maxPrime = 2;
            List<int> primeList = new List<int>();

            for (num = 2; num < maxValue; num++)
            {

                isprime = true;

                // 判断是否为质数
                for (i = 2; i <= num / 2; i++)
                {
                    if ((num % i) == 0)
                    {
                        isprime = false;
                    }
                }
                if (isprime)
                {
                    primeList.Add(num);
                    if (num > maxPrime)
                    {
                        maxPrime = num;
                    }
                    primes += 1;
                }
            }
            return primeList;
        }
        /// <summary>
        /// 汉字转换为Unicode编码
        /// </summary>
        /// <param name="str">要编码的汉字字符串</param>
        /// <returns>Unicode编码的的字符串</returns>
        public static string ToUnicode(string str)
        {
            byte[] bts = Encoding.Unicode.GetBytes(str);
            string r = "";
            for (int i = 0; i < bts.Length; i += 2) r += "\\\\u" + bts[i + 1].ToString("x").PadLeft(2, '0') + bts[i].ToString("x").PadLeft(2, '0');
            return r;
        }
        /// <summary>
        /// 将Unicode编码转换为汉字字符串
        /// </summary>
        /// <param name="str">Unicode编码字符串</param>
        /// <returns>汉字字符串</returns>
        public static string ToGB2312(string str)
        {
            string r = "";
            MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            byte[] bts = new byte[2];
            foreach (Match m in mc)
            {
                bts[0] = (byte)int.Parse(m.Groups[2].Value, NumberStyles.HexNumber);
                bts[1] = (byte)int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
                r += Encoding.Unicode.GetString(bts);
            }
            return r;
        }
        /// <summary>
        /// 获取汉字拼音码
        /// </summary>
        /// <param name="strText">要转换的汉字</param>
        /// <returns>处理之后的汉字简拼码</returns>
        public static string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += GetSpell(strText.Substring(i, 1));
            }
            return myStr;
        }
        /// <summary>
        /// 单个字符转换成简拼码
        /// </summary>
        /// <param name="cnChar">要处理的单个汉字</param>
        /// <returns>处理之后的简拼码</returns>
        public static string GetSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }
        /// <summary>
        /// 获取汉字的简拼码（小写）
        /// </summary>
        /// <param name="str">要处理的汉字</param>
        /// <param name="isLower">是否小写(默认大写)</param>
        /// <returns>要转换的汉字的简拼码</returns>
        public static string GetJPCode(string str, bool isLower)
        {
            string result = string.Empty;

            foreach (char temp in str)
            {
                result += GetSpell(temp.ToString());
            }

            return (isLower ? result.ToLower() : result.ToUpper());
        }
        /// <summary>
        /// 处理年龄
        /// </summary>
        /// <param name="age">年龄</param>
        /// <param name="type">类型（1-岁、2-月或3-日）</param>
        /// <returns></returns>
        public static double DealAge(double age, int type)
        {
            double result = 0;
            switch (type)
            {
                //岁
                case 1:
                    result = age;
                    break;
                //月
                case 2:
                    result = age * 0.03042;
                    break;
                //日
                case 3:
                    result = age * 0.001;
                    break;
            }
            return result;
        }
        /// <summary>
        /// 处理年龄(1：岁 2：月 3：日)
        /// </summary>
        /// <param name="age">年龄</param>
        /// <returns>输出的内容（比如1.2,岁）</returns>
        public static string DealAge(double age)
        {
            int result = 0;
            if (age <= 0)
            {
                return "0,1";
            }
            if (age >= 1)
            {
                return age + ",1";
            }
            if (int.TryParse((age * 1000).ToString(), out result) && age * 1000 == int.Parse((age * 1000).ToString()))
            {
                return (age * 1000).ToString() + ",3";
            }
            result = ((int)(age / 0.03042 * 10 + 0.5)) / 10;

            return result + ",2";
        }
        /// <summary>
        /// 处理年龄(例如（1岁、2月或3日）)
        /// </summary>
        /// <param name="age">年龄</param>
        /// <param name="isDot">是否有逗号</param>
        /// <returns>输出的内容</returns>
        public static string DealAgeResult(double age, bool isDot)
        {
            string strAge = DealAge(age);
            string result = string.Empty;

            switch (int.Parse(strAge.Split(',')[1]))
            {
                case 1:
                    result = strAge.Split(',')[0] + (isDot ? "," : "") + "岁";
                    break;
                case 2:
                    result = strAge.Split(',')[0] + (isDot ? "," : "") + "月";
                    break;
                case 3:
                    result = strAge.Split(',')[0] + (isDot ? "," : "") + "日";
                    break;
            }
            return result;
        }
        /// <summary>
        /// 处理年龄(例如（1岁、2月或3日）)
        /// </summary>
        /// <param name="age">年龄</param>
        /// <returns>输出的内容</returns>
        public static string DealAgeResult(double age)
        {
            string strAge = DealAge(age);
            string result = string.Empty;

            switch (int.Parse(strAge.Split(',')[1]))
            {
                case 1:
                    result = strAge.Split(',')[0] + "岁";
                    break;
                case 2:
                    result = strAge.Split(',')[0] + "月";
                    break;
                case 3:
                    result = strAge.Split(',')[0] + "日";
                    break;
            }
            return result;
        }
        /// <summary>
        /// 获取时间(flag标志格式)（默认输出全部）
        /// 0：输出全部（2012-12-01 23:22:22）
        /// 1：输出年月日（2012-12-01）
        /// 2：输出年月日其他为0（2012-12-01 00:00:00）
        /// </summary>
        /// <param name="flag">标志
        /// 0：输出全部（2012-12-01 23:22:22）
        /// 1：输出年月日（2012-12-01）
        /// 2：输出年月日其他为0（2012-12-01 00:00:00）
        /// </param>
        /// <returns></returns>
        public static string GetDateTime(int flag)
        {
            return GetDateTime(flag, 0);
        }

        /// <summary>
        /// 获取时间(flag标志格式)（默认输出全部）
        /// 0：输出全部（2012-12-01 23:22:22）
        /// 1：输出年月日（2012-12-01）
        /// 2：输出年月日其他为0（2012-12-01 00:00:00）
        /// </summary>
        /// <param name="flag">标志
        /// 0：输出全部（2012-12-01 23:22:22）
        /// 1：输出年月日（2012-12-01）
        /// 2：输出年月日其他为0（2012-12-01 00:00:00）
        /// </param>
        /// <param name="addDays">要增加的天数</param>
        /// <returns></returns>
        public static string GetDateTime(int flag, double addDays)
        {
            string yy = DateTime.Now.AddDays(addDays).Year.ToString();
            string mm = DateTime.Now.AddDays(addDays).Month.ToString();
            string dd = DateTime.Now.AddDays(addDays).Day.ToString();
            string hh = DateTime.Now.AddDays(addDays).Hour.ToString();
            string fz = DateTime.Now.AddDays(addDays).Minute.ToString();
            string ss = DateTime.Now.AddDays(addDays).Second.ToString();
            string result = string.Empty;

            mm = (int.Parse(mm) < 10 ? ("0" + mm) : mm);
            dd = (int.Parse(dd) < 10 ? ("0" + dd) : dd);
            hh = (int.Parse(hh) < 10 ? ("0" + hh) : hh);
            fz = (int.Parse(fz) < 10 ? ("0" + fz) : fz);
            ss = (int.Parse(ss) < 10 ? ("0" + ss) : ss);

            switch (flag)
            {
                //输出全部
                case 0:
                    result = yy + "-" + mm + "-" + dd + " " + hh + ":" + fz + ":" + mm;
                    break;
                //输出年月日
                case 1:
                    result = yy + "-" + mm + "-" + dd;
                    break;
                //输出年月日其他为0
                case 2:
                    result = yy + "-" + mm + "-" + dd + " 00:00:00";
                    break;
                default:
                    result = yy + "-" + mm + "-" + dd + " " + hh + ":" + fz + ":" + mm;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 计算字符串的像素值(px)
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>返回计算后的像素值</returns>
        public static float GetStringPXLength(string str)
        {
            Bitmap image = new Bitmap(1000, 14);
            Graphics g = Graphics.FromImage(image);
            SizeF sf = g.MeasureString(str, new Font(new FontFamily("宋体"), 12, FontStyle.Regular));

            return sf.Width;
        }

        public bool isNumberic(string message)
        {
            System.Text.RegularExpressions.Regex rex =
            new System.Text.RegularExpressions.Regex(@"^\d+$");
            if (rex.IsMatch(message))
            {
                return true;
            }
            else
                return false;
        }
    }
}
