using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class SachYeuCauService
    {
        //Thêm
        public bool Add(SachYeuCau cls)
        {
            bool blKey = false;
            SachYeuCauDAO clsDAO = new SachYeuCauDAO();
            if (clsDAO.IsExist(cls))
                strError = clsDAO.Error;
            else
            {
                if (clsDAO.Add(cls))
                    blKey = true;
                else
                    strError = clsDAO.Error;
            }
            return blKey;
        }
        //Xóa tất cả
        public bool DeleteAll()
        {
            bool blKey = false;
            SachYeuCauDAO clsDAO = new SachYeuCauDAO();
            if (clsDAO.DeleteAll())
                blKey = true;
            else
                strError = clsDAO.Error;

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
