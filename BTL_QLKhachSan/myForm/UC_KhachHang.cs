using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_QLKhachSan.myClass; // Đảm bảo bạn đã thêm dòng này
using System.Data.SqlClient; // Thêm thư viện này để dùng SqlParameter

namespace BTL_QLKhachSan.myForm
{
    public partial class UC_KhachHang : UserControl
    {
        // Khởi tạo đối tượng Database để tương tác
        Database db = new Database();

        // Biến tạm để lưu IDKhachHang khi chọn từ GridView (dùng cho Sửa/Xóa)
        private string selectedID = null;

        public UC_KhachHang()
        {
            InitializeComponent();
        }

        // Sự kiện khi UserControl được tải
        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu lên DataGridView khi form được mở
            LoadData();
            // (Tùy chọn) Đặt giá trị mặc định cho ComboBox
            if (cboGioiTinh.Items.Count > 0)
            {
                cboGioiTinh.SelectedIndex = 0;
            }
        }

        // --- HÀM XỬ LÝ CHÍNH ---

        // Hàm tải dữ liệu (chính hoặc tìm kiếm)
        private void LoadData(string searchTerm = "")
        {
            string query = "";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Câu lệnh SQL để lấy tất cả khách hàng
                query = "SELECT IDKhachHang, HoTen, CMND, SoDienThoai, GioiTinh, DiaChi FROM KHACHHANG";
            }
            else
            {
                // Câu lệnh SQL để tìm kiếm an toàn (theo Tên hoặc CMND)
                query = "SELECT IDKhachHang, HoTen, CMND, SoDienThoai, GioiTinh, DiaChi FROM KHACHHANG " +
                          "WHERE HoTen LIKE @searchTerm OR CMND LIKE @searchTerm";
                // Dùng N'%' để hỗ trợ tìm kiếm tiếng Việt và ký tự đặc biệt
                parameters.Add(new SqlParameter("@searchTerm", "%" + searchTerm + "%"));
            }
            
            try
            {
                // Lấy dữ liệu bằng phương thức GetData từ lớp Database
                DataTable dt = db.GetData(query, parameters); 
                dgvKhachHang.DataSource = dt;

                // (Tùy chọn) Đặt lại tên cột cho đẹp hơn
                dgvKhachHang.Columns["IDKhachHang"].HeaderText = "ID";
                dgvKhachHang.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvKhachHang.Columns["CMND"].HeaderText = "Số CMND";
                dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Điện Thoại";
                dgvKhachHang.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xóa trắng các ô nhập liệu
        private void ClearFields()
        {
            txtHoTen.Clear();
            txtCMND.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            if (cboGioiTinh.Items.Count > 0)
            {
                cboGioiTinh.SelectedIndex = 0;
            }
            txtTimKiem.Clear();
            selectedID = null; // Quan trọng: Đặt lại ID đã chọn
            dgvKhachHang.ClearSelection(); // Bỏ chọn trên lưới
        }

        // Hàm kiểm tra dữ liệu đầu vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập Số CMND.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCMND.Focus();
                return false;
            }
            return true;
        }

        // --- CÁC SỰ KIỆN CLICK NÚT ---

        // Sự kiện click nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return; // Kiểm tra đầu vào

            string query = "INSERT INTO KHACHHANG (HoTen, CMND, SoDienThoai, GioiTinh, DiaChi) " +
                           "VALUES (@HoTen, @CMND, @SoDienThoai, @GioiTinh, @DiaChi)";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@HoTen", txtHoTen.Text),
                new SqlParameter("@CMND", txtCMND.Text),
                new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                new SqlParameter("@GioiTinh", cboGioiTinh.Text),
                new SqlParameter("@DiaChi", txtDiaChi.Text)
            };

            try
            {
                db.ExecuteNonQuery(query, parameters); // Dùng hàm mới
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại dữ liệu
                ClearFields(); // Xóa các ô nhập
            }
            catch (Exception ex)
            {
                // Xử lý lỗi trùng lặp CMND (nếu có cài đặt UNIQUE trong CSDL)
                if (ex.Message.Contains("UNIQUE constraint"))
                {
                     MessageBox.Show("Số CMND này đã tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện click nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedID == null)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return; // Kiểm tra đầu vào

            string query = "UPDATE KHACHHANG SET HoTen = @HoTen, CMND = @CMND, SoDienThoai = @SoDienThoai, " +
                           "GioiTinh = @GioiTinh, DiaChi = @DiaChi WHERE IDKhachHang = @ID";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@HoTen", txtHoTen.Text),
                new SqlParameter("@CMND", txtCMND.Text),
                new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                new SqlParameter("@GioiTinh", cboGioiTinh.Text),
                new SqlParameter("@DiaChi", txtDiaChi.Text),
                new SqlParameter("@ID", Convert.ToInt32(selectedID)) // ID của khách hàng cần sửa
            };

            try
            {
                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện click nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedID == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (confirm == DialogResult.Yes)
            {
                // Cần kiểm tra xem khách hàng này có đang thuê phòng không (liên quan đến bảng PHIEUTHUE)
                string checkQuery = "SELECT COUNT(*) FROM PHIEUTHUE WHERE IDKhachHang = @ID AND TrangThai = N'Chưa thanh toán'"; // Giả sử trạng thái là 'Chưa thanh toán'
                List<SqlParameter> checkParams = new List<SqlParameter> { new SqlParameter("@ID", Convert.ToInt32(selectedID)) };
                
                // (Giả định hàm GetData trả về DataTable)
                DataTable dt = db.GetData(checkQuery, checkParams);
                int count = Convert.ToInt32(dt.Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa. Khách hàng này đang có phiếu thuê chưa thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nếu không vướng bận, tiến hành xóa
                string deleteQuery = "DELETE FROM KHACHHANG WHERE IDKhachHang = @ID";
                List<SqlParameter> deleteParams = new List<SqlParameter> { new SqlParameter("@ID", Convert.ToInt32(selectedID)) };

                try
                {
                    db.ExecuteNonQuery(deleteQuery, deleteParams);
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện click nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData(); // Tải lại toàn bộ danh sách
        }

        // Sự kiện click nút Tìm Kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();
            LoadData(searchTerm);
        }

        // Sự kiện click vào một ô trong DataGridView
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng không click vào tiêu đề cột
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy dòng hiện tại
                    DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                    // Lưu ID đã chọn vào biến tạm
                    selectedID = row.Cells["IDKhachHang"].Value.ToString();

                    // Hiển thị dữ liệu lên các ô nhập
                    txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                    txtCMND.Text = row.Cells["CMND"].Value.ToString();
                    txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                    cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                    txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Thêm phương thức này vào UC_KhachHang.cs
        public void ClearAndRefreshData()
        {
            ClearFields(); // Xóa các trường nhập liệu
            LoadData();    // Tải lại dữ liệu cho DataGridView
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bỏ qua ký tự này
            }
        }
    }
}