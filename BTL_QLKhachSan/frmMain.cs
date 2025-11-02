using BTL_QLKhachSan.myForm;
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
        // Constructor mới để nhận dữ liệu từ frmLogin
        public frmMain(string displayName, int accountType) : this() // : this() sẽ gọi constructor mặc định ở trên
        {
            this.username = displayName;
            this.LoaiTk = accountType;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            uC_NhanVien1.SetLoginInfo(this.LoaiTk, this.username);

            
            if (LoaiTk == 2) // Nếu là Lễ tân
            {
                 this.button_doanhthu.Enabled = false;
                 this.button_nhanvien.Enabled = false;
                
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void movePanel(Control btn)
        {
            panel_slide.Top = btn.Top;
            panel_slide.Height = btn.Height;
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

        private void button_daskboard_Click(object sender, EventArgs e)
        {
            movePanel(button_daskboard);
            uC_KhachHang1.Hide();
            uC_BaoCaoDoanhThu1.Hide();
            uC_NhanVien1.Hide();
            userControlBooking1.Hide();
            uC_BookingManagemen1.Hide();
            userControlBillManagement1.Hide();
            userControlOrderService1.Hide();
            uC_Dashboard1.Show();

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            label_datetime.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss tt");
            label_userName.Text = username;
        }

        private void button_khachhang_Click(object sender, EventArgs e)
        {
            movePanel(button_khachhang);
            uC_KhachHang1.Show();
            uC_KhachHang1.ClearAndRefreshData();
            uC_BaoCaoDoanhThu1.Hide();
            uC_NhanVien1.Hide();
            userControlBooking1.Hide();
            uC_BookingManagemen1.Hide();
            userControlBillManagement1.Hide();
            userControlOrderService1.Hide();
            uC_Dashboard1.Hide();

        }

        private void button_nhanvien_Click(object sender, EventArgs e)
        {
            movePanel(button_nhanvien);
            uC_KhachHang1.Hide();
            uC_BaoCaoDoanhThu1.Hide();
            uC_NhanVien1.Show();
            userControlBooking1.Hide();
            uC_BookingManagemen1.Hide();
            userControlOrderService1.Hide();
            userControlBillManagement1.Hide();
            uC_Dashboard1.Hide();




        }


        private void button_hoadon_Click(object sender, EventArgs e)
        {
            movePanel(button_hoadon);
            uC_KhachHang1.Hide();
            uC_BaoCaoDoanhThu1.Hide();
            uC_NhanVien1.Hide();
            userControlBooking1.Hide();
            uC_BookingManagemen1.Hide();
            userControlOrderService1.Hide();
            userControlBillManagement1.Show();
            uC_Dashboard1.Hide();
        }

        private void button_doanhthu_Click(object sender, EventArgs e)
        {
            movePanel(button_doanhthu);
            uC_BaoCaoDoanhThu1.Show();
            uC_KhachHang1.Hide();
            uC_NhanVien1.Hide();
            userControlBooking1.Hide();
            uC_BookingManagemen1.Hide();
            userControlBillManagement1.Hide();
            uC_Dashboard1.Hide();   
            userControlOrderService1.Hide();
        }

        private void button_datPhong_Click(object sender, EventArgs e)
        {
            movePanel(button_datPhong);
            uC_KhachHang1.Hide();
            uC_BaoCaoDoanhThu1.Hide();
            uC_NhanVien1.Hide();
            uC_BookingManagemen1.Show();
            userControlBooking1.Hide();
            userControlBillManagement1.Hide();
            userControlOrderService1.Hide();
            uC_Dashboard1.Hide();
            userControlBillManagement1.Hide();
        }

        private void button_booking_Click(object sender, EventArgs e)
        {
            movePanel(button_booking);
            uC_KhachHang1.Hide();
            uC_BaoCaoDoanhThu1.Hide();
            uC_NhanVien1.Hide();
            uC_BookingManagemen1.Hide();
            userControlOrderService1.Hide();
            userControlBooking1.Show();
            userControlBillManagement1.Hide();
            uC_Dashboard1.Hide();

        }

        private void button_dichvu_Click(object sender, EventArgs e)
        {
            movePanel(button_dichvu);
            uC_KhachHang1.Hide();
            uC_BaoCaoDoanhThu1.Hide();
            uC_NhanVien1.Hide();
            uC_BookingManagemen1.Hide();
            userControlBooking1.Hide();
            userControlOrderService1.Show();
            userControlBillManagement1.Hide();
            uC_Dashboard1.Hide();
        }
    }
}
