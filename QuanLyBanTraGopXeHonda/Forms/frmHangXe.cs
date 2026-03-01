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

        public frmHangXe()
        {
            InitializeComponent();
        }
        private void frmHangXe_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            var lx = context.LoaiXes.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = lx;

            dataGridView1.DataSource = bindingSource;

            // Hiển thị dữ liệu dòng đầu tiên lên controls nếu có
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                HienThiDuLieuLenControls();
            }
            else
            {
                txtTenHangXe.Clear();
            }
        }
        private void HienThiDuLieuLenControls()
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is LoaiXe lx)
            {
                txtTenHangXe.Text = lx.TenLX;
                id = lx.ID;
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
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is LoaiXe selected)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hãng xe '{selected.TenLX}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    context.LoaiXes.Remove(selected);
                    context.SaveChanges();
                    frmHangXe_Load(sender, e); // Tải lại dữ liệu sau khi xóa
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
                LoaiXe newLoaiXe = new LoaiXe
                {
                    TenLX = txtTenHangXe.Text
                };
                context.LoaiXes.Add(newLoaiXe);
            }
            else
            {
                var existingLoaiXe = context.LoaiXes.Find(id);
                if (existingLoaiXe != null)
                {
                    existingLoaiXe.TenLX = txtTenHangXe.Text;
                    context.LoaiXes.Update(existingLoaiXe);
                }
            }
            context.SaveChanges();
            frmHangXe_Load(sender, e); // Tải lại dữ liệu sau khi lưu
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            HienThiDuLieuLenControls();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
