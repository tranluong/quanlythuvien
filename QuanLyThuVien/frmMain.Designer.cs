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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.Line11 = new System.Windows.Forms.ToolStripSeparator();
            this.Line12 = new System.Windows.Forms.ToolStripSeparator();
            this.Line13 = new System.Windows.Forms.ToolStripSeparator();
            this.Line14 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.Line21 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.statMain = new System.Windows.Forms.StatusStrip();
            this.StatManager = new System.Windows.Forms.ToolStripStatusLabel();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.lblManager = new System.Windows.Forms.ToolStripStatusLabel();
            this.Login = new System.Windows.Forms.ToolStripMenuItem();
            this.Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.Restore = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateBook = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàXuấtBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiĐộcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateReader = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateManager = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchBook = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchReader = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessMuonTra = new System.Windows.Forms.ToolStripMenuItem();
            this.trảSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportTreHan = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportMuonNhieu = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêMượnTrảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tolSearch = new System.Windows.Forms.ToolStripButton();
            this.mnuMain.SuspendLayout();
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
            this.mnuReport});
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
            this.Line12,
            this.Backup,
            this.Restore,
            this.Line13,
            this.Line14,
            this.Exit});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(70, 20);
            this.mnuSystem.Text = "&Hệ thống";
            // 
            // Line11
            // 
            this.Line11.Name = "Line11";
            this.Line11.Size = new System.Drawing.Size(159, 6);
            // 
            // Line12
            // 
            this.Line12.Name = "Line12";
            this.Line12.Size = new System.Drawing.Size(159, 6);
            // 
            // Line13
            // 
            this.Line13.Name = "Line13";
            this.Line13.Size = new System.Drawing.Size(159, 6);
            // 
            // Line14
            // 
            this.Line14.Name = "Line14";
            this.Line14.Size = new System.Drawing.Size(159, 6);
            // 
            // mnuUpdate
            // 
            this.mnuUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateBook,
            this.loạiSáchToolStripMenuItem,
            this.nhàXuấtBảnToolStripMenuItem,
            this.Line21,
            this.loạiĐộcGiảToolStripMenuItem,
            this.UpdateReader,
            this.UpdateManager});
            this.mnuUpdate.Name = "mnuUpdate";
            this.mnuUpdate.Size = new System.Drawing.Size(69, 20);
            this.mnuUpdate.Text = "&Cập nhật";
            // 
            // Line21
            // 
            this.Line21.Name = "Line21";
            this.Line21.Size = new System.Drawing.Size(145, 6);
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
            // mnuProcess
            // 
            this.mnuProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpSáchToolStripMenuItem,
            this.ProcessMuonTra,
            this.trảSáchToolStripMenuItem});
            this.mnuProcess.Name = "mnuProcess";
            this.mnuProcess.Size = new System.Drawing.Size(47, 20);
            this.mnuProcess.Text = "&Xử lý";
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportTreHan,
            this.ReportMuonNhieu,
            this.thốngKêMượnTrảToolStripMenuItem});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(63, 20);
            this.mnuReport.Text = "&Báo cáo";
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
            // StatManager
            // 
            this.StatManager.Name = "StatManager";
            this.StatManager.Size = new System.Drawing.Size(97, 17);
            this.StatManager.Text = "chưa đăng nhập";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // lblManager
            // 
            this.lblManager.Image = global::QuanLyThuVien.Properties.Resources.user_login;
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(70, 16);
            this.lblManager.Text = "Thủ thư:";
            // 
            // Login
            // 
            this.Login.Image = global::QuanLyThuVien.Properties.Resources.login;
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(162, 22);
            this.Login.Text = "Đăng nhập";
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Logout
            // 
            this.Logout.Image = global::QuanLyThuVien.Properties.Resources.logout;
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(162, 22);
            this.Logout.Text = "Đăng xuất";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // ChangePass
            // 
            this.ChangePass.Image = global::QuanLyThuVien.Properties.Resources.changepass;
            this.ChangePass.Name = "ChangePass";
            this.ChangePass.Size = new System.Drawing.Size(162, 22);
            this.ChangePass.Text = "Đổi mật khẩu";
            this.ChangePass.Click += new System.EventHandler(this.ChangePass_Click);
            // 
            // Backup
            // 
            this.Backup.Image = global::QuanLyThuVien.Properties.Resources.backup;
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(162, 22);
            this.Backup.Text = "Sao lưu dữ liệu";
            this.Backup.Click += new System.EventHandler(this.Backup_Click);
            // 
            // Restore
            // 
            this.Restore.Image = global::QuanLyThuVien.Properties.Resources.restore;
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(162, 22);
            this.Restore.Text = "Phục hồi dữ liệu";
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // Exit
            // 
            this.Exit.Image = global::QuanLyThuVien.Properties.Resources.exit;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(162, 22);
            this.Exit.Text = "Thoát";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // UpdateBook
            // 
            this.UpdateBook.Image = global::QuanLyThuVien.Properties.Resources.books;
            this.UpdateBook.Name = "UpdateBook";
            this.UpdateBook.Size = new System.Drawing.Size(148, 22);
            this.UpdateBook.Text = "Sách";
            this.UpdateBook.Click += new System.EventHandler(this.UpdateBook_Click);
            // 
            // loạiSáchToolStripMenuItem
            // 
            this.loạiSáchToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.books;
            this.loạiSáchToolStripMenuItem.Name = "loạiSáchToolStripMenuItem";
            this.loạiSáchToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loạiSáchToolStripMenuItem.Text = "Loại sách";
            this.loạiSáchToolStripMenuItem.Click += new System.EventHandler(this.loạiSáchToolStripMenuItem_Click);
            // 
            // nhàXuấtBảnToolStripMenuItem
            // 
            this.nhàXuấtBảnToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.newspaper;
            this.nhàXuấtBảnToolStripMenuItem.Name = "nhàXuấtBảnToolStripMenuItem";
            this.nhàXuấtBảnToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.nhàXuấtBảnToolStripMenuItem.Text = "Nhà xuất bản";
            this.nhàXuấtBảnToolStripMenuItem.Click += new System.EventHandler(this.nhàXuấtBảnToolStripMenuItem_Click);
            // 
            // loạiĐộcGiảToolStripMenuItem
            // 
            this.loạiĐộcGiảToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.docgia2;
            this.loạiĐộcGiảToolStripMenuItem.Name = "loạiĐộcGiảToolStripMenuItem";
            this.loạiĐộcGiảToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loạiĐộcGiảToolStripMenuItem.Text = "Loại độc giả";
            this.loạiĐộcGiảToolStripMenuItem.Click += new System.EventHandler(this.loạiĐộcGiảToolStripMenuItem_Click);
            // 
            // UpdateReader
            // 
            this.UpdateReader.Image = global::QuanLyThuVien.Properties.Resources.users;
            this.UpdateReader.Name = "UpdateReader";
            this.UpdateReader.Size = new System.Drawing.Size(148, 22);
            this.UpdateReader.Text = "Độc giả";
            this.UpdateReader.Click += new System.EventHandler(this.UpdateReader_Click);
            // 
            // UpdateManager
            // 
            this.UpdateManager.Image = global::QuanLyThuVien.Properties.Resources.thuthu;
            this.UpdateManager.Name = "UpdateManager";
            this.UpdateManager.Size = new System.Drawing.Size(148, 22);
            this.UpdateManager.Text = "Thủ thư";
            this.UpdateManager.Click += new System.EventHandler(this.UpdateManager_Click);
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
            // nhậpSáchToolStripMenuItem
            // 
            this.nhậpSáchToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.newspaper;
            this.nhậpSáchToolStripMenuItem.Name = "nhậpSáchToolStripMenuItem";
            this.nhậpSáchToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.nhậpSáchToolStripMenuItem.Text = "Phiếu Nhập";
            this.nhậpSáchToolStripMenuItem.Click += new System.EventHandler(this.nhậpSáchToolStripMenuItem_Click);
            // 
            // ProcessMuonTra
            // 
            this.ProcessMuonTra.Image = global::QuanLyThuVien.Properties.Resources.muontra;
            this.ProcessMuonTra.Name = "ProcessMuonTra";
            this.ProcessMuonTra.Size = new System.Drawing.Size(136, 22);
            this.ProcessMuonTra.Text = "Mượn Sách";
            this.ProcessMuonTra.Click += new System.EventHandler(this.ProcessMuonTra_Click);
            // 
            // trảSáchToolStripMenuItem
            // 
            this.trảSáchToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.books;
            this.trảSáchToolStripMenuItem.Name = "trảSáchToolStripMenuItem";
            this.trảSáchToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.trảSáchToolStripMenuItem.Text = "Trả sách";
            // 
            // ReportTreHan
            // 
            this.ReportTreHan.Image = global::QuanLyThuVien.Properties.Resources.newspaper3;
            this.ReportTreHan.Name = "ReportTreHan";
            this.ReportTreHan.Size = new System.Drawing.Size(182, 22);
            this.ReportTreHan.Text = "Phiếu nhập";
            this.ReportTreHan.Click += new System.EventHandler(this.ReportTreHan_Click);
            // 
            // ReportMuonNhieu
            // 
            this.ReportMuonNhieu.Image = global::QuanLyThuVien.Properties.Resources.newspaper2;
            this.ReportMuonNhieu.Name = "ReportMuonNhieu";
            this.ReportMuonNhieu.Size = new System.Drawing.Size(182, 22);
            this.ReportMuonNhieu.Text = "Thống kế sách";
            this.ReportMuonNhieu.Click += new System.EventHandler(this.ReportMuonNhieu_Click);
            // 
            // thốngKêMượnTrảToolStripMenuItem
            // 
            this.thốngKêMượnTrảToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.newspaper;
            this.thốngKêMượnTrảToolStripMenuItem.Name = "thốngKêMượnTrảToolStripMenuItem";
            this.thốngKêMượnTrảToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.thốngKêMượnTrảToolStripMenuItem.Text = "Thống kê mượn trả";
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 460);
            this.Controls.Add(this.statMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình Quản lý Thư viện Trường Đại Học Công nghiệp Thực phẩm TP HCM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statMain;
        private System.Windows.Forms.ToolStripSeparator Line11;
        private System.Windows.Forms.ToolStripSeparator Line12;
        private System.Windows.Forms.ToolStripMenuItem Backup;
        private System.Windows.Forms.ToolStripMenuItem Restore;
        private System.Windows.Forms.ToolStripSeparator Line13;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem UpdateBook;
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
        private System.Windows.Forms.ToolStripMenuItem ReportMuonNhieu;
        private System.Windows.Forms.ToolStripButton tolSearch;
        private System.Windows.Forms.ToolStripStatusLabel lblManager;
        private System.Windows.Forms.ToolStripStatusLabel StatManager;
        private System.Windows.Forms.ToolStripSeparator Line14;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ToolStripMenuItem nhậpSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loạiSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàXuấtBảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loạiĐộcGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trảSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêMượnTrảToolStripMenuItem;
    }
}