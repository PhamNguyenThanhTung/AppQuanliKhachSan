using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_QLKhachSan.myForm
{
    public partial class UC_NhanVien : UserControl
    {
        private int loaiTaiKhoanDangNhap;
        private string tenDangNhapDangNhap;
        private string connectionString = "Data Source=HAHAHA\\SQLEXPRESS;Initial Catalog=QLKhachSanBTL;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private bool isAdding = false;
        private bool isEditing = false;

        public UC_NhanVien(int LoaiTK, string username)
        {
            InitializeComponent();
            loaiTaiKhoanDangNhap = LoaiTK;
            tenDangNhapDangNhap = username;
            this.Load += UC_NhanVien_Load;
        }
        // --- THÊM CONSTRUCTOR KHÔNG THAM SỐ NÀY ---
        public UC_NhanVien()
        {
            InitializeComponent();
            
            loaiTaiKhoanDangNhap = 0;
            tenDangNhapDangNhap = "";
            this.Load += UC_NhanVien_Load;
        }
        public void SetLoginInfo(int LoaiTK, string username)
        {
            loaiTaiKhoanDangNhap = LoaiTK;
            tenDangNhapDangNhap = username;
        }
        // --- KẾT THÚC THÊM ---

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {

            try
            {
                LoadLoaiTaiKhoan();
                LoadTrangThai();

                // Nếu là admin -> xem tất cả
                if (loaiTaiKhoanDangNhap == 1)
                {
                    LoadTatCaTaiKhoan();
                    EnableAdminMode(true);
                }
                else // Nếu KHÔNG phải admin -> chỉ xem tài khoản của chính mình
                {
                    LoadThongTinCaNhan(tenDangNhapDangNhap);
                    EnableAdminMode(false);
                }

                // Nếu có dữ liệu thì hiển thị chi tiết dòng đầu tiên
                if (dgvNhanVien.Rows.Count > 0)
                {
                    dgvNhanVien.Rows[0].Selected = true;
                    HienThiChiTietTuDong(0);
                }

                SetEditingMode(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private void LoadLoaiTaiKhoan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IDLoaiTK, TenLoaiTK FROM LOAITAIKHOAN";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboLoaiTK.DataSource = dt;
                cboLoaiTK.DisplayMember = "TenLoaiTK";
                cboLoaiTK.ValueMember = "IDLoaiTK";
                cboLoaiTK.SelectedIndex = -1;
            }
        }

        private void LoadTrangThai()
        {
            DataTable dtTrangThai = new DataTable();
            dtTrangThai.Columns.Add("Value", typeof(int));
            dtTrangThai.Columns.Add("Text", typeof(string));

            dtTrangThai.Rows.Add(1, "Hoạt động");
            dtTrangThai.Rows.Add(0, "Bị khóa");

            cboTrangThai.DataSource = dtTrangThai;
            cboTrangThai.DisplayMember = "Text";
            cboTrangThai.ValueMember = "Value";
        }

        private void EnableAdminMode(bool isAdmin)
        {
            // Chỉ admin mới có quyền thêm, xóa, khóa, lưu, hủy
            btnThem.Enabled = isAdmin;
            btnXoa.Enabled = isAdmin;
            btnKhoa.Enabled = isAdmin;
            btnLuu.Enabled = isAdmin;
            btnHuy.Enabled = isAdmin;
        }

        private void LoadTatCaTaiKhoan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, DisplayName, Email, TrangThai, IDLoaiTK FROM TAIKHOAN";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhanVien.DataSource = dt;
            }
        }

        private void LoadThongTinCaNhan(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Không tìm thấy thông tin đăng nhập của tài khoản hiện tại!");
                dgvNhanVien.DataSource = null;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    Username, 
                    DisplayName, 
                    Email, 
                    TrangThai, 
                    IDLoaiTK 
                FROM TAIKHOAN 
                WHERE DisplayName = @DisplayName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DisplayName", username.Trim());

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dgvNhanVien.DataSource = dt;
                            dgvNhanVien.ClearSelection();
                            HienThiChiTietTuDong(0); // Hiển thị thông tin của hàng đầu tiên
                        }
                        else
                        {
                            dgvNhanVien.DataSource = null;
                            MessageBox.Show($"Không tìm thấy tài khoản có username: {username}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin cá nhân: " + ex.Message);
                }
            }
        }


        private void HienThiChiTietTuDong(int rowIndex)
        {
            if (rowIndex < 0 || dgvNhanVien.Rows.Count == 0)
                return;

            DataGridViewRow row = dgvNhanVien.Rows[rowIndex];
            txtTenDangNhap.Text = row.Cells["Username"].Value?.ToString();
            txtTenHienThi.Text = row.Cells["DisplayName"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();

            if (row.Cells["IDLoaiTK"].Value != DBNull.Value)
                cboLoaiTK.SelectedValue = Convert.ToInt32(row.Cells["IDLoaiTK"].Value);

            if (row.Cells["TrangThai"].Value != DBNull.Value)
                cboTrangThai.SelectedValue = Convert.ToInt32(row.Cells["TrangThai"].Value);
        }

        private void SetEditingMode(bool editing)
        {
            txtTenDangNhap.Enabled = isAdding;
            txtTenHienThi.Enabled = editing;
            txtEmail.Enabled = editing;
            txtMatKhau.Enabled = editing;
            cboLoaiTK.Enabled = editing;
            cboTrangThai.Enabled = editing;

            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            btnThem.Enabled = !editing && loaiTaiKhoanDangNhap == 1;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing && loaiTaiKhoanDangNhap == 1;
            btnKhoa.Enabled = !editing && loaiTaiKhoanDangNhap == 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;
            ClearText();
            SetEditingMode(true);
        }

        private void ClearText()
        {
            txtTenDangNhap.Clear();
            txtTenHienThi.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            cboLoaiTK.SelectedIndex = -1;
            cboTrangThai.SelectedValue = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa.");
                return;
            }

            isAdding = false;
            isEditing = true;
            SetEditingMode(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (isAdding)
                    {
                        string query = "INSERT INTO TAIKHOAN (Username, Password, DisplayName, Email, TrangThai, IDLoaiTK) VALUES (@User, @Pass, @Name, @Email, @TrangThai, @Loai)";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@User", txtTenDangNhap.Text);
                        cmd.Parameters.AddWithValue("@Pass", txtMatKhau.Text);
                        cmd.Parameters.AddWithValue("@Name", txtTenHienThi.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Loai", cboLoaiTK.SelectedValue);
                        cmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.SelectedValue);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm tài khoản thành công!");
                    }
                    else if (isEditing)
                    {
                        string query = "UPDATE TAIKHOAN SET DisplayName=@Name, Email=@Email, IDLoaiTK=@Loai, TrangThai=@TrangThai WHERE Username=@User";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@User", txtTenDangNhap.Text);
                        cmd.Parameters.AddWithValue("@Name", txtTenHienThi.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Loai", cboLoaiTK.SelectedValue);
                        cmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.SelectedValue);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật tài khoản thành công!");
                    }

                    //Cập nhật lại danh sách hiển thị
                    if (loaiTaiKhoanDangNhap == 1)
                        LoadTatCaTaiKhoan();
                    else
                        LoadThongTinCaNhan(tenDangNhapDangNhap);

                    isAdding = false;
                    isEditing = false;
                    SetEditingMode(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            isEditing = false;
            SetEditingMode(false);

            if (loaiTaiKhoanDangNhap == 1)
                LoadTatCaTaiKhoan();
            else
                LoadThongTinCaNhan(tenDangNhapDangNhap);
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (loaiTaiKhoanDangNhap != 1)
            {
                MessageBox.Show("Chỉ Admin mới có quyền khóa tài khoản!");
                return;
            }

            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa.");
                return;
            }

            if (MessageBox.Show("Khóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE TAIKHOAN SET TrangThai = 0 WHERE Username = @User";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@User", txtTenDangNhap.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Đã khóa tài khoản!");
                    LoadTatCaTaiKhoan();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (loaiTaiKhoanDangNhap != 1)
            {
                MessageBox.Show("Chỉ Admin mới có quyền xóa tài khoản!");
                return;
            }

            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM TAIKHOAN WHERE Username = @User";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@User", txtTenDangNhap.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Đã xóa tài khoản!");
                    LoadTatCaTaiKhoan();
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //Nếu không phải admin thì không cho tìm kiếm danh sách người khác
            if (loaiTaiKhoanDangNhap != 1)
            {
                LoadThongTinCaNhan(tenDangNhapDangNhap);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, DisplayName, Email, TrangThai, IDLoaiTK FROM TAIKHOAN WHERE DisplayName LIKE @Search";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtTimKiem.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhanVien.DataSource = dt;
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                HienThiChiTietTuDong(e.RowIndex);
        }

        private void UC_NhanVien_Load_1(object sender, EventArgs e)
        {

        }
    }
}