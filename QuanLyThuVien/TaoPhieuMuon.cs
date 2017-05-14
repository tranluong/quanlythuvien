using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QuanLyThuVien;
using QuanLyThuVien.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static QuanLyThuVien.Entities.GetCode;

namespace QuanLyThuVien
{
    public partial class TaoPhieuMuon : Form
    {
        public TaoPhieuMuon()
        {
            InitializeComponent();
        }
        thuvienDataSet ds = new thuvienDataSet();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //ketnoi cnt = new ketnoi();
            //string sql = "select MaDG,TenDG,DiaChi from tblDocGia ";
            //dt = cnt.getDataTable(sql);
            //CrystalReport1 cr = new CrystalReport1();
            //cr.SetDataSource(dt);
            //crystalReportViewer1.ReportSource = cr;
        }

        private void TaoPhieuMuon_Load(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=FIRE;Initial Catalog=thuvien;Integrated Security=True";
            //string sql = "SELECT MaDG,TenDG,DiaChi FROM tblDocGia ";
            //SqlConnection connection = new SqlConnection(connectionString);
            //SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            //connection.Open();
            //dataadapter.Fill(ds, "tblDocGia_table");
            //connection.Close();

            //dataGridView1.DataSource = ds.tblDocGia;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(@"Data Source=FIRE;Initial Catalog=thuvien;Integrated Security=True");
           sc.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select * from tblDocGia where MaDG = '"+txtMaDG.Text+"'", sc);
            thuvienDataSet ds = new thuvienDataSet();
            sd.Fill(ds, "tblDocGia");
            dataGridView1.DataSource = ds.tblDocGia;

            sc.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //QuanLyThuVien.Entities.GetCode.GetCodeHD._mahd = txtMaDG.Text;
            InPhieuNhap frmHD = new InPhieuNhap();
            frmHD.ShowDialog();
        }
    }
}
