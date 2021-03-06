using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class KhoChuaService
    {
        /*Kiểm tra trùng tên kho
        public bool IsExistName(string strTenKho)
        {
            bool blDup = true;
            KhoChuaDAO cls = new KhoChuaDAO();
            if (cls.IsExistName(strTenKho))
                strError = cls.Error;
            else
                blDup = false;
            return blDup;
        }*/
        //Thêm kho
        public bool CreateKho(KhoChua clsKho)
        {
            bool blKey = false;
            KhoChuaDAO clsKhoDAO = new KhoChuaDAO();
            if (clsKhoDAO.IsExistName(clsKho.TenKho))
                strError = clsKhoDAO.Error;
            else
            {
                if (clsKhoDAO.CreateKho(clsKho))
                    blKey = true;
                else
                    strError = clsKhoDAO.Error;
            }
            return blKey;
        }
        /*Kiểm tra kho có đang được sử dụng hay không (khóa ngoại)
        public bool HasForeignKey(int intMaKho)
        {
            bool blKey = true;
            KhoChuaDAO cls = new KhoChuaDAO();
            if (cls.HasForeignKey(intMaKho))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }*/ 
        //Xóa kho
        public bool DeleteKho(KhoChua clsKho)
        {
            bool blKey = false;
            KhoChuaDAO clsKhoDAO = new KhoChuaDAO();
            if (clsKhoDAO.HasForeignKey(clsKho.MaKho))
                strError = clsKhoDAO.Error;
            else
            {
                if (clsKhoDAO.DeleteKho(clsKho))
                    blKey = true;
                else
                    strError = clsKhoDAO.Error;
            }
            return blKey;
        }
        //Cập nhật kho
        public bool UpdateKho(KhoChua clsKho)
        {
            bool blKey = false;
            KhoChuaDAO clsKhoDAO = new KhoChuaDAO();
            if (clsKhoDAO.IsExistName(clsKho))
                strError = clsKhoDAO.Error;
            else
            {
                if (clsKhoDAO.UpdateKho(clsKho))
                    blKey = true;
                else
                    strError = clsKhoDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm kho
        public DataTable SearchKho(string strKeyword, int intType)
        {
            KhoChuaDAO clsKhoDAO = new KhoChuaDAO();
            DataTable dt = clsKhoDAO.SearchKho(strKeyword, intType);
            if (clsKhoDAO.Error != "")
                strError = clsKhoDAO.Error;
            return dt;
        }
        //Hiển thị tất cả kho
        public DataTable ShowAllKho()
        {
            KhoChuaDAO clsKhoDAO = new KhoChuaDAO();
            DataTable dt = clsKhoDAO.ShowAllKho();
            if (clsKhoDAO.Error != "")
                strError = clsKhoDAO.Error;
            
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
