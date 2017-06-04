using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmMuonSach : Form
    {
        DataTable dtable;
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
            cboMaDG.Enabled = false;
            dateMuon.Enabled = false;
            dateTra.Enabled = false;
            cboTenNV.Enabled = false;
            dateNgayLapPhieu.Enabled = false;
            lblGiaHan.Visible = false;
            ckGiahan.Visible = false;
            txtTienCoc.Text = "0";
            txtTienCoc.Enabled = false;
            //btnXoa.Enabled = false;
            btnCapnhat.Enabled = false;
            btnLuuPhieu.Enabled = false;
            btnXoaPhieuMuon.Enabled = false;
            gridViewChiTiet.AllowUserToAddRows = false;
            txtTenDocGia.Enabled = false;
            button3.Enabled = false;
        }

        public void loadDocGia()
        {
            //Hiển thị mã độc giả để khi select tự fill tên vào textbox tên độc giả
            MuonTraService mt = new MuonTraService();
            cboMaDG.DataSource = mt.loadComboxDocGia();
            cboMaDG.DisplayMember = "MaDG";
            cboMaDG.ValueMember = "MaDG";
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
                MessageBox.Show("Nhập mã phiếu cần tìm kiếm !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPN.Focus();
                return;
            }
            Match m2 = Regex.Match(txtMaPN.Text, @"^[0-9]+$");
            if (!m2.Success)
            {
                MessageBox.Show("Mã phiếu mượn chỉ nhập số !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPN.Focus();
                return;
            }
            int MaPM = int.Parse(txtMaPN.Text.Trim());
            MuonTraService mtService = new MuonTraService();
            //Load phiếu mượn theo mã phiếu
            DataTable dt = mtService.TimPhieuMuon(MaPM);
            if (dt.Rows.Count != 0)
            {
                cboMaDG.SelectedValue = dt.Rows[0]["MaDG"].ToString();
                dateMuon.Value = Convert.ToDateTime(dt.Rows[0]["NgayMuon"].ToString());
                dateTra.Value = Convert.ToDateTime(dt.Rows[0]["HanTra"].ToString());
                cboTenNV.SelectedValue = dt.Rows[0]["MaNV"].ToString();
                dateNgayLapPhieu.Value = Convert.ToDateTime(dt.Rows[0]["NgayLapPhieu"].ToString());
                txtTienCoc.Text = dt.Rows[0]["TienDatCoc"].ToString();
            }
            else
            {
                MessageBox.Show("Mã phiếu mượn này không tồn tại !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Load chi tiết phiếu mượn
            DataTable dt1 = mtService.TimCTPhieuMuon(MaPM);
            if (dt1.Rows.Count != 0)
            {
                if (dt.Rows[0]["Giahan"].ToString().Equals("False"))
                {
                    lblGiaHan.Visible = true;
                    ckGiahan.Visible = true;
                    ckGiahan.Enabled = true;
                    ckGiahan.Checked = false;
                    btnCapnhat.Enabled = true;
                }
                else
                {
                    lblGiaHan.Visible = true;
                    ckGiahan.Visible = true;
                    ckGiahan.Checked = true;
                    ckGiahan.Enabled = false;
                    btnCapnhat.Enabled = false;
                }

            }
            else
            {
                enableFill1(false);
            }
            gridViewChiTiet.DataSource = dt1;
        }

        public void enableFill1(bool flg)
        {
            lblGiaHan.Visible = flg;
            ckGiahan.Visible = flg;
            btnCapnhat.Enabled = flg;
        }

        public void enableFill()
        {
            dtable = new DataTable();
            dtable.Columns.Add("Mã đầu sách");
            dtable.Columns.Add("Tên sách");
            dtable.Columns.Add("Trạng thái");
            dtable.Columns.Add("Đơn giá");
            cboMaDG.Enabled = true;
            btnLuuPhieu.Enabled = true;
            dateMuon.Value = DateTime.Today;
            dateTra.Value = DateTime.Today.AddDays(+10);
            dateNgayLapPhieu.Value = DateTime.Today;
            txtMaPN.Text = "";
            gridViewChiTiet.DataSource = null;
            button3.Enabled = true;
            btnCapnhat.Enabled = false;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            enableFill();
        }

        private void btnTimMuon_Click(object sender, EventArgs e)
        {
            MuonTraDAO mtDao = new MuonTraDAO();
            int idTimKiem = comboBox1.SelectedIndex;
            gridViewSach.DataSource = mtDao.getDauSachTheoLoaiTimKiem(idTimKiem, txtTimSachMuon.Text);
            gridViewSach.AllowUserToAddRows = false;

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            int isChecked = 0;
            if (ckGiahan.Checked)
            {
                isChecked = 1;
            }
            MuonTraDAO mtDao = new MuonTraDAO();
            int MaPM = int.Parse(txtMaPN.Text.Trim());
            DataTable dt = mtDao.getHanTra(MaPM);
            DateTime hantra = Convert.ToDateTime(dt.Rows[0]["HanTra"].ToString());
            if (mtDao.CapNhatGiaHan(MaPM, isChecked, hantra.AddDays(+10)))
            {
                MessageBox.Show("Gia hạn thành công !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCapnhat.Enabled = false;
            }
            else
            {
                MessageBox.Show("Gia hạn thất bại !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (txtTenDocGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chọn Mã Độc Giả muốn mượn sách !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Kiểm tra mã độc giả có được mượn không
            MuonTraDAO mtDao1 = new MuonTraDAO();
            DataTable dtKiemtraDGHetHan = mtDao1.kiemTraDocGiaDaHetHanMuon(Convert.ToString(cboMaDG.SelectedValue));
            if (dtKiemtraDGHetHan.Rows.Count != 0)
            {
                MessageBox.Show("Độc giả này đã hết hạn sử dụng thẻ, không thể mượn tiếp !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dtTinhTrangMuonTraCuaDG = mtDao1.kiemTraDocGiaDaMuonChua(Convert.ToString(cboMaDG.SelectedValue));
            if (dtTinhTrangMuonTraCuaDG.Rows.Count != 0)
            {
                MessageBox.Show("Độc giả này vẫn còn sách chưa trả, không thể mượn tiếp !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (gridViewChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách muốn mượn !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                List<MuonTra> mtList = new List<MuonTra>();
                MuonTra mtPhieuMuon = new MuonTra();
                mtPhieuMuon.NgayMuon = Convert.ToDateTime(dateMuon.Value.Date);
                mtPhieuMuon.HanTra = Convert.ToDateTime(dateTra.Value.Date);
                mtPhieuMuon.TienDatCoc = float.Parse(txtTienCoc.Text);
                mtPhieuMuon.NgayLapPhieu = Convert.ToDateTime(dateNgayLapPhieu.Value.Date);
                mtPhieuMuon.MaNV = Convert.ToInt16(cboTenNV.SelectedValue);
                mtPhieuMuon.MaDG = Convert.ToString(cboMaDG.SelectedValue);
                for (int i = 0; i < gridViewChiTiet.Rows.Count; i++)
                {
                    MuonTra mtCTPhieuMuon = new MuonTra();
                    mtCTPhieuMuon.MaDauSach = Convert.ToInt32(gridViewChiTiet.Rows[i].Cells["Mã Đầu Sách"].Value);
                    //mtCTPhieuMuon.NgayTra = DateTime.Today.AddDays(+10);
                    mtList.Add(mtCTPhieuMuon);
                }
                MuonTraService mtService = new MuonTraService();
                MuonTraDAO mtDao = new MuonTraDAO();
                if (!mtService.ThemPhieuMuonSach(mtList, mtPhieuMuon))
                {
                    MessageBox.Show("Mượn sách không thành công !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int ID = mtDao.getIDLonNhat();
                    txtMaPN.Text = ID.ToString();
                    int idTimKiem = comboBox1.SelectedIndex;
                    gridViewSach.DataSource = mtDao.getDauSachTheoLoaiTimKiem(idTimKiem, txtTimSachMuon.Text);
                    MessageBox.Show("Mượn sách thành công !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int duocChonToiDa = 3;
            var errorMaximum = "Chỉ được phép mượn tối đa 3 quyển !";

            if (gridViewSach.SelectedRows.Count > 0)
            {
                var daVuotQuaSoLuonToiDa = (gridViewChiTiet.Rows.Count + gridViewSach.SelectedRows.Count) > duocChonToiDa;

                if (gridViewChiTiet.Rows.Count >= duocChonToiDa || daVuotQuaSoLuonToiDa)
                {
                    MessageBox.Show(errorMaximum, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow r in gridViewSach.SelectedRows)
                {
                    var maDauSach = r.Cells["Mã Đầu Sách"].Value.ToString();
                    if (!DaChonDauSach(maDauSach))
                    {
                        var dr = dtable.NewRow();

                        dr["Mã đầu sách"] = r.Cells["Mã Đầu Sách"].Value.ToString();
                        dr["Tên sách"] = r.Cells["Tên Sách"].Value.ToString();
                        dr["Trạng thái"] = r.Cells["Tình Trạng"].Value.ToString();
                        dr["Đơn giá"] = r.Cells["Đơn giá"].Value.ToString();
                        dtable.Rows.Add(dr);
                    }
                    else
                    {
                        MessageBox.Show("Đầu sách " + maDauSach + " đã được chọn !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                gridViewChiTiet.DataSource = dtable;
                btnXoaPhieuMuon.Enabled = true;
                gridViewChiTiet.AllowUserToAddRows = false;
                // tính tiền đặt cọc
                int tienDatCoc = 0;
                int tongTienSachMuon = 0;
                for (int i = 0; i < gridViewChiTiet.Rows.Count; i++)
                {

                    tongTienSachMuon += Convert.ToInt32(gridViewChiTiet.Rows[i].Cells["Đơn giá"].Value);
                }
                decimal cvTongTienMuon = Convert.ToDecimal(tongTienSachMuon) / 1000;
                if (cvTongTienMuon <= 50)
                {
                    tienDatCoc = 0;
                }
                else if (cvTongTienMuon > 50)
                {
                    for (int i = 51; i < cvTongTienMuon; i += 50)
                    {
                        tienDatCoc += 50;
                    }
                }
                decimal cvTienCoc = Convert.ToDecimal(tienDatCoc) * 1000;
                txtTienCoc.Text = Convert.ToString(cvTienCoc);

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

        private void cboMaDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            MuonTraDAO mtDao = new MuonTraDAO();
            string maDG = "";
            try
            {
                maDG = cboMaDG.SelectedValue.ToString();
                DataTable dt = mtDao.getTenDG(maDG);
                txtTenDocGia.Text = dt.Rows[0]["Tên Độc Giả"].ToString();
            }
            catch (Exception ex)
            { }
        }

        private bool DaChonDauSach(string maDauSach)
        {
            foreach (DataGridViewRow r in gridViewChiTiet.Rows)
            {
                if (maDauSach == r.Cells["Mã Đầu Sách"].Value.ToString())
                    return true;
            }

            return false;
        }
    }
}
