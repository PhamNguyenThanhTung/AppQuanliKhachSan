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

                // TẠO LIST PARAMETER MỚI CHO TỪNG LẦN GỌI
                List<SqlParameter> paramPT_GetData = new List<SqlParameter> // <-- Tạo mới
                {
                    new SqlParameter("@IDPhong", this.idPhong)
                };

                DataTable dtPT = db.GetData(queryPT, paramPT_GetData); // Dùng paramPT_GetData
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

                // TẠO LIST PARAMETER MỚI CHO LẦN GỌI NÀY
                List<SqlParameter> paramDonGia_GetScalar = new List<SqlParameter> // <-- Tạo mới
                {
                    new SqlParameter("@IDPhong", this.idPhong)
                };

                decimal donGiaNgay = Convert.ToDecimal(db.GetScalar(queryDonGia, paramDonGia_GetScalar)); // Dùng paramDonGia_GetScalar

                // Tính số ngày ở (làm tròn lên)
                TimeSpan duration = DateTime.Now.Date.Subtract(ngayCheckIn.Date);
                int soNgay = (int)duration.TotalDays;
                if (soNgay <= 0) soNgay = 1; // charge at least one night

                this.tienPhong = soNgay * donGiaNgay;
                lblTienPhong.Text = string.Format("{0:N0} VNĐ", this.tienPhong);


                // 3. Load Dịch Vụ và tính Tiền Dịch Vụ
                string queryDV = $@"
                    SELECT d.TenDichVu, cd.SoLuong, cd.ThanhTien 
                    FROM CHITIET_DICHVU cd 
                    JOIN DICHVU d ON cd.IDDichVu = d.IDDichVu 
                    WHERE cd.IDPhieuThue = @IDPhieuThue";

                // TẠO LIST PARAMETER MỚI CHO LẦN GỌI NÀY
                List<SqlParameter> paramDV_GetData = new List<SqlParameter> // <-- Tạo mới
                {
                    new SqlParameter("@IDPhieuThue", this.idPhieuThue)
                };

                dgvDichVu.DataSource = db.GetData(queryDV, paramDV_GetData); // Dùng paramDV_GetData

                // Tính tổng tiền dịch vụ
                string querySumDV = "SELECT SUM(ThanhTien) FROM CHITIET_DICHVU WHERE IDPhieuThue = @IDPhieuThue";
                
                // TẠO LIST PARAMETER MỚI CHO LẦN GỌI NÀY
                List<SqlParameter> paramSumDV_GetScalar = new List<SqlParameter> // <-- Tạo mới
                {
                    new SqlParameter("@IDPhieuThue", this.idPhieuThue)
                };

                object sum = db.GetScalar(querySumDV, paramSumDV_GetScalar); // Dùng paramSumDV_GetScalar
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
            if (MessageBox.Show("Xác nhận thanh toán hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Database db = new Database();
            DateTime ngayThanhToan = DateTime.Now;

            try
            {
                // 0) đảm bảo tongCong đã được tính (Load đã làm trước)
                // 1) Kiểm tra xem HOADON đã tồn tại cho phiếu thuê này hay chưa
                object existing = db.GetScalar(
                    "SELECT IDHoaDon FROM HOADON WHERE IDPhieuThue = @IDPhieuThue",
                    new List<SqlParameter> { new SqlParameter("@IDPhieuThue", this.idPhieuThue) }
                );

                int hoaDonId = 0;

                if (existing != null && existing != DBNull.Value)
                {
                    // Nếu đã có: UPDATE thay vì INSERT (tránh vi phạm UNIQUE)
                    hoaDonId = Convert.ToInt32(existing);
                    string updateHD = @"
                        UPDATE HOADON
                        SET NguoiLap = @NguoiLap,
                            NgayThanhToan = @NgayThanhToan,
                            TongTienPhong = @TienPhong,
                            TongTienDichVu = @TienDV,
                            GiamGiaTien = 0,
                            PhuongThucThanhToan = @PhuongThuc,
                            TongTien = @TongTien
                        WHERE IDHoaDon = @IDHoaDon";

                    var updParams = new List<SqlParameter>
                    {
                        new SqlParameter("@NguoiLap", this.nguoiLapHD),
                        new SqlParameter("@NgayThanhToan", ngayThanhToan),
                        new SqlParameter("@TienPhong", this.tienPhong),
                        new SqlParameter("@TienDV", this.tienDichVu),
                        new SqlParameter("@PhuongThuc", cbPhuongThuc.Text),
                        new SqlParameter("@TongTien", this.tongCong),
                        new SqlParameter("@IDHoaDon", hoaDonId)
                    };

                    db.ExecuteNonQuery(updateHD, updParams);
                }
                else
                {
                    // Nếu chưa có: chèn mới và lấy ID bằng SCOPE_IDENTITY()
                    string insertHD = @"
                        INSERT INTO HOADON (IDPhieuThue, NguoiLap, NgayThanhToan, TongTienPhong, TongTienDichVu, GiamGiaTien, PhuongThucThanhToan, TongTien)
                        VALUES (@IDPhieuThue, @NguoiLap, @NgayThanhToan, @TienPhong, @TienDV, 0, @PhuongThuc, @TongTien);
                        SELECT SCOPE_IDENTITY();";

                    var insParams = new List<SqlParameter>
                    {
                        new SqlParameter("@IDPhieuThue", this.idPhieuThue),
                        new SqlParameter("@NguoiLap", this.nguoiLapHD),
                        new SqlParameter("@NgayThanhToan", ngayThanhToan),
                        new SqlParameter("@TienPhong", this.tienPhong),
                        new SqlParameter("@TienDV", this.tienDichVu),
                        new SqlParameter("@PhuongThuc", cbPhuongThuc.Text),
                        new SqlParameter("@TongTien", this.tongCong)
                    };

                    object inserted = db.GetScalar(insertHD, insParams);
                    if (inserted == null || inserted == DBNull.Value)
                        throw new Exception("Không lấy được ID hóa đơn sau khi Insert.");
                    hoaDonId = Convert.ToInt32(Math.Round(Convert.ToDecimal(inserted)));
                }

                // 2) UPDATE PHIEUTHUE -> Đã check-out
                string queryPT_Update = @"
                    UPDATE PHIEUTHUE
                    SET TrangThai = N'Đã check-out', NgayCheckOut = @NgayThanhToan
                    WHERE IDPhieuThue = @IDPhieuThue";

                List<SqlParameter> paramPT_Update = new List<SqlParameter>
                {
                    new SqlParameter("@NgayThanhToan", ngayThanhToan),
                    new SqlParameter("@IDPhieuThue", this.idPhieuThue)
                };
                db.ExecuteNonQuery(queryPT_Update, paramPT_Update);

                // 3) UPDATE PHONG -> Dọn dẹp
                string queryPhong = "UPDATE PHONG SET TrangThai = N'Dọn dẹp' WHERE IDPhong = @IDPhong";
                List<SqlParameter> paramPhong_Update = new List<SqlParameter>
                {
                    new SqlParameter("@IDPhong", this.idPhong)
                };
                db.ExecuteNonQuery(queryPhong, paramPhong_Update);

                MessageBox.Show("Thanh toán thành công!");

                // 4) Chuyển sang UcBill và nạp phiếu vừa thanh toán
                NavigateToBillControl();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn (SQL): " + sqlex.Message, "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        // Recursive enumerator to search controls
        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }

        // Find the UserControlBillManagement instance and instruct it to show & load the bill
        private void NavigateToBillControl()
        {
            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    // ensure the host form is visible/activated
                    if (!f.Visible) f.Show();
                    f.BringToFront();
                    f.Activate();

                    // search recursively under each open form
                    foreach (Control c in GetAllControls(f))
                    {
                        if (c is BTL_QLKhachSan.myForm.UserControlBillManagement uc)
                        {
                            // If UC is inside a TabPage, select its TabPage on the form's UI thread
                            Action selectTabAndShow = () =>
                            {
                                Control parent = uc.Parent;
                                while (parent != null)
                                {
                                    if (parent is TabPage tabPage)
                                    {
                                        var tc = tabPage.Parent as TabControl;
                                        if (tc != null)
                                            tc.SelectedTab = tabPage;
                                        break;
                                    }
                                    parent = parent.Parent;
                                }

                                // ensure UC visible and bring to front
                                uc.Visible = true;
                                uc.BringToFront();

                                // call the public loader with the just-paid IDPhieuThue
                                uc.ShowAndLoadPhieuThue(this.idPhieuThue);
                            };

                            if (f.InvokeRequired)
                                f.BeginInvoke((Action)(() => selectTabAndShow()));
                            else
                                selectTabAndShow();

                            // Activate the host form
                            f.BringToFront();
                            f.Activate();

                            return;
                        }
                    }
                }

                // If we reach here, control wasn't found
                MessageBox.Show("Không tìm thấy màn hình Hóa Đơn (UserControlBillManagement).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển sang màn hình Hóa Đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}