using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanTraGopXeHonda.Data
{
    public class QLBXDbContext : DbContext
    {  
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<HopDong_ChiTiet> HopDong_ChiTiets { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<HangXe> HangXes { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QLBXConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
