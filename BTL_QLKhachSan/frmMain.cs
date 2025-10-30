using BTL_QLKhachSan.myForm;
using BTL_QLKhachSan.QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace BTL_QLKhachSan
{
    public partial class frmMain : Form
    {
        public String username;
        private int LoaiTk;
        public frmMain()
        {
            InitializeComponent();

        }

        private void loadUserControl(UserControl uc)
        {
            // Xóa control cũ
            panel_main.Controls.Clear();

            // Cấu hình usercontrol mới
            uc.Dock = DockStyle.Fill;

            // Thêm vào panel
            panel_main.Controls.Add(uc);

            // Đưa usercontrol ra trước cùng
            uc.BringToFront();
        }

        // Constructor mới để nhận dữ liệu từ frmLogin
        public frmMain(string displayName, int accountType) : this() // : this() sẽ gọi constructor mặc định ở trên
        {
            this.username = displayName;
            this.LoaiTk = accountType;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            loadUserControl(new UC_Dashboard());//hiểm thị dashboard ngay khi load


            // Hiển thị tên đăng nhập
            label_userName.Text = username;

            // Lấy và hiển thị loại tài khoản
            string tenLoai = LayTenLoaiTaiKhoan(LoaiTk);
            label_LoaiTaiKhoan.Text = tenLoai;

            // Phân quyền nếu cần
            if (LoaiTk == 2)
            {
                // Ẩn các nút chỉ dành cho Admin
                // btnQuanLyNhanVien.Visible = false;
                // btnDoanhThu.Visible = false;
            }
        }

        public void DrawGradient(Control control, Color color1, Color color2, LinearGradientMode mode)
        {
            // Gắn sự kiện Paint để vẽ gradient
            control.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    control.ClientRectangle, color1, color2, mode))
                {
                    e.Graphics.FillRectangle(brush, control.ClientRectangle);
                }
            };

            // Yêu cầu control vẽ lại ngay
            control.Invalidate();
        }
     

        private void linkLabel_logOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Thay vì thoát hẳn, nên quay về form Login
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Mở lại form login
                frmLogin loginForm = new frmLogin();
                loginForm.Show();

                // Đóng form main (sự kiện FormClosed đã được gán ở frmLogin)
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_datetime.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss tt");
            label_userName.Text = username;
        }

       

        private void cboLoaiTK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //hiển thị quyền truy cập
        private string LayTenLoaiTaiKhoan(int idLoai)
        {
            string tenLoai = "Không xác định";
            string connectionString = "Data Source=LOMG\\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True"; // chỉnh lại chuỗi kết nối của bạn

            string query = "SELECT TenLoaiTK FROM LOAITAIKHOAN WHERE IDLoaiTK = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", idLoai);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    tenLoai = result.ToString();
                }
            }

            return tenLoai;
        }


        //di chuyển panel
        private void movePanel(Control btn)
        {
            //MessageBox.Show($"Before move: {panel_slide.Top} -> New: {btn.Top}");
            panel_slide.Top = btn.Top;
            panel_slide.Height = btn.Height;
        }

        private void button_dashboard_Click(object sender, EventArgs e)
        {
            movePanel(button_dashboard);
            loadUserControl(new UC_Dashboard());
        }

        private void button_khachhang_Click(object sender, EventArgs e)
        {
            movePanel(button_khachhang);
            loadUserControl(new UC_KhachHang());
        }

        private void button_nhanvien_Click(object sender, EventArgs e)
        {
            movePanel(button_nhanvien);
            loadUserControl(new UC_NhanVien());
        }

        private void button_phong_Click(object sender, EventArgs e)
        {
            movePanel(button_phong);
            loadUserControl(new UC_Phong());
        }

        private void button_hoadon_Click(object sender, EventArgs e)
        {
            movePanel(button_hoadon);
            loadUserControl(new UC_HoaDon());
        }

        //di chuyển panel end


        private void panel_dashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAdmin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLeTan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_adminCount_Click(object sender, EventArgs e)
        {

        }

        private void panel_Dashboard_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
