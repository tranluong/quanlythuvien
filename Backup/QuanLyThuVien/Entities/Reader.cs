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
        private string strKhoaHoc = "";
        public string KhoaHoc
        {
            get { return strKhoaHoc; }
            set { strKhoaHoc = value; }
        }
        private string strKhoa = "";
        public string Khoa
        {
            get { return strKhoa; }
            set { strKhoa = value; }
        }
        private string strNganh = "";
        public string Nganh
        {
            get { return strNganh; }
            set { strNganh = value; }
        }
        private string strLop = "";
        public string Lop
        {
            get { return strLop; }
            set { strLop = value; }
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
        private byte blDatCoc = 0;
        public byte DatCoc
        {
            get { return blDatCoc; }
            set { blDatCoc = value; }
        }
        private DateTime dtNgayDatCoc;
        public DateTime NgayDatCoc
        {
            get { return dtNgayDatCoc; }
            set { dtNgayDatCoc = value; }
        }
        private int intNguoiNhanDatCoc = 0;
        public int NguoiNhanDatCoc
        {
            get { return intNguoiNhanDatCoc; }
            set { intNguoiNhanDatCoc = value; }
        }
        private byte bytLoaiDG = 0;
        public byte LoaiDG
        {
            get { return bytLoaiDG; }
            set { bytLoaiDG = value; }
        }
        private int intNguoiCapNhat;
        public int NguoiCapNhat
        {
            get { return intNguoiCapNhat; }
            set { intNguoiCapNhat = value; }
        }
        private DateTime dtNgayCapNhat;
        public DateTime NgayCapNhat
        {
            get { return dtNgayCapNhat; }
            set { dtNgayCapNhat = value; }
        }
    }
}
