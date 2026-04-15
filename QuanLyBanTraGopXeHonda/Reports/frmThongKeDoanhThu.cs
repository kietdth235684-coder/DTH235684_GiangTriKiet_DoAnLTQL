using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanTraGopXeHonda.Data;

namespace QuanLyBanTraGopXeHonda.Reports
{
    public partial class frmThongKeDoanhThu : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net9.0-windows", "Reports");

        public frmThongKeDoanhThu()
        {
            InitializeComponent();
            QuanLyBanTraGopXeHonda.Forms.ThemeManager.ApplyTheme(this);
        }

        // ── Load: hiển thị tất cả, mô tả "(Tất cả thời gian)" ───────────────
        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            var danhSachHopDong = context.HopDongs.Select(r => new DanhSachHopDong
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                XeID = r.XeID,
                TenXe = r.Xe.TenXe,
                NgayLapHD = r.NgayLapHD,
                TongTienHopDong = r.HopDong_ChiTiet.Sum(ct => ct.SoTienThanhToan * ct.SoThangThanhToan),
                XemChiTiet = "Xem"
            }).ToList();

            BindReport(danhSachHopDong, "(Tất cả thời gian)");
        }

        // ── Lọc kết quả theo khoảng ngày ────────────────────────────────────
        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var danhSachHopDong = context.HopDongs.Select(r => new DanhSachHopDong
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                XeID = r.XeID,
                TenXe = r.Xe.TenXe,
                NgayLapHD = r.NgayLapHD,
                TongTienHopDong = r.HopDong_ChiTiet.Sum(ct => ct.SoTienThanhToan * ct.SoThangThanhToan),
                XemChiTiet = "Xem"
            });

            danhSachHopDong = danhSachHopDong
                .Where(r => r.NgayLapHD >= dtpTuNgay.Value.Date && r.NgayLapHD <= dtpDenNgay.Value.Date);

            string moTa = "Từ ngày " + dtpTuNgay.Text + " - Đến ngày: " + dtpDenNgay.Text;
            BindReport(danhSachHopDong.ToList(), moTa);
        }

        // ── Hiện tất cả: gọi lại Load ────────────────────────────────────────
        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu_Load(sender, e);
        }

        // ── Bind dữ liệu vào ReportViewer ────────────────────────────────────
        private void BindReport(System.Collections.Generic.List<DanhSachHopDong> data, string moTaKetQua)
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("NhanVienID", typeof(int));
            dt.Columns.Add("HoVaTenNhanVien", typeof(string));
            dt.Columns.Add("KhachHangID", typeof(int));
            dt.Columns.Add("HoVaTenKhachHang", typeof(string));
            dt.Columns.Add("XeID", typeof(int));
            dt.Columns.Add("TenXe", typeof(string));
            dt.Columns.Add("NgayLapHD", typeof(DateTime));
            dt.Columns.Add("TongTienHopDong", typeof(decimal));
            dt.Columns.Add("XemChiTiet", typeof(string));

            foreach (var row in data)
            {
                dt.Rows.Add(
                    row.ID,
                    row.NhanVienID,
                    row.HoVaTenNhanVien,
                    row.KhachHangID,
                    row.HoVaTenKhachHang,
                    row.XeID,
                    row.TenXe,
                    row.NgayLapHD,
                    row.TongTienHopDong,
                    row.XemChiTiet ?? ""
                );
            }

            // Ensure report path is set before adding data sources so RDLC schema is loaded first
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

            var reportDataSource = new ReportDataSource("DanhSachHopDong", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            var reportParameter = new ReportParameter("MoTaKetQuaHienThi", moTaKetQua);
            reportViewer1.LocalReport.SetParameters(reportParameter);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }
    }
}