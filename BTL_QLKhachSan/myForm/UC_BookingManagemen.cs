using BTL_QLKhachSan.myClass;
using BTL_QLKhachSan.myForm;
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
    public partial class UC_BookingManagemen : UserControl
    {
        private int currentPhieuThueID = -1;
        private string currentPhongID = null;
        private int currentKhachHangID = -1;
        private DateTime currentDateCheckIn;
        private bool isEditing = false;

        bool isRowSelected = false;
        public UC_BookingManagemen()
        {
            InitializeComponent();

        }

        private void EnableControls(bool? editing = null, bool? rowSelected = null)
        {
            // Cập nhật trạng thái
            if (editing.HasValue) isEditing = editing.Value;
            if (rowSelected.HasValue) isRowSelected = rowSelected.Value;

            if (isEditing)
            {
                // === ĐANG SỬA ===
                tbidphieu.Enabled = false;
                tbidkhach.Enabled = false;
                tbidphong.Enabled = true;
                tbsonguoi.Enabled = true;
                tbtiencoc.Enabled = true;
                tbghichu.Enabled = true;
                dtpngaydat.Enabled = true;
                dtpngaycheckin.Enabled = true;
                dtpngaycheckout.Enabled = false;
                tbnguoitao.Enabled = false;
            }
            else if (isRowSelected)
            {
                // === ĐÃ CHỌN 1 DÒNG ===
                tbidphieu.Enabled = false;
                tbidkhach.Enabled = false;
                tbidphong.Enabled = false;
                tbsonguoi.Enabled = false;
                tbtiencoc.Enabled = false;
                tbghichu.Enabled = false;
                dtpngaydat.Enabled = false;
                dtpngaycheckin.Enabled = false;
                dtpngaycheckout.Enabled = false;
                tbnguoitao.Enabled = false;
            }
            else
            {
                // === CHƯA CHỌN GÌ (TÌM KIẾM) ===
                tbidphieu.Enabled = true;
                tbidkhach.Enabled = true;
                tbidphong.Enabled = true;
                tbsonguoi.Enabled = true;
                tbtiencoc.Enabled = true;
                tbghichu.Enabled = true;
                dtpngaydat.Enabled = true;
                dtpngaycheckin.Enabled = true;
                dtpngaycheckout.Enabled = true;
                tbnguoitao.Enabled = true;
            }
        }
        private void LoadBookingList()
        {
            string query = @"
                SELECT 
                    PT.IDPhieuThue,
                    PT.IDKhachHang,
                    PT.IDPhong,
                    P.TenPhong,
                    KH.HoTen AS KhachHang,
                    KH.CMND,
                    KH.SoDienThoai,
                    PT.NguoiTao,
                    PT.SoNguoi,
                    PT.TienCoc,
                    PT.GhiChu,
                    PT.NgayDat,
                    PT.NgayCheckIn,
                    PT.NgayCheckOut,
                    PT.TrangThai
                FROM PHIEUTHUE PT
                JOIN KHACHHANG KH ON PT.IDKhachHang = KH.IDKhachHang
                JOIN PHONG P ON PT.IDPhong = P.IDPhong
                WHERE PT.TrangThai = N'Đã đặt'
                ORDER BY PT.NgayCheckIn, PT.IDPhieuThue";

            try
            {
                DataTable dt = new Database().GetData(query);
                dgvBookingList.DataSource = dt;

                // Tùy chọn: ẩn cột IDKhachHang nếu bạn chỉ muốn hiện tên
                if (dgvBookingList.Columns.Contains("IDKhachHang"))
                    dgvBookingList.Columns["IDKhachHang"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void UC_BookingManagemen_Load(object sender, EventArgs e)
        {
            isEditing = false;
            isRowSelected = false;
            EnableControls();
        }

        private (string, List<SqlParameter>) BuildSearchQuery()
        {
            // 1. Bắt đầu câu SQL gốc
            string sql = @"
                SELECT 
            PT.IDPhieuThue,
            PT.IDKhachHang,       
            PT.IDPhong,
            P.TenPhong,
            KH.HoTen AS KhachHang,
            KH.CMND,
            KH.SoDienThoai,
            PT.NguoiTao,
            PT.SoNguoi,
            PT.TienCoc,
            PT.GhiChu,
            PT.NgayDat,
            PT.NgayCheckIn,
            PT.NgayCheckOut,
            PT.TrangThai
            FROM PHIEUTHUE PT
            JOIN KHACHHANG KH ON PT.IDKhachHang = KH.IDKhachHang
            JOIN PHONG P ON PT.IDPhong = P.IDPhong
            WHERE PT.TrangThai = N'Đã đặt'";

            List<SqlParameter> paramList = new List<SqlParameter>();

            // 2. Thêm các điều kiện (TextBoxes) một cách an toàn
            if (!string.IsNullOrEmpty(tbidphieu.Text))
            {
                sql += " AND PT.IDPhieuThue LIKE @IDPhieu";
                paramList.Add(new SqlParameter("@IDPhieu", "%" + tbidphieu.Text + "%"));
            }

            if (!string.IsNullOrEmpty(tbidphong.Text))
            {
                sql += " AND PT.IDPhong LIKE @IDPhong";
                paramList.Add(new SqlParameter("@IDPhong", "%" + tbidphong.Text + "%"));
            }

            if (!string.IsNullOrEmpty(tbidkhach.Text))
            {
                sql += " AND KH.HoTen LIKE @TenKhach"; // Tìm theo Tên khách
                paramList.Add(new SqlParameter("@TenKhach", "%" + tbidkhach.Text + "%"));
            }

            if (!string.IsNullOrEmpty(tbnguoitao.Text))
            {
                sql += " AND PT.NguoiTao LIKE @NguoiTao";
                paramList.Add(new SqlParameter("@NguoiTao", "%" + tbnguoitao.Text + "%"));
            }

            // 3. Thêm các điều kiện (Số) một cách an toàn
            if (!string.IsNullOrEmpty(tbsonguoi.Text))
            {
                if (int.TryParse(tbsonguoi.Text, out int soNguoi))
                {
                    sql += " AND PT.SoNguoi = @SoNguoi";
                    paramList.Add(new SqlParameter("@SoNguoi", soNguoi));
                }
                else
                {
                    MessageBox.Show("'" + tbsonguoi.Text + "' không phải là 'Số người' hợp lệ. Điều kiện này sẽ bị bỏ qua.");
                }
            }

            if (!string.IsNullOrEmpty(tbtiencoc.Text))
            {
                if (decimal.TryParse(tbtiencoc.Text, out decimal tienCoc))
                {
                    sql += " AND PT.TienCoc >= @TienCoc"; // Tìm tiền cọc LỚN HƠN HOẶC BẰNG
                    paramList.Add(new SqlParameter("@TienCoc", tienCoc));
                }
                else
                {
                    MessageBox.Show("'" + tbtiencoc.Text + "' không phải là 'Tiền cọc' hợp lệ. Điều kiện này sẽ bị bỏ qua.");
                }
            }

            // (Bạn có thể thêm logic cho DateTimePicker ở đây nếu muốn)

            return (sql, paramList);
        }

        // SỬA LẠI HÀM NÀY
        private void btnfind_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Gọi hàm xây dựng query an toàn
                var (query, paramList) = BuildSearchQuery();

                // 2. Gọi hàm GetData (phiên bản mới)
                // YÊU CẦU: file Database.cs của bạn phải có hàm GetData nhận 2 tham số
                DataTable dt = new Database().GetData(query, paramList);

                dgvBookingList.DataSource = dt;
            }
            catch (FormatException)
            {
                MessageBox.Show("Lỗi định dạng số. Vui lòng kiểm tra lại ô 'Số người' và 'Tiền cọc'.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dữ liệu: " + ex.Message, "Lỗi");
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (currentPhieuThueID == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu từ danh sách để sửa.");
                return;
            }

            isEditing = true;
            isRowSelected = false;
            EnableControls();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn phiếu nào chưa
            if (currentPhieuThueID == -1 || string.IsNullOrEmpty(currentPhongID))
            {
                MessageBox.Show("Vui lòng chọn một phiếu đặt phòng từ danh sách.");
                return;
            }

            // 2. Mở form frmCheckIn (dạng pop-up)
            // (Sử dụng constructor 2: Dùng cho khách đã đặt)
            FrmCheckIn fCheckIn = new FrmCheckIn(currentPhieuThueID, currentPhongID);

            // 3. Hiển thị form và "chờ"
            // .ShowDialog() sẽ "đóng băng" code ở đây cho đến khi form frmCheckIn được đóng
            DialogResult result = fCheckIn.ShowDialog();

            // 4. Sau khi form CheckIn đóng, reset lại giao diện
            // (Chỉ tải lại nếu người dùng nhấn "Xác nhận" bên trong frmCheckIn)
            if (result == DialogResult.OK)
            {
                LoadBookingList(); // Tải lại (phiếu này sẽ biến mất)
                ClearInputPanel(); // Xóa các ô

                // Reset trạng thái
                isEditing = false;
                isRowSelected = false;
                EnableControls(); // Khóa các ô
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (currentPhieuThueID == -1)
            {
                MessageBox.Show("Không có phiếu để lưu.");
                return;
            }

            // Validate input
            string idPhongMoi = tbidphong.Text.Trim();
            if (string.IsNullOrEmpty(idPhongMoi))
            {
                MessageBox.Show("Vui lòng nhập mã phòng.");
                tbidphong.Focus();
                return;
            }

            if (!int.TryParse(tbsonguoi.Text.Trim(), out int soNguoiMoi))
            {
                MessageBox.Show("Số người không hợp lệ.");
                tbsonguoi.Focus();
                return;
            }

            if (!decimal.TryParse(tbtiencoc.Text.Trim(), out decimal tienCocMoi))
            {
                MessageBox.Show("Tiền cọc không hợp lệ.");
                tbtiencoc.Focus();
                return;
            }

            DateTime ngayCheckInMoi = dtpngaycheckin.Value.Date;
            Database db = new Database();

            try
            {
                // Kiểm tra xung đột: nếu đổi phòng hoặc đổi ngày
                if (idPhongMoi != currentPhongID || ngayCheckInMoi != currentDateCheckIn.Date)
                {
                    string qConflict = @"
                        SELECT TOP 1 1 FROM PHIEUTHUE
                        WHERE IDPhong = @pID
                          AND IDPhieuThue <> @curID
                          AND (TrangThai = N'Đã check-in'
                               OR (TrangThai = N'Đã đặt' AND CONVERT(date, NgayCheckIn) = @ngay))
                    ";
                    var param = new List<SqlParameter>()
                    {
                        new SqlParameter("@pID", idPhongMoi),
                        new SqlParameter("@curID", currentPhieuThueID),
                        new SqlParameter("@ngay", ngayCheckInMoi)
                    };

                    object conflict = db.GetScalar(qConflict, param);
                    if (conflict != null)
                    {
                        MessageBox.Show($"Phòng {idPhongMoi} không có sẵn vào {ngayCheckInMoi:dd/MM/yyyy}.");
                        return;
                    }
                }

                // Thực hiện update (dùng parameter để tránh SQL injection)
                string qUpdate = @"
                    UPDATE PHIEUTHUE SET
                        IDPhong = @pID,
                        IDKhachHang = @kID,
                        SoNguoi = @soNguoi,
                        TienCoc = @tienCoc,
                        GhiChu = @ghiChu,
                        NgayDat = @ngayDat,
                        NgayCheckIn = @ngayCheckIn
                    WHERE IDPhieuThue = @id
                ";
                var pUpdate = new List<SqlParameter>()
                {
                    new SqlParameter("@pID", idPhongMoi),
                    new SqlParameter("@kID", currentKhachHangID),
                    new SqlParameter("@soNguoi", soNguoiMoi),
                    new SqlParameter("@tienCoc", tienCocMoi),
                    new SqlParameter("@ghiChu", tbghichu.Text.Trim()),
                    new SqlParameter("@ngayDat", dtpngaydat.Value),
                    new SqlParameter("@ngayCheckIn", dtpngaycheckin.Value),
                    new SqlParameter("@id", currentPhieuThueID)
                };

                db.ExecuteNonQuery(qUpdate, pUpdate);

                // Nếu đổi phòng thì cập nhật trạng thái phòng
                if (currentPhongID != idPhongMoi)
                {
                    db.ExecuteNonQuery("UPDATE PHONG SET TrangThai = N'Trống' WHERE IDPhong = @old", new List<SqlParameter> { new SqlParameter("@old", currentPhongID) });
                    db.ExecuteNonQuery("UPDATE PHONG SET TrangThai = N'Đã đặt' WHERE IDPhong = @newp", new List<SqlParameter> { new SqlParameter("@newp", idPhongMoi) });
                }

                MessageBox.Show("Cập nhật thành công.");
                LoadBookingList();
                ClearInputPanel();
                EnableControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentPhieuThueID == -1)
            {
                MessageBox.Show("Chọn phiếu để xóa.");
                return;
            }
            var res = MessageBox.Show("Xác nhận xóa phiếu?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            Database db = new Database();
            try
            {
                // Xóa phiếu
                db.ExecuteNonQuery("DELETE FROM PHIEUTHUE WHERE IDPhieuThue = @id", new List<SqlParameter> { new SqlParameter("@id", currentPhieuThueID) });
                // Trả phòng về trạng thái Trống
                if (!string.IsNullOrEmpty(currentPhongID))
                    db.ExecuteNonQuery("UPDATE PHONG SET TrangThai = N'Trống' WHERE IDPhong = @p", new List<SqlParameter> { new SqlParameter("@p", currentPhongID) });

                MessageBox.Show("Đã xóa.");
                LoadBookingList();
                ClearInputPanel();
                EnableControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void dgvBookingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua header

            if (isEditing)
            {
                MessageBox.Show("Bạn đang trong chế độ Sửa. Hãy Lưu hoặc Hủy trước.", "Thông báo");
                return;
            }

            try
            {
                DataGridViewRow row = dgvBookingList.Rows[e.RowIndex];

                currentPhieuThueID = Convert.ToInt32(row.Cells["IDPhieuThue"].Value);
                currentKhachHangID = Convert.ToInt32(row.Cells["IDKhachHang"].Value);
                currentPhongID = row.Cells["IDPhong"].Value.ToString();
                currentDateCheckIn = Convert.ToDateTime(row.Cells["NgayCheckIn"].Value);

                tbidphieu.Text = row.Cells["IDPhieuThue"].Value.ToString();
                tbidphong.Text = row.Cells["IDPhong"].Value.ToString();
                tbidkhach.Text = row.Cells["KhachHang"].Value.ToString();
                tbnguoitao.Text = row.Cells["NguoiTao"].Value.ToString();
                tbsonguoi.Text = row.Cells["SoNguoi"].Value.ToString();
                tbtiencoc.Text = row.Cells["TienCoc"].Value.ToString();
                tbghichu.Text = row.Cells["GhiChu"].Value.ToString();

                dtpngaydat.Value = Convert.ToDateTime(row.Cells["NgayDat"].Value);
                dtpngaycheckin.Value = currentDateCheckIn;
                dtpngaycheckout.Value = row.Cells["NgayCheckOut"].Value == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(row.Cells["NgayCheckOut"].Value);

                // Cập nhật trạng thái
                isRowSelected = true;
                isEditing = false;
                EnableControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi click vào hàng: " + ex.Message, "Lỗi");
                ClearInputPanel();
            }
        }

        private void ClearInputPanel()
        {
            tbidphieu.Text = "";
            tbidphong.Text = "";
            tbidkhach.Text = "";
            tbnguoitao.Text = "";
            tbsonguoi.Text = "";
            tbtiencoc.Text = "";
            tbghichu.Text = "";

            dtpngaydat.Value = DateTime.Now;
            dtpngaycheckin.Value = DateTime.Now.AddHours(1);
            dtpngaycheckout.Value = DateTime.Now;

            currentPhieuThueID = -1;
            currentPhongID = null;
            currentKhachHangID = -1;
            isEditing = false;

            // 🔥 Thêm dòng này để khi quay lại giao diện hiển thị đúng nút
            btnluu.Visible = true;
            btnEdit.Visible = true;
            btnfind.Visible = true;
            btnDelete.Visible = true;
            btnCheckIn.Visible = true;
        }

    }

}