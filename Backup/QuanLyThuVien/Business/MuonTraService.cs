using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    class MuonTraService
    {
        //Lấy thông tin mượn trả của độc giả
        public MuonTra GetInfoReader(string strMaDG)
        {
            MuonTra clsMT = new MuonTra();
            try
            {                                
                MuonTraDAO cls = new MuonTraDAO();
                DataTable dt = cls.GetReader(strMaDG);
                DataTableReader tr = dt.CreateDataReader();
                HeThongService clsParam = new HeThongService();                
                if (tr.Read())
                {
                    clsMT.MaDG = tr["MaDG"].ToString();
                    clsMT.LoaiDG = Convert.ToByte(tr["LoaiDG"]) == 1 ? "GVBC" : "HSSV, GVHĐ";
                    clsMT.TenDG = Convert.ToString(tr["TenDG"]);                    
                    clsMT.TienDatCoc = Convert.ToInt32(tr["DaDatCoc"]) * Convert.ToInt32(clsParam.GetParam().SoTienDatCoc);
                }
                clsMT.TienConLaiVe = clsMT.TienDatCoc - cls.SoTienMuonVe(strMaDG);
                clsMT.TienConLaiTaiCho = Convert.ToInt32(clsParam.GetParam().SoTienDatCoc) - cls.SoTienMuonTaiCho(strMaDG);
                clsMT.SoCuonMuonVe = cls.SoCuonMuonVe(strMaDG);
                clsMT.SoCuonMuonTaiCho = cls.SoCuonMuonTaiCho(strMaDG);
            }
            catch
            {
                strError = "Có xảy ra lỗi khi lấy thông tin độc giả";            
            }
            return clsMT;
        }
        //Lấy thông tin sách
        public MuonTra GetInfoBook(int intSoDKCB)
        {
            MuonTra clsMT = new MuonTra();
            try
            {                
                MuonTraDAO cls = new MuonTraDAO();
                DataTable dt = cls.GetBook(intSoDKCB);                
                DataTableReader tr = dt.CreateDataReader();
                if (tr.Read())
                {
                    clsMT.TenTS = Convert.ToString(tr["TenTS"]);                    
                    clsMT.Kho = Convert.ToString(tr["TenKho"]);
                    clsMT.TinhTrang = Convert.ToByte(tr["TinhTrang"]);                    
                }
                if (cls.HasChapter(intSoDKCB))
                {
                    dt = cls.GetAuthorChapter(intSoDKCB);
                    BookService clsBS = new BookService();
                    clsMT.GiaBia = clsBS.GetInfoChapter(cls.GetChapterID(intSoDKCB)).GiaBia;
                }
                else
                {
                    dt = cls.GetAuthor(intSoDKCB);
                    clsMT.GiaBia = Convert.ToInt32(tr["GiaBia"]);
                }
                tr = dt.CreateDataReader();
                while (tr.Read())
                    clsMT.TacGia += tr["TenTG"] + ", ";
                clsMT.SoLuongCon = cls.SoLuongDauSach(intSoDKCB) - cls.SoLuongDangMuon(intSoDKCB);                
            }
            catch
            {
                strError = "Có xảy ra lỗi khi lấy thông tin sách";
            }
            return clsMT;
        }
        //Lấy thông tin báo tạp chí
        public MuonTra GetInfoNewspaper(int intMaTenBTC, string strSoPH)
        {
            MuonTra clsMT = new MuonTra();
            try
            {
                MuonTraDAO cls = new MuonTraDAO();
                DataTable dt = cls.GetNewspaper(intMaTenBTC,strSoPH);
                DataTableReader tr = dt.CreateDataReader();
                if (tr.Read())
                {
                    clsMT.TenBaoTC = Convert.ToString(tr["TenBTC"]);
                    clsMT.SoPH = tr["SoPH"].ToString();
                    clsMT.NgayPH = Convert.ToDateTime(tr["NgayPH"]);
                    clsMT.SoLuongNhap = Convert.ToInt32(tr["SoLuongNhap"]);
                }                
                clsMT.SoLuongConBTC = clsMT.SoLuongNhap - cls.SoLuongBTCDangMuon(intMaTenBTC,strSoPH);
            }
            catch
            {
                strError = "Có xảy ra lỗi khi lấy thông tin báo tạp chí";
            }
            return clsMT;
        }
        //Kiểm tra số cuốn mượn của GVBC
        public bool KiemTraSoCuonMuonGVBC(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;
            MuonTraDAO cls = new MuonTraDAO();
            int intSoCuonMuonVe = cls.SoCuonMuonVe(clsMuonTra.MaDG);
            int intSoCuonMuonTaiCho = cls.SoCuonMuonTaiCho(clsMuonTra.MaDG);
            int intSoCuonMuon = intSoCuonMuonVe + intSoCuonMuonTaiCho + dt.Rows.Count;
            
            HeThongService clsParamService = new HeThongService();
            int intSoCuonDuocMuonVe = clsParamService.GetParam().SoCuonMuonGVBC;
            if (intSoCuonMuon < intSoCuonDuocMuonVe)
                blKey = true;
            return blKey;
        }
        //Kiểm tra số cuốn mượn về
        public bool KiemTraSoCuonMuonVe(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;
            MuonTraDAO cls = new MuonTraDAO();
            int intSoCuonMuonVe = cls.SoCuonMuonVe(clsMuonTra.MaDG);                        
            byte bytLoaiDG = 0;
            DataTableReader tr = cls.GetReader(clsMuonTra.MaDG).CreateDataReader();
            if (tr.Read())
                bytLoaiDG = Convert.ToByte(tr["LoaiDG"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (Convert.ToInt32(row["LoaiPM"]) == 1)
                {
                    intSoCuonMuonVe++;
                }                
            }
            HeThongService clsParamService = new HeThongService();
            int intSoCuonDuocMuonVe = 0;
            //if (bytLoaiDG == 0)
                intSoCuonDuocMuonVe = clsParamService.GetParam().SoCuonMuonVe;
            //else
                //intSoCuonDuocMuonVe = clsParamService.GetParam().SoCuonMuonGVBC;
            if (intSoCuonMuonVe < intSoCuonDuocMuonVe)
                    blKey = true;
            return blKey;
        }
        //Kiểm tra số cuốn mượn tại chổ
        public bool KiemTraSoCuonMuonTaiCho(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;
            MuonTraDAO cls = new MuonTraDAO();
            int intSoCuonMuonTaiCho = cls.SoCuonMuonTaiCho(clsMuonTra.MaDG);
            byte bytLoaiDG = 0;
            DataTableReader tr = cls.GetReader(clsMuonTra.MaDG).CreateDataReader();
            if (tr.Read())
                bytLoaiDG = Convert.ToByte(tr["LoaiDG"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (Convert.ToInt32(row["LoaiPM"]) == 0)
                {
                    intSoCuonMuonTaiCho++;
                }
            }
            HeThongService clsParamService = new HeThongService();
            int intSoCuonDuocMuonTaiCho = 0;
            //if (bytLoaiDG == 0)
                intSoCuonDuocMuonTaiCho = clsParamService.GetParam().SoCuonMuonTaiCho;
            //else
                //intSoCuonDuocMuonTaiCho = clsParamService.GetParam().SoCuonMuonGVBC;
            if (intSoCuonMuonTaiCho < intSoCuonDuocMuonTaiCho)
                blKey = true;
            return blKey;
        }
        //Kiểm tra số tiền mượn về
        public bool KiemTraSoTienMuonVe(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;
            MuonTraDAO cls = new MuonTraDAO();
            //Cộng luôn giá bìa của sách chuẩn bị add vào
            int intSoTienMuonVe = cls.SoTienMuonVe(clsMuonTra.MaDG) + clsMuonTra.GiaBia;
            byte bytLoaiDG = 0;
            DataTableReader tr = cls.GetReader(clsMuonTra.MaDG).CreateDataReader();
            if (tr.Read())
                bytLoaiDG = Convert.ToByte(tr["LoaiDG"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (Convert.ToInt32(row["LoaiPM"]) == 1)
                {
                    intSoTienMuonVe += Convert.ToInt32(row["GiaBia"]);
                }
            }            
            HeThongService clsParamService = new HeThongService();
            //Không kiểm tra số tiền sách của GVBC
            if (bytLoaiDG == 1 || intSoTienMuonVe <= clsParamService.GetParam().SoTienDatCoc)
                blKey = true;
            return blKey;
        }
        //Kiểm tra số tiền mượn tại chổ
        public bool KiemTraSoTienMuonTaiCho(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;
            MuonTraDAO cls = new MuonTraDAO();
            //Cộng luôn giá bìa của sách chuẩn bị add vào
            int intSoTienMuonTaiCho = cls.SoTienMuonTaiCho(clsMuonTra.MaDG) + clsMuonTra.GiaBia;
            byte bytLoaiDG = 0;
            DataTableReader tr = cls.GetReader(clsMuonTra.MaDG).CreateDataReader();
            if (tr.Read())
                bytLoaiDG = Convert.ToByte(tr["LoaiDG"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (Convert.ToInt32(row["LoaiPM"]) == 0)
                {
                    intSoTienMuonTaiCho += Convert.ToInt32(row["GiaBia"]);
                }
            }            
            HeThongService clsParamService = new HeThongService();
            //Không kiểm tra số tiền sách của GVBC
            if (bytLoaiDG == 1 || intSoTienMuonTaiCho <= clsParamService.GetParam().SoTienDatCoc)
                blKey = true;
            return blKey;
        }
        //Mượn
        public bool Muon(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;            
            MuonTraDAO cls = new MuonTraDAO();
            if (cls.Muon(dt,clsMuonTra))
                blKey = true;
            else
                strError = cls.Error;            
            return blKey;
        }
        //Xem thông tin mượn trả dựa vào mã độc giả
        public DataTable XemDG(string strMaDG)
        {
            MuonTraDAO cls = new MuonTraDAO();
            DataTable dt = cls.XemDG(strMaDG);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Xem thông tin mượn trả dựa vào Số DKCB
        public DataTable XemSach(int intSoDKCB)
        {
            MuonTraDAO cls = new MuonTraDAO();
            DataTable dt = cls.XemSach(intSoDKCB);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Xem thông tin mượn trả dựa vào thông tin báo tc
        public DataTable XemBTC(int intMaTenBTC, string strSoPH)
        {
            MuonTraDAO cls = new MuonTraDAO();
            DataTable dt = cls.XemBTC(intMaTenBTC, strSoPH);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Gia hạn
        public bool GiaHan(MuonTra clsMuonTra)
        {
            bool blKey = false;
            MuonTraDAO cls = new MuonTraDAO();
            if (cls.GiaHan(clsMuonTra))
                blKey = true;
            else
                strError = cls.Error;
            return blKey;
        }
        //Trả sách
        public bool TraSach(MuonTra clsMuonTra)
        {
            bool blKey = false;            
            MuonTraDAO cls = new MuonTraDAO();
            if (cls.TraSach(clsMuonTra))
                blKey = true;
            else
                strError = cls.Error;            
            return blKey;
        }
        //Trả báo tạp chí
        public bool TraBaoTC(MuonTra clsMuonTra)
        {
            bool blKey = false;            
            MuonTraDAO cls = new MuonTraDAO();
            if (cls.TraBaoTC(clsMuonTra))
                blKey = true;
            else
                strError = cls.Error;            
            return blKey;
        }
        //Lấy tất cả tên báo tên tc
        public DataTable ShowAllBaoTC()
        {
            MuonTraDAO cls = new MuonTraDAO();
            DataTable dt = cls.ShowAllBaoTC();
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Lấy tất cả số báo tc dựa vào mã tên btc
        public DataTable ShowAllBaoTC(int intMaTenBTC)
        {
            MuonTraDAO cls = new MuonTraDAO();
            DataTable dt = cls.ShowAllBaoTC(intMaTenBTC);
            if (cls.Error != "")
                strError = cls.Error;
            return dt;
        }
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
