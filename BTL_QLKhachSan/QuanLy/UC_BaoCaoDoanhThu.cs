using BTL_QLKhachSan.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BTL_QLKhachSan.myForm
{
    public partial class UC_BaoCaoDoanhThu : UserControl
    {
        Database db = new Database();

        public UC_BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void UC_BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định: từ đầu tháng đến ngày hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            // Cấu hình ban đầu cho các biểu đồ
            ConfigureCharts();
        }

        private void ConfigureCharts()
        {
            // Cấu hình chart tổng hợp (Tab 1)
            chartDoanhThuTheoThoiGian.Series["DoanhThu"].ChartType = SeriesChartType.Column;
            chartDoanhThuTheoThoiGian.ChartAreas[0].AxisX.Title = "Thời gian";
            chartDoanhThuTheoThoiGian.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";
            chartDoanhThuTheoThoiGian.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}";
            chartDoanhThuTheoThoiGian.Legends[0].Enabled = false;

            // Cấu hình chart loại phòng (Tab 2)
            chartLoaiPhong.Series["LoaiPhong"].ChartType = SeriesChartType.Pie;
            chartLoaiPhong.Series["LoaiPhong"].IsValueShownAsLabel = true;
            // Sửa lỗi hiển thị %
            chartLoaiPhong.Series["LoaiPhong"].Label = "#PERCENT{P1}"; 
            chartLoaiPhong.Legends[0].Docking = Docking.Bottom;
            chartLoaiPhong.Series["LoaiPhong"]["PieLabelStyle"] = "Outside";
            chartLoaiPhong.Series["LoaiPhong"].ToolTip = "#VALX: #VALY{N0} VND (#PERCENT{P1})";

            // Cấu hình chart dịch vụ (Tab 2)
            chartDichVu.Series["DichVu"].ChartType = SeriesChartType.Bar;
            chartDichVu.ChartAreas[0].AxisX.Title = "Doanh thu (VND)";
            chartDichVu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:N0}";
            chartDichVu.ChartAreas[0].AxisY.Title = "Dịch Vụ";
            chartDichVu.Legends[0].Enabled = false;
        }

        // === Sự kiện click nút LỌC DỮ LIỆU (quan trọng nhất) ===
        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1); // Lấy đến cuối ngày

            if (tuNgay >= denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor; // Hiển thị con trỏ chờ

                // Tải dữ liệu cho cả 2 tab
                LoadDataTab1_TongHop(tuNgay, denNgay);
                LoadDataTab2_PhanTich(tuNgay, denNgay);

                // Tải dữ liệu cho panel thống kê
                LoadDataThongKeNhanh(tuNgay, denNgay);
                
                Cursor = Cursors.Default; // Trả lại con trỏ
                MessageBox.Show("Đã tải xong báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Xử lý cho Tab 1: Doanh thu Tổng hợp ---
        private void LoadDataTab1_TongHop(DateTime tuNgay, DateTime denNgay)
        {
            string query = "";
            string groupBy = "";
            string selectFormat = "";
            string labelFormat = "dd/MM/yyyy";
            var chartType = SeriesChartType.Column;

            if (rbTheoNgay.Checked)
            {
                selectFormat = "CONVERT(date, h.NgayThanhToan)";
                groupBy = "CONVERT(date, h.NgayThanhToan)";
                labelFormat = "dd/MM";
            }
            else if (rbTheoThang.Checked)
            {
                selectFormat = "FORMAT(h.NgayThanhToan, 'yyyy-MM')";
                groupBy = "FORMAT(h.NgayThanhToan, 'yyyy-MM')";
                labelFormat = "MM/yyyy";
                chartType = SeriesChartType.Line;
            }
            else // rbTheoNam
            {
                selectFormat = "YEAR(h.NgayThanhToan)";
                groupBy = "YEAR(h.NgayThanhToan)";
                labelFormat = "yyyy";
            }

            query = $"SELECT {selectFormat} AS ThoiGian, SUM(h.TongTien) AS DoanhThu " +
                    $"FROM HOADON h " +
                    $"WHERE h.NgayThanhToan >= @tuNgay AND h.NgayThanhToan < @denNgay ";
            
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay)
            };

            query += $"GROUP BY {groupBy} ORDER BY ThoiGian";

            DataTable dtChart = db.GetData(query, parameters);

            // Cập nhật biểu đồ
            chartDoanhThuTheoThoiGian.Series["DoanhThu"].Points.Clear();
            chartDoanhThuTheoThoiGian.Series["DoanhThu"].ChartType = chartType;
            chartDoanhThuTheoThoiGian.ChartAreas[0].AxisX.LabelStyle.Format = labelFormat;

            foreach (DataRow row in dtChart.Rows)
            {
                string thoiGian = row["ThoiGian"].ToString();
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);

                DataPoint dp = new DataPoint();
                dp.AxisLabel = thoiGian;
                dp.SetValueY((double)doanhThu);
                dp.ToolTip = $"{thoiGian}: {doanhThu:N0} VND";
                chartDoanhThuTheoThoiGian.Series["DoanhThu"].Points.Add(dp);
            }
        }

        // Sự kiện khi thay đổi RadioButton
        private void rbKieuBaoCao_CheckedChanged(object sender, EventArgs e)
        {
            if (chartDoanhThuTheoThoiGian.Series["DoanhThu"].Points.Count > 0)
            {
                // Nếu đã có dữ liệu, chạy lại lọc cho tab 1
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);
                LoadDataTab1_TongHop(tuNgay, denNgay);
            }
        }

        // --- Xử lý cho Tab 2: Phân tích Phòng & Dịch vụ ---
        private void LoadDataTab2_PhanTich(DateTime tuNgay, DateTime denNgay)
        {
            // 1. Tải biểu đồ Loại Phòng
            string queryLoaiPhong = "SELECT lp.TenLoaiPhong, SUM(h.TongTien) AS DoanhThuPhong " +
                                    "FROM HOADON h " +
                                    "JOIN PHIEUTHUE pt ON h.IDPhieuThue = pt.IDPhieuThue " +
                                    "JOIN PHONG p ON pt.IDPhong = p.IDPhong " +
                                    "JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong " +
                                    "WHERE h.NgayThanhToan >= @tuNgay AND h.NgayThanhToan < @denNgay " +
                                    "GROUP BY lp.TenLoaiPhong";

            List<SqlParameter> paramsLoaiPhong = new List<SqlParameter>
            {
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay)
            };

            DataTable dtLoaiPhong = db.GetData(queryLoaiPhong, paramsLoaiPhong);
            chartLoaiPhong.Series["LoaiPhong"].Points.Clear();
            
            foreach (DataRow row in dtLoaiPhong.Rows)
            {
                string ten = row["TenLoaiPhong"].ToString();
                decimal doanhThu = Convert.ToDecimal(row["DoanhThuPhong"]);
                
                DataPoint dp = new DataPoint(0, (double)doanhThu);
                dp.LegendText = ten; // Hiển thị "Deluxe", "Suite" ở chú thích
                dp.SetValueY((double)doanhThu);
                chartLoaiPhong.Series["LoaiPhong"].Points.Add(dp);
            }

            // 2. Tải biểu đồ Dịch vụ
            string queryDichVu = "SELECT dv.TenDichVu, SUM(ct.ThanhTien) AS DoanhThuDV " +
                                 "FROM CHITIET_DICHVU ct " +
                                 "JOIN DICHVU dv ON ct.IDDichVu = dv.IDDichVu " +
                                 "JOIN PHIEUTHUE pt ON ct.IDPhieuThue = pt.IDPhieuThue " +
                                 "JOIN HOADON h ON pt.IDPhieuThue = h.IDPhieuThue " + 
                                 "WHERE h.NgayThanhToan >= @tuNgay AND h.NgayThanhToan < @denNgay " +
                                 "GROUP BY dv.TenDichVu ORDER BY DoanhThuDV DESC";
            
            List<SqlParameter> paramsDichVu = new List<SqlParameter>
            {
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay)
            };
            
            DataTable dtDichVu = db.GetData(queryDichVu, paramsDichVu);
            chartDichVu.Series["DichVu"].Points.Clear();
            foreach (DataRow row in dtDichVu.Rows)
            {
                string ten = row["TenDichVu"].ToString();
                decimal doanhThu = Convert.ToDecimal(row["DoanhThuDV"]);
                DataPoint dp = new DataPoint();
                dp.AxisLabel = ten;
                dp.SetValueY((double)doanhThu);
                dp.ToolTip = $"{ten}: {doanhThu:N0} VND";
                chartDichVu.Series["DichVu"].Points.Add(dp);
            }
        }

        // --- Xử lý cho Panel Thống Kê Nhanh (ở dưới cùng) ---
        private void LoadDataThongKeNhanh(DateTime tuNgay, DateTime denNgay)
        {
            string query = "SELECT COUNT(IDHoaDon) AS SoHoaDon, SUM(TongTien) AS TongDoanhThu " +
                           "FROM HOADON h " +
                           "WHERE h.NgayThanhToan >= @tuNgay AND h.NgayThanhToan < @denNgay ";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay)
            };

            DataTable dt = db.GetData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                int soHoaDon = (row["SoHoaDon"] != DBNull.Value) ? Convert.ToInt32(row["SoHoaDon"]) : 0;
                decimal tongDoanhThu = (row["TongDoanhThu"] != DBNull.Value) ? Convert.ToDecimal(row["TongDoanhThu"]) : 0;
                decimal trungBinh = (soHoaDon > 0) ? (tongDoanhThu / soHoaDon) : 0;

                // Cập nhật Lables
                lblTongDoanhThu.Text = string.Format("Tổng doanh thu: {0:N0} VND", tongDoanhThu);
                lblSoHoaDon.Text = string.Format("Số hóa đơn: {0}", soHoaDon);
                lblTrungBinh.Text = string.Format("Trung bình / hóa đơn: {0:N0} VND", trungBinh);
            }
            else
            {
                // Xử lý trường hợp không có dữ liệu
                lblTongDoanhThu.Text = "Tổng doanh thu: 0 VND";
                lblSoHoaDon.Text = "Số hóa đơn: 0";
                lblTrungBinh.Text = "Trung bình / hóa đơn: 0 VND";
            }
        }

        
    }
}