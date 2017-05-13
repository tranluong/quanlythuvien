using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmMuonTra : Form
    {
        public frmMuonTra()
        {
            InitializeComponent();
        }
        HeThong clsParam = new HeThong();
        MuonTra clsMuonTra = new MuonTra();

      
        //Điền vào thông tin độc giả
        private void FillReader(MuonTra clsDG)
        {
            txtMaDG.Text = clsDG.MaDG;
            txtTenDG.Text = clsDG.TenDG;
            txtSoTienDC.Text = clsDG.TienDatCoc.ToString();
            if(Convert.ToInt16(clsDG.LoaiDG.ToString()) ==1)
            {
                txtLoaiDG.Text = "Sinh Viên";
            }
            else
            {
                txtLoaiDG.Text = "Giáo Viên";
            }
            //txtLoaiDG.Text = clsDG.LoaiDG.ToString();
            txtSLMuonVe.Text = clsDG.SoCuonMuonVe.ToString();
        }
        //Khởi tạo các cột trong datagridvew trên
        DataTable dt = new DataTable();
        private void CreateColumn()
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = "MaDG";
            //dc.Caption = "Mã độc giả";            
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "TenDG";
            //dc.Caption = "Mã độc giả";            
            dt.Columns.Add(dc);


            dc = new DataColumn();
            dc.ColumnName = "LoaiDG";
            //dc.Caption = "Mã độc giả";            
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "MaDauSach";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "TenSach";
            dt.Columns.Add(dc);


            dc = new DataColumn();
            dc.ColumnName = "NgayMuon";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "SoNgayMuon";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "NgayTra";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "DonGia";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "MaNV";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "TinhTrang";
            dt.Columns.Add(dc);

            dataGridView2.DataSource = dt;
            dataGridView2.Columns["MaNV"].Visible = false;
            //dataGridView2.Columns["MaDG"].Visible = false;
        }
        //Form load
        private void frmMuonTra_Load(object sender, EventArgs e)
        {
            CreateColumn();
        }
        //Fill thông tin sách
        private void FillBook(MuonTra clsMT)
        {
            //txtMaSach.Text = Convert.ToString(clsMT.MaSach);
            txtTenSach.Text = clsMT.TenSach;
            txtTacGia.Text = clsMT.TacGia;
            txtDonGia.Text = clsMT.DonGia.ToString();
            txtTinhTrang.Text = clsMT.TinhTrang.ToString();
            txtSLSachCon.Text = clsMT.SoLuongCon.ToString();
        }


        //Số ngày trễ hạn sách
        private int SoNgayTreHanSach()
        {
            int intSoNgayTreHan = 0;
            /*
            HeThongService cls = new HeThongService();
            clsParam = cls.GetParam();
            int intSoNgayMuonVe = clsParam.SoNgayMuonVe;
            int intSoTienPhatTreHanVe = clsParam.SoTienPhatTreHanVe;
            int intSoTienPhatTreHanTaiCho = clsParam.SoTienPhatTreHanTaiCho;*/

            MuonTraService clsMT = new MuonTraService();
            DataTable dt = clsMT.XemSach(Convert.ToInt32(txtMaSach.Text.Trim()));
            DataTableReader tr = dt.CreateDataReader();

            DateTime dtNgayMuon = new DateTime();
            int intSoNgayMuon = 0;
            if (tr.Read())
            {
                /*clsMuonTra.LoaiPM = Convert.ToByte(tr["LoaiPM"]);
                clsMuonTra.MaPM = Convert.ToInt32(tr.GetValue(2));
                clsMuonTra.MaDG = Convert.ToString(tr.GetValue(3));*/
                dtNgayMuon = Convert.ToDateTime(tr["Ngày mượn"]);
                if (dtNgayMuon.CompareTo(DateTime.Today) == 1)
                    MessageBox.Show("Ngày mượn lớn hơn ngày trả. Kiểm tra lại thời gian của máy !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                intSoNgayMuon = Convert.ToInt32(tr["Số ngày mượn"]);
            }
            int intSoNgayDaMuon = KiemTra.SoNgay(DateTime.Today, dtNgayMuon);
            intSoNgayTreHan = intSoNgayDaMuon - intSoNgayMuon;

            return intSoNgayTreHan;
        }

      

   
        //Kiểm tra sự tồn tại trước khi mượn
        private string strError = "";
        private bool Validation()
        {
            //Kiểm tra sự tồn tại của độc giả
            if (dataGridView2.RowCount == 0)
            {
                if (txtMaDG.Text.Trim().Length == 0)
                {
                    strError = "Nhập mã độc giả";
                    txtMaDG.Focus();
                    return false;
                }
                if (txtMaDG.Text.Trim().Length != 10)
                {
                    strError = "Mã độc giả phải 10 ký tự";
                    txtMaDG.Focus();
                    txtMaDG.SelectAll();
                    return false;
                }
                ReaderService clsReaderService = new ReaderService();
                if (clsReaderService.SearchReader(0, txtMaDG.Text.Trim(), 1).Rows.Count == 0)
                {
                    strError = "Độc giả này không có trong cơ sở dữ liệu";
                    txtMaDG.Focus();
                    txtMaDG.SelectAll();
                    return false;
                }
            }
            return true;

        }
        //Kiểm tra số lượng trước khi mượn        
        private bool KiemTraSoLuong()
        {
            //Kiểm tra số lượng mượn tại chổ
            MuonTraService cls = new MuonTraService();
            if (cls.GetInfoReader(clsMTM.MaDG).LoaiDG == 1)
            {
                if (!cls.KiemTraSoCuonMuonVe(dt, clsMTM))
                {
                    strError = "Số lượng mượn của độc giả này đã vượt quá quy định của Thư viện";
                    return false;
                }
            }
            return true;
        }

        //Mượn
        MuonTra clsMTM = new MuonTra();
        Book clsB = new Book();

        private bool KiemTraDG()
        {
            if (txtMaDG.Text.Trim().Length == 0)
            {
                strError = "Nhập mã độc giả";
                return false;
            }
            if (txtMaDG.Text.Trim().Length != 10)
            {
                strError = "Mã độc giả phải 10 ký tự";
                return false;
            }
            ReaderService clsReaderService = new ReaderService();
            if (clsReaderService.SearchReader(0, txtMaDG.Text.Trim(), 1).Rows.Count == 0)
            {
                strError = "Độc giả này không có trong cơ sở dữ liệu";
                return false;
            }
            return true;
        }

        private void txtSoTienDC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSLMuonVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }
        private void txtGiaBia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSLSachCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void btnXemSach_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text.Trim().Length != 0)
            {
                BookService clsBookService = new BookService();
                if (clsBookService.TimSachMT(txtMaSach.Text).Rows.Count == 0)
                {
                    strError = "Sách này không có trong cơ sở dữ liệu";
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MuonTraService cls = new MuonTraService();
                MuonTra clsMT = cls.GetInfoBookXS(Convert.ToInt32(txtMaSach.Text));
                FillBook(clsMT);

                dataGridView1.DataSource = cls.XemSach(Convert.ToInt32(txtMaSach.Text.Trim()));
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Columns["MaDG"].Visible = false;
            }
        }

        private void btnXemDG_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text.Trim().Length == 10)
            {
                ReaderService clsRader = new ReaderService();
                if (clsRader.SearchReader(0, txtMaDG.Text.Trim(), 1).Rows.Count == 0)
                {
                    strError = "Độc giả này không có trong cơ sở dữ liệu";
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MuonTraService cls = new MuonTraService();
                MuonTra clsDG = cls.GetInfoReader(txtMaDG.Text.Trim());
                FillReader(clsDG);
                DataTable dt = cls.XemDG(txtMaDG.Text.Trim()); // dataGridView1 không nhận đc dữ liệu 
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["MaDauSach"].Visible = false;
                dataGridView1.Columns["MaPM"].Visible = false;
            }
            else
            {
                strError = "Vui Lòng Nhập Đủ Ký Tự";
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool KiemTraSoTien()
        {
            //Kiểm tra số tiền mượn tại chổ
            MuonTraService cls = new MuonTraService();
            clsMTM.DonGia = cls.GetInfoBook(Convert.ToInt32(txtMaSach.Text)).DonGia;
            if (cls.GetInfoReader(clsMTM.MaDG).TienDatCoc == 0 && cls.GetInfoReader(clsMTM.MaDG).TenLoaiDG != "Giáo Viên")
                {
                    strError = "Độc giả này chưa đóng tiền thế chân";
                    return false;
                }
                if (!cls.KiemTraSoTienMuonVe(dt, clsMTM))
                {
                    strError = "Số tiền mượn về của độc giả này đã vượt quá quy định của Thư viện";
                    return false;
                }
            return true;
        }
        private void AddRowSach()
        {
            DataRow row = dt.NewRow();
            row["MaDG"] = clsMTM.MaDG;
            row["TenDG"] = txtTenDG.Text ;
            row["LoaiDG"] = txtLoaiDG.Text;
            //if (Convert.ToInt16(txtLoaiDG.Text) == 1)
            //{
            //    row["LoaiDG"] = "Sinh Viên";
            //}
            //else
            //{
            //    row["LoaiDG"] = "Giáo Viên";
            //}
            MuonTraService MT = new MuonTraService();
            //row["MaSach"] = MT.GetInfoBook(Convert.ToInt32(txtMaSach.Text)).MaSach;
            //row["TenSach"] = MT.GetInfoBook(Convert.ToInt32(txtMaSach.Text)).TenSach;
            //row["MaSach"] = clsMTM.MaSach;
            row["MaDauSach"] = clsMTM.MaDauSach;
            row["TenSach"] = MT.GetInfoBook(Convert.ToInt32(txtMaSach.Text)).TenSach;
            row["NgayMuon"] = DateTime.Today.Date;
            row["NgayTra"] = dateNgayTra.Value.Date;
            row["SoNgayMuon"] = dateNgayTra.Value.Day - DateTime.Today.Day;
            row["TinhTrang"] = txtTinhTrang.Text;
            MuonTraService cls = new MuonTraService();
            MuonTra clsGB = cls.GetInfoBook(Convert.ToInt32(txtMaSach.Text));
            row["DonGia"] = clsGB.DonGia;
            dt.Rows.Add(row);
            dataGridView2.DataSource = dt;
        }
        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (dataGridView2.RowCount == 0)
                {
                    clsMTM.MaDG = txtMaDG.Text.Trim();
                }
                //if (!KiemTraSoLuong())
                //{
                //    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    dataGridView2.Focus();
                //}
                //if (!KiemTraSoTien())
                //{
                //    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    dataGridView2.Focus();
                //}
                if (MessageBox.Show("Xác nhận cho mượn ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsMTM.NgayMuon = DateTime.Today;
                    clsMTM.MaNV = KiemTra.userid;
                    AddRowSach();
                }
            }
        }

        private void txtMaDG_KeyDown(object sender, KeyEventArgs e)
        {
            AcceptButton = btnXemDG;
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text.Trim().Length != 0)
            {
                BookService clsBookService = new BookService();
                if (clsBookService.TimSach(6, txtMaSach.Text, 1).Rows.Count == 0)
                {
                    strError = "Đầu sách này không có trong cơ sở dữ liệu";
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MuonTraService cls = new MuonTraService();
                MuonTra clsMT = cls.GetInfoBook(Convert.ToInt32(txtMaSach.Text));
                FillBook(clsMT);

                DataTable dt = cls.XemSach(Convert.ToInt32(txtMaSach.Text.Trim()));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin mượn của đầu sách này", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaSach.Focus();
                    txtMaSach.SelectAll();
                    return;
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["MaDG"].Visible = false;
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Tùy biến thông báo trễ hạn
                HeThongService clsHeThong = new HeThongService();
                int intSoNgayTreHan = SoNgayTreHanSach();
                int intSoTienPhat = clsParam.SoTienPhatTreHanVe * intSoNgayTreHan;
                string strTreHan = "\n Xác nhận gia hạn ?";
                MessageBoxIcon Icon = MessageBoxIcon.Question;
                if (intSoNgayTreHan > 0)
                {
                    strTreHan = "Sách này trễ: " + intSoNgayTreHan + " ngày. Tiền phạt: " + Convert.ToString(intSoTienPhat) + strTreHan;
                    Icon = MessageBoxIcon.Warning;
                }
                else
                    intSoNgayTreHan = 0;
                //Xác nhận gia hạn
                if (MessageBox.Show(strTreHan, this.Text, MessageBoxButtons.YesNo, Icon) == DialogResult.Yes)
                {
                    clsMuonTra.MaDauSach = Convert.ToInt32(txtMaSach.Text);
                    // clsMuonTra.SoNgayMuon = Convert.ToInt16(clsMuonTra.NgayTra.Day + clsMuonTra.SoNgayTre.Day);
                    //clsMuonTra.NguoiCapNhatMuon = KiemTra.userid;                    
                    if (cls.GiaHan(clsMuonTra))
                    {
                        dataGridView1.DataSource = cls.XemSach(clsMuonTra.MaDauSach);
                    }
                    else
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            MuonTraService cls = new MuonTraService();
            if (!cls.Muon(dt, clsMTM))
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                dt.Rows.Clear();
                dataGridView2.DataSource = dt;
                MuonTraService clsMTS = new MuonTraService();
                dataGridView1.DataSource = clsMTS.XemDG(clsMTM.MaDG);
                try
                {
                    MuonTraService clsS = new MuonTraService();
                    MuonTra clsMT = new MuonTra();
                    clsMT = clsS.GetInfoReader(clsMTM.MaDG);
                    FillReader(clsMT);
                }
                catch { }
            }
        }

        private void btnQuaTrinhMuonTra_Click(object sender, EventArgs e)
        {
            frmTimDocGia frm = new frmTimDocGia();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.strMaDG = txtMaDG.Text.Trim();
            frm.Show();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text.Trim().Length != 0)
            {
                BookService clsBookService = new BookService();
                if (clsBookService.TimSach(6, txtMaSach.Text, 1).Rows.Count == 0)
                {
                    strError = "Đầu sách này không có trong cơ sở dữ liệu";
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MuonTraService cls = new MuonTraService();
                MuonTra clsMT = cls.GetInfoBook(Convert.ToInt32(txtMaSach.Text));
                FillBook(clsMT);

                DataTable dt = cls.XemSach(Convert.ToInt32(txtMaSach.Text.Trim()));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin mượn của đầu sách này", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaSach.Focus();
                    txtMaSach.SelectAll();
                    return;
                }
                if (dataGridView1.DataSource == null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["MaDG"].Visible = false;
                }
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Tùy biến thông báo trễ hạn

                int intSoNgayTreHan = SoNgayTreHanSach();
                byte bytLoaiPM = Convert.ToByte(dataGridView1.CurrentRow.Cells["Hình thức mượn"].Value.Equals("Về nhà") ? 1 : 0);
                int intSoTienPhat = (bytLoaiPM == 0 ? clsParam.SoTienPhatTreHanTaiCho : clsParam.SoTienPhatTreHanVe) * intSoNgayTreHan;
                string strTreHan = "\n Xác nhận trả sách ?";
                MessageBoxIcon Icon = MessageBoxIcon.Question;
                if (intSoNgayTreHan > 0)
                {
                    strTreHan = "Sách này trễ: " + intSoNgayTreHan + " ngày. Tiền phạt: " + Convert.ToString(intSoTienPhat) + strTreHan;
                    Icon = MessageBoxIcon.Warning;
                }
                //Xác nhận trả sách
                if (MessageBox.Show(strTreHan, this.Text, MessageBoxButtons.YesNo, Icon) == DialogResult.Yes)
                {
                    clsMuonTra.MaDauSach = Convert.ToInt32(txtMaSach.Text);
                    clsMuonTra.NgayTra = DateTime.Today;
                    clsMuonTra.MaNV = KiemTra.userid;
                    if (cls.TraSach(clsMuonTra))
                    {
                        dataGridView1.DataSource = cls.XemDG(txtMaDG.Text);
                        dataGridView1.Columns["MaTenBTC"].Visible = false;
                        dataGridView1.Columns["MaPM"].Visible = false;
                        //MuonTraService cls = new MuonTraService();
                        MuonTra clsDG = cls.GetInfoReader(txtMaDG.Text.Trim());
                        FillReader(clsDG);
                    }
                    else
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
           // HeThongService cls = new HeThongService();
            if (dataGridView1.RowCount != 0)
            {
                btnQuaTrinhMuonTra.Enabled = true;
            }
            else
            {
                btnQuaTrinhMuonTra.Enabled = false;
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (vr != null)
            {
                if (Convert.ToInt32(vr.Cells["MaSach"].Value) != 0)
                {
                    txtMaSach.Text = Convert.ToString(vr.Cells["MaSach"].Value);
                    try
                    {
                        MuonTraService clsS = new MuonTraService();
                        MuonTra clsMT = new MuonTra();
                        clsMT = clsS.GetInfoBook(Convert.ToInt32(vr.Cells["MaSach"].Value));
                        FillBook(clsMT);
                    }
                    catch { }
                }
                try
                {
                    MuonTraService clsS = new MuonTraService();
                    MuonTra clsMT = new MuonTra();
                    clsMT = clsS.GetInfoReader(vr.Cells["MaDG"].Value.ToString());
                    FillReader(clsMT);
                }
                catch { }
            }
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView2.RowCount != 0)
            {
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnCapNhat.Enabled = false;
            }
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView2.RowCount != 0)
            {
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnCapNhat.Enabled = false;
            }
        }
    }
}
