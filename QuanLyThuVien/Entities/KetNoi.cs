using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Entities
{
    class KetNoi
    {
        SqlConnection conn;

        // mở kết nối

        public void connect()

        {

            if (conn == null)

                conn = new SqlConnection(@"Data Source=LUONG\SQLEXPRESS;Initial Catalog=thuvien;Persist Security Info=True;User ID=sa;Password=123456");


            if (conn.State == ConnectionState.Closed)

                conn.Open();

        }

        // đóng kết nối

        public void disconnect()

        {

            if ((conn != null) && (conn.State == ConnectionState.Open))

                conn.Close();

        }

        // trả về một DataTable .

        public DataTable getDataTable(string sql)

        {

            connect();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            disconnect();

            return dt;

        }
    }
}
