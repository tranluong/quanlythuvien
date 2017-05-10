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
    class LoaiDocGiaDao
    {
        //Kiểm tra trùng tên loại độc giả       
        public bool IsExistName(string strTenLoaiDG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblLoaiDocGia where TenLoaiDG=@TenLoaiDG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenLoaiDG", strTenLoaiDG);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                strError = "Loại độc giả này đã tồn tại";
            else
                blIsExist = false;
            return blIsExist;
        }

        //Kiểm tra trùng tên loại độc giả khi cập nhật
        public bool IsExistNameWhileUpdate(LoaiDocGia clsLDG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblLoaiDocGia where TenLoaiDG=@TenLoaiDG and MaLoaiDG!=@MaLoaiDG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenLoaiDG", clsLDG.TenLoaiDG);
            cmd.Parameters.AddWithValue("@MaLoaiDG", clsLDG.MaLoaiDG);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                strError = "Loại độc giả này đã tồn tại";

            else
                blIsExist = false;
            return blIsExist;
        }

        public bool CreateLoaiDocGia(LoaiDocGia clsLDG)
        {
            bool blKey = false;
            string strSQL = "insert into tblLoaiDocGia(TenLoaiDG) values(@TenLoaiDG)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenLoaiDG", clsLDG.TenLoaiDG);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Thêm loại độc giả thất bại";
            return blKey;
        }
       
        public bool HasForeignKey(int intMaLDG)
        {
            bool blKey = true;
            string strSQL = "select * from tblLoaiDocGia n, tblDocGia t where n.MaLoaiDG=t.MaLoaiDG and n.MaLoaiDG=" + intMaLDG;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                    strError = "Mã loại độc giả này đang được sử dụng, không thể xóa !";

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
        public bool DeleteLoaiDocGia(LoaiDocGia clsLDG)
        {
            bool blKey = false;
            string strsQL = "delete from tblLoaiDocGia where MaLoaiDG =" + clsLDG.MaLoaiDG;
            Database cls = new Database();
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Xóa loại độc giả thất bại";
            return blKey;
        }
        //Cập nhật nhà xuất bản
        public bool UpdateLoaiDocGia(LoaiDocGia clsLDG)
        {
            bool blKey = false;
            string strsQL = "update tblLoaiDocGia set TenLoaiDG=@TenLoaiDG where MaLoaiDG =@MaLoaiDG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenLoaiDG", clsLDG.TenLoaiDG);
            cmd.Parameters.AddWithValue("@MaLoaiDG", clsLDG.MaLoaiDG);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Cập nhật loại độc giả thất bại";
            return blKey;
        }
        //Tìm nhà xuất bản
        public DataTable SearchLoaiDocGia(string strTenLDG, int intType)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            if (intType == 0)
                strSQL = "select MaLoaiDG as 'Mã loại độc giả', TenLoaiDG as 'Tên loại độc giả'  from tblLoaiDocGia where TenLoaiDG like '%'+@Keyword+'%'";
            else
                strSQL = "select MaLoaiDG as 'Mã loại độc giả', TenLoaiDG as 'Tên loại độc giả'  from tblLoaiDocGia where TenLoaiDG like @Keyword";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strTenLDG);
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
        public DataTable ShowAllLoaiDocGia()
        {
            string strSQL = "select MaLoaiDG as 'Mã Loại Độc Giả', TenLoaiDG as 'Tên Loại Độc Giả' from tblLoaiDocGia order by MaLoaiDG Desc";
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
