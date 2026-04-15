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
            optionsBuilder.UseSqlServer(connectionString, sqlOptions => {
                sqlOptions.CommandTimeout(60);
            });
        }

        public void ReseedTable(string tableName)
        {
            try
            {
                // SQL command to find the current maximum ID in the table
                string sqlMax = $"SELECT ISNULL(MAX(ID), 0) FROM {tableName}";
                var result = this.Database.SqlQueryRaw<int>(sqlMax).ToList();
                int maxId = result.Count > 0 ? result[0] : 0;

                // Reseed identity to maxId
                // If maxId is 0, the next ID will be 1.
                this.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('{tableName}', RESEED, {maxId})");
            }
            catch (Exception)
            {
                // Silently fail or log if the table doesn't have an IDENTITY column
            }
        }
    }
}
