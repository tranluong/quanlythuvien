using QuanLyThuVien.Data;
using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Business
{
    class PhieuNhapService
    {
        public DataTable loadCombox()
        {
            PhieuNhapDao pn = new PhieuNhapDao();
            DataTable dt = pn.loadCombox();
            if (pn.Error != "")
                strError = pn.Error;
            return dt;
        }

        //Thêm thủ thư
        public bool ThemPhieuNhap(PhieuNhap pn)
        {
            bool blKey = false;
            PhieuNhapDao pnDAO = new PhieuNhapDao();
            if (pnDAO.ThemPhieuNhap(pn))
                blKey = true;
            else
                strError = pnDAO.Error;        
            return blKey;
        }

        public DataTable HienThiPhieuNhap()
        {
            PhieuNhapDao phieuNhapDAO = new PhieuNhapDao();
            DataTable dt = phieuNhapDAO.HienThiPhieuNhap();
            if (phieuNhapDAO.Error != "")
                strError = phieuNhapDAO.Error;
            return dt;
        }

        public DataTable SearchPhieuNhap(string keyWord)
        {
            PhieuNhapDao phieuNhapDAO = new PhieuNhapDao();
            DataTable dt = phieuNhapDAO.SearchPhieuNhap(keyWord);
            if (phieuNhapDAO.Error != "")
                strError = phieuNhapDAO.Error;
            return dt;
        }

        public bool DeletePhieuNhap(PhieuNhap pn)
        {
            bool blKey = false;
            //if (!HasForeignKey(clsLang.LangID))
            //{
            PhieuNhapDao phieuNhapDAO = new PhieuNhapDao();
            if (phieuNhapDAO.DeletePhieuNhap(pn))
                blKey = true;
            else
                strError = phieuNhapDAO.Error;
            //}
            return blKey;
        }

        public bool SuaPhieuNhap(PhieuNhap pn)
        {
            bool blKey = false;
            PhieuNhapDao phieuNhapDAO = new PhieuNhapDao();
            if (phieuNhapDAO.SuaPhieuNhap(pn))
                blKey = true;
            else
                strError = phieuNhapDAO.Error;
            
            return blKey;
        }

        public int getSLSach(int MSach)
        {
            PhieuNhapDao phieuNhapDAO = new PhieuNhapDao();
            int SLSach = phieuNhapDAO.getSLSach(MSach);
            if (SLSach == 0)
                strError = phieuNhapDAO.Error;
            return SLSach;       
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
