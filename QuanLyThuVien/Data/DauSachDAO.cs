using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Data
{
    class DauSachDAO
    {
        public void ThemDauSach(int maSach)
        {
            Database cls = new Database();
            string strsQL = "insert into tblDauSach values(@TinhTrang, @GhiChu, @MaSach);";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@TinhTrang", 1);
            cmd.Parameters.AddWithValue("@GhiChu", "Đang cap nhat");
            cmd.Parameters.AddWithValue("@MaSach", maSach);
            cmd.ExecuteNonQuery();
        }
    }
}
