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
    public partial class frmTraSach : Form
    {
        DateTimePicker cellDateTimePicker; 
        public frmTraSach()
        {
            InitializeComponent();
        }

        private void btnXoaPhieuMuon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadDocGia()
        {
            //Hiển thị mã độc giả để khi select tự fill tên vào textbox tên độc giả
            MuonTraService mt = new MuonTraService();
            cboMaDG.DataSource = mt.loadComboxDocGia();
            cboMaDG.DisplayMember = "MaDG";
            cboMaDG.ValueMember = "MaDG";
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
            MuonTraDAO mtDao = new MuonTraDAO();
            //Load phiếu mượn theo mã phiếu
            DataTable dt = mtService.TimPhieuTra(MaPM);
            if (dt.Rows.Count != 0)
            {
                //Load tên nhân viên theo mã
                cboTenNV.DataSource = mtService.loadComboxNhanVien(int.Parse(dt.Rows[0]["MaNV"].ToString()));
                cboTenNV.DisplayMember = "TenNV";
                cboTenNV.ValueMember = "MaNV";                
                //Load mã độc giả
                string MaDG = dt.Rows[0]["MaDG"].ToString();
                cboMaDG.SelectedValue = MaDG;      
                //Load tên độc giả theo mã
                DataTable dtTenDG = mtDao.getTenDG(MaDG);
                txtTenDocGia.Text = dtTenDG.Rows[0]["Tên Độc Giả"].ToString();
                dateHanTra.Value = Convert.ToDateTime(dt.Rows[0]["HanTra"].ToString());
                txtTienCoc.Text = dt.Rows[0]["TienDatCoc"].ToString();
            }
            else
            {
                MessageBox.Show("Mã phiếu mượn này không tồn tại !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Load chi tiết phiếu mượn
            DataTable dtableCTPTra = mtService.TimCTPhieuTra(MaPM);
            dvCTPTra.Rows.Clear();
            if (dtableCTPTra.Rows.Count != 0)
            {
                for (int i = 0; i < dtableCTPTra.Rows.Count; i++)
                {
                    dvCTPTra.Rows.Add();
                    dvCTPTra.Rows[i].Cells["MaDauSach"].Value = dtableCTPTra.Rows[i]["Mã đầu sách"].ToString();
                    dvCTPTra.Rows[i].Cells["TenSach"].Value = dtableCTPTra.Rows[i]["Tên sách"].ToString();
                    dvCTPTra.Rows[i].Cells["TinhTrang"].Value = dtableCTPTra.Rows[i]["Tình trạng"].ToString();
                    dvCTPTra.Rows[i].Cells["NgayToiTra"].Value = Convert.ToString(DateTime.Today.ToShortDateString());
                    dvCTPTra.Rows[i].Cells["GiaSach"].Value = dtableCTPTra.Rows[i]["Đơn giá"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Sách này đã trả hết !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmTraSach_Load(object sender, EventArgs e)
        {
            loadDocGia();
            diableField();
        }

        public void diableField()
        {
            cboTenNV.Enabled = false;
            cboMaDG.Enabled = false;
            txtTenDocGia.Enabled = false;
            dateHanTra.Enabled = false;
            txtTienCoc.Enabled = false;
            txtTienTraLai.Enabled = false;
            txtTienPhat.Enabled = false;
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            bool isChecked = false;
            if (dvCTPTra.Rows.Count != 0)
            {
                MuonTraService mtService = new MuonTraService();
                MuonTraDAO mtDao = new MuonTraDAO();
                int MaPM = int.Parse(txtMaPN.Text.Trim());
                DataTable dtLoaiDG = mtService.LayLoaiDGTheoMaPM(MaPM);
                foreach (DataGridViewRow row in dvCTPTra.Rows)
                {
                    DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chk.Value) == true)
                    {
                        isChecked = true;
                        //Lấy giá trị của combobox, nếu bằng null thì gán giá trị = 0
                        DataGridViewComboBoxCell cboTinhTrangSach = row.Cells[5] as DataGridViewComboBoxCell;
                        DataGridViewComboBoxCell cboTrangThaiMuon = row.Cells[6] as DataGridViewComboBoxCell;
                        
                        if (cboTinhTrangSach.Value == null)
                        {
                            cboTinhTrangSach.Value = cboTinhTrangSach.Items[0];
                        }
                        
                        if (cboTrangThaiMuon.Value == null)
                        {
                            cboTrangThaiMuon.Value = cboTrangThaiMuon.Items[1];
                        }
                        int tinhTrangSach = Convert.ToInt32(cboTinhTrangSach.Items.IndexOf(cboTinhTrangSach.Value));
                        int trangThaiMuon = Convert.ToInt32(cboTrangThaiMuon.Items.IndexOf(cboTrangThaiMuon.Value));
                        
                        // Update lại trạng thái cho 2 bảng tblChiTietPhieuMuonTra và tblDauSach
                        int MaDauSach = Convert.ToInt32(row.Cells[1].Value);
                        mtDao.CapNhatChiTietPhieuMuonTra(MaPM, MaDauSach, DateTime.Today, tinhTrangSach, trangThaiMuon);
                    }                    
                }

                //Lấy hạn trả sách theo mã phiếu trong bảng tblPhieuMuonTra
                DataTable dtHanTra = mtDao.layHanTraTheoMaPM(MaPM);
                //Đếm MaPM theo số phiếu nhập
                int countMaPM = mtDao.DemMaPM(MaPM);
                //Đếm MaPM theo tình trạng mượn trả(0:Đang mượn, 1:Đã trả, 2:Trả trễ)
                int countMaPMBTheoTinhTrang = mtDao.DemMaPMTheoTinhTrang(MaPM);
                double tienPhat = 0;
                //So sáng MaPM với MaPM có tình trang khác 0 để tính tiền phạt và tiền trả lại trong bảng tblChiTietPhieuMuonTra
                if (countMaPM == countMaPMBTheoTinhTrang)
                {
                    //Lấy mã đầu sách và tình trạng mượn trả trong tblChiTietPhieuMuonTra
                    DataTable dtDsTinhTrang = mtDao.layMaDSVaTinhTrangMuonTra(MaPM);
                    foreach (DataRow row in dtDsTinhTrang.Rows)
                    {
                        int MaDS = Convert.ToInt32(row["Mã đầu sách"].ToString());
                        int tinhTrangMuonTra = Convert.ToInt32(row["Tình trạng mượn"].ToString());
                        //Lấy trạng thái sách và đơn giá sách
                        DataTable dtTrangThaiSachDonGia = mtDao.layTrangThaiSachTheoMaDS(MaDS);
                        int trangThaiSach = Convert.ToInt32(dtTrangThaiSachDonGia.Rows[0]["Trạng thái sách"].ToString());
                        double donGiaSach = Convert.ToDouble(dtTrangThaiSachDonGia.Rows[0]["DonGia"].ToString());
                        //MessageBox.Show(tinhTrangMuonTra.ToString());
                        if (trangThaiSach == 0)// Sách mới
                        {
                            if (tinhTrangMuonTra == 1) // trạng thái: đã trả
                            {
                                tienPhat += 0;
                            }
                            else if (tinhTrangMuonTra == 2)// trạng thái: trả trễ
                            {
                                DateTime ngayTraHienTai = DateTime.Today;
                                DateTime hanTra = Convert.ToDateTime(dtHanTra.Rows[0]["HanTra"].ToString());
                                TimeSpan difference = ngayTraHienTai - hanTra;
                                int days = (int)Math.Ceiling(difference.TotalDays);                                
                                tienPhat += days * 1000;
                            }
                        }
                        else if ((trangThaiSach == 1) || (trangThaiSach == 2)) //Sách hỏng hoặc mất đều đền và ko tính phí trả trễ
                        {
                            int MaLoaiDG = Convert.ToInt32(dtLoaiDG.Rows[0]["MaLoaiDG"].ToString());
                            if (MaLoaiDG == 1)// Sinh viên
                            {
                                tienPhat += donGiaSach * 3;
                            }
                            else if (MaLoaiDG == 2) //Giáo viên
                            {
                                tienPhat += donGiaSach * 2;
                            }
                        }
                        else if (trangThaiSach == 3) // Sách hư bìa đền 50K
                        {
                            if (tinhTrangMuonTra == 1)// Đã trả
                            {
                                tienPhat += 50000;      
                            }
                            else if (tinhTrangMuonTra == 2)// Trả trễ
                            {
                                DateTime ngayTraHienTai = DateTime.Today;
                                DateTime hanTra = Convert.ToDateTime(dtHanTra.Rows[0]["HanTra"].ToString());
                                TimeSpan difference = ngayTraHienTai - hanTra;
                                int days = (int)Math.Ceiling(difference.TotalDays);
                                tienPhat += 50000 + (days * 1000);
                            }
                            
                        }
                    }
                    //Tính tiền còn lại
                    double tienConLai = Convert.ToDouble(txtTienCoc.Text) - tienPhat;
                    txtTienPhat.Text = Convert.ToString(tienPhat);
                    txtTienTraLai.Text = Convert.ToString(tienConLai);
                    //cập nhật tiền phạt và tiền trả lại trong tblPhieuMuonTra
                    mtDao.CapNhatTienPhieuMuonTra(MaPM, Convert.ToDouble(txtTienTraLai.Text), Convert.ToDouble(txtTienPhat.Text));
                }
                // Thông báo trả sách thành công 
                MessageBox.Show("Trả sách thành công !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Load chi tiết phiếu mượn trả
                DataTable dtableCTPTra = mtService.TimCTPhieuTra(MaPM);
                dvCTPTra.Rows.Clear();
                if (dtableCTPTra.Rows.Count != 0)
                {
                    for (int i = 0; i < dtableCTPTra.Rows.Count; i++)
                    {
                        dvCTPTra.Rows.Add();
                        dvCTPTra.Rows[i].Cells["MaDauSach"].Value = dtableCTPTra.Rows[i]["Mã đầu sách"].ToString();
                        dvCTPTra.Rows[i].Cells["TenSach"].Value = dtableCTPTra.Rows[i]["Tên sách"].ToString();
                        dvCTPTra.Rows[i].Cells["TinhTrang"].Value = dtableCTPTra.Rows[i]["Tình trạng"].ToString();
                        dvCTPTra.Rows[i].Cells["NgayToiTra"].Value = Convert.ToString(DateTime.Today.ToShortDateString());
                        dvCTPTra.Rows[i].Cells["GiaSach"].Value = dtableCTPTra.Rows[i]["Đơn giá"].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sách bạn muốn trả !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu không check vào checkbox nào để trả sách thì thông báo
            if (!isChecked)
                MessageBox.Show("Hãy check vào sách bạn muốn trả !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
