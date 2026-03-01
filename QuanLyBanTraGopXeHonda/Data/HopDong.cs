using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
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
    }
}   