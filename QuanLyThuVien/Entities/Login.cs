using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class Login
    {
        private string strUsername = "";
        public string Username
        {
            get { return strUsername; }
            set { strUsername = value; }
        }

        private string strPassword = "";
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        private string strNewPassword = "";
        public string NewPassword
        {
            get { return strNewPassword; }
            set { strNewPassword = value; }
        }

        private int intUserID;
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }
    }
}
