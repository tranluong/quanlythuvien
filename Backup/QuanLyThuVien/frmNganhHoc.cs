using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmNganhHoc : Form
    {
        public frmNganhHoc()
        {
            InitializeComponent();
        }
        //Download source code mien phi tai Sharecode.vn
        private void frmNganhHoc_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            NganhHocService cls = new NganhHocService();
            dataGridView1.DataSource = cls.ShowAllNganh();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
        }


      
        //Fill
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
                txtTenNganh.Text = Convert.ToString(vr.Cells[1].Value);
            }
        }
     
           
        
       //Hiển thị kết quả số mẫu tin ở status
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }

        //Xoá
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                int intMaNganh = Convert.ToInt16(vr.Cells[0].Value);
                string strTenNganh = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa ngành: " + strTenNganh + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NganhHoc clsNganh = new NganhHoc();
                    clsNganh.MaNganh = intMaNganh;
                    NganhHocService clsNganhService = new NganhHocService();
                    if (clsNganhService.DeleteNganh(clsNganh))
                    {
                        dataGridView1.DataSource = clsNganhService.ShowAllNganh();
                        if (clsNganhService.Error != "")
                            MessageBox.Show(clsNganhService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsNganhService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        //Cập nhật
        private void btnCapnhat_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtTenNganh.Text = txtTenNganh.Text;
                if (txtTenNganh.Text.Trim().Length == 0)
                {
                    MessageBox.Show(MessageLanguage.IsEmpty, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtTenNganh.Text.Trim().Equals(vr.Cells[1].Value.ToString()))
                    {
                        NganhHoc clsNganh = new NganhHoc();
                        clsNganh.TenNganh = txtTenNganh.Text.Trim();
                        clsNganh.MaNganh = Convert.ToInt16(vr.Cells[0].Value);
                        NganhHocService clsNganhService = new NganhHocService();
                        if (clsNganhService.UpdateNganh(clsNganh))
                        {
                            dataGridView1.DataSource = clsNganhService.ShowAllNganh();
                            if (clsNganhService.Error != "")
                                MessageBox.Show(clsNganhService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsNganhService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtTenNganh.Focus();
                txtTenNganh.SelectAll();
            }
            catch
            {
                MessageBox.Show(Message.ExceptionError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Thêm
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            txtTenNganh.Text = txtTenNganh.Text;
            if (txtTenNganh.Text.Trim().Length == 0)
            {
                
                MessageBox.Show("Nhập tên ngành", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NganhHoc clsNganh = new NganhHoc();
                NganhHocService clsNganhService = new NganhHocService();
                clsNganh.TenNganh = txtTenNganh.Text.Trim();
                if (clsNganhService.CreateNganh(clsNganh))
                {
                    dataGridView1.DataSource = clsNganhService.ShowAllNganh();
                    if (clsNganhService.Error != "")
                        MessageBox.Show(clsNganhService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsNganhService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTenNganh.Focus();
            txtTenNganh.SelectAll();
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {            
            this.Close();
        }

        //Tìm
        private void btnTim_Click_1(object sender, EventArgs e)
        {
            int intType = cboFilter.SelectedIndex;
            NganhHocService cls = new NganhHocService();
            dataGridView1.DataSource = cls.SearchNganh(txtKeyword.Text.Trim(), intType);
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
        }
    }
}
