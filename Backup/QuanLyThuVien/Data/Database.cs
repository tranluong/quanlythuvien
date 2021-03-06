using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Windows;
using System.Text.RegularExpressions;


namespace QuanLyThuVien
{
    class Database
    {
        private string strError = "";
        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
        
        public DataSet GetData(string strSQL, CommandType cmdType, SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            Connection cls = new Connection();
            bool blConnect = cls.Connect();
            if (!blConnect)
                strError = cls.Error;
            else
            {
                try
                {                    
                    cmd.CommandText = strSQL;
                    cmd.CommandType = cmdType;
                    cmd.Connection = Connection.sqlConnection;                 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
            }
            return ds;
        }
        public DataSet GetData(string strSQL)
        {
            DataSet ds = new DataSet();
            Connection cls = new Connection();
            bool blConnect = cls.Connect();
            if (!blConnect)
                strError = cls.Error;
            else
            {
                try
                {                    
                    SqlDataAdapter da = new SqlDataAdapter(strSQL,Connection.sqlConnection);
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
            }
            return ds;
        }
        
        public bool Update(string strSQL, CommandType cmdType, SqlCommand cmd)
        {
            bool blKey = false;
            Connection cls = new Connection();
            bool blConnect = cls.Connect();
            if (!blConnect)
                strError = cls.Error;
            else
            {
                try
                {                    
                    cmd.CommandText = strSQL;
                    cmd.CommandType = cmdType;
                    cmd.Connection = Connection.sqlConnection;
                    cmd.ExecuteNonQuery();
                    blKey = true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
            }
            return blKey;
        }
        public bool UpdateDataTable(string strSQL, DataTable dt)
        {
            bool blKey = false;
            Connection cls = new Connection();
            bool blConnect = cls.Connect();
            if (!blConnect)
                strError = cls.Error;
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = strSQL;                    
                    cmd.Connection = Connection.sqlConnection;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
                    if (da.Update(dt) != 0)
                        blKey = true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
            }
            return blKey;
        }
        public bool Update(string strSQL)
        {
            bool blKey = false;
            Connection cls = new Connection();
            bool blConnect = cls.Connect();
            if (!blConnect)
                strError = cls.Error;
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = strSQL;                    
                    cmd.Connection = Connection.sqlConnection;
                    cmd.ExecuteNonQuery();
                    blKey = true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
            }
            return blKey;
        }
        public object[] ReadData(string strSQL)
        {
            object[] info = null;
            Connection cls = new Connection();
            bool blConnect = cls.Connect();
            if (!blConnect)
                strError = cls.Error;
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = strSQL;
                    cmd.Connection = Connection.sqlConnection;
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        info = new object[dr.FieldCount];
                        dr.GetValues(info);
                    }
                    dr.Close();
                    dr.Dispose();
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }                
            }
            return info;
        }        
    }
}
