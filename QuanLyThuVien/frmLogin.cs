using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            this.txtUser.Focus();            
        }

        
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Length != 0 && txtPwd.Text.Trim().Length != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                Login clsLogin = new Login();
                clsLogin.Username = txtUser.Text.Trim();
                clsLogin.Password = txtPwd.Text.Trim();
                LoginService cls = new LoginService();
                if (cls.Login(clsLogin))
                {
                    KiemTra.user = txtUser.Text.Trim();
                    KiemTra.Logged = true;
                    //this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    txtPwd.Focus();
                    txtPwd.SelectAll();
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}