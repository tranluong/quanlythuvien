using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;

namespace QuanLyThuVien
{
    class ReaderDAO
    {
//Thêm độc giả mới        
        //Hàm kiểm tra trùng mã độc giả khi thêm
        public bool IsExistReaderID(string strReaderID)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblDocgia where MaDG=@ReaderID";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@ReaderID", strReaderID);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];            
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Mã độc giả này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Hàm kiểm tra trùng mã độc giả khi cập nhật
        public bool IsExistReaderID(string strNewReaderID, string strOldReaderID)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblDocgia where MaDG=@NewReaderID and MaDG !=@OldReaderID";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NewReaderID", strNewReaderID);
            cmd.Parameters.AddWithValue("@OldReaderID", strOldReaderID);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];            
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Mã độc giả này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Hàm thêm Độc giả
        public bool CreateReader(Reader clsReader)
        {
            bool blKey = false;
            string strsQL = "set dateformat dmy; insert into tblDocGia values(";
            strsQL += "@MaDG,@TenDG,@KhoaHoc,@Khoa,@Nganh,@Lop,@NgaySinh,@NoiSinh,@GioiTinh,@DiaChi,@SoDT,@DatCoc,@NgayDC,@NguoiNhanDC,@LoaiDG,@NguoiCapNhat,@NgayCapNhat)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", clsReader.MaDocGia);
            cmd.Parameters.AddWithValue("@TenDG", clsReader.TenDocGia);
            cmd.Parameters.AddWithValue("@KhoaHoc", clsReader.KhoaHoc);
            cmd.Parameters.AddWithValue("@Khoa", clsReader.Khoa);
            cmd.Parameters.AddWithValue("@Nganh", clsReader.Nganh);
            cmd.Parameters.AddWithValue("@Lop", clsReader.Lop);
            cmd.Parameters.AddWithValue("@NgaySinh", clsReader.NgaySinh);
            cmd.Parameters.AddWithValue("@NoiSinh", clsReader.NoiSinh);
            cmd.Parameters.AddWithValue("@GioiTinh", clsReader.GioiTinh);
            cmd.Parameters.AddWithValue("@DiaChi", clsReader.DiaChi);
            cmd.Parameters.AddWithValue("@SoDT", clsReader.SoDT);
            cmd.Parameters.AddWithValue("@DatCoc",clsReader.DatCoc);
            if (clsReader.NgayDatCoc == DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@NgayDC", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NgayDC", clsReader.NgayDatCoc);
            }
            cmd.Parameters.AddWithValue("@NguoiNhanDC",clsReader.NguoiNhanDatCoc);
            cmd.Parameters.AddWithValue("@LoaiDG", clsReader.LoaiDG);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsReader.NguoiCapNhat);
            cmd.Parameters.AddWithValue("@NgayCapNhat", clsReader.NgayCapNhat);
            Database cls = new Database();
            if (cls.Update(strsQL,CommandType.Text,cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm độc giả thất bại";
            return blKey;
        }
//Xóa độc giả        
        //Hàm lấy số sách chưa trả của một độc giả
        public int SachChuaTra(string strReaderID)
        {            
            string strSQL = "select *";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMSach PMS";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMS.MaPM and DG.MaDG=@MaDG and NgayTra is null";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strReaderID);
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
            return dt.Rows.Count;
        }

        //Hàm lấy số báo tạp chí chưa trả của một độc giả
        public int BaoTCChuaTra(string strReaderID)
        {
            string strSQL = "select *";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMBaoTC PMBTC";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMBTC.MaPM and DG.MaDG=@MaDG and NgayTra is null";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strReaderID);
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
            return dt.Rows.Count;
        }
         
        //Hàm xóa độc giả
        public bool DeleteReader(Reader clsReader)
        {
            bool blKey = false;
            string strsQL = "delete from tblDocGia where MaDG=@MaDG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", clsReader.MaDocGia);
            Database cls = new Database();
            if (cls.Update(strsQL,CommandType.Text,cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa độc giả thất bại";
            return blKey;
        }
//Cập nhật độc giả
        public bool UpdateReader(string strReaderID,Reader clsReader)
        {
            bool blKey = false;
            string strSQL = "set dateformat dmy; update tblDocGia set ";
            strSQL += "MaDG = @MaDG";
            strSQL += ",TenDG = @TenDG";
            strSQL += ",KhoaHoc = @KhoaHoc";
            strSQL += ",Khoa = @Khoa";
            strSQL += ",Nganh = @Nganh";
            strSQL += ",Lop = @Lop";
            strSQL += ",NgaySinh = @NgaySinh";
            strSQL += ",NoiSinh = @NoiSinh";
            strSQL += ",GioiTinh = @GioiTinh";
            strSQL += ",DiaChi = @DiaChi";
            strSQL += ",SoDT = @SoDT";
            strSQL += ",DaDatCoc = @DatCoc";
            if (clsReader.NgayDatCoc != DateTime.MinValue)
            {
                strSQL += ",NgayDatCoc = @NgayDC";
                strSQL += ",NguoiNhanDatCoc = @NguoiNhanDC";
            }            
            strSQL += ",LoaiDG = @LoaiDG";
            strSQL += ",NguoiCapNhat = @NguoiCapNhat";
            strSQL += ",NgayCapNhat = @NgayCapNhat";
            strSQL += " where MaDG = @ReaderID";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", clsReader.MaDocGia);
            cmd.Parameters.AddWithValue("@TenDG", clsReader.TenDocGia);
            cmd.Parameters.AddWithValue("@KhoaHoc", clsReader.KhoaHoc);
            cmd.Parameters.AddWithValue("@Khoa", clsReader.Khoa);
            cmd.Parameters.AddWithValue("@Nganh", clsReader.Nganh);
            cmd.Parameters.AddWithValue("@Lop", clsReader.Lop);
            cmd.Parameters.AddWithValue("@NgaySinh", clsReader.NgaySinh);
            cmd.Parameters.AddWithValue("@NoiSinh", clsReader.NoiSinh);
            cmd.Parameters.AddWithValue("@GioiTinh", clsReader.GioiTinh);
            cmd.Parameters.AddWithValue("@DiaChi", clsReader.DiaChi);
            cmd.Parameters.AddWithValue("@SoDT", clsReader.SoDT);
            cmd.Parameters.AddWithValue("@DatCoc", clsReader.DatCoc);
            if (clsReader.NgayDatCoc != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@NgayDC", clsReader.NgayDatCoc);
                cmd.Parameters.AddWithValue("@NguoiNhanDC", clsReader.NguoiNhanDatCoc);
            }
            cmd.Parameters.AddWithValue("@LoaiDG", clsReader.LoaiDG);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsReader.NguoiCapNhat);
            cmd.Parameters.AddWithValue("@NgayCapNhat", clsReader.NgayCapNhat);
            cmd.Parameters.AddWithValue("@ReaderID", strReaderID);
            Database cls = new Database();            
            if (cls.Update(strSQL,CommandType.Text,cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật ngôn ngữ thất bại";
            return blKey;
        }
//Tìm độc giả
        public DataTable SearchReader(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "";            
            if (intType == 0)//tìm theo Mã độc giả
                if (intFilter == 0)//Gần đúng
                    strSQL = "SELECT MaDG AS 'Mã độc giả',TenDG AS 'Tên độc giả',NgaySinh AS 'Ngày sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',DaDatCoc AS 'Đặt cọc',CASE LoaiDG WHEN 0 THEN N'HSSV,GVHĐ' ELSE 'GVBC' END AS 'Loại độc giả',DiaChi AS 'Địa chỉ',SoDT AS 'Số điện thoại',NoiSinh AS 'Nơi sinh',KhoaHoc AS 'Khóa học',Khoa,Nganh AS 'Ngành',Lop AS 'Lớp',CASE NgayDatCoc WHEN '01/01/1900' THEN '' ELSE NgayDatCoc END AS 'Ngày đặt cọc',(SELECT TenDangNhap FROM tblNhanVien WHERE MaNV=NguoiNhanDatCoc) AS 'Người nhận tiền đặt cọc',(SELECT TenDangNhap FROM tblNhanVien WHERE MaNV=NguoiCapNhat) AS 'Người cập nhật cuối',NgayCapNhat AS 'Ngày cập nhật cuối' FROM tblDocGia WHERE MaDG like '%'+@Keyword+'%'";
                else//Chính xác
                    strSQL = "SELECT MaDG AS 'Mã độc giả',TenDG AS 'Tên độc giả',NgaySinh AS 'Ngày sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',DaDatCoc AS 'Đặt cọc',CASE LoaiDG WHEN 0 THEN N'HSSV,GVHĐ' ELSE 'GVBC' END AS 'Loại độc giả',DiaChi AS 'Địa chỉ',SoDT AS 'Số điện thoại',NoiSinh AS 'Nơi sinh',KhoaHoc AS 'Khóa học',Khoa,Nganh AS 'Ngành',Lop AS 'Lớp',NgayDatCoc AS 'Ngày đặt cọc',(SELECT TenDangNhap FROM tblNhanVien WHERE MaNV=NguoiNhanDatCoc) AS 'Người nhận tiền đặt cọc',(SELECT TenDangNhap FROM tblNhanVien WHERE MaNV=NguoiCapNhat) AS 'Người cập nhật cuối',NgayCapNhat AS 'Ngày cập nhật cuối' FROM tblDocGia WHERE MaDG like @Keyword";
            else//tìm theo Tên độc giả
                if (intFilter == 0)//Gần đúng
                    strSQL = "SELECT MaDG AS 'Mã độc giả',TenDG AS 'Tên độc giả',NgaySinh AS 'Ngày sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',DaDatCoc AS 'Đặt cọc',CASE LoaiDG WHEN 0 THEN N'HSSV,GVHĐ' ELSE 'GVBC' END AS 'Loại độc giả',DiaChi AS 'Địa chỉ',SoDT AS 'Số điện thoại',NoiSinh AS 'Nơi sinh',KhoaHoc AS 'Khóa học',Khoa,Nganh AS 'Ngành',Lop AS 'Lớp',NgayDatCoc AS 'Ngày đặt cọc',(SELECT TenDangNhap FROM tblNhanVien WHERE MaNV=NguoiNhanDatCoc) AS 'Người nhận tiền đặt cọc',(SELECT TenDangNhap FROM tblNhanVien WHERE MaNV=NguoiCapNhat) AS 'Người cập nhật cuối',NgayCapNhat AS 'Ngày cập nhật cuối' FROM tblDocGia where TenDG like '%'+@Keyword+'%'";
                else//Chính xác
                    strSQL = "SELECT MaDG AS 'Mã độc giả',TenDG AS 'Tên độc giả',NgaySinh AS 'Ngày sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',DaDatCoc AS 'Đặt cọc',CASE LoaiDG WHEN 0 THEN N'HSSV,GVHĐ' ELSE 'GVBC' END AS 'Loại độc giả',DiaChi AS 'Địa chỉ',SoDT AS 'Số điện thoại',NoiSinh AS 'Nơi sinh',KhoaHoc AS 'Khóa học',Khoa,Nganh AS 'Ngành',Lop AS 'Lớp',NgayDatCoc AS 'Ngày đặt cọc',(SELECT TenDangNhap FROM tblNhanVien WHERE MaNV=NguoiNhanDatCoc) AS 'Người nhận tiền đặt cọc',(SELECT TenDangNhap FROM tblNhanVien WHERE MaNV=NguoiCapNhat) AS 'Người cập nhật cuối',NgayCapNhat AS 'Ngày cập nhật cuối' FROM tblDocGia where TenDG like @Keyword";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);            
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
        //Quá trình mượn trả
        public DataTable QuaTrinhMuonTra(string strMaDG, DateTime dtDau, DateTime dtCuoi, int intView)
        {
            string strS = "";
            /*if (intView == 0)//Tất cả
            {

            }*/
            if (intView == 1)//Chưa trả
            {
                strS = " and NgayTra is null";
            }
            if (intView == 2)//Đã trả
            {
                strS = " and NgayTra is not null";
            }
            string strSQL = "set dateformat dmy; select PMS.SoDKCB as 'Số ĐKCB', TenTS as 'Tựa sách', '' as 'Tên Báo TC', '' as 'Số phát hành', NgayMuon as 'Ngày mượn', SoNgayMuon as 'Số ngày mượn',";
            strSQL += " case LoaiPM when 0 then N'Tại chổ' when 1 then N'Về nhà' end as 'Hình thức mượn','' as 'MaTenBTC',PM.MaPM, NgayTra as 'Ngày trả'";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMSach PMS, tblDauSach DS, tblTuaSach TS";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMS.MaPM and PMS.SoDKCB=DS.SoDKCB and DS.MaTS=TS.MaTS";
            strSQL += " and DG.MaDG=@MaDG and NgayMuon between @dtDau and @dtCuoi";
            strSQL += strS;
            strSQL += " union";
            strSQL += " select 0, '', TenBTC, PMBTC.SoPH, NgayMuon, 0,";
            strSQL += " N'Tại chổ',TenBTC.MaTenBTC,PM.MaPM, NgayTra";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMBaoTC PMBTC, tblSoBaoTC SoBTC, tblTenBaoTC TenBTC";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMBTC.MaPM and PMBTC.MaTenBTC=SoBTC.MaTenBTC and PMBTC.SoPH=SoBTC.SoPH";
            strSQL += " and SoBTC.MaTenBTC=TenBTC.MaTenBTC and DG.MaDG=@MaDG and NgayMuon between @dtDau and @dtCuoi";
            strSQL += strS;
            strSQL += " order by NgayMuon desc";
            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strMaDG);
            cmd.Parameters.AddWithValue("@dtDau", dtDau);
            cmd.Parameters.AddWithValue("@dtCuoi", dtCuoi);
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
        public DataTable QuaTrinhMuonTra(string strMaDG)
        {
            string strSQL = "select PMS.SoDKCB as 'Số ĐKCB', TenTS as 'Tựa sách', '' as 'Tên Báo TC', '' as 'Số phát hành', NgayMuon as 'Ngày mượn', SoNgayMuon as 'Số ngày mượn',";
            strSQL += " case LoaiPM when 0 then N'Tại chổ' when 1 then N'Về nhà' end as 'Hình thức mượn','' as 'MaTenBTC',PM.MaPM, NgayTra as 'Ngày trả'";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMSach PMS, tblDauSach DS, tblTuaSach TS";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMS.MaPM and PMS.SoDKCB=DS.SoDKCB and DS.MaTS=TS.MaTS";
            //strSQL += " and PMS.NgayTra is not null and DG.MaDG=@MaDG";
            strSQL += " and DG.MaDG=@MaDG";
            strSQL += " union";
            strSQL += " select 0, '', TenBTC, PMBTC.SoPH, NgayMuon, 0,";
            strSQL += " N'Tại chổ',TenBTC.MaTenBTC,PM.MaPM, NgayTra";
            strSQL += " from tblDocGia DG, tblPhieuMuon PM, tblCT_PMBaoTC PMBTC, tblSoBaoTC SoBTC, tblTenBaoTC TenBTC";
            strSQL += " where DG.MaDG=PM.MaDG and PM.MaPM=PMBTC.MaPM and PMBTC.MaTenBTC=SoBTC.MaTenBTC and PMBTC.SoPH=SoBTC.SoPH";
            //strSQL += " and SoBTC.MaTenBTC=TenBTC.MaTenBTC and PMBTC.NgayTra is not null and DG.MaDG=@MaDG";
            strSQL += " and SoBTC.MaTenBTC=TenBTC.MaTenBTC and DG.MaDG=@MaDG";
            strSQL += " order by NgayMuon desc";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDG", strMaDG);            
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
        /*
        //Hiển thị tất cả ngôn ngữ
        public DataTable ShowAllReader()
        {
            //string strSQL = "select MaDG as 'Mã Độc giả', TenDG as 'Tên Độc giả', GioiTinh as 'Giới tính', DaDatCoc as 'Đặt cọc', LoaiDG as 'Loại Độc giả' from tblDocgia order by MaDG Desc";
            string strSQL = "SELECT MaDG AS 'Mã độc giả',TenDG AS 'Tên độc giả',NgaySinh AS 'Ngày sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',DaDatCoc AS 'Đặt cọc',CASE LoaiDG WHEN 0 THEN N'HSSV,GVHĐ' ELSE 'GVBC' END AS 'Loại độc giả',DiaChi AS 'Địa chỉ',SoDT AS 'Số điện thoại',NoiSinh AS 'Nơi sinh',KhoaHoc AS 'Khóa học',Khoa,Nganh AS 'Ngành',Lop AS 'Lớp',NgayDatCoc AS 'Ngày đặc cọc',(SELECT TenNV FROM tblNhanVien WHERE MaNV=NguoiNhanDatCoc) AS 'Người nhận tiền đặt cọc',(SELECT TenNV FROM tblNhanVien WHERE MaNV=NguoiCapNhat) AS 'Người cập nhật cuối',NgayCapNhat AS 'Ngày cập nhật cuối' FROM tblDocGia";
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                //dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
         */ 
//Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        } 
        //Đọc từ file excel
        public DataTable ReadExcel(string strFile)
        {
            DataTable dt = new DataTable();
            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+strFile+";Extended Properties=Excel 8.0;HDR=YES;";
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strFile + ";" + "Extended Properties=Excel 8.0;";
            try
            {
                OleDbConnection objConn = new OleDbConnection(connectionString);
                objConn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                objAdapter1.SelectCommand = objCmdSelect;
                objAdapter1.Fill(dt);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        //Ghi dữ liệu excel vào sql server
        public bool InsertFromExcel(DataTable dt)
        {
            bool blKey = false;
            string strSQL = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    strSQL += "insert into tblDocGia(MaDG,TenDG,NgaySinh,GioiTinh,Khoa,KhoaHoc,Nganh,Lop,NoiSinh,DiaChi,SoDT,DaDatCoc,LoaiDG,NguoiCapNhat,NgayCapNhat) values(";
                    strSQL += "@MaDG" + i + ",@TenDG" + i + ",@NgaySinh" + i + ",@GioiTinh" + i + ",@Khoa" + i + ",@KhoaHoc" + i + ",@Nganh" + i + ",@Lop" + i + ",@NoiSinh" + i + ",@DiaChi" + i + ",@SoDT" + i + ",@DaDatCoc,@LoaiDG,@NguoiCapNhat,@NgayCapNhat);";
                    cmd.Parameters.AddWithValue("@MaDG" + i, dr["MSSV"].ToString());
                    cmd.Parameters.AddWithValue("@TenDG" + i, dr["HoTen"].ToString());
                    cmd.Parameters.AddWithValue("@NgaySinh" + i, Convert.ToDateTime(dr["NgaySinh"]));
                    cmd.Parameters.AddWithValue("@GioiTinh" + i, Convert.ToByte(dr["GioiTinh"]));
                    cmd.Parameters.AddWithValue("@Khoa" + i, dr["Khoa"].ToString());
                    cmd.Parameters.AddWithValue("@KhoaHoc" + i, dr["KhoaHoc"].ToString());
                    cmd.Parameters.AddWithValue("@Nganh" + i, dr["Nganh"].ToString());
                    cmd.Parameters.AddWithValue("@Lop" + i, dr["Lop"].ToString());
                    cmd.Parameters.AddWithValue("@NoiSinh" + i, dr["NoiSinh"].ToString());
                    cmd.Parameters.AddWithValue("@DiaChi" + i, dr["DiaChi"].ToString());
                    cmd.Parameters.AddWithValue("@SoDT" + i, dr["SoDT"].ToString());
                    i++;
                }
                cmd.Parameters.AddWithValue("@DaDatCoc", 0);
                cmd.Parameters.AddWithValue("@LoaiDG", 0);
                cmd.Parameters.AddWithValue("@NguoiCapNhat", KiemTra.userid);
                cmd.Parameters.AddWithValue("@NgayCapNhat", DateTime.Today);
                Database db = new Database();
                if (db.Update(strSQL, CommandType.Text, cmd))
                    blKey = true;
                else
                    strError = db.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
    }
}
