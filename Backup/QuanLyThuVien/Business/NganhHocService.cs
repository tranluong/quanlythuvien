using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class NganhHocService
    {
        /*Kiểm tra trùng tên ngành
        public bool IsExistName(string strTenNganh)
        {
            bool blDup = true;
            NganhHocDAO cls = new NganhHocDAO();
            if (cls.IsExistName(strTenNganh))
                strError = cls.Error;
            else
                blDup = false;
            return blDup;
        } */
        //Thêm ngành
        public bool CreateNganh(NganhHoc clsNganh)
        {
            bool blKey = false;
            NganhHocDAO clsNganhDAO = new NganhHocDAO();
            if (clsNganhDAO.IsExistName(clsNganh.TenNganh))
                strError = clsNganhDAO.Error;
            else
            {
                if (clsNganhDAO.CreateNganh(clsNganh))
                    blKey = true;
                else
                    strError = clsNganhDAO.Error;
            }
            return blKey;
        }
        /*Kiểm tra ngành có đang được sử dụng hay không (khóa ngoại)
        public bool HasForeignKey(int intMaNganh)
        {
            bool blKey = true;
            NganhHocDAO cls = new NganhHocDAO();
            if (cls.HasForeignKey(intMaNganh))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }*/
        //Xóa ngành
        public bool DeleteNganh(NganhHoc clsNganh)
        {
            bool blKey = false;
            NganhHocDAO clsNganhDAO = new NganhHocDAO();
            if (clsNganhDAO.HasForeignKey(clsNganh.MaNganh))
                strError = clsNganhDAO.Error;
            else
            {
                if (clsNganhDAO.DeleteNganh(clsNganh))
                    blKey = true;
                else
                    strError = clsNganhDAO.Error;
            }
            return blKey;
        }
        //Cập nhật ngành
        public bool UpdateNganh(NganhHoc clsNganh)
        {
            bool blKey = false;
            NganhHocDAO clsNganhDAO = new NganhHocDAO();
            if (clsNganhDAO.IsExistName(clsNganh))
                strError = clsNganhDAO.Error;
            else
            {
                if (clsNganhDAO.UpdateNganh(clsNganh))
                    blKey = true;
                else
                    strError = clsNganhDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm ngành
        public DataTable SearchNganh(string strKeyword, int intType)
        {
            NganhHocDAO clsNganhDAO = new NganhHocDAO();
            DataTable dt = clsNganhDAO.SearchNganh(strKeyword, intType);
            if (clsNganhDAO.Error != "")
                strError = clsNganhDAO.Error;
            return dt;
        }
        //Hiển thị tất cả ngành
        public DataTable ShowAllNganh()
        {
            NganhHocDAO clsNganhDAO = new NganhHocDAO();
            DataTable dt = clsNganhDAO.ShowAllNganh();
            if (clsNganhDAO.Error != "")
                strError = clsNganhDAO.Error;
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
