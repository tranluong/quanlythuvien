using QuanLyThuVien.Business;
using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
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
                PhieuNhap pn = new PhieuNhap();
                pn.pMaSach = Convert.ToInt32(cboMaSach.SelectedValue);
                pn.pSoLuong = Convert.ToInt32(txtSL.Text.Trim());
                pn.pDonGia = Convert.ToDouble(txtDG.Text.Trim());
                pn.pThanhTien = Convert.ToDouble(Convert.ToInt16(txtSL.Text) * Convert.ToDouble(txtDG.Text));
                pn.pNgayNhap = Convert.ToDateTime(dateNgayNhap.Value.Date);
                pn.pTongTriGia = Convert.ToDouble(Convert.ToInt32(txtSL.Text) * Convert.ToDouble(txtDG.Text));
                PhieuNhapService pnService = new PhieuNhapService();
                if (!pnService.ThemPhieuNhap(pn))
                {
                    MessageBox.Show(pnService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSL.Focus();
                }
                else
                {
                    gridPhieuNhap.DataSource = pnService.HienThiPhieuNhap();
                }
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtDG.Text = "";
            txtSL.Text = "";
            txtTT.Text = "";
            dateNgayNhap.Value = DateTime.Today;
            cboMaSach.SelectedIndex = 0;  
        }

        private void ribbonClientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            PhieuNhapService pn = new PhieuNhapService();
            cboMaSach.DataSource = pn.loadCombox();
            cboMaSach.DisplayMember = "TenSach";
            cboMaSach.ValueMember = "MaSach";
            gridPhieuNhap.DataSource = pn.HienThiPhieuNhap();
            txtTT.Enabled = false;
            gridPhieuNhap.Columns[6].Visible = false;            
        }

        //Kiểm tra rỗng
        private string strError = "";
        private bool Validation()
        {
            if (txtSL.Text.Trim().Length == 0)
            {
                strError = "Nhập số lượng";
                txtSL.Focus();
                return false;
            }
            Match m1 = Regex.Match(txtSL.Text, @"^[0-9]+$");
            if (!m1.Success)
            {
                strError = "Số lượng chỉ nhập số";
                txtSL.Focus();
                return false;
            }
            if (txtDG.Text.Trim().Length == 0)
            {
                strError = "Nhập đơn giá";
                txtDG.Focus();
                return false;
            }
            Match m2 = Regex.Match(txtDG.Text, @"^[0-9]+$");
            if (!m2.Success)
            {
                strError = "Đơn giá chỉ nhập số";
                txtDG.Focus();
                return false;
            }
            return true;
        }    

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuNhap pn = new PhieuNhap();
                PhieuNhapService pnService = new PhieuNhapService();
                DataGridViewRow vr = gridPhieuNhap.CurrentRow;
                string MaPN = Convert.ToString(vr.Cells[0].Value);
                if (MessageBox.Show("Xóa phiếu nhập: " + MaPN + " ? Chú ý: sau khi xóa thông tin phiếu nhập này sẽ không còn !", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    pn.pMaPhieuNhap = Convert.ToInt32(vr.Cells[0].Value);
                    if (!pnService.DeletePhieuNhap(pn))
                        MessageBox.Show(pnService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        gridPhieuNhap.DataSource = pnService.HienThiPhieuNhap();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDG_TextChanged(object sender, EventArgs e)
        {
            if (txtDG.Text.Trim().Length == 0)
            {
                strError = "Nhập đơn giá";
                txtDG.Focus();
                return ;
            }
            Match m2 = Regex.Match(txtDG.Text, @"^[0-9]+$");
            if (!m2.Success)
            {
                strError = "Đơn giá chỉ nhập số";
                txtDG.Focus();
                return ;
            }
            double tt = Convert.ToInt16(txtSL.Text) * Convert.ToDouble(txtDG.Text);
            txtTT.Text = Convert.ToString(tt);
        }

        private void gridPhieuNhap_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = gridPhieuNhap.CurrentRow;
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
            PhieuNhap pn = new PhieuNhap();
            try
            {
                cboMaSach.SelectedValue = Convert.ToString(vr.Cells[6].Value);
                txtSL.Text = Convert.ToString(vr.Cells[2].Value);
                txtDG.Text = Convert.ToString(vr.Cells[3].Value);
                txtTT.Text = Convert.ToString(vr.Cells[4].Value);
                dateNgayNhap.Value = Convert.ToDateTime(vr.Cells[5].Value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PhieuNhap pn = new PhieuNhap();
                pn.pMaSach = Convert.ToInt16(cboMaSach.SelectedValue);
                pn.pSoLuong = Convert.ToInt32(txtSL.Text.Trim());
                pn.pDonGia = Convert.ToDouble(txtDG.Text.Trim());
                pn.pThanhTien = Convert.ToDouble(Convert.ToInt16(txtSL.Text) * Convert.ToDouble(txtDG.Text));
                pn.pNgayNhap = Convert.ToDateTime(dateNgayNhap.Value.Date);
                pn.pTongTriGia = Convert.ToDouble(Convert.ToInt16(txtSL.Text) * Convert.ToDouble(txtDG.Text));
                DataGridViewRow vr = gridPhieuNhap.CurrentRow;
                pn.pMaPhieuNhap = Convert.ToInt32(vr.Cells[0].Value);
                PhieuNhapService pnService = new PhieuNhapService();
                if (!pnService.SuaPhieuNhap(pn))
                {
                    MessageBox.Show(pnService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSL.Focus();
                }
                else
                {
                    gridPhieuNhap.DataSource = pnService.HienThiPhieuNhap();
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            PhieuNhapService pnService = new PhieuNhapService();
            gridPhieuNhap.DataSource = pnService.SearchPhieuNhap(txtKeyword.Text);
        }
    }
}
