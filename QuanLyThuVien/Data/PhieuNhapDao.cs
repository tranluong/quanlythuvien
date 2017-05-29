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
        public double getThanhTien(int MaPN, int MaSach)
        {
            string strsQL = "select ThanhTien from tblChiTietPhieuNhap where MaPN=@MaPN AND MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            cmd.Parameters.AddWithValue("@MaSach", MaSach);
            double thanhTien = Convert.ToDouble(cmd.ExecuteScalar());
            return thanhTien;
        }

        public double getTongTien(int MaPN)
        {
            string strsQL = "select TongTriGia from tblPhieuNhap where MaPN=@MaPN";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            double tongTien = Convert.ToDouble(cmd.ExecuteScalar());
            return tongTien;
        }
        public bool updateTongTien(int MaPN, double TongTriGia)
        {
            bool bkey = false;
            string strsQL = "update tblPhieuNhap set TongTriGia=@TongTriGia  where MaPN=@MaPN";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@TongTriGia", TongTriGia);
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            cmd.ExecuteNonQuery();
            bkey = true;
            return bkey;
        }

        public bool ThemPhieuNhap(List<PhieuNhap> listpn, PhieuNhap pn1)
        {
            bool blKey = false;
            Database cls = new Database();
            string strsQL1 = "insert into tblPhieuNhap values(@NgayNhap, @TongTriGia,@MaNV); SELECT SCOPE_IDENTITY();";
            string strsQL2 = "insert into tblChiTietPhieuNhap values(@MaPN, @MaSach, @SoLuong, @DonGia, @ThanhTien)";
            SqlCommand cmd1 = new SqlCommand(strsQL1, Connection.sqlConnection);
            cmd1.Parameters.AddWithValue("@NgayNhap", pn1.pNgayNhap);
            cmd1.Parameters.AddWithValue("@TongTriGia", pn1.pTongTriGia);
            cmd1.Parameters.AddWithValue("@MaNV", pn1.pMaNV);
            int lastIDPN = Convert.ToInt32(cmd1.ExecuteScalar());
            for (int i = 0; i < listpn.Count; i++)
            {
                SqlCommand cmd2 = new SqlCommand(strsQL2, Connection.sqlConnection);
                cmd2.Parameters.AddWithValue("@MaPN", lastIDPN);
                cmd2.Parameters.AddWithValue("@MaSach", listpn[i].pMaSach);
                cmd2.Parameters.AddWithValue("@SoLuong", listpn[i].pSoLuong);
                cmd2.Parameters.AddWithValue("@DonGia", listpn[i].pDonGia);
                cmd2.Parameters.AddWithValue("@ThanhTien", listpn[i].pThanhTien);
                cmd2.ExecuteNonQuery();
                blKey = true;
            }

            return blKey;
        }

        public DataTable HienThiPhieuNhap()
        {
            //string strSQL = "select ctpn.MaPN as 'Số Phiếu', s.TenSach as 'Tên Sách', ctpn.SoLuong as 'Số Lượng', ctpn.DonGia as 'Đơn Giá', ctpn.ThanhTien as 'Thành Tiền', pn.NgayNhap as 'Ngày Nhập', ctpn.MaSach from tblPhieuNhap pn join tblChiTietPhieuNhap ctpn on pn.MaPN=ctpn.MaPN join tblSach s on ctpn.MaSach=s.MaSach";
            string strSQL = "select p.MaPN as 'Mã phiếu nhập', (Select sum(SoLuong) from tblChitietphieunhap where MaPN = p.MaPN) as 'Tổng số lượng', p.TongTriGia as 'Tổng giá trị', p.NgayNhap as 'Ngày nhập' from tblPhieuNhap p order by MaPN desc";
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


        public DataTable HienThiChiTietPhieuNhap(int MaPN)
        {
            string strSQL = "select s.MaSach as 'Mã Sách', s.TenSach as 'Tên Sách', ctpn.SoLuong as 'Số Lượng', ctpn.DonGia as 'Đơn Giá', ctpn.ThanhTien as 'Thành Tiền', ctpn.MaSach, ctpn.MaPN from tblChiTietPhieuNhap ctpn join tblSach s on ctpn.MaSach=s.MaSach where ctpn.MaPN='" + MaPN + "' order by ctpn.MaPN desc";
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

        public DataTable HienThiChiTietPhieuNhap()
        {
            string strSQL = "select s.TenSach as 'Tên Sách', ctpn.SoLuong as 'Số Lượng', ctpn.DonGia as 'Đơn Giá', ctpn.ThanhTien as 'Thành Tiền', ctpn.MaSach, ctpn.MaPN from tblChiTietPhieuNhap ctpn join tblSach s on ctpn.MaSach=s.MaSach order by ctpn.MaPN desc";
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

        public DataTable SearchPhieuNhap(string keyWord, string from, string to)
        {
            //string strSQL = "select ctpn.MaPN as 'Số Phiếu', s.TenSach as 'Tên Sách', ctpn.SoLuong as 'Số Lượng', ctpn.DonGia as 'Đơn Giá', ctpn.ThanhTien as 'Thành Tiền', pn.NgayNhap as 'Ngày Nhập', ctpn.MaSach from tblPhieuNhap pn join tblChiTietPhieuNhap ctpn on pn.MaPN=ctpn.MaPN join tblSach s on ctpn.MaSach=s.MaSach where ctpn.MaPN like  '%'+@keyWord+'%' ";           
            string strSQL = "select p.MaPN as 'Mã phiếu nhập', (Select sum(SoLuong) from tblChitietphieunhap where MaPN = p.MaPN) as 'Tổng số lượng', p.TongTriGia as 'Tổng giá trị', p.NgayNhap as 'Ngày nhập' from tblPhieuNhap p where ";
            if (!keyWord.Equals(""))
            {
                strSQL += "p.MaPN like '%'+@keyWord+'%' AND (p.NgayNhap >=@from AND p.NgayNhap <= @to) order by p.MaPN desc";
            }
            else
            {
                strSQL += "p.NgayNhap >=@from AND p.NgayNhap <= @to order by p.MaPN desc";
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@keyWord", keyWord);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
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

        public bool DeleteChiTietPhieuNhap(PhieuNhap pn)
        {
            bool blKey = false;
            string strsQL = "delete from tblChiTietPhieuNhap where MaPN=@MaPN AND MaSach=@MaSach";
            SqlCommand cmd1 = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd1.Parameters.AddWithValue("@MaPN", pn.pMaPhieuNhap);
            cmd1.Parameters.AddWithValue("@MaSach", pn.pMaSach);
            cmd1.ExecuteNonQuery();
            blKey = true;
            return blKey;
        }

        public bool SuaPhieuNhap(PhieuNhap pn)
        {
            bool blKey = false;
            string strsQL1 = "update tblChiTietPhieuNhap set  DonGia=@DonGia, ThanhTien = @ThanhTien where  MaPN=@MaPN AND MaSach=@MaSachUpdate";
            SqlCommand cmd1 = new SqlCommand(strsQL1, Connection.sqlConnection);
            //cmd1.Parameters.AddWithValue("@MaSach", pn.pMaSach);
            cmd1.Parameters.AddWithValue("@DonGia", pn.pDonGia);
            cmd1.Parameters.AddWithValue("@ThanhTien", pn.pThanhTien);
            cmd1.Parameters.AddWithValue("@MaPN", pn.pMaPhieuNhap);
            cmd1.Parameters.AddWithValue("@MaSachUpdate", pn.pMaSach);
            cmd1.ExecuteNonQuery();

            string strsQL = "update tblPhieuNhap set NgayNhap=@NgayNhap where  MaPN=@MaPN ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NgayNhap", pn.pNgayNhap);
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

        public bool capNhatSLSach(int MaSach, int SL)
        {
            bool blKey = false;
            string strSQL = "update tblSach set SoLuong=@SL where MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand(strSQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@SL", SL);
            cmd.Parameters.AddWithValue("@MaSach", MaSach);
            cmd.ExecuteNonQuery();
            blKey = true;
            return blKey;
        }

        public bool capNhatSLSachVaDonGia(int MaSach, int SL, double donGia)
        {
            bool blKey = false;
            string strSQL = "update tblSach set SoLuong=@SL, DonGia=@DonGia where MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand(strSQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@SL", SL);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@MaSach", MaSach);
            cmd.ExecuteNonQuery();
            blKey = true;
            return blKey;
        }

        public bool DeletePhieuNhap(int MaPN)
        {
            bool bkey = false;
            //Xóa chi tiết phiếu nhập
            string strsQL = "delete from tblChiTietPhieuNhap where MaPN=@MaPN";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            cmd.ExecuteNonQuery();
            // Xóa phiếu nhập
            string strsQL1 = "delete from tblPhieuNhap where MaPN=@MaPN";
            SqlCommand cmd1 = new SqlCommand(strsQL1, Connection.sqlConnection);
            cmd1.Parameters.AddWithValue("@MaPN", MaPN);
            cmd1.ExecuteNonQuery();
            bkey = true;
            return bkey;
        }
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
