using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class TacGia
    {
        private int intMaTG;
        private string strTenTG;

        public int MaTG
        {
            get { return intMaTG; }
            set { intMaTG = value; }
        }

        public string TenTG
        {
            get { return strTenTG; }
            set { strTenTG = value; }
        }

        private int intMaTS;
        public int MaTS
        {
            get { return intMaTS; }
            set { intMaTS = value; }
        }

        private int intMaTap;
        public int MaTap
        {
            get { return intMaTap; }
            set { intMaTap = value; }
        }

        private byte bytChuBien = 0;
        public byte ChuBien
        {
            get { return bytChuBien; }
            set { bytChuBien = value; }
        }
    }
}
