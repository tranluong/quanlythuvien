using QuanLyThuVien.Entities;
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
    public partial class frmThongKeDocGiaHetHan : Form
    {
        public frmThongKeDocGiaHetHan()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            KetNoi cnt = new KetNoi();
            string sql = "select * from tblDocGia where ThoiGianKetThuc <  convert(datetime,'" + DateTime.Today + "')";
            dt = cnt.getDataTable(sql);
            DocGiaHetHan cr = new DocGiaHetHan();
            cr.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
