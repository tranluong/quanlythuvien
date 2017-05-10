using QuanLyThuVien.Business;
using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmLoaiSach : Form
    {
        public frmLoaiSach()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }

        private void frmLoaiSach_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            LoaiSachService cls = new LoaiSachService();
            dataGridView1.DataSource = cls.ShowAllLoaiSach();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
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
                txtTenLoaiSach.Text = Convert.ToString(vr.Cells[1].Value);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int intType = cboFilter.SelectedIndex;
            LoaiSachService cls = new LoaiSachService();
            dataGridView1.DataSource = cls.SearchLoaiSach(txtKeyword.Text.Trim(), intType);
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenLoaiSach.Text = txtTenLoaiSach.Text;
            if (txtTenLoaiSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên loại sách", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoaiSach clsLoaiSach = new LoaiSach();
                LoaiSachService clsLoaiSachService = new LoaiSachService();
                clsLoaiSach.TenLoaiSach = txtTenLoaiSach.Text.Trim();
                if (clsLoaiSachService.CreateLoaiSach(clsLoaiSach))
                {
                    dataGridView1.DataSource = clsLoaiSachService.ShowAllLoaiSach();
                    if (clsLoaiSachService.Error != "")
                        MessageBox.Show(clsLoaiSachService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsLoaiSachService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTenLoaiSach.Focus();
            txtTenLoaiSach.SelectAll();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenLoaiSach.Text = txtTenLoaiSach.Text;
                if (txtTenLoaiSach.Text.Trim().Length == 0)
                {
                    MessageBox.Show(" Vui Lòng Điền Tên Loại Sách", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtTenLoaiSach.Text.Trim().Equals(vr.Cells[1].Value.ToString()))
                    {
                        LoaiSach clsLoaiSach = new LoaiSach();
                        clsLoaiSach.TenLoaiSach = txtTenLoaiSach.Text.Trim();
                        clsLoaiSach.MaLoaiSach = Convert.ToInt16(vr.Cells[0].Value);
                        LoaiSachService clsLoaiSachService = new LoaiSachService();
                        if (clsLoaiSachService.UpdateLoaiSach(clsLoaiSach))
                        {
                            dataGridView1.DataSource = clsLoaiSachService.ShowAllLoaiSach();
                            if (clsLoaiSachService.Error != "")
                                MessageBox.Show(clsLoaiSachService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsLoaiSachService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtTenLoaiSach.Focus();
                txtTenLoaiSach.SelectAll();
            }
            catch
            {
                MessageBox.Show(Message.ExceptionError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                int intMaLoaiSach = Convert.ToInt16(vr.Cells[0].Value);
                string strTenLoaiSach = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa loại sách: " + strTenLoaiSach + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoaiSach clsLoaiSach = new LoaiSach();
                    clsLoaiSach.MaLoaiSach = intMaLoaiSach;
                    LoaiSachService clsLoaiSachService = new LoaiSachService();
                    if (clsLoaiSachService.DeleteLoaiSach(clsLoaiSach))
                    {

                        dataGridView1.DataSource = clsLoaiSachService.ShowAllLoaiSach();
                        if (clsLoaiSachService.Error != "")
                            MessageBox.Show(clsLoaiSachService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsLoaiSachService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
