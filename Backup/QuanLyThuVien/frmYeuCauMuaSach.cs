using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmYeuCauMuaSach : Form
    {
        public frmYeuCauMuaSach()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNXB.Text = "";
            txtGiaBia.Text = "";
            txtMore.Text = "";
        }
        private string strError = "";
        private bool Validation()
        {            
            if (txtMSSV.Text.Trim().Length == 0)
            {
                strError = "Nhập mã số sinh viên";
                txtMSSV.Focus();
                return false;
            }
            if (txtMSSV.Text.Trim().Length != 10)
            {
                strError = "Mã số sinh viên không hợp lệ (phải 10 chữ số)";
                txtMSSV.Focus();
                txtMSSV.SelectAll();
                return false;
            }
            if(txtTenSach.Text.Trim().Length==0)
            {
                strError = "Nhập tên sách";
                txtTenSach.Focus();
                return false;
            }
            if (txtTacGia.Text.Trim().Length == 0)
            {
                strError = "Nhập tác giả";
                txtTacGia.Focus();
                return false;
            }
            ReaderService cls = new ReaderService();
            if (cls.SearchReader(0, txtMSSV.Text.Trim(), 1).Rows.Count == 0)
            {
                strError = "Mã độc giả này không tồn tại";
                txtMSSV.Focus();
                txtMSSV.SelectAll();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SachYeuCau cls = new SachYeuCau();
                cls.MSSV = txtMSSV.Text.Trim();
                cls.NgayYC = DateTime.Today;                
                cls.TenSach = txtTenSach.Text.Trim();
                cls.TacGia = txtTacGia.Text.Trim();
                cls.NXB = txtNXB.Text.Trim();
                cls.GiaBia = txtGiaBia.Text;
                cls.ThongTinThem = txtMore.Text.Trim();
                SachYeuCauService clsService = new SachYeuCauService();
                if (clsService.Add(cls))
                {
                    MessageBox.Show("Thêm yêu cầu thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTaoMoi_Click(sender, e);
                    txtTenSach.Focus();
                }
                else
                {
                    MessageBox.Show(clsService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenSach.Focus();
                    txtTenSach.SelectAll();
                }
            }
        }

        private void txtGiaBia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void frmYeuCauMuaSach_Load(object sender, EventArgs e)
        {
            txtMSSV.Focus();
        }
    }
}