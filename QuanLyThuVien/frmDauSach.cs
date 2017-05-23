﻿using QuanLyThuVien.Business;
using QuanLyThuVien.Data;
using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmDauSach : Form
    {
        public frmDauSach()
        {
            InitializeComponent();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            DauSach clsBoo = new DauSach();
            GetCode abc = new GetCode();
            //clsBook.MaSach = Convert.ToInt16(cboMaSach.SelectedValue);
            clsBoo.TinhTrang = Convert.ToByte(cboTinhTrang.SelectedIndex);
            clsBoo.GhiChu = txtGhiChu.Text;
            clsBoo.TenDauSach = txtTenDauSach.Text;
            DataGridViewRow vr = dataGridView1.CurrentRow;
            //GetCode.GETSOLUONG._soluong = Convert.ToInt16(txtSoLuong.Text);  
            int strBookID = GetCode.GETMaDauSach.masachDS;
            int MDS = Convert.ToInt16(vr.Cells["Mã Đầu Sách"].Value);
            BookService cls = new BookService();
            if (cls.EditDauSach(strBookID, clsBoo, MDS))
            {
                dataGridView1.DataSource = cls.TimDauSach(clsBoo, MDS);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            dataGridView1.Refresh();
            dataGridView1.DataSource = cls.ShowDSTSach(strBookID);
        }

        private void frmDauSach_Load(object sender, EventArgs e)
        {
            DauSachDAO clsLDGService = new DauSachDAO();
            dataGridView1.DataSource = clsLDGService.ShowAllDauSach(GetCode.GETMaDauSach.masachDS);
        }

        private void groupBox16_Enter(object sender, EventArgs e)
        {

        }

        //private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    DataGridViewRow vr = dataGridView1.CurrentRow;
        //    if (vr == null)
        //    {
        //        btnCapnhat.Enabled = false;
        //    }
        //    else
        //    {

        //        btnCapnhat.Enabled = true;
        //        cboTinhTrang.SelectedValue = vr.Cells["TinhTrang"].Value;
        //        txtGhiChu.Text = Convert.ToString(vr.Cells["GhiChu"].Value);
        //    }
        //}

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DauSachDAO pnDao = new DauSachDAO();
            if (dataGridView1.Rows.Count > 0)
            {
                int MaPN = GetCode.GETMaDauSach.masachDS;
                if (MessageBox.Show("Xóa đầu sách: " + MaPN + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (pnDao.DeleteDS(MaPN))
                    {
                        MessageBox.Show("Xóa đầu sáchthành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                dataGridView1.DataSource = pnDao.ShowAllDauSach(GetCode.GETMaDauSach.masachDS);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
