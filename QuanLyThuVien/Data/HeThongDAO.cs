using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyThuVien
{
    class HeThongDAO
    {
       
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
