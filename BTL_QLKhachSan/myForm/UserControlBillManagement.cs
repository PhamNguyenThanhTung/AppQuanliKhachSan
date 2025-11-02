using BTL_QLKhachSan.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; // Giữ nguyên Interop để xuất Excel

namespace BTL_QLKhachSan.myForm
{

    public partial class UserControlBillManagement : UserControl
    {
        // Giả sử có DataGridView cho Chi tiết Dịch vụ tên là dgvchitietdichvu
        // Nếu tên control của bạn khác, hãy thay thế dgvchitietdichvu bằng tên chính xác.
        // Giả sử tên control cho Tổng tiền ở Form là txttongtien
        private int currentIDPhieuThue = 0; // lưu phiếu thuê đang được tìm kiếm

        Database db = new Database();

        public UserControlBillManagement()
        {
            InitializeComponent();
        }

        private void UserControlBillManagement_Load(object sender, EventArgs e)
        {
            LoadBills();
            LoadRooms();
            LoadPaymentMethods();
            LoadPhieuThueToComboBox();
        }
        private void LoadPhieuThue(int idPhieuThue)
        {
            try
            {
                string sqlQuery = @"
        SELECT PT.IDPhieuThue, PT.NgayCheckIn, PT.NgayCheckOut, PT.NguoiTao,
            KH.IDKhachHang, KH.HoTen, KH.SoDienThoai, KH.CMND,
            P.IDPhong,
            LP.DonGiaNgay,
            ISNULL(SUM(CTDV.ThanhTien),0) AS TongTienDichVu,
            ISNULL(HD.GiamGiaTien,0) AS GiamGia,
            ISNULL(HD.TongTien,0) AS TongTien
        FROM PHIEUTHUE PT
        INNER JOIN KHACHHANG KH ON PT.IDKhachHang = KH.IDKhachHang
        INNER JOIN PHONG P ON PT.IDPhong = P.IDPhong
        INNER JOIN LOAIPHONG LP ON P.IDLoaiPhong = LP.IDLoaiPhong
        LEFT JOIN CHITIET_DICHVU CTDV ON PT.IDPhieuThue = CTDV.IDPhieuThue
        LEFT JOIN HOADON HD ON PT.IDPhieuThue = HD.IDPhieuThue
        WHERE PT.IDPhieuThue = @IDPhieuThue
            AND PT.TrangThai IN (N'Đã check-in', N'Đã check-out') 
        GROUP BY PT.IDPhieuThue, PT.NgayCheckIn, PT.NgayCheckOut, PT.NguoiTao,
                KH.IDKhachHang, KH.HoTen, KH.SoDienThoai, KH.CMND,
                P.IDPhong, LP.DonGiaNgay, HD.GiamGiaTien, HD.TongTien";

                var parameters = new List<SqlParameter> { new SqlParameter("@IDPhieuThue", idPhieuThue) };
                DataTable dt = db.GetData(sqlQuery, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    ClearForm();

                    txtmakh.Text = row["IDKhachHang"].ToString();
                    txttenkh.Text = row["HoTen"].ToString();
                    txtsodt.Text = row["SoDienThoai"].ToString();
                    txtcccd.Text = row["CMND"].ToString();
                    txtnvlap.Text = row["NguoiTao"].ToString();
                    dtpngaylap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    txttiendichvu.Text = ((decimal)row["TongTienDichVu"]).ToString("N0");
                    txtgiamgia.Text = ((decimal)row["GiamGia"]).ToString("N0");
                    txttongtien.Text = ((decimal)row["TongTien"]).ToString("N0");

                    // Tính tiền phòng
                    TinhTienPhong(row);

                    // Check phòng đúng
                    string idPhong = row["IDPhong"].ToString();
                    for (int i = 0; i < checklistboxphong.Items.Count; i++)
                        checklistboxphong.SetItemChecked(i, checklistboxphong.Items[i].ToString() == idPhong);

                    LoadDichVuForPhieuThue(idPhieuThue);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Phiếu Thuê hoặc Phiếu Thuê chưa thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
            }
        }


        // =================== LOAD CƠ BẢN ===================
        private void LoadBills()
        {
            dgvhoadonthanhtoan.Columns.Add("IDHoaDon", "Mã HĐ");
            dgvhoadonthanhtoan.Columns.Add("TenKhach", "TênKhách");
            dgvhoadonthanhtoan.Columns.Add("IDPhong", "Phòng");
            dgvhoadonthanhtoan.Columns.Add("NgayThanhToan", "Ngày TT");
            dgvhoadonthanhtoan.Columns.Add("TongTienPhong", "Tiền Phòng");
            dgvhoadonthanhtoan.Columns.Add("TongTienDichVu", "Tiền DV");
            dgvhoadonthanhtoan.Columns.Add("GiamGiaTien", "Giảm Giá");
            dgvhoadonthanhtoan.Columns.Add("TongTien", "Tổng TT");

        }

        private void LoadRooms()
        {
            try
            {
                DataTable dt = db.GetData("SELECT IDPhong FROM PHONG ORDER BY IDPhong");
                checklistboxphong.Items.Clear();
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                        checklistboxphong.Items.Add(r["IDPhong"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng: " + ex.Message);
            }
        }

        private void LoadPaymentMethods()
        {
            cbhinhthucthanhtoan.Items.Clear();
            cbhinhthucthanhtoan.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ" });
            cbhinhthucthanhtoan.SelectedIndex = 0;
        }

        // =================== LẤY DỮ LIỆU BÁO CÁO CHI TIẾT (Cho Excel) ===================
        private DataTable LayDuLieuBaoCao(int idHoaDon)
        {
            string sqlReport = @"
                SELECT 
                    HD.IDHoaDon, HD.IDPhieuThue, HD.NguoiLap, HD.NgayThanhToan, HD.TongTienPhong, HD.TongTienDichVu, HD.GiamGiaTien, HD.TongTien,
                    PT.NgayCheckIn, PT.NgayCheckOut, P.IDPhong, 
                    (SELECT HoTen FROM KHACHHANG WHERE IDKhachHang = PT.IDKhachHang) AS TenKhach, 
                    (SELECT DisplayName FROM TAIKHOAN WHERE Username = HD.NguoiLap) AS TenNV,
                    
                    CTDV.SoLuong, 
                    CTDV.ThanhTien,
                    DV.TenDichVu,
                    DV.DonGia 
                    
                FROM HOADON HD
                INNER JOIN PHIEUTHUE PT ON HD.IDPhieuThue = PT.IDPhieuThue
                INNER JOIN PHONG P ON PT.IDPhong = P.IDPhong
                
                LEFT JOIN CHITIET_DICHVU CTDV ON PT.IDPhieuThue = CTDV.IDPhieuThue
                LEFT JOIN DICHVU DV ON CTDV.IDDichVu = DV.IDDichVu 
                
                WHERE HD.IDHoaDon = @IDHoaDon";

            var parameters = new List<SqlParameter> { new SqlParameter("@IDHoaDon", idHoaDon) };
            return db.GetData(sqlReport, parameters);
        }

        // =================== TÌM KIẾM PHIẾU THUÊ ===================
        private void LoadPhieuThueToComboBox()
        {
            try
            {
                string sql = @"
            SELECT IDPhieuThue
            FROM PHIEUTHUE
            WHERE TrangThai IN (N'Đã check-in', N'Đã check-out')
            ORDER BY IDPhieuThue DESC";

                DataTable dt = db.GetData(sql);

                cbtimkiem.Items.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        cbtimkiem.Items.Add(r["IDPhieuThue"].ToString());
                    }

                    // Gợi ý: có thể để auto complete
                    cbtimkiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbtimkiem.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(cbtimkiem.Text, out int idPhieuThue))
            {
                MessageBox.Show("Mã Phiếu Thuê không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sqlQuery = @"
                SELECT PT.IDPhieuThue, PT.NgayCheckIn, PT.NgayCheckOut, PT.NguoiTao,
                       KH.IDKhachHang, KH.HoTen, KH.SoDienThoai, KH.CMND,
                       P.IDPhong,
                       LP.DonGiaNgay,
                       ISNULL(SUM(CTDV.ThanhTien),0) AS TongTienDichVu
                FROM PHIEUTHUE PT
                INNER JOIN KHACHHANG KH ON PT.IDKhachHang = KH.IDKhachHang
                INNER JOIN PHONG P ON PT.IDPhong = P.IDPhong
                INNER JOIN LOAIPHONG LP ON P.IDLoaiPhong = LP.IDLoaiPhong
                LEFT JOIN CHITIET_DICHVU CTDV ON PT.IDPhieuThue = CTDV.IDPhieuThue
                WHERE PT.IDPhieuThue = @IDPhieuThue
                  AND PT.TrangThai IN (N'Đã check-in', N'Đã check-out') 
                GROUP BY PT.IDPhieuThue, PT.NgayCheckIn, PT.NgayCheckOut, PT.NguoiTao,
                         KH.IDKhachHang, KH.HoTen, KH.SoDienThoai, KH.CMND,
                         P.IDPhong, LP.DonGiaNgay";

                var parameters = new List<SqlParameter> { new SqlParameter("@IDPhieuThue", idPhieuThue) };
                DataTable dt = db.GetData(sqlQuery, parameters);

                dgvhoadonthanhtoan.Rows.Clear(); // Xóa dữ liệu cũ

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    ClearForm();

                    // Điền các TextBox
                    txtmahd.Text = row["IDPhieuThue"].ToString();
                    txtmakh.Text = row["IDKhachHang"].ToString();
                    txttenkh.Text = row["HoTen"].ToString();
                    txtsodt.Text = row["SoDienThoai"].ToString();
                    txtcccd.Text = row["CMND"].ToString();
                    txtnvlap.Text = row["NguoiTao"].ToString();
                    dtpngaylap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    txttiendichvu.Text = ((decimal)row["TongTienDichVu"]).ToString("N0");

                    // Tính tiền phòng và tổng
                    TinhTienPhong(row);

                    // Check phòng đúng
                    checklistboxphong.Items.Clear(); // Xóa tất cả
                    string idPhong = row["IDPhong"].ToString();
                    checklistboxphong.Items.Add(idPhong);
                    checklistboxphong.SetItemChecked(0, true);

                    // Thêm dữ liệu vào DataGridView dgvhoadonthanhtoan
                    dgvhoadonthanhtoan.Rows.Add(
                        idPhieuThue,
                        row["HoTen"],
                        idPhong,
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm"), // Ngày TT (tạm thời)
                        txttienphong.Text,
                        txttiendichvu.Text,
                        txtgiamgia.Text,
                        txttongtien.Text
                    );
                    currentIDPhieuThue = idPhieuThue; // lưu lại để dùng cho sửa
                    LoadPhieuThue(idPhieuThue);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Phiếu Thuê hoặc Phiếu Thuê chưa thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
            }
        }


        // =================== TÍNH TIỀN PHÒNG ===================
        private void TinhTienPhong(DataRow row)
        {
            DateTime checkIn = (DateTime)row["NgayCheckIn"];
            decimal donGiaNgay = (decimal)row["DonGiaNgay"];
            // Sử dụng DateTime.Now nếu chưa có ngày CheckOut, đây là logic lập HĐ
            DateTime checkOut = row["NgayCheckOut"] != DBNull.Value ? (DateTime)row["NgayCheckOut"] : DateTime.Now;

            TimeSpan thoiGian = checkOut - checkIn;
            decimal tongTienPhong;

            if (thoiGian.TotalDays < 1)
            {
                // Tính theo giờ (giả định 1 ngày = 24 giờ)
                tongTienPhong = donGiaNgay * (decimal)thoiGian.TotalHours / 24;
            }
            else
            {
                // Tính theo số ngày làm tròn lên
                tongTienPhong = donGiaNgay * (int)Math.Ceiling(thoiGian.TotalDays);
            }

            txttienphong.Text = tongTienPhong.ToString("N0");
            TinhTongThanhToan(tongTienPhong);
        }

        // =================== TÍNH TỔNG THANH TOÁN (Đã FIX LỖI ĐỊNH DẠNG) ===================
        private void TinhTongThanhToan(decimal tongTienPhong)
        {
            decimal tongDV = 0;
            decimal giamGia = 0;

            // ⭐ FIX LỖI: Chuẩn hóa chuỗi trước khi TryParse để tránh lỗi định dạng số
            string dvText = txttiendichvu.Text.Replace(".", "").Replace(",", "");
            string ggText = txtgiamgia.Text.Replace(".", "").Replace(",", "");

            decimal.TryParse(dvText, NumberStyles.Any, CultureInfo.InvariantCulture, out tongDV);
            decimal.TryParse(ggText, NumberStyles.Any, CultureInfo.InvariantCulture, out giamGia);

            decimal tongThanhToan = tongTienPhong + tongDV - giamGia;

            txttongtien.Text = tongThanhToan.ToString("N0");
        }

        // =================== LOAD DỊCH VỤ (Đã FIX LỖI GHI ĐÈ) ===================
        private void LoadDichVuForPhieuThue(int idPhieuThue)
        {
            try
            {
                string sql = @"
                    SELECT DV.TenDichVu, ISNULL(CTDV.SoLuong,0) AS SoLuong,
                           ISNULL(DV.DonGia,0) AS DonGia, ISNULL(CTDV.ThanhTien,0) AS ThanhTien
                    FROM CHITIET_DICHVU CTDV
                    INNER JOIN DICHVU DV ON CTDV.IDDichVu = DV.IDDichVu
                    WHERE CTDV.IDPhieuThue = @IDPhieuThue";

                var parameters = new List<SqlParameter> { new SqlParameter("@IDPhieuThue", idPhieuThue) };
                DataTable dt = db.GetData(sql, parameters);

                // ⭐ FIX LỖI: Gán vào DataGridView Chi tiết (Giả sử tên là dgvchitietdichvu)
                // (Nếu bạn không có DataGridView chi tiết, bạn có thể comment dòng này)
                // dgvchitietdichvu.DataSource = dt; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách dịch vụ: " + ex.Message);
                // dgvchitietdichvu.DataSource = null;
            }
        }

        // =================== XÓA FORM ===================
        private void ClearForm()
        {
            cbtimkiem.Text = "";
            txtmakh.Text = txttenkh.Text = txtsodt.Text = txtcccd.Text = "";

            for (int i = 0; i < checklistboxphong.Items.Count; i++)
            {
                checklistboxphong.SetItemChecked(i, false);
            }
            dtpngaylap.Text = txtnvlap.Text = "";
            txttienphong.Text = txttiendichvu.Text = txtgiamgia.Text = txttongtien.Text = "0";

            cbhinhthucthanhtoan.SelectedIndex = 0;
            // Giả sử tên control là txtghichu
            // txtghichu.Text = ""; 

            // dgvchitietdichvu.DataSource = null; // Xóa chi tiết dịch vụ
        }

        // =================== LẬP HÓA ĐƠN VÀ IN (btninhoadon_Click) ===================
        private void btninhoadon_Click(object sender, EventArgs e)
        {
            if (currentIDPhieuThue == 0)
            {
                MessageBox.Show("Vui lòng tìm Phiếu Thuê hợp lệ trước khi lập hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idPhieuThue = currentIDPhieuThue;

            // 1. Lấy và kiểm tra các giá trị trên form (ĐÃ FIX LỖI ĐỊNH DẠNG)
            decimal tongTienPhong = 0, tongTienDichVu = 0, giamGia = 0, tongTienThanhToan = 0;

            // ⭐ FIX LỖI: Chuẩn hóa chuỗi trước khi TryParse
            string tpText = txttienphong.Text.Replace(".", "").Replace(",", "");
            string dvText = txttiendichvu.Text.Replace(".", "").Replace(",", "");
            string ggText = txtgiamgia.Text.Replace(".", "").Replace(",", "");
            string ttText = txttongtien.Text.Replace(".", "").Replace(",", "");

            decimal.TryParse(tpText, NumberStyles.Any, CultureInfo.InvariantCulture, out tongTienPhong);
            decimal.TryParse(dvText, NumberStyles.Any, CultureInfo.InvariantCulture, out tongTienDichVu);
            decimal.TryParse(ggText, NumberStyles.Any, CultureInfo.InvariantCulture, out giamGia);
            decimal.TryParse(ttText, NumberStyles.Any, CultureInfo.InvariantCulture, out tongTienThanhToan);

            string phuongThuc = cbhinhthucthanhtoan.SelectedItem?.ToString() ?? "Tiền mặt";
            // string ghiChu = txtghichu.Text; // Giả sử tên control là txtghichu
            string ghiChu = ""; // Sử dụng chuỗi rỗng nếu không tìm thấy control
            string nguoiLap = txtnvlap.Text;

            if (tongTienThanhToan <= 0)
            {
                MessageBox.Show("Tổng tiền thanh toán không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // BƯỚC 1: LƯU HOÁ ĐƠN VÀ CẬP NHẬT TRẠNG THÁI
                string sqlCheck = "SELECT IDHoaDon FROM HOADON WHERE IDPhieuThue = @IDPhieuThue";
                var checkParam = new List<SqlParameter> { new SqlParameter("@IDPhieuThue", idPhieuThue) };
                DataTable dtCheck = db.GetData(sqlCheck, checkParam);

                int existingHoaDonId = (dtCheck != null && dtCheck.Rows.Count > 0) ? Convert.ToInt32(dtCheck.Rows[0][0]) : 0;

                int finalHoaDonId;
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IDPhieuThue", idPhieuThue),
                    new SqlParameter("@NguoiLap", nguoiLap),
                    new SqlParameter("@TongTienPhong", tongTienPhong),
                    new SqlParameter("@TongTienDichVu", tongTienDichVu),
                    new SqlParameter("@GiamGia", giamGia),
                    new SqlParameter("@PhuongThuc", phuongThuc),
                    new SqlParameter("@TongTien", tongTienThanhToan),
                    new SqlParameter("@GhiChu", ghiChu),
                    new SqlParameter("@NgayThanhToan", DateTime.Now)
                };

                if (existingHoaDonId > 0)
                {
                    // Cập nhật hóa đơn
                    string sqlUpdate = @"
                        UPDATE HOADON SET NgayThanhToan = @NgayThanhToan, NguoiLap = @NguoiLap, 
                        TongTienPhong = @TongTienPhong, TongTienDichVu = @TongTienDichVu, 
                        GiamGiaTien = @GiamGia, PhuongThucThanhToan = @PhuongThuc, 
                        TongTien = @TongTien, GhiChu = @GhiChu
                        WHERE IDHoaDon = @IDHoaDon";
                    parameters.Add(new SqlParameter("@IDHoaDon", existingHoaDonId));
                    db.ExecuteNonQuery(sqlUpdate, parameters);
                    finalHoaDonId = existingHoaDonId;
                }
                else
                {
                    // Thêm mới hóa đơn
                    string sqlInsert = @"
                        INSERT INTO HOADON (IDPhieuThue, NguoiLap, NgayThanhToan, TongTienPhong, TongTienDichVu, GiamGiaTien, PhuongThucThanhToan, TongTien, GhiChu)
                        OUTPUT INSERTED.IDHoaDon 
                        VALUES (@IDPhieuThue, @NguoiLap, @NgayThanhToan, @TongTienPhong, @TongTienDichVu, @GiamGia, @PhuongThuc, @TongTien, @GhiChu)";

                    DataTable dtInsert = db.GetData(sqlInsert, parameters);
                    finalHoaDonId = (dtInsert != null && dtInsert.Rows.Count > 0) ? Convert.ToInt32(dtInsert.Rows[0][0]) : 0;
                }

                // Cập nhật trạng thái Phiếu thuê và Phòng (Check-out)
                string sqlCapNhatTT = @"
                    UPDATE PHIEUTHUE SET TrangThai = N'Đã check-out', NgayCheckOut = GETDATE() WHERE IDPhieuThue = @IDPhieuThue;
                    UPDATE PHONG SET TrangThai = N'Dọn dẹp' WHERE IDPhong = (SELECT IDPhong FROM PHIEUTHUE WHERE IDPhieuThue = @IDPhieuThue)";

                var paramTT = new List<SqlParameter> { new SqlParameter("@IDPhieuThue", idPhieuThue) };
                db.ExecuteNonQuery(sqlCapNhatTT, paramTT);


                // BƯỚC 2: LẤY DỮ LIỆU VÀ XUẤT EXCEL
                DataTable dtExcel = LayDuLieuBaoCao(finalHoaDonId);

                if (dtExcel != null && dtExcel.Rows.Count > 0)
                {
                    MessageBox.Show($"Lập hóa đơn {finalHoaDonId} thành công! Bắt đầu xuất file Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XuatExcelInterop(dtExcel);
                    ClearForm();
                    LoadBills(); // Tải lại danh sách hóa đơn
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể lấy dữ liệu chi tiết cho báo cáo Excel. Hóa đơn đã được lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lập hóa đơn hoặc xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =================== XUẤT EXCEL (Interop) ===================
        private void XuatExcelInterop(DataTable dtReport)
        {
            if (dtReport == null || dtReport.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                xlWorkSheet.Name = "HÓA ĐƠN";

                // Tiêu đề
                xlWorkSheet.Range["A1", "E1"].Merge();
                xlWorkSheet.Cells[1, 1] = "HOÁ ĐƠN THANH TOÁN KHÁCH SẠN";
                xlWorkSheet.Cells[1, 1].Font.Bold = true;
                xlWorkSheet.Cells[1, 1].Font.Size = 16;
                xlWorkSheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                int row = 3;
                DataRow hdRow = dtReport.Rows[0];
                xlWorkSheet.Cells[row, 1] = "Mã Hóa Đơn:"; xlWorkSheet.Cells[row++, 2] = hdRow["IDHoaDon"];

                // ⭐ CẢI TIẾN: Định dạng ngày giờ
                xlWorkSheet.Cells[row, 1] = "Ngày Thanh Toán:";
                xlWorkSheet.Cells[row++, 2] = ((DateTime)hdRow["NgayThanhToan"]).ToString("dd/MM/yyyy HH:mm");

                xlWorkSheet.Cells[row, 1] = "Tên Khách Hàng:"; xlWorkSheet.Cells[row++, 2] = hdRow["TenKhach"];
                xlWorkSheet.Cells[row, 1] = "Phòng:"; xlWorkSheet.Cells[row++, 2] = hdRow["IDPhong"];
                xlWorkSheet.Cells[row, 1] = "Nhân viên lập:"; xlWorkSheet.Cells[row++, 2] = hdRow["TenNV"];

                // Chi tiết dịch vụ
                int detailStart = row + 1;
                xlWorkSheet.Cells[detailStart, 1] = "STT";
                xlWorkSheet.Cells[detailStart, 2] = "Tên Dịch Vụ";
                xlWorkSheet.Cells[detailStart, 3] = "Số Lượng";
                xlWorkSheet.Cells[detailStart, 4] = "Đơn Giá";
                xlWorkSheet.Cells[detailStart, 5] = "Thành Tiền";
                xlWorkSheet.Range[xlWorkSheet.Cells[detailStart, 1], xlWorkSheet.Cells[detailStart, 5]].Font.Bold = true;
                xlWorkSheet.Range[xlWorkSheet.Cells[detailStart, 1], xlWorkSheet.Cells[detailStart, 5]].Interior.Color = Color.LightGray;

                int stt = 1;
                row = detailStart + 1;

                foreach (DataRow dr in dtReport.Rows)
                {
                    if (dr["TenDichVu"] != DBNull.Value)
                    {
                        xlWorkSheet.Cells[row, 1] = stt++;
                        xlWorkSheet.Cells[row, 2] = dr["TenDichVu"];
                        xlWorkSheet.Cells[row, 3] = dr["SoLuong"];
                        xlWorkSheet.Cells[row, 4] = dr["DonGia"];
                        xlWorkSheet.Cells[row, 5] = dr["ThanhTien"];

                        // Định dạng tiền tệ
                        xlWorkSheet.Cells[row, 4].NumberFormat = "#,##0";
                        xlWorkSheet.Cells[row, 5].NumberFormat = "#,##0";
                        row++;
                    }
                }

                // Tổng kết
                row += 1;
                xlWorkSheet.Cells[row, 3] = "Tổng Tiền Phòng:"; xlWorkSheet.Cells[row++, 5] = hdRow["TongTienPhong"];
                xlWorkSheet.Cells[row, 3] = "Tổng Tiền Dịch Vụ:"; xlWorkSheet.Cells[row++, 5] = hdRow["TongTienDichVu"];
                xlWorkSheet.Cells[row, 3] = "Giảm Giá:"; xlWorkSheet.Cells[row++, 5] = hdRow["GiamGiaTien"];

                xlWorkSheet.Cells[row, 3] = "TỔNG THANH TOÁN:";
                xlWorkSheet.Cells[row, 3].Font.Bold = true;
                xlWorkSheet.Cells[row, 5] = hdRow["TongTien"];
                xlWorkSheet.Cells[row, 5].Font.Bold = true;

                // Định dạng tiền tệ cho Tổng kết
                xlWorkSheet.Cells[row - 3, 5].NumberFormat = "#,##0";
                xlWorkSheet.Cells[row - 2, 5].NumberFormat = "#,##0";
                xlWorkSheet.Cells[row - 1, 5].NumberFormat = "#,##0";
                xlWorkSheet.Cells[row, 5].NumberFormat = "#,##0";


                xlWorkSheet.Columns.AutoFit();

                // Hiển thị Excel
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Không nên gọi Quit/Release Com Object ở đây nếu muốn Excel hiện lên
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (currentIDPhieuThue == 0)
            {
                MessageBox.Show("Vui lòng tìm Phiếu Thuê trước khi sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy các giá trị trên form
                string nguoiLap = txtnvlap.Text.Trim();
                string hinhThucTT = cbhinhthucthanhtoan.SelectedItem?.ToString() ?? "Tiền mặt";

                // Chuẩn hóa các số trước khi parse
                string tpText = txttienphong.Text.Replace(".", "").Replace(",", "");
                string dvText = txttiendichvu.Text.Replace(".", "").Replace(",", "");
                string ggText = txtgiamgia.Text.Replace(".", "").Replace(",", "");
                string ttText = txttongtien.Text.Replace(".", "").Replace(",", "");

                decimal tienPhong = 0, tienDV = 0, giamGia = 0, tongTien = 0;
                decimal.TryParse(tpText, NumberStyles.Any, CultureInfo.InvariantCulture, out tienPhong);
                decimal.TryParse(dvText, NumberStyles.Any, CultureInfo.InvariantCulture, out tienDV);
                decimal.TryParse(ggText, NumberStyles.Any, CultureInfo.InvariantCulture, out giamGia);
                decimal.TryParse(ttText, NumberStyles.Any, CultureInfo.InvariantCulture, out tongTien);

                // Kiểm tra tổng tiền
                if (tongTien <= 0)
                {
                    MessageBox.Show("Tổng tiền thanh toán không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm IDHoaDon tương ứng (nếu có) để cập nhật chính xác theo IDHoaDon thay vì IDPhieuThue
                string sqlFindHoaDon = "SELECT IDHoaDon FROM HOADON WHERE IDPhieuThue = @IDPhieuThue";
                var findParams = new List<SqlParameter> { new SqlParameter("@IDPhieuThue", currentIDPhieuThue) };
                DataTable dtFind = db.GetData(sqlFindHoaDon, findParams);

                bool haveHoaDon = (dtFind != null && dtFind.Rows.Count > 0);
                int idHoaDon = haveHoaDon ? Convert.ToInt32(dtFind.Rows[0][0]) : 0;

                string sqlUpdate;
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@NguoiLap", nguoiLap),
                    new SqlParameter("@PhuongThuc", hinhThucTT),
                    new SqlParameter("@TongTienPhong", tienPhong),
                    new SqlParameter("@TongTienDichVu", tienDV),
                    new SqlParameter("@GiamGia", giamGia),
                    new SqlParameter("@TongTien", tongTien)
                };

                if (haveHoaDon)
                {
                    // Cập nhật theo IDHoaDon (an toàn hơn nếu có nhiều bản ghi)
                    sqlUpdate = @"
                        UPDATE HOADON
                        SET NguoiLap = @NguoiLap,
                            PhuongThucThanhToan = @PhuongThuc,
                            TongTienPhong = @TongTienPhong,
                            TongTienDichVu = @TongTienDichVu,
                            GiamGiaTien = @GiamGia,
                            TongTien = @TongTien
                        WHERE IDHoaDon = @IDHoaDon";
                    parameters.Add(new SqlParameter("@IDHoaDon", idHoaDon));
                }
                else
                {
                    // Nếu chưa có hóa đơn (thường không xảy ra khi đã lập trước), cập nhật theo IDPhieuThue
                    sqlUpdate = @"
                        UPDATE HOADON
                        SET NguoiLap = @NguoiLap,
                            PhuongThucThanhToan = @PhuongThuc,
                            TongTienPhong = @TongTienPhong,
                            TongTienDichVu = @TongTienDichVu,
                            GiamGiaTien = @GiamGia,
                            TongTien = @TongTien
                        WHERE IDPhieuThue = @IDPhieuThue";
                    parameters.Add(new SqlParameter("@IDPhieuThue", currentIDPhieuThue));
                }

                db.ExecuteNonQuery(sqlUpdate, parameters);

                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload dữ liệu lên form để hiển thị giá trị mới
                LoadPhieuThue(currentIDPhieuThue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}