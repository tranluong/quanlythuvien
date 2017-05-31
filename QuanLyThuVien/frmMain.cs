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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {            
            //AcceptButton = tolSmallSearch;
            //Hệ thống
            Login.Enabled = true;
            Logout.Enabled = false;
            ChangePass.Enabled = false;
            Backup.Enabled = false;
            Restore.Enabled = false;
            //Cập nhật
            mnuUpdate.Enabled = false;
            UpdateBook.Enabled = false;
            UpdateReader.Enabled = false;
            UpdateManager.Enabled = false;
            //Xử lý
            mnuProcess.Enabled = false;
            ProcessMuonTra.Enabled = false;
            //Báo cáo
            mnuReport.Enabled = false;  
            MuonTraService cls = new MuonTraService();           
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);            
         
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
                                mnuUpdate.Enabled = true;                   
                            }
                        }
                        if (i == 6)
                        {
                            if (byt[i] == 1)
                            {
                                UpdateReader.Enabled = true;
                                mnuUpdate.Enabled = true;
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
                Backup.Enabled = false;
                Restore.Enabled = false;
                //Cập nhật
                mnuUpdate.Enabled = false;
                UpdateBook.Enabled = false;
                UpdateReader.Enabled = false;
                UpdateManager.Enabled = false;
                //Xử lý
                mnuProcess.Enabled = false;
                ProcessMuonTra.Enabled = false;
                //Báo cáo
                mnuReport.Enabled = false;             

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
            frmDocGia frm = new frmDocGia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            Manager.GetCodeHD.TenMaNV = StatManager.Text;        
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

        private void tolSearchReader_Click(object sender, EventArgs e)
        {
            frmDocGia frm = new frmDocGia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            Manager test = new Manager();
            StatManager.Text = Manager.GetCodeHD.TenMaNV;
        }

        private void nhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frm = new frmPhieuNhap();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void loạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiSach frm = new frmLoaiSach();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaXB frm = new frmNhaXB();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void loạiĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiDocGia frm = new frmLoaiDocGia();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ProcessMuonTra_Click(object sender, EventArgs e)
        {
            frmMuonSach frm = new frmMuonSach();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportTreHan_Click(object sender, EventArgs e)
        {
            InPhieuNhap frm = new InPhieuNhap();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void ReportMuonNhieu_Click(object sender, EventArgs e)
        {
            frmThongKeSach frm = new frmThongKeSach();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraSach frm = new frmTraSach();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimSach frm = new frmTimSach();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}