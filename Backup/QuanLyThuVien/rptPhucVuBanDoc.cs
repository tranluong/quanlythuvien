using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class rptPhucVuBanDoc : Form
    {
        public rptPhucVuBanDoc()
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
            DateTime dtTu = Convert.ToDateTime(dtBegin.Value.ToShortDateString());
            DateTime dtDen = Convert.ToDateTime(dtEnd.Value.ToShortDateString());            
            int intSoNgay = KiemTra.SoNgay(dtDen, dtTu);
            string strHTML = rs.PhucVuBanDoc(intSoNgay, dtTu, dtDen);
            webBrowser1.DocumentText = strHTML;
            if (rs.Error != "")
                MessageBox.Show(rs.Error);
        }
    }
}