using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanTraGopXeHonda.Data
{
    public class HopDong
    {
        public int ID { get; set; }
        public int KhachHangID { get; set; }
        public int NhanVienID { get; set; }
        public int XeID { get; set; }
        public DateTime NgayLapHD { get; set; }

        public virtual ObservableCollectionListSource<HopDong_ChiTiet> HopDong_ChiTiet { get; } = new();

        public virtual KhachHang? KhachHang { get; set; }

        public virtual NhanVien? NhanVien { get; set; }

        public virtual Xe? Xe { get; set; }
    }

    [NotMapped]
    public class DanhSachHopDong
    {
        public int ID { get; set; }
        public int ID_Goc { get; set; }
        public int NhanVienID { get; set; }
        public string HoVaTenNhanVien { get; set; }
        public int KhachHangID { get; set; }
        public string HoVaTenKhachHang { get; set; }
        public int XeID { get; set; }
        public string TenXe { get; set; }
        public DateTime NgayLapHD { get; set; }
        public decimal TongTienHopDong { get; set; }
        public string XemChiTiet { get; set; }
    }
}
