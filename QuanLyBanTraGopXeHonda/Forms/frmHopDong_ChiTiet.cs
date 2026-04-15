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
    public partial class frmHopDong_ChiTiet : Form
    {
        QLBXDbContext context = new QLBXDbContext();
        int id; // Ma hop dong (0 = them moi)
        BindingList<DanhSachHopDong_ChiTiet> hopDongChiTiet = new BindingList<DanhSachHopDong_ChiTiet>();

        public frmHopDong_ChiTiet(int maHopDong = 0)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            id = maHopDong;
        }

        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanViens.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
        }

        public void LayKhachHangVaoComboBox()
        {
            cboKhachHang.DataSource = context.KhachHangs.ToList();
            cboKhachHang.ValueMember = "ID";
            cboKhachHang.DisplayMember = "HoVaTen";
        }

        public void LayXeVaoComboBox()
        {
            cboXe.DataSource = context.Xes.ToList();
            cboXe.ValueMember = "ID";
            cboXe.DisplayMember = "TenXe";
        }

        public void BatTatNut()
        {
            bool coDuLieu = dataGridView.Rows.Count > 0;
            btnLuuHopDong.Enabled = coDuLieu;
            btnXoa.Enabled = coDuLieu;
        }

        private void frmHopDong_ChiTiet_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayKhachHangVaoComboBox();
            LayXeVaoComboBox();
            dataGridView.AutoGenerateColumns = false;

            if (id != 0) // Sua hop dong cu
            {
                var hd = context.HopDongs.Where(r => r.ID == id).SingleOrDefault();
                if (hd != null)
                {
                    cboNhanVien.SelectedValue = hd.NhanVienID;
                    cboKhachHang.SelectedValue = hd.KhachHangID;
                    cboXe.SelectedValue = hd.XeID;
                    dtpNgayLap.Value = hd.NgayLapHD;

                    var ct = context.HopDong_ChiTiets
                        .Where(r => r.HopDongID == id)
                        .Select(r => new DanhSachHopDong_ChiTiet
                        {
                            ID = r.ID,
                            HopDongID = r.HopDongID,
                            XeID = r.XeID,
                            TenXe = r.Xe.TenXe,
                            NgayThanhToan = r.NgayThanhToan,
                            SoThangThanhToan = r.SoThangThanhToan,
                            SoTienThanhToan = r.SoTienThanhToan,
                            ThanhTien = r.SoTienThanhToan
                        }).ToList();

                    hopDongChiTiet = new BindingList<DanhSachHopDong_ChiTiet>(ct);
                }
            }
            else
            {
                // Them moi: reset form
                cboNhanVien.SelectedIndex = 0;
                cboKhachHang.SelectedIndex = 0;
                cboXe.SelectedIndex = 0;
                dtpNgayLap.Value = DateTime.Now;
                dtpNgayThanhToan.Value = DateTime.Now;
                numSoThang.Value = 12;
                numSoTien.Value = 0;
                hopDongChiTiet = new BindingList<DanhSachHopDong_ChiTiet>();
            }

            dataGridView.DataSource = hopDongChiTiet;
            BatTatNut();
        }

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (cboXe.SelectedValue == null)
            {
                MessageBox.Show("Vui long chon xe.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numSoThang.Value <= 0)
            {
                MessageBox.Show("So thang thanh toan phai lon hon 0.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numSoTien.Value <= 0)
            {
                MessageBox.Show("So tien thanh toan phai lon hon 0.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maXe = Convert.ToInt32(cboXe.SelectedValue);
            var chiTiet = hopDongChiTiet.FirstOrDefault(x => x.XeID == maXe);

            if (chiTiet != null)
            {
                // Cap nhat neu da ton tai
                chiTiet.NgayThanhToan = dtpNgayThanhToan.Value;
                chiTiet.SoThangThanhToan = (int)numSoThang.Value;
                chiTiet.SoTienThanhToan = numSoTien.Value;
                chiTiet.ThanhTien = numSoTien.Value;
                dataGridView.Refresh();
            }
            else
            {
                // Them moi
                DanhSachHopDong_ChiTiet ct = new DanhSachHopDong_ChiTiet
                {
                    ID = 0,
                    HopDongID = id,
                    XeID = maXe,
                    TenXe = cboXe.Text,
                    NgayThanhToan = dtpNgayThanhToan.Value,
                    SoThangThanhToan = (int)numSoThang.Value,
                    SoTienThanhToan = numSoTien.Value,
                    ThanhTien = numSoTien.Value
                };
                hopDongChiTiet.Add(ct);
            }

            BatTatNut();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            int maXe = Convert.ToInt32(dataGridView.CurrentRow.Cells["XeID"].Value.ToString());
            var chiTiet = hopDongChiTiet.FirstOrDefault(x => x.XeID == maXe);
            if (chiTiet != null)
            {
                hopDongChiTiet.Remove(chiTiet);
            }
            BatTatNut();
        }

        private void btnLuuHopDong_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null || string.IsNullOrWhiteSpace(cboNhanVien.Text))
            {
                MessageBox.Show("Vui long chon nhan vien lap hop dong.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboKhachHang.SelectedValue == null || string.IsNullOrWhiteSpace(cboKhachHang.Text))
            {
                MessageBox.Show("Vui long chon khach hang.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboXe.SelectedValue == null || string.IsNullOrWhiteSpace(cboXe.Text))
            {
                MessageBox.Show("Vui long chon xe.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (hopDongChiTiet.Count == 0)
            {
                MessageBox.Show("Vui long them it nhat mot ky thanh toan.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id != 0) // Cap nhat hop dong cu
            {
                HopDong? hd = context.HopDongs.Find(id);
                if (hd != null)
                {
                    hd.NhanVienID = (int)cboNhanVien.SelectedValue;
                    hd.KhachHangID = (int)cboKhachHang.SelectedValue;
                    hd.XeID = (int)cboXe.SelectedValue;
                    hd.NgayLapHD = dtpNgayLap.Value;
                    context.HopDongs.Update(hd);

                    // Xoa chi tiet cu
                    var oldCT = context.HopDong_ChiTiets.Where(r => r.HopDongID == id).ToList();
                    context.HopDong_ChiTiets.RemoveRange(oldCT);

                    // Them chi tiet moi
                    foreach (var item in hopDongChiTiet.ToList())
                    {
                        HopDong_ChiTiet ct = new HopDong_ChiTiet
                        {
                            HopDongID = id,
                            XeID = item.XeID,
                            NgayThanhToan = item.NgayThanhToan,
                            SoThangThanhToan = item.SoThangThanhToan,
                            SoTienThanhToan = item.SoTienThanhToan
                        };
                        context.HopDong_ChiTiets.Add(ct);
                    }

                    context.SaveChanges();
                    context.ReseedTable("HopDong_ChiTiets");
                }
            }
            else // Them moi hop dong
            {
                HopDong hd = new HopDong
                {
                    NhanVienID = (int)cboNhanVien.SelectedValue,
                    KhachHangID = (int)cboKhachHang.SelectedValue,
                    XeID = (int)cboXe.SelectedValue,
                    NgayLapHD = dtpNgayLap.Value
                };
                context.HopDongs.Add(hd);
                context.SaveChanges();

                // Them chi tiet
                foreach (var item in hopDongChiTiet.ToList())
                {
                    HopDong_ChiTiet ct = new HopDong_ChiTiet
                    {
                        HopDongID = hd.ID,
                        XeID = item.XeID,
                        NgayThanhToan = item.NgayThanhToan,
                        SoThangThanhToan = item.SoThangThanhToan,
                        SoTienThanhToan = item.SoTienThanhToan
                    };
                    context.HopDong_ChiTiets.Add(ct);
                }
                context.SaveChanges();
            }

            MessageBox.Show("Da luu hop dong thanh cong!", "Hoan tat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmHopDong_ChiTiet_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHopDong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuc nang in hop dong dang duoc phat trien.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CapNhatSoTienThanhToan()
        {
            if (cboXe.SelectedValue != null && numSoThang.Value > 0)
            {
                int maXe = (int)cboXe.SelectedValue;
                var xe = context.Xes.Find(maXe);
                if (xe != null)
                {
                    decimal tongTien = xe.GiaBan;
                    int soThang = (int)numSoThang.Value;
                    // Tinh so tien moi thang, lam tron ve 0 chu so thap phan cho VND
                    numSoTien.Value = Math.Round(tongTien / soThang, 0);
                }
            }
        }

        private void cboXe_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CapNhatSoTienThanhToan();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatSoTienThanhToan();
        }
    }
}
