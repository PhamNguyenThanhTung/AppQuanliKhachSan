using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_QLKhachSan.QuanLy
{
    public partial class UC_Dashboard : UserControl
    {
        string connectionString = "Data Source=LOMG\\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True";

        public UC_Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Đếm số tài khoản từng loại
            label_adminCount.Text = DemSoTaiKhoanTheoLoai(1).ToString(); // 1 = Admin
            label_letanCount.Text = DemSoTaiKhoanTheoLoai(2).ToString(); // 2 = Lễ tân

            // Đếm số phòng
            label_phongCount.Text = DemSoPhong().ToString();
        }

        private int DemSoTaiKhoanTheoLoai(int idLoaiTK)
        {
            int soLuong = 0;
            string query = "SELECT COUNT(*) FROM TAIKHOAN WHERE IDLoaiTK = @idLoaiTK";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idLoaiTK", idLoaiTK);
                conn.Open();
                soLuong = (int)cmd.ExecuteScalar();
            }
            return soLuong;
        }

        private int DemSoPhong()
        {
            int soLuong = 0;
            string query = "SELECT COUNT(*) FROM PHONG";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                soLuong = (int)cmd.ExecuteScalar();
            }
            return soLuong;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
