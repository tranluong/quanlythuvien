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
        private DateTime dateNgaySinh;
        public DateTime NgaySinh
        {
            get
            {
                return dateNgaySinh;
            }

            set
            {
                dateNgaySinh = value;
            }
        }
        private byte byteGioiTinh;
        public byte GioiTinh
        {
            get
            {
                return byteGioiTinh;
            }

            set
            {
                byteGioiTinh = value;
            }
        }
        private string strSoDT;
        public string SoDT
        {
            get
            {
                return strSoDT;
            }

            set
            {
                strSoDT = value;
            }
        }
        private string strEmail;
        public string Email
        {
            get
            {
                return strEmail;
            }

            set
            {
                strEmail = value;
            }
        }

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

        public int MaNV
        {
            get
            {
                return intManv;
            }

            set
            {
                intManv = value;
            }
        }

        

        public byte[] PhanQuyen = new byte[10];
        private int intMaPQ;
        //public byte[] PhanQuyen
        //{
        //    get
        //    {
        //        return phanQuyen;
        //    }

        //    set
        //    {
        //        phanQuyen = value;
        //    }
        //}
        private int intManv;
        public class GetCodeHD
        {
            public static string TenMaNV = null;
        }


    }
}
