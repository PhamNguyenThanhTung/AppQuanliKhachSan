using BTL_QLKhachSan.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Đảm bảo bạn đã thêm Reference: System.Windows.Forms.DataVisualization
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

            // Cấu hình ban đầu cho biểu đồ
            ConfigureChart();
        }

        private void ConfigureChart()
        {
            // Thiết lập loại biểu đồ (Column, Line, Pie...)
            chartDoanhThu.Series["DoanhThu"].ChartType = SeriesChartType.Column;
            
            // Tùy chỉnh trục X (Trục ngày)
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.Enabled = false; // Tắt lưới dọc
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1; // Hiển thị mỗi 1 nhãn
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM"; // Định dạng ngày

            // Tùy chỉnh trục Y (Trục doanh thu)
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}"; // Định dạng số (1,000,000)

            // Tắt chú giải (Legend) nếu chỉ có 1 series
            chartDoanhThu.Legends[0].Enabled = false;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date; // Lấy ngày, bỏ qua giờ
            
            // Khi lấy "Đến ngày", ta cần lấy đến cuối ngày đó (23:59:59)
            // Cách đơn giản là lấy ngày hôm sau và dùng phép so sánh "<"
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            if(tuNgay >= denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 1. Tải dữ liệu cho DataGridView
                LoadDataGridView(tuNgay, denNgay);

                // 2. Tải dữ liệu cho Biểu đồ
                LoadChartData(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải dữ liệu vào DataGridView và tính tổng doanh thu
        private void LoadDataGridView(DateTime tuNgay, DateTime denNgay)
        {
            // Dùng NgayThanhToan để tính doanh thu
            string query = "SELECT IDHoaDon, IDPhieuThue, NgayLap, NgayThanhToan, TongTienDichVu, GiamGiaTien, TongTien " +
                           "FROM HOADON " +
                           "WHERE NgayThanhToan >= @tuNgay AND NgayThanhToan <= @denNgay " +
                           "ORDER BY NgayThanhToan";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay)
            };

            DataTable dt = db.GetData(query, parameters);
            dgvHoaDon.DataSource = dt;

            // Tính tổng doanh thu từ DataTable
            // (Giả sử TongTien là cột doanh thu cuối cùng)
            decimal tongDoanhThu = 0;
            foreach (DataRow row in dt.Rows)
            {
                // Kiểm tra DBNull phòng trường hợp TongTien bị NULL
                if (row["TongTien"] != DBNull.Value)
                {
                    tongDoanhThu += Convert.ToDecimal(row["TongTien"]);
                }
            }

            // Hiển thị tổng doanh thu
            lblTongDoanhThu.Text = string.Format("Tổng doanh thu: {0:N0} VND", tongDoanhThu);
        }

        // Tải dữ liệu và vẽ biểu đồ
        private void LoadChartData(DateTime tuNgay, DateTime denNgay)
        {
            // Gom nhóm doanh thu theo từng ngày
            string query = "SELECT CAST(NgayThanhToan AS DATE) AS Ngay, SUM(TongTien) AS DoanhThuTheoNgay " +
                           "FROM HOADON " +
                           "WHERE NgayThanhToan >= @tuNgay AND NgayThanhToan <= @denNgay " +
                           "GROUP BY CAST(NgayThanhToan AS DATE) " +
                           "ORDER BY Ngay";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay)
            };

            DataTable dtChart = db.GetData(query, parameters);

            // Xóa dữ liệu cũ trên biểu đồ
            chartDoanhThu.Series["DoanhThu"].Points.Clear();
            
            // Thêm dữ liệu mới vào biểu đồ
            foreach (DataRow row in dtChart.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                decimal doanhThuNgay = Convert.ToDecimal(row["DoanhThuTheoNgay"]);

                // Thêm một điểm dữ liệu (Ngày, DoanhThu)
                DataPoint dp = new DataPoint(ngay.ToOADate(), (double)doanhThuNgay);
                dp.ToolTip = string.Format("{0:dd/MM/yyyy}: {1:N0} VND", ngay, doanhThuNgay);
                
                chartDoanhThu.Series["DoanhThu"].Points.Add(dp);
            }

            // Đặt lại định dạng trục X cho phù hợp
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = (denNgay - tuNgay).TotalDays > 30 ? "MM/yyyy" : "dd/MM";
            chartDoanhThu.ChartAreas[0].AxisX.IntervalType = (denNgay - tuNgay).TotalDays > 30 ? DateTimeIntervalType.Months : DateTimeIntervalType.Auto;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}