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

        public DataTable loadComboxDocGia()
        {
            string str = "select MaDG, TenDG from tblDocGia";
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
        public DataTable loadComboxMuonSach(int type)
        {
            string str = "";
            if (type == 0)
            {
                str = "select MaLoaiSach, TenLoaiSach from tblLoaiSach";
            }
            else if (type == 1)
            {
                str = "select MaSach, TenSach from tblSach";
            }

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

        public DataTable loadComboxNhanVien(int MaNV)
        {
            string str = "select MaNV, TenNV from tblNhanVien where MaNV = '" + MaNV + "'";
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
            string strSQL = "select DS.MaDauSach,S.MaSach,S.TenSach,S.TacGia,S.DonGia,DS.TinhTrang ";
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
        //public DataTable GetBookMT(int intMaDauSach)
        //{
        //    // string strSQL = "select MaDauSach,TenSach,TacGia, DonGia, TinhTrang";
        //    string strSQL = "select DS.MaDauSach,S.MaSach,S.TenSach,S.TacGia,S.DonGia,DS.TinhTrang ";
        //    strSQL += " from tblSach S, tblDauSach DS, tblPhieuMuonTra PMT, tblChiTietPhieuMuonTra CTPMT, tblNhanVien NV, tblDocGia DG";
        //    strSQL += " where S.MaSach=DS.MaSach and PMT.MaPM = CTPMT.MaPM and CTPMT.MaDauSach = DS.MaDauSach and PMT.MaNV = NV.MaNV and PMT.MaDG = DG.MaDG";
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.AddWithValue("@MaSach", intMaDauSach);
        //    Database cls = new Database();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
        //        if (cls.Error != "")
        //            strError = cls.Error;
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    return dt;
        //}
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
            //string strSQL = "select *";
            //strSQL += " from tblDauSach";
            //strSQL += " where TinhTrang = 0 and MaSach=(select S.MaSach from tblSach S, tblDauSach DS where S.MaSach=DS.MaSach and DS.MaDauSach=@MaDauSach)";
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where MaSach=@MaSach";
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
            string strSQL = "set format datetime dmy;insert into tblPhieuMuonTra values(@NgayMuon,@HanTra,@TienDatCoc,@TienTraLai,@TienPhat,@NgayLapPhieu,@MaNV,@MaDG); declare @ID int; set @ID=@@IDENTITY";
            SqlCommand cmd = new SqlCommand();
            if (clsMuonTra.NgayMuon == DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@NgayMuon", clsMuonTra.NgayMuon);
            }
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
                if (clsMuonTra.NgayTra == DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@NgayTra" + i.ToString(), Convert.ToString(row["NgayTra"]));
                }    
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

        public DataTable getDauSachTheoLoaiTimKiem(int loaiTim, string timKiemTheo)
        {
            string strSQL = "";
            if (loaiTim == 0)
            {
                strSQL += "select ds.MaDauSach as 'Mã Đầu Sách',s.TenSach as 'Tên Sách', CASE TinhTrang WHEN 0 THEN N'Mới' WHEN 1 THEN N'Hỏng' WHEN 2 THEN N'Mất' END as 'Tình Trạng', s.DonGia as 'Đơn giá' from tblSach s join tblDauSach ds on s.MaSach=ds.MaSach where s.MaSach like '%" + timKiemTheo + "%' AND ds.MaDauSach not in (select MaDauSach from tblChiTietPhieuMuonTra) AND ds.TinhTrang=0";
            }
            else if (loaiTim == 1)
            {
                strSQL += "select ds.MaDauSach as 'Mã Đầu Sách', s.TenSach as 'Tên Sách', CASE TinhTrang WHEN 0 THEN N'Mới' WHEN 1 THEN N'Hỏng' WHEN 2 THEN N'Mất' END as 'Tình Trạng', s.DonGia as 'Đơn giá' from tblSach s join tblDauSach ds on s.MaSach=ds.MaSach where s.MaSach in (select MaSach from tblSach where TenSach LIKE N'%" + timKiemTheo + "%') AND ds.MaDauSach not in (select MaDauSach from tblChiTietPhieuMuonTra) AND ds.TinhTrang=0";
            }
            else if (loaiTim == 2)
            {
                strSQL += "select ds.MaDauSach as 'Mã Đầu Sách', s.TenSach as 'Tên Sách', CASE TinhTrang WHEN 0 THEN N'Mới' WHEN 1 THEN N'Hỏng' WHEN 2 THEN N'Mất' END as 'Tình Trạng', s.DonGia as 'Đơn giá' from tblSach s join tblDauSach ds on s.MaSach=ds.MaSach where s.MaSach in (select MaSach from tblSach where TacGia LIKE N'%" + timKiemTheo + "%') AND ds.MaDauSach not in (select MaDauSach from tblChiTietPhieuMuonTra) AND ds.TinhTrang=0";
            }
            SqlCommand cmd = new SqlCommand();
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

        public DataTable getTenDG(string strMaDG)
        {
            string strSQL = "select TenDG as 'Tên Độc Giả' from tblDocGia where MaDG=@MaDG"; 
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

        public bool ThemPhieuMuonSach(List<MuonTra> listCTPM, MuonTra mtPhieuMuon)
        {
            bool blKey = false;
            Database cls = new Database();
            string strsQL1 = "insert into tblPhieuMuonTra values(@NgayMuon, @HanTra, @TienDatCoc, @TienTraLai, @TienPhat, @NgayLapPhieu, @MaNV, @MaDG, @GiaHan); SELECT SCOPE_IDENTITY();";
            string strsQL2 = "insert into tblChiTietPhieuMuonTra(MaPM, MaDauSach, TinhTrang) values(@MaPM, @MaDauSach, @TinhTrang)";
            SqlCommand cmd1 = new SqlCommand(strsQL1, Connection.sqlConnection);
            cmd1.Parameters.AddWithValue("@NgayMuon", mtPhieuMuon.NgayMuon);
            cmd1.Parameters.AddWithValue("@HanTra", mtPhieuMuon.HanTra);
            cmd1.Parameters.AddWithValue("@TienDatCoc", mtPhieuMuon.TienDatCoc);
            cmd1.Parameters.AddWithValue("@TienTraLai", 0);
            cmd1.Parameters.AddWithValue("@TienPhat", 0);
            cmd1.Parameters.AddWithValue("@NgayLapPhieu", mtPhieuMuon.NgayLapPhieu);
            cmd1.Parameters.AddWithValue("@MaNV", mtPhieuMuon.MaNV);
            cmd1.Parameters.AddWithValue("@MaDG", mtPhieuMuon.MaDG);
            cmd1.Parameters.AddWithValue("@GiaHan", 0);
            int lastIDPM = Convert.ToInt32(cmd1.ExecuteScalar());
            for (int i = 0; i < listCTPM.Count; i++)
            {
                SqlCommand cmd2 = new SqlCommand(strsQL2, Connection.sqlConnection);
                cmd2.Parameters.AddWithValue("@MaPM", lastIDPM);
                cmd2.Parameters.AddWithValue("@MaDauSach", listCTPM[i].MaDauSach);
                //cmd2.Parameters.AddWithValue("@NgayTra", listCTPM[i].NgayTra);
                cmd2.Parameters.AddWithValue("@TinhTrang", 0);
                cmd2.ExecuteNonQuery();
                blKey = true;
            }

            return blKey;
        }

        public DataTable TimCTPhieuMuon(int MaPM)
        {
            DataTable dt = null;
            string strSQL = "Select ds.MaDauSach as 'Mã đầu sách', s.TenSach as 'Tên sách', CASE ds.TinhTrang WHEN 0 THEN N'Mới' WHEN 1 THEN N'Hỏng' WHEN 2 THEN N'Mất' WHEN 3 THEN N'Hư bìa sách' END as 'Tình Trạng', s.DonGia as 'Đơn giá' from tblChiTietPhieuMuonTra ctmt join tblDauSach ds on ctmt.MaDauSach=ds.MaDauSach join tblSach s on s.MaSach=ds.MaSach where ctmt.MaPM=@MaPM and ctmt.TinhTrang=0";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPM", MaPM);
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

        public DataTable TimPhieuMuon(int MaPM)
        {
            DataTable dt = null;
            string strSQL = "Select  mt.MaDG, mt.NgayMuon, mt.HanTra, mt.MaNV, mt.NgayLapPhieu, mt.TienDatCoc, mt.GiaHan from tblPhieuMuonTra mt where mt.MaPM=@MaPM";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPM", MaPM);
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
        public bool CapNhatGiaHan(int MaPM, int giaHan, DateTime hanTra)
        {
            bool blKey = false;
            string strsQL = "update tblPhieuMuonTra set GiaHan='"+giaHan+"', HanTra='"+hanTra+"' where MaPM= '" + MaPM + "'";
            SqlCommand cmd = new SqlCommand();
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Gia hạn thất bại";
            return blKey;
        }

        public DataTable getHanTra(int MaPM)
        {
            DataTable dt = null;
            string strSQL = "Select  HanTra from tblPhieuMuonTra where MaPM=@MaPM";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPM", MaPM);
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

        public int getIDLonNhat()
        {
            string strSQL = "Select  Max(MaPM) from tblPhieuMuonTra";
            SqlCommand cmd = new SqlCommand(strSQL, Connection.sqlConnection);
            int ID = Convert.ToInt16(cmd.ExecuteScalar());
            return ID;
        }

        public DataTable TimPhieuTra(int MaPM)
        {
            DataTable dt = null;
            string strSQL = "Select  mt.MaNV, mt.MaDG, dg.TenDG, mt.HanTra, mt.TienDatCoc from tblPhieuMuonTra mt join tblDocGia dg on mt.MaDG=dg.MaDG where mt.MaPM=@MaPM";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPM", MaPM);
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

        public DataTable TimCTPhieuTra(int MaPM)
        {
            DataTable dt = null;
            string strSQL = "Select ds.MaDauSach as 'Mã đầu sách', s.TenSach as 'Tên sách', CASE ds.TinhTrang WHEN 0 THEN N'Mới' WHEN 1 THEN N'Hỏng' WHEN 2 THEN N'Mất'  WHEN 3 THEN N'Hư bìa sách' END as 'Tình Trạng', s.DonGia as 'Đơn giá' from tblChiTietPhieuMuonTra ctmt join tblDauSach ds on ctmt.MaDauSach=ds.MaDauSach join tblSach s on s.MaSach=ds.MaSach where ctmt.MaPM=@MaPM and ctmt.TinhTrang=0";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPM", MaPM);
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
        public DataTable LayLoaiDGTheoMaPM(int MaPM)
        {
            DataTable dt = null;
            string strSQL = "select ldg.MaLoaiDG,ldg.TenLoaiDG from tblPhieuMuonTra mt join tblDocGia dg on mt.MaDG=dg.MaDG join tblLoaiDocGia ldg on ldg.MaLoaiDG=dg.MaLoaiDG where mt.MaPM=@MaPM";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPM", MaPM);
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

        public void CapNhatChiTietPhieuMuonTra(int MaPM, int MaDS, DateTime ngayTra, int trangThaiSach, int tinhTrangMuon)
        {
            string strsQL = "update tblChiTietPhieuMuonTra set NgayTra='" + ngayTra + "', TinhTrang='" + tinhTrangMuon + "' where MaPM= '" + MaPM + "' AND MaDauSach='" + MaDS + "'";            
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            cmd.ExecuteNonQuery();
            string strsQL1 = "update tblDauSach set TinhTrang='" + trangThaiSach + "' where MaDauSach='" + MaDS + "'";
            SqlCommand cmd1 = new SqlCommand(strsQL1, Connection.sqlConnection);
            cmd1.ExecuteNonQuery();
        }

        public int DemMaPM(int MaPM)
        {
            string strsQL = "select count(MaPM) from tblChiTietPhieuMuonTra where MaPM= '" + MaPM + "'";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            int cMaPM = Convert.ToInt32(cmd.ExecuteScalar());
            return cMaPM;
        }

        public int DemMaPMTheoTinhTrang(int MaPM)
        {
            string strsQL = "select count(MaPM) from tblChiTietPhieuMuonTra where MaPM= '" + MaPM + "' AND TinhTrang <> 0";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            int cMaPM = Convert.ToInt32(cmd.ExecuteScalar());
            return cMaPM;
        }

        public DataTable layMaDSVaTinhTrangMuonTra(int MaPM)
        {
            DataTable dt = null;
            string strSQL = "select MaDauSach as 'Mã đầu sách', TinhTrang as 'Tình trạng mượn'  from tblChiTietPhieuMuonTra where MaPM=@MaPM";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPM", MaPM);
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
        public DataTable layTrangThaiSachTheoMaDS(int MaDS)
        {
            DataTable dt = null;
            string strSQL = "select ds.TinhTrang as 'Trạng thái sách', s.DonGia  from tblDauSach ds join tblSach s on ds.MaSach=s.MaSach where MaDauSach=@MaDS";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDS", MaDS);
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

        public double layTienDatCocTheoMaPM(int MaPM)
        {
            string strsQL = "select TienDatCoc from tblPhieuMuonTra where MaPM= '" + MaPM + "'";
            SqlCommand cmd = new SqlCommand(strsQL, Connection.sqlConnection);
            double tienDatCoc = Convert.ToDouble(cmd.ExecuteScalar());
            return tienDatCoc;
        }
        

        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
