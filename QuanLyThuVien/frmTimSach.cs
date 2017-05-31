using QuanLyThuVien.Data;
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
    public partial class frmTimSach : Form
    {
        public frmTimSach()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DauSachDAO dsDAO = new DauSachDAO();
            DataTable dt = new DataTable();

            if (rdangmuon.Checked)
            {
                dt = dsDAO.getDauSachTheoTinhTrangMuonTra(0);
            }
            else if (rdDaTra.Checked)
            {
                dt = dsDAO.getDauSachTheoTinhTrangMuonTra(1);
            }
            else if (rdTraTre.Checked)
            {
                dt = dsDAO.getDauSachTheoTinhTrangMuonTra(2);
            }

            gvTrangThaiTra.DataSource = dt;
            gvTrangThaiTra.AllowUserToAddRows = false;

        }

        private void frmTimSach_Load(object sender, EventArgs e)
        {
            rdangmuon.Checked = true;
        }

    }
}
