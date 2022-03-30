using MarketAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace MarketAPI.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<LoaiGianHang> LoaiGianHang { get; set; }
        public DbSet<GianHang> GianHang { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<NguoiGiaoHang> NguoiGiaoHang { get; set; }
        public DbSet<TinhTrangVanDon> TinhTrangVanDon { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<GiayTo> GiayTo { get; set; }
        public DbSet<DoanhThu> DoanhThu { get; set; }
        public DbSet<TongQuanDoanhThu> TongQuanDoanhThu { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public DbSet<UuDai> UuDai { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>().ToTable("NHANVIEN");
            modelBuilder.Entity<LoaiGianHang>().ToTable("LOAIGIANHANG");
            modelBuilder.Entity<GianHang>().ToTable("GIANHANG");
            modelBuilder.Entity<LoaiSanPham>().ToTable("LOAISANPHAM");
            modelBuilder.Entity<SanPham>().ToTable("SANPHAM");
            modelBuilder.Entity<NguoiGiaoHang>().ToTable("NGUOIGIAOHANG");
            modelBuilder.Entity<TinhTrangVanDon>().ToTable("TINHTRANGVANDON");
            modelBuilder.Entity<DonHang>().ToTable("DONHANG");
            modelBuilder.Entity<GiayTo>().ToTable("GIAYTO");
            modelBuilder.Entity<KhachHang>().ToTable("KHACHHANG");
            modelBuilder.Entity<ChiTietDonHang>().ToTable("CHITIETDONHANG");
            modelBuilder.Entity<UuDai>().ToTable("UUDAI");
        }

    }
}
