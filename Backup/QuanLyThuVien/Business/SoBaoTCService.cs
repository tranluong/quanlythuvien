using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class SoBaoTCService
    {
        //Thêm số báo, tạp chí
        public bool CreateSBTC(SoBaoTC clsSBTC)
        {
            bool blKey = false;
            SoBaoTCDAO clsSBTCDAO = new SoBaoTCDAO();
            if (clsSBTCDAO.IsExistNameSoPH(clsSBTC.SoPH,clsSBTC.MaTenBTC))
                strError = clsSBTCDAO.Error;
            else
            {
                if (clsSBTCDAO.CreateSBTC(clsSBTC))
                    blKey = true;
                else
                    strError = clsSBTCDAO.Error;
            }
            return blKey;
        }        
        //Xóa số báo, tạp chí
        public bool DeleteSBTC(SoBaoTC clsSBTC)
        {
            bool blKey = false;
            SoBaoTCDAO clsSBTCDAO = new SoBaoTCDAO();
            if (clsSBTCDAO.HasForeignKey(clsSBTC.MaTenBTC,clsSBTC.SoPH))
                strError = clsSBTCDAO.Error;
            else
            {
                if (clsSBTCDAO.DeleteSBTC(clsSBTC))
                    blKey = true;
                else
                    strError = clsSBTCDAO.Error;
            }
            return blKey;
        }
        //Cập nhật số báo, tạp chí
        public bool UpdateSBTC(SoBaoTC clsSBTC,int intMaTenBTC, string strSoPH)
        {
            bool blKey = false;
            SoBaoTCDAO clsSBTCDAO = new SoBaoTCDAO();
            if (clsSBTCDAO.IsExistNameSoPH(clsSBTC, intMaTenBTC, strSoPH))
                strError = clsSBTCDAO.Error;
            else
            {
                if (clsSBTCDAO.UpdateSBTC(clsSBTC, intMaTenBTC, strSoPH))
                    blKey = true;
                else
                    strError = clsSBTCDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm số báo, tạp chí
        public DataTable SearchSBTC(int intType,string strKeyword, int intFilter)
        {
            SoBaoTCDAO clsSBTCDAO = new SoBaoTCDAO();
            DataTable dt = clsSBTCDAO.SearchSBTC(intType, strKeyword, intFilter);
            if (clsSBTCDAO.Error != "")
                strError = clsSBTCDAO.Error;
            return dt;
        }
        //Hiển thị tất cả số báo, tạp chí
        public DataTable ShowAllSBTC()
        {
            SoBaoTCDAO clsSBTCDAO = new SoBaoTCDAO();
            DataTable dt = clsSBTCDAO.ShowAllSBTC();
            if (clsSBTCDAO.Error != "")
                strError = clsSBTCDAO.Error;
            return dt;
        }
        //Kiểm tra trùng ngày phát hành khi thêm
        public bool IsExistNgayPH(SoBaoTC clsSBTC)
        {
            bool blKey = false;
            SoBaoTCDAO clsSBTCDAO = new SoBaoTCDAO();
            blKey = clsSBTCDAO.IsExistNameNgayPH(clsSBTC);
            if (clsSBTCDAO.Error != "")
                strError = clsSBTCDAO.Error;
            return blKey;
        }
        //Kiểm tra trùng ngày phát hành khi cập nhật
        public bool IsExistNgayPH(SoBaoTC clsSBTC, DateTime dtOldNgayPH)
        {
            bool blKey = false;
            SoBaoTCDAO clsSBTCDAO = new SoBaoTCDAO();
            blKey = clsSBTCDAO.IsExistNameNgayPH(clsSBTC, dtOldNgayPH);
            if (clsSBTCDAO.Error != "")
                strError = clsSBTCDAO.Error;
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
