using QuanLyThuVien.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class ConnectSQL : Form
    {
        public ConnectSQL()
        {
            InitializeComponent();
        }
        DBConnection _DBConnection = new DBConnection();

        private void btn_show_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbo_server.Text))
                {
                    MessageBox.Show("Vui lòng nhập Server...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_server.Focus();
                    return;
                }
                string server = cbo_server.Text.Trim();
                cbo_database.Items.Clear();

                using (var con = new SqlConnection("Data Source=" + server + "; Integrated Security=True;"))
                {
                    con.Open();
                    DataTable databases = con.GetSchema("Databases");
                    if (databases != null)
                    {
                        int i = 0;
                        foreach (DataRow database in databases.Rows)
                        {
                            i++;
                            if (i > 6)
                            {
                                String databaseName = database.Field<String>("database_name");
                                short dbID = database.Field<short>("dbid");
                                //DateTime creationDate = database.Field<DateTime>("create_date");
                                cbo_database.Items.Add(databaseName);
                            }
                        }
                    }
                }

                if (cbo_database.Items.Count > 0)
                {
                    cbo_database.SelectedIndex = 0;
                }

            }
            catch
            {
                MessageBox.Show("Không lấy được danh sách CSDL.\nVui lòng kiểm tra lại Server xem đã nhập đúng chưa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_server.Focus();
            }
        }

        private void ConnectSQL_Load(object sender, EventArgs e)
        {
            try
            {
                cbo_server.Items.Clear();
                DataTable dt = _DBConnection.load_server();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cbo_server.Items.Add(dr[0].ToString());
                    }
                }
            }
            catch
            {

            }
            //--------------
            //cbx_auth.SelectedIndex = 0;
            cbo_server.Text = QuanLyThuVien.Properties.Settings.Default.Servername;
            cbo_database.Text = QuanLyThuVien.Properties.Settings.Default.Dataname;
            //cbx_auth.SelectedIndex = Convert.ToInt32(QuanLyThuVien.Properties.Settings.Default.Auth);
            cbx_auth.SelectedIndex = 0;
            if (cbo_server.Items.Count > 0)
                cbo_server.Text = cbo_server.Items[0].ToString();

            if (cbx_auth.SelectedIndex == 0)
            {
                txt_password.Enabled = false;
                txt_user.Enabled = false;
            }
            else
            {
                txt_password.Enabled = true;
                txt_user.Enabled = true;
                txt_user.Text = QuanLyThuVien.Properties.Settings.Default.UserSV;
                txt_password.Text = QuanLyThuVien.Properties.Settings.Default.PassSV;
            }
        }

        private void btn_ketnoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbo_server.Text) || string.IsNullOrEmpty(cbo_database.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin để kết nối...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_server.Focus();
                    return;
                }

                string server = cbo_server.Text.Trim();
                string data = cbo_database.Text.Trim();
                string user = txt_user.Text.Trim();
                string pass = txt_password.Text.Trim();
                string stringcon = "";
                if (cbx_auth.SelectedIndex == 0)
                {
                    stringcon = @"Data Source=" + server + ";Initial Catalog=" + data + ";Integrated Security=True";
                    SqlConnection con = new SqlConnection(stringcon);
                    con.Open();
                    con.Close();
                }
                else if (cbx_auth.SelectedIndex == 1)
                {
                    stringcon = @"Data Source=" + server + "; database=" + data + "; uid=" + user + "; pwd= " + pass + "";
                    SqlConnection con = new SqlConnection(stringcon);
                    con.Open();
                    con.Close();
                }
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                if (cbx_auth.SelectedIndex == 1)
                {
                    MessageBox.Show("Không thể kết nối CSDL.\nVui lòng kiểm tra lại Server xem đã nhập đúng chưa!!!\nVui lòng kiểm tra tài khoản và mật khẩu của SQL đã nhập đúng chưa ?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Không thể kết nối CSDL.\nVui lòng kiểm tra lại Server xem đã nhập đúng chưa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            QuanLyThuVien.Properties.Settings.Default.Servername = "";
            QuanLyThuVien.Properties.Settings.Default.Dataname = "";
            QuanLyThuVien.Properties.Settings.Default.UserSV = "";
            QuanLyThuVien.Properties.Settings.Default.PassSV = "";
            QuanLyThuVien.Properties.Settings.Default.Auth = 0;
            QuanLyThuVien.Properties.Settings.Default.Save();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            txt_password.Text = "";
            cbo_database.Items.Clear();
            cbo_database.Text = "";
            cbo_server.Text = "";
            txt_user.Text = "";
            cbx_auth.SelectedIndex = 0;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbo_server.Text) || string.IsNullOrEmpty(cbo_database.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin để kết nối...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_server.Focus();
                return;
            }
            try
            {
                _DBConnection.Connection(cbo_server.Text.Trim(), cbo_database.Text.Trim(), cbx_auth.SelectedIndex, txt_user.Text.Trim(), txt_password.Text.Trim());
                _DBConnection.OpenDB();
                _DBConnection.CloseDB();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối CSDL!\n Xin kiểm tra lại kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*if (_DBConnection.Connect(cbo_server.Text.Trim(),cbo_database.Text.Trim(),cbx_auth.SelectedIndex,txt_user.Text.Trim(),txt_pass.Text.Trim()))
            {
                MessageBox.Show("Đã thiết lập và lưu kết nối!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kiểm tra lại kết nối của bạn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/
            if (cbx_auth.SelectedIndex == 1 && (txt_user.Text == "" || txt_password.Text == ""))
            {
                MessageBox.Show("Bạn không thể lưu cấu hình!!!\nBạn vui lòng nhập tài khoản và mật khẩu của SQL server để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_user.Focus();
                return;
            }
            QuanLyThuVien.Properties.Settings.Default.Servername = cbo_server.Text.Trim();
            QuanLyThuVien.Properties.Settings.Default.Dataname = cbo_database.Text.Trim();
            QuanLyThuVien.Properties.Settings.Default.UserSV = txt_user.Text.Trim();
            QuanLyThuVien.Properties.Settings.Default.PassSV = txt_password.Text.Trim();
            QuanLyThuVien.Properties.Settings.Default.Auth = cbx_auth.SelectedIndex;
            QuanLyThuVien.Properties.Settings.Default.Save();
            //frmLogin dn = new frmLogin();
            //dn.Show();
            Hide();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbo_server_DropDown(object sender, EventArgs e)
        {
            cbo_database.Items.Clear();

            using (var conn = new SqlConnection("Data Source=" + cbo_server.Text + "; User ID = sa; Password = 123456 ; Integrated Security=True;"))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                DataTable dt = conn.GetSchema("Databases");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        String name = dr.Field<String>("database_name");
                        short db = dr.Field<short>("dbid");

                        cbo_database.Items.Add(name);
                    }
                }
            }
            if (String.IsNullOrEmpty(cbo_server.Text))
            {
                cbo_database.Items.Clear();
            }
        }

       
        private void cbx_auth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_auth.SelectedIndex == 0)
            {
                txt_user.Enabled = false;
                txt_password.Enabled = false;
                labelX4.Enabled = false;
                labelX5.Enabled = false;
            }

            else
            {
                txt_user.Enabled = true;
                txt_password.Enabled = true;
                labelX4.Enabled = true;
                labelX5.Enabled = true;
            }
        }

    }
}
