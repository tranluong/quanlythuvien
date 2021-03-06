using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class ReaderService
    {
//Thêm độc giả mới
        //Hàm kiểm tra trùng Mã Độc giả khi Thêm và Cập nhật
        /*public bool IsExistReaderID(string strReaderID,string strOldReaderID)
        {
            bool blKey = true;
            ReaderDAO cls = new ReaderDAO();
            if (cls.IsExistReaderID(strReaderID,strOldReaderID))
                strError = cls.Error;
            else
                blKey = false;
            return blKey;
        }*/
        //Hàm thêm độc giả
        public bool CreateReader(Reader clsReader)
        {
            bool blKey = false;
            ReaderDAO cls = new ReaderDAO();
            if (cls.IsExistReaderID(clsReader.MaDocGia))
                strError = cls.Error;
            else
            {
                if (cls.CreateReader(clsReader))
                    blKey = true;
                else
                    strError = cls.Error;
            }
            return blKey;
        }
//Xóa độc giả
        //Kiểm tra độc giả trả hết sách chưa
        public bool TraHetSach(string strMaDG)
        {
            bool blKey = false;
            ReaderDAO cls = new ReaderDAO();
            int intSoTaiLieu = cls.SachChuaTra(strMaDG);
            if (cls.Error != "")
            {
                strError = cls.Error;
            }
            else
            {
                if (intSoTaiLieu == 0)
                    blKey = true;                
            }
            return blKey;
        }
        //Xóa ngôn ngữ
        public bool DeleteReader(Reader clsReader)
        {
            bool blKey = false;
            //if (!HasForeignKey(clsReader.MaDocGia))
            //{
                ReaderDAO clsReaderDAO = new ReaderDAO();
                if (clsReaderDAO.DeleteReader(clsReader))
                    blKey = true;
                else
                    strError = clsReaderDAO.Error;
            //}
            return blKey;
        }
//Cập nhật độc giả
        public bool UpdateReader(string strReaderID,Reader clsReader)
        {
            bool blKey = false;
            ReaderDAO clsReaderDAO = new ReaderDAO();
            if (clsReaderDAO.IsExistReaderID(clsReader.MaDocGia, strReaderID))
                strError = clsReaderDAO.Error;
            else
            {                
                if (clsReaderDAO.UpdateReader(strReaderID,clsReader))
                    blKey = true;
                else
                    strError = clsReaderDAO.Error;
            }
            return blKey;
        }
//Tìm kiếm độc giả
        public DataTable SearchReader(int intType, string strKeyword, int intFilter)
        {
            ReaderDAO cls = new ReaderDAO();
            DataTable dt = cls.SearchReader(intType,strKeyword, intFilter);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;                
        }

        public DataTable ShowAllReader()
        {
            ReaderDAO clsReaderDAO = new ReaderDAO();
            DataTable dt = clsReaderDAO.ShowAllReader();
            if (clsReaderDAO.Error != "")
                strError = clsReaderDAO.Error;
            return dt;
        }

        //Quá trình mượn
        public DataTable QuaTrinhMuon(string strMaDG, DateTime dtDau, DateTime dtCuoi,int intView)
        {
            ReaderDAO cls = new ReaderDAO();
            DataTable dt = cls.QuaTrinhMuonTra(strMaDG, dtDau, dtCuoi, intView);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        public DataTable QuaTrinhMuon(string strMaDG)
        {
            ReaderDAO cls = new ReaderDAO();
            DataTable dt = cls.QuaTrinhMuonTra(strMaDG);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
//Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
        //Đọc file excel
        public DataTable ReadExcel(string strFile)
        {
            ReaderDAO cls = new ReaderDAO();
            DataTable dt = cls.ReadExcel(strFile);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Ghi dữ liệu excel vào sql server
        public bool InsertFromExcel(DataTable dt)
        {
            bool blKey = false;
            ReaderDAO cls = new ReaderDAO();
            if (cls.InsertFromExcel(dt))
                blKey = true;
            else
                strError = cls.Error;
            return blKey;
        }
    }
}
