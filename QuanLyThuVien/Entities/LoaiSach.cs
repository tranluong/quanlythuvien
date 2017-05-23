using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Entities
{
    class LoaiSach
    {
        private int intMaLoaiSach;
        private string strTenLoaiSach;

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

        public string TenLoaiSach
        {
            get
            {
                return strTenLoaiSach;
            }

            set
            {
                strTenLoaiSach = value;
            }
        }
    }
}
