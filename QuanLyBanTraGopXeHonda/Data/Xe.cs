using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBanTraGopXeHonda.Data
{
    public class Xe
    {
        public int ID { get; set; }
        public required string TenXe { get; set; }
        public int HangXeID { get; set; }
        public int LoaiXeID { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
        public virtual ObservableCollectionListSource<HopDong_ChiTiet> HopDong_ChiTiet { get; } = new();

        public virtual HangXe HangXes { get; set; } = null!;

        public virtual LoaiXe LoaiXes { get; set; } = null!;

    }

    [NotMapped]
    public class  DanhSachXe
    {
        public int ID { get; set; }
        public int HangXeID { get; set; }
        public string? TenHX { get; set; }

        public int LoaiXeID { get; set; }
        public string? TenLX { get; set; }

        public string? TenXe { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }

        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
    }
}
