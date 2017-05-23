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
    public partial class frmThongKeSach : Form
    {
        public frmThongKeSach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookDAO abc = new BookDAO();
            DataTable dt = new DataTable();
            //KetNoi cnt = new KetNoi();
            if (Convert.ToInt16(comboBox1.SelectedIndex) == 0)
            {
                //KetNoi cnt = new KetNoi();
                dt = abc.ShowSachMat();
                //dt = cnt.getDataTable(sql);
                SachMat cr = new SachMat();
                cr.SetDataSource(dt);
                crystalReportViewer1.ReportSource = cr;
            }
            else
            {
                if (Convert.ToInt16(comboBox1.SelectedIndex) == 1)
                {
                    dt = abc.ShowSachHong();
                    //dt = cnt.getDataTable(sql);
                    SachHong crr = new SachHong();
                    crr.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = crr;
                }
                else
                {
                    if (Convert.ToInt16(comboBox1.SelectedIndex) == 2)
                    {
                        dt = abc.ShowSachMuon();
                        //dt = cnt.getDataTable(sql);
                        SachMuon c = new SachMuon();
                        c.SetDataSource(dt);
                        crystalReportViewer1.ReportSource = c;
                    }
                    else
                    {
                        if (Convert.ToInt16(comboBox1.SelectedIndex) == 3)
                        {
                            dt = abc.ShowSachCu();
                            //dt = cnt.getDataTable(sql);
                            SachCu cc = new SachCu();
                            cc.SetDataSource(dt);
                            crystalReportViewer1.ReportSource = cc;
                        }
                        else
                        {
                            if (Convert.ToInt16(comboBox1.SelectedIndex) == 4)
                            {
                                dt = abc.ShowSachTra();
                                //dt = cnt.getDataTable(sql);
                                SachTra ccq = new SachTra();
                                ccq.SetDataSource(dt);
                                crystalReportViewer1.ReportSource = ccq;
                            }else
                            {
                                dt = abc.ShowSachMuonTreHan();
                                //dt = cnt.getDataTable(sql);
                                SachMuonTreHan ccqq = new SachMuonTreHan();
                                ccqq.SetDataSource(dt);
                                crystalReportViewer1.ReportSource = ccqq;
                            }
                        }
                    }

                }
            }
        }
        //else
        //{
        //    dt = abc.ShowSachMuon();
        //    //dt = cnt.getDataTable(sql);
        //    SachMuon cr = new SachHong();
        //    cr.SetDataSource(dt);
        //    crystalReportViewer1.ReportSource = cr;
        //}
    }
}
