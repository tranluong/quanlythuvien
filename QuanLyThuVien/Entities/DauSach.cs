using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Entities
{
    class DauSach
    {
        private int nMaDauSach;
        private int nTinhTrang;
        private string strGhiChu;
        private string strTenDauSach;
        private int strMaSach;

        public int MaDauSach
        {
            get { return nMaDauSach; }
            set { nMaDauSach = value; }
        }

        public int TinhTrang
        {
            get { return nTinhTrang; }
            set { nTinhTrang = value; }
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

        public int MaSach
        {
            get { return strMaSach; }
            set { strMaSach = value; }
        }

        public string TenDauSach
        {
            get
            {
                return strTenDauSach;
            }

            set
            {
                strTenDauSach = value;
            }
        }
    }
}
