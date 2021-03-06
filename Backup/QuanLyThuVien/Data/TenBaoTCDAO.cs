using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class TenBaoTCDAO
    {
        //Kiểm tra trùng tên báo, tạp chí khi thêm
        public bool IsExistName(string strTenBTC)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTenBaoTC where TenBTC=@TenBTC";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenBTC", strTenBTC);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Báo, tạp chí này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Kiểm tra trùng tên báo, tạp chí khi cập nhật
        public bool IsExistName(TenBaoTC clsTenBTC)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTenBaoTC where TenBTC=@TenBTC and MaTenBTC!=@MaTenBTC";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenBTC", clsTenBTC.TenBTC);
            cmd.Parameters.AddWithValue("MaTenBTC", clsTenBTC.MaTenBTC);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Báo, tạp chí này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Thêm báo, tạp chí
        public bool CreateBTC(TenBaoTC clsBTC)
        {
            bool blKey = false;
            string strSQL = "insert into tblTenBaoTC(TenBTC,BaoOrTapChi) values(@TenBTC,@BaoOrTapChi)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenBTC", clsBTC.TenBTC);
            cmd.Parameters.AddWithValue("@BaoOrTapChi", clsBTC.BaoOrTapChi);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm báo, tạp chí thất bại";
            return blKey;
        }
        //Kiểm tra báo, tạp chí có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(int intMaTenBTC)
        {
            bool blKey = true;
            string strSQL = "select * from tblTenBaoTC n, tblSoBaoTC t where n.MaTenBTC=t.MaTenBTC and n.MaTenBTC=" + intMaTenBTC;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Báo, tạp chí này đang được sử dụng, không thể xóa !";
                    
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Xóa báo, tạp chí
        public bool DeleteBTC(TenBaoTC clsBTC)
        {
            bool blKey = false;
            string strsQL = "delete from tblTenBaoTC where MaTenBTC=" + clsBTC.MaTenBTC;
            Database cls = new Database();
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa báo, tạp chí thất bại";
            return blKey;
        }
        //Cập nhật báo, tạp chí
        public bool UpdateBTC(TenBaoTC clsBTC)
        {
            bool blKey = false;
            string strsQL = "update tblTenBaoTC set TenBTC=@TenBTC,BaoOrTapChi=@BaoOrTapChi where MaTenBTC=@MaTenBTC";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenBTC", clsBTC.TenBTC);
            cmd.Parameters.AddWithValue("@MaTenBTC", clsBTC.MaTenBTC);
            cmd.Parameters.AddWithValue("@BaoOrTapChi", clsBTC.BaoOrTapChi);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật báo, tạp chí thất bại";
            return blKey;
        }
        //Tìm báo, tạp chí
        public DataTable SearchBTC(string strKeyword, int intType)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            if (intType == 0)
                strSQL = "select MaTenBTC as 'Mã tên Báo TC', TenBTC as 'Tên Báo TC',CASE BaoOrTapChi when 0 then N'Báo' else N'Tạp chí' end as 'Loại' from tblTenBaoTC where TenBTC like '%'+@Keyword+'%'";
            else
                strSQL = "select MaTenBTC as 'Mã tên Báo TC', TenBTC as 'Tên Báo TC',CASE BaoOrTapChi when 0 then N'Báo' else N'Tạp chí' end as 'Loại' from tblTenBaoTC where TenBTC like @Keyword";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        //Hiển thị tất cả báo, tạp chí
        public DataTable ShowAllBTC()
        {
            string strSQL = "select MaTenBTC as 'Mã tên Báo TC', TenBTC as 'Tên Báo TC',CASE BaoOrTapChi when 0 then N'Báo' else N'Tạp chí' end as 'Loại' from tblTenBaoTC order by MaTenBTC Desc";
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
