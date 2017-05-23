using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace QuanLyThuVien.Data
{
    public class DBConnectionDao
    {
        public SqlConnection con;
        public static string sv, dt, us, ps;
        public static int au;
        public void Connection(string server, string data, int auth, string user, string pass)
        {
            if (server == null || data == null)
            {
                try
                {
                    con = new SqlConnection(@"Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
                    con.Open();
                    con.Close();
                }
                catch
                {
                }
            }
            else
            {
                sv = server; dt = data; au = auth; us = user; ps = pass;
                if (auth == 0 && server != null)
                {
                    con = new SqlConnection("Data Source=" + server + ";Initial Catalog=" + data + ";Integrated Security=True");
                }
                else
                {
                    con = new SqlConnection("Data Source=" + server + ";database=" + data + "; uid=" + user + ";pwd=" + pass + "");
                }
            }

        }

        public DBConnectionDao()
        {
            Connection(sv, dt, au, us, ps);
        }

        public void CloseDB()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void OpenDB()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public DataTable load_server()
        {
            DataTable dt = new DataTable();
            //string sql = @"use master select data_source from sys.servers";
            string sql = @"select @@SERVERNAME go";
            OpenDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            CloseDB();
            da.Fill(dt);
            return dt;
            //SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            //DataTable dt = instance.GetDataSources();
            //return dt;
        }
    }
}
