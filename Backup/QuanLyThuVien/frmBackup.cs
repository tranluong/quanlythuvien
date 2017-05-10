using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strDate = DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString();
            saveFileDialog1.FileName = txtDatabaseName.Text.Trim() + strDate + ".bak";
            saveFileDialog1.Filter = "Backup files (*.bak)|*.bak";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = saveFileDialog1.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDatabaseName.Text.Trim().Length != 0 && txtPath.Text.Trim().Length!=0)
            {
                this.Cursor = Cursors.WaitCursor;
                HeThongService cls = new HeThongService();
                if(cls.Backup(txtDatabaseName.Text.Trim(),txtPath.Text.Trim()))
                {
                    MessageBox.Show("Sao lưu dữ liệu thành công",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {                    
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.Default;
            }
        }
    }
}