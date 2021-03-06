using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QuanLyThuVien
{
    class HeThongService
    {
     
        //Sao lưu
        public bool Backup(string strDatabaseName, string strPath)
        {
            bool blKey = false;
            HeThongDAO cls = new HeThongDAO();
            if (cls.Backup(strDatabaseName, strPath))
                blKey = true;
            else
                strError = cls.Error;
            return blKey;
        }
        //Phục hồi
        public bool Restore(string strDatabaseName, string strPath)
        {
            bool blKey = false;
            HeThongDAO cls = new HeThongDAO();
            if (cls.Restore(strDatabaseName, strPath))
                blKey = true;
            else
                strError = cls.Error;
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
