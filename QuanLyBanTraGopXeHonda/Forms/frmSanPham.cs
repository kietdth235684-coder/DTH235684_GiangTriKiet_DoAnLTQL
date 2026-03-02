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

namespace QuanLyBanTraGopXeHonda.Forms
{
    public partial class frmSanPham : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        bool xuLyThem = false;
        int id;
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "Images");

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            cboHangXe.Enabled = giaTri;
            cboPhanLoai.Enabled = giaTri;
            txtTenXe.Enabled = giaTri;
            numSoLuong.Enabled = giaTri;
            numDonGia.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = !giaTri;
            btnDoiAnh.Enabled = !giaTri;
            
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
            cboPhanLoai.DisplayMember = "TenLoai";
        }
        public void LayHangXeVaoComboBox()
        {
            cboHangXe.DataSource = context.HangXes.ToList();
            cboHangXe.ValueMember = "ID";
            cboHangXe.DisplayMember = "TenHangXe";
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LayLoaiXeVaoComboBox();
            LayHangXeVaoComboBox();
            dataGridView1.AutoGenerateColumns = false;

            List<DanhSachXe> xe = new List<DanhSachXe>();
            xe = context.Xes.Select(r => new DanhSachXe
            {
                ID = r.ID,
                LoaiXeID = r.LoaiXeID,
                TenLX = r.LoaiXes.TenLX,
                HangXeID = r.HangXeID,
                TenHX = r.HangXes.TenHX,
                TenXe = r.TenXe,
                GiaBan = r.GiaBan,
                SoLuong = r.SoLuong,
                HinhAnh = r.HinhAnh
            }).ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = xe;

            cboPhanLoai.DataBindings.Clear();
            cboPhanLoai.DataBindings.Add("SelectedValue", bindingSource, "LoaiXeID", false, DataSourceUpdateMode.Never);

            // Tương tự đối với cboHangSanXuat

            txtTenXe.DataBindings.Clear();
            txtTenXe.DataBindings.Add("Text", bindingSource, "TenXe", false, DataSourceUpdateMode.Never);

            // Tương tự đối với txtMoTa

            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bindingSource, "SoLuong", false, DataSourceUpdateMode.Never);

            // Tương tự đối với numDonGia
            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bindingSource, "HinhAnh");
            hinhAnh.Format += (s, e) =>
            {
                if (e.Value is string fileName && !string.IsNullOrEmpty(fileName))
                {
                    e.Value = Path.Combine(imagesFolder, fileName);
                }
                else
                {
                    e.Value = null;
                }
            };
            picHinhAnh.DataBindings.Add(hinhAnh);

            dataGridView1.DataSource = bindingSource;

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
                    else
                    {
                        e.Value = null;
                    }
                }
                else
                {
                    e.Value = null;
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is Xe selected)
            {
                id = selected.ID;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboPhanLoai.Text))
                MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboHangXe.Text))
                MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenXe.Text))
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuong.Value <= 0)
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGia.Value <= 0)
                MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    Xe xe = new Xe()
                    {   
                        TenXe = txtTenXe.Text,
                        HangXeID = cboHangXe.SelectedValue is int hangXeId ? hangXeId : 0,
                        LoaiXeID = cboPhanLoai.SelectedValue is int loaiXeId ? loaiXeId : 0,
                        SoLuong = (int)numSoLuong.Value,
                        GiaBan = numDonGia.Value,
                        HinhAnh = Path.GetFileName(picHinhAnh.ImageLocation),
                        MoTa = txtMoTa.Text
                    };
                    context.Xes.Add(xe);
                    context.SaveChanges();
                }
                else
                {
                    Xe? xe = context.Xes.Find(id);
                    if (xe != null)
                    {
                        xe.TenXe = txtTenXe.Text;
                        xe.HangXeID = cboHangXe.SelectedValue is int hangXeId ? hangXeId : 0;
                        xe.LoaiXeID = cboPhanLoai.SelectedValue is int loaiXeId ? loaiXeId : 0;
                        xe.SoLuong = (int)numSoLuong.Value;
                        xe.GiaBan = numDonGia.Value;
                        xe.HinhAnh = Path.GetFileName(picHinhAnh.ImageLocation);
                        xe.MoTa = txtMoTa.Text;
                        context.SaveChanges();
                    }
                }

                frmSanPham_Load(sender, e);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cboPhanLoai.Text = "";
            cboHangXe.Text = "";
            txtTenXe.Clear();
            txtMoTa.Clear();
            numSoLuong.Value = 0;
            numDonGia.Value = 0;
            picHinhAnh.Image = null;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is QuanLyBanTraGopXeHonda.Data.Xe selected)
            {
                var xe = context.Xes.Find(selected.ID);
                if (xe != null)
                {
                    context.Xes.Remove(xe);
                    context.SaveChanges();
                    frmSanPham_Load(sender, e);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmSanPham_Load(sender, e);
        }
        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);
                string fileSavePath = Path.Combine(imagesFolder, fileName + ext);
                File.Copy(openFileDialog.FileName, fileSavePath, true);

                var currentRow = dataGridView1.CurrentRow;
                if (currentRow != null && currentRow.Cells["ID"]?.Value != null)
                {
                    id = Convert.ToInt32(currentRow.Cells["ID"]!.Value!.ToString());
                    Xe? xe = context.Xes.Find(id);

                    if (xe != null)
                    {
                        xe.HinhAnh = fileName + ext;
                        context.Xes.Update(xe);

                        context.SaveChanges();
                        frmSanPham_Load(sender, e);
                    }
                }
            }
        }
    }
}
