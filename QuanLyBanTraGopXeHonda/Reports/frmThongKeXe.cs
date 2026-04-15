using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanTraGopXeHonda.Data;

namespace QuanLyBanTraGopXeHonda.Reports
{
    public partial class frmThongKeXe : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        QLBXDataSet.DanhSachXeDataTable danhSachXeDataTable = new QLBXDataSet.DanhSachXeDataTable();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net9.0-windows", "Reports");

        public frmThongKeXe()
        {
            InitializeComponent();
            QuanLyBanTraGopXeHonda.Forms.ThemeManager.ApplyTheme(this);
        }

        // ── Nạp danh sách Loại xe vào ComboBox ──────────────────────────────
        public void LayLoaiXeVaoComboBox()
        {
            var loaiXeList = context.LoaiXes.OrderBy(r => r.TenLX).ToList();
            cboLoaiXe.DataSource = new System.Collections.Generic.List<LoaiXe>(loaiXeList);
            cboLoaiXe.DisplayMember = "TenLX";
            cboLoaiXe.ValueMember = "ID";
            cboLoaiXe.SelectedIndex = -1;
        }

        // ── Nạp danh sách Hãng xe vào ComboBox ──────────────────────────────
        public void LayHangXeVaoComboBox()
        {
            var hangXeList = context.HangXes.OrderBy(r => r.TenHX).ToList();
            cboHangXe.DataSource = new System.Collections.Generic.List<HangXe>(hangXeList);
            cboHangXe.DisplayMember = "TenHX";
            cboHangXe.ValueMember = "ID";
            cboHangXe.SelectedIndex = -1;
        }

        // ── Load: hiển thị tất cả xe, mô tả "(Tất cả sản phẩm)" ────────────
        private void frmThongKeXe_Load(object sender, EventArgs e)
        {
            LayLoaiXeVaoComboBox();
            LayHangXeVaoComboBox();

            var danhSachXe = context.Xes.Select(r => new DanhSachXe
            {
                ID       = r.ID,
                HangXeID = r.HangXeID,
                TenHX    = r.HangXes.TenHX,
                LoaiXeID = r.LoaiXeID,
                TenLX    = r.LoaiXes.TenLX,
                TenXe    = r.TenXe,
                GiaBan   = r.GiaBan,
                SoLuong  = r.SoLuong,
                HinhAnh  = r.HinhAnh,
                MoTa     = r.MoTa
            }).ToList();

            danhSachXeDataTable.Clear();
            foreach (var row in danhSachXe)
            {
                danhSachXeDataTable.AddDanhSachXeRow(
                    row.ID,
                    row.HangXeID,
                    row.TenHX,
                    row.LoaiXeID,
                    row.TenLX,
                    row.TenXe,
                    Convert.ToInt32(row.GiaBan),
                    row.SoLuong,
                    row.HinhAnh,
                    row.MoTa
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name  = "DanhSachXe";
            reportDataSource.Value = danhSachXeDataTable;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeXe.rdlc");

            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "(Tất cả sản phẩm)");
            reportViewer1.LocalReport.SetParameters(reportParameter);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }

        // ── Lọc kết quả theo Hãng xe và/hoặc Loại xe ────────────────────────
        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            // Nếu cả 2 ComboBox đều bỏ trống thì hiển thị tất cả
            if (cboHangXe.Text == "" && cboLoaiXe.Text == "")
            {
                frmThongKeXe_Load(sender, e);
                return;
            }

            var danhSachXe = context.Xes.Select(r => new DanhSachXe
            {
                ID       = r.ID,
                HangXeID = r.HangXeID,
                TenHX    = r.HangXes.TenHX,
                LoaiXeID = r.LoaiXeID,
                TenLX    = r.LoaiXes.TenLX,
                TenXe    = r.TenXe,
                GiaBan   = r.GiaBan,
                SoLuong  = r.SoLuong,
                HinhAnh  = r.HinhAnh,
                MoTa     = r.MoTa
            });

            string hangXe = null;
            string loaiXe = null;

            if (cboHangXe.Text != "")
            {
                int hangXeID = Convert.ToInt32(cboHangXe.SelectedValue.ToString());
                hangXe = "Hãng xe: " + cboHangXe.Text;
                danhSachXe = danhSachXe.Where(r => r.HangXeID == hangXeID);
            }

            if (cboLoaiXe.Text != "")
            {
                int loaiXeID = Convert.ToInt32(cboLoaiXe.SelectedValue.ToString());
                loaiXe = "Loại xe: " + cboLoaiXe.Text;
                danhSachXe = danhSachXe.Where(r => r.LoaiXeID == loaiXeID);
            }

            danhSachXeDataTable.Clear();
            foreach (var row in danhSachXe)
            {
                danhSachXeDataTable.AddDanhSachXeRow(
                    row.ID,
                    row.HangXeID,
                    row.TenHX,
                    row.LoaiXeID,
                    row.TenLX,
                    row.TenXe,
                    Convert.ToInt32(row.GiaBan),
                    row.SoLuong,
                    row.HinhAnh,
                    row.MoTa
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name  = "DanhSachXe";
            reportDataSource.Value = danhSachXeDataTable;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeXe.rdlc");

            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "(" + hangXe + " - " + loaiXe + ")");
            reportViewer1.LocalReport.SetParameters(reportParameter);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }
    }
}