using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmNhaXB : Form
    {
        public frmNhaXB()
        {
            InitializeComponent();
        }

        private void frmNhaXB_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            btnThem.Enabled = false;
            NhaXBService cls = new NhaXBService();
            dataGridView1.DataSource = cls.ShowAllNhaXB();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                int intMaNXB = Convert.ToInt16(vr.Cells[0].Value);
                string strTenNXB = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa nhà xuất bản: " + strTenNXB + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhaXB clsNXB = new NhaXB();
                    clsNXB.MaNXB = intMaNXB;
                    NhaXBService clsNhaXBService = new NhaXBService();
                    if (clsNhaXBService.DeleteNhaXB(clsNXB))
                    {

                        dataGridView1.DataSource = clsNhaXBService.ShowAllNhaXB();
                        if (clsNhaXBService.Error != "")
                            MessageBox.Show(clsNhaXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsNhaXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                //txtTenNXB.Text = txtTenNXB.Text;
                //txtDiaChi.Text = txtTenNXB.Text;
                if (txtTenNXB.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập tên nhà xuất bản và địa chỉ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtTenNXB.Text.Trim().Equals(vr.Cells[1].Value.ToString()))
                    {
                        NhaXB clsNXB = new NhaXB();
                        clsNXB.DiaChiNXB = txtDiaChi.Text.Trim();
                        clsNXB.TenNXB = txtTenNXB.Text.Trim();
                        clsNXB.MaNXB = Convert.ToInt16(vr.Cells[0].Value);
                        NhaXBService clsNXBService = new NhaXBService();
                        if (clsNXBService.UpdateNhaXB(clsNXB))
                        {
                            MessageBox.Show("Cập nhật thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = clsNXBService.ShowAllNhaXB();
                            if (clsNXBService.Error != "")
                                MessageBox.Show(clsNXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsNXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtTenNXB.Focus();
                txtDiaChi.Focus();
                txtTenNXB.SelectAll();
                txtDiaChi.SelectAll();
            }
            catch
            {
                MessageBox.Show(Message.ExceptionError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenNXB.Text = txtTenNXB.Text;
            if (txtTenNXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên nhà xuất bản", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NhaXB clsNXB = new NhaXB();
                NhaXBService clsNhaXBService = new NhaXBService();
                clsNXB.TenNXB = txtTenNXB.Text.Trim();
                clsNXB.DiaChiNXB = txtDiaChi.Text.Trim();
                if (clsNhaXBService.CreateNhaXB(clsNXB))
                {
                    MessageBox.Show("Thêm thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = clsNhaXBService.ShowAllNhaXB();
                    if (clsNhaXBService.Error != "")
                        MessageBox.Show(clsNhaXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsNhaXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTenNXB.Focus();
            txtDiaChi.Focus();
            txtTenNXB.SelectAll();
            txtDiaChi.SelectAll();
            btnXoa.Enabled = true;
            btnCapnhat.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int intType = cboFilter.SelectedIndex;
            NhaXBService cls = new NhaXBService();
            dataGridView1.DataSource = cls.SearchNhaXB(txtKeyword.Text.Trim(), intType);
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
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
                txtTenNXB.Text = Convert.ToString(vr.Cells[1].Value);
                txtDiaChi.Text = Convert.ToString(vr.Cells[2].Value);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnCapnhat.Enabled = false;
        }

      

    }
}