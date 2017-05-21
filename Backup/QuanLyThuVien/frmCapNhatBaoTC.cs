using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmCapNhatBaoTC : Form
    {
        public frmCapNhatBaoTC()
        {
            InitializeComponent();
        }
        //Download source code mien phi tai Sharecode.vn
        private void frmCapNhatBaoTC_Load(object sender, EventArgs e)
        {            
            cboBTC.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;
            TenBaoTCService cls = new TenBaoTCService();
            cboTenBTC.DataSource = cls.ShowAllBTC();
            cboTenBTC.DisplayMember = "Tên Báo TC";
            cboTenBTC.ValueMember = "Mã tên Báo TC";
            cboTenBTC.SelectedIndex = 0;
            SoBaoTCService clsS = new SoBaoTCService();
            dataGridView1.DataSource = clsS.ShowAllSBTC();
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form frm = new frmTenBaoTC();            
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                TenBaoTCService cls = new TenBaoTCService();
                cboTenBTC.DataSource = cls.ShowAllBTC();
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboBTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBTC.SelectedIndex == 2)
            {
                dtKeyword.Visible = true;
                txtKeyword.Visible = false;
            }
            else
            {
                dtKeyword.Visible = false;
                txtKeyword.Visible = true;
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {            
            cboTenBTC.SelectedIndex = 0;
            txtSoPH.Text = "";
            dtNgayPH.Value = DateTime.Today;
            txtSoLuong.Text = "";
            dataGridView1.DataSource = null;
        }
        //Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoPH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập số phát hành",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtSoPH.Focus();
                return;
            }
            if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Nhập số lượng", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }
            if (Convert.ToInt32(txtSoLuong.Text)<= 0)
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }
            SoBaoTC clsSoBTC = new SoBaoTC();            
            clsSoBTC.MaTenBTC=Convert.ToInt32(cboTenBTC.SelectedValue);
            clsSoBTC.SoPH=txtSoPH.Text.Trim();
            clsSoBTC.NgayPH=dtNgayPH.Value;
            clsSoBTC.SoLuongNhap=Convert.ToInt32(txtSoLuong.Text);
            clsSoBTC.NguoiCapNhat = KiemTra.userid;
            clsSoBTC.NgayCapNhat = DateTime.Today;
            SoBaoTCService cls = new SoBaoTCService();
            if (cls.IsExistNgayPH(clsSoBTC))
            {
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayPH.Focus();
                return;
            }
            if (!cls.CreateSBTC(clsSoBTC))
            {
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoPH.Focus();
                txtSoPH.SelectAll();
            }
            else
            {
                dataGridView1.DataSource = cls.SearchSBTC(3, clsSoBTC.MaTenBTC.ToString(), 1);
                dataGridView1.Focus();
                if(cls.Error!="")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            SoBaoTCService cls = new SoBaoTCService();
            if (cboBTC.SelectedIndex == 2)
                dataGridView1.DataSource = cls.SearchSBTC(cboBTC.SelectedIndex, dtKeyword.Value.ToShortDateString(), cboFilter.SelectedIndex);
            else
                dataGridView1.DataSource = cls.SearchSBTC(cboBTC.SelectedIndex, txtKeyword.Text.Trim(), cboFilter.SelectedIndex);
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCount.Text = "Kết quả có " + dataGridView1.RowCount + " mẫu tin";
        }

        //Fill form
        private void FillForm(DataGridViewRow vr)
        {
            try
            {
                //cboLoai.SelectedIndex = Convert.ToInt32(vr.Cells["BaoOrTapChi"].Value);
                cboTenBTC.SelectedValue = vr.Cells["MaTenBTC"].Value;
                txtSoPH.Text = vr.Cells[1].Value.ToString();
                dtNgayPH.Value = Convert.ToDateTime(vr.Cells[2].Value);
                txtSoLuong.Text = vr.Cells[3].Value.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (vr != null)
            {
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = true;
                dataGridView1.Columns["BaoOrTapChi"].Visible = false;
                dataGridView1.Columns["MaTenBTC"].Visible = false;
                FillForm(vr);
            }
            else
            {
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = false;
            }
        }
        //Cập nhật
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtSoPH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập số phát hành", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoPH.Focus();
                return;
            }
            if (txtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Nhập số lượng", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }
            if (Convert.ToInt32(txtSoLuong.Text) <= 0)
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }
            SoBaoTC clsSoBTC = new SoBaoTC();            
            clsSoBTC.MaTenBTC = Convert.ToInt32(cboTenBTC.SelectedValue);
            clsSoBTC.SoPH = txtSoPH.Text.Trim();
            clsSoBTC.NgayPH = dtNgayPH.Value;
            clsSoBTC.SoLuongNhap = Convert.ToInt32(txtSoLuong.Text);
            clsSoBTC.NguoiCapNhat = KiemTra.userid;
            clsSoBTC.NgayCapNhat = DateTime.Today;
            int intMaTenBTC = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MaTenBTC"].Value);
            string strSoPH = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            SoBaoTCService cls = new SoBaoTCService();
            DateTime dtOldNgayPH = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Ngày phát hành"].Value);
            if (cls.IsExistNgayPH(clsSoBTC, dtOldNgayPH))
            {
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayPH.Focus();
                return;
            }
            if (!cls.UpdateSBTC(clsSoBTC, intMaTenBTC, strSoPH))
            {
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoPH.Focus();
                txtSoPH.SelectAll();
            }
            else
            {
                dataGridView1.DataSource = cls.SearchSBTC(3, clsSoBTC.MaTenBTC.ToString(), 1);
                dataGridView1.Focus();
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (MessageBox.Show("Xóa " + vr.Cells[0].Value.ToString() + " (" + vr.Cells[1].Value.ToString() + ")", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SoBaoTC clsSBTC = new SoBaoTC();
                clsSBTC.MaTenBTC = Convert.ToInt32(vr.Cells["MaTenBTC"].Value);
                clsSBTC.SoPH = vr.Cells[1].Value.ToString();
                SoBaoTCService cls = new SoBaoTCService();
                if (cls.DeleteSBTC(clsSBTC))
                {
                    dataGridView1.DataSource = cls.SearchSBTC(cboBTC.SelectedIndex,txtKeyword.Text.Trim(),cboFilter.SelectedIndex);
                    dataGridView1.Focus();
                }
                else
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Focus();
                }
            }
        }
    }
}