using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmTacgia : Form
    {
        public frmTacgia()
        {
            InitializeComponent();
        }

        private void frmTacgia_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            TacGiaService cls = new TacGiaService();
            dataGridView1.DataSource = cls.ShowAllTG();
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
            txtTenTG.Text = txtTenTG.Text;
            if (txtTenTG.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên tác giả", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TacGia clsTG = new TacGia();
                TacGiaService clsTGService = new TacGiaService();
                clsTG.TenTG = txtTenTG.Text.Trim();
                if (clsTGService.CreateTG(clsTG))
                {
                    dataGridView1.DataSource = clsTGService.ShowAllTG();
                    if (clsTGService.Error != "")
                        MessageBox.Show(clsTGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsTGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTenTG.Focus();
            txtTenTG.SelectAll();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int intType = cboFilter.SelectedIndex;
            TacGiaService cls = new TacGiaService();
            dataGridView1.DataSource = cls.SearchTG(txtKeyword.Text.Trim(), intType);
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
                txtTenTG.Text = Convert.ToString(vr.Cells[1].Value);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenTG.Text = txtTenTG.Text;
                if (txtTenTG.Text.Trim().Length == 0)
                {
                    MessageBox.Show(MessageLanguage.IsEmpty, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtTenTG.Text.Trim().Equals(vr.Cells[1].Value.ToString()))
                    {
                        TacGia clsTG = new TacGia();
                        clsTG.TenTG = txtTenTG.Text.Trim();
                        clsTG.MaTG = Convert.ToInt16(vr.Cells[0].Value);
                        TacGiaService clsTGService = new TacGiaService();
                        if (clsTGService.UpdateTG(clsTG))
                        {
                            dataGridView1.DataSource = clsTGService.ShowAllTG();
                            if (clsTGService.Error != "")
                                MessageBox.Show(clsTGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsTGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtTenTG.Focus();
                txtTenTG.SelectAll();
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
                int intMaTG = Convert.ToInt16(vr.Cells[0].Value);
                string strTenTG = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa tác giả: " + strTenTG + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TacGia clsTG = new TacGia();
                    clsTG.MaTG = intMaTG;
                    TacGiaService clsTGService = new TacGiaService();
                    if (clsTGService.DeleteTG(clsTG))
                    {
                        dataGridView1.DataSource = clsTGService.ShowAllTG();
                        if (clsTGService.Error != "")
                            MessageBox.Show(clsTGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsTGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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