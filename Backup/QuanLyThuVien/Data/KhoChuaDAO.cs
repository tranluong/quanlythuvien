using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class KhoChuaDAO
    {
        //Kiểm tra trùng tên kho chứa        
        public bool IsExistName(string strTenKho)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblKhoChua where TenKho=@TenKho";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenKho", strTenKho);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Kho này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }

        //Kiểm tra trùng tên kho chứa khi cập nhật
        public bool IsExistName(KhoChua clsKho)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblKhoChua where TenKho=@TenKho and MaKho!=@MaKho";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenKho", clsKho.TenKho);
            cmd.Parameters.AddWithValue("MaKho", clsKho.MaKho);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Kho chứa này đã tồn tại";

                else
                    blIsExist = false;
            return blIsExist;
        }

        //Thêm kho
        public bool CreateKho(KhoChua clsKho)
        {
            bool blKey = false;
            string strSQL = "insert into tblKhoChua(TenKho) values(@TenKho)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenKho", clsKho.TenKho);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm kho thất bại";
            return blKey;
        }
        //Kiểm tra kho có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(int intMaKho)
        {
            bool blKey = true;
            string strSQL = "select * from tblKhoChua n, tblTuaSach t where n.MaKho=t.MaKho and n.MaKho=" + intMaKho;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Kho này đang được sử dụng, không thể xóa !";
                    //strError = MessageLanguage.ForeignKey;
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Xóa kho
        public bool DeleteKho(KhoChua clsKho)
        {
            bool blKey = false;
            string strsQL = "delete from tblKhoChua where MaKho=" + clsKho.MaKho;
            Database cls = new Database();
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa kho thất bại";
            return blKey;
        }
        //Cập nhật kho
        public bool UpdateKho(KhoChua clsKho)
        {
            bool blKey = false;
            string strsQL = "update tblKhoChua set TenKho=@TenKho where MaKho=@MaKho";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenKho", clsKho.TenKho);
            cmd.Parameters.AddWithValue("@MaKho", clsKho.MaKho);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật kho thất bại";
            return blKey;
        }
        //Tìm kho
        public DataTable SearchKho(string strTenKho, int intType)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            if (intType == 0)
                strSQL = "select MaKho as 'Mã kho', TenKho as 'Tên kho' from tblKhoChua where TenKho like '%'+@Keyword+'%'";
            else
                strSQL = "select MaKho as 'Mã kho', TenKho as 'Tên kho' from tblKhoChua where TenKho like @Keyword";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strTenKho);
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
        //Hiển thị tất cả kho
        public DataTable ShowAllKho()
        {
            string strSQL = "select MaKho as 'Mã Kho Chứa', TenKho as 'Tên Kho Chứa' from tblKhoChua order by MaKho Desc";
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
