﻿namespace BTL_QLKhachSan
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
            this.linkLabel_logOut = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_datetime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_main = new System.Windows.Forms.Panel();
            this.gradientPanel3 = new BTL_QLKhachSan.myClass.GradientPanel();
            this.label_LoaiTaiKhoan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_userName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientPanel4 = new BTL_QLKhachSan.myClass.GradientPanel();
            this.gradientPanel1 = new BTL_QLKhachSan.myClass.GradientPanel();
            this.panel_slide = new System.Windows.Forms.Panel();
            this.button_hoadon = new System.Windows.Forms.Button();
            this.button_phong = new System.Windows.Forms.Button();
            this.button_nhanvien = new System.Windows.Forms.Button();
            this.button_khachhang = new System.Windows.Forms.Button();
            this.button_dashboard = new System.Windows.Forms.Button();
            this.gradientPanel2 = new BTL_QLKhachSan.myClass.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
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
            this.panel2.Controls.Add(this.linkLabel_logOut);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(192, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 65);
            this.panel2.TabIndex = 3;
            // 
            // linkLabel_logOut
            // 
            this.linkLabel_logOut.AutoSize = true;
            this.linkLabel_logOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel_logOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_logOut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.linkLabel_logOut.Location = new System.Drawing.Point(601, 21);
            this.linkLabel_logOut.Name = "linkLabel_logOut";
            this.linkLabel_logOut.Size = new System.Drawing.Size(70, 20);
            this.linkLabel_logOut.TabIndex = 1;
            this.linkLabel_logOut.TabStop = true;
            this.linkLabel_logOut.Text = "LogOut";
            this.linkLabel_logOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_logOut_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(526, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_datetime
            // 
            this.label_datetime.AutoSize = true;
            this.label_datetime.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_datetime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_datetime.Location = new System.Drawing.Point(376, 21);
            this.label_datetime.Name = "label_datetime";
            this.label_datetime.Size = new System.Drawing.Size(18, 24);
            this.label_datetime.TabIndex = 2;
            this.label_datetime.Text = "?";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel_main
            // 
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(192, 100);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(683, 431);
            this.panel_main.TabIndex = 0;
            this.panel_main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Dashboard_Paint_1);
            // 
            // gradientPanel3
            // 
            this.gradientPanel3.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.gradientPanel3.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel3.Controls.Add(this.label_LoaiTaiKhoan);
            this.gradientPanel3.Controls.Add(this.label3);
            this.gradientPanel3.Controls.Add(this.label_userName);
            this.gradientPanel3.Controls.Add(this.label2);
            this.gradientPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel3.EnableDynamicGradient = true;
            this.gradientPanel3.GradientAngle = 0F;
            this.gradientPanel3.Location = new System.Drawing.Point(192, 65);
            this.gradientPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(683, 35);
            this.gradientPanel3.TabIndex = 4;
            // 
            // label_LoaiTaiKhoan
            // 
            this.label_LoaiTaiKhoan.AutoSize = true;
            this.label_LoaiTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.label_LoaiTaiKhoan.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LoaiTaiKhoan.ForeColor = System.Drawing.Color.LightCyan;
            this.label_LoaiTaiKhoan.Location = new System.Drawing.Point(533, 11);
            this.label_LoaiTaiKhoan.Name = "label_LoaiTaiKhoan";
            this.label_LoaiTaiKhoan.Size = new System.Drawing.Size(111, 19);
            this.label_LoaiTaiKhoan.TabIndex = 6;
            this.label_LoaiTaiKhoan.Text = "loại tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(385, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loại tài khoản :";
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.BackColor = System.Drawing.Color.Transparent;
            this.label_userName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_userName.ForeColor = System.Drawing.Color.LightCyan;
            this.label_userName.Location = new System.Drawing.Point(144, 11);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(16, 19);
            this.label_userName.TabIndex = 4;
            this.label_userName.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Xin chào :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gradientPanel4
            // 
            this.gradientPanel4.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.gradientPanel4.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel4.EnableDynamicGradient = false;
            this.gradientPanel4.GradientAngle = 0F;
            this.gradientPanel4.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradientPanel4.Name = "gradientPanel4";
            this.gradientPanel4.Size = new System.Drawing.Size(160, 80);
            this.gradientPanel4.TabIndex = 3;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.gradientPanel1.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel1.Controls.Add(this.panel_slide);
            this.gradientPanel1.Controls.Add(this.button_hoadon);
            this.gradientPanel1.Controls.Add(this.button_phong);
            this.gradientPanel1.Controls.Add(this.button_nhanvien);
            this.gradientPanel1.Controls.Add(this.button_khachhang);
            this.gradientPanel1.Controls.Add(this.button_dashboard);
            this.gradientPanel1.Controls.Add(this.gradientPanel2);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gradientPanel1.EnableDynamicGradient = true;
            this.gradientPanel1.GradientAngle = 0F;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(192, 531);
            this.gradientPanel1.TabIndex = 0;
            // 
            // panel_slide
            // 
            this.panel_slide.Location = new System.Drawing.Point(13, 103);
            this.panel_slide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_slide.Name = "panel_slide";
            this.panel_slide.Size = new System.Drawing.Size(9, 46);
            this.panel_slide.TabIndex = 0;
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
            this.button_hoadon.Location = new System.Drawing.Point(28, 308);
            this.button_hoadon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_hoadon.Name = "button_hoadon";
            this.button_hoadon.Size = new System.Drawing.Size(164, 46);
            this.button_hoadon.TabIndex = 5;
            this.button_hoadon.Text = "Hóa đơn";
            this.button_hoadon.UseVisualStyleBackColor = false;
            this.button_hoadon.Click += new System.EventHandler(this.button_hoadon_Click);
            // 
            // button_phong
            // 
            this.button_phong.BackColor = System.Drawing.Color.Transparent;
            this.button_phong.FlatAppearance.BorderSize = 0;
            this.button_phong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_phong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_phong.ForeColor = System.Drawing.Color.White;
            this.button_phong.Image = ((System.Drawing.Image)(resources.GetObject("button_phong.Image")));
            this.button_phong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_phong.Location = new System.Drawing.Point(28, 257);
            this.button_phong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_phong.Name = "button_phong";
            this.button_phong.Size = new System.Drawing.Size(164, 46);
            this.button_phong.TabIndex = 4;
            this.button_phong.Text = "Phòng";
            this.button_phong.UseVisualStyleBackColor = false;
            this.button_phong.Click += new System.EventHandler(this.button_phong_Click);
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
            this.button_nhanvien.Location = new System.Drawing.Point(28, 206);
            this.button_nhanvien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_nhanvien.Name = "button_nhanvien";
            this.button_nhanvien.Size = new System.Drawing.Size(164, 46);
            this.button_nhanvien.TabIndex = 3;
            this.button_nhanvien.Text = "Nhân viên";
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
            this.button_khachhang.Location = new System.Drawing.Point(28, 154);
            this.button_khachhang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_khachhang.Name = "button_khachhang";
            this.button_khachhang.Size = new System.Drawing.Size(164, 46);
            this.button_khachhang.TabIndex = 2;
            this.button_khachhang.Text = "Khách hàng";
            this.button_khachhang.UseVisualStyleBackColor = false;
            this.button_khachhang.Click += new System.EventHandler(this.button_khachhang_Click);
            // 
            // button_dashboard
            // 
            this.button_dashboard.BackColor = System.Drawing.Color.Transparent;
            this.button_dashboard.FlatAppearance.BorderSize = 0;
            this.button_dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dashboard.ForeColor = System.Drawing.Color.White;
            this.button_dashboard.Image = ((System.Drawing.Image)(resources.GetObject("button_dashboard.Image")));
            this.button_dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_dashboard.Location = new System.Drawing.Point(28, 103);
            this.button_dashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_dashboard.Name = "button_dashboard";
            this.button_dashboard.Size = new System.Drawing.Size(164, 46);
            this.button_dashboard.TabIndex = 1;
            this.button_dashboard.Text = "Dashboard";
            this.button_dashboard.UseVisualStyleBackColor = false;
            this.button_dashboard.Click += new System.EventHandler(this.button_dashboard_Click);
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
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(192, 87);
            this.gradientPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản lý khách sạn";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(52, 10);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 531);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.gradientPanel3);
            this.Controls.Add(this.label_datetime);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gradientPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Button button_dashboard;
        private System.Windows.Forms.Button button_hoadon;
        private System.Windows.Forms.Button button_phong;
        private System.Windows.Forms.Button button_nhanvien;
        private System.Windows.Forms.Button button_khachhang;
        private System.Windows.Forms.Panel panel_slide;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_LoaiTaiKhoan;
        private myClass.GradientPanel gradientPanel4;
        private System.Windows.Forms.Panel panel_main;
    }
}

