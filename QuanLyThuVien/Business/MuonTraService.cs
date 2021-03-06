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
                if (tr.Read())
                {
                    clsMT.MaDG = tr["MaDG"].ToString();
                    clsMT.TenDG = Convert.ToString(tr["TenDG"]);
                    clsMT.TienDatCoc = Convert.ToInt32(tr["TienDatCoc"]);
                    clsMT.LoaiDG = Convert.ToInt16(tr["MaLoaiDG"]); //== 1 ? "Sinh Viên" : "Giáo Viên" ;                                                                  
                }
                clsMT.TongSoTien = cls.SoTienMuonVe(strMaDG);
                clsMT.SoCuonMuonVe = cls.SoCuonMuonVe(strMaDG);
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
                    clsMT.MaSach = Convert.ToInt16(tr["MaSach"]);
                    clsMT.TenSach = Convert.ToString(tr["TenSach"]);
                    clsMT.DonGia = Convert.ToInt32(tr["DonGia"]);                
                    clsMT.TinhTrang = Convert.ToByte(tr["TinhTrang"]);                                  
                }
                dt = cls.GetAuthor(intSoDKCB);
                //clsMT.DonGia = Convert.ToInt32(tr["DonGia"]);
                BookService test = new BookService();
                //tr = dt.CreateDataReader();
                while (tr.Read())
                    clsMT.TacGia = Convert.ToString(tr["TacGia"]) ;
                //clsMT.DonGia += test.GetInfo(cls.GetDauSach(intSoDKCB)).DonGia;
                clsMT.SoLuongCon += cls.SoLuongDauSach(intSoDKCB) - cls.SoLuongDangMuon(intSoDKCB); // kiểm tra số lượng đang mượn               
            }
            catch
            {
                strError = "Có xảy ra lỗi khi lấy thông tin sách";
            }
            return clsMT;
        }
      
    
        //Kiểm tra số cuốn mượn về
        public bool KiemTraSoCuonMuonVe(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;
            MuonTraDAO cls = new MuonTraDAO();
            int intSoCuonMuonVe = cls.SoCuonMuonVe(Convert.ToString(clsMuonTra.MaDauSach));                        
            byte bytLoaiDG = 0;
            DataTableReader tr = cls.GetReader(Convert.ToString(clsMuonTra.MaDauSach)).CreateDataReader();
            if (tr.Read())
                bytLoaiDG = Convert.ToByte(tr["LoaiDG"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                    intSoCuonMuonVe++;               
            }
            blKey = true;
            return blKey;
        }
      
      
        //Kiểm tra số tiền mượn tại chổ
      
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

        public bool KiemTraSoTienMuonVe(DataTable dt, MuonTra clsMuonTra)
        {
            bool blKey = false;
            MuonTraDAO cls = new MuonTraDAO();
            //Cộng luôn giá bìa của sách chuẩn bị add vào
            int intSoTienMuonVe = cls.SoTienMuonVe(clsMuonTra.MaDG) + (clsMuonTra.DonGia * clsMuonTra.SoCuonMuonVe);
            byte bytLoaiDG = 0;
            DataTableReader tr = cls.GetReader(clsMuonTra.MaDG).CreateDataReader();
            if (tr.Read())
                bytLoaiDG = Convert.ToByte(tr["MaLoaiDG"]);
            HeThongService clsParamService = new HeThongService();
            //Không kiểm tra số tiền sách của GVBC
            if (bytLoaiDG == 1)
                blKey = true;
            return blKey;
        }

        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
    }
}
