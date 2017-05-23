using QuanLyThuVien.Data;
using QuanLyThuVien.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Business
{
    class DauSachService
    {
        //Thêm thủ thư
        public void ThemDauSach(int maSach, string tenDauSach)
        {
            DauSachDAO dsDAO = new DauSachDAO();
            dsDAO.ThemDauSach(maSach, tenDauSach);
        }

    }
}
