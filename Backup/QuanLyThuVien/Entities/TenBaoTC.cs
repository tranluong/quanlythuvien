using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class TenBaoTC
    {
        private int intMaTenBTC;
        private string strTenBTC;
        private byte bytBaoOrTapChi = 0;

        public int MaTenBTC
        {
            get { return intMaTenBTC; }
            set { intMaTenBTC = value; }
        }

        public string TenBTC
        {
            get { return strTenBTC; }
            set { strTenBTC = value; }
        }

        public byte BaoOrTapChi
        {
            get { return bytBaoOrTapChi; }
            set { bytBaoOrTapChi = value; }
        }
    }
}
