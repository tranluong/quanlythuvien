using QuanLyThuVien.Business;
using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmCapNhatSach : Form
    {
        public frmCapNhatSach()
        {
            InitializeComponent();            
        }
        DataTable dt = new DataTable();

        private DataTable dtTap = new DataTable();
        //Form load
        private void frmCapNhatSach_Load(object sender, EventArgs e)
        {
            LoaiSachService loaiSachService = new LoaiSachService();
            cboLoaiSach.DataSource = new DataView(loaiSachService.ShowAllLoaiSach());
            cboLoaiSach.DisplayMember = "Tên Loại Sách";
            cboLoaiSach.ValueMember = "Mã Loại Sách";
            cboLoaiSach.SelectedIndex = 0;

            BookService clsBookService = new BookService();
            dataGridView10.DataSource = clsBookService.ShowAllBook();
            //Tab 3
            cboTab3Sach.SelectedIndex = 0;
            //Fill vào combobox nhà xuất bản
            NhaXBService cls3 = new NhaXBService();
            cboNXB3.DataSource = new DataView(cls3.ShowAllNhaXB());
            cboNXB3.DisplayMember = "Tên Nhà XB";
            cboNXB3.ValueMember = "Mã Nhà XB";
            cboNXB3.SelectedIndex = 0;

            txtSoLuong.Enabled = false;
            txtDonGia.Enabled = true;            
            cboNgonNgu.SelectedIndex = 0;
            dataGridView10.Columns[9].Visible = false;
            dataGridView10.Columns[10].Visible = false;
            //disable button
            btnThem3.Enabled = false;
            //kiểm ra giá trị của đơn giá lúc load form
            if (txtDonGia.Text == "0")
            {
                txtDonGia.Enabled = false;
            }
        }        
        
     
        
        //Kiểm tra khi thêm đầu sách        
        private bool Validation3()
        {
            if (txtTenSach.Text.Length == 0)
            {
                txtTenSach.Focus();
                txtTenSach.SelectAll();
                strError = "Nhập Tên Sách";
                return false;
            }

            if (txtTacGia.Text.Length == 0)
            {
                txtTacGia.Focus();
                txtTacGia.SelectAll();
                strError = "Nhập Tên Tác Giả";
                return false;
            }
            return true;
        }
        //Fill form 3
        private void FillForm3(DataGridViewRow vr)
        {
            int ngonngu = 0;
            txtTenSach.Text = Convert.ToString(vr.Cells["Tên Sách"].Value);
            txtTacGia.Text = Convert.ToString(vr.Cells["Tác Giả"].Value);
            txtSoLuong.Text = Convert.ToString(vr.Cells["Số Lượng"].Value);
            txtDonGia.Text = Convert.ToString(vr.Cells["Đơn Giá"].Value);

            if (txtDonGia.Text != "0")
            {
                txtDonGia.Enabled = true;
            }
            else if (txtDonGia.Text == "0")
            {
                txtDonGia.Enabled = false;
            }
            txtTomTat3.Text = Convert.ToString(vr.Cells["Nội Dung"].Value);
            if (Convert.ToString(vr.Cells["Ngôn Ngữ"].Value) == "Tiếng Anh")
            {
                ngonngu = 0;
            }
            else if (Convert.ToString(vr.Cells["Ngôn Ngữ"].Value) == "Tiếng Việt")
            {
                ngonngu = 1;

            }
            else if (Convert.ToString(vr.Cells["Ngôn Ngữ"].Value) == "Tiếng Nga")
            {
                ngonngu = 2;
            }
            else if (Convert.ToString(vr.Cells["Ngôn Ngữ"].Value) == "Tiếng Trung")
            {
                ngonngu = 3;
            }
            else if (Convert.ToString(vr.Cells["Ngôn Ngữ"].Value) == "Tiếng Pháp")
            {
                ngonngu = 4;
            }
            cboNgonNgu.SelectedIndex = ngonngu;
            cboLoaiSach.SelectedValue = (vr.Cells["MaLoaiSach"].Value);
            cboNXB3.SelectedValue = (vr.Cells["MaNXB"].Value);
        }

        private void btnTim3_Click(object sender, EventArgs e)
        {
            int intType = cboTab3Sach.SelectedIndex;
            BookService cls = new BookService();
            dataGridView10.DataSource = cls.TimSach(intType, txtTab3Keyword1.Text.Trim());
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtTab3Keyword1.Focus();
            txtTab3Keyword1.SelectAll();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtMaSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void dataGridView11_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCount3.Text = "Kết quả có " + dataGridView10.RowCount + " mẫu tin";
        }



        private void btnXoa3_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView10.CurrentRow;
                string strDauSach = Convert.ToString(vr.Cells["Mã Sách"].Value);
                int MaSach = Convert.ToInt16(vr.Cells["Mã Sách"].Value);
                BookService cls = new BookService();
                BookDAO bookDao = new BookDAO();
                if (!bookDao.kiemTraChiTietPhieuNhap(MaSach) || (!bookDao.kiemTraDauSach(MaSach)))
                {
                    MessageBox.Show("Sách này đang được sử dụng, không thể xóa !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Mã Sách: " + strDauSach + ". Bạn có muốn xóa nó không ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (cls.RemoveBook(MaSach))
                        {
                            dataGridView10.DataSource = cls.ShowAllBook();
                        }
                        else
                            MessageBox.Show("Không thể xóa sách", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapnhat3_Click(object sender, EventArgs e)
        {
            if (txtDonGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập đơn giá", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDonGia.Focus();
                return;
            }
            Match m2 = Regex.Match(txtDonGia.Text, @"^[0-9]+$");
            if (!m2.Success)
            {
                MessageBox.Show("Đơn giá chỉ nhập số", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDonGia.Focus();
                return;
            }
            if (!Validation3())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Book clsBook = new Book();
                DataGridViewRow vr = dataGridView10.CurrentRow;
                clsBook.MaSach = Convert.ToInt16(vr.Cells[0].Value);
                clsBook.TenSach = txtTenSach.Text;
                clsBook.TacGia = txtTacGia.Text;
                clsBook.SoLuong = Convert.ToInt16(txtSoLuong.Text);
                clsBook.DonGia = Convert.ToInt32(txtDonGia.Text);
                clsBook.NoiDungTomTat = txtTomTat3.Text;
                clsBook.NgonNgu = Convert.ToInt16(cboNgonNgu.SelectedValue);
                clsBook.MaLoaiSach = Convert.ToInt16(cboLoaiSach.SelectedValue);
                clsBook.MaNXB = Convert.ToInt16(cboNXB3.SelectedValue);
                BookService cls = new BookService();
                if (cls.EditBook(clsBook))
                {
                    MessageBox.Show("Cập nhật thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView10.DataSource = cls.ShowAllBook();
                }
                else
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem3_Click(object sender, EventArgs e)
        {

            if (!Validation3())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Book clsBook = new Book();
                clsBook.TenSach = txtTenSach.Text;
                clsBook.TacGia = txtTacGia.Text;
                clsBook.SoLuong = Convert.ToInt16(txtSoLuong.Text);
                clsBook.DonGia = Convert.ToInt32(txtDonGia.Text);
                clsBook.NoiDungTomTat = txtTomTat3.Text;
                clsBook.NgonNgu = Convert.ToInt16(cboNgonNgu.SelectedIndex);
                clsBook.MaLoaiSach = Convert.ToInt16(cboLoaiSach.SelectedValue);
                clsBook.MaNXB = Convert.ToInt16(cboNXB3.SelectedValue);

                BookService clsBookService = new BookService();
                if (!clsBookService.AddBook(clsBook))
                {
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Thêm sách thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView10.DataSource = clsBookService.ShowAllBook();
                }

            }
        }
        private string strError = "";

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
            txtTomTat3.Text = "";
            cboLoaiSach.SelectedIndex = 0;
            cboNXB3.SelectedIndex = 0;
            cboNgonNgu.SelectedIndex = 0;
            //dataGridView10.DataSource = null;
            btnThem3.Enabled = true;
            btnXoa3.Enabled = false;
            btnCapnhat3.Enabled = false;
            txtDonGia.Enabled = false;
            txtTenSach.Focus();
        }

        private void btnDong3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView10_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView10.CurrentRow;
            if (vr == null)
            {
                btnXoa3.Enabled = false;
                btnCapnhat3.Enabled = false;
                // btnThem3.Enabled = false;
                //btnTaoMoi.Enabled = false;

            }
            else
            {
                btnXoa3.Enabled = true;
                btnCapnhat3.Enabled = true;
                btnThem3.Enabled = false;
                btnTaoMoi.Enabled = true;
                FillForm3(vr);
            }
        }

        private void btnCapNhatDauSach_Click(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView10.CurrentRow;      
            GetCode.GETMaDauSach.masachDS = Convert.ToInt16(vr.Cells[0].Value);
            frmDauSach frm = new frmDauSach();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}