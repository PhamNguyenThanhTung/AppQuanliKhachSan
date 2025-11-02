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
        // New: track current customer when selecting CCCD
        private int currentIDKhachHang = -1;

        private void ClearForm()
        {
            // 🔹 Thông tin khách hàng
            txttenkh.Clear();
            txtsodt.Clear();
            // ComboBox does not have Clear(); reset selection and text instead
            if (cbcccd != null)
            {
                cbcccd.SelectedIndex = -1;
                cbcccd.Text = string.Empty;
            }
            txtdiachi.Clear();

            // reset tracked customer
            currentIDKhachHang = -1;

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
            cbcccd.KeyPress += OnlyDigits_KeyPress;
            txttiencoc.KeyPress += OnlyDigits_KeyPress;
            dgvbooking.CellClick += dgvbooking_CellClick;

            LoadLoaiPhong();
            LoadCCCDs(); // <- load CCCD values into ComboBox on form load

            // subscribe to selection / input events for CCCD
            cbcccd.SelectedIndexChanged += cbcccd_SelectedIndexChanged;
            cbcccd.Leave += cbcccd_Leave;

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
                cbcccd.Text = dtKH.Rows[0]["CMND"].ToString();
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

                // set current customer id
                currentIDKhachHang = idKH;

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

                // Determine customer ID: prefer currentIDKhachHang, then try by CMND, then by phone
                int idKH = -1;
                string cmndText = (cbcccd?.Text ?? string.Empty).Trim();
                string phoneText = txtsodt.Text.Trim();

                if (currentIDKhachHang != -1)
                {
                    idKH = currentIDKhachHang;
                }
                else if (!string.IsNullOrEmpty(cmndText))
                {
                    // try find by CMND
                    string qByCccd = "SELECT IDKhachHang FROM KHACHHANG WHERE CMND = @cmnd";
                    DataTable dtByCccd = db.GetData(qByCccd, new List<SqlParameter> { new SqlParameter("@cmnd", cmndText) });
                    if (dtByCccd != null && dtByCccd.Rows.Count > 0)
                        idKH = Convert.ToInt32(dtByCccd.Rows[0]["IDKhachHang"]);
                }

                if (idKH == -1)
                {
                    // fallback: try find by phone
                    string qByPhone = "SELECT IDKhachHang FROM KHACHHANG WHERE SoDienThoai = @sdt";
                    DataTable dtByPhone = db.GetData(qByPhone, new List<SqlParameter> { new SqlParameter("@sdt", phoneText) });
                    if (dtByPhone != null && dtByPhone.Rows.Count > 0)
                        idKH = Convert.ToInt32(dtByPhone.Rows[0]["IDKhachHang"]);
                }

                // If idKH found -> update customer details; otherwise insert new customer
                if (idKH != -1)
                {
                    string updateKH = @"UPDATE KHACHHANG SET HoTen = @ten, CMND = @cccd, SoDienThoai = @sdt, DiaChi = @diachi WHERE IDKhachHang = @id";
                    List<SqlParameter> pUpdate = new List<SqlParameter>
                    {
                        new SqlParameter("@ten", txttenkh.Text.Trim()),
                        new SqlParameter("@cccd", cmndText),
                        new SqlParameter("@sdt", phoneText),
                        new SqlParameter("@diachi", txtdiachi.Text.Trim()),
                        new SqlParameter("@id", idKH)
                    };
                    db.ExecuteNonQuery(updateKH, pUpdate);
                }
                else
                {
                    // Insert new customer
                    string insertKH = @"INSERT INTO KHACHHANG (HoTen, CMND, SoDienThoai, DiaChi)
                                VALUES (@ten, @cccd, @sdt, @diachi);
                                SELECT SCOPE_IDENTITY();";
                    List<SqlParameter> pNewKH = new List<SqlParameter>
                    {
                        new SqlParameter("@ten", txttenkh.Text.Trim()),
                        new SqlParameter("@cccd", cmndText),
                        new SqlParameter("@sdt", phoneText),
                        new SqlParameter("@diachi", txtdiachi.Text.Trim())
                    };
                    DataTable newKH = db.GetData(insertKH, pNewKH);
                    if (newKH != null && newKH.Rows.Count > 0)
                        idKH = Convert.ToInt32(newKH.Rows[0][0]);
                }

                // ensure idKH available
                if (idKH == -1)
                {
                    MessageBox.Show("Không thể tạo hoặc cập nhật thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                if (ngayTra.HasValue && ngayTra.Value < ngayNhan)
                {
                    MessageBox.Show("Ngày trả không được nhỏ hơn ngày nhận!",
                                    "Lỗi ngày tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                LoadSoDienThoaiToComboBox(); // 🔄 Cập nhật lại danh sách SĐT
                LoadCCCDs(); // refresh CCCD list (in case a new CMND was inserted)

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
            if (cbphong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng hợp lệ trước khi cập nhật!",
                                "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                if (ngayTra.HasValue && ngayTra.Value < ngayNhan)
                {
                    MessageBox.Show("Ngày trả không được nhỏ hơn ngày nhận!",
                                    "Lỗi ngày tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu thuê này không? (Hành động không thể hoàn tác)",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No) return;

            try
            {
                // 1) Xóa chi tiết dịch vụ liên quan (nếu có)
                string deleteCTDV = "DELETE FROM CHITIET_DICHVU WHERE IDPhieuThue = @id";
                db.ExecuteNonQuery(deleteCTDV, new List<SqlParameter> { new SqlParameter("@id", selectedPhieuThueID) });

                // 2) Xóa hóa đơn liên quan (nếu có)
                string deleteHD = "DELETE FROM HOADON WHERE IDPhieuThue = @id";
                db.ExecuteNonQuery(deleteHD, new List<SqlParameter> { new SqlParameter("@id", selectedPhieuThueID) });

                // 3) Xóa phiếu thuê
                string queryDelete = "DELETE FROM PHIEUTHUE WHERE IDPhieuThue = @id";
                db.ExecuteNonQuery(queryDelete, new List<SqlParameter> { new SqlParameter("@id", selectedPhieuThueID) });

                // 4) Cập nhật trạng thái phòng về "Trống" (nếu biết phòng)
                if (!string.IsNullOrEmpty(selectedPhongID))
                {
                    string queryPhong = "UPDATE PHONG SET TrangThai = N'Trống' WHERE IDPhong = @p";
                    db.ExecuteNonQuery(queryPhong, new List<SqlParameter> { new SqlParameter("@p", selectedPhongID) });
                }

                // 5) Cập nhật UI: nếu dgvbooking được bind tới DataTable thì xóa hàng khỏi DataTable,
                //    nếu dgv là unbound thì xóa trực tiếp hàng hiển thị.
                if (dgvbooking.DataSource is DataTable dt)
                {
                    // Cột được đặt tên là "Mã phiếu" trong truy vấn; dùng Select với bracket
                    DataRow[] rows = dt.Select($"[Mã phiếu] = {selectedPhieuThueID}");
                    foreach (var r in rows)
                    {
                        r.Delete();
                    }
                    dt.AcceptChanges();
                    dgvbooking.Refresh();
                }
                else
                {
                    // tìm và xóa hàng trong DataGridView (unbound mode)
                    for (int i = dgvbooking.Rows.Count - 1; i >= 0; i--)
                    {
                        var cell = dgvbooking.Rows[i].Cells["Mã phiếu"];
                        if (cell != null && cell.Value != null && Convert.ToInt32(cell.Value) == selectedPhieuThueID)
                        {
                            dgvbooking.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }

                // 6) Reset trạng thái form & biến
                selectedPhieuThueID = -1;
                selectedPhongID = null;
                btnxoa.Enabled = false;
                btnsua.Enabled = false;
                ClearForm();
                LoadSoDienThoaiToComboBox(); // cập nhật combobox số điện thoại nếu cần

                MessageBox.Show("Đã xóa phiếu thuê thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlex)
            {
                // Nếu có ràng buộc khoá ngoại khác không lường trước được, thông báo rõ ràng
                MessageBox.Show("Lỗi khi xóa phiếu thuê (SQL): " + sqlex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu thuê: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCCCDs()
        {
            try
            {
                // Load distinct CMND/CCCD values from KHACHHANG and populate the ComboBox
                string sql = @"
            SELECT DISTINCT CMND
            FROM KHACHHANG
            WHERE CMND IS NOT NULL AND CMND <> ''
            ORDER BY CMND";

                DataTable dt = db.GetData(sql);

                cbcccd.Items.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        cbcccd.Items.Add(r["CMND"].ToString());
                    }

                    // Enable AutoComplete to help user quickly find a value
                    cbcccd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbcccd.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                else
                {
                    cbcccd.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách CCCD/CMND: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // When user selects a CCCD from dropdown
        private void cbcccd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmnd = cbcccd.Text.Trim();
            if (!string.IsNullOrEmpty(cmnd))
                LoadCustomerByCCCD(cmnd);
        }

        // When user finishes typing CCCD and leaves field
        private void cbcccd_Leave(object sender, EventArgs e)
        {
            string cmnd = cbcccd.Text.Trim();
            if (string.IsNullOrEmpty(cmnd))
            {
                // If cleared, reset customer data
                currentIDKhachHang = -1;
                txttenkh.Text = string.Empty;
                txtsodt.Text = string.Empty;
                txtdiachi.Text = string.Empty;
                return;
            }

            LoadCustomerByCCCD(cmnd);
        }

        // Load customer by CMND and populate form; set currentIDKhachHang = -1 if not found
        private void LoadCustomerByCCCD(string cmnd)
        {
            try
            {
                string q = "SELECT * FROM KHACHHANG WHERE CMND = @cmnd";
                DataTable dt = db.GetData(q, new List<SqlParameter> { new SqlParameter("@cmnd", cmnd) });

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    currentIDKhachHang = Convert.ToInt32(r["IDKhachHang"]);
                    txttenkh.Text = r["HoTen"].ToString();
                    txtsodt.Text = r["SoDienThoai"].ToString();
                    txtdiachi.Text = r["DiaChi"].ToString();
                }
                else
                {
                    // New CCCD: clear customer fields but keep CCCD text
                    currentIDKhachHang = -1;
                    txttenkh.Text = string.Empty;
                    txtsodt.Text = string.Empty;
                    txtdiachi.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}