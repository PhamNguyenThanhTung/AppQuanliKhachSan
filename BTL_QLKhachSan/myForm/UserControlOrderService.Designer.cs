namespace BTL_QLKhachSan.myForm
{
    partial class UserControlOrderService
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
            this.txtmaphieu = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.txtsophong = new System.Windows.Forms.TextBox();
            this.txttenkh = new System.Windows.Forms.TextBox();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtthanhtien = new System.Windows.Forms.TextBox();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.cbsoluong = new System.Windows.Forms.ComboBox();
            this.cbdichvu = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvdichvu = new System.Windows.Forms.DataGridView();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.cbtimkiem = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdichvu)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtmaphieu);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.txtsophong);
            this.groupBox1.Controls.Add(this.txttenkh);
            this.groupBox1.Controls.Add(this.txtmakh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(63, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "thông tin khách hàng:";
            // 
            // txtmaphieu
            // 
            this.txtmaphieu.Location = new System.Drawing.Point(170, 114);
            this.txtmaphieu.Name = "txtmaphieu";
            this.txtmaphieu.Size = new System.Drawing.Size(169, 26);
            this.txtmaphieu.TabIndex = 7;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(10, 117);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(74, 20);
            this.label.TabIndex = 6;
            this.label.Text = "mã phiếu";
            // 
            // txtsophong
            // 
            this.txtsophong.Location = new System.Drawing.Point(170, 150);
            this.txtsophong.Name = "txtsophong";
            this.txtsophong.Size = new System.Drawing.Size(169, 26);
            this.txtsophong.TabIndex = 5;
            // 
            // txttenkh
            // 
            this.txttenkh.Location = new System.Drawing.Point(170, 79);
            this.txttenkh.Name = "txttenkh";
            this.txttenkh.Size = new System.Drawing.Size(169, 26);
            this.txttenkh.TabIndex = 4;
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(170, 35);
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(169, 26);
            this.txtmakh.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "số phòng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "tên khách hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "mã khách hàng:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtthanhtien);
            this.groupBox2.Controls.Add(this.txtdongia);
            this.groupBox2.Controls.Add(this.cbsoluong);
            this.groupBox2.Controls.Add(this.cbdichvu);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(601, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "danh sách dịch vụ:";
            // 
            // txtthanhtien
            // 
            this.txtthanhtien.Location = new System.Drawing.Point(158, 180);
            this.txtthanhtien.Name = "txtthanhtien";
            this.txtthanhtien.Size = new System.Drawing.Size(121, 26);
            this.txtthanhtien.TabIndex = 10;
            // 
            // txtdongia
            // 
            this.txtdongia.Location = new System.Drawing.Point(158, 137);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(121, 26);
            this.txtdongia.TabIndex = 9;
            // 
            // cbsoluong
            // 
            this.cbsoluong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsoluong.FormattingEnabled = true;
            this.cbsoluong.Location = new System.Drawing.Point(158, 91);
            this.cbsoluong.Name = "cbsoluong";
            this.cbsoluong.Size = new System.Drawing.Size(121, 28);
            this.cbsoluong.TabIndex = 8;
            this.cbsoluong.SelectedIndexChanged += new System.EventHandler(this.cbsoluong_SelectedIndexChanged);
            // 
            // cbdichvu
            // 
            this.cbdichvu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdichvu.FormattingEnabled = true;
            this.cbdichvu.Location = new System.Drawing.Point(158, 33);
            this.cbdichvu.Name = "cbdichvu";
            this.cbdichvu.Size = new System.Drawing.Size(121, 28);
            this.cbdichvu.TabIndex = 7;
            this.cbdichvu.SelectedIndexChanged += new System.EventHandler(this.cbdichvu_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "số lượng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "đơn giá:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "thành tiền:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "dịch vụ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Các dịch vụ thêm:";
            // 
            // dgvdichvu
            // 
            this.dgvdichvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdichvu.Location = new System.Drawing.Point(98, 394);
            this.dgvdichvu.Name = "dgvdichvu";
            this.dgvdichvu.ReadOnly = true;
            this.dgvdichvu.RowHeadersWidth = 62;
            this.dgvdichvu.RowTemplate.Height = 28;
            this.dgvdichvu.Size = new System.Drawing.Size(983, 208);
            this.dgvdichvu.TabIndex = 3;
            this.dgvdichvu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdichvu_CellClick);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(98, 614);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(110, 41);
            this.btnthem.TabIndex = 4;
            this.btnthem.Text = "thêm ";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(333, 614);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(91, 41);
            this.btnsua.TabIndex = 5;
            this.btnsua.Text = "sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(623, 614);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(104, 41);
            this.btnxoa.TabIndex = 6;
            this.btnxoa.Text = "xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(285, 335);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(100, 33);
            this.btntimkiem.TabIndex = 8;
            this.btntimkiem.Text = "tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // cbtimkiem
            // 
            this.cbtimkiem.FormattingEnabled = true;
            this.cbtimkiem.Location = new System.Drawing.Point(98, 340);
            this.cbtimkiem.Name = "cbtimkiem";
            this.cbtimkiem.Size = new System.Drawing.Size(121, 28);
            this.cbtimkiem.TabIndex = 9;
            // 
            // UserControlOrderService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbtimkiem);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgvdichvu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlOrderService";
            this.Size = new System.Drawing.Size(1100, 730);
            this.Load += new System.EventHandler(this.UserControlOrderService_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdichvu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvdichvu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsophong;
        private System.Windows.Forms.TextBox txttenkh;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.TextBox txtthanhtien;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.ComboBox cbsoluong;
        private System.Windows.Forms.ComboBox cbdichvu;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.TextBox txtmaphieu;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox cbtimkiem;
    }
}