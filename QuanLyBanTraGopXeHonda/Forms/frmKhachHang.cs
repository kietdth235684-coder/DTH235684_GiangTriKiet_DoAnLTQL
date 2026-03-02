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
using QuanLyBanTraGopXeHonda.Forms;

namespace QuanLyBanTraGopXeHonda.Forms
{
    public partial class KhachHang : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        bool xuLyThem = false;
        int id;
        public KhachHang()
        {
            InitializeComponent();
        }
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
            BatTatChucNang(false);

            var kh = context.KhachHangs.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = kh;

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);

            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);

            txtCCCD.DataBindings.Clear();
            txtCCCD.DataBindings.Add("Text", bindingSource, "CCCD", false, DataSourceUpdateMode.Never);
            dataGridView1.DataSource = bindingSource;
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtCCCD.Clear();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is QuanLyBanTraGopXeHonda.Data.KhachHang selected)
            {
                id = selected.ID;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row?.DataBoundItem is QuanLyBanTraGopXeHonda.Data.KhachHang selected)
            {
                var khachHang = context.KhachHangs.Find(selected.ID);
                if (khachHang != null)
                {
                    context.KhachHangs.Remove(khachHang);
                    context.SaveChanges();
                    frmKhachHang_Load(sender, e);
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (xuLyThem)
            {
                var khachHang = new QuanLyBanTraGopXeHonda.Data.KhachHang
                {
                    HoVaTen = txtHoVaTen.Text,
                    DienThoai = txtDienThoai.Text,
                    DiaChi = txtDiaChi.Text,
                    CCCD = txtCCCD.Text
                };
                context.KhachHangs.Add(khachHang);
            }
            else
            {
                var khachHang = context.KhachHangs.Find(id);
                if (khachHang != null)
                {
                    khachHang.HoVaTen = txtHoVaTen.Text;
                    khachHang.DienThoai = txtDienThoai.Text;
                    khachHang.DiaChi = txtDiaChi.Text;
                    khachHang.CCCD = txtCCCD.Text;
                }
            }
            context.SaveChanges();
            frmKhachHang_Load(sender, e);
        }

        private void BtnHuyBo_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
        }
    }
}
