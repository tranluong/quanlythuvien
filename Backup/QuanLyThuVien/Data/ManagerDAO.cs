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
            bool blKey = false;
            string strsQL = "insert into tblNhanVien values(@TenNV,@Username,@Password)";                        
            strsQL += "; insert into tblPhanQuyen values(@@IDENTITY,@Pass,@Param,@Backup,@Restore,@Sach,@Bao,@DocGia,@ThuThu,@MuonTra,@BaoCao)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNV", clsManager.Name);
            cmd.Parameters.AddWithValue("@Username", clsManager.Username);
            cmd.Parameters.AddWithValue("@Password", clsManager.Password);

            cmd.Parameters.AddWithValue("@Pass", clsManager.PhanQuyen[1]);
            cmd.Parameters.AddWithValue("@Param", clsManager.PhanQuyen[3]);
            cmd.Parameters.AddWithValue("@Backup", clsManager.PhanQuyen[7]);
            cmd.Parameters.AddWithValue("@Restore", clsManager.PhanQuyen[8]);
            cmd.Parameters.AddWithValue("@Sach", clsManager.PhanQuyen[4]);
            cmd.Parameters.AddWithValue("@Bao", clsManager.PhanQuyen[2]);
            cmd.Parameters.AddWithValue("@DocGia", clsManager.PhanQuyen[5]);
            cmd.Parameters.AddWithValue("@ThuThu", clsManager.PhanQuyen[9]);
            cmd.Parameters.AddWithValue("@MuonTra", clsManager.PhanQuyen[0]);
            cmd.Parameters.AddWithValue("@BaoCao", clsManager.PhanQuyen[6]);
/*
0 Mượn Trả
1 Đổi mật khẩu
2 Cập nhật Báo, Tạp chí
3 Thay đổi quy định
4 Cập nhật Sách
5 Cập nhật Độc giả
6 Báo cáo
7 Sao lưu dữ liệu
8 Phục hồi dữ liệu
9 Cập nhật Thủ thư
*/
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
        //Kiểm tra khóa ngoại thủ thư
        public bool HasForeignKey(int intLangID)
        {
            bool blKey = true;
            string strSQL = "select * from tblNgonNgu n, tblTuaSach t where n.MaNgonNgu=t.MaNgonNgu and n.MaNgonNgu=" + intLangID;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                //dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Ngôn ngữ này đang được sử dụng";
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
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
        public bool UpdateManager(Manager clsManager)
        {
            bool blKey = false;
            string strsQL = "update tblNhanVien set TenNV=@TenNV, TenDangNhap=@Username, MatKhau=@Password where MaNV=@MaNV";
            strsQL += "; update tblPhanQuyen set ChangePass=@Pass, ChangeParam=@Param, BackupData=@Backup, RestoreData=@Restore, CapNhatSach=@Sach, CapNhatBaoTC=@Bao, CapNhatDocGia=@DocGia, CapNhatThuThu=@ThuThu, MuonTra=@MuonTra, BaoCao=@BaoCao where MaNV=@MaNV";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNV", clsManager.Name);
            cmd.Parameters.AddWithValue("@Username", clsManager.Username);
            cmd.Parameters.AddWithValue("@Password", clsManager.Password);
            cmd.Parameters.AddWithValue("@MaNV", clsManager.ID);

            cmd.Parameters.AddWithValue("@Pass", clsManager.PhanQuyen[1]);
            cmd.Parameters.AddWithValue("@Param", clsManager.PhanQuyen[3]);
            cmd.Parameters.AddWithValue("@Backup", clsManager.PhanQuyen[7]);
            cmd.Parameters.AddWithValue("@Restore", clsManager.PhanQuyen[8]);
            cmd.Parameters.AddWithValue("@Sach", clsManager.PhanQuyen[4]);
            cmd.Parameters.AddWithValue("@Bao", clsManager.PhanQuyen[2]);
            cmd.Parameters.AddWithValue("@DocGia", clsManager.PhanQuyen[5]);
            cmd.Parameters.AddWithValue("@ThuThu", clsManager.PhanQuyen[9]);
            cmd.Parameters.AddWithValue("@MuonTra", clsManager.PhanQuyen[0]);
            cmd.Parameters.AddWithValue("@BaoCao", clsManager.PhanQuyen[6]);
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
                    strSQL = "select NV.MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau, MuonTra, ChangePass, CapNhatBaoTC, ChangeParam, CapNhatSach, CapNhatDocGia, BaoCao, BackupData, RestoreData, CapNhatThuThu  from tblNhanVien NV, tblPhanQuyen PQ where NV.MaNV=PQ.MaNV and TenDangNhap like '%'+@Keyword+'%' and TenDangNhap <> 'admin'";
                else
                    strSQL = "select NV.MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau, MuonTra, ChangePass, CapNhatBaoTC, ChangeParam, CapNhatSach, CapNhatDocGia, BaoCao, BackupData, RestoreData, CapNhatThuThu  from tblNhanVien NV, tblPhanQuyen PQ where NV.MaNV=PQ.MaNV and TenDangNhap like @Keyword and TenDangNhap <> 'admin'";
            else
                if(intFilter==0)
                    strSQL = "select NV.MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau, MuonTra, ChangePass, CapNhatBaoTC, ChangeParam, CapNhatSach, CapNhatDocGia, BaoCao, BackupData, RestoreData, CapNhatThuThu  from tblNhanVien NV, tblPhanQuyen PQ where NV.MaNV=PQ.MaNV and TenNV like '%'+@Keyword+'%' and TenDangNhap <> 'admin'";
                else
                    strSQL = "select NV.MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau, MuonTra, ChangePass, CapNhatBaoTC, ChangeParam, CapNhatSach, CapNhatDocGia, BaoCao, BackupData, RestoreData, CapNhatThuThu  from tblNhanVien NV, tblPhanQuyen PQ where NV.MaNV=PQ.MaNV and TenNV like @Keyword and TenDangNhap <> 'admin'";
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
        //Hiển thị tất cả ngôn ngữ
        public DataTable ShowAllManager()
        {
            string strSQL = "select NV.MaNV as 'Mã Thủ thư', TenNV as 'Tên Thủ thư', TenDangNhap as 'Tên đăng nhập',MatKhau as 'Mật khẩu', MuonTra, ChangePass, CapNhatBaoTC, ChangeParam, CapNhatSach, CapNhatDocGia, BaoCao, BackupData, RestoreData, CapNhatThuThu  from tblNhanVien NV, tblPhanQuyen PQ where NV.MaNV=PQ.MaNV and TenDangNhap <> 'admin'";
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
