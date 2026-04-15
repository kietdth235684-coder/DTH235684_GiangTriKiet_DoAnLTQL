using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanTraGopXeHonda.Data;
using BC = BCrypt.Net.BCrypt;

namespace QuanLyBanTraGopXeHonda.Forms
{
    public partial class frmDoiMatKhau : Form
    {
        private readonly string _tenDangNhap;
        private readonly QLBXDbContext _context;

        // Nhận tên đăng nhập và DbContext từ frmMain truyền vào
        public frmDoiMatKhau(string tenDangNhap, QLBXDbContext context)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _tenDangNhap = tenDangNhap;
            _context = context;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhan = txtXacNhan.Text;

            // ── Validation ────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXacNhan.Focus();
                return;
            }

            // ── Kiểm tra mật khẩu cũ ─────────────────────────────────────
            var nv = _context.NhanViens
                             .Where(r => r.TenDangNhap == _tenDangNhap)
                             .SingleOrDefault();

            if (nv == null || !BC.Verify(matKhauCu, nv.MatKhau))
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauCu.Clear();
                txtMatKhauCu.Focus();
                return;
            }

            // ── Cập nhật mật khẩu mới ─────────────────────────────────────
            nv.MatKhau = BC.HashPassword(matKhauMoi);
            _context.SaveChanges();

            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtXacNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDoiMatKhau_Click(sender, e);
        }
    }
}