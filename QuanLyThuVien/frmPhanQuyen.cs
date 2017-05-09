using QuanLyThuVien.Business;
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
    public partial class frmPhanQuyen : Form
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        private void btnUnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }


        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow vr = dataGridView1.CurrentRow;
            if (vr == null)
            {
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = true;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.Text = Convert.ToString(vr.Cells[i].Value);
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhanQuyen clsPhanQuyen = new PhanQuyen();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                clsPhanQuyen.PhanQuyen1[i] = Convert.ToByte(checkedListBox1.GetItemCheckState(i) == CheckState.Checked ? 1 : 0);
            }
            PhanQuyenService clsManagerService = new PhanQuyenService();
            if (clsManagerService.CreatePhanQuyen(clsPhanQuyen))
            {
                dataGridView1.DataSource = clsManagerService.ShowAllQuyen();
                if (clsManagerService.Error != "")
                    MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(clsManagerService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            CancelButton = btnDong;
            PhanQuyenService cls = new PhanQuyenService();
            dataGridView1.DataSource = cls.ShowAllQuyen();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                int intMaPQ = Convert.ToInt16(vr.Cells[0].Value);
                //string strTenPQ = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa phân quyền: " + intMaPQ + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PhanQuyen clsLDG = new PhanQuyen();
                    clsLDG.MaPQ = intMaPQ;
                    PhanQuyenService clsLDGService = new PhanQuyenService();
                    if (clsLDGService.DeletePhanQuyen(clsLDG))
                    {

                        dataGridView1.DataSource = clsLDGService.ShowAllQuyen();
                        if (clsLDGService.Error != "")
                        {
                            MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                PhanQuyen clsLDG = new PhanQuyen();
                clsLDG.MaPQ = Convert.ToInt16(vr.Cells[0].Value);
                clsLDG.PhanQuyen1[0] = Convert.ToByte(vr.Cells[1].Value);
                clsLDG.PhanQuyen1[1] = Convert.ToByte(vr.Cells[2].Value);
                clsLDG.PhanQuyen1[2] = Convert.ToByte(vr.Cells[3].Value);
                clsLDG.PhanQuyen1[3] = Convert.ToByte(vr.Cells[4].Value);
                clsLDG.PhanQuyen1[4] = Convert.ToByte(vr.Cells[5].Value);
                clsLDG.PhanQuyen1[5] = Convert.ToByte(vr.Cells[6].Value);
                clsLDG.PhanQuyen1[6] = Convert.ToByte(vr.Cells[7].Value);
                clsLDG.PhanQuyen1[7] = Convert.ToByte(vr.Cells[8].Value);
                PhanQuyenService clsLDGService = new PhanQuyenService();
                if (clsLDGService.UpdatePhanQuyen(clsLDG))
                {
                    dataGridView1.DataSource = clsLDGService.ShowAllQuyen();
                    if (clsLDGService.Error != "")
                        MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsLDGService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show(Message.ExceptionError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Để cái này cho tui, đừng xóa
            //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    phanquyen.PhanQuyen1[0] = Convert.ToByte(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    phanquyen.PhanQuyen1[1] = Convert.ToByte(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            //    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //}
        }
    }
}
