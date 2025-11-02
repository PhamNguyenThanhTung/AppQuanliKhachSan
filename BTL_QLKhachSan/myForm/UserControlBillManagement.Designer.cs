namespace BTL_QLKhachSan.myForm
{
    partial class UserControlBillManagement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtnvlap = new System.Windows.Forms.TextBox();
            this.dtpngaylap = new System.Windows.Forms.DateTimePicker();
            this.txtmahd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtcccd = new System.Windows.Forms.TextBox();
            this.txtsodt = new System.Windows.Forms.TextBox();
            this.txttenkh = new System.Windows.Forms.TextBox();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.checklistboxphong = new System.Windows.Forms.CheckedListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvhoadonthanhtoan = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbtrangthai = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbhinhthucthanhtoan = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.txtgiamgia = new System.Windows.Forms.TextBox();
            this.txttiendichvu = new System.Windows.Forms.TextBox();
            this.txttienphong = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btsua = new System.Windows.Forms.Button();
            this.btninhoadon = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.cbtimkiem = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadonthanhtoan)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtnvlap);
            this.groupBox1.Controls.Add(this.dtpngaylap);
            this.groupBox1.Controls.Add(this.txtmahd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(80, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "thông tin hóa đơn";
            // 
            // txtnvlap
            // 
            this.txtnvlap.Location = new System.Drawing.Point(141, 110);
            this.txtnvlap.Name = "txtnvlap";
            this.txtnvlap.Size = new System.Drawing.Size(200, 26);
            this.txtnvlap.TabIndex = 5;
            // 
            // dtpngaylap
            // 
            this.dtpngaylap.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpngaylap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaylap.Location = new System.Drawing.Point(141, 71);
            this.dtpngaylap.Name = "dtpngaylap";
            this.dtpngaylap.Size = new System.Drawing.Size(200, 26);
            this.dtpngaylap.TabIndex = 3;
            // 
            // txtmahd
            // 
            this.txtmahd.Location = new System.Drawing.Point(141, 26);
            this.txtmahd.Name = "txtmahd";
            this.txtmahd.Size = new System.Drawing.Size(200, 26);
            this.txtmahd.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "nhân viên lập ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày lập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hóa đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtcccd);
            this.groupBox2.Controls.Add(this.txtsodt);
            this.groupBox2.Controls.Add(this.txttenkh);
            this.groupBox2.Controls.Add(this.txtmakh);
            this.groupBox2.Controls.Add(this.checklistboxphong);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(537, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 202);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "thông tin khách hàng";
            // 
            // txtcccd
            // 
            this.txtcccd.Location = new System.Drawing.Point(150, 173);
            this.txtcccd.Name = "txtcccd";
            this.txtcccd.Size = new System.Drawing.Size(200, 26);
            this.txtcccd.TabIndex = 9;
            // 
            // txtsodt
            // 
            this.txtsodt.Location = new System.Drawing.Point(150, 139);
            this.txtsodt.Name = "txtsodt";
            this.txtsodt.Size = new System.Drawing.Size(200, 26);
            this.txtsodt.TabIndex = 8;
            // 
            // txttenkh
            // 
            this.txttenkh.Location = new System.Drawing.Point(150, 66);
            this.txttenkh.Name = "txttenkh";
            this.txttenkh.Size = new System.Drawing.Size(200, 26);
            this.txttenkh.TabIndex = 6;
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(150, 26);
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(200, 26);
            this.txtmakh.TabIndex = 6;
            // 
            // checklistboxphong
            // 
            this.checklistboxphong.FormattingEnabled = true;
            this.checklistboxphong.Location = new System.Drawing.Point(150, 104);
            this.checklistboxphong.Name = "checklistboxphong";
            this.checklistboxphong.Size = new System.Drawing.Size(200, 27);
            this.checklistboxphong.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "CCCD/CMT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "số điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "số phòng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "tên khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "mã khách hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "HÓA ĐƠN THANH TOÁN";
            // 
            // dgvhoadonthanhtoan
            // 
            this.dgvhoadonthanhtoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhoadonthanhtoan.Location = new System.Drawing.Point(80, 304);
            this.dgvhoadonthanhtoan.Name = "dgvhoadonthanhtoan";
            this.dgvhoadonthanhtoan.RowHeadersWidth = 62;
            this.dgvhoadonthanhtoan.RowTemplate.Height = 28;
            this.dgvhoadonthanhtoan.Size = new System.Drawing.Size(964, 212);
            this.dgvhoadonthanhtoan.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtghichu);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.cbtrangthai);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cbhinhthucthanhtoan);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(80, 635);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(964, 69);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "thông tin thanh toán";
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(754, 26);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(169, 26);
            this.txtghichu.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(628, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "ghi chú";
            // 
            // cbtrangthai
            // 
            this.cbtrangthai.FormattingEnabled = true;
            this.cbtrangthai.Location = new System.Drawing.Point(487, 26);
            this.cbtrangthai.Name = "cbtrangthai";
            this.cbtrangthai.Size = new System.Drawing.Size(121, 28);
            this.cbtrangthai.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(405, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "trạng thái";
            // 
            // cbhinhthucthanhtoan
            // 
            this.cbhinhthucthanhtoan.FormattingEnabled = true;
            this.cbhinhthucthanhtoan.Location = new System.Drawing.Point(172, 31);
            this.cbhinhthucthanhtoan.Name = "cbhinhthucthanhtoan";
            this.cbhinhthucthanhtoan.Size = new System.Drawing.Size(217, 28);
            this.cbhinhthucthanhtoan.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hình thức thanh toán";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txttongtien);
            this.groupBox4.Controls.Add(this.txtgiamgia);
            this.groupBox4.Controls.Add(this.txttiendichvu);
            this.groupBox4.Controls.Add(this.txttienphong);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(80, 522);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(964, 101);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tổng tiền";
            // 
            // txttongtien
            // 
            this.txttongtien.Location = new System.Drawing.Point(655, 66);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.Size = new System.Drawing.Size(250, 26);
            this.txttongtien.TabIndex = 7;
            // 
            // txtgiamgia
            // 
            this.txtgiamgia.Location = new System.Drawing.Point(655, 19);
            this.txtgiamgia.Name = "txtgiamgia";
            this.txtgiamgia.Size = new System.Drawing.Size(250, 26);
            this.txtgiamgia.TabIndex = 6;
            // 
            // txttiendichvu
            // 
            this.txttiendichvu.Location = new System.Drawing.Point(172, 63);
            this.txttiendichvu.Name = "txttiendichvu";
            this.txttiendichvu.Size = new System.Drawing.Size(250, 26);
            this.txttiendichvu.TabIndex = 5;
            // 
            // txttienphong
            // 
            this.txttienphong.Location = new System.Drawing.Point(172, 19);
            this.txttienphong.Name = "txttienphong";
            this.txttienphong.Size = new System.Drawing.Size(250, 26);
            this.txttienphong.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(498, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "Tổng thang toán";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(498, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Giảm giá";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Tổng tiền dịch vụ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Tổng tiền phòng";
            // 
            // btsua
            // 
            this.btsua.Location = new System.Drawing.Point(187, 723);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(128, 51);
            this.btsua.TabIndex = 7;
            this.btsua.Text = "Sửa";
            this.btsua.UseVisualStyleBackColor = true;
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
            // 
            // btninhoadon
            // 
            this.btninhoadon.Location = new System.Drawing.Point(652, 723);
            this.btninhoadon.Name = "btninhoadon";
            this.btninhoadon.Size = new System.Drawing.Size(128, 51);
            this.btninhoadon.TabIndex = 8;
            this.btninhoadon.Text = "In hóa đơn";
            this.btninhoadon.UseVisualStyleBackColor = true;
            this.btninhoadon.Click += new System.EventHandler(this.btninhoadon_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(252, 261);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(108, 37);
            this.btntimkiem.TabIndex = 10;
            this.btntimkiem.Text = "tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click_1);
            // 
            // cbtimkiem
            // 
            this.cbtimkiem.FormattingEnabled = true;
            this.cbtimkiem.Location = new System.Drawing.Point(83, 261);
            this.cbtimkiem.Name = "cbtimkiem";
            this.cbtimkiem.Size = new System.Drawing.Size(121, 28);
            this.cbtimkiem.TabIndex = 12;
            // 
            // UserControlBillManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbtimkiem);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.btninhoadon);
            this.Controls.Add(this.btsua);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvhoadonthanhtoan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlBillManagement";
            this.Size = new System.Drawing.Size(1100, 791);
            this.Load += new System.EventHandler(this.UserControlBillManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadonthanhtoan)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnvlap;
        private System.Windows.Forms.DateTimePicker dtpngaylap;
        private System.Windows.Forms.TextBox txtmahd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcccd;
        private System.Windows.Forms.TextBox txtsodt;
        private System.Windows.Forms.TextBox txttenkh;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.CheckedListBox checklistboxphong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvhoadonthanhtoan;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbtrangthai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbhinhthucthanhtoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.TextBox txtgiamgia;
        private System.Windows.Forms.TextBox txttiendichvu;
        private System.Windows.Forms.TextBox txttienphong;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btsua;
        private System.Windows.Forms.Button btninhoadon;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.ComboBox cbtimkiem;
    }
}