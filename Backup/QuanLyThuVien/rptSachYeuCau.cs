using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class rptSachYeuCau : Form
    {
        public rptSachYeuCau()
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

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tất cả sách yêu cầu ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SachYeuCauService cls = new SachYeuCauService();
                if (cls.DeleteAll())
                {
                    MessageBox.Show("Xóa tất cả sách yêu cầu thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ReportService rs = new ReportService();
            DateTime dtTu = dtBegin.Value;
            DateTime dtDen = dtEnd.Value;
            string strHTML = rs.SachYeuCau(dtTu, dtDen);
            webBrowser1.DocumentText = strHTML;
            if (rs.Error != "")
                MessageBox.Show(rs.Error);
        }

        private void rptSachYeuCau_Load(object sender, EventArgs e)
        {
            ReportService rs = new ReportService();
            DateTime dtTu = Convert.ToDateTime("01/01/1990");
            DateTime dtDen = DateTime.Today;
            string strHTML = rs.SachYeuCau(dtTu, dtDen);
            webBrowser1.DocumentText = strHTML;
            if (rs.Error != "")
                MessageBox.Show(rs.Error);
        }
    }
}