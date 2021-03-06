using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class SoBaoTCDAO
    {
        //Kiểm tra trùng số phát hành khi thêm
        public bool IsExistNameSoPH(string strSoPH,int intMaTenBTC)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblSoBaoTC where SoPH=@SoPH and MaTenBTC=@MaTenBTC";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoPH", strSoPH);
            cmd.Parameters.AddWithValue("@MaTenBTC", intMaTenBTC);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Số phát hành này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }        
        //Kiểm tra trùng ngày phát hành khi thêm
        public bool IsExistNameNgayPH(SoBaoTC clsSBTC)
        {
            bool blIsExist = true;
            string strSQL = "set dateformat dmy; select * from tblSoBaoTC where NgayPH=@NgayPH and MaTenBTC=@MaTenBTC";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NgayPH", clsSBTC.NgayPH);            
            cmd.Parameters.AddWithValue("@MaTenBTC", clsSBTC.MaTenBTC);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Ngày phát hành này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        
        //Kiểm tra trùng số phát hành khi cập nhật
        public bool IsExistNameSoPH(SoBaoTC clsSBTC, int intMaTenBTC, string strSoPH)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblSoBaoTC";
            strSQL += "  where SoPH=@SoPH and MaTenBTC=@MaTenBTC and (SoPH!=@OldSoPH or MaTenBTC!=@OldMaTenBTC)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoPH", clsSBTC.SoPH);
            cmd.Parameters.AddWithValue("@MaTenBTC", clsSBTC.MaTenBTC);
            cmd.Parameters.AddWithValue("@OldSoPH", strSoPH);
            cmd.Parameters.AddWithValue("@OldMaTenBTC", intMaTenBTC);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Số phát hành này đã tồn tại";

                else
                    blIsExist = false;
            return blIsExist;
        }        
        //Kiểm tra trùng ngày phát hành khi cập nhật
        public bool IsExistNameNgayPH(SoBaoTC clsSBTC, DateTime dtOldNgayPH)
        {
            bool blIsExist = true;
            string strSQL = "set dateformat dmy; select * from tblSoBaoTC where NgayPH=@NgayPH and NgayPH!=@OldNgayPH and MaTenBTC=@MaTenBTC";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NgayPH", clsSBTC.NgayPH);
            cmd.Parameters.AddWithValue("@MaTenBTC", clsSBTC.MaTenBTC);
            cmd.Parameters.AddWithValue("@OldNgayPH", dtOldNgayPH);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Ngày phát hành này đã tồn tại";

                else
                    blIsExist = false;
            return blIsExist;
        }
        //Thêm số báo, tạp chí
        public bool CreateSBTC(SoBaoTC clsSBTC)
        {
            bool blKey = false;
            string strSQL = "insert into tblSoBaoTC(MaTenBTC,SoPH,NgayPH,SoLuongNhap,NgayCapNhat,NguoiCapNhat) values(@MaTenBTC,@SoPH,@NgayPH,@SoLuongNhap,@NgayCapNhat,@NguoiCapNhat)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTenBTC", clsSBTC.MaTenBTC);
            cmd.Parameters.AddWithValue("@SoPH", clsSBTC.SoPH);
            cmd.Parameters.AddWithValue("@NgayPH", clsSBTC.NgayPH);
            cmd.Parameters.AddWithValue("@SoLuongNhap", clsSBTC.SoLuongNhap);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsSBTC.NguoiCapNhat);
            cmd.Parameters.AddWithValue("@NgayCapNhat", DateTime.Today);
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm số báo, tạp chí thất bại";
            return blKey;
        }
        //Kiểm tra số báo, tạp chí có đang được sử dụng hay không (khóa ngoại) khi xóa
        public bool HasForeignKey(int intMaTenBTC, string strSoPH)
        {
            bool blKey = true;
            string strSQL = "select * ";
            strSQL += " from tblCT_PMBaoTC";
            strSQL += " where MaTenBTC=@MaTenBTC and SoPH=@SoPH";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTenBTC", intMaTenBTC);
            cmd.Parameters.AddWithValue("@SoPH", strSoPH);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Số báo, tạp chí này đang được sử dụng, không thể xóa !";

                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Xóa số báo, tạp chí
        public bool DeleteSBTC(SoBaoTC clsSBTC)
        {
            bool blKey = false;
            string strsQL = "delete from tblSoBaoTC";
            strsQL += " where MaTenBTC=@MaTenBTC and SoPH=@SoPH";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTenBTC", clsSBTC.MaTenBTC);
            cmd.Parameters.AddWithValue("@SoPH", clsSBTC.SoPH);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa số báo, tạp chí thất bại";
            return blKey;
        }
        //Cập nhật số báo, tạp chí
        public bool UpdateSBTC(SoBaoTC clsSBTC,int intMaTenBTC, string strSoPH)
        {
            bool blKey = false;
            string strsQL = "update tblSoBaoTC set ";
            strsQL += " MaTenBTC=@MaTenBTC";
            strsQL += ", SoPH=@SoPH";
            strsQL += ", NgayPH=@NgayPH";
            strsQL += ", SoLuongNhap=@SoLuongNhap";
            strsQL += ", NgayCapNhat=@NgayCapNhat";
            strsQL += ", NguoiCapNhat=@NguoiCapNhat";
            strsQL += " where MaTenBTC=@OldMaTenBTC and SoPH=@OldSoPH";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTenBTC", clsSBTC.MaTenBTC);
            cmd.Parameters.AddWithValue("@SoPH", clsSBTC.SoPH);
            cmd.Parameters.AddWithValue("@NgayPH", clsSBTC.NgayPH);
            cmd.Parameters.AddWithValue("@SoLuongNhap", clsSBTC.SoLuongNhap);
            cmd.Parameters.AddWithValue("@NgayCapNhat", clsSBTC.NgayCapNhat);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsSBTC.NguoiCapNhat);
            cmd.Parameters.AddWithValue("@OldMaTenBTC", intMaTenBTC);
            cmd.Parameters.AddWithValue("@OldSoPH", strSoPH);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật số báo, tạp chí thất bại";
            return blKey;
        }
        //Tìm số báo, tạp chí
        public DataTable SearchSBTC(int intType, string strKeyword, int intFilter)
        {
            DataTable dt = new DataTable();
            string strSQL = "set dateformat dmy; select TenBTC as 'Tên Báo TC', SoPH as 'Số phát hành', NgayPH as 'Ngày phát hành', SoLuongNhap as 'Số lượng nhập', BaoOrTapChi, TBTC.MaTenBTC";
            strSQL += " from tblSoBaoTC SBTC, tblTenBaoTC TBTC";
            if (intType == 0)//Tên báo TC
                if (intFilter == 0)//Gần đúng
                {                   
                    strSQL += " where SBTC.MaTenBTC=TBTC.MaTenBTC and TenBTC like '%'+@Keyword+'%'";
                }
                else//Chính xác
                {
                    strSQL += " where SBTC.MaTenBTC=TBTC.MaTenBTC and TenBTC like @Keyword";
                }
            if (intType == 1)//Số phát hành
                if (intFilter == 0)
                {                 
                    strSQL += " where SBTC.MaTenBTC=TBTC.MaTenBTC and SoPH like '%'+@Keyword+'%'";
                }
                else
                {
                    strSQL += " where SBTC.MaTenBTC=TBTC.MaTenBTC and SoPH like @Keyword";
                }
            if (intType == 2)//Ngày phát hành                
                strSQL += " where SBTC.MaTenBTC=TBTC.MaTenBTC and day(NgayPH) = day(@Keyword) and month(NgayPH)=month(@Keyword) and year(NgayPH)=year(@Keyword)";
            if (intType == 3)//Mã tên BTC
                strSQL += " where SBTC.MaTenBTC=TBTC.MaTenBTC and SBTC.MaTenBTC=@Keyword";
            strSQL += " order by SBTC.MaTenBTC Desc, SoPH DESC";
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
        //Hiển thị tất cả số báo, tạp chí
        public DataTable ShowAllSBTC()
        {
            string strSQL = "select TenBTC as 'Tên Báo TC', SoPH as 'Số phát hành', NgayPH as 'Ngày phát hành', SoLuongNhap as 'Số lượng nhập', BaoOrTapChi, TBTC.MaTenBTC";
            strSQL += " from tblSoBaoTC SBTC, tblTenBaoTC TBTC ";
            strSQL += " where SBTC.MaTenBTC=TBTC.MaTenBTC";
            strSQL += " order by SBTC.MaTenBTC Desc, SoPH DESC";                
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
