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
            strSQL += " from tblPhieuMuon PM, tblCT_PMSach PMS";
            strSQL += " where PM.MaPM=PMS.MaPM and NgayTra is null and LoaiPM=1 and MaDG=@MaDG";
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
        //Số cuốn mượn tại chổ
        public int SoCuonMuonTaiCho(string strMaDG)
        {           
            string strSQL1 = "select *";
            strSQL1 += " from tblPhieuMuon PM, tblCT_PMSach PMS";
            strSQL1 += " where PM.MaPM=PMS.MaPM and NgayTra is null and LoaiPM=0 and MaDG=@MaDG";
            string strSQL2 = "select *";
            strSQL2 += " from tblPhieuMuon PM, tblCT_PMBaoTC PMBTC";
            strSQL2 += " where PM.MaPM=PMBTC.MaPM and NgayTra is null and MaDG=@MaDG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strMaDG);
            Database cls = new Database();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                dt1 = cls.GetData(strSQL1, CommandType.Text, cmd).Tables[0];
                dt2 = cls.GetData(strSQL2, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt1.Rows.Count + dt2.Rows.Count;
        }
        //Số tiền mượn về
        public int SoTienMuonVe(string strMaDG)
        {
            string strSQL = "select Sum(GiaBia) as TongTienVe";
            strSQL += " from tblPhieuMuon PM, tblCT_PMSach PMS, tblDauSach DS, tblTuaSach TS";
            strSQL += " where PM.MaPM=PMS.MaPM and PMS.SoDKCB=DS.SoDKCB and DS.MaTS=TS.MaTS and NgayTra is null and LoaiPM=1 and MaDG=@MaDG";
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
        //Số tiền mượn tại chổ
        public int SoTienMuonTaiCho(string strMaDG)
        {
            string strSQL = "select Sum(GiaBia) as TongTienTaiCho";
            strSQL += " from tblPhieuMuon PM, tblCT_PMSach PMS, tblDauSach DS, tblTuaSach TS";
            strSQL += " where PM.MaPM=PMS.MaPM and PMS.SoDKCB=DS.SoDKCB and DS.MaTS=TS.MaTS and NgayTra is null and LoaiPM=0 and MaDG=@MaDG";
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
                if (tr["TongTienTaiCho"] != DBNull.Value)
                    return Convert.ToInt32(tr["TongTienTaiCho"]);
            return 0;
        }
        //Lấy thông tin độc giả
        public DataTable GetReader(string strMaDG)
        {
            string strSQL = "select MaDG, TenDG, DaDatCoc, LoaiDG";
            strSQL += " from tblDocgia";
            strSQL += " where MaDG=@MaDG";
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
        public DataTable GetBook(int intSoDKCB)
        {
            string strSQL = "select TenTS, GiaBia, TenKho, TinhTrang";
            strSQL += " from tblTuaSach TS, tblDauSach DS, tblKhoChua KC";
            strSQL += " where TS.MaTS=DS.MaTS and KC.MaKho=TS.MaKho and DS.SoDKCB=@SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
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
        //Kiểm tra có tập hay không
        public bool HasChapter(int intSoDKCB)
        {
            bool blKey = false;
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where MaTap!=0 and SoDKCB=@SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
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
            if (dt.Rows.Count != 0)
                blKey = true;
            return blKey;
        }
        //Lấy thông tin tập
        public int GetChapterID(int intSoDKCB)
        {
            int ChapterID = 0;
            string strSQL = "select MaTap";
            strSQL += " from tblDauSach";
            strSQL += " where SoDKCB=@SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
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
                ChapterID = Convert.ToInt32(tr["MaTap"]);
            return ChapterID;
        }
        //Lấy tác giả sách không tập
        public DataTable GetAuthor(int intSoDKCB)
        {
            string strSQL = "select TenTG";
            strSQL += " from tblTuaSach TS, tblSach_Tacgia STG, tblTacGia TG, tblDauSach DS";
            strSQL += " where TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG and TS.MaTS=DS.MaTS and DS.SoDKCB=@SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
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
        //Lấy tác giả sách có tập
        public DataTable GetAuthorChapter(int intSoDKCB)
        {
            string strSQL = "select TenTG";
            strSQL += " from tblDauSach DS, tblTapSach TS, tblTap_Tacgia TTG, tblTacGia TG";
            strSQL += " where DS.MaTap=TS.MaTap and TS.MaTap=TTG.MaTap and TTG.MaTG=TG.MaTG and DS.SoDKCB=@SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
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
        public int SoLuongDauSach(int intSoDKCB)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where TinhTrang = 0 and MaTS=(select TS.MaTS from tblTuaSach TS, tblDauSach DS where TS.MaTS=DS.MaTS and DS.SoDKCB=@SoDKCB)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
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
        public int SoLuongDangMuon(int intSoDKCB)
        {
            string strSQL = "select *";
            strSQL += " from tblCT_PMSach PMS, tblDauSach DS, tblTuaSach TS";
            strSQL += " where PMS.SoDKCB=DS.SoDKCB and DS.MaTS=TS.MaTS";
            strSQL += " and NgayTra is null and TS.MaTS=(select TS.MaTS from tblTuaSach TS, tblDauSach DS where TS.MaTS=DS.MaTS and DS.SoDKCB=@SoDKCB)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
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
        //Lấy thông tin báo tạp chí
        public DataTable GetNewspaper(int intMaTenBTC, string strSoPH)
        {
            string strSQL = "select TenBTC, SoPH, NgayPH, SoLuongNhap";
            strSQL += " from tblSoBaoTC SBTC, tblTenBaoTC TBTC";
            strSQL += " where SBTC.MaTenBTC=TBTC.MaTenBTC and SBTC.SoPH=@SoPH and TBTC.MaTenBTC=@MaTenBTC";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTenBTC", intMaTenBTC);
            cmd.Parameters.AddWithValue("@SoPH", strSoPH);
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
        //Số lượng báo tc đang mượn
        public int SoLuongBTCDangMuon(int intMaTenBTC, string strSoPH)
        {
            string strSQL = "select *";
            strSQL += " from tblCT_PMBaoTC";
            strSQL += " where NgayTra is null and MaTenBTC=@MaTenBTC and SoPH=@SoPH";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTenBTC", intMaTenBTC);
            cmd.Parameters.AddWithValue("@SoPH", strSoPH);
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
            string strSQL = "insert into tblPhieuMuon values(@MaDG,@NgayMuon,@NguoiCapNhatMuon); declare @ID int; set @ID=@@IDENTITY";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", clsMuonTra.MaDG);
            cmd.Parameters.AddWithValue("@NgayMuon", clsMuonTra.NgayMuon);
            cmd.Parameters.AddWithValue("@NguoiCapNhatMuon", clsMuonTra.NguoiCapNhatMuon);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (Convert.ToInt32(row["SoDKCB"]) == 0)
                {
                    strSQL += "; insert into tblCT_PMBaoTC(MaPM,MaTenBTC,SoPH) values(@ID, @MaTenBTC" + i.ToString() + ", @SoPH" + i.ToString() + ")";
                    cmd.Parameters.AddWithValue("@MaTenBTC" + i.ToString(), Convert.ToInt32(row["MaTenBTC"]));
                    cmd.Parameters.AddWithValue("@SoPH" + i.ToString(), Convert.ToString(row["SoPH"]));
                }
                else
                {
                    strSQL += "; insert into tblCT_PMSach(MaPM,SoDKCB,SoNgayMuon,LoaiPM) values(@ID,@SoDKCB" + i.ToString() + ",@SoNgayMuon" + i.ToString() + ",@LoaiPM" + i.ToString() + ")";
                    cmd.Parameters.AddWithValue("@SoDKCB" + i.ToString(), Convert.ToInt32(row["SoDKCB"]));
                    cmd.Parameters.AddWithValue("@SoNgayMuon" + i.ToString(), Convert.ToString(row["SoNgayMuon"]));
                    cmd.Parameters.AddWithValue("@LoaiPM" + i.ToString(), Convert.ToString(row["LoaiPM"]));
                }
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
            string strSQL = "select PMS.SoDKCB as 'Số ĐKCB', TenTS as 'Tựa sách', '' as 'Tên Báo TC', '' as 'Số phát hành', NgayMuon as 'Ngày mượn', SoNgayMuon as 'Số ngày mượn',";
            strSQL += " case LoaiPM when 0 then N'Tại chổ' when 1 then N'Về nhà' end as 'Hình thức mượn','' as 'MaTenBTC',PM.MaPM";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMSach PMS, tblDauSach DS, tblTuaSach TS";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMS.MaPM and PMS.SoDKCB=DS.SoDKCB and DS.MaTS=TS.MaTS";
            strSQL += " and PMS.NgayTra is null and DG.MaDG=@MaDG";
            strSQL += " union";
            strSQL += " select 0, '', TenBTC, PMBTC.SoPH, NgayMuon, 0,";
            strSQL += " N'Tại chổ',TenBTC.MaTenBTC,PM.MaPM";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMBaoTC PMBTC, tblSoBaoTC SoBTC, tblTenBaoTC TenBTC";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMBTC.MaPM and PMBTC.MaTenBTC=SoBTC.MaTenBTC and PMBTC.SoPH=SoBTC.SoPH";
            strSQL += " and SoBTC.MaTenBTC=TenBTC.MaTenBTC and PMBTC.NgayTra is null and DG.MaDG=@MaDG";
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
        public DataTable XemSach(int intSoDKCB)
        {
            DataTable dt = null;
            string strSQL = "select PMS.SoDKCB as 'Số ĐKCB', TenTS as 'Tựa sách', '' as 'Tên Báo TC', '' as 'Số phát hành', NgayMuon as 'Ngày mượn', SoNgayMuon as 'Số ngày mượn',";
            strSQL += " case LoaiPM when 0 then N'Tại chổ' when 1 then N'Về nhà' end as 'Hình thức mượn',DG.MaDG";
            strSQL += " from tblCT_PMSach PMS, tblPhieuMuon PM, tblDocGia DG, tblDauSach DS, tblTuaSach TS";
            strSQL += " where PMS.MaPM=PM.MaPM and PM.MaDG=DG.MaDG and PMS.SoDKCB=DS.SoDKCB and DS.MaTS=TS.MaTS";
            strSQL += " and PMS.NgayTra is null and PMS.SoDKCB=@SoDKCB";
            strSQL += " order by NgayMuon desc";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
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
        //Xem thông tin mượn trả dựa vào thông tin báo tạp chí
        public DataTable XemBTC(int intMaTenBTC, string strSoPH)
        {
            DataTable dt = null;
            string strSQL = "select 0 as 'Số ĐKCB', '' as 'Tựa sách', TenBTC as 'Tên Báo TC', PMBTC.SoPH as 'Số phát hành', NgayMuon as 'Ngày mượn', 0 as 'Số ngày mượn',";
            strSQL += " N'Tại chổ' as 'Hình thức mượn', PMBTC.MaTenBTC, DG.MaDG, PM.MaPM";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMBaoTC PMBTC, tblSoBaoTC SoBTC, tblTenBaoTC TenBTC";
            strSQL += "  where DG.MaDG=PM.MaDG and PM.MaPM=PMBTC.MaPM and PMBTC.MaTenBTC=SoBTC.MaTenBTC and PMBTC.SoPH=SoBTC.SoPH and SoBTC.MaTenBTC=TenBTC.MaTenBTC";
            strSQL += " and PMBTC.NgayTra is null and PMBTC.MaTenBTC=@MaTenBTC and PMBTC.SoPH=@SoPH";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTenBTC", intMaTenBTC);
            cmd.Parameters.AddWithValue("@SoPH", strSoPH);
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
            string strSQL = "update tblCT_PMSach set ";
            strSQL += "SoNgayMuon = SoNgayMuon+@SoNgayMuon";            
            strSQL += " where NgayTra is null and SoDKCB = @SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoNgayMuon", clsMuonTra.SoNgayMuon);            
            cmd.Parameters.AddWithValue("@SoDKCB", clsMuonTra.SoDKCB);
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
            string strSQL = "update tblCT_PMSach set ";
            strSQL += "NgayTra = @NgayTra";
            strSQL += ",NguoiCapNhatTra = @NguoiCapNhatTra";
            strSQL += " where NgayTra is null and SoDKCB = @SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NgayTra", clsMuonTra.NgayTra);
            cmd.Parameters.AddWithValue("@NguoiCapNhatTra", clsMuonTra.NguoiCapNhatTra);
            cmd.Parameters.AddWithValue("@SoDKCB", clsMuonTra.SoDKCB);
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
        //Trả báo tạp chí
        public bool TraBaoTC(MuonTra clsMuonTra)
        {
            bool blKey = false;
            string strSQL = "update tblCT_PMBaoTC set ";
            strSQL += "NgayTra = @NgayTra";
            strSQL += ",NguoiCapNhatTra = @NguoiCapNhatTra";
            strSQL += " where NgayTra is null and MaPM=@MaPM and MaTenBTC = @MaTenBTC and SoPH=@SoPH";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NgayTra", clsMuonTra.NgayTra);
            cmd.Parameters.AddWithValue("@NguoiCapNhatTra", clsMuonTra.NguoiCapNhatTra);
            cmd.Parameters.AddWithValue("@MaTenBTC", clsMuonTra.MaTenBTC);
            cmd.Parameters.AddWithValue("@SoPH", clsMuonTra.SoPH);
            cmd.Parameters.AddWithValue("@MaPM", clsMuonTra.MaPM);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Trả Báo Tạp chí thất bại";
            return blKey;
        }
        //Lấy tất cả tên báo tc
        public DataTable ShowAllBaoTC()
        {
            DataTable dt = null;
            string strSQL = "select * from tblTenBaoTC order by MaTenBTC DESC";
            //SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.AddWithValue("@SoDKCB", intSoDKCB);
            Database cls = new Database();
            try
            {
                //dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
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
        //Lấy tất cả số báo tc dựa vào mã tên btc
        public DataTable ShowAllBaoTC(int intMaTenBTC)
        {
            DataTable dt = null;
            string strSQL = "select * from tblSoBaoTC where MaTenBTC=@MaTenBTC order by SoPH DESC";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTenBTC", intMaTenBTC);
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
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
