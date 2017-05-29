using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QuanLyThuVien
{
    class Book
    {
        private int intMaTS;
        private string strTenTS;
        private string strTSMaHoa;
        private string strKiHieuPL;
        private int intMaNganh;
        private int intMaNgonNgu;
        private int intMaNXB;
        private int intMaKho;
        private string strNamXB;        
        private int intGiaBia;
        private string strSoTrang;
        private string strKichThuoc;
        private string strDEWEY;
        private string strTomTat;
        private string strChuDe;
        private byte bytLanTB;
        private string strTuaSongSong;
        private string strTungThu = "";

        public int MaTS
        {
            get { return intMaTS; }
            set { intMaTS = value; }
        }

        public string TenTS
        {
            get { return strTenTS; }
            set { strTenTS = value; }
        }

        public string TSMaHoa
        {
            get { return strTSMaHoa; }
            set { strTSMaHoa = value; }
        }

        public string KiHieuPL
        {
            get { return strKiHieuPL; }
            set { strKiHieuPL = value; }
        }

        public int MaNganh
        {
            get { return intMaNganh; }
            set { intMaNganh = value; }
        }

        public int MaNgonNgu
        {
            get { return intMaNgonNgu; }
            set { intMaNgonNgu = value; }
        }

        public int MaNXB
        {
            get { return intMaNXB; }
            set { intMaNXB = value; }
        }

        public string NamXB
        {
            get { return strNamXB; }
            set { strNamXB = value; }
        }

        public int MaKho
        {
            get { return intMaKho; }
            set { intMaKho = value; }
        }

        public int GiaBia
        {
            get { return intGiaBia; }
            set { intGiaBia = value; }
        }

        public string SoTrang
        {
            get { return strSoTrang; }
            set { strSoTrang = value; }
        }

        public string KichThuoc
        {
            get { return strKichThuoc; }
            set { strKichThuoc = value; }
        }

        public string DEWEY
        {
            get { return strDEWEY; }
            set { strDEWEY = value; }
        }

        public string TomTat
        {
            get { return strTomTat; }
            set { strTomTat = value; }
        }

        public string ChuDe
        {
            get { return strChuDe; }
            set { strChuDe = value; }
        }

        public byte LanTB
        {
            get { return bytLanTB; }
            set { bytLanTB = value; }
        }

        public string TuaSongSong
        {
            get { return strTuaSongSong; }
            set { strTuaSongSong = value; }
        }

        public string TungThu
        {
            get { return strTungThu; }
            set { strTungThu = value; }
        }

        private int intSoDKCBTu;
        public int SoDKCBTu
        {
            get { return intSoDKCBTu; }
            set { intSoDKCBTu = value; }
        }

        private int intSoDKCBDen;
        public int SoDKCBDen
        {
            get { return intSoDKCBDen; }
            set { intSoDKCBDen = value; }
        }

        private byte bytTinhTrang = 0;
        public byte TinhTrang
        {
            get { return bytTinhTrang; }
            set { bytTinhTrang = value; }
        }

        private int intMaTap = 0;
        public int MaTap
        {
            get { return intMaTap; }
            set { intMaTap = value; }
        }
        private string strTenTap = "";
        public string TenTap
        {
            get { return strTenTap; }
            set { strTenTap = value; }
        }

        private DateTime dtNgayCapNhat;
        public DateTime NgayCapNhat
        {
            get { return dtNgayCapNhat; }
            set { dtNgayCapNhat = value; }
        }

        private int intNguoiCapNhat;
        public int NguoiCapNhat
        {
            get { return intNguoiCapNhat; }
            set { intNguoiCapNhat = value; }
        }

        private int[,] intTacGia = new int[10,2];
        public int[,] TacGia
        {
            get { return intTacGia; }
            set { intTacGia = value; }
        }

        private string[,] strTap = new string[10, 2];
        public string[,] Tap
        {
            get { return strTap; }
            set { strTap = value; }
        }

        private int intRows;
        public int Rows
        {
            get { return intRows; }
            set { intRows = value; }
        }

        private int intTongDauSach = 0;
        public int TongDauSach
        {
            get { return intTongDauSach; }
            set { intTongDauSach = value; }
        }

        private int intSLMat = 0;
        public int SLMat
        {
            get { return intSLMat; }
            set { intSLMat = value; }
        }

        private int intSLHong = 0;
        public int SLHong
        {
            get { return intSLHong; }
            set { intSLHong = value; }
        }

        private int intSLMuon = 0;
        public int SLMuon
        {
            get { return intSLMuon; }
            set { intSLMuon = value; }
        }

        private int intSLCon = 0;
        public int SLCon
        {
            get { return intSLCon; }
            set { intSLCon = value; }
        }
        //Thống kê sách tập
        private int intTongDauSachTap = 0;
        public int TongDauSachTap
        {
            get { return intTongDauSachTap; }
            set { intTongDauSachTap = value; }
        }

        private int intSLMatTap = 0;
        public int SLMatTap
        {
            get { return intSLMatTap; }
            set { intSLMatTap = value; }
        }

        private int intSLHongTap = 0;
        public int SLHongTap
        {
            get { return intSLHongTap; }
            set { intSLHongTap = value; }
        }

        private int intSLMuonTap = 0;
        public int SLMuonTap
        {
            get { return intSLMuonTap; }
            set { intSLMuonTap = value; }
        }

        private int intSLConTap = 0;
        public int SLConTap
        {
            get { return intSLConTap; }
            set { intSLConTap = value; }
        }

        private DataTable dtTacGia;
        public DataTable TacGiaTap
        {
            get { return dtTacGia; }
            set { dtTacGia = value; }
        }

        private int dtTap;
        public int TapSo
        {
            get { return dtTap; }
            set { dtTap = value; }
        }

        private string strGhiChu="";
        public string GhiChu
        {
            get { return strGhiChu; }
            set { strGhiChu = value; }
        }  
    }
}
