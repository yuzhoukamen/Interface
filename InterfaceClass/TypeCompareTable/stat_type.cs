using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceClass.TypeCompareTable
{
    /// <summary>
    /// 费用统计
    /// </summary>
    public class stat_type
    {
        public string GetValue(string name)
        {
            string value = string.Empty;

            switch (name)
            {
                case "F00":
                    value = "西药";
                    break;
                case "F01":
                    value = "中成药";
                    break;
                case "F02":
                    value = "中草药";
                    break;
                case "F03":
                    value = "诊察";
                    break;
                case "F04":
                    value = "检查";
                    break;
                case "F05":
                    value = "化验";
                    break;
                case "F06":
                    value = "放射";
                    break;
                case "F07":
                    value = "治疗费";
                    break;
                case "F08":
                    value = "手术费";
                    break;
                case "F09":
                    value = "护理";
                    break;
                case "F10":
                    value = "接生";
                    break;
                case "F11":
                    value = "特殊检查";
                    break;
                case "F12":
                    value = "特殊治疗";
                    break;
                case "F13":
                    value = "医用材料";
                    break;
                case "F14":
                    value = "氧气";
                    break;
                case "F15":
                    value = "输血";
                    break;
                case "F16":
                    value = "床位";
                    break;
                case "F17":
                    value = "其他医保";
                    break;
                case "F18":
                    value = "其他自费";
                    break;
                case "F19":
                    value = "保健品";
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}