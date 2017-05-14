﻿using QuanLyThuVien.Entities;
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
    public partial class InPhieuNhap : Form
    {
        public InPhieuNhap()
        {
            InitializeComponent();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.Date;
            dateTimePicker2.Value = dateTimePicker2.Value.Date;
        }

        private void InPhieuMuon_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            KetNoi cnt = new KetNoi();
            string sql = "select CTPN.MaPN,S.TenSach, CTPN.SoLuong, CTPN.DonGia, CTPN.ThanhTien from tblPhieuNhap PN,tblChiTietPhieuNhap CTPN, tblSach S where  PN.MaPN = CTPN.MaPN and CTPN.MaSach = S.MaSach and PN.NgayNhap between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
            dt = cnt.getDataTable(sql);
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}