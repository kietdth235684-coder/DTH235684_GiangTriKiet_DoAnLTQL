using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanTraGopXeHonda.Data
{
    public class LoaiXe
    {
        public int ID { get; set; }
        public required string TenLX { get; set; }
        public virtual ObservableCollectionListSource<Xe> Xe { get; } = new();
    }
}
