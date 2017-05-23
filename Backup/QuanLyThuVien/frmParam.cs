using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmParam : Form
    {
        public frmParam()
        {
            InitializeComponent();
        }

        private void frmParam_Load(object sender, EventArgs e)
        {
            HeThongService cls = new HeThongService();
            HeThong clsHeThong = cls.GetParam();
            if (cls.Error != "")
            {
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtSoTienDatCoc.Text = Convert.ToString(clsHeThong.SoTienDatCoc);
                txtSoNgayMuonVe.Text = Convert.ToString(clsHeThong.SoNgayMuonVe);
                txtSoTienPhatTreHanVe.Text = Convert.ToString(clsHeThong.SoTienPhatTreHanVe);
                txtSoTienPhatTreHanTaiCho.Text = Convert.ToString(clsHeThong.SoTienPhatTreHanTaiCho);
                txtSoCuonMuonVe.Text = Convert.ToString(clsHeThong.SoCuonMuonVe);
                txtSoCuonMuonTaiCho.Text = Convert.ToString(clsHeThong.SoCuonMuonTaiCho);
                txtSoCuonMuonGVBC.Text = Convert.ToString(clsHeThong.SoCuonMuonGVBC);
                txtSoNgayThanhLyBao.Text = Convert.ToString(clsHeThong.SoNgayThanhLyBao);
                txtSoNgayThanhLyTapchi.Text = Convert.ToString(clsHeThong.SoNgayThanhLyTapchi);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoTienDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoNgayMuonVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoTienPhatTreHanVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoTienPhatTreHanTaiCho_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoCuonMuonVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoCuonMuonTaiCho_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoCuonMuonGVBC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoNgayThanhLyBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void txtSoNgayThanhLyTapchi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Input.Number(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validation())
                MessageBox.Show(strError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                HeThong clsHeThong = new HeThong();
                clsHeThong.SoTienDatCoc = Convert.ToInt32(txtSoTienDatCoc.Text);
                clsHeThong.SoNgayMuonVe = Convert.ToByte(txtSoNgayMuonVe.Text);
                clsHeThong.SoTienPhatTreHanVe = Convert.ToInt32(txtSoTienPhatTreHanVe.Text);
                clsHeThong.SoTienPhatTreHanTaiCho = Convert.ToInt32(txtSoTienPhatTreHanTaiCho.Text);
                clsHeThong.SoCuonMuonVe = Convert.ToByte(txtSoCuonMuonVe.Text);
                clsHeThong.SoCuonMuonTaiCho = Convert.ToByte(txtSoCuonMuonTaiCho.Text);
                clsHeThong.SoCuonMuonGVBC = Convert.ToByte(txtSoCuonMuonGVBC.Text);
                clsHeThong.SoNgayThanhLyBao = Convert.ToByte(txtSoNgayThanhLyBao.Text);
                clsHeThong.SoNgayThanhLyTapchi = Convert.ToByte(txtSoNgayThanhLyTapchi.Text);
                HeThongService cls = new HeThongService();
                if (cls.ChangeParam(clsHeThong))
                {
                    MessageBox.Show("Thay ���i quy �i�nh tha�nh c�ng", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string strError = "";
        private bool Validation()
        {
            if (txtSoTienDatCoc.Text.Length == 0)
            {
                strError = "Nh��p s�� ti��n ���t co�c";
                txtSoTienDatCoc.Focus();
                return false;
            }
            if (txtSoNgayMuonVe.Text.Length == 0)
            {
                strError = "Nh��p s�� nga�y m���n v��";
                txtSoNgayMuonVe.Focus();
                return false;
            }
            if (txtSoTienPhatTreHanVe.Text.Length == 0)
            {
                strError = "Nh��p s�� ti��n pha�t m���n v�� tr�� ha�n";
                txtSoTienPhatTreHanVe.Focus();
                return false;
            }
            if (txtSoTienPhatTreHanTaiCho.Text.Length == 0)
            {
                strError = "Nh��p s�� ti��n pha�t ta�i ch�� tr�� ha�n";
                txtSoTienPhatTreHanTaiCho.Focus();
                return false;
            }
            if (txtSoCuonMuonVe.Text.Length == 0)
            {
                strError = "Nh��p s�� cu��n m���n v��";
                txtSoCuonMuonVe.Focus();
                return false;
            }
            if (txtSoCuonMuonTaiCho.Text.Length == 0)
            {
                strError = "Nh��p s�� cu��n m���n ta�i ch��";
                txtSoCuonMuonTaiCho.Focus();
                return false;
            }
            if (txtSoCuonMuonGVBC.Text.Length == 0)
            {
                strError = "Nh��p s�� cu��n m���n cu�a GVBC";
                txtSoCuonMuonGVBC.Focus();
                return false;
            }
            if (txtSoNgayThanhLyBao.Text.Length == 0)
            {
                strError = "Nh��p s�� nga�y cho phe�p m���n ba�o";
                txtSoNgayThanhLyBao.Focus();
                return false;
            }
            if (txtSoNgayThanhLyTapchi.Text.Length == 0)
            {
                strError = "Nh��p s�� nga�y cho phe�p m���n ta�p chi�";
                txtSoNgayThanhLyTapchi.Focus();
                return false;
            }
            return true;
        }
    }
}