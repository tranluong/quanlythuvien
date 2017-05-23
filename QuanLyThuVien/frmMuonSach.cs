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
    public partial class frmMuonSach : Form
    {
        public frmMuonSach()
        {
            InitializeComponent();
        }

        private void frmMuonSach_Load(object sender, EventArgs e)
        {

            desiableFillAndButton();
            loadDocGia();
            loadNhanVien();
        }

        public void desiableFillAndButton()
        {
            comboBox1.SelectedIndex = 0;
            cboTenDG.Enabled = false;
            dateMuon.Enabled = false;
            dateTra.Enabled = false;
            cboTenNV.Enabled = false;
            dateNgayLapPhieu.Enabled = false;
            lblGiaHan.Visible = false;
            ckGiahan.Visible = false;
            txtTienCoc.Text = "20000";
            txtTienCoc.Enabled = false;
            btnXoa.Enabled = false;
            btnCapnhat.Enabled = false;
            btnLuuPhieu.Enabled = false;
            btnXoaPhieuMuon.Enabled = false;
            dateMuon.MinDate = DateTime.Today;
            dateTra.Value = DateTime.Today.AddDays(+10);
            dateNgayLapPhieu.MinDate = DateTime.Today;
            txtMaSachMuon.Enabled = false;
            txtTenSachMuon.Enabled = false;
            gridViewChiTiet.AllowUserToAddRows = false;
        }

        public void loadDocGia()
        {
            MuonTraService mt = new MuonTraService();
            cboTenDG.DataSource = mt.loadComboxDocGia();
            cboTenDG.DisplayMember = "TenDG";
            cboTenDG.ValueMember = "MaDG";
        }

        public void loadNhanVien()
        {
            MuonTraService mt = new MuonTraService();
            cboTenNV.DataSource = mt.loadComboxNhanVien(KiemTra.userid);
            cboTenNV.DisplayMember = "TenNV";
            cboTenNV.ValueMember = "MaNV";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập mã phiếu cần tìm kiếm", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPN.Focus();
                return;
            }
            else
            {
                MessageBox.Show("ok tim dc");
            }
        }

        public void enableFill()
        {
            cboTenDG.Enabled = true;
            txtMaPN.Enabled = false;
            btnTim.Enabled = false;
            btnLuuPhieu.Enabled = true;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            enableFill();
        }

        private void btnTimMuon_Click(object sender, EventArgs e)
        {
            MuonTraDAO mtDao = new MuonTraDAO();
            int idTimKiem = comboBox1.SelectedIndex;
            int maSachHoacLoai = Convert.ToInt32(cboTimSach.SelectedValue);
            DataTable dt = mtDao.getInfoSachMuon(idTimKiem, maSachHoacLoai);
            txtMaSachMuon.Text = dt.Rows[0]["Mã Sách"].ToString();
            txtTenSachMuon.Text = dt.Rows[0]["Tên Sách"].ToString();
            gridViewSach.DataSource = mtDao.getDauSachTheoLoaiTimKiem(idTimKiem, maSachHoacLoai);
            gridViewSach.AllowUserToAddRows = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTim = comboBox1.SelectedIndex;
            MuonTraService mt = new MuonTraService();
            if (idTim == 0)
            {
                cboTimSach.DataSource = mt.loadComboxMuonSach(0);
                cboTimSach.DisplayMember = "TenLoaiSach";
                cboTimSach.ValueMember = "MaLoaiSach";
            }
            else if (idTim == 1)
            {
                cboTimSach.DataSource = mt.loadComboxMuonSach(1);
                cboTimSach.DisplayMember = "TenSach";
                cboTimSach.ValueMember = "MaSach";
            }
            
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (gridViewChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách nhập", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("ok");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr;
            DataTable dtable = new DataTable();
            dtable.Columns.Add("Mã đầu sách");
            dtable.Columns.Add("Tên đầu sách");
            dtable.Columns.Add("Trạng thái sách");

            if (gridViewSach.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in gridViewSach.SelectedRows)
                {
                    dr = dtable.NewRow();
                    dr["Mã đầu sách"] = r.Cells["Mã Đầu Sách"].Value.ToString();
                    dr["Tên đầu sách"] = r.Cells["Tên Đầu Sách"].Value.ToString();
                    dr["Trạng thái sách"] = r.Cells["Tình Trạng"].Value.ToString();
                    dtable.Rows.Add(dr);
                }
                gridViewChiTiet.DataSource = dtable;                
                btnXoaPhieuMuon.Enabled = true;
                gridViewChiTiet.AllowUserToAddRows = false;
            }
            else
            {
                MessageBox.Show("Hãy tìm sách muốn mượn hoặc nhấn ctrl và các dòng trên lưới để mượn sách !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaPhieuMuon_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridViewChiTiet.SelectedRows)
            {
                if (!row.IsNewRow)
                    gridViewChiTiet.Rows.Remove(row);
            }
        }
    }
}
