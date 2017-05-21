using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class SachYeuCauDAO
    {
        //Kiểm tra trùng tên sách và tác giả
        public bool IsExist(SachYeuCau cls)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblSachYeuCau where TenSach=@TenSach and TenTacGia=@TacGia";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenSach", cls.TenSach);
            cmd.Parameters.AddWithValue("@TacGia", cls.TacGia);
            Database clsData = new Database();
            DataTable dt = clsData.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (clsData.Error != "")
                strError = clsData.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Sách và tác giả này đã được yêu cầu";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Thêm
        public bool Add(SachYeuCau cls)
        {
            bool blKey = false;            
            string strSQL = "insert into tblSachYeuCau values(";
            strSQL += "@MSSV,@NgayYC,@TenSach,@TacGia,@NXB,@GiaBia,@ThongTinThem)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MSSV", cls.MSSV);
            cmd.Parameters.AddWithValue("@NgayYC", cls.NgayYC);
            cmd.Parameters.AddWithValue("@TenSach", cls.TenSach);
            cmd.Parameters.AddWithValue("@TacGia", cls.TacGia);
            cmd.Parameters.AddWithValue("@NXB", cls.NXB);
            cmd.Parameters.AddWithValue("@GiaBia", cls.GiaBia);
            cmd.Parameters.AddWithValue("@ThongTinThem", cls.ThongTinThem);
            Database clsData = new Database();
            if (clsData.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (clsData.Error != "")
                    strError = clsData.Error;
                else
                    strError = "Thêm yêu cầu thất bại";
            return blKey;
        }
        //Xóa tất cả
        public bool DeleteAll()
        {
            bool blKey = false;
            string strSQL = "delete from tblSachYeuCau";            
            Database clsData = new Database();
            if (clsData.Update(strSQL))
                blKey = true;
            else
                if (clsData.Error != "")
                    strError = clsData.Error;
                else
                    strError = "Xóa tất cả sách yêu cầu thất bại";
            return blKey;
        }
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        } 
    }
}
