using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanTraGopXeHonda.Data
{
    public class KhachHang
    {
        public int ID { get; set; }
        public required string HoVaTen { get; set; }
        public string? CCCD { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }

        public virtual ObservableCollectionListSource<HopDong> HopDong { get; } = new();
    }
}
