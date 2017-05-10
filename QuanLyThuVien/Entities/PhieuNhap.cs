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
        private float TongTriGia;
        private int MaSach;
        private int SoLuong;
        private float DonGia;
        private float ThanhTien;

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

        public float pTongTriGia
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

        public float pDonGia
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
        public float pThanhTien
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
