namespace QuanLyThuVien
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.Login = new System.Windows.Forms.ToolStripMenuItem();
            this.Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.Line11 = new System.Windows.Forms.ToolStripSeparator();
            this.ChangeParam = new System.Windows.Forms.ToolStripMenuItem();
            this.Line12 = new System.Windows.Forms.ToolStripSeparator();
            this.Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.Restore = new System.Windows.Forms.ToolStripMenuItem();
            this.Line13 = new System.Windows.Forms.ToolStripSeparator();
            this.HideToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.Line14 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateBook = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateNewspaper = new System.Windows.Forms.ToolStripMenuItem();
            this.Line21 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateReader = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateManager = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchBook = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchReader = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessMuonTra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportTreHan = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportYeuCau = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportDatCoc = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportMuonNhieu = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportSachMat = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportPhucVu = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportTheoNam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocGia = new System.Windows.Forms.ToolStripMenuItem();
            this.YeuCauSach = new System.Windows.Forms.ToolStripMenuItem();
            this.SachMoi = new System.Windows.Forms.ToolStripMenuItem();
            this.tolMain = new System.Windows.Forms.ToolStrip();
            this.tolMuonTra = new System.Windows.Forms.ToolStripButton();
            this.tolUpdateNewspaper = new System.Windows.Forms.ToolStripButton();
            this.tolSearchReader = new System.Windows.Forms.ToolStripButton();
            this.tolLine = new System.Windows.Forms.ToolStripSeparator();
            this.lblTimNhanh = new System.Windows.Forms.ToolStripLabel();
            this.cboType = new System.Windows.Forms.ToolStripComboBox();
            this.cboNewspaper = new System.Windows.Forms.ToolStripComboBox();
            this.cboTypeBook = new System.Windows.Forms.ToolStripComboBox();
            this.txtKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.cboSoPH = new System.Windows.Forms.ToolStripComboBox();
            this.tolSmallSearch = new System.Windows.Forms.ToolStripButton();
            this.lblSoLuongCon = new System.Windows.Forms.ToolStripLabel();
            this.tolSearch = new System.Windows.Forms.ToolStripButton();
            this.statMain = new System.Windows.Forms.StatusStrip();
            this.lblManager = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatManager = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain.SuspendLayout();
            this.tolMain.SuspendLayout();
            this.statMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuUpdate,
            this.mnuSearch,
            this.mnuProcess,
            this.mnuReport,
            this.mnuHelp,
            this.mnuDocGia});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(973, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Login,
            this.Logout,
            this.ChangePass,
            this.Line11,
            this.ChangeParam,
            this.Line12,
            this.Backup,
            this.Restore,
            this.Line13,
            this.HideToolBar,
            this.ChangeSkin,
            this.Line14,
            this.Exit});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(70, 20);
            this.mnuSystem.Text = "&Hệ thống";
            // 
            // Login
            // 
            this.Login.Image = global::QuanLyThuVien.Properties.Resources.login;
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(176, 22);
            this.Login.Text = "Đăng nhập";
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Logout
            // 
            this.Logout.Image = global::QuanLyThuVien.Properties.Resources.logout;
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(176, 22);
            this.Logout.Text = "Đăng xuất";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // ChangePass
            // 
            this.ChangePass.Image = global::QuanLyThuVien.Properties.Resources.changepass;
            this.ChangePass.Name = "ChangePass";
            this.ChangePass.Size = new System.Drawing.Size(176, 22);
            this.ChangePass.Text = "Đổi mật khẩu";
            this.ChangePass.Click += new System.EventHandler(this.ChangePass_Click);
            // 
            // Line11
            // 
            this.Line11.Name = "Line11";
            this.Line11.Size = new System.Drawing.Size(173, 6);
            // 
            // ChangeParam
            // 
            this.ChangeParam.Image = global::QuanLyThuVien.Properties.Resources.Configurator;
            this.ChangeParam.Name = "ChangeParam";
            this.ChangeParam.Size = new System.Drawing.Size(176, 22);
            this.ChangeParam.Text = "Thay đổi quy định";
            this.ChangeParam.Click += new System.EventHandler(this.ChangeParam_Click);
            // 
            // Line12
            // 
            this.Line12.Name = "Line12";
            this.Line12.Size = new System.Drawing.Size(173, 6);
            // 
            // Backup
            // 
            this.Backup.Image = global::QuanLyThuVien.Properties.Resources.backup;
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(176, 22);
            this.Backup.Text = "Sao lưu dữ liệu";
            this.Backup.Click += new System.EventHandler(this.Backup_Click);
            // 
            // Restore
            // 
            this.Restore.Image = global::QuanLyThuVien.Properties.Resources.restore;
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(176, 22);
            this.Restore.Text = "Phục hồi dữ liệu";
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // Line13
            // 
            this.Line13.Name = "Line13";
            this.Line13.Size = new System.Drawing.Size(173, 6);
            // 
            // HideToolBar
            // 
            this.HideToolBar.Name = "HideToolBar";
            this.HideToolBar.Size = new System.Drawing.Size(176, 22);
            this.HideToolBar.Text = "Ẩn thanh công cụ";
            this.HideToolBar.Click += new System.EventHandler(this.HideToolBar_Click);
            // 
            // ChangeSkin
            // 
            this.ChangeSkin.Name = "ChangeSkin";
            this.ChangeSkin.Size = new System.Drawing.Size(176, 22);
            this.ChangeSkin.Text = "Thay đổi giao diện";
            // 
            // Line14
            // 
            this.Line14.Name = "Line14";
            this.Line14.Size = new System.Drawing.Size(173, 6);
            // 
            // Exit
            // 
            this.Exit.Image = global::QuanLyThuVien.Properties.Resources.exit;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(176, 22);
            this.Exit.Text = "Thoát";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // mnuUpdate
            // 
            this.mnuUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateBook,
            this.UpdateNewspaper,
            this.Line21,
            this.UpdateReader,
            this.UpdateManager});
            this.mnuUpdate.Name = "mnuUpdate";
            this.mnuUpdate.Size = new System.Drawing.Size(69, 20);
            this.mnuUpdate.Text = "&Cập nhật";
            // 
            // UpdateBook
            // 
            this.UpdateBook.Image = global::QuanLyThuVien.Properties.Resources.books;
            this.UpdateBook.Name = "UpdateBook";
            this.UpdateBook.Size = new System.Drawing.Size(138, 22);
            this.UpdateBook.Text = "Sách";
            this.UpdateBook.Click += new System.EventHandler(this.UpdateBook_Click);
            // 
            // UpdateNewspaper
            // 
            this.UpdateNewspaper.Image = global::QuanLyThuVien.Properties.Resources.newspaper;
            this.UpdateNewspaper.Name = "UpdateNewspaper";
            this.UpdateNewspaper.Size = new System.Drawing.Size(138, 22);
            this.UpdateNewspaper.Text = "Báo Tạp chí";
            this.UpdateNewspaper.Click += new System.EventHandler(this.UpdateNewspaper_Click);
            // 
            // Line21
            // 
            this.Line21.Name = "Line21";
            this.Line21.Size = new System.Drawing.Size(135, 6);
            // 
            // UpdateReader
            // 
            this.UpdateReader.Image = global::QuanLyThuVien.Properties.Resources.users;
            this.UpdateReader.Name = "UpdateReader";
            this.UpdateReader.Size = new System.Drawing.Size(138, 22);
            this.UpdateReader.Text = "Độc giả";
            this.UpdateReader.Click += new System.EventHandler(this.UpdateReader_Click);
            // 
            // UpdateManager
            // 
            this.UpdateManager.Image = global::QuanLyThuVien.Properties.Resources.thuthu;
            this.UpdateManager.Name = "UpdateManager";
            this.UpdateManager.Size = new System.Drawing.Size(138, 22);
            this.UpdateManager.Text = "Thủ thư";
            this.UpdateManager.Click += new System.EventHandler(this.UpdateManager_Click);
            // 
            // mnuSearch
            // 
            this.mnuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchBook,
            this.SearchReader});
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.Size = new System.Drawing.Size(71, 20);
            this.mnuSearch.Text = "&Tìm kiếm";
            // 
            // SearchBook
            // 
            this.SearchBook.Image = global::QuanLyThuVien.Properties.Resources.searchtailieu;
            this.SearchBook.Name = "SearchBook";
            this.SearchBook.Size = new System.Drawing.Size(116, 22);
            this.SearchBook.Text = "Tài liệu";
            this.SearchBook.Click += new System.EventHandler(this.SearchBook_Click);
            // 
            // SearchReader
            // 
            this.SearchReader.Image = global::QuanLyThuVien.Properties.Resources.searchuser;
            this.SearchReader.Name = "SearchReader";
            this.SearchReader.Size = new System.Drawing.Size(116, 22);
            this.SearchReader.Text = "Độc giả";
            this.SearchReader.Click += new System.EventHandler(this.SearchReader_Click);
            // 
            // mnuProcess
            // 
            this.mnuProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProcessMuonTra});
            this.mnuProcess.Name = "mnuProcess";
            this.mnuProcess.Size = new System.Drawing.Size(47, 20);
            this.mnuProcess.Text = "&Xử lý";
            // 
            // ProcessMuonTra
            // 
            this.ProcessMuonTra.Image = global::QuanLyThuVien.Properties.Resources.muontra;
            this.ProcessMuonTra.Name = "ProcessMuonTra";
            this.ProcessMuonTra.Size = new System.Drawing.Size(128, 22);
            this.ProcessMuonTra.Text = "Mượn Trả";
            this.ProcessMuonTra.Click += new System.EventHandler(this.ProcessMuonTra_Click);
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportTreHan,
            this.ReportYeuCau,
            this.ReportDatCoc,
            this.ReportMuonNhieu,
            this.ReportSachMat,
            this.ReportPhucVu,
            this.ReportTheoNam});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(63, 20);
            this.mnuReport.Text = "&Báo cáo";
            // 
            // ReportTreHan
            // 
            this.ReportTreHan.Image = global::QuanLyThuVien.Properties.Resources.sachmoi;
            this.ReportTreHan.Name = "ReportTreHan";
            this.ReportTreHan.Size = new System.Drawing.Size(215, 22);
            this.ReportTreHan.Text = "Sách, Báo Tạp chí trễ hạn";
            this.ReportTreHan.Click += new System.EventHandler(this.ReportTreHan_Click);
            // 
            // ReportYeuCau
            // 
            this.ReportYeuCau.Image = global::QuanLyThuVien.Properties.Resources.heart;
            this.ReportYeuCau.Name = "ReportYeuCau";
            this.ReportYeuCau.Size = new System.Drawing.Size(215, 22);
            this.ReportYeuCau.Text = "Sách yêu cầu";
            this.ReportYeuCau.Click += new System.EventHandler(this.ReportYeuCau_Click);
            // 
            // ReportDatCoc
            // 
            this.ReportDatCoc.Image = global::QuanLyThuVien.Properties.Resources.tiendatcoc;
            this.ReportDatCoc.Name = "ReportDatCoc";
            this.ReportDatCoc.Size = new System.Drawing.Size(215, 22);
            this.ReportDatCoc.Text = "Tiền đặt cọc";
            this.ReportDatCoc.Click += new System.EventHandler(this.ReportDatCoc_Click);
            // 
            // ReportMuonNhieu
            // 
            this.ReportMuonNhieu.Image = global::QuanLyThuVien.Properties.Resources.star;
            this.ReportMuonNhieu.Name = "ReportMuonNhieu";
            this.ReportMuonNhieu.Size = new System.Drawing.Size(215, 22);
            this.ReportMuonNhieu.Text = "Sách mượn nhiều";
            this.ReportMuonNhieu.Click += new System.EventHandler(this.ReportMuonNhieu_Click);
            // 
            // ReportSachMat
            // 
            this.ReportSachMat.Image = global::QuanLyThuVien.Properties.Resources.folder_delete;
            this.ReportSachMat.Name = "ReportSachMat";
            this.ReportSachMat.Size = new System.Drawing.Size(215, 22);
            this.ReportSachMat.Text = "Sách mất";
            this.ReportSachMat.Click += new System.EventHandler(this.ReportSachMat_Click);
            // 
            // ReportPhucVu
            // 
            this.ReportPhucVu.Image = global::QuanLyThuVien.Properties.Resources.status_away;
            this.ReportPhucVu.Name = "ReportPhucVu";
            this.ReportPhucVu.Size = new System.Drawing.Size(215, 22);
            this.ReportPhucVu.Text = "Phục vụ bạn đọc";
            this.ReportPhucVu.Click += new System.EventHandler(this.ReportPhucVu_Click);
            // 
            // ReportTheoNam
            // 
            this.ReportTheoNam.Image = global::QuanLyThuVien.Properties.Resources.calendar;
            this.ReportTheoNam.Name = "ReportTheoNam";
            this.ReportTheoNam.Size = new System.Drawing.Size(215, 22);
            this.ReportTheoNam.Text = "Sách theo năm";
            this.ReportTheoNam.Click += new System.EventHandler(this.ReportTheoNam_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpGuide,
            this.HelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(65, 20);
            this.mnuHelp.Text = "T&rợ giúp";
            // 
            // HelpGuide
            // 
            this.HelpGuide.Image = global::QuanLyThuVien.Properties.Resources.help;
            this.HelpGuide.Name = "HelpGuide";
            this.HelpGuide.Size = new System.Drawing.Size(190, 22);
            this.HelpGuide.Text = "Hướng dẫn sử dụng";
            this.HelpGuide.Click += new System.EventHandler(this.HelpGuide_Click);
            // 
            // HelpAbout
            // 
            this.HelpAbout.Image = global::QuanLyThuVien.Properties.Resources.about;
            this.HelpAbout.Name = "HelpAbout";
            this.HelpAbout.Size = new System.Drawing.Size(190, 22);
            this.HelpAbout.Text = "Thông tin phần mềm";
            this.HelpAbout.Click += new System.EventHandler(this.HelpAbout_Click);
            // 
            // mnuDocGia
            // 
            this.mnuDocGia.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YeuCauSach,
            this.SachMoi});
            this.mnuDocGia.Name = "mnuDocGia";
            this.mnuDocGia.Size = new System.Drawing.Size(61, 20);
            this.mnuDocGia.Text = "Độc giả";
            // 
            // YeuCauSach
            // 
            this.YeuCauSach.Name = "YeuCauSach";
            this.YeuCauSach.Size = new System.Drawing.Size(175, 22);
            this.YeuCauSach.Text = "Yêu cầu mua sách";
            this.YeuCauSach.Click += new System.EventHandler(this.YeuCauSach_Click);
            // 
            // SachMoi
            // 
            this.SachMoi.Name = "SachMoi";
            this.SachMoi.Size = new System.Drawing.Size(175, 22);
            this.SachMoi.Text = "Xem sách mới";
            this.SachMoi.Click += new System.EventHandler(this.SachMoi_Click);
            // 
            // tolMain
            // 
            this.tolMain.AutoSize = false;
            this.tolMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolMuonTra,
            this.tolUpdateNewspaper,
            this.tolSearchReader,
            this.tolLine,
            this.lblTimNhanh,
            this.cboType,
            this.cboNewspaper,
            this.cboTypeBook,
            this.txtKeyword,
            this.cboSoPH,
            this.tolSmallSearch,
            this.lblSoLuongCon});
            this.tolMain.Location = new System.Drawing.Point(0, 24);
            this.tolMain.Name = "tolMain";
            this.tolMain.Size = new System.Drawing.Size(973, 39);
            this.tolMain.TabIndex = 2;
            this.tolMain.Text = "toolStrip1";
            // 
            // tolMuonTra
            // 
            this.tolMuonTra.Image = global::QuanLyThuVien.Properties.Resources.muontra;
            this.tolMuonTra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tolMuonTra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolMuonTra.Name = "tolMuonTra";
            this.tolMuonTra.Size = new System.Drawing.Size(97, 36);
            this.tolMuonTra.Text = "Mượn Trả";
            this.tolMuonTra.Click += new System.EventHandler(this.tolMuonTra_Click);
            // 
            // tolUpdateNewspaper
            // 
            this.tolUpdateNewspaper.Image = global::QuanLyThuVien.Properties.Resources.newspaper3;
            this.tolUpdateNewspaper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tolUpdateNewspaper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolUpdateNewspaper.Name = "tolUpdateNewspaper";
            this.tolUpdateNewspaper.Size = new System.Drawing.Size(135, 36);
            this.tolUpdateNewspaper.Text = "Cập nhật Báo TC";
            this.tolUpdateNewspaper.Click += new System.EventHandler(this.tolUpdateNewspaper_Click);
            // 
            // tolSearchReader
            // 
            this.tolSearchReader.Image = global::QuanLyThuVien.Properties.Resources.searchuser;
            this.tolSearchReader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tolSearchReader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolSearchReader.Name = "tolSearchReader";
            this.tolSearchReader.Size = new System.Drawing.Size(136, 36);
            this.tolSearchReader.Text = "Cập nhật độc giả";
            this.tolSearchReader.Click += new System.EventHandler(this.tolSearchReader_Click);
            // 
            // tolLine
            // 
            this.tolLine.Name = "tolLine";
            this.tolLine.Size = new System.Drawing.Size(6, 39);
            // 
            // lblTimNhanh
            // 
            this.lblTimNhanh.Name = "lblTimNhanh";
            this.lblTimNhanh.Size = new System.Drawing.Size(69, 36);
            this.lblTimNhanh.Text = "Tìm nhanh:";
            // 
            // cboType
            // 
            this.cboType.AutoSize = false;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Items.AddRange(new object[] {
            "Sách",
            "Báo TC"});
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(55, 21);
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // cboNewspaper
            // 
            this.cboNewspaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewspaper.Name = "cboNewspaper";
            this.cboNewspaper.Size = new System.Drawing.Size(121, 39);
            this.cboNewspaper.Visible = false;
            this.cboNewspaper.SelectedIndexChanged += new System.EventHandler(this.cboNewspaper_SelectedIndexChanged);
            // 
            // cboTypeBook
            // 
            this.cboTypeBook.AutoSize = false;
            this.cboTypeBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeBook.Items.AddRange(new object[] {
            "Tựa sách",
            "Số MFN",
            "Tác giả",
            "Chủ đề",
            "Nhà XB",
            "Năm XB"});
            this.cboTypeBook.Name = "cboTypeBook";
            this.cboTypeBook.Size = new System.Drawing.Size(70, 21);
            this.cboTypeBook.SelectedIndexChanged += new System.EventHandler(this.cboTypeBook_SelectedIndexChanged);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(150, 39);
            this.txtKeyword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyUp);
            // 
            // cboSoPH
            // 
            this.cboSoPH.AutoSize = false;
            this.cboSoPH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoPH.Name = "cboSoPH";
            this.cboSoPH.Size = new System.Drawing.Size(50, 21);
            this.cboSoPH.SelectedIndexChanged += new System.EventHandler(this.cboSoPH_SelectedIndexChanged);
            // 
            // tolSmallSearch
            // 
            this.tolSmallSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tolSmallSearch.Image = global::QuanLyThuVien.Properties.Resources.searchsmall;
            this.tolSmallSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolSmallSearch.Name = "tolSmallSearch";
            this.tolSmallSearch.Size = new System.Drawing.Size(23, 36);
            this.tolSmallSearch.Text = "toolStripButton1";
            this.tolSmallSearch.ToolTipText = "Tra";
            this.tolSmallSearch.Click += new System.EventHandler(this.tolSmallSearch_Click);
            // 
            // lblSoLuongCon
            // 
            this.lblSoLuongCon.Name = "lblSoLuongCon";
            this.lblSoLuongCon.Size = new System.Drawing.Size(82, 36);
            this.lblSoLuongCon.Text = "Số lượng còn:";
            // 
            // tolSearch
            // 
            this.tolSearch.Image = global::QuanLyThuVien.Properties.Resources.searchtailieu;
            this.tolSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolSearch.Name = "tolSearch";
            this.tolSearch.Size = new System.Drawing.Size(136, 36);
            this.tolSearch.Text = "Tìm kiếm tài liệu";
            // 
            // statMain
            // 
            this.statMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.statMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblManager,
            this.StatManager});
            this.statMain.Location = new System.Drawing.Point(0, 438);
            this.statMain.Name = "statMain";
            this.statMain.Size = new System.Drawing.Size(973, 22);
            this.statMain.TabIndex = 3;
            this.statMain.Text = "statusStrip1";
            // 
            // lblManager
            // 
            this.lblManager.Image = global::QuanLyThuVien.Properties.Resources.user_login;
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(70, 17);
            this.lblManager.Text = "Thủ thư:";
            // 
            // StatManager
            // 
            this.StatManager.Name = "StatManager";
            this.StatManager.Size = new System.Drawing.Size(97, 17);
            this.StatManager.Text = "chưa đăng nhập";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 460);
            this.Controls.Add(this.statMain);
            this.Controls.Add(this.tolMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình Quản lý Thư viện Trường CĐ Công nghiệp Thực phẩm TP HCM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tolMain.ResumeLayout(false);
            this.tolMain.PerformLayout();
            this.statMain.ResumeLayout(false);
            this.statMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem Login;
        private System.Windows.Forms.ToolStripMenuItem Logout;
        private System.Windows.Forms.ToolStripMenuItem ChangePass;
        private System.Windows.Forms.ToolStrip tolMain;
        private System.Windows.Forms.StatusStrip statMain;
        private System.Windows.Forms.ToolStripSeparator Line11;
        private System.Windows.Forms.ToolStripMenuItem ChangeParam;
        private System.Windows.Forms.ToolStripSeparator Line12;
        private System.Windows.Forms.ToolStripMenuItem Backup;
        private System.Windows.Forms.ToolStripMenuItem Restore;
        private System.Windows.Forms.ToolStripSeparator Line13;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem UpdateBook;
        private System.Windows.Forms.ToolStripMenuItem UpdateNewspaper;
        private System.Windows.Forms.ToolStripSeparator Line21;
        private System.Windows.Forms.ToolStripMenuItem UpdateReader;
        private System.Windows.Forms.ToolStripMenuItem UpdateManager;
        private System.Windows.Forms.ToolStripMenuItem mnuSearch;
        private System.Windows.Forms.ToolStripMenuItem SearchBook;
        private System.Windows.Forms.ToolStripMenuItem SearchReader;
        private System.Windows.Forms.ToolStripMenuItem mnuProcess;
        private System.Windows.Forms.ToolStripMenuItem ProcessMuonTra;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem ReportTreHan;
        private System.Windows.Forms.ToolStripMenuItem ReportYeuCau;
        private System.Windows.Forms.ToolStripMenuItem ReportDatCoc;
        private System.Windows.Forms.ToolStripMenuItem ReportMuonNhieu;
        private System.Windows.Forms.ToolStripMenuItem ReportSachMat;
        private System.Windows.Forms.ToolStripMenuItem ReportPhucVu;
        private System.Windows.Forms.ToolStripMenuItem ReportTheoNam;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem HelpGuide;
        private System.Windows.Forms.ToolStripMenuItem HelpAbout;
        private System.Windows.Forms.ToolStripButton tolMuonTra;
        private System.Windows.Forms.ToolStripButton tolSearch;
        private System.Windows.Forms.ToolStripButton tolSearchReader;
        private System.Windows.Forms.ToolStripSeparator tolLine;
        private System.Windows.Forms.ToolStripLabel lblTimNhanh;
        private System.Windows.Forms.ToolStripComboBox cboType;
        private System.Windows.Forms.ToolStripComboBox cboTypeBook;
        private System.Windows.Forms.ToolStripComboBox cboSoPH;
        private System.Windows.Forms.ToolStripButton tolSmallSearch;
        private System.Windows.Forms.ToolStripLabel lblSoLuongCon;
        private System.Windows.Forms.ToolStripStatusLabel lblManager;
        private System.Windows.Forms.ToolStripButton tolUpdateNewspaper;
        private System.Windows.Forms.ToolStripStatusLabel StatManager;
        private System.Windows.Forms.ToolStripTextBox txtKeyword;
        private System.Windows.Forms.ToolStripComboBox cboNewspaper;
        private System.Windows.Forms.ToolStripMenuItem mnuDocGia;
        private System.Windows.Forms.ToolStripMenuItem YeuCauSach;
        private System.Windows.Forms.ToolStripMenuItem SachMoi;
        private System.Windows.Forms.ToolStripMenuItem HideToolBar;
        private System.Windows.Forms.ToolStripSeparator Line14;
        private System.Windows.Forms.ToolStripMenuItem ChangeSkin;
    }
}