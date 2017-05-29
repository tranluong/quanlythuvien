using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QuanLyThuVien
{
    class ReportService
    {
        //Thuộc tính lỗi
        private string strError = "";
        public string Error
        {
            get { return strError; }
        }
        //Báo cáo sách mất
        public string SachMat(DateTime dtTu, DateTime dtDen)
        {
            string strHTML = "";
            ReportDAO cls = new ReportDAO();
            DataTable dt = cls.SachMat(dtTu, dtDen);
            if (cls.Error != "")
                strError = cls.Error;
            else
            {
                strHTML += "<body>";
                strHTML += "<table border='0' width='100%' id='table1' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr>";
                strHTML += "<td width='95%'><p align='center'><b><font size='5'>THỐNG KÊ SÁCH MẤT</font></b></td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td width='95%'><p align='center'><b><font size='4'>Từ&nbsp;&nbsp;" + dtTu.ToShortDateString() + "&nbsp;&nbsp;đến&nbsp;&nbsp;" + dtDen.ToShortDateString() + "</font></b></td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td width='95%'>";
                strHTML += "<table border='1' width='100%' id='table5' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td width='35' align='center'><b><font size='2'>STT</font></b></td>";
                strHTML += "<td width='77' align='center'><b><font size='2'>Số ĐKCB</font></b></td>";
                strHTML += "<td width='217' align='center'><b><font size='2'>Tựa sách</font></b></td>";
                strHTML += "<td width='46' align='center'><b><font size='2'>Giá bìa</font></b></td>";
                strHTML += "<td width='97' align='center'><b><font size='2'>Ghi chú</font></b></td>";
                strHTML += "</tr>";
                int i = 1;
                int intTongTien = 0;
                int intGiaBia = 0;
                foreach (DataRow dr in dt.Rows)
                {                    
                    strHTML += "<tr>";
                    strHTML += "<td width='35' align='center'>" + i++.ToString() + "</td>";
                    strHTML += "<td width='77'><font size='2'>" + dr["SoDKCB"].ToString() + "</font></td>";
                    strHTML += "<td width='217'><font size='2'></font>" + dr["TenTS"].ToString() + "</font></td>";
                    if (Convert.ToInt32(dr["MaTap"]) == 0)
                        intGiaBia = Convert.ToInt32(dr["GiaBia"]);
                    else
                    {
                        BookService clsBS = new BookService();
                        intGiaBia = clsBS.GetInfoChapter(Convert.ToInt32(dr["MaTap"])).GiaBia;
                    }

                    strHTML += "<td width='46' align='right'><font size='2'>&nbsp;" + intGiaBia.ToString() + "</font></td>";
                    strHTML += "<td width='97' align='left'><font size='2'>&nbsp;" + dr["GhiChu"].ToString() + "</font></td>";
                    strHTML += "</tr>";
                    intTongTien += intGiaBia;
                }
                strHTML += "<tr>";
                strHTML += "<td width='338' align='center' colspan='3'><p align='right'><b>Tổng tiền:</b></td>";
                strHTML += "<td width='46' align='right'><font size='2'><b>" + intTongTien + "</b></font></td>";
                strHTML += "<td width='97' align='center'>&nbsp;</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</body>";
            }
            return strHTML;
        }
        //Báo cáo tiền đặt cọc
        public string TienDatCoc(int intType, string strKeyword)
        {
            string strHTML = "";
            ReportDAO cls = new ReportDAO();
            DataTable dt = cls.TienDatCoc(intType, strKeyword);
            if (cls.Error != "")
                strError = cls.Error;
            else
            {
                strHTML += "<body>";
                strHTML += "<table border='0' width='100%%' id='table1' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr>";
                strHTML += "<td width='95%'><p align='center'><font size='5'><b>THỐNG KÊ TIỀN ĐẶT CỌC</b></font></td>";
                strHTML += "</tr>";
                string strKL="";
                if(intType==0)
                    strKL="Khóa: ";
                else
                    strKL="Lớp: ";
                strHTML += "<tr><td width='95%'><p align='center'><b><font size='4'>" + strKL + strKeyword.ToUpper() + "</font></b></td></tr>";
                strHTML += "<tr><td width='95%'>";
                strHTML += "<table border='1' width='100%' id='table5' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td width='35' align='center'><b><font size='2'>STT</font></b></td>";
                strHTML += "<td width='77' align='center'><font size='2'><b>Mã đọc giả</b></font></td>";
                strHTML += "<td width='217' align='center'><font size='2'><b>Tên đọc giả</b></font></td>";
                strHTML += "<td width='46' align='center'><font size='2'><b>Lớp</b></font></td>";
                strHTML += "<td width='97' align='center'><b><font size='2'>Khóa</font></b></td>";
                strHTML += "<td width='97' align='center'><b><font size='2'>Ngày đặt cọc</font></b></td></tr>";

                int i = 1;
                int intTongTien = 0;
                HeThongService HT = new HeThongService();
                foreach (DataRow dr in dt.Rows)
                {
                    intTongTien += HT.GetParam().SoTienDatCoc;
                    strHTML += "<tr>";
                    strHTML += "<td width='35' align='center'>" + i++.ToString() + "</td>";
                    strHTML += "<td width='77'>" + dr["MaDG"].ToString() + "</td>";
                    strHTML += "<td width='217'>" + dr["TenDG"] + "</td>";
                    strHTML += "<td width='46' align='center'><font size='2'>" + dr["Lop"].ToString() + "</font></td>";
                    strHTML += "<td width='97' align='center'><p align='center'>" + dr["KhoaHoc"].ToString() + "</td>";
                    strHTML += "<td width='97' align='right'>" + Convert.ToDateTime(dr["NgayDatCoc"]).ToShortDateString() + "</td>";
                    strHTML += "</tr>";
                }

                strHTML += "<tr>";
                strHTML += "<td width='569' align='center' colspan='6'><p align='right'><b><u>Tổng tiền:</u>&nbsp;&nbsp; " + intTongTien.ToString() + "</b></td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</body>";
            }
            return strHTML;
        }
        //Bảng kiểm kê tài sản
        public string KiemKeTaiSan(DateTime dtTu, DateTime dtDen)
        {
            string strHTML = "";
            ReportDAO cls = new ReportDAO();
            DataTable dt = cls.TongSoCuonTungNganh();
            if (cls.Error != "")
                strError = cls.Error;
            else
            {
                strHTML += "<body>";
                strHTML += "<table border='0' width='100%' id='table1' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr>";
                strHTML += "<td width='95%'><p align='center'><font size='5'><b>BẢNG KIỂM KÊ TÀI SẢN TRONG THƯ VIỆN</b></font></td>";
                strHTML += "</tr>";
                strHTML += "<tr><td width='95%'><p align='center'><font size='4'><b>(VỐN TÀI LIỆU NĂM "+dtTu.Year.ToString()+" - "+dtDen.Year.ToString()+")</b></font></td></tr>";
                strHTML += "<tr><td width='95%'>";
                strHTML += "<table border='1' width='100%' id='table5' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td width='35' align='center'><b>STT</b></td>";
                strHTML += "<td width='250' align='center'><b>Ngành học</b></td>";
                strHTML += "<td width='120'><p align='center'><b>Tổng số cuốn</b></td>";
                strHTML += "<td width='150' align='center'><b>Số cuốn trên giá</b></td>";
                strHTML += "<td width='180' align='center'><b>Số cuốn đang mượn</b></td>";
                strHTML += "<td width='140' align='center'><b>Số cuốn bị mất</b></td>";
                strHTML += "<td align='center'><b>Số cuốn bị hỏng</b></td>";
                strHTML += "</tr>";

                int i = 1;                
                foreach (DataRow dr in dt.Rows)
                {
                    strHTML += "<tr>";
                    strHTML += "<td width='35' align='center'>" + i++.ToString() + "</td>";
                    strHTML += "<td width='183'>" + dr["TenNganh"].ToString() + "</td>";
                    strHTML += "<td width='104'>";
                    int intTongSoCuon = Convert.ToInt32(dr["TongSoCuon"]);
                    strHTML += "<p align='center'>" + intTongSoCuon.ToString() + "</td>";
                    int intMaNganh = Convert.ToInt32(dr["MaNganh"]);
                    int intSoCuonHong = cls.SachHongbyNganh(intMaNganh);
                    int intSoCuonMat = cls.SachMatbyNganh(intMaNganh);
                    int intSoCuonDangMuon = cls.SachDangMuonbyNganh(intMaNganh, dtTu, dtDen);
                    int intSoCuonTrenGia = intTongSoCuon - (intSoCuonHong + intSoCuonMat + intSoCuonDangMuon);
                    strHTML += "<td width='123' align='center'>" + intSoCuonTrenGia.ToString() + "</td>";
                    strHTML += "<td width='152' align='center'>";
                    strHTML += "<p align='center'>" + intSoCuonDangMuon.ToString() + "</td>";
                    strHTML += "<td width='124' align='center'>";
                    strHTML += "<p align='center'>" + intSoCuonMat.ToString() + "</td>";
                    strHTML += "<td width='207' align='right'>";
                    strHTML += "<p align='center'>" + intSoCuonHong.ToString() + "</td>";
                    strHTML += "</tr>";
                }
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</body>";
            }
            return strHTML;
        }
        //Sách mượn nhiều
        public string SachMuonNhieu(int intTop, DateTime dtTu, DateTime dtDen)
        {
            string strHTML = "";
            ReportDAO cls = new ReportDAO();
            DataTable dt = cls.SachMuonNhieu(dtTu, dtDen);
            if (cls.Error != "")
                strError = cls.Error;
            else
            {
                strHTML += "<body>";
                strHTML += "<table border='0' width='100%' id='table1' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr>";
                strHTML += "<td width='95%'><p align='center'><font size='5'><b>" + intTop.ToString() + " SÁCH MƯỢN NHIỀU</b></font></td>";
                strHTML += "</tr>";
                strHTML += "<tr><td width='95%'><p align='center'><font size='4'><b>Từ " + dtTu.ToShortDateString() + " đến " + dtDen.ToShortDateString() + "</b></font></td></tr>";
                strHTML += "<tr><td width='95%'>";
                strHTML += "<table border='1' width='100%' id='table5' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td width='35' align='center'><b>STT</b></td>";
                strHTML += "<td width='250' align='center'><b>Tên tựa sách</b></td>";
                strHTML += "<td width='177'><p align='center'><b>Tác giả</b></td>";
                strHTML += "<td width='123' align='center'><b>NXB</b></td>";
                strHTML += "<td width='103' align='center'><b>Năm XB</b></td>";
                strHTML += "<td width='120' align='center'><b>Giá bìa</b></td>";
                strHTML += "<td width='120' align='center'><b>Số lần mượn</b></td>";
                strHTML += "</tr>";


                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    if (i > intTop) break;
                    strHTML += "<tr>";
                    strHTML += "<td width='35' align='center'>" + i++.ToString() + "</td>";
                    strHTML += "<td width='250'>" + dr["TenTS"].ToString() + "</td>";
                    DataTable dtTG = cls.TacGiabyTuaSach(Convert.ToInt32(dr["MaTS"]));
                    string strGiaBia = dr["GiaBia"].ToString();
                    if (dtTG.Rows.Count == 0)
                    {
                        dtTG = cls.TacGiabyTuaSachTap(Convert.ToInt32(dr["MaTap"]));
                        BookDAO clsDAO = new BookDAO();
                        DataTable dtGB = clsDAO.GetInfoChapter(Convert.ToInt32(dr["MaTap"]));                        
                        DataTableReader tr = dtGB.CreateDataReader();
                        if (tr.Read())
                        {
                            strGiaBia = tr["GiaBia"].ToString();
                        }
                    }
                    string strTacGia = "";
                    foreach (DataRow drTG in dtTG.Rows)
                    {
                        strTacGia += drTG["TenTG"].ToString() + "<br>";
                    }                    
                    strHTML += "<td width='177'>" + strTacGia + "</td>";
                    strHTML += "<td width='123' align='center'>" + dr["TenNXB"].ToString() + "</td>";
                    strHTML += "<td width='103' align='center'>";
                    strHTML += "<p align='center'>" + dr["NamXB"].ToString() + "</td>";
                    strHTML += "<td width='120' align='center'>";
                    strHTML += "<p align='center'>" + strGiaBia + "</td>";
                    strHTML += "<td width='120' align='right'>";
                    strHTML += "<p align='center'>" + dr["LanMuon"] + "</td>";
                    strHTML += "</tr>";
                }
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</body>";
            }
            return strHTML;
        }
        //Phục vụ bạn đọc
        public string PhucVuBanDoc(int intSoNgay,DateTime dtTu, DateTime dtDen)
        {
            string strHTML = "";            
            ReportDAO cls = new ReportDAO();
            int intLuotMuonVe = cls.LuotMuonVe(dtTu, dtDen);            
            int intDauSachMuonVe = cls.DauSachMuonVe(dtTu, dtDen);            
            int intLuotMuonTaiCho = cls.LuotMuonTaiCho(dtTu, dtDen);            
            int intDauSachMuonTaiCho = cls.DauSachMuonTaiCho(dtTu, dtDen);            
            int intTongLuotMuon = cls.TongLuotMuon(dtTu, dtDen);
            int intTongDauSachMuon = cls.TongDauSachMuon(dtTu, dtDen);
            if (cls.Error != "")
                strError = cls.Error;
            else
            {
                strHTML += "<body>";
                strHTML += "<table border='0' width='100%%' id='table1' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr>";
                strHTML += "<td width='96%'><p align='center'><font size='5'><b>PHỤC VỤ BẠN ĐỌC</b></font></td>";
                strHTML += "</tr>";
                strHTML += "<tr><td width='96%'><p align='center'><font size='4'><b>Từ " + dtTu.ToShortDateString() + " đến " + dtDen.ToShortDateString() + "<br>Số ngày phục vụ: " + intSoNgay.ToString() + "</b></font><br>&nbsp;</td></tr>";
                strHTML += "<tr><td width='96%'>";
                strHTML += "<table border='1' width='100%' id='table5' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td width='224' align='center' colspan='2'><b>Mượn về</b></td>";
                strHTML += "<td width='217' colspan='2'><p align='center'><b>Mượn tại chổ</b></td>";
                strHTML += "<td width='141' align='center' rowspan='2'><b>Tổng số lượt mượn</b></td>";
                strHTML += "<td width='143' align='center' rowspan='2'><b>Tổng số đầu sách</b></td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td width='118' align='center'><b>Số lượt mượn</b></td>";
                strHTML += "<td width='100' align='center'><b>Số đầu sách</b></td>";
                strHTML += "<td width='106' align='center'><b>Số lượt mượn</b></td>";
                strHTML += "<td width='104' align='center'><b>Số đầu sách</b></td>";
                strHTML += "</tr>";

                strHTML += "<tr>";
                strHTML += "<td width='118' align='center'>" + intLuotMuonVe.ToString() + "</td>";
                strHTML += "<td width='100' align='center'>" + intDauSachMuonVe.ToString() + "</td>";
                strHTML += "<td width='106' align='center'>" + intLuotMuonTaiCho.ToString() + "</td>";
                strHTML += "<td width='104' align='center'>" + intDauSachMuonTaiCho.ToString() + "</td>";
                strHTML += "<td width='141' align='center'>";
                strHTML += "<p align='center'>" + intTongLuotMuon.ToString() + "</td>";
                strHTML += "<td width='143' align='center'>";
                strHTML += "<p align='center'>" + intTongDauSachMuon.ToString() + "</td>";
                strHTML += "</tr>";

                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "<br>";
                strHTML += "Bình quân số lượng đầu sách phục vụ trong tuần &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : ";
                strHTML += Convert.ToString(intTongDauSachMuon) + "&nbsp;đầu sách/ 1 tuần<br>";
                strHTML += "Bình quân số lượng đầu sách phục vụ trong 1 ngày &nbsp;&nbsp; : ";
                int intDauSachPerNgay = 0;
                try
                {
                    intDauSachPerNgay = intTongDauSachMuon / intSoNgay;
                }
                catch{}
                strHTML += Convert.ToString(intDauSachPerNgay) + "&nbsp;đầu sách/ 1 ngày<br>";
                strHTML += "Bình quân số lượt đầu sách phục vụ trong tuần &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : ";
                strHTML += Convert.ToString(intTongLuotMuon) + "&nbsp;lượt bạn đọc/ 1 tuần<br>";
                strHTML += "Bình quân số lượt đầu sách phục vụ trong 1 ngày &nbsp;&nbsp;&nbsp;&nbsp; : ";
                int intLuotMuonPerNgay = 0;
                try
                {
                    intLuotMuonPerNgay = intTongDauSachMuon / intSoNgay;
                }
                catch { }
                strHTML += Convert.ToString(intLuotMuonPerNgay) + "&nbsp;lượt bạn đọc/ 1 ngày";

                strHTML += "</body>";
            }
            return strHTML;
        }
        //Tài liệu trễ hạn
        public string TreHan(DateTime dtTu, DateTime dtDen)
        {
            string strHTML = "";
            ReportDAO cls = new ReportDAO();
            DataTable dtSach = cls.SachTreHan(dtTu, dtDen);
            DataTable dtBTC = cls.BaoTCTreHan(dtTu, dtDen);
            if (cls.Error != "")
                strError = cls.Error;
            else
            {
                strHTML += "<body>";
                strHTML += "<table border='0' width='100%' id='table1' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr>";
                strHTML += "<td width='96%'><p align='center'><font size='5'><b>THỐNG KÊ TÀI LIỆU TRỄ HẠN</b></font></td>";
                strHTML += "</tr>";
                strHTML += "<tr><td width='96%'><p align='center'><font size='4'><b>Từ "+dtTu.ToShortDateString()+" đến "+dtDen.ToShortDateString()+"</b></font><br>&nbsp;</td></tr>";
                strHTML += "<tr><td width='96%'>";
                strHTML += "<table border='1' width='100%' id='table5' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td colspan='8'><b>Sách</b></td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td width='44' align='center' height='27'><b>STT</b></td>";
                strHTML += "<td width='89' height='27' align='center'><b>Số ĐKCB</b></td>";
                strHTML += "<td width='195' height='27' align='center'>";
                strHTML += "<p align='center'><b>Tựa sách</b></td>";
                strHTML += "<td width='113' height='27' align='center'><b>Ngày mượn</b></td>";
                strHTML += "<td width='117' height='27' align='center'><b>Số ngày mượn</b></td>";
                strHTML += "<td width='133' height='27' align='center'><b>Hình thức mượn</b></td>";
                strHTML += "<td width='120' height='27' align='center'><b>Mã đọc giả</b></td>";
                strHTML += "<td width='140' height='27' align='center'><p align='center'><b>Số ngày trễ hạn</b></td>";
                strHTML += "</tr>";

                int i = 1;
                foreach (DataRow dr in dtSach.Rows)
                {
                    strHTML += "<tr>";
                    strHTML += "<td width='44' align='center'>"+i++.ToString()+"</td>";
                    strHTML += "<td width='89' align='center'>"+dr["SoDKCB"]+"</td>";
                    strHTML += "<td width='195' align='center'>";
                    strHTML += "<p align='left'>"+dr["TenTS"].ToString()+"</td>";
                    strHTML += "<td width='113' align='center'>"+Convert.ToDateTime(dr["NgayMuon"]).ToShortDateString()+"</td>";
                    strHTML += "<td width='117' align='center'>"+dr["SoNgayMuon"].ToString()+"</td>";
                    strHTML += "<td width='133' align='center'>"+dr["LoaiPM"]+"</td>";
                    strHTML += "<td width='120' align='center'>"+dr["MaDG"].ToString()+"</td>";
                    strHTML += "<td width='110' align='center'>"+dr["SoNgayTre"].ToString()+"</td>";
                    strHTML += "</tr>";
                }
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "&nbsp;";
                strHTML += "<table border='0' width='100%' id='table8' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr><td width='96%'>";
                strHTML += "<table border='1' width='100%' id='table9' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td colspan='6'><b>Báo Tạp chí</b></td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td width='44' align='center' height='27'><b>STT</b></td>";
                strHTML += "<td width='284' height='27' align='center'><b>Tên Báo TC</b></td>";
                strHTML += "<td width='113' height='27' align='center'>";
                strHTML += "<p align='center'><b>Số phát hành</b></td>";
                strHTML += "<td width='143' height='27' align='center'><b>Ngày mượn</b></td>";
                strHTML += "<td width='211' height='27' align='center'><b>Mã đọc giả</b></td>";
                strHTML += "<td width='140' height='27' align='center'><p align='center'><b>Số ngày trễ hạn</b></td>";
                strHTML += "</tr>";

                i = 1;
                foreach (DataRow dr in dtBTC.Rows)
                {
                    strHTML += "<tr>";
                    strHTML += "<td width='44' align='center'>"+i++.ToString()+"</td>";
                    strHTML += "<td width='284' align='left'>"+dr["TenBTC"].ToString()+"</td>";
                    strHTML += "<td width='113' align='center'>";
                    strHTML += "<p align='left'>"+dr["SoPH"].ToString()+"</td>";
                    strHTML += "<td width='143' align='center'>"+Convert.ToDateTime(dr["NgayMuon"]).ToShortDateString()+"</td>";
                    strHTML += "<td width='211' align='center'>"+dr["MaDG"].ToString()+"</td>";
                    strHTML += "<td width='110' align='center'>"+dr["SoNgayTre"].ToString()+"</td>";
                    strHTML += "</tr>";
                }
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</body>";
            }
            return strHTML;
        }
        //Báo cáo sách yêu cầu
        public string SachYeuCau(DateTime dtTu, DateTime dtDen)
        {
            string strHTML = "";
            ReportDAO cls = new ReportDAO();
            DataTable dt = cls.SachYeuCau(dtTu, dtDen);
            if (cls.Error != "")
                strError = cls.Error;
            else
            {
                strHTML += "<body>";
                strHTML += "<table border='0' width='100%' id='table1' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr>";
                strHTML += "<td width='96%'><p align='center'><font size='5'><b>SÁCH YÊU CẦU</b></font></td>";
                strHTML += "</tr>";
                strHTML += "<tr><td width='96%'><p align='center'><font size='4'><b>Từ "+dtTu.ToShortDateString()+" đến "+dtDen.ToShortDateString()+"</b></font><br>&nbsp;</td></tr>";
                strHTML += "<tr><td width='96%'>";
                strHTML += "<table border='1' width='100%' id='table5' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td width='32' align='center' height='27'><b>STT</b></td>";
                strHTML += "<td width='243' height='27' align='center'><b>Tên sách</b></td>";
                strHTML += "<td width='139' height='27' align='center'>";
                strHTML += "<p align='center'><b>Tác giả</b></td>";
                strHTML += "<td width='113' height='27' align='center'><b>NXB</b></td>";
                strHTML += "<td width='71' height='27' align='center'><b>Giá bìa</b></td>";
                strHTML += "<td width='106' height='27' align='center'><b>MSSV</b></td>";
                strHTML += "<td width='223' height='27' align='center'><b>Thông tin thêm</b></td>";
                strHTML += "</tr>";
                int i = 1;               
                foreach (DataRow dr in dt.Rows)
                {
                    strHTML += "<tr>";
                    strHTML += "<td width='32' align='center'>"+i++.ToString()+"</td>";
                    strHTML += "<td width='243' align='center'>"+dr["TenSach"].ToString()+"</td>";
                    strHTML += "<td width='139' align='center'>";
                    strHTML += "<p align='left'>"+dr["TenTacGia"].ToString()+"</td>";
                    strHTML += "<td width='113' align='center'>&nbsp;" + dr["NhaXB"].ToString() + "</td>";
                    strHTML += "<td width='71' align='center'>&nbsp;" + dr["GiaBia"].ToString() + "</td>";
                    strHTML += "<td width='106' align='center'>"+dr["MSSV"].ToString()+"</td>";
                    strHTML += "<td width='223' align='center'>&nbsp;" + dr["ThongTinThem"].ToString() + "</td>";
                    strHTML += "</tr>";
                }
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</body>";
            }
            return strHTML;
        }
        //Sách mới
        public string SachMoi(int intYear)
        {
            string strHTML = "";
            ReportDAO cls = new ReportDAO();
            DataTable dt = cls.SachMoi(intYear);
            if (cls.Error != "")
                strError = cls.Error;
            else
            {
                strHTML += "<body>";
                strHTML += "<table border='0' width='100%' id='table1' cellspacing='0' cellpadding='0'>";
                strHTML += "<tr>";
                strHTML += "<td width='96%'><p align='center'><font size='5'><b>SÁCH MỚI</b></font></td>";
                strHTML += "</tr>";
                strHTML += "<tr><td width='96%'><p align='center'><font size='4'><b>Trong năm "+intYear.ToString()+"</b></font><br>&nbsp;</td></tr>";
                strHTML += "<tr><td width='96%'>";
                strHTML += "<table border='1' width='100%' id='table5' cellspacing='0' cellpadding='3'>";
                strHTML += "<tr>";
                strHTML += "<td width='32' align='center' height='27'><b>STT</b></td>";
                strHTML += "<td width='243' height='27' align='center'><b>Tên sách</b></td>";
                strHTML += "<td width='139' height='27' align='center'>";
                strHTML += "<p align='center'><b>Tác giả</b></td>";
                strHTML += "<td width='113' height='27' align='center'><b>NXB</b></td>";
                strHTML += "<td width='71' height='27' align='center'><b>Giá bìa</b></td>";
                //strHTML += "<td width='106' height='27' align='center'><b>Năm XB</b></td>";
                //strHTML += "<td width='223' height='27' align='center'><b>Lần tái bản</b></td>";
                strHTML += "</tr>";


                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    strHTML += "<tr>";
                    strHTML += "<td width='32' align='center'>" + i++.ToString() + "</td>";
                    strHTML += "<td width='243' align='left'>" + dr["TenTS"].ToString() + "</td>";
                    strHTML += "<td width='139' align='center'>";
                    DataTable dtTG = cls.TacGiabyTuaSach(Convert.ToInt32(dr["MaTS"]));
                    string strGiaBia = dr["GiaBia"].ToString();
                    if (dtTG.Rows.Count == 0)
                    {
                        dtTG = cls.TacGiaTap(Convert.ToInt32(dr["MaTS"]),Convert.ToInt32(dr["MaTap"]));
                    }
                    string strTacGia = "";
                    foreach (DataRow drTG in dtTG.Rows)
                    {
                        strTacGia += drTG["TenTG"].ToString() + "<br>";
                    }
                    strHTML += "<p align='left'>" + strTacGia + "</td>";
                    strHTML += "<td width='113' align='center'>" + dr["TenNXB"].ToString() + "</td>";
                    strHTML += "<td width='71' align='center'>&nbsp;" + dr["GiaBia"].ToString() + "</td>";
                    //strHTML += "<td width='106' align='center'>"+dr["NamXB"].ToString()+"</td>";
                    //strHTML += "<td width='223' align='center'>"+dr["LanTB"].ToString()+"</td>";
                    strHTML += "</tr>";
                }
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</body>";
            }
            return strHTML;
        }
    }
}
