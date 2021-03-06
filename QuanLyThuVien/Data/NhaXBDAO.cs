using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class NhaXBDAO
    {
        //Kiểm tra trùng tên nhà xuất bản        
        public bool IsExistName(string strTenNXB)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblNXB where TenNXB=@TenNXB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNXB", strTenNXB);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Nhà xuất bản này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }

        //Kiểm tra trùng tên nhà xuất bản khi cập nhật
        public bool IsExistName(NhaXB clsNXB)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblNXB where TenNXB=@TenNXB and MaNXB!=@MaNXB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNXB", clsNXB.TenNXB);
            cmd.Parameters.AddWithValue("MaNXB", clsNXB.MaNXB);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Nhà xuất bản này đã tồn tại";

                else
                    blIsExist = false;
            return blIsExist;
        }

        //Thêm nhà xuất bản
        public bool CreateNhaXB(NhaXB clsNXB)
        {
            bool blKey = false;
            string strSQL = "insert into tblNXB(TenNXB,DiaChiNXB) values(@TenNXB,@DiaChiNXB)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenNXB", clsNXB.TenNXB);
            cmd.Parameters.AddWithValue("@DiaChiNXB", clsNXB.DiaChiNXB);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm nhà xuất bản thất bại";
            return blKey;
        }
        //Kiểm tra nhà xuất bản có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(int intMaNXB)
        {
            bool blKey = true;
            string strSQL = "select * from tblNXB n, tblTuaSach t where n.MaNXB=t.MaNXB and n.MaNXB=" + intMaNXB;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Nhà xuất bản này đang được sử dụng, không thể xóa !";
                    
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
        public bool DeleteNhaXB(NhaXB clsNXB)
        {
            bool blKey = false;
            string strsQL = "delete from tblNXB where MaNXB=" + clsNXB.MaNXB;
            Database cls = new Database();
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa nhà xuất bản thất bại";
            return blKey;
        }
        //Cập nhật nhà xuất bản
        public bool UpdateNhaXB(NhaXB clsNXB)
        {
            bool blKey = false;
            string strsQL = "update tblNXB set TenNXB=@TenNXB and DiaChiNXB=@DiaChiNXB where MaNXB =@MaNXB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DiaChiNXB", clsNXB.DiaChiNXB);
            cmd.Parameters.AddWithValue("@TenNXB", clsNXB.TenNXB);
            cmd.Parameters.AddWithValue("@MaNXB", clsNXB.MaNXB);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật nhà xuất bản thất bại";
            return blKey;
        }
        //Tìm nhà xuất bản
        public DataTable SearchNhaXB(string strTenNXB, int intType)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            if (intType == 0)
                strSQL = "select MaNXB as 'Mã nhà xuất bản', TenNXB as 'Tên nhà xuất bản' , DiaChiNXB as 'Địa chỉ' from tblNXB where TenNXB like '%'+@Keyword+'%'";
            else
                strSQL = "select MaNXB as 'Mã nhà xuất bản', TenNXB as 'Tên nhà xuất bản' , DiaChiNXB as 'Địa chỉ'  from tblNXB where TenNXB like @Keyword";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strTenNXB);
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
        public DataTable ShowAllNhaXB()
        {
            string strSQL = "select MaNXB as 'Mã Nhà XB', TenNXB as 'Tên Nhà XB', DiaChiNXB as 'Địa Chỉ' from tblNXB order by MaNXB Desc";
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
