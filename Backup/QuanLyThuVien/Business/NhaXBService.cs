using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class NhaXBService
    {
        /*Kiểm tra trùng tên nhà xuất bản
        public bool IsExistName(string strTenNXB)
        {
            bool blDup = true;
            NhaXBDAO cls = new NhaXBDAO();
            if (cls.IsExistName(strTenNXB))
                strError = cls.Error;
            else
                blDup = false;
            return blDup;
        }*/ 
        //Thêm nhà xuất bản
        public bool CreateNhaXB(NhaXB clsNXB)
        {
            bool blKey = false;
            NhaXBDAO clsNXBDAO = new NhaXBDAO();
            if (clsNXBDAO.IsExistName(clsNXB.TenNXB))
                strError = clsNXBDAO.Error;
            else
            {
                if (clsNXBDAO.CreateNhaXB(clsNXB))
                    blKey = true;
                else
                    strError = clsNXBDAO.Error;
            }
            return blKey;
        }
        /*Kiểm tra nhà xuất bản có đang được sử dụng hay không (khóa ngoại)
        public bool HasForeignKey(int intMaNXB)
        {
            bool blKey = true;
            NhaXBDAO cls = new NhaXBDAO();
            if (cls.HasForeignKey(intMaNXB))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }*/ 
        //Xóa nhà xuất bản
        public bool DeleteNhaXB(NhaXB clsNXB)
        {
            bool blKey = false;
            NhaXBDAO clsNXBDAO = new NhaXBDAO();
            if (clsNXBDAO.HasForeignKey(clsNXB.MaNXB))
                strError = clsNXBDAO.Error;
            else
            {
                if (clsNXBDAO.DeleteNhaXB(clsNXB))
                    blKey = true;
                else
                    strError = clsNXBDAO.Error;
            }
            return blKey;
        }
        //Cập nhật nhà xuất bản
        public bool UpdateNhaXB(NhaXB clsNXB)
        {
            bool blKey = false;
            NhaXBDAO clsNXBDAO = new NhaXBDAO();
            if (clsNXBDAO.IsExistName(clsNXB))
                strError = clsNXBDAO.Error;
            else
            {
                if (clsNXBDAO.UpdateNhaXB(clsNXB))
                    blKey = true;
                else
                    strError = clsNXBDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm nhà xuất bản
        public DataTable SearchNhaXB(string strKeyword, int intType)
        {
            NhaXBDAO clsNhaXBDAO = new NhaXBDAO();
            DataTable dt = clsNhaXBDAO.SearchNhaXB(strKeyword, intType);
            if (clsNhaXBDAO.Error != "")
                strError = clsNhaXBDAO.Error;
            return dt;
        }
        //Hiển thị tất cả nhà xuất bản
        public DataTable ShowAllNhaXB()
        {
            NhaXBDAO clsNhaXBDAO = new NhaXBDAO();
            DataTable dt = clsNhaXBDAO.ShowAllNhaXB();
            if (clsNhaXBDAO.Error != "")
                strError = clsNhaXBDAO.Error;
            
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
