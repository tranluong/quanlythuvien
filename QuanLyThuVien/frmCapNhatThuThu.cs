using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmCapNhatThuThu : Form
    {
        public frmCapNhatThuThu()
        {
            InitializeComponent();
            AcceptButton = btnTim;
            CancelButton = btnDong;
        }

        private void frmCapNhatThuThu_Load(object sender, EventArgs e)
        {
            cboThuthu.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;
            //txtPhanQuyen.SelectedIndex = 0;
            txtKeyword.Focus();
            ManagerService clsManagerService = new ManagerService();
            dataGridView1.DataSource = clsManagerService.ShowAllManager();
            if (clsManagerService.Error != "")
                MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Kiểm tra rỗng
        private string strError = "";
        private bool Validation()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                strError = "Nhập tên Thủ thư";
                txtName.Focus();
                return false;
            }
            if (txtUsername.Text.Trim().Length == 0)
            {
                strError = "Nhập tên đăng nhập";
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                strError = "Nhập mật khẩu";
                txtPassword.Focus();
                return false;
            }
            if (DateTime.Today.Year - dtNgaySinh.Value.Year < 18)
            {
                strError = "Ngày sinh không hợp lệ (số tuổi phải lớn hơn 15)";
                dtNgaySinh.Focus();
                return false;
            }
            if (txtSDT.TextLength < 7 || txtSDT.TextLength > 12)
            {
                strError = "Số Điện Thoại Không Hợp Lệ";
                txtSDT.Focus();
                return false;
            }
            if (txtEmail.Text.Trim().Length > 0)
            {
                Regex rEMail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    strError = "Email Không Hợp Lệ";
                    txtEmail.Focus();
                    return false;
                }
            }
            else
            {
                strError = "Không được bỏ trống email";
                txtSDT.Focus();
                return false;
            }
            if (Convert.ToInt16(txtPhanQuyen.Text.Trim().Length) == 0)
            {
                strError = "Không được bỏ trống phân quyền";
                txtPhanQuyen.Focus();
                return false;
            }
            if (txtEmail.Text.Trim().Length != 0)
            {
                string test = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";
                return Regex.IsMatch(txtEmail.Text, test);
            }

            return true;
        }

        private void FillForm(DataGridViewRow vr)
        {
            Manager cls = new Manager();
            try
            {
                txtNhanVien.Text = Convert.ToString(vr.Cells[0].Value);
                txtName.Text = Convert.ToString(vr.Cells[1].Value);
                txtUsername.Text = Convert.ToString(vr.Cells[2].Value);
                txtPassword.Text = Convert.ToString(vr.Cells[3].Value);
                dtNgaySinh.Value = Convert.ToDateTime(vr.Cells[4].Value);
                if (Convert.ToString(vr.Cells[5].Value) == "Nam")
                    rdaNam.Checked = true;
                else
                    rdaNu.Checked = true;
                txtPhanQuyen.Text = Convert.ToString(vr.Cells[8].Value);
                txtSDT.Text = Convert.ToString(vr.Cells[6].Value);            
                txtEmail.Text = Convert.ToString(vr.Cells[7].Value);        
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                string strReaderName = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa thủ thư: " + strReaderName + " ? Chú ý: sau khi xóa thông tin do thủ thư này cập nhật sẽ không còn !", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Manager clsManager = new Manager();
                    clsManager.ID = Convert.ToInt16(vr.Cells[0].Value);
                    ManagerService clsManagerService = new ManagerService();
                    if (clsManagerService.DeleteManager(clsManager))
                    {
                        dataGridView1.DataSource = clsManagerService.SearchManager(cboThuthu.SelectedIndex, txtKeyword.Text, cboFilter.SelectedIndex);
                        if (clsManagerService.Error != "")
                            MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ManagerService cls = new ManagerService();
            dataGridView1.DataSource = cls.ShowAllManager();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                Manager clsManager = new Manager();
                clsManager.ID = Convert.ToInt16(txtNhanVien.Text.Trim());               
                clsManager.Name = txtName.Text.Trim();
                clsManager.Username = txtUsername.Text.Trim();
                clsManager.Password = txtPassword.Text.Trim();
                clsManager.NgaySinh = dtNgaySinh.Value.Date;
                clsManager.GioiTinh = Convert.ToByte(rdaNam.Checked == true ? 1 : 0);
                clsManager.SoDT = txtSDT.Text.Trim();
                clsManager.Email = txtEmail.Text.Trim();
                clsManager.MaPQ = Convert.ToInt16(txtPhanQuyen.Text.Trim());
                ManagerService clsManagerService = new ManagerService();
                DataGridViewRow vr = dataGridView1.CurrentRow;
                string strManagerID = Convert.ToString(vr.Cells[0].Value);
                if (clsManagerService.UpdateManager(strManagerID, clsManager))
                {
                    dataGridView1.DataSource = clsManagerService.SearchManager(0, Convert.ToString(clsManager.ID), 1);
                    if (clsManagerService.Error != "")
                        MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ManagerService cls= new ManagerService();
            dataGridView1.DataSource = cls.ShowAllManager();
            txtUsername.Focus();
            txtUsername.SelectAll();
        }
            

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Manager clsManager = new Manager();
                //clsManager.ID = Convert.ToInt32(txtNhanVien.Text.Trim());
                clsManager.Name = txtName.Text.Trim();
                clsManager.Username = txtUsername.Text.Trim();
                clsManager.Password = txtPassword.Text.Trim();
                clsManager.NgaySinh = Convert.ToDateTime(dtNgaySinh.Value.Date);
                clsManager.GioiTinh = Convert.ToByte(rdaNam.Checked == true ? 1 : 0);
                clsManager.SoDT = txtSDT.Text.Trim();
                clsManager.Email = txtEmail.Text.Trim();
                clsManager.MaPQ = Convert.ToInt16(txtPhanQuyen.Text);
                ManagerService clsManagerService = new ManagerService();
                if (!clsManagerService.CreateManager(clsManager))
                {
                    MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                }
                else
                {
                    dataGridView1.DataSource = clsManagerService.SearchManager(0, clsManager.Username, 1);
                    //dataGridView1.Columns[3].Visible = false;
                    if (clsManagerService.Error != "")
                        MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ManagerService cls = new ManagerService();
                dataGridView1.DataSource = cls.ShowAllManager();
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            dtNgaySinh.Value = DateTime.Today;
            rdaNam.Checked = true;
            txtSDT.Text = "";
            txtEmail.Text = "";
            //txtPhanQuyen.SelectedIndex = 0;
            dataGridView1.DataSource = null;
            txtName.Focus();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int intFilter = cboFilter.SelectedIndex;
            int intType = cboThuthu.SelectedIndex;
            ManagerService cls = new ManagerService();
            dataGridView1.DataSource = cls.SearchManager(intType, txtKeyword.Text.Trim(), intFilter);
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.DataSource != null)
            //{
            //    for (int i = 8; i <= 15; i++)
            //        dataGridView1.Columns[i].Visible = false;
            //}
            //lblRowCount.Text = "Kết quả có " + dataGridView1.RowCount + " mẫu tin";
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (vr == null)
            {
                btnXoa.Enabled = false;
                btnCapnhat.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
                btnCapnhat.Enabled = true;
                FillForm(vr);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.Show();
        }
    }
}