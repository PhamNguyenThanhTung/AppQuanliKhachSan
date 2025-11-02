namespace BTL_QLKhachSan.myForm
{
    partial class UserControlBooking
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpngaynhan = new System.Windows.Forms.DateTimePicker();
            this.dtpngaytra = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvbooking = new System.Windows.Forms.DataGridView();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.txtsodt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.txtccdd = new System.Windows.Forms.TextBox();
            this.txttenkh = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbphong = new System.Windows.Forms.ComboBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbloaiphong = new System.Windows.Forms.ComboBox();
            this.txtsonguoi = new System.Windows.Forms.TextBox();
            this.txttiencoc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbtimkiem = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(448, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "CCCD/CMT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày nhận : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày trả :";
            // 
            // dtpngaynhan
            // 
            this.dtpngaynhan.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpngaynhan.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpngaynhan.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpngaynhan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaynhan.Location = new System.Drawing.Point(154, 101);
            this.dtpngaynhan.Name = "dtpngaynhan";
            this.dtpngaynhan.ShowUpDown = true;
            this.dtpngaynhan.Size = new System.Drawing.Size(194, 26);
            this.dtpngaynhan.TabIndex = 5;
            // 
            // dtpngaytra
            // 
            this.dtpngaytra.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpngaytra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaytra.Location = new System.Drawing.Point(154, 158);
            this.dtpngaytra.Name = "dtpngaytra";
            this.dtpngaytra.ShowUpDown = true;
            this.dtpngaytra.Size = new System.Drawing.Size(194, 26);
            this.dtpngaytra.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "số điện thoại";
            // 
            // dgvbooking
            // 
            this.dgvbooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbooking.Location = new System.Drawing.Point(40, 418);
            this.dgvbooking.Name = "dgvbooking";
            this.dgvbooking.RowHeadersWidth = 62;
            this.dgvbooking.RowTemplate.Height = 28;
            this.dgvbooking.Size = new System.Drawing.Size(988, 238);
            this.dgvbooking.TabIndex = 8;
            this.dgvbooking.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbooking_CellClick);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(60, 674);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(102, 41);
            this.btnthem.TabIndex = 9;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(282, 674);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(101, 41);
            this.btnsua.TabIndex = 10;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(541, 674);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(105, 41);
            this.btnxoa.TabIndex = 11;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // txtsodt
            // 
            this.txtsodt.Location = new System.Drawing.Point(163, 75);
            this.txtsodt.Name = "txtsodt";
            this.txtsodt.Size = new System.Drawing.Size(217, 26);
            this.txtsodt.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtdiachi);
            this.groupBox1.Controls.Add(this.txtccdd);
            this.groupBox1.Controls.Add(this.txttenkh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtsodt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(50, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 251);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin khách hàng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Địa chỉ";
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(163, 190);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(217, 26);
            this.txtdiachi.TabIndex = 17;
            // 
            // txtccdd
            // 
            this.txtccdd.Location = new System.Drawing.Point(163, 124);
            this.txtccdd.Name = "txtccdd";
            this.txtccdd.Size = new System.Drawing.Size(217, 26);
            this.txtccdd.TabIndex = 16;
            // 
            // txttenkh
            // 
            this.txttenkh.Location = new System.Drawing.Point(163, 30);
            this.txttenkh.Name = "txttenkh";
            this.txttenkh.Size = new System.Drawing.Size(217, 26);
            this.txttenkh.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbphong);
            this.groupBox2.Controls.Add(this.txtghichu);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbloaiphong);
            this.groupBox2.Controls.Add(this.txtsonguoi);
            this.groupBox2.Controls.Add(this.txttiencoc);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpngaynhan);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpngaytra);
            this.groupBox2.Location = new System.Drawing.Point(580, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 299);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đặt phòng: ";
            // 
            // cbphong
            // 
            this.cbphong.FormattingEnabled = true;
            this.cbphong.Location = new System.Drawing.Point(154, 62);
            this.cbphong.Name = "cbphong";
            this.cbphong.Size = new System.Drawing.Size(194, 28);
            this.cbphong.TabIndex = 18;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(154, 262);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(194, 26);
            this.txtghichu.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "ghi chú";
            // 
            // cbloaiphong
            // 
            this.cbloaiphong.FormattingEnabled = true;
            this.cbloaiphong.Location = new System.Drawing.Point(154, 28);
            this.cbloaiphong.Name = "cbloaiphong";
            this.cbloaiphong.Size = new System.Drawing.Size(194, 28);
            this.cbloaiphong.TabIndex = 15;
            this.cbloaiphong.SelectedIndexChanged += new System.EventHandler(this.cbloaiphong_SelectedIndexChanged);
            // 
            // txtsonguoi
            // 
            this.txtsonguoi.Location = new System.Drawing.Point(154, 228);
            this.txtsonguoi.Name = "txtsonguoi";
            this.txtsonguoi.Size = new System.Drawing.Size(194, 26);
            this.txtsonguoi.TabIndex = 14;
            // 
            // txttiencoc
            // 
            this.txttiencoc.Location = new System.Drawing.Point(154, 190);
            this.txttiencoc.Name = "txttiencoc";
            this.txttiencoc.Size = new System.Drawing.Size(194, 26);
            this.txttiencoc.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "tiền cọc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "số lượng phòng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Loại phòng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "số người";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(251, 364);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(85, 36);
            this.btntimkiem.TabIndex = 18;
            this.btntimkiem.Text = "tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // cbtimkiem
            // 
            this.cbtimkiem.FormattingEnabled = true;
            this.cbtimkiem.Location = new System.Drawing.Point(81, 364);
            this.cbtimkiem.Name = "cbtimkiem";
            this.cbtimkiem.Size = new System.Drawing.Size(121, 28);
            this.cbtimkiem.TabIndex = 19;
            // 
            // UserControlBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbtimkiem);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgvbooking);
            this.Controls.Add(this.label1);
            this.Name = "UserControlBooking";
            this.Size = new System.Drawing.Size(1100, 730);
            this.Load += new System.EventHandler(this.UserControlBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpngaynhan;
        private System.Windows.Forms.DateTimePicker dtpngaytra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvbooking;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.TextBox txtsodt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.TextBox txtccdd;
        private System.Windows.Forms.TextBox txttenkh;
        private System.Windows.Forms.TextBox txtsonguoi;
        private System.Windows.Forms.TextBox txttiencoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btntimkiem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbloaiphong;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.ComboBox cbphong;
        private System.Windows.Forms.ComboBox cbtimkiem;
    }
}