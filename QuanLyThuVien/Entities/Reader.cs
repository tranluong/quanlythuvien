using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;

namespace QuanLyThuVien
{
    class Reader
    {
        private string strMaDocGia = "";
        public string MaDocGia
        {
            get { return strMaDocGia; }
            set { strMaDocGia = value; }
        }
        private string strTenDocGia = "";
        public string TenDocGia
        {
            get { return strTenDocGia; }
            set { strTenDocGia = value; }
        }
        private DateTime dtNgaySinh;
        public DateTime NgaySinh
        {
            get { return dtNgaySinh; }
            set { dtNgaySinh = value; }
        }
        private string strNoiSinh = "";
        public string NoiSinh
        {
            get { return strNoiSinh; }
            set { strNoiSinh = value; }
        }
        private byte blGioiTinh = 1;
        public byte GioiTinh
        {
            get { return blGioiTinh; }
            set { blGioiTinh = value; }
        }
        private string strDiaChi = "";
        public string DiaChi
        {
            get { return strDiaChi; }
            set { strDiaChi = value; }
        }
        private string strSoDT = "";
        public string SoDT
        {
            get { return strSoDT; }
            set { strSoDT = value; }
        }
        private int intTienDatCoc;
        public int TienDatCoc
        {
            get { return intTienDatCoc; }
            set { intTienDatCoc = value; }
        }
        private DateTime dtNgayDatCoc;
        public DateTime NgayDatCoc
        {
            get { return dtNgayDatCoc; }
            set { dtNgayDatCoc = value; }
        }
        private int intMaNhanVien = 0;
        public int MaNhanVien
        {
            get { return intMaNhanVien; }
            set { intMaNhanVien = value; }
        }
        private int intLoaiDG;
        public int LoaiDG
        {
            get { return intLoaiDG; }
            set { intLoaiDG = value; }
        }
        private DateTime dtThoiGianBatDau;
        public DateTime ThoiGianBatDau
        {
            get { return dtThoiGianBatDau; }
            set { dtThoiGianBatDau = value; }
        }
        private DateTime dtThoiGianKetThuc;
        public DateTime ThoiGianKetThuc
        {
            get { return dtThoiGianKetThuc; }
            set { dtThoiGianKetThuc = value; }
        }

        public int MaLoaiDG
        {
            get
            {
                return intMaLoaiDG;
            }

            set
            {
                intMaLoaiDG = value;
            }
        }

        private int intMaLoaiDG = 1 ;
    }
}
