using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QuanLyThuVien
{
    class HeThongService
    {
        //Hàm lấy thông tin quy định
        public HeThong GetParam()
        {
            HeThongDAO cls = new HeThongDAO();
            HeThong clsHeThong = new HeThong();
            try
            {
                object[] obj = cls.GetParam();
                clsHeThong.SoTienDatCoc = Convert.ToInt32(obj[0]);
                clsHeThong.SoNgayMuonVe = Convert.ToByte(obj[1]);
                clsHeThong.SoTienPhatTreHanVe = Convert.ToInt32(obj[2]);
                clsHeThong.SoTienPhatTreHanTaiCho = Convert.ToInt32(obj[3]);
                clsHeThong.SoCuonMuonVe = Convert.ToByte(obj[4]);
                clsHeThong.SoCuonMuonTaiCho = Convert.ToByte(obj[5]);
                clsHeThong.SoCuonMuonGVBC = Convert.ToByte(obj[6]);
                clsHeThong.SoNgayThanhLyBao = Convert.ToByte(obj[7]);
                clsHeThong.SoNgayThanhLyTapchi = Convert.ToByte(obj[8]);
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return clsHeThong;
        }
        //Hàm thay đổi quy định
        public bool ChangeParam(HeThong clsSystem)
        {
            bool blKey = false;
            HeThongDAO cls = new HeThongDAO();
            try
            {
                if (cls.ChangeParam(clsSystem))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
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
