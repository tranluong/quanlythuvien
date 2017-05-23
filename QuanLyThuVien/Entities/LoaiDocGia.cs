using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Entities
{
    class LoaiDocGia
    {
        private int intMaLoaiDocGia;
        private string strTenLoaiDocGia;

        public int MaLoaiDG
        {
            get
            {
                return intMaLoaiDocGia;
            }

            set
            {
                intMaLoaiDocGia = value;
            }
        }

        public string TenLoaiDG
        {
            get
            {
                return strTenLoaiDocGia;
            }

            set
            {
                strTenLoaiDocGia = value;
            }
        }
    }
}
