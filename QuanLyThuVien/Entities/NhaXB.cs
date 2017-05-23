using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class NhaXB
    {
        private int intMaNXB;
        private string strTenNXB;
        private string strDiaChi;

        public int MaNXB
        {
            get { return intMaNXB; }
            set { intMaNXB = value; }
        }

        public string TenNXB
        {
            get { return strTenNXB; }
            set { strTenNXB = value; }
        }

        public string DiaChiNXB
        {
            get
            {
                return strDiaChi;
            }

            set
            {
                strDiaChi = value;
            }
        }
    }
}
