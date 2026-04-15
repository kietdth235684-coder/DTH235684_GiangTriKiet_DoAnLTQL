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
using BC = BCrypt.Net.BCrypt;
using ClosedXML.Excel;

namespace QuanLyBanTraGopXeHonda.Forms
{
    public partial class frmNhanVien : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        bool xuLyThem = false;
        int id;

        public frmNhanVien() { InitializeComponent(); ThemeManager.ApplyTheme(this); }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtTenDangNhap.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnThoat.Enabled = !giaTri;
            btnHuyBo.Enabled = giaTri;
            btnLuu.Enabled = giaTri;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView1.AutoGenerateColumns = false;
            var nv = context.NhanViens.ToList();
            BindingSource bs = new BindingSource { DataSource = nv };
            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bs, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bs, "DienThoai", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bs, "DiaChi", false, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", bs, "TenDangNhap", false, DataSourceUpdateMode.Never);
            cboQuyenHan.DataBindings.Clear();
            cboQuyenHan.DataBindings.Add("SelectedIndex", bs, "QuyenHan", false, DataSourceUpdateMode.Never);
            dataGridView1.DataSource = bs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear(); txtDienThoai.Clear(); txtDiaChi.Clear();
            txtTenDangNhap.Clear(); txtMatKhau.Clear(); cboQuyenHan.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is NhanVien selected) id = selected.ID;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                MessageBox.Show("Vui lòng nhập tên đăng nhập?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboQuyenHan.Text))
                MessageBox.Show("Vui lòng chọn quyền hạn cho nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        MessageBox.Show("Vui lòng nhập mật khẩu?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        NhanVien nv = new NhanVien
                        {
                            HoVaTen = txtHoVaTen.Text,
                            DienThoai = txtDienThoai.Text,
                            DiaChi = txtDiaChi.Text,
                            TenDangNhap = txtTenDangNhap.Text,
                            MatKhau = BC.HashPassword(txtMatKhau.Text),
                            QuyenHan = cboQuyenHan.SelectedIndex == 0
                        };
                        context.NhanViens.Add(nv);
                        context.SaveChanges();
                    }
                }
                else
                {
                    NhanVien? nv = context.NhanViens.Find(id);
                    if (nv != null)
                    {
                        nv.HoVaTen = txtHoVaTen.Text;
                        nv.DienThoai = txtDienThoai.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.TenDangNhap = txtTenDangNhap.Text;
                        nv.QuyenHan = cboQuyenHan.SelectedIndex == 0;
                        context.NhanViens.Update(nv);
                        if (string.IsNullOrEmpty(txtMatKhau.Text))
                            context.Entry(nv).Property(x => x.MatKhau).IsModified = false;
                        else
                            nv.MatKhau = BC.HashPassword(txtMatKhau.Text);
                        context.SaveChanges();
                    }
                }
                frmNhanVien_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is NhanVien selected)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        context.NhanViens.Remove(selected);
                        context.SaveChanges();
                        context.ReseedTable("NhanViens");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể xóa nhân viên này vì họ đã lập các hợp đồng hoặc có dữ liệu liên quan khác!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    frmNhanVien_Load(sender, e);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e) => frmNhanVien_Load(sender, e);
        private void btnThoat_Click(object sender, EventArgs e) => this.Close();

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Nhập dữ liệu từ tập tin Excel";
            ofd.Filter = "Tập tin Excel|*.xls;*.xlsx";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(ofd.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString());
                                firstRow = false;
                            }
                            else
                            {
                                table.Rows.Add();
                                int ci = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Rows[table.Rows.Count - 1][ci++] = cell.Value.ToString();
                            }
                        }
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow r in table.Rows)
                            {
                                // Mật khẩu nhập từ Excel sẽ được hash
                                string matKhau = r.Table.Columns.Contains("MatKhau") ? r["MatKhau"].ToString()! : "123456";
                                bool quyenHan = false;
                                if (r.Table.Columns.Contains("QuyenHan"))
                                    bool.TryParse(r["QuyenHan"].ToString(), out quyenHan);

                                NhanVien nv = new NhanVien
                                {
                                    HoVaTen = r["HoVaTen"].ToString()!,
                                    DienThoai = r.Table.Columns.Contains("DienThoai") ? r["DienThoai"].ToString() : null,
                                    DiaChi = r.Table.Columns.Contains("DiaChi") ? r["DiaChi"].ToString() : null,
                                    TenDangNhap = r["TenDangNhap"].ToString()!,
                                    MatKhau = BC.HashPassword(matKhau),
                                    QuyenHan = quyenHan
                                };
                                context.NhanViens.Add(nv);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmNhanVien_Load(sender, e);
                        }
                        if (firstRow)
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Xuất dữ liệu ra tập tin Excel";
            sfd.Filter = "Tập tin Excel|*.xls;*.xlsx";
            sfd.FileName = "NhanVien_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTen", typeof(string)),
                        new DataColumn("DienThoai", typeof(string)),
                        new DataColumn("DiaChi", typeof(string)),
                        new DataColumn("TenDangNhap", typeof(string)),
                        new DataColumn("QuyenHan", typeof(bool))
                    });
                    foreach (var nv in context.NhanViens.ToList())
                        table.Rows.Add(nv.ID, nv.HoVaTen, nv.DienThoai, nv.DiaChi, nv.TenDangNhap, nv.QuyenHan);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhanVien");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }
    }
}
