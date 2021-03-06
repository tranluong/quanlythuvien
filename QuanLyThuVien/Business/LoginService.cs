using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class LoginService
    {
        //Hàm đăng nhập
        public bool Login(Login clsLogin)
        {
            bool blKey = false;            
            try
            {
                LoginDAO clsDAO = new LoginDAO();
                int intRow = clsDAO.Login(clsLogin).Rows.Count;
                if (clsDAO.Error != "")
                    strError = clsDAO.Error;
                else
                    if (intRow != 0)
                    {
                        KiemTra.userid = Convert.ToInt16(clsDAO.Login(clsLogin).Rows[0]["MaNV"]);
                        blKey = true;
                    }
                    else
                        strError = "Khai báo tên đăng nhập và mật khẩu không đúng";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Phân quyền
        public byte[] Permission(int intMaNV)
        {
            byte[] byt = new byte[10];
            LoginDAO clsDAO = new LoginDAO();            
            try
            {
                DataTable dt = new DataTable();
                dt = clsDAO.Permission(intMaNV);
                if (clsDAO.Error != "")
                    strError = clsDAO.Error;
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        byt[0] = Convert.ToByte(row["ChangePass"]);
                        byt[2] = Convert.ToByte(row["BackupData"]);
                        byt[3] = Convert.ToByte(row["RestoreData"]);
                        byt[4] = Convert.ToByte(row["CapNhatSach"]);
                        byt[6] = Convert.ToByte(row["CapNhatDocGia"]);
                        byt[7] = Convert.ToByte(row["CapNhatThuThu"]);
                        byt[8] = Convert.ToByte(row["MuonTra"]);
                        byt[9] = Convert.ToByte(row["BaoCao"]);
                    }       
                }                
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return byt;
        }
        //Hàm kiểm tra mật khẩu cũ khi thay đổi mật khẩu
        public bool CheckOldPwd(Login clsLogin)
        {
            bool blKey = false;
            try
            {                
                LoginDAO clsDAO = new LoginDAO();
                int intRow = clsDAO.Login(clsLogin).Rows.Count;
                if (clsDAO.Error != "")
                    strError = clsDAO.Error;
                else
                    if (intRow != 0)
                    {
                        blKey = true;
                    }
                    else
                        strError = "Khai báo mật khẩu cũ không đúng";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Hàm đổi mật khẩu
        public bool ChangePwd(Login clsLogin)
        {
            bool blKey = false;
            LoginDAO cls = new LoginDAO();
            try
            {
                if(CheckOldPwd(clsLogin))
                    if (cls.ChangePwd(clsLogin))
                        blKey = true;
                    else
                        strError = cls.Error;
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
