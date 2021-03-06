using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class Connection
    {
        public static SqlConnection sqlConnection=new SqlConnection();       

        private static string connectionString = "";
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }            
        }   
     
        private static string strError = "";
        public string Error
        {
            get { return strError; }
        }

        internal bool Connect()
        {            
            bool IsExist = false;
            if (connectionString != "")
            {
                if (sqlConnectionState() == false)
                {
                    if (ReConnect())                    
                        IsExist = true;
                }
                else
                    IsExist = true;
            }
            else
            {
                try
                {
                    SQLServer clsSQL = new SQLServer();
                    connectionString = clsSQL.GetNodeFromAppConfigFile();
                    if (connectionString == "")
                    {
                        strError = clsSQL.Error;                        
                    }
                    else
                    {
                        sqlConnection.ConnectionString = connectionString;
                        sqlConnection.Open();
                        IsExist = true;
                    }
                }
                catch
                {
                    strError = "Kết nối CSDL thất bại ";
                }
            }
            return IsExist;
        }
        internal static bool ReConnect()
        {
            bool IsExist = false;            
            //sqlConnection.ConnectionString = connectionString;
            try
            {
                sqlConnection.Open();
                IsExist = true;
            }
            catch
            {
                strError = "Kết nối CSDL thất bại";
            }
            return IsExist;            
        }
        internal static void CloseConnection()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
        internal static bool sqlConnectionState()
        {
            if (sqlConnection.State == ConnectionState.Closed)
                return false;
            else
                return true;
        }
    }
}
