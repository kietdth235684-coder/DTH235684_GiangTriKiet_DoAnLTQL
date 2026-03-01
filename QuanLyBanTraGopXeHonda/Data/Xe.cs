using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanTraGopXeHonda.Data
{
    public class Xe
    {
        public int ID { get; set; }
        public required string TenXe { get; set; }
        public int HangXeID { get; set; }
        public int LoaiXeID { get; set; }
        public string? MauSac { get; set; }
        public string? SoKhung { get; set; }
        public string? SoMay { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
        public int NamSanXuat { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
        public virtual ObservableCollectionListSource<HopDong_ChiTiet> HopDong_ChiTiet { get; } = new();

        public virtual HangXe HangXe { get; set; } = null!;

        public virtual LoaiXe LoaiXe { get; set; } = null!;

    }
}
