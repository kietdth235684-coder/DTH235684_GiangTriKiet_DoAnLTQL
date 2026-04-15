using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using QuanLyBanTraGopXeHonda.Data;
using BC = BCrypt.Net.BCrypt;

namespace QuanLyBanTraGopXeHonda.Forms
{
    public partial class frmMain : Form
    {
        QLBXDbContext context = new QLBXDbContext();

        // MDI child form instances
        frmLoaiXe loaiXe = null;
        frmHangXe hangXe = null;
        frmXe xe = null;
        KhachHang khachHang = null;
        frmNhanVien nhanVien = null;
        frmHopDong hopDong = null;
        frmDangNhap dangNhap = null;

        string hoVaTenNhanVien = "";
        string tenDangNhapHienTai = "";   // ← thêm: lưu tên đăng nhập hiện tại

        public frmMain()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        // ── Load ────────────────────────────────────────────────────────────
        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
            DangNhap();
        }

        // ── Permission helpers ───────────────────────────────────────────────
        public void ChuaDangNhap()
        {
            tenDangNhapHienTai = "";   // ← reset khi đăng xuất
            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;
            mnuLoaiXe.Enabled = false;
            mnuHangXe.Enabled = false;
            mnuXe.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuHopDong.Enabled = false;
            mnuThongKeXe.Enabled = false;
            mnuThongKeDoanhThu.Enabled = false;
            lblTrangThai.Text = "Chưa đăng nhập.";
        }

        public void QuyenQuanLy()
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuLoaiXe.Enabled = true;
            mnuHangXe.Enabled = true;
            mnuXe.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuHopDong.Enabled = true;
            mnuThongKeXe.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;
            lblTrangThai.Text = "Quản lý: " + hoVaTenNhanVien;
        }

        public void QuyenNhanVien()
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuLoaiXe.Enabled = false;
            mnuHangXe.Enabled = false;
            mnuXe.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuKhachHang.Enabled = true;
            mnuHopDong.Enabled = true;
            mnuThongKeXe.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;
            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
        }

        // ── Login logic ──────────────────────────────────────────────────────
        private void DangNhap()
        {
        LamLai:
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new frmDangNhap();

            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                string tenDangNhap = dangNhap.txtTenDangNhap.Text;
                string matKhau = dangNhap.txtMatKhau.Text;

                if (tenDangNhap.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                else if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtMatKhau.Focus();
                    goto LamLai;
                }
                else
                {
                    var nv = context.NhanViens.Where(r => r.TenDangNhap == tenDangNhap).SingleOrDefault();
                    if (nv == null)
                    {
                        MessageBox.Show("Tên đăng nhập không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtTenDangNhap.Focus();
                        goto LamLai;
                    }
                    else
                    {
                        if (BC.Verify(matKhau, nv.MatKhau))
                        {
                            hoVaTenNhanVien = nv.HoVaTen;
                            tenDangNhapHienTai = nv.TenDangNhap;   // ← lưu lại
                            if (nv.QuyenHan == true)
                                QuyenQuanLy();
                            else
                                QuyenNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dangNhap.txtMatKhau.Focus();
                            goto LamLai;
                        }
                    }
                }
            }
        }

        // ── Menu: Hệ thống ───────────────────────────────────────────────────
        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
                child.Close();
            ChuaDangNhap();
        }

        // ← THAY THẾ: mở form đổi mật khẩu thật sự
        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            using var frm = new frmDoiMatKhau(tenDangNhapHienTai, context);
            frm.ShowDialog(this);
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ── Menu: Quản lý ───────────────────────────────────────────────────
        private void mnuLoaiXe_Click(object sender, EventArgs e)
        {
            if (loaiXe == null || loaiXe.IsDisposed)
            {
                loaiXe = new frmLoaiXe();
                loaiXe.MdiParent = this;
                loaiXe.Show();
            }
            else
                loaiXe.Activate();
        }

        private void mnuHangXe_Click(object sender, EventArgs e)
        {
            if (hangXe == null || hangXe.IsDisposed)
            {
                hangXe = new frmHangXe();
                hangXe.MdiParent = this;
                hangXe.Show();
            }
            else
                hangXe.Activate();
        }

        private void mnuXe_Click(object sender, EventArgs e)
        {
            if (xe == null || xe.IsDisposed)
            {
                xe = new frmXe();
                xe.MdiParent = this;
                xe.Show();
            }
            else
                xe.Activate();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (khachHang == null || khachHang.IsDisposed)
            {
                khachHang = new KhachHang();
                khachHang.MdiParent = this;
                khachHang.Show();
            }
            else
                khachHang.Activate();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            if (nhanVien == null || nhanVien.IsDisposed)
            {
                nhanVien = new frmNhanVien();
                nhanVien.MdiParent = this;
                nhanVien.Show();
            }
            else
                nhanVien.Activate();
        }

        private void mnuHopDong_Click(object sender, EventArgs e)
        {
            if (hopDong == null || hopDong.IsDisposed)
            {
                hopDong = new frmHopDong();
                hopDong.MdiParent = this;
                hopDong.Show();
            }
            else
                hopDong.Activate();
        }

        // ── Menu: Báo cáo – Thống kê ────────────────────────────────────────
        private void mnuThongKeXe_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmThongKeXe"] == null)
            {
                Reports.frmThongKeXe frm = new Reports.frmThongKeXe();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                Application.OpenForms["frmThongKeXe"].Activate();
            }
        }

        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmThongKeDoanhThu"] == null)
            {
                Reports.frmThongKeDoanhThu frm = new Reports.frmThongKeDoanhThu();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                Application.OpenForms["frmThongKeDoanhThu"].Activate();
            }
        }

        // ── Menu: Trợ giúp ──────────────────────────────────────────────────
        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            string helpFile = Path.Combine(
                Application.StartupPath.Replace("bin\\Debug\\net9.0-windows", ""),
                "Help", "index.html");

            if (File.Exists(helpFile))
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = helpFile,
                    UseShellExecute = true
                };
                Process.Start(info);
            }
            else
            {
                MessageBox.Show(
                    "Không tìm thấy file hướng dẫn:\n" + helpFile,
                    "Trợ giúp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quản lý bán trả góp xe Honda\nPhiên bản: 1.0\n© 2024 FIT", "Thông tin phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── StatusStrip link ────────────────────────────────────────────────
        private void lblLienKet_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer.exe";
            info.Arguments = "https://fit.agu.edu.vn";
            Process.Start(info);
        }
    }
}