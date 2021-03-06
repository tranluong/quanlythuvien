using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmNhaXB : Form
    {
        public frmNhaXB()
        {
            InitializeComponent();
        }

        private void frmNhaXB_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            AcceptButton = btnTim;
            CancelButton = btnDong;
            NhaXBService cls = new NhaXBService();
            dataGridView1.DataSource = cls.ShowAllNhaXB();
            if (cls.Error != "")
                MessageBox.Show(cls.Error);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int intRowCount = dataGridView1.RowCount;
            lblRecordCount.Text = "Kết quả có " + intRowCount + " mẫu tin";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow vr = dataGridView1.CurrentRow;
                int intMaNXB = Convert.ToInt16(vr.Cells[0].Value);
                string strTenNXB = Convert.ToString(vr.Cells[1].Value);
                if (MessageBox.Show("Xóa nhà xuất bản: " + strTenNXB + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhaXB clsNXB = new NhaXB();
                    clsNXB.MaNXB = intMaNXB;
                    NhaXBService clsNhaXBService = new NhaXBService();
                    if (clsNhaXBService.DeleteNhaXB(clsNXB))
                    {

                        dataGridView1.DataSource = clsNhaXBService.ShowAllNhaXB();
                        if (clsNhaXBService.Error != "")
                            MessageBox.Show(clsNhaXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            dataGridView1.Focus();
                    }
                    else
                        MessageBox.Show(clsNhaXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenNXB.Text = txtTenNXB.Text;
                if (txtTenNXB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập tên nhà xuất bản", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataGridViewRow vr = dataGridView1.CurrentRow;
                    if (!txtTenNXB.Text.Trim().Equals(vr.Cells[1].Value.ToString()))
                    {
                        NhaXB clsNXB = new NhaXB();
                        clsNXB.TenNXB = txtTenNXB.Text.Trim();
                        clsNXB.MaNXB = Convert.ToInt16(vr.Cells[0].Value);
                        NhaXBService clsNXBService = new NhaXBService();
                        if (clsNXBService.UpdateNhaXB(clsNXB))
                        {
                            dataGridView1.DataSource = clsNXBService.ShowAllNhaXB();
                            if (clsNXBService.Error != "")
                                MessageBox.Show(clsNXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(clsNXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtTenNXB.Focus();
                txtTenNXB.SelectAll();
            }
            catch
            {
                MessageBox.Show(Message.ExceptionError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenNXB.Text = txtTenNXB.Text;
            if (txtTenNXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nhập tên nhà xuất bản", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NhaXB clsNXB = new NhaXB();
                NhaXBService clsNhaXBService = new NhaXBService();
                clsNXB.TenNXB = txtTenNXB.Text.Trim();
                if (clsNhaXBService.CreateNhaXB(clsNXB))
                {
                    dataGridView1.DataSource = clsNhaXBService.ShowAllNhaXB();
                    if (clsNhaXBService.Error != "")
                        MessageBox.Show(clsNhaXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(clsNhaXBService.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTenNXB.Focus();
            txtTenNXB.SelectAll();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int intType = cboFilter.SelectedIndex;
            NhaXBService cls = new NhaXBService();
            dataGridView1.DataSource = cls.SearchNhaXB(txtKeyword.Text.Trim(), intType);
            if (cls.Error != "")
                MessageBox.Show(cls.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
        }

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
                txtTenNXB.Text = Convert.ToString(vr.Cells[1].Value);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void cutStripMenuItem_Click(object sender, EventArgs e)
        {
            //Copy to clipboard
            CopyToClipboard();

            //Clear selected cells
            foreach (DataGridViewCell dgvCell in dataGridView1.SelectedCells)
                dgvCell.Value = string.Empty;
        }

        private void CopyStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void PasteStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteClipboardValue();
        }
        private void CopyToClipboard()
        {
            //Copy to clipboard
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void PasteClipboardValue()
        {
            //Show Error if no cell is selected
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a cell", "Paste",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Get the starting Cell
            DataGridViewCell startCell = GetStartCell(dataGridView1);
            //Get the clipboard value in a dictionary
            Dictionary<int, Dictionary<int, string>> cbValue =
                    ClipBoardValues(Clipboard.GetText());

            int iRowIndex = startCell.RowIndex;
            foreach (int rowKey in cbValue.Keys)
            {
                int iColIndex = startCell.ColumnIndex;
                foreach (int cellKey in cbValue[rowKey].Keys)
                {
                    //Check if the index is within the limit
                    if (iColIndex <= dataGridView1.Columns.Count - 1
                    && iRowIndex <= dataGridView1.Rows.Count - 1)
                    {
                        DataGridViewCell cell = dataGridView1[iColIndex, iRowIndex];

                        //Copy to selected cells if 'chkPasteToSelectedCells' is checked
                        if ((chkPasteToSelectedCells.Checked && cell.Selected) ||
                            (!chkPasteToSelectedCells.Checked))
                            cell.Value = cbValue[rowKey][cellKey];
                    }
                    iColIndex++;
                }
                iRowIndex++;
            }
        }

        private DataGridViewCell GetStartCell(DataGridView dgView)
        {
            //get the smallest row,column index
            if (dgView.SelectedCells.Count == 0)
                return null;

            int rowIndex = dgView.Rows.Count - 1;
            int colIndex = dgView.Columns.Count - 1;

            foreach (DataGridViewCell dgvCell in dgView.SelectedCells)
            {
                if (dgvCell.RowIndex < rowIndex)
                    rowIndex = dgvCell.RowIndex;
                if (dgvCell.ColumnIndex < colIndex)
                    colIndex = dgvCell.ColumnIndex;
            }

            return dgView[colIndex, rowIndex];
        }

        private Dictionary<int, Dictionary<int, string>> ClipBoardValues(string clipboardValue)
        {
            Dictionary<int, Dictionary<int, string>>
            copyValues = new Dictionary<int, Dictionary<int, string>>();

            String[] lines = clipboardValue.Split('\n');

            for (int i = 0; i <= lines.Length - 1; i++)
            {
                copyValues[i] = new Dictionary<int, string>();
                String[] lineContent = lines[i].Split('\t');

                //if an empty cell value copied, then set the dictionary with an empty string
                //else Set value to dictionary
                if (lineContent.Length == 0)
                    copyValues[i][0] = string.Empty;
                else
                {
                    for (int j = 0; j <= lineContent.Length - 1; j++)
                        copyValues[i][j] = lineContent[j];
                }
            }
            return copyValues;
        }
    }
}