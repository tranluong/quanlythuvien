using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmTimTaiLieu : Form
    {
        public frmTimTaiLieu()
        {
            InitializeComponent();
        }
        private void FillFormSach(DataGridViewRow vr)
        {
            try
            {

                txtMaSach.Text = vr.Cells[0].Value.ToString();
                txtTenSach.Text = vr.Cells[1].Value.ToString();

                txtTacGia.Text = vr.Cells["TacGia"].Value.ToString();
                txtSoLuong.Text = vr.Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = vr.Cells["DonGia"].Value.ToString();
                txtTomTat.Text = vr.Cells["NoiDungTomTat"].Value.ToString();
                txtNgonNgu.Text = vr.Cells["NgonNgu"].Value.ToString();
                cboLoaiSach.Text = vr.Cells["MaLoaiSach"].Value.ToString();
                txtNXB.Text = vr.Cells["TenNXB"].Value.ToString();
                int intMaSach = Convert.ToInt32(vr.Cells["MaSach"].Value);
                BookService cls = new BookService();
                dataGridView7.DataSource = cls.ShowAllDBook(intMaSach);
                dataGridView2.DataSource = cls.ShowAuthor(intMaSach);
                Book clsBook = cls.Stat(intMaSach);
                txtTongSL.Text = clsBook.TongDauSach.ToString();
                txtSLHong.Text = clsBook.SLHong.ToString();
                txtSLMat.Text = clsBook.SLMat.ToString();
                txtSLSachMuon.Text = clsBook.SLMuon.ToString();
                txtSLSachCon.Text = clsBook.SLCon.ToString();
                DataTable dt = cls.ShowAuthor(intMaSach);
                if (dt.Rows.Count != 0)
                {
                    dataGridView2.DataSource = dt;
                    //dataGridView2.Columns[0].Visible = false;
                }
                ReportService clsR = new ReportService();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int intType;
        public int intFilter;
        public string strKeyword = "";
        private void frmTimTaiLieu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thuvienDataSet.tblLoaiSach' table. You can move, or remove it, as needed.
            this.tblLoaiSachTableAdapter.Fill(this.thuvienDataSet.tblLoaiSach);
            // TODO: This line of code loads data into the 'thuvienDataSet.tblNXB' table. You can move, or remove it, as needed.
            this.tblNXBTableAdapter.Fill(this.thuvienDataSet.tblNXB);
            txtKeyword1.Focus();
            if (strKeyword != "")
            {
                BookService cls = new BookService();
                dataGridView9.DataSource = cls.FindBook(intType, strKeyword, intFilter);
                if (cls.Error != "")
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKeyword1.Focus();
                    txtKeyword1.SelectAll();
                }
                else
                    dataGridView9.Focus();
            }
        }
        //Fill form tập
        private void FillFormTap(DataGridViewRow vr)
        {
            try
            {                
                //txtDonGia.Text = vr.Cells["DonGia"].Value.ToString();
                //txtTenDauSach.Text = vr.Cells["TenDauSach"].Value.ToString();
                int intMaSach = Convert.ToInt32(vr.Cells["MaSach"].Value);
                BookService cls = new BookService();
                //DataTable dt = cls.ShowAuthorDauSach(intMaSach);
                //dataGridView2.DataSource = dt;
                Book clsBook = cls.Stat(intMaSach);
                txtTongSL.Text = clsBook.TongDauSach.ToString();
                txtSLHong.Text = clsBook.SLHong.ToString();
                txtSLMat.Text = clsBook.SLMat.ToString();
                txtSLSachMuon.Text = clsBook.SLMuon.ToString();
                txtSLSachCon.Text = clsBook.SLCon.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView9_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCountSach.Text = "Kết quả có " + dataGridView9.RowCount + " mẫu tin";
        }

        private void dataGridView9_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView9.CurrentRow;
            if (vr != null)
            {
                FillFormSach(vr);
            }
            else
            {
                txtKeyword1.Focus();
                txtKeyword1.SelectAll();
                dataGridView7.DataSource = null;
            }
        }

        private void dataGridView7_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView7.CurrentRow;
            if (vr != null)
            {
                FillFormTap(vr);
            }
            else
            {
                txtKeyword1.Focus();
                txtKeyword1.SelectAll();
                txtTenSach.Text = "";
            }
        }

        private void txtTongSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSLHong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSLMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSLSachMuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSLSachCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtMaSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void dataGridView7_DataSourceChanged(object sender, EventArgs e)
        {
            groupBox14.Text = "(" + dataGridView7.RowCount.ToString() + " đầu sách)";
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            if (txtKeyword1.Text != "")
            {
                int intType = cboSach1.SelectedIndex;
                int intFilter = cboFilter1.SelectedIndex;
                BookService cls = new BookService();
                dataGridView9.DataSource = cls.FindBook(intType, txtKeyword1.Text.Trim(), intFilter);
                if (cls.Error != "")
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKeyword1.Focus();
                    txtKeyword1.SelectAll();
                }
                else
                    dataGridView9.Focus();
            }
        }

        private void btnDongSach_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}