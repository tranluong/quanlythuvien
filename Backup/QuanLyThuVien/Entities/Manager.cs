using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class Manager
    {
        private int intID = 0;
        public int ID
        {
            get { return intID; }
            set { intID = value; }
        }

        private string strName;
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        private string strUsername;
        public string Username
        {
            get { return strUsername; }
            set { strUsername = value; }
        }

        private string strPassword;
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }
        
        public byte[] PhanQuyen= new byte[10];        
    }
}
