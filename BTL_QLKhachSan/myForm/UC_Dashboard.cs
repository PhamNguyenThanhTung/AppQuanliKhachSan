using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using BTL_QLKhachSan.myForm;

namespace BTL_QLKhachSan.myForm
{
    public partial class UC_Dashboard : UserControl
    {
        private string connectionString = "Data Source=HAHAHA\\SQLEXPRESS;Initial Catalog=QLKhachSanBTL;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public UC_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        public void LoadRooms()
        {
            flowLayoutPanelRooms.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT P.IDPhong, P.TenPhong, LP.TenLoaiPhong, P.TrangThai
                    FROM PHONG P
                    JOIN LOAIPHONG LP ON P.IDLoaiPhong = LP.IDLoaiPhong
                    ORDER BY P.Tang, P.IDPhong";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string idPhong = row["IDPhong"].ToString();
                    string tenPhong = row["TenPhong"].ToString();
                    string loaiPhong = row["TenLoaiPhong"].ToString();
                    string trangThai = row["TrangThai"].ToString();

                    Panel roomCard = CreateRoomCard(idPhong, tenPhong, loaiPhong, trangThai);
                    flowLayoutPanelRooms.Controls.Add(roomCard);
                }
            }
        }

        private Panel CreateRoomCard(string id, string name, string type, string status)
        {
            Panel card = new Panel();
            card.Width = 200;
            card.Height = 180;
            card.Margin = new Padding(10);
            card.BorderStyle = BorderStyle.FixedSingle;
            card.BackColor = GetStatusColor(status);
            card.Tag = id;

            // Label: Tên phòng
            Label label_RoomName = new Label()
            {
                Text = name,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = false,
                Width = 180,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                Top = 10,
                Left = 10
            };
            card.Controls.Add(label_RoomName);

            // Label: Loại phòng
            Label label_RoomType = new Label()
            {
                Text = "Loại: " + type,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                AutoSize = false,
                Width = 180,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Top = 45,
                Left = 10
            };
            card.Controls.Add(label_RoomType);

            // Label: Trạng thái
            Label label_Status = new Label()
            {
                Text = "Tình trạng: " + status,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                AutoSize = false,
                Width = 180,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Top = 70,
                Left = 10
            };
            card.Controls.Add(label_Status);

            // Nút cho từng trạng thái
            Button actionButton = new Button()
            {
                Width = 140,
                Height = 35,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Top = 110,
                Left = 30
            };

            // Xử lý theo trạng thái phòng
            if (status == "Có khách")
            {
                actionButton.Text = "Check-out";
                actionButton.BackColor = Color.LightCoral;
                actionButton.ForeColor = Color.White;

                actionButton.Click += (s, e) =>
                {
                    frmCheckOut frm = new frmCheckOut(id);
                    frm.ShowDialog();
                    LoadRooms();
                };
                card.Controls.Add(actionButton);
            }
            else if (status == "Dọn dẹp")
            {
                actionButton.Text = "Đã dọn xong";
                actionButton.BackColor = Color.LightSeaGreen;
                actionButton.ForeColor = Color.White;

                actionButton.Click += (s, e) =>
                {
                    UpdateRoomStatus(id, "Trống");
                    MessageBox.Show($"Phòng {name} đã chuyển sang trạng thái 'Trống'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                };
                card.Controls.Add(actionButton);
            }
            else if (status == "Bảo trì")
            {
                actionButton.Text = "Đã bảo trì xong";
                actionButton.BackColor = Color.SteelBlue;
                actionButton.ForeColor = Color.White;

                actionButton.Click += (s, e) =>
                {
                    UpdateRoomStatus(id, "Trống");
                    MessageBox.Show($"Phòng {name} đã chuyển sang trạng thái 'Trống'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                };
                card.Controls.Add(actionButton);
            }
            else if (status == "Trống")
            {
                actionButton.Text = "Bảo trì";
                actionButton.BackColor = Color.Gray;
                actionButton.ForeColor = Color.White;

                actionButton.Click += (s, e) =>
                {
                    UpdateRoomStatus(id, "Bảo trì");
                    MessageBox.Show($"Phòng {name} đã chuyển sang trạng thái 'Bảo trì'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                };
                card.Controls.Add(actionButton);
            }

            return card;
        }

        private void UpdateRoomStatus(string idPhong, string newStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE PHONG SET TrangThai = @TrangThai WHERE IDPhong = @IDPhong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThai", newStatus);
                    cmd.Parameters.AddWithValue("@IDPhong", idPhong);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "Trống":
                    return Color.LightGreen;
                case "Có khách":
                    return Color.LightSalmon;
                case "Dọn dẹp":
                    return Color.Khaki;
                case "Bảo trì":
                    return Color.LightGray;
                default:
                    return Color.White;
            }
        }

        private void flowLayoutPanelRooms_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}