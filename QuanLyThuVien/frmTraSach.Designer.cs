namespace QuanLyThuVien
{
    partial class frmTraSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoaPhieuMuon = new System.Windows.Forms.Button();
            this.dvCTPTra = new System.Windows.Forms.DataGridView();
            this.ckSave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDauSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayToiTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrangSach = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TinhTrangMuonTra = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GiaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTienPhat = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtTienTraLai = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtTenDocGia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.txtTienCoc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cboMaDG = new System.Windows.Forms.ComboBox();
            this.cboTenNV = new System.Windows.Forms.ComboBox();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dateHanTra = new System.Windows.Forms.DateTimePicker();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtMaPN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel1.SuspendLayout();
            this.ribbonClientPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvCTPTra)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ribbonClientPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(910, 512);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.groupBox2);
            this.ribbonClientPanel1.Controls.Add(this.groupBox1);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(3, 3);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(904, 506);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnXoaPhieuMuon);
            this.groupBox2.Controls.Add(this.dvCTPTra);
            this.groupBox2.Controls.Add(this.btnLuuPhieu);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(3, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sách trả";
            // 
            // btnXoaPhieuMuon
            // 
            this.btnXoaPhieuMuon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaPhieuMuon.Image = global::QuanLyThuVien.Properties.Resources.Delete;
            this.btnXoaPhieuMuon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaPhieuMuon.Location = new System.Drawing.Point(467, 205);
            this.btnXoaPhieuMuon.Name = "btnXoaPhieuMuon";
            this.btnXoaPhieuMuon.Size = new System.Drawing.Size(125, 27);
            this.btnXoaPhieuMuon.TabIndex = 72;
            this.btnXoaPhieuMuon.Text = "Thoát";
            this.btnXoaPhieuMuon.UseVisualStyleBackColor = true;
            this.btnXoaPhieuMuon.Click += new System.EventHandler(this.btnXoaPhieuMuon_Click);
            // 
            // dvCTPTra
            // 
            this.dvCTPTra.AllowUserToAddRows = false;
            this.dvCTPTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvCTPTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ckSave,
            this.MaDauSach,
            this.TenSach,
            this.TinhTrang,
            this.NgayToiTra,
            this.TinhTrangSach,
            this.TinhTrangMuonTra,
            this.GiaSach});
            this.dvCTPTra.Location = new System.Drawing.Point(6, 19);
            this.dvCTPTra.Name = "dvCTPTra";
            this.dvCTPTra.Size = new System.Drawing.Size(886, 176);
            this.dvCTPTra.TabIndex = 1;
            // 
            // ckSave
            // 
            this.ckSave.HeaderText = "";
            this.ckSave.Name = "ckSave";
            this.ckSave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ckSave.Width = 30;
            // 
            // MaDauSach
            // 
            this.MaDauSach.HeaderText = "Mã đầu sách";
            this.MaDauSach.Name = "MaDauSach";
            this.MaDauSach.ReadOnly = true;
            // 
            // TenSach
            // 
            this.TenSach.HeaderText = "Tên sách";
            this.TenSach.Name = "TenSach";
            this.TenSach.ReadOnly = true;
            // 
            // TinhTrang
            // 
            this.TinhTrang.HeaderText = "Tình Trạng";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.ReadOnly = true;
            // 
            // NgayToiTra
            // 
            this.NgayToiTra.HeaderText = "Ngày trả";
            this.NgayToiTra.Name = "NgayToiTra";
            this.NgayToiTra.ReadOnly = true;
            this.NgayToiTra.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TinhTrangSach
            // 
            this.TinhTrangSach.HeaderText = "Cập nhật trạng thái sách";
            this.TinhTrangSach.Items.AddRange(new object[] {
            "Mới",
            "Hỏng",
            "Mất",
            "Hư bìa sách"});
            this.TinhTrangSach.Name = "TinhTrangSach";
            this.TinhTrangSach.Width = 150;
            // 
            // TinhTrangMuonTra
            // 
            this.TinhTrangMuonTra.HeaderText = "Cập nhật tình trạng mượn trả";
            this.TinhTrangMuonTra.Items.AddRange(new object[] {
            "Đang mượn",
            "Đã trã",
            "Trả trễ"});
            this.TinhTrangMuonTra.Name = "TinhTrangMuonTra";
            this.TinhTrangMuonTra.Width = 170;
            // 
            // GiaSach
            // 
            this.GiaSach.HeaderText = "Giá Sách";
            this.GiaSach.Name = "GiaSach";
            this.GiaSach.ReadOnly = true;
            this.GiaSach.Visible = false;
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPhieu.Image = global::QuanLyThuVien.Properties.Resources.Add;
            this.btnLuuPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuPhieu.Location = new System.Drawing.Point(318, 205);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(139, 27);
            this.btnLuuPhieu.TabIndex = 71;
            this.btnLuuPhieu.Text = "Lưu phiếu trả";
            this.btnLuuPhieu.UseVisualStyleBackColor = true;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtTienPhat);
            this.groupBox1.Controls.Add(this.labelX6);
            this.groupBox1.Controls.Add(this.txtTienTraLai);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.txtTenDocGia);
            this.groupBox1.Controls.Add(this.labelX11);
            this.groupBox1.Controls.Add(this.txtTienCoc);
            this.groupBox1.Controls.Add(this.labelX7);
            this.groupBox1.Controls.Add(this.cboMaDG);
            this.groupBox1.Controls.Add(this.cboTenNV);
            this.groupBox1.Controls.Add(this.labelX5);
            this.groupBox1.Controls.Add(this.dateHanTra);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.txtMaPN);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin trả sách";
            // 
            // txtTienPhat
            // 
            // 
            // 
            // 
            this.txtTienPhat.Border.Class = "TextBoxBorder";
            this.txtTienPhat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTienPhat.Location = new System.Drawing.Point(531, 135);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(121, 20);
            this.txtTienPhat.TabIndex = 98;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX6.Location = new System.Drawing.Point(468, 134);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(95, 23);
            this.labelX6.TabIndex = 97;
            this.labelX6.Text = "Tiền phạt:";
            // 
            // txtTienTraLai
            // 
            // 
            // 
            // 
            this.txtTienTraLai.Border.Class = "TextBoxBorder";
            this.txtTienTraLai.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTienTraLai.Location = new System.Drawing.Point(531, 109);
            this.txtTienTraLai.Name = "txtTienTraLai";
            this.txtTienTraLai.Size = new System.Drawing.Size(121, 20);
            this.txtTienTraLai.TabIndex = 96;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX3.Location = new System.Drawing.Point(468, 105);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(95, 23);
            this.labelX3.TabIndex = 95;
            this.labelX3.Text = "Tiền trả lại";
            // 
            // txtTenDocGia
            // 
            // 
            // 
            // 
            this.txtTenDocGia.Border.Class = "TextBoxBorder";
            this.txtTenDocGia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDocGia.Location = new System.Drawing.Point(283, 135);
            this.txtTenDocGia.Name = "txtTenDocGia";
            this.txtTenDocGia.Size = new System.Drawing.Size(121, 20);
            this.txtTenDocGia.TabIndex = 94;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX11.Location = new System.Drawing.Point(192, 134);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(95, 23);
            this.labelX11.TabIndex = 93;
            this.labelX11.Text = "Tên độc giả:";
            // 
            // txtTienCoc
            // 
            // 
            // 
            // 
            this.txtTienCoc.Border.Class = "TextBoxBorder";
            this.txtTienCoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTienCoc.Location = new System.Drawing.Point(531, 80);
            this.txtTienCoc.Name = "txtTienCoc";
            this.txtTienCoc.Size = new System.Drawing.Size(121, 20);
            this.txtTienCoc.TabIndex = 92;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX7.Location = new System.Drawing.Point(468, 77);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(95, 23);
            this.labelX7.TabIndex = 91;
            this.labelX7.Text = "Tiền cọc:";
            // 
            // cboMaDG
            // 
            this.cboMaDG.FormattingEnabled = true;
            this.cboMaDG.Location = new System.Drawing.Point(283, 107);
            this.cboMaDG.Name = "cboMaDG";
            this.cboMaDG.Size = new System.Drawing.Size(121, 22);
            this.cboMaDG.TabIndex = 90;
            // 
            // cboTenNV
            // 
            this.cboTenNV.FormattingEnabled = true;
            this.cboTenNV.Location = new System.Drawing.Point(283, 77);
            this.cboTenNV.Name = "cboTenNV";
            this.cboTenNV.Size = new System.Drawing.Size(121, 22);
            this.cboTenNV.TabIndex = 85;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX5.Location = new System.Drawing.Point(193, 75);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(95, 23);
            this.labelX5.TabIndex = 84;
            this.labelX5.Text = "Tên nhân viên:";
            // 
            // dateHanTra
            // 
            this.dateHanTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateHanTra.Location = new System.Drawing.Point(283, 163);
            this.dateHanTra.Name = "dateHanTra";
            this.dateHanTra.Size = new System.Drawing.Size(121, 20);
            this.dateHanTra.TabIndex = 83;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX4.Location = new System.Drawing.Point(193, 163);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(95, 23);
            this.labelX4.TabIndex = 82;
            this.labelX4.Text = "Hạn trả:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX2.Location = new System.Drawing.Point(193, 105);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(95, 23);
            this.labelX2.TabIndex = 79;
            this.labelX2.Text = "Mã độc giả:";
            // 
            // btnTim
            // 
            this.btnTim.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTim.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QuanLyThuVien.Properties.Resources.tim;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(517, 37);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 78;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtMaPN
            // 
            // 
            // 
            // 
            this.txtMaPN.Border.Class = "TextBoxBorder";
            this.txtMaPN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaPN.Location = new System.Drawing.Point(400, 38);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(100, 20);
            this.txtMaPN.TabIndex = 77;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.Location = new System.Drawing.Point(299, 38);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(95, 23);
            this.labelX1.TabIndex = 76;
            this.labelX1.Text = "Mã phiếu mượn:";
            // 
            // frmTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 512);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTraSach";
            this.Text = "Trả Sách";
            this.Load += new System.EventHandler(this.frmTraSach_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvCTPTra)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDocGia;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTienCoc;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.ComboBox cboMaDG;
        private System.Windows.Forms.ComboBox cboTenNV;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.DateTimePicker dateHanTra;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Button btnTim;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaPN;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTienPhat;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTienTraLai;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Button btnXoaPhieuMuon;
        private System.Windows.Forms.DataGridView dvCTPTra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ckSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDauSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayToiTra;
        private System.Windows.Forms.DataGridViewComboBoxColumn TinhTrangSach;
        private System.Windows.Forms.DataGridViewComboBoxColumn TinhTrangMuonTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaSach;

    }
}