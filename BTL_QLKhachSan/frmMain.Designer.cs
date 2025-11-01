namespace BTL_QLKhachSan
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.gradientPanel4 = new BTL_QLKhachSan.myClass.GradientPanel();
            this.label_datetime = new System.Windows.Forms.Label();
            this.linkLabel_logOut = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uC_BaoCaoDoanhThu1 = new BTL_QLKhachSan.myForm.UC_BaoCaoDoanhThu();
            this.uC_KhachHang1 = new BTL_QLKhachSan.myForm.UC_KhachHang();
            this.gradientPanel3 = new BTL_QLKhachSan.myClass.GradientPanel();
            this.label_userName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientPanel1 = new BTL_QLKhachSan.myClass.GradientPanel();
            this.button_datPhong = new System.Windows.Forms.Button();
            this.button_doanhthu = new System.Windows.Forms.Button();
            this.panel_slide = new System.Windows.Forms.Panel();
            this.button_hoadon = new System.Windows.Forms.Button();
            this.button_nhanvien = new System.Windows.Forms.Button();
            this.button_khachhang = new System.Windows.Forms.Button();
            this.button_daskboard = new System.Windows.Forms.Button();
            this.gradientPanel2 = new BTL_QLKhachSan.myClass.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.uC_NhanVien1 = new BTL_QLKhachSan.myForm.UC_NhanVien();
            this.uC_BookingManagemen1 = new BTL_QLKhachSan.myForm.UC_BookingManagemen();
            this.button_booking = new System.Windows.Forms.Button();
            this.userControlBooking1 = new BTL_QLKhachSan.myForm.UserControlBooking();
            this.userControlOrderService1 = new BTL_QLKhachSan.myForm.UserControlOrderService();
            this.button_dichvu = new System.Windows.Forms.Button();
            this.userControlBillManagement1 = new BTL_QLKhachSan.myForm.UserControlBillManagement();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gradientPanel3.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gradientPanel4);
            this.panel2.Controls.Add(this.label_datetime);
            this.panel2.Controls.Add(this.linkLabel_logOut);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(233, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 81);
            this.panel2.TabIndex = 3;
            // 
            // gradientPanel4
            // 
            this.gradientPanel4.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.gradientPanel4.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel4.EnableDynamicGradient = false;
            this.gradientPanel4.GradientAngle = 0F;
            this.gradientPanel4.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel4.Name = "gradientPanel4";
            this.gradientPanel4.Size = new System.Drawing.Size(200, 100);
            this.gradientPanel4.TabIndex = 3;
            // 
            // label_datetime
            // 
            this.label_datetime.AutoSize = true;
            this.label_datetime.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_datetime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_datetime.Location = new System.Drawing.Point(52, 21);
            this.label_datetime.Name = "label_datetime";
            this.label_datetime.Size = new System.Drawing.Size(21, 27);
            this.label_datetime.TabIndex = 2;
            this.label_datetime.Text = "?";
            // 
            // linkLabel_logOut
            // 
            this.linkLabel_logOut.AutoSize = true;
            this.linkLabel_logOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel_logOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_logOut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.linkLabel_logOut.Location = new System.Drawing.Point(1194, 42);
            this.linkLabel_logOut.Name = "linkLabel_logOut";
            this.linkLabel_logOut.Size = new System.Drawing.Size(83, 25);
            this.linkLabel_logOut.TabIndex = 1;
            this.linkLabel_logOut.TabStop = true;
            this.linkLabel_logOut.Text = "LogOut";
            this.linkLabel_logOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_logOut_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1088, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uC_BaoCaoDoanhThu1
            // 
            this.uC_BaoCaoDoanhThu1.AutoScroll = true;
            this.uC_BaoCaoDoanhThu1.BackColor = System.Drawing.Color.White;
            this.uC_BaoCaoDoanhThu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_BaoCaoDoanhThu1.Location = new System.Drawing.Point(233, 125);
            this.uC_BaoCaoDoanhThu1.Name = "uC_BaoCaoDoanhThu1";
            this.uC_BaoCaoDoanhThu1.Size = new System.Drawing.Size(949, 565);
            this.uC_BaoCaoDoanhThu1.TabIndex = 6;
            this.uC_BaoCaoDoanhThu1.Visible = false;
            // 
            // uC_KhachHang1
            // 
            this.uC_KhachHang1.BackColor = System.Drawing.Color.White;
            this.uC_KhachHang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_KhachHang1.Location = new System.Drawing.Point(233, 125);
            this.uC_KhachHang1.Name = "uC_KhachHang1";
            this.uC_KhachHang1.Size = new System.Drawing.Size(949, 565);
            this.uC_KhachHang1.TabIndex = 5;
            this.uC_KhachHang1.Visible = false;
            // 
            // gradientPanel3
            // 
            this.gradientPanel3.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.gradientPanel3.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel3.Controls.Add(this.label_userName);
            this.gradientPanel3.Controls.Add(this.label2);
            this.gradientPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel3.EnableDynamicGradient = true;
            this.gradientPanel3.GradientAngle = 0F;
            this.gradientPanel3.Location = new System.Drawing.Point(233, 81);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(949, 44);
            this.gradientPanel3.TabIndex = 4;
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.BackColor = System.Drawing.Color.Transparent;
            this.label_userName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_userName.ForeColor = System.Drawing.Color.LightCyan;
            this.label_userName.Location = new System.Drawing.Point(162, 14);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(21, 25);
            this.label_userName.TabIndex = 4;
            this.label_userName.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Xin chào :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.gradientPanel1.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel1.Controls.Add(this.button_dichvu);
            this.gradientPanel1.Controls.Add(this.button_booking);
            this.gradientPanel1.Controls.Add(this.button_datPhong);
            this.gradientPanel1.Controls.Add(this.button_doanhthu);
            this.gradientPanel1.Controls.Add(this.panel_slide);
            this.gradientPanel1.Controls.Add(this.button_hoadon);
            this.gradientPanel1.Controls.Add(this.button_nhanvien);
            this.gradientPanel1.Controls.Add(this.button_khachhang);
            this.gradientPanel1.Controls.Add(this.button_daskboard);
            this.gradientPanel1.Controls.Add(this.gradientPanel2);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gradientPanel1.EnableDynamicGradient = true;
            this.gradientPanel1.GradientAngle = 0F;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(233, 690);
            this.gradientPanel1.TabIndex = 0;
            // 
            // button_datPhong
            // 
            this.button_datPhong.BackColor = System.Drawing.Color.Transparent;
            this.button_datPhong.FlatAppearance.BorderSize = 0;
            this.button_datPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_datPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_datPhong.ForeColor = System.Drawing.Color.White;
            this.button_datPhong.Image = ((System.Drawing.Image)(resources.GetObject("button_datPhong.Image")));
            this.button_datPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_datPhong.Location = new System.Drawing.Point(31, 385);
            this.button_datPhong.Name = "button_datPhong";
            this.button_datPhong.Size = new System.Drawing.Size(185, 58);
            this.button_datPhong.TabIndex = 8;
            this.button_datPhong.Text = "Quản Lý Đặt phòng";
            this.button_datPhong.UseVisualStyleBackColor = false;
            this.button_datPhong.Click += new System.EventHandler(this.button_datPhong_Click);
            // 
            // button_doanhthu
            // 
            this.button_doanhthu.BackColor = System.Drawing.Color.Transparent;
            this.button_doanhthu.FlatAppearance.BorderSize = 0;
            this.button_doanhthu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_doanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_doanhthu.ForeColor = System.Drawing.Color.White;
            this.button_doanhthu.Image = ((System.Drawing.Image)(resources.GetObject("button_doanhthu.Image")));
            this.button_doanhthu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_doanhthu.Location = new System.Drawing.Point(28, 193);
            this.button_doanhthu.Name = "button_doanhthu";
            this.button_doanhthu.Size = new System.Drawing.Size(182, 58);
            this.button_doanhthu.TabIndex = 7;
            this.button_doanhthu.Text = "    Doanh Thu";
            this.button_doanhthu.UseVisualStyleBackColor = false;
            this.button_doanhthu.Click += new System.EventHandler(this.button_doanhthu_Click);
            // 
            // panel_slide
            // 
            this.panel_slide.Location = new System.Drawing.Point(15, 129);
            this.panel_slide.Name = "panel_slide";
            this.panel_slide.Size = new System.Drawing.Size(10, 58);
            this.panel_slide.TabIndex = 6;
            // 
            // button_hoadon
            // 
            this.button_hoadon.BackColor = System.Drawing.Color.Transparent;
            this.button_hoadon.FlatAppearance.BorderSize = 0;
            this.button_hoadon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_hoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_hoadon.ForeColor = System.Drawing.Color.White;
            this.button_hoadon.Image = ((System.Drawing.Image)(resources.GetObject("button_hoadon.Image")));
            this.button_hoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_hoadon.Location = new System.Drawing.Point(25, 577);
            this.button_hoadon.Name = "button_hoadon";
            this.button_hoadon.Size = new System.Drawing.Size(185, 58);
            this.button_hoadon.TabIndex = 5;
            this.button_hoadon.Text = "    Hóa đơn";
            this.button_hoadon.UseVisualStyleBackColor = false;
            this.button_hoadon.Click += new System.EventHandler(this.button_hoadon_Click);
            // 
            // button_nhanvien
            // 
            this.button_nhanvien.BackColor = System.Drawing.Color.Transparent;
            this.button_nhanvien.FlatAppearance.BorderSize = 0;
            this.button_nhanvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_nhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_nhanvien.ForeColor = System.Drawing.Color.White;
            this.button_nhanvien.Image = ((System.Drawing.Image)(resources.GetObject("button_nhanvien.Image")));
            this.button_nhanvien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_nhanvien.Location = new System.Drawing.Point(25, 449);
            this.button_nhanvien.Name = "button_nhanvien";
            this.button_nhanvien.Size = new System.Drawing.Size(185, 58);
            this.button_nhanvien.TabIndex = 3;
            this.button_nhanvien.Text = "    Nhân viên";
            this.button_nhanvien.UseVisualStyleBackColor = false;
            this.button_nhanvien.Click += new System.EventHandler(this.button_nhanvien_Click);
            // 
            // button_khachhang
            // 
            this.button_khachhang.BackColor = System.Drawing.Color.Transparent;
            this.button_khachhang.FlatAppearance.BorderSize = 0;
            this.button_khachhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_khachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_khachhang.ForeColor = System.Drawing.Color.White;
            this.button_khachhang.Image = ((System.Drawing.Image)(resources.GetObject("button_khachhang.Image")));
            this.button_khachhang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_khachhang.Location = new System.Drawing.Point(25, 513);
            this.button_khachhang.Name = "button_khachhang";
            this.button_khachhang.Size = new System.Drawing.Size(185, 58);
            this.button_khachhang.TabIndex = 2;
            this.button_khachhang.Text = "    Khách hàng";
            this.button_khachhang.UseVisualStyleBackColor = false;
            this.button_khachhang.Click += new System.EventHandler(this.button_khachhang_Click);
            // 
            // button_daskboard
            // 
            this.button_daskboard.BackColor = System.Drawing.Color.Transparent;
            this.button_daskboard.FlatAppearance.BorderSize = 0;
            this.button_daskboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_daskboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_daskboard.ForeColor = System.Drawing.Color.White;
            this.button_daskboard.Image = ((System.Drawing.Image)(resources.GetObject("button_daskboard.Image")));
            this.button_daskboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_daskboard.Location = new System.Drawing.Point(31, 129);
            this.button_daskboard.Name = "button_daskboard";
            this.button_daskboard.Size = new System.Drawing.Size(185, 58);
            this.button_daskboard.TabIndex = 1;
            this.button_daskboard.Text = "    Daskboard";
            this.button_daskboard.UseVisualStyleBackColor = false;
            this.button_daskboard.Click += new System.EventHandler(this.button_daskboard_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.gradientPanel2.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.pictureBox2);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.EnableDynamicGradient = true;
            this.gradientPanel2.GradientAngle = 0F;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(233, 109);
            this.gradientPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản lý khách sạn";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(59, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // uC_NhanVien1
            // 
            this.uC_NhanVien1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_NhanVien1.Location = new System.Drawing.Point(233, 125);
            this.uC_NhanVien1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_NhanVien1.Name = "uC_NhanVien1";
            this.uC_NhanVien1.Size = new System.Drawing.Size(949, 565);
            this.uC_NhanVien1.TabIndex = 7;
            this.uC_NhanVien1.Visible = false;
            // 
            // uC_BookingManagemen1
            // 
            this.uC_BookingManagemen1.BackColor = System.Drawing.Color.White;
            this.uC_BookingManagemen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_BookingManagemen1.Location = new System.Drawing.Point(233, 125);
            this.uC_BookingManagemen1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uC_BookingManagemen1.Name = "uC_BookingManagemen1";
            this.uC_BookingManagemen1.Size = new System.Drawing.Size(949, 565);
            this.uC_BookingManagemen1.TabIndex = 8;
            this.uC_BookingManagemen1.Visible = false;
            // 
            // button_booking
            // 
            this.button_booking.BackColor = System.Drawing.Color.Transparent;
            this.button_booking.FlatAppearance.BorderSize = 0;
            this.button_booking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_booking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_booking.ForeColor = System.Drawing.Color.White;
            this.button_booking.Image = ((System.Drawing.Image)(resources.GetObject("button_booking.Image")));
            this.button_booking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_booking.Location = new System.Drawing.Point(31, 257);
            this.button_booking.Name = "button_booking";
            this.button_booking.Size = new System.Drawing.Size(185, 58);
            this.button_booking.TabIndex = 9;
            this.button_booking.Text = "Đặt phòng";
            this.button_booking.UseVisualStyleBackColor = false;
            this.button_booking.Click += new System.EventHandler(this.button_booking_Click);
            // 
            // userControlBooking1
            // 
            this.userControlBooking1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlBooking1.Location = new System.Drawing.Point(233, 125);
            this.userControlBooking1.Name = "userControlBooking1";
            this.userControlBooking1.Size = new System.Drawing.Size(949, 565);
            this.userControlBooking1.TabIndex = 9;
            this.userControlBooking1.Visible = false;
            // 
            // userControlOrderService1
            // 
            this.userControlOrderService1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlOrderService1.Location = new System.Drawing.Point(233, 125);
            this.userControlOrderService1.Name = "userControlOrderService1";
            this.userControlOrderService1.Size = new System.Drawing.Size(949, 565);
            this.userControlOrderService1.TabIndex = 10;
            this.userControlOrderService1.Visible = false;
            // 
            // button_dichvu
            // 
            this.button_dichvu.BackColor = System.Drawing.Color.Transparent;
            this.button_dichvu.FlatAppearance.BorderSize = 0;
            this.button_dichvu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dichvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dichvu.ForeColor = System.Drawing.Color.White;
            this.button_dichvu.Image = ((System.Drawing.Image)(resources.GetObject("button_dichvu.Image")));
            this.button_dichvu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_dichvu.Location = new System.Drawing.Point(25, 321);
            this.button_dichvu.Name = "button_dichvu";
            this.button_dichvu.Size = new System.Drawing.Size(185, 58);
            this.button_dichvu.TabIndex = 10;
            this.button_dichvu.Text = "Thêm dịch vụ";
            this.button_dichvu.UseVisualStyleBackColor = false;
            this.button_dichvu.Click += new System.EventHandler(this.button_dichvu_Click);
            // 
            // userControlBillManagement1
            // 
            this.userControlBillManagement1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlBillManagement1.Location = new System.Drawing.Point(233, 125);
            this.userControlBillManagement1.Name = "userControlBillManagement1";
            this.userControlBillManagement1.Size = new System.Drawing.Size(949, 565);
            this.userControlBillManagement1.TabIndex = 11;
            this.userControlBillManagement1.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 690);
            this.Controls.Add(this.userControlBillManagement1);
            this.Controls.Add(this.userControlOrderService1);
            this.Controls.Add(this.userControlBooking1);
            this.Controls.Add(this.uC_BookingManagemen1);
            this.Controls.Add(this.uC_NhanVien1);
            this.Controls.Add(this.uC_BaoCaoDoanhThu1);
            this.Controls.Add(this.uC_KhachHang1);
            this.Controls.Add(this.gradientPanel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách sạn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gradientPanel3.ResumeLayout(false);
            this.gradientPanel3.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myClass.GradientPanel gradientPanel1;
        private myClass.GradientPanel gradientPanel2;
        private System.Windows.Forms.Panel panel2;
        private myClass.GradientPanel gradientPanel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel_logOut;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_datetime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Button button_daskboard;
        private System.Windows.Forms.Button button_hoadon;
        private System.Windows.Forms.Button button_nhanvien;
        private System.Windows.Forms.Button button_khachhang;
        private myClass.GradientPanel gradientPanel4;
        private System.Windows.Forms.Panel panel_slide;
        private System.Windows.Forms.Timer timer1;
        private myForm.UC_KhachHang uC_KhachHang1;
        private System.Windows.Forms.Button button_doanhthu;
        private myForm.UC_BaoCaoDoanhThu uC_BaoCaoDoanhThu1;
        private myForm.UC_NhanVien uC_NhanVien1;
        private System.Windows.Forms.Button button_datPhong;
        private myForm.UC_BookingManagemen uC_BookingManagemen1;
        private System.Windows.Forms.Button button_booking;
        private myForm.UserControlBooking userControlBooking1;
        private System.Windows.Forms.Button button_dichvu;
        private myForm.UserControlOrderService userControlOrderService1;
        private myForm.UserControlBillManagement userControlBillManagement1;
    }
}

