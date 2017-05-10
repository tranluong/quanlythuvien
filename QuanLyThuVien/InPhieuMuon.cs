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
//using static QuanLyThuVien.Entities.GetCode;

namespace QuanLyThuVien
{
    public partial class InPhieuMuon : Form
    {
        public InPhieuMuon()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            KetNoi cnt = new KetNoi();
            string sql = "select * from tblDocGia DG where DG.MaDG='" + QuanLyThuVien.Entities.GetCode.GetCodeHD._mahd + "'";
            dt = cnt.getDataTable(sql);
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
