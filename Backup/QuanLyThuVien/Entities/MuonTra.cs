using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class MuonTra
    {
        private int intMaPM;
        public int MaPM
        {
            get { return intMaPM; }
            set { intMaPM = value; }
        }              

        private DateTime datNgayTra;
        public DateTime NgayTra
        {
            get { return datNgayTra; }
            set { datNgayTra = value; }
        }

        private string strGhiChu;
        public string GhiChu
        {
            get { return strGhiChu; }
            set { strGhiChu = value; }
        }

        private int intNguoiCapNhatTra;
        public int NguoiCapNhatTra
        {
            get { return intNguoiCapNhatTra; }
            set { intNguoiCapNhatTra = value; }
        }       

        private DateTime datNgayMuon;
        public DateTime NgayMuon
        {
            get { return datNgayMuon; }
            set { datNgayMuon = value; }
        }

        private int intSoNgayMuon;
        public int SoNgayMuon
        {
            get { return intSoNgayMuon; }
            set { intSoNgayMuon = value; }
        }

        private byte bytLoaiPM = 0;
        public byte LoaiPM
        {
            get { return bytLoaiPM; }
            set { bytLoaiPM = value; }
        }

        private int intNguoiCapNhatMuon;
        public int NguoiCapNhatMuon
        {
            get { return intNguoiCapNhatMuon; }
            set { intNguoiCapNhatMuon = value; }
        }        
        //Thông tin ðôòc giaÒ
        private string strMaDG = "";
        public string MaDG
        {
            get { return strMaDG; }
            set { strMaDG = value; }
        }

        private string strLoaiDG = "";
        public string LoaiDG
        {
            get { return strLoaiDG; }
            set { strLoaiDG = value; }
        }

        private string strTenDG = "";
        public string TenDG
        {
            get { return strTenDG; }
            set { strTenDG = value; }
        }

        private int intTienDatCoc = 0;
        public int TienDatCoc
        {
            get { return intTienDatCoc; }
            set { intTienDatCoc = value; }
        }

        private int intTienConLaiVe = 0;
        public int TienConLaiVe
        {
            get { return intTienConLaiVe; }
            set { intTienConLaiVe = value; }
        }

        private int intTienConLaiTaiCho = 0;
        public int TienConLaiTaiCho
        {
            get { return intTienConLaiTaiCho; }
            set { intTienConLaiTaiCho = value; }
        }

        private int intSoCuonMuonVe = 0;
        public int SoCuonMuonVe
        {
            get { return intSoCuonMuonVe; }
            set { intSoCuonMuonVe = value; }
        }

        private int intSoCuonMuonTaiCho = 0;
        public int SoCuonMuonTaiCho
        {
            get { return intSoCuonMuonTaiCho; }
            set { intSoCuonMuonTaiCho = value; }
        }
        //Thông tin saìch
        private int intSoDKCB;
        public int SoDKCB
        {
            get { return intSoDKCB; }
            set { intSoDKCB = value; }
        }

        private string strTenTS = "";
        public string TenTS
        {
            get { return strTenTS; }
            set { strTenTS = value; }
        }

        private string strKho = "";
        public string Kho
        {
            get { return strKho; }
            set { strKho = value; }
        }

        private string strTacGia = "";
        public string TacGia
        {
            get { return strTacGia; }
            set { strTacGia = value; }
        }

        private int intGiaBia= 0;
        public int GiaBia
        {
            get { return intGiaBia; }
            set { intGiaBia = value; }
        }

        private int intSoLuongCon = 0;
        public int SoLuongCon
        {
            get { return intSoLuongCon; }
            set { intSoLuongCon = value; }
        }

        private byte bytTinhTrang = 0;
        public byte TinhTrang
        {
            get { return bytTinhTrang; }
            set { bytTinhTrang = value; }
        }
        //Thông tin baìo taòp chiì
        private int intMaTenBTC;
        public int MaTenBTC
        {
            get { return intMaTenBTC; }
            set { intMaTenBTC = value; }
        }

        private string strTenBaoTC = "";
        public string TenBaoTC
        {
            get { return strTenBaoTC; }
            set { strTenBaoTC = value; }
        }

        private string strSoPH = "";
        public string SoPH
        {
            get { return strSoPH; }
            set { strSoPH = value; }
        }

        private DateTime dtNgayPH;
        public DateTime NgayPH
        {
            get { return dtNgayPH; }
            set { dtNgayPH = value; }
        }

        private int intSoLuongNhap;
        public int SoLuongNhap
        {
            get { return intSoLuongNhap; }
            set { intSoLuongNhap = value; }
        }
        private int intSoLuongConBTC = 0;
        public int SoLuongConBTC
        {
            get { return intSoLuongConBTC; }
            set { intSoLuongConBTC = value; }
        }
    }
}
