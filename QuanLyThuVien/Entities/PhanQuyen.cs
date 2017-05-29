using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Entities
{
    class PhanQuyen
    {
        private int intMaPQ;

        public int MaPQ
        {
            get
            {
                return intMaPQ;
            }

            set
            {
                intMaPQ = value;
            }
        }
        public byte[] PhanQuyen1 = new byte[10];
    }
}
