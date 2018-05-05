namespace WebsiteSonGaming.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SonGamingCodeFirst : DbContext
    {
        public SonGamingCodeFirst()
            : base("name=SonGamingCodeFirst")
        {
        }

        public virtual DbSet<ADMIN> ADMIN { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADON { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAM { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUAT { get; set; }
        public virtual DbSet<SANPHAM> SANPHAM { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.HOADON)
                .WithOptional(e => e.KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LOAISANPHAM>()
                .HasMany(e => e.SANPHAM)
                .WithOptional(e => e.LOAISANPHAM)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NHASANXUAT>()
                .HasMany(e => e.SANPHAM)
                .WithOptional(e => e.NHASANXUAT)
                .WillCascadeOnDelete();
        }
    }
}
