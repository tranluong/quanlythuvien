using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmTenBaoTC : Form
    {
        public frmTenBaoTC()
        {
            InitializeComponent();
        }

        private void frmTenBaoTC_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            cboLoai.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            TenBaoTCService cls = new TenBaoTCService();
            dataGridView1.DataSource = cls.ShowAllBTC();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenBTC.Text = txtTenBTC.Text;
            cboLoai.SelectedIndex = cboLoai.SelectedIndex;
            if (txtTenBTC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên báo, tạp chí", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TenBaoTC clsBTC = new TenBaoTC();
                TenBaoTCService clsBTCService = new TenBaoTCService();
                clsBTC.TenBTC = txtTenBTC.Text.Trim();
                clsBTC.BaoOrTapChi = Convert.ToByte(cboLoai.SelectedIndex);
                if (clsBTCService.CreateBTC(clsBTC))
                {
                    dataGridView1.DataSource = clsBTCService.ShowAllBTC();
                    if (clsBTCService.Error != "")
                        MessageBox.Show(clsBTCService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsBTCService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTenBTC.Focus();
            txtTenBTC.SelectAll();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int intType = cboFilter.SelectedIndex;
            TenBaoTCService cls = new TenBaoTCService();
            dataGridView1.DataSource = cls.SearchBTC(txtKeyword.Text.Trim(), intType);
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
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
                txtTenBTC.Text = Convert.ToString(vr.Cells[1].Value);
                cboLoai.SelectedIndex = vr.Cells[2].Value.ToString()=="Báo" ? 0 : 1;
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenBTC.Text = txtTenBTC.Text;
                cboLoai.SelectedIndex = cboLoai.SelectedIndex;
                if (txtTenBTC.Text.Trim().Length == 0)
                {
                    MessageBox.Show(MessageLanguage.IsEmpty, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtTenBTC.Text.Trim().Equals(vr.Cells[1].Value.ToString()) || cboLoai.SelectedText != vr.Cells[2].Value.ToString())
                    {
                        TenBaoTC clsBTC = new TenBaoTC();
                        clsBTC.TenBTC = txtTenBTC.Text.Trim();
                        clsBTC.MaTenBTC = Convert.ToInt16(vr.Cells[0].Value);
                        clsBTC.BaoOrTapChi = Convert.ToByte(cboLoai.SelectedIndex);
                        TenBaoTCService clsBTCService = new TenBaoTCService();
                        if (clsBTCService.UpdateBTC(clsBTC))
                        {
                            dataGridView1.DataSource = clsBTCService.ShowAllBTC();
                            if (clsBTCService.Error != "")
                                MessageBox.Show(clsBTCService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsBTCService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtTenBTC.Focus();
                txtTenBTC.SelectAll();
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
                int intMaTenBTC = Convert.ToInt32(vr.Cells[0].Value);
                string strTenBTC = Convert.ToString(vr.Cells[1].Value);
                byte bytBaoOrTapChi = Convert.ToByte(vr.Cells[2].Value.ToString() == "Báo" ? 0 : 1);
                if (MessageBox.Show("Xóa báo, tạp chí: " + strTenBTC + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TenBaoTC clsBTC = new TenBaoTC();
                    clsBTC.MaTenBTC = intMaTenBTC;
                    TenBaoTCService clsBTCService = new TenBaoTCService();
                    if (clsBTCService.DeleteBTC(clsBTC))
                    {
                        dataGridView1.DataSource = clsBTCService.ShowAllBTC();
                        if (clsBTCService.Error != "")
                            MessageBox.Show(clsBTCService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsBTCService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        //Hiển thị kết quả số mẫu tin ở status
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }
    }
}