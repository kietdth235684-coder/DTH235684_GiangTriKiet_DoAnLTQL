using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanTraGopXeHonda.Data
{
    public class HopDong_ChiTiet
    {
        public int ID { get; set; }
        public int HopDongID { get; set; }
        public int XeID { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int SoThangThanhToan { get; set; }
        public decimal SoTienThanhToan { get; set; }
        public virtual HopDong HopDong { get; set; } = null;

        public virtual Xe Xe { get; set; } = null;
    }
}
