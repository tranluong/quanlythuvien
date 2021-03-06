using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class TacGiaDAO
    {
        //Kiểm tra trùng tên tác giả khi thêm
        public bool IsExistName(string strTenTG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTacgia where TenTG=@TenTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenTG", strTenTG);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tác giả này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Kiểm tra trùng tên tác giả khi cập nhật
        public bool IsExistName(TacGia clsTG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTacgia where TenTG=@TenTG and MaTG!=@MaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenTG", clsTG.TenTG);
            cmd.Parameters.AddWithValue("MaTG", clsTG.MaTG);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tác giả này đã tồn tại";

                else
                    blIsExist = false;
            return blIsExist;
        }
        //Kiểm tra trùng tác giả khi thêm tác giả một sách
        public bool IsExistName(int intMaTS, int intMaTG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblSach_Tacgia where MaTS=@MaTS and MaTG=@MaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
            cmd.Parameters.AddWithValue("@MaTG", intMaTG);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tác giả này đã có, chọn tác giả khác";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Kiểm tra trùng tác giả khi thêm tác giả một tập
        public bool IsExistNameChapter(int intMaTap, int intMaTG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTap_Tacgia where MaTap=@MaTap and MaTG=@MaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
            cmd.Parameters.AddWithValue("@MaTG", intMaTG);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tác giả này đã có, chọn tác giả khác";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Kiểm tra trùng tác giả khi cập nhật tác giả một sách
        public bool IsExistName(TacGia clsTacGia,int intOldMaTG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblSach_Tacgia where MaTS=@MaTS and MaTG=@MaTG and MaTG!=@OldMaTG";
            //string strSQL = "select * from tblSach_Tacgia where MaTS=@MaTS and MaTG=@MaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", clsTacGia.MaTS);
            cmd.Parameters.AddWithValue("@MaTG", clsTacGia.MaTG);
            cmd.Parameters.AddWithValue("@OldMaTG", intOldMaTG);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tác giả này đã có, chọn tác giả khác";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Kiểm tra trùng tác giả khi cập nhật tác giả một tập
        public bool IsExistNameChapter(TacGia clsTacGia, int intOldMaTG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTap_Tacgia where MaTap=@MaTap and MaTG=@MaTG and MaTG!=@OldMaTG";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", clsTacGia.MaTap);
            cmd.Parameters.AddWithValue("@MaTG", clsTacGia.MaTG);
            cmd.Parameters.AddWithValue("@OldMaTG", intOldMaTG);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tác giả này đã có, chọn tác giả khác";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Thêm tác giả
        public bool CreateTG(TacGia clsTG)
        {
            bool blKey = false;
            string strSQL = "insert into tblTacgia(TenTG) values(@TenTG)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenTG", clsTG.TenTG);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm tác giả thất bại";
            return blKey;
        }
        //Kiểm tra tác giả có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(int intMaTG)
        {
            bool blKey = true;
            string strSQL = "select *";
            strSQL += " from tblTacgia";
            strSQL += " where MaTG in (select MaTG from tblSach_Tacgia where MaTG=@MaTG)";
            strSQL += " or MaTG in (select MaTG from tblTap_Tacgia where MaTG=@MaTG)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTG", intMaTG);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Tác giả này đang được sử dụng, không thể xóa !";

                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Xóa tác giả
        public bool DeleteTG(TacGia clsTG)
        {
            bool blKey = false;
            string strsQL = "delete from tblTacgia where MaTG=" + clsTG.MaTG;
            Database cls = new Database();
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa tác giả thất bại";
            return blKey;
        }
        //Cập nhật tác giả
        public bool UpdateTG(TacGia clsTG)
        {
            bool blKey = false;
            string strsQL = "update tblTacgia set TenTG=@TenTG where MaTG=@MaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenTG", clsTG.TenTG);
            cmd.Parameters.AddWithValue("@MaTG", clsTG.MaTG);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật tác giả thất bại";
            return blKey;
        }
        //Tìm tác giả
        public DataTable SearchTG(string strKeyword, int intType)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            if (intType == 0)
                strSQL = "select MaTG as 'Mã tác giả', TenTG as 'Tên tác giả' from tblTacgia where TenTG like '%'+@Keyword+'%'";
            else
                strSQL = "select MaTG as 'Mã tác giả', TenTG as 'Tên tác giả' from tblTacgia where TenTG like @Keyword";
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
        //Hiển thị tất cả tác giả
        public DataTable ShowAllTG()
        {
            string strSQL = "select MaTG as 'Mã Tác Giả', TenTG as 'Tên Tác Giả' from tblTacgia order by MaTG Desc";
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
        //Thêm tác giả của tập
        public bool CreateTGT(TacGia clsTG)
        {
            bool blKey = false;
            string strSQL = "insert into tblTap_Tacgia values(@MaTap,@MaTG,@ChuBien)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", clsTG.MaTap);
            cmd.Parameters.AddWithValue("@MaTG", clsTG.MaTG);
            cmd.Parameters.AddWithValue("@ChuBien", clsTG.ChuBien);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm tác giả cho tập thất bại";
            return blKey;
        }
        //Xóa tác giả của một tập
        public bool DeleteTGT(TacGia clsTG)
        {
            bool blKey = false;
            string strsQL = "delete from tblTap_Tacgia where MaTap=@MaTap and MaTG=@MaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", clsTG.MaTap);
            cmd.Parameters.AddWithValue("@MaTG", clsTG.MaTG);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error; 
                else
                    strError = "Xóa tác giả của tập thất bại";
            return blKey;
        }
        //Cập nhật tác giả của một tập
        public bool UpdateTGT(TacGia clsTG, int intOldMaTG)
        {
            bool blKey = false;
            string strsQL = "update tblTap_Tacgia set MaTG=@MaTG, ChuBien=@ChuBien where MaTap=@MaTap and MaTG=@OldMaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTG", clsTG.MaTG);
            cmd.Parameters.AddWithValue("@ChuBien", clsTG.ChuBien);
            cmd.Parameters.AddWithValue("@MaTap", clsTG.MaTap);
            cmd.Parameters.AddWithValue("@OldMaTG", intOldMaTG);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật tác giả của tập thất bại";
            return blKey;
        }
        //Thêm tác giả của sách
        public bool CreateTGS(TacGia clsTG)
        {
            bool blKey = false;
            string strSQL = "insert into tblSach_Tacgia values(@MaTS,@MaTG,@ChuBien)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", clsTG.MaTS);
            cmd.Parameters.AddWithValue("@MaTG", clsTG.MaTG);
            cmd.Parameters.AddWithValue("@ChuBien", clsTG.ChuBien);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm tác giả cho sách thất bại";
            return blKey;
        }
        //Xóa tác giả của một sách
        public bool DeleteTGS(TacGia clsTG)
        {
            bool blKey = false;
            string strsQL = "delete from tblSach_Tacgia where MaTS=@MaTS and MaTG=@MaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", clsTG.MaTS);
            cmd.Parameters.AddWithValue("@MaTG", clsTG.MaTG);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa tác giả của sách thất bại";
            return blKey;
        }
        //Cập nhật tác giả của một sách
        public bool UpdateTGS(TacGia clsTG, int intOldMaTG)
        {
            bool blKey = false;
            string strsQL = "update tblSach_Tacgia set MaTG=@MaTG, ChuBien=@ChuBien where MaTS=@MaTS and MaTG=@OldMaTG";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTG", clsTG.MaTG);
            cmd.Parameters.AddWithValue("@ChuBien", clsTG.ChuBien);
            cmd.Parameters.AddWithValue("@MaTS", clsTG.MaTS);
            cmd.Parameters.AddWithValue("@OldMaTG", intOldMaTG);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật tác giả của sách thất bại";
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
