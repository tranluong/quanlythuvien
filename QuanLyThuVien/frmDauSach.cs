using QuanLyThuVien.Business;
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
            DataGridViewRow vr = gvDauSach.CurrentRow;
            //GetCode.GETSOLUONG._soluong = Convert.ToInt16(txtSoLuong.Text);  
            int strBookID = GetCode.GETMaDauSach.masachDS;
            int MDS = Convert.ToInt16(vr.Cells["Mã Đầu Sách"].Value);
            BookService cls = new BookService();
            if (cls.EditDauSach(strBookID, clsBoo, MDS))
            {
                MessageBox.Show("Cập nhật thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            gvDauSach.Refresh();
            gvDauSach.DataSource = cls.ShowDSTSach(strBookID);
            gvDauSach.Columns[4].Visible = false;

        }

        private void frmDauSach_Load(object sender, EventArgs e)
        {            
            loadData();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DauSachDAO pnDao = new DauSachDAO();
            if (gvDauSach.Rows.Count > 0)
            {
                int MaPN = GetCode.GETMaDauSach.masachDS;
                if (MessageBox.Show("Xóa đầu sách: " + MaPN + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (pnDao.DeleteDS(MaPN))
                    {
                        MessageBox.Show("Xóa đầu sách thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                gvDauSach.DataSource = pnDao.ShowAllDauSach(GetCode.GETMaDauSach.masachDS);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void loadData()
        {
            DauSachDAO clsLDGService = new DauSachDAO();
            DataTable dt = clsLDGService.ShowAllDauSach(GetCode.GETMaDauSach.masachDS);
            if (dt.Rows.Count != 0)
            {
                gvDauSach.DataSource = dt;
                fillData();
            }
            else
            {
                return;
            }
        }

        public void fillData()
        {
            txtMaSach.Enabled = false;
            txtMaSach.Text = gvDauSach.CurrentRow.Cells[4].Value.ToString();
            string tinhTrang = gvDauSach.CurrentRow.Cells[2].Value.ToString();
            int _s = 0;
            if (tinhTrang == "Cũ")
            {
                _s = 0;
            }
            else if (tinhTrang == "Mới")
            {
                _s = 1;
            }
            else if (tinhTrang == "Hỏng")
            {
                _s = 2;
            }
            else if (tinhTrang == "Mất")
            {
                _s = 3;
            }
            cboTinhTrang.SelectedIndex = _s;
            txtTenDauSach.Text = gvDauSach.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = gvDauSach.CurrentRow.Cells[3].Value.ToString();
            gvDauSach.Columns[4].Visible = false;
        }

        private void gvDauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillData();
        }

        private void gvDauSach_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = gvDauSach.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }
    }
}
