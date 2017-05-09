using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyThuVien
{
    class HeThong
    {
        private int intSoTienDatCoc = 0;
        private byte bytSoNgayMuonVe = 0;
        private int intSoTienPhatTreHanVe = 0;
        private int intSoTienPhatTreHanTaiCho = 0;
        private byte bytSoCuonMuonVe = 0;
        private byte bytSoCuonMuonTaiCho = 0;
        private byte bytSoCuonMuonGVBC = 0;

        public int SoTienDatCoc
        {
            get { return intSoTienDatCoc; }
            set { intSoTienDatCoc = value; }
        }

        public byte SoNgayMuonVe
        {
            get { return bytSoNgayMuonVe; }
            set { bytSoNgayMuonVe = value; }
        }

        public int SoTienPhatTreHanVe
        {
            get { return intSoTienPhatTreHanVe; }
            set { intSoTienPhatTreHanVe = value; }
        }

        public int SoTienPhatTreHanTaiCho
        {
            get { return intSoTienPhatTreHanTaiCho; }
            set { intSoTienPhatTreHanTaiCho = value; }
        }

        public byte SoCuonMuonVe
        {
            get { return bytSoCuonMuonVe; }
            set { bytSoCuonMuonVe = value; }
        }

        public byte SoCuonMuonTaiCho
        {
            get { return bytSoCuonMuonTaiCho; }
            set { bytSoCuonMuonTaiCho = value; }
        }

        public byte SoCuonMuonGVBC
        {
            get { return bytSoCuonMuonGVBC; }
            set { bytSoCuonMuonGVBC = value; }
        }
    }
}
