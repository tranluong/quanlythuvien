using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class SoBaoTC
    {
        private int intMaTenBTC;
        private string intSoPH;
        private DateTime datNgayPH;
        private int intSoLuongNhap;
        private DateTime datNgayCapNhat;
        private int intNguoiCapNhat;

        public int MaTenBTC
        {
            get { return intMaTenBTC; }
            set { intMaTenBTC = value; }
        }

        public string SoPH
        {
            get { return intSoPH; }
            set { intSoPH = value; }
        }
        public DateTime NgayPH
        {
            get { return datNgayPH; }
            set { datNgayPH = value; }
        }

        public int SoLuongNhap
        {
            get { return intSoLuongNhap; }
            set { intSoLuongNhap = value; }
        }

        public DateTime NgayCapNhat
        {
            get { return datNgayCapNhat; }
            set { datNgayCapNhat = value; }
        }

        public int NguoiCapNhat
        {
            get { return intNguoiCapNhat; }
            set { intNguoiCapNhat = value; }
        }

        byte bytLoai = 0;
        public byte Loai
        {
            get { return bytLoai; }
            set { bytLoai = value; }
        }
    }
}
