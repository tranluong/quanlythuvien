using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class NganhHoc
    {
        private int intMaNganh;
        private string strTenNganh;

        public int MaNganh
        {
            get { return intMaNganh; }
            set { intMaNganh = value; }
        }

        public string TenNganh
        {
            get { return strTenNganh; }
            set { strTenNganh = value; }
        }
    }
}
