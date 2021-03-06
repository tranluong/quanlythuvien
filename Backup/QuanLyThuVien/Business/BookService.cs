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
        public bool DeleteBook(int intMaTS)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.HasForeignKey(intMaTS))
                strError = cls.Error;
            else
            {
                if (cls.DeleteBook(intMaTS))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
        //Xóa tập sách
        public bool DeleteBookChapter(int intMaTap)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.HasForeignKeyChapter(intMaTap))
                strError = cls.Error;
            else
            {
                if (cls.DeleteBookChapter(intMaTap))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
        //Xóa tựa sách tập
        public bool XoaTuaSachTap(int intMaTS)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.HasForeignKeyInTapSach(intMaTS))
                strError = cls.Error;
            else
            {
                if (cls.XoaTuaSachTap(intMaTS))
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
        //Cập nhật tựa sách tập
        public bool UpdateBookChapter(Book clsBook)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.UpdateBookChapter(clsBook))
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
        public DataTable TimDauSach(int intType, string strKeyword, int intFilter)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.TimDauSach(intType, strKeyword, intFilter);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Hiển thị tất cả sách
        public DataTable ShowAllBook()
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.ShowAllBook();
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
        //Hiển thị các tập của một tựa sách
        public DataTable ShowAllChapter(int intMaTS)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.ShowAllChapter(intMaTS);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Hiển thị tác giả tập
        public DataTable ShowAuthorChapter(int intMaTap)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.ShowAuthorChapter(intMaTap);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Thống kê 1 tựa sách
        public Book Stat(int intMaTS)
        {
            Book clsBook = new Book();
            BookDAO cls = new BookDAO();
            clsBook.TongDauSach = cls.TongDauSach(intMaTS);
            clsBook.SLMat = cls.SachMat(intMaTS);
            clsBook.SLHong = cls.SachHong(intMaTS);
            clsBook.SLMuon = cls.SachMuon(intMaTS);
            clsBook.SLCon = clsBook.TongDauSach - (clsBook.SLMat + clsBook.SLHong + clsBook.SLMuon);            
            return clsBook;
        }
        public Book StatTap(int intMaTap)
        {
            Book clsBook = new Book();
            BookDAO cls = new BookDAO();
            clsBook.TongDauSachTap = cls.TongDauSachTap(intMaTap);
            clsBook.SLMatTap = cls.SachMatTap(intMaTap);
            clsBook.SLHongTap = cls.SachHongTap(intMaTap);
            clsBook.SLMuonTap = cls.SachMuonTap(intMaTap);
            clsBook.SLConTap = clsBook.TongDauSachTap - (clsBook.SLMatTap + clsBook.SLHongTap + clsBook.SLMuonTap);
            return clsBook;
        }
        //Hàm thêm sách tập
        public bool CreateBookChapter(Book clsBook)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.IsExistBookID(clsBook))
                strError = cls.Error;
            else
            {
                if (cls.CreateBookHasChapter(clsBook))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
        //Hàm kiểm tra trùng tập khi cập nhật
        public bool IsExistChapter(Book clsBook,int intOldTapSo)
        {
            bool blKey = true;
            BookDAO cls = new BookDAO();
            if (cls.IsExistChapter(clsBook,intOldTapSo))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }
        //Hàm kiểm tra trùng tên tập khi cập nhật
        public bool IsExistChapterName(Book clsBook,string strOldTenTap)
        {
            bool blKey = true;
            BookDAO cls = new BookDAO();
            if (cls.IsExistChapterName(clsBook,strOldTenTap))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }
        //Hàm kiểm tra trùng tập khi thêm
        public bool IsExistChapter(Book clsBook)
        {
            bool blKey = true;
            BookDAO cls = new BookDAO();
            if (cls.IsExistChapter(clsBook))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }
        //Hàm kiểm tra trùng tên tập khi thêm
        public bool IsExistChapterName(Book clsBook)
        {
            bool blKey = true;
            BookDAO cls = new BookDAO();
            if (cls.IsExistChapterName(clsBook))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }
        //Hàm thêm sách tập
        public bool AddChapter(Book clsBook)
        {
            bool blKey = false;
            BookDAO cls = new BookDAO();
            if (cls.IsExistBookID(clsBook))
                strError = cls.Error;
            else
            {
                if (cls.AddChapter(clsBook))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
        //Hiển thị tất cả sách có tập
        public DataTable ShowAllBookHasChapter()
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.ShowAllBookHasChapter();
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Tìm kiếm sách có tập
        public DataTable SearchBookHasChapter(int intType, string strKeyword, int intFilter)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.SearchBookHasChapter(intType, strKeyword, intFilter);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Lấy thông tin tập
        public Book GetInfoChapter(int intMaTap)
        {
            BookDAO cls = new BookDAO();
            DataTable dt = cls.GetInfoChapter(intMaTap);
            if (cls.Error != "")
                strError = cls.Error;            
            Book clsBook = new Book();
            DataTableReader tr = dt.CreateDataReader();
            if (tr.Read())
            {
                clsBook.TapSo = Convert.ToInt32(tr["TapSo"]);
                clsBook.TenTap = tr["TenTap"].ToString();
                clsBook.GiaBia = Convert.ToInt32(tr["GiaBia"]);
                clsBook.SoTrang = tr["SoTrang"].ToString();
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
