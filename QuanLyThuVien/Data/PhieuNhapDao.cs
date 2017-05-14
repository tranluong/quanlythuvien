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
    class PhieuNhapDao
    {
        public DataTable loadCombox()
        {
            string str = "select MaSach, TenSach from tblSach";
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(str).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }

        public bool ThemPhieuNhap(PhieuNhap pn)
        {
            bool blKey = false;
            string strsQL1 = "insert into tblPhieuNhap values(@NgayNhap, @TongTriGia); SELECT SCOPE_IDENTITY();";
            string strsQL2 = "insert into tblChiTietPhieuNhap values(@MaPN, @MaSach, @SoLuong, @DonGia, @ThanhTien)";
            SqlCommand cmd1 = new SqlCommand(strsQL1, Connection.sqlConnection);
            cmd1.Parameters.AddWithValue("@NgayNhap", pn.pNgayNhap);
            cmd1.Parameters.AddWithValue("@TongTriGia", pn.pTongTriGia);
            int lastIDPN = Convert.ToInt32(cmd1.ExecuteScalar());
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Parameters.AddWithValue("@MaPN", lastIDPN);
            cmd2.Parameters.AddWithValue("@MaSach", pn.pMaSach);
            cmd2.Parameters.AddWithValue("@SoLuong", pn.pSoLuong);
            cmd2.Parameters.AddWithValue("@DonGia", pn.pDonGia);
            cmd2.Parameters.AddWithValue("@ThanhTien", pn.pThanhTien);
            
            Database cls = new Database();
            if (cls.Update(strsQL2, CommandType.Text, cmd2))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm phiếu nhập thất bại";
            return blKey;
        }

        public DataTable HienThiPhieuNhap()
        {
            string strSQL = "select ctpn.MaPN as 'Số Phiếu', s.TenSach as 'Tên Sách', ctpn.SoLuong as 'Số Lượng', ctpn.DonGia as 'Đơn Giá', ctpn.ThanhTien as 'Thành Tiền', pn.NgayNhap as 'Ngày Nhập', ctpn.MaSach from tblPhieuNhap pn join tblChiTietPhieuNhap ctpn on pn.MaPN=ctpn.MaPN join tblSach s on ctpn.MaSach=s.MaSach";
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
        public DataTable SearchPhieuNhap(string keyWord)
        {
            string strSQL = "select ctpn.MaPN as 'Số Phiếu', s.TenSach as 'Tên Sách', ctpn.SoLuong as 'Số Lượng', ctpn.DonGia as 'Đơn Giá', ctpn.ThanhTien as 'Thành Tiền', pn.NgayNhap as 'Ngày Nhập', ctpn.MaSach from tblPhieuNhap pn join tblChiTietPhieuNhap ctpn on pn.MaPN=ctpn.MaPN join tblSach s on ctpn.MaSach=s.MaSach where ctpn.MaPN like  '%'+@keyWord+'%' ";     
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@keyWord", keyWord);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }

        public bool DeletePhieuNhap(PhieuNhap pn)
        {
            bool blKey = false;
            string strsQL1 = "delete from tblChiTietPhieuNhap where MaPN=@MaPN";
            SqlCommand cmd1 = new SqlCommand(strsQL1,Connection.sqlConnection);
            cmd1.Parameters.AddWithValue("@MaPN", pn.pMaPhieuNhap);
            cmd1.ExecuteNonQuery();
            string strsQL = "delete from tblPhieuNhap where MaPN=@MaPN";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPN", pn.pMaPhieuNhap);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa phiếu nhập thất bại";
            return blKey;
        }

        public bool SuaPhieuNhap(PhieuNhap pn)
        {
            bool blKey = false;
            string strsQL1 = "update tblChiTietPhieuNhap set MaSach=@MaSach, SoLuong=@SoLuong, DonGia=@DonGia, ThanhTien = @ThanhTien where  MaPN=@MaPN ";
            SqlCommand cmd1 = new SqlCommand(strsQL1,Connection.sqlConnection);
            cmd1.Parameters.AddWithValue("@MaSach", pn.pMaSach);
            cmd1.Parameters.AddWithValue("@SoLuong", pn.pSoLuong);
            cmd1.Parameters.AddWithValue("@DonGia", pn.pDonGia);
            cmd1.Parameters.AddWithValue("@ThanhTien", pn.pThanhTien);         
            cmd1.Parameters.AddWithValue("@MaPN", pn.pMaPhieuNhap);
            cmd1.ExecuteNonQuery();
            string strsQL = "update tblPhieuNhap set NgayNhap=@NgayNhap, TongTriGia=@TongTriGia where  MaPN=@MaPN ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NgayNhap", pn.pNgayNhap);
            cmd.Parameters.AddWithValue("@TongTriGia", pn.pThanhTien);
            cmd.Parameters.AddWithValue("@MaPN", pn.pMaPhieuNhap);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật thất bại";
            return blKey;
        }

        public int getSLSach(int MSach)
        {
            string strsQL = "select SoLuong from tblSach where MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@MaSach", MSach);
            int SL = Convert.ToInt32(cmd.ExecuteScalar());
            return SL;
        }

        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
