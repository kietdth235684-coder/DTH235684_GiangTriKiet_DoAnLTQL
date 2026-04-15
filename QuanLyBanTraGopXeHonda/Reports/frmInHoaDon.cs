using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyBanTraGopXeHonda.Data;

namespace QuanLyBanTraGopXeHonda.Reports
{
    public partial class frmInHoaDon : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net9.0-windows", "Reports");
        int id; // Mã hợp đồng cần in

        public frmInHoaDon(int maHopDong = 0)
        {
            InitializeComponent();
            QuanLyBanTraGopXeHonda.Forms.ThemeManager.ApplyTheme(this);
            id = maHopDong;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            // Lấy thông tin hợp đồng kèm khách hàng và chi tiết
            var hopDong = context.HopDongs
                .Include(r => r.KhachHang)
                .Include(r => r.NhanVien)
                .Include(r => r.HopDong_ChiTiet)
                .Where(r => r.ID == id)
                .SingleOrDefault();

            if (hopDong == null)
            {
                MessageBox.Show(
                    "Không tìm thấy hợp đồng với mã: " + id,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Lấy chi tiết hợp đồng (xe, ngày thanh toán, số tháng, tiền/tháng, thành tiền)
            var chiTietList = context.HopDong_ChiTiets
                .Where(r => r.HopDongID == id)
                .Select(r => new DanhSachHopDong_ChiTiet
                {
                    ID = r.ID,
                    HopDongID = r.HopDongID,
                    XeID = r.XeID,
                    TenXe = r.Xe.TenXe,
                    NgayThanhToan = r.NgayThanhToan,
                    SoThangThanhToan = r.SoThangThanhToan,
                    SoTienThanhToan = r.SoTienThanhToan,
                    ThanhTien = (decimal)(r.SoThangThanhToan * r.SoTienThanhToan)
                })
                .ToList();

            // Nạp dữ liệu vào DataTable khớp với schema QLBXDataSet
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("HopDongID", typeof(int));
            dt.Columns.Add("XeID", typeof(int));
            dt.Columns.Add("TenXe", typeof(string));
            dt.Columns.Add("NgayThanhToan", typeof(DateTime));
            dt.Columns.Add("SoThangThanhToan", typeof(short));
            dt.Columns.Add("SoTienThanhToan", typeof(int));
            dt.Columns.Add("ThanhTien", typeof(int));

            foreach (var row in chiTietList)
            {
                dt.Rows.Add(
                    row.ID,
                    row.HopDongID,
                    row.XeID,
                    row.TenXe,
                    row.NgayThanhToan,
                    (short)row.SoThangThanhToan,
                    (int)row.SoTienThanhToan,
                    (int)row.ThanhTien
                );
            }

            // Thiết lập DataSource cho ReportViewer
            reportViewer1.LocalReport.ReportPath =
                Path.Combine(reportsFolder, "rptInHoaDon.rdlc");

            var reportDataSource = new ReportDataSource("DanhSachHopDong_ChiTiet", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Thiết lập các tham số cho report
            IList<ReportParameter> parameters = new List<ReportParameter>
            {
                new ReportParameter("NgayLap",
                    string.Format("Ngày {0} Tháng {1} Năm {2}",
                        hopDong.NgayLapHD.Day,
                        hopDong.NgayLapHD.Month,
                        hopDong.NgayLapHD.Year)),

                new ReportParameter("NguoiBan_Ten",      "CÔNG TY TNHH HONDA"),
                new ReportParameter("NguoiBan_DiaChi",   "Mỹ Phước, TP. Long Xuyên, An Giang"),
                new ReportParameter("NguoiBan_MaSoThue", "1602162060"),

                new ReportParameter("NguoiMua_Ten",      hopDong.KhachHang?.HoVaTen ?? ""),
                new ReportParameter("NguoiMua_DiaChi",   hopDong.KhachHang?.DiaChi  ?? ""),
                new ReportParameter("NguoiMua_CCCD", hopDong.KhachHang?.CCCD ?? ""),
            };

            reportViewer1.LocalReport.SetParameters(parameters);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }
    }
}