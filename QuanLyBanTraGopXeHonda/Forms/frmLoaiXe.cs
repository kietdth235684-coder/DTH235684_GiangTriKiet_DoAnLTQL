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
            List<LoaiXe> lx = new List<LoaiXe>();
            lx = context.LoaiXes.ToList();
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
            {
                id = selected.ID;
            }
            else
            {
                MessageBox.Show("Không có dòng nào được chọn hoặc giá trị ID bị thiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    LoaiXe lsp = new LoaiXe
                    {
                        TenLX = txtTenLoai.Text
                    };
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
                if (MessageBox.Show("Xác nhận xóa loại sản phẩm?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoaiXe? lsp = context.LoaiXes.Find(selected.ID);
                    if (lsp != null)
                    {
                        context.LoaiXes.Remove(lsp);
                        context.SaveChanges();
                    }

                    frmLoaiXe_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Không có dòng nào được chọn hoặc giá trị ID bị thiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmLoaiXe_Load(sender, e);
        }
        public frmLoaiXe()
        {
            InitializeComponent();
        }
    }
}
