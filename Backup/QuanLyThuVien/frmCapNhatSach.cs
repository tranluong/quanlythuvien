using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmCapNhatSach : Form
    {
        public frmCapNhatSach()
        {
            InitializeComponent();            
        }
        DataTable dt = new DataTable();
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            txtTuaSach2.Focus();
            lblSach.Text = "CẬP NHẬT SÁCH CÓ TẬP";
            AcceptButton = btnTim2;
            CancelButton = btnDong2;
        }
                
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            lblSach.Text = "CẬP NHẬT SÁCH KHÔNG TẬP";
            AcceptButton = btnTim1;
            CancelButton = btnDong1;
            txtSoDKCBTu1.Focus();            
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            lblSach.Text = "CẬP NHẬT ĐẦU SÁCH";
            AcceptButton = btnTim3;
            CancelButton = btnDong3;            
            txtTab3Keyword1.Focus();            
        }

        /*private void cboDauSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTab3Sach.SelectedIndex == 1)
            {
                //lblSoDKCBEnd.Visible = true;
                //txtTab3Keyword2.Visible = true;
                //cboTab3Filter.Location = new Point(534, 24);
            }
            else 
            {
                //lblSoDKCBEnd.Visible = false;
                //txtTab3Keyword2.Visible = false;
                //cboTab3Filter.Location = new Point(341, 24);
            }
        }*/

        private void btnNgonNgu_Click(object sender, EventArgs e)
        {            
            frmNgonNgu frm = new frmNgonNgu();
            frm.Show();
        }        

        private void btnDong1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNgonNgu1_Click(object sender, EventArgs e)
        {            
            frmNgonNgu frm = new frmNgonNgu();
            frm.StartPosition = FormStartPosition.CenterScreen;            
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                LanguageService cls = new LanguageService();
                cboNgonNgu1.DataSource = cls.ShowAllLang();                
            }
        }              

        private void txtSoDKCBTu1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }
          
        //Kiểm tra khi thêm
        private string strError = "";
        private bool Validation1()
        {
            if (txtSoDKCBTu1.Text.Length == 0)
            {
                txtSoDKCBTu1.Focus();
                txtSoDKCBTu1.SelectAll();
                strError = "Nhập Số ĐKCB bắt đầu";
                return false;
            }
            int intSoDKCBDen = 0;
            if (txtSoDKCBDen1.Text.Trim().Length == 0)
            {
                intSoDKCBDen = Convert.ToInt32(txtSoDKCBTu1.Text);
            }
            else
            {
                intSoDKCBDen = Convert.ToInt32(txtSoDKCBDen1.Text);
            }
            if (Convert.ToInt32(txtSoDKCBTu1.Text) > intSoDKCBDen)
            {
                txtSoDKCBDen1.Focus();
                txtSoDKCBDen1.SelectAll();
                strError = "Dãy số ĐKCB không hợp lệ";
                return false;
            }            
            if (txtTuaSach1.Text.Trim().Length == 0)
            {
                txtTuaSach1.Focus();
                txtTuaSach1.SelectAll();
                strError = "Nhập tựa sách";
                return false;
            }
            if (txtGiaBia1.Text.Length == 0)
            {
                txtGiaBia1.Focus();
                txtGiaBia1.SelectAll();
                strError = "Nhập giá bìa sách";
                return false;
            }
            if (Convert.ToInt32(txtGiaBia1.Text) <= 0)
            {
                txtGiaBia1.Focus();
                txtGiaBia1.SelectAll();
                strError = "Giá bìa sách phải lớn hơn 0";
                return false;
            }
            if (txtSoTrang1.Text.Length == 0)
            {
                txtSoTrang1.Focus();
                txtSoTrang1.SelectAll();
                strError = "Nhập số trang";
                return false;
            }
            if (Convert.ToInt32(txtSoTrang1.Text) <= 0)
            {
                txtSoTrang1.Focus();
                txtSoTrang1.SelectAll();
                strError = "Số trang phải lớn hơn 0";
                return false;
            }
            if (txtNamXB1.Text.Length < 4 || Convert.ToInt16(txtNamXB1.Text)>DateTime.Today.Year)
            {
                txtNamXB1.Focus();
                txtNamXB1.SelectAll();
                strError = "Năm xuất bản không hợp lệ (phải 4 chữ số)";
                return false;
            }
            if (dataGridView2.RowCount == 1)
            {
                dataGridView2.Focus();
                strError = "Nhập tác giả";
                return false;
            }
            else
            {
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                    if (dataGridView2.Rows[i].Cells[0].Value == null)
                    {
                        dataGridView2.Focus();
                        strError = "Chọn tác giả";
                        return false;
                    }
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                    for (int j = i+1; j < dataGridView2.RowCount - 1; j++)
                        if(Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value)==Convert.ToInt32(dataGridView2.Rows[j].Cells[0].Value))
                        {
                            dataGridView2.Focus();
                            strError = "Có ít nhất 2 tác giả giống nhau, xóa hoặc chọn tác giả khác";
                            return false;
                        }
            }
            if (txtLanTB1.Text.Length == 0)
            {
                strError = "Nhập lần tái bản";
                txtLanTB1.Focus();
                return false;
            }
            return true;
        }        
        //Thêm tab 1
        private void btnThem1_Click(object sender, EventArgs e)
        {
            if (!Validation1())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Book clsBook = new Book();
                clsBook.SoDKCBTu = Convert.ToInt32(txtSoDKCBTu1.Text);
                if (txtSoDKCBDen1.Text.Length != 0)
                {
                    clsBook.SoDKCBDen = Convert.ToInt32(txtSoDKCBDen1.Text);
                }
                else
                {
                    clsBook.SoDKCBDen = Convert.ToInt32(txtSoDKCBTu1.Text);
                }
                clsBook.TenTS = txtTuaSach1.Text.Trim();
                clsBook.TSMaHoa = txtTSMH1.Text.Trim();
                clsBook.KiHieuPL = txtKHPL1.Text.Trim();
                clsBook.MaNganh = Convert.ToInt32(cboNganhHoc1.SelectedValue);
                clsBook.MaNgonNgu = Convert.ToInt32(cboNgonNgu1.SelectedValue);                
                clsBook.MaNXB = Convert.ToInt32(cboNXB1.SelectedValue);
                clsBook.MaKho = Convert.ToInt32(cboKho1.SelectedValue);
                clsBook.GiaBia = Convert.ToInt32(txtGiaBia1.Text);
                clsBook.SoTrang = txtSoTrang1.Text;
                clsBook.NamXB = txtNamXB1.Text.Trim();
                clsBook.KichThuoc = txtKichThuoc1.Text.Trim();
                clsBook.DEWEY = txtDEWEY1.Text.Trim();
                clsBook.LanTB = Convert.ToByte(txtLanTB1.Text);
                clsBook.TomTat = txtTomTat1.Text.Trim();
                clsBook.ChuDe = txtChuDe1.Text.Trim();
                clsBook.TungThu = txtTungThu1.Text.Trim();
                clsBook.TuaSongSong = txtTuaSongSong1.Text.Trim();
                clsBook.TinhTrang = 0;
                clsBook.MaTap = 0;
                clsBook.NgayCapNhat = DateTime.Today;
                clsBook.NguoiCapNhat = KiemTra.userid;                
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    clsBook.TacGia[i, 0] = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);
                    clsBook.TacGia[i, 1] = (Convert.ToBoolean(dataGridView2.Rows[i].Cells[1].Value) == true ? 1 : 0);                    
                }                
                clsBook.Rows = dataGridView2.RowCount - 1;
                BookService clsBookService = new BookService();
                if (!clsBookService.CreateBook(clsBook))
                {
                    txtSoDKCBTu1.Focus();
                    txtSoDKCBTu1.SelectAll();
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dataGridView1.DataSource = clsBookService.SearchBook(0, Convert.ToString(clsBook.TenTS), 1);
                    if (clsBookService.Error != "")
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private DataTable dtTap = new DataTable();
        //private DataTable dtTacGia = new DataTable();
        //Form load
        private void frmCapNhatSach_Load(object sender, EventArgs e)
        {            
            cboTab2Sach.SelectedIndex = 0;
            cboTab2Filter.SelectedIndex = 0;            
//Tab 1
            cboTab1Sach.SelectedIndex = 0;
            cboTab1Filter.SelectedIndex = 0;
            //Fill vào combobox Ngành học
            NganhHocService cls1 = new NganhHocService();
            cboNganhHoc1.DataSource = new DataView(cls1.ShowAllNganh());
            cboNganhHoc1.DisplayMember = "Tên Ngành Học";
            cboNganhHoc1.ValueMember = "Mã Ngành Học";
            cboNganhHoc1.SelectedIndex = 0;
            //Fill vào combobox ngôn ngữ
            LanguageService cls2 = new LanguageService();
            cboNgonNgu1.DataSource = new DataView(cls2.ShowAllLang());
            cboNgonNgu1.DisplayMember = "Tên Ngôn Ngữ";
            cboNgonNgu1.ValueMember = "Mã Ngôn Ngữ";
            cboNgonNgu1.SelectedIndex = 0;
            //Fill vào combobox nhà xuất bản
            NhaXBService cls3 = new NhaXBService();
            cboNXB1.DataSource = new DataView(cls3.ShowAllNhaXB());
            cboNXB1.DisplayMember = "Tên Nhà XB";
            cboNXB1.ValueMember = "Mã Nhà XB";
            cboNXB1.SelectedIndex = 0;
            //Fill vào combobox kho chứa
            KhoChuaService cls4 = new KhoChuaService();
            cboKho1.DataSource = new DataView(cls4.ShowAllKho());
            cboKho1.DisplayMember = "Tên Kho Chứa";
            cboKho1.ValueMember = "Mã Kho Chứa";
            cboKho1.SelectedIndex = 0;
            //Fill vào datagridview Tác giả
            TacGiaService cls5 = new TacGiaService();
            cboTacGia1.DataSource = new DataView(cls5.ShowAllTG());
            cboTacGia1.DisplayMember = "Tên Tác Giả";
            cboTacGia1.ValueMember = "Mã Tác Giả";
//Tab 2
            cboTab2Sach.SelectedIndex = 0;
            cboTab2Filter.SelectedIndex = 0;
            //Fill vào combobox Ngành học            
            cboNganhHoc2.DataSource = new DataView(cls1.ShowAllNganh());
            cboNganhHoc2.DisplayMember = "Tên Ngành Học";
            cboNganhHoc2.ValueMember = "Mã Ngành Học";
            cboNganhHoc2.SelectedIndex = 0;
            //Fill vào combobox ngôn ngữ            
            cboNgonNgu2.DataSource = new DataView(cls2.ShowAllLang());
            cboNgonNgu2.DisplayMember = "Tên Ngôn Ngữ";
            cboNgonNgu2.ValueMember = "Mã Ngôn Ngữ";
            cboNgonNgu2.SelectedIndex = 0;
            //Fill vào combobox nhà xuất bản            
            cboNXB2.DataSource = new DataView(cls3.ShowAllNhaXB());
            cboNXB2.DisplayMember = "Tên Nhà XB";
            cboNXB2.ValueMember = "Mã Nhà XB";
            cboNXB2.SelectedIndex = 0;
            //Fill vào combobox kho chứa            
            cboKho2.DataSource = new DataView(cls4.ShowAllKho());
            cboKho2.DisplayMember = "Tên Kho Chứa";
            cboKho2.ValueMember = "Mã Kho Chứa";
            cboKho2.SelectedIndex = 0;
            //Fill vào datagridview Tác giả            
            cboTacGia2.DataSource = new DataView(cls5.ShowAllTG());
            cboTacGia2.DisplayMember = "Tên Tác Giả";
            cboTacGia2.ValueMember = "Mã Tác Giả";
            //cboTacGia22.DataSource = new DataView(cls5.ShowAllTG());
            //cboTacGia22.DisplayMember = "Tên Tác Giả";
            //cboTacGia22.ValueMember = "Mã Tác Giả";
            //Thong tin tap
            /*DataColumn dc = new DataColumn();
            dc.ColumnName = "SoDKCBTu";
            dtTap.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "SoDKCBDen";            
            dtTap.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Tap";
            dtTap.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "TenTap";
            dtTap.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "GiaBia";
            dtTap.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "SoTrang";
            dtTap.Columns.Add(dc);

            Tap.DataSource = dtTap;*/
            //Hiển thị tất cả sách có tập
            //BookService cls = new BookService();
            //TuaSachTap.DataSource = cls.ShowAllBookHasChapter();
            //if (cls.Error != "")
            //{
                //MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
//Tab 3
            cboTab3Sach.SelectedIndex = 6;
            cboTab3Filter.SelectedIndex = 0;
            //Fill vào combobox Ngành học
            //NganhHocService cls1 = new NganhHocService();
            cboNganhHoc3.DataSource = new DataView(cls1.ShowAllNganh());
            cboNganhHoc3.DisplayMember = "Tên Ngành Học";
            cboNganhHoc3.ValueMember = "Mã Ngành Học";
            cboNganhHoc3.SelectedIndex = 0;
            //Fill vào combobox ngôn ngữ
            //LanguageService cls2 = new LanguageService();
            cboNgonNgu3.DataSource = new DataView(cls2.ShowAllLang());
            cboNgonNgu3.DisplayMember = "Tên Ngôn Ngữ";
            cboNgonNgu3.ValueMember = "Mã Ngôn Ngữ";
            cboNgonNgu3.SelectedIndex = 0;
            //Fill vào combobox nhà xuất bản
            //NhaXBService cls3 = new NhaXBService();
            cboNXB3.DataSource = new DataView(cls3.ShowAllNhaXB());
            cboNXB3.DisplayMember = "Tên Nhà XB";
            cboNXB3.ValueMember = "Mã Nhà XB";
            cboNXB3.SelectedIndex = 0;
            //Fill vào combobox kho chứa
            //KhoChuaService cls4 = new KhoChuaService();
            cboKho3.DataSource = new DataView(cls4.ShowAllKho());
            cboKho3.DisplayMember = "Tên Kho Chứa";
            cboKho3.ValueMember = "Mã Kho Chứa";
            cboKho3.SelectedIndex = 0;
        }        

        private void btnNganhHoc1_Click(object sender, EventArgs e)
        {
            frmNganhHoc frm = new frmNganhHoc();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                NganhHocService cls = new NganhHocService();
                cboNganhHoc1.DataSource = cls.ShowAllNganh();
            }
        }

        private void btnNXB1_Click(object sender, EventArgs e)
        {
            frmNhaXB frm = new frmNhaXB();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                NhaXBService cls = new NhaXBService();
                cboNXB1.DataSource = cls.ShowAllNhaXB();
            }
        }

        private void btnKho1_Click(object sender, EventArgs e)
        {
            frmKhoChua frm = new frmKhoChua();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                KhoChuaService cls = new KhoChuaService();
                cboKho1.DataSource = cls.ShowAllKho();
            }
        }

        private void btnTacGia1_Click(object sender, EventArgs e)
        {
            frmTacgia frm = new frmTacgia();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                TacGiaService cls = new TacGiaService();                
                cboTacGia1.DataSource = cls.ShowAllTG();                
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCount1.Text = "Kết quả có " + dataGridView1.RowCount + " mẫu tin";
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (vr == null)
            {
                btnXoa1.Enabled = false;
                btnCapnhat1.Enabled = false;
                btnSuaTG.Enabled = false;

                dataGridView2.DataSource = null;
                cboTacGia1.Visible = true;
                chkChuBien1.Visible = true;
            }
            else
            {
                btnXoa1.Enabled = true;
                btnCapnhat1.Enabled = true;
                btnSuaTG.Enabled = true;
                FillForm1(vr);
                
                cboTacGia1.Visible = false;
                chkChuBien1.Visible = false;
            }
        }
        
        private void FillForm1(DataGridViewRow vr)
        {
            try
            {
                txtTuaSach1.Text = Convert.ToString(vr.Cells[1].Value);
                txtTSMH1.Text = Convert.ToString(vr.Cells[2].Value);
                txtKHPL1.Text = Convert.ToString(vr.Cells[3].Value);
                cboNganhHoc1.SelectedValue = (vr.Cells[4].Value);
                cboNgonNgu1.SelectedValue = (vr.Cells[5].Value);
                cboNXB1.SelectedValue = (vr.Cells[6].Value);
                txtNamXB1.Text = Convert.ToString(vr.Cells[7].Value);
                cboKho1.SelectedValue = vr.Cells[8].Value;
                txtGiaBia1.Text = Convert.ToString(vr.Cells[9].Value);
                txtSoTrang1.Text = Convert.ToString(vr.Cells[10].Value);
                txtKichThuoc1.Text = Convert.ToString(vr.Cells[11].Value);
                txtDEWEY1.Text = Convert.ToString(vr.Cells[12].Value);                
                txtTomTat1.Text = Convert.ToString(vr.Cells[13].Value);
                txtChuDe1.Text = Convert.ToString(vr.Cells[14].Value);
                txtLanTB1.Text = Convert.ToString(vr.Cells[15].Value);
                txtTungThu1.Text = Convert.ToString(vr.Cells[16].Value);
                txtTuaSongSong1.Text = Convert.ToString(vr.Cells[17].Value);
                int intMaTS = Convert.ToInt32(vr.Cells[0].Value);
                BookService cls = new BookService();
                dt = cls.ShowAuthor(intMaTS);                
                dataGridView2.DataSource = dt;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].Visible = false;
                
                dataGridView2.ReadOnly = true;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToDeleteRows = false;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Xóa tab 1
        private void btnXoa1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                string strTenTS = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa tựa sách: " + strTenTS + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intMaTS = Convert.ToInt32(vr.Cells[0].Value);
                    BookService cls = new BookService();
                    if (cls.DeleteBook(intMaTS))
                    {
                        dataGridView1.DataSource = cls.SearchBook(cboTab1Sach.SelectedIndex, txtTab1Keyword.Text, cboTab1Filter.SelectedIndex);
                        if (cls.Error != "")
                            MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTaoMoi1_Click(object sender, EventArgs e)
        {
            txtSoDKCBTu1.Text = ""; ;
            txtSoDKCBDen1.Text = "";
            txtTuaSach1.Text = "";
            txtTSMH1.Text = "";
            txtKHPL1.Text = "";
            cboNganhHoc1.SelectedIndex = 0;
            cboNgonNgu1.SelectedIndex = 0;
            cboNXB1.SelectedIndex = 0;
            cboKho1.SelectedIndex = 0;
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            txtGiaBia1.Text = "";
            txtSoTrang1.Text = "";
            txtNamXB1.Text = "";
            txtKichThuoc1.Text = "";
            txtDEWEY1.Text = "";
            txtLanTB1.Text = "0";
            txtTomTat1.Text = "";
            txtChuDe1.Text = "";
            txtTungThu1.Text = "";
            txtTuaSongSong1.Text = "";            
            dataGridView2.ReadOnly = false;
            dataGridView2.AllowUserToAddRows = true;
            dataGridView2.AllowUserToDeleteRows = true;
            dataGridView1.DataSource = null;
            txtSoDKCBTu1.Focus();
        }
        //Tìm tab 1
        private void btnTim1_Click(object sender, EventArgs e)
        {
            if (txtTab1Keyword.Text != "")
            {
                int intFilter = cboTab1Filter.SelectedIndex;
                int intType = cboTab1Sach.SelectedIndex;
                BookService cls = new BookService();
                dataGridView1.DataSource = cls.SearchBook(intType, txtTab1Keyword.Text.Trim(), intFilter);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTab1Keyword.Focus();
                txtTab1Keyword.SelectAll();
            }
        }
        //Kiểm tra khi cập nhật
        private bool Validation2()
        {
            if (txtTuaSach1.Text.Trim().Length == 0)
            {
                txtTuaSach1.Focus();
                txtTuaSach1.SelectAll();
                strError = "Nhập tựa sách";
                return false;
            }
            if (txtGiaBia1.Text.Length == 0)
            {
                txtGiaBia1.Focus();
                txtGiaBia1.SelectAll();
                strError = "Nhập giá bìa sách";
                return false;
            }
            if (Convert.ToInt32(txtGiaBia1.Text) <= 0)
            {
                txtGiaBia1.Focus();
                txtGiaBia1.SelectAll();
                strError = "Giá bìa sách phải lớn hơn 0";
                return false;
            }
            if (txtSoTrang1.Text.Length == 0)
            {
                txtSoTrang1.Focus();
                txtSoTrang1.SelectAll();
                strError = "Nhập số trang";
                return false;
            }
            if (Convert.ToInt32(txtSoTrang1.Text) <= 0)
            {
                txtSoTrang1.Focus();
                txtSoTrang1.SelectAll();
                strError = "Số trang phải lớn hơn 0";
                return false;
            }
            if (txtNamXB1.Text.Length < 4 || Convert.ToInt16(txtNamXB1.Text) > DateTime.Today.Year)
            {
                txtNamXB1.Focus();
                txtNamXB1.SelectAll();
                strError = "Năm xuất bản không hợp lệ (phải 4 chữ số)";
                return false;
            }
            if (txtLanTB1.Text.Length == 0)
            {
                strError = "Nhập lần tái bản";
                txtLanTB1.Focus();
                return false;
            }
            return true;
        }
        //Cập nhật
        private void btnCapnhat1_Click(object sender, EventArgs e)
        {            
            try                
            {                
                if (!Validation2())
                {
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
                else
                {                    
                    Book clsBook = new Book();                    
                    clsBook.TenTS = txtTuaSach1.Text.Trim();
                    clsBook.TSMaHoa = txtTSMH1.Text.Trim();
                    clsBook.KiHieuPL = txtKHPL1.Text.Trim();
                    clsBook.MaNganh = Convert.ToInt32(cboNganhHoc1.SelectedValue);
                    clsBook.MaNgonNgu = Convert.ToInt32(cboNgonNgu1.SelectedValue);
                    clsBook.MaNXB = Convert.ToInt32(cboNXB1.SelectedValue);
                    clsBook.MaKho = Convert.ToInt32(cboKho1.SelectedValue);
                    clsBook.GiaBia = Convert.ToInt32(txtGiaBia1.Text);
                    clsBook.SoTrang = txtSoTrang1.Text;
                    clsBook.NamXB = txtNamXB1.Text.Trim();
                    clsBook.KichThuoc = txtKichThuoc1.Text.Trim();
                    clsBook.DEWEY = txtDEWEY1.Text.Trim();
                    clsBook.LanTB = Convert.ToByte(txtLanTB1.Text);
                    clsBook.TomTat = txtTomTat1.Text.Trim();
                    clsBook.ChuDe = txtChuDe1.Text.Trim();
                    clsBook.TungThu = txtTungThu1.Text.Trim();
                    clsBook.TuaSongSong = txtTuaSongSong1.Text.Trim();
                    DataGridViewRow vr = dataGridView1.CurrentRow;                    
                    clsBook.MaTS = Convert.ToInt32(vr.Cells[0].Value);                    

                    BookService clsBookService = new BookService();
                    if (!clsBookService.UpdateBook(clsBook))
                    {
                        txtTuaSach1.Focus();
                        txtTuaSach1.SelectAll();
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dataGridView1.DataSource = clsBookService.SearchBook(0, Convert.ToString(clsBook.TenTS), 1);
                        if (clsBookService.Error != "")
                            MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Sửa tác giả sách không tập
        private void btnSuaTG_Click(object sender, EventArgs e)
        {
            frmTacGiaSach frm = new frmTacGiaSach();
            DataGridViewRow vr = dataGridView1.CurrentRow;
            frm.intMaTS = Convert.ToInt32(vr.Cells[0].Value);
            frm.strTuaSach = Convert.ToString(vr.Cells[1].Value);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                BookService cls = new BookService();
                //DataGridViewRow vr =dataGridView1.CurrentRow;

                dataGridView2.DataSource = cls.ShowAuthor(Convert.ToInt32(vr.Cells[0].Value));                 
                //dataGridView2.Columns[0].Visible = false;
                //dataGridView2.Columns[1].Visible = false;
                //dataGridView2.Columns[2].Visible = false;

                //dataGridView2.ReadOnly = true;
                //dataGridView2.AllowUserToDeleteRows = false;
            }
        }
        //Kiểm tra khi thêm đầu sách        
        private bool Validation3()
        {
            if (txtSoDKCBTu3.Text.Length == 0)
            {
                txtSoDKCBTu3.Focus();
                txtSoDKCBTu3.SelectAll();
                strError = "Nhập Số ĐKCB bắt đầu";
                return false;
            }
            if (txtSoDKCBDen3.Text.Length != 0)
            {
                if (Convert.ToInt32(txtSoDKCBTu3.Text) > Convert.ToInt32(txtSoDKCBDen3.Text))
                {
                    txtSoDKCBDen3.Focus();
                    txtSoDKCBDen3.SelectAll();
                    strError = "Dãy số ĐKCB không hợp lệ";
                    return false;
                }
            }
            return true;
        }
        //Thêm tab 3
        private void btnThem3_Click(object sender, EventArgs e)
        {
            if (!Validation3())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Book clsBook = new Book();
                clsBook.MaTS = Convert.ToInt32(txtSoMFN3.Text);
                clsBook.SoDKCBTu = Convert.ToInt32(txtSoDKCBTu3.Text);
                if (txtSoDKCBDen3.Text.Length != 0)
                    clsBook.SoDKCBDen = Convert.ToInt32(txtSoDKCBDen3.Text);
                else
                    clsBook.SoDKCBDen = clsBook.SoDKCBTu;
                //clsBook.TinhTrang = Convert.ToByte(cboTinhTrang3.SelectedIndex);
                clsBook.TinhTrang = 0;
                clsBook.NgayCapNhat = DateTime.Today;
                clsBook.NguoiCapNhat = KiemTra.userid;

                BookService clsBookService = new BookService();
                if (!clsBookService.AddBook(clsBook))
                {
                    txtSoDKCBTu3.Focus();
                    txtSoDKCBTu3.SelectAll();
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dataGridView11.DataSource = clsBookService.TimDauSach(1, Convert.ToString(clsBook.MaTS), 1);
                    if (clsBookService.Error != "")
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Tìm tab3
        private void btnTim3_Click(object sender, EventArgs e)
        {
            if (txtTab3Keyword1.Text != "")
            {
                int intFilter = cboTab3Filter.SelectedIndex;
                int intType = cboTab3Sach.SelectedIndex;
                BookService cls = new BookService();
                dataGridView11.DataSource = cls.TimDauSach(intType, txtTab3Keyword1.Text.Trim(), intFilter);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTab3Keyword1.Focus();
                txtTab3Keyword1.SelectAll();
            }
        }

        private void btnDong3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Fill form 3
        private void FillForm3(DataGridViewRow vr)
        {
            //try
            {
                txtTuaSach3.Text = Convert.ToString(vr.Cells["TenTS"].Value);
                txtTSMH3.Text = Convert.ToString(vr.Cells["TSMaHoa"].Value);
                txtKHPL3.Text = Convert.ToString(vr.Cells["KiHieuPL"].Value);
                cboNganhHoc3.SelectedValue = (vr.Cells["MaNganh"].Value);
                cboNgonNgu3.SelectedValue = (vr.Cells["MaNgonNgu"].Value);
                cboNXB3.SelectedValue = (vr.Cells["MaNXB"].Value);
                txtNamXB3.Text = Convert.ToString(vr.Cells["NamXB"].Value);
                cboKho3.SelectedValue = vr.Cells["MaKho"].Value;
                txtGiaBia3.Text = Convert.ToString(vr.Cells["GiaBia"].Value);
                txtSoTrang3.Text = Convert.ToString(vr.Cells["SoTrang"].Value);
                txtKichThuoc3.Text = Convert.ToString(vr.Cells["KichThuoc"].Value);
                txtDEWEY3.Text = Convert.ToString(vr.Cells["DEWEY"].Value);
                txtTomTat3.Text = Convert.ToString(vr.Cells["TomTat"].Value);
                txtChuDe3.Text = Convert.ToString(vr.Cells["ChuDe"].Value);
                txtLanTB3.Text = Convert.ToString(vr.Cells["LanTB"].Value);
                txtTungThu3.Text = Convert.ToString(vr.Cells["TungThu"].Value);
                txtTuaSongSong3.Text = Convert.ToString(vr.Cells["TuaSongSong"].Value);                
                cboTinhTrang3.SelectedIndex = Convert.ToInt32(Convert.ToString(vr.Cells["TinhTrang"].Value));
                txtGhiChu.Text = vr.Cells["GhiChu"].Value.ToString();
                int intMaTS = Convert.ToInt32(vr.Cells["MaTS"].Value);
                txtSoMFN3.Text = Convert.ToString(intMaTS);
                BookService cls = new BookService();
                dt = cls.ShowAuthor(intMaTS);
                dataGridView10.DataSource = dt;
                dataGridView10.Columns[0].Visible = false;
                dataGridView10.Columns[1].Visible = false;
                dataGridView10.Columns[2].Visible = false;
                int intMaTap = Convert.ToInt32(vr.Cells["MaTap"].Value);

                if (intMaTap != 0)
                {
                    dataGridView10.DataSource = cls.ShowAuthorChapter(intMaTap);
                    dataGridView10.Columns[0].Visible = false;
                    Book clsBook = cls.GetInfoChapter(intMaTap);
                    txtTap3.Text = clsBook.TapSo.ToString();
                    txtTenTap3.Text = clsBook.TenTap;
                    txtGiaBia3.Text = clsBook.GiaBia.ToString();
                    txtSoTrang3.Text = clsBook.SoTrang;
                }

                dataGridView10.ReadOnly = true;
                dataGridView10.AllowUserToDeleteRows = false;

            }
            //catch (Exception e)
            {
                //MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView11_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView11.CurrentRow;
            if (vr == null)
            {
                btnXoa3.Enabled = false;
                btnCapnhat3.Enabled = false;
                btnThem3.Enabled = false;
                cboTinhTrang3.Enabled = false;

                txtSoDKCBTu3.Enabled = false;
                txtSoDKCBDen3.Enabled = false;
            }
            else
            {
                btnXoa3.Enabled = true;
                btnCapnhat3.Enabled = true;
                btnThem3.Enabled = true;
                cboTinhTrang3.Enabled = true;

                txtSoDKCBTu3.Enabled = true;
                txtSoDKCBDen3.Enabled = true;
                FillForm3(vr);                
            }
        }

        private void dataGridView11_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCount3.Text = "Kết quả có " + dataGridView11.RowCount + " mẫu tin";
        }

        private void btnCapnhat3_Click(object sender, EventArgs e)
        {
            Book clsBook = new Book();
            DataGridViewRow vr = dataGridView11.CurrentRow;
            clsBook.SoDKCBTu = Convert.ToInt32(vr.Cells["SoDKCB"].Value);
            clsBook.TinhTrang = Convert.ToByte(cboTinhTrang3.SelectedIndex);
            clsBook.GhiChu = txtGhiChu.Text.Trim();
            BookService cls = new BookService();
            if (cls.EditBook(clsBook))
            {
                dataGridView11.DataSource = cls.TimDauSach(6, Convert.ToString(clsBook.SoDKCBTu), 1);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa3_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView11.CurrentRow;
                string strDauSach = Convert.ToString(vr.Cells["SoDKCB"].Value);
                if (MessageBox.Show("Xóa đầu sách có Số ĐKCB: " + strDauSach + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Book clsBook = new Book();
                    clsBook.SoDKCBTu=Convert.ToInt32(vr.Cells["SoDKCB"].Value);
                    BookService cls = new BookService();
                    if (cls.RemoveBook(clsBook))
                    {
                        dataGridView11.DataSource = cls.TimDauSach(cboTab3Sach.SelectedIndex, txtTab3Keyword1.Text, cboTab3Filter.SelectedIndex);
                        if (cls.Error != "")
                            MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView11.Focus();
                    }
                    else
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDong2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaomoi2_Click(object sender, EventArgs e)
        {            
            txtTuaSach2.Text = "";
            txtTSMH2.Text = "";
            txtKHPL2.Text = "";
            cboNganhHoc2.SelectedIndex = 0;
            cboNgonNgu2.SelectedIndex = 0;
            cboNXB2.SelectedIndex = 0;
            cboKho2.SelectedIndex = 0;
            txtNamXB2.Text = "";
            txtKichThuoc2.Text = "";
            txtDEWEY2.Text = "";
            txtLanTB2.Text = "0";
            txtTomTat2.Text = "";
            txtChuDe2.Text = "";
            txtTungThu2.Text = "";
            txtTuaSongSong2.Text = "";
            txtSoDKCBTu2.Text = "";
            txtSoDKCBDen2.Text = "";
            txtTap.Text = "";
            txtTenTap.Text = "";
            txtGiaBia2.Text = "";
            txtSoTrang2.Text = "";            
            TacGiaChung.ReadOnly = false;            
            TacGiaChung.AllowUserToAddRows = true;            
            dt.Rows.Clear();            
            TacGiaChung.AllowUserToDeleteRows = true;
            TacGiaChung.DataSource = null;
            TapbyTuaSach.DataSource = null;
            TuaSachTap.DataSource = null;
            txtTuaSach2.Focus();             
        }

        private void btnNganhHoc2_Click(object sender, EventArgs e)
        {
            frmNganhHoc frm = new frmNganhHoc();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                NganhHocService cls = new NganhHocService();
                cboNganhHoc2.DataSource = cls.ShowAllNganh();
            }
        }

        private void btnNgonNgu2_Click(object sender, EventArgs e)
        {
            frmNgonNgu frm = new frmNgonNgu();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                LanguageService cls = new LanguageService();
                cboNgonNgu2.DataSource = cls.ShowAllLang();
            }
        }

        private void btnNXB2_Click(object sender, EventArgs e)
        {
            frmNhaXB frm = new frmNhaXB();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                NhaXBService cls = new NhaXBService();
                cboNXB2.DataSource = cls.ShowAllNhaXB();
            }
        }

        private void btnKho2_Click(object sender, EventArgs e)
        {
            frmKhoChua frm = new frmKhoChua();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                KhoChuaService cls = new KhoChuaService();
                cboKho2.DataSource = cls.ShowAllKho();
            }
        }

        private void btnTacgia2_Click(object sender, EventArgs e)
        {
            frmTacgia frm = new frmTacgia();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                TacGiaService cls = new TacGiaService();
                cboTacGia2.DataSource = cls.ShowAllTG();
                //cboTacGia22.DataSource = cls.ShowAllTG();
            }
        }

        //Validation sách tập
        private bool ValidationTap()
        {
            if (txtTuaSach2.Text.Trim().Length == 0)
            {
                strError = "Nhập tựa sách";
                txtTuaSach2.Focus();
                return false;
            }                        
            if (txtNamXB2.Text.Length != 4 || Convert.ToInt16(txtNamXB2.Text) > DateTime.Today.Year)
            {
                txtNamXB2.Focus();
                txtNamXB2.SelectAll();
                strError = "Năm xuất bản không hợp lệ (phải 4 chữ số)";
                return false;
            }
            if (txtSoDKCBTu2.Text.Length == 0)
            {
                txtSoDKCBTu2.Focus();
                strError = "Nhập số ĐKCB từ";
                return false;
            }
            if (txtSoDKCBDen2.Text.Length != 0)
            {
                if (Convert.ToInt32(txtSoDKCBTu2.Text) > Convert.ToInt32(txtSoDKCBDen2.Text))
                {
                    txtSoDKCBDen2.Focus();
                    strError = "Dãy số ĐKCB không hợp lệ";
                    return false;
                }
            }
            if(txtTap.Text.Length==0)
            {
                txtTap.Focus();
                strError = "Nhập tập";
                return false;
            }
            if (Convert.ToInt32(txtTap.Text) <= 0)
            {
                txtTap.Focus();
                txtTap.SelectAll();
                strError = "Tập phải lớn hơn 0";
                return false;
            }
            if (txtTenTap.Text.Trim().Length == 0)
            {
                txtTenTap.Focus();
                strError = "Nhập tên tập";
                return false;
            }            
            if (txtGiaBia2.Text.Length == 0)
            {
                txtGiaBia2.Focus();
                strError = "Nhập giá bìa";
                return false;
            }
            if (Convert.ToInt32(txtGiaBia2.Text) <= 0)
            {
                txtGiaBia2.Focus();
                txtGiaBia2.SelectAll();
                strError = "Giá bìa phải lớn hơn 0";
                return false;
            }
            if (txtSoTrang2.Text.Length == 0)
            {
                txtSoTrang2.Focus();                
                strError = "Nhập số trang";
                return false;
            }
            if (Convert.ToInt32(txtSoTrang2.Text) <= 0)
            {
                txtSoTrang2.Focus();
                txtSoTrang2.SelectAll();
                strError = "Số trang phải lớn hơn 0";
                return false;
            }
            if (TacGiaChung.RowCount == 1)
            {
                TacGiaChung.Focus();
                strError = "Nhập tác giả (hoặc nhấn nút Tạo mới)";
                return false;
            }
            else
            {
                for (int i = 0; i < TacGiaChung.RowCount - 1; i++)
                    if (TacGiaChung.Rows[i].Cells[0].Value == null)
                    {
                        TacGiaChung.Focus();
                        strError = "Chọn tác giả";
                        return false;
                    }
                for (int i = 0; i < TacGiaChung.RowCount - 1; i++)
                    for (int j = i + 1; j < TacGiaChung.RowCount - 1; j++)
                        if (Convert.ToInt32(TacGiaChung.Rows[i].Cells[0].Value) == Convert.ToInt32(TacGiaChung.Rows[j].Cells[0].Value))
                        {
                            TacGiaChung.Focus();
                            strError = "Có ít nhất 2 tác giả giống nhau, xóa hoặc chọn tác giả khác";
                            return false;
                        }
            }
            if (txtLanTB2.Text.Length == 0)
            {
                strError = "Nhập lần tái bản";
                txtLanTB2.Focus();
                return false;
            }
            return true;
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            if (ValidationTap())
            {
                Book clsBook = new Book();
                clsBook.TenTS = txtTuaSach2.Text.Trim();
                clsBook.TSMaHoa = txtTSMH2.Text.Trim();
                clsBook.KiHieuPL = txtKHPL2.Text.Trim();                
                clsBook.MaNganh = Convert.ToInt32(cboNganhHoc2.SelectedValue);
                clsBook.MaNgonNgu = Convert.ToInt32(cboNgonNgu2.SelectedValue);
                clsBook.MaNXB = Convert.ToInt32(cboNXB2.SelectedValue);
                clsBook.MaKho = Convert.ToInt32(cboKho2.SelectedValue);                
                clsBook.NamXB = txtNamXB2.Text.Trim();
                clsBook.KichThuoc = txtKichThuoc2.Text.Trim();
                clsBook.DEWEY = txtDEWEY2.Text.Trim();
                clsBook.LanTB = Convert.ToByte(txtLanTB2.Text);
                clsBook.TomTat = txtTomTat2.Text.Trim();
                clsBook.ChuDe = txtChuDe2.Text.Trim();
                clsBook.TungThu = txtTungThu2.Text.Trim();
                clsBook.TuaSongSong = txtTuaSongSong2.Text.Trim();
                clsBook.SoDKCBTu = Convert.ToInt32(txtSoDKCBTu2.Text);
                if (txtSoDKCBDen2.Text.Length == 0)
                    clsBook.SoDKCBDen = clsBook.SoDKCBTu;
                else
                    clsBook.SoDKCBDen = Convert.ToInt32(txtSoDKCBDen2.Text);
                clsBook.TapSo = Convert.ToInt32(txtTap.Text);
                clsBook.TenTap = txtTenTap.Text.Trim();
                clsBook.GiaBia = Convert.ToInt32(txtGiaBia2.Text);
                clsBook.SoTrang = txtSoTrang2.Text.Trim();
                clsBook.TinhTrang = 0;                
                clsBook.NgayCapNhat = DateTime.Today;
                clsBook.NguoiCapNhat = KiemTra.userid;
                for (int i = 0; i < TacGiaChung.RowCount - 1; i++)
                {
                    clsBook.TacGia[i, 0] = Convert.ToInt32(TacGiaChung.Rows[i].Cells[0].Value);
                    clsBook.TacGia[i, 1] = (Convert.ToBoolean(TacGiaChung.Rows[i].Cells[1].Value) == true ? 1 : 0);
                }
                clsBook.Rows = TacGiaChung.RowCount - 1;                
                BookService clsBookService = new BookService();
                if (!clsBookService.CreateBookChapter(clsBook))
                {
                    txtSoDKCBTu2.Focus();
                    txtSoDKCBTu2.SelectAll();
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TuaSachTap.DataSource = clsBookService.SearchBookHasChapter(0, clsBook.TenTS.ToString(), 1);
                    //TuaSachTap.DataSource = clsBookService.ShowAllBookHasChapter();
                    if (clsBookService.Error != "")
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show(strError,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void TuaSachTap_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = TuaSachTap.CurrentRow;            
            if (vr == null)
            {
                btnXoa2.Enabled = false;                
                btnXoaTap.Enabled = false;
                btnCapnhat2.Enabled = false;
                btnSuaTG2.Enabled = false;
                btnThemTap.Enabled = false;

                TacGiaChung.DataSource = null;
                TapbyTuaSach.DataSource = null;                
                cboTacGia2.Visible = true;                
                chkChuBien2.Visible = true;
                btnThem2.Enabled = true;
            }
            else
            {
                int intMaTS = Convert.ToInt32(vr.Cells[0].Value);
                BookService cls = new BookService();
                TapbyTuaSach.DataSource = cls.ShowAllChapter(intMaTS);
                btnXoa2.Enabled = true;
                if (TapbyTuaSach.CurrentRow != null)
                    btnXoaTap.Enabled = true;
                else
                    btnXoaTap.Enabled = false;
                btnCapnhat2.Enabled = true;
                btnSuaTG2.Enabled = true;
                btnThemTap.Enabled = true;
                FillForm2(vr);

                cboTacGia2.Visible = false;                
                chkChuBien2.Visible = false;
                btnThem2.Enabled = false;
            }
        }

        private void FillForm2(DataGridViewRow vr)
        {
            try
            {
                txtTuaSach2.Text = Convert.ToString(vr.Cells[1].Value);
                txtTSMH2.Text = Convert.ToString(vr.Cells[2].Value);
                txtKHPL2.Text = Convert.ToString(vr.Cells[3].Value);
                cboNganhHoc2.SelectedValue = (vr.Cells[4].Value);
                cboNgonNgu2.SelectedValue = (vr.Cells[5].Value);
                cboNXB2.SelectedValue = (vr.Cells[6].Value);
                txtNamXB2.Text = Convert.ToString(vr.Cells[7].Value);
                cboKho2.SelectedValue = vr.Cells[8].Value;                
                txtKichThuoc2.Text = Convert.ToString(vr.Cells[11].Value);
                txtDEWEY2.Text = Convert.ToString(vr.Cells[12].Value);
                txtTomTat2.Text = Convert.ToString(vr.Cells[13].Value);
                txtChuDe2.Text = Convert.ToString(vr.Cells[14].Value);
                txtLanTB2.Text = Convert.ToString(vr.Cells[15].Value);
                txtTungThu2.Text = Convert.ToString(vr.Cells[16].Value);
                txtTuaSongSong2.Text = Convert.ToString(vr.Cells[17].Value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim2_Click(object sender, EventArgs e)
        {
            if (txtTab2Keyword.Text.Trim().Length != 0)
            {
                BookService cls = new BookService();
                TuaSachTap.DataSource = cls.SearchBookHasChapter(cboTab2Sach.SelectedIndex, txtTab2Keyword.Text.Trim(), cboTab2Filter.SelectedIndex);
                if (cls.Error != "")
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Validation khi thêm tập
        private bool ValidationThemTap()
        {
            if (txtSoDKCBTu2.Text.Length == 0)
            {
                txtSoDKCBTu2.Focus();
                strError = "Nhập số ĐKCB từ";
                return false;
            }
            if (txtSoDKCBDen2.Text.Length != 0)
            {
                if (Convert.ToInt32(txtSoDKCBTu2.Text) > Convert.ToInt32(txtSoDKCBDen2.Text))
                {
                    txtSoDKCBDen2.Focus();
                    strError = "Dãy số ĐKCB không hợp lệ";
                    return false;
                }
            }
            if (txtTap.Text.Length == 0)
            {
                txtTap.Focus();
                strError = "Nhập tập";
                return false;
            }
            if (Convert.ToInt32(txtTap.Text) <= 0)
            {
                txtTap.Focus();
                txtTap.SelectAll();
                strError = "Tập phải lớn hơn 0";
                return false;
            }
            if (txtTenTap.Text.Trim().Length == 0)
            {
                txtTenTap.Focus();
                strError = "Nhập tên tập";
                return false;
            }
            if (txtGiaBia2.Text.Length == 0)
            {
                txtGiaBia2.Focus();
                strError = "Nhập giá bìa";
                return false;
            }
            if (Convert.ToInt32(txtGiaBia2.Text) <= 0)
            {
                txtGiaBia2.Focus();
                txtGiaBia2.SelectAll();
                strError = "Giá bìa phải lớn hơn 0";
                return false;
            }
            if (txtSoTrang2.Text.Length == 0)
            {
                txtSoTrang2.Focus();                
                strError = "Nhập số trang";
                return false;
            }
            if (Convert.ToInt32(txtSoTrang2.Text) <= 0)
            {
                txtSoTrang2.Focus();
                txtSoTrang2.SelectAll();
                strError = "Số trang phải lớn hơn 0";
                return false;
            }
            return true;
        }

        private void btnThemTap_Click(object sender, EventArgs e)
        {
            if (ValidationThemTap())
            {
                Book clsBook = new Book();
                clsBook.MaTS = Convert.ToInt32(TuaSachTap.CurrentRow.Cells["MaTS"].Value);
                clsBook.SoDKCBTu = Convert.ToInt32(txtSoDKCBTu2.Text);
                if (txtSoDKCBDen2.Text.Length == 0)
                    clsBook.SoDKCBDen = clsBook.SoDKCBTu;
                else
                    clsBook.SoDKCBDen = Convert.ToInt32(txtSoDKCBDen2.Text);
                clsBook.TapSo = Convert.ToInt32(txtTap.Text);
                clsBook.TenTap = txtTenTap.Text.Trim();
                clsBook.GiaBia = Convert.ToInt32(txtGiaBia2.Text);
                clsBook.SoTrang = txtSoTrang2.Text.Trim();
                clsBook.TinhTrang = 0;
                clsBook.NgayCapNhat = DateTime.Today;
                clsBook.NguoiCapNhat = KiemTra.userid;                               
                
                BookService clsBookService = new BookService();
                int intMaTap = Convert.ToInt32(TapbyTuaSach.CurrentRow.Cells["MaTap"].Value);
                clsBook.TacGiaTap = clsBookService.ShowAuthorChapter(intMaTap);
                if(clsBookService.IsExistChapter(clsBook))
                {
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTap.Focus();
                    txtTap.SelectAll();
                    return;
                }
                if (clsBookService.IsExistChapterName(clsBook))
                {
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenTap.Focus();
                    txtTenTap.SelectAll();
                    return;
                }
                if (!clsBookService.AddChapter(clsBook))
                {
                    txtSoDKCBTu2.Focus();
                    txtSoDKCBTu2.SelectAll();
                    MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TuaSachTap.DataSource = clsBookService.SearchBookHasChapter(1, clsBook.MaTS.ToString(), 1);                    
                    if (clsBookService.Error != "")
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TapbyTuaSach_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = TapbyTuaSach.CurrentRow;
            if (vr != null)
            {                             
                FillForm2Tap(vr);
            }
        }        
        private void FillForm2Tap(DataGridViewRow vr)
        {
            try
            {
                txtTap.Text = vr.Cells["TapSo"].Value.ToString();
                txtTenTap.Text = vr.Cells["TenTap"].Value.ToString();
                txtGiaBia2.Text = vr.Cells["GiaBia"].Value.ToString();
                txtSoTrang2.Text = vr.Cells["SoTrang"].Value.ToString();
                int intMaTap = Convert.ToInt32(vr.Cells["MaTap"].Value);
                BookService cls = new BookService();
                dt = cls.ShowAuthorChapter(intMaTap);
                TacGiaChung.DataSource = dt;
                TacGiaChung.Columns["MaTG"].Visible = false;

                TacGiaChung.ReadOnly = true;
                TacGiaChung.AllowUserToAddRows = false;
                TacGiaChung.AllowUserToDeleteRows = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TapbyTuaSach_DataSourceChanged(object sender, EventArgs e)
        {
            groupBox14.Text = "(" + TapbyTuaSach.RowCount.ToString() + " tập)";            
        }        

        private void TuaSachTap_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCount2.Text = "Kết quả có " + TuaSachTap.RowCount + " mẫu tin";
        }

        private void btnSuaTG2_Click(object sender, EventArgs e)
        {
            frmTacGiaSachTap frm = new frmTacGiaSachTap();
            DataGridViewRow vr = TapbyTuaSach.CurrentRow;
            frm.intMaTap = Convert.ToInt32(vr.Cells[0].Value);
            frm.strTenTap = Convert.ToString(vr.Cells[2].Value);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                BookService cls = new BookService();
                TacGiaChung.DataSource = cls.ShowAuthorChapter(Convert.ToInt32(vr.Cells[0].Value));                
            }
        }

        private void btnXoaTap_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = TapbyTuaSach.CurrentRow;
                string strTenTS = Convert.ToString(vr.Cells[2].Value);
                if (MessageBox.Show("Xóa tập sách: " + strTenTS + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intMaTap = Convert.ToInt32(vr.Cells[0].Value);
                    BookService cls = new BookService();
                    if (cls.DeleteBookChapter(intMaTap))
                    {
                        TapbyTuaSach.DataSource = cls.ShowAllChapter(Convert.ToInt32(TuaSachTap.CurrentRow.Cells["MaTS"].Value));
                        if (cls.Error != "")
                            MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (TapbyTuaSach.RowCount == 0)
                            {
                                try
                                {
                                    DataGridViewRow vrTS = TuaSachTap.CurrentRow;
                                    int intMaTS = Convert.ToInt32(vrTS.Cells[0].Value);
                                    BookService clsBS = new BookService();
                                    if (clsBS.XoaTuaSachTap(intMaTS))
                                    {
                                        TuaSachTap.DataSource = clsBS.SearchBookHasChapter(cboTab2Sach.SelectedIndex, txtTab2Keyword.Text, cboTab2Filter.SelectedIndex);
                                        TuaSachTap.Focus();
                                        if (clsBS.Error != "")
                                            MessageBox.Show(clsBS.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                                                                                    
                                    }
                                    else
                                        MessageBox.Show(clsBS.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                                TapbyTuaSach.Focus();
                        }
                    }
                    else
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = TuaSachTap.CurrentRow;
                string strTenTS = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa tựa sách: " + strTenTS + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intMaTS = Convert.ToInt32(vr.Cells[0].Value);
                    BookService cls = new BookService();
                    if (cls.XoaTuaSachTap(intMaTS))
                    {
                        TuaSachTap.DataSource = cls.SearchBookHasChapter(cboTab2Sach.SelectedIndex, txtTab2Keyword.Text, cboTab2Filter.SelectedIndex);
                        if (cls.Error != "")
                            MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            TuaSachTap.Focus();
                    }
                    else
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Validation khi cập nhật
        private bool ValidationTapUpdate()
        {
            if (txtTuaSach2.Text.Trim().Length == 0)
            {
                strError = "Nhập tựa sách";
                txtTuaSach2.Focus();
                return false;
            }
            if (txtNamXB2.Text.Length != 4 || Convert.ToInt16(txtNamXB2.Text) > DateTime.Today.Year)
            {
                txtNamXB2.Focus();
                txtNamXB2.SelectAll();
                strError = "Năm xuất bản không hợp lệ (phải 4 chữ số)";
                return false;
            }            
            if (txtTap.Text.Length == 0)
            {
                txtTap.Focus();
                strError = "Nhập tập";
                return false;
            }
            if (Convert.ToInt32(txtTap.Text) <= 0)
            {
                txtTap.Focus();
                txtTap.SelectAll();
                strError = "Tập phải lớn hơn 0";
                return false;
            }
            if (txtTenTap.Text.Trim().Length == 0)
            {
                txtTenTap.Focus();
                strError = "Nhập tên tập";
                return false;
            }
            if (txtGiaBia2.Text.Length == 0)
            {
                txtGiaBia2.Focus();
                strError = "Nhập giá bìa";
                return false;
            }
            if (Convert.ToInt32(txtGiaBia2.Text) <= 0)
            {
                txtGiaBia2.Focus();
                txtGiaBia2.SelectAll();
                strError = "Giá bìa phải lớn hơn 0";
                return false;
            }
            if (txtSoTrang2.Text.Length == 0)
            {
                txtSoTrang2.Focus();
                strError = "Nhập số trang";
                return false;
            }
            if (Convert.ToInt32(txtSoTrang2.Text) <= 0)
            {
                txtSoTrang2.Focus();
                txtSoTrang2.SelectAll();
                strError = "Số trang phải lớn hơn 0";
                return false;
            }
            if (txtLanTB2.Text.Length == 0)
            {
                strError = "Nhập lần tái bản";
                txtLanTB2.Focus();
                return false;
            }
            return true;
        }
        private void btnCapnhat2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidationTapUpdate())
                {
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Book clsBook = new Book();
                    clsBook.TenTS = txtTuaSach2.Text.Trim();
                    clsBook.TSMaHoa = txtTSMH2.Text.Trim();
                    clsBook.KiHieuPL = txtKHPL2.Text.Trim();
                    clsBook.MaNganh = Convert.ToInt32(cboNganhHoc2.SelectedValue);
                    clsBook.MaNgonNgu = Convert.ToInt32(cboNgonNgu2.SelectedValue);
                    clsBook.MaNXB = Convert.ToInt32(cboNXB2.SelectedValue);
                    clsBook.MaKho = Convert.ToInt32(cboKho2.SelectedValue);
                    clsBook.NamXB = txtNamXB2.Text.Trim();
                    clsBook.KichThuoc = txtKichThuoc2.Text.Trim();
                    clsBook.DEWEY = txtDEWEY2.Text.Trim();
                    clsBook.LanTB = Convert.ToByte(txtLanTB2.Text);
                    clsBook.TomTat = txtTomTat2.Text.Trim();
                    clsBook.ChuDe = txtChuDe2.Text.Trim();
                    clsBook.TungThu = txtTungThu2.Text.Trim();
                    clsBook.TuaSongSong = txtTuaSongSong2.Text.Trim();                    
                    clsBook.TapSo = Convert.ToInt32(txtTap.Text);
                    clsBook.TenTap = txtTenTap.Text.Trim();
                    clsBook.GiaBia = Convert.ToInt32(txtGiaBia2.Text);
                    clsBook.SoTrang = txtSoTrang2.Text.Trim();
                    clsBook.TinhTrang = 0;
                    clsBook.NgayCapNhat = DateTime.Today;
                    clsBook.NguoiCapNhat = KiemTra.userid;
                    clsBook.MaTS = Convert.ToInt32(TuaSachTap.CurrentRow.Cells["MaTS"].Value);
                    clsBook.MaTap = Convert.ToInt32(TapbyTuaSach.CurrentRow.Cells["MaTap"].Value);
                    BookService clsBookService = new BookService();
                    if (clsBookService.IsExistChapter(clsBook,Convert.ToInt32(TapbyTuaSach.CurrentRow.Cells["TapSo"].Value)))
                    {
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTap.Focus();
                        txtTap.SelectAll();
                        return;
                    }
                    if (clsBookService.IsExistChapterName(clsBook, TapbyTuaSach.CurrentRow.Cells["TenTap"].Value.ToString()))
                    {
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenTap.Focus();
                        txtTenTap.SelectAll();
                        return;
                    }
                    if (!clsBookService.UpdateBookChapter(clsBook))
                    {                        
                        MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        TuaSachTap.DataSource = clsBookService.SearchBookHasChapter(1, Convert.ToString(clsBook.MaTS), 1);
                        if (clsBookService.Error != "")
                            MessageBox.Show(clsBookService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTinhTrang3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTinhTrang3.SelectedIndex == 2)
            {
                txtGhiChu.Enabled = true;
            }
            else
            {
                txtGhiChu.Enabled = false;
            }
        }
    }
}