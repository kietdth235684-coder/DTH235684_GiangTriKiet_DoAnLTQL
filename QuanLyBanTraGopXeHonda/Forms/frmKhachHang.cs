using QuanLyBanTraGopXeHonda.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace QuanLyBanTraGopXeHonda.Forms
{
    public partial class KhachHang : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        bool xuLyThem = false;
        int id;

        public KhachHang() { InitializeComponent(); ThemeManager.ApplyTheme(this); }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtCCCD.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            ID.DataPropertyName = "ID";
            HoVaTen.DataPropertyName = "HoVaTen";
            CCCD.DataPropertyName = "CCCD";
            DiaChi.DataPropertyName = "DiaChi";
            DienThoai.DataPropertyName = "DienThoai";

            BatTatChucNang(false);
            var kh = context.KhachHangs.ToList();
            BindingSource bs = new BindingSource();
            bs.DataSource = kh;
            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bs, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bs, "DienThoai", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bs, "DiaChi", false, DataSourceUpdateMode.Never);
            txtCCCD.DataBindings.Clear();
            txtCCCD.DataBindings.Add("Text", bs, "CCCD", false, DataSourceUpdateMode.Never);
            dataGridView1.DataSource = bs;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear(); txtDienThoai.Clear(); txtDiaChi.Clear(); txtCCCD.Clear();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is QuanLyBanTraGopXeHonda.Data.KhachHang selected)
                id = selected.ID;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is QuanLyBanTraGopXeHonda.Data.KhachHang selected)
            {
                if (MessageBox.Show("Xác nhận xóa khách hàng?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var kh = context.KhachHangs.Find(selected.ID);
                    if (kh != null) 
                    {
                        try
                        {
                            context.KhachHangs.Remove(kh);
                            context.SaveChanges();
                            context.ReseedTable("KhachHangs");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không thể xóa khách hàng này vì họ đang có hợp đồng hoặc dữ liệu liên quan khác!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    frmKhachHang_Load(sender, e);
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (xuLyThem)
            {
                var kh = new QuanLyBanTraGopXeHonda.Data.KhachHang
                {
                    HoVaTen = txtHoVaTen.Text,
                    DienThoai = txtDienThoai.Text,
                    DiaChi = txtDiaChi.Text,
                    CCCD = txtCCCD.Text
                };
                context.KhachHangs.Add(kh);
            }
            else
            {
                var kh = context.KhachHangs.Find(id);
                if (kh != null)
                {
                    kh.HoVaTen = txtHoVaTen.Text;
                    kh.DienThoai = txtDienThoai.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    kh.CCCD = txtCCCD.Text;
                }
            }
            context.SaveChanges();
            frmKhachHang_Load(sender, e);
        }

        private void BtnHuyBo_Click(object sender, EventArgs e) => frmKhachHang_Load(sender, e);

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
                                var kh = new QuanLyBanTraGopXeHonda.Data.KhachHang
                                {
                                    HoVaTen = r["HoVaTen"].ToString()!,
                                    CCCD = r.Table.Columns.Contains("CCCD") ? r["CCCD"].ToString() : null,
                                    DienThoai = r.Table.Columns.Contains("DienThoai") ? r["DienThoai"].ToString() : null,
                                    DiaChi = r.Table.Columns.Contains("DiaChi") ? r["DiaChi"].ToString() : null
                                };
                                context.KhachHangs.Add(kh);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmKhachHang_Load(sender, e);
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
            sfd.FileName = "KhachHang_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTen", typeof(string)),
                        new DataColumn("CCCD", typeof(string)),
                        new DataColumn("DienThoai", typeof(string)),
                        new DataColumn("DiaChi", typeof(string))
                    });
                    foreach (var kh in context.KhachHangs.ToList())
                        table.Rows.Add(kh.ID, kh.HoVaTen, kh.CCCD, kh.DienThoai, kh.DiaChi);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "KhachHang");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) => this.Close();
    }
}
