using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmTacGiaSachTap : Form
    {
        public frmTacGiaSachTap()
        {
            InitializeComponent();
        }
        public int intMaTap = 0;
        public string strTenTap= "";

        private void frmTacGiaSachTap_Load(object sender, EventArgs e)
        {
            //Fill combobox Tác giả
            TacGiaService cls = new TacGiaService();
            cboTacGia.DataSource = new DataView(cls.ShowAllTG());
            cboTacGia.DisplayMember = "Tên Tác Giả";
            cboTacGia.ValueMember = "Mã Tác Giả";
            //Fill datagridview
            BookService clsBookService = new BookService();
            dataGridView1.DataSource = clsBookService.ShowAuthorChapter(intMaTap);

            groupBox2.Text = groupBox2.Text + ": " + strTenTap;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            frmTacgia frm = new frmTacgia();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                TacGiaService cls = new TacGiaService();
                cboTacGia.DataSource = cls.ShowAllTG();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TacGia clsTG = new TacGia();
            clsTG.MaTap = intMaTap;
            clsTG.MaTG = Convert.ToInt32(cboTacGia.SelectedValue);
            clsTG.ChuBien = Convert.ToByte(chkChuBien.Checked == true ? 1 : 0);
            TacGiaService clsTGService = new TacGiaService();
            if (clsTGService.CreateTGT(clsTG))
            {
                BookService clsBookService = new BookService();
                dataGridView1.DataSource = clsBookService.ShowAuthorChapter(intMaTap);
                if (clsBookService.Error != "")
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(clsTGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Fill form
        private void FillForm(DataGridViewRow vr)
        {
            cboTacGia.SelectedValue = vr.Cells[0].Value;
            chkChuBien.Checked = ((Convert.ToByte(vr.Cells[2].Value) == 1) ? true : false);
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (vr == null)
            {
                btnXoa.Enabled = false;
                btnCapnhat.Enabled = false;
                btnDong.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
                btnCapnhat.Enabled = true;
                btnDong.Enabled = true;
                FillForm(vr);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                TacGia clsTG = new TacGia();
                clsTG.MaTap = intMaTap;
                clsTG.MaTG = Convert.ToInt32(cboTacGia.SelectedValue);
                clsTG.ChuBien = Convert.ToByte(chkChuBien.Checked == true ? 1 : 0);
                int intOldMaTG = Convert.ToInt32(vr.Cells[0].Value);
                TacGiaService clsTGService = new TacGiaService();
                if (clsTGService.UpdateTGT(clsTG, intOldMaTG))
                {
                    BookService cls = new BookService();
                    dataGridView1.DataSource = cls.ShowAuthorChapter(intMaTap);
                    if (cls.Error != "")
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsTGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    clsTG.MaTap = intMaTap;
                    clsTG.MaTG = intMaTG;
                    TacGiaService clsTGService = new TacGiaService();
                    if (clsTGService.DeleteTGT(clsTG))
                    {
                        BookService cls = new BookService();
                        dataGridView1.DataSource = cls.ShowAuthorChapter(intMaTap);
                        if (cls.Error != "")
                            MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}