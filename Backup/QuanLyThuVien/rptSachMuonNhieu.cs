using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class rptSachMuonNhieu : Form
    {
        public rptSachMuonNhieu()
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
            DateTime dtTu = dtBegin.Value;
            DateTime dtDen = dtEnd.Value;
            int intTop = Convert.ToInt32(txtTop.Value);
            string strHTML = rs.SachMuonNhieu(intTop, dtTu, dtDen);
            webBrowser1.DocumentText = strHTML;
            if (rs.Error != "")
                MessageBox.Show(rs.Error);
        }
    }
}