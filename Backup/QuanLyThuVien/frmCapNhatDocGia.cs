using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace QuanLyThuVien
{
    public partial class frmCapNhatDocGia : Form
    {
        public frmCapNhatDocGia()
        {
            InitializeComponent();
            AcceptButton = btnTim;
            CancelButton = btnDong;            
        }

        private void frmCapNhatDocGia_Load(object sender, EventArgs e)
        {            
            cboLoaiDG.SelectedIndex = 0;
            cboDocgia.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;            

            txtKeyword.Focus();            
            /*ReaderService cls = new ReaderService();
            dataGridView1.DataSource = cls.ShowAllReader();
            if (cls.Error != "")
                MessageBox.Show(cls.Error,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);*/
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Reader clsReader = new Reader();
                clsReader.MaDocGia = txtMaDG.Text.Trim();
                clsReader.TenDocGia = txtTenDG.Text.Trim();
                clsReader.KhoaHoc = txtKhoaHoc.Text.Trim();
                clsReader.Khoa = txtKhoa.Text.Trim();
                clsReader.Nganh = txtNganh.Text.Trim();
                clsReader.Lop = txtLop.Text.Trim();
                clsReader.NgaySinh = dtNgaySinh.Value.Date;
                clsReader.NoiSinh = txtNoiSinh.Text.Trim();
                clsReader.GioiTinh = Convert.ToByte(radNam.Checked == true ? 1 : 0);
                clsReader.DiaChi = txtDiaChi.Text.Trim();
                clsReader.SoDT = txtSoDT.Text.Trim();
                clsReader.DatCoc = Convert.ToByte(chkDatCoc.Checked == true ? 1 : 0);
                if (chkDatCoc.Checked)
                {
                    clsReader.NgayDatCoc = DateTime.Today;
                    clsReader.NguoiNhanDatCoc = KiemTra.userid;
                }
                else
                {
                    clsReader.NgayDatCoc = DateTime.MinValue;
                    clsReader.NguoiNhanDatCoc = 0;
                }
                clsReader.LoaiDG = Convert.ToByte(cboLoaiDG.SelectedIndex);
                clsReader.NguoiCapNhat = KiemTra.userid;
                clsReader.NgayCapNhat = DateTime.Today;
                ReaderService clsReaderService = new ReaderService();
                if (!clsReaderService.CreateReader(clsReader))
                {
                    txtMaDG.Focus();
                    txtMaDG.SelectAll();
                    MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dataGridView1.DataSource = clsReaderService.SearchReader(0, clsReader.MaDocGia, 1);
                    if (clsReaderService.Error != "")
                        MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }        

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCount.Text = "Kết quả có " + dataGridView1.RowCount + " mẫu tin";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {            
            if (txtKeyword.Text != "")
            {
                int intFilter = cboFilter.SelectedIndex;
                int intType = cboDocgia.SelectedIndex;
                ReaderService cls = new ReaderService();
                dataGridView1.DataSource = cls.SearchReader(intType, txtKeyword.Text.Trim(), intFilter);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
        }

        private void FillForm(DataGridViewRow vr)
        {
            try
            {
                txtMaDG.Text = Convert.ToString(vr.Cells[0].Value);
                txtTenDG.Text = Convert.ToString(vr.Cells[1].Value);
                dtNgaySinh.Value = Convert.ToDateTime(vr.Cells[2].Value);
                if (Convert.ToString(vr.Cells[3].Value) == "Nam")
                    radNam.Checked = true;
                else
                    radNu.Checked = true;
                chkDatCoc.Checked = (Convert.ToByte(vr.Cells[4].Value) == 1 ? true : false);
                if (Convert.ToString(vr.Cells[5].Value) == "GVBC")
                    cboLoaiDG.SelectedIndex = 1;
                else
                    cboLoaiDG.SelectedIndex = 0;
                txtDiaChi.Text = Convert.ToString(vr.Cells[6].Value);
                txtSoDT.Text = Convert.ToString(vr.Cells[7].Value);
                txtNoiSinh.Text = Convert.ToString(vr.Cells[8].Value);
                txtKhoaHoc.Text = Convert.ToString(vr.Cells[9].Value);
                txtKhoa.Text = Convert.ToString(vr.Cells[10].Value);
                txtNganh.Text = Convert.ToString(vr.Cells[11].Value);
                txtLop.Text = Convert.ToString(vr.Cells[12].Value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                ReaderService clsReaderService = new ReaderService();                
                DataGridViewRow vr = dataGridView1.CurrentRow;
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
                        dataGridView1.DataSource = clsReaderService.SearchReader(cboDocgia.SelectedIndex, txtKeyword.Text, cboFilter.SelectedIndex);
                        if (clsReaderService.Error != "")
                            MessageBox.Show(clsReaderService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
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
                    clsReader.TenDocGia = txtTenDG.Text.Trim();
                    clsReader.KhoaHoc = txtKhoaHoc.Text.Trim();
                    clsReader.Khoa = txtKhoa.Text.Trim();
                    clsReader.Nganh = txtNganh.Text.Trim();
                    clsReader.Lop = txtLop.Text.Trim();
                    clsReader.NgaySinh = dtNgaySinh.Value.Date;
                    clsReader.NoiSinh = txtNoiSinh.Text.Trim();
                    clsReader.GioiTinh = Convert.ToByte(radNam.Checked == true ? 1 : 0);
                    clsReader.DiaChi = txtDiaChi.Text.Trim();
                    clsReader.SoDT = txtSoDT.Text.Trim();
                    clsReader.DatCoc = Convert.ToByte(chkDatCoc.Checked == true ? 1 : 0);
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (chkDatCoc.Checked && Convert.ToByte(vr.Cells[4].Value) == 0)
                    {
                        clsReader.NgayDatCoc = DateTime.Today;                        
                        clsReader.NguoiNhanDatCoc = KiemTra.userid;
                    }
                    else
                        clsReader.NgayDatCoc = DateTime.MinValue;
                    clsReader.LoaiDG = Convert.ToByte(cboLoaiDG.SelectedIndex);
                    clsReader.NguoiCapNhat = KiemTra.userid;
                    clsReader.NgayCapNhat = DateTime.Today;

                    string strReaderID = Convert.ToString(vr.Cells[0].Value);
                    ReaderService clsReaderService = new ReaderService();
                    if (clsReaderService.UpdateReader(strReaderID, clsReader))
                    {
                        dataGridView1.DataSource = clsReaderService.SearchReader(0, clsReader.MaDocGia, 1);
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
        
//Kiểm tra rỗng và loại bỏ dấu '
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
            if (txtTenDG.Text.Trim().Length == 0)
            {
                strError = "Nhập tên Độc giả";
                txtTenDG.Focus();
                return false;
            }
            if (DateTime.Today.Year - dtNgaySinh.Value.Year < 16) 
            {                
                strError = "Ngày sinh không hợp lệ (số tuổi phải lớn hơn 15)";
                dtNgaySinh.Focus();
                return false;
            }            
            return true;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaDG.Text = "";
            txtTenDG.Text = "";
            txtKhoaHoc.Text = "";
            txtKhoa.Text = "";
            txtNganh.Text = "";
            txtLop.Text = "";
            dtNgaySinh.Value = DateTime.Today;
            txtNoiSinh.Text = "";            
            radNam.Checked = true;            
            txtDiaChi.Text = "";
            txtSoDT.Text = "";
            chkDatCoc.Checked = false;
            cboLoaiDG.SelectedIndex = 0;
            dataGridView1.DataSource = null;
            txtMaDG.Focus();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "*.xls";
            openFileDialog1.Filter = "Excel files(*.xls)|*.xls";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLink.Text = openFileDialog1.FileName;   
            }
        }

        private bool CheckDataExcel(DataTable dt)
        {            
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["HoTen"].ToString().Length == 0)
                {
                    strError = "Dữ liệu cột HoTen chưa được nhập đầy đủ hoặc chưa cùng định dạng";
                    return false;
                }
                if (dr["MSSV"].ToString().Length != 10)
                {
                    strError = "MSSV " + dr["MSSV"].ToString() + " không hợp lệ (phải 10 ký tự) hoặc cột MSSV chưa cùng định dạng";                    
                    return false;
                }
                //Kiểm tra trùng MSSV trong CSDL
                ReaderService rs = new ReaderService();
                if (rs.SearchReader(0, dr["MSSV"].ToString(), 1).Rows.Count != 0)
                {
                    strError = "MSSV " + dr["MSSV"].ToString() + " đã tồn tại trong cơ sở dữ liệu";                    
                    return false;
                }
                //NgaySinh null
                if (dr["NgaySinh"] == DBNull.Value)
                {
                    strError = "Dữ liệu ở cột NgaySinh chưa được nhập đầy đủ hoặc chưa cùng định dạng";
                    return false;
                }
                //GioiTinh null
                if (dr["GioiTinh"] == DBNull.Value)
                {
                    strError = "Dữ liệu ở cột GioiTinh chưa được nhập đầy đủ hoặc chưa cùng định dạng";
                    return false;
                }
                //Kiểm tra giá trị NgaySinh
                DateTime dtTest;                
                try
                {
                    dtTest = Convert.ToDateTime(dr["NgaySinh"]);                    
                }
                catch
                {
                    strError = "Giá trị " + dr["NgaySinh"].ToString() + " ở cột NgaySinh không hợp lệ";
                    return false;
                }
                //Kiểm tra giá trị GioiTinh
                int intTest;
                try
                {                    
                    intTest = Convert.ToInt32(dr["GioiTinh"]);
                }
                catch
                {
                    strError = "Giá trị " + dr["GioiTinh"].ToString() + " ở cột GioiTinh không hợp lệ";
                    return false;
                }
                //Kiểm tra tuổi
                if (DateTime.Today.Year - dtTest.Year < 16)
                {
                    strError = "Ngày sinh không hợp lệ (số tuổi phải lớn hơn 15)";
                    return false;
                }
                //Kiểm tra giá trị giới tính 0 hay 1
                if (intTest < 0 || intTest > 1)
                {
                    strError = "Dữ liệu cột GioiTinh phải là 0 (Nữ) hoặc 1 (Nam)";
                    return false;
                }
            }
            //Kiểm tra trùng mssv trong file excel            
            foreach (DataRow dr in dt.Rows)
            {
                int intDem = 0;
                string strMSSV = "";
                foreach (DataRow dr2 in dt.Rows)
                {                    
                    if (dr["MSSV"].ToString() == dr2["MSSV"].ToString())
                    {                        
                        intDem++;
                        strMSSV = dr["MSSV"].ToString();
                    }
                    if (intDem > 1)
                    {
                        strError = "Có nhiều hơn 1 MSSV " + strMSSV + " trong file Excel";
                        return false;
                    }
                }
            }            

            return true;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLink.Text.Trim().Length != 0)
                {
                    ReaderService cls = new ReaderService();
                    DataTable dt = cls.ReadExcel(txtLink.Text.Trim());
                    if (cls.Error != "")
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {                        
                        if (!CheckDataExcel(dt))
                        {
                            MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (cls.InsertFromExcel(dt))
                            {
                                MessageBox.Show("Nhập thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtLink.Clear();
                            }
                            else
                                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nhập độc giả từ file excel thất bại", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}