namespace BTL_QLKhachSan.myForm
{
    partial class UC_BookingManagemen
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
            this.dgvBookingList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.dtpngaycheckout = new System.Windows.Forms.DateTimePicker();
            this.dtpngaycheckin = new System.Windows.Forms.DateTimePicker();
            this.dtpngaydat = new System.Windows.Forms.DateTimePicker();
            this.tbghichu = new System.Windows.Forms.TextBox();
            this.tbnguoitao = new System.Windows.Forms.TextBox();
            this.tbsonguoi = new System.Windows.Forms.TextBox();
            this.tbtiencoc = new System.Windows.Forms.TextBox();
            this.tbidkhach = new System.Windows.Forms.TextBox();
            this.tbidphong = new System.Windows.Forms.TextBox();
            this.tbidphieu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnfind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingList)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBookingList
            // 
            this.dgvBookingList.AllowUserToAddRows = false;
            this.dgvBookingList.AllowUserToDeleteRows = false;
            this.dgvBookingList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookingList.Location = new System.Drawing.Point(25, 297);
            this.dgvBookingList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvBookingList.Name = "dgvBookingList";
            this.dgvBookingList.ReadOnly = true;
            this.dgvBookingList.RowHeadersWidth = 51;
            this.dgvBookingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookingList.Size = new System.Drawing.Size(1002, 267);
            this.dgvBookingList.TabIndex = 2;
            this.dgvBookingList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookingList_CellClick);
            this.dgvBookingList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookingList_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý đặt phòng";
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.dtpngaycheckout);
            this.panelInput.Controls.Add(this.dtpngaycheckin);
            this.panelInput.Controls.Add(this.dtpngaydat);
            this.panelInput.Controls.Add(this.tbghichu);
            this.panelInput.Controls.Add(this.tbnguoitao);
            this.panelInput.Controls.Add(this.tbsonguoi);
            this.panelInput.Controls.Add(this.tbtiencoc);
            this.panelInput.Controls.Add(this.tbidkhach);
            this.panelInput.Controls.Add(this.tbidphong);
            this.panelInput.Controls.Add(this.tbidphieu);
            this.panelInput.Controls.Add(this.label9);
            this.panelInput.Controls.Add(this.label11);
            this.panelInput.Controls.Add(this.label12);
            this.panelInput.Controls.Add(this.label13);
            this.panelInput.Controls.Add(this.label5);
            this.panelInput.Controls.Add(this.label6);
            this.panelInput.Controls.Add(this.label7);
            this.panelInput.Controls.Add(this.label4);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Location = new System.Drawing.Point(25, 55);
            this.panelInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(722, 234);
            this.panelInput.TabIndex = 29;
            // 
            // dtpngaycheckout
            // 
            this.dtpngaycheckout.CustomFormat = "dd/MM/yyyy";
            this.dtpngaycheckout.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaycheckout.Location = new System.Drawing.Point(500, 103);
            this.dtpngaycheckout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpngaycheckout.Name = "dtpngaycheckout";
            this.dtpngaycheckout.Size = new System.Drawing.Size(212, 22);
            this.dtpngaycheckout.TabIndex = 47;
            // 
            // dtpngaycheckin
            // 
            this.dtpngaycheckin.CustomFormat = "dd/MM/yyyy";
            this.dtpngaycheckin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaycheckin.Location = new System.Drawing.Point(500, 60);
            this.dtpngaycheckin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpngaycheckin.Name = "dtpngaycheckin";
            this.dtpngaycheckin.Size = new System.Drawing.Size(212, 22);
            this.dtpngaycheckin.TabIndex = 46;
            // 
            // dtpngaydat
            // 
            this.dtpngaydat.CustomFormat = "dd/MM/yyyy";
            this.dtpngaydat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaydat.Location = new System.Drawing.Point(500, 21);
            this.dtpngaydat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpngaydat.Name = "dtpngaydat";
            this.dtpngaydat.Size = new System.Drawing.Size(212, 22);
            this.dtpngaydat.TabIndex = 45;
            // 
            // tbghichu
            // 
            this.tbghichu.Location = new System.Drawing.Point(500, 188);
            this.tbghichu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbghichu.Name = "tbghichu";
            this.tbghichu.Size = new System.Drawing.Size(212, 22);
            this.tbghichu.TabIndex = 44;
            // 
            // tbnguoitao
            // 
            this.tbnguoitao.Location = new System.Drawing.Point(133, 151);
            this.tbnguoitao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbnguoitao.Name = "tbnguoitao";
            this.tbnguoitao.Size = new System.Drawing.Size(212, 22);
            this.tbnguoitao.TabIndex = 43;
            // 
            // tbsonguoi
            // 
            this.tbsonguoi.Location = new System.Drawing.Point(133, 188);
            this.tbsonguoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbsonguoi.Name = "tbsonguoi";
            this.tbsonguoi.Size = new System.Drawing.Size(212, 22);
            this.tbsonguoi.TabIndex = 42;
            // 
            // tbtiencoc
            // 
            this.tbtiencoc.Location = new System.Drawing.Point(500, 151);
            this.tbtiencoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbtiencoc.Name = "tbtiencoc";
            this.tbtiencoc.Size = new System.Drawing.Size(212, 22);
            this.tbtiencoc.TabIndex = 41;
            // 
            // tbidkhach
            // 
            this.tbidkhach.Location = new System.Drawing.Point(133, 103);
            this.tbidkhach.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbidkhach.Name = "tbidkhach";
            this.tbidkhach.Size = new System.Drawing.Size(212, 22);
            this.tbidkhach.TabIndex = 40;
            // 
            // tbidphong
            // 
            this.tbidphong.Location = new System.Drawing.Point(133, 60);
            this.tbidphong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbidphong.Name = "tbidphong";
            this.tbidphong.Size = new System.Drawing.Size(212, 22);
            this.tbidphong.TabIndex = 39;
            // 
            // tbidphieu
            // 
            this.tbidphieu.Location = new System.Drawing.Point(133, 21);
            this.tbidphieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbidphieu.Name = "tbidphieu";
            this.tbidphieu.Size = new System.Drawing.Size(212, 22);
            this.tbidphieu.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(400, 192);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "Ghi chú:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(400, 107);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "Ngày C-Out:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(400, 64);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "Ngày C-In:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(400, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 33;
            this.label13.Text = "Ngày đặt:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Tiền cọc:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 192);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Số người:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 155);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Người tạo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "ID Khách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "ID phòng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Id phiếu:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnluu);
            this.panelButtons.Controls.Add(this.btnCheckIn);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnfind);
            this.panelButtons.Location = new System.Drawing.Point(773, 55);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(254, 234);
            this.panelButtons.TabIndex = 30;
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(20, 155);
            this.btnluu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(227, 28);
            this.btnluu.TabIndex = 12;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(20, 118);
            this.btnCheckIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(227, 28);
            this.btnCheckIn.TabIndex = 11;
            this.btnCheckIn.Text = "Check-in";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(20, 192);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(227, 28);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(20, 81);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(227, 28);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(20, 44);
            this.btnfind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(227, 28);
            this.btnfind.TabIndex = 8;
            this.btnfind.Text = "Tìm kiếm";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
            // 
            // UC_BookingManagemen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBookingList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UC_BookingManagemen";
            this.Size = new System.Drawing.Size(1067, 639);
            this.Load += new System.EventHandler(this.UC_BookingManagemen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingList)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBookingList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.DateTimePicker dtpngaycheckout;
        private System.Windows.Forms.DateTimePicker dtpngaycheckin;
        private System.Windows.Forms.DateTimePicker dtpngaydat;
        private System.Windows.Forms.TextBox tbghichu;
        private System.Windows.Forms.TextBox tbnguoitao;
        private System.Windows.Forms.TextBox tbsonguoi;
        private System.Windows.Forms.TextBox tbtiencoc;
        private System.Windows.Forms.TextBox tbidkhach;
        private System.Windows.Forms.TextBox tbidphong;
        private System.Windows.Forms.TextBox tbidphieu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnfind;
    }
}