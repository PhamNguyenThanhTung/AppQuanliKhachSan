namespace BTL_QLKhachSan.QuanLy
{
    partial class UC_Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_room = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.actionButton = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.label_RoomType = new System.Windows.Forms.Label();
            this.label_RoomName = new System.Windows.Forms.Label();
            this.flowLayoutPanelRooms.SuspendLayout();
            this.panel_room.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelRooms
            // 
            this.flowLayoutPanelRooms.Controls.Add(this.panel_room);
            this.flowLayoutPanelRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelRooms.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelRooms.Name = "flowLayoutPanelRooms";
            this.flowLayoutPanelRooms.Size = new System.Drawing.Size(900, 600);
            this.flowLayoutPanelRooms.TabIndex = 0;
            // 
            // panel_room
            // 
            this.panel_room.Controls.Add(this.label2);
            this.panel_room.Controls.Add(this.label1);
            this.panel_room.Controls.Add(this.actionButton);
            this.panel_room.Controls.Add(this.label_Status);
            this.panel_room.Controls.Add(this.label_RoomType);
            this.panel_room.Controls.Add(this.label_RoomName);
            this.panel_room.Location = new System.Drawing.Point(3, 3);
            this.panel_room.Name = "panel_room";
            this.panel_room.Size = new System.Drawing.Size(199, 174);
            this.panel_room.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trạng thái:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Loại phòng:";
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(58, 133);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(86, 23);
            this.actionButton.TabIndex = 3;
            this.actionButton.Text = "Check Out";
            this.actionButton.UseVisualStyleBackColor = true;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(97, 87);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(67, 16);
            this.label_Status.TabIndex = 2;
            this.label_Status.Text = "Trạng thái";
            // 
            // label_RoomType
            // 
            this.label_RoomType.AutoSize = true;
            this.label_RoomType.Location = new System.Drawing.Point(97, 53);
            this.label_RoomType.Name = "label_RoomType";
            this.label_RoomType.Size = new System.Drawing.Size(74, 16);
            this.label_RoomType.TabIndex = 1;
            this.label_RoomType.Text = "Loại phòng";
            // 
            // label_RoomName
            // 
            this.label_RoomName.AutoSize = true;
            this.label_RoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RoomName.Location = new System.Drawing.Point(55, 21);
            this.label_RoomName.Name = "label_RoomName";
            this.label_RoomName.Size = new System.Drawing.Size(81, 16);
            this.label_RoomName.TabIndex = 0;
            this.label_RoomName.Text = "Tên phòng";
            // 
            // UC_Dashboard
            // 
            this.Controls.Add(this.flowLayoutPanelRooms);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.UC_Dashboard_Load);
            this.flowLayoutPanelRooms.ResumeLayout(false);
            this.panel_room.ResumeLayout(false);
            this.panel_room.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRooms;
        private System.Windows.Forms.Panel panel_room;
        private System.Windows.Forms.Label label_RoomName;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Label label_RoomType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
