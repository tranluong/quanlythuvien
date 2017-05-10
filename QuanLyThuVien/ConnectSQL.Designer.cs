namespace QuanLyThuVien
{
    partial class ConnectSQL
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cbo_server = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_database = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbx_auth = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.txt_user = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_password = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_show = new DevComponents.DotNetBar.ButtonX();
            this.btn_thoat = new DevComponents.DotNetBar.ButtonX();
            this.btn_reset = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.btn_ketnoi = new DevComponents.DotNetBar.ButtonX();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 25);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Server";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 86);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Database";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 141);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Authentication";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 187);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Username";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(12, 232);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Password";
            // 
            // cbo_server
            // 
            this.cbo_server.DisplayMember = "Text";
            this.cbo_server.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_server.FormattingEnabled = true;
            this.cbo_server.ItemHeight = 14;
            this.cbo_server.Location = new System.Drawing.Point(111, 25);
            this.cbo_server.Name = "cbo_server";
            this.cbo_server.Size = new System.Drawing.Size(305, 20);
            this.cbo_server.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbo_server.TabIndex = 1;
            this.cbo_server.DropDown += new System.EventHandler(this.cbo_server_DropDown);
            // 
            // cbo_database
            // 
            this.cbo_database.DisplayMember = "Text";
            this.cbo_database.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_database.FormattingEnabled = true;
            this.cbo_database.ItemHeight = 14;
            this.cbo_database.Location = new System.Drawing.Point(111, 86);
            this.cbo_database.Name = "cbo_database";
            this.cbo_database.Size = new System.Drawing.Size(305, 20);
            this.cbo_database.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbo_database.TabIndex = 2;
            // 
            // cbx_auth
            // 
            this.cbx_auth.DisplayMember = "Text";
            this.cbx_auth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_auth.FormattingEnabled = true;
            this.cbx_auth.ItemHeight = 14;
            this.cbx_auth.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbx_auth.Location = new System.Drawing.Point(111, 141);
            this.cbx_auth.Name = "cbx_auth";
            this.cbx_auth.Size = new System.Drawing.Size(305, 20);
            this.cbx_auth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbx_auth.TabIndex = 3;
            this.cbx_auth.SelectedIndexChanged += new System.EventHandler(this.cbx_auth_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Window";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "SQL";
            // 
            // txt_user
            // 
            // 
            // 
            // 
            this.txt_user.Border.Class = "TextBoxBorder";
            this.txt_user.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_user.Location = new System.Drawing.Point(111, 187);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(305, 20);
            this.txt_user.TabIndex = 4;
            // 
            // txt_password
            // 
            // 
            // 
            // 
            this.txt_password.Border.Class = "TextBoxBorder";
            this.txt_password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_password.Location = new System.Drawing.Point(111, 232);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(305, 20);
            this.txt_password.TabIndex = 5;
            // 
            // btn_show
            // 
            this.btn_show.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_show.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_show.Location = new System.Drawing.Point(111, 52);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(75, 23);
            this.btn_show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_show.TabIndex = 6;
            this.btn_show.Text = "Hiển thị dữ liệu";
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_thoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_thoat.Location = new System.Drawing.Point(7, 274);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_thoat.TabIndex = 7;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_reset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_reset.Location = new System.Drawing.Point(89, 274);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_reset.TabIndex = 7;
            this.btn_reset.Text = "Xóa lưu";
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(173, 274);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(75, 23);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 7;
            this.buttonX4.Text = "Nhập lại";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // btn_ketnoi
            // 
            this.btn_ketnoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ketnoi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ketnoi.Location = new System.Drawing.Point(257, 274);
            this.btn_ketnoi.Name = "btn_ketnoi";
            this.btn_ketnoi.Size = new System.Drawing.Size(75, 23);
            this.btn_ketnoi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_ketnoi.TabIndex = 7;
            this.btn_ketnoi.Text = "Thử kết nối";
            this.btn_ketnoi.Click += new System.EventHandler(this.btn_ketnoi_Click);
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_save.Location = new System.Drawing.Point(341, 274);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Lưu cấu hình";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // ConnectSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 336);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_ketnoi);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.cbx_auth);
            this.Controls.Add(this.cbo_database);
            this.Controls.Add(this.cbo_server);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Name = "ConnectSQL";
            this.Text = "ConnectSQL";
            this.Load += new System.EventHandler(this.ConnectSQL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_server;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_database;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbx_auth;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_user;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_password;
        private DevComponents.DotNetBar.ButtonX btn_show;
        private DevComponents.DotNetBar.ButtonX btn_thoat;
        private DevComponents.DotNetBar.ButtonX btn_reset;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX btn_ketnoi;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
    }
}