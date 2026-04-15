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
    public partial class frmXe : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        bool xuLyThem = false;
        int id;
        string imagesFolder = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory
                .Replace("bin\\Debug\\net9.0-windows\\", "")
                .Replace("bin\\Release\\net9.0-windows\\", ""),
            "Images");

        public frmXe() { InitializeComponent(); ThemeManager.ApplyTheme(this); }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            cboHangXe.Enabled = giaTri;
            cboPhanLoai.Enabled = giaTri;
            txtTenXe.Enabled = giaTri;
            numSoLuong.Enabled = giaTri;
            numGiaBan.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;
            btnDoiAnh.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        public void LayLoaiXeVaoComboBox()
        {
            cboPhanLoai.DataSource = context.LoaiXes.ToList();
            cboPhanLoai.ValueMember = "ID";
            cboPhanLoai.DisplayMember = "TenLX";
        }

        public void LayHangXeVaoComboBox()
        {
            cboHangXe.DataSource = context.HangXes.ToList();
            cboHangXe.ValueMember = "ID";
            cboHangXe.DisplayMember = "TenHX";
        }

        private void frmXe_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LayLoaiXeVaoComboBox();
            LayHangXeVaoComboBox();
            dataGridView1.AutoGenerateColumns = false;

            List<DanhSachXe> dsXe = context.Xes.Select(r => new DanhSachXe
            {
                ID = r.ID,
                LoaiXeID = r.LoaiXeID,
                TenLX = r.LoaiXes.TenLX,
                HangXeID = r.HangXeID,
                TenHX = r.HangXes.TenHX,
                TenXe = r.TenXe,
                GiaBan = r.GiaBan,
                SoLuong = r.SoLuong,
                HinhAnh = r.HinhAnh,
                MoTa = r.MoTa
            }).ToList();

            BindingSource bs = new BindingSource();
            bs.DataSource = dsXe;

            cboPhanLoai.DataBindings.Clear();
            cboPhanLoai.DataBindings.Add("SelectedValue", bs, "LoaiXeID", false, DataSourceUpdateMode.Never);
            cboHangXe.DataBindings.Clear();
            cboHangXe.DataBindings.Add("SelectedValue", bs, "HangXeID", false, DataSourceUpdateMode.Never);
            txtTenXe.DataBindings.Clear();
            txtTenXe.DataBindings.Add("Text", bs, "TenXe", false, DataSourceUpdateMode.Never);
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bs, "MoTa", false, DataSourceUpdateMode.Never);
            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bs, "SoLuong", false, DataSourceUpdateMode.Never);
            numGiaBan.DataBindings.Clear();
            numGiaBan.DataBindings.Add("Value", bs, "GiaBan", false, DataSourceUpdateMode.Never);

            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bs, "HinhAnh");
            hinhAnh.Format += (s, ev) =>
            {
                if (ev.Value is string fileName && !string.IsNullOrEmpty(fileName))
                    ev.Value = Path.Combine(imagesFolder, fileName);
                else
                    ev.Value = null;
            };
            picHinhAnh.DataBindings.Add(hinhAnh);
            dataGridView1.DataSource = bs;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                if (e.Value is string fileName && !string.IsNullOrEmpty(fileName))
                {
                    string imagePath = Path.Combine(imagesFolder, fileName);
                    if (File.Exists(imagePath))
                    {
                        Image image = Image.FromFile(imagePath);
                        image = new Bitmap(image, 24, 24);
                        e.Value = image;
                    }
                    else e.Value = null;
                }
                else e.Value = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cboPhanLoai.SelectedIndex = -1;
            cboHangXe.SelectedIndex = -1;
            txtTenXe.Clear();
            txtMoTa.Clear();
            numSoLuong.Value = 0;
            numGiaBan.Value = 0;
            picHinhAnh.Image = null;
            picHinhAnh.ImageLocation = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một xe để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            xuLyThem = false;
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            BatTatChucNang(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboPhanLoai.SelectedValue == null || string.IsNullOrWhiteSpace(cboPhanLoai.Text))
                MessageBox.Show("Vui lòng chọn loại xe.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboHangXe.SelectedValue == null || string.IsNullOrWhiteSpace(cboHangXe.Text))
                MessageBox.Show("Vui lòng chọn hãng xe.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenXe.Text))
                MessageBox.Show("Vui lòng nhập tên xe.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuong.Value <= 0)
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numGiaBan.Value <= 0)
                MessageBox.Show("Giá bán phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    Xe xe = new Xe()
                    {
                        TenXe = txtTenXe.Text.Trim(),
                        HangXeID = (int)cboHangXe.SelectedValue,
                        LoaiXeID = (int)cboPhanLoai.SelectedValue,
                        SoLuong = (int)numSoLuong.Value,
                        GiaBan = numGiaBan.Value,
                        HinhAnh = picHinhAnh.ImageLocation != null ? Path.GetFileName(picHinhAnh.ImageLocation) : null,
                        MoTa = txtMoTa.Text.Trim()
                    };
                    context.Xes.Add(xe);
                    context.SaveChanges();
                }
                else
                {
                    Xe? xe = context.Xes.Find(id);
                    if (xe != null)
                    {
                        xe.TenXe = txtTenXe.Text.Trim();
                        xe.HangXeID = (int)cboHangXe.SelectedValue;
                        xe.LoaiXeID = (int)cboPhanLoai.SelectedValue;
                        xe.SoLuong = (int)numSoLuong.Value;
                        xe.GiaBan = numGiaBan.Value;
                        xe.MoTa = txtMoTa.Text.Trim();
                        context.Xes.Update(xe);
                        context.SaveChanges();
                    }
                }
                frmXe_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một xe để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string tenXe = txtTenXe.Text;
            if (MessageBox.Show("Xác nhận xóa xe \"" + tenXe + "\"?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                Xe? xe = context.Xes.Find(id);
                if (xe != null) 
                {
                    try
                    {
                        context.Xes.Remove(xe);
                        context.SaveChanges();
                        context.ReseedTable("Xes");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể xóa xe này vì nó đang được sử dụng ở các bảng khác (VD: Hợp đồng)!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                frmXe_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e) => frmXe_Load(sender, e);
        private void btnThoat_Click(object sender, EventArgs e) => this.Close();

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Cập nhật hình ảnh xe";
            ofd.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(ofd.FileName);
                string ext = Path.GetExtension(ofd.FileName);
                string savedFileName = fileName + ext;
                string fileSavePath = Path.Combine(imagesFolder, savedFileName);
                Directory.CreateDirectory(imagesFolder);
                File.Copy(ofd.FileName, fileSavePath, true);
                if (xuLyThem)
                    picHinhAnh.ImageLocation = fileSavePath;
                else if (dataGridView1.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                    Xe? xe = context.Xes.Find(id);
                    if (xe != null)
                    {
                        xe.HinhAnh = savedFileName;
                        context.Xes.Update(xe);
                        context.SaveChanges();
                        frmXe_Load(sender, e);
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng tìm kiếm đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
                                Xe xe = new Xe
                                {
                                    TenXe = r["TenXe"].ToString()!,
                                    HangXeID = int.Parse(r["HangXeID"].ToString()!),
                                    LoaiXeID = int.Parse(r["LoaiXeID"].ToString()!),
                                    GiaBan = decimal.Parse(r["GiaBan"].ToString()!),
                                    SoLuong = int.Parse(r["SoLuong"].ToString()!),
                                    HinhAnh = r.Table.Columns.Contains("HinhAnh") ? r["HinhAnh"].ToString() : null,
                                    MoTa = r.Table.Columns.Contains("MoTa") ? r["MoTa"].ToString() : null
                                };
                                context.Xes.Add(xe);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmXe_Load(sender, e);
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
            sfd.FileName = "Xe_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("TenXe", typeof(string)),
                        new DataColumn("HangXeID", typeof(int)),
                        new DataColumn("TenHX", typeof(string)),
                        new DataColumn("LoaiXeID", typeof(int)),
                        new DataColumn("TenLX", typeof(string)),
                        new DataColumn("GiaBan", typeof(decimal)),
                        new DataColumn("SoLuong", typeof(int)),
                        new DataColumn("MoTa", typeof(string))
                    });
                    var dsXe = context.Xes.Select(r => new DanhSachXe
                    {
                        ID = r.ID, TenXe = r.TenXe,
                        HangXeID = r.HangXeID, TenHX = r.HangXes.TenHX,
                        LoaiXeID = r.LoaiXeID, TenLX = r.LoaiXes.TenLX,
                        GiaBan = r.GiaBan, SoLuong = r.SoLuong, MoTa = r.MoTa
                    }).ToList();
                    foreach (var xe in dsXe)
                        table.Rows.Add(xe.ID, xe.TenXe, xe.HangXeID, xe.TenHX, xe.LoaiXeID, xe.TenLX, xe.GiaBan, xe.SoLuong, xe.MoTa);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "Xe");
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
