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
        //Hàm kiểm tra trùng số ĐKCB khi thêm
        public bool IsExistBookID(Book clsBook)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblDauSach where SoDKCB>=@SoDKCB1 and SoDKCB<=@SoDKCB2";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB1", clsBook.SoDKCBTu);
            cmd.Parameters.AddWithValue("@SoDKCB2", clsBook.SoDKCBDen);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Có Số ĐKCB bị trùng";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Hàm kiểm tra trùng mã độc giả khi cập nhật
        public bool IsExistReaderID(string strNewReaderID, string strOldReaderID)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblDocgia where MaDG=@NewReaderID and MaDG !=@OldReaderID";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NewReaderID", strNewReaderID);
            cmd.Parameters.AddWithValue("@OldReaderID", strOldReaderID);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Mã độc giả này đã tồn tại";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Hàm thêm sách mới
        public bool CreateBook(Book clsBook)
        {
            bool blKey = false;
            SqlCommand cmd = new SqlCommand();
            string strSQL = "insert into tblTuaSach values(";
            strSQL += "@TenTS,@TSMH,@KHPL,@Nganh,@NgonNgu,@NXB,@NamXB,@Kho,@GiaBia,@SoTrang,@KichThuoc,@DEWEY,@TomTat,@ChuDe,@LanTB,@TungThu,@TuaSongSong); declare @ID int; set @ID=@@IDENTITY";            
            for (int i = clsBook.SoDKCBTu; i <= clsBook.SoDKCBDen; i++)
            {
                strSQL += "; insert into tblDauSach values(@SoDKCB" + i.ToString() + ",@ID,@TinhTrang,'',@MaTap,@NgayCapNhat,@NguoiCapNhat)";
                cmd.Parameters.AddWithValue("@SoDKCB" + i.ToString(), i);
            }            
            for (int i = 0; i < clsBook.Rows; i++)
            {
                strSQL += "; insert into tblSach_Tacgia values(@ID,@TacGia" + i.ToString() + ",@ChuBien" + i.ToString() + ")";
                cmd.Parameters.AddWithValue("@TacGia" + i.ToString(), clsBook.TacGia[i, 0]);
                cmd.Parameters.AddWithValue("@ChuBien" + i.ToString(), clsBook.TacGia[i, 1]);
            }            
            cmd.Parameters.AddWithValue("@TenTS", clsBook.TenTS);
            cmd.Parameters.AddWithValue("@TSMH", clsBook.TSMaHoa);
            cmd.Parameters.AddWithValue("@KHPL", clsBook.KiHieuPL);
            cmd.Parameters.AddWithValue("@Nganh", clsBook.MaNganh);
            cmd.Parameters.AddWithValue("@NgonNgu", clsBook.MaNgonNgu);
            cmd.Parameters.AddWithValue("@NXB", clsBook.MaNXB);
            cmd.Parameters.AddWithValue("@NamXB", clsBook.NamXB);
            cmd.Parameters.AddWithValue("@Kho", clsBook.MaKho);
            cmd.Parameters.AddWithValue("@GiaBia", clsBook.GiaBia);
            cmd.Parameters.AddWithValue("@SoTrang", clsBook.SoTrang);
            cmd.Parameters.AddWithValue("@KichThuoc", clsBook.KichThuoc);
            cmd.Parameters.AddWithValue("@DEWEY", clsBook.DEWEY);
            cmd.Parameters.AddWithValue("@TomTat", clsBook.TomTat);
            cmd.Parameters.AddWithValue("@ChuDe", clsBook.ChuDe);
            cmd.Parameters.AddWithValue("@LanTB", clsBook.LanTB);
            cmd.Parameters.AddWithValue("@TungThu", clsBook.TungThu);
            cmd.Parameters.AddWithValue("@TuaSongSong", clsBook.TuaSongSong);
            
            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@MaTap", clsBook.MaTap);
            cmd.Parameters.AddWithValue("@NgayCapNhat", clsBook.NgayCapNhat);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsBook.NguoiCapNhat);
            
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
        //Xóa tựa sách        
        //Hàm kiểm tra tựa sách có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKey(int intMaTS)
        {
            bool blKey = true;
            string strSQL = "select * from tblDauSach where MaTS=@MaTS";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS",intMaTS);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL,CommandType.Text,cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Hiện có đầu sách thuộc tựa sách này nên không thể xóa";
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Hàm kiểm tra tập sách có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKeyChapter(int intMaTap)
        {
            bool blKey = true;
            string strSQL = "select * from tblDauSach where MaTap=@MaTap";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Hiện có đầu sách thuộc tập sách này nên không thể xóa";
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Hàm kiểm tra tựa sách tập có đang được sử dụng hay không (khóa ngoại)        
        public bool HasForeignKeyInTapSach(int intMaTS)
        {
            bool blKey = true;
            string strSQL = "select * from tblTapSach where MaTS=@MaTS";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                        strError = "Hiện có tập sách thuộc tựa sách này nên không thể xóa";
                    else
                        blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }   
        //Hàm xóa tựa sách
        public bool DeleteBook(int intMaTS)
        {
            bool blKey = false;
            string strsQL = "delete from tblTuaSach where MaTS=@MaTS";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa tựa sách thất bại";
            return blKey;
        }
        //Hàm xóa tập sách
        public bool DeleteBookChapter(int intMaTap)
        {
            bool blKey = false;
            string strsQL = "delete from tblTapSach where MaTap=@MaTap";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa tập sách thất bại";
            return blKey;
        }
        //Hàm xóa tựa sách tập
        public bool XoaTuaSachTap(int intMaTS)
        {
            bool blKey = false;
            string strsQL = "delete from tblTuaSach where MaTS=@MaTS";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
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
        //Cập nhật tựa sách
        public bool UpdateBook(Book clsBook)
        {
            bool blKey = false;
            string strSQL = "update tblTuaSach set ";
            strSQL += "TenTS = @TenTS";
            strSQL += ",TSMaHoa = @TSMH";
            strSQL += ",KiHieuPL = @KHPL";
            strSQL += ",MaNganh = @Nganh";
            strSQL += ",MaNgonNgu = @NgonNgu";
            strSQL += ",MaNXB = @NXB";
            strSQL += ",NamXB = @NamXB";
            strSQL += ",MaKho = @Kho";
            strSQL += ",GiaBia = @GiaBia";
            strSQL += ",SoTrang = @SoTrang";
            strSQL += ",KichThuoc = @KichThuoc";
            strSQL += ",DEWEY = @DEWEY";
            strSQL += ",TomTat = @TomTat";
            strSQL += ",ChuDe = @ChuDe";
            strSQL += ",LanTB = @LanTB";
            strSQL += ",TungThu = @TungThu";
            strSQL += ",TuaSongSong = @TuaSongSong";
            strSQL += " where MaTS = @MaTS";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenTS", clsBook.TenTS);
            cmd.Parameters.AddWithValue("@TSMH", clsBook.TSMaHoa);
            cmd.Parameters.AddWithValue("@KHPL", clsBook.KiHieuPL);
            cmd.Parameters.AddWithValue("@Nganh", clsBook.MaNganh);
            cmd.Parameters.AddWithValue("@NgonNgu", clsBook.MaNgonNgu);
            cmd.Parameters.AddWithValue("@NXB", clsBook.MaNXB);
            cmd.Parameters.AddWithValue("@NamXB", clsBook.NamXB);
            cmd.Parameters.AddWithValue("@Kho", clsBook.MaKho);
            cmd.Parameters.AddWithValue("@GiaBia", clsBook.GiaBia);
            cmd.Parameters.AddWithValue("@SoTrang", clsBook.SoTrang);
            cmd.Parameters.AddWithValue("@KichThuoc", clsBook.KichThuoc);
            cmd.Parameters.AddWithValue("@DEWEY", clsBook.DEWEY);
            cmd.Parameters.AddWithValue("@TomTat", clsBook.TomTat);
            cmd.Parameters.AddWithValue("@ChuDe", clsBook.ChuDe);
            cmd.Parameters.AddWithValue("@LanTB", clsBook.LanTB);
            cmd.Parameters.AddWithValue("@TungThu", clsBook.TungThu);
            cmd.Parameters.AddWithValue("@TuaSongSong", clsBook.TuaSongSong);
            cmd.Parameters.AddWithValue("@MaTS", clsBook.MaTS);

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
        public bool UpdateBookChapter(Book clsBook)
        {
            bool blKey = false;
            string strSQL = "update tblTuaSach set ";
            strSQL += "TenTS = @TenTS";
            strSQL += ",TSMaHoa = @TSMH";
            strSQL += ",KiHieuPL = @KHPL";
            strSQL += ",MaNganh = @Nganh";
            strSQL += ",MaNgonNgu = @NgonNgu";
            strSQL += ",MaNXB = @NXB";
            strSQL += ",NamXB = @NamXB";
            strSQL += ",MaKho = @Kho";
            strSQL += ",KichThuoc = @KichThuoc";
            strSQL += ",DEWEY = @DEWEY";
            strSQL += ",TomTat = @TomTat";
            strSQL += ",ChuDe = @ChuDe";
            strSQL += ",LanTB = @LanTB";
            strSQL += ",TungThu = @TungThu";
            strSQL += ",TuaSongSong = @TuaSongSong";
            strSQL += " where MaTS = @MaTS";
            strSQL += "; update tblTapSach set ";
            strSQL += "TenTap = @TenTap";
            strSQL += ",TapSo = @TapSo";
            strSQL += ",GiaBia = @GiaBia";
            strSQL += ",SoTrang = @SoTrang";
            strSQL += " where MaTS = @MaTS and MaTap=@MaTap";
            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@TenTS", clsBook.TenTS);
            cmd.Parameters.AddWithValue("@TSMH", clsBook.TSMaHoa);
            cmd.Parameters.AddWithValue("@KHPL", clsBook.KiHieuPL);
            cmd.Parameters.AddWithValue("@Nganh", clsBook.MaNganh);
            cmd.Parameters.AddWithValue("@NgonNgu", clsBook.MaNgonNgu);
            cmd.Parameters.AddWithValue("@NXB", clsBook.MaNXB);
            cmd.Parameters.AddWithValue("@NamXB", clsBook.NamXB);
            cmd.Parameters.AddWithValue("@Kho", clsBook.MaKho);            
            cmd.Parameters.AddWithValue("@KichThuoc", clsBook.KichThuoc);
            cmd.Parameters.AddWithValue("@DEWEY", clsBook.DEWEY);
            cmd.Parameters.AddWithValue("@TomTat", clsBook.TomTat);
            cmd.Parameters.AddWithValue("@ChuDe", clsBook.ChuDe);
            cmd.Parameters.AddWithValue("@LanTB", clsBook.LanTB);
            cmd.Parameters.AddWithValue("@TungThu", clsBook.TungThu);
            cmd.Parameters.AddWithValue("@TuaSongSong", clsBook.TuaSongSong);
            cmd.Parameters.AddWithValue("@TenTap", clsBook.TenTap);
            cmd.Parameters.AddWithValue("@TapSo", clsBook.TapSo);
            cmd.Parameters.AddWithValue("@MaTS", clsBook.MaTS);            
            cmd.Parameters.AddWithValue("@MaTap", clsBook.MaTap);

            cmd.Parameters.AddWithValue("@GiaBia", clsBook.GiaBia);
            cmd.Parameters.AddWithValue("@SoTrang", clsBook.SoTrang);

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
        //Tìm tựa sách
        public DataTable SearchBook(int intType, string strKeyword, int intFilter)
        {      
            string strSQL = "";
            switch (intType)
            {
                case 0://Tựa sách
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach WHERE TenTS like '%'+@Keyword+'%' and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach WHERE TenTS like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach WHERE TenTS like @Keyword and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach WHERE TenTS like @Keyword";
                    break;
                case 1://Số MFN
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach WHERE MaTS like '%'+@Keyword+'%' and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach WHERE MaTS like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach WHERE MaTS like @Keyword and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach WHERE MaTS like @Keyword";
                    break;
                case 2://Tác giả
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblSach_Tacgia STG, tblTacgia TG WHERE TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG and TenTG like '%'+@Keyword+'%' and TS.MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach TS, tblSach_Tacgia STG, tblTacgia TG WHERE TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG and TenTG like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblSach_Tacgia STG, tblTacgia TG WHERE TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG and TenTG like @Keyword and TS.MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach TS, tblSach_Tacgia STG, tblTacgia TG WHERE TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG and TenTG like @Keyword";
                    break;
                case 3://Chủ đề
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach WHERE ChuDe like '%'+@Keyword+'%' and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach WHERE ChuDe like '%'+@Keyword+'%'";
                    else//Chính xác
                        //strSQL = "SELECT * FROM tblTuaSach WHERE ChuDe like @Keyword and MaTS not in (Select MaTS from tblTapSach)";
                        strSQL = "SELECT * FROM tblTuaSach WHERE ChuDe like @Keyword";
                    break;
                case 4://Nhà XB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like '%'+@Keyword+'%' and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like @Keyword and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like @Keyword";
                    break;
                case 5://Năm XB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach WHERE NamXB like '%'+@Keyword+'%' and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach WHERE NamXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach WHERE NamXB like @Keyword and MaTS not in (Select MaTS from tblTapSach)";
                        //strSQL = "SELECT * FROM tblTuaSach WHERE NamXB like @Keyword";
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
        //Tìm tựa đầu sách
        public DataTable TimDauSach(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "";
            string strSQL2 = "";
            switch (intType)
            {
                case 0://Tựa sách
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and TenTS like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and TenTS like @Keyword";
                    break;
                case 1://Số MFN
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and TS.MaTS like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and TS.MaTS like @Keyword";
                    break;
                case 2://Tác giả
                    if (intFilter == 0)//Gần đúng
                    {
                        strSQL = "SELECT TS.MaTS,TenTS,TSMaHoa,KiHieuPL,MaNganh,MaNgonNgu,MaNXB,MaKho,NamXB,GiaBia,SoTrang,KichThuoc,DEWEY,LanTB,TinhTrang,TungThu,TuaSongSong,TomTat,ChuDe,MaTap";
                        strSQL += " FROM tblTuaSach TS, tblSach_Tacgia STG, tblTacgia TG, tblDauSach DS";
                        strSQL += " WHERE TS.MaTS=DS.MaTS and TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG and TenTG like '%'+@Keyword+'%'";

                        strSQL2 = "SELECT TS.MaTS,TenTS,TSMaHoa,KiHieuPL,MaNganh,MaNgonNgu,MaNXB,MaKho,NamXB,TapS.GiaBia,TapS.SoTrang,KichThuoc,DEWEY,LanTB,TinhTrang,TungThu,TuaSongSong,TomTat,ChuDe,DS.MaTap";
                        strSQL2 += " FROM tblDauSach DS, tblTapSach TapS, tblTap_Tacgia TTG, tblTacGia TG, tblTuaSach TS";
                        strSQL2 += " WHERE TapS.MaTap=DS.MaTap and TapS.MaTap=TTG.MaTap and TTG.MaTG=TG.MaTG and TS.MaTS=TapS.MaTS and TenTG like '%'+@Keyword+'%'";
                    }
                    else//Chính xác
                    {
                        strSQL = "SELECT TS.MaTS,TenTS,TSMaHoa,KiHieuPL,MaNganh,MaNgonNgu,MaNXB,MaKho,NamXB,GiaBia,SoTrang,KichThuoc,DEWEY,LanTB,TinhTrang,TungThu,TuaSongSong,TomTat,ChuDe,MaTap";
                        strSQL += " FROM tblTuaSach TS, tblSach_Tacgia STG, tblTacgia TG, tblDauSach DS";
                        strSQL += " WHERE TS.MaTS=DS.MaTS and TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG and TenTG like @Keyword";

                        strSQL2 = "SELECT TS.MaTS,TenTS,TSMaHoa,KiHieuPL,MaNganh,MaNgonNgu,MaNXB,MaKho,NamXB,TapS.GiaBia,TapS.SoTrang,KichThuoc,DEWEY,LanTB,TinhTrang,TungThu,TuaSongSong,TomTat,ChuDe,DS.MaTap";
                        strSQL2 += " FROM tblDauSach DS, tblTapSach TapS, tblTap_Tacgia TTG, tblTacGia TG, tblTuaSach TS";
                        strSQL2 += " WHERE TapS.MaTap=DS.MaTap and TapS.MaTap=TTG.MaTap and TTG.MaTG=TG.MaTG and TS.MaTS=TapS.MaTS and TenTG like @Keyword";
                    }
                    break;
                case 3://Chủ đề
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and ChuDe like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and ChuDe like @Keyword";
                    break;
                case 4://Nhà XB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblNXB NXB, tblDauSach DS WHERE TS.MaTS=DS.MaTS and TS.MaNXB=NXB.MaNXB and TenNXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblNXB NXB, tblDauSach DS WHERE TS.MaTS=DS.MaTS and TS.MaNXB=NXB.MaNXB and TenNXB like @Keyword";
                    break;
                case 5://Năm XB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and NamXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and NamXB like @Keyword";
                    break;
                case 6://Số ĐKCB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and SoDKCB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblDauSach DS WHERE TS.MaTS=DS.MaTS and SoDKCB like @Keyword";
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
        //Hiển thị tất cả sách
        public DataTable ShowAllBook()
        {
            string strSQL = "select * from tblTuaSach";            
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
        public DataTable ShowAuthor(int intMaTS)
        {
            string strSQL = "select TG.MaTG, TenTG as 'Tác giả', ChuBien as 'Chủ biên' from tblSach_Tacgia STG, tblTacgia TG where STG.MaTG=TG.MaTG and MaTS=@MaTS";
            //string strSQL = "select TenTG, ChuBien from tblSach_Tacgia STG, tblTacgia TG where STG.MaTG=TG.MaTG and MaTS=@MaTS";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
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
        //Hiển thị tác giả của sách có tập
        public DataTable ShowAuthorChapter(int intMaTap)
        {
            string strSQL = "select TG.MaTG, TenTG, ChuBien";
            strSQL += " from tblTapSach TS, tblTap_Tacgia TTG, tblTacGia TG";
            strSQL += " where TS.MaTap=TTG.MaTap and TTG.MaTG=TG.MaTG and TS.MaTap=@MaTap";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
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
        //Hàm thêm đầu sách mới
        public bool AddBook(Book clsBook)
        {
            bool blKey = false;
            string strSQL = "";
            for (int i = clsBook.SoDKCBTu; i <= clsBook.SoDKCBDen; i++)
            {
                strSQL += "insert into tblDauSach values(@SoDKCB" + i.ToString() + ",@MaTS,@TinhTrang,'',@MaTap,@NgayCapNhat,@NguoiCapNhat)";
            }            
            SqlCommand cmd = new SqlCommand();            
            for (int i = clsBook.SoDKCBTu; i <= clsBook.SoDKCBDen; i++)
            {
                cmd.Parameters.AddWithValue("@SoDKCB" + i.ToString(), i);
            }
            cmd.Parameters.AddWithValue("@MaTS", clsBook.MaTS);
            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@MaTap", clsBook.MaTap);
            cmd.Parameters.AddWithValue("@NgayCapNhat", clsBook.NgayCapNhat);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsBook.NguoiCapNhat);

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
            string strSQL = "update tblDauSach set TinhTrang=@TinhTrang, GhiChu=@GhiChu where SoDKCB=@SoDKCB";            
            SqlCommand cmd = new SqlCommand();            
            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@GhiChu", clsBook.GhiChu);
            cmd.Parameters.AddWithValue("@SoDKCB", clsBook.SoDKCBTu);           

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
            string strSQL = "select * from tblCT_PMSach where SoDKCB=@SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", clsBook.SoDKCBTu);
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
        //Hàm xóa tựa sách
        public bool RemoveBook(Book clsBook)
        {
            bool blKey = false;
            string strsQL = "delete from tblDauSach where SoDKCB=@SoDKCB";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoDKCB", clsBook.SoDKCBTu);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Xóa đầu sách thất bại";
            return blKey;
        }
        //Hàm thêm sách mới có tập
        public bool CreateBookChapter(Book clsBook)
        {
            bool blKey = false;
            SqlCommand cmd = new SqlCommand();
            string strSQL = "insert into tblTuaSach values(";
            strSQL += "@TenTS,@TSMH,@KHPL,@Nganh,@NgonNgu,@NXB,@NamXB,@Kho,@GiaBia,@SoTrang,@KichThuoc,@DEWEY,@TomTat,@ChuDe,@LanTB,@TungThu,@TuaSongSong); declare @ID int; set @ID=@@IDENTITY";
            for (int i = clsBook.SoDKCBTu; i <= clsBook.SoDKCBDen; i++)
            {
                strSQL += "; insert into tblDauSach values(@SoDKCB" + i.ToString() + ",@ID,@TinhTrang,'',@MaTap,@NgayCapNhat,@NguoiCapNhat)";
                cmd.Parameters.AddWithValue("@SoDKCB" + i.ToString(), i);
            }
            for (int i = 0; i < clsBook.Rows; i++)
            {
                strSQL += "; insert into tblSach_Tacgia values(@ID,@TacGia" + i.ToString() + ",@ChuBien" + i.ToString() + ")";
                cmd.Parameters.AddWithValue("@TacGia" + i.ToString(), clsBook.TacGia[i, 0]);
                cmd.Parameters.AddWithValue("@ChuBien" + i.ToString(), clsBook.TacGia[i, 1]);
            }
            cmd.Parameters.AddWithValue("@TenTS", clsBook.TenTS);
            cmd.Parameters.AddWithValue("@TSMH", clsBook.TSMaHoa);
            cmd.Parameters.AddWithValue("@KHPL", clsBook.KiHieuPL);
            cmd.Parameters.AddWithValue("@Nganh", clsBook.MaNganh);
            cmd.Parameters.AddWithValue("@NgonNgu", clsBook.MaNgonNgu);
            cmd.Parameters.AddWithValue("@NXB", clsBook.MaNXB);
            cmd.Parameters.AddWithValue("@NamXB", clsBook.NamXB);
            cmd.Parameters.AddWithValue("@Kho", clsBook.MaKho);
            cmd.Parameters.AddWithValue("@GiaBia", clsBook.GiaBia);
            cmd.Parameters.AddWithValue("@SoTrang", clsBook.SoTrang);
            cmd.Parameters.AddWithValue("@KichThuoc", clsBook.KichThuoc);
            cmd.Parameters.AddWithValue("@DEWEY", clsBook.DEWEY);
            cmd.Parameters.AddWithValue("@TomTat", clsBook.TomTat);
            cmd.Parameters.AddWithValue("@ChuDe", clsBook.ChuDe);
            cmd.Parameters.AddWithValue("@LanTB", clsBook.LanTB);
            cmd.Parameters.AddWithValue("@TungThu", clsBook.TungThu);
            cmd.Parameters.AddWithValue("@TuaSongSong", clsBook.TuaSongSong);

            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@MaTap", clsBook.MaTap);
            cmd.Parameters.AddWithValue("@NgayCapNhat", clsBook.NgayCapNhat);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsBook.NguoiCapNhat);

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
        //Tìm sách torng form tìm tài liệu
        public DataTable FindBook(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "SELECT MaTS, TenTS, NamXB, GiaBia, SoTrang, TomTat, ChuDe, TenNganh, TenNgonNgu, TenNXB, TenKho";
                strSQL +=" FROM tblTuaSach TS, tblNganhHoc NH, tblNgonNgu NN, tblNXB NXB, tblKhoChua KC";
                strSQL +=" WHERE TS.MaNganh=NH.MaNganh and TS.MaNgonNgu=NN.MaNgonNgu and TS.MaNXB=NXB.MaNXB and TS.MaKho=KC.MaKho";
               
                string strSQL2 = "";                
            switch (intType)
            {
                case 0://Tựa sách
                    if (intFilter == 0)//Gần đúng                    
                        strSQL += " and (TenTS like '%'+@Keyword+'%' or MaTS in (select MaTS from tblTapSach where TenTap like '%'+@Keyword+'%'))";
                    else//Chính xác
                        strSQL += " and (TenTS like @Keyword or MaTS in (select MaTS from tblTapSach where TenTap like @Keyword))";
                    break;
                case 1://Số MFN
                    if (intFilter == 0)//Gần đúng
                        strSQL += " and MaTS like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL += " and MaTS like @Keyword";
                    break;
                case 2://Tác giả
                    if (intFilter == 0)//Gần đúng
                    {
                        strSQL = "SELECT TS.MaTS, TenTS, NamXB, GiaBia, SoTrang, TomTat, ChuDe, TenNganh, TenNgonNgu, TenNXB, TenKho, TenTG";
                        strSQL += "  FROM tblTuaSach TS, tblNganhHoc NH, tblNgonNgu NN, tblNXB NXB, tblKhoChua KC, tblSach_Tacgia STG, tblTacGia TG";
                        strSQL += "  WHERE TS.MaNganh=NH.MaNganh and TS.MaNgonNgu=NN.MaNgonNgu and TS.MaNXB=NXB.MaNXB and TS.MaKho=KC.MaKho and TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG";
                        strSQL += " and TenTG like '%'+@Keyword+'%'";

                        strSQL2 = "SELECT TS.MaTS, TenTS, NamXB, TapS.GiaBia, TapS.SoTrang, TomTat, ChuDe, TenNganh, TenNgonNgu, TenNXB, TenKho, TenTG";
                        strSQL2 += "  FROM tblTuaSach TS, tblNganhHoc NH, tblNgonNgu NN, tblNXB NXB, tblKhoChua KC, tblTapSach TapS, tblTap_Tacgia TTG, tblTacGia TG";
                        strSQL2 += " WHERE TS.MaNganh=NH.MaNganh and TS.MaNgonNgu=NN.MaNgonNgu and TS.MaNXB=NXB.MaNXB and TS.MaKho=KC.MaKho and TS.MaTS=TapS.MaTS and TapS.MaTap=TTG.MaTap and TTG.MaTG=TG.MaTG";
                        strSQL2 += " and TenTG like '%'+@Keyword+'%'";
                    }
                    else//Chính xác
                    {
                        strSQL = "SELECT TS.MaTS, TenTS, NamXB, GiaBia, SoTrang, TomTat, ChuDe, TenNganh, TenNgonNgu, TenNXB, TenKho, TenTG";
                        strSQL += "  FROM tblTuaSach TS, tblNganhHoc NH, tblNgonNgu NN, tblNXB NXB, tblKhoChua KC, tblSach_Tacgia STG, tblTacGia TG";
                        strSQL += "  WHERE TS.MaNganh=NH.MaNganh and TS.MaNgonNgu=NN.MaNgonNgu and TS.MaNXB=NXB.MaNXB and TS.MaKho=KC.MaKho and TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG";
                        strSQL += " and TenTG like @Keyword";

                        strSQL2 = "SELECT TS.MaTS, TenTS, NamXB, TapS.GiaBia, TapS.SoTrang, TomTat, ChuDe, TenNganh, TenNgonNgu, TenNXB, TenKho, TenTG";
                        strSQL2 += "  FROM tblTuaSach TS, tblNganhHoc NH, tblNgonNgu NN, tblNXB NXB, tblKhoChua KC, tblTapSach TapS, tblTap_Tacgia TTG, tblTacGia TG";
                        strSQL2 += " WHERE TS.MaNganh=NH.MaNganh and TS.MaNgonNgu=NN.MaNgonNgu and TS.MaNXB=NXB.MaNXB and TS.MaKho=KC.MaKho and TS.MaTS=TapS.MaTS and TapS.MaTap=TTG.MaTap and TTG.MaTG=TG.MaTG";
                        strSQL2 += " and TenTG like @Keyword";
                    }
                    break;
                case 3://Chủ đề
                    if (intFilter == 0)//Gần đúng
                        strSQL += " and ChuDe like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL += " and ChuDe like @Keyword";
                    break;
                case 4://Nhà XB
                    if (intFilter == 0)//Gần đúng
                        strSQL += " and TenNXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL += " and TenNXB like @Keyword";
                    break;
                case 5://Năm XB
                    if (intFilter == 0)//Gần đúng
                        strSQL += " and NamXB like '%'+@Keyword+'%'";
                    else//Chính xác
                        strSQL += " and NamXB like @Keyword";
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
                if (intType == 2)
                {
                    dt2 = cls.GetData(strSQL2, CommandType.Text, cmd).Tables[0];                    
                }
                if (cls.Error != "")
                    strError = cls.Error;
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
        //Hiển thị các tập của một tựa
        public DataTable ShowAllChapter(int intMaTS)
        {
            string strSQL = "SELECT * FROM tblTapSach WHERE MaTS=@MaTS";
            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
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
        //Tổng số đầu sách của 1 tựa sách
        public int TongDauSach(int intMaTS)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where MaTS=@MaTS";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
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
        public int SachMat(int intMaTS)
        {
            string strSQL = "select *";
            strSQL += "  from tblDauSach";
            strSQL += " where TinhTrang=2 and MaTS=@MaTS";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
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
        public int SachHong(int intMaTS)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where TinhTrang=1 and MaTS=@MaTS";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
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
        public int SachMuon(int intMaTS)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach DS, tblCT_PMSach PMS";
            strSQL += " where DS.SoDKCB=PMS.SoDKCB and NgayTra is null and MaTS=@MaTS";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
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
        //Tổng số đầu sách của 1 tập sách
        public int TongDauSachTap(int intMaTap)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where MaTap=@MaTap";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
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
        //Sách mất của 1 tập sách
        public int SachMatTap(int intMaTap)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where TinhTrang=1 and MaTap=@MaTap";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
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
        //Sách hỏng của 1 tập sách
        public int SachHongTap(int intMaTap)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach";
            strSQL += " where TinhTrang=2 and MaTap=@MaTap";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
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
        //Sách mượn của 1 tập sách
        public int SachMuonTap(int intMaTap)
        {
            string strSQL = "select *";
            strSQL += " from tblDauSach DS, tblCT_PMSach PMS";
            strSQL += " where DS.SoDKCB=PMS.SoDKCB and NgayTra is null and DS.MaTap=@MaTap";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
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
        //Hàm thêm sách tập
        public bool CreateBookHasChapter(Book clsBook)
        {
            bool blKey = false;
            SqlCommand cmd = new SqlCommand();
            string strSQL = "insert into tblTuaSach(TenTS,TSMaHoa,KiHieuPL,MaNganh,MaNgonNgu,MaNXB,NamXB,MaKho,KichThuoc,DEWEY,TomTat,ChuDe,LanTB,TungThu,TuaSongSong) values(";
            strSQL += "@TenTS,@TSMH,@KHPL,@Nganh,@NgonNgu,@NXB,@NamXB,@Kho,@KichThuoc,@DEWEY,@TomTat,@ChuDe,@LanTB,@TungThu,@TuaSongSong); declare @ID int; set @ID=@@IDENTITY";
            strSQL += "; insert into tblTapSach values(";
            strSQL += "@ID,@TenTap,@TapSo,@GiaBia,@SoTrang); declare @IDTap int; set @IDTap=@@IDENTITY";
            for (int i = clsBook.SoDKCBTu; i <= clsBook.SoDKCBDen; i++)
            {
                strSQL += "; insert into tblDauSach values(@SoDKCB" + i.ToString() + ",@ID,@TinhTrang,'',@IDTap,@NgayCapNhat,@NguoiCapNhat)";
                cmd.Parameters.AddWithValue("@SoDKCB" + i.ToString(), i);
            }
            for (int i = 0; i < clsBook.Rows; i++)
            {
                strSQL += "; insert into tblTap_Tacgia values(@IDTap,@TacGia" + i.ToString() + ",@ChuBien" + i.ToString() + ")";
                cmd.Parameters.AddWithValue("@TacGia" + i.ToString(), clsBook.TacGia[i, 0]);
                cmd.Parameters.AddWithValue("@ChuBien" + i.ToString(), clsBook.TacGia[i, 1]);
            }
            cmd.Parameters.AddWithValue("@TenTS", clsBook.TenTS);
            cmd.Parameters.AddWithValue("@TSMH", clsBook.TSMaHoa);
            cmd.Parameters.AddWithValue("@KHPL", clsBook.KiHieuPL);
            cmd.Parameters.AddWithValue("@Nganh", clsBook.MaNganh);
            cmd.Parameters.AddWithValue("@NgonNgu", clsBook.MaNgonNgu);
            cmd.Parameters.AddWithValue("@NXB", clsBook.MaNXB);
            cmd.Parameters.AddWithValue("@NamXB", clsBook.NamXB);
            cmd.Parameters.AddWithValue("@Kho", clsBook.MaKho);            
            cmd.Parameters.AddWithValue("@KichThuoc", clsBook.KichThuoc);
            cmd.Parameters.AddWithValue("@DEWEY", clsBook.DEWEY);
            cmd.Parameters.AddWithValue("@TomTat", clsBook.TomTat);
            cmd.Parameters.AddWithValue("@ChuDe", clsBook.ChuDe);
            cmd.Parameters.AddWithValue("@LanTB", clsBook.LanTB);
            cmd.Parameters.AddWithValue("@TungThu", clsBook.TungThu);
            cmd.Parameters.AddWithValue("@TuaSongSong", clsBook.TuaSongSong);

            cmd.Parameters.AddWithValue("@TenTap", clsBook.TenTap);
            cmd.Parameters.AddWithValue("@TapSo", clsBook.TapSo);
            cmd.Parameters.AddWithValue("@GiaBia", clsBook.GiaBia);
            cmd.Parameters.AddWithValue("@SoTrang", clsBook.SoTrang);

            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@MaTap", clsBook.MaTap);
            cmd.Parameters.AddWithValue("@NgayCapNhat", clsBook.NgayCapNhat);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsBook.NguoiCapNhat);

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
        //Hiển thị tất cả sách có tập
        public DataTable ShowAllBookHasChapter()
        {
            string strSQL = "select *";
            strSQL += " from tblTuaSach";
            strSQL += "  where MaTS in (Select MaTS from tblTapSach)";            
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
        //Tìm tựa sách có tập
        public DataTable SearchBookHasChapter(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "";
            switch (intType)
            {
                case 0://Tựa sách
                    if (intFilter == 0)//Gần đúng
                    {
                        strSQL = "SELECT *";
                        strSQL += " FROM tblTuaSach";
                        strSQL += " WHERE (TenTS like '%'+@Keyword+'%' and MaTS in (Select MaTS from tblTapSach)";
                        strSQL += " or MaTS in (select MaTS from tblTapSach where TenTap like '%'+@Keyword+'%'))";
                    }
                    else//Chính xác
                    {
                        strSQL = "SELECT *";
                        strSQL += " FROM tblTuaSach";
                        strSQL += " WHERE (TenTS like @Keyword and MaTS in (Select MaTS from tblTapSach)";
                        strSQL += " or MaTS in (select MaTS from tblTapSach where TenTap like @Keyword))";
                    }
                    break;
                case 1://Số MFN
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach WHERE MaTS like '%'+@Keyword+'%' and MaTS in (Select MaTS from tblTapSach)";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach WHERE MaTS like @Keyword and MaTS in (Select MaTS from tblTapSach)";
                    break;
                case 2://Tác giả
                    if (intFilter == 0)//Gần đúng
                    {
                        strSQL = "SELECT * FROM tblTuaSach TS, tblTapSach TapS, tblTap_Tacgia TTG, tblTacgia TG";
                        strSQL += " WHERE TS.MaTS=TapS.MaTS and TapS.MaTap=TTG.MaTap and TTG.MaTG=TG.MaTG and TenTG like '%'+@Keyword+'%'";
                        strSQL += " and TS.MaTS in (Select MaTS from tblTapSach)";
                    }
                    else//Chính xác
                    {
                        strSQL = "SELECT * FROM tblTuaSach TS, tblTapSach TapS, tblTap_Tacgia TTG, tblTacgia TG";
                        strSQL += " WHERE TS.MaTS=TapS.MaTS and TapS.MaTap=TTG.MaTap and TTG.MaTG=TG.MaTG and TenTG like @Keyword";
                        strSQL += " and TS.MaTS in (Select MaTS from tblTapSach)";
                    }                       
                    break;
                case 3://Chủ đề
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach WHERE ChuDe like '%'+@Keyword+'%' and MaTS in (Select MaTS from tblTapSach)";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach WHERE ChuDe like @Keyword and MaTS in (Select MaTS from tblTapSach)";
                    break;
                case 4://Nhà XB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like '%'+@Keyword+'%' and MaTS in (Select MaTS from tblTapSach)";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach TS, tblNXB NXB WHERE TS.MaNXB=NXB.MaNXB and TenNXB like @Keyword and MaTS in (Select MaTS from tblTapSach)";
                    break;
                case 5://Năm XB
                    if (intFilter == 0)//Gần đúng
                        strSQL = "SELECT * FROM tblTuaSach WHERE NamXB like '%'+@Keyword+'%' and MaTS in (Select MaTS from tblTapSach)";
                    else//Chính xác
                        strSQL = "SELECT * FROM tblTuaSach WHERE NamXB like @Keyword and MaTS in (Select MaTS from tblTapSach)";
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
        //Hàm kiểm tra trùng tập khi cập nhật
        public bool IsExistChapter(Book clsBook, int intOldTapSo)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTapSach where MaTS=@MaTS and TapSo=@TapSo and TapSo!=@OldTapSo";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", clsBook.MaTS);
            cmd.Parameters.AddWithValue("@TapSo", clsBook.TapSo);
            cmd.Parameters.AddWithValue("@OldTapSo", intOldTapSo);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tập này đã tồn tại, nhập tập khác";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Hàm kiểm tra trùng tập khi thêm tập
        public bool IsExistChapterName(Book clsBook, string strOldTenTap)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTapSach where MaTS=@MaTS and TenTap=@TenTap and TenTap!=@OldTenTap";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", clsBook.MaTS);
            cmd.Parameters.AddWithValue("@TenTap", clsBook.TenTap);
            cmd.Parameters.AddWithValue("@OldTenTap", strOldTenTap);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tên tập này đã tồn tại, nhập tên tập khác";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Hàm kiểm tra trùng tập khi thêm tập
        public bool IsExistChapter(Book clsBook)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTapSach where MaTS=@MaTS and TapSo=@TapSo";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", clsBook.MaTS);
            cmd.Parameters.AddWithValue("@TapSo", clsBook.TapSo);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tập này đã tồn tại, nhập tập khác";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Hàm kiểm tra trùng tập khi thêm tập
        public bool IsExistChapterName(Book clsBook)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblTapSach where MaTS=@MaTS and TenTap=@TenTap";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", clsBook.MaTS);
            cmd.Parameters.AddWithValue("@TenTap", clsBook.TenTap);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                    strError = "Tên tập này đã tồn tại, nhập tên tập khác";
                else
                    blIsExist = false;
            return blIsExist;
        }
        //Hàm thêm sách tập
        public bool AddChapter(Book clsBook)
        {
            bool blKey = false;            
            SqlCommand cmd = new SqlCommand();
            string strSQL = "insert into tblTapSach values(";
            strSQL += "@MaTS,@TenTap,@TapSo,@GiaBia,@SoTrang); declare @IDTap int; set @IDTap=@@IDENTITY";
            for (int i = clsBook.SoDKCBTu; i <= clsBook.SoDKCBDen; i++)
            {
                strSQL += "; insert into tblDauSach values(@SoDKCB" + i.ToString() + ",@MaTS,@TinhTrang,'',@IDTap,@NgayCapNhat,@NguoiCapNhat)";
                cmd.Parameters.AddWithValue("@SoDKCB" + i.ToString(), i);
            }            
            int j = 1;
            foreach(DataRow dr in clsBook.TacGiaTap.Rows )
            {
                strSQL += "; insert into tblTap_Tacgia values(@IDTap,@TacGia" + j.ToString() + ",@ChuBien" + j.ToString() + ")";
                cmd.Parameters.AddWithValue("@TacGia" + j.ToString(), Convert.ToInt32(dr["MaTG"]));
                cmd.Parameters.AddWithValue("@ChuBien" + j.ToString(), Convert.ToInt32(dr["ChuBien"]));
                j++;
            }

            cmd.Parameters.AddWithValue("@MaTS", clsBook.MaTS);            
            cmd.Parameters.AddWithValue("@TenTap", clsBook.TenTap);
            cmd.Parameters.AddWithValue("@TapSo", clsBook.TapSo);
            cmd.Parameters.AddWithValue("@GiaBia", clsBook.GiaBia);
            cmd.Parameters.AddWithValue("@SoTrang", clsBook.SoTrang);

            cmd.Parameters.AddWithValue("@TinhTrang", clsBook.TinhTrang);
            cmd.Parameters.AddWithValue("@MaTap", clsBook.MaTap);
            cmd.Parameters.AddWithValue("@NgayCapNhat", clsBook.NgayCapNhat);
            cmd.Parameters.AddWithValue("@NguoiCapNhat", clsBook.NguoiCapNhat);

            Database cls = new Database();
            if (cls.Update(strSQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    strError = "Thêm tập thất bại";
            return blKey;
        }
        //Lấy thông tin tập
        public DataTable GetInfoChapter(int intMaTap)
        {
            string strSQL = "select * from tblTapSach where MaTap=@MaTap";
            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
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
