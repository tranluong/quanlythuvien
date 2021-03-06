using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class ManagerDAO
    {
        //Kiểm tra trùng tên đăng nhập khi thêm
        public bool IsExistUsername(string strUsername)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblNhanVien where TenDangNhap=@TenDangNhap";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenDangNhap", strUsername);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            //DataTable dt = new DataTable();
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tên đăng nhập này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Kiểm tra trùng tên đăng nhập khi cập nhật
        public bool IsExistUsername(int intManagerID, string strUsername)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblNhanVien where MaNV <>" + intManagerID + " and TenDangNhap=N'" + strUsername + "'";
            Database cls = new Database();
            //DataTable dt = cls.GetData(strSQL).Tables[0];
            DataTable dt = new DataTable();
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tên đăng nhập này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Thêm thủ thư
        public bool CreateManager(Manager clsManager)
        {
            //select cast('2010-02-13 00:00:00.000' as datetime)
            //tblNhanVien.NgaySinh where tblNhanVien.NgaySinh BETWEEN CONVERT(DATETIME, '{1}', 105) AND CONVERT(DATETIME, '{2}', 105))
            bool blKey = false;
            string strsQL = "insert into tblNhanVien values(@TenNV,@TenDangNhap,@MatKhau,@NgaySinh,@GioiTinh,@SoDT,@Email,@MaPQ)";
           // strsQL += "; insert into tblPhanQuyen values(@MaPQ,@Pass,@Backup,@Restore,@Sach,@DocGia,@ThuThu,@MuonTra,@BaoCao)";
            SqlCommand cmd = new SqlCommand();
            //Conversion failed when converting date and/or time from character string
            //cmd.Parameters.AddWithValue("@MaNV", clsManager.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", clsManager.Name);
            cmd.Parameters.AddWithValue("@TenDangNhap", clsManager.Username);
            cmd.Parameters.AddWithValue("@MatKhau", clsManager.Password);
            cmd.Parameters.AddWithValue("@NgaySinh", clsManager.NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", clsManager.GioiTinh);
            cmd.Parameters.AddWithValue("@SoDT", clsManager.SoDT);
            cmd.Parameters.AddWithValue("@Email", clsManager.Email);
            cmd.Parameters.AddWithValue("@MaPQ", clsManager.MaPQ);
         
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm thủ thư thất bại";
            return blKey;
        }
 
        //Xóa thủ thư
        public bool DeleteManager(Manager clsManager)
        {
            bool blKey = false;
            string strsQL = "delete from tblNhanVien where MaNV=@MaNV";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaNV", clsManager.ID);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa thủ thư thất bại";
            return blKey;
        }
        //Cập nhật ngôn ngữ
        public bool UpdateManager(string strManager,Manager clsManager)
        {
            bool blKey = false;
            string strsQL = "update tblNhanVien set TenNV=@TenNV, TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, SoDT = @SoDT, Email = @Email, MaPQ = @MaPQ where MaNV=@MaNVID ";
            //strsQL += "; update tblPhanQuyen set ChangePass=@Pass, BackupData=@Backup, RestoreData=@Restore, CapNhatSach=@Sach, CapNhatDocGia=@DocGia, CapNhatThuThu=@ThuThu, MuonTra=@MuonTra, BaoCao=@BaoCao where MaPQ=@MaPQ ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaNV", clsManager.ID);
            cmd.Parameters.AddWithValue("@TenNV", clsManager.Name);
            cmd.Parameters.AddWithValue("@TenDangNhap", clsManager.Username);
            cmd.Parameters.AddWithValue("@MatKhau", clsManager.Password);
            cmd.Parameters.AddWithValue("@NgaySinh", clsManager.NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", clsManager.GioiTinh);
            cmd.Parameters.AddWithValue("@SoDT", clsManager.SoDT);
            cmd.Parameters.AddWithValue("@Email", clsManager.Email);
            cmd.Parameters.AddWithValue("@MaPQ", clsManager.MaPQ);
            cmd.Parameters.AddWithValue("@MaNVID", strManager);
            //cmd.Parameters.AddWithValue("@Pass", clsManager.PhanQuyen[1]);
            //cmd.Parameters.AddWithValue("@Backup", clsManager.PhanQuyen[7]);
            //cmd.Parameters.AddWithValue("@Restore", clsManager.PhanQuyen[8]);
            //cmd.Parameters.AddWithValue("@Sach", clsManager.PhanQuyen[4]);
            //cmd.Parameters.AddWithValue("@DocGia", clsManager.PhanQuyen[5]);
            //cmd.Parameters.AddWithValue("@ThuThu", clsManager.PhanQuyen[9]);
            //cmd.Parameters.AddWithValue("@MuonTra", clsManager.PhanQuyen[0]);
            //cmd.Parameters.AddWithValue("@BaoCao", clsManager.PhanQuyen[6]);
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
        //Tìm ngôn ngữ
        public DataTable SearchManager(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "";
            if (intType == 0)
                if(intFilter==0)
                    strSQL = "select MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau as 'Mật Khẩu',NgaySinh as 'Ngày Sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',SoDT as 'Điện Thoại',Email,MaPQ as 'Phân Quyền' from tblNhanVien  where  TenDangNhap like '%'+@Keyword+'%' and TenDangNhap <> 'admin'";
                else
                    strSQL = "select MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau as 'Mật Khẩu',NgaySinh as 'Ngày Sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',SoDT as 'Điện Thoại',Email,MaPQ as 'Phân Quyền'  from tblNhanVien where  TenDangNhap like @Keyword and TenDangNhap <> 'admin'";
            else
                if(intFilter==0)
                    strSQL = "select MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau as 'Mật Khẩu',NgaySinh as 'Ngày Sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',SoDT as 'Điện Thoại',Email,MaPQ as 'Phân Quyền' from tblNhanVien  where  TenNV like '%'+@Keyword+'%' and TenDangNhap <> 'admin'";
                else
                    strSQL = "select MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau as 'Mật Khẩu',NgaySinh as 'Ngày Sinh',CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính',SoDT as 'Điện Thoại',Email,MaPQ as 'Phân Quyền'  from tblNhanVien where  TenNV like @Keyword and TenDangNhap <> 'admin'";
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
        public DataTable ShowAllManager()
        {
            string strSQL = "select NV.MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau as 'Mật khẩu', NgaySinh as 'Ngày Sinh', CASE GioiTinh WHEN 1 THEN 'Nam' WHEN 0 THEN N'Nữ' END AS 'Giới tính' , SoDT as 'Điện Thoại', Email, MaPQ as 'Mã PQ'  from tblNhanVien NV where TenDangNhap <> 'admin'";
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
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
