using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class MuonTraDAO
    {
        //Số cuốn mượn về
        public int SoCuonMuonVe(string strMaDG)
        {            
            string strSQL = "select *";
            strSQL += " from tblPhieuMuonTra PM, tblChiTietPhieuMuonTra PMS";
            strSQL += " where PM.MaPM=PMS.MaPM and NgayTra is null and MaDG=@MaDG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strMaDG);
            Database cls = new Database();
            DataTable dt = new DataTable();
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
            return dt.Rows.Count;
        }
      
        //Số tiền mượn về
        public int SoTienMuonVe(string strMaDG)
        {
            string strSQL = "select Sum(DonGia*SoLuong) as TongTienVe";
            strSQL += " from tblPhieuMuonTra PM, tblChiTietPhieuMuonTra PMS, tblDauSach DS, tblSach S";
            strSQL += " where PM.MaPM=PMS.MaPM and PMS.MaDauSach=DS.MaDauSach and DS.MaSach=S.MaSach and NgayTra is null and MaDG=@MaDG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strMaDG);
            Database cls = new Database();
            DataTable dt = new DataTable();
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
            DataTableReader tr = dt.CreateDataReader();
            if (tr.Read())
                if (tr["TongTienVe"]!=DBNull.Value)                    
                    return Convert.ToInt32(tr["TongTienVe"]);                
            return 0;
        }
     
        //Lấy thông tin độc giả
        public DataTable GetReader(string strMaDG)
        {
            string strSQL = "select * ";
            strSQL += " from tblDocgia, tblLoaiDocGia";
            strSQL += " where MaDG=@MaDG and tblLoaiDocGia.MaLoaiDG = tblDocGia.MaLoaiDG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strMaDG);
            Database cls = new Database();
            DataTable dt = new DataTable();
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
        //Lấy thông tin sách
        public DataTable GetBook(int intMaDauSach)
        {
            // string strSQL = "select MaDauSach,TenSach,TacGia, DonGia, TinhTrang";
            string strSQL = "select S.MaSach,S.TenSach,S.TacGia,S.DonGia,DS.TinhTrang ";
            strSQL += " from tblSach S, tblDauSach DS";
            strSQL += " where S.MaSach=DS.MaSach ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaDauSach);
            Database cls = new Database();
            DataTable dt = new DataTable();
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
        public DataTable GetDauSach(int intMaDauSach)
        {
            // string strSQL = "select MaDauSach,TenSach,TacGia, DonGia, TinhTrang";
            string strSQL = "select MaDauSach ";
            strSQL += " from tblDauSach DS";
            strSQL += " where MaDauSach=@MaDauSach ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach", intMaDauSach);
            Database cls = new Database();
            DataTable dt = new DataTable();
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


        //Lấy tác giả sách không tập
        public DataTable GetAuthor(int intMaDauSach)
        {
            string strSQL = "select TacGia";
            strSQL += " from tblSach S, tblDauSach DS";
            strSQL += " where S.MaSach=DS.MaSach and DS.MaDauSach=@MaDauSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach", intMaDauSach);
            Database cls = new Database();
            DataTable dt = new DataTable();
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
       
        //Số lượng đầu sách của 1 tựa sách
        public int SoLuongDauSach(int intMaDauSach)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where TinhTrang = 0 and MaSach=(select S.MaSach from tblSach S, tblDauSach DS where S.MaSach=DS.MaSach and DS.MaDauSach=@MaDauSach)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach", intMaDauSach);
            Database cls = new Database();
            DataTable dt = new DataTable();
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
            return dt.Rows.Count;
        }
        //Số lượng đầu sách đang mượn của 1 tựa sách
        public int SoLuongDangMuon(int intMaDauSach)
        {
            string strSQL = "select *";
            strSQL += " from tblChiTietPhieuMuonTra PMS, tblDauSach DS, tblSach S";
            strSQL += " where PMS.MaDauSach=DS.MaDauSach and DS.MaSach=S.MaSach";
            strSQL += " and NgayTra is null and S.MaSach=(select S.MaSach from tblSach S, tblDauSach DS where S.MaSach=DS.MaSach and DS.MaDauSach=@MaDauSach)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach", intMaDauSach);
            Database cls = new Database();
            DataTable dt = new DataTable();
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
            return dt.Rows.Count;
        }
      
      
        //Mượn tài liệu
        public bool Muon(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;
            string strSQL = "insert into tblPhieuMuonTra values(@NgayMuon,@HanTra,@TienDatCoc,@TienTraLai,@TienPhat,@NgayLapPhieu,@MaNV,@MaDG); declare @ID int; set @ID=@@IDENTITY";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NgayMuon", clsMuonTra.NgayMuon);
            cmd.Parameters.AddWithValue("@HanTra", clsMuonTra.HanTra);
            cmd.Parameters.AddWithValue("@TienDatCoc", clsMuonTra.TienDatCoc);
            cmd.Parameters.AddWithValue("@TienTraLai", clsMuonTra.TienTraLai);
            cmd.Parameters.AddWithValue("@TienPhat", clsMuonTra.TienPhat);
            cmd.Parameters.AddWithValue("@NgayLapPhieu", clsMuonTra.NgayLapPhieu);
            cmd.Parameters.AddWithValue("@MaNV", clsMuonTra.MaNV);
            cmd.Parameters.AddWithValue("@MaDG", clsMuonTra.MaDG);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                strSQL += "; insert into tblChiTietPhieuMuonTra(MaPM,MaDauSach,NgayTra,TinhTrang) values(@ID,@MaDauSach" + i.ToString() + ",@NgayTra" + i.ToString() + ",@TinhTrang" + i.ToString() + ")";
                cmd.Parameters.AddWithValue("@MaDauSach" + i.ToString(), Convert.ToInt32(row["MaDauSach"]));
                cmd.Parameters.AddWithValue("@NgayTra" + i.ToString(), Convert.ToString(row["NgayTra"]));
                cmd.Parameters.AddWithValue("@TinhTrang" + i.ToString(), Convert.ToString(row["TinhTrang"]));
            }           
            
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật mượn thất bại";
            return blKey;
        }
        //Xem thông tin mượn trả dựa vào mã độc giả
        public DataTable XemDG(string strMaDG)
        {
            DataTable dt = null;
            //string strSQL = "select PMS.MaDauSach as 'Mã Đầu Sách', TenSach as 'Tên sách', NgayMuon as 'Ngày Mượn', PM.MaPM";
            string strSQL = "select *";
            strSQL += " from tblDocGia DG, tblPhieuMuonTra PM, tblChiTietPhieuMuonTra PMS, tblDauSach DS, tblSach S";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMS.MaPM and PMS.MaDauSach=DS.MaDauSach and DS.MaSach=S.MaSach";
            strSQL += " and PMS.NgayTra is null and DG.MaDG=@MaDG";
            strSQL += " order by NgayMuon desc";
                    
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strMaDG);            
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
        //Xem thông tin mượn trả dựa vào Số DKCB
        public DataTable XemSach(int intMaDauSach)
        {
            DataTable dt = null;
            string strSQL = "select S.MaSach, TenSach as 'Tên Sách', S.TacGia, S.DonGia, DS.TinhTrang, NgayMuon as 'Ngày Mượn',DG.MaDG";
            strSQL += " from tblChiTietPhieuMuonTra PMS, tblPhieuMuonTra PM, tblDocGia DG, tblDauSach DS, tblSach S";
            strSQL += " where PMS.MaPM=PM.MaPM and PM.MaDG=DG.MaDG and PMS.MaDauSach=DS.MaDauSach and DS.MaSach=S.MaSach";
            strSQL += " and PMS.NgayTra is null ";
            strSQL += " order by NgayMuon desc";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaDauSach);
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
     
        //Gia hạn
        public bool GiaHan(MuonTra clsMuonTra)
        {
            bool blKey = false;
            string strSQL = "update tblPhieuMuonTra set ";
            strSQL += "NgayMuon = NgayMuon+@NgayMuon";
            strSQL += "from tblPhieuMuonTra PM , tblChiTietPhieuMuonTra CTPM";
            strSQL += " where NgayTra is null and MaDauSach = @MaDauSach and PM.MaPM = CTPM.MaPM";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NgayMuon", clsMuonTra.SoNgayMuon);            
            cmd.Parameters.AddWithValue("@MaDauSach", clsMuonTra.MaDauSach);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Gia hạn thất bại";
            return blKey;
        }
        //Trả sách
        public bool TraSach(MuonTra clsMuonTra)
        {
            bool blKey = false;
            string strSQL = "update tblChiTietPhieuMuonTra set ";
            strSQL += "NgayTra = @NgayTra";
            strSQL += ",MaDauSach = @MaDauSach";
            strSQL += " where NgayTra is null and MaDauSach = @MaDauSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TinhTrang", clsMuonTra.TinhTrang);
            cmd.Parameters.AddWithValue("@NgayTra", clsMuonTra.NgayTra);    
            cmd.Parameters.AddWithValue("@MaDauSach", clsMuonTra.MaDauSach);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Trả sách thất bại";
            return blKey;
        }
       
      
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
