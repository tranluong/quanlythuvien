using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmTimTaiLieu : Form
    {
        public frmTimTaiLieu()
        {
            InitializeComponent();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            lblSearch.Text = "TÌM KIẾM SÁCH";
            AcceptButton = btnTimSach;
            CancelButton = btnDongSach;
            cboSach1.SelectedIndex = 0;
            cboFilter1.SelectedIndex = 0;
            /*cboDK1.SelectedIndex = 0;
            cboSach2.SelectedIndex = 2;
            cboFilter2.SelectedIndex = 0;
            cboDK2.SelectedIndex = 0;
            cboSach3.SelectedIndex = 3;
            cboFilter3.SelectedIndex = 0;*/
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            lblSearch.Text = "TÌM KIẾM BÁO TẠP CHÍ";
            AcceptButton = btnTimBTC;
            CancelButton = btnDongBTC;
            txtKeywordBTC1.Focus();
            cboBTC1.SelectedIndex = 0;
            cboFilterBTC1.SelectedIndex = 0;
            cboDKBTC1.SelectedIndex = 0;
            /*cboBTC2.SelectedIndex = 1;
            cboFilterBTC2.SelectedIndex = 0;
            cboDKBTC2.SelectedIndex = 0;
            cboBTC3.SelectedIndex = 2;
            cboFilterBTC3.SelectedIndex = 0;*/
        }

        private void chkSearchAd_CheckedChanged(object sender, EventArgs e)
        {
            /*if (chkSearchAd.Checked == true)
            {
                cboSach2.Visible = true;
                cboSach3.Visible = true;
                txtKeyword2.Visible = true;
                txtKeyword3.Visible = true;
                cboDK1.Visible = true;
                cboDK2.Visible = true;
                cboFilter2.Visible = true;
                cboFilter3.Visible = true;
            }
            else 
            {
                cboSach2.Visible = false;
                cboSach3.Visible = false;
                txtKeyword2.Visible = false;
                txtKeyword3.Visible = false;
                cboDK1.Visible = false;
                cboDK2.Visible = false;
                cboFilter2.Visible = false;
                cboFilter3.Visible = false;
            }*/
        }

        private void chkSearchBTC_CheckedChanged(object sender, EventArgs e)
        {
            /*if (chkSearchBTC.Checked == true)
            {
                cboBTC2.Visible = true;
                cboBTC3.Visible = true;
                txtKeywordBTC2.Visible = true;
                txtKeywordBTC3.Visible = true;
                cboDKBTC1.Visible = true;
                cboDKBTC2.Visible = true;
                cboFilterBTC2.Visible = true;
                cboFilterBTC3.Visible = true;
            }
            else
            {
                cboBTC2.Visible = false;
                cboBTC3.Visible = false;
                txtKeywordBTC2.Visible = false;
                txtKeywordBTC3.Visible = false;
                cboDKBTC1.Visible = false;
                cboDKBTC2.Visible = false;
                cboFilterBTC2.Visible = false;
                cboFilterBTC3.Visible = false;
            }*/
        }

        private void btnTimBTC_Click(object sender, EventArgs e)
        {
            SoBaoTCService cls = new SoBaoTCService();
            if (cboBTC1.SelectedIndex == 2)
                dataGridView1.DataSource = cls.SearchSBTC(cboBTC1.SelectedIndex, dtKeyword.Value.ToShortDateString(), cboFilterBTC1.SelectedIndex);
            else
            {
                dataGridView1.DataSource = cls.SearchSBTC(cboBTC1.SelectedIndex, txtKeywordBTC1.Text.Trim(), cboFilterBTC1.SelectedIndex);
                dataGridView1.Columns["BaoOrTapChi"].Visible = false;
                dataGridView1.Columns["MaTenBTC"].Visible = false;
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDongBTC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongSach_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            if (txtKeyword1.Text != "")
            {
                int intType = cboSach1.SelectedIndex;
                int intFilter = cboFilter1.SelectedIndex;
                BookService cls = new BookService();
                dataGridView9.DataSource = cls.FindBook(intType, txtKeyword1.Text.Trim(), intFilter);
                if (cls.Error != "")
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKeyword1.Focus();
                    txtKeyword1.SelectAll();
                }
                else
                    dataGridView9.Focus();
            }
        }

        //Fill form
        private void FillForm(DataGridViewRow vr)
        {
            try
            {
                //cboLoai.SelectedIndex = Convert.ToInt32(vr.Cells["BaoOrTapChi"].Value);
                txtTenBTC.Text = vr.Cells[0].Value.ToString();
                txtSoPH.Text = vr.Cells[1].Value.ToString();
                txtNgayPH.Text = Convert.ToDateTime(vr.Cells[2].Value).ToShortDateString();
                txtSLNhap.Text = vr.Cells[3].Value.ToString();
                MuonTraService cls = new MuonTraService();
                int intSLCon = cls.GetInfoNewspaper(Convert.ToInt32(vr.Cells["MaTenBTC"].Value), vr.Cells[1].Value.ToString()).SoLuongConBTC;
                txtSLCon.Text = intSLCon.ToString();
                txtSLMuon.Text = Convert.ToString(Convert.ToInt32(vr.Cells[3].Value) - intSLCon);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (vr != null)
            {                
                FillForm(vr);
            }
            else
            {
                txtKeywordBTC1.Focus();
                txtKeywordBTC1.SelectAll();
            }
        }

        private void cboBTC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBTC1.SelectedIndex == 2)
            {
                dtKeyword.Visible = true;
                txtKeywordBTC1.Visible = false;
            }
            else
            {
                dtKeyword.Visible = false;
                txtKeywordBTC1.Visible = true;
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCountBTC.Text = "Kết quả có " + dataGridView1.RowCount + " mẫu tin";
        }


        private void FillFormSach(DataGridViewRow vr)
        {
            try
            {

                txtSoMFN.Text = vr.Cells[0].Value.ToString();
                txtTuaSach.Text = vr.Cells[1].Value.ToString();
                NganhHocService cls1 = new NganhHocService();

                txtNganhHoc.Text = vr.Cells["TenNganh"].Value.ToString();
                txtNgonNgu.Text = vr.Cells["TenNgonNgu"].Value.ToString();
                txtNXB.Text = vr.Cells["TenNXB"].Value.ToString();
                txtNamXB.Text = vr.Cells["NamXB"].Value.ToString();
                txtKho.Text = vr.Cells["TenKho"].Value.ToString();
                txtGiaBia.Text = vr.Cells["GiaBia"].Value.ToString();
                txtSoTrang.Text = vr.Cells["SoTrang"].Value.ToString();                
                txtTomTat.Text = vr.Cells["TomTat"].Value.ToString();
                txtChuDe.Text = vr.Cells["ChuDe"].Value.ToString();
                int intMaTS = Convert.ToInt32(vr.Cells["MaTS"].Value);
                BookService cls = new BookService();
                dataGridView7.DataSource = cls.ShowAllChapter(intMaTS);
                Book clsBook = cls.Stat(intMaTS);
                txtTongSL.Text = clsBook.TongDauSach.ToString();
                txtSLHong.Text = clsBook.SLHong.ToString();
                txtSLMat.Text = clsBook.SLMat.ToString();
                txtSLSachMuon.Text = clsBook.SLMuon.ToString();
                txtSLSachCon.Text = clsBook.SLCon.ToString();
                DataTable dt = cls.ShowAuthor(intMaTS);
                if (dt.Rows.Count != 0)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].Visible = false;
                }
                ReportService clsR = new ReportService();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView9_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView9.CurrentRow;
            if (vr != null)
            {
                FillFormSach(vr);
            }
            else
            {
                txtKeywordBTC1.Focus();
                txtKeywordBTC1.SelectAll();
                dataGridView7.DataSource = null;
            }
        }
        public int intType;
        public int intFilter;
        public string strKeyword = "";
        private void frmTimTaiLieu_Load(object sender, EventArgs e)
        {
            txtKeyword1.Focus();
            if (strKeyword != "")
            {
                BookService cls = new BookService();
                dataGridView9.DataSource = cls.FindBook(intType, strKeyword, intFilter);
                if (cls.Error != "")
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKeyword1.Focus();
                    txtKeyword1.SelectAll();
                }
                else
                    dataGridView9.Focus();
            }
        }

        private void dataGridView9_DataSourceChanged(object sender, EventArgs e)
        {
            lblRowCountSach.Text = "Kết quả có " + dataGridView9.RowCount + " mẫu tin";
        }

        private void dataGridView7_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView7.CurrentRow;
            if (vr != null)
            {
                FillFormTap(vr);
            }
            else
            {
                txtKeywordBTC1.Focus();
                txtKeywordBTC1.SelectAll();
                txtTap.Text = "";
                txtTenTap.Text = "";
            }
        }
        //Fill form tập
        private void FillFormTap(DataGridViewRow vr)
        {
            try
            {                
                txtGiaBia.Text = vr.Cells["GiaBia"].Value.ToString();
                txtSoTrang.Text = vr.Cells["SoTrang"].Value.ToString();
                txtTap.Text = vr.Cells["TapSo"].Value.ToString();
                txtTenTap.Text = vr.Cells["TenTap"].Value.ToString();
                int intMaTap = Convert.ToInt32(vr.Cells["MaTap"].Value);
                BookService cls = new BookService();
                DataTable dt = cls.ShowAuthorChapter(intMaTap);
                dataGridView2.DataSource = dt;
                Book clsBook = cls.StatTap(intMaTap);
                txtTongSL.Text = clsBook.TongDauSachTap.ToString();
                txtSLHong.Text = clsBook.SLHongTap.ToString();
                txtSLMat.Text = clsBook.SLMatTap.ToString();
                txtSLSachMuon.Text = clsBook.SLMuonTap.ToString();
                txtSLSachCon.Text = clsBook.SLConTap.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView7_DataSourceChanged(object sender, EventArgs e)
        {
            groupBox14.Text = "(" + dataGridView7.RowCount.ToString() + " tập)";
        }
    }
}