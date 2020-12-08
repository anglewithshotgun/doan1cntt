using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLchSach.Models
{
    public partial class Dtb_NhaSachContext : DbContext
    {
        public Dtb_NhaSachContext()
        {
        }

        public Dtb_NhaSachContext(DbContextOptions<Dtb_NhaSachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Nxb> Nxbs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Tacgium> Tacgia { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<Thanhvien> Thanhviens { get; set; }
        public virtual DbSet<Theloai> Theloais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-CBH7IMS;Database=Dtb_NhaSach;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.MaSach, e.SoHd });

                entity.ToTable("CHITIETHOADON");

                entity.Property(e => e.MaSach)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SoHd).HasColumnName("SoHD");

                entity.HasOne(d => d.SoHdNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.SoHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETHOADON_HOADON");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.SoHd);

                entity.ToTable("HOADON");

                entity.Property(e => e.SoHd)
                    .ValueGeneratedNever()
                    .HasColumnName("SoHD");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayBan).HasColumnType("datetime");

                entity.Property(e => e.TenKh).HasMaxLength(50);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_HOADON_NHANVIEN");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.NgSinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<Nxb>(entity =>
            {
                entity.HasKey(e => e.MaNxb);

                entity.ToTable("NXB");

                entity.Property(e => e.MaNxb)
                    .HasMaxLength(10)
                    .HasColumnName("MaNXB")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.TenNxb)
                    .HasMaxLength(50)
                    .HasColumnName("TenNXB");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach);

                entity.ToTable("SACH");

                entity.Property(e => e.MaSach)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaNxb)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaNXB")
                    .IsFixedLength(true);

                entity.Property(e => e.MaTg)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaTG")
                    .IsFixedLength(true);

                entity.Property(e => e.MaTl)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaTL")
                    .IsFixedLength(true);

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaNxbNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaNxb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SACH_NXB");

                entity.HasOne(d => d.MaTgNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaTg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SACH_TACGIA");
            });

            modelBuilder.Entity<Tacgium>(entity =>
            {
                entity.HasKey(e => e.MaTg);

                entity.ToTable("TACGIA");

                entity.Property(e => e.MaTg)
                    .HasMaxLength(10)
                    .HasColumnName("MaTG")
                    .IsFixedLength(true);

                entity.Property(e => e.TenTg)
                    .HasMaxLength(50)
                    .HasColumnName("TenTG");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan1);

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.TaiKhoan1)
                    .HasMaxLength(10)
                    .HasColumnName("TaiKhoan")
                    .IsFixedLength(true);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.TaiKhoan1Navigation)
                    .WithOne(p => p.Taikhoan)
                    .HasForeignKey<Taikhoan>(d => d.TaiKhoan1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TAIKHOAN_NHANVIEN");
            });

            modelBuilder.Entity<Thanhvien>(entity =>
            {
                entity.HasKey(e => e.MaTv);

                entity.ToTable("THANHVIEN");

                entity.Property(e => e.MaTv).ValueGeneratedNever();

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.TenTv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTl);

                entity.ToTable("THELOAI");

                entity.Property(e => e.MaTl)
                    .HasMaxLength(30)
                    .HasColumnName("MaTL")
                    .IsFixedLength(true);

                entity.Property(e => e.TenTl)
                    .HasMaxLength(50)
                    .HasColumnName("TenTL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
