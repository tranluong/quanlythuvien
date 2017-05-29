using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class SachYeuCau
    {
        private string strMSSV = "";
        public string MSSV
        {
            get { return strMSSV; }
            set { strMSSV = value; }
        }

        private DateTime dtNgayYC = DateTime.Today;
        public DateTime NgayYC
        {
            get { return dtNgayYC; }
            set { dtNgayYC = value; }
        }

        private string strTenSach = "";
        public string TenSach
        {
            get { return strTenSach; }
            set { strTenSach = value; }
        }

        private string strTacGia = "";
        public string TacGia
        {
            get { return strTacGia; }
            set { strTacGia = value; }
        }

        private string strNXB = "";
        public string NXB
        {
            get { return strNXB; }
            set { strNXB = value; }
        }

        private string strGiaBia = "";
        public string GiaBia
        {
            get { return strGiaBia; }
            set { strGiaBia = value; }
        }

        private string strThongTinThem = "";
        public string ThongTinThem
        {
            get { return strThongTinThem; }
            set { strThongTinThem = value; }
        }
    }
}
