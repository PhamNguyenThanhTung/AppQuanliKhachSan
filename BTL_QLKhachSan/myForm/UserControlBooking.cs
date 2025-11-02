using BTL_QLKhachSan.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BTL_QLKhachSan.myForm
{
    public partial class UserControlBooking : UserControl
    {
        Database db = new Database();
        public UserControlBooking()
        {
            InitializeComponent();
        }
        private int selectedPhieuThueID = -1;
        private void ClearForm()
        {
            // 🔹 Thông tin khách hàng
            txttenkh.Clear();
            txtsodt.Clear();
            txtccdd.Clear();
            txtdiachi.Clear();

            // 🔹 Thông tin đặt phòng
            cbloaiphong.SelectedIndex = -1;
            if (cbphong != null)
            {
                cbphong.DataSource = null;
                cbphong.Items.Clear();
            }

            txtsonguoi.Clear();
            txtghichu.Clear();
            txttiencoc.Clear();

            // 🔹 Ngày nhận & trả
            dtpngaynhan.Value = DateTime.Now;
            dtpngaytra.Value = DateTime.Now;
            dtpngaytra.Checked = false;

            // 🔹 Xóa bảng hiển thị nếu có
            dgvbooking.DataSource = null;
        }




        private void UserControlBooking_Load(object sender, EventArgs e)
        {
            txtsodt.KeyPress += OnlyDigits_KeyPress;
            txtccdd.KeyPress += OnlyDigits_KeyPress;
            txttiencoc.KeyPress += OnlyDigits_KeyPress;
            dgvbooking.CellClick += dgvbooking_CellClick;

            LoadLoaiPhong();
            btnsua.Enabled = false;



            dgvbooking.Columns.Add("MaPhieu", "Mã phiếu");
            dgvbooking.Columns.Add("Phong", "Phòng");
            dgvbooking.Columns.Add("LoaiPhong", "Loại phòng");
            dgvbooking.Columns.Add("NgayNhan", "Ngày nhận");
            dgvbooking.Columns.Add("NgayTra", "Ngày trả");
            dgvbooking.Columns.Add("SoNguoi", "Số người");
            dgvbooking.Columns.Add("TrangThai", "Trạng thái");
            dgvbooking.Columns.Add("GhiChu", "Ghi chú");

            dgvbooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadSoDienThoaiToComboBox();
        }
        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số và phím điều khiển (Backspace, Delete,...)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự
            }
        }
        private void LoadLoaiPhong()
        {
            string query = "SELECT IDLoaiPhong, TenLoaiPhong FROM LOAIPHONG";
            DataTable dt = db.GetData(query);

            cbloaiphong.DataSource = dt;
            cbloaiphong.DisplayMember = "TenLoaiPhong";
            cbloaiphong.ValueMember = "IDLoaiPhong";
            cbloaiphong.SelectedIndex = -1;
        }
        private void LoadSoDienThoaiToComboBox()
        {
            try
            {
                string sql = @"
            SELECT DISTINCT SoDienThoai 
            FROM KHACHHANG kh
            JOIN PHIEUTHUE pt ON kh.IDKhachHang = pt.IDKhachHang
            ORDER BY SoDienThoai";

                DataTable dt = db.GetData(sql);

                cbtimkiem.Items.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        cbtimkiem.Items.Add(r["SoDienThoai"].ToString());
                    }

                    cbtimkiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbtimkiem.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách số điện thoại: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            dgvbooking.Columns.Clear();
            string sdt = cbtimkiem.Text.Trim();

            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng cần tìm!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string queryKH = "SELECT * FROM KHACHHANG kh join PHIEUTHUE pt on kh.IDKhachHang=pt.IDKhachHang " +
                            "join PHONG p on pt.IDPhong=p.IDPhong " +
                            "join LOAIPHONG lp on p.IDLoaiPhong=lp.IDLoaiPhong " +
                            "WHERE SoDienThoai = @sdt";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@sdt", sdt)
            };

            DataTable dtKH = db.GetData(queryKH, parameters);

            if (dtKH.Rows.Count > 0)
            {
                // 🔹 Hiển thị thông tin khách hàng
                txttenkh.Text = dtKH.Rows[0]["HoTen"].ToString();
                txtsodt.Text = dtKH.Rows[0]["SoDienThoai"].ToString();
                txtccdd.Text = dtKH.Rows[0]["CMND"].ToString();
                txtdiachi.Text = dtKH.Rows[0]["DiaChi"].ToString();
                cbloaiphong.Text = dtKH.Rows[0]["TenLoaiPhong"].ToString();
                txtghichu.Text = dtKH.Rows[0]["GhiChu"].ToString();
                txttiencoc.Text = dtKH.Rows[0]["TienCoc"].ToString();
                dtpngaynhan.Value = Convert.ToDateTime(dtKH.Rows[0]["NgayCheckIn"]);
                if (dtKH.Rows[0]["NgayCheckOut"] != DBNull.Value)
                    dtpngaytra.Value = Convert.ToDateTime(dtKH.Rows[0]["NgayCheckOut"]);
                else
                    dtpngaytra.Checked = false;// hoặc để trống, tuỳ bạn

                txtsonguoi.Text = dtKH.Rows[0]["SoNguoi"].ToString();
                int idKH = Convert.ToInt32(dtKH.Rows[0]["IDKhachHang"]);

                // 🔹 Truy vấn danh sách phiếu thuê của khách
                string queryPhieu = @"
                            SELECT 
                                PT.IDPhieuThue AS [Mã phiếu],
                                P.IDPhong AS [Phòng],
                                LP.TenLoaiPhong AS [Loại phòng],
                                PT.NgayCheckIn AS [Ngày nhận],
                                PT.NgayCheckOut AS [Ngày trả],
                                PT.SoNguoi AS [Số người],
                                PT.TrangThai AS [Trạng thái],
                                PT.GhiChu AS [Ghi chú]
                            FROM PHIEUTHUE PT
                            JOIN PHONG P ON PT.IDPhong = P.IDPhong
                            JOIN LOAIPHONG LP ON P.IDLoaiPhong = LP.IDLoaiPhong
                            WHERE PT.IDKhachHang = @idKH";

                List<SqlParameter> paramPhieu = new List<SqlParameter>
            {
                new SqlParameter("@idKH", idKH)
            };

                DataTable dtPhieu = db.GetData(queryPhieu, paramPhieu);

                dgvbooking.DataSource = dtPhieu;
                dgvbooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                MessageBox.Show("Đã tìm thấy khách hàng và hiển thị danh sách phiếu thuê!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng có số điện thoại này!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Xoá thông tin cũ
                ClearForm();
                dgvbooking.DataSource = null;
                btnsua.Enabled = false;
            }
            btnsua.Enabled = true;

        }

        private void btnthem_Click(object sender, EventArgs e)

        {
            txtsodt.Focus();
            try
            {
                // ✅ Kiểm tra dữ liệu
                if (string.IsNullOrEmpty(txttenkh.Text) || string.IsNullOrEmpty(txtsodt.Text) ||
                    cbloaiphong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng và chọn loại phòng!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Lấy ID khách hàng (nếu khách cũ)
                string queryKH = "SELECT * FROM KHACHHANG WHERE SoDienThoai = @sdt";
                List<SqlParameter> pKH = new List<SqlParameter> { new SqlParameter("@sdt", txtsodt.Text.Trim()) };
                DataTable dtKH = db.GetData(queryKH, pKH);

                int idKH;
                if (dtKH.Rows.Count > 0)
                {
                    idKH = Convert.ToInt32(dtKH.Rows[0]["IDKhachHang"]);
                }
                else
                {
                    // ✅ Nếu khách mới thì thêm vào bảng KHACHHANG
                    string insertKH = @"INSERT INTO KHACHHANG (HoTen, CMND, SoDienThoai, DiaChi)
                                VALUES (@ten, @cccd, @sdt, @diachi);
                                SELECT SCOPE_IDENTITY();";
                    List<SqlParameter> pNewKH = new List<SqlParameter>
            {
                new SqlParameter("@ten", txttenkh.Text),
                new SqlParameter("@cccd", txtccdd.Text),
                new SqlParameter("@sdt", txtsodt.Text),
                new SqlParameter("@diachi", txtdiachi.Text)
            };
                    DataTable newKH = db.GetData(insertKH, pNewKH);
                    idKH = Convert.ToInt32(newKH.Rows[0][0]);
                }

                // ✅ Lấy phòng được chọn (ví dụ bạn có ComboBox cbphong)
                if (cbloaiphong.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbphong.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string idPhong = cbphong.SelectedValue.ToString();

                // ✅ Lấy thông tin chung
                DateTime ngayNhan = dtpngaynhan.Value;
                DateTime? ngayTra = dtpngaytra.Checked ? dtpngaytra.Value : (DateTime?)null;
                int soNguoi = int.TryParse(txtsonguoi.Text, out int n) ? n : 1;
                decimal tienCoc = decimal.TryParse(txttiencoc.Text, out decimal c) ? c : 0;
                string ghiChu = txtghichu.Text;
                string nguoiTao = "letan01"; // có thể lấy từ tài khoản đăng nhập
                string trangThai = "Đã đặt";

                // ✅ Thêm phiếu thuê mới
                string insertPT = @"
            INSERT INTO PHIEUTHUE (IDPhong, IDKhachHang, NguoiTao, NgayDat, NgayCheckIn, NgayCheckOut, SoNguoi, TienCoc, TrangThai, GhiChu)
            VALUES (@phong, @kh, @nguoitao, GETDATE(), @checkin, @checkout, @songuoi, @tiencoc, @trangthai, @ghichu)";
                List<SqlParameter> pPT = new List<SqlParameter>
                    {
                        new SqlParameter("@phong", idPhong),
                        new SqlParameter("@kh", idKH),
                        new SqlParameter("@nguoitao", nguoiTao),
                        new SqlParameter("@checkin", ngayNhan),
                        new SqlParameter("@checkout", (object)ngayTra ?? DBNull.Value),
                        new SqlParameter("@songuoi", soNguoi),
                        new SqlParameter("@tiencoc", tienCoc),
                        new SqlParameter("@trangthai", trangThai),
                        new SqlParameter("@ghichu", ghiChu)
                    };

                db.ExecuteNonQuery(insertPT, pPT);
                string updatePhong = "UPDATE PHONG SET TrangThai = N'Đã đặt' WHERE IDPhong = @id";
                List<SqlParameter> paramUpdate = new List<SqlParameter>
                {
                    new SqlParameter("@id", idPhong)
                };
                db.ExecuteNonQuery(updatePhong, paramUpdate);


                MessageBox.Show("Đã thêm phiếu đặt phòng mới thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Tải lại danh sách booking sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearForm();
            btnsua.Enabled = false;




        }

        private void cbloaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbloaiphong.SelectedValue == null) return;

            if (cbloaiphong.SelectedValue == null || cbloaiphong.SelectedValue is DataRowView)
                return;

            if (cbloaiphong.SelectedValue == null || cbloaiphong.SelectedValue is DataRowView)
                return;

            int idLoaiPhong = Convert.ToInt32(cbloaiphong.SelectedValue);



            string query = @"
        SELECT IDPhong, TenPhong 
        FROM PHONG 
        WHERE TrangThai = N'Trống' AND IDLoaiPhong = @idLoaiPhong";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@idLoaiPhong", idLoaiPhong)
            };

            DataTable dtPhong = db.GetData(query, parameters);

            cbphong.DataSource = dtPhong;
            cbphong.DisplayMember = "TenPhong";
            cbphong.ValueMember = "IDPhong";

            if (dtPhong.Rows.Count == 0)
            {
                cbphong.Text = "(Không có phòng trống)";
            }
            else
            {
                cbphong.SelectedIndex = 0;
            }
        }
        private string selectedPhongID = null;

        private void dgvbooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvbooking.Rows[e.RowIndex];
                selectedPhieuThueID = Convert.ToInt32(row.Cells["Mã phiếu"].Value);

                // 🔹 Đổ thông tin phiếu thuê lên form
                cbloaiphong.Text = row.Cells["Loại phòng"].Value.ToString();
                cbphong.Text = row.Cells["Phòng"].Value.ToString();

                txtsonguoi.Text = row.Cells["Số người"].Value.ToString();
                txtghichu.Text = row.Cells["Ghi chú"].Value.ToString();

                if (row.Cells["Ngày nhận"].Value != DBNull.Value)
                    dtpngaynhan.Value = Convert.ToDateTime(row.Cells["Ngày nhận"].Value);

                if (row.Cells["Ngày trả"].Value != DBNull.Value)
                {
                    dtpngaytra.Value = Convert.ToDateTime(row.Cells["Ngày trả"].Value);
                    dtpngaytra.Checked = true;
                }
                else
                    dtpngaytra.Checked = false;

                btnsua.Enabled = true; // Cho phép sửa khi đã chọn phiếu
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvbooking.Rows[e.RowIndex];
                selectedPhieuThueID = Convert.ToInt32(row.Cells["Mã phiếu"].Value);
                selectedPhongID = row.Cells["Phòng"].Value.ToString();
                btnxoa.Enabled = true;
                btnsua.Enabled = true;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (selectedPhieuThueID == -1)
            {
                MessageBox.Show("Vui lòng chọn một phiếu thuê để sửa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy giá trị cập nhật
                string idPhong = cbphong.SelectedValue?.ToString();
                DateTime ngayNhan = dtpngaynhan.Value;
                DateTime? ngayTra = dtpngaytra.Checked ? dtpngaytra.Value : (DateTime?)null;
                int soNguoi = int.TryParse(txtsonguoi.Text, out int n) ? n : 1;
                decimal tienCoc = decimal.TryParse(txttiencoc.Text, out decimal c) ? c : 0;
                string ghiChu = txtghichu.Text;
                string trangThai = "Đã đặt";

                // Câu truy vấn cập nhật
                string queryUpdate = @"
            UPDATE PHIEUTHUE
            SET 
                IDPhong = @phong,
                NgayCheckIn = @checkin,
                NgayCheckOut = @checkout,
                SoNguoi = @songuoi,
                TienCoc = @tiencoc,
                TrangThai = @trangthai,
                GhiChu = @ghichu
            WHERE IDPhieuThue = @id";

                List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@phong", idPhong),
            new SqlParameter("@checkin", ngayNhan),
            new SqlParameter("@checkout", (object)ngayTra ?? DBNull.Value),
            new SqlParameter("@songuoi", soNguoi),
            new SqlParameter("@tiencoc", tienCoc),
            new SqlParameter("@trangthai", trangThai),
            new SqlParameter("@ghichu", ghiChu),
            new SqlParameter("@id", selectedPhieuThueID)
        };

                db.ExecuteNonQuery(queryUpdate, parameters);

                MessageBox.Show("Cập nhật thông tin phiếu thuê thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload lại danh sách sau khi sửa

                // Reset form
                selectedPhieuThueID = -1;
                btnsua.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phiếu thuê: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (selectedPhieuThueID == -1)
            {
                MessageBox.Show("Vui lòng chọn một phiếu thuê để xóa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu thuê này không?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No) return;

            try
            {
                // ✅ 1. Xóa phiếu thuê trong bảng PHIEUTHUE
                string queryDelete = "DELETE FROM PHIEUTHUE WHERE IDPhieuThue = @id";
                List<SqlParameter> param = new List<SqlParameter>
        {
            new SqlParameter("@id", selectedPhieuThueID)
        };
                db.ExecuteNonQuery(queryDelete, param);

                // ✅ 2. Cập nhật trạng thái phòng về "Trống"
                if (!string.IsNullOrEmpty(selectedPhongID))
                {
                    string queryPhong = "UPDATE PHONG SET TrangThai = N'Trống' WHERE IDPhong = @p";
                    List<SqlParameter> pPhong = new List<SqlParameter>
            {
                new SqlParameter("@p", selectedPhongID)
            };
                    db.ExecuteNonQuery(queryPhong, pPhong);
                }

                // ✅ 3. Tải lại danh sách
                dgvbooking.DataSource = null;
                // ✅ 4. Reset biến & form
                selectedPhieuThueID = -1;
                selectedPhongID = null;
                btnxoa.Enabled = false;
                btnsua.Enabled = false;

                MessageBox.Show("Đã xóa phiếu thuê thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu thuê: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}