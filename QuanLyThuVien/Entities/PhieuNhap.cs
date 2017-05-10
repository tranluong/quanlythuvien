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

        public int MaPhieuNhap
        {
            get { return MaPhieuNhap; }
            set { MaPhieuNhap = value; }
        }

        public DateTime NgayNhap
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

        public float TongTriGia
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
        public int MaSach
        {
            get { return MaSach; }
            set { MaSach = value; }
        }
        public int SoLuong
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }

        public float DonGia
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
        public float ThanhTien
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
