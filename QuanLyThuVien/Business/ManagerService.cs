using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace QuanLyThuVien
{
    class ManagerService
    {        
        //Thêm ngôn ngữ
        public bool CreateManager(Manager clsManager)
        {
            bool blKey = false;
            ManagerDAO clsManagerDAO = new ManagerDAO();
            if (clsManagerDAO.IsExistUsername(clsManager.Username))
                strError = clsManagerDAO.Error;
            else
            {
                if (clsManagerDAO.CreateManager(clsManager))
                    blKey = true;
                else
                    strError = clsManagerDAO.Error;
            }
            return blKey;
        }
        
        //Xóa thủ thư
        public bool DeleteManager(Manager clsManager)
        {
            bool blKey = false;
            //if (!HasForeignKey(clsLang.LangID))
            //{
                ManagerDAO clsManagerDAO = new ManagerDAO();
                if (clsManagerDAO.DeleteManager(clsManager))
                    blKey = true;
                else
                    strError = clsManagerDAO.Error;
            //}
            return blKey;
        }
        //Cập nhật thủ thư
        public bool UpdateManager(string strManager,Manager clsManager)
        {
            bool blKey = false;
            ManagerDAO clsManagerDAO = new ManagerDAO();
            if (clsManagerDAO.IsExistUsername(clsManager.ID, strManager))
                strError = clsManagerDAO.Error;
            else
            {                
                if (clsManagerDAO.UpdateManager(strManager,clsManager))
                    blKey = true;
                else
                    strError = clsManagerDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm thủ thư
        public DataTable SearchManager(int intType, string strKeyword, int intFilter)
        {
            ManagerDAO clsManagerDAO = new ManagerDAO();
            DataTable dt = clsManagerDAO.SearchManager(intType, strKeyword, intFilter);
            if (clsManagerDAO.Error != "")
                strError = clsManagerDAO.Error;            
            return dt;
        }
        //Hiển thị tất cả thủ thư
        public DataTable ShowAllManager()
        {
            ManagerDAO clsManagerDAO = new ManagerDAO();
            DataTable dt = clsManagerDAO.ShowAllManager();
            if (clsManagerDAO.Error != "")
                strError = clsManagerDAO.Error;            
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
