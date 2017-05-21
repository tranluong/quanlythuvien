using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QuanLyThuVien
{
    class Book
    {
        private int intMaSach;
        private string strTenSach;
        private string strTacGia;
        private int intSoLuong;
        private float floatDonGia;
        private string strNoiDungTomTat;
        private int strNgonNgu;
        private int intMaLoaiSach;
        private int intMaNXB;
        private byte bytTinhTrang = 0;
        private string strGhiChu = "";
        private int intTongDauSach = 0;
        private int intSLMat = 0;
        private int intSLHong = 0;
        private int intSLMuon = 0;
        private int intSLCon = 0;
        private int intMaDauSach;
        public int MaSach
        {
            get
            {
                return intMaSach;
            }

            set
            {
                intMaSach = value;
            }
        }

        public string TenSach
        {
            get
            {
                return strTenSach;
            }

            set
            {
                strTenSach = value;
            }
        }

        public string TacGia
        {
            get { return strTacGia; }
            set { strTacGia = value; }
        }

        public int SoLuong
        {
            get
            {
                return intSoLuong;
            }

            set
            {
                intSoLuong = value;
            }
        }

        public float DonGia
        {
            get
            {
                return floatDonGia;
            }

            set
            {
                floatDonGia = value;
            }
        }

        public string NoiDungTomTat
        {
            get
            {
                return strNoiDungTomTat;
            }

            set
            {
                strNoiDungTomTat = value;
            }
        }

        public int NgonNgu
        {
            get
            {
                return strNgonNgu;
            }

            set
            {
                strNgonNgu = value;
            }
        }

        public int MaLoaiSach
        {
            get
            {
                return intMaLoaiSach;
            }

            set
            {
                intMaLoaiSach = value;
            }
        }

        public int MaNXB
        {
            get
            {
                return intMaNXB;
            }

            set
            {
                intMaNXB = value;
            }
        }

     
        
        //public int Rows
        //{
        //    get { return intRows; }
        //    set { intRows = value; }
        //}

        public byte TinhTrang
        {
            get
            {
                return bytTinhTrang;
            }

            set
            {
                bytTinhTrang = value;
            }
        }

        public string GhiChu
        {
            get
            {
                return strGhiChu;
            }

            set
            {
                strGhiChu = value;
            }
        }

        public int TongDauSach
        {
            get
            {
                return intTongDauSach;
            }

            set
            {
                intTongDauSach = value;
            }
        }

        public int SLHong
        {
            get
            {
                return intSLHong;
            }

            set
            {
                intSLHong = value;
            }
        }

        public int SLMuon
        {
            get
            {
                return intSLMuon;
            }

            set
            {
                intSLMuon = value;
            }
        }

        public int SLCon
        {
            get
            {
                return intSLCon;
            }

            set
            {
                intSLCon = value;
            }
        }

        public int SLMat
        {
            get
            {
                return intSLMat;
            }

            set
            {
                intSLMat = value;
            }
        }

        public int MaDauSach
        {
            get
            {
                return intMaDauSach;
            }

            set
            {
                intMaDauSach = value;
            }
        }

        public int SoLuongSau
        {
            get
            {
                return intSoLuongSau;
            }

            set
            {
                intSoLuongSau = value;
            }
        }

        private int intSoLuongSau;
    }
}
