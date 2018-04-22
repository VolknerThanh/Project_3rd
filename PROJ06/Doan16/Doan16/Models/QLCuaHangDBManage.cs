namespace Doan16.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLCuaHangDBManage : DbContext
    {
        public QLCuaHangDBManage()
            : base("name=QLCuaHangDB")
        {
        }

        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTietPhieuGiaoHang> ChiTietPhieuGiaoHangs { get; set; }
        public virtual DbSet<ChiTietPhieuHen> ChiTietPhieuHens { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiNGK> LoaiNGKs { get; set; }
        public virtual DbSet<NhaCungUng> NhaCungUngs { get; set; }
        public virtual DbSet<NuocGK> NuocGKs { get; set; }
        public virtual DbSet<PhieuGiaoHang> PhieuGiaoHangs { get; set; }
        public virtual DbSet<PhieuHen> PhieuHens { get; set; }
        public virtual DbSet<PhieuTraNo> PhieuTraNoes { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonDatHang>()
                .HasMany(e => e.ChiTietDonDatHangs)
                .WithRequired(e => e.DonDatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.soHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiNGK>()
                .HasMany(e => e.NuocGKs)
                .WithOptional(e => e.LoaiNGK)
                .HasForeignKey(e => e.nhanhieuNGK);

            modelBuilder.Entity<NhaCungUng>()
                .HasMany(e => e.DonDatHangs)
                .WithOptional(e => e.NhaCungUng1)
                .HasForeignKey(e => e.NhaCungUng);

            modelBuilder.Entity<NhaCungUng>()
                .HasMany(e => e.LoaiNGKs)
                .WithOptional(e => e.NhaCungUng1)
                .HasForeignKey(e => e.NhaCungUng);

            modelBuilder.Entity<NuocGK>()
                .HasMany(e => e.ChiTietDonDatHangs)
                .WithRequired(e => e.NuocGK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NuocGK>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.NuocGK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NuocGK>()
                .HasMany(e => e.ChiTietPhieuGiaoHangs)
                .WithRequired(e => e.NuocGK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NuocGK>()
                .HasMany(e => e.ChiTietPhieuHens)
                .WithRequired(e => e.NuocGK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuGiaoHang>()
                .HasMany(e => e.ChiTietPhieuGiaoHangs)
                .WithRequired(e => e.PhieuGiaoHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuHen>()
                .HasMany(e => e.ChiTietPhieuHens)
                .WithRequired(e => e.PhieuHen)
                .WillCascadeOnDelete(false);
        }
    }
}
