using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Data
{
    class LoaiSachDao
    {
        public bool IsExistName(string strTenLoaiSach)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblLoaiSach where TenLoaiSach=@TenLoaiSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenLoaiSach", strTenLoaiSach);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                strError = "Loại sách này đã tồn tại";
            else
                blIsExist = false;
            return blIsExist;
        }

        //Kiểm tra trùng tên loại độc giả khi cập nhật
        public bool IsExistNameWhileUpdate(LoaiSach clsLoaiSach)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblLoaiSach where TenLoaiSach=@TenLoaiSach and MaLoaiSach!=@MaLoaiSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenLoaiSach", clsLoaiSach.TenLoaiSach);
            cmd.Parameters.AddWithValue("@MaLoaiSach", clsLoaiSach.MaLoaiSach);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                strError = "Loại sách này đã tồn tại";

            else
                blIsExist = false;
            return blIsExist;
        }

        public bool CreateLoaiDocGia(LoaiSach clsLoaiSach)
        {
            bool blKey = false;
            string strSQL = "insert into tblLoaiSach(TenLoaiSach) values(@TenLoaiSach)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenLoaiSach", clsLoaiSach.TenLoaiSach);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Thêm loại sách thất bại";
            return blKey;
        }

        public bool HasForeignKey(int intMaLoaiSach)
        {
            bool blKey = true;
            string strSQL = "select * from tblLoaiSach n, tblSach t where n.MaLoaiSach=t.MaLoaiSach and n.MaLoaiSach=" + intMaLoaiSach;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                    strError = "Mã loại sách này đang được sử dụng, không thể xóa !";

                else
                    blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Xóa nhà xuất bản
        public bool DeleteLoaiSach(LoaiSach clsLoaiSach)
        {
            bool blKey = false;
            string strsQL = "delete from tblLoaiSach where MaLoaiSach =" + clsLoaiSach.MaLoaiSach;
            Database cls = new Database();
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Xóa loại sách thất bại";
            return blKey;
        }
        //Cập nhật nhà xuất bản
        public bool UpdateLoaiSach(LoaiSach clsLoaiSach)
        {
            bool blKey = false;
            string strsQL = "update tblLoaiSach set TenLoaiSach=@TenLoaiSach where MaLoaiSach =@MaLoaiSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenLoaiSach", clsLoaiSach.TenLoaiSach);
            cmd.Parameters.AddWithValue("@MaLoaiSach", clsLoaiSach.MaLoaiSach);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Cập nhật loại sách thất bại";
            return blKey;
        }
        //Tìm nhà xuất bản
        public DataTable SearchLoaiSach(string strTenLoaiSach, int intType)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            if (intType == 0)
                strSQL = "select MaLoaiSach as 'Mã loại sách', TenLoaiSach as 'Tên loại sách'  from tblLoaiSach where TenLoaiSach like '%'+@Keyword+'%'";
            else
                strSQL = "select MaLoaiSach as 'Mã loại sách', TenLoaiSach as 'Tên loại sách'  from tblLoaiSach where TenLoaiSach like @Keyword";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strTenLoaiSach);
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
        //Hiển thị tất cả nhà xuất bản
        public DataTable ShowAllLoaiSach()
        {
            string strSQL = "select MaLoaiSach as 'Mã Loại Sách', TenLoaiSach as 'Tên Loại Sách' from tblLoaiSach order by MaLoaiSach Desc";
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
