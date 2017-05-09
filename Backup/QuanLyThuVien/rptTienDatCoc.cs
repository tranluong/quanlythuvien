using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class rptTienDatCoc : Form
    {
        public rptTienDatCoc()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Download source code mien phi tai Sharecode.vn
        private void btnIn_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
                webBrowser1.Print();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text.Trim().Length != 0)
            {
                ReportService rs = new ReportService();                
                string strHTML = rs.TienDatCoc(0, txtKeyword.Text.Trim());
                webBrowser1.DocumentText = strHTML;
                if (rs.Error != "")
                    MessageBox.Show(rs.Error);
            }
        }

        private void rptTienDatCoc_Load(object sender, EventArgs e)
        {
            //cboTheo.SelectedIndex = 0;
            txtKeyword.Focus();
        }
    }
}