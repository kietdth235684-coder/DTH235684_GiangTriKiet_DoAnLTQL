using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanTraGopXeHonda.Data;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace QuanLyBanTraGopXeHonda.Forms
{
    public partial class frmHopDong : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        int id;

        public frmHopDong() { InitializeComponent(); ThemeManager.ApplyTheme(this); }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            var query = context.HopDongs
                .Include(h => h.NhanVien)
                .Include(h => h.KhachHang)
                .Include(h => h.Xe)
                .Include(h => h.HopDong_ChiTiet)
                .ToList();
            int stt = 1;
            List<DanhSachHopDong> ds = query.Select(r => new DanhSachHopDong
            {
                ID = stt++,
                ID_Goc = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien?.HoVaTen ?? "",
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang?.HoVaTen ?? "",
                XeID = r.XeID,
                TenXe = r.Xe?.TenXe ?? "",
                NgayLapHD = r.NgayLapHD,
                TongTienHopDong = r.HopDong_ChiTiet.Sum(ct => ct.SoTienThanhToan * ct.SoThangThanhToan),
                XemChiTiet = "Xem chi tiết"
            }).ToList();
            dataGridView.DataSource = ds;
        }

        private void btnLapHopDong_Click(object sender, EventArgs e)
        {
            using (frmHopDong_ChiTiet chiTiet = new frmHopDong_ChiTiet())
            {
                chiTiet.ShowDialog();
                frmHopDong_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID_Goc"].Value.ToString());
            using (frmHopDong_ChiTiet chiTiet = new frmHopDong_ChiTiet(id))
            {
                chiTiet.ShowDialog();
                frmHopDong_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID_Goc"].Value.ToString());
            if (MessageBox.Show("Xác nhận xóa hợp đồng ID = " + id + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var chiTiets = context.HopDong_ChiTiets.Where(r => r.HopDongID == id).ToList();
                    context.HopDong_ChiTiets.RemoveRange(chiTiets);
                    HopDong? hd = context.HopDongs.Find(id);
                    if (hd != null) context.HopDongs.Remove(hd);
                    context.SaveChanges();
                    context.ReseedTable("HopDongs");
                    context.ReseedTable("HopDong_ChiTiets");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa hợp đồng này vì có dữ liệu liên quan khác không thể gỡ bỏ!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmHopDong_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) => this.Close();

        private void btnInHopDong_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để in.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID_Goc"].Value.ToString());
            using (Reports.frmInHoaDon inHopDong = new Reports.frmInHoaDon(id))
            {
                inHopDong.ShowDialog();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng tìm kiếm đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Xuất dữ liệu ra tập tin Excel";
            sfd.Filter = "Tập tin Excel|*.xls;*.xlsx";
            sfd.FileName = "HopDong_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Sheet 1: HopDong
                    DataTable tableHD = new DataTable();
                    tableHD.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTenNhanVien", typeof(string)),
                        new DataColumn("HoVaTenKhachHang", typeof(string)),
                        new DataColumn("TenXe", typeof(string)),
                        new DataColumn("NgayLapHD", typeof(DateTime)),
                        new DataColumn("TongTienHopDong", typeof(decimal))
                    });
                    var dsHD = context.HopDongs.Select(r => new DanhSachHopDong
                    {
                        ID = r.ID,
                        HoVaTenNhanVien = r.NhanVien.HoVaTen,
                        HoVaTenKhachHang = r.KhachHang.HoVaTen,
                        TenXe = r.Xe.TenXe,
                        NgayLapHD = r.NgayLapHD,
                        TongTienHopDong = r.HopDong_ChiTiet.Sum(ct => ct.SoTienThanhToan)
                    }).ToList();
                    foreach (var hd in dsHD)
                        tableHD.Rows.Add(hd.ID, hd.HoVaTenNhanVien, hd.HoVaTenKhachHang, hd.TenXe, hd.NgayLapHD, hd.TongTienHopDong);

                    // Sheet 2: HopDong_ChiTiet
                    DataTable tableCT = new DataTable();
                    tableCT.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HopDongID", typeof(int)),
                        new DataColumn("TenXe", typeof(string)),
                        new DataColumn("NgayThanhToan", typeof(DateTime)),
                        new DataColumn("SoThangThanhToan", typeof(int)),
                        new DataColumn("SoTienThanhToan", typeof(decimal)),
                        new DataColumn("ThanhTien", typeof(decimal))
                    });
                    var dsCT = context.HopDong_ChiTiets.Select(r => new DanhSachHopDong_ChiTiet
                    {
                        ID = r.ID,
                        HopDongID = r.HopDongID,
                        TenXe = r.Xe.TenXe,
                        NgayThanhToan = r.NgayThanhToan,
                        SoThangThanhToan = r.SoThangThanhToan,
                        SoTienThanhToan = r.SoTienThanhToan,
                        ThanhTien = r.SoTienThanhToan
                    }).ToList();
                    foreach (var ct in dsCT)
                        tableCT.Rows.Add(ct.ID, ct.HopDongID, ct.TenXe, ct.NgayThanhToan, ct.SoThangThanhToan, ct.SoTienThanhToan, ct.ThanhTien);

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheetHD = wb.Worksheets.Add(tableHD, "HopDong");
                        sheetHD.Columns().AdjustToContents();
                        var sheetCT = wb.Worksheets.Add(tableCT, "HopDong_ChiTiet");
                        sheetCT.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID_Goc"].Value.ToString());
                using (frmHopDong_ChiTiet chiTiet = new frmHopDong_ChiTiet(id))
                {
                    chiTiet.ShowDialog();
                    frmHopDong_Load(sender, e);
                }
            }
        }
    }
}