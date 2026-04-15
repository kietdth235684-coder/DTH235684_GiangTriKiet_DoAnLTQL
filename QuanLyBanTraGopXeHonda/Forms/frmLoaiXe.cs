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

namespace QuanLyBanTraGopXeHonda.Forms
{
    public partial class frmLoaiXe : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        bool xuLyThem = false;
        int id;

        private void BatTatChucNang(bool giatri)
        {
            btnThem.Enabled = !giatri;
            btnSua.Enabled = !giatri;
            btnXoa.Enabled = !giatri;
            btnLuu.Enabled = giatri;
            btnHuyBo.Enabled = giatri;
            txtTenLoai.Enabled = giatri;
        }

        private void frmLoaiXe_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            var lx = context.LoaiXes.ToList();
            BindingSource bs = new BindingSource();
            bs.DataSource = lx;
            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", bs, "TenLX", false, DataSourceUpdateMode.Never);
            dataGridView1.DataSource = bs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenLoai.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is LoaiXe selected)
                id = selected.ID;
            else
            {
                MessageBox.Show("Không có dòng nào được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
                MessageBox.Show("Vui lòng nhập tên loại xe?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    LoaiXe lsp = new LoaiXe { TenLX = txtTenLoai.Text };
                    context.LoaiXes.Add(lsp);
                    context.SaveChanges();
                }
                else
                {
                    LoaiXe? lsp = context.LoaiXes.Find(id);
                    if (lsp != null)
                    {
                        lsp.TenLX = txtTenLoai.Text;
                        context.LoaiXes.Update(lsp);
                        context.SaveChanges();
                    }
                }
                frmLoaiXe_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is LoaiXe selected)
            {
                if (MessageBox.Show("Xác nhận xóa loại xe?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoaiXe? lsp = context.LoaiXes.Find(selected.ID);
                    if (lsp != null) 
                    {
                        try
                        {
                            context.LoaiXes.Remove(lsp);
                            context.SaveChanges();
                            context.ReseedTable("LoaiXes");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không thể xóa loại xe này vì nó đang được sử dụng ở các bảng khác!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    frmLoaiXe_Load(sender, e);
                }
            }
            else
                MessageBox.Show("Không có dòng nào được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuyBo_Click(object sender, EventArgs e) => frmLoaiXe_Load(sender, e);

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
                                LoaiXe lx = new LoaiXe { TenLX = r["TenLX"].ToString()! };
                                context.LoaiXes.Add(lx);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmLoaiXe_Load(sender, e);
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
            sfd.FileName = "LoaiXe_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("TenLX", typeof(string))
                    });
                    foreach (var lx in context.LoaiXes.ToList())
                        table.Rows.Add(lx.ID, lx.TenLX);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "LoaiXe");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

        public frmLoaiXe() { InitializeComponent(); ThemeManager.ApplyTheme(this); }

        private void btnThoat_Click(object sender, EventArgs e) => this.Close();
    }
}
