using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class ThongKeSachTheoLoai : Form
    {
        public ThongKeSachTheoLoai()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            BookDAO abc = new BookDAO();
            DataTable dt = new DataTable();
            //KetNoi cnt = new KetNoi();
            dt = abc.ShowSLSachTHEOLOAI();
            //dt = cnt.getDataTable(sql);
            SLSACHTHEOLOAI cr = new SLSACHTHEOLOAI();
            cr.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
