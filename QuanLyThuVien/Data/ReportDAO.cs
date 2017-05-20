using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{
    class ReportDAO
    {
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
        //Báo cáo sách mất
        public DataTable SachMat(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy; select MaDauSach, TenSach,DonGia, GhiChu, MaSach";
            strSQL += " from tblDauSach DS, tblSach S, tblPhieuNhap PN, tblChiTietPhieuNhap CTPN";
            strSQL += " where DS.MaSach=S.MaSach and PN.MaPN = CTPN.MaPN and CTPN.MaSach = S.MaSach and TinhTrang=2 and NgayNhap between @dtTu and @dtDen";            

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        //Báo cáo tiền đặt cọc
        public DataTable TienDatCoc(int intType, string strKeyword)
        {
            string strSQL = "select MaDG, TenDG, SUBSTRING(MaDG,5,2) as 'KhoaHoc',substring(MaDG,5,3) as 'Lop', NgayDatCoc";
            strSQL += "  from tblDocGia";
            if (intType == 0)//Khoa Hoc
                strSQL += " where DaDatCoc=1 and SUBSTRING(MaDG,5,2)=@Keyword";
            else//Lop
                strSQL += " where DaDatCoc=1 and substring(MaDG,5,3)=@Keyword";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Keyword", strKeyword);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
     
        //So cuon bi mat cua mot nganh
        public int SachMatbyNganh(int intMaSach)
        {
            string strSQL = "select S.MaSach,S.TenSach count(*) as SoCuonBiMat";
            strSQL += "  from  tblSach S, tblDauSach DS";
            strSQL += "  where  S.MaSach=DS.MaSach and TinhTrang=2 ";
            strSQL += "  group by S.MaSach, S.TenSach";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            int intSoCuonBiMat = 0;
            foreach (DataRow dr in dt.Rows)
                intSoCuonBiMat = Convert.ToInt32(dr["SoCuonBiMat"]);
        return intSoCuonBiMat;
        }
        //So cuon bi hỏng cua mot nganh
        public int SachHong(int intMaSach)
        {
            string strSQL = "select S.MaSach,S.TenSach count(*) as SoCuonBiHong";
            strSQL += "  from  tblSach S, tblDauSach DS";
            strSQL += "  where  S.MaSach=DS.MaSach and TinhTrang=1 ";
            strSQL += "  group by S.MaSach, S.TenSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            int intSoCuonBiHong = 0;
            foreach(DataRow dr in dt.Rows)            
                intSoCuonBiHong = Convert.ToInt32(dr["SoCuonBiHong"]);
            return intSoCuonBiHong;
        }
        //So cuon dang muon
        public int SachDangMuonbyNganh(int intMaSach, DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy; select S.MaSach, TenSach, count(*) as SoCuonDangMuon";
            strSQL += "  from  tblSach S, tblDauSach DS, tblChiTietPhieuMuon PMS, tblPhieuMuonTra PM";
            strSQL += "  where S.MaSach=DS.MaSach and DS.MaDauSach=PMS.MaDauSach and PMS.MaPM=PM.MaPM";
            strSQL += "  and NgayTra is null and S.MaSach=@MaSach";
            strSQL += "  and NgayTra is null and NgayMuon between @dtTu and @dtDen and S.MaSach=@MaSach";
            strSQL += "  group by S.MaSach, TenSach";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaSach);
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            int intSoCuonDangMuon=0;
            foreach (DataRow dr in dt.Rows)
                intSoCuonDangMuon = Convert.ToInt32(dr["SoCuonDangMuon"]);
         return intSoCuonDangMuon;
        }
        //Số lần mượn nhiều
        public DataTable SachMuonNhieu(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select S.MaSach, S.TenSach, TenNXB, DonGia, Count(*) as 'LanMuon'";
            strSQL += "  from tblNXB NXB, tblSach S, tblDauSach DS, tblChiTietPhieuMuon PMS, tblPhieuMuonTra PM";
            strSQL += "  where NXB.MaNXB=S.MaNXB and S.MaSach=DS.MaSach and DS.MaDauSach=PMS.MaDauSach and PMS.MaPM=PM.MaPM";
            strSQL += "  and NgayMuon between @dtTu and @dtDen";
            strSQL += "  group by S.MaSach, S.TenSach, TenNXB, NamXB, DonGia";
            strSQL += "  order by LanMuon desc";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        //Tác giả theo tựa sách
        public DataTable TacGiabyTuaSach(int intMaTS)
        {
            string strSQL = "select TacGia";
            strSQL += "  from tblSach S";
            strSQL += "  where MaSach=@MaSach";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaSach", intMaTS);            
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
      
        //Số lượt mượn về
        public int LuotMuonVe(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select distinct PM.MaPM";
            strSQL += "  from tblPhieuMuon PM, tblCT_PMSach PMS";
            strSQL += "  where PM.MaPM=PMS.MaPM and LoaiPM=1 and NgayMuon between @dtTu and @dtDen";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt.Rows.Count;
        }
        //Số đầu sách mượn về
        public int DauSachMuonVe(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select distinct MaDauSach";
            strSQL += "  from tblPhieuMuonTra PM, tblChiTietPhieuMuon PMS";
            strSQL += "  where PM.MaPM=PMS.MaPM and NgayMuon between @dtTu and @dtDen";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt.Rows.Count;
        }
        //Số lượt mượn tại chổ
        public int LuotMuonTaiCho(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select distinct PM.MaPM";
            strSQL += "  from tblPhieuMuon PM, tblChiTietPhieuMuon PMS";
            strSQL += "  where PM.MaPM=PMS.MaPM and NgayMuon between @dtTu and @dtDen";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt.Rows.Count;
        }
    
        //Tổng số đầu sách mượn
        public int TongDauSachMuon(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select distinct MaDauSach";
            strSQL += "  from tblPhieuMuon PM, tblChiTietPhieuMuon PMS";
            strSQL += "  where PM.MaPM=PMS.MaPM and NgayMuon between @dtTu and @dtDen";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt.Rows.Count;
        }
        //Tổng số lượt mượn
        public int TongLuotMuon(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select distinct PM.MaPM";
            strSQL += "  from tblPhieuMuonTra PM, tblChiTietPhieuMuon PMS";
            strSQL += "  where PM.MaPM=PMS.MaPM and NgayMuon between @dtTu and @dtDen";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt.Rows.Count;
        }
        //Sách trễ hạn
        public DataTable SachTreHan(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select MaDG, NgayMuon, SoNgayMuon, DS.SoDKCB, TenTS, DATEDIFF(day,NgayMuon,getdate()) as 'SoNgayDaMuon',case LoaiPM when 0 then N'Tại chổ' when 1 then N'Về nhà' end as LoaiPM,DATEDIFF(day,NgayMuon,getdate())-SoNgayMuon as 'SoNgayTre'";
            strSQL += "  from tblPhieuMuon PM, tblCT_PMSach PMS, tblDauSach DS, tblTuaSach TS";
            strSQL += "  where PM.MaPM=PMS.MaPM and NgayTra is null and DATEDIFF(day,NgayMuon,getdate())>SoNgayMuon";
            strSQL += "  and PMS.SoDKCB=DS.SoDKCB and DS.MaTS=TS.MaTS and NgayMuon between @dtTu and @dtDen";           
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        //Báo tạp chí trễ hạn
        public DataTable BaoTCTreHan(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select MaDG, NgayMuon, SoBTC.SoPH, TenBTC, DATEDIFF(day,NgayMuon,getdate()) as 'SoNgayTre'";
            strSQL += "  from tblPhieuMuon PM, tblCT_PMBaoTC PMBTC, tblSoBaoTC SoBTC, tblTenBaoTC TBTC";
            strSQL += "  where PM.MaPM=PMBTC.MaPM and NgayTra is null and DATEDIFF(day,NgayMuon,getdate())>0";
            strSQL += "  and PMBTC.SoPH=SoBTC.SoPH and PMBTC.MaTenBTC=SoBTC.MaTenBTC and SoBTC.MaTenBTC=TBTC.MaTenBTC and NgayMuon between @dtTu and @dtDen";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        //Báo cáo sách yêu cầu
        public DataTable SachYeuCau(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy; select *";
            strSQL += " from tblSachYeuCau";
            strSQL += " where NgayYC between @dtTu and @dtDen";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dtTu", dtTu);
            cmd.Parameters.AddWithValue("@dtDen", dtDen);
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dt;
        }
        //Báo cáo sách mới
        public DataTable SachMoi(int intYear)
        {
            string strSQL = "select MaTS,TenTS,TenNXB,NamXB,LanTB,GiaBia,0 as MaTap";
            strSQL += " from tblTuaSach TS, tblNXB NXB";
            strSQL += " where TS.MaNXB=NXB.MaNXB and NamXB=@intYear and LanTB=0 and MaTS not in (Select MaTS from tblTapSach)";

            string strSQL2 = "select TS.MaTS,TenTap as TenTS,TenNXB,NamXB,LanTB,TapS.GiaBia,MaTap";
            strSQL2 += " from tblTuaSach TS, tblNXB NXB, tblTapSach TapS";
            strSQL2 += " where TS.MaNXB=NXB.MaNXB and NamXB=@intYear and LanTB=0 and TS.MaTS=TapS.MaTS";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@intYear", intYear);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
                dt2 = cls.GetData(strSQL2, CommandType.Text, cmd).Tables[0];
                if (cls.Error != "")
                    strError = cls.Error;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            dt.Merge(dt2);
            return dt;
        }
    }
}
