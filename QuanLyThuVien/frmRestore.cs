using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmRestore : Form
    {
        public frmRestore()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "*.bak";
            openFileDialog1.Filter = "Backup files (*.bak)|*.bak";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDatabaseName.Text.Trim().Length != 0 && txtPath.Text.Trim().Length != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                HeThongService cls = new HeThongService();
                if (cls.Restore(txtDatabaseName.Text.Trim(), txtPath.Text.Trim()))
                {
                    MessageBox.Show("Phục hồi dữ liệu thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}