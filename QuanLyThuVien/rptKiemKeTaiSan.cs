using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class rptKiemKeTaiSan : Form
    {
        public rptKiemKeTaiSan()
        {
            InitializeComponent();
        }


        private void rptKiemKeTaiSan_Load(object sender, EventArgs e)
        {
            ReportService rs = new ReportService();
            DateTime dtTu = Convert.ToDateTime("01/01/1990");
            DateTime dtDen = DateTime.Today;
            //string strHTML = rs.KiemKeTaiSan(dtTu, dtDen);
            //webBrowser1.DocumentText = strHTML;
            if (rs.Error != "")
                MessageBox.Show(rs.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ReportService rs = new ReportService();
            DateTime dtTu = dtBegin.Value;
            DateTime dtDen = dtEnd.Value;
            //string strHTML = rs.KiemKeTaiSan(dtTu, dtDen);
            //webBrowser1.DocumentText = strHTML;
            if (rs.Error != "")
                MessageBox.Show(rs.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
                webBrowser1.Print();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}