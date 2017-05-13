using QuanLyThuVien.Entities;
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
            // TODO: This line of code loads data into the 'thuvienDataSet.tblLoaiSach' table. You can move, or remove it, as needed.
            this.tblLoaiSachTableAdapter.Fill(this.thuvienDataSet.tblLoaiSach);

            BookService clsBookService = new BookService();
            dataGridView11.DataSource = clsBookService.ShowAllBook();
            //Tab 3
            cboTab3Sach.SelectedIndex = 1;
            cboTab3Filter.SelectedIndex = 0;
            //Fill vào combobox nhà xuất bản
            NhaXBService cls3 = new NhaXBService();
            cboNXB3.DataSource = new DataView(cls3.ShowAllNhaXB());
            cboNXB3.DisplayMember = "Tên Nhà XB";
            cboNXB3.ValueMember = "Mã Nhà XB";
            cboNXB3.SelectedIndex = 0;
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
            if (txtSoLuong.Text.Length == 0)
            {
                txtTenSach.Focus();
                txtTenSach.SelectAll();
                strError = "Số Lượng Phải Lớn Hơn 0";
                return false;
            }
            return true;
        }
        //Fill form 3
        private void FillForm3(DataGridViewRow vr)
        {
            //try
            {
                txtTenSach.Text = Convert.ToString(vr.Cells["TenSach"].Value);
                txtTacGia.Text = Convert.ToString(vr.Cells["TacGia"].Value);
                txtSoLuong.Text = Convert.ToString(vr.Cells["SoLuong"].Value);               
                txtDonGia.Text = Convert.ToString(vr.Cells["DonGia"].Value);
                txtTomTat3.Text = Convert.ToString(vr.Cells["NoiDungTomTat"].Value);
                txtNgonNgu.Text = Convert.ToString(vr.Cells["NgonNgu"].Value);
                cboLoaiSach.SelectedValue = (vr.Cells["MaLoaiSach"].Value);
                cboNXB3.SelectedValue = (vr.Cells["MaNXB"].Value);               
                //cboTinhTrang3.SelectedIndex = Convert.ToInt32(Convert.ToString(vr.Cells["TinhTrang"].Value));
                //txtGhiChu.Text = vr.Cells["GhiChu"].Value.ToString();
                int intMaSach = Convert.ToInt32(vr.Cells["MaSach"].Value);
                txtMaSach.Text = Convert.ToString(intMaSach);
                BookService cls = new BookService();
                dt = cls.ShowAuthor(intMaSach);
                dataGridView10.DataSource = dt;
                //dataGridView10.Columns[0].Visible = false;
                //dataGridView10.Columns[1].Visible = false;
                //dataGridView10.Columns[2].Visible = false;
                //int intMaTap = Convert.ToInt32(vr.Cells["MaSach"].Value);

                //if (intMaTap != 0)
                //{
                //    dataGridView10.DataSource = cls.ShowAuthorDauSach(intMaTap);
                //    dataGridView10.Columns[0].Visible = false;
                //    Book clsBook = cls.GetInfo(intMaTap);
                //    txtTenSach.Text = clsBook.TenSach;
                //    txtDonGia.Text = clsBook.DonGia.ToString();
                //}

                dataGridView10.ReadOnly = true;
                dataGridView10.AllowUserToDeleteRows = false;

            }
            //catch (Exception e)
            {
                //MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim3_Click(object sender, EventArgs e)
        {
            if (txtTab3Keyword1.Text != "")
            {
                int intFilter = cboTab3Filter.SelectedIndex;
                int intType = cboTab3Sach.SelectedIndex;
                BookService cls = new BookService();
                dataGridView11.DataSource = cls.TimSach(intType, txtTab3Keyword1.Text.Trim(), intFilter);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTab3Keyword1.Focus();
                txtTab3Keyword1.SelectAll();
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtMaSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }


        private void dataGridView11_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView11.CurrentRow;
            if (vr == null)
            {
                btnXoa3.Enabled = false;
                btnCapnhat3.Enabled = false;
               // btnThem3.Enabled = false;
                //btnTaoMoi.Enabled = false;

                txtMaSach.Enabled = false;
            }
            else
            {
                btnXoa3.Enabled = true;
                btnCapnhat3.Enabled = true;
                btnThem3.Enabled = true;
                btnTaoMoi.Enabled = true;
                txtMaSach.Enabled = true;
                FillForm3(vr);
            }
        }

        private void dataGridView11_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCount3.Text = "Kết quả có " + dataGridView11.RowCount + " mẫu tin";
        }



        private void btnXoa3_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView11.CurrentRow;
                string strDauSach = Convert.ToString(vr.Cells["MaSach"].Value);
                Book clsBook = new Book();
                clsBook.MaSach = Convert.ToInt16(vr.Cells["MaSach"].Value);
                BookService cls = new BookService();
                if (cls.KiemTraDauSach(clsBook) == false)
                {
                    if (MessageBox.Show("Mã Sách: " + strDauSach + " có đầu sách. Bạn có muốn xóa nó không ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (cls.RemoveBookDS(clsBook))
                        {
                            dataGridView11.DataSource = cls.TimSachPR(clsBook);
                            if (cls.Error != "")
                                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                dataGridView11.Focus();
                        }
                        else
                            MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }else
                {
                    if (cls.RemoveBook(clsBook))
                    {
                        dataGridView11.DataSource = cls.TimSachPR(clsBook);
                        if (cls.Error != "")
                            MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView11.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BookService clss = new BookService();
            dataGridView11.DataSource = clss.ShowAllBook();
        }

        private void btnCapnhat3_Click(object sender, EventArgs e)
        {
            Book clsBook = new Book();
            GetCode abc = new GetCode();
            //clsBook.MaSach = Convert.ToInt16(txtMaSach.Text);
            clsBook.TenSach = txtTenSach.Text;
            clsBook.TacGia = txtTacGia.Text;
            GetCode.GETSOLUONG._soluong = Convert.ToInt16(txtSoLuong.Text);       
            DataGridViewRow vr = dataGridView11.CurrentRow;
            int strBookID = Convert.ToInt16(vr.Cells[0].Value);
            BookService clsBookService = new BookService();
            clsBookService.UpdateDauSach(strBookID, clsBook, abc);
            //}
            clsBook.SoLuong = Convert.ToInt16(txtSoLuong.Text);
            clsBook.DonGia = Convert.ToInt32(txtDonGia.Text);
            clsBook.NoiDungTomTat = txtTomTat3.Text;
            clsBook.NgonNgu = txtNgonNgu.Text;
            clsBook.MaLoaiSach = Convert.ToInt16(cboLoaiSach.SelectedValue);
            clsBook.MaNXB = Convert.ToInt16(cboNXB3.SelectedValue); 
            BookService cls = new BookService();
            if (cls.EditBook(strBookID,clsBook))
            {
                dataGridView11.DataSource = cls.TimSachPR(clsBook);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            dataGridView11.Refresh();
            dataGridView11.DataSource = cls.ShowAllBook();
        }

        private void btnThem3_Click(object sender, EventArgs e)
        {
            if (!Validation3())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Book clsBook = new Book();
                //clsBook.MaSach = Convert.ToInt16(txtMaSach.Text);
                clsBook.TenSach = txtTenSach.Text;
                clsBook.TacGia = txtTacGia.Text;
                clsBook.SoLuong = Convert.ToInt16(txtSoLuong.Text);
                clsBook.DonGia = Convert.ToInt32(txtDonGia.Text);
                clsBook.NoiDungTomTat = txtTomTat3.Text;
                clsBook.NgonNgu = txtNgonNgu.Text;
                clsBook.MaLoaiSach = Convert.ToInt16(cboLoaiSach.SelectedValue);
                clsBook.MaNXB = Convert.ToInt16(cboNXB3.SelectedValue);

                BookService clsBookService = new BookService();
                if (!clsBookService.AddBook(clsBook))
                {
                    txtMaSach.Focus();
                    txtMaSach.SelectAll();
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dataGridView11.DataSource = clsBookService.TimSach(1, Convert.ToString(clsBook.MaSach), 1);
                    if (clsBookService.Error != "")
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnSoLuong.Enabled = true;
                dataGridView11.Refresh();
                dataGridView11.DataSource = clsBookService.ShowAllBook();
            }
        }
        private string strError = "";

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmLoaiSach frm = new frmLoaiSach();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            frmNhaXB frm = new frmNhaXB();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtTomTat3.Text = "";
            txtNgonNgu.Text = "";
            cboLoaiSach.SelectedIndex = 0;
            cboNXB3.SelectedIndex = 0;
            dataGridView11.DataSource = null;
            txtTenSach.Focus();
        }

        private void btnSoLuong_Click(object sender, EventArgs e)
        {
            Book clsBook = new Book();


            clsBook.SoLuong = Convert.ToInt16(txtSoLuong.Text);
            clsBook.TinhTrang = 0;
            clsBook.GhiChu = "";
            DataGridViewRow vr = dataGridView11.CurrentRow;
            int strBookID = Convert.ToInt16(vr.Cells[0].Value);
            int intSL = Convert.ToInt16(vr.Cells[3].Value);
            BookService clsBookService = new BookService();
            if (!clsBookService.AddDauSach(strBookID, clsBook, intSL))
            {
                txtMaSach.Focus();
                txtMaSach.SelectAll();
                MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView11.DataSource = clsBookService.TimSach(1, Convert.ToString(clsBook.MaSach), 1);
                if (clsBookService.Error != "")
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView11.Refresh();
            dataGridView11.DataSource = clsBookService.ShowAllBook();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }
    }
}