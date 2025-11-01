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

namespace BTL_QLKhachSan.myForm
{
    public partial class FrmCheckIn : Form
    {
        private string idPhong;
        private int idPhieuThue = -1; // -1: Khách vãng lai, > 0: Khách đã đặt
        private int idKhachHang = -1; // -1: Khách mới
        public FrmCheckIn(int idPhieu, string idPhong)
        {
            InitializeComponent();
            // Your initialization code her
            this.idPhong = idPhong;
            lblPhong.Text = idPhong;
            this.idPhieuThue = idPhieu;
        }
        private void frmCheckIn_Load(object sender, EventArgs e)
        {
            dtpNgayCheckIn.Value = DateTime.Now; // Set ngày check-in là bây giờ

            // Nếu idPhieuThue > 0, nghĩa là đây là khách đã đặt
            // Cần tải thông tin cũ của họ lên
            if (idPhieuThue > 0)
            {
                try
                {
                    string query = $@"
                        SELECT 
                            k.HoTen, k.CMND, k.SoDienThoai, k.GioiTinh, k.DiaChi, 
                            pt.TienCoc, pt.IDKhachHang
                        FROM PHIEUTHUE pt
                        JOIN KHACHHANG k ON pt.IDKhachHang = k.IDKhachHang
                        WHERE pt.IDPhieuThue = @IDPhieuThue";

                    List<SqlParameter> param = new List<SqlParameter>
                    {
                        new SqlParameter("@IDPhieuThue", idPhieuThue)
                    };

                    DataTable dt = new Database().GetData(query, param);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];

                        // === PHẦN "HIỆN" (ĐIỀN DỮ LIỆU) ===
                        txtHoTen.Text = r["HoTen"].ToString();
                        txtCMND.Text = r["CMND"].ToString();
                        txtSoDienThoai.Text = r["SoDienThoai"].ToString();
                        cbGioiTinh.Text = r["GioiTinh"].ToString();
                        txtDiaChi.Text = r["DiaChi"].ToString();
                        numTienCoc.Value = Convert.ToDecimal(r["TienCoc"]);
                        this.idKhachHang = Convert.ToInt32(r["IDKhachHang"]);

                        // === PHẦN "KHÓA" (KHÔNG CHO SỬA) ===
                        // (Đúng như ý bạn: "khóa không được sửa thông tin")
                        txtHoTen.Enabled = false;
                        txtCMND.Enabled = false;
                        txtSoDienThoai.Enabled = false;
                        cbGioiTinh.Enabled = false;
                        txtDiaChi.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin đặt phòng: " + ex.Message);
                }
            }
        }

        // === HÀM LƯU (XÁC NHẬN CHECK-IN) ===
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên và CMND.", "Thông báo");
                return;
            }

            Database db = new Database();

            try
            {
                // 2. Xử lý KHACHHANG
                // Chỉ INSERT khách hàng nếu là khách vãng lai
                if (idPhieuThue == -1) // Khách vãng lai
                {
                    // (Nên thêm logic Tìm khách hàng theo CMND ở đây trước)
                    // ...

                    // Nếu không tìm thấy, tạo khách mới
                    string queryKH = $@"
                        INSERT INTO KHACHHANG (HoTen, CMND, SoDienThoai, GioiTinh, DiaChi) 
                        VALUES (@HoTen, @CMND, @SoDienThoai, @GioiTinh, @DiaChi);
                        SELECT SCOPE_IDENTITY();";

                    List<SqlParameter> paramKH = new List<SqlParameter>
                    {
                        new SqlParameter("@HoTen", txtHoTen.Text),
                        new SqlParameter("@CMND", txtCMND.Text),
                        new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                        new SqlParameter("@GioiTinh", cbGioiTinh.Text),
                        new SqlParameter("@DiaChi", txtDiaChi.Text)
                    };

                    this.idKhachHang = Convert.ToInt32(db.GetScalar(queryKH, paramKH));
                }

                // 3. Xử lý PHIEUTHUE
                string usernameNguoiTao = "admin"; // (Nên lấy từ frmMain)

                if (idPhieuThue > 0) // Khách đã đặt -> Cập nhật phiếu
                {
                    string queryPT = $@"
                        UPDATE PHIEUTHUE 
                        SET TrangThai = N'Đã check-in', 
                            NgayCheckIn = @NgayCheckIn,
                            TienCoc = @TienCoc 
                        WHERE IDPhieuThue = @IDPhieuThue";

                    List<SqlParameter> paramPT = new List<SqlParameter>
                    {
                        new SqlParameter("@NgayCheckIn", dtpNgayCheckIn.Value),
                        new SqlParameter("@TienCoc", numTienCoc.Value),
                        new SqlParameter("@IDPhieuThue", idPhieuThue)
                    };
                    db.ExecuteNonQuery(queryPT, paramPT);
                }
                else // Khách vãng lai -> Tạo phiếu mới
                {
                    string queryPT = $@"
                        INSERT INTO PHIEUTHUE (IDPhong, IDKhachHang, NguoiTao, NgayCheckIn, TienCoc, TrangThai) 
                        VALUES (@IDPhong, @IDKhachHang, @NguoiTao, @NgayCheckIn, @TienCoc, N'Đã check-in')";

                    List<SqlParameter> paramPT = new List<SqlParameter>
                    {
                        new SqlParameter("@IDPhong", this.idPhong),
                        new SqlParameter("@IDKhachHang", this.idKhachHang),
                        new SqlParameter("@NguoiTao", usernameNguoiTao),
                        new SqlParameter("@NgayCheckIn", dtpNgayCheckIn.Value),
                        new SqlParameter("@TienCoc", numTienCoc.Value)
                    };
                    db.ExecuteNonQuery(queryPT, paramPT);
                }

                // 4. Cập nhật PHONG
                string queryPhong = $"UPDATE PHONG SET TrangThai = N'Có khách' WHERE IDPhong = @IDPhong";
                db.ExecuteNonQuery(queryPhong, new List<SqlParameter> { new SqlParameter("@IDPhong", this.idPhong) });

                MessageBox.Show("Check-in thành công cho phòng " + idPhong);
                this.DialogResult = DialogResult.OK; // Báo cho UC_BookingManagement biết để load lại
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận Check-in: " + ex.Message, "Lỗi");
            }
        }
    }
}