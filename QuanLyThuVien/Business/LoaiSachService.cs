using QuanLyThuVien.Data;
using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Business
{
    class LoaiSachService
    {
        public bool CreateLoaiSach(LoaiSach clsLoaiSach)
        {
            bool blKey = false;
            LoaiSachDao clsLoaiSachDAO = new LoaiSachDao();
            if (clsLoaiSachDAO.IsExistName(clsLoaiSach.TenLoaiSach))
                strError = clsLoaiSachDAO.Error;
            else
            {
                if (clsLoaiSachDAO.CreateLoaiDocGia(clsLoaiSach))
                    blKey = true;
                else
                    strError = clsLoaiSachDAO.Error;
            }
            return blKey;
        }
        //Xóa loại sách
        public bool DeleteLoaiSach(LoaiSach clsLoaiSach)
        {
            bool blKey = false;
            LoaiSachDao clsLoaiSachDAO = new LoaiSachDao();
            if (clsLoaiSachDAO.HasForeignKey(clsLoaiSach.MaLoaiSach))
                strError = clsLoaiSachDAO.Error;
            else
            {
                if (clsLoaiSachDAO.DeleteLoaiSach(clsLoaiSach))
                    blKey = true;
                else
                    strError = clsLoaiSachDAO.Error;
            }
            return blKey;
        }
        //Cập nhật loại sách
        public bool UpdateLoaiSach(LoaiSach clsLoaiSach)
        {
            bool blKey = false;
            LoaiSachDao clsLoaiSachDAO = new LoaiSachDao();
            if (clsLoaiSachDAO.IsExistNameWhileUpdate(clsLoaiSach))
                strError = clsLoaiSachDAO.Error;
            else
            {
                if (clsLoaiSachDAO.UpdateLoaiSach(clsLoaiSach))
                    blKey = true;
                else
                    strError = clsLoaiSachDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm nhà xuất bản
        public DataTable SearchLoaiSach(string strKeyword, int intType)
        {
            LoaiSachDao clsLoaiSachDAO = new LoaiSachDao();
            DataTable dt = clsLoaiSachDAO.SearchLoaiSach(strKeyword, intType);
            if (clsLoaiSachDAO.Error != "")
                strError = clsLoaiSachDAO.Error;
            return dt;
        }
        //Hiển thị tất cả nhà xuất bản
        public DataTable ShowAllLoaiSach()
        {
            LoaiSachDao clsLoaiSachDAO = new LoaiSachDao();
            DataTable dt = clsLoaiSachDAO.ShowAllLoaiSach();
            if (clsLoaiSachDAO.Error != "")
                strError = clsLoaiSachDAO.Error;

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
