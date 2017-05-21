namespace QuanLyThuVien
{
    partial class frmLoaiDocGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiDocGia));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.label64 = new System.Windows.Forms.Label();
            this.txtTenLoaiDocGia = new System.Windows.Forms.TextBox();
            this.ribbonClientPanel2 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.ribbonClientPanel3 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.ribbonClientPanel4 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.ribbonClientPanel1.SuspendLayout();
            this.ribbonClientPanel2.SuspendLayout();
            this.ribbonClientPanel3.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.ribbonClientPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ribbonClientPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ribbonClientPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ribbonClientPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ribbonClientPanel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.76786F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.23214F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(601, 441);
            this.tableLayoutPanel1.TabIndex = 147;
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.groupBox1);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(3, 3);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(595, 78);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseDown.Class = "";
            this.ribbonClientPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseOver.Class = "";
            this.ribbonClientPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel1.TabIndex = 0;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.Location = new System.Drawing.Point(114, 31);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(95, 14);
            this.label64.TabIndex = 144;
            this.label64.Text = "Tên loại độc giả:";
            // 
            // txtTenLoaiDocGia
            // 
            this.txtTenLoaiDocGia.Location = new System.Drawing.Point(223, 28);
            this.txtTenLoaiDocGia.Name = "txtTenLoaiDocGia";
            this.txtTenLoaiDocGia.Size = new System.Drawing.Size(231, 20);
            this.txtTenLoaiDocGia.TabIndex = 145;
            // 
            // ribbonClientPanel2
            // 
            this.ribbonClientPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel2.Controls.Add(this.btnTaoMoi);
            this.ribbonClientPanel2.Controls.Add(this.btnXoa);
            this.ribbonClientPanel2.Controls.Add(this.btnCapnhat);
            this.ribbonClientPanel2.Controls.Add(this.btnThem);
            this.ribbonClientPanel2.Controls.Add(this.btnDong);
            this.ribbonClientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel2.Location = new System.Drawing.Point(3, 87);
            this.ribbonClientPanel2.Name = "ribbonClientPanel2";
            this.ribbonClientPanel2.Size = new System.Drawing.Size(595, 86);
            // 
            // 
            // 
            this.ribbonClientPanel2.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel2.StyleMouseDown.Class = "";
            this.ribbonClientPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel2.StyleMouseOver.Class = "";
            this.ribbonClientPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel2.TabIndex = 1;
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::QuanLyThuVien.Properties.Resources.Delete;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(27, 31);
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
            this.btnCapnhat.Location = new System.Drawing.Point(138, 31);
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
            this.btnDong.Location = new System.Drawing.Point(470, 31);
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
            this.btnThem.Location = new System.Drawing.Point(249, 31);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 27);
            this.btnThem.TabIndex = 62;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // ribbonClientPanel3
            // 
            this.ribbonClientPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel3.Controls.Add(this.groupBox17);
            this.ribbonClientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel3.Location = new System.Drawing.Point(3, 179);
            this.ribbonClientPanel3.Name = "ribbonClientPanel3";
            this.ribbonClientPanel3.Size = new System.Drawing.Size(595, 71);
            // 
            // 
            // 
            this.ribbonClientPanel3.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel3.StyleMouseDown.Class = "";
            this.ribbonClientPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel3.StyleMouseOver.Class = "";
            this.ribbonClientPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel3.TabIndex = 2;
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.Transparent;
            this.groupBox17.Controls.Add(this.btnTim);
            this.groupBox17.Controls.Add(this.cboFilter);
            this.groupBox17.Controls.Add(this.txtKeyword);
            this.groupBox17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.Location = new System.Drawing.Point(0, 0);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(595, 71);
            this.groupBox17.TabIndex = 145;
            this.groupBox17.TabStop = false;
            this.groupBox17.Tag = "";
            this.groupBox17.Text = "Tìm kiếm";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QuanLyThuVien.Properties.Resources.tim;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(403, 26);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(106, 28);
            this.btnTim.TabIndex = 109;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "Gần đúng",
            "Chính xác"});
            this.cboFilter.Location = new System.Drawing.Point(307, 33);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(87, 21);
            this.cboFilter.TabIndex = 108;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(75, 33);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(226, 21);
            this.txtKeyword.TabIndex = 62;
            // 
            // ribbonClientPanel4
            // 
            this.ribbonClientPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel4.Controls.Add(this.groupBox2);
            this.ribbonClientPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel4.Location = new System.Drawing.Point(3, 256);
            this.ribbonClientPanel4.Name = "ribbonClientPanel4";
            this.ribbonClientPanel4.Size = new System.Drawing.Size(595, 182);
            // 
            // 
            // 
            this.ribbonClientPanel4.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel4.StyleMouseDown.Class = "";
            this.ribbonClientPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel4.StyleMouseOver.Class = "";
            this.ribbonClientPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel4.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 182);
            this.groupBox2.TabIndex = 143;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(589, 163);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRecordCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(601, 22);
            this.statusStrip1.TabIndex = 148;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtTenLoaiDocGia);
            this.groupBox1.Controls.Add(this.label64);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 76);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin loại độc giả";
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoMoi.Image")));
            this.btnTaoMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoMoi.Location = new System.Drawing.Point(359, 31);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(105, 27);
            this.btnTaoMoi.TabIndex = 67;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // frmLoaiDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 441);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmLoaiDocGia";
            this.Text = "Loại Độc Giả";
            this.Load += new System.EventHandler(this.frmLoaiDocGia_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ribbonClientPanel2.ResumeLayout(false);
            this.ribbonClientPanel3.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.ribbonClientPanel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox txtTenLoaiDocGia;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnThem;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel3;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.TextBox txtKeyword;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTaoMoi;
    }
}