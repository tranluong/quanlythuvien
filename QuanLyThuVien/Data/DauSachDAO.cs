using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Data
{
    class DauSachDAO
    {
        public void ThemDauSach(int maSach, string tenDauSach)
        {
            Database cls = new Database();
            string strsQL = "insert into tblDauSach values(@TinhTrang, @GhiChu, @MaSach, @TenDauSach);";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@TinhTrang", 1);
            cmd.Parameters.AddWithValue("@GhiChu", "Đang cap nhat");
            cmd.Parameters.AddWithValue("@MaSach", maSach);
            cmd.Parameters.AddWithValue("@TenDauSach", tenDauSach);
            cmd.ExecuteNonQuery();
        }
        public DataTable ShowAllDauSach(int intMADS)
        {
            string strSQL = "select MaDauSach as 'Mã Đầu Sách', TenDauSach as 'Tên Đầu Sách', CASE TinhTrang WHEN 0 THEN N'Cũ' WHEN 1 THEN N'Mới' WHEN 2 THEN N'Hỏng' WHEN 3 THEN N'Mất' END as 'Tình Trạng', GhiChu as 'Ghi Chú', MaSach as 'Mã Sách' from tblDauSach where MaSach = '" + intMADS + "'";
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        public bool DeleteDS(int MaDS)
        {
            bool blKey = false;
            string strsQL = "delete from tblDauSach where MaDauSach= '" + MaDS + "'";
            SqlCommand cmd = new SqlCommand();
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Xóa đầu sách thất bại";
            return blKey;
        }
        public DataTable ShowAll()
        {
            string strSQL = "select * from tblDauSach ";
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        public bool UpdateBook(DauSach clsBook, int MADS)
        {
            bool blKey = false;
            string strSQL = "update tblDauSach set ";
            strSQL += "TinhTrang = @TinhTrang";
            strSQL += ",GhiChu = @GhiChu";
            strSQL += ",MaSach = @MaSach";
            strSQL += ",TenDauSach = @TenDauSach";
            strSQL += " where MaSach = '" + MADS + "' and MaDauSach = '" +clsBook.MaDauSach+"'";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@GhiChu", clsBook.GhiChu);
            cmd.Parameters.AddWithValue("@MaSach", MADS);
            cmd.Parameters.AddWithValue("TenDauSach", clsBook.TenDauSach);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
            {
                blKey = true;
            }
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Cập nhật đầu sách thất bại";
            return blKey;
        }

        public bool kiemTraDauSach(int MaDauSach)
        {
            bool blKey = false;
            string strSQL = "select ds.MaDauSach from tblDauSach ds join tblChiTietPhieuMuonTra ct on ds.MaDauSach=ct.MaDauSach where ds.MaDauSach='" + MaDauSach + "' ";
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    blKey = false;
                }
                else
                    blKey = true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }

        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
