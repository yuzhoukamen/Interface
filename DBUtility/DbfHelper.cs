using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Data.OleDb;
using System.IO;

namespace Alif.HIS.DBUtility
{
    /// <summary>
    /// dbf文件导出助手
    /// </summary>
    public class DbfHelper
    {
        string _templetFile;//DBF模板文件  
        string _fileName;//目标临时文件  
        string _serverpath;
        string _fields;
        string _fileprefix;
        DataTable _dataSource;

        public DbfHelper()
        {
            _serverpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "Medical\\WT4\\Model\\";


        }
        public string TempletFile
        {
            set { _templetFile = value; }
            get { return _templetFile; }
        }
        public string FilePrefix
        {
            set { _fileprefix = value; }
            get { return _fileprefix; }
        }
        public string Fields
        {
            set { _fields = value; }
            get { return _fields; }
        }
        public DataTable DataSource
        {
            set { _dataSource = value; }
            get { return _dataSource; }
        }

        public void Export()
        {
            HttpResponse response = HttpContext.Current.Response;

            CreateData();

            response.Charset = "GB2312";
            response.ContentEncoding = Encoding.GetEncoding("GB2312");
            response.ContentType = "APPLICATION/OCTET-STREAM";
            response.AppendHeader("Content-Disposition", "attachment;filename=" +
             HttpUtility.UrlEncode(_fileName));
            response.WriteFile(_fileName);
            response.Flush();
            File.Delete(_fileName);
            response.End();

        }
        private void CreateData()
        {

            string tempfile = GetRandomFileName();
            _fileName = _serverpath + @"Temp/" + tempfile + ".dbf";
            File.Copy(_serverpath + _templetFile, _fileName, true);

            //string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _serverpath + @"Temp/" + ";Extended Properties=dBASE 5.0";

            string strConn = "Dsn=Visual FoxPro Tables;sourcedb=" + HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) +
                "\\Medical\\WT4\\Model\\Temp;sourcetype=DBF;exclusive=No;backgroundfetch=Yes;collate=Machine;Provider=SQLOLEDB;";
            string sql = "";
            if (_fields != null && _fields != string.Empty)
            {
                sql = "Select  " + _fields + "  From  [" + tempfile + "]";
            }
            else
            {
                sql = "Select  *  From  [" + tempfile + "]";
            }
            OleDbConnection connection = new OleDbConnection(strConn);
            connection.Open();

            OleDbDataAdapter adpt = new OleDbDataAdapter(sql, strConn);
            OleDbCommandBuilder bd = new OleDbCommandBuilder(adpt);
            bd.QuotePrefix = "[";
            bd.QuoteSuffix = "]";

            DataSet mySet = new DataSet();
            adpt.Fill(mySet, tempfile);

            MoveBatch(_dataSource, mySet.Tables[0]);//批量导出数据

            adpt.Update(mySet, tempfile);
        }
        /// <summary>
        /// 得到一个随意的文件名
        /// </summary>
        /// <returns></returns>
        private string GetRandomFileName()
        {
            Random rnd = new Random((int)(DateTime.Now.Ticks));
            string s = rnd.Next(999).ToString();
            s = FilePrefix + s;
            return s;
        }
        protected virtual void MoveBatch(DataTable src_dt, DataTable dst_dt)
        {
            foreach (DataRow dr in src_dt.Rows)
            {
                //dst_dt.ImportRow(dr);//此处要修改为:dst_dt.Rows.Add(dr.ItemArray);  
                dst_dt.Rows.Add(dr.ItemArray);
            }
        }
    }
}