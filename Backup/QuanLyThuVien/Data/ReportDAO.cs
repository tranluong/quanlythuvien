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
            string strSQL = "set dateformat dmy; select SoDKCB, TenTS,GiaBia, GhiChu, MaTap";
            strSQL += " from tblDauSach DS, tblTuaSach TS";
            strSQL += " where DS.MaTS=TS.MaTS and TinhTrang=2 and NgayCapNhat between @dtTu and @dtDen";            

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
        //Tổng số cuốn theo từng ngành
        public DataTable TongSoCuonTungNganh()
        {
            string strSQL = "select NH.MaNganh, TenNganh, Count(*) as TongSoCuon";
            strSQL += "  from tblNganhHoc NH, tblTuaSach TS, tblDauSach DS";
            strSQL += "  where NH.MaNganh=TS.MaNganh and TS.MaTS=DS.MaTS";
            strSQL += "  group by NH.MaNganh, NH.TenNganh";            
            DataTable dt = new DataTable();
            Database cls = new Database();
            try
            {
                dt = cls.GetData(strSQL).Tables[0];
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
        public int SachMatbyNganh(int intMaNganh)
        {
            string strSQL = "select NH.MaNganh, TenNganh, count(*) as SoCuonBiMat";
            strSQL += "  from tblNganhHoc NH, tblTuaSach TS, tblDauSach DS";
            strSQL += "  where NH.MaNganh=TS.MaNganh and TS.MaTS=DS.MaTS and TinhTrang=2 and NH.MaNganh=@MaNganh";
            strSQL += "  group by NH.MaNganh, TenNganh";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaNganh", intMaNganh);
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
        public int SachHongbyNganh(int intMaNganh)
        {
            string strSQL = "select NH.MaNganh, TenNganh, count(*) as SoCuonBiHong";
            strSQL += "  from tblNganhHoc NH, tblTuaSach TS, tblDauSach DS";
            strSQL += "  where NH.MaNganh=TS.MaNganh and TS.MaTS=DS.MaTS and TinhTrang=1 and NH.MaNganh=@MaNganh";
            strSQL += "  group by NH.MaNganh, TenNganh";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaNganh", intMaNganh);
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
        public int SachDangMuonbyNganh(int intMaNganh, DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy; select NH.MaNganh, TenNganh, count(*) as SoCuonDangMuon";
            strSQL += "  from tblNganhHoc NH, tblTuaSach TS, tblDauSach DS, tblCT_PMSach PMS, tblPhieuMuon PM";
            strSQL += "  where TS.MaTS=DS.MaTS and NH.MaNganh=TS.MaNganh and DS.SoDKCB=PMS.SoDKCB and PMS.MaPM=PM.MaPM";
            strSQL += "  and NgayTra is null and NH.MaNganh=@MaNganh";
            strSQL += "  and NgayTra is null and NgayMuon between @dtTu and @dtDen and NH.MaNganh=@MaNganh";
            strSQL += "  group by NH.MaNganh, TenNganh";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaNganh", intMaNganh);
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
            strSQL += "  select TS.MaTS, TS.TenTS, TenNXB, NamXB, GiaBia, Count(*) as 'LanMuon', MaTap";
            strSQL += "  from tblNXB NXB, tblTuaSach TS, tblDauSach DS, tblCT_PMSach PMS, tblPhieuMuon PM";
            strSQL += "  where NXB.MaNXB=TS.MaNXB and TS.MaTS=DS.MaTS and DS.SoDKCB=PMS.SoDKCB and PMS.MaPM=PM.MaPM";
            strSQL += "  and NgayMuon between @dtTu and @dtDen";
            strSQL += "  group by TS.MaTS, TS.TenTS, TenNXB, NamXB, GiaBia, MaTap";
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
            string strSQL = "select TenTG";
            strSQL += "  from tblTuaSach TS, tblSach_Tacgia STG, tblTacGia TG";
            strSQL += "  where TS.MaTS=STG.MaTS and STG.MaTG=TG.MaTG and TS.MaTS=@MaTS";            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);            
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
        //Tác giả theo tựa sách có tập
        public DataTable TacGiabyTuaSachTap(int intMaTap)
        {
            string strSQL = "select TenTG";
            strSQL += "  from tblTuaSach TS, tblTapSach TapS, tblTap_Tacgia STG, tblTacGia TG";
            strSQL += "  where TS.MaTS=TapS.MaTS and TapS.MaTap=STG.MaTap and STG.MaTG=TG.MaTG and TapS.MaTap=@MaTap";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
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
        //Tác giả theo tựa sách có tập theo mã tựa sách
        public DataTable TacGiaTap(int intMaTS, int intMaTap)
        {
            string strSQL = "select TenTG";
            strSQL += " from tblTuaSach TS, tblTapSach TapS, tblTap_Tacgia STG, tblTacGia TG";
            strSQL += " where TS.MaTS=TapS.MaTS and TapS.MaTap=STG.MaTap and STG.MaTG=TG.MaTG and TS.MaTS=@MaTS and TapS.MaTap=@MaTap";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@MaTS", intMaTS);
            cmd.Parameters.AddWithValue("@MaTap", intMaTap);
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
            strSQL += "  select distinct SoDKCB";
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
        //Số lượt mượn tại chổ
        public int LuotMuonTaiCho(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select distinct PM.MaPM";
            strSQL += "  from tblPhieuMuon PM, tblCT_PMSach PMS";
            strSQL += "  where PM.MaPM=PMS.MaPM and LoaiPM=0 and NgayMuon between @dtTu and @dtDen";
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
        //Số đầu sách mượn tại chổ
        public int DauSachMuonTaiCho(DateTime dtTu, DateTime dtDen)
        {
            string strSQL = "set dateformat dmy;";
            strSQL += "  select distinct SoDKCB";
            strSQL += "  from tblPhieuMuon PM, tblCT_PMSach PMS";
            strSQL += "  where PM.MaPM=PMS.MaPM and LoaiPM=0 and NgayMuon between @dtTu and @dtDen";
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
            strSQL += "  select distinct SoDKCB";
            strSQL += "  from tblPhieuMuon PM, tblCT_PMSach PMS";
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
            strSQL += "  from tblPhieuMuon PM, tblCT_PMSach PMS";
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
