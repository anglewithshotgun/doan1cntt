using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Nxb> Nxb { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<Tacgia> Tacgia { get; set; }
        public virtual DbSet<Taikhoan> Taikhoan { get; set; }
        public virtual DbSet<Thanhvien> Thanhvien { get; set; }
        public virtual DbSet<Theloai> Theloai { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
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
                    .IsFixedLength();

                entity.Property(e => e.SoHd).HasColumnName("SoHD");

                entity.HasOne(d => d.SoHdNavigation)
                    .WithMany(p => p.Chitiethoadon)
                    .HasForeignKey(d => d.SoHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETHOADON_HOADON");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.SoHd);

                entity.ToTable("HOADON");

                entity.Property(e => e.SoHd)
                    .HasColumnName("SoHD")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NgayBan).HasColumnType("date");

                entity.Property(e => e.TenKh).HasMaxLength(50);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_HOADON_NHANVIEN");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.NgSinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.TenNv)
                    .HasColumnName("TenNV")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Nxb>(entity =>
            {
                entity.HasKey(e => e.MaNxb);

                entity.ToTable("NXB");

                entity.Property(e => e.MaNxb)
                    .HasColumnName("MaNXB")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.TenNxb)
                    .HasColumnName("TenNXB")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach);

                entity.ToTable("SACH");

                entity.Property(e => e.MaSach)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaNxb)
                    .IsRequired()
                    .HasColumnName("MaNXB")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaTg)
                    .IsRequired()
                    .HasColumnName("MaTG")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaTl)
                    .IsRequired()
                    .HasColumnName("MaTL")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaNxbNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaNxb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SACH_NXB");

                entity.HasOne(d => d.MaTgNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SACH_TACGIA");
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.MaTg);

                entity.ToTable("TACGIA");

                entity.Property(e => e.MaTg)
                    .HasColumnName("MaTG")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenTg)
                    .HasColumnName("TenTG")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.TaiKhoan1);

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.TaiKhoan1)
                    .HasColumnName("TaiKhoan")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsFixedLength();

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

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenTv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTl);

                entity.ToTable("THELOAI");

                entity.Property(e => e.MaTl)
                    .HasColumnName("MaTL")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.TenTl)
                    .HasColumnName("TenTL")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
