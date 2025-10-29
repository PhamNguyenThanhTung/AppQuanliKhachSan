using System;
using System.Drawing;
using System.Windows.Forms;
using BTL_QLKhachSan; // (để thấy frmMain)
using BTL_QLKhachSan.myClass; // <--- THÊM DÒNG NÀY (để thấy Database.cs)
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BTL_QLKhachSan.myForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ Form
            string loginInput = txtUsername.Text.Trim(); // (Đây có thể là Username hoặc Email)
            string password = txtPassword.Text;

            // 2. Chuẩn bị truy vấn
            // Chọn tất cả thông tin từ TAIKHOAN
            // Nơi (Username = @input HOẶC Email = @input) VÀ Password = @pass
            string sqlQuery = "SELECT * FROM TAIKHOAN " +
                              "WHERE (Username = @loginInput OR Email = @loginInput) AND Password = @password";

            // 3. Tạo danh sách tham số (SqlParameter) để chống SQL Injection
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@loginInput", loginInput));
            parameters.Add(new SqlParameter("@password", password));

            // 4. Thực thi truy vấn
            Database db = new Database();
            DataTable dt = db.GetData(sqlQuery, parameters);

            // 5. Xử lý kết quả
            if (dt.Rows.Count == 1) // Tìm thấy 1 tài khoản
            {
                // Lấy dữ liệu từ hàng (Row) đầu tiên tìm thấy
                DataRow row = dt.Rows[0];
                bool trangThai = (bool)row["TrangThai"];

                if (trangThai == true) // Nếu trạng thái là True (đang hoạt động)
                {
                    // Lấy thông tin người dùng
                    string displayName = row["DisplayName"].ToString();
                    int idLoaiTK = Convert.ToInt32(row["IDLoaiTK"]);

                    // Đăng nhập thành công
                    frmMain main = new frmMain(displayName, idLoaiTK);

                    main.FormClosed += (s, args) => Application.Exit();
                    main.Show();
                    this.Hide();
                }
                else // Nếu trạng thái là False (bị khóa)
                {
                    MessageBox.Show(
                        "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên.",
                        "Lỗi Đăng Nhập",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            else // Không tìm thấy tài khoản nào (Rows.Count == 0)
            {
                MessageBox.Show(
                    "Tên đăng nhập, email hoặc mật khẩu không chính xác.",
                    "Đăng Nhập Thất Bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // (Các hàm còn lại giữ nguyên)
        private void btnShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Please contact your administrator for password recovery.",
                "Forgot Password"
            );
        }

        private void lblAppName_Click(object sender, EventArgs e)
        {

        }
    }
}