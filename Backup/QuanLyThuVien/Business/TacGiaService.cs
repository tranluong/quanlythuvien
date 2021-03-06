using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class TacGiaService
    {
        
        //Thêm tác giả
        public bool CreateTG(TacGia clsTG)
        {
            bool blKey = false;
            TacGiaDAO clsTGDAO = new TacGiaDAO();
            if (clsTGDAO.IsExistName(clsTG.TenTG))
                strError = clsTGDAO.Error;
            else
            {
                if (clsTGDAO.CreateTG(clsTG))
                    blKey = true;
                else
                    strError = clsTGDAO.Error;
            }
            return blKey;
        }
       
        //Xóa tác giả
        public bool DeleteTG(TacGia clsTG)
        {
            bool blKey = false;
            TacGiaDAO clsTGDAO = new TacGiaDAO();
            if (clsTGDAO.HasForeignKey(clsTG.MaTG))
                strError = clsTGDAO.Error;
            else
            {
                if (clsTGDAO.DeleteTG(clsTG))
                    blKey = true;
                else
                    strError = clsTGDAO.Error;
            }
            return blKey;
        }
        //Cập nhật tác giả
        public bool UpdateTG(TacGia clsTG)
        {
            bool blKey = false;
            TacGiaDAO clsTGDAO = new TacGiaDAO();
            if (clsTGDAO.IsExistName(clsTG))
                strError = clsTGDAO.Error;
            else
            {
                if (clsTGDAO.UpdateTG(clsTG))
                    blKey = true;
                else
                    strError = clsTGDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm tác giả
        public DataTable SearchTG(string strKeyword, int intType)
        {
            TacGiaDAO clsTGDAO = new TacGiaDAO();
            DataTable dt = clsTGDAO.SearchTG(strKeyword, intType);
            if (clsTGDAO.Error != "")
                strError = clsTGDAO.Error;
            return dt;
        }
        //Hiển thị tất cả tác giả
        public DataTable ShowAllTG()
        {
            TacGiaDAO clsTGDAO = new TacGiaDAO();
            DataTable dt = clsTGDAO.ShowAllTG();
            if (clsTGDAO.Error != "")
                strError = clsTGDAO.Error;
            return dt;
        }
        //Thêm tác giả của sách
        public bool CreateTGT(TacGia clsTG)
        {
            bool blKey = false;
            TacGiaDAO cls = new TacGiaDAO();
            if (cls.IsExistNameChapter(clsTG.MaTap, clsTG.MaTG))
                strError = cls.Error;
            else
            {
                if (cls.CreateTGT(clsTG))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
        //Xóa tác giả của một sách
        //Xóa tác giả
        public bool DeleteTGT(TacGia clsTG)
        {
            bool blKey = false;
            TacGiaDAO clsTGDAO = new TacGiaDAO();            
            if (clsTGDAO.DeleteTGT(clsTG))
                blKey = true;
            else
                strError = clsTGDAO.Error;            
            return blKey;
        }
        //Cập nhật tác giả của sách
        public bool UpdateTGT(TacGia clsTG,int intOldMaTG)
        {
            bool blKey = false;
            TacGiaDAO clsTGDAO = new TacGiaDAO();
            if (clsTGDAO.IsExistNameChapter(clsTG, intOldMaTG))
            {
                strError = clsTGDAO.Error;                
            }
            else
            {
                if (clsTGDAO.UpdateTGT(clsTG, intOldMaTG))
                    blKey = true;
                else
                    strError = clsTGDAO.Error;
            }
            return blKey;
        }
        //Thêm tác giả của sách
        public bool CreateTGS(TacGia clsTG)
        {
            bool blKey = false;
            TacGiaDAO cls = new TacGiaDAO();
            if (cls.IsExistName(clsTG.MaTS, clsTG.MaTG))
                strError = cls.Error;
            else
            {
                if (cls.CreateTGS(clsTG))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
        //Xóa tác giả của một sách
        //Xóa tác giả
        public bool DeleteTGS(TacGia clsTG)
        {
            bool blKey = false;
            TacGiaDAO clsTGDAO = new TacGiaDAO();
            if (clsTGDAO.DeleteTGS(clsTG))
                blKey = true;
            else
                strError = clsTGDAO.Error;
            return blKey;
        }
        //Cập nhật tác giả của sách
        public bool UpdateTGS(TacGia clsTG, int intOldMaTG)
        {
            bool blKey = false;
            TacGiaDAO clsTGDAO = new TacGiaDAO();
            if (clsTGDAO.IsExistName(clsTG, intOldMaTG))
            {
                strError = clsTGDAO.Error;
            }
            else
            {
                if (clsTGDAO.UpdateTGS(clsTG, intOldMaTG))
                    blKey = true;
                else
                    strError = clsTGDAO.Error;
            }
            return blKey;
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
