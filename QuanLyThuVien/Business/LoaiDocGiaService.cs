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
    class LoaiDocGiaService
    {
        //Thêm nhà xuất bản
        public bool CreateLoaiDocGia(LoaiDocGia clsLDG)
        {
            bool blKey = false;
            LoaiDocGiaDao clsLDGDAO = new LoaiDocGiaDao();
            if (clsLDGDAO.IsExistName(clsLDG.TenLoaiDG))
                strError = clsLDGDAO.Error;
            else
            {
                if (clsLDGDAO.CreateLoaiDocGia(clsLDG))
                    blKey = true;
                else
                    strError = clsLDGDAO.Error;
            }
            return blKey;
        }
        //Xóa nhà xuất bản
        public bool DeleteLoaiDocGia(LoaiDocGia clsLDG)
        {
            bool blKey = false;
            LoaiDocGiaDao clsLDGDAO = new LoaiDocGiaDao();
            if (clsLDGDAO.HasForeignKey(clsLDG.MaLoaiDG))
                strError = clsLDGDAO.Error;
            else
            {
                if (clsLDGDAO.DeleteLoaiDocGia(clsLDG))
                    blKey = true;
                else
                    strError = clsLDGDAO.Error;
            }
            return blKey;
        }
        //Cập nhật nhà xuất bản
        public bool UpdateLoaiDocGia(LoaiDocGia clsLDG)
        {
            bool blKey = false;
            LoaiDocGiaDao clsLDGDAO = new LoaiDocGiaDao();
            if (clsLDGDAO.IsExistNameWhileUpdate(clsLDG))
                strError = clsLDGDAO.Error;
            else
            {
                if (clsLDGDAO.UpdateLoaiDocGia(clsLDG))
                    blKey = true;
                else
                    strError = clsLDGDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm nhà xuất bản
        public DataTable SearchLoaiDocGia(string strKeyword, int intType)
        {
            LoaiDocGiaDao clsLoaiDocGiaDAO = new LoaiDocGiaDao();
            DataTable dt = clsLoaiDocGiaDAO.SearchLoaiDocGia(strKeyword, intType);
            if (clsLoaiDocGiaDAO.Error != "")
                strError = clsLoaiDocGiaDAO.Error;
            return dt;
        }
        //Hiển thị tất cả nhà xuất bản
        public DataTable ShowAllLoaiDocGia()
        {
            LoaiDocGiaDao clsLoaiDocGiaDAO = new LoaiDocGiaDao();
            DataTable dt = clsLoaiDocGiaDAO.ShowAllLoaiDocGia();
            if (clsLoaiDocGiaDAO.Error != "")
                strError = clsLoaiDocGiaDAO.Error;

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
