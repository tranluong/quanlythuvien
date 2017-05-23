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

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            lblTenBTC.Visible = false;
            cboTenBTC.Visible = false;
            lblSoPH.Visible = false;
            cboSoPH.Visible = false;
            groupBox7.Visible = false;

            label4.Visible = true;
            txtSoDKCB.Visible = true;
            groupBox3.Visible = true;

            btnGiaHan.Enabled = true;
            rdoVeNha.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
            txtSoDKCB.Visible = false;
            groupBox3.Visible = false;
            
            lblTenBTC.Visible = true;
            cboTenBTC.Visible = true;
            lblSoPH.Visible = true;
            cboSoPH.Visible = true;
            groupBox7.Visible = true;

            btnGiaHan.Enabled = false;
            rdoVeNha.Enabled = false;
        }

        private void rdoVeNha_CheckedChanged(object sender, EventArgs e)
        {
            rdoBTC.Enabled = false;
        }

        private void rdoTaiCho_CheckedChanged(object sender, EventArgs e)
        {            
            if(rdoBTC.Enabled == false)
                rdoBTC.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Điền vào thông tin độc giả
        private void FillReader(MuonTra clsDG)
        {
            txtMaDG.Text = clsDG.MaDG;
            txtTenDG.Text = clsDG.TenDG;
            txtSoTienDC.Text = clsDG.TienDatCoc.ToString();
            txtLoaiDG.Text = clsDG.LoaiDG;
            txtSoTienConLai.Text = clsDG.TienConLaiVe.ToString();
            txtSoTienConLaiTaiCho.Text = clsDG.TienConLaiTaiCho.ToString();
            txtSLMuonVe.Text = clsDG.SoCuonMuonVe.ToString();
            txtSLMuonTaiCho.Text = clsDG.SoCuonMuonTaiCho.ToString();
        }
        //Xem thông tin mượn trả dựa vào mã độc giả
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

                DataTable dt = cls.XemDG(txtMaDG.Text.Trim());                
                if(cls.Error!="")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["MaTenBTC"].Visible = false;
                dataGridView1.Columns["MaPM"].Visible = false;
            }
        }
        
        private void txtMaDG_KeyDown(object sender, KeyEventArgs e)
        {
            AcceptButton = btnXemDG;
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
            dc.ColumnName = "SoDKCB";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Tựa sách";
            dt.Columns.Add(dc);

            dc = new DataColumn();           
            dc.ColumnName = "MaTenBTC";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Tên Báo TC";
            dt.Columns.Add(dc);

            dc = new DataColumn();            
            dc.ColumnName = "SoPH";
            dt.Columns.Add(dc);
            
            dc = new DataColumn();            
            dc.ColumnName = "NgayMuon";
            dt.Columns.Add(dc);

            dc = new DataColumn();            
            dc.ColumnName = "SoNgayMuon";
            dt.Columns.Add(dc);

            dc = new DataColumn();            
            dc.ColumnName = "LoaiPM";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Hình thức mượn";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "GiaBia";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "NguoiCapNhatMuon";
            dt.Columns.Add(dc);            

            dataGridView2.DataSource = dt;
            dataGridView2.Columns["NguoiCapNhatMuon"].Visible = false;
            //dataGridView2.Columns["MaDG"].Visible = false;
        }
        //Form load
        private void frmMuonTra_Load(object sender, EventArgs e)
        {
            CreateColumn();
            dataGridView2.Columns["MaTenBTC"].Visible = false;
            dataGridView2.Columns["LoaiPM"].Visible = false;
            dataGridView2.Columns["GiaBia"].Visible = false;
            txtMaDG.Focus();
            HeThongService clsService = new HeThongService();
            clsParam = clsService.GetParam();

            MuonTraService cls = new MuonTraService();
            //fill vào tên báo tc
            cboTenBTC.DataSource=cls.ShowAllBaoTC();
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (cboTenBTC.Items.Count != 0)
                {
                    cboTenBTC.DisplayMember = "TenBTC";
                    cboTenBTC.ValueMember = "MaTenBTC";
                    cboTenBTC.SelectedIndex = 0;
                }
            }
            //fill vào số btc            
             DataTable dt = cls.ShowAllBaoTC(Convert.ToInt32(cboTenBTC.SelectedValue));
             cboSoPH.DataSource = dt;
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (dt.Rows.Count != 0)
                {
                    cboSoPH.DisplayMember = "SoPH";
                    cboSoPH.ValueMember = "SoPH";
                    cboSoPH.SelectedIndex = 0;
                }
            }
        }        
        //Fill thông tin báo tạp chí
        private void FillNewspaper(MuonTra clsMT)
        {
            txtTenBaoTC.Text = clsMT.TenBaoTC;
            txtSoPH.Text = clsMT.SoPH;
            txtNgayPH.Text = clsMT.NgayPH.ToShortDateString();
            txtSLCon.Text = clsMT.SoLuongConBTC.ToString();
        }
        //Fill thông tin sách
        private void FillBook(MuonTra clsMT)
        {
            txtTenSach.Text = clsMT.TenTS;
            txtTacGia.Text = clsMT.TacGia;
            txtGiaBia.Text = clsMT.GiaBia.ToString();
            txtKhoSach.Text = clsMT.Kho;
            txtSLSachCon.Text = clsMT.SoLuongCon.ToString();
        }
        //Xem thông tin mượn trả dựa vào số DKCB
        private void btnXemSach_Click(object sender, EventArgs e)
        {
            if (rdoSach.Checked == true)
            {
                if (txtSoDKCB.Text.Trim().Length != 0)
                {
                    BookService clsBookService = new BookService();
                    if (clsBookService.TimDauSach(6, txtSoDKCB.Text, 1).Rows.Count == 0)
                    {
                        strError = "Đầu sách này không có trong cơ sở dữ liệu";
                        MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MuonTraService cls = new MuonTraService();
                    MuonTra clsMT = cls.GetInfoBook(Convert.ToInt32(txtSoDKCB.Text));
                    FillBook(clsMT);

                    dataGridView1.DataSource = cls.XemSach(Convert.ToInt32(txtSoDKCB.Text.Trim()));                                   
                    if (cls.Error != "")
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    dataGridView1.Columns["MaDG"].Visible = false;                    
                }
            }
            else
            {
                if (cboSoPH != null)
                {
                    MuonTraService cls = new MuonTraService();
                    int intMaTenBTC = Convert.ToInt32(cboTenBTC.SelectedValue);
                    string strSoPH = Convert.ToString(cboSoPH.SelectedValue);
                    MuonTra clsMT = cls.GetInfoNewspaper(intMaTenBTC, strSoPH);
                    FillNewspaper(clsMT);

                    DataTable dt = cls.XemBTC(intMaTenBTC, strSoPH);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["MaPM"].Visible = false;
                    dataGridView1.Columns["MaDG"].Visible = false;
                    dataGridView1.Columns["MaTenBTC"].Visible = false;
                    if (cls.Error != "")
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
        }

        private void txtSoDKCB_KeyDown(object sender, KeyEventArgs e)
        {
            AcceptButton = btnXemSach;
        }

        private void txtMaDG_KeyDown(object sender, MouseEventArgs e)
        {
            AcceptButton = btnXemDG;
        }

        private void txtSoDKCB_KeyDown(object sender, MouseEventArgs e)
        {
            AcceptButton = btnXemSach;
        }
        //Data Source Changed
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
            /*HeThongService cls = new HeThongService();
            HeThong clsHeThong = cls.GetParam();
            if (dataGridView1.RowCount != 0)
            {                
                btnQuaTrinhMuonTra.Enabled = true;                
            }
            else
            {                
                btnQuaTrinhMuonTra.Enabled = false;
            }*/
        }
        //Current Cell Changed
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (vr != null)
            {                
                if (Convert.ToInt32(vr.Cells["Số ĐKCB"].Value) != 0)
                {                    
                    rdoSach.Checked = true;
                    txtSoDKCB.Text = Convert.ToString(vr.Cells["Số ĐKCB"].Value);
                    try
                    {
                        MuonTraService clsS = new MuonTraService();
                        MuonTra clsMT = new MuonTra();                    
                        clsMT= clsS.GetInfoBook(Convert.ToInt32(vr.Cells["Số ĐKCB"].Value));                    
                        FillBook(clsMT);
                    }
                    catch{}
                }
                else
                {                   
                    rdoBTC.Checked = true;                  
                    cboTenBTC.SelectedValue = vr.Cells["MaTenBTC"].Value;
                    MuonTraService cls = new MuonTraService();
                    cboSoPH.DataSource = cls.ShowAllBaoTC(Convert.ToInt32(cboTenBTC.SelectedValue));
                    if (cls.Error != "")
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        cboSoPH.DisplayMember = "SoPH";
                        cboSoPH.ValueMember = "SoPH";
                        cboSoPH.SelectedValue = vr.Cells["Số phát hành"].Value;  
                     
                        try
                        {
                            MuonTraService clsS = new MuonTraService();
                            MuonTra clsMT = new MuonTra();
                            clsMT= clsS.GetInfoNewspaper(Convert.ToInt32(vr.Cells["MaTenBTC"].Value),vr.Cells["Số phát hành"].Value.ToString());
                            FillNewspaper(clsMT);
                        }
                        catch{}
                    }
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
            DataTable dt = clsMT.XemSach(Convert.ToInt32(txtSoDKCB.Text.Trim()));
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
        //Gia hạn
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (txtSoDKCB.Text.Trim().Length != 0)
            {
                BookService clsBookService = new BookService();
                if (clsBookService.TimDauSach(6, txtSoDKCB.Text, 1).Rows.Count == 0)
                {
                    strError = "Đầu sách này không có trong cơ sở dữ liệu";
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MuonTraService cls = new MuonTraService();
                MuonTra clsMT = cls.GetInfoBook(Convert.ToInt32(txtSoDKCB.Text));
                FillBook(clsMT);

                DataTable dt = cls.XemSach(Convert.ToInt32(txtSoDKCB.Text.Trim()));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin mượn của đầu sách này", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoDKCB.Focus();
                    txtSoDKCB.SelectAll();
                    return;
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["MaDG"].Visible = false;
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Kiểm tra hình thức mượn đầu sách này
                clsMuonTra.LoaiPM = Convert.ToByte(dataGridView1.CurrentRow.Cells["Hình thức mượn"].Value.Equals("Về nhà") ? 1 : 0);                               
                if (clsMuonTra.LoaiPM == 0)
                {
                    MessageBox.Show("Đầu sách này mượn đọc tại chổ, không thể gia hạn", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoDKCB.Focus();
                    txtSoDKCB.SelectAll();
                    return;
                }
                //Tùy biến thông báo trễ hạn
                HeThongService clsHeThong = new HeThongService();
                clsParam = clsHeThong.GetParam();
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
                    clsMuonTra.SoDKCB = Convert.ToInt32(txtSoDKCB.Text);
                    clsMuonTra.SoNgayMuon = clsParam.SoNgayMuonVe + intSoNgayTreHan;
                    //clsMuonTra.NguoiCapNhatMuon = KiemTra.userid;                    
                    if (cls.GiaHan(clsMuonTra))
                    {
                        dataGridView1.DataSource = cls.XemSach(clsMuonTra.SoDKCB);                        
                    }
                    else
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }        
        private void txtSoDKCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }
        //Số ngày trễ hạn báo tâp chí
        private int SoNgayTreHanBTC()
        {
            int intSoNgayTreHan = 0;
            /*
            HeThongService cls = new HeThongService();
            clsParam = cls.GetParam();
            int intSoNgayMuonVe = clsParam.SoNgayMuonVe;
            int intSoTienPhatTreHanVe = clsParam.SoTienPhatTreHanVe;
            int intSoTienPhatTreHanTaiCho = clsParam.SoTienPhatTreHanTaiCho;*/

            MuonTraService clsMT = new MuonTraService();
            int intMaTenBTC = Convert.ToInt32(cboTenBTC.SelectedValue);
            string strSoPH = cboSoPH.SelectedValue.ToString();
            DataTable dt = clsMT.XemBTC(intMaTenBTC,strSoPH);
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
        //Số ngày trễ hạn báo tạp chí
        /*private int SoNgayTreHanBTC()
        {
            int intSoNgayTreHan = 0;

            HeThongService cls = new HeThongService();
            clsParam = cls.GetParam();
            //int intSoNgayMuonVe = 0;            
            int intSoTienPhatTreHanTaiCho = clsParam.SoTienPhatTreHanTaiCho;

            MuonTraService clsMT = new MuonTraService();
            DataTable dt = clsMT.XemBTC(Convert.ToInt32(cboTenBTC.SelectedValue),Convert.ToString(cboSoPH.SelectedValue));
            if (dt.Rows.Count != 0)
            {
                DataTableReader tr = dt.CreateDataReader();
                DateTime dtNgayMuon = new DateTime();
                int intSoNgayMuon = 0;
                if (tr.Read())
                {
                    clsMuonTra.LoaiPM = 0;
                    clsMuonTra.MaPM = Convert.ToInt32(tr.GetValue(2));
                    clsMuonTra.MaDG = Convert.ToString(tr.GetValue(3));
                    dtNgayMuon = Convert.ToDateTime(tr.GetValue(8));
                    intSoNgayMuon = Convert.ToInt32(tr.GetValue(9));
                }
                int intSoNgayDaMuon = KiemTra.SoNgay(DateTime.Today, dtNgayMuon);
                intSoNgayTreHan = intSoNgayDaMuon - intSoNgayMuon;
            }
            return intSoNgayTreHan;
        }*/
        //Trả tài liệu
        private void btnTra_Click(object sender, EventArgs e)
        {
            if (rdoSach.Checked == true)
            {
                if (txtSoDKCB.Text.Trim().Length != 0)
                {
                    BookService clsBookService = new BookService();
                    if (clsBookService.TimDauSach(6, txtSoDKCB.Text, 1).Rows.Count == 0)
                    {
                        strError = "Đầu sách này không có trong cơ sở dữ liệu";
                        MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MuonTraService cls = new MuonTraService();
                    MuonTra clsMT = cls.GetInfoBook(Convert.ToInt32(txtSoDKCB.Text));
                    FillBook(clsMT);

                    DataTable dt = cls.XemSach(Convert.ToInt32(txtSoDKCB.Text.Trim()));
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin mượn của đầu sách này", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoDKCB.Focus();
                        txtSoDKCB.SelectAll();
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
                    HeThongService clsHeThong = new HeThongService();
                    clsParam = clsHeThong.GetParam();
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
                        clsMuonTra.SoDKCB = Convert.ToInt32(txtSoDKCB.Text);
                        clsMuonTra.NgayTra = DateTime.Today;
                        clsMuonTra.NguoiCapNhatTra = KiemTra.userid;                    
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
            else
            {
                if (cboSoPH.SelectedValue!=null)
                {
                    MuonTraService cls = new MuonTraService();
                    int intMaTenBTC = Convert.ToInt32(cboTenBTC.SelectedValue);
                    string strSoPH = cboSoPH.SelectedValue.ToString();
                    MuonTra clsMT = cls.GetInfoNewspaper(intMaTenBTC, strSoPH);
                    FillNewspaper(clsMT);

                    DataTable dt = cls.XemBTC(intMaTenBTC,strSoPH);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin mượn của báo tạp chí này", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboSoPH.Focus();                        
                        return;
                    }
                    /*if (dt.Rows.Count > 1 && dataGridView1.DataSource == null)
                    {
                        MessageBox.Show("Báo tạp chí này có nhiều hơn một độc giả mượn, chú ý chọn đúng độc giả cần trả", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboSoPH.Focus();
                        //return;
                    }*/
                    if (dataGridView1.DataSource == null)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["MaPM"].Visible = false;
                        dataGridView1.Columns["MaDG"].Visible = false;
                        dataGridView1.Columns["MaTenBTC"].Visible = false;
                    }
                    if (cls.Error != "")
                    {
                        MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Tùy biến thông báo trễ hạn
                    HeThongService clsHeThong = new HeThongService();
                    clsParam = clsHeThong.GetParam();
                    int intSoNgayTreHan = SoNgayTreHanBTC();
                    //byte bytLoaiPM = 0;
                    int intSoTienPhat = clsParam.SoTienPhatTreHanTaiCho * intSoNgayTreHan;
                    //string strBTC = dataGridView1.CurrentRow.Cells["Tên 
                    string strTreHan = "\n Xác nhận trả báo tạp chí ?";
                    MessageBoxIcon Icon = MessageBoxIcon.Question;
                    if (intSoNgayTreHan > 0)
                    {
                        strTreHan = "Báo tạp chí này trễ: " + intSoNgayTreHan + " ngày. Tiền phạt: " + Convert.ToString(intSoTienPhat) + strTreHan;
                        Icon = MessageBoxIcon.Warning;
                    }
                    //Xác nhận trả báo tạp chí
                    if (MessageBox.Show(strTreHan, this.Text, MessageBoxButtons.YesNo, Icon) == DialogResult.Yes)
                    {
                        clsMuonTra.MaTenBTC = Convert.ToInt32(cboTenBTC.SelectedValue);
                        clsMuonTra.SoPH = cboSoPH.SelectedValue.ToString();
                        clsMuonTra.NgayTra = DateTime.Today;
                        clsMuonTra.NguoiCapNhatTra = KiemTra.userid;
                        clsMuonTra.MaPM = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MaPM"].Value);
                        if (cls.TraBaoTC(clsMuonTra))
                        {
                            dataGridView1.DataSource = cls.XemDG(txtMaDG.Text);
                            MuonTra clsDG = cls.GetInfoReader(txtMaDG.Text.Trim());
                            FillReader(clsDG);
                        }
                        else
                            MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cboTenBTC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //fill vào số btc            
            MuonTraService cls = new MuonTraService();
            cboSoPH.DataSource = cls.ShowAllBaoTC(Convert.ToInt32(cboTenBTC.SelectedValue));
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (cboSoPH.Items.Count != 0)
                {
                    cboSoPH.DisplayMember = "SoPH";
                    cboSoPH.ValueMember = "SoPH";
                    cboSoPH.SelectedIndex = 0;
                }
            }
        }        
        //Hàm add row mượn sách
        private void AddRowSach()
        {
            DataRow row = dt.NewRow();
            row["MaDG"] = clsMTM.MaDG;
            row["SoDKCB"] = Convert.ToInt32(txtSoDKCB.Text);
            MuonTraService MT = new MuonTraService();
            row["Tựa sách"] = MT.GetInfoBook(Convert.ToInt32(txtSoDKCB.Text)).TenTS;
            row["MaTenBTC"] = 0;
            row["Tên Báo TC"] = "";
            row["SoPH"] = "";
            row["NgayMuon"] = DateTime.Today.Date;
            if (rdoTaiCho.Checked)
            {
                row["SoNgayMuon"] = 0;
                row["LoaiPM"] = 0;
                row["Hình thức mượn"] = "Tại chổ";
            }
            else
            {
                row["SoNgayMuon"] = 10;
                row["LoaiPM"] = 1;
                row["Hình thức mượn"] = "Về nhà";
            }
            MuonTraService cls = new MuonTraService();
            MuonTra clsGB = cls.GetInfoBook(Convert.ToInt32(txtSoDKCB.Text));            
            row["GiaBia"] = clsGB.GiaBia;
            dt.Rows.Add(row);
            dataGridView2.DataSource = dt;            
        }
        //Hàm add row mượn báo tc
        private void AddRowBaoTC()
        {
            DataRow row = dt.NewRow();
            row["MaDG"] = clsMTM.MaDG;
            row["SoDKCB"] = 0;
            row["Tựa sách"] = "";
            int intMaTenBTC = Convert.ToInt32(cboTenBTC.SelectedValue);
            string strSoPH = Convert.ToString(cboSoPH.SelectedValue);
            row["MaTenBTC"] = intMaTenBTC;
            MuonTraService MT = new MuonTraService();
            row["Tên Báo TC"] = MT.GetInfoNewspaper(intMaTenBTC, strSoPH).TenBaoTC;
            row["SoPH"] = strSoPH;
            row["NgayMuon"] = DateTime.Today;
            row["SoNgayMuon"] = 0;
            row["LoaiPM"] = 0;
            row["Hình thức mượn"] = "Tại chổ";
            row["GiaBia"] = 0;
            dt.Rows.Add(row);
            dataGridView2.DataSource = dt;
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

            //Kiểm tra sự tồn tại của sách
            if (rdoSach.Checked)
            {                
                if (txtSoDKCB.Text.Trim().Length == 0)
                {
                    strError = "Nhập Số ĐKCB";
                    txtSoDKCB.Focus();
                    return false;
                }
                BookService clsBookService = new BookService();
                if (clsBookService.TimDauSach(6, txtSoDKCB.Text, 1).Rows.Count == 0)
                {
                    strError = "Đầu sách này không có trong cơ sở dữ liệu";
                    txtSoDKCB.Focus();
                    txtSoDKCB.SelectAll();
                    return false;
                }
                MuonTraService cls = new MuonTraService();
                if (cls.GetInfoBook(Convert.ToInt32(txtSoDKCB.Text)).TinhTrang != 0)
                {
                    strError = "Đầu sách này đang trong tình trạng mất hoặc hỏng";
                    txtSoDKCB.Focus();
                    txtSoDKCB.SelectAll();
                    return false;
                }
                DataTable dtS = cls.XemSach(Convert.ToInt32(txtSoDKCB.Text));
                if (dtS.Rows.Count != 0)
                {
                    strError = "Đầu sách này đã được mượn";
                    txtSoDKCB.Focus();
                    txtSoDKCB.SelectAll();
                    return false;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];                        
                        if (Convert.ToInt32(row["SoDKCB"]) == Convert.ToInt32(txtSoDKCB.Text))
                        {
                            strError = "Đầu sách này đã được thêm vào chi tiết mượn";                            
                            txtSoDKCB.Focus();
                            txtSoDKCB.SelectAll();
                            return false;
                        }
                    }
                }
            }
            //Kiểm tra sự tồn tại của báo tạp chí
            if (rdoBTC.Checked)
            {                
                if (cboSoPH.Items.Count==0)
                {
                    strError = "Không có số phát hành";                    
                    return false;
                }
                //Kiểm tra số lượng còn của báo tạp chí
                MuonTraService cls = new MuonTraService();
                MuonTra clsNews = cls.GetInfoNewspaper(Convert.ToInt32(cboTenBTC.SelectedValue),cboSoPH.SelectedValue.ToString());
                if (clsNews.SoLuongConBTC <= 0)
                {
                    strError = "Số lượng của tên báo tạp chí và số phát hành này đã hết";
                    cboSoPH.Focus();
                    return false;
                }
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    if (Convert.ToInt32(row["MaTenBTC"]) == Convert.ToInt32(cboTenBTC.SelectedValue) && row["SoPH"].ToString() == cboSoPH.SelectedValue.ToString())
                    {
                        strError = "Tên báo tạp chí và số phát hành này đã được thêm vào chi tiết mượn";
                        cboSoPH.Focus();
                        return false;
                    }
                }
                //}
            }
            return true;
        }
        //Kiểm tra số lượng trước khi mượn        
        private bool KiemTraSoLuong()
        {            
            //Kiểm tra số lượng mượn tại chổ
            MuonTraService cls = new MuonTraService();
            if (cls.GetInfoReader(clsMTM.MaDG).LoaiDG == "GVBC")
            {
                if (!cls.KiemTraSoCuonMuonGVBC(dt, clsMTM))
                {
                    strError = "Số lượng mượn của độc giả này đã vượt quá quy định của Thư viện";
                    return false;
                }
            }
            else
            {
                if (rdoTaiCho.Checked)
                    if (!cls.KiemTraSoCuonMuonTaiCho(dt, clsMTM))
                    {
                        strError = "Số lượng mượn tại chổ của độc giả này đã vượt quá quy định của Thư viện";                        
                        return false;
                    }
                //Kiểm tra số lượng mượn về nhà
                if (rdoVeNha.Checked)
                    if (!cls.KiemTraSoCuonMuonVe(dt, clsMTM))
                    {
                        strError = "Số lượng mượn về của độc giả này đã vượt quá quy định của Thư viện";                        
                        return false;
                    }
            }
            return true;
        }
        //Kiểm tra số tiền trước khi mượn        
        private bool KiemTraSoTien()
        {
            //Kiểm tra số tiền mượn tại chổ
            MuonTraService cls = new MuonTraService();            
            clsMTM.GiaBia = cls.GetInfoBook(Convert.ToInt32(txtSoDKCB.Text)).GiaBia;
            if (rdoTaiCho.Checked)
                if (!cls.KiemTraSoTienMuonTaiCho(dt, clsMTM))
                {
                    strError = "Số tiền mượn tại chổ của độc giả này đã vượt quá quy định của Thư viện";                    
                    return false;
                }
            //Kiểm tra số tiền mượn về nhà
            if (rdoVeNha.Checked)
            {
                if (cls.GetInfoReader(clsMTM.MaDG).TienDatCoc == 0 && cls.GetInfoReader(clsMTM.MaDG).LoaiDG != "GVBC")
                {
                    strError = "Độc giả này chưa đóng tiền thế chân";
                    return false;
                }
                if (!cls.KiemTraSoTienMuonVe(dt, clsMTM))
                {
                    strError = "Số tiền mượn về của độc giả này đã vượt quá quy định của Thư viện";                    
                    return false;
                }
            }
            return true;
        }
        //Mượn
        MuonTra clsMTM = new MuonTra();
        private void btnMuon_Click(object sender, EventArgs e)
        {            
                if (!Validation())
                    MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {                    
                    if(dataGridView2.RowCount==0)
                        clsMTM.MaDG = txtMaDG.Text.Trim();                    

                    if (rdoSach.Checked)
                    {
                        if (!KiemTraSoLuong())
                        {                            
                            MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataGridView2.Focus();
                        }
                        if (!KiemTraSoTien())
                        {                            
                            MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataGridView2.Focus();
                        }
                        if (MessageBox.Show("Xác nhận cho mượn ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            clsMTM.NgayMuon = DateTime.Today;
                            clsMTM.NguoiCapNhatMuon = KiemTra.userid;
                            AddRowSach();
                        }
                    }
                    
                    if (rdoBTC.Checked)
                    {
                        if (!KiemTraSoLuong())
                        {                            
                            MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataGridView2.Focus();
                        }
                        if (MessageBox.Show("Xác nhận cho mượn ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            clsMTM.NgayMuon = DateTime.Today;
                            clsMTM.NguoiCapNhatMuon = KiemTra.userid;
                            AddRowBaoTC();
                        }
                    }
        }
        }
        //Cập nhật
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
        //Quá trình mượn
        private void btnQuaTrinhMuonTra_Click(object sender, EventArgs e)
        {
            frmTimDocGia frm = new frmTimDocGia();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.strMaDG = txtMaDG.Text.Trim();
            frm.Show();
        } 
    }
}