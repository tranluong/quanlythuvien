﻿namespace QuanLyThuVien
{
    partial class frmDocGia
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ribbonClientPanel3 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.tblNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thuvienDataSet = new QuanLyThuVien.thuvienDataSet();
            this.label12 = new System.Windows.Forms.Label();
            this.dateNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.dateNDatCoc = new System.Windows.Forms.DateTimePicker();
            this.dateNKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dateNBatDau = new System.Windows.Forms.DateTimePicker();
            this.txtTienDatCoc = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtNoiSinh = new System.Windows.Forms.TextBox();
            this.txtTenDocGia = new System.Windows.Forms.TextBox();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblLoaiDocGiaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cboMaLoaiDocGia = new System.Windows.Forms.ComboBox();
            this.tblLoaiDocGiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ribbonClientPanel5 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.ribbonClientPanel6 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.ribbonClientPanel7 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDocGia = new System.Windows.Forms.DataGridView();
            this.tblLoaiDocGiaTableAdapter = new QuanLyThuVien.thuvienDataSetTableAdapters.tblLoaiDocGiaTableAdapter();
            this.tblNhanVienTableAdapter = new QuanLyThuVien.thuvienDataSetTableAdapters.tblNhanVienTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.ribbonClientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ribbonClientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblNhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thuvienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoaiDocGiaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoaiDocGiaBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.ribbonClientPanel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.ribbonClientPanel6.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.ribbonClientPanel7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.80882F));
            this.tableLayoutPanel1.Controls.Add(this.ribbonClientPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(837, 228);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.groupBox1);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(3, 3);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(831, 222);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.ribbonClientPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 222);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin độc giả";
            // 
            // ribbonClientPanel3
            // 
            this.ribbonClientPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel3.Controls.Add(this.cboMaLoaiDocGia);
            this.ribbonClientPanel3.Controls.Add(this.label11);
            this.ribbonClientPanel3.Controls.Add(this.cboNhanVien);
            this.ribbonClientPanel3.Controls.Add(this.label12);
            this.ribbonClientPanel3.Controls.Add(this.dateNgaySinh);
            this.ribbonClientPanel3.Controls.Add(this.label4);
            this.ribbonClientPanel3.Controls.Add(this.txtDiaChi);
            this.ribbonClientPanel3.Controls.Add(this.label5);
            this.ribbonClientPanel3.Controls.Add(this.rdoNu);
            this.ribbonClientPanel3.Controls.Add(this.rdoNam);
            this.ribbonClientPanel3.Controls.Add(this.dateNDatCoc);
            this.ribbonClientPanel3.Controls.Add(this.dateNKetThuc);
            this.ribbonClientPanel3.Controls.Add(this.dateNBatDau);
            this.ribbonClientPanel3.Controls.Add(this.txtTienDatCoc);
            this.ribbonClientPanel3.Controls.Add(this.txtSDT);
            this.ribbonClientPanel3.Controls.Add(this.txtNoiSinh);
            this.ribbonClientPanel3.Controls.Add(this.txtTenDocGia);
            this.ribbonClientPanel3.Controls.Add(this.txtMaDG);
            this.ribbonClientPanel3.Controls.Add(this.label9);
            this.ribbonClientPanel3.Controls.Add(this.label10);
            this.ribbonClientPanel3.Controls.Add(this.label13);
            this.ribbonClientPanel3.Controls.Add(this.label7);
            this.ribbonClientPanel3.Controls.Add(this.label8);
            this.ribbonClientPanel3.Controls.Add(this.label6);
            this.ribbonClientPanel3.Controls.Add(this.label3);
            this.ribbonClientPanel3.Controls.Add(this.label2);
            this.ribbonClientPanel3.Controls.Add(this.label1);
            this.ribbonClientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel3.Location = new System.Drawing.Point(3, 16);
            this.ribbonClientPanel3.Name = "ribbonClientPanel3";
            this.ribbonClientPanel3.Size = new System.Drawing.Size(825, 203);
            // 
            // 
            // 
            this.ribbonClientPanel3.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel3.TabIndex = 0;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblNhanVienBindingSource, "MaNV", true));
            this.cboNhanVien.DataSource = this.tblNhanVienBindingSource;
            this.cboNhanVien.DisplayMember = "TenDangNhap";
            this.cboNhanVien.Enabled = false;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(526, 145);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(198, 22);
            this.cboNhanVien.TabIndex = 61;
            this.cboNhanVien.ValueMember = "MaNV";
            // 
            // tblNhanVienBindingSource
            // 
            this.tblNhanVienBindingSource.DataMember = "tblNhanVien";
            this.tblNhanVienBindingSource.DataSource = this.thuvienDataSet;
            // 
            // thuvienDataSet
            // 
            this.thuvienDataSet.DataSetName = "thuvienDataSet";
            this.thuvienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(423, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 14);
            this.label12.TabIndex = 60;
            this.label12.Text = "Tên nhân viên:";
            // 
            // dateNgaySinh
            // 
            this.dateNgaySinh.Location = new System.Drawing.Point(108, 172);
            this.dateNgaySinh.Name = "dateNgaySinh";
            this.dateNgaySinh.Size = new System.Drawing.Size(200, 20);
            this.dateNgaySinh.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 57;
            this.label4.Text = "Ngày sinh:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(526, 99);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(200, 37);
            this.txtDiaChi.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(423, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 54;
            this.label5.Text = "Địa chỉ:";
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(155, 92);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(40, 18);
            this.rdoNu.TabIndex = 53;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Checked = true;
            this.rdoNam.Location = new System.Drawing.Point(108, 93);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(49, 18);
            this.rdoNam.TabIndex = 52;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // dateNDatCoc
            // 
            this.dateNDatCoc.Location = new System.Drawing.Point(528, 9);
            this.dateNDatCoc.Name = "dateNDatCoc";
            this.dateNDatCoc.Size = new System.Drawing.Size(200, 20);
            this.dateNDatCoc.TabIndex = 51;
            // 
            // dateNKetThuc
            // 
            this.dateNKetThuc.Location = new System.Drawing.Point(526, 63);
            this.dateNKetThuc.Name = "dateNKetThuc";
            this.dateNKetThuc.Size = new System.Drawing.Size(200, 20);
            this.dateNKetThuc.TabIndex = 50;
            // 
            // dateNBatDau
            // 
            this.dateNBatDau.Location = new System.Drawing.Point(526, 41);
            this.dateNBatDau.Name = "dateNBatDau";
            this.dateNBatDau.Size = new System.Drawing.Size(200, 20);
            this.dateNBatDau.TabIndex = 50;
            // 
            // txtTienDatCoc
            // 
            this.txtTienDatCoc.Enabled = false;
            this.txtTienDatCoc.Location = new System.Drawing.Point(108, 144);
            this.txtTienDatCoc.Name = "txtTienDatCoc";
            this.txtTienDatCoc.Size = new System.Drawing.Size(125, 20);
            this.txtTienDatCoc.TabIndex = 46;
            this.txtTienDatCoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienDatCoc_KeyPress);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(108, 115);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(125, 20);
            this.txtSDT.TabIndex = 45;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // txtNoiSinh
            // 
            this.txtNoiSinh.Location = new System.Drawing.Point(108, 66);
            this.txtNoiSinh.Name = "txtNoiSinh";
            this.txtNoiSinh.Size = new System.Drawing.Size(125, 20);
            this.txtNoiSinh.TabIndex = 42;
            // 
            // txtTenDocGia
            // 
            this.txtTenDocGia.Location = new System.Drawing.Point(108, 40);
            this.txtTenDocGia.Name = "txtTenDocGia";
            this.txtTenDocGia.Size = new System.Drawing.Size(125, 20);
            this.txtTenDocGia.TabIndex = 40;
            // 
            // txtMaDG
            // 
            this.txtMaDG.Location = new System.Drawing.Point(108, 11);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.Size = new System.Drawing.Size(125, 20);
            this.txtMaDG.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 14);
            this.label9.TabIndex = 38;
            this.label9.Text = "Thời gian kết thúc:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(419, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 14);
            this.label10.TabIndex = 37;
            this.label10.Text = "Thời gian bắt đầu:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(419, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 14);
            this.label13.TabIndex = 34;
            this.label13.Text = "Ngày đặt cọc:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 14);
            this.label7.TabIndex = 33;
            this.label7.Text = "Tiền đặt cọc:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 14);
            this.label8.TabIndex = 32;
            this.label8.Text = "Số điện thoại:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "Giới tính:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nơi sinh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên độc giả:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã độc giả:";
            // 
            // tblLoaiDocGiaBindingSource1
            // 
            this.tblLoaiDocGiaBindingSource1.DataMember = "tblLoaiDocGia";
            this.tblLoaiDocGiaBindingSource1.DataSource = this.thuvienDataSet;
            // 
            // cboMaLoaiDocGia
            // 
            this.cboMaLoaiDocGia.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblLoaiDocGiaBindingSource, "MaLoaiDG", true));
            this.cboMaLoaiDocGia.FormattingEnabled = true;
            this.cboMaLoaiDocGia.Location = new System.Drawing.Point(526, 172);
            this.cboMaLoaiDocGia.Name = "cboMaLoaiDocGia";
            this.cboMaLoaiDocGia.Size = new System.Drawing.Size(198, 22);
            this.cboMaLoaiDocGia.TabIndex = 55;
            // 
            // tblLoaiDocGiaBindingSource
            // 
            this.tblLoaiDocGiaBindingSource.DataMember = "tblLoaiDocGia";
            this.tblLoaiDocGiaBindingSource.DataSource = this.thuvienDataSet;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(425, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 14);
            this.label11.TabIndex = 50;
            this.label11.Text = "Tên loại độc giả:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ribbonClientPanel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ribbonClientPanel6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ribbonClientPanel7, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 228);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.01681F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.98319F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(837, 270);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ribbonClientPanel5
            // 
            this.ribbonClientPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel5.Controls.Add(this.groupBox5);
            this.ribbonClientPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel5.Location = new System.Drawing.Point(3, 3);
            this.ribbonClientPanel5.Name = "ribbonClientPanel5";
            this.ribbonClientPanel5.Size = new System.Drawing.Size(831, 44);
            // 
            // 
            // 
            this.ribbonClientPanel5.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel5.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.cboDocGia);
            this.groupBox5.Controls.Add(this.cboFilter);
            this.groupBox5.Controls.Add(this.txtKeyword);
            this.groupBox5.Controls.Add(this.btnTim);
            this.groupBox5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(9, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(819, 38);
            this.groupBox5.TabIndex = 113;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tìm kiếm";
            // 
            // cboDocGia
            // 
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Items.AddRange(new object[] {
            "Mã độc giả",
            "Tên độc giả"});
            this.cboDocGia.Location = new System.Drawing.Point(102, 11);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(121, 22);
            this.cboDocGia.TabIndex = 111;
            // 
            // cboFilter
            // 
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "Gần đúng",
            "Chính xác"});
            this.cboFilter.Location = new System.Drawing.Point(530, 11);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(121, 22);
            this.cboFilter.TabIndex = 112;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(245, 11);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(279, 20);
            this.txtKeyword.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTim.Location = new System.Drawing.Point(672, 11);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 110;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // ribbonClientPanel6
            // 
            this.ribbonClientPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel6.Controls.Add(this.groupBox16);
            this.ribbonClientPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel6.Location = new System.Drawing.Point(3, 53);
            this.ribbonClientPanel6.Name = "ribbonClientPanel6";
            this.ribbonClientPanel6.Size = new System.Drawing.Size(831, 63);
            // 
            // 
            // 
            this.ribbonClientPanel6.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel6.TabIndex = 1;
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.Transparent;
            this.groupBox16.Controls.Add(this.btnTaoMoi);
            this.groupBox16.Controls.Add(this.btnXoa);
            this.groupBox16.Controls.Add(this.btnCapnhat);
            this.groupBox16.Controls.Add(this.btnDong);
            this.groupBox16.Controls.Add(this.btnThem);
            this.groupBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox16.Location = new System.Drawing.Point(0, 0);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(831, 63);
            this.groupBox16.TabIndex = 148;
            this.groupBox16.TabStop = false;
            this.groupBox16.Tag = "";
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMoi.Image = global::QuanLyThuVien.Properties.Resources.taomoi;
            this.btnTaoMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoMoi.Location = new System.Drawing.Point(523, 19);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(105, 27);
            this.btnTaoMoi.TabIndex = 96;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::QuanLyThuVien.Properties.Resources.Delete;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(190, 19);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 27);
            this.btnXoa.TabIndex = 64;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.Enabled = false;
            this.btnCapnhat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapnhat.Image = global::QuanLyThuVien.Properties.Resources.save;
            this.btnCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapnhat.Location = new System.Drawing.Point(301, 19);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(105, 27);
            this.btnCapnhat.TabIndex = 63;
            this.btnCapnhat.Text = "Cập nhật";
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = global::QuanLyThuVien.Properties.Resources.close;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(640, 19);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(105, 27);
            this.btnDong.TabIndex = 61;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::QuanLyThuVien.Properties.Resources.Add;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(412, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 27);
            this.btnThem.TabIndex = 62;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // ribbonClientPanel7
            // 
            this.ribbonClientPanel7.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel7.Controls.Add(this.groupBox4);
            this.ribbonClientPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel7.Location = new System.Drawing.Point(3, 122);
            this.ribbonClientPanel7.Name = "ribbonClientPanel7";
            this.ribbonClientPanel7.Size = new System.Drawing.Size(831, 145);
            // 
            // 
            // 
            this.ribbonClientPanel7.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel7.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.dataGridViewDocGia);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(831, 145);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bảng thông tin độc giả";
            // 
            // dataGridViewDocGia
            // 
            this.dataGridViewDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDocGia.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewDocGia.Name = "dataGridViewDocGia";
            this.dataGridViewDocGia.Size = new System.Drawing.Size(825, 126);
            this.dataGridViewDocGia.TabIndex = 0;
            this.dataGridViewDocGia.DataSourceChanged += new System.EventHandler(this.dataGridViewDocGia_DataSourceChanged);
            this.dataGridViewDocGia.CurrentCellChanged += new System.EventHandler(this.dataGridViewDocGia_CurrentCellChanged);
            // 
            // tblLoaiDocGiaTableAdapter
            // 
            this.tblLoaiDocGiaTableAdapter.ClearBeforeFill = true;
            // 
            // tblNhanVienTableAdapter
            // 
            this.tblNhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // frmDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 498);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmDocGia";
            this.Text = "Độc giả";
            this.Load += new System.EventHandler(this.frmDocGia_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ribbonClientPanel3.ResumeLayout(false);
            this.ribbonClientPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblNhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thuvienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoaiDocGiaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoaiDocGiaBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ribbonClientPanel5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ribbonClientPanel6.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.ribbonClientPanel7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel3;
        private System.Windows.Forms.DateTimePicker dateNDatCoc;
        private System.Windows.Forms.DateTimePicker dateNKetThuc;
        private System.Windows.Forms.DateTimePicker dateNBatDau;
        private System.Windows.Forms.TextBox txtTienDatCoc;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtNoiSinh;
        private System.Windows.Forms.TextBox txtTenDocGia;
        private System.Windows.Forms.TextBox txtMaDG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel5;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel6;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridViewDocGia;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker dateNgaySinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMaLoaiDocGia;
        private thuvienDataSet thuvienDataSet;
        private System.Windows.Forms.BindingSource tblLoaiDocGiaBindingSource;
        private thuvienDataSetTableAdapters.tblLoaiDocGiaTableAdapter tblLoaiDocGiaTableAdapter;
        private System.Windows.Forms.BindingSource tblLoaiDocGiaBindingSource1;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.BindingSource tblNhanVienBindingSource;
        private thuvienDataSetTableAdapters.tblNhanVienTableAdapter tblNhanVienTableAdapter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}