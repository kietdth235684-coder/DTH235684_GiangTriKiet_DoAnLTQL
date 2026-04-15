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
    public partial class frmHangXe : Form
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
            txtTenHangXe.Enabled = giatri;
        }

        public frmHangXe() { InitializeComponent(); ThemeManager.ApplyTheme(this); }

        private void frmHangXe_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            var hx = context.HangXes.ToList();
            BindingSource bs = new BindingSource();
            bs.DataSource = hx;
            dataGridView1.DataSource = bs;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                HienThiDuLieuLenControls();
            }
            else
                txtTenHangXe.Clear();
        }

        private void HienThiDuLieuLenControls()
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is HangXe hx)
            {
                txtTenHangXe.Text = hx.TenHX;
                id = hx.ID;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenHangXe.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            HienThiDuLieuLenControls();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is HangXe selected)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa hãng xe '{selected.TenHX}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        context.HangXes.Remove(selected);
                        context.SaveChanges();
                        context.ReseedTable("HangXes");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể xóa hãng xe này vì nó đang được sử dụng ở các bảng khác!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    frmHangXe_Load(sender, e);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHangXe.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hãng xe?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (xuLyThem)
            {
                HangXe newHangXe = new HangXe { TenHX = txtTenHangXe.Text };
                context.HangXes.Add(newHangXe);
            }
            else
            {
                var existing = context.HangXes.Find(id);
                if (existing != null) { existing.TenHX = txtTenHangXe.Text; context.HangXes.Update(existing); }
            }
            context.SaveChanges();
            frmHangXe_Load(sender, e);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            HienThiDuLieuLenControls();
        }

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
                                HangXe hx = new HangXe { TenHX = r["TenHX"].ToString()! };
                                context.HangXes.Add(hx);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmHangXe_Load(sender, e);
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
            sfd.FileName = "HangXe_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("TenHX", typeof(string))
                    });
                    foreach (var hx in context.HangXes.ToList())
                        table.Rows.Add(hx.ID, hx.TenHX);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "HangXe");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
    }
}
