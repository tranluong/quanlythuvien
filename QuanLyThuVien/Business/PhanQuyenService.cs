using QuanLyThuVien.Data;
using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Business
{
    class PhanQuyenService
    {
        public bool CreatePhanQuyen(PhanQuyen clsPhanQuyen)
        {
            bool blKey = false;
            PhanQuyenDao clsPhanQuyenDAO = new PhanQuyenDao();
            if (clsPhanQuyenDAO.IsExistID(Convert.ToString(clsPhanQuyen.MaPQ)))
                strError = clsPhanQuyenDAO.Error;
            else
            {
                if (clsPhanQuyenDAO.CreatePhanQuyen(clsPhanQuyen))
                    blKey = true;
                else
                    strError = clsPhanQuyenDAO.Error;
            }
            return blKey;
        }
        public DataTable SearchPhanQuyen(int intType, string strKeyword, int intFilter)
        {
            string strSQL = "";
            if (intType == 0)
                if (intFilter == 0)
                    strSQL = "select *  from tblPhanQuyen  where  MaPQ like '%'+@Keyword+'%' ";
                else
                    strSQL = "select * from tblPhanQuyen where  MaPQ like @Keyword ";
            else
                if (intFilter == 0)
                strSQL = "select *  from tblPhanQuyen where  MaPQ like '%'+@Keyword+'%' ";
            else
                strSQL = "select * from tblPhanQuyen where  MaPQ like @Keyword ";
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
        public DataTable ShowAllQuyen()
        {
            PhanQuyenDao clsPhanQuyenDAO = new PhanQuyenDao();
            DataTable dt = clsPhanQuyenDAO.ShowAllQuyen();
            if (clsPhanQuyenDAO.Error != "")
                strError = clsPhanQuyenDAO.Error;

            return dt;
        }
        public bool DeletePhanQuyen(PhanQuyen clsPQ)
        {
            bool blKey = false;
            PhanQuyenDao clsLDGDAO = new PhanQuyenDao();
            if (clsLDGDAO.HasForeignKey(clsPQ.MaPQ))
                strError = clsLDGDAO.Error;
            else
            {
                if (clsLDGDAO.DeletePhanQuyen(clsPQ))
                    blKey = true;
                else
                    strError = clsLDGDAO.Error;
            }
            return blKey;
        }
        public bool UpdatePhanQuyen(PhanQuyen clsLDG)
        {
            bool blKey = false;
            PhanQuyenDao clsLDGDAO = new PhanQuyenDao();
            //if (clsLDGDAO.IsExistNameWhileUpdate(clsLDG))
            //    strError = clsLDGDAO.Error;
            //else
            //{
                if (clsLDGDAO.UpdatePhanQuyen(clsLDG))
                    blKey = true;
                else
                    strError = clsLDGDAO.Error;
            //}
            return blKey;
        }
        private string strError = "";
        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }
    }
}
