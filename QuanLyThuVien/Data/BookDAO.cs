using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class BookDAO
    {
        //Thêm sách mới
        //Hàm kiểm tra trùng mã khi thêm
        public bool IsExistBookID(Book clsBook)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblSach where MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", clsBook.MaSach);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Có Mã Sách bị trùng";
                else
                    blIsExist = false;
            return blIsExist;
        }
       
        //Hàm thêm sách mới // canxemlai
        public bool CreateBook(Book clsBook)
        {
            bool blKey = false;
            SqlCommand cmd = new SqlCommand();
            string strSQL = "insert into tblSach values(";
            strSQL += "@TenSach,@TacGia,@SoLuong,@DonGia,@NoiDungTomTat,@NgonNgu,@@IDENTITY,@@IDENTITY); declare @ID int; set @ID=@@IDENTITY";
            for (int i = clsBook.MaDauSach; i <= clsBook.SoLuong; i++)
            {
                strSQL += "; insert into tblDauSach values(@MaDauSach" + i.ToString() + ",@TinhTrang,'',@ID)";
                cmd.Parameters.AddWithValue("@MaDauSach" + i.ToString(), i);
            }             
            cmd.Parameters.AddWithValue("@TenSach", clsBook.TenSach);
            cmd.Parameters.AddWithValue("@TacGia", clsBook.TacGia);
            cmd.Parameters.AddWithValue("@SoLuong", clsBook.SoLuong);
            cmd.Parameters.AddWithValue("@DonGia", clsBook.DonGia);
            cmd.Parameters.AddWithValue("@NoiDungTomTat", clsBook.NoiDungTomTat);
            cmd.Parameters.AddWithValue("@NgonNgu", clsBook.NgonNgu);
            cmd.Parameters.AddWithValue("@MaLoaiSach", clsBook.MaLoaiSach);
            cmd.Parameters.AddWithValue("@MaNXB", clsBook.MaNXB);
            
            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@GhiChu", clsBook.GhiChu);
            
            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm sách thất bại";
            return blKey;
        }
        //public bool CreateBookBySL(Book clsBook)
        //{
        //    bool blKey = false;
        //    SqlCommand cmd = new SqlCommand();
        //    string strSQL = "insert into tblSach values(";
        //    strSQL += "@TenSach,@TacGia,@SoLuong,@DonGia,@NoiDungTomTat,@NgonNgu,@@IDENTITY,@@IDENTITY); declare @ID int; set @ID=@@IDENTITY";
        //    for (int i = clsBook.MaDauSach; i <= clsBook.SoLuong; i++)
        //    {
        //        strSQL += "; insert into tblDauSach values(@MaDauSach" + i.ToString() + ",@TinhTrang,'',@ID)";
        //        cmd.Parameters.AddWithValue("@MaDauSach" + i.ToString(), i);
        //    }
        //    cmd.Parameters.AddWithValue("@TenSach", clsBook.TenSach);
        //    cmd.Parameters.AddWithValue("@TacGia", clsBook.TacGia);
        //    cmd.Parameters.AddWithValue("@SoLuong", clsBook.SoLuong);
        //    cmd.Parameters.AddWithValue("@DonGia", clsBook.DonGia);
        //    cmd.Parameters.AddWithValue("@NoiDungTomTat", clsBook.NoiDungTomTat);
        //    cmd.Parameters.AddWithValue("@NgonNgu", clsBook.NgonNgu);
        //    cmd.Parameters.AddWithValue("@MaLoaiSach", clsBook.MaLoaiSach);
        //    cmd.Parameters.AddWithValue("@MaNXB", clsBook.MaNXB);

        //    cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
        //    cmd.Parameters.AddWithValue("@GhiChu", clsBook.GhiChu);

        //    Database cls = new Database();
        //    if (cls.Update(strSQL, CommandType.Text, cmd))
        //        blKey = true;
        //    else
        //        if (cls.Error != "")
        //        strError = cls.Error;
        //    else
        //        strError = "Thêm sách thất bại";
        //    return blKey;
        //}
        //Hàm kiểm tra tựa sách có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(int intMaDauSach)
        {
            bool blKey = true;
            string strSQL = "select * from tblDauSach where MaDauSach=@MaDauSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach",intMaDauSach);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL,CommandType.Text,cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Hiện có đầu sách này đang được sử dụng nên không thể xóa";
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Hàm xóa dàu sách
        public bool DeleteDBook(int intMaDSach)
        {
            bool blKey = false;
            string strsQL = "delete from tblDauSach where MaDauSach=@MaDauSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach", intMaDSach);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Xóa đầu sách thất bại";
            return blKey;
        }

        //Hàm xóa sách
        public bool DeleteBook(int intMaSach)
        {
            bool blKey = false;
            string strsQL = "delete from tblSach where MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strsQL, CommandType.Text, cmd).Tables[0];
                if (cls.Update(strsQL, CommandType.Text, cmd))
                    blKey = true;
                else
                    if (cls.Error != "")
                    strError = cls.Error;
                else
                     if (dt.Rows.Count != 0)
                    strError = "Hiện có đầu sách này đang được sử dụng nên không thể xóa";
                else
                    strError = "Xóa sách thất bại";
                return blKey;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
      
        //Cập nhật sách
        public bool UpdateBook(Book clsBook)
        {
            bool blKey = false;
            string strSQL = "update tblSach set ";
            strSQL += "TenSach = @TenSach";
            strSQL += ",TacGia = @TacGia";
            strSQL += ",SoLuong = @SoLuong";
            strSQL += ",DonGia = @DonGia";
            strSQL += ",NoiDungTomTat = @NoiDungTomTat";
            strSQL += ",NgonNgu = @NgonNgu";
            strSQL += ",MaLoaiSach = @MaLoaiSach";
            strSQL += ",MaNXB = @MaNXB";
            strSQL += " where MaSach = @MaSach";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenSach", clsBook.TenSach);
            cmd.Parameters.AddWithValue("@TacGia", clsBook.TacGia);
            cmd.Parameters.AddWithValue("@SoLuong", clsBook.SoLuong);
            cmd.Parameters.AddWithValue("@DonGia", clsBook.DonGia);
            cmd.Parameters.AddWithValue("@NoiDungTomTat", clsBook.NoiDungTomTat);
            cmd.Parameters.AddWithValue("@NgonNgu", clsBook.NgonNgu);
            cmd.Parameters.AddWithValue("@MaLoaiSach", clsBook.MaLoaiSach);
            cmd.Parameters.AddWithValue("@MaNXB", clsBook.MaNXB);
            cmd.Parameters.AddWithValue("@MaSach", clsBook.MaSach);

            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
            {
                blKey = true;
            }
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật sách thất bại";
            return blKey;
        }
        //Cập nhật tựa sách tập
      
        //Tìm tựa sách
        public DataTable SearchBook(int intType, string strKeyword, int intFilter)
        {      
            string strSQL = "";
            switch (intType)
            {
                case 0://Tựa sách
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblSach WHERE TenSach like '%'+@Keyword+'%' and MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach WHERE TenSach like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblSach WHERE TenSach like @Keyword and MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach WHERE TenSach like @Keyword";
                    break;
                case 1://Số MFN
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblSach WHERE MaSach like '%'+@Keyword+'%' and MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach WHERE MaSach like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblSach WHERE MaSach like @Keyword and MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach WHERE MaSach like @Keyword";
                    break;
                case 2://Tác giả
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblSach WHERE TacGia like '%'+@Keyword+'%' and tblSach.MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach TS, tblSach_Tacgia STG, tblTacgia TG WHERE TS.MaSach=STG.MaSach and STG.MaTG=TG.MaTG and TenTG like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblSach  WHERE TacGia like @Keyword and tblSach.MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach TS, tblSach_Tacgia STG, tblTacgia TG WHERE TS.MaSach=STG.MaSach and STG.MaTG=TG.MaTG and TenTG like @Keyword";
                    break;
                case 3://Nhà XB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like '%'+@Keyword+'%' and MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like @Keyword and MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like @Keyword";
                    break;
                case 4://Loại sách
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblSach S, tblLoaiSach LS WHERE S.MaLoaiSach=LS.MaLoaiSach and TenLoaiSach like '%'+@Keyword+'%' and MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach WHERE NamXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblSach S, tblLoaiSach LS WHERE S.MaLoaiSach=LS.MaLoaiSach and TenLoaiSach like @Keyword and MaSach not in (Select MaSach from tblDauSach)";
                        //strSQL = "SELECT * FROM tblSach WHERE NamXB like @Keyword";
                    break;                            
            }            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);
            DataTable dt = new DataTable();
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
        //Hiển thị tất cả sách
        public DataTable ShowAllDBook(int intMaSach)
        {
            string strSQL = "select * from tblDauSach where MaSach = '" + intMaSach + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
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
        //Hiển thị tác giả của sách
        public DataTable ShowAuthor(int intMaSach)
        {
            string strSQL = "select MaSach, TenSach, TacGia from tblSach  where MaSach=@MaSach";
            //string strSQL = "select TenTG, ChuBien from tblSach_Tacgia STG, tblTacgia TG where STG.MaTG=TG.MaTG and MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
            DataTable dt = new DataTable();
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
        //Hàm xóa đầu sách
        public bool XoaDauSach(int intMaDauSach)
        {
            bool blKey = false;
            string strsQL = "delete from tblDauSach where MaDauSach=@MaDauSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach", intMaDauSach);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Xóa tựa sách tập thất bại";
            return blKey;
        }
        //Tìm tựa đầu sách
        public DataTable TimSach(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "";
            string strSQL2 = "";
            switch (intType)
            {
                case 0://Tựa sách
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblDauSach DS WHERE S.MaSach=DS.MaSach and TenSach like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblDauSach DS WHERE S.MaSach=DS.MaSach and TenSach like @Keyword";
                    break;
                case 1://Mã Sách
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblDauSach DS WHERE S.MaSach=DS.MaSach and S.MaSach like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblDauSach DS WHERE S.MaSach=DS.MaSach and S.MaSach like @Keyword";
                    break;
                case 2://Tác giả
                    if (intFilter == 0)//Gần đúng
                    {
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu";
                        strSQL += " FROM tblSach S, tblDauSach DS";
                        strSQL += " WHERE S.MaSach=DS.MaSach and TacGia like '%'+@Keyword+'%'";

                    }
                    else//Chính xác
                    {
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu";
                        strSQL += " FROM tblSach S, tblDauSach DS";
                        strSQL += " WHERE S.MaSach=DS.MaSach and TacGia like @Keyword";

                    }
                    break;
                case 3://Chủ đề
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblLoaiSach LS WHERE S.MaLoaiSach=LS.MaLoaiSach and TenLoaiSach like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblLoaiSach LS WHERE S.MaLoaiSach=LS.MaLoaiSach and TenLoaiSach like @Keyword";
                    break;
                case 4://Nhà XB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblNXB NXB, tblDauSach DS WHERE S.MaSach=DS.MaSach and S.MaNXB=NXB.MaNXB and TenNXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblNXB NXB, tblDauSach DS WHERE S.MaSach=DS.MaSach and S.MaNXB=NXB.MaNXB and TenNXB like @Keyword";
                    break;
                case 5://Số ĐKCB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblDauSach DS WHERE S.MaSach=DS.MaSach and MaSach like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblDauSach DS WHERE S.MaSach=DS.MaSach and MaSach like @Keyword";
                    break;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                if (intType == 2)
                {
                    dt2 = cls.GetData(strSQL2, CommandType.Text, cmd).Tables[0];
                    if (cls.Error != "")
                        strError = cls.Error;
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            if (intType == 2)
            {
                dt.Merge(dt2);
            }
            return dt;
        }
        public DataTable TimSachMT(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,TinhTrang FROM tblSach S, tblDauSach DS WHERE S.MaSach = DS.MaSach and S.MaSach like @Keyword " ;
            //string strSQL2 = "";
            //switch (intType)
            //{
            //    case 0://Tựa sách
            //        if (intFilter == 0)//Gần đúng
            //        {
            //            strSQL += " WHERE  TenSach like '%'+@Keyword+'%'";
            //        }
            //        else//Chính xác
            //        {
            //            strSQL += " WHERE  TenSach like @Keyword";
            //        }
            //        break;
            //    case 1://Mã Sách
            //        if (intFilter == 0)//Gần đúng
            //        {
            //            strSQL += " WHERE  MaSach like '%'+@Keyword+'%'";
            //        }
            //        else//Chính xác
            //        {
            //            strSQL += " WHERE  MaSach like @Keyword";
            //        }
            //        break;
            //    case 2://Tác giả
            //        if (intFilter == 0)//Gần đúng
            //        {
            //            strSQL += " WHERE TacGia like '%'+@Keyword+'%'";
            //        }
            //        else//Chính xác
            //        {
            //            strSQL += " WHERE TacGia like @Keyword";
            //        }
            //        break;
            //    case 3://Chủ đề
            //        if (intFilter == 0)//Gần đúng
            //            strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblLoaiSach LS WHERE S.MaLoaiSach=LS.MaLoaiSach and TenLoaiSach like '%'+@Keyword+'%'";
            //        else//Chính xác
            //            strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblLoaiSach LS WHERE S.MaLoaiSach=LS.MaLoaiSach and TenLoaiSach like @Keyword";
            //        break;
            //    case 4://Nhà XB
            //        if (intFilter == 0)//Gần đúng
            //            strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblNXB NXB, tblDauSach DS WHERE S.MaSach=DS.MaSach and S.MaNXB=NXB.MaNXB and TenNXB like '%'+@Keyword+'%'";
            //        else//Chính xác
            //            strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblNXB NXB, tblDauSach DS WHERE S.MaSach=DS.MaSach and S.MaNXB=NXB.MaNXB and TenNXB like @Keyword";
            //        break;
            //    case 5://Số ĐKCB
            //        if (intFilter == 0)//Gần đúng
            //            strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblDauSach DS WHERE S.MaSach=DS.MaSach and MaSach like '%'+@Keyword+'%'";
            //        else//Chính xác
            //            strSQL = "SELECT S.MaSach,TenSach,TacGia,SoLuong,DonGia,NoiDungTomTat,NgonNgu,MaLoaiSach,MaNXB,DS.TinhTrang,DS.GhiChu FROM tblSach S, tblDauSach DS WHERE S.MaSach=DS.MaSach and MaSach like @Keyword";
            //        break;
            //}
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                //if (intType == 2)
                //{
                //    dt2 = cls.GetData(strSQL2, CommandType.Text, cmd).Tables[0];
                //    if (cls.Error != "")
                //        strError = cls.Error;
                //}
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            if (intType == 2)
            {
                dt.Merge(dt2);
            }
            return dt;
        }

        //Hiển thị tác giả của đầu sách 
        public DataTable ShowAuthorDauSach(int intMaDauSach)
        {
            string strSQL = "select DS.MaDauSach , TenDauSach, TacGia";
            strSQL += " from tblSach S, tblDauSach DS where S.MaSach = DS.MaSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaDauSach);
            DataTable dt = new DataTable();
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
        //Hiển thị tác giả theo loại sách
        public DataTable ShowAuthorLoaiSach(int intMaLoaiSach)
        {
            string strSQL = "select S.MaSach , TenSach, TenLoaiSach , TacGia";
            strSQL += " from tblSach S, tblLoaiSach LS where S.MaLoaiSach = LS.MaLoaiSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaLoaiSach);
            DataTable dt = new DataTable();
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
        //Hàm thêm sách mới
        public bool AddBook(Book clsBook)
        {
            bool blKey = false;
            SqlCommand cmd = new SqlCommand();
            string strSQL = "insert into tblSach values(";
            strSQL += "@TenSach,@TacGia,@SoLuong,@DonGia,@NoiDungTomTat,@NgonNgu,@MaLoaiSach,@MaNXB); declare @ID int; set @ID=@@IDENTITY";
            for (int i = clsBook.MaDauSach; i <= clsBook.SoLuong; i++)
            {
                strSQL += "; insert into tblDauSach values(@MaDauSach" + i.ToString() + ",@TinhTrang,@GhiChu,@ID)";
                cmd.Parameters.AddWithValue("@MaDauSach" + i.ToString(), i);
            }
            cmd.Parameters.AddWithValue("@TenSach", clsBook.TenSach);
            cmd.Parameters.AddWithValue("@TacGia", clsBook.TacGia);
            cmd.Parameters.AddWithValue("@SoLuong", clsBook.SoLuong);
            cmd.Parameters.AddWithValue("@DonGia", clsBook.DonGia);
            cmd.Parameters.AddWithValue("@NoiDungTomTat", clsBook.NoiDungTomTat);
            cmd.Parameters.AddWithValue("@NgonNgu", clsBook.NgonNgu);
            cmd.Parameters.AddWithValue("@MaLoaiSach", clsBook.MaLoaiSach);
            cmd.Parameters.AddWithValue("@MaNXB", clsBook.MaNXB);

            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@GhiChu", clsBook.GhiChu);

            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm đầu sách thất bại";
            return blKey;
        }
        //Hàm cập nhật đầu sách
        public bool EditBook(Book clsBook)
        {
            bool blKey = false;
            string strSQL = "update tlbDauSach set TinhTrang=@TinhTrang, GhiChu=@GhiChu where MaDauSach=@MaDauSach";            
            SqlCommand cmd = new SqlCommand();            
            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@GhiChu", clsBook.GhiChu);
            cmd.Parameters.AddWithValue("@MaDauSach", clsBook.MaDauSach);           

            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Cập nhật đầu sách thất bại";
            return blKey;
        }
        //Xóa đầu sách

        //Hàm kiểm tra đầu sách có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(Book clsBook)
        {
            bool blKey = true;
            string strSQL = "select * from tblChiTietPhieuMuonTra where MaDauSach=@MaDauSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach", clsBook.MaDauSach);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Đầu sách này đang có trong chi tiết phiếu mượn nên không thể xóa";
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Hàm xóa sách
        public bool RemoveBook(Book clsBook)
        {
            bool blKey = false;
            string strsQL = "delete from tlbDauSach where MaDauSach=@MaDauSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaDauSach", clsBook.MaDauSach);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strsQL, CommandType.Text, cmd).Tables[0];
                if (cls.Update(strsQL, CommandType.Text, cmd))
                    blKey = true;
                else
                    if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                    strError = "Đầu sách này đang có trong chi tiết phiếu mượn nên không thể xóa";
                else
                    blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
// toi day roi
        //Tìm sách torng form tìm tài liệu
        public DataTable FindBook(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "SELECT S.MaSach, TenSach, TacGia, SoLuong, DonGia, NoiDungTomTat, NgonNgu, LS.TenLoaiSach,LS.MaLoaiSach, NXB.TenNXB";
                strSQL +=" FROM tblSach S, tblNXB NXB, tblLoaiSach LS ";
                strSQL +=" WHERE S.MaNXB=NXB.MaNXB and S.MaLoaiSach=LS.MaLoaiSach ";
               
            //string strSQL2 = "";                
            switch (intType)
            {
                case 0:// mã sách
                    if (intFilter == 0)//Gần đúng
                        strSQL += " and S.MaSach like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL += " and S.MaSach like @Keyword";
                    break;
                case 1://Tác giả
                    if (intFilter == 0)//Gần đúng
                    {
                        //strSQL = "SELECT S.MaSach, TenSach, MaLoaiSach, TacGia, SoLuong, DonGia, NoiDungTomTat, NgonNgu, NXB.TenNXB";
                        //strSQL += "  FROM tblSach S, tblNXB NXB ";
                        //strSQL += "  WHERE S.MaNXB=NXB.MaNXB ";
                        strSQL += " and TacGia like '%'+@Keyword+'%'";
                    }
                    else//Chính xác
                    {
                        //strSQL = "SELECT S.MaSach, TenSach,  MaLoaiSach,TacGia, SoLuong, DonGia, NoiDungTomTat, NgonNgu, NXB.TenNXB";
                        //strSQL += "  FROM tblSach S,  tblNXB NXB";
                        //strSQL += "  WHERE S.MaNXB=NXB.MaNXB";
                        strSQL += " and TacGia like @Keyword";
                    }
                    break;
                case 2:// Tên Sách
                    if (intFilter == 0)//Gần đúng
                    {
                        //strSQL = "SELECT S.MaSach, TenSach, MaLoaiSach, TacGia, SoLuong, DonGia, NoiDungTomTat, NgonNgu, NXB.TenNXB";
                        //strSQL += "  FROM tblSach S, tblNXB NXB ";
                        //strSQL += "  WHERE S.MaNXB=NXB.MaNXB ";
                        strSQL += " and TenSach like '%'+@Keyword+'%'";
                    }
                    else//Chính xác
                    {
                        //strSQL = "SELECT S.MaSach, TenSach, MaLoaiSach, TacGia, SoLuong, DonGia, NoiDungTomTat, NgonNgu, NXB.TenNXB";
                        //strSQL += "  FROM tblSach S, tblNXB NXB ";
                        //strSQL += "  WHERE S.MaNXB=NXB.MaNXB ";
                        strSQL += " and TenSach like @Keyword";
                    }
                    break;
                case 3://Nhà XB
                    if (intFilter == 0)//Gần đúng
                        strSQL += " and TenNXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL += " and TenNXB like @Keyword";
                    break;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                //if (intType == 1)
                //{
                //    dt2 = cls.GetData(strSQL2, CommandType.Text, cmd).Tables[0];                    
                //}
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            //if (intType == 2)
            //{
            //    dt.Merge(dt2);
            //}
            return dt;
        }
     
        //Tổng số đầu sách của 1 tựa sách
        public int TongDauSach(int intMaSach)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where MaSach=@MaSach";
            //strSQL += " group by MaSach";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
            DataTable dt = new DataTable();
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
            return dt.Rows.Count;
        }
        //Sách mất
        public int SachMat(int intMaDauSach)
        {
            string strSQL = "select *";
            strSQL += "  from tblDauSach";
            strSQL += " where TinhTrang=2 and MaSach=@MaSach";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaDauSach);
            DataTable dt = new DataTable();
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
            return dt.Rows.Count;
        }
        //Sách hỏng
        public int SachHong(int intMaDauSach)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where TinhTrang=1 and MaSach=@MaSach";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaDauSach);
            DataTable dt = new DataTable();
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
            return dt.Rows.Count;
        }
        //Sách mượn
        public int SachMuon(int intMaSach)
        {
            string strSQL = "select *";
            strSQL += " from tblSach S, tblChiTietPhieuMuonTra PM";
            strSQL += " where S.MaSach=PM.MaSach and NgayTra is null and MaSach=@MaSach";
            //string strSQL = "select *";
            //strSQL += " from tblDauSach ";
            //strSQL += " where TinhTrang=3 and MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
            DataTable dt = new DataTable();
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
            return dt.Rows.Count;
        }
        //public int SachDaTra(int intMaSach)
        //{
        //    //string strSQL = "select *";
        //    //strSQL += " from tblSach S, tblChiTietPhieuMuonTra PM";
        //    //strSQL += " where S.MaSach=PM.MaSach and NgayTra is null and MaSach=@MaSach";
        //    string strSQL = "select *";
        //    strSQL += " from tblDauSach ";
        //    strSQL += " where TinhTrang=4 and MaSach=@MaSach";
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.AddWithValue("@MaSach", intMaSach);
        //    DataTable dt = new DataTable();
        //    Database cls = new Database();
        //    try
        //    {
        //        dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
        //        if (cls.Error != "")
        //            strError = cls.Error;
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    return dt.Rows.Count;
        //}
        public DataTable GetInfo(int intMaSach)
        {
            string strSQL = "select * from tblSach where MaSach=@MaSach";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
            DataTable dt = new DataTable();
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
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        } 
    }
}
