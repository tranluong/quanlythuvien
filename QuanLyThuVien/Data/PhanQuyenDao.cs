using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Data
{
    class PhanQuyenDao
    {
        public bool IsExistID(string intMaPQ)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblPhanQuyen where MaPQ=@MaPQ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPQ", intMaPQ);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                strError = "Mã quyền này đã tồn tại";
            else
                blIsExist = false;
            return blIsExist;
        }
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
        public bool CreatePhanQuyen(PhanQuyen clsPhanQuyen)
        {
            bool blKey = false;
            string strsQL = "insert into tblPhanQuyen(MuonTra, ChangePass, CapNhatSach, CapNhatDocGia, Baocao, BackupData, RestoreData, CapNhatThuThu) values(@MuonTra, @ChangePass, @CapNhatSach, @CapNhatDocGia, @Baocao, @BackupData,@RestoreData,@CapNhatThuThu)";
                //" insert into tblPhanQuyen values()";
            SqlCommand cmd = new SqlCommand();
           // cmd.Parameters.AddWithValue("@MaPQ", clsPhanQuyen.MaPQ);
            cmd.Parameters.AddWithValue("@ChangePass", clsPhanQuyen.PhanQuyen1[1]);
            cmd.Parameters.AddWithValue("@BackupData", clsPhanQuyen.PhanQuyen1[5]);
            cmd.Parameters.AddWithValue("@RestoreData", clsPhanQuyen.PhanQuyen1[6]);
            cmd.Parameters.AddWithValue("@CapNhatSach", clsPhanQuyen.PhanQuyen1[2]);
            cmd.Parameters.AddWithValue("@CapNhatDocGia", clsPhanQuyen.PhanQuyen1[3]);
            cmd.Parameters.AddWithValue("@CapNhatThuThu", clsPhanQuyen.PhanQuyen1[7]);
            cmd.Parameters.AddWithValue("@MuonTra", clsPhanQuyen.PhanQuyen1[0]);
            cmd.Parameters.AddWithValue("@BaoCao", clsPhanQuyen.PhanQuyen1[4]);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Thêm quyền thất bại";
            return blKey;
        }
        public DataTable ShowAllQuyen()
        {
            string strSQL = "select MaPQ, MuonTra as 'Menu Xử Lý', ChangePass as 'Đổi Mật Khẩu', CapNhatSach as 'Menu Sách', CapNhatDocGia as 'Độc giả', Baocao as 'Menu Báo Cáo', BackupData as 'Sao Lưu', RestoreData as 'Phục Hồi', CapNhatThuThu as 'Thủ Thư' from tblPhanQuyen order by MaPQ Desc";
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
        public bool DeletePhanQuyen(PhanQuyen clsPQ)
        {
            bool blKey = false;
            string strsQL = "delete from tblPhanQuyen where MaPQ =" + clsPQ.MaPQ;
            Database cls = new Database();
            if (cls.Update(strsQL))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Xóa quyền thất bại";
            return blKey;
        }
        public bool HasForeignKey(int intMaLDG)
        {
            bool blKey = true;
            string strSQL = "select * from tblPhanQuyen PQ, tblNhanVien NV where PQ.MaPQ=NV.MaPQ and PQ.MaPQ=" + intMaLDG;
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                else
                    if (dt.Rows.Count != 0)
                    strError = "Mã quyền này đang được sử dụng, không thể xóa !";

                else
                    blKey = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        public bool IsExistNameWhileUpdate(PhanQuyen clsLDG)
        {
            bool blIsExist = true;
            string strSQL = "select * from tblPhanQuyen where  MaPQ!=@MaPQ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPQ", clsLDG.MaPQ);
            Database cls = new Database();
            DataTable dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
            if (cls.Error != "")
                strError = cls.Error;
            else
                if (dt.Rows.Count != 0)
                strError = "Quyền này đã tồn tại";

            else
                blIsExist = false;
            return blIsExist;
        }
        public bool UpdatePhanQuyen(PhanQuyen clsPhanQuyen)
        {         
            bool blKey = false;
            string strsQL = "update tblPhanQuyen set ChangePass=@ChangePass,BackupData=@BackupData,RestoreData=@RestoreData,";
            strsQL+=" CapNhatSach=@CapNhatSach, CapNhatDocGia=@CapNhatDocGia,CapNhatThuThu=@CapNhatThuThu,MuonTra=@Muontra,BaoCao=@BaoCao where MaPQ =@MaPQ";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaPQ", clsPhanQuyen.MaPQ);
            cmd.Parameters.AddWithValue("@ChangePass", clsPhanQuyen.PhanQuyen1[1]);
            cmd.Parameters.AddWithValue("@BackupData", clsPhanQuyen.PhanQuyen1[5]);
            cmd.Parameters.AddWithValue("@RestoreData", clsPhanQuyen.PhanQuyen1[6]);
            cmd.Parameters.AddWithValue("@CapNhatSach", clsPhanQuyen.PhanQuyen1[2]);
            cmd.Parameters.AddWithValue("@CapNhatDocGia", clsPhanQuyen.PhanQuyen1[3]);
            cmd.Parameters.AddWithValue("@CapNhatThuThu", clsPhanQuyen.PhanQuyen1[7]);
            cmd.Parameters.AddWithValue("@MuonTra", clsPhanQuyen.PhanQuyen1[0]);
            cmd.Parameters.AddWithValue("@BaoCao", clsPhanQuyen.PhanQuyen1[4]);
            Database cls = new Database();
            if (cls.Update(strsQL, CommandType.Text, cmd))
                blKey = true;
            else
                if (cls.Error != "")
                strError = cls.Error;
            else
                strError = "Cập nhật quyền thất bại";
            return blKey;
        }
    }
}
