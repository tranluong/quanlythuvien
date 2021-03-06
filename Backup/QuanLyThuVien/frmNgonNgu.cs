using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmNgonNgu : Form
    {
        public frmNgonNgu()
        {
            InitializeComponent();
        }

        private void frmNgonNgu_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            LanguageService cls = new LanguageService();            
            dataGridView1.DataSource = cls.ShowAllLang();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
//Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {            
            txtLangName.Text = txtLangName.Text;
            if (txtLangName.Text.Trim().Length == 0)
            {
                //MessageBox.Show(MessageLanguage.IsEmpty, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Nhập tên ngôn ngữ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Language clsLang = new Language();
                LanguageService clsLangService = new LanguageService();
                clsLang.LangName = txtLangName.Text.Trim();
                if (clsLangService.CreateLang(clsLang))
                {                    
                    dataGridView1.DataSource = clsLangService.ShowAllLang();
                    if (clsLangService.Error != "")
                        MessageBox.Show(clsLangService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
                else
                {
                    MessageBox.Show(clsLangService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            txtLangName.Focus();
            txtLangName.SelectAll();
        }        
//Tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            //if (txtKeyword.Text.Trim().Length != 0)
            //{            
                int intType = cboFilter.SelectedIndex;
                LanguageService cls = new LanguageService();
                dataGridView1.DataSource = cls.SearchLang(txtKeyword.Text.Trim(), intType);
                if (cls.Error != "")
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    txtKeyword.Focus();
                    txtKeyword.SelectAll();
                }
            //}           
        }        
//Fill
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;            
            if (vr == null)
            {
                btnXoa.Enabled = false;
                btnCapnhat.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
                btnCapnhat.Enabled = true;
                txtLangName.Text = Convert.ToString(vr.Cells[1].Value);
            }
        }
//Cập nhật
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                txtLangName.Text = txtLangName.Text;
                if (txtLangName.Text.Trim().Length == 0)
                {
                    MessageBox.Show(MessageLanguage.IsEmpty, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {                    
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtLangName.Text.Trim().Equals(vr.Cells[1].Value.ToString()))
                    {
                        Language clsLang = new Language();
                        clsLang.LangName = txtLangName.Text.Trim();
                        clsLang.LangID = Convert.ToInt16(vr.Cells[0].Value);                        
                        LanguageService clsLangService = new LanguageService();
                        if (clsLangService.UpdateLang(clsLang))
                        {
                            dataGridView1.DataSource = clsLangService.ShowAllLang();
                            if (clsLangService.Error != "")
                                MessageBox.Show(clsLangService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsLangService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtLangName.Focus();
                txtLangName.SelectAll();
            }
            catch
            {
                MessageBox.Show(Message.ExceptionError,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }        
//Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {            
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                int intLangID = Convert.ToInt16(vr.Cells[0].Value);
                string strLangName = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa ngôn ngữ: " + strLangName + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Language clsLang = new Language();
                    clsLang.LangID = intLangID;
                    LanguageService clsLangService = new LanguageService();
                    if (clsLangService.DeleteLang(clsLang))
                    {                        
                        dataGridView1.DataSource = clsLangService.ShowAllLang();
                        if (clsLangService.Error != "")
                            MessageBox.Show(clsLangService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsLangService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
//Hiển thị kết quả số mẫu tin ở status
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }
    }
}