using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class BookService
    {        
        //Hàm thêm sách
        public bool CreateBook(Book clsBook)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.IsExistBookID(clsBook))
                strError = cls.Error;
            else
            {
                if (cls.CreateBook(clsBook))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }                
        //Xóa tựa sách
        public bool DeleteBook(int intMaSach)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.HasForeignKey(intMaSach))
                strError = cls.Error;
            else
            {
                if (cls.DeleteBook(intMaSach))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
 
        //Cập nhật sách
        public bool UpdateBook(Book clsBook)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();

            if (cls.UpdateBook(clsBook))
                blKey = true;
            else
                strError = cls.Error;
            return blKey;
        }
      
        //Tìm kiếm sách
        public DataTable SearchBook(int intType, string strKeyword, int intFilter)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.SearchBook(intType, strKeyword, intFilter);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Tìm kiếm sách trong form tìm tài liệu
        public DataTable FindBook(int intType, string strKeyword, int intFilter)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.FindBook(intType, strKeyword, intFilter);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Tìm kiếm đầu sách
        public DataTable TimSach(int intType, string strKeyword, int intFilter)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.TimSach(intType, strKeyword, intFilter);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        public DataTable TimSachMT(int intType, string strKeyword, int intFilter)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.TimSachMT(intType, strKeyword, intFilter);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Hiển thị tất cả sách
        public DataTable ShowAllDBook(int intMaSach)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.ShowAllDBook(intMaSach);
            if (cls.Error != "")
                strError = cls.Error;                    
            return dt;
        }
        //Hiển thị tác giả của sách
        public DataTable ShowAuthor(int intMaTS)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.ShowAuthor(intMaTS);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Hàm thêm đầu sách
        public bool AddBook(Book clsBook)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.IsExistBookID(clsBook))
                strError = cls.Error;
            else
            {
                if (cls.AddBook(clsBook))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
        //Cập nhật đầu sách
        public bool EditBook(Book clsBook)
        {
            bool blKey = false;            
            BookDAO cls = new BookDAO();            
            if (cls.EditBook(clsBook))
                blKey = true;
            else
                strError = cls.Error;            
            return blKey;
        }
        //Xóa đầu sách
        public bool RemoveBook(Book clsBook)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.HasForeignKey(clsBook))
                strError = cls.Error;
            else
            {
                if (cls.RemoveBook(clsBook))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
 
     
        //Thống kê 1 tựa sách
        public Book Stat(int intMaSach)
        {
            Book clsBook = new Book();
            BookDAO cls = new BookDAO();
            clsBook.TongDauSach = cls.TongDauSach(intMaSach);
            clsBook.SLMat = cls.SachMat(intMaSach);
            clsBook.SLHong = cls.SachHong(intMaSach);
            clsBook.SLMuon = cls.SachMuon(intMaSach);
            clsBook.SLCon = clsBook.TongDauSach - (clsBook.SLMat + clsBook.SLMuon + clsBook.SLHong);            
            return clsBook;
        }
        public DataTable ShowAuthorDauSach(int intMaTap)
        {
            string strSQL = "select TenSach , TacGia, ";
            strSQL += " from tblSach ";
            strSQL += " where  MaSach=@MaSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaTap);
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
        public Book GetInfo(int intMaSach)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.GetInfo(intMaSach);
            if (cls.Error != "")
                strError = cls.Error;
            Book clsBook = new Book();
            DataTableReader tr = dt.CreateDataReader();
            if (tr.Read())
            {
                clsBook.MaSach = Convert.ToInt16(tr["MaSach"].ToString());
                clsBook.TenSach = tr["TenSach"].ToString();
                clsBook.TacGia = tr["TacGia"].ToString();
                clsBook.SoLuong = Convert.ToInt16(tr["SoLuong"]);
                clsBook.DonGia = Convert.ToInt32(tr["DonGia"]);
                clsBook.NoiDungTomTat = tr["NoiDungTomTat"].ToString();
                clsBook.NgonNgu = tr["NgonNgu"].ToString();
                clsBook.MaLoaiSach = Convert.ToInt16(tr["MaLoaiSach"]);
                clsBook.MaNXB = Convert.ToInt16(tr["MaNXB"]);
            }
            return clsBook;
        }
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
    }
}
