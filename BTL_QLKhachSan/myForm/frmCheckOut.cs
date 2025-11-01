using BTL_QLKhachSan.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_QLKhachSan.myForm
{
    public partial class frmCheckOut : Form
    {
        private string idPhong;
        private int idPhieuThue;
        private string nguoiLapHD = "admin"; // (Nên lấy từ frmMain)

        // Biến lưu trữ tiền
        private decimal tienPhong = 0;
        private decimal tienDichVu = 0;
        private decimal tienCoc = 0;
        private decimal tongCong = 0;

        // Constructor: Chỉ cần nhận IDPhòng đang 'Có khách'
        public frmCheckOut(string idPhong)
        {
            InitializeComponent();
            this.idPhong = idPhong;
            lblPhong.Text = idPhong;
        }

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            try
            {
                // 1. Lấy IDPhieuThue, TienCoc, NgayCheckIn của phòng này
                string queryPT = $@"
                    SELECT IDPhieuThue, TienCoc, NgayCheckIn 
                    FROM PHIEUTHUE 
                    WHERE IDPhong = @IDPhong AND TrangThai = N'Đã check-in'";

                List<SqlParameter> paramPT = new List<SqlParameter>
                {
                    new SqlParameter("@IDPhong", this.idPhong)
                };

                DataTable dtPT = db.GetData(queryPT, paramPT);
                if (dtPT.Rows.Count == 0)
                {
                    MessageBox.Show("Lỗi: Không tìm thấy phiếu thuê đang hoạt động của phòng này.");
                    this.Close();
                    return;
                }

                DataRow rPT = dtPT.Rows[0];
                this.idPhieuThue = Convert.ToInt32(rPT["IDPhieuThue"]);
                this.tienCoc = Convert.ToDecimal(rPT["TienCoc"]);
                DateTime ngayCheckIn = Convert.ToDateTime(rPT["NgayCheckIn"]);

                // 2. Tính Tiền Phòng
                string queryDonGia = $@"
                    SELECT lp.DonGiaNgay 
                    FROM PHONG p 
                    JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong 
                    WHERE p.IDPhong = @IDPhong";

                decimal donGiaNgay = Convert.ToDecimal(db.GetScalar(queryDonGia, paramPT)); // Dùng lại paramPT

                // Tính số ngày ở (làm tròn lên)
                TimeSpan duration = DateTime.Now.Subtract(ngayCheckIn);
                int soNgay = (int)Math.Ceiling(duration.TotalDays);
                if (soNgay == 0) soNgay = 1; // Ở trong ngày

                this.tienPhong = soNgay * donGiaNgay;
                lblTienPhong.Text = string.Format("{0:N0} VNĐ", this.tienPhong);


                // 3. Load Dịch Vụ và tính Tiền Dịch Vụ
                string queryDV = $@"
                    SELECT d.TenDichVu, cd.SoLuong, cd.ThanhTien 
                    FROM CHITIET_DICHVU cd 
                    JOIN DICHVU d ON cd.IDDichVu = d.IDDichVu 
                    WHERE cd.IDPhieuThue = @IDPhieuThue";

                List<SqlParameter> paramPhieu = new List<SqlParameter>
                {
                    new SqlParameter("@IDPhieuThue", this.idPhieuThue)
                };

                dgvDichVu.DataSource = db.GetData(queryDV, paramPhieu);

                // Tính tổng tiền dịch vụ
                string querySumDV = "SELECT SUM(ThanhTien) FROM CHITIET_DICHVU WHERE IDPhieuThue = @IDPhieuThue";
                object sum = db.GetScalar(querySumDV, paramPhieu);
                this.tienDichVu = (sum == DBNull.Value) ? 0 : Convert.ToDecimal(sum);
                lblTienDichVu.Text = string.Format("{0:N0} VNĐ", this.tienDichVu);

                // 4. Tính toán tổng cộng
                lblTienCoc.Text = string.Format("{0:N0} VNĐ", this.tienCoc);
                this.tongCong = (this.tienPhong + this.tienDichVu) - this.tienCoc;
                lblTongCong.Text = string.Format("{0:N0} VNĐ", this.tongCong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thanh toán: " + ex.Message, "Lỗi");
                this.Close();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thanh toán hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Database db = new Database();
                DateTime ngayThanhToan = DateTime.Now;

                try
                {
                    // 1. INSERT vào HOADON
                    string queryHD = $@"
                        INSERT INTO HOADON (IDPhieuThue, NguoiLap, NgayThanhToan, TongTienPhong, TongTienDichVu, GiamGiaTien, PhuongThucThanhToan, TongTien) 
                        VALUES (@IDPhieuThue, @NguoiLap, @NgayThanhToan, @TienPhong, @TienDV, 0, @PhuongThuc, @TongTien)";

                    List<SqlParameter> paramHD = new List<SqlParameter>
                    {
                        new SqlParameter("@IDPhieuThue", this.idPhieuThue),
                        new SqlParameter("@NguoiLap", this.nguoiLapHD),
                        new SqlParameter("@NgayThanhToan", ngayThanhToan),
                        new SqlParameter("@TienPhong", this.tienPhong),
                        new SqlParameter("@TienDV", this.tienDichVu),
                        new SqlParameter("@PhuongThuc", cbPhuongThuc.Text),
                        new SqlParameter("@TongTien", this.tongCong)
                    };
                    db.ExecuteNonQuery(queryHD, paramHD);

                    // 2. UPDATE PHIEUTHUE -> Đã check-out
                    string queryPT = $@"
                        UPDATE PHIEUTHUE 
                        SET TrangThai = N'Đã check-out', NgayCheckOut = @NgayThanhToan
                        WHERE IDPhieuThue = @IDPhieuThue";

                    List<SqlParameter> paramPT = new List<SqlParameter>
                    {
                        new SqlParameter("@NgayThanhToan", ngayThanhToan),
                        new SqlParameter("@IDPhieuThue", this.idPhieuThue)
                    };
                    db.ExecuteNonQuery(queryPT, paramPT);

                    // 3. UPDATE PHONG -> Dọn dẹp
                    string queryPhong = $"UPDATE PHONG SET TrangThai = N'Dọn dẹp' WHERE IDPhong = @IDPhong";
                    db.ExecuteNonQuery(queryPhong, new List<SqlParameter> { new SqlParameter("@IDPhong", this.idPhong) });

                    MessageBox.Show("Thanh toán thành công!");
                    this.DialogResult = DialogResult.OK; // Báo cho Sơ đồ phòng load lại
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi");
                }
            }
        }
    }
}