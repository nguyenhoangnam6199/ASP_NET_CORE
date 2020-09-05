using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Data
{
    public class MyDbContext:DbContext
    {
        #region DbSet
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<HangHoaTag> HangHoaTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<HinhPhu> HinhPhus { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HangHoa>(e =>
            {
                e.ToTable("HangHoa");
                e.HasKey(hh => hh.MaHangHoa);
                e.Property(hh => hh.MaHangHoa).HasDefaultValueSql("newid()");   //HasDefault("0");
                e.Property(hh => hh.TenHangHoa).IsRequired().HasMaxLength(100);
                e.Property(hh => hh.ChiTiet).HasMaxLength(200);
                e.HasIndex(hh => hh.TenHangHoa).IsUnique();
                e.HasOne(l => l.Loai).WithMany(lo => lo.HangHoas).HasForeignKey(hh => hh.MaLoai)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<HangHoaTag>(e =>
            {
                e.ToTable("HangHoaTag");
                e.HasKey(hh => new { hh.TagKey, hh.MaHangHoa });
                //định nghĩa mỗi quan hệ
                e.HasOne(hh => hh.HangHoa).WithMany(hht => hht.HangHoaTags)
                    .HasForeignKey(t => t.MaHangHoa);

                e.HasOne(hh => hh.Tag).WithMany(hht => hht.HangHoaTags).HasForeignKey(t => t.TagKey);

            });

            modelBuilder.Entity<Tag>(e =>
            {
                e.ToTable("Tag");
                e.HasKey(e => e.TagKey);
                e.Property(e => e.TagKey).HasMaxLength(50);
            });

            modelBuilder.Entity<Loai>(entity =>
            {
                entity.ToTable("Loai");
                entity.Property(l => l.TenLoai).IsRequired()
                    .HasMaxLength(100);
                entity.HasKey(l => l.MaLoai);
                
            });

            modelBuilder.Entity<HinhPhu>(e =>
            {
                e.HasOne(hh => hh.HangHoa).WithMany(hh => hh.HinhPhus).HasForeignKey(h => h.MaHangHoa);
            });

        }
        public MyDbContext(DbContextOptions opt): base(opt)
        {

        }
    }
}
