using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_QLKhachSan.QuanLy
{
    public partial class UC_KhachHang : UserControl
    {
        string connectionString = "Data Source=LOMG\\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True";
        int selectedID = -1; // ID khách hàng đang chọn

        public UC_KhachHang()
        {
            InitializeComponent();
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
            LoadDanhSachKhachHang();
        }

        //Hiển thị danh sách khách hàng
        private void LoadDanhSachKhachHang()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT IDKhachHang, HoTen, CMND, SoDienThoai, GioiTinh, DiaChi FROM KHACHHANG";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKhachHang.DataSource = dt;
            }
        }

        //Làm trống form nhập liệu
        private void ClearForm()
        {
            txtHoTen.Clear();
            txtCMND.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            cboGioiTinh.SelectedIndex = -1;
            selectedID = -1;
        }

        //Thêm khách hàng
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "" || txtCMND.Text == "" || cboGioiTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO KHACHHANG (HoTen, CMND, SoDienThoai, GioiTinh, DiaChi) VALUES (@ten, @cmnd, @sdt, @gt, @dc)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@cmnd", txtCMND.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@gt", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm khách hàng thành công!");
                    LoadDanhSachKhachHang();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        MessageBox.Show("CMND đã tồn tại!");
                    else
                        MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
        }

        //Khi chọn 1 hàng trong DataGridView
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(row.Cells["IDKhachHang"].Value);
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtCMND.Text = row.Cells["CMND"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }

        //Sửa khách hàng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE KHACHHANG SET HoTen=@ten, CMND=@cmnd, SoDienThoai=@sdt, GioiTinh=@gt, DiaChi=@dc WHERE IDKhachHang=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@cmnd", txtCMND.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@gt", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@id", selectedID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Cập nhật thành công!");
                LoadDanhSachKhachHang();
                ClearForm();
            }
        }

        //Xóa khách hàng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM KHACHHANG WHERE IDKhachHang=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Đã xóa khách hàng!");
            LoadDanhSachKhachHang();
            ClearForm();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //Hàm tìm kiếm khách hàng theo tên hoặc số điện thoại
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (keyword == "")
            {
                MessageBox.Show("Vui lòng nhập tên hoặc số điện thoại để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT IDKhachHang, HoTen, CMND, SoDienThoai, GioiTinh, DiaChi 
                             FROM KHACHHANG
                             WHERE HoTen LIKE @kw OR SoDienThoai LIKE @kw";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvKhachHang.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //út hiển thị lại toàn bộ danh sách
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDanhSachKhachHang();
        }

    }
}
