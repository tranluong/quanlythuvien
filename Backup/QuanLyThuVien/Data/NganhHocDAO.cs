using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class NganhHocDAO
    {
        //Kiểm tra trùng tên ngành khi thêm
        public bool IsExistName(string strTenNganh)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblNganhHoc where TenNganh=@TenNganh";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNganh", strTenNganh);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Ngành này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }

        //Kiểm tra trùng tên ngành khi cập nhật
        public bool IsExistName(NganhHoc clsNganh)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblNganhHoc where TenNganh=@TenNganh and MaNganh!=@MaNganh";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNganh", clsNganh.TenNganh);
            cmd.Parameters.AddWithValue("MaNganh", clsNganh.MaNganh);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Ngành này đã tồn tại";

                else
                    blIsExist = false;
            return blIsExist;
        }

        //Thêm ngành
        public bool CreateNganh(NganhHoc clsNganh)
        {
            bool blKey = false;
            string strSQL = "insert into tblNganhHoc(TenNganh) values(@TenNganh)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNganh", clsNganh.TenNganh);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm ngành thất bại";
            return blKey;
        }
        //Kiểm tra ngành có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(int intMaNganh)
        {
            bool blKey = true;
            string strSQL = "select * from tblNganhHoc n, tblTuaSach t where n.MaNganh=t.MaNganh and n.MaNganh=" + intMaNganh;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Ngành này đang được sử dụng";
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Xóa ngành
        public bool DeleteNganh(NganhHoc clsNganh)
        {
            bool blKey = false;
            string strsQL = "delete from tblNganhHoc where MaNganh=" + clsNganh.MaNganh;
            Database cls = new Database();
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa ngành thất bại";
            return blKey;
        }
        //Cập nhật ngành
        public bool UpdateNganh(NganhHoc clsNganh)
        {
            bool blKey = false;
            string strsQL = "update tblNganhHoc set TenNganh=@TenNganh where MaNganh=@MaNganh";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNganh", clsNganh.TenNganh);
            cmd.Parameters.AddWithValue("@MaNganh", clsNganh.MaNganh);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật ngành thất bại";
            return blKey;
        }
        //Tìm ngành
        public DataTable SearchNganh(string strKeyword, int intType)
        {
            string strSQL = "";
            if (intType == 0)
                strSQL = "select MaNganh as 'Mã ngành', TenNganh as 'Tên ngành' from tblNganhHoc where TenNganh like '%'+@Keyword+'%'";
            else
                strSQL = "select MaNganh as 'Mã ngành', TenNganh as 'Tên ngành' from tblNganhHoc where TenNganh like @Keyword";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);
            Database cls = new Database();
            DataTable dt = new DataTable();
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
        //Hiển thị tất cả ngành
        public DataTable ShowAllNganh()
        {
            string strSQL = "select MaNganh as 'Mã Ngành Học', TenNganh as 'Tên Ngành Học' from tblNganhHoc order by MaNganh Desc";
            //string strSQL = "select * from tblNganhHoc";
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
