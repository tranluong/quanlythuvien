using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Sunisoft.IrisSkin;

namespace QuanLyThuVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            se = new SkinEngine();
            se.SerialNumber = "n7cKULtvGKV9Xvrwywp6jEjZtTJqexLVUVJm+5BfuNMgk1tYsIPRmw==";
            se.BuiltIn = true;
            se.SkinFile = "skins\\Vista.ssk";
            se.SkinAllForm = true;
            se.Active = false;
            loadSkinsMenu();
        }
        private SkinEngine se;
        //Hàm đổi giao diện khi click
        private void skinmenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem skinmenu = (ToolStripMenuItem)sender;
            //Giao diện mặc định
            foreach (ToolStripMenuItem ts in ChangeSkin.DropDownItems)
            {
                ts.Checked = false;
            }
            if (skinmenu == ChangeSkin.DropDownItems[0])
            {
                se.SkinAllForm = false;
                se.Active = false;
                skinmenu.Checked = true;
                return;
            }
            string skinlocation = "skins\\" + skinmenu.Text + ".ssk";
            loadSkin(skinlocation);            
            skinmenu.Checked = true;
        }
        //Hàm load skin menu
        private void loadSkinsMenu()
        {
            try
            {
                string[] files = Directory.GetFiles("skins", "*.ssk", SearchOption.TopDirectoryOnly);
                ToolStripMenuItem[] skinmenu = new ToolStripMenuItem[files.Length];                
                ToolStripMenuItem defaultSkin = new ToolStripMenuItem();
                defaultSkin.Text = "Mặc định";
                defaultSkin.Checked = true;
                defaultSkin.Click += new EventHandler(skinmenu_Click);
                ChangeSkin.DropDownItems.Add(defaultSkin);                
                for (int i = 0; i < files.Length; i++)
                {
                    string[] temp = files[i].Split('\\');                    
                    temp = temp[temp.Length - 1].Split('.');
                    skinmenu[i] = new ToolStripMenuItem();
                    skinmenu[i].Text = temp[0];
                    skinmenu[i].Click += new EventHandler(skinmenu_Click);
                    ChangeSkin.DropDownItems.Add(skinmenu[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Load skin với path truyền vào
        private void loadSkin(string skinFile)
        {
            try
            {
                se.SkinFile = skinFile;
                se.SkinAllForm = true;                
                se.Active = true;                
            }
            catch 
            {
                MessageBox.Show("Thay đổi giao diện thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {            
            //AcceptButton = tolSmallSearch;
            //Hệ thống
            Login.Enabled = true;
            Logout.Enabled = false;
            ChangePass.Enabled = false;
            ChangeParam.Enabled = false;
            Backup.Enabled = false;
            Restore.Enabled = false;
            //Cập nhật
            mnuUpdate.Enabled = false;
            UpdateBook.Enabled = false;
            UpdateNewspaper.Enabled = false;
            UpdateReader.Enabled = false;
            UpdateManager.Enabled = false;
            //Xử lý
            mnuProcess.Enabled = false;
            ProcessMuonTra.Enabled = false;
            //Báo cáo
            mnuReport.Enabled = false;
            //Toolbar
            tolMuonTra.Enabled = false;
            tolUpdateNewspaper.Enabled = false;
            tolSearchReader.Enabled = false;
            //Tìm nhanh
            cboType.SelectedIndex = 0;//0=Sách, 1=Báo TC
            cboTypeBook.SelectedIndex = 1;//0=Tựa sách,1=Số MFN,2=Tác giả,3=Chủ đề,4=Nhà XB,5=Năm XB            
            MuonTraService cls = new MuonTraService();
            //fill vào tên báo tc  
            ComboBox cb = (ComboBox)cboNewspaper.Control;
            cb.DataSource = cls.ShowAllBaoTC();
            cb.DisplayMember = "TenBTC";
            cb.ValueMember = "MaTenBTC";            
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);            
            //fill vào số btc            
            ComboBox cbSoPH = (ComboBox)cboSoPH.Control;
            cbSoPH.DataSource = cls.ShowAllBaoTC(Convert.ToInt32(cboNewspaper.ComboBox.SelectedValue));            
            cbSoPH.DisplayMember = "SoPH";
            cbSoPH.ValueMember = "SoPH";            
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);            

            frmLogin frm = new frmLogin();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.Disposed += new EventHandler(Logging);
        }

        private void Logging(object sender, EventArgs e)
        {
            if (KiemTra.Logged == true)
            {
                LoginService cls = new LoginService();
                byte[] byt = cls.Permission(KiemTra.userid);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    for (int i = 0; i < 10; i++)
                    {                        
                        if (i == 0)
                            ChangePass.Enabled = (byt[i] == 1 ? true : false);
                        if (i == 1)
                            ChangeParam.Enabled = (byt[i] == 1 ? true : false);
                        if (i == 2)
                            Backup.Enabled = (byt[i] == 1 ? true : false);
                        if (i == 3)
                            Restore.Enabled = (byt[i] == 1 ? true : false);
                        if (i == 4)
                        {
                            if (byt[i] == 1)
                            {
                                UpdateBook.Enabled = true;
                                mnuUpdate.Enabled = true;
                            }
                        }
                        if (i == 5)
                        {
                            if (byt[i] == 1)
                            {
                                UpdateNewspaper.Enabled = true;
                                mnuUpdate.Enabled = true;
                                tolUpdateNewspaper.Enabled = true;
                            }
                        }
                        if (i == 6)
                        {
                            if (byt[i] == 1)
                            {
                                UpdateReader.Enabled = true;
                                mnuUpdate.Enabled = true;
                                tolSearchReader.Enabled = true;
                            }
                        }
                        if (i == 7)
                        {
                            if (byt[i] == 1)
                            {
                                UpdateManager.Enabled = true;
                                mnuUpdate.Enabled = true;
                            }
                        }
                        if (i == 8)
                        {
                            if (byt[i] == 1)
                            {
                                ProcessMuonTra.Enabled = true;
                                mnuProcess.Enabled = true;
                                tolMuonTra.Enabled = true;
                            }
                        }
                        if (i == 9)
                            mnuReport.Enabled = (byt[i] == 1 ? true : false);
                    }
                }
                Logout.Enabled = true;                
                Login.Enabled = false;
                StatManager.Text = KiemTra.user;
            }            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát khỏi chương trình này ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            foreach (Form f in frmMain.ActiveForm.MdiChildren)
                if (f.Name == "frmLogin")
                    f.Hide();
            frmLogin frm = new frmLogin();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.Disposed += new EventHandler(Logging);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                cboTypeBook.Visible = true;
                txtKeyword.Visible = true;
                cboNewspaper.Visible = false;
                cboSoPH.Visible = false;
            }
            else
            {
                cboTypeBook.Visible = false;
                txtKeyword.Visible = false;
                cboNewspaper.Visible = true;
                cboSoPH.Visible = true;
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng xuất khỏi tên đăng nhập: "+KiemTra.user+" ?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form f in frmMain.ActiveForm.MdiChildren)
                    f.Hide();                    

                //Hệ thống
                Login.Enabled = true;
                Logout.Enabled = false;
                ChangePass.Enabled = false;
                ChangeParam.Enabled = false;
                Backup.Enabled = false;
                Restore.Enabled = false;
                //Cập nhật
                mnuUpdate.Enabled = false;
                UpdateBook.Enabled = false;
                UpdateNewspaper.Enabled = false;
                UpdateReader.Enabled = false;
                UpdateManager.Enabled = false;
                //Xử lý
                mnuProcess.Enabled = false;
                ProcessMuonTra.Enabled = false;
                //Báo cáo
                mnuReport.Enabled = false;
                //Toolbar
                tolMuonTra.Enabled = false;
                tolUpdateNewspaper.Enabled = false;
                tolSearchReader.Enabled = false;                

                KiemTra.Logged = false;
                KiemTra.user = "chưa đăng nhập";
                StatManager.Text = "chưa đăng nhập";

                frmLogin frm = new frmLogin();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
                frm.Disposed += new EventHandler(Logging);
            }
        }

        private void UpdateReader_Click(object sender, EventArgs e)
        {
            frmCapNhatDocGia frm = new frmCapNhatDocGia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void UpdateManager_Click(object sender, EventArgs e)
        {
            frmCapNhatThuThu frm =new frmCapNhatThuThu();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ChangePass_Click(object sender, EventArgs e)
        {
            frmChangePwd frm = new frmChangePwd();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ChangeParam_Click(object sender, EventArgs e)
        {
            frmParam frm = new frmParam();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void Backup_Click(object sender, EventArgs e)
        {
            frmBackup frm = new frmBackup();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            frmRestore frm = new frmRestore();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void UpdateBook_Click(object sender, EventArgs e)
        {
            frmCapNhatSach frm = new frmCapNhatSach();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void UpdateNewspaper_Click(object sender, EventArgs e)
        {
            frmCapNhatBaoTC frm = new frmCapNhatBaoTC();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;            
            frm.Show();
            frm.Disposed += new EventHandler(frm_Disposed);
        }        

        void frm_Disposed(object sender, EventArgs e)
        {            
            MuonTraService cls = new MuonTraService();            
            cboNewspaper.ComboBox.DataSource = cls.ShowAllBaoTC();
        }        

        private void SearchBook_Click(object sender, EventArgs e)
        {
            frmTimTaiLieu frm = new frmTimTaiLieu();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void SearchReader_Click(object sender, EventArgs e)
        {
            frmTimDocGia frm = new frmTimDocGia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ProcessMuonTra_Click(object sender, EventArgs e)
        {
            frmMuonTra frm = new frmMuonTra();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportTreHan_Click(object sender, EventArgs e)
        {
            rptTreHan frm = new rptTreHan();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportDatCoc_Click(object sender, EventArgs e)
        {
            rptTienDatCoc frm = new rptTienDatCoc();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportMuonNhieu_Click(object sender, EventArgs e)
        {
            rptSachMuonNhieu frm = new rptSachMuonNhieu();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportSachMat_Click(object sender, EventArgs e)
        {
            rptSachMat frm = new rptSachMat();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportPhucVu_Click(object sender, EventArgs e)
        {
            rptPhucVuBanDoc frm = new rptPhucVuBanDoc();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportTheoNam_Click(object sender, EventArgs e)
        {
            rptKiemKeTaiSan frm = new rptKiemKeTaiSan();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void tolMuonTra_Click(object sender, EventArgs e)
        {
            frmMuonTra frm = new frmMuonTra();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void tolUpdateNewspaper_Click(object sender, EventArgs e)
        {
            frmCapNhatBaoTC frm = new frmCapNhatBaoTC();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.Disposed += new EventHandler(frm_Disposed);
        }

        private void tolSearchReader_Click(object sender, EventArgs e)
        {
            frmCapNhatDocGia frm = new frmCapNhatDocGia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void tolSmallSearch_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)//Sách
            {                
                if (txtKeyword.Text.Trim().Length != 0)
                {
                    if (cboTypeBook.SelectedIndex == 1)
                    {                        
                        try
                        {
                            int intMaTS = Convert.ToInt32(txtKeyword.Text.Trim());
                            BookService cls = new BookService();
                            Book clsBook = cls.Stat(intMaTS);
                            lblSoLuongCon.Text = "Số lượng còn: " + clsBook.SLCon.ToString() + "/" + clsBook.TongDauSach.ToString();
                        }
                        catch 
                        {
                            MessageBox.Show("Số MFN không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                        
                    }
                    else
                    {
                        frmTimTaiLieu frm = new frmTimTaiLieu();
                        frm.intType = cboTypeBook.ComboBox.SelectedIndex;
                        frm.intFilter = 0;
                        frm.strKeyword = txtKeyword.Text.Trim();
                        frm.MdiParent = this;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Show();
                    }
                }                
            }            
        }

        

        private void cboNewspaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            MuonTraService cls = new MuonTraService();
            ComboBox cbSoPH = (ComboBox)cboSoPH.Control;
            cbSoPH.DataSource = cls.ShowAllBaoTC(Convert.ToInt32(cboNewspaper.ComboBox.SelectedValue));
            cbSoPH.DisplayMember = "SoPH";
            cbSoPH.ValueMember = "SoPH";
            //cboSoPH.SelectedIndex = 0;
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cboSoPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            MuonTraService cls = new MuonTraService();
            int intMaTenBTC = Convert.ToInt32(cboNewspaper.ComboBox.SelectedValue);
            string strSoPH = cboSoPH.ComboBox.SelectedValue.ToString();
            int intTongSo = cls.GetInfoNewspaper(intMaTenBTC, strSoPH).SoLuongNhap;
            int intSLCon = cls.GetInfoNewspaper(intMaTenBTC, strSoPH).SoLuongConBTC;
            lblSoLuongCon.Text = "Số lượng còn: " + intSLCon.ToString() + "/" + intTongSo.ToString();
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cboTypeBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTypeBook.SelectedIndex == 1)
            {
                txtKeyword.Text = "";
                txtKeyword.KeyPress += new KeyPressEventHandler(txtKeyword_KeyPress);
            }
            else
            {
                txtKeyword.KeyPress +=new KeyPressEventHandler(txtKeyword_KeyPress1);
            }
            txtKeyword.Focus();
            txtKeyword.SelectAll();
        }

        void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {            
            e.Handled = Input.Number(e);
        }

        void txtKeyword_KeyPress1(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void txtKeyword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tolSmallSearch_Click(sender, e);
        }

        private void YeuCauSach_Click(object sender, EventArgs e)
        {
            frmYeuCauMuaSach frm = new frmYeuCauMuaSach();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void SachMoi_Click(object sender, EventArgs e)
        {
            rptSachMoi frm = new rptSachMoi();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportYeuCau_Click(object sender, EventArgs e)
        {
            rptSachYeuCau frm = new rptSachYeuCau();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void HideToolBar_Click(object sender, EventArgs e)
        {
            tolMain.Visible = HideToolBar.Checked;
            HideToolBar.Checked = !HideToolBar.Checked;            
        }

        private void HelpGuide_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = Application.StartupPath + "\\Help.chm";
                p.Start();
            }
            catch
            {
                MessageBox.Show("Mở file Help.chm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}