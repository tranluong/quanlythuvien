using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using Managers = System.Configuration.ConfigurationManager;



namespace QuanLyThuVien
{
    class SQLServer
    {
        private string connectionString = "";
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        private bool windowsNT = true;
        public bool WindowsNT
        {
            get { return windowsNT; }
            set { windowsNT = value; }
        }
        private string serverName = "(local)";
        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        private string databaseName = "thuvien";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        private string userName = "sa";
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string passWord = "";
        public string Password
        {
            get { return passWord; }
            set { passWord = value; }
        }        
        private string connectionTimeout = "";
        public string ConnectionTimeout
        {
            get { return connectionTimeout; }
            set { connectionTimeout = value; }
        }
        private string portNo = "";
        public string PortNo
        {
            get { return portNo; }
            set { portNo = value; }
        }
        internal string GetConnectionString()
        {
            string conString = "server="+serverName+";database="+databaseName;
            if (windowsNT)
                conString += ";Integrated Security=true";
            else
                conString+=";uid="+userName+";pwd="+passWord;
            if(!connectionTimeout.Equals(""))
                conString+=";ConnectionTimeout="+connectionTimeout;
            if (!portNo.Equals(""))
                conString += ";Port="+portNo;
            return conString;
        }
        private string strError = "";
        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
        internal string GetNodeFromAppConfigFile()
        {
            string strApp = "";
            try
            {
                serverName = Managers.AppSettings.Get("server");
                databaseName = Managers.AppSettings.Get("database");
                userName = Managers.AppSettings.Get("userid");
                passWord = Managers.AppSettings.Get("password");
                windowsNT = Convert.ToBoolean(Managers.AppSettings.Get("windows"));
                portNo = Managers.AppSettings.Get("port");
                connectionTimeout = Managers.AppSettings.Get("timeout");
                strApp = GetConnectionString();
            }
            catch
            {
                strError = "Đọc nội dung file App.config thất bại";                
            }
            return strApp;
        }
    }
}
