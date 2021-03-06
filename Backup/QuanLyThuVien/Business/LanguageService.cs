using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class LanguageService
    {
/*        
        //Kiểm tra trùng tên ngôn ngữ
        public bool IsExistName(string strLangName)
        {
            bool blDup = true;
            LanguageDAO cls = new LanguageDAO();
            if (cls.IsExistName(strLangName))
                strError = cls.Error;
            else
                blDup = false;
            return blDup;
        }
*/
//Thêm ngôn ngữ
        public bool CreateLang(Language clsLang)
        {
            bool blKey = false;
            LanguageDAO clsLangDAO = new LanguageDAO();
            if (clsLangDAO.IsExistName(clsLang.LangName))
                strError = clsLangDAO.Error;
            else
            {
                if (clsLangDAO.CreateLang(clsLang))
                    blKey = true;
                else
                    strError = clsLangDAO.Error;
            }
            return blKey;        
        }
//Kiểm tra ngôn ngữ có đang được sử dụng hay không (khóa ngoại)
        /*public bool HasForeignKey(int intLangID)
        {
            bool blKey = true;
            LanguageDAO cls = new LanguageDAO();
            if (cls.HasForeignKey(intLangID))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }*/
//Xóa ngôn ngữ
        public bool DeleteLang(Language clsLang)
        {
            bool blKey = false;
            LanguageDAO clsLangDAO = new LanguageDAO();
            if (clsLangDAO.HasForeignKey(clsLang.LangID))
                strError = clsLangDAO.Error;
            else
            {
                if (clsLangDAO.DeleteLang(clsLang))
                    blKey = true;
                else
                    strError = clsLangDAO.Error;
            }
            return blKey;
        }
//Cập nhật ngôn ngữ
        public bool UpdateLang(Language clsLang)
        {
            bool blKey = false;
            LanguageDAO clsLangDAO = new LanguageDAO();
            if (clsLangDAO.IsExistName(clsLang))
                strError = clsLangDAO.Error;
            else
            {                
                if (clsLangDAO.UpdateLang(clsLang))
                    blKey = true;
                else
                    strError = clsLangDAO.Error;
            }
            return blKey;
        }
//Tìm kiếm ngôn ngữ
        public DataTable SearchLang(string strKeyword, int intType)
        {                      
            LanguageDAO clsLangDAO = new LanguageDAO();
            DataTable dt = clsLangDAO.SearchLang(strKeyword,intType);
            if (clsLangDAO.Error != "")
                strError = clsLangDAO.Error;
            return dt;                
        }
//Hiển thị tất cả ngôn ngữ
        public DataTable ShowAllLang()
        {
            LanguageDAO clsLangDAO = new LanguageDAO();
            DataTable dt = clsLangDAO.ShowAllLang();
            if (clsLangDAO.Error != "")
                strError = clsLangDAO.Error;
            return dt;
        }
//Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
    }
}
