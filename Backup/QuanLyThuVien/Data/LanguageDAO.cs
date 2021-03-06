using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class LanguageDAO
    {
//Kiểm tra trùng tên ngôn ngữ khi thêm
        public bool IsExistName(string strLangName)
        {            
            bool blIsExist = true;            
            string strSQL = "select * from tblNgonNgu where TenNgonNgu=@TenNgonNgu";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNgonNgu", strLangName);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Ngôn ngữ này đã tồn tại";
                    //strError = MessageLanguage.IsExist;
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Kiểm tra trùng tên ngôn ngữ khi cập nhật
        public bool IsExistName(Language clsLang)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblNgonNgu where TenNgonNgu=@TenNgonNgu and MaNgonNgu!=@MaNgonNgu";
            SqlCommand cmd = new SqlCommand();            
            cmd.Parameters.AddWithValue("@TenNgonNgu", clsLang.LangName);
            cmd.Parameters.AddWithValue("MaNgonNgu", clsLang.LangID);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Ngôn ngữ này đã tồn tại";
                    //strError = MessageLanguage.IsExist;
                else
                    blIsExist = false;
            return blIsExist;
        }
//Thêm ngôn ngữ
        public bool CreateLang(Language clsLang)
        {
            bool blKey = false;            
            string strSQL = "insert into tblNgonNgu(TenNgonNgu) values(@TenNgonNgu)";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNgonNgu", clsLang.LangName);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm ngôn ngữ thất bại";
            return blKey;
        }
//Kiểm tra ngôn ngữ có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(int intLangID)
        {
            bool blKey = true;
            string strSQL = "select * from tblNgonNgu n, tblTuaSach t where n.MaNgonNgu=t.MaNgonNgu and n.MaNgonNgu=" + intLangID;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Ngôn ngữ này đang được sử dụng, không thể xóa !";
                        //strError = MessageLanguage.ForeignKey;
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
//Xóa ngôn ngữ
        public bool DeleteLang(Language clsLang)
        {
            bool blKey = false;
            string strsQL = "delete from tblNgonNgu where MaNgonNgu="+ clsLang.LangID;
            Database cls = new Database();            
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa ngôn ngữ thất bại";
            return blKey;
        }
//Cập nhật ngôn ngữ
        public bool UpdateLang(Language clsLang)
        {
            bool blKey = false;            
            string strsQL = "update tblNgonNgu set TenNgonNgu=@TenNgonNgu where MaNgonNgu=@MaNgonNgu";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNgonNgu", clsLang.LangName);
            cmd.Parameters.AddWithValue("@MaNgonNgu", clsLang.LangID);            
            Database cls = new Database();
            if (cls.Update(strsQL,CommandType.Text,cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật ngôn ngữ thất bại";
            return blKey;
        }
//Tìm ngôn ngữ
        public DataTable SearchLang(string strKeyword,int intType)
        {
            DataTable dt = new DataTable();
            string strSQL="";
            if(intType==0)
                strSQL = "select MaNgonNgu as 'Mã ngôn ngữ', TenNgonNgu as 'Tên ngôn ngữ' from tblNgonNgu where TenNgonNgu like '%'+@Keyword+'%'";
            else
                strSQL = "select MaNgonNgu as 'Mã ngôn ngữ', TenNgonNgu as 'Tên ngôn ngữ' from tblNgonNgu where TenNgonNgu like @Keyword";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);            
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
        public DataTable ShowAllLang()
        {
            string strSQL = "select MaNgonNgu as 'Mã ngôn ngữ', TenNgonNgu as 'Tên ngôn ngữ' from tblNgonNgu order by MaNgonNgu Desc";
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
