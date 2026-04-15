namespace QuanLyBanTraGopXeHonda.Forms
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            statusStrip = new StatusStrip();
            helpProvider1 = new HelpProvider();

            // ── Menu items ──────────────────────────────────────────────────
            mnuHeThong = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();

            mnuQuanLy = new ToolStripMenuItem();
            mnuLoaiXe = new ToolStripMenuItem();
            mnuHangXe = new ToolStripMenuItem();
            mnuXe = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            mnuHopDong = new ToolStripMenuItem();

            mnuBaoCaoThongKe = new ToolStripMenuItem();
            mnuThongKeXe = new ToolStripMenuItem();
            mnuThongKeDoanhThu = new ToolStripMenuItem();

            mnuTroGiup = new ToolStripMenuItem();
            mnuHuongDanSuDung = new ToolStripMenuItem();
            mnuThongTinPhanMem = new ToolStripMenuItem();

            // ── Status labels ───────────────────────────────────────────────
            lblTrangThai = new ToolStripStatusLabel();
            lblSpring = new ToolStripStatusLabel();
            lblLienKet = new ToolStripStatusLabel();

            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();

            // menuStrip
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuBaoCaoThongKe, mnuTroGiup });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1280, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            menuStrip.Visible = true;

            // mnuHeThong
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangNhap, mnuDangXuat, mnuDoiMatKhau, new ToolStripSeparator(), mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Text = "Hệ thống";

            // mnuDangNhap
            mnuDangNhap.Name = "mnuDangNhap";
            mnuDangNhap.Text = "Đăng nhập...";
            mnuDangNhap.Click += mnuDangNhap_Click;

            // mnuDangXuat
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;

            // mnuDoiMatKhau
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Text = "Đổi mật khẩu...";
            mnuDoiMatKhau.Click += mnuDoiMatKhau_Click;

            // mnuThoat
            mnuThoat.Name = "mnuThoat";
            mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;

            // mnuQuanLy
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuLoaiXe, mnuHangXe, mnuXe, mnuKhachHang, mnuNhanVien, mnuHopDong });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Text = "Quản lý";

            // mnuLoaiXe
            mnuLoaiXe.Name = "mnuLoaiXe";
            mnuLoaiXe.Text = "Loại xe...";
            mnuLoaiXe.Click += mnuLoaiXe_Click;

            // mnuHangXe
            mnuHangXe.Name = "mnuHangXe";
            mnuHangXe.Text = "Hãng xe...";
            mnuHangXe.Click += mnuHangXe_Click;

            // mnuXe
            mnuXe.Name = "mnuXe";
            mnuXe.Text = "Sản phẩm (Xe)...";
            mnuXe.Click += mnuXe_Click;

            // mnuKhachHang
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Text = "Khách hàng...";
            mnuKhachHang.Click += mnuKhachHang_Click;

            // mnuNhanVien
            mnuNhanVien.Name = "mnuNhanVien";
            mnuNhanVien.Text = "Nhân viên...";
            mnuNhanVien.Click += mnuNhanVien_Click;

            // mnuHopDong
            mnuHopDong.Name = "mnuHopDong";
            mnuHopDong.Text = "Hợp đồng bán hàng...";
            mnuHopDong.Click += mnuHopDong_Click;

            // mnuBaoCaoThongKe
            mnuBaoCaoThongKe.DropDownItems.AddRange(new ToolStripItem[] { mnuThongKeXe, mnuThongKeDoanhThu });
            mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe";
            mnuBaoCaoThongKe.Text = "Báo cáo – Thống kê";

            // mnuThongKeXe
            mnuThongKeXe.Name = "mnuThongKeXe";
            mnuThongKeXe.Text = "Thống kê sản phẩm...";
            mnuThongKeXe.Click += mnuThongKeXe_Click;

            // mnuThongKeDoanhThu
            mnuThongKeDoanhThu.Name = "mnuThongKeDoanhThu";
            mnuThongKeDoanhThu.Text = "Thống kê doanh thu...";
            mnuThongKeDoanhThu.Click += mnuThongKeDoanhThu_Click;

            // mnuTroGiup
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuHuongDanSuDung, mnuThongTinPhanMem });
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Text = "Trợ giúp";

            // mnuHuongDanSuDung
            mnuHuongDanSuDung.Name = "mnuHuongDanSuDung";
            mnuHuongDanSuDung.ShortcutKeys = Keys.Control | Keys.F1;
            mnuHuongDanSuDung.Text = "Hướng dẫn sử dụng";
            mnuHuongDanSuDung.Click += mnuHuongDanSuDung_Click;

            // mnuThongTinPhanMem
            mnuThongTinPhanMem.Name = "mnuThongTinPhanMem";
            mnuThongTinPhanMem.Text = "Thông tin phần mềm...";
            mnuThongTinPhanMem.Click += mnuThongTinPhanMem_Click;

            // statusStrip
            statusStrip.Items.AddRange(new ToolStripItem[] { lblTrangThai, lblSpring, lblLienKet });
            statusStrip.Location = new Point(0, 720);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1280, 26);
            statusStrip.TabIndex = 1;

            // lblTrangThai
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(120, 20);
            lblTrangThai.Text = "Chưa đăng nhập.";

            // lblSpring (spacer)
            lblSpring.Name = "lblSpring";
            lblSpring.Size = new Size(0, 20);
            lblSpring.Spring = true;
            lblSpring.Text = "";

            // lblLienKet
            lblLienKet.IsLink = true;
            lblLienKet.Name = "lblLienKet";
            lblLienKet.Size = new Size(70, 20);
            lblLienKet.Text = "© 2024 FIT";
            lblLienKet.Click += lblLienKet_Click;

            // frmMain
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 746);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý bán trả góp xe Honda";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;

            // helpProvider1 – F1 sẽ mở file hướng dẫn sử dụng (Help/index.html)
            helpProvider1.HelpNamespace = System.IO.Path.Combine(
                Application.StartupPath.Replace("bin\\Debug\\net9.0-windows", ""),
                "Help", "index.html");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.TableOfContents);
            helpProvider1.SetShowHelp(this, true);

            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        // MenuStrip
        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuLoaiXe;
        private ToolStripMenuItem mnuHangXe;
        private ToolStripMenuItem mnuXe;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuHopDong;
        private ToolStripMenuItem mnuBaoCaoThongKe;
        private ToolStripMenuItem mnuThongKeXe;
        private ToolStripMenuItem mnuThongKeDoanhThu;
        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuHuongDanSuDung;
        private ToolStripMenuItem mnuThongTinPhanMem;

        // StatusStrip
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel lblSpring;
        private ToolStripStatusLabel lblLienKet;

        // HelpProvider
        private HelpProvider helpProvider1;
    }
}