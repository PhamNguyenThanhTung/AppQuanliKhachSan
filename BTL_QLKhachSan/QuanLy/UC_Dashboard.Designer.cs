namespace BTL_QLKhachSan.QuanLy
{
    partial class UC_Dashboard
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
            this.label_adminCount = new System.Windows.Forms.Label();
            this.label_letanCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_phongCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_adminCount
            // 
            this.label_adminCount.AutoSize = true;
            this.label_adminCount.Location = new System.Drawing.Point(113, 45);
            this.label_adminCount.Name = "label_adminCount";
            this.label_adminCount.Size = new System.Drawing.Size(65, 16);
            this.label_adminCount.TabIndex = 6;
            this.label_adminCount.Text = "Số Admin";
            // 
            // label_letanCount
            // 
            this.label_letanCount.AutoSize = true;
            this.label_letanCount.Location = new System.Drawing.Point(113, 123);
            this.label_letanCount.Name = "label_letanCount";
            this.label_letanCount.Size = new System.Drawing.Size(59, 16);
            this.label_letanCount.TabIndex = 7;
            this.label_letanCount.Text = "Số lễ tân";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Số Admin:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Số lễ tân:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Số phòng:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label_phongCount
            // 
            this.label_phongCount.AutoSize = true;
            this.label_phongCount.Location = new System.Drawing.Point(113, 199);
            this.label_phongCount.Name = "label_phongCount";
            this.label_phongCount.Size = new System.Drawing.Size(65, 16);
            this.label_phongCount.TabIndex = 11;
            this.label_phongCount.Text = "Số phòng";
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.label_phongCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_letanCount);
            this.Controls.Add(this.label_adminCount);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(683, 431);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_adminCount;
        private System.Windows.Forms.Label label_letanCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_phongCount;
    }
}
