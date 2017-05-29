using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien.Business
{
    class BusinessError
    {
        private string strError = "";
        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
    }
}
