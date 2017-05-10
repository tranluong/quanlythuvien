using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class KhoChua
    {
        private int intMaKho;
        private string strTenKho = "";
        private byte bytSucChua;

        public int MaKho
        {
            get { return intMaKho; }
            set { intMaKho = value; }
        }

        public string TenKho
        {
            get { return strTenKho; }
            set { strTenKho = value; }
        }

        public byte SucChua
        {
            get { return bytSucChua; }
            set { bytSucChua = value; }
        }
    }
}
