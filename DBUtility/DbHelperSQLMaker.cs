using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Alif.DBUtility
{
    public class DbHelperSQLMaker
    {
        #region 将SQLServer中的类型转换为C#.Net中的类型
        /// <summary>
        /// 将SQLServer中的类型转换为C#.Net中的类型
        /// </summary>
        /// <param name="_type">SQLServer类型</param>
        /// <returns>转换后的C#.Net类型</returns>
        public static string GetType(string _type)
        {
            string _NumType = _type.ToLower();
            switch (_NumType)
            {
                case "bigint": return "long";
                case "bit": return "int";
                case "decimal": return "decimal";
                case "int": return "int";
                case "money": return "double";
                case "numeric": return "";
                case "smallint": return "int";
                case "smallmoney": return "float";
                case "tinyint": return "byte";

                case "float": return "double";
                case "real": return "float";

                case "date": return "DateTime";
                case "datetimeoffset": return "DateTime";
                case "datetime2": return "DateTime";
                case "smalldatetime": return "DateTime";
                case "datetime": return "DateTime";
                case "time": return "DateTime";

                case "char": return "string";
                case "varchar": return "string";
                case "text": return "string";

                case "nchar": return "string";
                case "nvarchar": return "string";
                case "ntext": return "string";

                case "binary": return "byte[]";
                case "varbinary": return "byte[]";
                case "image": return "byte[]";

                case "uniqueidentifier": return "Guid";
                case "cursor": return "string";
                case "timestamp": return "string";
                case "hierarchyid": return "string";
                case "sql_variant": return "string";
                case "xml": return "string";
                case "table": return "string";

                default:
                    return "string";
            }
        }
        #endregion

        #region 将字符串进行相关处理（过滤空格、无关符号）
        /// <summary>
        /// 将字符串进行相关处理（过滤空格、无关符号）
        /// </summary>
        /// <param name="_stringEditor">要处理的字符串</param>
        /// <param name="isUper">是否首字母大写</param>
        /// <returns>处理后的字符串</returns>
        public static string StringMaker(string _stringEditor, bool isUper)
        {
            string _result = string.Empty;
            char[] _temp = _stringEditor.ToCharArray();
            int index = 1;
            foreach (char c in _temp)
            {
                if (!string.IsNullOrEmpty(c.ToString().Trim()))
                {
                    if (isUper)//首字母大写
                    {
                        if (index == 1)//第一次进入
                        {
                            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_')
                            {
                                _result += c.ToString().ToUpper();
                                index--;
                            }
                        }
                        else
                        {
                            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_' || (c >= '0' && c <= '9'))
                            {
                                _result += c.ToString();
                            }
                        }
                    }
                    else//首字母小写
                    {
                        if (index == 1)
                        {
                            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_')
                            {
                                _result += c.ToString().ToLower();
                                index--;
                            }
                        }
                        else
                        {
                            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_' || (c >= '0' && c <= '9'))
                            {
                                _result += c.ToString();
                            }
                        }
                    }
                }
            }
            return _result;
        }
        #endregion

        #region 获取表格中的主键
        /// <summary>
        /// 获取表格中的主键(未处理)
        /// </summary>
        /// <param name="_dtEditor">受影响的表格</param>
        /// <returns></returns>
        public static string GetKeyColomnName(DataTable _dtEditor)
        {
            DataRow _KeyColomn = GetKeyColomn(_dtEditor);
            return _KeyColomn["ColumnName"].ToString();
        }
        #endregion

        #region 获取主键列
        /// <summary>
        /// 获取主键列
        /// </summary>
        /// <param name="_dtEditor">受影响的表格</param>
        /// <returns></returns>
        internal static DataRow GetKeyColomn(DataTable _dtEditor)
        {
            try
            {
                foreach (DataRow _DataRowEditor in _dtEditor.Rows)
                {
                    if (_DataRowEditor["isPK"].ToString().Trim() != "") return _DataRowEditor;
                }
                return _dtEditor.Rows[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 获取主键类型(经转换过的.Net数据类型)
        /// <summary>
        /// 获取主键类型(经转换过的.Net数据类型)
        /// </summary>
        /// <param name="_dtEditor">受影响的表格</param>
        /// <returns>经转换过的.Net数据类型</returns>
        public static string GetKeyType(DataTable _dtEditor)
        {
            DataRow _keyColomn = GetKeyColomn(_dtEditor);
            return GetType(_keyColomn["TypeName"].ToString());
        }
        #endregion

        #region 获取默认值
        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <param name="_drEditor">受影响的列信息</param>
        /// <returns></returns>
        internal static string GetDefaultValues(DataRow _drEditor)
        {
            string _defaultValues = _drEditor["defaultVal"].ToString();

            if (_defaultValues.Trim() != "") return _defaultValues;
            else return "System.DBNull.Value";
        }
        #endregion

        #region 返回用于一个表格中所有列的信息
        /// <summary>
        /// 返回用于一个表格中所有列的信息
        /// </summary>
        /// <param name="_dtEditor">受影响的表</param>
        /// <returns>所有列信息</returns>
        public static string GetAllColomns(DataTable _dtEditor)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < _dtEditor.Rows.Count; i++)
            {
                string _colomnName = _dtEditor.Rows[i]["ColumnName"].ToString();
                builder.Append("[" + _colomnName + "]");
                if ((i + 1) == _dtEditor.Rows.Count) break;
                builder.Append(",");
            }

            return builder.ToString();
        }
        #endregion

        #region 获取主键类型和长度
        /// <summary>
        /// 获取主键类型和长度
        /// </summary>
        /// <param name="_dtEditor">受影响的表</param>
        /// <returns></returns>
        public static string GetKeyTypeAndLength(DataTable _dtEditor)
        {
            DataRow _keyRow = GetKeyColomn(_dtEditor);
            return GetTypeAndLength(_keyRow);
        }
        #endregion

        #region 获取类型和长度
        /// <summary>
        /// 获取类型和长度
        /// </summary>
        /// <param name="_drEditor">受影响的行记录</param>
        /// <returns></returns>
        public static string GetTypeAndLength(DataRow _drEditor)
        {
            string _type = _drEditor["TypeName"].ToString();
            string _length = _drEditor["Length"].ToString();

            switch (_type)
            {
                case "bigint": return "BigInt," + _length;
                case "bit": return "Bit," + _length;
                case "decimal": return "Decimal," + _length;
                case "int": return "Int," + _length;
                case "money": return "Money," + _length;
                case "numeric": return "//对不起，遇到未知类型";
                case "smallint": return "SmallInt," + _length;
                case "smallmoney": return "SmallMoney," + _length;
                case "tinyint": return "TinyInt," + _length;

                case "float": return "Float," + _length;
                case "real": return "Real," + _length;

                case "date": return "Date," + _length;
                case "datetimeoffset": return "DateTimeOffset," + _length;
                case "datetime2": return "DateTime2," + _length;
                case "smalldatetime": return "SmallDateTime," + _length;
                case "datetime": return "DateTime," + _length;
                case "time": return "Time," + _length;

                case "char": return "Char," + _length;
                case "varchar": return "VarChar," + _length;
                case "text": return "Text," + _length;

                case "nchar": return "NChar," + _length;
                case "nvarchar": return "NVarChar," + _length;
                case "ntext": return "NText," + _length;

                case "binary": return "Binary";
                case "varbinary": return "VarBinary";
                case "image": return "Image";

                case "uniqueidentifier": return "UniqueIdentifier," + _length;
                case "cursor": return "//对不起，遇到未知类型";
                case "timestamp": return "Timestamp," + _length;
                case "hierarchyid": return "";
                case "sql_variant": return "";
                case "xml": return "Xml," + _length;
                case "table": return "//对不起，遇到未知类型";

                default:
                    return "NVarChar,50";
            }
        }
        #endregion

        #region 获取数据转换信息
        /// <summary>
        /// 获取数据转换信息
        /// </summary>
        /// <param name="_drEditor">受影响的列</param>
        /// <returns>数据转化数据</returns>
        public static string GetTypeParseInfomation(DataRow _drEditor)
        {
            string _colomnName = _drEditor["ColumnName"].ToString();
            string _colomnType = _drEditor["TypeName"].ToString();

            switch (_colomnType)
            {
                case "bigint": return "long.Parse(dr[\"" + _colomnName + "\"].ToString())";
                case "bit": return "int.Parse(dr[\"" + _colomnName + "\"].ToString())";
                case "decimal": return "decimal.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "int": return "int.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "money": return "double.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "numeric": return "\"\"";
                case "smallint": return "int.Parse(dr[\"" + _colomnName + "\"].ToString())";
                case "smallmoney": return "float.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "tinyint": return "byte.Parse (dr[\"" + _colomnName + "\"].ToString())";

                case "float": return "double.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "real": return "float.Parse (dr[\"" + _colomnName + "\"].ToString())";

                case "date": return "DateTime.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "datetimeoffset": return "DateTime.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "datetime2": return "DateTime.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "smalldatetime": return "DateTime.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "datetime": return "DateTime.Parse (dr[\"" + _colomnName + "\"].ToString())";
                case "time": return "DateTime.Parse (dr[\"" + _colomnName + "\"].ToString())";

                case "char": return "dr[\"" + _colomnName + "\"].ToString()";
                case "varchar": return "dr[\"" + _colomnName + "\"].ToString()";
                case "text": return "dr[\"" + _colomnName + "\"].ToString()";

                case "nchar": return "dr[\"" + _colomnName + "\"].ToString()";
                case "nvarchar": return "dr[\"" + _colomnName + "\"].ToString()";
                case "ntext": return "dr[\"" + _colomnName + "\"].ToString()";

                case "binary": return "(byte[])dr[\"" + _colomnName + "\"]";
                case "varbinary": return "(byte[])dr[\"" + _colomnName + "\"]";
                case "image": return "(byte[])dr[\"" + _colomnName + "\"]";

                case "uniqueidentifier": return "new Guid(\"dr[\"" + _colomnName + "\"].ToString()\")";
                case "cursor": return "dr[\"" + _colomnName + "\"].ToString()";
                case "timestamp": return "dr[\"" + _colomnName + "\"].ToString()";
                case "hierarchyid": return "dr[\"" + _colomnName + "\"].ToString()";
                case "sql_variant": return "dr[\"" + _colomnName + "\"].ToString()";
                case "xml": return "dr[\"" + _colomnName + "\"].ToString()";
                case "table": return "dr[\"" + _colomnName + "\"].ToString()";

                default:
                    return "dr[\"" + _colomnName + "\"].ToString()";
            }
        }
        #endregion

        #region 获取新增的所有列
        /// <summary>
        /// 获取用于新增的所有列
        /// </summary>
        /// <param name="_dtEditor">受影响的表（表详细信息）</param>
        /// <returns>新增的所有列</returns>
        internal static string GetInsertColomns(DataTable _dtEditor)
        {
            StringBuilder builder = new StringBuilder();
            bool _isKeyIdentity = IsKeyIdentity(_dtEditor);
            string _keyColomnName = GetKeyColomnName(_dtEditor);

            for (int i = 0; i < _dtEditor.Rows.Count; i++)
            {
                DataRow _drEditor = _dtEditor.Rows[i];
                if (_isKeyIdentity)
                {
                    if (_drEditor["ColumnName"].ToString() == _keyColomnName)
                    {
                        continue;
                    }
                    builder.Append("[" + _drEditor["ColumnName"].ToString() + "]");
                }
                else
                {
                    builder.Append("[" + _drEditor["ColumnName"].ToString() + "]");
                }

                if ((i + 1) == _dtEditor.Rows.Count) continue;
                builder.Append(",");
            }

            return builder.ToString();
        }
        #endregion

        #region 获取用于新增的列的值信息
        /// <summary>
        /// 获取用于新增的列的值信息
        /// </summary>
        /// <param name="_dtEditor"></param>
        /// <returns></returns>
        public static string GetInsertColomnValues(DataTable _dtEditor)
        {
            StringBuilder builder = new StringBuilder();

            bool _isKeyIdentity = IsKeyIdentity(_dtEditor);
            string _keyColomnName = GetKeyColomnName(_dtEditor);

            for (int i = 0; i < _dtEditor.Rows.Count; i++)
            {
                DataRow _drEditor = _dtEditor.Rows[i];
                string _colomnNameLower = StringMaker(_drEditor["ColumnName"].ToString(), false);

                if (_isKeyIdentity)
                {
                    if (_drEditor["ColumnName"].ToString() == _keyColomnName)
                    {
                        continue;
                    }
                    builder.Append("@" + _colomnNameLower);
                }
                else
                {
                    builder.Append("@" + _colomnNameLower);
                }

                if ((i + 1) == _dtEditor.Rows.Count) continue;
                builder.Append(",");
            }

            return builder.ToString();
        }
        #endregion

        #region 查询主键列是否是标志列
        /// <summary>
        /// 查询主键列是否是标志列
        /// </summary>
        /// <param name="_dtEditor">受影响的表（表详细信息）</param>
        /// <returns></returns>
        public static bool IsKeyIdentity(DataTable _dtEditor)
        {
            DataRow _keyColomn = GetKeyColomn(_dtEditor);
            if (_keyColomn["IsIdentity"].ToString().Trim() != "") return true;
            else return false;
        }
        #endregion

        #region 表格数据操作生成代码
        /// <summary>
        /// 获取表的查询代码
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <param name="_tableInfo">表结构</param>
        /// <returns></returns>
        public static string GetSelectCode(string _tableName, DataTable _tableInfo)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Select ");

            for (int rowIndex = 0; rowIndex < _tableInfo.Rows.Count; rowIndex++)
            {
                DataRow _row = _tableInfo.Rows[rowIndex];
                builder.Append("        [" + _row["ColumnName"].ToString() + "]");
                if ((rowIndex + 1) == _tableInfo.Rows.Count) continue;
                builder.AppendLine(",");
            }
            builder.AppendLine("");
            builder.AppendLine(" From [" + _tableName + "] ");
            builder.AppendLine(" Where '条件语句'");

            return builder.ToString();
        }

        /// <summary>
        /// 获取创建表的脚本语句
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <param name="_tableInfo">表结构</param>
        /// <returns></returns>
        public static string GetCreateScript(string _tableName, DataTable _tableInfo)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("CREATE TABLE [" + _tableName + "]");

            for (int index = 0; index < _tableInfo.Rows.Count; index++)
            {
                DataRow _rowColumn = _tableInfo.Rows[index];
                string _res = GetTypeForCreateScript(_rowColumn);
                builder.Append("    " + _res);
                if ((index + 1) == _tableInfo.Rows.Count) continue;
                builder.AppendLine(",");
            }
            builder.AppendLine(")");
            return builder.ToString();
        }

        /// <summary>
        /// 为创建表的脚本语句生成类型
        /// </summary>
        /// <param name="_row"></param>
        /// <returns></returns>
        public static string GetTypeForCreateScript(DataRow _row)
        {
            string _columnName = _row["ColumnName"].ToString().Trim().ToLower();
            string _length = _row["Length"].ToString().Trim();
            string _scale = _row["Scale"].ToString().Trim();
            string _Preci = _row["Preci"].ToString().Trim();
            bool isNull = string.IsNullOrEmpty(_row["cisNull"].ToString().Trim()) ? false : true;
            bool isIdentity = string.IsNullOrEmpty(_row["IsIdentity"].ToString().Trim()) ? false : true;
            string _result = "[" + _columnName + "] ";

            switch (_columnName)
            {
                case "bigint": break;
                case "binary":
                    _result += "(" + _length + ") ";
                    break;
                case "bit": break;
                case "char":
                    _result += "(" + _length + ") ";
                    break;
                case "date": break;
                case "datetime": break;
                case "datetime2":
                    _result += "(" + _scale + ") ";
                    break;
                case "datetimeoffset":
                    _result += "(" + _scale + ") ";
                    break;
                case "decimal":
                    _result += "(" + _Preci + "," + _scale + ") ";
                    break;
                case "float": break;
                case "geography": break;
                case "geometry": break;
                case "hierarchyid": break;
                case "image": break;
                case "int": break;
                case "money": break;
                case "nchar":
                    _result += "(" + _length + ") ";
                    break;
                case "ntext": break;
                case "numeric":
                    _result += "(" + _Preci + "," + _scale + ") ";
                    break;
                case "nvarchar":
                    if (_length.Trim() == "0") _result += "(max) ";
                    else _result += "(" + _length + ") ";
                    break;
                case "smalldatetime": break;
                case "real": break;
                case "smallint": break;
                case "smallmoney": break;
                case "sql_variant": break;
                case "text": break;
                case "time":
                    _result += "(" + _scale + ") ";
                    break;
                case "timestamp": break;
                case "tinyint": break;
                case "uniqueidentifier": break;
                case "varbinary":
                    if (_length.Trim() == "-1") _result += "(max) ";
                    else _result += "(" + _length + ") ";
                    break;
                case "xml": break;
                default: break;
            }

            if (isIdentity) _result += " IDENTITY(1,1) ";

            if (isNull) _result += "NULL ";
            else _result += "NOT NULL ";

            return _result;
        }

        /// <summary>
        /// 获取新增数据行的SQL语句
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <param name="_tableInfo">表结构</param>
        /// <returns></returns>
        public static string GetInsertCode(string _tableName, DataTable _tableInfo)
        {
            StringBuilder builder = new StringBuilder();

            bool _isKeyIdentity = IsKeyIdentity(_tableInfo);
            builder.Append("INSERT INTO [" + _tableName + "]");
            builder.Append("(");

            for (int index = 0; index < _tableInfo.Rows.Count; index++)
            {
                string _columnName = _tableInfo.Rows[index]["ColumnName"].ToString();
                if (_isKeyIdentity && _columnName == GetKeyColomnName(_tableInfo)) continue;
                builder.Append("[" + _columnName + "]");
                if ((index + 1) == _tableInfo.Rows.Count) continue;
                builder.Append(",");
            }

            builder.AppendLine(")");
            builder.Append("VALUES ");
            builder.Append("(");

            for (int item = 0; item < _tableInfo.Rows.Count; item++)
            {
                string _columnName = _tableInfo.Rows[item]["ColumnName"].ToString();
                if (_isKeyIdentity && (_columnName == GetKeyColomnName(_tableInfo))) continue;
                builder.Append(GetValuesForInsertUpdate(_tableInfo.Rows[item]));
                if ((item + 1) == _tableInfo.Rows.Count) continue;
                builder.Append(",");
            }

            builder.AppendLine(")");

            return builder.ToString();
        }

        /// <summary>
        /// 获取新增数据行的Insert脚本
        /// </summary>
        /// <param name="_tableInsertScript" >table类型的表插入脚本</param>
        /// <returns></returns>
        public static string GetInsertScript(DataTable _tableInsertScript)
        {
            StringBuilder builder = new StringBuilder();


            foreach (DataRow _rowColumn in _tableInsertScript.Rows)
            {
                for (int index = 0; index < _tableInsertScript.Columns.Count; index++)
                {
                    builder.Append(_rowColumn[index].ToString());
                }
                builder.AppendLine("");
            }

            return builder.ToString();
        }

        public static string GetValuesForInsertUpdate(DataRow _RowInfo)
        {
            string _type = _RowInfo["TypeName"].ToString().Trim().ToLower();

            switch (_type)
            {
                case "bigint": return " ";
                case "binary": return " ";
                case "bit": return " ";
                case "decimal": return " ";
                case "float": return " ";
                case "smallint": return " ";
                case "smallmoney": return " ";
                case "tinyint": return " ";
                case "varbinary": return " ";

                default:
                    return "' '";
            }

        }
        public static string GetValuesForInsertUpdate(DataRow _RowInfo, object obj)
        {
            string _type = _RowInfo["TypeName"].ToString().Trim().ToLower();

            switch (_type)
            {
                case "bigint":
                case "binary":
                case "bit":
                case "decimal":
                case "float":
                case "smallint":
                case "smallmoney":
                case "tinyint":
                case "varbinary":
                    return obj.ToString().Trim();
                case "datetime":
                    if (obj.ToString().Trim() == string.Empty)
                    {
                        return "null";
                    }
                    return "'" + obj.ToString().Trim() + " '";
                default:
                    return "'" + obj.ToString().Trim() + " '";
            }
        }

        /// <summary>
        /// 获取更新表记录的SQL语句
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <param name="_tableInfo">表结构</param>
        /// <returns></returns>
        public static string GetUpdateCode(string _tableName, DataTable _tableInfo)
        {
            StringBuilder builder = new StringBuilder();
            bool _isKeyIdentity = IsKeyIdentity(_tableInfo);
            builder.Append("UPDATE [" + _tableName + "]");
            builder.AppendLine(" SET ");

            for (int rowIndex = 0; rowIndex < _tableInfo.Rows.Count; rowIndex++)
            {
                string _columnName = _tableInfo.Rows[rowIndex]["ColumnName"].ToString();
                if (_isKeyIdentity && (_columnName == GetKeyColomnName(_tableInfo))) continue;
                builder.Append("          " + "[" + _tableInfo.Rows[rowIndex]["ColumnName"].ToString() + "] = " + GetValuesForInsertUpdate(_tableInfo.Rows[rowIndex]));
                if ((rowIndex + 1) == _tableInfo.Rows.Count) continue;
                builder.AppendLine(",");
            }

            builder.AppendLine(")");
            builder.AppendLine(" WHERE '搜索条件'");

            return builder.ToString();
        }

        /// <summary>
        /// 获取删除表记录的SQL语句
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <returns></returns>
        public static string GetDeleteCode(string _tableName)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("DELETE FROM [" + _tableName + "] WHERE '条件语句'");

            return builder.ToString();
        }

        /// <summary>
        /// 获取删除表的Drop脚本
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <returns></returns>
        public static string GetDropScript(string _tableName)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("DROP TABLE [" + _tableName + "]");

            return builder.ToString();
        }

        /// <summary>
        /// 获取创建和删除表的Create/Drop脚本
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <param name="_tableInfo">表结构</param>
        /// <returns></returns>
        public static string GetCrDrScript(string _tableName, DataTable _tableInfo)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("--------------Create脚本-----------");
            builder.AppendLine(GetCreateScript(_tableName, _tableInfo));

            builder.AppendLine("---------------Drop脚本-------------");
            builder.AppendLine(GetDropScript(_tableName));

            return builder.ToString();
        }
        #endregion
    }
}
