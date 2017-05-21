using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Entities
{
    class PhieuNhap
    {
        private int MaPhieuNhap;
        private DateTime NgayNhap;
        private double TongTriGia;
        private int MaSach;
        private int SoLuong;
        private double DonGia;
        private double ThanhTien;

        public int pMaPhieuNhap
        {
            get { return MaPhieuNhap; }
            set { MaPhieuNhap = value; }
        }

        public DateTime pNgayNhap
        {
            get
            {
                return NgayNhap;
            }

            set
            {
                NgayNhap = value;
            }
        }

        public double pTongTriGia
        {
            get
            {
                return TongTriGia;
            }

            set
            {
                TongTriGia = value;
            }
        }
        public int pMaSach
        {
            get { return MaSach; }
            set { MaSach = value; }
        }
        public int pSoLuong
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }

        public double pDonGia
        {
            get
            {
                return DonGia;
            }

            set
            {
                DonGia = value;
            }
        }
        public double pThanhTien
        {
            get
            {
                return ThanhTien;
            }

            set
            {
                ThanhTien = value;
            }
        }

    }
}
