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
    public partial class frmDocGia : Form
    {
        public frmDocGia()
        {
            InitializeComponent();
            AcceptButton = btnTim;
            CancelButton = btnDong;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            ReaderService clsReader = new ReaderService();
            dataGridViewDocGia.DataSource = clsReader.ShowAllReader();
            if (clsReader.Error != "")
                MessageBox.Show(clsReader.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            // TODO: This line of code loads data into the 'thuvienDataSet.tblNhanVien' table. You can move, or remove it, as needed.
            this.tblNhanVienTableAdapter.Fill(this.thuvienDataSet.tblNhanVien);
            // TODO: This line of code loads data into the 'thuvienDataSet.tblLoaiDocGia' table. You can move, or remove it, as needed.
            this.tblLoaiDocGiaTableAdapter.Fill(this.thuvienDataSet.tblLoaiDocGia);
            cboMaLoaiDocGia.SelectedIndex = 0;
        }
        private void FillForm(DataGridViewRow vr)
        {
            
            try
            {
                txtMaDG.Text = Convert.ToString(vr.Cells[0].Value);
                txtTenDocGia.Text = Convert.ToString(vr.Cells[1].Value);
                dateNgaySinh.Value = Convert.ToDateTime(vr.Cells[2].Value);
                txtNoiSinh.Text = Convert.ToString(vr.Cells[3].Value);
                if (Convert.ToString(vr.Cells[4].Value) == "Nam")
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;
                txtDiaChi.Text = Convert.ToString(vr.Cells[5].Value);    
                txtSDT.Text = Convert.ToString(vr.Cells[6].Value);
                txtTienDatCoc.Text = Convert.ToString(vr.Cells[7].Value);
                
                dateNDatCoc.Value = Convert.ToDateTime(vr.Cells[8].Value); 
                cboNhanVien.Text = Convert.ToString(vr.Cells[9].Value);
                cboMaLoaiDocGia.Text = Convert.ToString(vr.Cells[10].Value);
                dateNBatDau.Value = Convert.ToDateTime(vr.Cells[11].Value);// kiem tra dong nay
                dateNKetThuc.Value = Convert.ToDateTime(vr.Cells[12].Value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string strError = "";
        private bool Validation()
        {
            if (txtMaDG.Text.Trim().Length == 0)
            {
                strError = "Nhập mã độc giả";
                txtMaDG.Focus();
                return false;
            }
            if (txtMaDG.Text.Trim().Length != 10)
            {
                strError = "Mã độc giả không hợp lệ (phải 10 ký tự)";
                txtMaDG.Focus();
                return false;
            }
            if (txtTenDocGia.Text.Trim().Length == 0)
            {
                strError = "Nhập tên Độc giả";
                txtTenDocGia.Focus();
                return false;
            }
            if (DateTime.Today.Year - dateNgaySinh.Value.Year < 16)
            {
                strError = "Ngày sinh không hợp lệ (số tuổi phải lớn hơn 15)";
                dateNgaySinh.Focus();
                return false;
            }
            return true;
        }

        private void dataGridViewDocGia_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridViewDocGia.CurrentRow;
            if (vr == null)
            {
                btnXoa.Enabled = false;
                btnCapnhat.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
                btnCapnhat.Enabled = true;
                FillForm(vr);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Reader clsReader = new Reader();
                    clsReader.MaDocGia = txtMaDG.Text.Trim();
                    clsReader.TenDocGia = txtTenDocGia.Text.Trim();
                    clsReader.NgaySinh = dateNgaySinh.Value.Date;
                    clsReader.NoiSinh = txtNoiSinh.Text.Trim();
                    clsReader.GioiTinh = Convert.ToByte(rdoNam.Checked == true ? 1 : 0);
                    clsReader.DiaChi = txtDiaChi.Text.Trim();
                    clsReader.SoDT = txtSDT.Text.Trim();
                    //int test;
                    clsReader.TienDatCoc = Convert.ToInt32(txtTienDatCoc.Text.Trim());
                    clsReader.NgayDatCoc = DateTime.Today;
                    clsReader.MaNhanVien = KiemTra.userid;
                   // clsReader.LoaiDG = Convert.ToByte(KiemTra.userid); 
                    clsReader.NgayDatCoc = DateTime.MinValue;
                    clsReader.LoaiDG = Convert.ToByte(cboMaLoaiDocGia.SelectedValue);
                    clsReader.ThoiGianBatDau = dateNBatDau.Value.Date;
                    clsReader.ThoiGianKetThuc = dateNKetThuc.Value.Date;
                    DataGridViewRow vr = dataGridViewDocGia.CurrentRow;
                    string strReaderID = Convert.ToString(vr.Cells[0].Value);
                    ReaderService clsReaderService = new ReaderService();
                    if (clsReaderService.UpdateReader(strReaderID, clsReader))
                    {
                        dataGridViewDocGia.DataSource = clsReaderService.SearchReader(0, clsReader.MaDocGia, 1);
                        if (clsReaderService.Error != "")
                            MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtMaDG.Focus();
                        txtMaDG.SelectAll();
                        MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text != "")
            {
                int intFilter = cboFilter.SelectedIndex;
                int intType = cboDocGia.SelectedIndex;
                ReaderService cls = new ReaderService();
                dataGridViewDocGia.DataSource = cls.SearchReader(intType, txtKeyword.Text.Trim(), intFilter);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaDG.Text = "";
            txtTenDocGia.Text = "";
            dateNgaySinh.Value = DateTime.Today;
            txtNoiSinh.Text = "";
            rdoNam.Checked = true;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTienDatCoc.Text = "";
            dateNDatCoc.Value = DateTime.Today;
            cboMaLoaiDocGia.SelectedIndex = 0;
            dateNBatDau.Value = DateTime.Today;
            dateNKetThuc.Value = DateTime.Today;
            dataGridViewDocGia.DataSource = null;
            txtMaDG.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderService clsReaderService = new ReaderService();
                DataGridViewRow vr = dataGridViewDocGia.CurrentRow;
                if (!clsReaderService.TraHetSach(vr.Cells[0].Value.ToString()))
                    MessageBox.Show("Độc giả này chưa trả hết tài liệu cho thư viện", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string strReaderName = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa độc giả: " + strReaderName + " ? Chú ý: thông tin mượn trả của độc giả này cũng sẽ bị xóa luôn !", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Reader clsReader = new Reader();
                    clsReader.MaDocGia = Convert.ToString(vr.Cells[0].Value);
                    //ReaderService clsReaderService = new ReaderService();
                    if (clsReaderService.DeleteReader(clsReader))
                    {
                        dataGridViewDocGia.DataSource = clsReaderService.SearchReader(cboDocGia.SelectedIndex, txtKeyword.Text, cboFilter.SelectedIndex);
                        if (clsReaderService.Error != "")
                            MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridViewDocGia.Focus();
                    }
                    else
                        MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Reader clsReader = new Reader();
                clsReader.MaDocGia = txtMaDG.Text.Trim();
                clsReader.TenDocGia = txtTenDocGia.Text.Trim();
                clsReader.NgaySinh = Convert.ToDateTime(dateNgaySinh.Value.Date);
                clsReader.NoiSinh = txtNoiSinh.Text.Trim();
                clsReader.GioiTinh = Convert.ToByte(rdoNam.Checked == true ? 1 : 0);
                clsReader.DiaChi = txtDiaChi.Text.Trim();
                clsReader.SoDT = txtSDT.Text.Trim();
                clsReader.TienDatCoc = Convert.ToInt32(txtTienDatCoc.Text.Trim());
                clsReader.NgayDatCoc = DateTime.Today;
                clsReader.MaNhanVien = KiemTra.userid;
                clsReader.MaNhanVien = Convert.ToInt16(cboNhanVien.SelectedValue);// vua them
                clsReader.LoaiDG = Convert.ToInt16(cboMaLoaiDocGia.SelectedValue);
                // clsReader.LoaiDG = Convert.ToByte(KiemTra.userid);
                clsReader.NgayDatCoc = dateNDatCoc.Value.Date;
                clsReader.ThoiGianBatDau = dateNBatDau.Value.Date;
                clsReader.ThoiGianKetThuc = dateNKetThuc.Value.Date;
                //DataGridViewRow vr = dataGridViewDocGia.CurrentRow;
                //string strReaderID = Convert.ToString(vr.Cells[0].Value);
                ReaderService clsReaderService = new ReaderService();
                if (clsReaderService.CreateReader(clsReader))
                {
                    dataGridViewDocGia.DataSource = clsReaderService.SearchReader(0, clsReader.MaDocGia, 1);
                    if (clsReaderService.Error != "")
                        MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtMaDG.Focus();
                    txtMaDG.SelectAll();
                    MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnfrmLoaiDocGia_Click(object sender, EventArgs e)
        {
            frmLoaiDocGia frm = new frmLoaiDocGia();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtTienDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

      
    }
}
