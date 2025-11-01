using BTL_QLKhachSan.myClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_QLKhachSan.myForm
{
    public partial class UserControlOrderService : UserControl
    {
        Database db = new Database();

        public UserControlOrderService()
        {
            InitializeComponent();
        }

        private void UserControlOrderService_Load(object sender, EventArgs e)
        {
            LoadComboBoxDichVu();
            LoadComboBoxSoLuong();
            KhoiTaoDGV();
        }

        // 📌 1. Khởi tạo DataGridView khi load form
        private void KhoiTaoDGV()
        {
            dgvdichvu.Columns.Clear();
            dgvdichvu.AutoGenerateColumns = false;

            dgvdichvu.Columns.Add("IDPhieuThue" ,"IDPhieuThue");
            dgvdichvu.Columns.Add("IDDichVu", "TenDichVu");
            dgvdichvu.Columns.Add("SoLuong", "SoLuong");
            dgvdichvu.Columns.Add("ThanhTien", "ThanhTien");

            dgvdichvu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvdichvu.Columns["ThanhTien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvdichvu.Rows.Clear();
        }


        // 📌 2. Load dữ liệu dịch vụ vào ComboBox
        private void LoadComboBoxDichVu()
        {
            try
            {
                string query = "SELECT IDDichVu, TenDichVu, DonGia FROM DICHVU";
                DataTable dt = db.GetData(query);

                cbdichvu.DataSource = dt;
                cbdichvu.DisplayMember = "TenDichVu";
                cbdichvu.ValueMember = "IDDichVu";
                cbdichvu.SelectedIndex = -1;
                txtdongia.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách dịch vụ: " + ex.Message);
            }
        }

        // 📌 3. Load danh sách số lượng
        private void LoadComboBoxSoLuong()
        {
            cbsoluong.Items.Clear();
            for (int i = 1; i <= 30; i++)
                cbsoluong.Items.Add(i);
        }

        // 📌 4. Khi chọn dịch vụ -> hiện đơn giá + tính lại thành tiền
        private void cbdichvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbdichvu.SelectedIndex != -1)
            {
                DataRowView row = cbdichvu.SelectedItem as DataRowView;
                if (row != null)
                {
                    txtdongia.Text = row["DonGia"].ToString();
                    TinhThanhTien();
                }
            }
            else
            {
                txtdongia.Clear();
                txtthanhtien.Clear();
            }
        }

        // 📌 5. Khi chọn số lượng -> tính lại thành tiền
        private void cbsoluong_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        // 📌 6. Hàm tính thành tiền
        private void TinhThanhTien()
        {
            if (int.TryParse(cbsoluong.Text, out int sl) &&
                decimal.TryParse(txtdongia.Text, out decimal dg))
            {
                txtthanhtien.Text = (sl * dg).ToString("N0"); // định dạng có dấu phân cách
            }
            else
            {
                txtthanhtien.Clear();
            }
        }

        // 📌 7. Khi bấm tìm kiếm khách hàng
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            dgvdichvu.Columns.Clear();
            if (!int.TryParse(txttimkiem.Text.Trim(), out int idPhieuThue))
            {
                MessageBox.Show("Vui lòng nhập ID phiếu thuê hợp lệ (số nguyên)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"
            SELECT 
                kh.HoTen AS TenKhachHang,
                p.TenPhong,
                ctdv.ID,
                ctdv.IDPhieuThue,
                
                dv.TenDichVu,
                ctdv.SoLuong,
                ctdv.ThanhTien
            FROM CHITIET_DICHVU ctdv
            JOIN DICHVU dv ON ctdv.IDDichVu = dv.IDDichVu
            JOIN PHIEUTHUE pt ON ctdv.IDPhieuThue = pt.IDPhieuThue
            JOIN KHACHHANG kh ON pt.IDKhachHang = kh.IDKhachHang
            JOIN PHONG p ON pt.IDPhong = p.IDPhong
            WHERE ctdv.IDPhieuThue = @IDPhieuThue";

                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@IDPhieuThue", SqlDbType.Int) { Value = idPhieuThue }
        };

                DataTable dt = db.GetData(sql, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // 🧩 Hiển thị chi tiết dịch vụ
                    dgvdichvu.AutoGenerateColumns = true;
                    dgvdichvu.DataSource = dt;
                    if (dgvdichvu.Columns.Contains("TenKhachHang"))
                        dgvdichvu.Columns["TenKhachHang"].Visible = false;
                    if (dgvdichvu.Columns.Contains("TenPhong"))
                        dgvdichvu.Columns["TenPhong"].Visible = false;
                    dgvdichvu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    dgvdichvu.Columns["ThanhTien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    txttenkh.Text = dt.Rows[0]["TenKhachHang"].ToString();
                    txtsophong.Text = dt.Rows[0]["TenPhong"].ToString();
                    txtmaphieu.Text = idPhieuThue.ToString();
                    txtmakh.Text = dt.Rows[0]["IDPhieuThue"].ToString();
                    // 🧩 Gán thông tin khách hàng và phòng

                }
                else
                {
                    txtmakh.Clear();
                    txttenkh.Clear();
                    txtsophong.Clear();
                    txtmaphieu.Clear();
                    dgvdichvu.DataSource = null;
                    KhoiTaoDGV();

                    MessageBox.Show($"Phiếu thuê {idPhieuThue} chưa có dịch vụ nào hoặc không tồn tại!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvdichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdichvu.Rows[e.RowIndex];
                cbdichvu.Text = row.Cells["TenDichVu"].Value.ToString();
                cbsoluong.Text = row.Cells["SoLuong"].Value.ToString();
                txtthanhtien.Text = row.Cells["ThanhTien"].Value.ToString();
            }

            // Gán giá trị lên các TextBox

        }
        private void txtmaphieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số và phím điều khiển (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmaphieu.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc tìm kiếm mã phiếu thuê!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPhieuThue = Convert.ToInt32(txtmaphieu.Text.Trim());

            if (string.IsNullOrWhiteSpace(txtmakh.Text))
            {
                MessageBox.Show("Chưa có mã khách hàng! Hãy tìm phiếu thuê trước khi thêm dịch vụ.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbdichvu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần thêm!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cbsoluong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng hợp lệ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDichVu = Convert.ToInt32(((DataRowView)cbdichvu.SelectedItem)["IDDichVu"]);
            decimal donGia = Convert.ToDecimal(((DataRowView)cbdichvu.SelectedItem)["DonGia"]);
            decimal thanhTien = donGia * soLuong;
            DateTime thoiGianGoi = DateTime.Now;

            try
            {
                string sqlInsert = @"
            INSERT INTO CHITIET_DICHVU (IDPhieuThue, IDDichVu, SoLuong, ThoiGianGoi, ThanhTien)
            VALUES (@IDPhieuThue, @IDDichVu, @SoLuong, @ThoiGianGoi, @ThanhTien)";

                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@IDPhieuThue", idPhieuThue),
            new SqlParameter("@IDDichVu", idDichVu),
            new SqlParameter("@SoLuong", soLuong),
            new SqlParameter("@ThoiGianGoi", thoiGianGoi),
            new SqlParameter("@ThanhTien", thanhTien)
        };

                db.ExecuteNonQuery(sqlInsert, parameters);

                MessageBox.Show("Thêm dịch vụ thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Load lại danh sách dịch vụ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetForm();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvdichvu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtmaphieu.Text, out int idPhieuThue))
            {
                MessageBox.Show("Mã phiếu thuê không hợp lệ!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbdichvu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cbsoluong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDichVu = Convert.ToInt32(((DataRowView)cbdichvu.SelectedItem)["IDDichVu"]);
            decimal donGia = Convert.ToDecimal(((DataRowView)cbdichvu.SelectedItem)["DonGia"]);
            decimal thanhTien = donGia * soLuong;

            try
            {
                string sqlUpdate = @"
            UPDATE CHITIET_DICHVU
            SET SoLuong = @SoLuong, ThanhTien = @ThanhTien
            WHERE IDPhieuThue = @IDPhieuThue AND IDDichVu = @IDDichVu";

                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@SoLuong", soLuong),
            new SqlParameter("@ThanhTien", thanhTien),
            new SqlParameter("@IDPhieuThue", idPhieuThue),
            new SqlParameter("@IDDichVu", idDichVu)
        };

                db.ExecuteNonQuery(sqlUpdate, parameters);

                MessageBox.Show("Cập nhật dịch vụ thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dịch vụ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetForm();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvdichvu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtmaphieu.Text, out int idPhieuThue))
            {
                MessageBox.Show("Mã phiếu thuê không hợp lệ!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenDV = dgvdichvu.CurrentRow.Cells["TenDichVu"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa dịch vụ '{tenDV}' khỏi phiếu thuê này không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idDichVu = Convert.ToInt32(dgvdichvu.CurrentRow.Cells["ID"].Value);

                try
                {
                    string sqlDelete = @"
                DELETE FROM CHITIET_DICHVU
                WHERE IDPhieuThue = @IDPhieuThue AND ID = @ID";

                    var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IDPhieuThue", idPhieuThue),
                new SqlParameter("@ID", idDichVu)
            };

                    db.ExecuteNonQuery(sqlDelete, parameters);

                    MessageBox.Show("Xóa dịch vụ thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dịch vụ: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ResetForm();

        }
        private void ResetForm()
        {
            cbdichvu.SelectedIndex = -1;
            cbsoluong.SelectedIndex = -1;
            txtdongia.Clear();
            txtthanhtien.Clear();
        }

    }
}
