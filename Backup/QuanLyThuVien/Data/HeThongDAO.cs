using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyThuVien
{
    class HeThongDAO
    {
        //Hàm lấy thông tin quy định
        public object[] GetParam()
        {
            string strSQL = "select * from tblQuyDinh";            
            Database cls = new Database();
            object[] obj = null;
            try
            {
                obj = cls.ReadData(strSQL);
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return obj;
        }
        //Hàm thay đổi quy định
        public bool ChangeParam(HeThong clsSystem)
        {
            bool blKey = false;
            string strSQL = "update tblQuyDinh set ";
            strSQL += "SoTienDatCoc=@SoTienDatCoc";
            strSQL += ",SoNgayMuonVe=@SoNgayMuonVe";
            strSQL += ",SoTienPhatTreHanVe=@SoTienPhatTreHanVe";
            strSQL += ",SoTienPhatTreHanTaiCho=@SoTienPhatTreHanTaiCho";
            strSQL += ",SoCuonMuonVe=@SoCuonMuonVe";
            strSQL += ",SoCuonMuonTaiCho=@SoCuonMuonTaiCho";
            strSQL += ",SoCuonMuonGVBC=@SoCuonMuonGVBC";
            strSQL += ",SoNgayThanhLyBao=@SoNgayThanhLyBao";
            strSQL += ",SoNgayThanhLyTapchi=@SoNgayThanhLyTapchi";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SoTienDatCoc",clsSystem.SoTienDatCoc);            
            cmd.Parameters.AddWithValue("@SoNgayMuonVe",clsSystem.SoNgayMuonVe);
            cmd.Parameters.AddWithValue("@SoTienPhatTreHanVe",clsSystem.SoTienPhatTreHanVe);
            cmd.Parameters.AddWithValue("@SoTienPhatTreHanTaiCho",clsSystem.SoTienPhatTreHanTaiCho);
            cmd.Parameters.AddWithValue("@SoCuonMuonVe",clsSystem.SoCuonMuonVe);
            cmd.Parameters.AddWithValue("@SoCuonMuonTaiCho",clsSystem.SoCuonMuonTaiCho);
            cmd.Parameters.AddWithValue("@SoCuonMuonGVBC",clsSystem.SoCuonMuonGVBC);
            cmd.Parameters.AddWithValue("@SoNgayThanhLyBao",clsSystem.SoNgayThanhLyBao);
            cmd.Parameters.AddWithValue("@SoNgayThanhLyTapchi",clsSystem.SoNgayThanhLyTapchi);
            Database cls = new Database();
            try
            {
                if (cls.Update(strSQL, CommandType.Text, cmd))
                    blKey = true;
                else
                    if (cls.Error != "")
                        strError = cls.Error;
                    else
                        strError = "Cập nhật quy định thất bại";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Sao lưu
        public bool Backup(string strDatabaseName, string strPath)
        {
            bool blKey = false;
            string strSQL = "BACKUP DATABASE @DatabaseName";
            strSQL += " TO DISK = @Path";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DatabaseName", strDatabaseName);
            cmd.Parameters.AddWithValue("@Path", strPath);
            Database cls = new Database();
            try
            {
                if (cls.Update(strSQL, CommandType.Text, cmd))
                    blKey = true;
                else
                    if (cls.Error != "")
                        strError = cls.Error;
                    else
                        strError = "Sao lưu dữ liệu thất bại";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return blKey;
        }
        //Sao lưu
        public bool Restore(string strDatabaseName, string strPath)
        {
            bool blKey = false;
            string strSQL = "RESTORE DATABASE @DatabaseName";
            strSQL += " FROM DISK = @Path";
            strSQL += " WITH REPLACE,";
            strSQL += " MOVE 'thuvien_Data' TO @PathData,";
            strSQL += " MOVE 'thuvien_Log' TO @PathLog";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DatabaseName", strDatabaseName);
            cmd.Parameters.AddWithValue("@Path", strPath);
            cmd.Parameters.AddWithValue("@PathData", strPath.Remove(strPath.Length - 4) + "_Data.mdf");
            cmd.Parameters.AddWithValue("@PathLog", strPath.Remove(strPath.Length - 4) + "_Log.ldf");
            Database cls = new Database();
            try
            {
                if (cls.Update(strSQL, CommandType.Text, cmd))
                    blKey = true;
                else
                    if (cls.Error != "")
                        strError = cls.Error;
                    else
                        strError = "Phục hồi dữ liệu thất bại";
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
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
