namespace QuanLyThuVien
{
    partial class frmYeuCauMuaSach
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNXB = new System.Windows.Forms.TextBox();
            this.txtGiaBia = new System.Windows.Forms.TextBox();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::QuanLyThuVien.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(244, 239);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::QuanLyThuVien.Properties.Resources.Add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(22, 239);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 27);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(115, 28);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(234, 20);
            this.txtMSSV.TabIndex = 1;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.Location = new System.Drawing.Point(12, 31);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(68, 14);
            this.label64.TabIndex = 140;
            this.label64.Text = "Mã độc giả:";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 22);
            this.label3.TabIndex = 139;
            this.label3.Text = "YÊU CẦU MUA SÁCH";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMore
            // 
            this.txtMore.Location = new System.Drawing.Point(115, 158);
            this.txtMore.Multiline = true;
            this.txtMore.Name = "txtMore";
            this.txtMore.Size = new System.Drawing.Size(234, 75);
            this.txtMore.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 140;
            this.label1.Text = "Thông tin thêm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 140;
            this.label2.Text = "Tên sách:";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(115, 54);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(234, 20);
            this.txtTenSach.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 140;
            this.label4.Text = "Tác giả:";
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(115, 80);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(234, 20);
            this.txtTacGia.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 140;
            this.label5.Text = "Nhà XB:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 14);
            this.label6.TabIndex = 140;
            this.label6.Text = "Giá bìa:";
            // 
            // txtNXB
            // 
            this.txtNXB.Location = new System.Drawing.Point(115, 106);
            this.txtNXB.Name = "txtNXB";
            this.txtNXB.Size = new System.Drawing.Size(234, 20);
            this.txtNXB.TabIndex = 4;
            // 
            // txtGiaBia
            // 
            this.txtGiaBia.Location = new System.Drawing.Point(115, 132);
            this.txtGiaBia.Name = "txtGiaBia";
            this.txtGiaBia.Size = new System.Drawing.Size(234, 20);
            this.txtGiaBia.TabIndex = 5;
            this.txtGiaBia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaBia_KeyPress);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMoi.Image = global::QuanLyThuVien.Properties.Resources.taomoi;
            this.btnTaoMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoMoi.Location = new System.Drawing.Point(133, 239);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(105, 27);
            this.btnTaoMoi.TabIndex = 8;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // frmYeuCauMuaSach
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(361, 277);
            this.Controls.Add(this.btnTaoMoi);
            this.Controls.Add(this.txtMore);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtGiaBia);
            this.Controls.Add(this.txtNXB);
            this.Controls.Add(this.txtTacGia);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmYeuCauMuaSach";
            this.Text = "Yêu cầu mua sách";
            this.Load += new System.EventHandler(this.frmYeuCauMuaSach_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNXB;
        private System.Windows.Forms.TextBox txtGiaBia;
        private System.Windows.Forms.Button btnTaoMoi;
    }
}