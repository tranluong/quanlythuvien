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
        GetCode abc = new GetCode();
        public frmDauSach()
        {
            InitializeComponent();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (gvDauSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có đầu sách nào để cập nhật", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DauSach clsBoo = new DauSach();           
            //clsBook.MaSach = Convert.ToInt16(cboMaSach.SelectedValue);
            clsBoo.TinhTrang = Convert.ToByte(cboTinhTrang.SelectedIndex);
            clsBoo.GhiChu = txtGhiChu.Text;
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
            gvDauSach.Columns[3].Visible = false;

        }

        private void frmDauSach_Load(object sender, EventArgs e)
        {
            loadData();
            cboTimKiemTinhTrang.SelectedIndex = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DauSachDAO pnDao = new DauSachDAO();
            BookService cls = new BookService();
            BookDAO bDao = new BookDAO();
            if (gvDauSach.Rows.Count > 0)
            {
                int MaDS = Convert.ToInt16(gvDauSach.CurrentRow.Cells[0].Value);
                if (!pnDao.kiemTraDauSach(MaDS))
                {
                    MessageBox.Show("Đầu sách này đang được sử dụng, không thể xóa !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Xóa đầu sách: " + MaDS + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (pnDao.DeleteDS(MaDS))
                        {
                            // Cập nhật lại số lượng khi xóa một đầu sách
                            bDao.GiamSoLuongKhiXoaDauSach(GetCode.GETMaDauSach.masachDS);
                            gvDauSach.DataSource = cls.ShowDSTSach(GetCode.GETMaDauSach.masachDS);
                            gvDauSach.AllowUserToAddRows = false;
                        }
                        else
                        {
                            MessageBox.Show("Xóa đầu sách thất bại", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }                
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
            DataTable tenSach;
            if (dt.Rows.Count != 0)
            {
                gvDauSach.DataSource = dt;
                fillData();
                tenSach = clsLDGService.getTenSachTheoMa(GetCode.GETMaDauSach.masachDS);
                txtTenSach.Text = tenSach.Rows[0]["TenSach"].ToString();
                gvDauSach.AllowUserToAddRows = false;
            }
            else
            {
                return;
            }
        }

        public void fillData()
        {
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtMaSach.Text = gvDauSach.CurrentRow.Cells[3].Value.ToString();
            string tinhTrang = gvDauSach.CurrentRow.Cells[1].Value.ToString();
            int _s = 0;
            if (tinhTrang == "Mới")
            {
                _s = 0;
            }
            else if (tinhTrang == "Hỏng")
            {
                _s = 1;
            }
            else if (tinhTrang == "Mất")
            {
                _s = 2;
            }
            else if (tinhTrang == "Hư bìa sách")
            {
                _s = 3;
            }
            cboTinhTrang.SelectedIndex = _s;
            txtGhiChu.Text = gvDauSach.CurrentRow.Cells[2].Value.ToString();
            gvDauSach.Columns[3].Visible = false;
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim3_Click(object sender, EventArgs e)
        {
            DauSachDAO clsLDSDAO = new DauSachDAO();
            int typeTrangThaiSach = cboTimKiemTinhTrang.SelectedIndex;
            gvDauSach.DataSource = clsLDSDAO.getDauSachTheoTinhTrang(typeTrangThaiSach, GetCode.GETMaDauSach.masachDS);
        }
    }
}
