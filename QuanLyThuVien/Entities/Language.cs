using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class Language
    {
        private int intLangID;
        public int LangID
        {
            get { return intLangID; }
            set { intLangID = value; }
        }

        private string strLangName;
        public string LangName
        {
            get { return strLangName; }
            set { strLangName = value; }
        }
    }
}
