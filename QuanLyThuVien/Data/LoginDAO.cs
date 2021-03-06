using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyThuVien
{
     class LoginDAO
    {
        //Hàm đăng nhập
        public DataTable Login(Login clsLogin)
        {
            string strSQL = "select * from tblNhanVien where TenDangNhap=@Username and MatKhau=@Password";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Username", clsLogin.Username);
            cmd.Parameters.AddWithValue("@Password", clsLogin.Password);
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
        //Phân quyền
        public DataTable Permission(int intMaNV)
        {
            string strSQL = "select * from tblPhanQuyen PQ, tblNhanVien NV where MaNV=@MaNV and PQ.MaPQ = NV.MaPQ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaNV", intMaNV);
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
        //Hàm đổi mật khẩu
        public bool ChangePwd(Login clsLogin)
        {
            bool blKey = false;
            string strSQL = "update tblNhanVien set MatKhau=@MatKhauMoi where MaNV=@MaNV";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MatKhauMoi", clsLogin.NewPassword);
            cmd.Parameters.AddWithValue("@MaNV", clsLogin.UserID);
            Database cls = new Database();            
            try
            {
                if (cls.Update(strSQL, CommandType.Text, cmd))
                    blKey = true;
                else
                    if (cls.Error != "")
                        strError = cls.Error;
                    else
                        strError = "Thay đổi mật khẩu thất bại";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
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
