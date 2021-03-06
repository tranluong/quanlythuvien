using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmCapNhatThuThu : Form
    {
        public frmCapNhatThuThu()
        {
            InitializeComponent();
        }
        //Download source code mien phi tai Sharecode.vn
        private void frmCapNhatThuThu_Load(object sender, EventArgs e)
        {
            cboThuthu.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;
            txtKeyword.Focus();
            ManagerService clsManagerService = new ManagerService();
            dataGridView1.DataSource = clsManagerService.ShowAllManager();            
            if (clsManagerService.Error != "")
                MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Manager clsManager = new Manager();
                clsManager.Name = txtName.Text.Trim();
                clsManager.Username = txtUsername.Text.Trim();
                clsManager.Password = txtPassword.Text.Trim();                
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {                    
                    clsManager.PhanQuyen[i] = Convert.ToByte(checkedListBox1.GetItemCheckState(i) == CheckState.Checked ? 1 : 0);
                }

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
                    dataGridView1.Columns[3].Visible = false;                    
                    if (clsManagerService.Error != "")
                        MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            return true;
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
                for (int i = 3; i <= 13; i++)
                    dataGridView1.Columns[i].Visible = false;
            lblRowCount.Text = "Kết quả có " + dataGridView1.RowCount + " mẫu tin";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //if (txtKeyword.Text != "")
            //{
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
            //}
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
        private void FillForm(DataGridViewRow vr)
        {
            try
            {
                txtName.Text = Convert.ToString(vr.Cells[1].Value);
                txtUsername.Text = Convert.ToString(vr.Cells[2].Value);
                txtPassword.Text = Convert.ToString(vr.Cells[3].Value);
                for (int i = 0, j = 4; i < 10; i++)
                {
                    checkedListBox1.SetItemChecked(i, (Convert.ToByte(vr.Cells[j++].Value) == 1 ? true : false));                
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
            dataGridView1.DataSource = null;            
            txtName.Focus();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Manager clsManager = new Manager();
                clsManager.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                clsManager.Name = txtName.Text.Trim();
                clsManager.Username = txtUsername.Text.Trim();
                clsManager.Password = txtPassword.Text.Trim();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    clsManager.PhanQuyen[i] = Convert.ToByte(checkedListBox1.GetItemCheckState(i) == CheckState.Checked ? 1 : 0);
                }

                ManagerService clsManagerService = new ManagerService();
                if (!clsManagerService.UpdateManager(clsManager))
                {
                    MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                }
                else
                {
                    dataGridView1.DataSource = clsManagerService.SearchManager(0, clsManager.Username, 1);
                    dataGridView1.Columns[3].Visible = false;
                    if (clsManagerService.Error != "")
                        MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }
    }
}