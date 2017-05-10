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
    public partial class frmLoaiDocGia : Form
    {
        public frmLoaiDocGia()
        {
            InitializeComponent();
        }

        private void frmLoaiDocGia_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            LoaiDocGiaService cls = new LoaiDocGiaService();
            dataGridView1.DataSource = cls.ShowAllLoaiDocGia();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
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
                txtTenLoaiDocGia.Text = Convert.ToString(vr.Cells[1].Value);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int intType = cboFilter.SelectedIndex;
            LoaiDocGiaService cls = new LoaiDocGiaService();
            dataGridView1.DataSource = cls.SearchLoaiDocGia(txtKeyword.Text.Trim(), intType);
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenLoaiDocGia.Text = txtTenLoaiDocGia.Text;
            if (txtTenLoaiDocGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên nhà xuất bản", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoaiDocGia clsLDG = new LoaiDocGia();
                LoaiDocGiaService clsLDGService = new LoaiDocGiaService();
                clsLDG.TenLoaiDG = txtTenLoaiDocGia.Text.Trim();
                if (clsLDGService.CreateLoaiDocGia(clsLDG))
                {
                    dataGridView1.DataSource = clsLDGService.ShowAllLoaiDocGia();
                    if (clsLDGService.Error != "")
                        MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTenLoaiDocGia.Focus();
            txtTenLoaiDocGia.SelectAll();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenLoaiDocGia.Text = txtTenLoaiDocGia.Text;
                if (txtTenLoaiDocGia.Text.Trim().Length == 0)
                {
                    MessageBox.Show(" Vui lòng điền tên độc giả", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtTenLoaiDocGia.Text.Trim().Equals(vr.Cells[1].Value.ToString()))
                    {
                        LoaiDocGia clsLDG = new LoaiDocGia();
                        clsLDG.TenLoaiDG = txtTenLoaiDocGia.Text.Trim();
                        clsLDG.MaLoaiDG = Convert.ToInt16(vr.Cells[0].Value);
                        LoaiDocGiaService clsLDGService = new LoaiDocGiaService();
                        if (clsLDGService.UpdateLoaiDocGia(clsLDG))
                        {
                            dataGridView1.DataSource = clsLDGService.ShowAllLoaiDocGia();
                            if (clsLDGService.Error != "")
                                MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtTenLoaiDocGia.Focus();
                txtTenLoaiDocGia.SelectAll();
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
                int intMaLDG = Convert.ToInt16(vr.Cells[0].Value);
                string strTenLDG = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa loại độc giả: " + strTenLDG + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoaiDocGia clsLDG = new LoaiDocGia();
                    clsLDG.MaLoaiDG = intMaLDG;
                    LoaiDocGiaService clsLDGService = new LoaiDocGiaService();
                    if (clsLDGService.DeleteLoaiDocGia(clsLDG))
                    {

                        dataGridView1.DataSource = clsLDGService.ShowAllLoaiDocGia();
                        if (clsLDGService.Error != "")
                            MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
