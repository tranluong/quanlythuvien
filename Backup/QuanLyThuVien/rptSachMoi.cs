using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class rptSachMoi : Form
    {
        public rptSachMoi()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
                webBrowser1.Print();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ReportService rs = new ReportService();
            int intYear = Convert.ToInt32(txtYear.Value);
            string strHTML = rs.SachMoi(intYear);
            webBrowser1.DocumentText = strHTML;
            if (rs.Error != "")
                MessageBox.Show(rs.Error);
        }

        private void rptSachMoi_Load(object sender, EventArgs e)
        {
            txtYear.Value = DateTime.Today.Year;
            ReportService rs = new ReportService();
            int intYear = DateTime.Today.Year;
            string strHTML = rs.SachMoi(intYear);
            webBrowser1.DocumentText = strHTML;
            if (rs.Error != "")
                MessageBox.Show(rs.Error);
        }
    }
}