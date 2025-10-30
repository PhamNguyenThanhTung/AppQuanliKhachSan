using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTL_QLKhachSan.myForm
{
    public partial class frmEmployeeManagement : Form
    {
        // Danh sách mô phỏng dữ liệu (sau này thay bằng SQL)
        private List<TaiKhoan> danhSachTaiKhoan = new List<TaiKhoan>();
        private TaiKhoan taiKhoanDangChon;
        private enum ActionMode { None, Add, Edit }
        private ActionMode mode = ActionMode.None;

        public frmEmployeeManagement()
        {
            InitializeComponent();
        }

        private void frmEmployeeManagement_Load(object sender, EventArgs e)
        {
            KhoiTaoComboBox();
            TaiDanhSach();
        }

        private void KhoiTaoComboBox()
        {
            cboLoaiTK.Items.AddRange(new string[] { "Admin", "Lễ tân" });
            cboTrangThai.Items.AddRange(new string[] { "Hoạt động", "Khóa" });
        }

        private void TaiDanhSach()
        {
            // Dữ liệu mẫu (thay bằng dữ liệu từ DB)
            danhSachTaiKhoan = new List<TaiKhoan>
            {
                new TaiKhoan { TenHienThi = "Nguyễn Văn A", TenDangNhap = "admin", LoaiTK = "Admin", TrangThai = "Hoạt động" },
                new TaiKhoan { TenHienThi = "Lê Thị B", TenDangNhap = "letan1", LoaiTK = "Lễ tân", TrangThai = "Khóa" }
            };

            dataGridView1.DataSource = danhSachTaiKhoan.Select(x => new
            {
                x.TenHienThi,
                x.TenDangNhap,
                x.LoaiTK,
                x.TrangThai
            }).ToList();
        }

        private void LamMoiForm()
        {
            txtTenHienThi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboLoaiTK.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            taiKhoanDangChon = null;
            mode = ActionMode.None;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            mode = ActionMode.Add;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (taiKhoanDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            mode = ActionMode.Edit;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (taiKhoanDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            taiKhoanDangChon.TrangThai = "Khóa";
            TaiDanhSach();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHienThi.Text) ||
                string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                string.IsNullOrWhiteSpace(cboLoaiTK.Text) ||
                string.IsNullOrWhiteSpace(cboTrangThai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mode == ActionMode.Add)
            {
                TaiKhoan tk = new TaiKhoan
                {
                    TenHienThi = txtTenHienThi.Text,
                    TenDangNhap = txtTenDangNhap.Text,
                    LoaiTK = cboLoaiTK.Text,
                    TrangThai = cboTrangThai.Text
                };
                danhSachTaiKhoan.Add(tk);
            }
            else if (mode == ActionMode.Edit && taiKhoanDangChon != null)
            {
                taiKhoanDangChon.TenHienThi = txtTenHienThi.Text;
                taiKhoanDangChon.LoaiTK = cboLoaiTK.Text;
                taiKhoanDangChon.TrangThai = cboTrangThai.Text;
            }

            TaiDanhSach();
            LamMoiForm();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower();
            var ketQua = danhSachTaiKhoan
                .Where(x => x.TenHienThi.ToLower().Contains(keyword) ||
                            x.TenDangNhap.ToLower().Contains(keyword))
                .Select(x => new
                {
                    x.TenHienThi,
                    x.TenDangNhap,
                    x.LoaiTK,
                    x.TrangThai
                }).ToList();
            dataGridView1.DataSource = ketQua;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenDangNhap = dataGridView1.Rows[e.RowIndex].Cells["TenDangNhap"].Value.ToString();
                taiKhoanDangChon = danhSachTaiKhoan.FirstOrDefault(t => t.TenDangNhap == tenDangNhap);

                if (taiKhoanDangChon != null)
                {
                    txtTenHienThi.Text = taiKhoanDangChon.TenHienThi;
                    txtTenDangNhap.Text = taiKhoanDangChon.TenDangNhap;
                    cboLoaiTK.Text = taiKhoanDangChon.LoaiTK;
                    cboTrangThai.Text = taiKhoanDangChon.TrangThai;
                }
            }
        }
    }

    // Lớp mô phỏng dữ liệu tài khoản
    public class TaiKhoan
    {
        public string TenHienThi { get; set; }
        public string TenDangNhap { get; set; }
        public string LoaiTK { get; set; }
        public string TrangThai { get; set; }
    }
}
