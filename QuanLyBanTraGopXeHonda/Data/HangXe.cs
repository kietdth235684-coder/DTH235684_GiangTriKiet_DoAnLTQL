using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanTraGopXeHonda.Data
{
    public class HangXe
    {
        public int ID { get; set; }
        public required string TenHX { get; set; }
        public virtual ObservableCollectionListSource<Xe> Xe { get; } = new();
    }
}
