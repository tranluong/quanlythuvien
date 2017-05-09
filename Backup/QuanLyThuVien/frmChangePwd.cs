using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmChangePwd : Form
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            { 
                Login clsLogin = new Login();
                clsLogin.UserID = KiemTra.userid;
                clsLogin.Username = KiemTra.user;
                clsLogin.Password = txtOldPwd.Text;
                clsLogin.NewPassword = txtPwd1.Text;
                LoginService cls = new LoginService();
                if (cls.ChangePwd(clsLogin))
                {
                    MessageBox.Show("Thay ���i m��t kh��u tha�nh c�ng", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOldPwd.Focus();
                }
            }
        }

        private string strError = "";
        private bool Validation()
        {
            if (txtOldPwd.Text.Length == 0)
            {
                strError = "Nh��p m��t kh��u cu�";
                txtOldPwd.Focus();
                return false;
            }
            if (txtPwd1.Text.Length == 0)
            {
                strError = "Nh��p m��t kh��u m��i";
                txtPwd1.Focus();
                return false;
            }
            if (txtPwd2.Text.Length == 0)
            {
                strError = "Nh��p la�i m��t kh��u m��i";
                txtPwd2.Focus();
                return false;
            }
            if (txtPwd1.Text != txtPwd2.Text)
            {
                strError = "Hai m��t kh��u m��i kh�ng gi��ng nhau";
                txtPwd1.Focus();
                txtPwd1.SelectAll();
                return false;
            }
            return true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}