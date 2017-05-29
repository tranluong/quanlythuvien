using QuanLyThuVien.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace QuanLyThuVien.Business
{
    public class DBConnection
    {
        DBConnectionDao _DBcon = new DBConnectionDao();
        public void Connection(string server, string data, int auth, string user, string pass)
        {
            _DBcon.Connection(server, data, auth, user, pass);
        }
        public void CloseDB()
        {
            _DBcon.CloseDB();
        }
        public void OpenDB()
        {
            _DBcon.OpenDB();
        }
        public SqlConnection con()
        {
            return _DBcon.con;
        }
        public DataTable load_server()
        {
            return _DBcon.load_server();
        }
    }
}
