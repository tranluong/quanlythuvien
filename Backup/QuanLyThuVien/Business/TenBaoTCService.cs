using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class TenBaoTCService
    {
        
        //Thêm báo, tạp chí
        public bool CreateBTC(TenBaoTC clsBTC)
        {
            bool blKey = false;
            TenBaoTCDAO clsBTCDAO = new TenBaoTCDAO();
            if (clsBTCDAO.IsExistName(clsBTC.TenBTC))
                strError = clsBTCDAO.Error;
            else
            {
                if (clsBTCDAO.CreateBTC(clsBTC))
                    blKey = true;
                else
                    strError = clsBTCDAO.Error;
            }
            return blKey;
        }
        
        //Xóa báo, tạp chí
        public bool DeleteBTC(TenBaoTC clsBTC)
        {
            bool blKey = false;
            TenBaoTCDAO clsBTCDAO = new TenBaoTCDAO();
            if (clsBTCDAO.HasForeignKey(clsBTC.MaTenBTC))
                strError = clsBTCDAO.Error;
            else
            {
                if (clsBTCDAO.DeleteBTC(clsBTC))
                    blKey = true;
                else
                    strError = clsBTCDAO.Error;
            }
            return blKey;
        }
        //Cập nhật báo, tạp chí
        public bool UpdateBTC(TenBaoTC clsBTC)
        {
            bool blKey = false;
            TenBaoTCDAO clsBTCDAO = new TenBaoTCDAO();
            if (clsBTCDAO.IsExistName(clsBTC))
                strError = clsBTCDAO.Error;
            else
            {
                if (clsBTCDAO.UpdateBTC(clsBTC))
                    blKey = true;
                else
                    strError = clsBTCDAO.Error;
            }
            return blKey;
        }
        //Tìm kiếm báo, tạp chí
        public DataTable SearchBTC(string strKeyword, int intType)
        {
            TenBaoTCDAO clsBTCDAO = new TenBaoTCDAO();
            DataTable dt = clsBTCDAO.SearchBTC(strKeyword, intType);
            if (clsBTCDAO.Error != "")
                strError = clsBTCDAO.Error;
            return dt;
        }
        //Hiển thị tất cả báo, tạp chí
        public DataTable ShowAllBTC()
        {
            TenBaoTCDAO clsBTCDAO = new TenBaoTCDAO();
            DataTable dt = clsBTCDAO.ShowAllBTC();
            if (clsBTCDAO.Error != "")
                strError = clsBTCDAO.Error;
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
