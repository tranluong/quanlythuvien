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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmPhieuNhap : Form
    {
        DataTable dtable;
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtDG.Text = "";
            txtSL.Text = "";
            txtTT.Text = "";
            dateNgayNhap.Value = DateTime.Today;
            cboMaSach.SelectedIndex = 0;
            cboMaSach.Enabled = true;
            button1.Enabled = true;
            btnCapnhat.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            button2.Enabled = true;
            dataGridView2.DataSource = null;

        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            PhieuNhapService pn = new PhieuNhapService();
            PhieuNhapDao pnDao = new PhieuNhapDao();
            //Hiển thị combobox sách
            cboMaSach.DataSource = pn.loadCombox();
            cboMaSach.DisplayMember = "TenSach";
            cboMaSach.ValueMember = "MaSach";
            //Hiển thị form phiếu nhập
            gridPhieuNhap.DataSource = pn.HienThiPhieuNhap();
            txtTT.Enabled = false;
            //Tạo mới data trên form chi tiết phiếu nhập
            dtable = new DataTable();
            dtable.Columns.Add("Mã Sách");
            dtable.Columns.Add("Tên Sách");
            dtable.Columns.Add("Số Lượng");
            dtable.Columns.Add("Đơn giá");
            dtable.Columns.Add("Thành Tiền");
            dataGridView2.AllowUserToAddRows = false;
            button1.Enabled = false;
            from.Value = DateTime.Today.AddMonths(-1);
            //Fill dữ liệu qua chi tiết phiếu nhập
            txtCTMPN.Text = gridPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            dateNgayNhap.Value = Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells[3].Value);
            //Hiển thị chi tiết phiếu nhập            
            dataGridView2.DataSource = pnDao.HienThiChiTietPhieuNhap(int.Parse(txtCTMPN.Text));
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;            
            //disable combobox sách
            cboMaSach.Enabled = false;
            //fill data lên form chi tiết phiếu nhập
            cboMaSach.SelectedValue = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            txtSL.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtDG.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtTT.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            //Disable button lưu CSDL và Xóa
            btnThem.Enabled = false;
            button2.Enabled = false;
        }

        //Kiểm tra rỗng
        private string strError = "";
        private bool Validation()
        {
            if (txtSL.Text.Trim().Length == 0)
            {
                strError = "Nhập số lượng";
                txtSL.Focus();
                return false;
            }
            Match m1 = Regex.Match(txtSL.Text, @"^[0-9]+$");
            if (!m1.Success)
            {
                strError = "Số lượng chỉ nhập số";
                txtSL.Focus();
                return false;
            }
            if (Convert.ToInt32(txtSL.Text.Trim()) <= 0)
            {
                strError = "Số lượng phải lớn hơn 0";
                txtSL.Focus();
                return false;
            }


            if (txtDG.Text.Trim().Length == 0)
            {
                strError = "Nhập đơn giá";
                txtDG.Focus();
                return false;
            }
            Match m2 = Regex.Match(txtDG.Text, @"^[0-9]+$");
            if (!m2.Success)
            {
                strError = "Đơn giá chỉ nhập số";
                txtDG.Focus();
                return false;
            }
            if (Convert.ToInt32(txtDG.Text.Trim()) <= 0)
            {
                strError = "Đơn giá phải lớn hơn 0";
                txtSL.Focus();
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuNhap pn = new PhieuNhap();
                PhieuNhapService pnService = new PhieuNhapService();
                PhieuNhapDao pnDao = new PhieuNhapDao();
                DataGridViewRow vr = dataGridView2.CurrentRow;
                string MaPN = Convert.ToString(vr.Cells[5].Value);
                if (MessageBox.Show("Xóa chi tiết phiếu nhập: " + MaPN + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    pn.pMaPhieuNhap = Convert.ToInt32(vr.Cells[5].Value);
                    pn.pMaSach = Convert.ToInt32(vr.Cells[4].Value);
                    if (!pnService.DeleteChiTietPhieuNhap(pn))
                        MessageBox.Show(pnService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        dataGridView2.DataSource = pnDao.HienThiChiTietPhieuNhap(int.Parse(MaPN));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDG_TextChanged(object sender, EventArgs e)
        {
            Match m1 = Regex.Match(txtSL.Text, @"^[0-9]+$");
            Match m2 = Regex.Match(txtDG.Text, @"^[0-9]+$");
            if (!m1.Success)
            {
                return;
            }

            if (!m2.Success)
            {
                return;
            }

            if ((txtSL.Text.Trim().Length != 0) && (txtDG.Text.Trim().Length) != 0 && (m1.Success) && (m2.Success) )
            {
                double tt = Convert.ToInt16(txtSL.Text) * Convert.ToDouble(txtDG.Text);
                txtTT.Text = Convert.ToString(tt);
            }
            else
            {
                return;
            }
           
 
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PhieuNhap pn = new PhieuNhap();
                PhieuNhapDao pnDao = new PhieuNhapDao();
                float tongtien = 0;
                pn.pMaSach = Convert.ToInt16(cboMaSach.SelectedValue);
                pn.pSoLuong = Convert.ToInt32(txtSL.Text.Trim());
                pn.pDonGia = Convert.ToDouble(txtDG.Text.Trim());
                pn.pThanhTien = Convert.ToDouble(Convert.ToInt16(txtSL.Text) * Convert.ToDouble(txtDG.Text));
                pn.pNgayNhap = Convert.ToDateTime(dateNgayNhap.Value.Date);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    tongtien += Convert.ToInt32(dataGridView2.Rows[i].Cells["Thành Tiền"].Value);
                }
                pn.pTongTriGia = tongtien;
                pn.pMaPhieuNhap = Convert.ToInt32(dataGridView2.CurrentRow.Cells[5].Value);
                PhieuNhapService pnService = new PhieuNhapService();
                if (!pnService.SuaPhieuNhap(pn))
                {
                    MessageBox.Show(pnService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSL.Focus();
                }
                else
                {
                    int sLuongSach = pnService.getSLSach(Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value));
                    int sLuongUpdate = Convert.ToInt32(txtSL.Text.Trim());
                    int SL = sLuongSach + sLuongUpdate;
                    if (pnDao.capNhatSLSach(Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value),SL))
                    {
                        MessageBox.Show("Cập nhật thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                    dataGridView2.DataSource = pnDao.HienThiChiTietPhieuNhap(Convert.ToInt32(dataGridView2.CurrentRow.Cells[5].Value));
                }
            }
        }

        private void cboMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int fid = 0;
            //try
            //{
            //    fid = int.Parse(cboMaSach.SelectedValue.ToString());
            //    PhieuNhapService pnService = new PhieuNhapService();
            //    int SL = pnService.getSLSach(fid);
            //    txtSL.Text = Convert.ToString(SL);
            //}
            //catch (Exception ex)
            //{ }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cboMaSach.Enabled = true;
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var isAdded = false;
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        int ms = Convert.ToInt32(dataGridView2.Rows[i].Cells["Mã Sách"].Value);
                        if (ms == Convert.ToInt32(cboMaSach.SelectedValue))
                            isAdded = true;
                    }
                }

                if ((dataGridView2.Rows.Count > 0) && isAdded)
                {
                    MessageBox.Show("Vui lòng chọn sách khác", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataRow dr;
                    dr = dtable.NewRow();
                    dr["Mã Sách"] = cboMaSach.SelectedValue;
                    dr["Tên Sách"] = cboMaSach.Text;
                    dr["Số Lượng"] = txtSL.Text;
                    dr["Đơn Giá"] = txtDG.Text;
                    dr["Thành Tiền"] = txtTT.Text;

                    dtable.Rows.Add(dr);
                    dataGridView2.DataSource = dtable;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridView2.Rows.Remove(row);
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách nhập", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                List<PhieuNhap> pnList = new List<PhieuNhap>();
                PhieuNhap pn1 = new PhieuNhap();
                float tongtien = 0;
                pn1.pNgayNhap = Convert.ToDateTime(dateNgayNhap.Value.Date);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    tongtien += Convert.ToInt32(dataGridView2.Rows[i].Cells["Thành Tiền"].Value);
                }
                pn1.pTongTriGia = tongtien;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    PhieuNhap pn = new PhieuNhap();
                    int sl = Convert.ToInt32(dataGridView2.Rows[i].Cells["Số Lượng"].Value);
                    double dg = Convert.ToInt32(dataGridView2.Rows[i].Cells["Đơn Giá"].Value);
                    pn.pMaSach = Convert.ToInt32(dataGridView2.Rows[i].Cells["Mã Sách"].Value);
                    pn.pSoLuong = Convert.ToInt32(dataGridView2.Rows[i].Cells["Số Lượng"].Value);
                    pn.pDonGia = Convert.ToDouble(dataGridView2.Rows[i].Cells["Đơn Giá"].Value);
                    pn.pThanhTien = Convert.ToDouble(sl * dg);
                    pnList.Add(pn);

                }
                PhieuNhapService pnService = new PhieuNhapService();
                PhieuNhapDao pnDao = new PhieuNhapDao();
                DauSachService dsService = new DauSachService();
                if (!pnService.ThemPhieuNhap(pnList, pn1))
                {
                    MessageBox.Show(pnService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSL.Focus();
                }
                else
                {
                    button1.Enabled = false;
                    btnThem.Enabled = false;
                    button2.Enabled = false;
                    btnXoa.Enabled = true;
                    btnCapnhat.Enabled = true;
                    bool isAdded = false;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        int slUpdate = Convert.ToInt32(dataGridView2.Rows[i].Cells["Số Lượng"].Value);
                        int MaSach = Convert.ToInt32(dataGridView2.Rows[i].Cells["Mã Sách"].Value);
                        int sLuongSach = pnService.getSLSach(MaSach);
                        int SL = slUpdate + sLuongSach;
                        double donGia = Convert.ToInt32(dataGridView2.Rows[i].Cells["Đơn Giá"].Value);
                        if (pnDao.capNhatSLSachVaDonGia(MaSach, SL, donGia))
                        {
                            isAdded = true;                            
                        }

                        for (int j = 0; j < slUpdate; j++)
                        {
                            dsService.ThemDauSach(MaSach);
                        }
                    }
                    if (isAdded)
                    {
                        MessageBox.Show("Thêm phiếu thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    gridPhieuNhap.DataSource = pnService.HienThiPhieuNhap();
                    dataGridView2.DataSource = pnDao.HienThiChiTietPhieuNhap();
                    cboMaSach.SelectedValue = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                    txtSL.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    txtDG.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    txtTT.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                }
            }
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            Match m1 = Regex.Match(txtKeyword.Text, @"^[A-Za-z]+$");
            if (m1.Success)
            {
                strError = "Phiếu nhập chỉ nhập số";
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSL.Focus();
                return;
            }
            PhieuNhapService pnService = new PhieuNhapService();
            string _from = from.Value.ToString("yyyy-MM-dd");
            string _to = to.Value.ToString("yyyy-MM-dd");
            gridPhieuNhap.DataSource = pnService.SearchPhieuNhap(txtKeyword.Text, _from, _to);
        }

        private void gridPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCTMPN.Text = gridPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            dateNgayNhap.Value = Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells[3].Value);
            PhieuNhapDao pn = new PhieuNhapDao();
            dataGridView2.DataSource = pn.HienThiChiTietPhieuNhap(int.Parse(txtCTMPN.Text));
            dataGridView2.Columns[4].Visible = false;
        }
   
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
            btnCapnhat.Enabled = true;
            button1.Enabled = false;
            cboMaSach.Enabled = false;
            cboMaSach.SelectedValue = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            txtSL.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtDG.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtTT.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            Match m1 = Regex.Match(txtSL.Text, @"^[0-9]+$");
            Match m2 = Regex.Match(txtDG.Text, @"^[0-9]+$");
            if (!m1.Success)
            {
                return;
            }

            if (!m2.Success)
            {
                return;
            }

            if ((txtSL.Text.Trim().Length != 0) && (txtDG.Text.Trim().Length) != 0 && (m1.Success) && (m2.Success))
            {
                double tt = Convert.ToInt16(txtSL.Text) * Convert.ToDouble(txtDG.Text);
                txtTT.Text = Convert.ToString(tt);
            }
            else
            {
                return;
            }
  
        }

        private void btnXoaPhieuNhap_Click(object sender, EventArgs e)
        {
            PhieuNhapService pn = new PhieuNhapService();
            PhieuNhapDao pnDao = new PhieuNhapDao();
            if (gridPhieuNhap.Rows.Count > 0)
            {
                int MaPN = Convert.ToInt32(gridPhieuNhap.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("Xóa phiếu nhập: " + MaPN + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                    
                    if (pnDao.DeletePhieuNhap(MaPN))
                    {
                        MessageBox.Show("Xóa phiếu nhập thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                gridPhieuNhap.DataSource = pn.HienThiPhieuNhap();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
