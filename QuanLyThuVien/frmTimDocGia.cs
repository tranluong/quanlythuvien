using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmTimDocGia : Form
    {
        public frmTimDocGia()
        {
            InitializeComponent();
        }
        public string strMaDG = "";
        private void frmTimDocGia_Load(object sender, EventArgs e)
        {
            cboDocgia.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;

            MuonTraService MTS = new MuonTraService();
            txtMaDG.Text = MTS.GetInfoReader(strMaDG).MaDG;
            txtTenDG.Text = MTS.GetInfoReader(strMaDG).TenDG;

            ReaderService clsRS = new ReaderService();
            dataGridView2.DataSource = clsRS.QuaTrinhMuon(strMaDG);
            //dataGridView2.Columns["MaDauSach"].Visible = false;
            dataGridView2.Columns["MaPM"].Visible = false;
            if (clsRS.Error != "")
                MessageBox.Show(clsRS.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text.Trim().Length != 0)
            {
                ReaderService RS = new ReaderService();
                dataGridView1.DataSource = RS.SearchReader(cboDocgia.SelectedIndex, txtKeyword.Text.Trim(), cboFilter.SelectedIndex);
                if (RS.Error != "")
                {
                    MessageBox.Show(RS.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                if (vr != null)
                {
                    txtMaDG.Text = vr.Cells["Mã độc giả"].Value.ToString();
                    txtTenDG.Text = vr.Cells["Độc giả"].Value.ToString();
                    dataGridView1.Columns["Ngày đặt cọc"].Visible = false;
                    dataGridView1.Columns["Ngày sinh"].Visible = false;
                    dataGridView1.Columns["Địa chỉ"].Visible = false;
                    dataGridView1.Columns["Điện thoại"].Visible = false;
                    dataGridView1.Columns["Nơi sinh"].Visible = false;
                    //dataGridView1.Columns["ThoiGianKetThuc"].Visible = false;

                    ReaderService clsRS = new ReaderService();
                    dataGridView2.DataSource = clsRS.QuaTrinhMuon(txtMaDG.Text);
                    if (clsRS.Error != "")
                        MessageBox.Show(clsRS.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCount.Text = "Kết quả có " + dataGridView1.RowCount + " mẫu tin";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}