using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QuanLyThuVien
{
    class KiemTra
    {
        internal static bool Logged = false;
        internal static int userid = 0;
        internal static string user = "chưa đăng nhập";
        internal static int SoNgay(DateTime dt1, DateTime dt2)
        {
            int intSoNgay = 0;
            TimeSpan ts = dt1.Subtract(dt2);
            intSoNgay = ts.Days;
            return intSoNgay;
        }
    }
    class Input
    {
        internal static bool Number(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                return true;
            return false;
        }
        internal static string RemoveQuote(string strString)
        {            
            strString = Regex.Replace(strString, "'", "''").Trim();
            return strString;
        }        
    }    
    class Message
    {
        internal static string AddError = "Thêm thất bại !";
        internal static string DeleteError = "Xóa thất bại !";
        internal static string UpdateError = "Cập nhật thất bại !";
        internal static string ExceptionError = "Có lỗi xảy ra, xin liên hệ người bảo trì phần mềm này !";        
    }
    class MessageLanguage
    {
        internal static string ForeignKey = "Ngôn ngữ này đang được sử dụng, không thể xóa !";
        internal static string IsExist = "Ngôn ngữ này đã tồn tại, xin nhập ngôn ngữ khác !";
        internal static string IsEmpty = "Xin nhập tên ngôn ngữ !";
    }


}
