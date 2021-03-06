using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmKhoChua : Form
    {
        public frmKhoChua()
        {
            InitializeComponent();
        }

        private void frmKhoChua_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            KhoChuaService cls = new KhoChuaService();            
            dataGridView1.DataSource = cls.ShowAllKho();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenKho.Text = txtTenKho.Text;
            if (txtTenKho.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên kho", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                KhoChua clsKho = new KhoChua();
                KhoChuaService clsKhoService = new KhoChuaService();
                clsKho.TenKho = txtTenKho.Text.Trim();
                if (clsKhoService.CreateKho(clsKho))
                {
                    dataGridView1.DataSource = clsKhoService.ShowAllKho();
                    if (clsKhoService.Error != "")
                        MessageBox.Show(clsKhoService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsKhoService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTenKho.Focus();
            txtTenKho.SelectAll();   
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int intType = cboFilter.SelectedIndex;
            KhoChuaService cls = new KhoChuaService();
            dataGridView1.DataSource = cls.SearchKho(txtKeyword.Text.Trim(), intType);
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
                txtTenKho.Text = Convert.ToString(vr.Cells[1].Value);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenKho.Text = txtTenKho.Text;
                if (txtTenKho.Text.Trim().Length == 0)
                {
                    MessageBox.Show(MessageLanguage.IsEmpty, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtTenKho.Text.Trim().Equals(vr.Cells[1].Value.ToString()))
                    {
                        KhoChua clsKho = new KhoChua();
                        clsKho.TenKho = txtTenKho.Text.Trim();
                        clsKho.MaKho = Convert.ToInt16(vr.Cells[0].Value);
                        KhoChuaService clsKhoService = new KhoChuaService();
                        if (clsKhoService.UpdateKho(clsKho))
                        {
                            dataGridView1.DataSource = clsKhoService.ShowAllKho();
                            if (clsKhoService.Error != "")
                                MessageBox.Show(clsKhoService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsKhoService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtTenKho.Focus();
                txtTenKho.SelectAll();
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
                int intMaKho = Convert.ToInt32(vr.Cells[0].Value);
                string strTenKho = Convert.ToString(vr.Cells[1].Value);
                //byte bytSucChua = Convert.ToByte(vr.Cells[2].Value);
                if (MessageBox.Show("Xóa kho: " + strTenKho + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KhoChua clsKho = new KhoChua();
                    clsKho.MaKho = intMaKho;
                    KhoChuaService clsKhoService = new KhoChuaService();
                    if (clsKhoService.DeleteKho(clsKho))
                    {
                        dataGridView1.DataSource = clsKhoService.ShowAllKho();
                        if (clsKhoService.Error != "")
                            MessageBox.Show(clsKhoService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsKhoService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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